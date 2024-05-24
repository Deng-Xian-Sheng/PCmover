using System;
using System.Threading;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200080E RID: 2062
	public class FixedPage : DocumentLayoutPart, rm
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06005371 RID: 21361 RVA: 0x00291BCC File Offset: 0x00290BCC
		// (remove) Token: 0x06005372 RID: 21362 RVA: 0x00291C08 File Offset: 0x00290C08
		public event PageLayingOutEventHandler PageLayingOut
		{
			add
			{
				PageLayingOutEventHandler pageLayingOutEventHandler = this.j;
				PageLayingOutEventHandler pageLayingOutEventHandler2;
				do
				{
					pageLayingOutEventHandler2 = pageLayingOutEventHandler;
					PageLayingOutEventHandler value2 = (PageLayingOutEventHandler)Delegate.Combine(pageLayingOutEventHandler2, value);
					pageLayingOutEventHandler = Interlocked.CompareExchange<PageLayingOutEventHandler>(ref this.j, value2, pageLayingOutEventHandler2);
				}
				while (pageLayingOutEventHandler != pageLayingOutEventHandler2);
			}
			remove
			{
				PageLayingOutEventHandler pageLayingOutEventHandler = this.j;
				PageLayingOutEventHandler pageLayingOutEventHandler2;
				do
				{
					pageLayingOutEventHandler2 = pageLayingOutEventHandler;
					PageLayingOutEventHandler value2 = (PageLayingOutEventHandler)Delegate.Remove(pageLayingOutEventHandler2, value);
					pageLayingOutEventHandler = Interlocked.CompareExchange<PageLayingOutEventHandler>(ref this.j, value2, pageLayingOutEventHandler2);
				}
				while (pageLayingOutEventHandler != pageLayingOutEventHandler2);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06005373 RID: 21363 RVA: 0x00291C44 File Offset: 0x00290C44
		// (remove) Token: 0x06005374 RID: 21364 RVA: 0x00291C80 File Offset: 0x00290C80
		public event PageLaidOutEventHandler PageLaidOut
		{
			add
			{
				PageLaidOutEventHandler pageLaidOutEventHandler = this.k;
				PageLaidOutEventHandler pageLaidOutEventHandler2;
				do
				{
					pageLaidOutEventHandler2 = pageLaidOutEventHandler;
					PageLaidOutEventHandler value2 = (PageLaidOutEventHandler)Delegate.Combine(pageLaidOutEventHandler2, value);
					pageLaidOutEventHandler = Interlocked.CompareExchange<PageLaidOutEventHandler>(ref this.k, value2, pageLaidOutEventHandler2);
				}
				while (pageLaidOutEventHandler != pageLaidOutEventHandler2);
			}
			remove
			{
				PageLaidOutEventHandler pageLaidOutEventHandler = this.k;
				PageLaidOutEventHandler pageLaidOutEventHandler2;
				do
				{
					pageLaidOutEventHandler2 = pageLaidOutEventHandler;
					PageLaidOutEventHandler value2 = (PageLaidOutEventHandler)Delegate.Remove(pageLaidOutEventHandler2, value);
					pageLaidOutEventHandler = Interlocked.CompareExchange<PageLaidOutEventHandler>(ref this.k, value2, pageLaidOutEventHandler2);
				}
				while (pageLaidOutEventHandler != pageLaidOutEventHandler2);
			}
		}

		// Token: 0x06005375 RID: 21365 RVA: 0x00291CBC File Offset: 0x00290CBC
		internal FixedPage(v7 A_0, DocumentLayout A_1) : base(A_1)
		{
			this.h = A_0.b();
			this.a = A_0.c();
			this.b = A_0.d();
			if (A_0.e() != null)
			{
				this.c = A_0.e().f1();
				base.DocumentLayout.a(this.c);
			}
			if (A_0.a() != null)
			{
				this.i = new ReportElementList(this, A_0.a());
			}
			base.DocumentLayout.a(this.h, this);
		}

		// Token: 0x06005376 RID: 21366 RVA: 0x00291D88 File Offset: 0x00290D88
		internal override void ev()
		{
			for (vj.a a = this.e.b(); a != null; a = a.b)
			{
				for (sz.a a2 = a.a.a(); a2 != null; a2 = a2.b)
				{
					if (this.c != null && a2.a.a() == this.c.Id)
					{
						this.c.e().a(a2.a);
					}
					else
					{
						Query queryById = base.DocumentLayout.GetQueryById(a2.a.a());
						queryById.e().a(a2.a);
					}
					if (a2.a.b() == this.h)
					{
						this.c().a(a2.a);
					}
					else
					{
						rm rm = base.DocumentLayout.a(a2.a.b());
						bool flag = false;
						if (rm is Report)
						{
							flag = (((Report)rm).Query.Id == a2.a.a());
						}
						else if (rm is FixedPage)
						{
							flag = (((FixedPage)rm).e() != null && ((FixedPage)rm).e().Id == a2.a.a());
						}
						if (!flag)
						{
							throw new ReportWriterException("Query id and scope id specified for an aggregate function in the FixedPage '" + this.h + "' are incorrect");
						}
						rm.a().a(a2.a);
						a2.a.a(true);
					}
				}
			}
		}

		// Token: 0x06005377 RID: 21367 RVA: 0x00291F78 File Offset: 0x00290F78
		internal override void ew(wu A_0)
		{
			if (this.j != null)
			{
				PageLayingOutEventArgs pageLayingOutEventArgs = new PageLayingOutEventArgs(A_0);
				this.j(this, pageLayingOutEventArgs);
				if (pageLayingOutEventArgs.Layout)
				{
					A_0.Document.Pages.Add(pageLayingOutEventArgs.Page);
				}
			}
			else
			{
				rn rn = new rn(this, A_0);
				rn.e0();
				if (this.k != null)
				{
					PageList pages = A_0.Document.Pages;
					PageLaidOutEventArgs pageLaidOutEventArgs = new PageLaidOutEventArgs(A_0, pages[pages.Count - 1]);
					this.k(this, pageLaidOutEventArgs);
				}
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06005378 RID: 21368 RVA: 0x00292024 File Offset: 0x00291024
		public string Id
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x06005379 RID: 21369 RVA: 0x0029203C File Offset: 0x0029103C
		DocumentLayoutPart rm.a()
		{
			return this;
		}

		// Token: 0x0600537A RID: 21370 RVA: 0x00292050 File Offset: 0x00291050
		sz rm.b()
		{
			return this.c();
		}

		// Token: 0x0600537B RID: 21371 RVA: 0x00292068 File Offset: 0x00291068
		internal override vj ex()
		{
			if (this.e == null)
			{
				this.e = new vj();
			}
			return this.e;
		}

		// Token: 0x0600537C RID: 21372 RVA: 0x002920A0 File Offset: 0x002910A0
		internal sz c()
		{
			if (this.f == null)
			{
				this.f = new sz();
			}
			return this.f;
		}

		// Token: 0x0600537D RID: 21373 RVA: 0x002920D8 File Offset: 0x002910D8
		internal override bool ey()
		{
			return this.e != null && this.e.a() >= 1;
		}

		// Token: 0x0600537E RID: 21374 RVA: 0x00292108 File Offset: 0x00291108
		internal PageDimensions d()
		{
			return this.a;
		}

		// Token: 0x0600537F RID: 21375 RVA: 0x00292120 File Offset: 0x00291120
		internal Query e()
		{
			return this.c;
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06005380 RID: 21376 RVA: 0x00292138 File Offset: 0x00291138
		// (set) Token: 0x06005381 RID: 21377 RVA: 0x0029217C File Offset: 0x0029117C
		public PdfPage Template
		{
			get
			{
				PdfPage result;
				if (this.d != null && this.d.d() != null)
				{
					result = this.d.d();
				}
				else
				{
					result = this.b;
				}
				return result;
			}
			set
			{
				if ((this.d != null && this.d.d() == null) || this.d == null)
				{
					this.b = value;
				}
			}
		}

		// Token: 0x06005382 RID: 21378 RVA: 0x002921BC File Offset: 0x002911BC
		bool rm.f()
		{
			return false;
		}

		// Token: 0x06005383 RID: 21379 RVA: 0x002921D0 File Offset: 0x002911D0
		internal ReportElementList g()
		{
			return this.i;
		}

		// Token: 0x06005384 RID: 21380 RVA: 0x002921E8 File Offset: 0x002911E8
		void rm.a(SubReport A_0)
		{
		}

		// Token: 0x06005385 RID: 21381 RVA: 0x002921EC File Offset: 0x002911EC
		internal tm h()
		{
			if (this.g == null)
			{
				this.g = new tm();
			}
			return this.g;
		}

		// Token: 0x04002CBC RID: 11452
		private PageDimensions a = null;

		// Token: 0x04002CBD RID: 11453
		private PdfPage b = null;

		// Token: 0x04002CBE RID: 11454
		private Query c = null;

		// Token: 0x04002CBF RID: 11455
		private x3 d = null;

		// Token: 0x04002CC0 RID: 11456
		private vj e = null;

		// Token: 0x04002CC1 RID: 11457
		private sz f = null;

		// Token: 0x04002CC2 RID: 11458
		private tm g;

		// Token: 0x04002CC3 RID: 11459
		private string h;

		// Token: 0x04002CC4 RID: 11460
		private ReportElementList i;

		// Token: 0x04002CC5 RID: 11461
		private PageLayingOutEventHandler j;

		// Token: 0x04002CC6 RID: 11462
		private PageLaidOutEventHandler k;
	}
}
