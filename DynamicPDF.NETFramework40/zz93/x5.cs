using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200039A RID: 922
	internal struct x5
	{
		// Token: 0x06002761 RID: 10081 RVA: 0x0016ABB9 File Offset: 0x00169BB9
		public x5(float A_0)
		{
			this.b = (long)(A_0 * 10000f);
		}

		// Token: 0x06002762 RID: 10082 RVA: 0x0016ABCA File Offset: 0x00169BCA
		internal x5(long A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002763 RID: 10083 RVA: 0x0016ABD4 File Offset: 0x00169BD4
		public static x5 c()
		{
			return x5.c;
		}

		// Token: 0x06002764 RID: 10084 RVA: 0x0016ABEC File Offset: 0x00169BEC
		public static x5 b()
		{
			return x5.d;
		}

		// Token: 0x06002765 RID: 10085 RVA: 0x0016AC04 File Offset: 0x00169C04
		public static x5 a()
		{
			return x5.e;
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x0016AC1C File Offset: 0x00169C1C
		public override bool Equals(object obj)
		{
			bool result;
			try
			{
				result = (this.b == ((x5)obj).b);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002767 RID: 10087 RVA: 0x0016AC5C File Offset: 0x00169C5C
		public override string ToString()
		{
			string text = (this.b / 10000L).ToString();
			int num = (int)(this.b % 10000L);
			string result;
			if (num == 0)
			{
				result = text;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder(text, text.Length + 5);
				stringBuilder.Append('.');
				stringBuilder.Append((char)(48 + num / 1000));
				num %= 1000;
				if (num == 0)
				{
					result = stringBuilder.ToString();
				}
				else
				{
					stringBuilder.Append((char)(48 + num / 100));
					num %= 100;
					if (num == 0)
					{
						result = stringBuilder.ToString();
					}
					else
					{
						stringBuilder.Append((char)(48 + num / 10));
						num %= 10;
						if (num == 0)
						{
							result = stringBuilder.ToString();
						}
						else
						{
							stringBuilder.Append((char)(48 + num));
							result = stringBuilder.ToString();
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06002768 RID: 10088 RVA: 0x0016AD58 File Offset: 0x00169D58
		public override int GetHashCode()
		{
			return this.b.GetHashCode();
		}

		// Token: 0x06002769 RID: 10089 RVA: 0x0016AD78 File Offset: 0x00169D78
		public static bool h(x5 A_0, x5 A_1)
		{
			return A_0.b == A_1.b;
		}

		// Token: 0x0600276A RID: 10090 RVA: 0x0016AD9C File Offset: 0x00169D9C
		public static bool g(x5 A_0, x5 A_1)
		{
			return A_0.b != A_1.b;
		}

		// Token: 0x0600276B RID: 10091 RVA: 0x0016ADC4 File Offset: 0x00169DC4
		public static x5 f(x5 A_0, x5 A_1)
		{
			return new x5(A_0.b + A_1.b);
		}

		// Token: 0x0600276C RID: 10092 RVA: 0x0016ADEC File Offset: 0x00169DEC
		public static x5 e(x5 A_0, x5 A_1)
		{
			return new x5(A_0.b - A_1.b);
		}

		// Token: 0x0600276D RID: 10093 RVA: 0x0016AE14 File Offset: 0x00169E14
		public static x5 d(x5 A_0)
		{
			return new x5(-A_0.b);
		}

		// Token: 0x0600276E RID: 10094 RVA: 0x0016AE34 File Offset: 0x00169E34
		public static x5 c(x5 A_0)
		{
			A_0.b += 10000L;
			return new x5(A_0.b);
		}

		// Token: 0x0600276F RID: 10095 RVA: 0x0016AE68 File Offset: 0x00169E68
		public static x5 b(x5 A_0, int A_1)
		{
			return new x5(A_0.b * (long)A_1);
		}

		// Token: 0x06002770 RID: 10096 RVA: 0x0016AE8C File Offset: 0x00169E8C
		public static x5 a(x5 A_0, int A_1)
		{
			return new x5(A_0.b / (long)A_1);
		}

		// Token: 0x06002771 RID: 10097 RVA: 0x0016AEB0 File Offset: 0x00169EB0
		public static bool d(x5 A_0, x5 A_1)
		{
			return A_0.b < A_1.b;
		}

		// Token: 0x06002772 RID: 10098 RVA: 0x0016AED4 File Offset: 0x00169ED4
		public static bool c(x5 A_0, x5 A_1)
		{
			return A_0.b > A_1.b;
		}

		// Token: 0x06002773 RID: 10099 RVA: 0x0016AEF8 File Offset: 0x00169EF8
		public static bool b(x5 A_0, x5 A_1)
		{
			return A_0.b <= A_1.b;
		}

		// Token: 0x06002774 RID: 10100 RVA: 0x0016AF20 File Offset: 0x00169F20
		public static bool a(x5 A_0, x5 A_1)
		{
			return A_0.b >= A_1.b;
		}

		// Token: 0x06002775 RID: 10101 RVA: 0x0016AF48 File Offset: 0x00169F48
		public static x5 a(float A_0)
		{
			return new x5((long)(A_0 * 10000f));
		}

		// Token: 0x06002776 RID: 10102 RVA: 0x0016AF68 File Offset: 0x00169F68
		public static x5 a(double A_0)
		{
			return new x5((long)(A_0 * 10000.0));
		}

		// Token: 0x06002777 RID: 10103 RVA: 0x0016AF8C File Offset: 0x00169F8C
		public static float b(x5 A_0)
		{
			return (float)A_0.b / 10000f;
		}

		// Token: 0x06002778 RID: 10104 RVA: 0x0016AFAC File Offset: 0x00169FAC
		public static double a(x5 A_0)
		{
			return (double)A_0.b / 10000.0;
		}

		// Token: 0x04001113 RID: 4371
		private const long a = 10000L;

		// Token: 0x04001114 RID: 4372
		private long b;

		// Token: 0x04001115 RID: 4373
		private static readonly x5 c = new x5(0L);

		// Token: 0x04001116 RID: 4374
		private static readonly x5 d = new x5(long.MaxValue);

		// Token: 0x04001117 RID: 4375
		private static readonly x5 e = new x5(long.MinValue);
	}
}
