using System;
using System.Threading;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200094B RID: 2379
	public class Label : LayoutElement
	{
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600609F RID: 24735 RVA: 0x003619D0 File Offset: 0x003609D0
		// (remove) Token: 0x060060A0 RID: 24736 RVA: 0x00361A0C File Offset: 0x00360A0C
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.n;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.n, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.n;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.n, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060060A1 RID: 24737 RVA: 0x00361A48 File Offset: 0x00360A48
		// (remove) Token: 0x060060A2 RID: 24738 RVA: 0x00361A84 File Offset: 0x00360A84
		public event LabelLaidOutEventHandler LaidOut
		{
			add
			{
				LabelLaidOutEventHandler labelLaidOutEventHandler = this.o;
				LabelLaidOutEventHandler labelLaidOutEventHandler2;
				do
				{
					labelLaidOutEventHandler2 = labelLaidOutEventHandler;
					LabelLaidOutEventHandler value2 = (LabelLaidOutEventHandler)Delegate.Combine(labelLaidOutEventHandler2, value);
					labelLaidOutEventHandler = Interlocked.CompareExchange<LabelLaidOutEventHandler>(ref this.o, value2, labelLaidOutEventHandler2);
				}
				while (labelLaidOutEventHandler != labelLaidOutEventHandler2);
			}
			remove
			{
				LabelLaidOutEventHandler labelLaidOutEventHandler = this.o;
				LabelLaidOutEventHandler labelLaidOutEventHandler2;
				do
				{
					labelLaidOutEventHandler2 = labelLaidOutEventHandler;
					LabelLaidOutEventHandler value2 = (LabelLaidOutEventHandler)Delegate.Remove(labelLaidOutEventHandler2, value);
					labelLaidOutEventHandler = Interlocked.CompareExchange<LabelLaidOutEventHandler>(ref this.o, value2, labelLaidOutEventHandler2);
				}
				while (labelLaidOutEventHandler != labelLaidOutEventHandler2);
			}
		}

		// Token: 0x060060A3 RID: 24739 RVA: 0x00361AC0 File Offset: 0x00360AC0
		internal Label(alo A_0, ak6 A_1)
		{
			this.h = A_1.h();
			this.k = A_1.k();
			this.l = A_1.l();
			this.j = A_1.j();
			this.i = A_1.i();
			this.a = A_1.a();
			this.b = A_1.b();
			this.c = A_1.c();
			this.d = A_1.d();
			this.g = A_1.g();
			this.f = A_1.f();
			this.e = A_1.e();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x060060A4 RID: 24740 RVA: 0x00361BA4 File Offset: 0x00360BA4
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.n != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.n(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			amt amt = new amt(this.d, x5.b(this.k), x5.b(this.l), x5.b(this.j), x5.b(this.i), this.b, this.c, this.a, this.e);
			amt.Angle = this.h;
			amt.Underline = this.f;
			amt.VAlign = this.g;
			amt.a(this.m);
			A_0.a(amt);
			if (this.o != null)
			{
				LabelLaidOutEventArgs labelLaidOutEventArgs = new LabelLaidOutEventArgs(A_1, amt);
				this.o(this, labelLaidOutEventArgs);
			}
		}

		// Token: 0x060060A5 RID: 24741 RVA: 0x00361C9C File Offset: 0x00360C9C
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x060060A6 RID: 24742 RVA: 0x00361CB0 File Offset: 0x00360CB0
		internal override short nw()
		{
			return this.m;
		}

		// Token: 0x060060A7 RID: 24743 RVA: 0x00361CC8 File Offset: 0x00360CC8
		internal override void nx(short A_0)
		{
			this.m = A_0;
		}

		// Token: 0x060060A8 RID: 24744 RVA: 0x00361CD4 File Offset: 0x00360CD4
		internal override x5 ny()
		{
			return this.l;
		}

		// Token: 0x060060A9 RID: 24745 RVA: 0x00361CEC File Offset: 0x00360CEC
		internal override x5 nz()
		{
			return x5.f(this.l, this.i);
		}

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x060060AA RID: 24746 RVA: 0x00361D10 File Offset: 0x00360D10
		// (set) Token: 0x060060AB RID: 24747 RVA: 0x00361D28 File Offset: 0x00360D28
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

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x060060AC RID: 24748 RVA: 0x00361D34 File Offset: 0x00360D34
		// (set) Token: 0x060060AD RID: 24749 RVA: 0x00361D4C File Offset: 0x00360D4C
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

		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x060060AE RID: 24750 RVA: 0x00361D58 File Offset: 0x00360D58
		// (set) Token: 0x060060AF RID: 24751 RVA: 0x00361D70 File Offset: 0x00360D70
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

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x060060B0 RID: 24752 RVA: 0x00361D7C File Offset: 0x00360D7C
		// (set) Token: 0x060060B1 RID: 24753 RVA: 0x00361D94 File Offset: 0x00360D94
		public string Text
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

		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x060060B2 RID: 24754 RVA: 0x00361DA0 File Offset: 0x00360DA0
		// (set) Token: 0x060060B3 RID: 24755 RVA: 0x00361DB8 File Offset: 0x00360DB8
		public Color TextColor
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

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x060060B4 RID: 24756 RVA: 0x00361DC4 File Offset: 0x00360DC4
		// (set) Token: 0x060060B5 RID: 24757 RVA: 0x00361DDC File Offset: 0x00360DDC
		public bool Underline
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

		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x060060B6 RID: 24758 RVA: 0x00361DE8 File Offset: 0x00360DE8
		// (set) Token: 0x060060B7 RID: 24759 RVA: 0x00361E00 File Offset: 0x00360E00
		public VAlign VAlign
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

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x060060B8 RID: 24760 RVA: 0x00361E0C File Offset: 0x00360E0C
		// (set) Token: 0x060060B9 RID: 24761 RVA: 0x00361E24 File Offset: 0x00360E24
		public float Angle
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

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x060060BA RID: 24762 RVA: 0x00361E30 File Offset: 0x00360E30
		// (set) Token: 0x060060BB RID: 24763 RVA: 0x00361E4E File Offset: 0x00360E4E
		public float Height
		{
			get
			{
				return x5.b(this.i);
			}
			set
			{
				this.i = x5.a(value);
			}
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x060060BC RID: 24764 RVA: 0x00361E60 File Offset: 0x00360E60
		// (set) Token: 0x060060BD RID: 24765 RVA: 0x00361E7E File Offset: 0x00360E7E
		public float Width
		{
			get
			{
				return x5.b(this.j);
			}
			set
			{
				this.j = x5.a(value);
			}
		}

		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x060060BE RID: 24766 RVA: 0x00361E90 File Offset: 0x00360E90
		// (set) Token: 0x060060BF RID: 24767 RVA: 0x00361EAE File Offset: 0x00360EAE
		public float X
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

		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x060060C0 RID: 24768 RVA: 0x00361EC0 File Offset: 0x00360EC0
		// (set) Token: 0x060060C1 RID: 24769 RVA: 0x00361EDE File Offset: 0x00360EDE
		public float Y
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

		// Token: 0x040031F4 RID: 12788
		private TextAlign a;

		// Token: 0x040031F5 RID: 12789
		private Font b;

		// Token: 0x040031F6 RID: 12790
		private float c;

		// Token: 0x040031F7 RID: 12791
		private string d;

		// Token: 0x040031F8 RID: 12792
		private Color e;

		// Token: 0x040031F9 RID: 12793
		private bool f;

		// Token: 0x040031FA RID: 12794
		private VAlign g;

		// Token: 0x040031FB RID: 12795
		private float h;

		// Token: 0x040031FC RID: 12796
		private x5 i;

		// Token: 0x040031FD RID: 12797
		private x5 j;

		// Token: 0x040031FE RID: 12798
		private x5 k;

		// Token: 0x040031FF RID: 12799
		private x5 l;

		// Token: 0x04003200 RID: 12800
		private short m = short.MinValue;

		// Token: 0x04003201 RID: 12801
		private LayingOutEventHandler n;

		// Token: 0x04003202 RID: 12802
		private LabelLaidOutEventHandler o;
	}
}
