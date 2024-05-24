using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006ED RID: 1773
	public class AppendedPage : Page
	{
		// Token: 0x06004458 RID: 17496 RVA: 0x00233960 File Offset: 0x00232960
		internal AppendedPage(PdfPage A_0, abb A_1) : base(A_0.i().b())
		{
			this.b = A_0;
			base.Rotate = A_0.g();
			this.c = A_1;
			if (A_0.j() != null && A_0.j().a(A_1.d(), A_1.e()))
			{
				this.d = A_0.j().a(A_1, A_1.d(), A_1.e(), A_1.c());
			}
			else
			{
				this.d = null;
			}
		}

		// Token: 0x06004459 RID: 17497 RVA: 0x00233A08 File Offset: 0x00232A08
		private void c(DocumentWriter A_0)
		{
			if (A_0.Document.d().Output == FormOutput.Flatten || A_0.Document.d().Output == FormOutput.Remove)
			{
				A_0.Document.RequireLicense(13);
			}
			else if (this.d != null && this.d.Length > 0)
			{
				for (int i = 0; i < this.d.Length; i++)
				{
					if (this.d[i].ag() == FormFieldOutput.Flatten || this.d[i].ag() == FormFieldOutput.Remove)
					{
						A_0.Document.RequireLicense(13);
						break;
					}
				}
			}
		}

		// Token: 0x0600445A RID: 17498 RVA: 0x00233ACC File Offset: 0x00232ACC
		internal override void ff(DocumentWriter A_0, int A_1, int A_2)
		{
			A_0.Document.RequireLicense(this.b.b());
			this.e = (this.c.h() && (this.b.p() || this.g9(A_0, A_1)) && A_0.Document.j() != null);
			if (this.c.h() && (this.b.p() || this.g9(A_0, A_1)) && A_0.Document.j() != null)
			{
				A_0.Document.RequireLicense(4);
				base.a(A_0.Document.k());
				A_0.Document.j().a(this.f(), A_0.GetObjectNumber());
			}
			this.c(A_0);
			if (this.g9(A_0, A_1) || A_0.Document.g() || A_0.Document.d().Output == FormOutput.Flatten || A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten || this.b(A_0) || (A_0.Document.Template != null && A_0.Document.Template.j2() == 703119003) || (A_0.Document.StampTemplate != null && A_0.Document.StampTemplate.j2() == 703119003))
			{
				this.a(A_0, A_1, A_2);
			}
			else
			{
				this.a(A_0);
			}
			if (A_0.Document.Pages.Count == A_1 && A_0.Document.i() != null && A_0.Document.i().Count > 0)
			{
				PageResources a_ = new PageResources();
				PageWriter a_2 = new PageWriter(this, a_, A_0, A_0.u(), A_1, A_2);
				base.c(a_2);
			}
			if (this.c.f())
			{
				this.b.a().b(A_0);
			}
			if (this.c.h() && (this.b.p() || this.g9(A_0, A_1)) && A_0.Document.j() != null)
			{
				if (this.b.n() && !this.c.f())
				{
					A_0.WriteName(Page.l);
					A_0.WriteName(Page.n);
				}
				A_0.Document.a(base.f() + 1);
				A_0.WriteName(Page.m);
				A_0.WriteNumber(base.f());
			}
			if (this.b.f() != null)
			{
				this.b.f().a(A_0);
			}
		}

		// Token: 0x0600445B RID: 17499 RVA: 0x00233DB4 File Offset: 0x00232DB4
		private bool b(DocumentWriter A_0)
		{
			bool result;
			if (A_0.Document.d().c() && this.d != null)
			{
				for (int i = 0; i < this.d.Length; i++)
				{
					if (this.d[i].ag() == FormFieldOutput.Flatten)
					{
						return true;
					}
					if (this.d[i].ag() == FormFieldOutput.Inherit)
					{
						if (this.d[i] is SignatureField)
						{
							if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten)
							{
								return true;
							}
							if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
							{
								if (A_0.Document.d().Output == FormOutput.Flatten)
								{
									return true;
								}
							}
						}
						else if (A_0.Document.d().Output == FormOutput.Flatten)
						{
							return true;
						}
					}
				}
				result = false;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600445C RID: 17500 RVA: 0x00233EE0 File Offset: 0x00232EE0
		private void a(DocumentWriter A_0, int A_1, int A_2)
		{
			PageResources a_ = new PageResources();
			PageWriter pageWriter = new PageWriter(this, a_, A_0, A_0.u(), A_1, A_2);
			this.e9(pageWriter);
			pageWriter.Write_q_(false);
			PageWriter pageWriter2 = new PageWriter(this, a_, A_0, A_0.x(), A_1, A_2);
			pageWriter2.Write_Q(false);
			base.b(pageWriter2);
			if (this.d != null && this.d.Length > 0)
			{
				for (int i = 0; i < this.d.Length; i++)
				{
					if (this.d[i] != null && this.d[i] is FormField)
					{
						if (this.d[i].ag() == FormFieldOutput.Flatten)
						{
							((FormField)this.d[i]).hc(pageWriter2, A_1);
						}
						else if (this.d[i].ag() == FormFieldOutput.Inherit)
						{
							if (this.d[i] is SignatureField)
							{
								if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten)
								{
									((FormField)this.d[i]).hc(pageWriter2, A_1);
								}
								else if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
								{
									if (A_0.Document.d().Output == FormOutput.Flatten)
									{
										((FormField)this.d[i]).hc(pageWriter2, A_1);
									}
								}
							}
							else if (A_0.Document.d().Output == FormOutput.Flatten)
							{
								((FormField)this.d[i]).hc(pageWriter2, A_1);
							}
						}
					}
				}
				if (A_0.Document.d().Output == FormOutput.Flatten)
				{
					foreach (PdfFormField pdfFormField in this.b.j().b())
					{
						if (pdfFormField != null)
						{
							pdfFormField.hm(A_1).hc(pageWriter2, A_1);
						}
					}
				}
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
			if (this.b.h() != null)
			{
				if (this.b.h().hy() == ag9.e)
				{
					((abe)this.b.h()).a(A_0);
				}
				else if (this.b.h().hy() == ag9.j)
				{
					this.b.h().hz(A_0);
				}
			}
			A_0.WriteReferenceUnique(pageWriter2);
			A_0.WriteArrayClose();
			this.a(A_0, a_);
			if (this.d != null || pageWriter.Annotations.a() > 0 || pageWriter2.Annotations.a() > 0)
			{
				A_0.WriteName(Page.k);
				A_0.WriteArrayOpen();
				pageWriter.Annotations.a(A_0);
				if (this.d != null)
				{
					for (int i = 0; i < this.d.Length; i++)
					{
						if (this.d[i] != null)
						{
							if (this.d[i] is FormField)
							{
								if (this.d[i].ag() == FormFieldOutput.Retain)
								{
									A_0.WriteReference(this.d[i]);
								}
								else if (this.d[i].ag() == FormFieldOutput.Inherit)
								{
									if (this.d[i] is SignatureField)
									{
										if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain)
										{
											A_0.WriteReference(this.d[i]);
										}
										else if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
										{
											if (A_0.Document.d().Output == FormOutput.Retain)
											{
												A_0.WriteReference(this.d[i]);
											}
										}
									}
									else if (A_0.Document.d().Output == FormOutput.Retain)
									{
										A_0.WriteReference(this.d[i]);
									}
								}
							}
							else if (!this.d[i].hn())
							{
								A_0.WriteReference(this.d[i]);
							}
						}
					}
				}
				pageWriter2.Annotations.a(A_0);
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x0600445D RID: 17501 RVA: 0x0023447C File Offset: 0x0023347C
		private void a(DocumentWriter A_0)
		{
			if (this.b.h() != null)
			{
				A_0.WriteName(Page.j);
				this.b.h().hz(A_0);
			}
			this.a(A_0, null);
			if (this.d != null)
			{
				A_0.WriteName(Page.k);
				A_0.WriteArrayOpen();
				for (int i = 0; i < this.d.Length; i++)
				{
					if (this.d[i] != null)
					{
						if (this.d[i].ag() == FormFieldOutput.Retain)
						{
							A_0.WriteReference(this.d[i]);
						}
						else if (this.d[i].ag() == FormFieldOutput.Inherit)
						{
							if (this.d[i] is SignatureField)
							{
								if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain)
								{
									A_0.WriteReference(this.d[i]);
								}
								else if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
								{
									if (A_0.Document.d().Output == FormOutput.Retain)
									{
										A_0.WriteReference(this.d[i]);
									}
								}
							}
							else if (A_0.Document.d().Output == FormOutput.Retain)
							{
								A_0.WriteReference(this.d[i]);
							}
						}
					}
				}
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x0600445E RID: 17502 RVA: 0x00234620 File Offset: 0x00233620
		private void a(DocumentWriter A_0, PageResources A_1)
		{
			if (A_1 == null)
			{
				if (this.b.k() != null)
				{
					this.b.k().a(A_0);
				}
			}
			else if (this.b.k() == null)
			{
				A_1.Draw(A_0);
			}
			else
			{
				this.b.k().a(A_0, A_1);
			}
		}

		// Token: 0x0600445F RID: 17503 RVA: 0x00234698 File Offset: 0x00233698
		internal override void e9(PageWriter A_0)
		{
			if (this.b.k() != null)
			{
				A_0.Resources.SetStartingNameNumber(this.b.k().b());
			}
			base.e9(A_0);
			if (this.a.Count > 0)
			{
				A_0.Write_q_(true);
				this.a.Draw(A_0);
				A_0.Write_Q(true);
			}
		}

		// Token: 0x06004460 RID: 17504 RVA: 0x00234710 File Offset: 0x00233710
		internal override bool g9(DocumentWriter A_0, int A_1)
		{
			return base.g9(A_0, A_1) || this.a.Count > 0;
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06004461 RID: 17505 RVA: 0x00234740 File Offset: 0x00233740
		public Group BackgroundElements
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06004462 RID: 17506 RVA: 0x00234758 File Offset: 0x00233758
		internal override PdfPage fg()
		{
			return this.b;
		}

		// Token: 0x06004463 RID: 17507 RVA: 0x00234770 File Offset: 0x00233770
		internal override bool ha()
		{
			return this.e;
		}

		// Token: 0x0400262D RID: 9773
		private new Group a = new Group();

		// Token: 0x0400262E RID: 9774
		private new PdfPage b;

		// Token: 0x0400262F RID: 9775
		private new abb c;

		// Token: 0x04002630 RID: 9776
		private Resource[] d;

		// Token: 0x04002631 RID: 9777
		private bool e = true;
	}
}
