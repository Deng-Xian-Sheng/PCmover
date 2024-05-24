using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;

namespace zz93
{
	// Token: 0x020003FF RID: 1023
	internal class aao : SignatureField
	{
		// Token: 0x06002ADF RID: 10975 RVA: 0x0018D304 File Offset: 0x0018C304
		internal aao(PdfSignatureField A_0, int A_1) : base(A_0.Name, (int)A_0.Flags, null)
		{
			base.IsAnnotation = A_0.w();
			this.a = A_0;
			this.b = A_1;
			if (A_0.q() != null)
			{
				base.AlternateName = A_0.q().kf();
			}
			if (A_0.r() != null)
			{
				base.MappingName = A_0.r().kf();
			}
		}

		// Token: 0x06002AE0 RID: 10976 RVA: 0x0018D380 File Offset: 0x0018C380
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002AE1 RID: 10977 RVA: 0x0018D398 File Offset: 0x0018C398
		protected override void DrawDictionary(DocumentWriter writer)
		{
			if (this.a.ab() && writer.Document.j() != null)
			{
				StructureElement structureElement = this.a.g();
				if (structureElement != null && base.d() && this.a.ae())
				{
					base.a(structureElement);
					structureElement.bp(this, this.a.GetOriginalPageNumber() - 1);
					writer.Document.j().e(structureElement);
				}
			}
			this.a.a(writer);
			base.DrawDictionary(writer);
			Resource resource = this.a.h();
			if (resource != null)
			{
				base.Form.a(writer, resource);
			}
			ab7 ab = this.a.i();
			if (ab != null)
			{
				base.Form.a(writer, ab);
			}
			if (this.a.s() != null)
			{
				writer.WriteName(FormField.o);
				this.a.s().hz(writer);
			}
			if (this.a.t() != null)
			{
				writer.WriteName(FormField.p);
				this.a.s().hz(writer);
			}
			if (this.b > 0)
			{
				writer.WriteName(80);
				writer.WriteReferenceShallow(writer.GetPageObject(this.b));
			}
			if (base.i() != null && this.b() != -1)
			{
				base.i().a(writer, this.b());
			}
		}

		// Token: 0x06002AE2 RID: 10978 RVA: 0x0018D548 File Offset: 0x0018C548
		internal override void hc(PageWriter A_0, int A_1)
		{
			if (this.a.s() != null)
			{
				if (base.Output == FormFieldOutput.Flatten || (base.Output == FormFieldOutput.Inherit && A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten) || (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && A_0.Document.d().Output == FormOutput.Flatten))
				{
					abd abd = this.a();
					if (abd != null)
					{
						A_0.Write_q_();
						A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
						A_0.Write_Do(new abn(abd));
						A_0.Write_Q();
					}
				}
			}
		}

		// Token: 0x06002AE3 RID: 10979 RVA: 0x0018D664 File Offset: 0x0018C664
		private new abd a()
		{
			for (abk abk = this.a.s().l(); abk != null; abk = abk.d())
			{
				if (abk.b())
				{
					if (abk.a().j9() == "N")
					{
						if (abk.c().hy() == ag9.j)
						{
							ab6 ab = (ab6)abk.c();
							abg abg = ab.b().m().b((long)ab.c());
							abd result;
							if (abg == null)
							{
								result = null;
							}
							else
							{
								result = abg.h0();
							}
							return result;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x040013BC RID: 5052
		private new PdfSignatureField a;

		// Token: 0x040013BD RID: 5053
		private new int b;
	}
}
