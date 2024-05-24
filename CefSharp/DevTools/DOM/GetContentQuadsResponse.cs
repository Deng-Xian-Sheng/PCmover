using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000399 RID: 921
	[DataContract]
	public class GetContentQuadsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06001AF3 RID: 6899 RVA: 0x0001F20D File Offset: 0x0001D40D
		// (set) Token: 0x06001AF4 RID: 6900 RVA: 0x0001F215 File Offset: 0x0001D415
		[DataMember]
		internal double[] quads { get; set; }

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06001AF5 RID: 6901 RVA: 0x0001F21E File Offset: 0x0001D41E
		public double[] Quads
		{
			get
			{
				return this.quads;
			}
		}
	}
}
