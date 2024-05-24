using System;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200081A RID: 2074
	internal class WorkItem
	{
		// Token: 0x060058FC RID: 22780 RVA: 0x001398A8 File Offset: 0x00137AA8
		[SecurityCritical]
		internal WorkItem(IMessage reqMsg, IMessageSink nextSink, IMessageSink replySink)
		{
			this._reqMsg = reqMsg;
			this._replyMsg = null;
			this._nextSink = nextSink;
			this._replySink = replySink;
			this._ctx = Thread.CurrentContext;
			this._callCtx = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
		}

		// Token: 0x060058FD RID: 22781 RVA: 0x001398F7 File Offset: 0x00137AF7
		internal virtual void SetWaiting()
		{
			this._flags |= 1;
		}

		// Token: 0x060058FE RID: 22782 RVA: 0x00139907 File Offset: 0x00137B07
		internal virtual bool IsWaiting()
		{
			return (this._flags & 1) == 1;
		}

		// Token: 0x060058FF RID: 22783 RVA: 0x00139914 File Offset: 0x00137B14
		internal virtual void SetSignaled()
		{
			this._flags |= 2;
		}

		// Token: 0x06005900 RID: 22784 RVA: 0x00139924 File Offset: 0x00137B24
		internal virtual bool IsSignaled()
		{
			return (this._flags & 2) == 2;
		}

		// Token: 0x06005901 RID: 22785 RVA: 0x00139931 File Offset: 0x00137B31
		internal virtual void SetAsync()
		{
			this._flags |= 4;
		}

		// Token: 0x06005902 RID: 22786 RVA: 0x00139941 File Offset: 0x00137B41
		internal virtual bool IsAsync()
		{
			return (this._flags & 4) == 4;
		}

		// Token: 0x06005903 RID: 22787 RVA: 0x0013994E File Offset: 0x00137B4E
		internal virtual void SetDummy()
		{
			this._flags |= 8;
		}

		// Token: 0x06005904 RID: 22788 RVA: 0x0013995E File Offset: 0x00137B5E
		internal virtual bool IsDummy()
		{
			return (this._flags & 8) == 8;
		}

		// Token: 0x06005905 RID: 22789 RVA: 0x0013996C File Offset: 0x00137B6C
		[SecurityCritical]
		internal static object ExecuteCallback(object[] args)
		{
			WorkItem workItem = (WorkItem)args[0];
			if (workItem.IsAsync())
			{
				workItem._nextSink.AsyncProcessMessage(workItem._reqMsg, workItem._replySink);
			}
			else if (workItem._nextSink != null)
			{
				workItem._replyMsg = workItem._nextSink.SyncProcessMessage(workItem._reqMsg);
			}
			return null;
		}

		// Token: 0x06005906 RID: 22790 RVA: 0x001399C4 File Offset: 0x00137BC4
		[SecurityCritical]
		internal virtual void Execute()
		{
			Thread.CurrentThread.InternalCrossContextCallback(this._ctx, WorkItem._xctxDel, new object[]
			{
				this
			});
		}

		// Token: 0x17000EC2 RID: 3778
		// (get) Token: 0x06005907 RID: 22791 RVA: 0x001399E6 File Offset: 0x00137BE6
		internal virtual IMessage ReplyMessage
		{
			get
			{
				return this._replyMsg;
			}
		}

		// Token: 0x04002885 RID: 10373
		private const int FLG_WAITING = 1;

		// Token: 0x04002886 RID: 10374
		private const int FLG_SIGNALED = 2;

		// Token: 0x04002887 RID: 10375
		private const int FLG_ASYNC = 4;

		// Token: 0x04002888 RID: 10376
		private const int FLG_DUMMY = 8;

		// Token: 0x04002889 RID: 10377
		internal int _flags;

		// Token: 0x0400288A RID: 10378
		internal IMessage _reqMsg;

		// Token: 0x0400288B RID: 10379
		internal IMessageSink _nextSink;

		// Token: 0x0400288C RID: 10380
		internal IMessageSink _replySink;

		// Token: 0x0400288D RID: 10381
		internal IMessage _replyMsg;

		// Token: 0x0400288E RID: 10382
		internal Context _ctx;

		// Token: 0x0400288F RID: 10383
		[SecurityCritical]
		internal LogicalCallContext _callCtx;

		// Token: 0x04002890 RID: 10384
		internal static InternalCrossContextDelegate _xctxDel = new InternalCrossContextDelegate(WorkItem.ExecuteCallback);
	}
}
