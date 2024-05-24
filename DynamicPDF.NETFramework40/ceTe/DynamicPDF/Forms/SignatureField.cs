using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020000AD RID: 173
	public abstract class SignatureField : FormField
	{
		// Token: 0x0600081C RID: 2076 RVA: 0x00072CCF File Offset: 0x00071CCF
		internal SignatureField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, (FormFieldFlags)A_1, A_2)
		{
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00072CE0 File Offset: 0x00071CE0
		protected override void DrawDictionary(DocumentWriter writer)
		{
			if (base.Parent == null || !(base.Parent is SignatureField))
			{
				writer.WriteName(FormField.n);
				writer.WriteName(SignatureField.a);
			}
			if (base.e() != null)
			{
				base.d(writer);
			}
			base.DrawDictionary(writer);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00072D48 File Offset: 0x00071D48
		internal override bj cc()
		{
			return bj.g;
		}

		// Token: 0x04000471 RID: 1137
		private new static byte[] a = new byte[]
		{
			83,
			105,
			103
		};
	}
}
