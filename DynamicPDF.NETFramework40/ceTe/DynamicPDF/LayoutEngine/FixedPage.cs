using System;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.Merger;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000930 RID: 2352
	public class FixedPage : DocumentLayoutPart, alo
	{
		// Token: 0x06005F9A RID: 24474 RVA: 0x0035DFAC File Offset: 0x0035CFAC
		internal FixedPage(ak9 A_0, DocumentLayout A_1) : base(A_1)
		{
			this.g = A_0.b();
			this.a = A_0.c();
			this.b = A_0.d();
			if (A_0.a() != null)
			{
				this.h = new LayoutElementList(this, A_0.a());
			}
			base.DocumentLayout.a(this.g, this);
		}

		// Token: 0x06005F9B RID: 24475 RVA: 0x0035E03C File Offset: 0x0035D03C
		internal override void mz()
		{
			for (akm.a a = this.d.b(); a != null; a = a.b)
			{
				for (ahs.a a2 = a.a.a(); a2 != null; a2 = a2.b)
				{
					ain ain = base.DocumentLayout.a(a2.a.a());
					ain.b().a(a2.a);
					if (a2.a.b() == this.g)
					{
						this.c().a(a2.a);
					}
					else
					{
						alo alo = base.DocumentLayout.b(a2.a.b());
						if (!(alo is Report))
						{
							throw new LayoutEngineException("Query id and scope id specified for an aggregate function in the FixedPage '" + this.g + "' are incorrect");
						}
						alo.a().a(a2.a);
						a2.a.a(true);
					}
				}
			}
		}

		// Token: 0x06005F9C RID: 24476 RVA: 0x0035E160 File Offset: 0x0035D160
		internal override void m0(alr A_0)
		{
			als als = new als(this, A_0);
			als.m3();
		}

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x06005F9D RID: 24477 RVA: 0x0035E180 File Offset: 0x0035D180
		public string Id
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x06005F9E RID: 24478 RVA: 0x0035E198 File Offset: 0x0035D198
		DocumentLayoutPart alo.a()
		{
			return this;
		}

		// Token: 0x06005F9F RID: 24479 RVA: 0x0035E1AC File Offset: 0x0035D1AC
		ahs alo.b()
		{
			return this.c();
		}

		// Token: 0x06005FA0 RID: 24480 RVA: 0x0035E1C4 File Offset: 0x0035D1C4
		internal override akm m1()
		{
			if (this.d == null)
			{
				this.d = new akm();
			}
			return this.d;
		}

		// Token: 0x06005FA1 RID: 24481 RVA: 0x0035E1FC File Offset: 0x0035D1FC
		internal ahs c()
		{
			if (this.e == null)
			{
				this.e = new ahs();
			}
			return this.e;
		}

		// Token: 0x06005FA2 RID: 24482 RVA: 0x0035E234 File Offset: 0x0035D234
		internal override bool m2()
		{
			return this.d != null && this.d.a() >= 1;
		}

		// Token: 0x06005FA3 RID: 24483 RVA: 0x0035E264 File Offset: 0x0035D264
		internal PageDimensions d()
		{
			return this.a;
		}

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x06005FA4 RID: 24484 RVA: 0x0035E27C File Offset: 0x0035D27C
		// (set) Token: 0x06005FA5 RID: 24485 RVA: 0x0035E2C0 File Offset: 0x0035D2C0
		public PdfPage Template
		{
			get
			{
				PdfPage result;
				if (this.c != null && this.c.d() != null)
				{
					result = this.c.d();
				}
				else
				{
					result = this.b;
				}
				return result;
			}
			set
			{
				if ((this.c != null && this.c.d() == null) || this.c == null)
				{
					this.b = value;
				}
			}
		}

		// Token: 0x06005FA6 RID: 24486 RVA: 0x0035E300 File Offset: 0x0035D300
		bool alo.e()
		{
			return false;
		}

		// Token: 0x06005FA7 RID: 24487 RVA: 0x0035E314 File Offset: 0x0035D314
		internal LayoutElementList f()
		{
			return this.h;
		}

		// Token: 0x06005FA8 RID: 24488 RVA: 0x0035E32C File Offset: 0x0035D32C
		void alo.a(SubReport A_0)
		{
		}

		// Token: 0x06005FA9 RID: 24489 RVA: 0x0035E330 File Offset: 0x0035D330
		internal aig g()
		{
			if (this.f == null)
			{
				this.f = new aig();
			}
			return this.f;
		}

		// Token: 0x04003139 RID: 12601
		private PageDimensions a = null;

		// Token: 0x0400313A RID: 12602
		private PdfPage b = null;

		// Token: 0x0400313B RID: 12603
		private ang c = null;

		// Token: 0x0400313C RID: 12604
		private akm d = null;

		// Token: 0x0400313D RID: 12605
		private ahs e = null;

		// Token: 0x0400313E RID: 12606
		private aig f;

		// Token: 0x0400313F RID: 12607
		private string g;

		// Token: 0x04003140 RID: 12608
		private LayoutElementList h;
	}
}
