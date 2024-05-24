using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006CC RID: 1740
	public abstract class ChoiceField : FormField
	{
		// Token: 0x06004339 RID: 17209 RVA: 0x0022EDFE File Offset: 0x0022DDFE
		internal ChoiceField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, (FormFieldFlags)A_1, A_2)
		{
		}

		// Token: 0x0600433A RID: 17210 RVA: 0x0022EE0C File Offset: 0x0022DE0C
		protected override void DrawDictionary(DocumentWriter writer)
		{
			if (base.Parent == null || !(base.Parent is ChoiceField))
			{
				writer.WriteName(FormField.n);
				writer.WriteName(ChoiceField.a);
			}
			base.d(writer);
			base.DrawDictionary(writer);
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600433B RID: 17211
		public abstract string Default { get; }

		// Token: 0x04002563 RID: 9571
		private new static byte[] a = new byte[]
		{
			67,
			104
		};

		// Token: 0x04002564 RID: 9572
		internal new static byte[] b = new byte[]
		{
			79,
			112,
			116
		};
	}
}
