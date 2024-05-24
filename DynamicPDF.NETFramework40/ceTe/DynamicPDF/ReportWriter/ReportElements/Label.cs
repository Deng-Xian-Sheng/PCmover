using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000838 RID: 2104
	public class Label : ReportElement
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060054DB RID: 21723 RVA: 0x002966DC File Offset: 0x002956DC
		// (remove) Token: 0x060054DC RID: 21724 RVA: 0x00296718 File Offset: 0x00295718
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

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060054DD RID: 21725 RVA: 0x00296754 File Offset: 0x00295754
		// (remove) Token: 0x060054DE RID: 21726 RVA: 0x00296790 File Offset: 0x00295790
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

		// Token: 0x060054DF RID: 21727 RVA: 0x002967CC File Offset: 0x002957CC
		internal Label(rm A_0, v4 A_1)
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
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x060054E0 RID: 21728 RVA: 0x002968B0 File Offset: 0x002958B0
		internal override void fi(xf A_0, LayoutWriter A_1)
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
			xl xl = new xl(this.d, x5.b(this.k), x5.b(this.l), x5.b(this.j), x5.b(this.i), this.b, this.c, this.a, this.e);
			xl.Angle = this.h;
			xl.Underline = this.f;
			xl.VAlign = this.g;
			xl.a(this.m);
			A_0.a(xl);
			if (this.o != null)
			{
				LabelLaidOutEventArgs labelLaidOutEventArgs = new LabelLaidOutEventArgs(A_1, xl);
				this.o(this, labelLaidOutEventArgs);
			}
		}

		// Token: 0x060054E1 RID: 21729 RVA: 0x002969A8 File Offset: 0x002959A8
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x060054E2 RID: 21730 RVA: 0x002969BC File Offset: 0x002959BC
		internal override short gk()
		{
			return this.m;
		}

		// Token: 0x060054E3 RID: 21731 RVA: 0x002969D4 File Offset: 0x002959D4
		internal override void gl(short A_0)
		{
			this.m = A_0;
		}

		// Token: 0x060054E4 RID: 21732 RVA: 0x002969E0 File Offset: 0x002959E0
		internal override x5 gm()
		{
			return this.l;
		}

		// Token: 0x060054E5 RID: 21733 RVA: 0x002969F8 File Offset: 0x002959F8
		internal override x5 gn()
		{
			return x5.f(this.l, this.i);
		}

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x060054E6 RID: 21734 RVA: 0x00296A1C File Offset: 0x00295A1C
		// (set) Token: 0x060054E7 RID: 21735 RVA: 0x00296A34 File Offset: 0x00295A34
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

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x060054E8 RID: 21736 RVA: 0x00296A40 File Offset: 0x00295A40
		// (set) Token: 0x060054E9 RID: 21737 RVA: 0x00296A58 File Offset: 0x00295A58
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

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x060054EA RID: 21738 RVA: 0x00296A64 File Offset: 0x00295A64
		// (set) Token: 0x060054EB RID: 21739 RVA: 0x00296A7C File Offset: 0x00295A7C
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

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x060054EC RID: 21740 RVA: 0x00296A88 File Offset: 0x00295A88
		// (set) Token: 0x060054ED RID: 21741 RVA: 0x00296AA0 File Offset: 0x00295AA0
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

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x060054EE RID: 21742 RVA: 0x00296AAC File Offset: 0x00295AAC
		// (set) Token: 0x060054EF RID: 21743 RVA: 0x00296AC4 File Offset: 0x00295AC4
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

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x060054F0 RID: 21744 RVA: 0x00296AD0 File Offset: 0x00295AD0
		// (set) Token: 0x060054F1 RID: 21745 RVA: 0x00296AE8 File Offset: 0x00295AE8
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

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x060054F2 RID: 21746 RVA: 0x00296AF4 File Offset: 0x00295AF4
		// (set) Token: 0x060054F3 RID: 21747 RVA: 0x00296B0C File Offset: 0x00295B0C
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

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x060054F4 RID: 21748 RVA: 0x00296B18 File Offset: 0x00295B18
		// (set) Token: 0x060054F5 RID: 21749 RVA: 0x00296B30 File Offset: 0x00295B30
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

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x060054F6 RID: 21750 RVA: 0x00296B3C File Offset: 0x00295B3C
		// (set) Token: 0x060054F7 RID: 21751 RVA: 0x00296B5A File Offset: 0x00295B5A
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

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x060054F8 RID: 21752 RVA: 0x00296B6C File Offset: 0x00295B6C
		// (set) Token: 0x060054F9 RID: 21753 RVA: 0x00296B8A File Offset: 0x00295B8A
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

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x060054FA RID: 21754 RVA: 0x00296B9C File Offset: 0x00295B9C
		// (set) Token: 0x060054FB RID: 21755 RVA: 0x00296BBA File Offset: 0x00295BBA
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

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x060054FC RID: 21756 RVA: 0x00296BCC File Offset: 0x00295BCC
		// (set) Token: 0x060054FD RID: 21757 RVA: 0x00296BEA File Offset: 0x00295BEA
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

		// Token: 0x04002D67 RID: 11623
		private TextAlign a;

		// Token: 0x04002D68 RID: 11624
		private Font b;

		// Token: 0x04002D69 RID: 11625
		private float c;

		// Token: 0x04002D6A RID: 11626
		private string d;

		// Token: 0x04002D6B RID: 11627
		private Color e;

		// Token: 0x04002D6C RID: 11628
		private bool f;

		// Token: 0x04002D6D RID: 11629
		private VAlign g;

		// Token: 0x04002D6E RID: 11630
		private float h;

		// Token: 0x04002D6F RID: 11631
		private x5 i;

		// Token: 0x04002D70 RID: 11632
		private x5 j;

		// Token: 0x04002D71 RID: 11633
		private x5 k;

		// Token: 0x04002D72 RID: 11634
		private x5 l;

		// Token: 0x04002D73 RID: 11635
		private short m = short.MinValue;

		// Token: 0x04002D74 RID: 11636
		private LayingOutEventHandler n;

		// Token: 0x04002D75 RID: 11637
		private LabelLaidOutEventHandler o;
	}
}
