using System;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000887 RID: 2183
	internal class ClientAsyncReplyTerminatorSink : IMessageSink
	{
		// Token: 0x06005C9B RID: 23707 RVA: 0x00144E43 File Offset: 0x00143043
		internal ClientAsyncReplyTerminatorSink(IMessageSink nextSink)
		{
			this._nextSink = nextSink;
		}

		// Token: 0x06005C9C RID: 23708 RVA: 0x00144E54 File Offset: 0x00143054
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage replyMsg)
		{
			Guid id = Guid.Empty;
			if (RemotingServices.CORProfilerTrackRemotingCookie())
			{
				object obj = replyMsg.Properties["CORProfilerCookie"];
				if (obj != null)
				{
					id = (Guid)obj;
				}
			}
			RemotingServices.CORProfilerRemotingClientReceivingReply(id, true);
			return this._nextSink.SyncProcessMessage(replyMsg);
		}

		// Token: 0x06005C9D RID: 23709 RVA: 0x00144E9C File Offset: 0x0014309C
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage replyMsg, IMessageSink replySink)
		{
			return null;
		}

		// Token: 0x17000FEA RID: 4074
		// (get) Token: 0x06005C9E RID: 23710 RVA: 0x00144E9F File Offset: 0x0014309F
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._nextSink;
			}
		}

		// Token: 0x040029CB RID: 10699
		internal IMessageSink _nextSink;
	}
}
