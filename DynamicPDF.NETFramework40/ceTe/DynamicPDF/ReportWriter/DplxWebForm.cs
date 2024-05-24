using System;
using System.IO;
using System.Web;
using System.Web.UI;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000818 RID: 2072
	public class DplxWebForm : Page
	{
		// Token: 0x060053E3 RID: 21475 RVA: 0x002931F0 File Offset: 0x002921F0
		protected void DrawPdfToWeb()
		{
			base.Visible = false;
			Document document = this.DocumentLayout.Run(this.b);
			document.DrawToWeb();
		}

		// Token: 0x060053E4 RID: 21476 RVA: 0x00293220 File Offset: 0x00292220
		protected void DrawPdfToWeb(string downloadAsFileName)
		{
			base.Visible = false;
			Document document = this.DocumentLayout.Run(this.b);
			document.DrawToWeb(downloadAsFileName);
		}

		// Token: 0x060053E5 RID: 21477 RVA: 0x00293250 File Offset: 0x00292250
		protected void DrawPdfToWeb(bool allowBrowserCaching)
		{
			base.Visible = false;
			Document document = this.DocumentLayout.Run(this.b);
			HttpContext httpContext = HttpContext.Current;
			document.a(httpContext.Request, httpContext.Response, allowBrowserCaching, "DynamicPDF.pdf", false);
		}

		// Token: 0x060053E6 RID: 21478 RVA: 0x00293298 File Offset: 0x00292298
		protected void DrawPdfToWeb(string downloadAsFileName, bool forceDownload)
		{
			base.Visible = false;
			Document document = this.DocumentLayout.Run(this.b);
			document.DrawToWeb(downloadAsFileName, forceDownload);
		}

		// Token: 0x060053E7 RID: 21479 RVA: 0x002932CC File Offset: 0x002922CC
		protected void DrawPdfToWeb(bool allowBrowserCaching, string downloadAsFileName, bool forceDownload)
		{
			base.Visible = false;
			Document document = this.DocumentLayout.Run(this.b);
			HttpContext httpContext = HttpContext.Current;
			document.a(httpContext.Request, httpContext.Response, allowBrowserCaching, downloadAsFileName, forceDownload);
		}

		// Token: 0x060053E8 RID: 21480 RVA: 0x00293310 File Offset: 0x00292310
		protected byte[] DrawPdf()
		{
			Document document = this.DocumentLayout.Run(this.b);
			return document.Draw();
		}

		// Token: 0x060053E9 RID: 21481 RVA: 0x0029333C File Offset: 0x0029233C
		protected void DrawPdf(string filePath)
		{
			Document document = this.DocumentLayout.Run(this.b);
			document.Draw(filePath);
		}

		// Token: 0x060053EA RID: 21482 RVA: 0x00293364 File Offset: 0x00292364
		protected void DrawPdf(Stream stream)
		{
			Document document = this.DocumentLayout.Run(this.b);
			document.Draw(stream);
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x060053EB RID: 21483 RVA: 0x0029338C File Offset: 0x0029238C
		protected DocumentLayout DocumentLayout
		{
			get
			{
				if (this.a == null)
				{
					this.a = wr.a(this);
				}
				return this.a;
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x060053EC RID: 21484 RVA: 0x002933C0 File Offset: 0x002923C0
		protected ParameterDictionary Parameters
		{
			get
			{
				if (this.b == null)
				{
					this.b = new ParameterDictionary();
				}
				return this.b;
			}
		}

		// Token: 0x04002CF0 RID: 11504
		private DocumentLayout a = null;

		// Token: 0x04002CF1 RID: 11505
		private ParameterDictionary b = null;
	}
}
