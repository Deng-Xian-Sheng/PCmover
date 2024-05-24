using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RestSharp
{
	// Token: 0x02000013 RID: 19
	[NullableContext(1)]
	public interface IHttp
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000F0 RID: 240
		// (set) Token: 0x060000F1 RID: 241
		Action<Stream> ResponseWriter { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000F2 RID: 242
		// (set) Token: 0x060000F3 RID: 243
		Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000F4 RID: 244
		// (set) Token: 0x060000F5 RID: 245
		[Nullable(2)]
		CookieContainer CookieContainer { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000F6 RID: 246
		// (set) Token: 0x060000F7 RID: 247
		[Nullable(2)]
		ICredentials Credentials { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000F8 RID: 248
		// (set) Token: 0x060000F9 RID: 249
		bool AutomaticDecompression { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000FA RID: 250
		// (set) Token: 0x060000FB RID: 251
		bool AlwaysMultipartFormData { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000FC RID: 252
		// (set) Token: 0x060000FD RID: 253
		string UserAgent { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000FE RID: 254
		// (set) Token: 0x060000FF RID: 255
		int Timeout { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000100 RID: 256
		// (set) Token: 0x06000101 RID: 257
		int ReadWriteTimeout { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000102 RID: 258
		// (set) Token: 0x06000103 RID: 259
		bool FollowRedirects { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000104 RID: 260
		// (set) Token: 0x06000105 RID: 261
		bool Pipelined { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000106 RID: 262
		// (set) Token: 0x06000107 RID: 263
		[Nullable(2)]
		X509CertificateCollection ClientCertificates { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000108 RID: 264
		// (set) Token: 0x06000109 RID: 265
		int? MaxRedirects { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600010A RID: 266
		// (set) Token: 0x0600010B RID: 267
		bool UseDefaultCredentials { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600010C RID: 268
		// (set) Token: 0x0600010D RID: 269
		Encoding Encoding { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600010E RID: 270
		IList<HttpHeader> Headers { get; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600010F RID: 271
		IList<HttpParameter> Parameters { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000110 RID: 272
		IList<HttpFile> Files { get; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000111 RID: 273
		IList<HttpCookie> Cookies { get; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000112 RID: 274
		// (set) Token: 0x06000113 RID: 275
		string RequestBody { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000114 RID: 276
		// (set) Token: 0x06000115 RID: 277
		string RequestContentType { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000116 RID: 278
		// (set) Token: 0x06000117 RID: 279
		bool PreAuthenticate { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000118 RID: 280
		// (set) Token: 0x06000119 RID: 281
		bool UnsafeAuthenticatedConnectionSharing { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600011A RID: 282
		// (set) Token: 0x0600011B RID: 283
		[Nullable(2)]
		RequestCachePolicy CachePolicy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600011C RID: 284
		// (set) Token: 0x0600011D RID: 285
		string ConnectionGroupName { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600011E RID: 286
		// (set) Token: 0x0600011F RID: 287
		byte[] RequestBodyBytes { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000120 RID: 288
		// (set) Token: 0x06000121 RID: 289
		Uri Url { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000122 RID: 290
		// (set) Token: 0x06000123 RID: 291
		[Nullable(2)]
		string Host { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000124 RID: 292
		string FormBoundary { get; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000125 RID: 293
		// (set) Token: 0x06000126 RID: 294
		IList<DecompressionMethods> AllowedDecompressionMethods { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000127 RID: 295
		// (set) Token: 0x06000128 RID: 296
		[Nullable(2)]
		IWebProxy Proxy { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000129 RID: 297
		// (set) Token: 0x0600012A RID: 298
		[Nullable(2)]
		RemoteCertificateValidationCallback RemoteCertificateValidationCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600012B RID: 299
		// (set) Token: 0x0600012C RID: 300
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<HttpWebRequest> WebRequestConfigurator { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x0600012D RID: 301
		[Obsolete]
		HttpWebRequest DeleteAsync(Action<HttpResponse> action);

		// Token: 0x0600012E RID: 302
		[Obsolete]
		HttpWebRequest GetAsync(Action<HttpResponse> action);

		// Token: 0x0600012F RID: 303
		[Obsolete]
		HttpWebRequest HeadAsync(Action<HttpResponse> action);

		// Token: 0x06000130 RID: 304
		[Obsolete]
		HttpWebRequest OptionsAsync(Action<HttpResponse> action);

		// Token: 0x06000131 RID: 305
		[Obsolete]
		HttpWebRequest PostAsync(Action<HttpResponse> action);

		// Token: 0x06000132 RID: 306
		[Obsolete]
		HttpWebRequest PutAsync(Action<HttpResponse> action);

		// Token: 0x06000133 RID: 307
		[Obsolete]
		HttpWebRequest PatchAsync(Action<HttpResponse> action);

		// Token: 0x06000134 RID: 308
		[Obsolete]
		HttpWebRequest MergeAsync(Action<HttpResponse> action);

		// Token: 0x06000135 RID: 309
		[return: Nullable(2)]
		HttpWebRequest AsPostAsync(Action<HttpResponse> action, string httpMethod);

		// Token: 0x06000136 RID: 310
		[return: Nullable(2)]
		HttpWebRequest AsGetAsync(Action<HttpResponse> action, string httpMethod);

		// Token: 0x06000137 RID: 311
		HttpResponse Delete();

		// Token: 0x06000138 RID: 312
		HttpResponse Get();

		// Token: 0x06000139 RID: 313
		HttpResponse Head();

		// Token: 0x0600013A RID: 314
		HttpResponse Options();

		// Token: 0x0600013B RID: 315
		HttpResponse Post();

		// Token: 0x0600013C RID: 316
		HttpResponse Put();

		// Token: 0x0600013D RID: 317
		HttpResponse Patch();

		// Token: 0x0600013E RID: 318
		HttpResponse Merge();

		// Token: 0x0600013F RID: 319
		HttpResponse AsPost(string httpMethod);

		// Token: 0x06000140 RID: 320
		HttpResponse AsGet(string httpMethod);
	}
}
