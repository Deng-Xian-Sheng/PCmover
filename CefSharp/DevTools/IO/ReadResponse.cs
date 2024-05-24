using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IO
{
	// Token: 0x02000128 RID: 296
	[DataContract]
	public class ReadResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x0000DD1E File Offset: 0x0000BF1E
		// (set) Token: 0x06000899 RID: 2201 RVA: 0x0000DD26 File Offset: 0x0000BF26
		[DataMember]
		internal bool? base64Encoded { get; set; }

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x0000DD2F File Offset: 0x0000BF2F
		public bool? Base64Encoded
		{
			get
			{
				return this.base64Encoded;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x0000DD37 File Offset: 0x0000BF37
		// (set) Token: 0x0600089C RID: 2204 RVA: 0x0000DD3F File Offset: 0x0000BF3F
		[DataMember]
		internal string data { get; set; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x0000DD48 File Offset: 0x0000BF48
		public string Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600089E RID: 2206 RVA: 0x0000DD50 File Offset: 0x0000BF50
		// (set) Token: 0x0600089F RID: 2207 RVA: 0x0000DD58 File Offset: 0x0000BF58
		[DataMember]
		internal bool eof { get; set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0000DD61 File Offset: 0x0000BF61
		public bool Eof
		{
			get
			{
				return this.eof;
			}
		}
	}
}
