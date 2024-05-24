using System;
using System.Collections;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.Merger;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000934 RID: 2356
	public class Report : DocumentLayoutPart, alo, alp
	{
		// Token: 0x06005FB9 RID: 24505 RVA: 0x0035E974 File Offset: 0x0035D974
		internal Report(DocumentLayout A_0) : base(A_0)
		{
		}

		// Token: 0x06005FBA RID: 24506 RVA: 0x0035E9E4 File Offset: 0x0035D9E4
		internal override void m0(alr A_0)
		{
			A_0.a(A_0.Document.Pages.Count);
			al2 al = new al2(this, A_0);
			al.m3();
		}

		// Token: 0x06005FBB RID: 24507 RVA: 0x0035EA18 File Offset: 0x0035DA18
		internal void a(alh A_0)
		{
			this.j = A_0.a();
			this.k = A_0.f();
			this.d = A_0.b();
			this.e = A_0.c();
			this.f = new ain(this.j);
			base.DocumentLayout.a(this.f);
			base.DocumentLayout.a(this.j, this);
			this.l = A_0.g();
			this.m = A_0.h();
			this.n = A_0.i();
			this.o = A_0.j();
			this.a = new ReportHeader(this, A_0.d());
			this.q = false;
			this.c = new DetailReportPart(A_0.e(), this);
			this.q = true;
			this.b = new ReportFooter(this, A_0.k());
			if (A_0.l() != null)
			{
				this.i = new ang(this, A_0.l());
			}
		}

		// Token: 0x06005FBC RID: 24508 RVA: 0x0035EB20 File Offset: 0x0035DB20
		internal override void mz()
		{
			akm.a a = this.g.b();
			while (a != null)
			{
				ahs.a a2 = a.a.a();
				if (a.a.c())
				{
					while (a2 != null)
					{
						if (this.p == null)
						{
							this.p = new and();
						}
						if (string.Compare(a2.a.b(), "CurrentPage", true) == 0 || string.Compare(a2.a.b(), "PreviousPage", true) == 0)
						{
							SubReport subReport = a.a.d();
							if (subReport == null)
							{
								this.p.d().a(a2.a);
							}
							else
							{
								and and = subReport.h();
								and.d().a(a2.a);
							}
							ain ain = base.DocumentLayout.a(a2.a.a());
							ain.b().a(a2.a);
						}
						else
						{
							if (a2.a.a() == this.Id)
							{
								this.f.b().a(a2.a);
							}
							else
							{
								ain ain = base.DocumentLayout.a(a2.a.a());
								ain.b().a(a2.a);
							}
							if (a2.a.b() == this.j)
							{
								this.d().a(a2.a);
							}
							else
							{
								alo alo = base.DocumentLayout.b(a2.a.b());
								alo.a().a(a2.a);
								if (alo is FixedPage)
								{
									throw new LayoutEngineException("FixedPage cannot be a scope for an aggregate function inside the report.");
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
						if (a2.a.a() == this.Id)
						{
							this.f.b().a(a2.a);
						}
						else
						{
							ain ain = base.DocumentLayout.a(a2.a.a());
							ain.b().a(a2.a);
						}
						if (a2.a.b() == this.j)
						{
							this.d().a(a2.a);
						}
						else
						{
							alo alo = base.DocumentLayout.b(a2.a.b());
							alo.a().a(a2.a);
							if (alo is FixedPage)
							{
								throw new LayoutEngineException("FixedPage cannot be a scope for an aggregate function inside the report.");
							}
						}
						a2 = a2.b;
					}
					a = a.b;
				}
			}
		}

		// Token: 0x06005FBD RID: 24509 RVA: 0x0035EE78 File Offset: 0x0035DE78
		ahs alo.a()
		{
			return this.d();
		}

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x06005FBE RID: 24510 RVA: 0x0035EE90 File Offset: 0x0035DE90
		public string Id
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x06005FBF RID: 24511 RVA: 0x0035EEA8 File Offset: 0x0035DEA8
		internal string b()
		{
			return this.k;
		}

		// Token: 0x06005FC0 RID: 24512 RVA: 0x0035EEC0 File Offset: 0x0035DEC0
		DocumentLayoutPart alo.c()
		{
			return this;
		}

		// Token: 0x06005FC1 RID: 24513 RVA: 0x0035EED4 File Offset: 0x0035DED4
		internal ahs d()
		{
			if (this.h == null)
			{
				this.h = new ahs();
			}
			return this.h;
		}

		// Token: 0x06005FC2 RID: 24514 RVA: 0x0035EF0C File Offset: 0x0035DF0C
		internal override akm m1()
		{
			if (this.g == null)
			{
				this.g = new akm();
			}
			return this.g;
		}

		// Token: 0x06005FC3 RID: 24515 RVA: 0x0035EF44 File Offset: 0x0035DF44
		internal PageDimensions e()
		{
			return this.d;
		}

		// Token: 0x06005FC4 RID: 24516 RVA: 0x0035EF5C File Offset: 0x0035DF5C
		internal amz a(amg A_0, al2 A_1)
		{
			amz amz;
			if (this.e == null && this.p() == null && (this.p() == null || !this.i.e()))
			{
				amz = new amz(A_0, A_1);
			}
			else
			{
				amz = new am0(A_0, A_1);
			}
			if (A_1.nb() != null)
			{
				amz.b(A_1);
			}
			return amz;
		}

		// Token: 0x17000A30 RID: 2608
		// (get) Token: 0x06005FC5 RID: 24517 RVA: 0x0035EFCC File Offset: 0x0035DFCC
		public ReportHeader Header
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A31 RID: 2609
		// (get) Token: 0x06005FC6 RID: 24518 RVA: 0x0035EFE4 File Offset: 0x0035DFE4
		public ReportFooter Footer
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x06005FC7 RID: 24519 RVA: 0x0035EFFC File Offset: 0x0035DFFC
		public DetailReportPart Detail
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x06005FC8 RID: 24520 RVA: 0x0035F014 File Offset: 0x0035E014
		internal ain f()
		{
			return this.f;
		}

		// Token: 0x06005FC9 RID: 24521 RVA: 0x0035F02C File Offset: 0x0035E02C
		internal void a(ain A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06005FCA RID: 24522 RVA: 0x0035F038 File Offset: 0x0035E038
		internal PdfPage g()
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

		// Token: 0x06005FCB RID: 24523 RVA: 0x0035F07C File Offset: 0x0035E07C
		internal void a(PdfPage A_0)
		{
			if ((this.i != null && this.i.d() == null) || this.i == null)
			{
				this.e = A_0;
			}
		}

		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x06005FCC RID: 24524 RVA: 0x0035F0BC File Offset: 0x0035E0BC
		// (set) Token: 0x06005FCD RID: 24525 RVA: 0x0035F100 File Offset: 0x0035E100
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

		// Token: 0x06005FCE RID: 24526 RVA: 0x0035F140 File Offset: 0x0035E140
		internal override bool m2()
		{
			return this.g != null && this.g.a() >= 1;
		}

		// Token: 0x06005FCF RID: 24527 RVA: 0x0035F170 File Offset: 0x0035E170
		internal and h()
		{
			return this.p;
		}

		// Token: 0x06005FD0 RID: 24528 RVA: 0x0035F188 File Offset: 0x0035E188
		int alp.i()
		{
			return this.l;
		}

		// Token: 0x06005FD1 RID: 24529 RVA: 0x0035F1A0 File Offset: 0x0035E1A0
		x5 alp.j()
		{
			return this.m;
		}

		// Token: 0x06005FD2 RID: 24530 RVA: 0x0035F1B8 File Offset: 0x0035E1B8
		x5 alp.k()
		{
			return this.n;
		}

		// Token: 0x06005FD3 RID: 24531 RVA: 0x0035F1D0 File Offset: 0x0035E1D0
		akq alp.l()
		{
			return this.o;
		}

		// Token: 0x06005FD4 RID: 24532 RVA: 0x0035F1E8 File Offset: 0x0035E1E8
		bool alp.m()
		{
			return this.c.AutoSplit;
		}

		// Token: 0x06005FD5 RID: 24533 RVA: 0x0035F208 File Offset: 0x0035E208
		LayoutElementList alp.n()
		{
			return this.c.Elements;
		}

		// Token: 0x06005FD6 RID: 24534 RVA: 0x0035F228 File Offset: 0x0035E228
		bool alo.o()
		{
			return this.q;
		}

		// Token: 0x06005FD7 RID: 24535 RVA: 0x0035F240 File Offset: 0x0035E240
		internal ang p()
		{
			return this.i;
		}

		// Token: 0x06005FD8 RID: 24536 RVA: 0x0035F258 File Offset: 0x0035E258
		void alo.a(SubReport A_0)
		{
			SubReport.a(A_0, ref this.r);
		}

		// Token: 0x06005FD9 RID: 24537 RVA: 0x0035F268 File Offset: 0x0035E268
		internal ArrayList q()
		{
			return this.r;
		}

		// Token: 0x06005FDA RID: 24538 RVA: 0x0035F280 File Offset: 0x0035E280
		internal ArrayList r()
		{
			return this.s;
		}

		// Token: 0x06005FDB RID: 24539 RVA: 0x0035F298 File Offset: 0x0035E298
		internal static void a(alo A_0, string A_1)
		{
			if (A_0 is Report)
			{
				((Report)A_0).r().Add(A_1);
			}
			if (A_0 is SubReport)
			{
				((SubReport)A_0).s().Add(A_1);
			}
		}

		// Token: 0x04003146 RID: 12614
		private ReportHeader a = null;

		// Token: 0x04003147 RID: 12615
		private ReportFooter b = null;

		// Token: 0x04003148 RID: 12616
		private DetailReportPart c = null;

		// Token: 0x04003149 RID: 12617
		private PageDimensions d = null;

		// Token: 0x0400314A RID: 12618
		private PdfPage e = null;

		// Token: 0x0400314B RID: 12619
		private ain f = null;

		// Token: 0x0400314C RID: 12620
		private akm g = null;

		// Token: 0x0400314D RID: 12621
		private ahs h = null;

		// Token: 0x0400314E RID: 12622
		private ang i = null;

		// Token: 0x0400314F RID: 12623
		private string j;

		// Token: 0x04003150 RID: 12624
		private string k;

		// Token: 0x04003151 RID: 12625
		private int l;

		// Token: 0x04003152 RID: 12626
		private x5 m;

		// Token: 0x04003153 RID: 12627
		private x5 n;

		// Token: 0x04003154 RID: 12628
		private akq o;

		// Token: 0x04003155 RID: 12629
		private and p;

		// Token: 0x04003156 RID: 12630
		private bool q = true;

		// Token: 0x04003157 RID: 12631
		private ArrayList r = null;

		// Token: 0x04003158 RID: 12632
		private ArrayList s = new ArrayList(5);
	}
}
