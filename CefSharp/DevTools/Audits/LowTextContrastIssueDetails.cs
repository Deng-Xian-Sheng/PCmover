using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200041F RID: 1055
	[DataContract]
	public class LowTextContrastIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B28 RID: 2856
		// (get) Token: 0x06001EA0 RID: 7840 RVA: 0x00022E80 File Offset: 0x00021080
		// (set) Token: 0x06001EA1 RID: 7841 RVA: 0x00022E88 File Offset: 0x00021088
		[DataMember(Name = "violatingNodeId", IsRequired = true)]
		public int ViolatingNodeId { get; set; }

		// Token: 0x17000B29 RID: 2857
		// (get) Token: 0x06001EA2 RID: 7842 RVA: 0x00022E91 File Offset: 0x00021091
		// (set) Token: 0x06001EA3 RID: 7843 RVA: 0x00022E99 File Offset: 0x00021099
		[DataMember(Name = "violatingNodeSelector", IsRequired = true)]
		public string ViolatingNodeSelector { get; set; }

		// Token: 0x17000B2A RID: 2858
		// (get) Token: 0x06001EA4 RID: 7844 RVA: 0x00022EA2 File Offset: 0x000210A2
		// (set) Token: 0x06001EA5 RID: 7845 RVA: 0x00022EAA File Offset: 0x000210AA
		[DataMember(Name = "contrastRatio", IsRequired = true)]
		public double ContrastRatio { get; set; }

		// Token: 0x17000B2B RID: 2859
		// (get) Token: 0x06001EA6 RID: 7846 RVA: 0x00022EB3 File Offset: 0x000210B3
		// (set) Token: 0x06001EA7 RID: 7847 RVA: 0x00022EBB File Offset: 0x000210BB
		[DataMember(Name = "thresholdAA", IsRequired = true)]
		public double ThresholdAA { get; set; }

		// Token: 0x17000B2C RID: 2860
		// (get) Token: 0x06001EA8 RID: 7848 RVA: 0x00022EC4 File Offset: 0x000210C4
		// (set) Token: 0x06001EA9 RID: 7849 RVA: 0x00022ECC File Offset: 0x000210CC
		[DataMember(Name = "thresholdAAA", IsRequired = true)]
		public double ThresholdAAA { get; set; }

		// Token: 0x17000B2D RID: 2861
		// (get) Token: 0x06001EAA RID: 7850 RVA: 0x00022ED5 File Offset: 0x000210D5
		// (set) Token: 0x06001EAB RID: 7851 RVA: 0x00022EDD File Offset: 0x000210DD
		[DataMember(Name = "fontSize", IsRequired = true)]
		public string FontSize { get; set; }

		// Token: 0x17000B2E RID: 2862
		// (get) Token: 0x06001EAC RID: 7852 RVA: 0x00022EE6 File Offset: 0x000210E6
		// (set) Token: 0x06001EAD RID: 7853 RVA: 0x00022EEE File Offset: 0x000210EE
		[DataMember(Name = "fontWeight", IsRequired = true)]
		public string FontWeight { get; set; }
	}
}
