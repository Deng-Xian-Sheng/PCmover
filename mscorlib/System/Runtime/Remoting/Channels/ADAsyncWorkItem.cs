using System;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000838 RID: 2104
	internal class ADAsyncWorkItem
	{
		// Token: 0x060059EC RID: 23020 RVA: 0x0013D1E3 File Offset: 0x0013B3E3
		[SecurityCritical]
		internal ADAsyncWorkItem(IMessage reqMsg, IMessageSink nextSink, IMessageSink replySink)
		{
			this._reqMsg = reqMsg;
			this._nextSink = nextSink;
			this._replySink = replySink;
			this._callCtx = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
		}

		// Token: 0x060059ED RID: 23021 RVA: 0x0013D218 File Offset: 0x0013B418
		[SecurityCritical]
		internal virtual void FinishAsyncWork(object stateIgnored)
		{
			LogicalCallContext logicalCallContext = CallContext.SetLogicalCallContext(this._callCtx);
			IMessage msg = this._nextSink.SyncProcessMessage(this._reqMsg);
			if (this._replySink != null)
			{
				this._replySink.SyncProcessMessage(msg);
			}
			CallContext.SetLogicalCallContext(logicalCallContext);
		}

		// Token: 0x040028EC RID: 10476
		private IMessageSink _replySink;

		// Token: 0x040028ED RID: 10477
		private IMessageSink _nextSink;

		// Token: 0x040028EE RID: 10478
		[SecurityCritical]
		private LogicalCallContext _callCtx;

		// Token: 0x040028EF RID: 10479
		private IMessage _reqMsg;
	}
}
