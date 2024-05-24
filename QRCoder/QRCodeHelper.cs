using System;
using System.Drawing;

namespace QRCoder
{
	// Token: 0x02000015 RID: 21
	public static class QRCodeHelper
	{
		// Token: 0x06000057 RID: 87 RVA: 0x00004434 File Offset: 0x00002634
		public static Bitmap GetQRCode(string plainText, int pixelsPerModule, Color darkColor, Color lightColor, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, Bitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true)
		{
			Bitmap graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (QRCode qrcode = new QRCode(qrcodeData))
					{
						graphic = qrcode.GetGraphic(pixelsPerModule, darkColor, lightColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones, null);
					}
				}
			}
			return graphic;
		}
	}
}
