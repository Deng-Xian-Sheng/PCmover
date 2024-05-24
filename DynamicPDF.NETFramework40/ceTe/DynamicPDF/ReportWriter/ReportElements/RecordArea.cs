using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.Layout;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000848 RID: 2120
	public class RecordArea : ReportElement
	{
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06005589 RID: 21897 RVA: 0x00297DA0 File Offset: 0x00296DA0
		// (remove) Token: 0x0600558A RID: 21898 RVA: 0x00297DDC File Offset: 0x00296DDC
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.x;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.x, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.x;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.x, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x0600558B RID: 21899 RVA: 0x00297E18 File Offset: 0x00296E18
		// (remove) Token: 0x0600558C RID: 21900 RVA: 0x00297E54 File Offset: 0x00296E54
		public event RecordAreaLaidOutEventHandler LaidOut
		{
			add
			{
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler = this.y;
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler2;
				do
				{
					recordAreaLaidOutEventHandler2 = recordAreaLaidOutEventHandler;
					RecordAreaLaidOutEventHandler value2 = (RecordAreaLaidOutEventHandler)Delegate.Combine(recordAreaLaidOutEventHandler2, value);
					recordAreaLaidOutEventHandler = Interlocked.CompareExchange<RecordAreaLaidOutEventHandler>(ref this.y, value2, recordAreaLaidOutEventHandler2);
				}
				while (recordAreaLaidOutEventHandler != recordAreaLaidOutEventHandler2);
			}
			remove
			{
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler = this.y;
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler2;
				do
				{
					recordAreaLaidOutEventHandler2 = recordAreaLaidOutEventHandler;
					RecordAreaLaidOutEventHandler value2 = (RecordAreaLaidOutEventHandler)Delegate.Remove(recordAreaLaidOutEventHandler2, value);
					recordAreaLaidOutEventHandler = Interlocked.CompareExchange<RecordAreaLaidOutEventHandler>(ref this.y, value2, recordAreaLaidOutEventHandler2);
				}
				while (recordAreaLaidOutEventHandler != recordAreaLaidOutEventHandler2);
			}
		}

		// Token: 0x0600558D RID: 21901 RVA: 0x00297E90 File Offset: 0x00296E90
		internal RecordArea(rm A_0, we A_1)
		{
			this.a = A_1.a();
			this.b = A_1.b();
			this.c = A_1.c();
			this.d = A_1.d();
			this.e = A_1.e();
			this.f = A_1.f();
			this.g = A_1.g();
			this.h = A_1.h();
			this.i = A_1.i();
			this.j = A_1.j();
			this.k = A_1.k();
			this.l = A_1.l();
			this.o = A_1.m();
			this.p = A_1.n();
			this.q = A_1.o();
			this.t = A_1.r();
			this.u = A_1.s();
			this.s = A_1.q();
			this.r = A_1.p();
			if (this.k.d())
			{
				A_0.b().ex().a(this.k.e());
			}
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			this.w = A_0;
			if (A_0.c())
			{
				if (A_0 is SubReport && this.k.d())
				{
					this.k.e().a((SubReport)A_0);
				}
			}
			else
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x0600558E RID: 21902 RVA: 0x00298048 File Offset: 0x00297048
		internal override void gi(xh A_0, LayoutWriter A_1)
		{
			if (this.k != null)
			{
				if (this.x != null)
				{
					LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
					this.x(this, layingOutEventArgs);
					if (!layingOutEventArgs.Layout)
					{
						return;
					}
				}
				LayoutTextArea layoutTextArea;
				if (this.k.d())
				{
					layoutTextArea = new LayoutTextArea(this, new char[0]);
					A_0.a(layoutTextArea);
					if (this.d)
					{
						A_0.a().a(layoutTextArea);
					}
					vi vi = new vi();
					for (int i = 0; i < this.k.c().a(); i++)
					{
						if (this.k.c().a(i).e8())
						{
							((rq)this.k.c().a(i)).a().eu(A_1, vi, layoutTextArea);
						}
					}
					wt wt = new wt(this.k.c().a());
					this.k.a(A_1, wt);
					if (this.k.e().c())
					{
						if (this.k.e().d() == null)
						{
							((Report)this.w).f().f().a(new tv(layoutTextArea, vi, this.k, wt));
						}
						else
						{
							((SubReport)this.w).f().f().a(new tv(layoutTextArea, vi, this.k, wt));
						}
					}
					else if (this.w is FixedPage)
					{
						((FixedPage)this.w).h().a(new tv(layoutTextArea, vi, this.k, wt));
					}
					else
					{
						((w1)A_1).e2().a(new tv(layoutTextArea, vi, this.k, wt));
					}
					vi.a();
				}
				else
				{
					layoutTextArea = new LayoutTextArea(this, this.k.b(A_1));
					A_0.a(layoutTextArea);
					if (this.d)
					{
						A_0.a().a(layoutTextArea);
					}
				}
				if (this.y != null)
				{
					RecordAreaLaidOutEventArgs recordAreaLaidOutEventArgs = new RecordAreaLaidOutEventArgs(A_1, layoutTextArea);
					this.y(this, recordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600558F RID: 21903 RVA: 0x002982E4 File Offset: 0x002972E4
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (this.k != null)
			{
				if (this.x != null)
				{
					LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
					this.x(this, layingOutEventArgs);
					if (!layingOutEventArgs.Layout)
					{
						return;
					}
				}
				LayoutTextArea layoutTextArea;
				if (this.k.d())
				{
					layoutTextArea = new LayoutTextArea(this, new char[0]);
					A_0.a(layoutTextArea);
					vi vi = new vi();
					for (int i = 0; i < this.k.c().a(); i++)
					{
						if (this.k.c().a(i).e8())
						{
							((rq)this.k.c().a(i)).a().eu(A_1, vi, layoutTextArea);
						}
					}
					wt wt = new wt(this.k.c().a());
					this.k.a(A_1, wt);
					if (this.k.e().c())
					{
						if (this.k.e().d() == null)
						{
							((Report)this.w).f().f().a(new tv(layoutTextArea, vi, this.k, wt));
						}
						else
						{
							((SubReport)this.w).f().f().a(new tv(layoutTextArea, vi, this.k, wt));
						}
					}
					else if (this.w is FixedPage)
					{
						((FixedPage)this.w).h().a(new tv(layoutTextArea, vi, this.k, wt));
					}
					else
					{
						((w1)A_1).e2().a(new tv(layoutTextArea, vi, this.k, wt));
					}
					vi.a();
				}
				else
				{
					layoutTextArea = new LayoutTextArea(this, this.k.b(A_1));
					A_0.a(layoutTextArea);
				}
				if (this.y != null)
				{
					RecordAreaLaidOutEventArgs recordAreaLaidOutEventArgs = new RecordAreaLaidOutEventArgs(A_1, layoutTextArea);
					this.y(this, recordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x06005590 RID: 21904 RVA: 0x00298548 File Offset: 0x00297548
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x06005591 RID: 21905 RVA: 0x0029855C File Offset: 0x0029755C
		internal override short gk()
		{
			return this.v;
		}

		// Token: 0x06005592 RID: 21906 RVA: 0x00298574 File Offset: 0x00297574
		internal override void gl(short A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06005593 RID: 21907 RVA: 0x00298580 File Offset: 0x00297580
		internal override x5 gm()
		{
			return this.u;
		}

		// Token: 0x06005594 RID: 21908 RVA: 0x00298598 File Offset: 0x00297598
		internal override x5 gn()
		{
			return x5.f(this.u, this.r);
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06005595 RID: 21909 RVA: 0x002985BC File Offset: 0x002975BC
		// (set) Token: 0x06005596 RID: 21910 RVA: 0x002985D4 File Offset: 0x002975D4
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

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06005597 RID: 21911 RVA: 0x002985E0 File Offset: 0x002975E0
		// (set) Token: 0x06005598 RID: 21912 RVA: 0x002985F8 File Offset: 0x002975F8
		public bool AutoLeading
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

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06005599 RID: 21913 RVA: 0x00298604 File Offset: 0x00297604
		// (set) Token: 0x0600559A RID: 21914 RVA: 0x0029861C File Offset: 0x0029761C
		public bool CleanParagraphBreaks
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

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x0600559B RID: 21915 RVA: 0x00298628 File Offset: 0x00297628
		// (set) Token: 0x0600559C RID: 21916 RVA: 0x00298640 File Offset: 0x00297640
		public bool Expandable
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

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x0600559D RID: 21917 RVA: 0x0029864C File Offset: 0x0029764C
		// (set) Token: 0x0600559E RID: 21918 RVA: 0x00298664 File Offset: 0x00297664
		public bool Splittable
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

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x0600559F RID: 21919 RVA: 0x00298670 File Offset: 0x00297670
		// (set) Token: 0x060055A0 RID: 21920 RVA: 0x00298688 File Offset: 0x00297688
		public Font Font
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

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x060055A1 RID: 21921 RVA: 0x00298694 File Offset: 0x00297694
		// (set) Token: 0x060055A2 RID: 21922 RVA: 0x002986AC File Offset: 0x002976AC
		public float FontSize
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

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x060055A3 RID: 21923 RVA: 0x002986B8 File Offset: 0x002976B8
		// (set) Token: 0x060055A4 RID: 21924 RVA: 0x002986D0 File Offset: 0x002976D0
		public float Leading
		{
			get
			{
				return this.h;
			}
			set
			{
				this.b = false;
				this.h = value;
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x060055A5 RID: 21925 RVA: 0x002986E4 File Offset: 0x002976E4
		// (set) Token: 0x060055A6 RID: 21926 RVA: 0x002986FC File Offset: 0x002976FC
		public float ParagraphIndent
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

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x060055A7 RID: 21927 RVA: 0x00298708 File Offset: 0x00297708
		// (set) Token: 0x060055A8 RID: 21928 RVA: 0x00298720 File Offset: 0x00297720
		public float ParagraphSpacing
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

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x060055A9 RID: 21929 RVA: 0x0029872C File Offset: 0x0029772C
		// (set) Token: 0x060055AA RID: 21930 RVA: 0x00298749 File Offset: 0x00297749
		public string Text
		{
			get
			{
				return this.k.ToString();
			}
			set
			{
				this.k = new tu(value);
			}
		}

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x060055AB RID: 21931 RVA: 0x00298758 File Offset: 0x00297758
		// (set) Token: 0x060055AC RID: 21932 RVA: 0x00298770 File Offset: 0x00297770
		public Color TextColor
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x060055AD RID: 21933 RVA: 0x0029877C File Offset: 0x0029777C
		// (set) Token: 0x060055AE RID: 21934 RVA: 0x00298794 File Offset: 0x00297794
		public Color TextOutlineColor
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x060055AF RID: 21935 RVA: 0x002987A0 File Offset: 0x002977A0
		// (set) Token: 0x060055B0 RID: 21936 RVA: 0x002987B8 File Offset: 0x002977B8
		public float TextOutlineWidth
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x060055B1 RID: 21937 RVA: 0x002987C4 File Offset: 0x002977C4
		// (set) Token: 0x060055B2 RID: 21938 RVA: 0x002987DC File Offset: 0x002977DC
		public bool Underline
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x060055B3 RID: 21939 RVA: 0x002987E8 File Offset: 0x002977E8
		// (set) Token: 0x060055B4 RID: 21940 RVA: 0x00298800 File Offset: 0x00297800
		public VAlign VAlign
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x060055B5 RID: 21941 RVA: 0x0029880C File Offset: 0x0029780C
		// (set) Token: 0x060055B6 RID: 21942 RVA: 0x00298824 File Offset: 0x00297824
		public float Angle
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x060055B7 RID: 21943 RVA: 0x00298830 File Offset: 0x00297830
		// (set) Token: 0x060055B8 RID: 21944 RVA: 0x0029884E File Offset: 0x0029784E
		public float Height
		{
			get
			{
				return x5.b(this.r);
			}
			set
			{
				this.r = x5.a(value);
			}
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x060055B9 RID: 21945 RVA: 0x00298860 File Offset: 0x00297860
		// (set) Token: 0x060055BA RID: 21946 RVA: 0x0029887E File Offset: 0x0029787E
		public float Width
		{
			get
			{
				return x5.b(this.s);
			}
			set
			{
				this.s = x5.a(value);
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x060055BB RID: 21947 RVA: 0x00298890 File Offset: 0x00297890
		// (set) Token: 0x060055BC RID: 21948 RVA: 0x002988AE File Offset: 0x002978AE
		public float X
		{
			get
			{
				return x5.b(this.t);
			}
			set
			{
				this.t = x5.a(value);
			}
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x060055BD RID: 21949 RVA: 0x002988C0 File Offset: 0x002978C0
		// (set) Token: 0x060055BE RID: 21950 RVA: 0x002988DE File Offset: 0x002978DE
		public float Y
		{
			get
			{
				return x5.b(this.u);
			}
			set
			{
				this.u = x5.a(value);
			}
		}

		// Token: 0x04002DA7 RID: 11687
		private TextAlign a;

		// Token: 0x04002DA8 RID: 11688
		private bool b;

		// Token: 0x04002DA9 RID: 11689
		private bool c;

		// Token: 0x04002DAA RID: 11690
		private bool d;

		// Token: 0x04002DAB RID: 11691
		private bool e;

		// Token: 0x04002DAC RID: 11692
		private Font f;

		// Token: 0x04002DAD RID: 11693
		private float g;

		// Token: 0x04002DAE RID: 11694
		private float h;

		// Token: 0x04002DAF RID: 11695
		private float i;

		// Token: 0x04002DB0 RID: 11696
		private float j;

		// Token: 0x04002DB1 RID: 11697
		private tu k;

		// Token: 0x04002DB2 RID: 11698
		private Color l;

		// Token: 0x04002DB3 RID: 11699
		private Color m;

		// Token: 0x04002DB4 RID: 11700
		private float n = 1f;

		// Token: 0x04002DB5 RID: 11701
		private bool o;

		// Token: 0x04002DB6 RID: 11702
		private VAlign p;

		// Token: 0x04002DB7 RID: 11703
		private float q;

		// Token: 0x04002DB8 RID: 11704
		private x5 r;

		// Token: 0x04002DB9 RID: 11705
		private x5 s;

		// Token: 0x04002DBA RID: 11706
		private x5 t;

		// Token: 0x04002DBB RID: 11707
		private x5 u;

		// Token: 0x04002DBC RID: 11708
		private short v = short.MinValue;

		// Token: 0x04002DBD RID: 11709
		private rm w;

		// Token: 0x04002DBE RID: 11710
		private LayingOutEventHandler x;

		// Token: 0x04002DBF RID: 11711
		private RecordAreaLaidOutEventHandler y;
	}
}
