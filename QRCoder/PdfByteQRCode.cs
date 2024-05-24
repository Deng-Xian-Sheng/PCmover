using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace QRCoder
{
	// Token: 0x0200000E RID: 14
	public class PdfByteQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x06000038 RID: 56 RVA: 0x000031B8 File Offset: 0x000013B8
		public PdfByteQRCode()
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000031D7 File Offset: 0x000013D7
		public PdfByteQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000031F7 File Offset: 0x000013F7
		public byte[] GetGraphic(int pixelsPerModule)
		{
			return this.GetGraphic(pixelsPerModule, "#000000", "#ffffff", 150, 85L);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003214 File Offset: 0x00001414
		private byte[] HexColorToByteArray(string colorString)
		{
			if (colorString.StartsWith("#"))
			{
				colorString = colorString.Substring(1);
			}
			byte[] array = new byte[colorString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte.Parse(colorString.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return array;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003270 File Offset: 0x00001470
		public byte[] GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, int dpi = 150, long jpgQuality = 85L)
		{
			byte[] array = null;
			byte[] array2 = null;
			int num = base.QrCodeData.ModuleMatrix.Count * pixelsPerModule;
			string text = (num * 72 / dpi).ToString(CultureInfo.InvariantCulture);
			using (PngByteQRCode pngByteQRCode = new PngByteQRCode(base.QrCodeData))
			{
				array2 = pngByteQRCode.GetGraphic(pixelsPerModule, this.HexColorToByteArray(darkColorHtmlHex), this.HexColorToByteArray(lightColorHtmlHex), true);
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(array2, 0, array2.Length);
				Image image = Image.FromStream(memoryStream);
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders().First((ImageCodecInfo x) => x.MimeType == "image/jpeg");
					EncoderParameters encoderParams = new EncoderParameters(1)
					{
						Param = new EncoderParameter[]
						{
							new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, jpgQuality)
						}
					};
					image.Save(memoryStream2, encoder, encoderParams);
					array = memoryStream2.ToArray();
				}
			}
			byte[] result;
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				StreamWriter streamWriter = new StreamWriter(memoryStream3, Encoding.GetEncoding("ASCII"));
				List<long> list = new List<long>();
				streamWriter.Write("%PDF-1.5\r\n");
				streamWriter.Flush();
				memoryStream3.Write(this.pdfBinaryComment, 0, this.pdfBinaryComment.Length);
				streamWriter.WriteLine();
				streamWriter.Flush();
				list.Add(memoryStream3.Position);
				streamWriter.Write(list.Count.ToString() + " 0 obj\r\n<<\r\n/Type /Catalog\r\n/Pages 2 0 R\r\n>>\r\nendobj\r\n");
				streamWriter.Flush();
				list.Add(memoryStream3.Position);
				streamWriter.Write(string.Concat(new string[]
				{
					list.Count.ToString(),
					" 0 obj\r\n<<\r\n/Count 1\r\n/Kids [ <<\r\n/Type /Page\r\n/Parent 2 0 R\r\n/MediaBox [0 0 ",
					text,
					" ",
					text,
					"]\r\n/Resources << /ProcSet [ /PDF /ImageC ]\r\n/XObject << /Im1 4 0 R >> >>\r\n/Contents 3 0 R\r\n>> ]\r\n>>\r\nendobj\r\n"
				}));
				string text2 = string.Concat(new string[]
				{
					"q\r\n",
					text,
					" 0 0 ",
					text,
					" 0 0 cm\r\n/Im1 Do\r\nQ"
				});
				streamWriter.Flush();
				list.Add(memoryStream3.Position);
				streamWriter.Write(string.Concat(new string[]
				{
					list.Count.ToString(),
					" 0 obj\r\n<< /Length ",
					text2.Length.ToString(),
					" >>\r\nstream\r\n",
					text2,
					"endstream\r\nendobj\r\n"
				}));
				streamWriter.Flush();
				list.Add(memoryStream3.Position);
				streamWriter.Write(string.Concat(new string[]
				{
					list.Count.ToString(),
					" 0 obj\r\n<<\r\n/Name /Im1\r\n/Type /XObject\r\n/Subtype /Image\r\n/Width ",
					num.ToString(),
					"/Height ",
					num.ToString(),
					"/Length 5 0 R\r\n/Filter /DCTDecode\r\n/ColorSpace /DeviceRGB\r\n/BitsPerComponent 8\r\n>>\r\nstream\r\n"
				}));
				streamWriter.Flush();
				memoryStream3.Write(array, 0, array.Length);
				streamWriter.Write("\r\nendstream\r\nendobj\r\n");
				streamWriter.Flush();
				list.Add(memoryStream3.Position);
				streamWriter.Write(list.Count.ToString() + " 0 obj\r\n" + array.Length.ToString() + " endobj\r\n");
				streamWriter.Flush();
				long position = memoryStream3.Position;
				streamWriter.Write("xref\r\n0 " + (list.Count + 1).ToString() + "\r\n0000000000 65535 f\r\n");
				foreach (long num2 in list)
				{
					streamWriter.Write(num2.ToString("0000000000") + " 00000 n\r\n");
				}
				streamWriter.Write(string.Concat(new string[]
				{
					"trailer\r\n<<\r\n/Size ",
					(list.Count + 1).ToString(),
					"\r\n/Root 1 0 R\r\n>>\r\nstartxref\r\n",
					position.ToString(),
					"\r\n%%EOF"
				}));
				streamWriter.Flush();
				memoryStream3.Position = 0L;
				result = memoryStream3.ToArray();
			}
			return result;
		}

		// Token: 0x04000005 RID: 5
		private readonly byte[] pdfBinaryComment = new byte[]
		{
			37,
			226,
			227,
			207,
			211
		};
	}
}
