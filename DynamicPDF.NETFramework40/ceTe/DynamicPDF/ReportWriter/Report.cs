using System;
using System.Collections;
using System.Threading;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000829 RID: 2089
	public class Report : DocumentLayoutPart, rm, xc
	{
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600542F RID: 21551 RVA: 0x00293E78 File Offset: 0x00292E78
		// (remove) Token: 0x06005430 RID: 21552 RVA: 0x00293EB4 File Offset: 0x00292EB4
		public event ReportPageLayingOutEventHandler ReportPageLayingOut
		{
			add
			{
				ReportPageLayingOutEventHandler reportPageLayingOutEventHandler = this.s;
				ReportPageLayingOutEventHandler reportPageLayingOutEventHandler2;
				do
				{
					reportPageLayingOutEventHandler2 = reportPageLayingOutEventHandler;
					ReportPageLayingOutEventHandler value2 = (ReportPageLayingOutEventHandler)Delegate.Combine(reportPageLayingOutEventHandler2, value);
					reportPageLayingOutEventHandler = Interlocked.CompareExchange<ReportPageLayingOutEventHandler>(ref this.s, value2, reportPageLayingOutEventHandler2);
				}
				while (reportPageLayingOutEventHandler != reportPageLayingOutEventHandler2);
			}
			remove
			{
				ReportPageLayingOutEventHandler reportPageLayingOutEventHandler = this.s;
				ReportPageLayingOutEventHandler reportPageLayingOutEventHandler2;
				do
				{
					reportPageLayingOutEventHandler2 = reportPageLayingOutEventHandler;
					ReportPageLayingOutEventHandler value2 = (ReportPageLayingOutEventHandler)Delegate.Remove(reportPageLayingOutEventHandler2, value);
					reportPageLayingOutEventHandler = Interlocked.CompareExchange<ReportPageLayingOutEventHandler>(ref this.s, value2, reportPageLayingOutEventHandler2);
				}
				while (reportPageLayingOutEventHandler != reportPageLayingOutEventHandler2);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06005431 RID: 21553 RVA: 0x00293EF0 File Offset: 0x00292EF0
		// (remove) Token: 0x06005432 RID: 21554 RVA: 0x00293F2C File Offset: 0x00292F2C
		public event ReportPageLaidOutEventHandler ReportPageLaidOut
		{
			add
			{
				ReportPageLaidOutEventHandler reportPageLaidOutEventHandler = this.t;
				ReportPageLaidOutEventHandler reportPageLaidOutEventHandler2;
				do
				{
					reportPageLaidOutEventHandler2 = reportPageLaidOutEventHandler;
					ReportPageLaidOutEventHandler value2 = (ReportPageLaidOutEventHandler)Delegate.Combine(reportPageLaidOutEventHandler2, value);
					reportPageLaidOutEventHandler = Interlocked.CompareExchange<ReportPageLaidOutEventHandler>(ref this.t, value2, reportPageLaidOutEventHandler2);
				}
				while (reportPageLaidOutEventHandler != reportPageLaidOutEventHandler2);
			}
			remove
			{
				ReportPageLaidOutEventHandler reportPageLaidOutEventHandler = this.t;
				ReportPageLaidOutEventHandler reportPageLaidOutEventHandler2;
				do
				{
					reportPageLaidOutEventHandler2 = reportPageLaidOutEventHandler;
					ReportPageLaidOutEventHandler value2 = (ReportPageLaidOutEventHandler)Delegate.Remove(reportPageLaidOutEventHandler2, value);
					reportPageLaidOutEventHandler = Interlocked.CompareExchange<ReportPageLaidOutEventHandler>(ref this.t, value2, reportPageLaidOutEventHandler2);
				}
				while (reportPageLaidOutEventHandler != reportPageLaidOutEventHandler2);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06005433 RID: 21555 RVA: 0x00293F68 File Offset: 0x00292F68
		// (remove) Token: 0x06005434 RID: 21556 RVA: 0x00293FA4 File Offset: 0x00292FA4
		public event ReportLayingOutEventHandler ReportLayingOut
		{
			add
			{
				ReportLayingOutEventHandler reportLayingOutEventHandler = this.u;
				ReportLayingOutEventHandler reportLayingOutEventHandler2;
				do
				{
					reportLayingOutEventHandler2 = reportLayingOutEventHandler;
					ReportLayingOutEventHandler value2 = (ReportLayingOutEventHandler)Delegate.Combine(reportLayingOutEventHandler2, value);
					reportLayingOutEventHandler = Interlocked.CompareExchange<ReportLayingOutEventHandler>(ref this.u, value2, reportLayingOutEventHandler2);
				}
				while (reportLayingOutEventHandler != reportLayingOutEventHandler2);
			}
			remove
			{
				ReportLayingOutEventHandler reportLayingOutEventHandler = this.u;
				ReportLayingOutEventHandler reportLayingOutEventHandler2;
				do
				{
					reportLayingOutEventHandler2 = reportLayingOutEventHandler;
					ReportLayingOutEventHandler value2 = (ReportLayingOutEventHandler)Delegate.Remove(reportLayingOutEventHandler2, value);
					reportLayingOutEventHandler = Interlocked.CompareExchange<ReportLayingOutEventHandler>(ref this.u, value2, reportLayingOutEventHandler2);
				}
				while (reportLayingOutEventHandler != reportLayingOutEventHandler2);
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06005435 RID: 21557 RVA: 0x00293FE0 File Offset: 0x00292FE0
		// (remove) Token: 0x06005436 RID: 21558 RVA: 0x0029401C File Offset: 0x0029301C
		public event ReportLaidOutEventHandler ReportLaidOut
		{
			add
			{
				ReportLaidOutEventHandler reportLaidOutEventHandler = this.v;
				ReportLaidOutEventHandler reportLaidOutEventHandler2;
				do
				{
					reportLaidOutEventHandler2 = reportLaidOutEventHandler;
					ReportLaidOutEventHandler value2 = (ReportLaidOutEventHandler)Delegate.Combine(reportLaidOutEventHandler2, value);
					reportLaidOutEventHandler = Interlocked.CompareExchange<ReportLaidOutEventHandler>(ref this.v, value2, reportLaidOutEventHandler2);
				}
				while (reportLaidOutEventHandler != reportLaidOutEventHandler2);
			}
			remove
			{
				ReportLaidOutEventHandler reportLaidOutEventHandler = this.v;
				ReportLaidOutEventHandler reportLaidOutEventHandler2;
				do
				{
					reportLaidOutEventHandler2 = reportLaidOutEventHandler;
					ReportLaidOutEventHandler value2 = (ReportLaidOutEventHandler)Delegate.Remove(reportLaidOutEventHandler2, value);
					reportLaidOutEventHandler = Interlocked.CompareExchange<ReportLaidOutEventHandler>(ref this.v, value2, reportLaidOutEventHandler2);
				}
				while (reportLaidOutEventHandler != reportLaidOutEventHandler2);
			}
		}

		// Token: 0x06005437 RID: 21559 RVA: 0x00294058 File Offset: 0x00293058
		internal Report(DocumentLayout A_0) : base(A_0)
		{
		}

		// Token: 0x06005438 RID: 21560 RVA: 0x002940C8 File Offset: 0x002930C8
		internal override void ew(wu A_0)
		{
			if (this.u != null)
			{
				ReportLayingOutEventArgs reportLayingOutEventArgs = new ReportLayingOutEventArgs(A_0, this);
				this.u(this, reportLayingOutEventArgs);
				if (!reportLayingOutEventArgs.Layout)
				{
					return;
				}
			}
			A_0.a(A_0.Document.Pages.Count);
			w1 w = new w1(this, A_0);
			w.e0();
			if (this.v != null)
			{
				ReportLaidOutEventArgs reportLaidOutEventArgs = new ReportLaidOutEventArgs(A_0, A_0.b() + 1, A_0.Document.Pages.Count - A_0.b());
				this.v(this, reportLaidOutEventArgs);
			}
		}

		// Token: 0x06005439 RID: 21561 RVA: 0x00294170 File Offset: 0x00293170
		internal void a(wi A_0)
		{
			this.j = A_0.a();
			this.d = A_0.b();
			this.e = A_0.c();
			this.f = A_0.d().f1();
			base.DocumentLayout.a(this.f);
			base.DocumentLayout.a(this.j, this);
			this.k = A_0.g();
			this.l = A_0.h();
			this.m = A_0.i();
			this.n = A_0.j();
			this.a = new ReportHeader(this, A_0.e());
			this.p = false;
			this.c = new DetailReportPart(A_0.f(), this);
			this.p = true;
			this.b = new ReportFooter(this, A_0.k());
			if (A_0.l() != null)
			{
				this.i = new x3(this, A_0.l());
			}
		}

		// Token: 0x0600543A RID: 21562 RVA: 0x0029426C File Offset: 0x0029326C
		internal override void ev()
		{
			vj.a a = this.g.b();
			while (a != null)
			{
				sz.a a2 = a.a.a();
				if (a.a.c())
				{
					while (a2 != null)
					{
						if (this.o == null)
						{
							this.o = new xw();
						}
						if (string.Compare(a2.a.b(), "CurrentPage", true) == 0 || string.Compare(a2.a.b(), "PreviousPage", true) == 0)
						{
							SubReport subReport = a.a.d();
							if (subReport == null)
							{
								this.o.d().a(a2.a);
							}
							else
							{
								xw xw = subReport.f();
								xw.d().a(a2.a);
							}
							Query queryById = base.DocumentLayout.GetQueryById(a2.a.a());
							queryById.e().a(a2.a);
						}
						else
						{
							if (a2.a.a() == this.f.Id)
							{
								this.f.e().a(a2.a);
							}
							else
							{
								Query queryById = base.DocumentLayout.GetQueryById(a2.a.a());
								queryById.e().a(a2.a);
							}
							if (a2.a.b() == this.j)
							{
								this.c().a(a2.a);
							}
							else
							{
								rm rm = base.DocumentLayout.a(a2.a.b());
								rm.a().a(a2.a);
								if (rm is FixedPage)
								{
									throw new ReportWriterException("FixedPage cannot be a scope for an aggregate function inside the report.");
								}
							}
						}
						a2 = a2.b;
					}
					a = a.b;
				}
				else
				{
					while (a2 != null)
					{
						if (a2.a.a() == this.f.Id)
						{
							this.f.e().a(a2.a);
						}
						else
						{
							Query queryById = base.DocumentLayout.GetQueryById(a2.a.a());
							queryById.e().a(a2.a);
						}
						if (a2.a.b() == this.j)
						{
							this.c().a(a2.a);
						}
						else
						{
							rm rm = base.DocumentLayout.a(a2.a.b());
							rm.a().a(a2.a);
							if (rm is FixedPage)
							{
								throw new ReportWriterException("FixedPage cannot be a scope for an aggregate function inside the report.");
							}
						}
						a2 = a2.b;
					}
					a = a.b;
				}
			}
		}

		// Token: 0x0600543B RID: 21563 RVA: 0x002945D0 File Offset: 0x002935D0
		sz rm.a()
		{
			return this.c();
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x0600543C RID: 21564 RVA: 0x002945E8 File Offset: 0x002935E8
		public string Id
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x0600543D RID: 21565 RVA: 0x00294600 File Offset: 0x00293600
		DocumentLayoutPart rm.b()
		{
			return this;
		}

		// Token: 0x0600543E RID: 21566 RVA: 0x00294614 File Offset: 0x00293614
		internal sz c()
		{
			if (this.h == null)
			{
				this.h = new sz();
			}
			return this.h;
		}

		// Token: 0x0600543F RID: 21567 RVA: 0x0029464C File Offset: 0x0029364C
		internal override vj ex()
		{
			if (this.g == null)
			{
				this.g = new vj();
			}
			return this.g;
		}

		// Token: 0x06005440 RID: 21568 RVA: 0x00294684 File Offset: 0x00293684
		internal PageDimensions d()
		{
			return this.d;
		}

		// Token: 0x06005441 RID: 21569 RVA: 0x0029469C File Offset: 0x0029369C
		internal xq a(xd A_0, w1 A_1)
		{
			if (this.s != null)
			{
				ReportPageLayingOutEventArgs reportPageLayingOutEventArgs = new ReportPageLayingOutEventArgs(A_1);
				this.s(this, reportPageLayingOutEventArgs);
			}
			xq xq;
			if (this.e == null && this.n() == null && (this.n() == null || !this.i.e()))
			{
				xq = new xq(A_0, A_1);
			}
			else
			{
				xq = new xr(A_0, A_1);
			}
			if (A_1.e7() != null)
			{
				xq.b(A_1);
			}
			if (this.t != null)
			{
				ReportPageLaidOutEventArgs reportPageLaidOutEventArgs = new ReportPageLaidOutEventArgs(A_1, xq);
				this.t(this, reportPageLaidOutEventArgs);
				if (reportPageLaidOutEventArgs.Header != null)
				{
					xq.Elements.Add(reportPageLaidOutEventArgs.Header);
				}
				if (reportPageLaidOutEventArgs.Footer != null)
				{
					xq.Elements.Add(reportPageLaidOutEventArgs.Footer);
				}
			}
			return xq;
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06005442 RID: 21570 RVA: 0x002947A4 File Offset: 0x002937A4
		public ReportHeader Header
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06005443 RID: 21571 RVA: 0x002947BC File Offset: 0x002937BC
		public ReportFooter Footer
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06005444 RID: 21572 RVA: 0x002947D4 File Offset: 0x002937D4
		public DetailReportPart Detail
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06005445 RID: 21573 RVA: 0x002947EC File Offset: 0x002937EC
		// (set) Token: 0x06005446 RID: 21574 RVA: 0x00294804 File Offset: 0x00293804
		public Query Query
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

		// Token: 0x06005447 RID: 21575 RVA: 0x00294810 File Offset: 0x00293810
		internal PdfPage e()
		{
			PdfPage result;
			if (this.i != null && this.i.d() != null)
			{
				result = this.i.d();
			}
			else
			{
				result = this.e;
			}
			return result;
		}

		// Token: 0x06005448 RID: 21576 RVA: 0x00294854 File Offset: 0x00293854
		internal void a(PdfPage A_0)
		{
			if ((this.i != null && this.i.d() == null) || this.i == null)
			{
				this.e = A_0;
			}
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06005449 RID: 21577 RVA: 0x00294894 File Offset: 0x00293894
		// (set) Token: 0x0600544A RID: 21578 RVA: 0x002948D8 File Offset: 0x002938D8
		public PdfPage Template
		{
			get
			{
				PdfPage result;
				if (this.i != null && this.i.d() != null)
				{
					result = this.i.d();
				}
				else
				{
					result = this.e;
				}
				return result;
			}
			set
			{
				if ((this.i != null && this.i.d() == null) || this.i == null)
				{
					this.e = value;
				}
			}
		}

		// Token: 0x0600544B RID: 21579 RVA: 0x00294918 File Offset: 0x00293918
		internal override bool ey()
		{
			return this.g != null && this.g.a() >= 1;
		}

		// Token: 0x0600544C RID: 21580 RVA: 0x00294948 File Offset: 0x00293948
		internal xw f()
		{
			return this.o;
		}

		// Token: 0x0600544D RID: 21581 RVA: 0x00294960 File Offset: 0x00293960
		int xc.g()
		{
			return this.k;
		}

		// Token: 0x0600544E RID: 21582 RVA: 0x00294978 File Offset: 0x00293978
		x5 xc.h()
		{
			return this.l;
		}

		// Token: 0x0600544F RID: 21583 RVA: 0x00294990 File Offset: 0x00293990
		x5 xc.i()
		{
			return this.m;
		}

		// Token: 0x06005450 RID: 21584 RVA: 0x002949A8 File Offset: 0x002939A8
		rk xc.j()
		{
			return this.n;
		}

		// Token: 0x06005451 RID: 21585 RVA: 0x002949C0 File Offset: 0x002939C0
		bool xc.k()
		{
			return this.c.AutoSplit;
		}

		// Token: 0x06005452 RID: 21586 RVA: 0x002949E0 File Offset: 0x002939E0
		ReportElementList xc.l()
		{
			return this.c.Elements;
		}

		// Token: 0x06005453 RID: 21587 RVA: 0x00294A00 File Offset: 0x00293A00
		bool rm.m()
		{
			return this.p;
		}

		// Token: 0x06005454 RID: 21588 RVA: 0x00294A18 File Offset: 0x00293A18
		internal x3 n()
		{
			return this.i;
		}

		// Token: 0x06005455 RID: 21589 RVA: 0x00294A30 File Offset: 0x00293A30
		void rm.a(SubReport A_0)
		{
			SubReport.a(A_0, ref this.q);
		}

		// Token: 0x06005456 RID: 21590 RVA: 0x00294A40 File Offset: 0x00293A40
		internal ArrayList o()
		{
			return this.q;
		}

		// Token: 0x06005457 RID: 21591 RVA: 0x00294A58 File Offset: 0x00293A58
		internal ArrayList p()
		{
			return this.r;
		}

		// Token: 0x06005458 RID: 21592 RVA: 0x00294A70 File Offset: 0x00293A70
		internal static void a(rm A_0, string A_1)
		{
			if (A_0 is Report)
			{
				((Report)A_0).p().Add(A_1);
			}
			if (A_0 is SubReport)
			{
				((SubReport)A_0).q().Add(A_1);
			}
		}

		// Token: 0x04002D11 RID: 11537
		private ReportHeader a = null;

		// Token: 0x04002D12 RID: 11538
		private ReportFooter b = null;

		// Token: 0x04002D13 RID: 11539
		private DetailReportPart c = null;

		// Token: 0x04002D14 RID: 11540
		private PageDimensions d = null;

		// Token: 0x04002D15 RID: 11541
		private PdfPage e = null;

		// Token: 0x04002D16 RID: 11542
		private Query f = null;

		// Token: 0x04002D17 RID: 11543
		private vj g = null;

		// Token: 0x04002D18 RID: 11544
		private sz h = null;

		// Token: 0x04002D19 RID: 11545
		private x3 i = null;

		// Token: 0x04002D1A RID: 11546
		private string j;

		// Token: 0x04002D1B RID: 11547
		private int k;

		// Token: 0x04002D1C RID: 11548
		private x5 l;

		// Token: 0x04002D1D RID: 11549
		private x5 m;

		// Token: 0x04002D1E RID: 11550
		private rk n;

		// Token: 0x04002D1F RID: 11551
		private xw o;

		// Token: 0x04002D20 RID: 11552
		private bool p = true;

		// Token: 0x04002D21 RID: 11553
		private ArrayList q = null;

		// Token: 0x04002D22 RID: 11554
		private ArrayList r = new ArrayList(5);

		// Token: 0x04002D23 RID: 11555
		private ReportPageLayingOutEventHandler s;

		// Token: 0x04002D24 RID: 11556
		private ReportPageLaidOutEventHandler t;

		// Token: 0x04002D25 RID: 11557
		private ReportLayingOutEventHandler u;

		// Token: 0x04002D26 RID: 11558
		private ReportLaidOutEventHandler v;
	}
}
