using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000397 RID: 919
	[DataContract]
	public class GetAttributesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06001AEB RID: 6891 RVA: 0x0001F1CB File Offset: 0x0001D3CB
		// (set) Token: 0x06001AEC RID: 6892 RVA: 0x0001F1D3 File Offset: 0x0001D3D3
		[DataMember]
		internal string[] attributes { get; set; }

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06001AED RID: 6893 RVA: 0x0001F1DC File Offset: 0x0001D3DC
		public string[] Attributes
		{
			get
			{
				return this.attributes;
			}
		}
	}
}
