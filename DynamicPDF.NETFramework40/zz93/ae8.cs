using System;
using ceTe.DynamicPDF.Xmp;

namespace zz93
{
	// Token: 0x020004A9 RID: 1193
	internal class ae8 : XmpSchema
	{
		// Token: 0x06003172 RID: 12658 RVA: 0x001BB80B File Offset: 0x001BA80B
		internal ae8()
		{
		}

		// Token: 0x06003173 RID: 12659 RVA: 0x001BB818 File Offset: 0x001BA818
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://ns.adobe.com/pdf/1.3/", "pdf", " ");
			if (xwriter.Keywords != null)
			{
				xwriter.Draw("\t\t<pdf:Keywords>" + x7.a(xwriter.Keywords) + "</pdf:Keywords>\n");
			}
			xwriter.Draw("\t\t<pdf:PDFVersion>" + xwriter.PdfVersion + "</pdf:PDFVersion>\n");
			xwriter.Draw("\t\t<pdf:Producer>" + x7.a(xwriter.Producer) + "</pdf:Producer>\n");
			xwriter.EndDescription();
		}
	}
}
