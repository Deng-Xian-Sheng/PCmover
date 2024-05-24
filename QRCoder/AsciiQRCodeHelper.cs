using System;

namespace QRCoder
{
	// Token: 0x02000007 RID: 7
	public static class AsciiQRCodeHelper
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000028BC File Offset: 0x00000ABC
		public static string GetQRCode(string plainText, int pixelsPerModule, string darkColorString, string whiteSpaceString, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, string endOfLine = "\n", bool drawQuietZones = true)
		{
			string graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (AsciiQRCode asciiQRCode = new AsciiQRCode(qrcodeData))
					{
						graphic = asciiQRCode.GetGraphic(pixelsPerModule, darkColorString, whiteSpaceString, drawQuietZones, endOfLine);
					}
				}
			}
			return graphic;
		}
	}
}
