using System;
using System.Collections.Generic;
using System.Text;

namespace zz93
{
	// Token: 0x02000022 RID: 34
	internal abstract class af
	{
		// Token: 0x0600014C RID: 332 RVA: 0x00026DE0 File Offset: 0x00025DE0
		internal static Encoding a(ref int A_0)
		{
			switch (A_0)
			{
			case 0:
			case 2:
				return ae5.a(437);
			case 1:
			case 3:
				return ae5.a(28591);
			case 4:
				return ae5.a(28592);
			case 5:
				return ae5.a(28593);
			case 6:
				return ae5.a(28594);
			case 7:
				return ae5.a(28595);
			case 8:
				return ae5.a(28596);
			case 9:
				return ae5.a(28597);
			case 10:
				return ae5.a(28598);
			case 11:
				return ae5.a(28599);
			case 13:
				return ae5.a(874);
			case 15:
				return ae5.a(28603);
			case 17:
				return ae5.a(28605);
			case 20:
				return ae5.a(932);
			case 21:
				return ae5.a(1250);
			case 22:
				return ae5.a(1251);
			case 23:
				return ae5.a(1252);
			case 24:
				return ae5.a(1256);
			case 25:
				return ae5.a(1201);
			case 27:
				return ae5.a(20127);
			case 28:
				return ae5.a(950);
			case 29:
				return ae5.a(936);
			case 30:
				return ae5.a(949);
			}
			A_0 = 26;
			return ae5.a(65001);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00026FE0 File Offset: 0x00025FE0
		internal static byte[] a(string A_0, bool A_1)
		{
			int num = 0;
			Encoding encoding = af.a(ref num);
			byte[] result;
			if (A_1 && !string.IsNullOrEmpty(A_0))
			{
				List<byte> list = new List<byte>();
				List<string> list2 = new List<string>();
				do
				{
					list2.Add(af.a(ref A_0));
				}
				while (A_0.Length > 0);
				foreach (string text in list2)
				{
					int num2 = 0;
					if ((byte)text[num2] == 126 && (byte)text[num2 + 1] == 50)
					{
						list.Add((byte)text[num2++]);
						list.Add((byte)text[num2++]);
						string text2 = string.Empty;
						for (int i = num2; i < num2 + 6; i++)
						{
							if ((byte)text[i] <= 47 || (byte)text[i] >= 58)
							{
								throw new an("ECI number must be 6 digits long.");
							}
							text2 += (int)((byte)text[i] - 48);
						}
						int num3 = int.Parse(text2);
						encoding = af.a(ref num3);
						string text3 = num3.ToString().PadLeft(6, '0');
						for (int i = 0; i < text3.Length; i++)
						{
							list.Add((byte)text3[i]);
						}
						num2 += 6;
						list.AddRange(encoding.GetBytes(text.Substring(num2)));
					}
					else
					{
						list.AddRange(encoding.GetBytes(text));
					}
				}
				result = list.ToArray();
			}
			else
			{
				result = encoding.GetBytes(A_0);
			}
			return result;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00027200 File Offset: 0x00026200
		private static string a(ref string A_0)
		{
			int num = 0;
			bool flag = false;
			if (A_0.StartsWith("~2"))
			{
				num++;
				flag = true;
			}
			int num2 = A_0.IndexOf("~2", num);
			if (num2 == -1)
			{
				num2 = A_0.Length;
			}
			num = (flag ? (num - 1) : num);
			string result = A_0.Substring(num, num2 - num);
			num = num2;
			A_0 = A_0.Substring(num);
			return result;
		}
	}
}
