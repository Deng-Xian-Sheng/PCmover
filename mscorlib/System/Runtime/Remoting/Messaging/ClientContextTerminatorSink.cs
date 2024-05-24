using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000882 RID: 2178
	internal class ClientContextTerminatorSink : InternalSink, IMessageSink
	{
		// Token: 0x17000FE3 RID: 4067
		// (get) Token: 0x06005C7E RID: 23678 RVA: 0x00144808 File Offset: 0x00142A08
		internal static IMessageSink MessageSink
		{
			get
			{
				if (ClientContextTerminatorSink.messageSink == null)
				{
					ClientContextTerminatorSink clientContextTerminatorSink = new ClientContextTerminatorSink();
					object obj = ClientContextTerminatorSink.staticSyncObject;
					lock (obj)
					{
						if (ClientContextTerminatorSink.messageSink == null)
						{
							ClientContextTerminatorSink.messageSink = clientContextTerminatorSink;
						}
					}
				}
				return ClientContextTerminatorSink.messageSink;
			}
		}

		// Token: 0x06005C7F RID: 23679 RVA: 0x00144868 File Offset: 0x00142A68
		[SecurityCritical]
		internal static object SyncProcessMessageCallback(object[] args)
		{
			IMessage msg = (IMessage)args[0];
			IMessageSink messageSink = (IMessageSink)args[1];
			return messageSink.SyncProcessMessage(msg);
		}

		// Token: 0x06005C80 RID: 23680 RVA: 0x00144890 File Offset: 0x00142A90
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			IMessage message = InternalSink.ValidateMessage(reqMsg);
			if (message != null)
			{
				return message;
			}
			Context currentContext = Thread.CurrentContext;
			bool flag = currentContext.NotifyDynamicSinks(reqMsg, true, true, false, true);
			IMessage message2;
			if (reqMsg is IConstructionCallMessage)
			{
				message = currentContext.NotifyActivatorProperties(reqMsg, false);
				if (message != null)
				{
					return message;
				}
				message2 = ((IConstructionCallMessage)reqMsg).Activator.Activate((IConstructionCallMessage)reqMsg);
				message = currentContext.NotifyActivatorProperties(message2, false);
				if (message != null)
				{
					return message;
				}
			}
			else
			{
				ChannelServices.NotifyProfiler(reqMsg, RemotingProfilerEvent.ClientSend);
				object[] array = new object[2];
				IMessageSink channelSink = this.GetChannelSink(reqMsg);
				array[0] = reqMsg;
				array[1] = channelSink;
				InternalCrossContextDelegate internalCrossContextDelegate = new InternalCrossContextDelegate(ClientContextTerminatorSink.SyncProcessMessageCallback);
				if (channelSink != CrossContextChannel.MessageSink)
				{
					message2 = (IMessage)Thread.CurrentThread.InternalCrossContextCallback(Context.DefaultContext, internalCrossContextDelegate, array);
				}
				else
				{
					message2 = (IMessage)internalCrossContextDelegate(array);
				}
				ChannelServices.NotifyProfiler(message2, RemotingProfilerEvent.ClientReceive);
			}
			if (flag)
			{
				currentContext.NotifyDynamicSinks(reqMsg, true, false, false, true);
			}
			return message2;
		}

		// Token: 0x06005C81 RID: 23681 RVA: 0x00144974 File Offset: 0x00142B74
		[SecurityCritical]
		internal static object AsyncProcessMessageCallback(object[] args)
		{
			IMessage msg = (IMessage)args[0];
			IMessageSink replySink = (IMessageSink)args[1];
			IMessageSink messageSink = (IMessageSink)args[2];
			return messageSink.AsyncProcessMessage(msg, replySink);
		}

		// Token: 0x06005C82 RID: 23682 RVA: 0x001449A4 File Offset: 0x00142BA4
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			IMessage message = InternalSink.ValidateMessage(reqMsg);
			IMessageCtrl result = null;
			if (message == null)
			{
				message = InternalSink.DisallowAsyncActivation(reqMsg);
			}
			if (message != null)
			{
				if (replySink != null)
				{
					replySink.SyncProcessMessage(message);
				}
			}
			else
			{
				if (RemotingServices.CORProfilerTrackRemotingAsync())
				{
					Guid guid;
					RemotingServices.CORProfilerRemotingClientSendingMessage(out guid, true);
					if (RemotingServices.CORProfilerTrackRemotingCookie())
					{
						reqMsg.Properties["CORProfilerCookie"] = guid;
					}
					if (replySink != null)
					{
						IMessageSink messageSink = new ClientAsyncReplyTerminatorSink(replySink);
						replySink = messageSink;
					}
				}
				Context currentContext = Thread.CurrentContext;
				currentContext.NotifyDynamicSinks(reqMsg, true, true, true, true);
				if (replySink != null)
				{
					replySink = new AsyncReplySink(replySink, currentContext);
				}
				object[] array = new object[3];
				InternalCrossContextDelegate internalCrossContextDelegate = new InternalCrossContextDelegate(ClientContextTerminatorSink.AsyncProcessMessageCallback);
				IMessageSink channelSink = this.GetChannelSink(reqMsg);
				array[0] = reqMsg;
				array[1] = replySink;
				array[2] = channelSink;
				if (channelSink != CrossContextChannel.MessageSink)
				{
					result = (IMessageCtrl)Thread.CurrentThread.InternalCrossContextCallback(Context.DefaultContext, internalCrossContextDelegate, array);
				}
				else
				{
					result = (IMessageCtrl)internalCrossContextDelegate(array);
				}
			}
			return result;
		}

		// Token: 0x17000FE4 RID: 4068
		// (get) Token: 0x06005C83 RID: 23683 RVA: 0x00144A91 File Offset: 0x00142C91
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x06005C84 RID: 23684 RVA: 0x00144A94 File Offset: 0x00142C94
		[SecurityCritical]
		private IMessageSink GetChannelSink(IMessage reqMsg)
		{
			Identity identity = InternalSink.GetIdentity(reqMsg);
			return identity.ChannelSink;
		}

		// Token: 0x040029C2 RID: 10690
		private static volatile ClientContextTerminatorSink messageSink;

		// Token: 0x040029C3 RID: 10691
		private static object staticSyncObject = new object();
	}
}
