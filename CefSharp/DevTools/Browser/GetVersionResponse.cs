using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003FB RID: 1019
	[DataContract]
	public class GetVersionResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x06001DBD RID: 7613 RVA: 0x00022074 File Offset: 0x00020274
		// (set) Token: 0x06001DBE RID: 7614 RVA: 0x0002207C File Offset: 0x0002027C
		[DataMember]
		internal string protocolVersion { get; set; }

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x06001DBF RID: 7615 RVA: 0x00022085 File Offset: 0x00020285
		public string ProtocolVersion
		{
			get
			{
				return this.protocolVersion;
			}
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x06001DC0 RID: 7616 RVA: 0x0002208D File Offset: 0x0002028D
		// (set) Token: 0x06001DC1 RID: 7617 RVA: 0x00022095 File Offset: 0x00020295
		[DataMember]
		internal string product { get; set; }

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x06001DC2 RID: 7618 RVA: 0x0002209E File Offset: 0x0002029E
		public string Product
		{
			get
			{
				return this.product;
			}
		}

		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x06001DC3 RID: 7619 RVA: 0x000220A6 File Offset: 0x000202A6
		// (set) Token: 0x06001DC4 RID: 7620 RVA: 0x000220AE File Offset: 0x000202AE
		[DataMember]
		internal string revision { get; set; }

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x06001DC5 RID: 7621 RVA: 0x000220B7 File Offset: 0x000202B7
		public string Revision
		{
			get
			{
				return this.revision;
			}
		}

		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x06001DC6 RID: 7622 RVA: 0x000220BF File Offset: 0x000202BF
		// (set) Token: 0x06001DC7 RID: 7623 RVA: 0x000220C7 File Offset: 0x000202C7
		[DataMember]
		internal string userAgent { get; set; }

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x06001DC8 RID: 7624 RVA: 0x000220D0 File Offset: 0x000202D0
		public string UserAgent
		{
			get
			{
				return this.userAgent;
			}
		}

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x06001DC9 RID: 7625 RVA: 0x000220D8 File Offset: 0x000202D8
		// (set) Token: 0x06001DCA RID: 7626 RVA: 0x000220E0 File Offset: 0x000202E0
		[DataMember]
		internal string jsVersion { get; set; }

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x06001DCB RID: 7627 RVA: 0x000220E9 File Offset: 0x000202E9
		public string JsVersion
		{
			get
			{
				return this.jsVersion;
			}
		}
	}
}
