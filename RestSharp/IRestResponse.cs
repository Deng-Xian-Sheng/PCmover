using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000017 RID: 23
	[NullableContext(1)]
	public interface IRestResponse
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000208 RID: 520
		// (set) Token: 0x06000209 RID: 521
		IRestRequest Request { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600020A RID: 522
		// (set) Token: 0x0600020B RID: 523
		string ContentType { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600020C RID: 524
		// (set) Token: 0x0600020D RID: 525
		long ContentLength { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600020E RID: 526
		// (set) Token: 0x0600020F RID: 527
		string ContentEncoding { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000210 RID: 528
		// (set) Token: 0x06000211 RID: 529
		string Content { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000212 RID: 530
		// (set) Token: 0x06000213 RID: 531
		HttpStatusCode StatusCode { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000214 RID: 532
		bool IsSuccessful { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000215 RID: 533
		// (set) Token: 0x06000216 RID: 534
		string StatusDescription { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000217 RID: 535
		// (set) Token: 0x06000218 RID: 536
		byte[] RawBytes { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000219 RID: 537
		// (set) Token: 0x0600021A RID: 538
		Uri ResponseUri { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600021B RID: 539
		// (set) Token: 0x0600021C RID: 540
		string Server { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600021D RID: 541
		IList<RestResponseCookie> Cookies { get; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600021E RID: 542
		IList<Parameter> Headers { get; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600021F RID: 543
		// (set) Token: 0x06000220 RID: 544
		ResponseStatus ResponseStatus { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000221 RID: 545
		// (set) Token: 0x06000222 RID: 546
		string ErrorMessage { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000223 RID: 547
		// (set) Token: 0x06000224 RID: 548
		Exception ErrorException { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000225 RID: 549
		// (set) Token: 0x06000226 RID: 550
		Version ProtocolVersion { get; set; }
	}
}
