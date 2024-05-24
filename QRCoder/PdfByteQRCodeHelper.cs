using System;

namespace QRCoder
{
	// Token: 0x0200000F RID: 15
	public static class PdfByteQRCodeHelper
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00003738 File Offset: 0x00001938
		public static byte[] GetQRCode(string plainText, int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1)
		{
			byte[] graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (PdfByteQRCode pdfByteQRCode = new PdfByteQRCode(qrcodeData))
					{
						graphic = pdfByteQRCode.GetGraphic(pixelsPerModule, darkColorHtmlHex, lightColorHtmlHex, 150, 85L);
					}
				}
			}
			return graphic;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000037C0 File Offset: 0x000019C0
		public static byte[] GetQRCode(string txt, QRCodeGenerator.ECCLevel eccLevel, int size)
		{
			byte[] graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(txt, eccLevel, false, false, QRCodeGenerator.EciMode.Default, -1))
				{
					using (PdfByteQRCode pdfByteQRCode = new PdfByteQRCode(qrcodeData))
					{
						graphic = pdfByteQRCode.GetGraphic(size);
					}
				}
			}
			return graphic;
		}
	}
}
