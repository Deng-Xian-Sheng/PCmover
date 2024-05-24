using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace zz93
{
	// Token: 0x020002B5 RID: 693
	internal class r3
	{
		// Token: 0x06001FE0 RID: 8160
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr A_0, IntPtr A_1);

		// Token: 0x06001FE1 RID: 8161
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DeleteObject(IntPtr A_0);

		// Token: 0x06001FE2 RID: 8162
		[DllImport("gdi32.dll")]
		private static extern uint GetFontData(IntPtr A_0, uint A_1, uint A_2, [Out] byte[] A_3, uint A_4);

		// Token: 0x06001FE3 RID: 8163 RVA: 0x0013ABF0 File Offset: 0x00139BF0
		[SecurityCritical]
		internal static string a(Font A_0)
		{
			string result = null;
			using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
			{
				IntPtr hdc = graphics.GetHdc();
				IntPtr intPtr = A_0.ToHfont();
				r3.SelectObject(hdc, intPtr);
				byte[] a_ = null;
				uint fontData = r3.GetFontData(hdc, 1701667182U, 0U, a_, 0U);
				byte[] array = new byte[fontData];
				r3.GetFontData(hdc, 1701667182U, 0U, array, fontData);
				result = r3.a(array);
				r3.DeleteObject(intPtr);
				graphics.ReleaseHdc(hdc);
			}
			return result;
		}

		// Token: 0x06001FE4 RID: 8164 RVA: 0x0013AC98 File Offset: 0x00139C98
		private static string a(byte[] A_0)
		{
			string text = null;
			int num = r3.a(A_0, 4);
			int num2 = 6;
			int num3 = r3.a(A_0, 2) * 12;
			Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
			for (int i = num2; i < num3; i += 12)
			{
				if (r3.a(A_0, i + 6) == 4)
				{
					int num4 = r3.a(A_0, i);
					int num5 = r3.a(A_0, i + 2);
					int num6 = r3.a(A_0, i + 4);
					if (num4 == 3 && num6 == 1033 && (num5 == 1 || num5 == 0))
					{
						text = bigEndianUnicode.GetString(A_0, num + r3.a(A_0, i + 10), r3.a(A_0, i + 8)).Trim().Replace(" ", string.Empty);
						text = text.Replace("-", string.Empty);
						break;
					}
				}
			}
			return text;
		}

		// Token: 0x06001FE5 RID: 8165 RVA: 0x0013AD98 File Offset: 0x00139D98
		private static int a(byte[] A_0, int A_1)
		{
			return (int)A_0[A_1++] << 8 | (int)A_0[A_1];
		}
	}
}
