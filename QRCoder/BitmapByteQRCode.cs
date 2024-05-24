using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QRCoder
{
	// Token: 0x0200000A RID: 10
	public class BitmapByteQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002B50 File Offset: 0x00000D50
		public BitmapByteQRCode()
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002B58 File Offset: 0x00000D58
		public BitmapByteQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002B61 File Offset: 0x00000D61
		public byte[] GetGraphic(int pixelsPerModule)
		{
			return this.GetGraphic(pixelsPerModule, new byte[3], new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002B81 File Offset: 0x00000D81
		public byte[] GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex)
		{
			return this.GetGraphic(pixelsPerModule, this.HexColorToByteArray(darkColorHtmlHex), this.HexColorToByteArray(lightColorHtmlHex));
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002B98 File Offset: 0x00000D98
		public byte[] GetGraphic(int pixelsPerModule, byte[] darkColorRgb, byte[] lightColorRgb)
		{
			int num = base.QrCodeData.ModuleMatrix.Count * pixelsPerModule;
			IEnumerable<byte> enumerable = darkColorRgb.Reverse<byte>();
			IEnumerable<byte> enumerable2 = lightColorRgb.Reverse<byte>();
			List<byte> list = new List<byte>();
			list.AddRange(new byte[]
			{
				66,
				77,
				76,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				26,
				0,
				0,
				0,
				12,
				0,
				0,
				0
			});
			list.AddRange(this.IntTo4Byte(num));
			list.AddRange(this.IntTo4Byte(num));
			List<byte> list2 = list;
			byte[] array = new byte[4];
			array[0] = 1;
			array[2] = 24;
			list2.AddRange(array);
			for (int i = num - 1; i >= 0; i -= pixelsPerModule)
			{
				for (int j = 0; j < pixelsPerModule; j++)
				{
					for (int k = 0; k < num; k += pixelsPerModule)
					{
						bool flag = base.QrCodeData.ModuleMatrix[(i + pixelsPerModule) / pixelsPerModule - 1][(k + pixelsPerModule) / pixelsPerModule - 1];
						for (int l = 0; l < pixelsPerModule; l++)
						{
							list.AddRange(flag ? enumerable : enumerable2);
						}
					}
					if (num % 4 != 0)
					{
						for (int m = 0; m < num % 4; m++)
						{
							list.Add(0);
						}
					}
				}
			}
			list.AddRange(new byte[2]);
			return list.ToArray();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002CC0 File Offset: 0x00000EC0
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

		// Token: 0x0600002B RID: 43 RVA: 0x00002D1C File Offset: 0x00000F1C
		private byte[] IntTo4Byte(int inp)
		{
			byte[] array = new byte[]
			{
				0,
				(byte)(inp >> 8)
			};
			array[0] = (byte)inp;
			return array;
		}
	}
}
