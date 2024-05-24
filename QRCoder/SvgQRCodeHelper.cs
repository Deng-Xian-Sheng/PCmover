using System;

namespace QRCoder
{
	// Token: 0x02000019 RID: 25
	public static class SvgQRCodeHelper
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00006B88 File Offset: 0x00004D88
		public static string GetQRCode(string plainText, int pixelsPerModule, string darkColorHex, string lightColorHex, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute, SvgQRCode.SvgLogo logo = null)
		{
			string graphic;
			using (QRCodeGenerator qrcodeGenerator = new QRCodeGenerator())
			{
				using (QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
				{
					using (SvgQRCode svgQRCode = new SvgQRCode(qrcodeData))
					{
						graphic = svgQRCode.GetGraphic(pixelsPerModule, darkColorHex, lightColorHex, drawQuietZones, sizingMode, logo);
					}
				}
			}
			return graphic;
		}
	}
}
