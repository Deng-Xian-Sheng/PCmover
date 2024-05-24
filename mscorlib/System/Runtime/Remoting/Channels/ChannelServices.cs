using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000826 RID: 2086
	[ComVisible(true)]
	public sealed class ChannelServices
	{
		// Token: 0x17000ED6 RID: 3798
		// (get) Token: 0x06005968 RID: 22888 RVA: 0x0013B0FA File Offset: 0x001392FA
		internal static object[] CurrentChannelData
		{
			[SecurityCritical]
			get
			{
				if (ChannelServices.s_currentChannelData == null)
				{
					ChannelServices.RefreshChannelData();
				}
				return ChannelServices.s_currentChannelData;
			}
		}

		// Token: 0x06005969 RID: 22889 RVA: 0x0013B111 File Offset: 0x00139311
		private ChannelServices()
		{
		}

		// Token: 0x17000ED7 RID: 3799
		// (get) Token: 0x0600596A RID: 22890 RVA: 0x0013B119 File Offset: 0x00139319
		// (set) Token: 0x0600596B RID: 22891 RVA: 0x0013B12F File Offset: 0x0013932F
		private static long remoteCalls
		{
			get
			{
				return Thread.GetDomain().RemotingData.ChannelServicesData.remoteCalls;
			}
			set
			{
				Thread.GetDomain().RemotingData.ChannelServicesData.remoteCalls = value;
			}
		}

		// Token: 0x0600596C RID: 22892
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern Perf_Contexts* GetPrivateContextsPerfCounters();

		// Token: 0x0600596D RID: 22893 RVA: 0x0013B146 File Offset: 0x00139346
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterChannel(IChannel chnl, bool ensureSecurity)
		{
			ChannelServices.RegisterChannelInternal(chnl, ensureSecurity);
		}

		// Token: 0x0600596E RID: 22894 RVA: 0x0013B14F File Offset: 0x0013934F
		[SecuritySafeCritical]
		[Obsolete("Use System.Runtime.Remoting.ChannelServices.RegisterChannel(IChannel chnl, bool ensureSecurity) instead.", false)]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterChannel(IChannel chnl)
		{
			ChannelServices.RegisterChannelInternal(chnl, false);
		}

		// Token: 0x0600596F RID: 22895 RVA: 0x0013B158 File Offset: 0x00139358
		[SecurityCritical]
		internal unsafe static void RegisterChannelInternal(IChannel chnl, bool ensureSecurity)
		{
			if (chnl == null)
			{
				throw new ArgumentNullException("chnl");
			}
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(ChannelServices.s_channelLock, ref flag);
				string channelName = chnl.ChannelName;
				RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
				if (channelName != null && channelName.Length != 0 && -1 != registeredChannelList.FindChannelIndex(chnl.ChannelName))
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_ChannelNameAlreadyRegistered", new object[]
					{
						chnl.ChannelName
					}));
				}
				if (ensureSecurity)
				{
					ISecurableChannel securableChannel = chnl as ISecurableChannel;
					if (securableChannel == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CannotBeSecured", new object[]
						{
							chnl.ChannelName ?? chnl.ToString()
						}));
					}
					securableChannel.IsSecured = ensureSecurity;
				}
				RegisteredChannel[] registeredChannels = registeredChannelList.RegisteredChannels;
				RegisteredChannel[] array;
				if (registeredChannels == null)
				{
					array = new RegisteredChannel[1];
				}
				else
				{
					array = new RegisteredChannel[registeredChannels.Length + 1];
				}
				if (!ChannelServices.unloadHandlerRegistered && !(chnl is CrossAppDomainChannel))
				{
					AppDomain.CurrentDomain.DomainUnload += ChannelServices.UnloadHandler;
					ChannelServices.unloadHandlerRegistered = true;
				}
				int channelPriority = chnl.ChannelPriority;
				int i;
				for (i = 0; i < registeredChannels.Length; i++)
				{
					RegisteredChannel registeredChannel = registeredChannels[i];
					if (channelPriority > registeredChannel.Channel.ChannelPriority)
					{
						array[i] = new RegisteredChannel(chnl);
						break;
					}
					array[i] = registeredChannel;
				}
				if (i == registeredChannels.Length)
				{
					array[registeredChannels.Length] = new RegisteredChannel(chnl);
				}
				else
				{
					while (i < registeredChannels.Length)
					{
						array[i + 1] = registeredChannels[i];
						i++;
					}
				}
				if (ChannelServices.perf_Contexts != null)
				{
					ChannelServices.perf_Contexts->cChannels++;
				}
				ChannelServices.s_registeredChannels = new RegisteredChannelList(array);
				ChannelServices.RefreshChannelData();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ChannelServices.s_channelLock);
				}
			}
		}

		// Token: 0x06005970 RID: 22896 RVA: 0x0013B330 File Offset: 0x00139530
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public unsafe static void UnregisterChannel(IChannel chnl)
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(ChannelServices.s_channelLock, ref flag);
				if (chnl != null)
				{
					RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
					int num = registeredChannelList.FindChannelIndex(chnl);
					if (-1 == num)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_ChannelNotRegistered", new object[]
						{
							chnl.ChannelName
						}));
					}
					RegisteredChannel[] registeredChannels = registeredChannelList.RegisteredChannels;
					RegisteredChannel[] array = new RegisteredChannel[registeredChannels.Length - 1];
					IChannelReceiver channelReceiver = chnl as IChannelReceiver;
					if (channelReceiver != null)
					{
						channelReceiver.StopListening(null);
					}
					int num2 = 0;
					int i = 0;
					while (i < registeredChannels.Length)
					{
						if (i == num)
						{
							i++;
						}
						else
						{
							array[num2] = registeredChannels[i];
							num2++;
							i++;
						}
					}
					if (ChannelServices.perf_Contexts != null)
					{
						ChannelServices.perf_Contexts->cChannels--;
					}
					ChannelServices.s_registeredChannels = new RegisteredChannelList(array);
				}
				ChannelServices.RefreshChannelData();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ChannelServices.s_channelLock);
				}
			}
		}

		// Token: 0x17000ED8 RID: 3800
		// (get) Token: 0x06005971 RID: 22897 RVA: 0x0013B434 File Offset: 0x00139634
		public static IChannel[] RegisteredChannels
		{
			[SecurityCritical]
			get
			{
				RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
				int count = registeredChannelList.Count;
				if (count == 0)
				{
					return new IChannel[0];
				}
				int num = count - 1;
				int num2 = 0;
				IChannel[] array = new IChannel[num];
				for (int i = 0; i < count; i++)
				{
					IChannel channel = registeredChannelList.GetChannel(i);
					if (!(channel is CrossAppDomainChannel))
					{
						array[num2++] = channel;
					}
				}
				return array;
			}
		}

		// Token: 0x06005972 RID: 22898 RVA: 0x0013B498 File Offset: 0x00139698
		[SecurityCritical]
		internal static IMessageSink CreateMessageSink(string url, object data, out string objectURI)
		{
			IMessageSink messageSink = null;
			objectURI = null;
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			for (int i = 0; i < count; i++)
			{
				if (registeredChannelList.IsSender(i))
				{
					IChannelSender channelSender = (IChannelSender)registeredChannelList.GetChannel(i);
					messageSink = channelSender.CreateMessageSink(url, data, out objectURI);
					if (messageSink != null)
					{
						break;
					}
				}
			}
			if (objectURI == null)
			{
				objectURI = url;
			}
			return messageSink;
		}

		// Token: 0x06005973 RID: 22899 RVA: 0x0013B4F4 File Offset: 0x001396F4
		[SecurityCritical]
		internal static IMessageSink CreateMessageSink(object data)
		{
			string text;
			return ChannelServices.CreateMessageSink(null, data, out text);
		}

		// Token: 0x06005974 RID: 22900 RVA: 0x0013B50C File Offset: 0x0013970C
		[SecurityCritical]
		public static IChannel GetChannel(string name)
		{
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int num = registeredChannelList.FindChannelIndex(name);
			if (0 > num)
			{
				return null;
			}
			IChannel channel = registeredChannelList.GetChannel(num);
			if (channel is CrossAppDomainChannel || channel is CrossContextChannel)
			{
				return null;
			}
			return channel;
		}

		// Token: 0x06005975 RID: 22901 RVA: 0x0013B54C File Offset: 0x0013974C
		[SecurityCritical]
		public static string[] GetUrlsForObject(MarshalByRefObject obj)
		{
			if (obj == null)
			{
				return null;
			}
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			Hashtable hashtable = new Hashtable();
			bool flag;
			Identity identity = MarshalByRefObject.GetIdentity(obj, out flag);
			if (identity != null)
			{
				string objURI = identity.ObjURI;
				if (objURI != null)
				{
					for (int i = 0; i < count; i++)
					{
						if (registeredChannelList.IsReceiver(i))
						{
							try
							{
								string[] urlsForUri = ((IChannelReceiver)registeredChannelList.GetChannel(i)).GetUrlsForUri(objURI);
								for (int j = 0; j < urlsForUri.Length; j++)
								{
									hashtable.Add(urlsForUri[j], urlsForUri[j]);
								}
							}
							catch (NotSupportedException)
							{
							}
						}
					}
				}
			}
			ICollection keys = hashtable.Keys;
			string[] array = new string[keys.Count];
			int num = 0;
			foreach (object obj2 in keys)
			{
				string text = (string)obj2;
				array[num++] = text;
			}
			return array;
		}

		// Token: 0x06005976 RID: 22902 RVA: 0x0013B664 File Offset: 0x00139864
		[SecurityCritical]
		internal static IMessageSink GetChannelSinkForProxy(object obj)
		{
			IMessageSink result = null;
			if (RemotingServices.IsTransparentProxy(obj))
			{
				RealProxy realProxy = RemotingServices.GetRealProxy(obj);
				RemotingProxy remotingProxy = realProxy as RemotingProxy;
				if (remotingProxy != null)
				{
					Identity identityObject = remotingProxy.IdentityObject;
					result = identityObject.ChannelSink;
				}
			}
			return result;
		}

		// Token: 0x06005977 RID: 22903 RVA: 0x0013B69C File Offset: 0x0013989C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static IDictionary GetChannelSinkProperties(object obj)
		{
			IMessageSink channelSinkForProxy = ChannelServices.GetChannelSinkForProxy(obj);
			IClientChannelSink clientChannelSink = channelSinkForProxy as IClientChannelSink;
			if (clientChannelSink != null)
			{
				ArrayList arrayList = new ArrayList();
				do
				{
					IDictionary properties = clientChannelSink.Properties;
					if (properties != null)
					{
						arrayList.Add(properties);
					}
					clientChannelSink = clientChannelSink.NextChannelSink;
				}
				while (clientChannelSink != null);
				return new AggregateDictionary(arrayList);
			}
			IDictionary dictionary = channelSinkForProxy as IDictionary;
			if (dictionary != null)
			{
				return dictionary;
			}
			return null;
		}

		// Token: 0x06005978 RID: 22904 RVA: 0x0013B6F3 File Offset: 0x001398F3
		internal static IMessageSink GetCrossContextChannelSink()
		{
			if (ChannelServices.xCtxChannel == null)
			{
				ChannelServices.xCtxChannel = CrossContextChannel.MessageSink;
			}
			return ChannelServices.xCtxChannel;
		}

		// Token: 0x06005979 RID: 22905 RVA: 0x0013B711 File Offset: 0x00139911
		[SecurityCritical]
		internal unsafe static void IncrementRemoteCalls(long cCalls)
		{
			ChannelServices.remoteCalls += cCalls;
			if (ChannelServices.perf_Contexts != null)
			{
				ChannelServices.perf_Contexts->cRemoteCalls += (int)cCalls;
			}
		}

		// Token: 0x0600597A RID: 22906 RVA: 0x0013B73C File Offset: 0x0013993C
		[SecurityCritical]
		internal static void IncrementRemoteCalls()
		{
			ChannelServices.IncrementRemoteCalls(1L);
		}

		// Token: 0x0600597B RID: 22907 RVA: 0x0013B748 File Offset: 0x00139948
		[SecurityCritical]
		internal static void RefreshChannelData()
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(ChannelServices.s_channelLock, ref flag);
				ChannelServices.s_currentChannelData = ChannelServices.CollectChannelDataFromChannels();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ChannelServices.s_channelLock);
				}
			}
		}

		// Token: 0x0600597C RID: 22908 RVA: 0x0013B794 File Offset: 0x00139994
		[SecurityCritical]
		private static object[] CollectChannelDataFromChannels()
		{
			RemotingServices.RegisterWellKnownChannels();
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			int receiverCount = registeredChannelList.ReceiverCount;
			object[] array = new object[receiverCount];
			int num = 0;
			int i = 0;
			int num2 = 0;
			while (i < count)
			{
				IChannel channel = registeredChannelList.GetChannel(i);
				if (channel == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_ChannelNotRegistered", new object[]
					{
						""
					}));
				}
				if (registeredChannelList.IsReceiver(i))
				{
					object channelData = ((IChannelReceiver)channel).ChannelData;
					array[num2] = channelData;
					if (channelData != null)
					{
						num++;
					}
					num2++;
				}
				i++;
			}
			if (num != receiverCount)
			{
				object[] array2 = new object[num];
				int num3 = 0;
				for (int j = 0; j < receiverCount; j++)
				{
					object obj = array[j];
					if (obj != null)
					{
						array2[num3++] = obj;
					}
				}
				array = array2;
			}
			return array;
		}

		// Token: 0x0600597D RID: 22909 RVA: 0x0013B870 File Offset: 0x00139A70
		private static bool IsMethodReallyPublic(MethodInfo mi)
		{
			if (!mi.IsPublic || mi.IsStatic)
			{
				return false;
			}
			if (!mi.IsGenericMethod)
			{
				return true;
			}
			foreach (Type type in mi.GetGenericArguments())
			{
				if (!type.IsVisible)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600597E RID: 22910 RVA: 0x0013B8C0 File Offset: 0x00139AC0
		[SecurityCritical]
		public static ServerProcessing DispatchMessage(IServerChannelSinkStack sinkStack, IMessage msg, out IMessage replyMsg)
		{
			ServerProcessing serverProcessing = ServerProcessing.Complete;
			replyMsg = null;
			try
			{
				if (msg == null)
				{
					throw new ArgumentNullException("msg");
				}
				ChannelServices.IncrementRemoteCalls();
				ServerIdentity serverIdentity = ChannelServices.CheckDisconnectedOrCreateWellKnownObject(msg);
				if (serverIdentity.ServerType == typeof(AppDomain))
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_AppDomainsCantBeCalledRemotely"));
				}
				IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;
				if (methodCallMessage == null)
				{
					if (!typeof(IMessageSink).IsAssignableFrom(serverIdentity.ServerType))
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_AppDomainsCantBeCalledRemotely"));
					}
					serverProcessing = ServerProcessing.Complete;
					replyMsg = ChannelServices.GetCrossContextChannelSink().SyncProcessMessage(msg);
				}
				else
				{
					MethodInfo methodInfo = (MethodInfo)methodCallMessage.MethodBase;
					if (!ChannelServices.IsMethodReallyPublic(methodInfo) && !RemotingServices.IsMethodAllowedRemotely(methodInfo))
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_NonPublicOrStaticCantBeCalledRemotely"));
					}
					RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(methodInfo);
					if (RemotingServices.IsOneWay(methodInfo))
					{
						serverProcessing = ServerProcessing.OneWay;
						ChannelServices.GetCrossContextChannelSink().AsyncProcessMessage(msg, null);
					}
					else
					{
						serverProcessing = ServerProcessing.Complete;
						if (!serverIdentity.ServerType.IsContextful)
						{
							object[] args = new object[]
							{
								msg,
								serverIdentity.ServerContext
							};
							replyMsg = (IMessage)CrossContextChannel.SyncProcessMessageCallback(args);
						}
						else
						{
							replyMsg = ChannelServices.GetCrossContextChannelSink().SyncProcessMessage(msg);
						}
					}
				}
			}
			catch (Exception e)
			{
				if (serverProcessing != ServerProcessing.OneWay)
				{
					try
					{
						IMessage message2;
						if (msg == null)
						{
							IMessage message = new ErrorMessage();
							message2 = message;
						}
						else
						{
							message2 = msg;
						}
						IMethodCallMessage mcm = (IMethodCallMessage)message2;
						replyMsg = new ReturnMessage(e, mcm);
						if (msg != null)
						{
							((ReturnMessage)replyMsg).SetLogicalCallContext((LogicalCallContext)msg.Properties[Message.CallContextKey]);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return serverProcessing;
		}

		// Token: 0x0600597F RID: 22911 RVA: 0x0013BA70 File Offset: 0x00139C70
		[SecurityCritical]
		public static IMessage SyncDispatchMessage(IMessage msg)
		{
			IMessage message = null;
			bool flag = false;
			try
			{
				if (msg == null)
				{
					throw new ArgumentNullException("msg");
				}
				ChannelServices.IncrementRemoteCalls();
				if (!(msg is TransitionCall))
				{
					ChannelServices.CheckDisconnectedOrCreateWellKnownObject(msg);
					MethodBase methodBase = ((IMethodMessage)msg).MethodBase;
					flag = RemotingServices.IsOneWay(methodBase);
				}
				IMessageSink crossContextChannelSink = ChannelServices.GetCrossContextChannelSink();
				if (!flag)
				{
					message = crossContextChannelSink.SyncProcessMessage(msg);
				}
				else
				{
					crossContextChannelSink.AsyncProcessMessage(msg, null);
				}
			}
			catch (Exception e)
			{
				if (!flag)
				{
					try
					{
						IMessage message3;
						if (msg == null)
						{
							IMessage message2 = new ErrorMessage();
							message3 = message2;
						}
						else
						{
							message3 = msg;
						}
						IMethodCallMessage methodCallMessage = (IMethodCallMessage)message3;
						message = new ReturnMessage(e, methodCallMessage);
						if (msg != null)
						{
							((ReturnMessage)message).SetLogicalCallContext(methodCallMessage.LogicalCallContext);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return message;
		}

		// Token: 0x06005980 RID: 22912 RVA: 0x0013BB34 File Offset: 0x00139D34
		[SecurityCritical]
		public static IMessageCtrl AsyncDispatchMessage(IMessage msg, IMessageSink replySink)
		{
			IMessageCtrl result = null;
			try
			{
				if (msg == null)
				{
					throw new ArgumentNullException("msg");
				}
				ChannelServices.IncrementRemoteCalls();
				if (!(msg is TransitionCall))
				{
					ChannelServices.CheckDisconnectedOrCreateWellKnownObject(msg);
				}
				result = ChannelServices.GetCrossContextChannelSink().AsyncProcessMessage(msg, replySink);
			}
			catch (Exception e)
			{
				if (replySink != null)
				{
					try
					{
						IMethodCallMessage methodCallMessage = (IMethodCallMessage)msg;
						ReturnMessage returnMessage = new ReturnMessage(e, (IMethodCallMessage)msg);
						if (msg != null)
						{
							returnMessage.SetLogicalCallContext(methodCallMessage.LogicalCallContext);
						}
						replySink.SyncProcessMessage(returnMessage);
					}
					catch (Exception)
					{
					}
				}
			}
			return result;
		}

		// Token: 0x06005981 RID: 22913 RVA: 0x0013BBC8 File Offset: 0x00139DC8
		[SecurityCritical]
		public static IServerChannelSink CreateServerChannelSinkChain(IServerChannelSinkProvider provider, IChannelReceiver channel)
		{
			if (provider == null)
			{
				return new DispatchChannelSink();
			}
			IServerChannelSinkProvider serverChannelSinkProvider = provider;
			while (serverChannelSinkProvider.Next != null)
			{
				serverChannelSinkProvider = serverChannelSinkProvider.Next;
			}
			serverChannelSinkProvider.Next = new DispatchChannelSinkProvider();
			IServerChannelSink result = provider.CreateSink(channel);
			serverChannelSinkProvider.Next = null;
			return result;
		}

		// Token: 0x06005982 RID: 22914 RVA: 0x0013BC0C File Offset: 0x00139E0C
		[SecurityCritical]
		internal static ServerIdentity CheckDisconnectedOrCreateWellKnownObject(IMessage msg)
		{
			ServerIdentity serverIdentity = InternalSink.GetServerIdentity(msg);
			if (serverIdentity == null || serverIdentity.IsRemoteDisconnected())
			{
				string uri = InternalSink.GetURI(msg);
				if (uri != null)
				{
					ServerIdentity serverIdentity2 = RemotingConfigHandler.CreateWellKnownObject(uri);
					if (serverIdentity2 != null)
					{
						serverIdentity = serverIdentity2;
					}
				}
			}
			if (serverIdentity == null || serverIdentity.IsRemoteDisconnected())
			{
				string uri2 = InternalSink.GetURI(msg);
				throw new RemotingException(Environment.GetResourceString("Remoting_Disconnected", new object[]
				{
					uri2
				}));
			}
			return serverIdentity;
		}

		// Token: 0x06005983 RID: 22915 RVA: 0x0013BC6E File Offset: 0x00139E6E
		[SecurityCritical]
		internal static void UnloadHandler(object sender, EventArgs e)
		{
			ChannelServices.StopListeningOnAllChannels();
		}

		// Token: 0x06005984 RID: 22916 RVA: 0x0013BC78 File Offset: 0x00139E78
		[SecurityCritical]
		private static void StopListeningOnAllChannels()
		{
			try
			{
				RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
				int count = registeredChannelList.Count;
				for (int i = 0; i < count; i++)
				{
					if (registeredChannelList.IsReceiver(i))
					{
						IChannelReceiver channelReceiver = (IChannelReceiver)registeredChannelList.GetChannel(i);
						channelReceiver.StopListening(null);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06005985 RID: 22917 RVA: 0x0013BCD4 File Offset: 0x00139ED4
		[SecurityCritical]
		internal static void NotifyProfiler(IMessage msg, RemotingProfilerEvent profilerEvent)
		{
			if (profilerEvent != RemotingProfilerEvent.ClientSend)
			{
				if (profilerEvent != RemotingProfilerEvent.ClientReceive)
				{
					return;
				}
				if (RemotingServices.CORProfilerTrackRemoting())
				{
					Guid id = Guid.Empty;
					if (RemotingServices.CORProfilerTrackRemotingCookie())
					{
						object obj = msg.Properties["CORProfilerCookie"];
						if (obj != null)
						{
							id = (Guid)obj;
						}
					}
					RemotingServices.CORProfilerRemotingClientReceivingReply(id, false);
				}
			}
			else if (RemotingServices.CORProfilerTrackRemoting())
			{
				Guid guid;
				RemotingServices.CORProfilerRemotingClientSendingMessage(out guid, false);
				if (RemotingServices.CORProfilerTrackRemotingCookie())
				{
					msg.Properties["CORProfilerCookie"] = guid;
					return;
				}
			}
		}

		// Token: 0x06005986 RID: 22918 RVA: 0x0013BD4C File Offset: 0x00139F4C
		[SecurityCritical]
		internal static string FindFirstHttpUrlForObject(string objectUri)
		{
			if (objectUri == null)
			{
				return null;
			}
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			for (int i = 0; i < count; i++)
			{
				if (registeredChannelList.IsReceiver(i))
				{
					IChannelReceiver channelReceiver = (IChannelReceiver)registeredChannelList.GetChannel(i);
					string fullName = channelReceiver.GetType().FullName;
					if (string.CompareOrdinal(fullName, "System.Runtime.Remoting.Channels.Http.HttpChannel") == 0 || string.CompareOrdinal(fullName, "System.Runtime.Remoting.Channels.Http.HttpServerChannel") == 0)
					{
						string[] urlsForUri = channelReceiver.GetUrlsForUri(objectUri);
						if (urlsForUri != null && urlsForUri.Length != 0)
						{
							return urlsForUri[0];
						}
					}
				}
			}
			return null;
		}

		// Token: 0x040028B9 RID: 10425
		private static volatile object[] s_currentChannelData = null;

		// Token: 0x040028BA RID: 10426
		private static object s_channelLock = new object();

		// Token: 0x040028BB RID: 10427
		private static volatile RegisteredChannelList s_registeredChannels = new RegisteredChannelList();

		// Token: 0x040028BC RID: 10428
		private static volatile IMessageSink xCtxChannel;

		// Token: 0x040028BD RID: 10429
		[SecurityCritical]
		private unsafe static volatile Perf_Contexts* perf_Contexts = ChannelServices.GetPrivateContextsPerfCounters();

		// Token: 0x040028BE RID: 10430
		private static bool unloadHandlerRegistered = false;
	}
}
