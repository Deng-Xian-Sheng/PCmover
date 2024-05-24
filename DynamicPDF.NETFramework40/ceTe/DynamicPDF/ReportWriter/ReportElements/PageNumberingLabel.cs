using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000842 RID: 2114
	public class PageNumberingLabel : ReportElement
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06005541 RID: 21825 RVA: 0x0029742C File Offset: 0x0029642C
		// (remove) Token: 0x06005542 RID: 21826 RVA: 0x00297468 File Offset: 0x00296468
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

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06005543 RID: 21827 RVA: 0x002974A4 File Offset: 0x002964A4
		// (remove) Token: 0x06005544 RID: 21828 RVA: 0x002974E0 File Offset: 0x002964E0
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

		// Token: 0x06005545 RID: 21829 RVA: 0x0029751C File Offset: 0x0029651C
		internal PageNumberingLabel(rm A_0, v9 A_1)
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
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005546 RID: 21830 RVA: 0x00297618 File Offset: 0x00296618
		internal override void fi(xf A_0, LayoutWriter A_1)
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
			ry ry = new ry(this.f, x5.b(this.m), x5.b(this.n), x5.b(this.l), x5.b(this.k), this.b, this.c, this.a, this.g);
			ry.Angle = this.j;
			ry.Underline = this.h;
			ry.VAlign = this.i;
			ry.PageOffset = this.d;
			ry.PageTotalOffset = this.e;
			A_0.a(ry);
			if (this.q != null)
			{
				PageNumberingLabelLaidOutEventArgs pageNumberingLabelLaidOutEventArgs = new PageNumberingLabelLaidOutEventArgs(A_1, ry);
				this.q(this, pageNumberingLabelLaidOutEventArgs);
			}
		}

		// Token: 0x06005547 RID: 21831 RVA: 0x0029771C File Offset: 0x0029671C
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x06005548 RID: 21832 RVA: 0x00297730 File Offset: 0x00296730
		internal override short gk()
		{
			return this.o;
		}

		// Token: 0x06005549 RID: 21833 RVA: 0x00297748 File Offset: 0x00296748
		internal override void gl(short A_0)
		{
			this.o = A_0;
		}

		// Token: 0x0600554A RID: 21834 RVA: 0x00297754 File Offset: 0x00296754
		internal override x5 gm()
		{
			return this.n;
		}

		// Token: 0x0600554B RID: 21835 RVA: 0x0029776C File Offset: 0x0029676C
		internal override x5 gn()
		{
			return x5.f(this.n, this.k);
		}

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x0600554C RID: 21836 RVA: 0x00297790 File Offset: 0x00296790
		// (set) Token: 0x0600554D RID: 21837 RVA: 0x002977A8 File Offset: 0x002967A8
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

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x0600554E RID: 21838 RVA: 0x002977B4 File Offset: 0x002967B4
		// (set) Token: 0x0600554F RID: 21839 RVA: 0x002977CC File Offset: 0x002967CC
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

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06005550 RID: 21840 RVA: 0x002977D8 File Offset: 0x002967D8
		// (set) Token: 0x06005551 RID: 21841 RVA: 0x002977F0 File Offset: 0x002967F0
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

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06005552 RID: 21842 RVA: 0x002977FC File Offset: 0x002967FC
		// (set) Token: 0x06005553 RID: 21843 RVA: 0x00297814 File Offset: 0x00296814
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

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06005554 RID: 21844 RVA: 0x00297820 File Offset: 0x00296820
		// (set) Token: 0x06005555 RID: 21845 RVA: 0x00297838 File Offset: 0x00296838
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

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x06005556 RID: 21846 RVA: 0x00297844 File Offset: 0x00296844
		// (set) Token: 0x06005557 RID: 21847 RVA: 0x0029785C File Offset: 0x0029685C
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

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06005558 RID: 21848 RVA: 0x00297868 File Offset: 0x00296868
		// (set) Token: 0x06005559 RID: 21849 RVA: 0x00297880 File Offset: 0x00296880
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

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x0600555A RID: 21850 RVA: 0x0029788C File Offset: 0x0029688C
		// (set) Token: 0x0600555B RID: 21851 RVA: 0x002978A4 File Offset: 0x002968A4
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

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x0600555C RID: 21852 RVA: 0x002978B0 File Offset: 0x002968B0
		// (set) Token: 0x0600555D RID: 21853 RVA: 0x002978CE File Offset: 0x002968CE
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

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x0600555E RID: 21854 RVA: 0x002978E0 File Offset: 0x002968E0
		// (set) Token: 0x0600555F RID: 21855 RVA: 0x002978FE File Offset: 0x002968FE
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

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06005560 RID: 21856 RVA: 0x00297910 File Offset: 0x00296910
		// (set) Token: 0x06005561 RID: 21857 RVA: 0x0029792E File Offset: 0x0029692E
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

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06005562 RID: 21858 RVA: 0x00297940 File Offset: 0x00296940
		// (set) Token: 0x06005563 RID: 21859 RVA: 0x0029795E File Offset: 0x0029695E
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

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06005564 RID: 21860 RVA: 0x00297970 File Offset: 0x00296970
		// (set) Token: 0x06005565 RID: 21861 RVA: 0x00297988 File Offset: 0x00296988
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

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06005566 RID: 21862 RVA: 0x00297994 File Offset: 0x00296994
		// (set) Token: 0x06005567 RID: 21863 RVA: 0x002979AC File Offset: 0x002969AC
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

		// Token: 0x04002D8B RID: 11659
		private TextAlign a;

		// Token: 0x04002D8C RID: 11660
		private Font b;

		// Token: 0x04002D8D RID: 11661
		private float c;

		// Token: 0x04002D8E RID: 11662
		private int d;

		// Token: 0x04002D8F RID: 11663
		private int e;

		// Token: 0x04002D90 RID: 11664
		private string f;

		// Token: 0x04002D91 RID: 11665
		private Color g;

		// Token: 0x04002D92 RID: 11666
		private bool h;

		// Token: 0x04002D93 RID: 11667
		private VAlign i;

		// Token: 0x04002D94 RID: 11668
		private float j;

		// Token: 0x04002D95 RID: 11669
		private x5 k;

		// Token: 0x04002D96 RID: 11670
		private x5 l;

		// Token: 0x04002D97 RID: 11671
		private x5 m;

		// Token: 0x04002D98 RID: 11672
		private x5 n;

		// Token: 0x04002D99 RID: 11673
		private short o = short.MinValue;

		// Token: 0x04002D9A RID: 11674
		private LayingOutEventHandler p;

		// Token: 0x04002D9B RID: 11675
		private PageNumberingLabelLaidOutEventHandler q;
	}
}
