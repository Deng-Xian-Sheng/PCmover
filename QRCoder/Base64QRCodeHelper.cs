using System;

namespace QRCoder
{
	// Token: 0x02000009 RID: 9
	public static class Base64QRCodeHelper
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002ACC File Offset: 0x00000CCC
		public static string GetQRCode(string plainText, int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, Base64QRCode.ImageType imgType = Base64QRCode.ImageType.Png)
		{
			string graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (Base64QRCode base64QRCode = new Base64QRCode(qrcodeData))
					{
						graphic = base64QRCode.GetGraphic(pixelsPerModule, darkColorHtmlHex, lightColorHtmlHex, drawQuietZones, imgType);
					}
				}
			}
			return graphic;
		}
	}
}
