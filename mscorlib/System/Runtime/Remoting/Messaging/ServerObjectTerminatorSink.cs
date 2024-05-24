using System;
using System.Runtime.Remoting.Contexts;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000886 RID: 2182
	[Serializable]
	internal class ServerObjectTerminatorSink : InternalSink, IMessageSink
	{
		// Token: 0x06005C97 RID: 23703 RVA: 0x00144D67 File Offset: 0x00142F67
		internal ServerObjectTerminatorSink(MarshalByRefObject srvObj)
		{
			this._stackBuilderSink = new StackBuilderSink(srvObj);
		}

		// Token: 0x06005C98 RID: 23704 RVA: 0x00144D7C File Offset: 0x00142F7C
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			IMessage message = InternalSink.ValidateMessage(reqMsg);
			if (message != null)
			{
				return message;
			}
			ServerIdentity serverIdentity = InternalSink.GetServerIdentity(reqMsg);
			ArrayWithSize serverSideDynamicSinks = serverIdentity.ServerSideDynamicSinks;
			if (serverSideDynamicSinks != null)
			{
				DynamicPropertyHolder.NotifyDynamicSinks(reqMsg, serverSideDynamicSinks, false, true, false);
			}
			IMessageSink messageSink = this._stackBuilderSink.ServerObject as IMessageSink;
			IMessage message2;
			if (messageSink != null)
			{
				message2 = messageSink.SyncProcessMessage(reqMsg);
			}
			else
			{
				message2 = this._stackBuilderSink.SyncProcessMessage(reqMsg);
			}
			if (serverSideDynamicSinks != null)
			{
				DynamicPropertyHolder.NotifyDynamicSinks(message2, serverSideDynamicSinks, false, false, false);
			}
			return message2;
		}

		// Token: 0x06005C99 RID: 23705 RVA: 0x00144DEC File Offset: 0x00142FEC
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
				IMessageSink messageSink = this._stackBuilderSink.ServerObject as IMessageSink;
				if (messageSink != null)
				{
					result = messageSink.AsyncProcessMessage(reqMsg, replySink);
				}
				else
				{
					result = this._stackBuilderSink.AsyncProcessMessage(reqMsg, replySink);
				}
			}
			return result;
		}

		// Token: 0x17000FE9 RID: 4073
		// (get) Token: 0x06005C9A RID: 23706 RVA: 0x00144E40 File Offset: 0x00143040
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x040029CA RID: 10698
		internal StackBuilderSink _stackBuilderSink;
	}
}
