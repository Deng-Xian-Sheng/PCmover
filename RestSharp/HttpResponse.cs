using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using RestSharp.Extensions;

namespace RestSharp
{
	// Token: 0x02000012 RID: 18
	[NullableContext(1)]
	[Nullable(0)]
	public class HttpResponse : IHttpResponse
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x000039F4 File Offset: 0x00001BF4
		public HttpResponse()
		{
			this.ResponseStatus = ResponseStatus.None;
			this.Headers = new List<HttpHeader>();
			this.Cookies = new List<HttpCookie>();
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00003A19 File Offset: 0x00001C19
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00003A21 File Offset: 0x00001C21
		public string ContentType { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00003A2A File Offset: 0x00001C2A
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00003A32 File Offset: 0x00001C32
		public long ContentLength { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00003A3B File Offset: 0x00001C3B
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00003A43 File Offset: 0x00001C43
		public string ContentEncoding { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00003A4C File Offset: 0x00001C4C
		public string Content
		{
			get
			{
				string result;
				if ((result = this._content) == null)
				{
					result = (this._content = this.RawBytes.AsString(this.ContentEncoding));
				}
				return result;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003A7D File Offset: 0x00001C7D
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00003A85 File Offset: 0x00001C85
		public HttpStatusCode StatusCode { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00003A8E File Offset: 0x00001C8E
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00003A96 File Offset: 0x00001C96
		public string StatusDescription { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003A9F File Offset: 0x00001C9F
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00003AA7 File Offset: 0x00001CA7
		public byte[] RawBytes { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00003AB0 File Offset: 0x00001CB0
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00003AB8 File Offset: 0x00001CB8
		public Uri ResponseUri { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003AC1 File Offset: 0x00001CC1
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00003AC9 File Offset: 0x00001CC9
		public string Server { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00003AD2 File Offset: 0x00001CD2
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00003ADA File Offset: 0x00001CDA
		public IList<HttpHeader> Headers { get; internal set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00003AE3 File Offset: 0x00001CE3
		public IList<HttpCookie> Cookies { get; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00003AEB File Offset: 0x00001CEB
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00003AF3 File Offset: 0x00001CF3
		public ResponseStatus ResponseStatus { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00003AFC File Offset: 0x00001CFC
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00003B04 File Offset: 0x00001D04
		public string ErrorMessage { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00003B0D File Offset: 0x00001D0D
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00003B15 File Offset: 0x00001D15
		public Exception ErrorException { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00003B1E File Offset: 0x00001D1E
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00003B26 File Offset: 0x00001D26
		public Version ProtocolVersion { get; set; }

		// Token: 0x04000067 RID: 103
		private string _content;
	}
}
