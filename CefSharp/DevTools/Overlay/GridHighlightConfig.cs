using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200028C RID: 652
	[DataContract]
	public class GridHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06001282 RID: 4738 RVA: 0x0001735F File Offset: 0x0001555F
		// (set) Token: 0x06001283 RID: 4739 RVA: 0x00017367 File Offset: 0x00015567
		[DataMember(Name = "showGridExtensionLines", IsRequired = false)]
		public bool? ShowGridExtensionLines { get; set; }

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06001284 RID: 4740 RVA: 0x00017370 File Offset: 0x00015570
		// (set) Token: 0x06001285 RID: 4741 RVA: 0x00017378 File Offset: 0x00015578
		[DataMember(Name = "showPositiveLineNumbers", IsRequired = false)]
		public bool? ShowPositiveLineNumbers { get; set; }

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06001286 RID: 4742 RVA: 0x00017381 File Offset: 0x00015581
		// (set) Token: 0x06001287 RID: 4743 RVA: 0x00017389 File Offset: 0x00015589
		[DataMember(Name = "showNegativeLineNumbers", IsRequired = false)]
		public bool? ShowNegativeLineNumbers { get; set; }

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06001288 RID: 4744 RVA: 0x00017392 File Offset: 0x00015592
		// (set) Token: 0x06001289 RID: 4745 RVA: 0x0001739A File Offset: 0x0001559A
		[DataMember(Name = "showAreaNames", IsRequired = false)]
		public bool? ShowAreaNames { get; set; }

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x0600128A RID: 4746 RVA: 0x000173A3 File Offset: 0x000155A3
		// (set) Token: 0x0600128B RID: 4747 RVA: 0x000173AB File Offset: 0x000155AB
		[DataMember(Name = "showLineNames", IsRequired = false)]
		public bool? ShowLineNames { get; set; }

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x0600128C RID: 4748 RVA: 0x000173B4 File Offset: 0x000155B4
		// (set) Token: 0x0600128D RID: 4749 RVA: 0x000173BC File Offset: 0x000155BC
		[DataMember(Name = "showTrackSizes", IsRequired = false)]
		public bool? ShowTrackSizes { get; set; }

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x0600128E RID: 4750 RVA: 0x000173C5 File Offset: 0x000155C5
		// (set) Token: 0x0600128F RID: 4751 RVA: 0x000173CD File Offset: 0x000155CD
		[DataMember(Name = "gridBorderColor", IsRequired = false)]
		public RGBA GridBorderColor { get; set; }

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x000173D6 File Offset: 0x000155D6
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x000173DE File Offset: 0x000155DE
		[DataMember(Name = "cellBorderColor", IsRequired = false)]
		public RGBA CellBorderColor { get; set; }

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x06001292 RID: 4754 RVA: 0x000173E7 File Offset: 0x000155E7
		// (set) Token: 0x06001293 RID: 4755 RVA: 0x000173EF File Offset: 0x000155EF
		[DataMember(Name = "rowLineColor", IsRequired = false)]
		public RGBA RowLineColor { get; set; }

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x000173F8 File Offset: 0x000155F8
		// (set) Token: 0x06001295 RID: 4757 RVA: 0x00017400 File Offset: 0x00015600
		[DataMember(Name = "columnLineColor", IsRequired = false)]
		public RGBA ColumnLineColor { get; set; }

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x00017409 File Offset: 0x00015609
		// (set) Token: 0x06001297 RID: 4759 RVA: 0x00017411 File Offset: 0x00015611
		[DataMember(Name = "gridBorderDash", IsRequired = false)]
		public bool? GridBorderDash { get; set; }

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x06001298 RID: 4760 RVA: 0x0001741A File Offset: 0x0001561A
		// (set) Token: 0x06001299 RID: 4761 RVA: 0x00017422 File Offset: 0x00015622
		[DataMember(Name = "cellBorderDash", IsRequired = false)]
		public bool? CellBorderDash { get; set; }

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x0001742B File Offset: 0x0001562B
		// (set) Token: 0x0600129B RID: 4763 RVA: 0x00017433 File Offset: 0x00015633
		[DataMember(Name = "rowLineDash", IsRequired = false)]
		public bool? RowLineDash { get; set; }

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x0001743C File Offset: 0x0001563C
		// (set) Token: 0x0600129D RID: 4765 RVA: 0x00017444 File Offset: 0x00015644
		[DataMember(Name = "columnLineDash", IsRequired = false)]
		public bool? ColumnLineDash { get; set; }

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x0600129E RID: 4766 RVA: 0x0001744D File Offset: 0x0001564D
		// (set) Token: 0x0600129F RID: 4767 RVA: 0x00017455 File Offset: 0x00015655
		[DataMember(Name = "rowGapColor", IsRequired = false)]
		public RGBA RowGapColor { get; set; }

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x060012A0 RID: 4768 RVA: 0x0001745E File Offset: 0x0001565E
		// (set) Token: 0x060012A1 RID: 4769 RVA: 0x00017466 File Offset: 0x00015666
		[DataMember(Name = "rowHatchColor", IsRequired = false)]
		public RGBA RowHatchColor { get; set; }

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x060012A2 RID: 4770 RVA: 0x0001746F File Offset: 0x0001566F
		// (set) Token: 0x060012A3 RID: 4771 RVA: 0x00017477 File Offset: 0x00015677
		[DataMember(Name = "columnGapColor", IsRequired = false)]
		public RGBA ColumnGapColor { get; set; }

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x060012A4 RID: 4772 RVA: 0x00017480 File Offset: 0x00015680
		// (set) Token: 0x060012A5 RID: 4773 RVA: 0x00017488 File Offset: 0x00015688
		[DataMember(Name = "columnHatchColor", IsRequired = false)]
		public RGBA ColumnHatchColor { get; set; }

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x060012A6 RID: 4774 RVA: 0x00017491 File Offset: 0x00015691
		// (set) Token: 0x060012A7 RID: 4775 RVA: 0x00017499 File Offset: 0x00015699
		[DataMember(Name = "areaBorderColor", IsRequired = false)]
		public RGBA AreaBorderColor { get; set; }

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x060012A8 RID: 4776 RVA: 0x000174A2 File Offset: 0x000156A2
		// (set) Token: 0x060012A9 RID: 4777 RVA: 0x000174AA File Offset: 0x000156AA
		[DataMember(Name = "gridBackgroundColor", IsRequired = false)]
		public RGBA GridBackgroundColor { get; set; }
	}
}
