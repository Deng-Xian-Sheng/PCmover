using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000834 RID: 2100
	internal class AsyncWorkItem : IMessageSink
	{
		// Token: 0x060059C4 RID: 22980 RVA: 0x0013C96D File Offset: 0x0013AB6D
		[SecurityCritical]
		internal AsyncWorkItem(IMessageSink replySink, Context oldCtx) : this(null, replySink, oldCtx, null)
		{
		}

		// Token: 0x060059C5 RID: 22981 RVA: 0x0013C979 File Offset: 0x0013AB79
		[SecurityCritical]
		internal AsyncWorkItem(IMessage reqMsg, IMessageSink replySink, Context oldCtx, ServerIdentity srvID)
		{
			this._reqMsg = reqMsg;
			this._replySink = replySink;
			this._oldCtx = oldCtx;
			this._callCtx = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			this._srvID = srvID;
		}

		// Token: 0x060059C6 RID: 22982 RVA: 0x0013C9B4 File Offset: 0x0013ABB4
		[SecurityCritical]
		internal static object SyncProcessMessageCallback(object[] args)
		{
			IMessageSink messageSink = (IMessageSink)args[0];
			IMessage msg = (IMessage)args[1];
			return messageSink.SyncProcessMessage(msg);
		}

		// Token: 0x060059C7 RID: 22983 RVA: 0x0013C9DC File Offset: 0x0013ABDC
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			IMessage result = null;
			if (this._replySink != null)
			{
				Thread.CurrentContext.NotifyDynamicSinks(msg, false, false, true, true);
				object[] args = new object[]
				{
					this._replySink,
					msg
				};
				InternalCrossContextDelegate ftnToCall = new InternalCrossContextDelegate(AsyncWorkItem.SyncProcessMessageCallback);
				result = (IMessage)Thread.CurrentThread.InternalCrossContextCallback(this._oldCtx, ftnToCall, args);
			}
			return result;
		}

		// Token: 0x060059C8 RID: 22984 RVA: 0x0013CA3D File Offset: 0x0013AC3D
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		// Token: 0x17000EE2 RID: 3810
		// (get) Token: 0x060059C9 RID: 22985 RVA: 0x0013CA4E File Offset: 0x0013AC4E
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._replySink;
			}
		}

		// Token: 0x060059CA RID: 22986 RVA: 0x0013CA58 File Offset: 0x0013AC58
		[SecurityCritical]
		internal static object FinishAsyncWorkCallback(object[] args)
		{
			AsyncWorkItem asyncWorkItem = (AsyncWorkItem)args[0];
			Context serverContext = asyncWorkItem._srvID.ServerContext;
			LogicalCallContext logicalCallContext = CallContext.SetLogicalCallContext(asyncWorkItem._callCtx);
			serverContext.NotifyDynamicSinks(asyncWorkItem._reqMsg, false, true, true, true);
			IMessageCtrl messageCtrl = serverContext.GetServerContextChain().AsyncProcessMessage(asyncWorkItem._reqMsg, asyncWorkItem);
			CallContext.SetLogicalCallContext(logicalCallContext);
			return null;
		}

		// Token: 0x060059CB RID: 22987 RVA: 0x0013CAB4 File Offset: 0x0013ACB4
		[SecurityCritical]
		internal virtual void FinishAsyncWork(object stateIgnored)
		{
			InternalCrossContextDelegate ftnToCall = new InternalCrossContextDelegate(AsyncWorkItem.FinishAsyncWorkCallback);
			object[] args = new object[]
			{
				this
			};
			Thread.CurrentThread.InternalCrossContextCallback(this._srvID.ServerContext, ftnToCall, args);
		}

		// Token: 0x040028D9 RID: 10457
		private IMessageSink _replySink;

		// Token: 0x040028DA RID: 10458
		private ServerIdentity _srvID;

		// Token: 0x040028DB RID: 10459
		private Context _oldCtx;

		// Token: 0x040028DC RID: 10460
		[SecurityCritical]
		private LogicalCallContext _callCtx;

		// Token: 0x040028DD RID: 10461
		private IMessage _reqMsg;
	}
}
