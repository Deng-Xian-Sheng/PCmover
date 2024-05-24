using System;
using System.Drawing;
using System.Globalization;

namespace QRCoder
{
	// Token: 0x02000012 RID: 18
	public class PostscriptQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00003B34 File Offset: 0x00001D34
		public PostscriptQRCode()
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003B3C File Offset: 0x00001D3C
		public PostscriptQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003B48 File Offset: 0x00001D48
		public string GetGraphic(int pointsPerModule, bool epsFormat = false)
		{
			Size viewBox = new Size(pointsPerModule * base.QrCodeData.ModuleMatrix.Count, pointsPerModule * base.QrCodeData.ModuleMatrix.Count);
			return this.GetGraphic(viewBox, Color.Black, Color.White, true, epsFormat);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003B94 File Offset: 0x00001D94
		public string GetGraphic(int pointsPerModule, Color darkColor, Color lightColor, bool drawQuietZones = true, bool epsFormat = false)
		{
			Size viewBox = new Size(pointsPerModule * base.QrCodeData.ModuleMatrix.Count, pointsPerModule * base.QrCodeData.ModuleMatrix.Count);
			return this.GetGraphic(viewBox, darkColor, lightColor, drawQuietZones, epsFormat);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003BDC File Offset: 0x00001DDC
		public string GetGraphic(int pointsPerModule, string darkColorHex, string lightColorHex, bool drawQuietZones = true, bool epsFormat = false)
		{
			Size viewBox = new Size(pointsPerModule * base.QrCodeData.ModuleMatrix.Count, pointsPerModule * base.QrCodeData.ModuleMatrix.Count);
			return this.GetGraphic(viewBox, darkColorHex, lightColorHex, drawQuietZones, epsFormat);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003C21 File Offset: 0x00001E21
		public string GetGraphic(Size viewBox, bool drawQuietZones = true, bool epsFormat = false)
		{
			return this.GetGraphic(viewBox, Color.Black, Color.White, drawQuietZones, epsFormat);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003C36 File Offset: 0x00001E36
		public string GetGraphic(Size viewBox, string darkColorHex, string lightColorHex, bool drawQuietZones = true, bool epsFormat = false)
		{
			return this.GetGraphic(viewBox, ColorTranslator.FromHtml(darkColorHex), ColorTranslator.FromHtml(lightColorHex), drawQuietZones, epsFormat);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003C50 File Offset: 0x00001E50
		public string GetGraphic(Size viewBox, Color darkColor, Color lightColor, bool drawQuietZones = true, bool epsFormat = false)
		{
			int num = drawQuietZones ? 0 : 4;
			int num2 = base.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : (num * 2));
			double input = (double)Math.Min(viewBox.Width, viewBox.Height) / (double)num2;
			string str = string.Format("%!PS-Adobe-3.0 {3}\r\n%%Creator: QRCoder.NET\r\n%%Title: QRCode\r\n%%CreationDate: {0}\r\n%%DocumentData: Clean7Bit\r\n%%Origin: 0\r\n%%DocumentMedia: Default {1} {1} 0 () ()\r\n%%BoundingBox: 0 0 {1} {1}\r\n%%LanguageLevel: 2 \r\n%%Pages: 1\r\n%%Page: 1 1\r\n%%EndComments\r\n%%BeginConstants\r\n/sz {1} def\r\n/sc {2} def\r\n%%EndConstants\r\n%%BeginFeature: *PageSize Default\r\n<< /PageSize [ sz sz ] /ImagingBBox null >> setpagedevice\r\n%%EndFeature\r\n", new object[]
			{
				DateTime.Now.ToString("s"),
				this.CleanSvgVal((double)viewBox.Width),
				this.CleanSvgVal(input),
				epsFormat ? "EPSF-3.0" : string.Empty
			});
			str += string.Format("%%BeginFunctions \r\n/csquare {{\r\n    newpath\r\n    0 0 moveto\r\n    0 1 rlineto\r\n    1 0 rlineto\r\n    0 -1 rlineto\r\n    closepath\r\n    setrgbcolor\r\n    fill\r\n}} def\r\n/f {{ \r\n    {0} {1} {2} csquare\r\n    1 0 translate\r\n}} def\r\n/b {{ \r\n    1 0 translate\r\n}} def \r\n/background {{ \r\n    {3} {4} {5} csquare \r\n}} def\r\n/nl {{\r\n    -{6} -1 translate\r\n}} def\r\n%%EndFunctions\r\n%%BeginBody\r\n0 0 moveto\r\ngsave\r\nsz sz scale\r\nbackground\r\ngrestore\r\ngsave\r\nsc sc scale\r\n0 {6} 1 sub translate\r\n", new object[]
			{
				this.CleanSvgVal((double)darkColor.R / 255.0),
				this.CleanSvgVal((double)darkColor.G / 255.0),
				this.CleanSvgVal((double)darkColor.B / 255.0),
				this.CleanSvgVal((double)lightColor.R / 255.0),
				this.CleanSvgVal((double)lightColor.G / 255.0),
				this.CleanSvgVal((double)lightColor.B / 255.0),
				num2
			});
			for (int i = num; i < num + num2; i++)
			{
				if (i > num)
				{
					str += "nl\n";
				}
				for (int j = num; j < num + num2; j++)
				{
					str += (base.QrCodeData.ModuleMatrix[i][j] ? "f " : "b ");
				}
				str += "\n";
			}
			return str + "%%EndBody\r\ngrestore\r\nshowpage   \r\n%%EOF\r\n";
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003E2B File Offset: 0x0000202B
		private string CleanSvgVal(double input)
		{
			return input.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04000006 RID: 6
		private const string psHeader = "%!PS-Adobe-3.0 {3}\r\n%%Creator: QRCoder.NET\r\n%%Title: QRCode\r\n%%CreationDate: {0}\r\n%%DocumentData: Clean7Bit\r\n%%Origin: 0\r\n%%DocumentMedia: Default {1} {1} 0 () ()\r\n%%BoundingBox: 0 0 {1} {1}\r\n%%LanguageLevel: 2 \r\n%%Pages: 1\r\n%%Page: 1 1\r\n%%EndComments\r\n%%BeginConstants\r\n/sz {1} def\r\n/sc {2} def\r\n%%EndConstants\r\n%%BeginFeature: *PageSize Default\r\n<< /PageSize [ sz sz ] /ImagingBBox null >> setpagedevice\r\n%%EndFeature\r\n";

		// Token: 0x04000007 RID: 7
		private const string psFunctions = "%%BeginFunctions \r\n/csquare {{\r\n    newpath\r\n    0 0 moveto\r\n    0 1 rlineto\r\n    1 0 rlineto\r\n    0 -1 rlineto\r\n    closepath\r\n    setrgbcolor\r\n    fill\r\n}} def\r\n/f {{ \r\n    {0} {1} {2} csquare\r\n    1 0 translate\r\n}} def\r\n/b {{ \r\n    1 0 translate\r\n}} def \r\n/background {{ \r\n    {3} {4} {5} csquare \r\n}} def\r\n/nl {{\r\n    -{6} -1 translate\r\n}} def\r\n%%EndFunctions\r\n%%BeginBody\r\n0 0 moveto\r\ngsave\r\nsz sz scale\r\nbackground\r\ngrestore\r\ngsave\r\nsc sc scale\r\n0 {6} 1 sub translate\r\n";

		// Token: 0x04000008 RID: 8
		private const string psFooter = "%%EndBody\r\ngrestore\r\nshowpage   \r\n%%EOF\r\n";
	}
}
