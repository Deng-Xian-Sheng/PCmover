using System;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000EF RID: 239
	public class BrowserProcessServiceHost : ServiceHost
	{
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x0000BA50 File Offset: 0x00009C50
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x0000BA58 File Offset: 0x00009C58
		public IJavascriptObjectRepositoryInternal JavascriptObjectRepository { get; private set; }

		// Token: 0x06000713 RID: 1811 RVA: 0x0000BA64 File Offset: 0x00009C64
		public BrowserProcessServiceHost(IJavascriptObjectRepositoryInternal javascriptObjectRepository, int parentProcessId, int browserId, IJavascriptCallbackFactory callbackFactory) : base(typeof(BrowserProcessService), new Uri[0])
		{
			this.JavascriptObjectRepository = javascriptObjectRepository;
			string serviceName = RenderprocessClientFactory.GetServiceName(parentProcessId, browserId);
			base.Description.ApplyServiceBehavior(() => new ServiceDebugBehavior(), delegate(ServiceDebugBehavior p)
			{
				p.IncludeExceptionDetailInFaults = true;
			});
			CustomBinding binding = BrowserProcessServiceHost.CreateBinding();
			ServiceEndpoint serviceEndpoint = base.AddServiceEndpoint(typeof(IBrowserProcess), binding, new Uri(serviceName));
			serviceEndpoint.Contract.ProtectionLevel = ProtectionLevel.None;
			serviceEndpoint.Behaviors.Add(new JavascriptCallbackEndpointBehavior(callbackFactory));
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0000BB1B File Offset: 0x00009D1B
		protected override void OnClosed()
		{
			base.OnClosed();
			this.JavascriptObjectRepository = null;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0000BB2C File Offset: 0x00009D2C
		public static CustomBinding CreateBinding()
		{
			CustomBinding customBinding = new CustomBinding(new NetNamedPipeBinding(NetNamedPipeSecurityMode.None)
			{
				MaxReceivedMessageSize = 134217728L,
				ReceiveTimeout = TimeSpan.MaxValue,
				SendTimeout = TimeSpan.MaxValue,
				OpenTimeout = TimeSpan.MaxValue,
				CloseTimeout = TimeSpan.MaxValue,
				ReaderQuotas = 
				{
					MaxStringContentLength = int.MaxValue,
					MaxArrayLength = int.MaxValue,
					MaxDepth = int.MaxValue,
					MaxNameTableCharCount = int.MaxValue,
					MaxBytesPerRead = int.MaxValue
				}
			});
			NamedPipeConnectionPoolSettings connectionPoolSettings = customBinding.Elements.Find<NamedPipeTransportBindingElement>().ConnectionPoolSettings;
			connectionPoolSettings.IdleTimeout = TimeSpan.MaxValue;
			connectionPoolSettings.MaxOutboundConnectionsPerEndpoint = 0;
			return customBinding;
		}

		// Token: 0x04000396 RID: 918
		private const long OneHundredAndTwentyEightMegaBytesInBytes = 134217728L;
	}
}
