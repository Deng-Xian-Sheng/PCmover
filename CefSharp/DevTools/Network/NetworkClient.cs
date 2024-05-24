using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.Emulation;

namespace CefSharp.DevTools.Network
{
	// Token: 0x0200030C RID: 780
	public class NetworkClient : DevToolsDomainBase
	{
		// Token: 0x060016A6 RID: 5798 RVA: 0x0001A2C0 File Offset: 0x000184C0
		public NetworkClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000070 RID: 112
		// (add) Token: 0x060016A7 RID: 5799 RVA: 0x0001A2CF File Offset: 0x000184CF
		// (remove) Token: 0x060016A8 RID: 5800 RVA: 0x0001A2E2 File Offset: 0x000184E2
		public event EventHandler<DataReceivedEventArgs> DataReceived
		{
			add
			{
				this._client.AddEventHandler<DataReceivedEventArgs>("Network.dataReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DataReceivedEventArgs>("Network.dataReceived", value);
			}
		}

		// Token: 0x14000071 RID: 113
		// (add) Token: 0x060016A9 RID: 5801 RVA: 0x0001A2F6 File Offset: 0x000184F6
		// (remove) Token: 0x060016AA RID: 5802 RVA: 0x0001A309 File Offset: 0x00018509
		public event EventHandler<EventSourceMessageReceivedEventArgs> EventSourceMessageReceived
		{
			add
			{
				this._client.AddEventHandler<EventSourceMessageReceivedEventArgs>("Network.eventSourceMessageReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventSourceMessageReceivedEventArgs>("Network.eventSourceMessageReceived", value);
			}
		}

		// Token: 0x14000072 RID: 114
		// (add) Token: 0x060016AB RID: 5803 RVA: 0x0001A31D File Offset: 0x0001851D
		// (remove) Token: 0x060016AC RID: 5804 RVA: 0x0001A330 File Offset: 0x00018530
		public event EventHandler<LoadingFailedEventArgs> LoadingFailed
		{
			add
			{
				this._client.AddEventHandler<LoadingFailedEventArgs>("Network.loadingFailed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LoadingFailedEventArgs>("Network.loadingFailed", value);
			}
		}

		// Token: 0x14000073 RID: 115
		// (add) Token: 0x060016AD RID: 5805 RVA: 0x0001A344 File Offset: 0x00018544
		// (remove) Token: 0x060016AE RID: 5806 RVA: 0x0001A357 File Offset: 0x00018557
		public event EventHandler<LoadingFinishedEventArgs> LoadingFinished
		{
			add
			{
				this._client.AddEventHandler<LoadingFinishedEventArgs>("Network.loadingFinished", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LoadingFinishedEventArgs>("Network.loadingFinished", value);
			}
		}

		// Token: 0x14000074 RID: 116
		// (add) Token: 0x060016AF RID: 5807 RVA: 0x0001A36B File Offset: 0x0001856B
		// (remove) Token: 0x060016B0 RID: 5808 RVA: 0x0001A37E File Offset: 0x0001857E
		public event EventHandler<RequestServedFromCacheEventArgs> RequestServedFromCache
		{
			add
			{
				this._client.AddEventHandler<RequestServedFromCacheEventArgs>("Network.requestServedFromCache", value);
			}
			remove
			{
				this._client.RemoveEventHandler<RequestServedFromCacheEventArgs>("Network.requestServedFromCache", value);
			}
		}

		// Token: 0x14000075 RID: 117
		// (add) Token: 0x060016B1 RID: 5809 RVA: 0x0001A392 File Offset: 0x00018592
		// (remove) Token: 0x060016B2 RID: 5810 RVA: 0x0001A3A5 File Offset: 0x000185A5
		public event EventHandler<RequestWillBeSentEventArgs> RequestWillBeSent
		{
			add
			{
				this._client.AddEventHandler<RequestWillBeSentEventArgs>("Network.requestWillBeSent", value);
			}
			remove
			{
				this._client.RemoveEventHandler<RequestWillBeSentEventArgs>("Network.requestWillBeSent", value);
			}
		}

		// Token: 0x14000076 RID: 118
		// (add) Token: 0x060016B3 RID: 5811 RVA: 0x0001A3B9 File Offset: 0x000185B9
		// (remove) Token: 0x060016B4 RID: 5812 RVA: 0x0001A3CC File Offset: 0x000185CC
		public event EventHandler<ResourceChangedPriorityEventArgs> ResourceChangedPriority
		{
			add
			{
				this._client.AddEventHandler<ResourceChangedPriorityEventArgs>("Network.resourceChangedPriority", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ResourceChangedPriorityEventArgs>("Network.resourceChangedPriority", value);
			}
		}

		// Token: 0x14000077 RID: 119
		// (add) Token: 0x060016B5 RID: 5813 RVA: 0x0001A3E0 File Offset: 0x000185E0
		// (remove) Token: 0x060016B6 RID: 5814 RVA: 0x0001A3F3 File Offset: 0x000185F3
		public event EventHandler<SignedExchangeReceivedEventArgs> SignedExchangeReceived
		{
			add
			{
				this._client.AddEventHandler<SignedExchangeReceivedEventArgs>("Network.signedExchangeReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SignedExchangeReceivedEventArgs>("Network.signedExchangeReceived", value);
			}
		}

		// Token: 0x14000078 RID: 120
		// (add) Token: 0x060016B7 RID: 5815 RVA: 0x0001A407 File Offset: 0x00018607
		// (remove) Token: 0x060016B8 RID: 5816 RVA: 0x0001A41A File Offset: 0x0001861A
		public event EventHandler<ResponseReceivedEventArgs> ResponseReceived
		{
			add
			{
				this._client.AddEventHandler<ResponseReceivedEventArgs>("Network.responseReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ResponseReceivedEventArgs>("Network.responseReceived", value);
			}
		}

		// Token: 0x14000079 RID: 121
		// (add) Token: 0x060016B9 RID: 5817 RVA: 0x0001A42E File Offset: 0x0001862E
		// (remove) Token: 0x060016BA RID: 5818 RVA: 0x0001A441 File Offset: 0x00018641
		public event EventHandler<WebSocketClosedEventArgs> WebSocketClosed
		{
			add
			{
				this._client.AddEventHandler<WebSocketClosedEventArgs>("Network.webSocketClosed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketClosedEventArgs>("Network.webSocketClosed", value);
			}
		}

		// Token: 0x1400007A RID: 122
		// (add) Token: 0x060016BB RID: 5819 RVA: 0x0001A455 File Offset: 0x00018655
		// (remove) Token: 0x060016BC RID: 5820 RVA: 0x0001A468 File Offset: 0x00018668
		public event EventHandler<WebSocketCreatedEventArgs> WebSocketCreated
		{
			add
			{
				this._client.AddEventHandler<WebSocketCreatedEventArgs>("Network.webSocketCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketCreatedEventArgs>("Network.webSocketCreated", value);
			}
		}

		// Token: 0x1400007B RID: 123
		// (add) Token: 0x060016BD RID: 5821 RVA: 0x0001A47C File Offset: 0x0001867C
		// (remove) Token: 0x060016BE RID: 5822 RVA: 0x0001A48F File Offset: 0x0001868F
		public event EventHandler<WebSocketFrameErrorEventArgs> WebSocketFrameError
		{
			add
			{
				this._client.AddEventHandler<WebSocketFrameErrorEventArgs>("Network.webSocketFrameError", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketFrameErrorEventArgs>("Network.webSocketFrameError", value);
			}
		}

		// Token: 0x1400007C RID: 124
		// (add) Token: 0x060016BF RID: 5823 RVA: 0x0001A4A3 File Offset: 0x000186A3
		// (remove) Token: 0x060016C0 RID: 5824 RVA: 0x0001A4B6 File Offset: 0x000186B6
		public event EventHandler<WebSocketFrameReceivedEventArgs> WebSocketFrameReceived
		{
			add
			{
				this._client.AddEventHandler<WebSocketFrameReceivedEventArgs>("Network.webSocketFrameReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketFrameReceivedEventArgs>("Network.webSocketFrameReceived", value);
			}
		}

		// Token: 0x1400007D RID: 125
		// (add) Token: 0x060016C1 RID: 5825 RVA: 0x0001A4CA File Offset: 0x000186CA
		// (remove) Token: 0x060016C2 RID: 5826 RVA: 0x0001A4DD File Offset: 0x000186DD
		public event EventHandler<WebSocketFrameSentEventArgs> WebSocketFrameSent
		{
			add
			{
				this._client.AddEventHandler<WebSocketFrameSentEventArgs>("Network.webSocketFrameSent", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketFrameSentEventArgs>("Network.webSocketFrameSent", value);
			}
		}

		// Token: 0x1400007E RID: 126
		// (add) Token: 0x060016C3 RID: 5827 RVA: 0x0001A4F1 File Offset: 0x000186F1
		// (remove) Token: 0x060016C4 RID: 5828 RVA: 0x0001A504 File Offset: 0x00018704
		public event EventHandler<WebSocketHandshakeResponseReceivedEventArgs> WebSocketHandshakeResponseReceived
		{
			add
			{
				this._client.AddEventHandler<WebSocketHandshakeResponseReceivedEventArgs>("Network.webSocketHandshakeResponseReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketHandshakeResponseReceivedEventArgs>("Network.webSocketHandshakeResponseReceived", value);
			}
		}

		// Token: 0x1400007F RID: 127
		// (add) Token: 0x060016C5 RID: 5829 RVA: 0x0001A518 File Offset: 0x00018718
		// (remove) Token: 0x060016C6 RID: 5830 RVA: 0x0001A52B File Offset: 0x0001872B
		public event EventHandler<WebSocketWillSendHandshakeRequestEventArgs> WebSocketWillSendHandshakeRequest
		{
			add
			{
				this._client.AddEventHandler<WebSocketWillSendHandshakeRequestEventArgs>("Network.webSocketWillSendHandshakeRequest", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebSocketWillSendHandshakeRequestEventArgs>("Network.webSocketWillSendHandshakeRequest", value);
			}
		}

		// Token: 0x14000080 RID: 128
		// (add) Token: 0x060016C7 RID: 5831 RVA: 0x0001A53F File Offset: 0x0001873F
		// (remove) Token: 0x060016C8 RID: 5832 RVA: 0x0001A552 File Offset: 0x00018752
		public event EventHandler<WebTransportCreatedEventArgs> WebTransportCreated
		{
			add
			{
				this._client.AddEventHandler<WebTransportCreatedEventArgs>("Network.webTransportCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebTransportCreatedEventArgs>("Network.webTransportCreated", value);
			}
		}

		// Token: 0x14000081 RID: 129
		// (add) Token: 0x060016C9 RID: 5833 RVA: 0x0001A566 File Offset: 0x00018766
		// (remove) Token: 0x060016CA RID: 5834 RVA: 0x0001A579 File Offset: 0x00018779
		public event EventHandler<WebTransportConnectionEstablishedEventArgs> WebTransportConnectionEstablished
		{
			add
			{
				this._client.AddEventHandler<WebTransportConnectionEstablishedEventArgs>("Network.webTransportConnectionEstablished", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebTransportConnectionEstablishedEventArgs>("Network.webTransportConnectionEstablished", value);
			}
		}

		// Token: 0x14000082 RID: 130
		// (add) Token: 0x060016CB RID: 5835 RVA: 0x0001A58D File Offset: 0x0001878D
		// (remove) Token: 0x060016CC RID: 5836 RVA: 0x0001A5A0 File Offset: 0x000187A0
		public event EventHandler<WebTransportClosedEventArgs> WebTransportClosed
		{
			add
			{
				this._client.AddEventHandler<WebTransportClosedEventArgs>("Network.webTransportClosed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WebTransportClosedEventArgs>("Network.webTransportClosed", value);
			}
		}

		// Token: 0x14000083 RID: 131
		// (add) Token: 0x060016CD RID: 5837 RVA: 0x0001A5B4 File Offset: 0x000187B4
		// (remove) Token: 0x060016CE RID: 5838 RVA: 0x0001A5C7 File Offset: 0x000187C7
		public event EventHandler<RequestWillBeSentExtraInfoEventArgs> RequestWillBeSentExtraInfo
		{
			add
			{
				this._client.AddEventHandler<RequestWillBeSentExtraInfoEventArgs>("Network.requestWillBeSentExtraInfo", value);
			}
			remove
			{
				this._client.RemoveEventHandler<RequestWillBeSentExtraInfoEventArgs>("Network.requestWillBeSentExtraInfo", value);
			}
		}

		// Token: 0x14000084 RID: 132
		// (add) Token: 0x060016CF RID: 5839 RVA: 0x0001A5DB File Offset: 0x000187DB
		// (remove) Token: 0x060016D0 RID: 5840 RVA: 0x0001A5EE File Offset: 0x000187EE
		public event EventHandler<ResponseReceivedExtraInfoEventArgs> ResponseReceivedExtraInfo
		{
			add
			{
				this._client.AddEventHandler<ResponseReceivedExtraInfoEventArgs>("Network.responseReceivedExtraInfo", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ResponseReceivedExtraInfoEventArgs>("Network.responseReceivedExtraInfo", value);
			}
		}

		// Token: 0x14000085 RID: 133
		// (add) Token: 0x060016D1 RID: 5841 RVA: 0x0001A602 File Offset: 0x00018802
		// (remove) Token: 0x060016D2 RID: 5842 RVA: 0x0001A615 File Offset: 0x00018815
		public event EventHandler<TrustTokenOperationDoneEventArgs> TrustTokenOperationDone
		{
			add
			{
				this._client.AddEventHandler<TrustTokenOperationDoneEventArgs>("Network.trustTokenOperationDone", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TrustTokenOperationDoneEventArgs>("Network.trustTokenOperationDone", value);
			}
		}

		// Token: 0x14000086 RID: 134
		// (add) Token: 0x060016D3 RID: 5843 RVA: 0x0001A629 File Offset: 0x00018829
		// (remove) Token: 0x060016D4 RID: 5844 RVA: 0x0001A63C File Offset: 0x0001883C
		public event EventHandler<SubresourceWebBundleMetadataReceivedEventArgs> SubresourceWebBundleMetadataReceived
		{
			add
			{
				this._client.AddEventHandler<SubresourceWebBundleMetadataReceivedEventArgs>("Network.subresourceWebBundleMetadataReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SubresourceWebBundleMetadataReceivedEventArgs>("Network.subresourceWebBundleMetadataReceived", value);
			}
		}

		// Token: 0x14000087 RID: 135
		// (add) Token: 0x060016D5 RID: 5845 RVA: 0x0001A650 File Offset: 0x00018850
		// (remove) Token: 0x060016D6 RID: 5846 RVA: 0x0001A663 File Offset: 0x00018863
		public event EventHandler<SubresourceWebBundleMetadataErrorEventArgs> SubresourceWebBundleMetadataError
		{
			add
			{
				this._client.AddEventHandler<SubresourceWebBundleMetadataErrorEventArgs>("Network.subresourceWebBundleMetadataError", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SubresourceWebBundleMetadataErrorEventArgs>("Network.subresourceWebBundleMetadataError", value);
			}
		}

		// Token: 0x14000088 RID: 136
		// (add) Token: 0x060016D7 RID: 5847 RVA: 0x0001A677 File Offset: 0x00018877
		// (remove) Token: 0x060016D8 RID: 5848 RVA: 0x0001A68A File Offset: 0x0001888A
		public event EventHandler<SubresourceWebBundleInnerResponseParsedEventArgs> SubresourceWebBundleInnerResponseParsed
		{
			add
			{
				this._client.AddEventHandler<SubresourceWebBundleInnerResponseParsedEventArgs>("Network.subresourceWebBundleInnerResponseParsed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SubresourceWebBundleInnerResponseParsedEventArgs>("Network.subresourceWebBundleInnerResponseParsed", value);
			}
		}

		// Token: 0x14000089 RID: 137
		// (add) Token: 0x060016D9 RID: 5849 RVA: 0x0001A69E File Offset: 0x0001889E
		// (remove) Token: 0x060016DA RID: 5850 RVA: 0x0001A6B1 File Offset: 0x000188B1
		public event EventHandler<SubresourceWebBundleInnerResponseErrorEventArgs> SubresourceWebBundleInnerResponseError
		{
			add
			{
				this._client.AddEventHandler<SubresourceWebBundleInnerResponseErrorEventArgs>("Network.subresourceWebBundleInnerResponseError", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SubresourceWebBundleInnerResponseErrorEventArgs>("Network.subresourceWebBundleInnerResponseError", value);
			}
		}

		// Token: 0x1400008A RID: 138
		// (add) Token: 0x060016DB RID: 5851 RVA: 0x0001A6C5 File Offset: 0x000188C5
		// (remove) Token: 0x060016DC RID: 5852 RVA: 0x0001A6D8 File Offset: 0x000188D8
		public event EventHandler<ReportingApiReportAddedEventArgs> ReportingApiReportAdded
		{
			add
			{
				this._client.AddEventHandler<ReportingApiReportAddedEventArgs>("Network.reportingApiReportAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ReportingApiReportAddedEventArgs>("Network.reportingApiReportAdded", value);
			}
		}

		// Token: 0x1400008B RID: 139
		// (add) Token: 0x060016DD RID: 5853 RVA: 0x0001A6EC File Offset: 0x000188EC
		// (remove) Token: 0x060016DE RID: 5854 RVA: 0x0001A6FF File Offset: 0x000188FF
		public event EventHandler<ReportingApiReportUpdatedEventArgs> ReportingApiReportUpdated
		{
			add
			{
				this._client.AddEventHandler<ReportingApiReportUpdatedEventArgs>("Network.reportingApiReportUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ReportingApiReportUpdatedEventArgs>("Network.reportingApiReportUpdated", value);
			}
		}

		// Token: 0x1400008C RID: 140
		// (add) Token: 0x060016DF RID: 5855 RVA: 0x0001A713 File Offset: 0x00018913
		// (remove) Token: 0x060016E0 RID: 5856 RVA: 0x0001A726 File Offset: 0x00018926
		public event EventHandler<ReportingApiEndpointsChangedForOriginEventArgs> ReportingApiEndpointsChangedForOrigin
		{
			add
			{
				this._client.AddEventHandler<ReportingApiEndpointsChangedForOriginEventArgs>("Network.reportingApiEndpointsChangedForOrigin", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ReportingApiEndpointsChangedForOriginEventArgs>("Network.reportingApiEndpointsChangedForOrigin", value);
			}
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x0001A73C File Offset: 0x0001893C
		public Task<DevToolsMethodResponse> SetAcceptedEncodingsAsync(ContentEncoding[] encodings)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("encodings", base.EnumToString(encodings));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setAcceptedEncodings", dictionary);
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x0001A774 File Offset: 0x00018974
		public Task<DevToolsMethodResponse> ClearAcceptedEncodingsOverrideAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.clearAcceptedEncodingsOverride", parameters);
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x0001A794 File Offset: 0x00018994
		public Task<DevToolsMethodResponse> ClearBrowserCacheAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.clearBrowserCache", parameters);
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x0001A7B4 File Offset: 0x000189B4
		public Task<DevToolsMethodResponse> ClearBrowserCookiesAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.clearBrowserCookies", parameters);
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0001A7D4 File Offset: 0x000189D4
		public Task<DevToolsMethodResponse> DeleteCookiesAsync(string name, string url = null, string domain = null, string path = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("name", name);
			if (!string.IsNullOrEmpty(url))
			{
				dictionary.Add("url", url);
			}
			if (!string.IsNullOrEmpty(domain))
			{
				dictionary.Add("domain", domain);
			}
			if (!string.IsNullOrEmpty(path))
			{
				dictionary.Add("path", path);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.deleteCookies", dictionary);
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0001A844 File Offset: 0x00018A44
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.disable", parameters);
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x0001A864 File Offset: 0x00018A64
		public Task<DevToolsMethodResponse> EmulateNetworkConditionsAsync(bool offline, double latency, double downloadThroughput, double uploadThroughput, ConnectionType? connectionType = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("offline", offline);
			dictionary.Add("latency", latency);
			dictionary.Add("downloadThroughput", downloadThroughput);
			dictionary.Add("uploadThroughput", uploadThroughput);
			if (connectionType != null)
			{
				dictionary.Add("connectionType", base.EnumToString(connectionType));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.emulateNetworkConditions", dictionary);
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0001A8F0 File Offset: 0x00018AF0
		public Task<DevToolsMethodResponse> EnableAsync(int? maxTotalBufferSize = null, int? maxResourceBufferSize = null, int? maxPostDataSize = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (maxTotalBufferSize != null)
			{
				dictionary.Add("maxTotalBufferSize", maxTotalBufferSize.Value);
			}
			if (maxResourceBufferSize != null)
			{
				dictionary.Add("maxResourceBufferSize", maxResourceBufferSize.Value);
			}
			if (maxPostDataSize != null)
			{
				dictionary.Add("maxPostDataSize", maxPostDataSize.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.enable", dictionary);
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x0001A974 File Offset: 0x00018B74
		public Task<GetAllCookiesResponse> GetAllCookiesAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetAllCookiesResponse>("Network.getAllCookies", parameters);
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x0001A994 File Offset: 0x00018B94
		public Task<GetCertificateResponse> GetCertificateAsync(string origin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			return this._client.ExecuteDevToolsMethodAsync<GetCertificateResponse>("Network.getCertificate", dictionary);
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x0001A9C4 File Offset: 0x00018BC4
		public Task<GetCookiesResponse> GetCookiesAsync(string[] urls = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (urls != null)
			{
				dictionary.Add("urls", urls);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetCookiesResponse>("Network.getCookies", dictionary);
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x0001A9F8 File Offset: 0x00018BF8
		public Task<GetResponseBodyResponse> GetResponseBodyAsync(string requestId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			return this._client.ExecuteDevToolsMethodAsync<GetResponseBodyResponse>("Network.getResponseBody", dictionary);
		}

		// Token: 0x060016ED RID: 5869 RVA: 0x0001AA28 File Offset: 0x00018C28
		public Task<GetRequestPostDataResponse> GetRequestPostDataAsync(string requestId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			return this._client.ExecuteDevToolsMethodAsync<GetRequestPostDataResponse>("Network.getRequestPostData", dictionary);
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x0001AA58 File Offset: 0x00018C58
		public Task<GetResponseBodyForInterceptionResponse> GetResponseBodyForInterceptionAsync(string interceptionId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("interceptionId", interceptionId);
			return this._client.ExecuteDevToolsMethodAsync<GetResponseBodyForInterceptionResponse>("Network.getResponseBodyForInterception", dictionary);
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x0001AA88 File Offset: 0x00018C88
		public Task<TakeResponseBodyForInterceptionAsStreamResponse> TakeResponseBodyForInterceptionAsStreamAsync(string interceptionId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("interceptionId", interceptionId);
			return this._client.ExecuteDevToolsMethodAsync<TakeResponseBodyForInterceptionAsStreamResponse>("Network.takeResponseBodyForInterceptionAsStream", dictionary);
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x0001AAB8 File Offset: 0x00018CB8
		public Task<DevToolsMethodResponse> ReplayXHRAsync(string requestId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.replayXHR", dictionary);
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x0001AAE8 File Offset: 0x00018CE8
		public Task<SearchInResponseBodyResponse> SearchInResponseBodyAsync(string requestId, string query, bool? caseSensitive = null, bool? isRegex = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			dictionary.Add("query", query);
			if (caseSensitive != null)
			{
				dictionary.Add("caseSensitive", caseSensitive.Value);
			}
			if (isRegex != null)
			{
				dictionary.Add("isRegex", isRegex.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<SearchInResponseBodyResponse>("Network.searchInResponseBody", dictionary);
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x0001AB64 File Offset: 0x00018D64
		public Task<DevToolsMethodResponse> SetBlockedURLsAsync(string[] urls)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("urls", urls);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setBlockedURLs", dictionary);
		}

		// Token: 0x060016F3 RID: 5875 RVA: 0x0001AB94 File Offset: 0x00018D94
		public Task<DevToolsMethodResponse> SetBypassServiceWorkerAsync(bool bypass)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("bypass", bypass);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setBypassServiceWorker", dictionary);
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x0001ABCC File Offset: 0x00018DCC
		public Task<DevToolsMethodResponse> SetCacheDisabledAsync(bool cacheDisabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cacheDisabled", cacheDisabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setCacheDisabled", dictionary);
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x0001AC04 File Offset: 0x00018E04
		public Task<SetCookieResponse> SetCookieAsync(string name, string value, string url = null, string domain = null, string path = null, bool? secure = null, bool? httpOnly = null, CookieSameSite? sameSite = null, double? expires = null, CookiePriority? priority = null, bool? sameParty = null, CookieSourceScheme? sourceScheme = null, int? sourcePort = null, string partitionKey = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("name", name);
			dictionary.Add("value", value);
			if (!string.IsNullOrEmpty(url))
			{
				dictionary.Add("url", url);
			}
			if (!string.IsNullOrEmpty(domain))
			{
				dictionary.Add("domain", domain);
			}
			if (!string.IsNullOrEmpty(path))
			{
				dictionary.Add("path", path);
			}
			if (secure != null)
			{
				dictionary.Add("secure", secure.Value);
			}
			if (httpOnly != null)
			{
				dictionary.Add("httpOnly", httpOnly.Value);
			}
			if (sameSite != null)
			{
				dictionary.Add("sameSite", base.EnumToString(sameSite));
			}
			if (expires != null)
			{
				dictionary.Add("expires", expires.Value);
			}
			if (priority != null)
			{
				dictionary.Add("priority", base.EnumToString(priority));
			}
			if (sameParty != null)
			{
				dictionary.Add("sameParty", sameParty.Value);
			}
			if (sourceScheme != null)
			{
				dictionary.Add("sourceScheme", base.EnumToString(sourceScheme));
			}
			if (sourcePort != null)
			{
				dictionary.Add("sourcePort", sourcePort.Value);
			}
			if (!string.IsNullOrEmpty(partitionKey))
			{
				dictionary.Add("partitionKey", partitionKey);
			}
			return this._client.ExecuteDevToolsMethodAsync<SetCookieResponse>("Network.setCookie", dictionary);
		}

		// Token: 0x060016F6 RID: 5878 RVA: 0x0001AD9C File Offset: 0x00018F9C
		public Task<DevToolsMethodResponse> SetCookiesAsync(IList<CookieParam> cookies)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cookies", from x in cookies
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setCookies", dictionary);
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x0001ADF0 File Offset: 0x00018FF0
		public Task<DevToolsMethodResponse> SetExtraHTTPHeadersAsync(Headers headers)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("headers", headers.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setExtraHTTPHeaders", dictionary);
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x0001AE28 File Offset: 0x00019028
		public Task<DevToolsMethodResponse> SetAttachDebugStackAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setAttachDebugStack", dictionary);
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x0001AE60 File Offset: 0x00019060
		public Task<DevToolsMethodResponse> SetUserAgentOverrideAsync(string userAgent, string acceptLanguage = null, string platform = null, UserAgentMetadata userAgentMetadata = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("userAgent", userAgent);
			if (!string.IsNullOrEmpty(acceptLanguage))
			{
				dictionary.Add("acceptLanguage", acceptLanguage);
			}
			if (!string.IsNullOrEmpty(platform))
			{
				dictionary.Add("platform", platform);
			}
			if (userAgentMetadata != null)
			{
				dictionary.Add("userAgentMetadata", userAgentMetadata.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.setUserAgentOverride", dictionary);
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x0001AED0 File Offset: 0x000190D0
		public Task<GetSecurityIsolationStatusResponse> GetSecurityIsolationStatusAsync(string frameId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(frameId))
			{
				dictionary.Add("frameId", frameId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetSecurityIsolationStatusResponse>("Network.getSecurityIsolationStatus", dictionary);
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x0001AF08 File Offset: 0x00019108
		public Task<DevToolsMethodResponse> EnableReportingApiAsync(bool enable)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enable", enable);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Network.enableReportingApi", dictionary);
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x0001AF40 File Offset: 0x00019140
		public Task<LoadNetworkResourceResponse> LoadNetworkResourceAsync(string frameId, string url, LoadNetworkResourceOptions options)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(frameId))
			{
				dictionary.Add("frameId", frameId);
			}
			dictionary.Add("url", url);
			dictionary.Add("options", options.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<LoadNetworkResourceResponse>("Network.loadNetworkResource", dictionary);
		}

		// Token: 0x04000CBB RID: 3259
		private IDevToolsClient _client;
	}
}
