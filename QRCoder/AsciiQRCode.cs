using System;
using System.Collections.Generic;
using System.Text;

namespace QRCoder
{
	// Token: 0x02000006 RID: 6
	public class AsciiQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x06000017 RID: 23 RVA: 0x0000279C File Offset: 0x0000099C
		public AsciiQRCode()
		{
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000027A4 File Offset: 0x000009A4
		public AsciiQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000027AD File Offset: 0x000009AD
		public string GetGraphic(int repeatPerModule, string darkColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true, string endOfLine = "\n")
		{
			return string.Join(endOfLine, this.GetLineByLineGraphic(repeatPerModule, darkColorString, whiteSpaceString, drawQuietZones));
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000027C4 File Offset: 0x000009C4
		public string[] GetLineByLineGraphic(int repeatPerModule, string darkColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true)
		{
			List<string> list = new List<string>();
			int num = drawQuietZones ? 0 : 8;
			int num2 = (int)((double)num * 0.5);
			int num3 = (darkColorString.Length / 2 != 1) ? (darkColorString.Length / 2) : 0;
			int num4 = repeatPerModule + num3;
			int num5 = (base.QrCodeData.ModuleMatrix.Count - num) * num4;
			for (int i = 0; i < num5; i++)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < base.QrCodeData.ModuleMatrix.Count - num; j++)
				{
					bool flag = base.QrCodeData.ModuleMatrix[j + num2][(i + num4) / num4 - 1 + num2];
					for (int k = 0; k < repeatPerModule; k++)
					{
						stringBuilder.Append(flag ? darkColorString : whiteSpaceString);
					}
				}
				list.Add(stringBuilder.ToString());
			}
			return list.ToArray();
		}
	}
}
