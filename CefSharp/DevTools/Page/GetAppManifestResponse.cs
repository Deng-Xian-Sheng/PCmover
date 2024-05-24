using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000276 RID: 630
	[DataContract]
	public class GetAppManifestResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x060011C0 RID: 4544 RVA: 0x00015FB2 File Offset: 0x000141B2
		// (set) Token: 0x060011C1 RID: 4545 RVA: 0x00015FBA File Offset: 0x000141BA
		[DataMember]
		internal string url { get; set; }

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x060011C2 RID: 4546 RVA: 0x00015FC3 File Offset: 0x000141C3
		public string Url
		{
			get
			{
				return this.url;
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x060011C3 RID: 4547 RVA: 0x00015FCB File Offset: 0x000141CB
		// (set) Token: 0x060011C4 RID: 4548 RVA: 0x00015FD3 File Offset: 0x000141D3
		[DataMember]
		internal IList<AppManifestError> errors { get; set; }

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x00015FDC File Offset: 0x000141DC
		public IList<AppManifestError> Errors
		{
			get
			{
				return this.errors;
			}
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x060011C6 RID: 4550 RVA: 0x00015FE4 File Offset: 0x000141E4
		// (set) Token: 0x060011C7 RID: 4551 RVA: 0x00015FEC File Offset: 0x000141EC
		[DataMember]
		internal string data { get; set; }

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x060011C8 RID: 4552 RVA: 0x00015FF5 File Offset: 0x000141F5
		public string Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x060011C9 RID: 4553 RVA: 0x00015FFD File Offset: 0x000141FD
		// (set) Token: 0x060011CA RID: 4554 RVA: 0x00016005 File Offset: 0x00014205
		[DataMember]
		internal AppManifestParsedProperties parsed { get; set; }

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x060011CB RID: 4555 RVA: 0x0001600E File Offset: 0x0001420E
		public AppManifestParsedProperties Parsed
		{
			get
			{
				return this.parsed;
			}
		}
	}
}
