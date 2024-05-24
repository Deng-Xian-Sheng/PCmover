using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization;

namespace RestSharp
{
	// Token: 0x02000015 RID: 21
	[NullableContext(1)]
	public interface IRestClient
	{
		// Token: 0x0600015C RID: 348
		IRestClient UseSerializer(Func<IRestSerializer> serializerFactory);

		// Token: 0x0600015D RID: 349
		IRestClient UseSerializer<[Nullable(0)] T>() where T : IRestSerializer, new();

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600015E RID: 350
		// (set) Token: 0x0600015F RID: 351
		[Nullable(2)]
		CookieContainer CookieContainer { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000160 RID: 352
		// (set) Token: 0x06000161 RID: 353
		bool AutomaticDecompression { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000162 RID: 354
		// (set) Token: 0x06000163 RID: 355
		int? MaxRedirects { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000164 RID: 356
		// (set) Token: 0x06000165 RID: 357
		string UserAgent { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000166 RID: 358
		// (set) Token: 0x06000167 RID: 359
		int Timeout { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000168 RID: 360
		// (set) Token: 0x06000169 RID: 361
		int ReadWriteTimeout { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600016A RID: 362
		// (set) Token: 0x0600016B RID: 363
		bool UseSynchronizationContext { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600016C RID: 364
		// (set) Token: 0x0600016D RID: 365
		[Nullable(2)]
		IAuthenticator Authenticator { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600016E RID: 366
		// (set) Token: 0x0600016F RID: 367
		[Nullable(2)]
		Uri BaseUrl { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000170 RID: 368
		// (set) Token: 0x06000171 RID: 369
		Encoding Encoding { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000172 RID: 370
		// (set) Token: 0x06000173 RID: 371
		bool ThrowOnDeserializationError { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000174 RID: 372
		// (set) Token: 0x06000175 RID: 373
		bool FailOnDeserializationError { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000176 RID: 374
		// (set) Token: 0x06000177 RID: 375
		bool ThrowOnAnyError { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000178 RID: 376
		// (set) Token: 0x06000179 RID: 377
		[Nullable(2)]
		string ConnectionGroupName { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600017A RID: 378
		// (set) Token: 0x0600017B RID: 379
		bool PreAuthenticate { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600017C RID: 380
		// (set) Token: 0x0600017D RID: 381
		bool UnsafeAuthenticatedConnectionSharing { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600017E RID: 382
		IList<Parameter> DefaultParameters { get; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600017F RID: 383
		// (set) Token: 0x06000180 RID: 384
		[Nullable(2)]
		string BaseHost { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000181 RID: 385
		// (set) Token: 0x06000182 RID: 386
		bool AllowMultipleDefaultParametersWithSameName { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000183 RID: 387
		// (set) Token: 0x06000184 RID: 388
		[Nullable(2)]
		X509CertificateCollection ClientCertificates { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000185 RID: 389
		// (set) Token: 0x06000186 RID: 390
		[Nullable(2)]
		IWebProxy Proxy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000187 RID: 391
		// (set) Token: 0x06000188 RID: 392
		[Nullable(2)]
		RequestCachePolicy CachePolicy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000189 RID: 393
		// (set) Token: 0x0600018A RID: 394
		bool Pipelined { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600018B RID: 395
		// (set) Token: 0x0600018C RID: 396
		bool FollowRedirects { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600018D RID: 397
		// (set) Token: 0x0600018E RID: 398
		[Nullable(2)]
		RemoteCertificateValidationCallback RemoteCertificateValidationCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x0600018F RID: 399
		IRestResponse<T> Deserialize<[Nullable(2)] T>(IRestResponse response);

		// Token: 0x06000190 RID: 400
		IRestClient UseUrlEncoder(Func<string, string> encoder);

		// Token: 0x06000191 RID: 401
		IRestClient UseQueryEncoder(Func<string, Encoding, string> queryEncoder);

		// Token: 0x06000192 RID: 402
		IRestResponse Execute(IRestRequest request);

		// Token: 0x06000193 RID: 403
		IRestResponse Execute(IRestRequest request, Method httpMethod);

		// Token: 0x06000194 RID: 404
		IRestResponse<T> Execute<[Nullable(2)] T>(IRestRequest request);

		// Token: 0x06000195 RID: 405
		IRestResponse<T> Execute<[Nullable(2)] T>(IRestRequest request, Method httpMethod);

		// Token: 0x06000196 RID: 406
		byte[] DownloadData(IRestRequest request);

		// Token: 0x06000197 RID: 407
		[Obsolete("Use ThrowOnAnyError property to instruct RestSharp to rethrow exceptions")]
		byte[] DownloadData(IRestRequest request, bool throwOnError);

		// Token: 0x06000198 RID: 408
		Uri BuildUri(IRestRequest request);

		// Token: 0x06000199 RID: 409
		string BuildUriWithoutQueryParameters(IRestRequest request);

		// Token: 0x0600019A RID: 410
		void ConfigureWebRequest(Action<HttpWebRequest> configurator);

		// Token: 0x0600019B RID: 411
		void AddHandler(string contentType, Func<IDeserializer> deserializerFactory);

		// Token: 0x0600019C RID: 412
		void RemoveHandler(string contentType);

		// Token: 0x0600019D RID: 413
		void ClearHandlers();

		// Token: 0x0600019E RID: 414
		IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod);

		// Token: 0x0600019F RID: 415
		IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod);

		// Token: 0x060001A0 RID: 416
		IRestResponse<T> ExecuteAsGet<[Nullable(2)] T>(IRestRequest request, string httpMethod);

		// Token: 0x060001A1 RID: 417
		IRestResponse<T> ExecuteAsPost<[Nullable(2)] T>(IRestRequest request, string httpMethod);

		// Token: 0x060001A2 RID: 418
		Task<IRestResponse<T>> ExecuteAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A3 RID: 419
		Task<IRestResponse<T>> ExecuteAsync<[Nullable(2)] T>(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A4 RID: 420
		Task<IRestResponse> ExecuteAsync(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A5 RID: 421
		Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A6 RID: 422
		Task<IRestResponse<T>> ExecuteGetAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A7 RID: 423
		Task<IRestResponse<T>> ExecutePostAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A8 RID: 424
		Task<IRestResponse> ExecuteGetAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001A9 RID: 425
		Task<IRestResponse> ExecutePostAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060001AA RID: 426
		[Obsolete("Use the overload that accepts the delegate factory")]
		IRestClient UseSerializer(IRestSerializer serializer);

		// Token: 0x060001AB RID: 427
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback);

		// Token: 0x060001AC RID: 428
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsync<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback);

		// Token: 0x060001AD RID: 429
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, Method httpMethod);

		// Token: 0x060001AE RID: 430
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsync<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, Method httpMethod);

		// Token: 0x060001AF RID: 431
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod);

		// Token: 0x060001B0 RID: 432
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod);

		// Token: 0x060001B1 RID: 433
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsyncGet<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod);

		// Token: 0x060001B2 RID: 434
		[Obsolete("This method will be removed soon in favour of the proper async call")]
		RestRequestAsyncHandle ExecuteAsyncPost<[Nullable(2)] T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod);

		// Token: 0x060001B3 RID: 435
		[Obsolete("This method will be renamed to ExecuteAsync soon")]
		Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request);

		// Token: 0x060001B4 RID: 436
		[Obsolete("UseExecuteAsync instead")]
		Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token);

		// Token: 0x060001B5 RID: 437
		[Obsolete("Use ExecuteAsync instead")]
		Task<IRestResponse<T>> ExecuteTaskAsync<[Nullable(2)] T>(IRestRequest request, Method httpMethod);

		// Token: 0x060001B6 RID: 438
		[Obsolete("Use ExecuteGetAsync instead")]
		Task<IRestResponse<T>> ExecuteGetTaskAsync<[Nullable(2)] T>(IRestRequest request);

		// Token: 0x060001B7 RID: 439
		[Obsolete("Use ExecuteGetAsync instead")]
		Task<IRestResponse<T>> ExecuteGetTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token);

		// Token: 0x060001B8 RID: 440
		[Obsolete("Use ExecutePostAsync instead")]
		Task<IRestResponse<T>> ExecutePostTaskAsync<[Nullable(2)] T>(IRestRequest request);

		// Token: 0x060001B9 RID: 441
		[Obsolete("Use ExecutePostAsync instead")]
		Task<IRestResponse<T>> ExecutePostTaskAsync<[Nullable(2)] T>(IRestRequest request, CancellationToken token);

		// Token: 0x060001BA RID: 442
		[Obsolete("Use ExecuteAsync instead")]
		Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token);

		// Token: 0x060001BB RID: 443
		[Obsolete("Use ExecuteAsync instead")]
		Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token, Method httpMethod);

		// Token: 0x060001BC RID: 444
		[Obsolete("Use ExecuteAsync instead")]
		Task<IRestResponse> ExecuteTaskAsync(IRestRequest request);

		// Token: 0x060001BD RID: 445
		[Obsolete("Use ExecuteGetAsync instead")]
		Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request);

		// Token: 0x060001BE RID: 446
		[Obsolete("Use ExecuteGetAsync instead")]
		Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token);

		// Token: 0x060001BF RID: 447
		[Obsolete("Use ExecutePostAsync instead")]
		Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request);

		// Token: 0x060001C0 RID: 448
		[Obsolete("Use ExecutePostAsync instead")]
		Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token);

		// Token: 0x060001C1 RID: 449
		[Obsolete("Use the overload that accepts a factory delegate")]
		void AddHandler(string contentType, IDeserializer deserializer);
	}
}
