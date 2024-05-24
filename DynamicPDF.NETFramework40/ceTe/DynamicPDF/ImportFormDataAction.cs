using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200065C RID: 1628
	public class ImportFormDataAction : OutlineAnnotationAction
	{
		// Token: 0x06003D8B RID: 15755 RVA: 0x00215A29 File Offset: 0x00214A29
		public ImportFormDataAction()
		{
		}

		// Token: 0x06003D8C RID: 15756 RVA: 0x00215A34 File Offset: 0x00214A34
		public ImportFormDataAction(string filePath)
		{
			this.a = filePath;
		}

		// Token: 0x06003D8D RID: 15757 RVA: 0x00215A48 File Offset: 0x00214A48
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteDictionaryOpen();
			if (this.a != null)
			{
				writer.Document.RequireLicense(3);
				writer.WriteName(ImportFormDataAction.b);
				writer.WriteReferenceUnique(new bh(this.a));
			}
			writer.WriteName(Action.c);
			writer.WriteName(ImportFormDataAction.c);
			if (base.NextAction != null)
			{
				writer.WriteName(Action.d);
				base.NextAction.Draw(writer);
			}
			writer.WriteDictionaryClose();
		}

		// Token: 0x0400212E RID: 8494
		private new string a;

		// Token: 0x0400212F RID: 8495
		private new static byte b = 70;

		// Token: 0x04002130 RID: 8496
		private new static byte[] c = new byte[]
		{
			73,
			109,
			112,
			111,
			114,
			116,
			68,
			97,
			116,
			97
		};
	}
}
