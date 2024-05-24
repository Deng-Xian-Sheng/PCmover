using System;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x0200091A RID: 2330
	public class PdfASchema : XmpSchema
	{
		// Token: 0x06005EF6 RID: 24310 RVA: 0x0035B9B9 File Offset: 0x0035A9B9
		public PdfASchema(PdfAStandard standard)
		{
			this.a = standard;
		}

		// Token: 0x06005EF7 RID: 24311 RVA: 0x0035B9D4 File Offset: 0x0035A9D4
		internal override bool j0()
		{
			return true;
		}

		// Token: 0x06005EF8 RID: 24312 RVA: 0x0035B9E8 File Offset: 0x0035A9E8
		internal PdfAStandard a()
		{
			return this.a;
		}

		// Token: 0x06005EF9 RID: 24313 RVA: 0x0035BA00 File Offset: 0x0035AA00
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://www.aiim.org/pdfa/ns/id/", "pdfaid", " ");
			if (this.a == PdfAStandard.PDF_A_1a_2005)
			{
				xwriter.Draw("\t\t<pdfaid:part>1</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>A</pdfaid:conformance>\n");
			}
			else if (this.a == PdfAStandard.PDF_A_1b_2005)
			{
				xwriter.Draw("\t\t<pdfaid:part>1</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>B</pdfaid:conformance>\n");
			}
			else if (this.a == PdfAStandard.PdfA2a)
			{
				xwriter.Draw("\t\t<pdfaid:part>2</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>A</pdfaid:conformance>\n");
			}
			else if (this.a == PdfAStandard.PdfA2b)
			{
				xwriter.Draw("\t\t<pdfaid:part>2</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>B</pdfaid:conformance>\n");
			}
			else if (this.a == PdfAStandard.PdfA2u)
			{
				xwriter.Draw("\t\t<pdfaid:part>2</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>U</pdfaid:conformance>\n");
			}
			else if (this.a == PdfAStandard.PdfA3a)
			{
				xwriter.Draw("\t\t<pdfaid:part>3</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>A</pdfaid:conformance>\n");
			}
			else if (this.a == PdfAStandard.PdfA3b)
			{
				xwriter.Draw("\t\t<pdfaid:part>3</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>B</pdfaid:conformance>\n");
			}
			else
			{
				xwriter.Draw("\t\t<pdfaid:part>3</pdfaid:part>\n");
				xwriter.Draw("\t\t<pdfaid:conformance>U</pdfaid:conformance>\n");
			}
			xwriter.EndDescription();
		}

		// Token: 0x040030D8 RID: 12504
		private PdfAStandard a = PdfAStandard.PDF_A_1b_2005;
	}
}
