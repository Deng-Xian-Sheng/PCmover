using System;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000885 RID: 2181
	internal class DisposeSink : IMessageSink
	{
		// Token: 0x06005C93 RID: 23699 RVA: 0x00144CFB File Offset: 0x00142EFB
		internal DisposeSink(IDisposable iDis, IMessageSink replySink)
		{
			this._iDis = iDis;
			this._replySink = replySink;
		}

		// Token: 0x06005C94 RID: 23700 RVA: 0x00144D14 File Offset: 0x00142F14
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			IMessage result = null;
			try
			{
				if (this._replySink != null)
				{
					result = this._replySink.SyncProcessMessage(reqMsg);
				}
			}
			finally
			{
				this._iDis.Dispose();
			}
			return result;
		}

		// Token: 0x06005C95 RID: 23701 RVA: 0x00144D58 File Offset: 0x00142F58
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000FE8 RID: 4072
		// (get) Token: 0x06005C96 RID: 23702 RVA: 0x00144D5F File Offset: 0x00142F5F
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._replySink;
			}
		}

		// Token: 0x040029C8 RID: 10696
		private IDisposable _iDis;

		// Token: 0x040029C9 RID: 10697
		private IMessageSink _replySink;
	}
}
