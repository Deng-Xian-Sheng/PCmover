using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCoder
{
	// Token: 0x02000008 RID: 8
	public class Base64QRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002940 File Offset: 0x00000B40
		public Base64QRCode()
		{
			this.qr = new QRCode();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002953 File Offset: 0x00000B53
		public Base64QRCode(QRCodeData data) : base(data)
		{
			this.qr = new QRCode(data);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002968 File Offset: 0x00000B68
		public override void SetQRCodeData(QRCodeData data)
		{
			this.qr.SetQRCodeData(data);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002976 File Offset: 0x00000B76
		public string GetGraphic(int pixelsPerModule)
		{
			return this.GetGraphic(pixelsPerModule, Color.Black, Color.White, true, Base64QRCode.ImageType.Png);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000298B File Offset: 0x00000B8B
		public string GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, bool drawQuietZones = true, Base64QRCode.ImageType imgType = Base64QRCode.ImageType.Png)
		{
			return this.GetGraphic(pixelsPerModule, ColorTranslator.FromHtml(darkColorHtmlHex), ColorTranslator.FromHtml(lightColorHtmlHex), drawQuietZones, imgType);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000029A4 File Offset: 0x00000BA4
		public string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, bool drawQuietZones = true, Base64QRCode.ImageType imgType = Base64QRCode.ImageType.Png)
		{
			string result = string.Empty;
			using (Bitmap graphic = this.qr.GetGraphic(pixelsPerModule, darkColor, lightColor, drawQuietZones))
			{
				result = this.BitmapToBase64(graphic, imgType);
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000029F0 File Offset: 0x00000BF0
		public string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, Bitmap icon, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true, Base64QRCode.ImageType imgType = Base64QRCode.ImageType.Png)
		{
			string result = string.Empty;
			using (Bitmap graphic = this.qr.GetGraphic(pixelsPerModule, darkColor, lightColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones, null))
			{
				result = this.BitmapToBase64(graphic, imgType);
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002A4C File Offset: 0x00000C4C
		private string BitmapToBase64(Bitmap bmp, Base64QRCode.ImageType imgType)
		{
			string result = string.Empty;
			ImageFormat format;
			switch (imgType)
			{
			case Base64QRCode.ImageType.Gif:
				format = ImageFormat.Gif;
				break;
			case Base64QRCode.ImageType.Jpeg:
				format = ImageFormat.Jpeg;
				break;
			case Base64QRCode.ImageType.Png:
				format = ImageFormat.Png;
				break;
			default:
				format = ImageFormat.Png;
				break;
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bmp.Save(memoryStream, format);
				result = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.None);
			}
			return result;
		}

		// Token: 0x04000004 RID: 4
		private QRCode qr;

		// Token: 0x02000021 RID: 33
		public enum ImageType
		{
			// Token: 0x04000030 RID: 48
			Gif,
			// Token: 0x04000031 RID: 49
			Jpeg,
			// Token: 0x04000032 RID: 50
			Png
		}
	}
}
