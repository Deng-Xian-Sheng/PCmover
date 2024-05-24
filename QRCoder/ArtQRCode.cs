using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QRCoder
{
	// Token: 0x02000004 RID: 4
	public class ArtQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000021B5 File Offset: 0x000003B5
		public ArtQRCode()
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021BD File Offset: 0x000003BD
		public ArtQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021C8 File Offset: 0x000003C8
		public Bitmap GetGraphic(int pixelsPerModule)
		{
			return this.GetGraphic(pixelsPerModule, Color.Black, Color.White, Color.Transparent, null, 0.8, true, ArtQRCode.QuietZoneStyle.Dotted, ArtQRCode.BackgroundImageStyle.DataAreaOnly, null);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021FC File Offset: 0x000003FC
		public Bitmap GetGraphic(Bitmap backgroundImage = null)
		{
			return this.GetGraphic(10, Color.Black, Color.White, Color.Transparent, backgroundImage, 0.8, true, ArtQRCode.QuietZoneStyle.Dotted, ArtQRCode.BackgroundImageStyle.DataAreaOnly, null);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002230 File Offset: 0x00000430
		public Bitmap GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, Color backgroundColor, Bitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, ArtQRCode.QuietZoneStyle quietZoneRenderingStyle = ArtQRCode.QuietZoneStyle.Dotted, ArtQRCode.BackgroundImageStyle backgroundImageStyle = ArtQRCode.BackgroundImageStyle.DataAreaOnly, Bitmap finderPatternImage = null)
		{
			if (pixelSizeFactor > 1.0)
			{
				throw new Exception("The parameter pixelSize must be between 0 and 1. (0-100%)");
			}
			int pixelSize = (int)Math.Min((double)pixelsPerModule, Math.Floor((double)pixelsPerModule / pixelSizeFactor));
			int num = base.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8);
			int num2 = drawQuietZones ? 0 : 4;
			int num3 = num * pixelsPerModule;
			Bitmap bitmap = new Bitmap(num3, num3);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				using (SolidBrush solidBrush = new SolidBrush(lightColor))
				{
					using (SolidBrush solidBrush2 = new SolidBrush(darkColor))
					{
						using (SolidBrush solidBrush3 = new SolidBrush(backgroundColor))
						{
							graphics.FillRectangle(solidBrush3, new Rectangle(0, 0, num3, num3));
						}
						if (backgroundImage != null)
						{
							if (backgroundImageStyle == ArtQRCode.BackgroundImageStyle.Fill)
							{
								graphics.DrawImage(this.Resize(backgroundImage, num3), 0, 0);
							}
							else if (backgroundImageStyle == ArtQRCode.BackgroundImageStyle.DataAreaOnly)
							{
								int num4 = 4 - num2;
								graphics.DrawImage(this.Resize(backgroundImage, num3 - 2 * num4 * pixelsPerModule), num4 * pixelsPerModule, num4 * pixelsPerModule);
							}
						}
						Bitmap bitmap2 = this.MakeDotPixel(pixelsPerModule, pixelSize, solidBrush2);
						Bitmap bitmap3 = this.MakeDotPixel(pixelsPerModule, pixelSize, solidBrush);
						for (int i = 0; i < num; i++)
						{
							for (int j = 0; j < num; j++)
							{
								Rectangle rect = new Rectangle(i * pixelsPerModule, j * pixelsPerModule, pixelsPerModule, pixelsPerModule);
								bool flag = base.QrCodeData.ModuleMatrix[num2 + j][num2 + i];
								SolidBrush brush = flag ? solidBrush2 : solidBrush;
								Bitmap image = flag ? bitmap2 : bitmap3;
								if (!this.IsPartOfFinderPattern(i, j, num, num2))
								{
									if (drawQuietZones && quietZoneRenderingStyle == ArtQRCode.QuietZoneStyle.Flat && this.IsPartOfQuietZone(i, j, num))
									{
										graphics.FillRectangle(brush, rect);
									}
									else
									{
										graphics.DrawImage(image, rect);
									}
								}
								else if (finderPatternImage == null)
								{
									graphics.FillRectangle(brush, rect);
								}
							}
						}
						if (finderPatternImage != null)
						{
							int num5 = 7 * pixelsPerModule;
							graphics.DrawImage(finderPatternImage, new Rectangle(0, 0, num5, num5));
							graphics.DrawImage(finderPatternImage, new Rectangle(num3 - num5, 0, num5, num5));
							graphics.DrawImage(finderPatternImage, new Rectangle(0, num3 - num5, num5, num5));
						}
						graphics.Save();
					}
				}
			}
			return bitmap;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000024D4 File Offset: 0x000006D4
		private Bitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SolidBrush brush)
		{
			Bitmap image = new Bitmap(pixelSize, pixelSize);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				graphics.FillEllipse(brush, new Rectangle(0, 0, pixelSize, pixelSize));
				graphics.Save();
			}
			int num = Math.Min(pixelsPerModule, pixelSize);
			int num2 = Math.Max((pixelsPerModule - num) / 2, 0);
			Bitmap bitmap = new Bitmap(pixelsPerModule, pixelsPerModule);
			using (Graphics graphics2 = Graphics.FromImage(bitmap))
			{
				graphics2.DrawImage(image, new Rectangle(num2, num2, num, num), new RectangleF(((float)pixelSize - (float)num) / 2f, ((float)pixelSize - (float)num) / 2f, (float)num, (float)num), GraphicsUnit.Pixel);
				graphics2.Save();
			}
			return bitmap;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000025A8 File Offset: 0x000007A8
		private bool IsPartOfQuietZone(int x, int y, int numModules)
		{
			return x < 4 || y < 4 || x > numModules - 5 || y > numModules - 5;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000025C0 File Offset: 0x000007C0
		private bool IsPartOfFinderPattern(int x, int y, int numModules, int offset)
		{
			int num = 11 - offset;
			int num2 = numModules - num - 1;
			int num3 = num2 + 8;
			int num4 = 4 - offset;
			return (x >= num4 && x < num && y >= num4 && y < num) || (x > num2 && x < num3 && y >= num4 && y < num) || (x >= num4 && x < num && y > num2 && y < num3);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002618 File Offset: 0x00000818
		private Bitmap Resize(Bitmap image, int newSize)
		{
			if (image == null)
			{
				return null;
			}
			float num = Math.Min((float)newSize / (float)image.Width, (float)newSize / (float)image.Height);
			int num2 = (int)((float)image.Width * num);
			int num3 = (int)((float)image.Height * num);
			int x = (newSize - num2) / 2;
			int y = (newSize - num3) / 2;
			Bitmap image2 = new Bitmap(image, new Size(num2, num3));
			Bitmap bitmap = new Bitmap(newSize, newSize);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				using (SolidBrush solidBrush = new SolidBrush(Color.Transparent))
				{
					graphics.FillRectangle(solidBrush, new Rectangle(0, 0, newSize, newSize));
					graphics.InterpolationMode = InterpolationMode.High;
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					graphics.DrawImage(image2, new Rectangle(x, y, num2, num3));
				}
			}
			return bitmap;
		}

		// Token: 0x0200001F RID: 31
		public enum QuietZoneStyle
		{
			// Token: 0x0400002A RID: 42
			Dotted,
			// Token: 0x0400002B RID: 43
			Flat
		}

		// Token: 0x02000020 RID: 32
		public enum BackgroundImageStyle
		{
			// Token: 0x0400002D RID: 45
			Fill,
			// Token: 0x0400002E RID: 46
			DataAreaOnly
		}
	}
}
