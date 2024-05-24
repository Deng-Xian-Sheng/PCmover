using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;
using QRCoder.Extensions;

namespace QRCoder
{
	// Token: 0x02000018 RID: 24
	public class SvgQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x06000093 RID: 147 RVA: 0x0000644F File Offset: 0x0000464F
		public SvgQRCode()
		{
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006457 File Offset: 0x00004657
		public SvgQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006460 File Offset: 0x00004660
		public string GetGraphic(int pixelsPerModule)
		{
			Size viewBox = new Size(pixelsPerModule * base.QrCodeData.ModuleMatrix.Count, pixelsPerModule * base.QrCodeData.ModuleMatrix.Count);
			return this.GetGraphic(viewBox, Color.Black, Color.White, true, SvgQRCode.SizingMode.WidthHeightAttribute, null);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000064AC File Offset: 0x000046AC
		public string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, bool drawQuietZones = true, SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute, SvgQRCode.SvgLogo logo = null)
		{
			int num = drawQuietZones ? 0 : 4;
			int num2 = base.QrCodeData.ModuleMatrix.Count * pixelsPerModule - num * 2 * pixelsPerModule;
			Size viewBox = new Size(num2, num2);
			return this.GetGraphic(viewBox, darkColor, lightColor, drawQuietZones, sizingMode, logo);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000064F4 File Offset: 0x000046F4
		public string GetGraphic(int pixelsPerModule, string darkColorHex, string lightColorHex, bool drawQuietZones = true, SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute, SvgQRCode.SvgLogo logo = null)
		{
			int num = drawQuietZones ? 0 : 4;
			int num2 = base.QrCodeData.ModuleMatrix.Count * pixelsPerModule - num * 2 * pixelsPerModule;
			Size viewBox = new Size(num2, num2);
			return this.GetGraphic(viewBox, darkColorHex, lightColorHex, drawQuietZones, sizingMode, logo);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000653B File Offset: 0x0000473B
		public string GetGraphic(Size viewBox, bool drawQuietZones = true, SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute, SvgQRCode.SvgLogo logo = null)
		{
			return this.GetGraphic(viewBox, Color.Black, Color.White, drawQuietZones, sizingMode, logo);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006552 File Offset: 0x00004752
		public string GetGraphic(Size viewBox, Color darkColor, Color lightColor, bool drawQuietZones = true, SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute, SvgQRCode.SvgLogo logo = null)
		{
			return this.GetGraphic(viewBox, ColorTranslator.ToHtml(Color.FromArgb(darkColor.ToArgb())), ColorTranslator.ToHtml(Color.FromArgb(lightColor.ToArgb())), drawQuietZones, sizingMode, logo);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006584 File Offset: 0x00004784
		public string GetGraphic(Size viewBox, string darkColorHex, string lightColorHex, bool drawQuietZones = true, SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute, SvgQRCode.SvgLogo logo = null)
		{
			int num = drawQuietZones ? 0 : 4;
			int num2 = base.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : (num * 2));
			double num3 = (double)Math.Min(viewBox.Width, viewBox.Height) / (double)num2;
			double input = (double)num2 * num3;
			string str = (sizingMode == SvgQRCode.SizingMode.WidthHeightAttribute) ? string.Format("width=\"{0}\" height=\"{1}\"", viewBox.Width, viewBox.Height) : string.Format("viewBox=\"0 0 {0} {1}\"", viewBox.Width, viewBox.Height);
			SvgQRCode.ImageAttributes? attr = null;
			if (logo != null)
			{
				attr = new SvgQRCode.ImageAttributes?(this.GetLogoAttributes(logo, viewBox));
			}
			int[,] array = new int[num2, num2];
			for (int i = 0; i < num2; i++)
			{
				BitArray bitArray = base.QrCodeData.ModuleMatrix[i + num];
				int num4 = -1;
				int num5 = 0;
				for (int j = 0; j < num2; j++)
				{
					array[i, j] = 0;
					if (bitArray[j + num] && (logo == null || !logo.FillLogoBackground() || !this.IsBlockedByLogo((double)(j + num) * num3, (double)(i + num) * num3, attr, num3)))
					{
						if (num4 == -1)
						{
							num4 = j;
						}
						num5++;
					}
					else if (num5 > 0)
					{
						array[i, num4] = num5;
						num4 = -1;
						num5 = 0;
					}
				}
				if (num5 > 0)
				{
					array[i, num4] = num5;
				}
			}
			StringBuilder stringBuilder = new StringBuilder("<svg version=\"1.1\" baseProfile=\"full\" shape-rendering=\"crispEdges\" " + str + " xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">");
			stringBuilder.AppendLine(string.Concat(new string[]
			{
				"<rect x=\"0\" y=\"0\" width=\"",
				this.CleanSvgVal(input),
				"\" height=\"",
				this.CleanSvgVal(input),
				"\" fill=\"",
				lightColorHex,
				"\" />"
			}));
			for (int k = 0; k < num2; k++)
			{
				double num6 = (double)k * num3;
				for (int l = 0; l < num2; l++)
				{
					int num7 = array[k, l];
					if (num7 > 0)
					{
						int num8 = 1;
						int num9 = k + 1;
						while (num9 < num2 && array[num9, l] == num7)
						{
							array[num9, l] = 0;
							num8++;
							num9++;
						}
						double num10 = (double)l * num3;
						if (logo == null || !logo.FillLogoBackground() || !this.IsBlockedByLogo(num10, num6, attr, num3))
						{
							stringBuilder.AppendLine(string.Concat(new string[]
							{
								"<rect x=\"",
								this.CleanSvgVal(num10),
								"\" y=\"",
								this.CleanSvgVal(num6),
								"\" width=\"",
								this.CleanSvgVal((double)num7 * num3),
								"\" height=\"",
								this.CleanSvgVal((double)num8 * num3),
								"\" fill=\"",
								darkColorHex,
								"\" />"
							}));
						}
					}
				}
			}
			if (logo != null)
			{
				if (!logo.IsEmbedded())
				{
					stringBuilder.AppendLine("<svg width=\"100%\" height=\"100%\" version=\"1.1\" xmlns = \"http://www.w3.org/2000/svg\">");
					stringBuilder.AppendLine(string.Concat(new string[]
					{
						"<image x=\"",
						this.CleanSvgVal(attr.Value.X),
						"\" y=\"",
						this.CleanSvgVal(attr.Value.Y),
						"\" width=\"",
						this.CleanSvgVal(attr.Value.Width),
						"\" height=\"",
						this.CleanSvgVal(attr.Value.Height),
						"\" xlink:href=\"",
						logo.GetDataUri(),
						"\" />"
					}));
					stringBuilder.AppendLine("</svg>");
				}
				else
				{
					XDocument xdocument = XDocument.Parse((string)logo.GetRawLogo());
					xdocument.Root.SetAttributeValue("x", this.CleanSvgVal(attr.Value.X));
					xdocument.Root.SetAttributeValue("y", this.CleanSvgVal(attr.Value.Y));
					xdocument.Root.SetAttributeValue("width", this.CleanSvgVal(attr.Value.Width));
					xdocument.Root.SetAttributeValue("height", this.CleanSvgVal(attr.Value.Height));
					xdocument.Root.SetAttributeValue("shape-rendering", "geometricPrecision");
					stringBuilder.AppendLine(xdocument.ToString(SaveOptions.DisableFormatting).Replace("svg:", ""));
				}
			}
			stringBuilder.Append("</svg>");
			return stringBuilder.ToString();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006A58 File Offset: 0x00004C58
		private bool IsBlockedByLogo(double x, double y, SvgQRCode.ImageAttributes? attr, double pixelPerModule)
		{
			return x + pixelPerModule >= attr.Value.X && x <= attr.Value.X + attr.Value.Width && y + pixelPerModule >= attr.Value.Y && y <= attr.Value.Y + attr.Value.Height;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006AC8 File Offset: 0x00004CC8
		private SvgQRCode.ImageAttributes GetLogoAttributes(SvgQRCode.SvgLogo logo, Size viewBox)
		{
			double num = (double)logo.GetIconSizePercent() / 100.0 * (double)viewBox.Width;
			double num2 = (double)logo.GetIconSizePercent() / 100.0 * (double)viewBox.Height;
			double x = (double)viewBox.Width / 2.0 - num / 2.0;
			double y = (double)viewBox.Height / 2.0 - num2 / 2.0;
			return new SvgQRCode.ImageAttributes
			{
				Width = num,
				Height = num2,
				X = x,
				Y = y
			};
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006B73 File Offset: 0x00004D73
		private string CleanSvgVal(double input)
		{
			return input.ToString("G15", CultureInfo.InvariantCulture);
		}

		// Token: 0x02000055 RID: 85
		private struct ImageAttributes
		{
			// Token: 0x04000113 RID: 275
			public double Width;

			// Token: 0x04000114 RID: 276
			public double Height;

			// Token: 0x04000115 RID: 277
			public double X;

			// Token: 0x04000116 RID: 278
			public double Y;
		}

		// Token: 0x02000056 RID: 86
		public enum SizingMode
		{
			// Token: 0x04000118 RID: 280
			WidthHeightAttribute,
			// Token: 0x04000119 RID: 281
			ViewBoxAttribute
		}

		// Token: 0x02000057 RID: 87
		public class SvgLogo
		{
			// Token: 0x06000176 RID: 374 RVA: 0x0000C02C File Offset: 0x0000A22C
			public SvgLogo(Bitmap iconRasterized, int iconSizePercent = 15, bool fillLogoBackground = true)
			{
				this._iconSizePercent = iconSizePercent;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (Bitmap bitmap = new Bitmap(iconRasterized))
					{
						bitmap.Save(memoryStream, ImageFormat.Png);
						this._logoData = Convert.ToBase64String(memoryStream.GetBuffer(), Base64FormattingOptions.None);
					}
				}
				this._mediaType = SvgQRCode.SvgLogo.MediaType.PNG;
				this._fillLogoBackground = fillLogoBackground;
				this._logoRaw = iconRasterized;
				this._isEmbedded = false;
			}

			// Token: 0x06000177 RID: 375 RVA: 0x0000C0C0 File Offset: 0x0000A2C0
			public SvgLogo(string iconVectorized, int iconSizePercent = 15, bool fillLogoBackground = true, bool iconEmbedded = true)
			{
				this._iconSizePercent = iconSizePercent;
				this._logoData = Convert.ToBase64String(Encoding.UTF8.GetBytes(iconVectorized), Base64FormattingOptions.None);
				this._mediaType = SvgQRCode.SvgLogo.MediaType.SVG;
				this._fillLogoBackground = fillLogoBackground;
				this._logoRaw = iconVectorized;
				this._isEmbedded = iconEmbedded;
			}

			// Token: 0x06000178 RID: 376 RVA: 0x0000C10E File Offset: 0x0000A30E
			public object GetRawLogo()
			{
				return this._logoRaw;
			}

			// Token: 0x06000179 RID: 377 RVA: 0x0000C116 File Offset: 0x0000A316
			public bool IsEmbedded()
			{
				return this._isEmbedded;
			}

			// Token: 0x0600017A RID: 378 RVA: 0x0000C11E File Offset: 0x0000A31E
			public SvgQRCode.SvgLogo.MediaType GetMediaType()
			{
				return this._mediaType;
			}

			// Token: 0x0600017B RID: 379 RVA: 0x0000C126 File Offset: 0x0000A326
			public string GetDataUri()
			{
				return "data:" + this._mediaType.GetStringValue() + ";base64," + this._logoData;
			}

			// Token: 0x0600017C RID: 380 RVA: 0x0000C14D File Offset: 0x0000A34D
			public int GetIconSizePercent()
			{
				return this._iconSizePercent;
			}

			// Token: 0x0600017D RID: 381 RVA: 0x0000C155 File Offset: 0x0000A355
			public bool FillLogoBackground()
			{
				return this._fillLogoBackground;
			}

			// Token: 0x0400011A RID: 282
			private string _logoData;

			// Token: 0x0400011B RID: 283
			private SvgQRCode.SvgLogo.MediaType _mediaType;

			// Token: 0x0400011C RID: 284
			private int _iconSizePercent;

			// Token: 0x0400011D RID: 285
			private bool _fillLogoBackground;

			// Token: 0x0400011E RID: 286
			private object _logoRaw;

			// Token: 0x0400011F RID: 287
			private bool _isEmbedded;

			// Token: 0x02000087 RID: 135
			public enum MediaType
			{
				// Token: 0x040002A0 RID: 672
				[StringValue("image/png")]
				PNG,
				// Token: 0x040002A1 RID: 673
				[StringValue("image/svg+xml")]
				SVG
			}
		}
	}
}
