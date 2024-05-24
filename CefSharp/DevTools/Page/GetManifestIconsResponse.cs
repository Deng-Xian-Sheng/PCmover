using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000278 RID: 632
	[DataContract]
	public class GetManifestIconsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x060011D1 RID: 4561 RVA: 0x0001603F File Offset: 0x0001423F
		// (set) Token: 0x060011D2 RID: 4562 RVA: 0x00016047 File Offset: 0x00014247
		[DataMember]
		internal string primaryIcon { get; set; }

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x060011D3 RID: 4563 RVA: 0x00016050 File Offset: 0x00014250
		public byte[] PrimaryIcon
		{
			get
			{
				return base.Convert(this.primaryIcon);
			}
		}
	}
}
