using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000833 RID: 2099
	internal class CrossContextChannel : InternalSink, IMessageSink
	{
		// Token: 0x17000EDF RID: 3807
		// (get) Token: 0x060059B9 RID: 22969 RVA: 0x0013C52D File Offset: 0x0013A72D
		// (set) Token: 0x060059BA RID: 22970 RVA: 0x0013C543 File Offset: 0x0013A743
		private static CrossContextChannel messageSink
		{
			get
			{
				return Thread.GetDomain().RemotingData.ChannelServicesData.xctxmessageSink;
			}
			set
			{
				Thread.GetDomain().RemotingData.ChannelServicesData.xctxmessageSink = value;
			}
		}

		// Token: 0x17000EE0 RID: 3808
		// (get) Token: 0x060059BB RID: 22971 RVA: 0x0013C55C File Offset: 0x0013A75C
		internal static IMessageSink MessageSink
		{
			get
			{
				if (CrossContextChannel.messageSink == null)
				{
					CrossContextChannel messageSink = new CrossContextChannel();
					object obj = CrossContextChannel.staticSyncObject;
					lock (obj)
					{
						if (CrossContextChannel.messageSink == null)
						{
							CrossContextChannel.messageSink = messageSink;
						}
					}
				}
				return CrossContextChannel.messageSink;
			}
		}

		// Token: 0x060059BC RID: 22972 RVA: 0x0013C5B4 File Offset: 0x0013A7B4
		[SecurityCritical]
		internal static object SyncProcessMessageCallback(object[] args)
		{
			IMessage message = args[0] as IMessage;
			Context context = args[1] as Context;
			if (RemotingServices.CORProfilerTrackRemoting())
			{
				Guid id = Guid.Empty;
				if (RemotingServices.CORProfilerTrackRemotingCookie())
				{
					object obj = message.Properties["CORProfilerCookie"];
					if (obj != null)
					{
						id = (Guid)obj;
					}
				}
				RemotingServices.CORProfilerRemotingServerReceivingMessage(id, false);
			}
			context.NotifyDynamicSinks(message, false, true, false, true);
			IMessage message2 = context.GetServerContextChain().SyncProcessMessage(message);
			context.NotifyDynamicSinks(message2, false, false, false, true);
			if (RemotingServices.CORProfilerTrackRemoting())
			{
				Guid guid;
				RemotingServices.CORProfilerRemotingServerSendingReply(out guid, false);
				if (RemotingServices.CORProfilerTrackRemotingCookie())
				{
					message2.Properties["CORProfilerCookie"] = guid;
				}
			}
			return message2;
		}

		// Token: 0x060059BD RID: 22973 RVA: 0x0013C664 File Offset: 0x0013A864
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			object[] array = new object[2];
			IMessage message = null;
			try
			{
				IMessage message2 = InternalSink.ValidateMessage(reqMsg);
				if (message2 != null)
				{
					return message2;
				}
				ServerIdentity serverIdentity = InternalSink.GetServerIdentity(reqMsg);
				array[0] = reqMsg;
				array[1] = serverIdentity.ServerContext;
				message = (IMessage)Thread.CurrentThread.InternalCrossContextCallback(serverIdentity.ServerContext, CrossContextChannel.s_xctxDel, array);
			}
			catch (Exception e)
			{
				message = new ReturnMessage(e, (IMethodCallMessage)reqMsg);
				if (reqMsg != null)
				{
					((ReturnMessage)message).SetLogicalCallContext((LogicalCallContext)reqMsg.Properties[Message.CallContextKey]);
				}
			}
			return message;
		}

		// Token: 0x060059BE RID: 22974 RVA: 0x0013C708 File Offset: 0x0013A908
		[SecurityCritical]
		internal static object AsyncProcessMessageCallback(object[] args)
		{
			AsyncWorkItem replySink = null;
			IMessage msg = (IMessage)args[0];
			IMessageSink messageSink = (IMessageSink)args[1];
			Context oldCtx = (Context)args[2];
			Context context = (Context)args[3];
			if (messageSink != null)
			{
				replySink = new AsyncWorkItem(messageSink, oldCtx);
			}
			context.NotifyDynamicSinks(msg, false, true, true, true);
			return context.GetServerContextChain().AsyncProcessMessage(msg, replySink);
		}

		// Token: 0x060059BF RID: 22975 RVA: 0x0013C76C File Offset: 0x0013A96C
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			IMessage message = InternalSink.ValidateMessage(reqMsg);
			object[] array = new object[4];
			IMessageCtrl result = null;
			if (message != null)
			{
				if (replySink != null)
				{
					replySink.SyncProcessMessage(message);
				}
			}
			else
			{
				ServerIdentity serverIdentity = InternalSink.GetServerIdentity(reqMsg);
				if (RemotingServices.CORProfilerTrackRemotingAsync())
				{
					Guid id = Guid.Empty;
					if (RemotingServices.CORProfilerTrackRemotingCookie())
					{
						object obj = reqMsg.Properties["CORProfilerCookie"];
						if (obj != null)
						{
							id = (Guid)obj;
						}
					}
					RemotingServices.CORProfilerRemotingServerReceivingMessage(id, true);
					if (replySink != null)
					{
						IMessageSink messageSink = new ServerAsyncReplyTerminatorSink(replySink);
						replySink = messageSink;
					}
				}
				Context serverContext = serverIdentity.ServerContext;
				if (serverContext.IsThreadPoolAware)
				{
					array[0] = reqMsg;
					array[1] = replySink;
					array[2] = Thread.CurrentContext;
					array[3] = serverContext;
					InternalCrossContextDelegate ftnToCall = new InternalCrossContextDelegate(CrossContextChannel.AsyncProcessMessageCallback);
					result = (IMessageCtrl)Thread.CurrentThread.InternalCrossContextCallback(serverContext, ftnToCall, array);
				}
				else
				{
					AsyncWorkItem @object = new AsyncWorkItem(reqMsg, replySink, Thread.CurrentContext, serverIdentity);
					WaitCallback callBack = new WaitCallback(@object.FinishAsyncWork);
					ThreadPool.QueueUserWorkItem(callBack);
				}
			}
			return result;
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x0013C868 File Offset: 0x0013AA68
		[SecurityCritical]
		internal static object DoAsyncDispatchCallback(object[] args)
		{
			AsyncWorkItem replySink = null;
			IMessage msg = (IMessage)args[0];
			IMessageSink messageSink = (IMessageSink)args[1];
			Context oldCtx = (Context)args[2];
			Context context = (Context)args[3];
			if (messageSink != null)
			{
				replySink = new AsyncWorkItem(messageSink, oldCtx);
			}
			return context.GetServerContextChain().AsyncProcessMessage(msg, replySink);
		}

		// Token: 0x060059C1 RID: 22977 RVA: 0x0013C8BC File Offset: 0x0013AABC
		[SecurityCritical]
		internal static IMessageCtrl DoAsyncDispatch(IMessage reqMsg, IMessageSink replySink)
		{
			object[] array = new object[4];
			ServerIdentity serverIdentity = InternalSink.GetServerIdentity(reqMsg);
			if (RemotingServices.CORProfilerTrackRemotingAsync())
			{
				Guid id = Guid.Empty;
				if (RemotingServices.CORProfilerTrackRemotingCookie())
				{
					object obj = reqMsg.Properties["CORProfilerCookie"];
					if (obj != null)
					{
						id = (Guid)obj;
					}
				}
				RemotingServices.CORProfilerRemotingServerReceivingMessage(id, true);
				if (replySink != null)
				{
					IMessageSink messageSink = new ServerAsyncReplyTerminatorSink(replySink);
					replySink = messageSink;
				}
			}
			Context serverContext = serverIdentity.ServerContext;
			array[0] = reqMsg;
			array[1] = replySink;
			array[2] = Thread.CurrentContext;
			array[3] = serverContext;
			InternalCrossContextDelegate ftnToCall = new InternalCrossContextDelegate(CrossContextChannel.DoAsyncDispatchCallback);
			return (IMessageCtrl)Thread.CurrentThread.InternalCrossContextCallback(serverContext, ftnToCall, array);
		}

		// Token: 0x17000EE1 RID: 3809
		// (get) Token: 0x060059C2 RID: 22978 RVA: 0x0013C962 File Offset: 0x0013AB62
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x040028D4 RID: 10452
		private const string _channelName = "XCTX";

		// Token: 0x040028D5 RID: 10453
		private const int _channelCapability = 0;

		// Token: 0x040028D6 RID: 10454
		private const string _channelURI = "XCTX_URI";

		// Token: 0x040028D7 RID: 10455
		private static object staticSyncObject = new object();

		// Token: 0x040028D8 RID: 10456
		private static InternalCrossContextDelegate s_xctxDel = new InternalCrossContextDelegate(CrossContextChannel.SyncProcessMessageCallback);
	}
}
