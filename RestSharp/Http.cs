using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using RestSharp.Extensions;

namespace RestSharp
{
	// Token: 0x0200000D RID: 13
	[NullableContext(1)]
	[Nullable(0)]
	public class Http : IHttp
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000022A6 File Offset: 0x000004A6
		[return: Nullable(2)]
		public HttpWebRequest AsPostAsync(Action<HttpResponse> action, string httpMethod)
		{
			return this.PutPostInternalAsync(httpMethod.ToUpperInvariant(), action);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000022B5 File Offset: 0x000004B5
		[return: Nullable(2)]
		public HttpWebRequest AsGetAsync(Action<HttpResponse> action, string httpMethod)
		{
			return this.GetStyleMethodInternalAsync(httpMethod.ToUpperInvariant(), action);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000022C4 File Offset: 0x000004C4
		[return: Nullable(2)]
		private HttpWebRequest GetStyleMethodInternalAsync(string method, Action<HttpResponse> callback)
		{
			HttpWebRequest httpWebRequest = null;
			try
			{
				httpWebRequest = this.ConfigureAsyncWebRequest(method, this.Url);
				if (this.HasBody && (method == "DELETE" || method == "OPTIONS"))
				{
					httpWebRequest.ContentType = this.RequestContentType;
					this.WriteRequestBodyAsync(httpWebRequest, callback);
				}
				else
				{
					this._timeoutState = new Http.TimeOutState
					{
						Request = httpWebRequest
					};
					IAsyncResult timeout = httpWebRequest.BeginGetResponse(delegate(IAsyncResult result)
					{
						this.ResponseCallback(result, callback);
					}, httpWebRequest);
					this.SetTimeout(timeout);
				}
			}
			catch (Exception ex)
			{
				Http.ExecuteCallback(this.CreateErrorResponse(ex), callback);
			}
			return httpWebRequest;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002388 File Offset: 0x00000588
		[return: Nullable(2)]
		private HttpWebRequest PutPostInternalAsync(string method, Action<HttpResponse> callback)
		{
			HttpWebRequest httpWebRequest = null;
			try
			{
				httpWebRequest = this.ConfigureAsyncWebRequest(method, this.Url);
				this.PreparePostBody(httpWebRequest);
				this.WriteRequestBodyAsync(httpWebRequest, callback);
			}
			catch (Exception ex)
			{
				Http.ExecuteCallback(this.CreateErrorResponse(ex), callback);
			}
			return httpWebRequest;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000023D8 File Offset: 0x000005D8
		private void WriteRequestBodyAsync(HttpWebRequest webRequest, Action<HttpResponse> callback)
		{
			Http.<>c__DisplayClass5_0 CS$<>8__locals1 = new Http.<>c__DisplayClass5_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.webRequest = webRequest;
			this._timeoutState = new Http.TimeOutState
			{
				Request = CS$<>8__locals1.webRequest
			};
			IAsyncResult timeout;
			if (this.HasBody || this.HasFiles || this.AlwaysMultipartFormData)
			{
				CS$<>8__locals1.webRequest.ContentLength = this.CalculateContentLength();
				timeout = CS$<>8__locals1.webRequest.BeginGetRequestStream(new AsyncCallback(CS$<>8__locals1.<WriteRequestBodyAsync>g__RequestStreamCallback|1), CS$<>8__locals1.webRequest);
			}
			else
			{
				timeout = CS$<>8__locals1.webRequest.BeginGetResponse(delegate(IAsyncResult r)
				{
					CS$<>8__locals1.<>4__this.ResponseCallback(r, CS$<>8__locals1.callback);
				}, CS$<>8__locals1.webRequest);
			}
			this.SetTimeout(timeout);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002488 File Offset: 0x00000688
		private long CalculateContentLength()
		{
			if (this.RequestBodyBytes != null)
			{
				return (long)this.RequestBodyBytes.Length;
			}
			if (!this.HasFiles && !this.AlwaysMultipartFormData)
			{
				return (long)this.Encoding.GetByteCount(this.RequestBody);
			}
			long num = 0L;
			foreach (HttpFile httpFile in this.Files)
			{
				num += (long)this.Encoding.GetByteCount(this.GetMultipartFileHeader(httpFile));
				num += httpFile.ContentLength;
				num += (long)this.Encoding.GetByteCount("\r\n");
			}
			num = this.Parameters.Aggregate(num, (long current, HttpParameter param) => current + (long)this.Encoding.GetByteCount(this.GetMultipartFormData(param)));
			num += (long)this.Encoding.GetByteCount(this.GetMultipartFooter());
			return num;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002568 File Offset: 0x00000768
		private void SetTimeout(IAsyncResult asyncResult)
		{
			if (this.Timeout != 0)
			{
				ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle, new WaitOrTimerCallback(Http.<SetTimeout>g__TimeoutCallback|7_0), this._timeoutState, this.Timeout, true);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002598 File Offset: 0x00000798
		private static void GetRawResponseAsync(IAsyncResult result, [Nullable(new byte[]
		{
			1,
			2
		})] Action<HttpWebResponse> callback)
		{
			HttpWebResponse httpWebResponse;
			try
			{
				httpWebResponse = (((HttpWebRequest)result.AsyncState).EndGetResponse(result) as HttpWebResponse);
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.RequestCanceled)
				{
					throw;
				}
				HttpWebResponse httpWebResponse2 = ex.Response as HttpWebResponse;
				if (httpWebResponse2 == null)
				{
					throw;
				}
				httpWebResponse = httpWebResponse2;
			}
			callback(httpWebResponse);
			if (httpWebResponse != null)
			{
				httpWebResponse.Close();
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002600 File Offset: 0x00000800
		private void ResponseCallback(IAsyncResult result, Action<HttpResponse> callback)
		{
			try
			{
				if (this._timeoutState.TimedOut)
				{
					Http.ExecuteCallback(new HttpResponse
					{
						ResponseStatus = ResponseStatus.TimedOut
					}, callback);
				}
				else
				{
					Http.GetRawResponseAsync(result, delegate(HttpWebResponse webResponse)
					{
						HttpResponse response = this.ExtractResponseData(webResponse);
						if (webResponse != null)
						{
							webResponse.Dispose();
						}
						Http.ExecuteCallback(response, callback);
					});
				}
			}
			catch (Exception ex)
			{
				Http.ExecuteCallback(this.CreateErrorResponse(ex), callback);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002680 File Offset: 0x00000880
		private static void ExecuteCallback(HttpResponse response, Action<HttpResponse> callback)
		{
			if (response.ResponseStatus != ResponseStatus.Completed && response.ErrorException == null)
			{
				response.ErrorException = response.ResponseStatus.ToWebException();
				response.ErrorMessage = response.ErrorException.Message;
			}
			callback(response);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000026BC File Offset: 0x000008BC
		private HttpResponse CreateErrorResponse(Exception ex)
		{
			HttpResponse httpResponse = new HttpResponse
			{
				ErrorMessage = ex.Message,
				ErrorException = ex
			};
			WebException ex2 = ex as WebException;
			if (ex2 != null)
			{
				HttpResponse httpResponse2 = httpResponse;
				WebExceptionStatus status = ex2.Status;
				ResponseStatus responseStatus;
				if (status != WebExceptionStatus.RequestCanceled)
				{
					if (status != WebExceptionStatus.Timeout)
					{
						responseStatus = ResponseStatus.Error;
					}
					else
					{
						responseStatus = ResponseStatus.TimedOut;
					}
				}
				else
				{
					responseStatus = (this._timeoutState.TimedOut ? ResponseStatus.TimedOut : ResponseStatus.Aborted);
				}
				httpResponse2.ResponseStatus = responseStatus;
			}
			else
			{
				httpResponse.ResponseStatus = ResponseStatus.Error;
			}
			return httpResponse;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000272E File Offset: 0x0000092E
		public string FormBoundary { get; } = "---------" + Guid.NewGuid().ToString().ToUpperInvariant();

		// Token: 0x06000027 RID: 39 RVA: 0x00002738 File Offset: 0x00000938
		public Http()
		{
			this._restrictedHeaderActions = new Dictionary<string, Action<HttpWebRequest, string>>(StringComparer.OrdinalIgnoreCase);
			this.<.ctor>g__AddSharedHeaderActions|19_1();
			this.<.ctor>g__AddSyncHeaderActions|19_0();
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000027BF File Offset: 0x000009BF
		protected bool HasParameters
		{
			get
			{
				return this.Parameters.Any<HttpParameter>();
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000027CC File Offset: 0x000009CC
		protected bool HasCookies
		{
			get
			{
				return this.Cookies.Any<HttpCookie>();
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000027D9 File Offset: 0x000009D9
		protected bool HasBody
		{
			get
			{
				return this.RequestBodyBytes != null || !string.IsNullOrEmpty(this.RequestBody);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000027F3 File Offset: 0x000009F3
		protected bool HasFiles
		{
			get
			{
				return this.Files.Any<HttpFile>();
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002800 File Offset: 0x00000A00
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002808 File Offset: 0x00000A08
		internal Func<string, string> Encode { get; set; } = (string s) => s.UrlEncode();

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002811 File Offset: 0x00000A11
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002819 File Offset: 0x00000A19
		public bool AutomaticDecompression { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002822 File Offset: 0x00000A22
		// (set) Token: 0x06000031 RID: 49 RVA: 0x0000282A File Offset: 0x00000A2A
		public bool AlwaysMultipartFormData { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002833 File Offset: 0x00000A33
		// (set) Token: 0x06000033 RID: 51 RVA: 0x0000283B File Offset: 0x00000A3B
		public string UserAgent { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002844 File Offset: 0x00000A44
		// (set) Token: 0x06000035 RID: 53 RVA: 0x0000284C File Offset: 0x00000A4C
		public int Timeout { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002855 File Offset: 0x00000A55
		// (set) Token: 0x06000037 RID: 55 RVA: 0x0000285D File Offset: 0x00000A5D
		public int ReadWriteTimeout { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002866 File Offset: 0x00000A66
		// (set) Token: 0x06000039 RID: 57 RVA: 0x0000286E File Offset: 0x00000A6E
		[Nullable(2)]
		public ICredentials Credentials { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002877 File Offset: 0x00000A77
		// (set) Token: 0x0600003B RID: 59 RVA: 0x0000287F File Offset: 0x00000A7F
		[Nullable(2)]
		public CookieContainer CookieContainer { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002888 File Offset: 0x00000A88
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002890 File Offset: 0x00000A90
		public Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002899 File Offset: 0x00000A99
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000028A1 File Offset: 0x00000AA1
		public Action<Stream> ResponseWriter { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000028AA File Offset: 0x00000AAA
		// (set) Token: 0x06000041 RID: 65 RVA: 0x000028B2 File Offset: 0x00000AB2
		public IList<HttpFile> Files { get; internal set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000028BB File Offset: 0x00000ABB
		// (set) Token: 0x06000043 RID: 67 RVA: 0x000028C3 File Offset: 0x00000AC3
		public bool FollowRedirects { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000028CC File Offset: 0x00000ACC
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000028D4 File Offset: 0x00000AD4
		public bool Pipelined { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000028DD File Offset: 0x00000ADD
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000028E5 File Offset: 0x00000AE5
		[Nullable(2)]
		public X509CertificateCollection ClientCertificates { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000028EE File Offset: 0x00000AEE
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000028F6 File Offset: 0x00000AF6
		public int? MaxRedirects { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000028FF File Offset: 0x00000AFF
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002907 File Offset: 0x00000B07
		public bool UseDefaultCredentials { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002910 File Offset: 0x00000B10
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002918 File Offset: 0x00000B18
		public string ConnectionGroupName { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002921 File Offset: 0x00000B21
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002929 File Offset: 0x00000B29
		public Encoding Encoding { get; set; } = Encoding.UTF8;

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002932 File Offset: 0x00000B32
		// (set) Token: 0x06000051 RID: 81 RVA: 0x0000293A File Offset: 0x00000B3A
		public IList<HttpHeader> Headers { get; internal set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002943 File Offset: 0x00000B43
		// (set) Token: 0x06000053 RID: 83 RVA: 0x0000294B File Offset: 0x00000B4B
		public IList<HttpParameter> Parameters { get; internal set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002954 File Offset: 0x00000B54
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000295C File Offset: 0x00000B5C
		public IList<HttpCookie> Cookies { get; internal set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002965 File Offset: 0x00000B65
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000296D File Offset: 0x00000B6D
		public string RequestBody { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002976 File Offset: 0x00000B76
		// (set) Token: 0x06000059 RID: 89 RVA: 0x0000297E File Offset: 0x00000B7E
		public string RequestContentType { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002987 File Offset: 0x00000B87
		// (set) Token: 0x0600005B RID: 91 RVA: 0x0000298F File Offset: 0x00000B8F
		public byte[] RequestBodyBytes { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002998 File Offset: 0x00000B98
		// (set) Token: 0x0600005D RID: 93 RVA: 0x000029A0 File Offset: 0x00000BA0
		public Uri Url { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000029A9 File Offset: 0x00000BA9
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000029B1 File Offset: 0x00000BB1
		[Nullable(2)]
		public string Host { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000029BA File Offset: 0x00000BBA
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000029C2 File Offset: 0x00000BC2
		public IList<DecompressionMethods> AllowedDecompressionMethods { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000029CB File Offset: 0x00000BCB
		// (set) Token: 0x06000063 RID: 99 RVA: 0x000029D3 File Offset: 0x00000BD3
		public bool PreAuthenticate { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000029DC File Offset: 0x00000BDC
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000029E4 File Offset: 0x00000BE4
		public bool UnsafeAuthenticatedConnectionSharing { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000029ED File Offset: 0x00000BED
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000029F5 File Offset: 0x00000BF5
		[Nullable(2)]
		public IWebProxy Proxy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000029FE File Offset: 0x00000BFE
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002A06 File Offset: 0x00000C06
		[Nullable(2)]
		public RequestCachePolicy CachePolicy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002A0F File Offset: 0x00000C0F
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002A17 File Offset: 0x00000C17
		[Nullable(2)]
		public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002A20 File Offset: 0x00000C20
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002A28 File Offset: 0x00000C28
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<HttpWebRequest> WebRequestConfigurator { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x0600006E RID: 110 RVA: 0x00002A31 File Offset: 0x00000C31
		[Obsolete]
		public static IHttp Create()
		{
			return new Http();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002A38 File Offset: 0x00000C38
		[Obsolete("Overriding this method won't be possible in future version")]
		[return: Nullable(2)]
		protected virtual HttpWebRequest CreateWebRequest(Uri url)
		{
			return null;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002A3B File Offset: 0x00000C3B
		private static HttpWebRequest CreateRequest(Uri uri)
		{
			return (HttpWebRequest)WebRequest.Create(uri);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002A48 File Offset: 0x00000C48
		private string GetMultipartFileHeader(HttpFile file)
		{
			return string.Concat(new string[]
			{
				"--",
				this.FormBoundary,
				"\r\nContent-Disposition: form-data; name=\"",
				file.Name,
				"\"; filename=\"",
				file.FileName,
				"\"\r\nContent-Type: ",
				file.ContentType ?? "application/octet-stream",
				"\r\n\r\n"
			});
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002AB8 File Offset: 0x00000CB8
		private string GetMultipartFormData(HttpParameter param)
		{
			return string.Format((param.Name == this.RequestContentType) ? "--{0}{3}Content-Type: {4}{3}Content-Disposition: form-data; name=\"{1}\"{3}{3}{2}{3}" : "--{0}{3}Content-Disposition: form-data; name=\"{1}\"{3}{3}{2}{3}", new object[]
			{
				this.FormBoundary,
				param.Name,
				param.Value,
				"\r\n",
				param.ContentType
			});
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002B1B File Offset: 0x00000D1B
		private string GetMultipartFooter()
		{
			return "--" + this.FormBoundary + "--\r\n";
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002B34 File Offset: 0x00000D34
		private void PreparePostBody(WebRequest webRequest)
		{
			bool flag = string.IsNullOrEmpty(webRequest.ContentType);
			if (this.HasFiles || this.AlwaysMultipartFormData)
			{
				if (flag)
				{
					webRequest.ContentType = this.<PreparePostBody>g__GetMultipartFormContentType|166_1();
					return;
				}
				if (!webRequest.ContentType.Contains("boundary"))
				{
					webRequest.ContentType = webRequest.ContentType + "; boundary=" + this.FormBoundary;
					return;
				}
			}
			else if (this.HasBody)
			{
				if (flag)
				{
					webRequest.ContentType = this.RequestContentType;
					return;
				}
			}
			else if (this.HasParameters)
			{
				if (flag)
				{
					webRequest.ContentType = "application/x-www-form-urlencoded";
				}
				this.RequestBody = this.<PreparePostBody>g__EncodeParameters|166_0();
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002BD8 File Offset: 0x00000DD8
		private void WriteMultipartFormData(Stream requestStream)
		{
			foreach (HttpParameter param in this.Parameters)
			{
				requestStream.WriteString(this.GetMultipartFormData(param), this.Encoding);
			}
			foreach (HttpFile httpFile in this.Files)
			{
				requestStream.WriteString(this.GetMultipartFileHeader(httpFile), this.Encoding);
				httpFile.Writer(requestStream);
				requestStream.WriteString("\r\n", this.Encoding);
			}
			requestStream.WriteString(this.GetMultipartFooter(), this.Encoding);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002CA8 File Offset: 0x00000EA8
		private HttpResponse ExtractResponseData(HttpWebResponse webResponse)
		{
			Http.<>c__DisplayClass168_0 CS$<>8__locals1 = new Http.<>c__DisplayClass168_0();
			CS$<>8__locals1.webResponse = webResponse;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.response = new HttpResponse
			{
				ContentEncoding = CS$<>8__locals1.webResponse.ContentEncoding,
				Server = CS$<>8__locals1.webResponse.Server,
				ProtocolVersion = CS$<>8__locals1.webResponse.ProtocolVersion,
				ContentType = CS$<>8__locals1.webResponse.ContentType,
				ContentLength = CS$<>8__locals1.webResponse.ContentLength,
				StatusCode = CS$<>8__locals1.webResponse.StatusCode,
				StatusDescription = CS$<>8__locals1.webResponse.StatusDescription,
				ResponseUri = CS$<>8__locals1.webResponse.ResponseUri,
				ResponseStatus = ResponseStatus.Completed
			};
			if (CS$<>8__locals1.webResponse.Cookies != null)
			{
				foreach (object obj in CS$<>8__locals1.webResponse.Cookies)
				{
					Cookie cookie = (Cookie)obj;
					CS$<>8__locals1.response.Cookies.Add(new HttpCookie
					{
						Comment = cookie.Comment,
						CommentUri = cookie.CommentUri,
						Discard = cookie.Discard,
						Domain = cookie.Domain,
						Expired = cookie.Expired,
						Expires = cookie.Expires,
						HttpOnly = cookie.HttpOnly,
						Name = cookie.Name,
						Path = cookie.Path,
						Port = cookie.Port,
						Secure = cookie.Secure,
						TimeStamp = cookie.TimeStamp,
						Value = cookie.Value,
						Version = cookie.Version
					});
				}
			}
			CS$<>8__locals1.response.Headers = (from x in CS$<>8__locals1.webResponse.Headers.AllKeys
			select new HttpHeader(x, CS$<>8__locals1.webResponse.Headers[x])).ToList<HttpHeader>();
			CS$<>8__locals1.webResponseStream = CS$<>8__locals1.webResponse.GetResponseStream();
			if (CS$<>8__locals1.webResponseStream != null)
			{
				CS$<>8__locals1.<ExtractResponseData>g__ProcessResponseStream|1();
			}
			CS$<>8__locals1.webResponse.Close();
			return CS$<>8__locals1.response;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002EE4 File Offset: 0x000010E4
		public HttpResponse Post()
		{
			return this.PostPutInternal("POST");
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002EF1 File Offset: 0x000010F1
		public HttpResponse Put()
		{
			return this.PostPutInternal("PUT");
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002EFE File Offset: 0x000010FE
		public HttpResponse Get()
		{
			return this.GetStyleMethodInternal("GET");
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002F0B File Offset: 0x0000110B
		public HttpResponse Head()
		{
			return this.GetStyleMethodInternal("HEAD");
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002F18 File Offset: 0x00001118
		public HttpResponse Options()
		{
			return this.GetStyleMethodInternal("OPTIONS");
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002F25 File Offset: 0x00001125
		public HttpResponse Delete()
		{
			return this.GetStyleMethodInternal("DELETE");
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002F32 File Offset: 0x00001132
		public HttpResponse Patch()
		{
			return this.PostPutInternal("PATCH");
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002F3F File Offset: 0x0000113F
		public HttpResponse Merge()
		{
			return this.PostPutInternal("MERGE");
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002F4C File Offset: 0x0000114C
		public HttpResponse AsGet(string httpMethod)
		{
			return this.GetStyleMethodInternal(httpMethod.ToUpperInvariant());
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002F5A File Offset: 0x0000115A
		public HttpResponse AsPost(string httpMethod)
		{
			return this.PostPutInternal(httpMethod.ToUpperInvariant());
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002F68 File Offset: 0x00001168
		private HttpResponse GetStyleMethodInternal(string method)
		{
			return this.ExecuteRequest(method, delegate(HttpWebRequest r)
			{
				if (!this.HasBody)
				{
					return;
				}
				if (!base.<GetStyleMethodInternal>g__CanGetWithBody|1())
				{
					throw new NotSupportedException("Http verb " + method + " does not support body");
				}
				r.ContentType = this.RequestContentType;
				this.WriteRequestBody(r);
			});
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002FA1 File Offset: 0x000011A1
		private HttpResponse PostPutInternal(string method)
		{
			return this.ExecuteRequest(method, delegate(HttpWebRequest r)
			{
				this.PreparePostBody(r);
				this.WriteRequestBody(r);
			});
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002FB8 File Offset: 0x000011B8
		private HttpResponse ExecuteRequest(string httpMethod, Action<HttpWebRequest> prepareRequest)
		{
			HttpWebRequest httpWebRequest = this.ConfigureWebRequest(httpMethod, this.Url);
			prepareRequest(httpWebRequest);
			HttpResponse result;
			try
			{
				using (HttpWebResponse httpWebResponse = Http.<ExecuteRequest>g__GetRawResponse|181_1(httpWebRequest))
				{
					result = this.ExtractResponseData(httpWebResponse);
				}
			}
			catch (Exception ex)
			{
				result = Http.<ExecuteRequest>g__ExtractErrorResponse|181_0(ex);
			}
			return result;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000301C File Offset: 0x0000121C
		private void WriteRequestBody(WebRequest webRequest)
		{
			if (this.HasBody || this.HasFiles || this.AlwaysMultipartFormData)
			{
				webRequest.ContentLength = this.CalculateContentLength();
			}
			using (Stream requestStream = webRequest.GetRequestStream())
			{
				if (this.HasFiles || this.AlwaysMultipartFormData)
				{
					this.WriteMultipartFormData(requestStream);
				}
				else if (this.RequestBodyBytes != null)
				{
					requestStream.Write(this.RequestBodyBytes, 0, this.RequestBodyBytes.Length);
				}
				else if (this.RequestBody != null)
				{
					requestStream.WriteString(this.RequestBody, this.Encoding);
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000030C4 File Offset: 0x000012C4
		[Obsolete("Use the WebRequestConfigurator delegate instead of overriding this method")]
		protected virtual HttpWebRequest ConfigureWebRequest(string method, Uri url)
		{
			Http.<>c__DisplayClass183_0 CS$<>8__locals1 = new Http.<>c__DisplayClass183_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.webRequest = (this.CreateWebRequest(url) ?? Http.CreateRequest(url));
			CS$<>8__locals1.webRequest.UseDefaultCredentials = this.UseDefaultCredentials;
			CS$<>8__locals1.webRequest.PreAuthenticate = this.PreAuthenticate;
			CS$<>8__locals1.webRequest.Pipelined = this.Pipelined;
			CS$<>8__locals1.webRequest.UnsafeAuthenticatedConnectionSharing = this.UnsafeAuthenticatedConnectionSharing;
			try
			{
				CS$<>8__locals1.webRequest.ServicePoint.Expect100Continue = false;
			}
			catch (PlatformNotSupportedException)
			{
			}
			CS$<>8__locals1.<ConfigureWebRequest>g__AppendHeaders|1();
			CS$<>8__locals1.<ConfigureWebRequest>g__AppendCookies|2();
			if (this.Host != null)
			{
				CS$<>8__locals1.webRequest.Host = this.Host;
			}
			CS$<>8__locals1.webRequest.Method = method;
			if (!this.HasFiles && !this.AlwaysMultipartFormData && method != "GET")
			{
				CS$<>8__locals1.webRequest.ContentLength = 0L;
			}
			if (this.Credentials != null)
			{
				CS$<>8__locals1.webRequest.Credentials = this.Credentials;
			}
			if (this.UserAgent.HasValue())
			{
				CS$<>8__locals1.webRequest.UserAgent = this.UserAgent;
			}
			if (this.ClientCertificates != null)
			{
				CS$<>8__locals1.webRequest.ClientCertificates.AddRange(this.ClientCertificates);
			}
			this.AllowedDecompressionMethods.ForEach(delegate(DecompressionMethods x)
			{
				CS$<>8__locals1.webRequest.AutomaticDecompression |= x;
			});
			if (this.AutomaticDecompression)
			{
				CS$<>8__locals1.webRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
			}
			if (this.Timeout != 0)
			{
				CS$<>8__locals1.webRequest.Timeout = this.Timeout;
			}
			if (this.ReadWriteTimeout != 0)
			{
				CS$<>8__locals1.webRequest.ReadWriteTimeout = this.ReadWriteTimeout;
			}
			CS$<>8__locals1.webRequest.Proxy = this.Proxy;
			if (this.CachePolicy != null)
			{
				CS$<>8__locals1.webRequest.CachePolicy = this.CachePolicy;
			}
			CS$<>8__locals1.webRequest.AllowAutoRedirect = this.FollowRedirects;
			if (this.FollowRedirects && this.MaxRedirects != null)
			{
				CS$<>8__locals1.webRequest.MaximumAutomaticRedirections = this.MaxRedirects.Value;
			}
			CS$<>8__locals1.webRequest.ServerCertificateValidationCallback = this.RemoteCertificateValidationCallback;
			CS$<>8__locals1.webRequest.ConnectionGroupName = this.ConnectionGroupName;
			Action<HttpWebRequest> webRequestConfigurator = this.WebRequestConfigurator;
			if (webRequestConfigurator != null)
			{
				webRequestConfigurator(CS$<>8__locals1.webRequest);
			}
			return CS$<>8__locals1.webRequest;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003318 File Offset: 0x00001518
		[Obsolete]
		public HttpWebRequest DeleteAsync(Action<HttpResponse> action)
		{
			return this.GetStyleMethodInternalAsync("DELETE", action);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003326 File Offset: 0x00001526
		[Obsolete]
		public HttpWebRequest GetAsync(Action<HttpResponse> action)
		{
			return this.GetStyleMethodInternalAsync("GET", action);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003334 File Offset: 0x00001534
		[Obsolete]
		public HttpWebRequest HeadAsync(Action<HttpResponse> action)
		{
			return this.GetStyleMethodInternalAsync("HEAD", action);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003342 File Offset: 0x00001542
		[Obsolete]
		public HttpWebRequest OptionsAsync(Action<HttpResponse> action)
		{
			return this.GetStyleMethodInternalAsync("OPTIONS", action);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003350 File Offset: 0x00001550
		[Obsolete]
		public HttpWebRequest PostAsync(Action<HttpResponse> action)
		{
			return this.PutPostInternalAsync("POST", action);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000335E File Offset: 0x0000155E
		[Obsolete]
		public HttpWebRequest PutAsync(Action<HttpResponse> action)
		{
			return this.PutPostInternalAsync("PUT", action);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000336C File Offset: 0x0000156C
		[Obsolete]
		public HttpWebRequest PatchAsync(Action<HttpResponse> action)
		{
			return this.PutPostInternalAsync("PATCH", action);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000337A File Offset: 0x0000157A
		[Obsolete]
		public HttpWebRequest MergeAsync(Action<HttpResponse> action)
		{
			return this.PutPostInternalAsync("MERGE", action);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003388 File Offset: 0x00001588
		[Obsolete("Use the WebRequestConfigurator delegate instead of overriding this method")]
		protected virtual HttpWebRequest ConfigureAsyncWebRequest(string method, Uri url)
		{
			return this.ConfigureWebRequest(method, url);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000033BC File Offset: 0x000015BC
		[CompilerGenerated]
		internal static void <SetTimeout>g__TimeoutCallback|7_0(object state, bool timedOut)
		{
			if (!timedOut)
			{
				return;
			}
			Http.TimeOutState timeOutState = state as Http.TimeOutState;
			if (timeOutState == null)
			{
				return;
			}
			Http.TimeOutState obj = timeOutState;
			lock (obj)
			{
				timeOutState.TimedOut = true;
			}
			HttpWebRequest request = timeOutState.Request;
			if (request == null)
			{
				return;
			}
			request.Abort();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003418 File Offset: 0x00001618
		[CompilerGenerated]
		private void <.ctor>g__AddSyncHeaderActions|19_0()
		{
			this._restrictedHeaderActions.Add("Connection", delegate(HttpWebRequest r, string v)
			{
				r.KeepAlive = v.ToLowerInvariant().Contains("keep-alive");
			});
			this._restrictedHeaderActions.Add("Content-Length", delegate(HttpWebRequest r, string v)
			{
				r.ContentLength = Convert.ToInt64(v);
			});
			this._restrictedHeaderActions.Add("Expect", delegate(HttpWebRequest r, string v)
			{
				r.Expect = v;
			});
			this._restrictedHeaderActions.Add("If-Modified-Since", delegate(HttpWebRequest r, string v)
			{
				r.IfModifiedSince = Convert.ToDateTime(v, CultureInfo.InvariantCulture);
			});
			this._restrictedHeaderActions.Add("Referer", delegate(HttpWebRequest r, string v)
			{
				r.Referer = v;
			});
			this._restrictedHeaderActions.Add("Transfer-Encoding", delegate(HttpWebRequest r, string v)
			{
				r.TransferEncoding = v;
				r.SendChunked = true;
			});
			this._restrictedHeaderActions.Add("User-Agent", delegate(HttpWebRequest r, string v)
			{
				r.UserAgent = v;
			});
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003570 File Offset: 0x00001770
		[CompilerGenerated]
		private void <.ctor>g__AddSharedHeaderActions|19_1()
		{
			this._restrictedHeaderActions.Add("Accept", delegate(HttpWebRequest r, string v)
			{
				r.Accept = v;
			});
			this._restrictedHeaderActions.Add("Content-Type", delegate(HttpWebRequest r, string v)
			{
				r.ContentType = v;
			});
			this._restrictedHeaderActions.Add("Date", delegate(HttpWebRequest r, string v)
			{
				DateTime date;
				if (DateTime.TryParse(v, out date))
				{
					r.Date = date;
				}
			});
			this._restrictedHeaderActions.Add("Host", delegate(HttpWebRequest r, string v)
			{
				r.Host = v;
			});
			this._restrictedHeaderActions.Add("Range", new Action<HttpWebRequest, string>(Http.<.ctor>g__AddRange|19_13));
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003658 File Offset: 0x00001858
		[CompilerGenerated]
		internal static void <.ctor>g__AddRange|19_13(HttpWebRequest r, string range)
		{
			Match match = Http.AddRangeRegex.Match(range);
			if (!match.Success)
			{
				return;
			}
			string value = match.Groups[1].Value;
			long from = Convert.ToInt64(match.Groups[2].Value);
			long to = Convert.ToInt64(match.Groups[3].Value);
			r.AddRange(value, from, to);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000036C3 File Offset: 0x000018C3
		[CompilerGenerated]
		private string <PreparePostBody>g__EncodeParameters|166_0()
		{
			return string.Join("&", from p in this.Parameters
			select this.Encode(p.Name) + "=" + this.Encode(p.Value));
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003714 File Offset: 0x00001914
		[CompilerGenerated]
		private string <PreparePostBody>g__GetMultipartFormContentType|166_1()
		{
			return "multipart/form-data; boundary=" + this.FormBoundary;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003738 File Offset: 0x00001938
		[CompilerGenerated]
		internal static HttpResponse <ExecuteRequest>g__ExtractErrorResponse|181_0(Exception ex)
		{
			HttpResponse httpResponse = new HttpResponse
			{
				ErrorMessage = ex.Message
			};
			WebException ex2 = ex as WebException;
			if (ex2 != null && ex2.Status == WebExceptionStatus.Timeout)
			{
				httpResponse.ResponseStatus = ResponseStatus.TimedOut;
				httpResponse.ErrorException = ex2;
			}
			else
			{
				httpResponse.ErrorException = ex;
				httpResponse.ResponseStatus = ResponseStatus.Error;
			}
			return httpResponse;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000378C File Offset: 0x0000198C
		[CompilerGenerated]
		internal static HttpWebResponse <ExecuteRequest>g__GetRawResponse|181_1(WebRequest request)
		{
			HttpWebResponse result;
			try
			{
				result = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException ex)
			{
				HttpWebResponse httpWebResponse = ex.Response as HttpWebResponse;
				if (httpWebResponse == null)
				{
					throw;
				}
				result = httpWebResponse;
			}
			return result;
		}

		// Token: 0x04000029 RID: 41
		private Http.TimeOutState _timeoutState;

		// Token: 0x0400002A RID: 42
		private const string LineBreak = "\r\n";

		// Token: 0x0400002C RID: 44
		private static readonly Regex AddRangeRegex = new Regex("(\\w+)=(\\d+)-(\\d+)$");

		// Token: 0x0400002D RID: 45
		private readonly IDictionary<string, Action<HttpWebRequest, string>> _restrictedHeaderActions;

		// Token: 0x0200006A RID: 106
		[NullableContext(2)]
		[Nullable(0)]
		private class TimeOutState
		{
			// Token: 0x1700018C RID: 396
			// (get) Token: 0x0600059F RID: 1439 RVA: 0x0000DCCB File Offset: 0x0000BECB
			// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0000DCD3 File Offset: 0x0000BED3
			public bool TimedOut { get; set; }

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000DCDC File Offset: 0x0000BEDC
			// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0000DCE4 File Offset: 0x0000BEE4
			public HttpWebRequest Request { get; set; }
		}
	}
}
