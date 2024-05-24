using System;
using System.Threading;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000832 RID: 2098
	public class FormattedRecordArea : ReportElement
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06005494 RID: 21652 RVA: 0x002958B8 File Offset: 0x002948B8
		// (remove) Token: 0x06005495 RID: 21653 RVA: 0x002958F4 File Offset: 0x002948F4
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

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06005496 RID: 21654 RVA: 0x00295930 File Offset: 0x00294930
		// (remove) Token: 0x06005497 RID: 21655 RVA: 0x0029596C File Offset: 0x0029496C
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

		// Token: 0x06005498 RID: 21656 RVA: 0x002959A8 File Offset: 0x002949A8
		internal FormattedRecordArea(rm A_0, vz A_1)
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
				A_0.b().ex().a(this.b.e());
			}
			A_0.b().DocumentLayout.a(A_1.f0(), this);
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
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005499 RID: 21657 RVA: 0x00295B18 File Offset: 0x00294B18
		internal override void fi(xf A_0, LayoutWriter A_1)
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
				rw rw;
				if (this.b.d())
				{
					rw = new rw(this, new char[0]);
					A_0.a(rw);
					vi vi = new vi();
					for (int i = 0; i < this.b.c().a(); i++)
					{
						if (this.b.c().a(i).e8())
						{
							((rq)this.b.c().a(i)).a().eu(A_1, vi, rw);
						}
					}
					wt wt = new wt(this.b.c().a());
					this.b.a(A_1, wt);
					if (this.b.e().c())
					{
						if (this.b.e().d() == null)
						{
							((Report)this.l).f().f().a(new tv(rw, vi, this.b, wt));
						}
						else
						{
							((SubReport)this.l).f().f().a(new tv(rw, vi, this.b, wt));
						}
					}
					else if (this.l is FixedPage)
					{
						((FixedPage)this.l).h().a(new tv(rw, vi, this.b, wt));
					}
					else
					{
						((w1)A_1).e2().a(new tv(rw, vi, this.b, wt));
					}
					vi.a();
				}
				else
				{
					rw = new rw(this, this.b.b(A_1));
					A_0.a(rw);
				}
				if (this.o != null)
				{
					FormattedRecordAreaLaidOutEventArgs formattedRecordAreaLaidOutEventArgs = new FormattedRecordAreaLaidOutEventArgs(A_1, rw);
					this.o(this, formattedRecordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600549A RID: 21658 RVA: 0x00295D7C File Offset: 0x00294D7C
		internal override void gi(xh A_0, LayoutWriter A_1)
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
				rw rw;
				if (this.b.d())
				{
					rw = new rw(this, new char[0]);
					A_0.a(rw);
					if (this.h)
					{
						A_0.a().a(rw);
					}
					vi vi = new vi();
					for (int i = 0; i < this.b.c().a(); i++)
					{
						if (this.b.c().a(i).e8())
						{
							((rq)this.b.c().a(i)).a().eu(A_1, vi, rw);
						}
					}
					wt wt = new wt(this.b.c().a());
					this.b.a(A_1, wt);
					if (this.b.e().c())
					{
						if (this.b.e().d() == null)
						{
							((Report)this.l).f().f().a(new tv(rw, vi, this.b, wt));
						}
						else
						{
							((SubReport)this.l).f().f().a(new tv(rw, vi, this.b, wt));
						}
					}
					else if (this.l is FixedPage)
					{
						((FixedPage)this.l).h().a(new tv(rw, vi, this.b, wt));
					}
					else
					{
						((w1)A_1).e2().a(new tv(rw, vi, this.b, wt));
					}
					vi.a();
				}
				else
				{
					rw = new rw(this, this.b.b(A_1));
					A_0.a(rw);
					if (this.h)
					{
						A_0.a().a(rw);
					}
				}
				if (this.o != null)
				{
					FormattedRecordAreaLaidOutEventArgs formattedRecordAreaLaidOutEventArgs = new FormattedRecordAreaLaidOutEventArgs(A_1, rw);
					this.o(this, formattedRecordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600549B RID: 21659 RVA: 0x00296018 File Offset: 0x00295018
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x0600549C RID: 21660 RVA: 0x0029602C File Offset: 0x0029502C
		internal override short gk()
		{
			return this.j;
		}

		// Token: 0x0600549D RID: 21661 RVA: 0x00296044 File Offset: 0x00295044
		internal override void gl(short A_0)
		{
			this.j = A_0;
		}

		// Token: 0x0600549E RID: 21662 RVA: 0x00296050 File Offset: 0x00295050
		internal override x5 gm()
		{
			return this.f;
		}

		// Token: 0x0600549F RID: 21663 RVA: 0x00296068 File Offset: 0x00295068
		internal override x5 gn()
		{
			return x5.f(this.f, this.c);
		}

		// Token: 0x060054A0 RID: 21664 RVA: 0x0029608C File Offset: 0x0029508C
		internal FontFamilyList a()
		{
			return this.k;
		}

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x060054A1 RID: 21665 RVA: 0x002960A4 File Offset: 0x002950A4
		// (set) Token: 0x060054A2 RID: 21666 RVA: 0x002960C1 File Offset: 0x002950C1
		public string Text
		{
			get
			{
				return this.b.ToString();
			}
			set
			{
				this.b = new tu(value);
			}
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x060054A3 RID: 21667 RVA: 0x002960D0 File Offset: 0x002950D0
		// (set) Token: 0x060054A4 RID: 21668 RVA: 0x002960E8 File Offset: 0x002950E8
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

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x060054A5 RID: 21669 RVA: 0x002960F4 File Offset: 0x002950F4
		// (set) Token: 0x060054A6 RID: 21670 RVA: 0x0029610C File Offset: 0x0029510C
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

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x060054A7 RID: 21671 RVA: 0x00296118 File Offset: 0x00295118
		// (set) Token: 0x060054A8 RID: 21672 RVA: 0x00296136 File Offset: 0x00295136
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

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x060054A9 RID: 21673 RVA: 0x00296148 File Offset: 0x00295148
		// (set) Token: 0x060054AA RID: 21674 RVA: 0x00296166 File Offset: 0x00295166
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

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x060054AB RID: 21675 RVA: 0x00296178 File Offset: 0x00295178
		// (set) Token: 0x060054AC RID: 21676 RVA: 0x00296196 File Offset: 0x00295196
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

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x060054AD RID: 21677 RVA: 0x002961A8 File Offset: 0x002951A8
		// (set) Token: 0x060054AE RID: 21678 RVA: 0x002961C6 File Offset: 0x002951C6
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

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x060054AF RID: 21679 RVA: 0x002961D8 File Offset: 0x002951D8
		// (set) Token: 0x060054B0 RID: 21680 RVA: 0x002961F0 File Offset: 0x002951F0
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

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x060054B1 RID: 21681 RVA: 0x002961FC File Offset: 0x002951FC
		// (set) Token: 0x060054B2 RID: 21682 RVA: 0x00296214 File Offset: 0x00295214
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

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x060054B3 RID: 21683 RVA: 0x00296220 File Offset: 0x00295220
		// (set) Token: 0x060054B4 RID: 21684 RVA: 0x00296238 File Offset: 0x00295238
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

		// Token: 0x04002D4A RID: 11594
		private float a;

		// Token: 0x04002D4B RID: 11595
		private tu b;

		// Token: 0x04002D4C RID: 11596
		private x5 c;

		// Token: 0x04002D4D RID: 11597
		private x5 d;

		// Token: 0x04002D4E RID: 11598
		private x5 e;

		// Token: 0x04002D4F RID: 11599
		private x5 f;

		// Token: 0x04002D50 RID: 11600
		private bool g;

		// Token: 0x04002D51 RID: 11601
		private bool h = true;

		// Token: 0x04002D52 RID: 11602
		private VAlign i = VAlign.Top;

		// Token: 0x04002D53 RID: 11603
		private short j = short.MinValue;

		// Token: 0x04002D54 RID: 11604
		private FontFamilyList k;

		// Token: 0x04002D55 RID: 11605
		private rm l;

		// Token: 0x04002D56 RID: 11606
		private FormattedTextAreaStyle m = new FormattedTextAreaStyle(FontFamily.Helvetica, 12f, true);

		// Token: 0x04002D57 RID: 11607
		private LayingOutEventHandler n;

		// Token: 0x04002D58 RID: 11608
		private FormattedRecordAreaLaidOutEventHandler o;
	}
}
