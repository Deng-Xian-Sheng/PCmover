using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200027B RID: 635
	[DataContract]
	public class GetLayoutMetricsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x060011E0 RID: 4576 RVA: 0x000160C1 File Offset: 0x000142C1
		// (set) Token: 0x060011E1 RID: 4577 RVA: 0x000160C9 File Offset: 0x000142C9
		[DataMember]
		internal LayoutViewport layoutViewport { get; set; }

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x060011E2 RID: 4578 RVA: 0x000160D2 File Offset: 0x000142D2
		public LayoutViewport LayoutViewport
		{
			get
			{
				return this.layoutViewport;
			}
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x060011E3 RID: 4579 RVA: 0x000160DA File Offset: 0x000142DA
		// (set) Token: 0x060011E4 RID: 4580 RVA: 0x000160E2 File Offset: 0x000142E2
		[DataMember]
		internal VisualViewport visualViewport { get; set; }

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x060011E5 RID: 4581 RVA: 0x000160EB File Offset: 0x000142EB
		public VisualViewport VisualViewport
		{
			get
			{
				return this.visualViewport;
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x060011E6 RID: 4582 RVA: 0x000160F3 File Offset: 0x000142F3
		// (set) Token: 0x060011E7 RID: 4583 RVA: 0x000160FB File Offset: 0x000142FB
		[DataMember]
		internal Rect contentSize { get; set; }

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x060011E8 RID: 4584 RVA: 0x00016104 File Offset: 0x00014304
		public Rect ContentSize
		{
			get
			{
				return this.contentSize;
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x060011E9 RID: 4585 RVA: 0x0001610C File Offset: 0x0001430C
		// (set) Token: 0x060011EA RID: 4586 RVA: 0x00016114 File Offset: 0x00014314
		[DataMember]
		internal LayoutViewport cssLayoutViewport { get; set; }

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x060011EB RID: 4587 RVA: 0x0001611D File Offset: 0x0001431D
		public LayoutViewport CssLayoutViewport
		{
			get
			{
				return this.cssLayoutViewport;
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x060011EC RID: 4588 RVA: 0x00016125 File Offset: 0x00014325
		// (set) Token: 0x060011ED RID: 4589 RVA: 0x0001612D File Offset: 0x0001432D
		[DataMember]
		internal VisualViewport cssVisualViewport { get; set; }

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x060011EE RID: 4590 RVA: 0x00016136 File Offset: 0x00014336
		public VisualViewport CssVisualViewport
		{
			get
			{
				return this.cssVisualViewport;
			}
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x060011EF RID: 4591 RVA: 0x0001613E File Offset: 0x0001433E
		// (set) Token: 0x060011F0 RID: 4592 RVA: 0x00016146 File Offset: 0x00014346
		[DataMember]
		internal Rect cssContentSize { get; set; }

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x060011F1 RID: 4593 RVA: 0x0001614F File Offset: 0x0001434F
		public Rect CssContentSize
		{
			get
			{
				return this.cssContentSize;
			}
		}
	}
}
