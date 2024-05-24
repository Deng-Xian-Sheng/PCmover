using System;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000881 RID: 2177
	[Serializable]
	internal class EnvoyTerminatorSink : InternalSink, IMessageSink
	{
		// Token: 0x17000FE1 RID: 4065
		// (get) Token: 0x06005C78 RID: 23672 RVA: 0x0014472C File Offset: 0x0014292C
		internal static IMessageSink MessageSink
		{
			get
			{
				if (EnvoyTerminatorSink.messageSink == null)
				{
					EnvoyTerminatorSink envoyTerminatorSink = new EnvoyTerminatorSink();
					object obj = EnvoyTerminatorSink.staticSyncObject;
					lock (obj)
					{
						if (EnvoyTerminatorSink.messageSink == null)
						{
							EnvoyTerminatorSink.messageSink = envoyTerminatorSink;
						}
					}
				}
				return EnvoyTerminatorSink.messageSink;
			}
		}

		// Token: 0x06005C79 RID: 23673 RVA: 0x0014478C File Offset: 0x0014298C
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			IMessage message = InternalSink.ValidateMessage(reqMsg);
			if (message != null)
			{
				return message;
			}
			return Thread.CurrentContext.GetClientContextChain().SyncProcessMessage(reqMsg);
		}

		// Token: 0x06005C7A RID: 23674 RVA: 0x001447B8 File Offset: 0x001429B8
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			IMessageCtrl result = null;
			IMessage message = InternalSink.ValidateMessage(reqMsg);
			if (message != null)
			{
				if (replySink != null)
				{
					replySink.SyncProcessMessage(message);
				}
			}
			else
			{
				result = Thread.CurrentContext.GetClientContextChain().AsyncProcessMessage(reqMsg, replySink);
			}
			return result;
		}

		// Token: 0x17000FE2 RID: 4066
		// (get) Token: 0x06005C7B RID: 23675 RVA: 0x001447F1 File Offset: 0x001429F1
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x040029C0 RID: 10688
		private static volatile EnvoyTerminatorSink messageSink;

		// Token: 0x040029C1 RID: 10689
		private static object staticSyncObject = new object();
	}
}
