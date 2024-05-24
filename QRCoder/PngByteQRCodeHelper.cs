using System;

namespace QRCoder
{
	// Token: 0x02000011 RID: 17
	public static class PngByteQRCodeHelper
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00003A34 File Offset: 0x00001C34
		public static byte[] GetQRCode(string plainText, int pixelsPerModule, byte[] darkColorRgba, byte[] lightColorRgba, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true)
		{
			byte[] graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (PngByteQRCode pngByteQRCode = new PngByteQRCode(qrcodeData))
					{
						graphic = pngByteQRCode.GetGraphic(pixelsPerModule, darkColorRgba, lightColorRgba, drawQuietZones);
					}
				}
			}
			return graphic;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003AB8 File Offset: 0x00001CB8
		public static byte[] GetQRCode(string txt, QRCodeGenerator.ECCLevel eccLevel, int size, bool drawQuietZones = true)
		{
			byte[] graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(txt, eccLevel, false, false, QRCodeGenerator.EciMode.Default, -1))
				{
					using (PngByteQRCode pngByteQRCode = new PngByteQRCode(qrcodeData))
					{
						graphic = pngByteQRCode.GetGraphic(size, drawQuietZones);
					}
				}
			}
			return graphic;
		}
	}
}
