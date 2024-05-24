using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using RestSharp.Extensions;

namespace RestSharp
{
	// Token: 0x02000025 RID: 37
	[NullableContext(1)]
	[Nullable(0)]
	[DebuggerDisplay("{DebuggerDisplay()}")]
	public abstract class RestResponseBase
	{
		// Token: 0x0600036F RID: 879 RVA: 0x00006D9B File Offset: 0x00004F9B
		protected RestResponseBase()
		{
			this.ResponseStatus = ResponseStatus.None;
			this.Headers = new List<Parameter>();
			this.Cookies = new List<RestResponseCookie>();
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00006DC0 File Offset: 0x00004FC0
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00006DC8 File Offset: 0x00004FC8
		public IRestRequest Request { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00006DD1 File Offset: 0x00004FD1
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00006DD9 File Offset: 0x00004FD9
		public string ContentType { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00006DE2 File Offset: 0x00004FE2
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00006DEA File Offset: 0x00004FEA
		public long ContentLength { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00006DF3 File Offset: 0x00004FF3
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00006DFB File Offset: 0x00004FFB
		public string ContentEncoding { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000378 RID: 888 RVA: 0x00006E04 File Offset: 0x00005004
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00006E35 File Offset: 0x00005035
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
			set
			{
				this._content = value;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00006E3E File Offset: 0x0000503E
		// (set) Token: 0x0600037B RID: 891 RVA: 0x00006E46 File Offset: 0x00005046
		public HttpStatusCode StatusCode { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00006E4F File Offset: 0x0000504F
		public bool IsSuccessful
		{
			get
			{
				return this.StatusCode >= HttpStatusCode.OK && this.StatusCode <= (HttpStatusCode)299 && this.ResponseStatus == ResponseStatus.Completed;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600037D RID: 893 RVA: 0x00006E76 File Offset: 0x00005076
		// (set) Token: 0x0600037E RID: 894 RVA: 0x00006E7E File Offset: 0x0000507E
		public string StatusDescription { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00006E87 File Offset: 0x00005087
		// (set) Token: 0x06000380 RID: 896 RVA: 0x00006E8F File Offset: 0x0000508F
		public byte[] RawBytes { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00006E98 File Offset: 0x00005098
		// (set) Token: 0x06000382 RID: 898 RVA: 0x00006EA0 File Offset: 0x000050A0
		public Uri ResponseUri { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00006EA9 File Offset: 0x000050A9
		// (set) Token: 0x06000384 RID: 900 RVA: 0x00006EB1 File Offset: 0x000050B1
		public string Server { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00006EBA File Offset: 0x000050BA
		// (set) Token: 0x06000386 RID: 902 RVA: 0x00006EC2 File Offset: 0x000050C2
		public IList<RestResponseCookie> Cookies { get; protected internal set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00006ECB File Offset: 0x000050CB
		// (set) Token: 0x06000388 RID: 904 RVA: 0x00006ED3 File Offset: 0x000050D3
		public IList<Parameter> Headers { get; protected internal set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00006EDC File Offset: 0x000050DC
		// (set) Token: 0x0600038A RID: 906 RVA: 0x00006EE4 File Offset: 0x000050E4
		public ResponseStatus ResponseStatus { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00006EED File Offset: 0x000050ED
		// (set) Token: 0x0600038C RID: 908 RVA: 0x00006EF5 File Offset: 0x000050F5
		public string ErrorMessage { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00006EFE File Offset: 0x000050FE
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00006F06 File Offset: 0x00005106
		public Exception ErrorException { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00006F0F File Offset: 0x0000510F
		// (set) Token: 0x06000390 RID: 912 RVA: 0x00006F17 File Offset: 0x00005117
		public Version ProtocolVersion { get; set; }

		// Token: 0x06000391 RID: 913 RVA: 0x00006F20 File Offset: 0x00005120
		protected string DebuggerDisplay()
		{
			return string.Format("StatusCode: {0}, Content-Type: {1}, Content-Length: {2})", this.StatusCode, this.ContentType, this.ContentLength);
		}

		// Token: 0x040000C0 RID: 192
		private string _content;
	}
}
