using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth.Extensions;
using RestSharp.Deserializers;
using RestSharp.Extensions;
using RestSharp.Serialization;
using RestSharp.Serialization.Json;
using RestSharp.Serialization.Xml;
using RestSharp.Serializers;
using RestSharp.Validation;

namespace RestSharp
{
	// Token: 0x0200001A RID: 26
	[NullableContext(1)]
	[Nullable(0)]
	public class RestClient : IRestClient
	{
		// Token: 0x0600022F RID: 559 RVA: 0x00003C8B File Offset: 0x00001E8B
		private static HttpWebRequest DoAsGetAsync(IHttp http, Action<HttpResponse> responseCb, string method)
		{
			return http.AsGetAsync(responseCb, method);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00003C95 File Offset: 0x00001E95
		private static HttpWebRequest DoAsPostAsync(IHttp http, Action<HttpResponse> responseCb, string method)
		{
			return http.AsPostAsync(responseCb, method);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00003C9F File Offset: 0x00001E9F
		[Obsolete("Use ExecuteAsync instead")]
		public virtual Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token, Method httpMethod)
		{
			return this.ExecuteAsync(request, httpMethod, token);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00003CAC File Offset: 0x00001EAC
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, Method httpMethod)
		{
			string name = Enum.GetName(typeof(Method), httpMethod);
			switch (httpMethod)
			{
			case Method.POST:
				return this.ExecuteAsync(request, callback, name, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsPostAsync));
			case Method.PUT:
				return this.ExecuteAsync(request, callback, name, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsPostAsync));
			case Method.PATCH:
				return this.ExecuteAsync(request, callback, name, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsPostAsync));
			case Method.MERGE:
				return this.ExecuteAsync(request, callback, name, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsPostAsync));
			case Method.COPY:
				return this.ExecuteAsync(request, callback, name, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsPostAsync));
			}
			return this.ExecuteAsync(request, callback, name, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsGetAsync));
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00003D88 File Offset: 0x00001F88
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return this.ExecuteAsync(request, callback, request.Method);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00003D98 File Offset: 0x00001F98
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
		{
			return this.ExecuteAsync(request, callback, httpMethod, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsGetAsync));
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00003DAF File Offset: 0x00001FAF
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
		{
			request.Method = Method.POST;
			return this.ExecuteAsync(request, callback, httpMethod, new Func<IHttp, Action<HttpResponse>, string, HttpWebRequest>(RestClient.DoAsPostAsync));
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00003DCD File Offset: 0x00001FCD
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsync<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, Method httpMethod)
		{
			Ensure.NotNull(request, "request");
			Ensure.NotNull(callback, "callback");
			request.Method = httpMethod;
			return this.ExecuteAsync<T>(request, callback);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00003DF4 File Offset: 0x00001FF4
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsync<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
		{
			return this.ExecuteAsync(request, delegate(IRestResponse response, RestRequestAsyncHandle asyncHandle)
			{
				this.DeserializeResponse<T>(request, callback, response, asyncHandle);
			});
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00003E34 File Offset: 0x00002034
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsyncGet<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
		{
			return this.ExecuteAsyncGet(request, delegate(IRestResponse response, RestRequestAsyncHandle asyncHandle)
			{
				this.DeserializeResponse<T>(request, callback, response, asyncHandle);
			}, httpMethod);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00003E78 File Offset: 0x00002078
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		public virtual RestRequestAsyncHandle ExecuteAsyncPost<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
		{
			return this.ExecuteAsyncPost(request, delegate(IRestResponse response, RestRequestAsyncHandle asyncHandle)
			{
				this.DeserializeResponse<T>(request, callback, response, asyncHandle);
			}, httpMethod);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00003EB9 File Offset: 0x000020B9
		[Obsolete("This method will be renamed to ExecuteGetAsync soon")]
		public virtual Task<IRestResponse<T>> ExecuteGetTaskAsync<[Nullable(2)] T>(IRestRequest request)
		{
			return this.ExecuteGetAsync<T>(request, CancellationToken.None);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00003EC7 File Offset: 0x000020C7
		[Obsolete("Use ExecuteAsync instead")]
		public virtual Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
		{
			return this.ExecuteAsync(request, token);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00003ED1 File Offset: 0x000020D1
		[Obsolete("Use ExecuteAsync instead")]
		public virtual Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token, Method httpMethod)
		{
			return this.ExecuteAsync<T>(request, httpMethod, token);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00003EDC File Offset: 0x000020DC
		[Obsolete("Use ExecuteGetAsync instead")]
		public virtual Task<IRestResponse<T>> ExecuteGetTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token)
		{
			return this.ExecuteTaskAsync<T>(request, token, Method.GET);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00003EE7 File Offset: 0x000020E7
		[Obsolete("Use ExecutePostAsync instead")]
		public virtual Task<IRestResponse<T>> ExecutePostTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token)
		{
			return this.ExecuteAsync<T>(request, Method.POST, token);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00003EF2 File Offset: 0x000020F2
		[Obsolete("Use ExecutePostAsync instead")]
		public virtual Task<IRestResponse<T>> ExecutePostTaskAsync<[Nullable(2)] T>(IRestRequest request)
		{
			return this.ExecutePostAsync<T>(request, CancellationToken.None);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00003F00 File Offset: 0x00002100
		[Obsolete("Please use ExecuteAsync instead")]
		public virtual Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request, Method httpMethod)
		{
			return this.ExecuteAsync<T>(request, httpMethod, CancellationToken.None);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00003F10 File Offset: 0x00002110
		[Obsolete("Please use ExecuteAsync instead")]
		public virtual Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request)
		{
			return this.ExecuteAsync<T>(request, default(CancellationToken));
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00003F2D File Offset: 0x0000212D
		[Obsolete("Please use ExecuteAsync instead")]
		public virtual Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token)
		{
			return this.ExecuteAsync<T>(request, token);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00003F37 File Offset: 0x00002137
		[Obsolete("This method will be renamed to ExecutePostAsync soon")]
		public virtual Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
		{
			return this.ExecutePostAsync(request, token);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00003F41 File Offset: 0x00002141
		[Obsolete("Use ExecutePostAsync instead")]
		public virtual Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
		{
			return this.ExecutePostAsync(request, CancellationToken.None);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00003F4F File Offset: 0x0000214F
		[Obsolete("Use ExecuteAsync instead")]
		public virtual Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
		{
			return this.ExecuteAsync(request, CancellationToken.None);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00003F5D File Offset: 0x0000215D
		[Obsolete("Use ExecuteGetAsync instead")]
		public virtual Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
		{
			return this.ExecuteGetAsync(request, CancellationToken.None);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00003F6B File Offset: 0x0000216B
		[Obsolete("Use ExecuteGetAsync instead")]
		public virtual Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
		{
			return this.ExecuteGetAsync(request, token);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00003F75 File Offset: 0x00002175
		public Task<IRestResponse<T>> ExecuteGetAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.ExecuteAsync<T>(request, Method.GET, cancellationToken);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00003F80 File Offset: 0x00002180
		public Task<IRestResponse<T>> ExecutePostAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.ExecuteAsync<T>(request, Method.POST, cancellationToken);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00003F8B File Offset: 0x0000218B
		public Task<IRestResponse> ExecuteGetAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.ExecuteAsync(request, Method.GET, cancellationToken);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00003F96 File Offset: 0x00002196
		public Task<IRestResponse> ExecutePostAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.ExecuteAsync(request, Method.POST, cancellationToken);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00003FA4 File Offset: 0x000021A4
		public Task<IRestResponse<T>> ExecuteAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			TaskCompletionSource<IRestResponse<T>> taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
			try
			{
				RestRequestAsyncHandle async = this.ExecuteAsync<T>(request, delegate([Nullable(new byte[]
				{
					1,
					0
				})] IRestResponse<T> response, RestRequestAsyncHandle _)
				{
					if (cancellationToken.IsCancellationRequested)
					{
						taskCompletionSource.TrySetCanceled();
						return;
					}
					taskCompletionSource.TrySetResult(response);
				});
				CancellationTokenRegistration registration = cancellationToken.Register(delegate()
				{
					async.Abort();
					taskCompletionSource.TrySetCanceled();
				});
				taskCompletionSource.Task.ContinueWith(delegate([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> t)
				{
					registration.Dispose();
				}, cancellationToken);
			}
			catch (Exception exception)
			{
				taskCompletionSource.TrySetException(exception);
			}
			return taskCompletionSource.Task;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00004080 File Offset: 0x00002280
		public Task<IRestResponse> ExecuteAsync(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken))
		{
			Ensure.NotNull(request, "request");
			request.Method = httpMethod;
			return this.ExecuteAsync(request, cancellationToken);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000409C File Offset: 0x0000229C
		public Task<IRestResponse<T>> ExecuteAsync<[Nullable(2)] T>(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken))
		{
			Ensure.NotNull(request, "request");
			request.Method = httpMethod;
			return this.ExecuteAsync<T>(request, cancellationToken);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000040B8 File Offset: 0x000022B8
		public Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken token = default(CancellationToken))
		{
			Ensure.NotNull(request, "request");
			TaskCompletionSource<IRestResponse> taskCompletionSource = new TaskCompletionSource<IRestResponse>();
			try
			{
				RestRequestAsyncHandle async = this.ExecuteAsync(request, delegate(IRestResponse response, RestRequestAsyncHandle _)
				{
					if (token.IsCancellationRequested)
					{
						taskCompletionSource.TrySetCanceled();
						return;
					}
					taskCompletionSource.TrySetResult(response);
				});
				CancellationTokenRegistration registration = token.Register(delegate()
				{
					async.Abort();
					taskCompletionSource.TrySetCanceled();
				});
				taskCompletionSource.Task.ContinueWith(delegate([Nullable(new byte[]
				{
					0,
					1
				})] Task<IRestResponse> t)
				{
					registration.Dispose();
				}, token);
			}
			catch (Exception exception)
			{
				taskCompletionSource.TrySetException(exception);
			}
			return taskCompletionSource.Task;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00004190 File Offset: 0x00002390
		private RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod, Func<IHttp, Action<HttpResponse>, string, HttpWebRequest> getWebRequest)
		{
			RestClient.<>c__DisplayClass33_0 CS$<>8__locals1 = new RestClient.<>c__DisplayClass33_0();
			CS$<>8__locals1.request = request;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.request.SerializeRequestBody(this.Serializers, new ISerializer[]
			{
				CS$<>8__locals1.request.XmlSerializer,
				CS$<>8__locals1.request.JsonSerializer
			});
			this.AuthenticateIfNeeded(CS$<>8__locals1.request);
			IHttp http = this.ConfigureHttp(CS$<>8__locals1.request);
			Action<IHttp> onBeforeRequest = CS$<>8__locals1.request.OnBeforeRequest;
			if (onBeforeRequest != null)
			{
				onBeforeRequest(http);
			}
			CS$<>8__locals1.asyncHandle = new RestRequestAsyncHandle();
			Action<HttpResponse> action = new Action<HttpResponse>(CS$<>8__locals1.<ExecuteAsync>g__ProcessResponse|0);
			if (this.UseSynchronizationContext && SynchronizationContext.Current != null)
			{
				SynchronizationContext ctx = SynchronizationContext.Current;
				Action<HttpResponse> cb = action;
				action = delegate(HttpResponse resp)
				{
					ctx.Post(delegate(object s)
					{
						cb(resp);
					}, null);
				};
			}
			CS$<>8__locals1.asyncHandle.WebRequest = getWebRequest(http, action, httpMethod);
			return CS$<>8__locals1.asyncHandle;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00004279 File Offset: 0x00002479
		private void DeserializeResponse<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, IRestResponse response, RestRequestAsyncHandle asyncHandle)
		{
			callback(this.Deserialize<T>(request, response), asyncHandle);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000428C File Offset: 0x0000248C
		public RestClient()
		{
			this.Encoding = Encoding.UTF8;
			this.ContentHandlers = new Dictionary<string, Func<IDeserializer>>();
			this.Serializers = new Dictionary<DataFormat, IRestSerializer>();
			this.AcceptTypes = new List<string>();
			this.DefaultParameters = new List<Parameter>();
			this.AutomaticDecompression = true;
			this.UseSerializer<JsonSerializer>();
			this.UseSerializer<XmlRestSerializer>();
			this.FollowRedirects = true;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000434E File Offset: 0x0000254E
		public RestClient(Uri baseUrl) : this()
		{
			this.BaseUrl = baseUrl;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000435D File Offset: 0x0000255D
		public RestClient(string baseUrl) : this()
		{
			if (baseUrl.IsEmpty())
			{
				throw new ArgumentNullException("baseUrl");
			}
			this.BaseUrl = new Uri(baseUrl);
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00004384 File Offset: 0x00002584
		private IDictionary<string, Func<IDeserializer>> ContentHandlers { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0000438C File Offset: 0x0000258C
		internal IDictionary<DataFormat, IRestSerializer> Serializers { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00004394 File Offset: 0x00002594
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0000439C File Offset: 0x0000259C
		private Func<string, string> Encode { get; set; } = (string s) => s.UrlEncode();

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000259 RID: 601 RVA: 0x000043A5 File Offset: 0x000025A5
		// (set) Token: 0x0600025A RID: 602 RVA: 0x000043AD File Offset: 0x000025AD
		private Func<string, Encoding, string> EncodeQuery { get; set; } = (string s, Encoding encoding) => s.UrlEncode(encoding);

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600025B RID: 603 RVA: 0x000043B6 File Offset: 0x000025B6
		private IList<string> AcceptTypes { get; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000043BE File Offset: 0x000025BE
		// (set) Token: 0x0600025D RID: 605 RVA: 0x000043C6 File Offset: 0x000025C6
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<HttpWebRequest> WebRequestConfigurator { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x0600025E RID: 606 RVA: 0x000043D0 File Offset: 0x000025D0
		[Obsolete("Use the overload that accepts the delegate factory")]
		public IRestClient UseSerializer(IRestSerializer serializer)
		{
			Func<IRestSerializer> <>9__1;
			return this.With(delegate(RestClient x)
			{
				Func<IRestSerializer> serializerFactory;
				if ((serializerFactory = <>9__1) == null)
				{
					serializerFactory = (<>9__1 = (() => serializer));
				}
				x.UseSerializer(serializerFactory);
			});
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000043FC File Offset: 0x000025FC
		public IRestClient UseUrlEncoder(Func<string, string> encoder)
		{
			return this.With(delegate(RestClient x)
			{
				x.Encode = encoder;
			});
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00004428 File Offset: 0x00002628
		public IRestClient UseQueryEncoder(Func<string, Encoding, string> queryEncoder)
		{
			return this.With(delegate(RestClient x)
			{
				x.EncodeQuery = queryEncoder;
			});
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00004454 File Offset: 0x00002654
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000445C File Offset: 0x0000265C
		public bool AutomaticDecompression { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00004465 File Offset: 0x00002665
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0000446D File Offset: 0x0000266D
		public int? MaxRedirects { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00004476 File Offset: 0x00002676
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0000447E File Offset: 0x0000267E
		[Nullable(2)]
		public X509CertificateCollection ClientCertificates { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00004487 File Offset: 0x00002687
		// (set) Token: 0x06000268 RID: 616 RVA: 0x0000448F File Offset: 0x0000268F
		[Nullable(2)]
		public IWebProxy Proxy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00004498 File Offset: 0x00002698
		// (set) Token: 0x0600026A RID: 618 RVA: 0x000044A0 File Offset: 0x000026A0
		[Nullable(2)]
		public RequestCachePolicy CachePolicy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600026B RID: 619 RVA: 0x000044A9 File Offset: 0x000026A9
		// (set) Token: 0x0600026C RID: 620 RVA: 0x000044B1 File Offset: 0x000026B1
		public bool Pipelined { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600026D RID: 621 RVA: 0x000044BA File Offset: 0x000026BA
		// (set) Token: 0x0600026E RID: 622 RVA: 0x000044C2 File Offset: 0x000026C2
		public bool FollowRedirects { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600026F RID: 623 RVA: 0x000044CB File Offset: 0x000026CB
		// (set) Token: 0x06000270 RID: 624 RVA: 0x000044D3 File Offset: 0x000026D3
		[Nullable(2)]
		public CookieContainer CookieContainer { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000271 RID: 625 RVA: 0x000044DC File Offset: 0x000026DC
		// (set) Token: 0x06000272 RID: 626 RVA: 0x000044E4 File Offset: 0x000026E4
		public string UserAgent { get; set; } = RestClient.DefaultUserAgent;

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000273 RID: 627 RVA: 0x000044ED File Offset: 0x000026ED
		// (set) Token: 0x06000274 RID: 628 RVA: 0x000044F5 File Offset: 0x000026F5
		public int Timeout { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000275 RID: 629 RVA: 0x000044FE File Offset: 0x000026FE
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00004506 File Offset: 0x00002706
		public int ReadWriteTimeout { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0000450F File Offset: 0x0000270F
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00004517 File Offset: 0x00002717
		public bool UseSynchronizationContext { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00004520 File Offset: 0x00002720
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00004528 File Offset: 0x00002728
		[Nullable(2)]
		public IAuthenticator Authenticator { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00004531 File Offset: 0x00002731
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00004539 File Offset: 0x00002739
		[Nullable(2)]
		public virtual Uri BaseUrl { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00004542 File Offset: 0x00002742
		// (set) Token: 0x0600027E RID: 638 RVA: 0x0000454A File Offset: 0x0000274A
		public Encoding Encoding { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00004553 File Offset: 0x00002753
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000455B File Offset: 0x0000275B
		public bool PreAuthenticate { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00004564 File Offset: 0x00002764
		// (set) Token: 0x06000282 RID: 642 RVA: 0x0000456C File Offset: 0x0000276C
		public bool ThrowOnDeserializationError { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00004575 File Offset: 0x00002775
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0000457D File Offset: 0x0000277D
		public bool FailOnDeserializationError { get; set; } = true;

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00004586 File Offset: 0x00002786
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0000458E File Offset: 0x0000278E
		public bool ThrowOnAnyError { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00004597 File Offset: 0x00002797
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0000459F File Offset: 0x0000279F
		public bool UnsafeAuthenticatedConnectionSharing { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000289 RID: 649 RVA: 0x000045A8 File Offset: 0x000027A8
		// (set) Token: 0x0600028A RID: 650 RVA: 0x000045B0 File Offset: 0x000027B0
		[Nullable(2)]
		public string ConnectionGroupName { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000045B9 File Offset: 0x000027B9
		// (set) Token: 0x0600028C RID: 652 RVA: 0x000045C1 File Offset: 0x000027C1
		[Nullable(2)]
		public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000045CA File Offset: 0x000027CA
		public IList<Parameter> DefaultParameters { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000045D2 File Offset: 0x000027D2
		// (set) Token: 0x0600028F RID: 655 RVA: 0x000045DA File Offset: 0x000027DA
		[Nullable(2)]
		public string BaseHost { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000290 RID: 656 RVA: 0x000045E3 File Offset: 0x000027E3
		// (set) Token: 0x06000291 RID: 657 RVA: 0x000045EB File Offset: 0x000027EB
		public bool AllowMultipleDefaultParametersWithSameName { get; set; }

		// Token: 0x06000292 RID: 658 RVA: 0x000045F4 File Offset: 0x000027F4
		public void AddHandler(string contentType, Func<IDeserializer> deserializerFactory)
		{
			this.ContentHandlers[contentType] = deserializerFactory;
			if (contentType == "*" || RestClient.IsWildcardStructuredSuffixSyntax(contentType))
			{
				return;
			}
			if (!this.AcceptTypes.Contains(contentType))
			{
				this.AcceptTypes.Add(contentType);
			}
			string value = this.AcceptTypes.JoinToString(", ");
			this.AddOrUpdateDefaultParameter(new Parameter("Accept", value, ParameterType.HttpHeader));
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00004664 File Offset: 0x00002864
		[Obsolete("Use the overload that accepts a factory delegate")]
		public void AddHandler(string contentType, IDeserializer deserializer)
		{
			this.AddHandler(contentType, () => deserializer);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00004691 File Offset: 0x00002891
		public void RemoveHandler(string contentType)
		{
			this.ContentHandlers.Remove(contentType);
			this.AcceptTypes.Remove(contentType);
			this.RemoveDefaultParameter("Accept");
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000046B9 File Offset: 0x000028B9
		public void ClearHandlers()
		{
			this.ContentHandlers.Clear();
			this.AcceptTypes.Clear();
			this.RemoveDefaultParameter("Accept");
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000046DD File Offset: 0x000028DD
		public IRestResponse<T> Deserialize<[Nullable(2)] T>(IRestResponse response)
		{
			return this.Deserialize<T>(response.Request, response);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000046EC File Offset: 0x000028EC
		public void ConfigureWebRequest(Action<HttpWebRequest> configurator)
		{
			this.WebRequestConfigurator = configurator;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000046F8 File Offset: 0x000028F8
		public Uri BuildUri(IRestRequest request)
		{
			this.DoBuildUriValidations(request);
			RestClient.UrlSegmentParamsValues urlSegmentParamsValues = this.GetUrlSegmentParamsValues(request);
			string mergedUri = RestClient.MergeBaseUrlAndResource(urlSegmentParamsValues.Uri, urlSegmentParamsValues.Resource);
			return new Uri(this.ApplyQueryStringParamsValuesToUri(mergedUri, request));
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00004734 File Offset: 0x00002934
		string IRestClient.BuildUriWithoutQueryParameters(IRestRequest request)
		{
			this.DoBuildUriValidations(request);
			RestClient.UrlSegmentParamsValues urlSegmentParamsValues = this.GetUrlSegmentParamsValues(request);
			return RestClient.MergeBaseUrlAndResource(urlSegmentParamsValues.Uri, urlSegmentParamsValues.Resource);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00004764 File Offset: 0x00002964
		public IRestClient UseSerializer(Func<IRestSerializer> serializerFactory)
		{
			IRestSerializer restSerializer = serializerFactory();
			this.Serializers[restSerializer.DataFormat] = restSerializer;
			this.AddHandler(serializerFactory, restSerializer.SupportedContentTypes);
			return this;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00004798 File Offset: 0x00002998
		public IRestClient UseSerializer<[Nullable(0)] T>() where T : IRestSerializer, new()
		{
			return this.UseSerializer(() => Activator.CreateInstance<T>());
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000047C0 File Offset: 0x000029C0
		private void AddHandler(Func<IDeserializer> deserializerFactory, params string[] contentTypes)
		{
			foreach (string contentType in contentTypes)
			{
				this.AddHandler(contentType, deserializerFactory);
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000047EC File Offset: 0x000029EC
		private void DoBuildUriValidations(IRestRequest request)
		{
			if (this.BaseUrl == null && !request.Resource.ToLowerInvariant().StartsWith("http"))
			{
				throw new ArgumentOutOfRangeException("request", "Request resource doesn't contain a valid scheme for an empty client base URL");
			}
			string[] array = (from p in request.Parameters
			where p.Type == ParameterType.UrlSegment && p.Value == null
			select p.Name).ToArray<string>();
			if (array.Any<string>())
			{
				string str = array.JoinToString(", ", (string name) => "'" + name + "'");
				throw new ArgumentException("Cannot build uri when url segment parameter(s) " + str + " value is null.", "request");
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000048D0 File Offset: 0x00002AD0
		private RestClient.UrlSegmentParamsValues GetUrlSegmentParamsValues(IRestRequest request)
		{
			string text = (this.BaseUrl == null) ? "" : request.Resource;
			Uri uri = this.BaseUrl ?? new Uri(request.Resource);
			bool flag = !text.IsEmpty();
			List<Parameter> list = (from p in request.Parameters
			where p.Type == ParameterType.UrlSegment
			select p).ToList<Parameter>();
			list.AddRange(from p in this.DefaultParameters
			where p.Type == ParameterType.UrlSegment
			select p);
			UriBuilder uriBuilder = new UriBuilder(uri);
			foreach (Parameter parameter in list)
			{
				string oldValue = "{" + parameter.Name + "}";
				string newValue = this.Encode(parameter.Value.ToString());
				if (flag)
				{
					text = text.Replace(oldValue, newValue);
				}
				uriBuilder.Path = uriBuilder.Path.UrlDecode().Replace(oldValue, newValue);
			}
			return new RestClient.UrlSegmentParamsValues(uriBuilder.Uri, text);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00004A20 File Offset: 0x00002C20
		private static string MergeBaseUrlAndResource(Uri baseUrl, string resource)
		{
			string text = resource;
			if (!string.IsNullOrEmpty(text) && text.StartsWith("/"))
			{
				text = text.Substring(1);
			}
			if (baseUrl == null || string.IsNullOrEmpty(baseUrl.AbsoluteUri))
			{
				return text;
			}
			Uri baseUri = (baseUrl.AbsoluteUri.EndsWith("/") || string.IsNullOrEmpty(text)) ? baseUrl : new Uri(baseUrl.AbsoluteUri + "/");
			if (text == null)
			{
				return baseUrl.AbsoluteUri;
			}
			return new Uri(baseUri, text).AbsoluteUri;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00004AB0 File Offset: 0x00002CB0
		private string ApplyQueryStringParamsValuesToUri(string mergedUri, IRestRequest request)
		{
			List<Parameter> list = RestClient.GetQueryStringParameters(request).ToList<Parameter>();
			list.AddRange(this.GetDefaultQueryStringParameters(request));
			if (!list.Any<Parameter>())
			{
				return mergedUri;
			}
			string str = (mergedUri != null && mergedUri.Contains("?")) ? "&" : "?";
			return mergedUri + str + this.EncodeParameters(list, this.Encoding);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00004B14 File Offset: 0x00002D14
		private IEnumerable<Parameter> GetDefaultQueryStringParameters(IRestRequest request)
		{
			if (request.Method == Method.POST || request.Method == Method.PUT || request.Method == Method.PATCH)
			{
				return from p in this.DefaultParameters
				where p.Type == ParameterType.QueryString || p.Type == ParameterType.QueryStringWithoutEncode
				select p;
			}
			return from p in this.DefaultParameters
			where p.Type == ParameterType.GetOrPost || p.Type == ParameterType.QueryString || p.Type == ParameterType.QueryStringWithoutEncode
			select p;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00004B94 File Offset: 0x00002D94
		private static IEnumerable<Parameter> GetQueryStringParameters(IRestRequest request)
		{
			if (request.Method == Method.POST || request.Method == Method.PUT || request.Method == Method.PATCH)
			{
				return from p in request.Parameters
				where p.Type == ParameterType.QueryString || p.Type == ParameterType.QueryStringWithoutEncode
				select p;
			}
			return from p in request.Parameters
			where p.Type == ParameterType.GetOrPost || p.Type == ParameterType.QueryString || p.Type == ParameterType.QueryStringWithoutEncode
			select p;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00004C14 File Offset: 0x00002E14
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<IDeserializer> GetHandler(string contentType)
		{
			if (contentType.IsEmpty() && this.ContentHandlers.ContainsKey("*"))
			{
				return this.ContentHandlers["*"];
			}
			if (contentType.IsEmpty())
			{
				return this.ContentHandlers.First<KeyValuePair<string, Func<IDeserializer>>>().Value;
			}
			int num = contentType.IndexOf(';');
			if (num > -1)
			{
				contentType = contentType.Substring(0, num);
			}
			Func<IDeserializer> result;
			if (this.ContentHandlers.TryGetValue(contentType, out result))
			{
				return result;
			}
			if (contentType.IndexOf('+') >= 0)
			{
				Match match = RestClient.StructuredSyntaxSuffixRegex.Match(contentType);
				if (match.Success)
				{
					string key = "*" + match.Value;
					Func<IDeserializer> result2;
					if (this.ContentHandlers.TryGetValue(key, out result2))
					{
						return result2;
					}
				}
			}
			if (!this.ContentHandlers.ContainsKey("*"))
			{
				return null;
			}
			return this.ContentHandlers["*"];
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00004CFA File Offset: 0x00002EFA
		private void AuthenticateIfNeeded(IRestRequest request)
		{
			IAuthenticator authenticator = this.Authenticator;
			if (authenticator == null)
			{
				return;
			}
			authenticator.Authenticate(this, request);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00004D10 File Offset: 0x00002F10
		private string EncodeParameters(IEnumerable<Parameter> parameters, Encoding encoding)
		{
			return string.Join("&", (from parameter in parameters
			select this.EncodeParameter(parameter, encoding)).ToArray<string>());
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00004D54 File Offset: 0x00002F54
		private string EncodeParameter(Parameter parameter, Encoding encoding)
		{
			if (parameter.Type != ParameterType.QueryStringWithoutEncode)
			{
				return this.EncodeQuery(parameter.Name, encoding) + "=" + this.EncodeQuery(RestClient.<EncodeParameter>g__StringOrEmpty|186_0(parameter.Value), encoding);
			}
			return parameter.Name + "=" + RestClient.<EncodeParameter>g__StringOrEmpty|186_0(parameter.Value);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00004DBC File Offset: 0x00002FBC
		private IHttp ConfigureHttp(IRestRequest request)
		{
			Http http = new Http
			{
				Encoding = this.Encoding,
				AlwaysMultipartFormData = request.AlwaysMultipartFormData,
				UseDefaultCredentials = request.UseDefaultCredentials,
				ResponseWriter = request.ResponseWriter,
				AdvancedResponseWriter = request.AdvancedResponseWriter,
				CookieContainer = this.CookieContainer,
				AutomaticDecompression = this.AutomaticDecompression,
				WebRequestConfigurator = this.WebRequestConfigurator,
				Encode = this.Encode
			};
			List<Parameter> list = new List<Parameter>();
			list.AddRange(request.Parameters);
			using (IEnumerator<Parameter> enumerator = this.DefaultParameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Parameter defaultParameter = enumerator.Current;
					bool flag = request.Parameters.Any((Parameter p) => p.Name != null && p.Name.Equals(defaultParameter.Name, StringComparison.InvariantCultureIgnoreCase) && p.Type == defaultParameter.Type);
					if (this.AllowMultipleDefaultParametersWithSameName)
					{
						flag = (!RestClient.MultiParameterTypes.Any((ParameterType pt) => pt == defaultParameter.Type) && flag);
					}
					if (!flag)
					{
						list.Add(defaultParameter);
					}
				}
			}
			if (list.All((Parameter p) => !p.Name.EqualsIgnoreCase("accept")))
			{
				string value = string.Join(", ", this.AcceptTypes);
				list.Add(new Parameter("Accept", value, ParameterType.HttpHeader));
			}
			http.Url = this.BuildUri(request);
			http.Host = this.BaseHost;
			http.PreAuthenticate = this.PreAuthenticate;
			http.UnsafeAuthenticatedConnectionSharing = this.UnsafeAuthenticatedConnectionSharing;
			http.UserAgent = (this.UserAgent ?? http.UserAgent);
			int num = (request.Timeout != 0) ? request.Timeout : this.Timeout;
			if (num != 0)
			{
				http.Timeout = num;
			}
			int num2 = (request.ReadWriteTimeout != 0) ? request.ReadWriteTimeout : this.ReadWriteTimeout;
			if (num2 != 0)
			{
				http.ReadWriteTimeout = num2;
			}
			http.FollowRedirects = this.FollowRedirects;
			if (this.ClientCertificates != null)
			{
				http.ClientCertificates = this.ClientCertificates;
			}
			http.MaxRedirects = this.MaxRedirects;
			http.CachePolicy = this.CachePolicy;
			http.Pipelined = this.Pipelined;
			if (request.Credentials != null)
			{
				http.Credentials = request.Credentials;
			}
			if (!string.IsNullOrEmpty(this.ConnectionGroupName))
			{
				http.ConnectionGroupName = this.ConnectionGroupName;
			}
			http.Headers = (from p in list
			where p.Type == ParameterType.HttpHeader
			select new HttpHeader(p.Name, p.Value)).ToList<HttpHeader>();
			http.Cookies = (from p in list
			where p.Type == ParameterType.Cookie
			select p).Select(delegate(Parameter p)
			{
				HttpCookie httpCookie = new HttpCookie();
				httpCookie.Name = p.Name;
				object value2 = p.Value;
				httpCookie.Value = (((value2 != null) ? value2.ToString() : null) ?? "");
				return httpCookie;
			}).ToList<HttpCookie>();
			http.Parameters = (from p in list
			where p.Type == ParameterType.GetOrPost
			select new HttpParameter(p.Name, p.Value, null)).ToList<HttpParameter>();
			http.Files = (from file in request.Files
			select new HttpFile
			{
				Name = file.Name,
				ContentType = file.ContentType,
				Writer = file.Writer,
				FileName = file.FileName,
				ContentLength = file.ContentLength
			}).ToList<HttpFile>();
			if (request.Body != null)
			{
				http.AddBody(request.Body);
			}
			http.AllowedDecompressionMethods = request.AllowedDecompressionMethods;
			IWebProxy webProxy = this.Proxy ?? WebRequest.DefaultWebProxy;
			try
			{
				if (webProxy == null)
				{
					webProxy = WebRequest.GetSystemWebProxy();
				}
			}
			catch (PlatformNotSupportedException)
			{
			}
			http.Proxy = webProxy;
			http.RemoteCertificateValidationCallback = this.RemoteCertificateValidationCallback;
			return http;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x000051C4 File Offset: 0x000033C4
		private IRestResponse<T> Deserialize<[Nullable(2)] T>(IRestRequest request, IRestResponse raw)
		{
			IRestResponse<T> restResponse = new RestResponse<T>();
			try
			{
				Action<IRestResponse> onBeforeDeserialization = request.OnBeforeDeserialization;
				if (onBeforeDeserialization != null)
				{
					onBeforeDeserialization(raw);
				}
				restResponse = raw.ToAsyncResponse<T>();
				if (restResponse.ErrorException == null)
				{
					Func<IDeserializer> handler = this.GetHandler(raw.ContentType);
					IDeserializer deserializer = (handler != null) ? handler() : null;
					IXmlDeserializer xmlDeserializer = deserializer as IXmlDeserializer;
					if (xmlDeserializer != null)
					{
						if (request.DateFormat.IsNotEmpty())
						{
							xmlDeserializer.DateFormat = request.DateFormat;
						}
						if (request.XmlNamespace.IsNotEmpty())
						{
							xmlDeserializer.Namespace = request.XmlNamespace;
						}
					}
					IWithRootElement withRootElement = deserializer as IWithRootElement;
					if (withRootElement != null && !request.RootElement.IsEmpty())
					{
						withRootElement.RootElement = request.RootElement;
					}
					if (deserializer != null)
					{
						restResponse.Data = deserializer.Deserialize<T>(raw);
					}
				}
			}
			catch (Exception ex)
			{
				if (this.ThrowOnAnyError)
				{
					throw;
				}
				if (this.FailOnDeserializationError || this.ThrowOnDeserializationError)
				{
					restResponse.ResponseStatus = ResponseStatus.Error;
				}
				restResponse.ErrorMessage = ex.Message;
				restResponse.ErrorException = ex;
				if (this.ThrowOnDeserializationError)
				{
					throw new DeserializationException(restResponse, ex);
				}
			}
			restResponse.Request = request;
			return restResponse;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000052E8 File Offset: 0x000034E8
		private static bool IsWildcardStructuredSuffixSyntax(string contentType)
		{
			int num = 0;
			return contentType[num++] == '*' && contentType[num++] == '+' && num != contentType.Length && RestClient.StructuredSyntaxSuffixWildcardRegex.IsMatch(contentType);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000532F File Offset: 0x0000352F
		public byte[] DownloadData(IRestRequest request)
		{
			return this.DownloadData(request, false);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000533C File Offset: 0x0000353C
		public byte[] DownloadData(IRestRequest request, bool throwOnError)
		{
			IRestResponse restResponse = this.Execute(request);
			if (restResponse.ResponseStatus != ResponseStatus.Error || !throwOnError)
			{
				return restResponse.RawBytes;
			}
			throw restResponse.ErrorException;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000536B File Offset: 0x0000356B
		public virtual IRestResponse Execute(IRestRequest request, Method httpMethod)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			request.Method = httpMethod;
			return this.Execute(request);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000538C File Offset: 0x0000358C
		public virtual IRestResponse Execute(IRestRequest request)
		{
			string name = Enum.GetName(typeof(Method), request.Method);
			switch (request.Method)
			{
			case Method.POST:
				return this.Execute(request, name, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsPost));
			case Method.PUT:
				return this.Execute(request, name, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsPost));
			case Method.PATCH:
				return this.Execute(request, name, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsPost));
			case Method.MERGE:
				return this.Execute(request, name, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsPost));
			case Method.COPY:
				return this.Execute(request, name, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsPost));
			}
			return this.Execute(request, name, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsGet));
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000546E File Offset: 0x0000366E
		public IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod)
		{
			return this.Execute(request, httpMethod, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsGet));
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00005484 File Offset: 0x00003684
		public IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod)
		{
			request.Method = Method.POST;
			return this.Execute(request, httpMethod, new Func<IHttp, string, HttpResponse>(RestClient.DoExecuteAsPost));
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000054A1 File Offset: 0x000036A1
		public virtual IRestResponse<T> Execute<[Nullable(2)] T>(IRestRequest request, Method httpMethod)
		{
			Ensure.NotNull(request, "request");
			request.Method = httpMethod;
			return this.Execute<T>(request);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000054BC File Offset: 0x000036BC
		public virtual IRestResponse<T> Execute<[Nullable(2)] T>(IRestRequest request)
		{
			return this.Deserialize<T>(request, this.Execute(request));
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x000054CC File Offset: 0x000036CC
		public IRestResponse<T> ExecuteAsGet<[Nullable(2)] T>(IRestRequest request, string httpMethod)
		{
			return this.Deserialize<T>(request, this.ExecuteAsGet(request, httpMethod));
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x000054DD File Offset: 0x000036DD
		public IRestResponse<T> ExecuteAsPost<[Nullable(2)] T>(IRestRequest request, string httpMethod)
		{
			return this.Deserialize<T>(request, this.ExecuteAsPost(request, httpMethod));
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000054F0 File Offset: 0x000036F0
		private IRestResponse Execute(IRestRequest request, string httpMethod, Func<IHttp, string, HttpResponse> getResponse)
		{
			request.SerializeRequestBody(this.Serializers, new ISerializer[]
			{
				request.XmlSerializer,
				request.JsonSerializer
			});
			this.AuthenticateIfNeeded(request);
			IRestResponse restResponse = new RestResponse();
			try
			{
				IHttp http = this.ConfigureHttp(request);
				Action<IHttp> onBeforeRequest = request.OnBeforeRequest;
				if (onBeforeRequest != null)
				{
					onBeforeRequest(http);
				}
				restResponse = RestResponse.FromHttpResponse(getResponse(http, httpMethod), request);
			}
			catch (Exception ex)
			{
				if (this.ThrowOnAnyError)
				{
					throw;
				}
				restResponse.ResponseStatus = ResponseStatus.Error;
				restResponse.ErrorMessage = ex.Message;
				restResponse.ErrorException = ex;
			}
			restResponse.Request = request;
			restResponse.Request.IncreaseNumAttempts();
			return restResponse;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000055A4 File Offset: 0x000037A4
		private static HttpResponse DoExecuteAsGet(IHttp http, string method)
		{
			return http.AsGet(method);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000055AD File Offset: 0x000037AD
		private static HttpResponse DoExecuteAsPost(IHttp http, string method)
		{
			return http.AsPost(method);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000562D File Offset: 0x0000382D
		[CompilerGenerated]
		internal static string <EncodeParameter>g__StringOrEmpty|186_0([Nullable(2)] object value)
		{
			if (value != null)
			{
				return value.ToString();
			}
			return "";
		}

		// Token: 0x04000078 RID: 120
		private static readonly Version Version = new AssemblyName(typeof(RestClient).Assembly.FullName).Version;

		// Token: 0x04000079 RID: 121
		private static readonly string DefaultUserAgent = string.Format("RestSharp/{0}", RestClient.Version);

		// Token: 0x0400007A RID: 122
		private static readonly Regex StructuredSyntaxSuffixRegex = new Regex("\\+\\w+$");

		// Token: 0x0400007B RID: 123
		private static readonly Regex StructuredSyntaxSuffixWildcardRegex = new Regex("^\\*\\+\\w+$");

		// Token: 0x0400007C RID: 124
		private static readonly ParameterType[] MultiParameterTypes = new ParameterType[]
		{
			ParameterType.QueryString,
			ParameterType.GetOrPost
		};

		// Token: 0x02000076 RID: 118
		[Nullable(0)]
		private class UrlSegmentParamsValues
		{
			// Token: 0x060005CD RID: 1485 RVA: 0x0000E289 File Offset: 0x0000C489
			public UrlSegmentParamsValues(Uri builderUri, string assembled)
			{
				this.Uri = builderUri;
				this.Resource = assembled;
			}

			// Token: 0x1700018E RID: 398
			// (get) Token: 0x060005CE RID: 1486 RVA: 0x0000E29F File Offset: 0x0000C49F
			public Uri Uri { get; }

			// Token: 0x1700018F RID: 399
			// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000E2A7 File Offset: 0x0000C4A7
			public string Resource { get; }
		}
	}
}
