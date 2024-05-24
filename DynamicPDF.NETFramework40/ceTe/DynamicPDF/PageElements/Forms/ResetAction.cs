using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007F2 RID: 2034
	public class ResetAction : OutlineAnnotationAction
	{
		// Token: 0x0600529B RID: 21147 RVA: 0x0028E61C File Offset: 0x0028D61C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteDictionaryOpen();
			writer.WriteName(Action.c);
			writer.WriteName(ResetAction.a);
			if (base.NextAction != null)
			{
				writer.WriteName(Action.d);
				base.NextAction.Draw(writer);
			}
			writer.WriteDictionaryClose();
		}

		// Token: 0x04002C23 RID: 11299
		private new static byte[] a = new byte[]
		{
			82,
			101,
			115,
			101,
			116,
			70,
			111,
			114,
			109
		};
	}
}
