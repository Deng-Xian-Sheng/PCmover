using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000005 RID: 5
	public static class WcfHelper
	{
		// Token: 0x06000020 RID: 32 RVA: 0x0000250C File Offset: 0x0000070C
		public static Binding GetBinding(Uri uri)
		{
			if (uri != null)
			{
				string scheme = uri.Scheme;
				if (scheme == Uri.UriSchemeNetTcp)
				{
					return new NetTcpBinding();
				}
				if (scheme == Uri.UriSchemeNetPipe)
				{
					return new NetNamedPipeBinding();
				}
			}
			return null;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002550 File Offset: 0x00000750
		public static void ExamineOperationContext()
		{
			OperationContext operationContext = OperationContext.Current;
			if (operationContext == null)
			{
				return;
			}
			MessageProperties incomingMessageProperties = operationContext.IncomingMessageProperties;
			string sessionId = operationContext.SessionId;
			IContextChannel channel = operationContext.Channel;
			IInputSession inputSession = channel.InputSession;
			EndpointAddress localAddress = channel.LocalAddress;
			IOutputSession outputSession = channel.OutputSession;
			EndpointAddress remoteAddress = channel.RemoteAddress;
			string sessionId2 = channel.SessionId;
			EndpointDispatcher endpointDispatcher = operationContext.EndpointDispatcher;
			EndpointAddress endpointAddress = endpointDispatcher.EndpointAddress;
			string bindingName = endpointDispatcher.ChannelDispatcher.BindingName;
			NetworkHelper.GetHostName(WcfHelper.RemoteMachineAddress);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000025C0 File Offset: 0x000007C0
		public static string RemoteMachineAddress
		{
			get
			{
				string address = null;
				CodeHelper.trycatch(delegate()
				{
					OperationContext operationContext = OperationContext.Current;
					Uri uri = (operationContext != null) ? operationContext.Channel.LocalAddress.Uri : null;
					if (uri != null)
					{
						if (uri.Scheme == Uri.UriSchemeNetPipe)
						{
							address = "localhost";
							return;
						}
						RemoteEndpointMessageProperty remoteEndpointMessageProperty = (RemoteEndpointMessageProperty)OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name];
						address = remoteEndpointMessageProperty.Address;
					}
				});
				return address;
			}
		}

		// Token: 0x0400000C RID: 12
		public const int DEFAULT_WCF_TCPPORT = 808;
	}
}
