using System;
using System.Drawing;

namespace QRCoder
{
	// Token: 0x02000005 RID: 5
	public static class ArtQRCodeHelper
	{
		// Token: 0x06000016 RID: 22 RVA: 0x0000270C File Offset: 0x0000090C
		public static Bitmap GetQRCode(string plainText, int pixelsPerModule, Color darkColor, Color lightColor, Color backgroundColor, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, Bitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, ArtQRCode.QuietZoneStyle quietZoneRenderingStyle = ArtQRCode.QuietZoneStyle.Flat, ArtQRCode.BackgroundImageStyle backgroundImageStyle = ArtQRCode.BackgroundImageStyle.DataAreaOnly, Bitmap finderPatternImage = null)
		{
			Bitmap graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (ArtQRCode artQRCode = new ArtQRCode(qrcodeData))
					{
						graphic = artQRCode.GetGraphic(pixelsPerModule, darkColor, lightColor, backgroundColor, backgroundImage, pixelSizeFactor, drawQuietZones, quietZoneRenderingStyle, backgroundImageStyle, finderPatternImage);
					}
				}
			}
			return graphic;
		}
	}
}
