using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;

namespace zz93
{
	// Token: 0x0200041E RID: 1054
	internal abstract class abg
	{
		// Token: 0x06002BD9 RID: 11225 RVA: 0x00194346 File Offset: 0x00193346
		internal abg(aba A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002BDA RID: 11226
		internal abstract abd h0();

		// Token: 0x06002BDB RID: 11227 RVA: 0x00194374 File Offset: 0x00193374
		internal virtual afj ia()
		{
			if (this.d == null)
			{
				this.d = new abr(this.h0());
			}
			return (afj)this.d.c();
		}

		// Token: 0x06002BDC RID: 11228 RVA: 0x001943BC File Offset: 0x001933BC
		internal Resource d()
		{
			if (this.d == null)
			{
				this.d = new abr(this.h0());
			}
			return this.d.h3();
		}

		// Token: 0x06002BDD RID: 11229 RVA: 0x001943FC File Offset: 0x001933FC
		internal void a(DocumentWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new abr(this.h0());
			}
			if (this.d.c() == null)
			{
				A_0.WriteNull();
			}
			else
			{
				this.d.bw(A_0);
			}
		}

		// Token: 0x06002BDE RID: 11230 RVA: 0x00194458 File Offset: 0x00193458
		internal void b(DocumentWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new abr(this.h0());
			}
			this.d.bv(A_0);
		}

		// Token: 0x06002BDF RID: 11231 RVA: 0x00194498 File Offset: 0x00193498
		internal c8 e()
		{
			return this.d;
		}

		// Token: 0x06002BE0 RID: 11232 RVA: 0x001944B0 File Offset: 0x001934B0
		internal bool f()
		{
			return this.e;
		}

		// Token: 0x06002BE1 RID: 11233 RVA: 0x001944C8 File Offset: 0x001934C8
		internal void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06002BE2 RID: 11234 RVA: 0x001944D4 File Offset: 0x001934D4
		internal PdfPage a(int A_0, acf A_1)
		{
			PdfPage pdfPage = new PdfPage((abj)this.d.c(), A_0, A_1);
			this.d = new ab1(pdfPage);
			return pdfPage;
		}

		// Token: 0x06002BE3 RID: 11235 RVA: 0x0019450C File Offset: 0x0019350C
		internal abp a(acc A_0, int A_1, PdfPage A_2)
		{
			abp result;
			if (this.d is abq)
			{
				result = this.d.hx();
			}
			else
			{
				if (this.d == null || this.d.hx() == null)
				{
					abj a_ = (abj)this.h0();
					acb acb = new acb(A_0, A_1, a_, A_2);
					acb.a(this.b);
					this.d = new abc(acb);
				}
				result = this.d.hx();
			}
			return result;
		}

		// Token: 0x06002BE4 RID: 11236 RVA: 0x001945A0 File Offset: 0x001935A0
		internal PdfFormField a(ab6 A_0, PdfForm A_1)
		{
			abj a_ = (abj)this.h0();
			A_0.a().a(true);
			return PdfFormField.a(A_1, A_0.c(), null, a_);
		}

		// Token: 0x06002BE5 RID: 11237 RVA: 0x001945DC File Offset: 0x001935DC
		internal PdfFormField a(ab6 A_0, PdfForm A_1, PdfFormField A_2)
		{
			abj a_ = (abj)this.h0();
			A_0.a().a(true);
			PdfFormField pdfFormField = PdfFormField.a(A_1, A_0.c(), A_2, a_);
			if (pdfFormField.w())
			{
				this.d = new abq(pdfFormField);
			}
			return pdfFormField;
		}

		// Token: 0x06002BE6 RID: 11238 RVA: 0x00194630 File Offset: 0x00193630
		internal da g()
		{
			abj a_ = (abj)this.h0();
			da da = new da(a_, this);
			if (this.d == null)
			{
				this.d = new c9(da);
			}
			return da;
		}

		// Token: 0x06002BE7 RID: 11239 RVA: 0x00194674 File Offset: 0x00193674
		internal PdfPage h()
		{
			PdfPage result;
			if (this.d != null)
			{
				result = this.d.h8();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002BE8 RID: 11240 RVA: 0x001946A4 File Offset: 0x001936A4
		internal abd i()
		{
			if (this.d == null)
			{
				this.d = new abr(this.h0());
			}
			return this.d.c();
		}

		// Token: 0x06002BE9 RID: 11241 RVA: 0x001946E4 File Offset: 0x001936E4
		internal afj j()
		{
			if (this.d == null)
			{
				abd abd = this.h0();
				if (abd.hy() != ag9.h)
				{
					return null;
				}
				this.d = new ahd((afj)abd);
			}
			return this.d.lt();
		}

		// Token: 0x06002BEA RID: 11242 RVA: 0x00194748 File Offset: 0x00193748
		internal ag6 k()
		{
			if (this.c > 2)
			{
				throw new MergerException("Object number and stream object number are same in the compressed object.");
			}
			this.c++;
			ag6 result;
			try
			{
				if (this.d == null)
				{
					abd abd = this.h0();
					if (abd == null)
					{
						return null;
					}
					ag6 a_ = new ag6(this.a.af(), (afj)abd);
					this.d = new abx(a_);
				}
				result = this.d.h7();
			}
			finally
			{
				this.c--;
			}
			return result;
		}

		// Token: 0x06002BEB RID: 11243 RVA: 0x00194800 File Offset: 0x00193800
		internal int l()
		{
			return this.b;
		}

		// Token: 0x06002BEC RID: 11244 RVA: 0x00194818 File Offset: 0x00193818
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x00194824 File Offset: 0x00193824
		internal aba m()
		{
			return this.a;
		}

		// Token: 0x040014A1 RID: 5281
		private aba a;

		// Token: 0x040014A2 RID: 5282
		private int b;

		// Token: 0x040014A3 RID: 5283
		private int c = 0;

		// Token: 0x040014A4 RID: 5284
		private c8 d = null;

		// Token: 0x040014A5 RID: 5285
		private bool e = false;
	}
}
