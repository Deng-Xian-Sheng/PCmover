using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000014 RID: 20
	[NullableContext(1)]
	public interface IHttpResponse
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000141 RID: 321
		// (set) Token: 0x06000142 RID: 322
		string ContentType { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000143 RID: 323
		// (set) Token: 0x06000144 RID: 324
		long ContentLength { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000145 RID: 325
		// (set) Token: 0x06000146 RID: 326
		string ContentEncoding { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000147 RID: 327
		string Content { get; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000148 RID: 328
		// (set) Token: 0x06000149 RID: 329
		HttpStatusCode StatusCode { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600014A RID: 330
		// (set) Token: 0x0600014B RID: 331
		string StatusDescription { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600014C RID: 332
		// (set) Token: 0x0600014D RID: 333
		byte[] RawBytes { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600014E RID: 334
		// (set) Token: 0x0600014F RID: 335
		Uri ResponseUri { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000150 RID: 336
		// (set) Token: 0x06000151 RID: 337
		string Server { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000152 RID: 338
		IList<HttpHeader> Headers { get; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000153 RID: 339
		IList<HttpCookie> Cookies { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000154 RID: 340
		// (set) Token: 0x06000155 RID: 341
		ResponseStatus ResponseStatus { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000156 RID: 342
		// (set) Token: 0x06000157 RID: 343
		string ErrorMessage { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000158 RID: 344
		// (set) Token: 0x06000159 RID: 345
		Exception ErrorException { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600015A RID: 346
		// (set) Token: 0x0600015B RID: 347
		Version ProtocolVersion { get; set; }
	}
}
