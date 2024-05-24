using System;
using System.Threading;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200094F RID: 2383
	public class PageNumberingLabel : LayoutElement
	{
		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060060EF RID: 24815 RVA: 0x00362638 File Offset: 0x00361638
		// (remove) Token: 0x060060F0 RID: 24816 RVA: 0x00362674 File Offset: 0x00361674
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.p;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.p, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.p;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.p, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060060F1 RID: 24817 RVA: 0x003626B0 File Offset: 0x003616B0
		// (remove) Token: 0x060060F2 RID: 24818 RVA: 0x003626EC File Offset: 0x003616EC
		public event PageNumberingLabelLaidOutEventHandler LaidOut
		{
			add
			{
				PageNumberingLabelLaidOutEventHandler pageNumberingLabelLaidOutEventHandler = this.q;
				PageNumberingLabelLaidOutEventHandler pageNumberingLabelLaidOutEventHandler2;
				do
				{
					pageNumberingLabelLaidOutEventHandler2 = pageNumberingLabelLaidOutEventHandler;
					PageNumberingLabelLaidOutEventHandler value2 = (PageNumberingLabelLaidOutEventHandler)Delegate.Combine(pageNumberingLabelLaidOutEventHandler2, value);
					pageNumberingLabelLaidOutEventHandler = Interlocked.CompareExchange<PageNumberingLabelLaidOutEventHandler>(ref this.q, value2, pageNumberingLabelLaidOutEventHandler2);
				}
				while (pageNumberingLabelLaidOutEventHandler != pageNumberingLabelLaidOutEventHandler2);
			}
			remove
			{
				PageNumberingLabelLaidOutEventHandler pageNumberingLabelLaidOutEventHandler = this.q;
				PageNumberingLabelLaidOutEventHandler pageNumberingLabelLaidOutEventHandler2;
				do
				{
					pageNumberingLabelLaidOutEventHandler2 = pageNumberingLabelLaidOutEventHandler;
					PageNumberingLabelLaidOutEventHandler value2 = (PageNumberingLabelLaidOutEventHandler)Delegate.Remove(pageNumberingLabelLaidOutEventHandler2, value);
					pageNumberingLabelLaidOutEventHandler = Interlocked.CompareExchange<PageNumberingLabelLaidOutEventHandler>(ref this.q, value2, pageNumberingLabelLaidOutEventHandler2);
				}
				while (pageNumberingLabelLaidOutEventHandler != pageNumberingLabelLaidOutEventHandler2);
			}
		}

		// Token: 0x060060F3 RID: 24819 RVA: 0x00362728 File Offset: 0x00361728
		internal PageNumberingLabel(alo A_0, alb A_1)
		{
			this.j = A_1.h();
			this.m = A_1.k();
			this.n = A_1.l();
			this.l = A_1.j();
			this.k = A_1.i();
			this.a = A_1.a();
			this.b = A_1.b();
			this.c = A_1.c();
			this.f = A_1.d();
			this.i = A_1.g();
			this.h = A_1.f();
			this.g = A_1.e();
			this.d = A_1.m();
			this.e = A_1.n();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x060060F4 RID: 24820 RVA: 0x00362824 File Offset: 0x00361824
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.p != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.p(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			amv amv = new amv(this.f, x5.b(this.m), x5.b(this.n), x5.b(this.l), x5.b(this.k), this.b, this.c, this.a, this.g);
			amv.Angle = this.j;
			amv.Underline = this.h;
			amv.VAlign = this.i;
			amv.PageOffset = this.d;
			amv.PageTotalOffset = this.e;
			A_0.a(amv);
			if (this.q != null)
			{
				PageNumberingLabelLaidOutEventArgs pageNumberingLabelLaidOutEventArgs = new PageNumberingLabelLaidOutEventArgs(A_1, amv);
				this.q(this, pageNumberingLabelLaidOutEventArgs);
			}
		}

		// Token: 0x060060F5 RID: 24821 RVA: 0x00362928 File Offset: 0x00361928
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x060060F6 RID: 24822 RVA: 0x0036293C File Offset: 0x0036193C
		internal override short nw()
		{
			return this.o;
		}

		// Token: 0x060060F7 RID: 24823 RVA: 0x00362954 File Offset: 0x00361954
		internal override void nx(short A_0)
		{
			this.o = A_0;
		}

		// Token: 0x060060F8 RID: 24824 RVA: 0x00362960 File Offset: 0x00361960
		internal override x5 ny()
		{
			return this.n;
		}

		// Token: 0x060060F9 RID: 24825 RVA: 0x00362978 File Offset: 0x00361978
		internal override x5 nz()
		{
			return x5.f(this.n, this.k);
		}

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x060060FA RID: 24826 RVA: 0x0036299C File Offset: 0x0036199C
		// (set) Token: 0x060060FB RID: 24827 RVA: 0x003629B4 File Offset: 0x003619B4
		public TextAlign Align
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x060060FC RID: 24828 RVA: 0x003629C0 File Offset: 0x003619C0
		// (set) Token: 0x060060FD RID: 24829 RVA: 0x003629D8 File Offset: 0x003619D8
		public Font Font
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x060060FE RID: 24830 RVA: 0x003629E4 File Offset: 0x003619E4
		// (set) Token: 0x060060FF RID: 24831 RVA: 0x003629FC File Offset: 0x003619FC
		public float FontSize
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x06006100 RID: 24832 RVA: 0x00362A08 File Offset: 0x00361A08
		// (set) Token: 0x06006101 RID: 24833 RVA: 0x00362A20 File Offset: 0x00361A20
		public string Text
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06006102 RID: 24834 RVA: 0x00362A2C File Offset: 0x00361A2C
		// (set) Token: 0x06006103 RID: 24835 RVA: 0x00362A44 File Offset: 0x00361A44
		public Color TextColor
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06006104 RID: 24836 RVA: 0x00362A50 File Offset: 0x00361A50
		// (set) Token: 0x06006105 RID: 24837 RVA: 0x00362A68 File Offset: 0x00361A68
		public bool Underline
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06006106 RID: 24838 RVA: 0x00362A74 File Offset: 0x00361A74
		// (set) Token: 0x06006107 RID: 24839 RVA: 0x00362A8C File Offset: 0x00361A8C
		public VAlign VAlign
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x06006108 RID: 24840 RVA: 0x00362A98 File Offset: 0x00361A98
		// (set) Token: 0x06006109 RID: 24841 RVA: 0x00362AB0 File Offset: 0x00361AB0
		public float Angle
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x0600610A RID: 24842 RVA: 0x00362ABC File Offset: 0x00361ABC
		// (set) Token: 0x0600610B RID: 24843 RVA: 0x00362ADA File Offset: 0x00361ADA
		public float Height
		{
			get
			{
				return x5.b(this.k);
			}
			set
			{
				this.k = x5.a(value);
			}
		}

		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x0600610C RID: 24844 RVA: 0x00362AEC File Offset: 0x00361AEC
		// (set) Token: 0x0600610D RID: 24845 RVA: 0x00362B0A File Offset: 0x00361B0A
		public float Width
		{
			get
			{
				return x5.b(this.l);
			}
			set
			{
				this.l = x5.a(value);
			}
		}

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x0600610E RID: 24846 RVA: 0x00362B1C File Offset: 0x00361B1C
		// (set) Token: 0x0600610F RID: 24847 RVA: 0x00362B3A File Offset: 0x00361B3A
		public float X
		{
			get
			{
				return x5.b(this.m);
			}
			set
			{
				this.m = x5.a(value);
			}
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x06006110 RID: 24848 RVA: 0x00362B4C File Offset: 0x00361B4C
		// (set) Token: 0x06006111 RID: 24849 RVA: 0x00362B6A File Offset: 0x00361B6A
		public float Y
		{
			get
			{
				return x5.b(this.n);
			}
			set
			{
				this.n = x5.a(value);
			}
		}

		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x06006112 RID: 24850 RVA: 0x00362B7C File Offset: 0x00361B7C
		// (set) Token: 0x06006113 RID: 24851 RVA: 0x00362B94 File Offset: 0x00361B94
		public int PageTotalOffset
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06006114 RID: 24852 RVA: 0x00362BA0 File Offset: 0x00361BA0
		// (set) Token: 0x06006115 RID: 24853 RVA: 0x00362BB8 File Offset: 0x00361BB8
		public int PageOffset
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x04003212 RID: 12818
		private TextAlign a;

		// Token: 0x04003213 RID: 12819
		private Font b;

		// Token: 0x04003214 RID: 12820
		private float c;

		// Token: 0x04003215 RID: 12821
		private int d;

		// Token: 0x04003216 RID: 12822
		private int e;

		// Token: 0x04003217 RID: 12823
		private string f;

		// Token: 0x04003218 RID: 12824
		private Color g;

		// Token: 0x04003219 RID: 12825
		private bool h;

		// Token: 0x0400321A RID: 12826
		private VAlign i;

		// Token: 0x0400321B RID: 12827
		private float j;

		// Token: 0x0400321C RID: 12828
		private x5 k;

		// Token: 0x0400321D RID: 12829
		private x5 l;

		// Token: 0x0400321E RID: 12830
		private x5 m;

		// Token: 0x0400321F RID: 12831
		private x5 n;

		// Token: 0x04003220 RID: 12832
		private short o = short.MinValue;

		// Token: 0x04003221 RID: 12833
		private LayingOutEventHandler p;

		// Token: 0x04003222 RID: 12834
		private PageNumberingLabelLaidOutEventHandler q;
	}
}
