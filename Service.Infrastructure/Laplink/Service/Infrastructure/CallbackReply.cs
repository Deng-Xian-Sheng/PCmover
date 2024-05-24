using System;
using System.Threading.Tasks;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000002 RID: 2
	public class CallbackReply
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public CallbackReply(IUiCallbackControl manager, Action<int> callbackFunc, int defaultResult)
		{
			this._callbackFunc = callbackFunc;
			this._defaultResult = defaultResult;
			this._manager = manager;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000206D File Offset: 0x0000026D
		public Task<int> CallAsync(int intParameter)
		{
			this._intParameter = intParameter;
			this._taskCompletionSource = new TaskCompletionSource<int>();
			this.Refresh();
			return this._taskCompletionSource.Task;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002094 File Offset: 0x00000294
		public void Refresh()
		{
			if (this._taskCompletionSource == null)
			{
				return;
			}
			if (this._manager.CanSendUiCallback)
			{
				this._callbackFunc(this._intParameter);
				return;
			}
			if (this._manager.UseDefaultUiResponse)
			{
				this.SetResult(this._defaultResult);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020E2 File Offset: 0x000002E2
		public void SetResult(int result)
		{
			this._taskCompletionSource.SetResult(result);
		}

		// Token: 0x04000001 RID: 1
		private readonly IUiCallbackControl _manager;

		// Token: 0x04000002 RID: 2
		private readonly Action<int> _callbackFunc;

		// Token: 0x04000003 RID: 3
		private readonly int _defaultResult;

		// Token: 0x04000004 RID: 4
		private int _intParameter;

		// Token: 0x04000005 RID: 5
		private TaskCompletionSource<int> _taskCompletionSource;
	}
}
