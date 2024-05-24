using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200027D RID: 637
	[DataContract]
	public class GetResourceContentResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x060011FA RID: 4602 RVA: 0x00016199 File Offset: 0x00014399
		// (set) Token: 0x060011FB RID: 4603 RVA: 0x000161A1 File Offset: 0x000143A1
		[DataMember]
		internal string content { get; set; }

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x060011FC RID: 4604 RVA: 0x000161AA File Offset: 0x000143AA
		public string Content
		{
			get
			{
				return this.content;
			}
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x060011FD RID: 4605 RVA: 0x000161B2 File Offset: 0x000143B2
		// (set) Token: 0x060011FE RID: 4606 RVA: 0x000161BA File Offset: 0x000143BA
		[DataMember]
		internal bool base64Encoded { get; set; }

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x060011FF RID: 4607 RVA: 0x000161C3 File Offset: 0x000143C3
		public bool Base64Encoded
		{
			get
			{
				return this.base64Encoded;
			}
		}
	}
}
