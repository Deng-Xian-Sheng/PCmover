using System;

namespace QRCoder
{
	// Token: 0x0200000B RID: 11
	public static class BitmapByteQRCodeHelper
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002D30 File Offset: 0x00000F30
		public static byte[] GetQRCode(string plainText, int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1)
		{
			byte[] graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (BitmapByteQRCode bitmapByteQRCode = new BitmapByteQRCode(qrcodeData))
					{
						graphic = bitmapByteQRCode.GetGraphic(pixelsPerModule, darkColorHtmlHex, lightColorHtmlHex);
					}
				}
			}
			return graphic;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002DB0 File Offset: 0x00000FB0
		public static byte[] GetQRCode(string txt, QRCodeGenerator.ECCLevel eccLevel, int size)
		{
			byte[] graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(txt, eccLevel, false, false, QRCodeGenerator.EciMode.Default, -1))
				{
					using (BitmapByteQRCode bitmapByteQRCode = new BitmapByteQRCode(qrcodeData))
					{
						graphic = bitmapByteQRCode.GetGraphic(size);
					}
				}
			}
			return graphic;
		}
	}
}
