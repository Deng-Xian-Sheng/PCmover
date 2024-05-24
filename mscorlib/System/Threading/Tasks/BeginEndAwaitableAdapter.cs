using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x02000587 RID: 1415
	internal sealed class BeginEndAwaitableAdapter : ICriticalNotifyCompletion, INotifyCompletion
	{
		// Token: 0x06004296 RID: 17046 RVA: 0x000F834A File Offset: 0x000F654A
		public BeginEndAwaitableAdapter GetAwaiter()
		{
			return this;
		}

		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06004297 RID: 17047 RVA: 0x000F834D File Offset: 0x000F654D
		public bool IsCompleted
		{
			get
			{
				return this._continuation == BeginEndAwaitableAdapter.CALLBACK_RAN;
			}
		}

		// Token: 0x06004298 RID: 17048 RVA: 0x000F835F File Offset: 0x000F655F
		[SecurityCritical]
		public void UnsafeOnCompleted(Action continuation)
		{
			this.OnCompleted(continuation);
		}

		// Token: 0x06004299 RID: 17049 RVA: 0x000F8368 File Offset: 0x000F6568
		public void OnCompleted(Action continuation)
		{
			if (this._continuation == BeginEndAwaitableAdapter.CALLBACK_RAN || Interlocked.CompareExchange<Action>(ref this._continuation, continuation, null) == BeginEndAwaitableAdapter.CALLBACK_RAN)
			{
				Task.Run(continuation);
			}
		}

		// Token: 0x0600429A RID: 17050 RVA: 0x000F839C File Offset: 0x000F659C
		public IAsyncResult GetResult()
		{
			IAsyncResult asyncResult = this._asyncResult;
			this._asyncResult = null;
			this._continuation = null;
			return asyncResult;
		}

		// Token: 0x04001BB1 RID: 7089
		private static readonly Action CALLBACK_RAN = delegate()
		{
		};

		// Token: 0x04001BB2 RID: 7090
		private IAsyncResult _asyncResult;

		// Token: 0x04001BB3 RID: 7091
		private Action _continuation;

		// Token: 0x04001BB4 RID: 7092
		public static readonly AsyncCallback Callback = delegate(IAsyncResult asyncResult)
		{
			BeginEndAwaitableAdapter beginEndAwaitableAdapter = (BeginEndAwaitableAdapter)asyncResult.AsyncState;
			beginEndAwaitableAdapter._asyncResult = asyncResult;
			Action action = Interlocked.Exchange<Action>(ref beginEndAwaitableAdapter._continuation, BeginEndAwaitableAdapter.CALLBACK_RAN);
			if (action != null)
			{
				action();
			}
		};
	}
}
