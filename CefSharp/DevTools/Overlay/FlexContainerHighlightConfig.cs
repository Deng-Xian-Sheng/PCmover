using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200028D RID: 653
	[DataContract]
	public class FlexContainerHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x060012AB RID: 4779 RVA: 0x000174BB File Offset: 0x000156BB
		// (set) Token: 0x060012AC RID: 4780 RVA: 0x000174C3 File Offset: 0x000156C3
		[DataMember(Name = "containerBorder", IsRequired = false)]
		public LineStyle ContainerBorder { get; set; }

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x060012AD RID: 4781 RVA: 0x000174CC File Offset: 0x000156CC
		// (set) Token: 0x060012AE RID: 4782 RVA: 0x000174D4 File Offset: 0x000156D4
		[DataMember(Name = "lineSeparator", IsRequired = false)]
		public LineStyle LineSeparator { get; set; }

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x060012AF RID: 4783 RVA: 0x000174DD File Offset: 0x000156DD
		// (set) Token: 0x060012B0 RID: 4784 RVA: 0x000174E5 File Offset: 0x000156E5
		[DataMember(Name = "itemSeparator", IsRequired = false)]
		public LineStyle ItemSeparator { get; set; }

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x000174EE File Offset: 0x000156EE
		// (set) Token: 0x060012B2 RID: 4786 RVA: 0x000174F6 File Offset: 0x000156F6
		[DataMember(Name = "mainDistributedSpace", IsRequired = false)]
		public BoxStyle MainDistributedSpace { get; set; }

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x060012B3 RID: 4787 RVA: 0x000174FF File Offset: 0x000156FF
		// (set) Token: 0x060012B4 RID: 4788 RVA: 0x00017507 File Offset: 0x00015707
		[DataMember(Name = "crossDistributedSpace", IsRequired = false)]
		public BoxStyle CrossDistributedSpace { get; set; }

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x00017510 File Offset: 0x00015710
		// (set) Token: 0x060012B6 RID: 4790 RVA: 0x00017518 File Offset: 0x00015718
		[DataMember(Name = "rowGapSpace", IsRequired = false)]
		public BoxStyle RowGapSpace { get; set; }

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x00017521 File Offset: 0x00015721
		// (set) Token: 0x060012B8 RID: 4792 RVA: 0x00017529 File Offset: 0x00015729
		[DataMember(Name = "columnGapSpace", IsRequired = false)]
		public BoxStyle ColumnGapSpace { get; set; }

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x060012B9 RID: 4793 RVA: 0x00017532 File Offset: 0x00015732
		// (set) Token: 0x060012BA RID: 4794 RVA: 0x0001753A File Offset: 0x0001573A
		[DataMember(Name = "crossAlignment", IsRequired = false)]
		public LineStyle CrossAlignment { get; set; }
	}
}
