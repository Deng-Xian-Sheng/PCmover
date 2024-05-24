using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000293 RID: 659
	[DataContract]
	public class HighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x060012CF RID: 4815 RVA: 0x00017609 File Offset: 0x00015809
		// (set) Token: 0x060012D0 RID: 4816 RVA: 0x00017611 File Offset: 0x00015811
		[DataMember(Name = "showInfo", IsRequired = false)]
		public bool? ShowInfo { get; set; }

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x060012D1 RID: 4817 RVA: 0x0001761A File Offset: 0x0001581A
		// (set) Token: 0x060012D2 RID: 4818 RVA: 0x00017622 File Offset: 0x00015822
		[DataMember(Name = "showStyles", IsRequired = false)]
		public bool? ShowStyles { get; set; }

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x060012D3 RID: 4819 RVA: 0x0001762B File Offset: 0x0001582B
		// (set) Token: 0x060012D4 RID: 4820 RVA: 0x00017633 File Offset: 0x00015833
		[DataMember(Name = "showRulers", IsRequired = false)]
		public bool? ShowRulers { get; set; }

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x060012D5 RID: 4821 RVA: 0x0001763C File Offset: 0x0001583C
		// (set) Token: 0x060012D6 RID: 4822 RVA: 0x00017644 File Offset: 0x00015844
		[DataMember(Name = "showAccessibilityInfo", IsRequired = false)]
		public bool? ShowAccessibilityInfo { get; set; }

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x060012D7 RID: 4823 RVA: 0x0001764D File Offset: 0x0001584D
		// (set) Token: 0x060012D8 RID: 4824 RVA: 0x00017655 File Offset: 0x00015855
		[DataMember(Name = "showExtensionLines", IsRequired = false)]
		public bool? ShowExtensionLines { get; set; }

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x060012D9 RID: 4825 RVA: 0x0001765E File Offset: 0x0001585E
		// (set) Token: 0x060012DA RID: 4826 RVA: 0x00017666 File Offset: 0x00015866
		[DataMember(Name = "contentColor", IsRequired = false)]
		public RGBA ContentColor { get; set; }

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x060012DB RID: 4827 RVA: 0x0001766F File Offset: 0x0001586F
		// (set) Token: 0x060012DC RID: 4828 RVA: 0x00017677 File Offset: 0x00015877
		[DataMember(Name = "paddingColor", IsRequired = false)]
		public RGBA PaddingColor { get; set; }

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x060012DD RID: 4829 RVA: 0x00017680 File Offset: 0x00015880
		// (set) Token: 0x060012DE RID: 4830 RVA: 0x00017688 File Offset: 0x00015888
		[DataMember(Name = "borderColor", IsRequired = false)]
		public RGBA BorderColor { get; set; }

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x060012DF RID: 4831 RVA: 0x00017691 File Offset: 0x00015891
		// (set) Token: 0x060012E0 RID: 4832 RVA: 0x00017699 File Offset: 0x00015899
		[DataMember(Name = "marginColor", IsRequired = false)]
		public RGBA MarginColor { get; set; }

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x000176A2 File Offset: 0x000158A2
		// (set) Token: 0x060012E2 RID: 4834 RVA: 0x000176AA File Offset: 0x000158AA
		[DataMember(Name = "eventTargetColor", IsRequired = false)]
		public RGBA EventTargetColor { get; set; }

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x000176B3 File Offset: 0x000158B3
		// (set) Token: 0x060012E4 RID: 4836 RVA: 0x000176BB File Offset: 0x000158BB
		[DataMember(Name = "shapeColor", IsRequired = false)]
		public RGBA ShapeColor { get; set; }

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x000176C4 File Offset: 0x000158C4
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x000176CC File Offset: 0x000158CC
		[DataMember(Name = "shapeMarginColor", IsRequired = false)]
		public RGBA ShapeMarginColor { get; set; }

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x000176D5 File Offset: 0x000158D5
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x000176DD File Offset: 0x000158DD
		[DataMember(Name = "cssGridColor", IsRequired = false)]
		public RGBA CssGridColor { get; set; }

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x000176E6 File Offset: 0x000158E6
		// (set) Token: 0x060012EA RID: 4842 RVA: 0x00017702 File Offset: 0x00015902
		public ColorFormat? ColorFormat
		{
			get
			{
				return (ColorFormat?)DevToolsDomainEntityBase.StringToEnum(typeof(ColorFormat?), this.colorFormat);
			}
			set
			{
				this.colorFormat = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x00017715 File Offset: 0x00015915
		// (set) Token: 0x060012EC RID: 4844 RVA: 0x0001771D File Offset: 0x0001591D
		[DataMember(Name = "colorFormat", IsRequired = false)]
		internal string colorFormat { get; set; }

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x00017726 File Offset: 0x00015926
		// (set) Token: 0x060012EE RID: 4846 RVA: 0x0001772E File Offset: 0x0001592E
		[DataMember(Name = "gridHighlightConfig", IsRequired = false)]
		public GridHighlightConfig GridHighlightConfig { get; set; }

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x00017737 File Offset: 0x00015937
		// (set) Token: 0x060012F0 RID: 4848 RVA: 0x0001773F File Offset: 0x0001593F
		[DataMember(Name = "flexContainerHighlightConfig", IsRequired = false)]
		public FlexContainerHighlightConfig FlexContainerHighlightConfig { get; set; }

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x00017748 File Offset: 0x00015948
		// (set) Token: 0x060012F2 RID: 4850 RVA: 0x00017750 File Offset: 0x00015950
		[DataMember(Name = "flexItemHighlightConfig", IsRequired = false)]
		public FlexItemHighlightConfig FlexItemHighlightConfig { get; set; }

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x060012F3 RID: 4851 RVA: 0x00017759 File Offset: 0x00015959
		// (set) Token: 0x060012F4 RID: 4852 RVA: 0x00017775 File Offset: 0x00015975
		public ContrastAlgorithm? ContrastAlgorithm
		{
			get
			{
				return (ContrastAlgorithm?)DevToolsDomainEntityBase.StringToEnum(typeof(ContrastAlgorithm?), this.contrastAlgorithm);
			}
			set
			{
				this.contrastAlgorithm = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x060012F5 RID: 4853 RVA: 0x00017788 File Offset: 0x00015988
		// (set) Token: 0x060012F6 RID: 4854 RVA: 0x00017790 File Offset: 0x00015990
		[DataMember(Name = "contrastAlgorithm", IsRequired = false)]
		internal string contrastAlgorithm { get; set; }

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x060012F7 RID: 4855 RVA: 0x00017799 File Offset: 0x00015999
		// (set) Token: 0x060012F8 RID: 4856 RVA: 0x000177A1 File Offset: 0x000159A1
		[DataMember(Name = "containerQueryContainerHighlightConfig", IsRequired = false)]
		public ContainerQueryContainerHighlightConfig ContainerQueryContainerHighlightConfig { get; set; }
	}
}
