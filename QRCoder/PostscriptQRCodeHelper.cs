using System;

namespace QRCoder
{
	// Token: 0x02000013 RID: 19
	public static class PostscriptQRCodeHelper
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00003E3C File Offset: 0x0000203C
		public static string GetQRCode(string plainText, int pointsPerModule, string darkColorHex, string lightColorHex, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, bool epsFormat = false)
		{
			string graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (PostscriptQRCode postscriptQRCode = new PostscriptQRCode(qrcodeData))
					{
						graphic = postscriptQRCode.GetGraphic(pointsPerModule, darkColorHex, lightColorHex, drawQuietZones, epsFormat);
					}
				}
			}
			return graphic;
		}
	}
}
