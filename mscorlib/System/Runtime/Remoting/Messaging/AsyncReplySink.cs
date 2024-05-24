using System;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000883 RID: 2179
	internal class AsyncReplySink : IMessageSink
	{
		// Token: 0x06005C87 RID: 23687 RVA: 0x00144AC2 File Offset: 0x00142CC2
		internal AsyncReplySink(IMessageSink replySink, Context cliCtx)
		{
			this._replySink = replySink;
			this._cliCtx = cliCtx;
		}

		// Token: 0x06005C88 RID: 23688 RVA: 0x00144AD8 File Offset: 0x00142CD8
		[SecurityCritical]
		internal static object SyncProcessMessageCallback(object[] args)
		{
			IMessage msg = (IMessage)args[0];
			IMessageSink messageSink = (IMessageSink)args[1];
			Thread.CurrentContext.NotifyDynamicSinks(msg, true, false, true, true);
			return messageSink.SyncProcessMessage(msg);
		}

		// Token: 0x06005C89 RID: 23689 RVA: 0x00144B10 File Offset: 0x00142D10
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			IMessage result = null;
			if (this._replySink != null)
			{
				object[] args = new object[]
				{
					reqMsg,
					this._replySink
				};
				InternalCrossContextDelegate ftnToCall = new InternalCrossContextDelegate(AsyncReplySink.SyncProcessMessageCallback);
				result = (IMessage)Thread.CurrentThread.InternalCrossContextCallback(this._cliCtx, ftnToCall, args);
			}
			return result;
		}

		// Token: 0x06005C8A RID: 23690 RVA: 0x00144B61 File Offset: 0x00142D61
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000FE5 RID: 4069
		// (get) Token: 0x06005C8B RID: 23691 RVA: 0x00144B68 File Offset: 0x00142D68
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._replySink;
			}
		}

		// Token: 0x040029C4 RID: 10692
		private IMessageSink _replySink;

		// Token: 0x040029C5 RID: 10693
		private Context _cliCtx;
	}
}
