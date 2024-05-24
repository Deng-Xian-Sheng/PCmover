using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F0 RID: 1776
	public class ImportedPage : Page
	{
		// Token: 0x0600446D RID: 17517 RVA: 0x00234A89 File Offset: 0x00233A89
		public ImportedPage(string filePath, int pageNumber) : this(new PdfDocument(filePath).GetPage(pageNumber))
		{
		}

		// Token: 0x0600446E RID: 17518 RVA: 0x00234AA0 File Offset: 0x00233AA0
		public ImportedPage(string filePath, int pageNumber, float margins) : this(new PdfDocument(filePath).GetPage(pageNumber), margins)
		{
		}

		// Token: 0x0600446F RID: 17519 RVA: 0x00234AB8 File Offset: 0x00233AB8
		public ImportedPage(PdfPage pdfPage)
		{
			this.b = new Group();
			this.c = true;
			this.d = true;
			this.e = true;
			this.f = string.Empty;
			this.g = true;
			this.h = true;
			base..ctor(pdfPage.i().b());
			this.a = pdfPage;
			base.Rotate = pdfPage.g();
		}

		// Token: 0x06004470 RID: 17520 RVA: 0x00234B28 File Offset: 0x00233B28
		public ImportedPage(PdfPage pdfPage, float margins)
		{
			this.b = new Group();
			this.c = true;
			this.d = true;
			this.e = true;
			this.f = string.Empty;
			this.g = true;
			this.h = true;
			base..ctor(pdfPage.i().b());
			this.a = pdfPage;
			base.Rotate = pdfPage.g();
			base.Dimensions.SetMargins(margins);
			this.c = true;
			this.d = true;
			this.e = true;
			this.g = true;
		}

		// Token: 0x06004471 RID: 17521 RVA: 0x00234BC0 File Offset: 0x00233BC0
		internal override void ff(DocumentWriter A_0, int A_1, int A_2)
		{
			if (this.g)
			{
				this.a.q().e().n().a(A_0.Document, this.a.e() + 1, 1);
			}
			this.h = ((this.a.p() || this.g9(A_0, A_1)) && this.g && A_0.Document.j() != null);
			A_0.Document.RequireLicense(this.a.b());
			if ((this.a.p() || this.g9(A_0, A_1)) && this.g && A_0.Document.j() != null)
			{
				A_0.Document.RequireLicense(4);
				base.a(A_0.Document.k());
				A_0.Document.j().a(this.f(), A_0.GetObjectNumber());
			}
			if (this.g9(A_0, A_1) || A_0.Document.g() || A_0.Document.d().Output == FormOutput.Flatten || A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten)
			{
				this.a(A_0, A_1, A_2);
			}
			else
			{
				this.a(A_0, A_1);
			}
			if (this.e)
			{
				this.a.a().b(A_0);
			}
			if ((this.a.p() || this.g9(A_0, A_1)) && this.g && A_0.Document.j() != null)
			{
				if (this.a.n() && !this.e)
				{
					A_0.WriteName(Page.l);
					A_0.WriteName(Page.n);
				}
				A_0.Document.a(base.f() + 1);
				A_0.WriteName(Page.m);
				A_0.WriteNumber(base.f());
			}
		}

		// Token: 0x06004472 RID: 17522 RVA: 0x00234DE8 File Offset: 0x00233DE8
		private void a(DocumentWriter A_0, int A_1, int A_2)
		{
			PageResources a_ = new PageResources();
			PageWriter pageWriter = new PageWriter(this, a_, A_0, A_0.u(), A_1, A_2);
			this.e9(pageWriter);
			pageWriter.Write_q_(false);
			PageWriter pageWriter2 = new PageWriter(this, a_, A_0, A_0.x(), A_1, A_2);
			pageWriter2.Write_Q(false);
			base.b(pageWriter2);
			if (this.a())
			{
				this.a.j().a(pageWriter2, A_0.Document.a(this.f), this.d, this.c, A_1, this.g);
			}
			A_0.Document.RequireLicense(pageWriter2.r());
			A_0.Document.RequireLicense(pageWriter.r());
			if (A_0.Document.g())
			{
				pageWriter.f();
				pageWriter2.i();
				pageWriter2.w();
			}
			else
			{
				pageWriter.w();
				pageWriter2.w();
			}
			A_0.WriteName(Page.j);
			A_0.WriteArrayOpen();
			A_0.WriteReferenceUnique(pageWriter);
			if (this.a.h() != null)
			{
				if (this.a.h().hy() == ag9.e)
				{
					((abe)this.a.h()).a(A_0);
				}
				else if (this.a.h().hy() == ag9.j)
				{
					this.a.h().hz(A_0);
				}
			}
			A_0.WriteReferenceUnique(pageWriter2);
			A_0.WriteArrayClose();
			this.a(A_0, a_);
			if (this.a() || pageWriter.Annotations.a() > 0 || pageWriter2.Annotations.a() > 0)
			{
				A_0.WriteName(Page.k);
				A_0.WriteArrayOpen();
				pageWriter.Annotations.a(A_0);
				if (this.a())
				{
					this.a.j().a(A_0, A_0.Document.a(this.f), this.d, this.c, A_1, this.g);
				}
				pageWriter2.Annotations.a(A_0);
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x06004473 RID: 17523 RVA: 0x00235038 File Offset: 0x00234038
		private void a(DocumentWriter A_0, int A_1)
		{
			if (this.a.h() != null)
			{
				A_0.WriteName(Page.j);
				this.a.h().hz(A_0);
			}
			this.a(A_0, null);
			if (this.a())
			{
				A_0.WriteName(Page.k);
				A_0.WriteArrayOpen();
				this.a.j().a(A_0, A_0.Document.a(this.f), this.d, this.c, A_1, this.g);
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x06004474 RID: 17524 RVA: 0x002350E0 File Offset: 0x002340E0
		private bool a()
		{
			return this.a.j() != null && this.a.j().a(this.d, this.c);
		}

		// Token: 0x06004475 RID: 17525 RVA: 0x00235120 File Offset: 0x00234120
		private void a(DocumentWriter A_0, PageResources A_1)
		{
			if (A_1 == null)
			{
				if (this.a.k() != null)
				{
					this.a.k().a(A_0);
				}
			}
			else if (this.a.k() == null)
			{
				A_1.Draw(A_0);
			}
			else
			{
				this.a.k().a(A_0, A_1);
			}
		}

		// Token: 0x06004476 RID: 17526 RVA: 0x00235198 File Offset: 0x00234198
		internal override void e9(PageWriter A_0)
		{
			if (this.a.k() != null)
			{
				A_0.Resources.SetStartingNameNumber(this.a.k().b());
			}
			base.e9(A_0);
			if (this.b.Count > 0)
			{
				A_0.Write_q_(true);
				this.b.Draw(A_0);
				A_0.Write_Q(true);
			}
		}

		// Token: 0x06004477 RID: 17527 RVA: 0x00235210 File Offset: 0x00234210
		internal override bool g9(DocumentWriter A_0, int A_1)
		{
			return base.g9(A_0, A_1) || this.b.Count > 0;
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06004478 RID: 17528 RVA: 0x00235240 File Offset: 0x00234240
		// (set) Token: 0x06004479 RID: 17529 RVA: 0x00235258 File Offset: 0x00234258
		public bool ImportAnnotations
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

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x0600447A RID: 17530 RVA: 0x00235264 File Offset: 0x00234264
		// (set) Token: 0x0600447B RID: 17531 RVA: 0x0023527C File Offset: 0x0023427C
		public bool ImportFormFields
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

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600447C RID: 17532 RVA: 0x00235288 File Offset: 0x00234288
		// (set) Token: 0x0600447D RID: 17533 RVA: 0x002352A0 File Offset: 0x002342A0
		public bool ImportAllOtherData
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

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600447E RID: 17534 RVA: 0x002352AC File Offset: 0x002342AC
		// (set) Token: 0x0600447F RID: 17535 RVA: 0x002352C4 File Offset: 0x002342C4
		public bool LogicalStructure
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

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06004480 RID: 17536 RVA: 0x002352D0 File Offset: 0x002342D0
		public Group BackgroundElements
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06004481 RID: 17537 RVA: 0x002352E8 File Offset: 0x002342E8
		internal override PdfPage fg()
		{
			return this.a;
		}

		// Token: 0x06004482 RID: 17538 RVA: 0x00235300 File Offset: 0x00234300
		internal override bool ha()
		{
			return this.h;
		}

		// Token: 0x04002636 RID: 9782
		private new PdfPage a;

		// Token: 0x04002637 RID: 9783
		private new Group b;

		// Token: 0x04002638 RID: 9784
		private new bool c;

		// Token: 0x04002639 RID: 9785
		private bool d;

		// Token: 0x0400263A RID: 9786
		private bool e;

		// Token: 0x0400263B RID: 9787
		private string f;

		// Token: 0x0400263C RID: 9788
		private bool g;

		// Token: 0x0400263D RID: 9789
		private bool h;
	}
}
