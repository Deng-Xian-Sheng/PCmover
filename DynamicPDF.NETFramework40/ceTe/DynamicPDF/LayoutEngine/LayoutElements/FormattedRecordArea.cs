using System;
using System.Threading;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000949 RID: 2377
	public class FormattedRecordArea : LayoutElement
	{
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06006066 RID: 24678 RVA: 0x00360C3C File Offset: 0x0035FC3C
		// (remove) Token: 0x06006067 RID: 24679 RVA: 0x00360C78 File Offset: 0x0035FC78
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

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06006068 RID: 24680 RVA: 0x00360CB4 File Offset: 0x0035FCB4
		// (remove) Token: 0x06006069 RID: 24681 RVA: 0x00360CF0 File Offset: 0x0035FCF0
		public event FormattedRecordAreaLaidOutEventHandler LaidOut
		{
			add
			{
				FormattedRecordAreaLaidOutEventHandler formattedRecordAreaLaidOutEventHandler = this.o;
				FormattedRecordAreaLaidOutEventHandler formattedRecordAreaLaidOutEventHandler2;
				do
				{
					formattedRecordAreaLaidOutEventHandler2 = formattedRecordAreaLaidOutEventHandler;
					FormattedRecordAreaLaidOutEventHandler value2 = (FormattedRecordAreaLaidOutEventHandler)Delegate.Combine(formattedRecordAreaLaidOutEventHandler2, value);
					formattedRecordAreaLaidOutEventHandler = Interlocked.CompareExchange<FormattedRecordAreaLaidOutEventHandler>(ref this.o, value2, formattedRecordAreaLaidOutEventHandler2);
				}
				while (formattedRecordAreaLaidOutEventHandler != formattedRecordAreaLaidOutEventHandler2);
			}
			remove
			{
				FormattedRecordAreaLaidOutEventHandler formattedRecordAreaLaidOutEventHandler = this.o;
				FormattedRecordAreaLaidOutEventHandler formattedRecordAreaLaidOutEventHandler2;
				do
				{
					formattedRecordAreaLaidOutEventHandler2 = formattedRecordAreaLaidOutEventHandler;
					FormattedRecordAreaLaidOutEventHandler value2 = (FormattedRecordAreaLaidOutEventHandler)Delegate.Remove(formattedRecordAreaLaidOutEventHandler2, value);
					formattedRecordAreaLaidOutEventHandler = Interlocked.CompareExchange<FormattedRecordAreaLaidOutEventHandler>(ref this.o, value2, formattedRecordAreaLaidOutEventHandler2);
				}
				while (formattedRecordAreaLaidOutEventHandler != formattedRecordAreaLaidOutEventHandler2);
			}
		}

		// Token: 0x0600606A RID: 24682 RVA: 0x00360D2C File Offset: 0x0035FD2C
		internal FormattedRecordArea(alo A_0, ak2 A_1)
		{
			this.a = A_1.a();
			this.b = A_1.b();
			this.e = A_1.e();
			this.f = A_1.f();
			this.d = A_1.g();
			this.c = A_1.h();
			this.g = A_1.c();
			this.h = A_1.d();
			this.i = A_1.j();
			this.m = A_1.i();
			this.k = A_1.k();
			if (this.b.d())
			{
				A_0.b().m1().a(this.b.e());
			}
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			this.l = A_0;
			if (A_0.c())
			{
				if (A_0 is SubReport && this.b.d())
				{
					this.b.e().a((SubReport)A_0);
				}
			}
			else
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x0600606B RID: 24683 RVA: 0x00360E9C File Offset: 0x0035FE9C
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.b != null)
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
				amr amr;
				if (this.b.d())
				{
					amr = new amr(this, new char[0]);
					A_0.a(amr);
					akk akk = new akk();
					for (int i = 0; i < this.b.c().a(); i++)
					{
						if (this.b.c().a(i).nd())
						{
							((al6)this.b.c().a(i)).a().mc(A_1, akk, amr);
						}
					}
					alq alq = new alq(this.b.c().a());
					this.b.a(A_1, alq);
					if (this.b.e().c())
					{
						if (this.b.e().d() == null)
						{
							((Report)this.l).h().f().a(new ais(amr, akk, this.b, alq));
						}
						else
						{
							((SubReport)this.l).h().f().a(new ais(amr, akk, this.b, alq));
						}
					}
					else if (this.l is FixedPage)
					{
						((FixedPage)this.l).g().a(new ais(amr, akk, this.b, alq));
					}
					else
					{
						((al2)A_1).m5().a(new ais(amr, akk, this.b, alq));
					}
					akk.a();
				}
				else
				{
					amr = new amr(this, this.b.b(A_1));
					A_0.a(amr);
				}
				if (this.o != null)
				{
					FormattedRecordAreaLaidOutEventArgs formattedRecordAreaLaidOutEventArgs = new FormattedRecordAreaLaidOutEventArgs(A_1, amr);
					this.o(this, formattedRecordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600606C RID: 24684 RVA: 0x00361100 File Offset: 0x00360100
		internal override void nu(aml A_0, LayoutWriter A_1)
		{
			if (this.b != null)
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
				amr amr;
				if (this.b.d())
				{
					amr = new amr(this, new char[0]);
					A_0.a(amr);
					if (this.h)
					{
						A_0.a().a(amr);
					}
					akk akk = new akk();
					for (int i = 0; i < this.b.c().a(); i++)
					{
						if (this.b.c().a(i).nd())
						{
							((al6)this.b.c().a(i)).a().mc(A_1, akk, amr);
						}
					}
					alq alq = new alq(this.b.c().a());
					this.b.a(A_1, alq);
					if (this.b.e().c())
					{
						if (this.b.e().d() == null)
						{
							((Report)this.l).h().f().a(new ais(amr, akk, this.b, alq));
						}
						else
						{
							((SubReport)this.l).h().f().a(new ais(amr, akk, this.b, alq));
						}
					}
					else if (this.l is FixedPage)
					{
						((FixedPage)this.l).g().a(new ais(amr, akk, this.b, alq));
					}
					else
					{
						((al2)A_1).m5().a(new ais(amr, akk, this.b, alq));
					}
					akk.a();
				}
				else
				{
					amr = new amr(this, this.b.b(A_1));
					A_0.a(amr);
					if (this.h)
					{
						A_0.a().a(amr);
					}
				}
				if (this.o != null)
				{
					FormattedRecordAreaLaidOutEventArgs formattedRecordAreaLaidOutEventArgs = new FormattedRecordAreaLaidOutEventArgs(A_1, amr);
					this.o(this, formattedRecordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600606D RID: 24685 RVA: 0x0036139C File Offset: 0x0036039C
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x0600606E RID: 24686 RVA: 0x003613B0 File Offset: 0x003603B0
		internal override short nw()
		{
			return this.j;
		}

		// Token: 0x0600606F RID: 24687 RVA: 0x003613C8 File Offset: 0x003603C8
		internal override void nx(short A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06006070 RID: 24688 RVA: 0x003613D4 File Offset: 0x003603D4
		internal override x5 ny()
		{
			return this.f;
		}

		// Token: 0x06006071 RID: 24689 RVA: 0x003613EC File Offset: 0x003603EC
		internal override x5 nz()
		{
			return x5.f(this.f, this.c);
		}

		// Token: 0x06006072 RID: 24690 RVA: 0x00361410 File Offset: 0x00360410
		internal FontFamilyList a()
		{
			return this.k;
		}

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06006073 RID: 24691 RVA: 0x00361428 File Offset: 0x00360428
		// (set) Token: 0x06006074 RID: 24692 RVA: 0x00361445 File Offset: 0x00360445
		public string Text
		{
			get
			{
				return this.b.ToString();
			}
			set
			{
				this.b = new air(value);
			}
		}

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06006075 RID: 24693 RVA: 0x00361454 File Offset: 0x00360454
		// (set) Token: 0x06006076 RID: 24694 RVA: 0x0036146C File Offset: 0x0036046C
		public bool Splittable
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

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06006077 RID: 24695 RVA: 0x00361478 File Offset: 0x00360478
		// (set) Token: 0x06006078 RID: 24696 RVA: 0x00361490 File Offset: 0x00360490
		public bool Expandable
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

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06006079 RID: 24697 RVA: 0x0036149C File Offset: 0x0036049C
		// (set) Token: 0x0600607A RID: 24698 RVA: 0x003614BA File Offset: 0x003604BA
		public float X
		{
			get
			{
				return x5.b(this.e);
			}
			set
			{
				this.e = x5.a(value);
			}
		}

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x0600607B RID: 24699 RVA: 0x003614CC File Offset: 0x003604CC
		// (set) Token: 0x0600607C RID: 24700 RVA: 0x003614EA File Offset: 0x003604EA
		public float Y
		{
			get
			{
				return x5.b(this.f);
			}
			set
			{
				this.f = x5.a(value);
			}
		}

		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x0600607D RID: 24701 RVA: 0x003614FC File Offset: 0x003604FC
		// (set) Token: 0x0600607E RID: 24702 RVA: 0x0036151A File Offset: 0x0036051A
		public float Width
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x0600607F RID: 24703 RVA: 0x0036152C File Offset: 0x0036052C
		// (set) Token: 0x06006080 RID: 24704 RVA: 0x0036154A File Offset: 0x0036054A
		public float Height
		{
			get
			{
				return x5.b(this.c);
			}
			set
			{
				this.c = x5.a(value);
			}
		}

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x06006081 RID: 24705 RVA: 0x0036155C File Offset: 0x0036055C
		// (set) Token: 0x06006082 RID: 24706 RVA: 0x00361574 File Offset: 0x00360574
		public FormattedTextAreaStyle InitialStyle
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

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x06006083 RID: 24707 RVA: 0x00361580 File Offset: 0x00360580
		// (set) Token: 0x06006084 RID: 24708 RVA: 0x00361598 File Offset: 0x00360598
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

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x06006085 RID: 24709 RVA: 0x003615A4 File Offset: 0x003605A4
		// (set) Token: 0x06006086 RID: 24710 RVA: 0x003615BC File Offset: 0x003605BC
		public float Angle
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

		// Token: 0x040031DB RID: 12763
		private float a;

		// Token: 0x040031DC RID: 12764
		private air b;

		// Token: 0x040031DD RID: 12765
		private x5 c;

		// Token: 0x040031DE RID: 12766
		private x5 d;

		// Token: 0x040031DF RID: 12767
		private x5 e;

		// Token: 0x040031E0 RID: 12768
		private x5 f;

		// Token: 0x040031E1 RID: 12769
		private bool g;

		// Token: 0x040031E2 RID: 12770
		private bool h = true;

		// Token: 0x040031E3 RID: 12771
		private VAlign i = VAlign.Top;

		// Token: 0x040031E4 RID: 12772
		private short j = short.MinValue;

		// Token: 0x040031E5 RID: 12773
		private FontFamilyList k;

		// Token: 0x040031E6 RID: 12774
		private alo l;

		// Token: 0x040031E7 RID: 12775
		private FormattedTextAreaStyle m = new FormattedTextAreaStyle(FontFamily.Helvetica, 12f, true);

		// Token: 0x040031E8 RID: 12776
		private LayingOutEventHandler n;

		// Token: 0x040031E9 RID: 12777
		private FormattedRecordAreaLaidOutEventHandler o;
	}
}
