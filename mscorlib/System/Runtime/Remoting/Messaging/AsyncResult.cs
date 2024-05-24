using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000854 RID: 2132
	[ComVisible(true)]
	public class AsyncResult : IAsyncResult, IMessageSink
	{
		// Token: 0x06005A62 RID: 23138 RVA: 0x0013DCA2 File Offset: 0x0013BEA2
		[SecurityCritical]
		internal AsyncResult(Message m)
		{
			m.GetAsyncBeginInfo(out this._acbd, out this._asyncState);
			this._asyncDelegate = (Delegate)m.GetThisPtr();
		}

		// Token: 0x17000F1B RID: 3867
		// (get) Token: 0x06005A63 RID: 23139 RVA: 0x0013DCCD File Offset: 0x0013BECD
		public virtual bool IsCompleted
		{
			get
			{
				return this._isCompleted;
			}
		}

		// Token: 0x17000F1C RID: 3868
		// (get) Token: 0x06005A64 RID: 23140 RVA: 0x0013DCD5 File Offset: 0x0013BED5
		public virtual object AsyncDelegate
		{
			get
			{
				return this._asyncDelegate;
			}
		}

		// Token: 0x17000F1D RID: 3869
		// (get) Token: 0x06005A65 RID: 23141 RVA: 0x0013DCDD File Offset: 0x0013BEDD
		public virtual object AsyncState
		{
			get
			{
				return this._asyncState;
			}
		}

		// Token: 0x17000F1E RID: 3870
		// (get) Token: 0x06005A66 RID: 23142 RVA: 0x0013DCE5 File Offset: 0x0013BEE5
		public virtual bool CompletedSynchronously
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000F1F RID: 3871
		// (get) Token: 0x06005A67 RID: 23143 RVA: 0x0013DCE8 File Offset: 0x0013BEE8
		// (set) Token: 0x06005A68 RID: 23144 RVA: 0x0013DCF0 File Offset: 0x0013BEF0
		public bool EndInvokeCalled
		{
			get
			{
				return this._endInvokeCalled;
			}
			set
			{
				this._endInvokeCalled = value;
			}
		}

		// Token: 0x06005A69 RID: 23145 RVA: 0x0013DCFC File Offset: 0x0013BEFC
		private void FaultInWaitHandle()
		{
			lock (this)
			{
				if (this._AsyncWaitHandle == null)
				{
					this._AsyncWaitHandle = new ManualResetEvent(false);
				}
			}
		}

		// Token: 0x17000F20 RID: 3872
		// (get) Token: 0x06005A6A RID: 23146 RVA: 0x0013DD48 File Offset: 0x0013BF48
		public virtual WaitHandle AsyncWaitHandle
		{
			get
			{
				this.FaultInWaitHandle();
				return this._AsyncWaitHandle;
			}
		}

		// Token: 0x06005A6B RID: 23147 RVA: 0x0013DD56 File Offset: 0x0013BF56
		public virtual void SetMessageCtrl(IMessageCtrl mc)
		{
			this._mc = mc;
		}

		// Token: 0x06005A6C RID: 23148 RVA: 0x0013DD60 File Offset: 0x0013BF60
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			if (msg == null)
			{
				this._replyMsg = new ReturnMessage(new RemotingException(Environment.GetResourceString("Remoting_NullMessage")), new ErrorMessage());
			}
			else if (!(msg is IMethodReturnMessage))
			{
				this._replyMsg = new ReturnMessage(new RemotingException(Environment.GetResourceString("Remoting_Message_BadType")), new ErrorMessage());
			}
			else
			{
				this._replyMsg = msg;
			}
			this._isCompleted = true;
			this.FaultInWaitHandle();
			this._AsyncWaitHandle.Set();
			if (this._acbd != null)
			{
				this._acbd(this);
			}
			return null;
		}

		// Token: 0x06005A6D RID: 23149 RVA: 0x0013DDEF File Offset: 0x0013BFEF
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		// Token: 0x17000F21 RID: 3873
		// (get) Token: 0x06005A6E RID: 23150 RVA: 0x0013DE00 File Offset: 0x0013C000
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x06005A6F RID: 23151 RVA: 0x0013DE03 File Offset: 0x0013C003
		public virtual IMessage GetReplyMessage()
		{
			return this._replyMsg;
		}

		// Token: 0x040028FE RID: 10494
		private IMessageCtrl _mc;

		// Token: 0x040028FF RID: 10495
		private AsyncCallback _acbd;

		// Token: 0x04002900 RID: 10496
		private IMessage _replyMsg;

		// Token: 0x04002901 RID: 10497
		private bool _isCompleted;

		// Token: 0x04002902 RID: 10498
		private bool _endInvokeCalled;

		// Token: 0x04002903 RID: 10499
		private ManualResetEvent _AsyncWaitHandle;

		// Token: 0x04002904 RID: 10500
		private Delegate _asyncDelegate;

		// Token: 0x04002905 RID: 10501
		private object _asyncState;
	}
}
