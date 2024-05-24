using System;
using System.IO;
using System.Reflection;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using WizardModule.Properties;

namespace WizardModule.Engine.ClientReports.DynamicPdf
{
	// Token: 0x020000C4 RID: 196
	public class DynamicPdfReport : ClientReport
	{
		// Token: 0x06001040 RID: 4160 RVA: 0x00029E00 File Offset: 0x00028000
		static DynamicPdfReport()
		{
			Document.AddLicense("GEN10NPDJPNPODDnpQoNKRBGYjTCPG/Cb8JI0Yb80wVNq4CR3YtQjv3rSwDcCFruGZyhujcPsCbGOs7++sAfPJdIZ8yj/sVCCBug");
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x00029E10 File Offset: 0x00028010
		public DynamicPdfReport(IClientReportParameters parameters) : base(parameters)
		{
			this.NormalDynamicFont = this.GetFont(Resources.Report_PDF_Font_Normal, this.NormalDynamicFont);
			this.BoldDynamicFont = this.GetFont(Resources.Report_PDF_Font_Bold, this.BoldDynamicFont);
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x00029E74 File Offset: 0x00028074
		private Font GetFont(string fontString, Font defaultFont)
		{
			if (string.IsNullOrWhiteSpace(fontString))
			{
				return defaultFont;
			}
			PropertyInfo property = typeof(Font).GetProperty(fontString, BindingFlags.Static | BindingFlags.Public);
			if (property == null)
			{
				return defaultFont;
			}
			return (property.GetValue(null) as Font) ?? defaultFont;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x00029EBC File Offset: 0x000280BC
		public override bool GenerateReport()
		{
			string text = base.AppendExtension(this._reportData.FileName, ".pdf");
			if (!base.CreateFolderForFile(text))
			{
				this._ts.TraceInformation("CreateFolderForFile(\"" + text + "\") failed");
				return false;
			}
			bool result;
			try
			{
				Document document = this.CreateDynamicPdfDocument();
				if (document == null)
				{
					this._ts.TraceInformation("CreateDynamicPdfDocument failed");
					result = false;
				}
				else
				{
					document.Draw(text);
					result = true;
				}
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "GenerateReport");
				result = false;
			}
			return result;
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00029F58 File Offset: 0x00028158
		protected virtual Document CreateDynamicPdfDocument()
		{
			Document document = new Document();
			document.Title = base.Title;
			document.Subject = base.Subheading;
			document.Author = Resources.Report_Author;
			this.DefineCover(document);
			if (!this.AddContent(document))
			{
				document = null;
			}
			return document;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x00029FA1 File Offset: 0x000281A1
		protected float InchesToPoints(float inches)
		{
			return inches * 72f;
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x00029FAA File Offset: 0x000281AA
		protected float CmToPoints(float cm)
		{
			return cm * 28.35f;
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x00029FB4 File Offset: 0x000281B4
		protected float StringToPoints(string s)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				return 0f;
			}
			if (s.ToUpper().EndsWith("CM"))
			{
				float cm = Convert.ToSingle(s.Substring(0, s.Length - 2));
				return this.CmToPoints(cm);
			}
			return 0f;
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x06001048 RID: 4168 RVA: 0x0002A003 File Offset: 0x00028203
		// (set) Token: 0x06001049 RID: 4169 RVA: 0x0002A00B File Offset: 0x0002820B
		public Font NormalDynamicFont { get; set; } = Font.Helvetica;

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x0600104A RID: 4170 RVA: 0x0002A014 File Offset: 0x00028214
		// (set) Token: 0x0600104B RID: 4171 RVA: 0x0002A01C File Offset: 0x0002821C
		public Font BoldDynamicFont { get; set; } = Font.HelveticaBold;

		// Token: 0x0600104C RID: 4172 RVA: 0x0002A025 File Offset: 0x00028225
		protected Page CreatePage()
		{
			return new Page(PageSize.A4, 20f);
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x0002A034 File Offset: 0x00028234
		protected Table2 CreateFullTable(Page page)
		{
			return new Table2(0f, 0f, page.Dimensions.Body.Width, page.Dimensions.Body.Height)
			{
				Border = 
				{
					LineStyle = LineStyle.None,
					Width = new float?(0f)
				},
				CellDefault = 
				{
					Border = 
					{
						LineStyle = LineStyle.None,
						Width = new float?(0f)
					},
					Padding = new float?(0f),
					Font = this.NormalDynamicFont,
					FontSize = new float?(this._defaultFontSize)
				}
			};
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x0002A108 File Offset: 0x00028308
		protected virtual void DefineCover(Document document)
		{
			Page page = this.CreatePage();
			document.Pages.Add(page);
			Table2 table = this.CreateFullTable(page);
			table.CellDefault.Align = new TextAlign?(TextAlign.Center);
			table.Columns.Add(table.Width);
			table.Rows.Add(this.CmToPoints(10f));
			table.Rows.Add().Cells.Add(base.Title, this.BoldDynamicFont, new float?((float)16));
			table.Rows.Add().Cells.Add(base.Subheading, this.BoldDynamicFont, new float?((float)10));
			table.Rows.Add().Cells.Add(string.Format(Resources.Report_Subtitle_Date, this._summary.FinishTime.ToLongDateString()), this.BoldDynamicFont, new float?((float)10));
			table.Rows.Add(this.CmToPoints(10f));
			Row2 row = table.Rows.Add(30f);
			string text = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PdfLogo.png");
			if (File.Exists(text))
			{
				row.Cells.Add(new Image(text, 0f, 0f));
			}
			string report_Cover_Rendered = Resources.Report_Cover_Rendered;
			if (!string.IsNullOrWhiteSpace(report_Cover_Rendered))
			{
				Row2 row2 = table.Rows.Add();
				row2.CellDefault.Align = new TextAlign?(TextAlign.Left);
				DateTime now = DateTime.Now;
				row2.Cells.Add(string.Concat(new string[]
				{
					report_Cover_Rendered,
					": ",
					now.ToShortDateString(),
					" ",
					now.ToShortTimeString()
				}), this.NormalDynamicFont, new float?((float)10));
			}
			page.Elements.Add(table);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x0002A2EE File Offset: 0x000284EE
		protected virtual bool AddContent(Document document)
		{
			this._ts.TraceCaller("Unimplemented", "AddContent");
			return false;
		}

		// Token: 0x04000582 RID: 1410
		protected float _defaultFontSize = 9f;
	}
}
