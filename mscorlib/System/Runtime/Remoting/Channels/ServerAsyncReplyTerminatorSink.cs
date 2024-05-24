using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200082B RID: 2091
	internal class ServerAsyncReplyTerminatorSink : IMessageSink
	{
		// Token: 0x06005996 RID: 22934 RVA: 0x0013BF5C File Offset: 0x0013A15C
		internal ServerAsyncReplyTerminatorSink(IMessageSink nextSink)
		{
			this._nextSink = nextSink;
		}

		// Token: 0x06005997 RID: 22935 RVA: 0x0013BF6C File Offset: 0x0013A16C
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage replyMsg)
		{
			Guid guid;
			RemotingServices.CORProfilerRemotingServerSendingReply(out guid, true);
			if (RemotingServices.CORProfilerTrackRemotingCookie())
			{
				replyMsg.Properties["CORProfilerCookie"] = guid;
			}
			return this._nextSink.SyncProcessMessage(replyMsg);
		}

		// Token: 0x06005998 RID: 22936 RVA: 0x0013BFAA File Offset: 0x0013A1AA
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage replyMsg, IMessageSink replySink)
		{
			return null;
		}

		// Token: 0x17000EDD RID: 3805
		// (get) Token: 0x06005999 RID: 22937 RVA: 0x0013BFAD File Offset: 0x0013A1AD
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._nextSink;
			}
		}

		// Token: 0x040028CB RID: 10443
		internal IMessageSink _nextSink;
	}
}
