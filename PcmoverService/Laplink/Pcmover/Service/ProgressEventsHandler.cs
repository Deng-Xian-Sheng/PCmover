using System;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200002E RID: 46
	public class ProgressEventsHandler : ProgressCallbacks, IProgressCallbacks, IDisposable
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600022B RID: 555 RVA: 0x0001012C File Offset: 0x0000E32C
		public ProgressInfo Progress
		{
			get
			{
				object progressLock = this._progressLock;
				ProgressInfo result;
				lock (progressLock)
				{
					result = new ProgressInfo
					{
						TimeStampUtc = DateTime.UtcNow,
						Task = this._taskString,
						TaskCode = (UiCallbackCode)this._taskCode,
						Action = this._actionString,
						ActionCode = (UiCallbackCode)this._actionCode,
						Item = this._itemString,
						ItemCode = (UiCallbackCode)this._itemCode,
						Percentage = this._percentage,
						BytesProcessed = this._bytesProcessed
					};
				}
				return result;
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000101D8 File Offset: 0x0000E3D8
		public ProgressEventsHandler()
		{
			this._pollingLoop = Task.Factory.StartNew(delegate()
			{
				this.PollingLoop();
			}, TaskCreationOptions.LongRunning);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0001024B File Offset: 0x0000E44B
		private void cleanup()
		{
			if (this._pollingLoop != null)
			{
				this._stopEvent.Set();
				this._pollingLoop.Wait();
				this._pollingLoop = null;
				this._stopEvent.Dispose();
				this._stopEvent = null;
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00010288 File Offset: 0x0000E488
		private void PollingLoop()
		{
			while (!this._stopEvent.WaitOne(this._millisecondsTimeout))
			{
				if (this._somethingChanged)
				{
					object progressLock = this._progressLock;
					ProgressInfo progress;
					lock (progressLock)
					{
						progress = this.Progress;
						this._somethingChanged = false;
					}
					this.OnProgressChanged(progress);
				}
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003A90 File Offset: 0x00001C90
		protected virtual void OnProgressChanged(ProgressInfo progressInfo)
		{
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000102F4 File Offset: 0x0000E4F4
		public void OnTaskChanged(UI_CALLBACK_CODE code, string task)
		{
			object progressLock = this._progressLock;
			lock (progressLock)
			{
				this._taskString = task;
				this._taskCode = code;
				this._actionString = "";
				this._actionCode = UI_CALLBACK_CODE.UICC_NoError;
				this._itemString = "";
				this._itemCode = UI_CALLBACK_CODE.UICC_NoError;
				this._somethingChanged = true;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00010368 File Offset: 0x0000E568
		public void OnActionChanged(UI_CALLBACK_CODE code, string action)
		{
			object progressLock = this._progressLock;
			lock (progressLock)
			{
				this._actionString = action;
				this._actionCode = code;
				this._itemString = "";
				this._itemCode = UI_CALLBACK_CODE.UICC_NoError;
				this._somethingChanged = true;
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000103CC File Offset: 0x0000E5CC
		public void OnItemChanged(UI_CALLBACK_CODE code, string item)
		{
			object progressLock = this._progressLock;
			lock (progressLock)
			{
				this._itemString = item;
				this._itemCode = code;
				this._somethingChanged = true;
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0001041C File Offset: 0x0000E61C
		public void OnPercentageChanged(ushort percentage)
		{
			object progressLock = this._progressLock;
			lock (progressLock)
			{
				this._percentage = percentage;
				this._somethingChanged = true;
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00010464 File Offset: 0x0000E664
		public void OnBytesProcessedChanged(ulong bytesProcessed)
		{
			object progressLock = this._progressLock;
			lock (progressLock)
			{
				this._bytesProcessed = bytesProcessed;
				this._somethingChanged = true;
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000104AC File Offset: 0x0000E6AC
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					this.cleanup();
				}
				this.disposedValue = true;
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000104C6 File Offset: 0x0000E6C6
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x040000A7 RID: 167
		private object _progressLock = new object();

		// Token: 0x040000A8 RID: 168
		private bool _somethingChanged;

		// Token: 0x040000A9 RID: 169
		private ushort _percentage;

		// Token: 0x040000AA RID: 170
		private string _taskString = "";

		// Token: 0x040000AB RID: 171
		private UI_CALLBACK_CODE _taskCode;

		// Token: 0x040000AC RID: 172
		private string _actionString = "";

		// Token: 0x040000AD RID: 173
		private UI_CALLBACK_CODE _actionCode;

		// Token: 0x040000AE RID: 174
		private string _itemString = "";

		// Token: 0x040000AF RID: 175
		private UI_CALLBACK_CODE _itemCode;

		// Token: 0x040000B0 RID: 176
		private ulong _bytesProcessed;

		// Token: 0x040000B1 RID: 177
		private Task _pollingLoop;

		// Token: 0x040000B2 RID: 178
		private ManualResetEvent _stopEvent = new ManualResetEvent(false);

		// Token: 0x040000B3 RID: 179
		private int _millisecondsTimeout = 1000;

		// Token: 0x040000B4 RID: 180
		private bool disposedValue;
	}
}
