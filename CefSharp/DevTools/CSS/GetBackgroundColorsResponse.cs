using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003DE RID: 990
	[DataContract]
	public class GetBackgroundColorsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x06001CFC RID: 7420 RVA: 0x00021442 File Offset: 0x0001F642
		// (set) Token: 0x06001CFD RID: 7421 RVA: 0x0002144A File Offset: 0x0001F64A
		[DataMember]
		internal string[] backgroundColors { get; set; }

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x06001CFE RID: 7422 RVA: 0x00021453 File Offset: 0x0001F653
		public string[] BackgroundColors
		{
			get
			{
				return this.backgroundColors;
			}
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x06001CFF RID: 7423 RVA: 0x0002145B File Offset: 0x0001F65B
		// (set) Token: 0x06001D00 RID: 7424 RVA: 0x00021463 File Offset: 0x0001F663
		[DataMember]
		internal string computedFontSize { get; set; }

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06001D01 RID: 7425 RVA: 0x0002146C File Offset: 0x0001F66C
		public string ComputedFontSize
		{
			get
			{
				return this.computedFontSize;
			}
		}

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06001D02 RID: 7426 RVA: 0x00021474 File Offset: 0x0001F674
		// (set) Token: 0x06001D03 RID: 7427 RVA: 0x0002147C File Offset: 0x0001F67C
		[DataMember]
		internal string computedFontWeight { get; set; }

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06001D04 RID: 7428 RVA: 0x00021485 File Offset: 0x0001F685
		public string ComputedFontWeight
		{
			get
			{
				return this.computedFontWeight;
			}
		}
	}
}
