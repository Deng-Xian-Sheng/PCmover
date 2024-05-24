using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace zz93
{
	// Token: 0x020000A4 RID: 164
	internal class dr
	{
		// Token: 0x060007DD RID: 2013 RVA: 0x0007112D File Offset: 0x0007012D
		internal dr(string A_0, float A_1, float A_2)
		{
			this.f = A_1;
			this.e = A_2;
			this.g = A_0.ToCharArray();
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00071164 File Offset: 0x00070164
		internal float c()
		{
			return this.f;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0007117C File Offset: 0x0007017C
		internal BitArray d()
		{
			int length = this.b();
			string text = this.a();
			this.a = new BitArray(length, true);
			if (text[0] != '*')
			{
				this.a(42, ref this.f);
			}
			foreach (byte a_ in text)
			{
				this.a(a_, ref this.f);
			}
			if (text[text.Length - 1] != '*')
			{
				this.a(42, ref this.f);
			}
			return this.a;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00071234 File Offset: 0x00070234
		internal float e()
		{
			return (float)this.b() * this.e;
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x00071254 File Offset: 0x00070254
		private int b()
		{
			string text = this.a();
			int num = text.Length;
			if (text[0] != '*')
			{
				num++;
			}
			if (text[text.Length - 1] != '*')
			{
				num++;
			}
			return num * 16 - 1;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x000712A8 File Offset: 0x000702A8
		private string a()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in this.g)
			{
				if (dr.i.ContainsKey((byte)c))
				{
					stringBuilder.Append(dr.i[(byte)c]);
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00071320 File Offset: 0x00070320
		private void a(byte A_0, ref float A_1)
		{
			if (A_0 >= 97 && A_0 <= 122)
			{
				A_0 -= 32;
			}
			if (A_0 > 90 || A_0 < 32)
			{
				throw new ap("Invalid Code 3 of 9 character.");
			}
			int num = dr.h[(int)(A_0 - 32)];
			if (num == 0)
			{
				throw new ap("Invalid Code 3 of 9 character.");
			}
			int num2 = 256;
			for (;;)
			{
				if ((num & num2) == num2)
				{
					this.c(ref A_1);
				}
				else
				{
					this.a(ref A_1);
				}
				if (num2 == 1)
				{
					break;
				}
				num2 /= 2;
				if ((num & num2) == num2)
				{
					this.d(ref A_1);
				}
				else
				{
					this.b(ref A_1);
				}
				num2 /= 2;
			}
			this.b(ref A_1);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000713F9 File Offset: 0x000703F9
		private void d(ref float A_0)
		{
			A_0 += this.e * 3f;
			this.d = 3f;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00071418 File Offset: 0x00070418
		private void c(ref float A_0)
		{
			if (this.c)
			{
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.e * 3f;
				this.c = false;
			}
			else
			{
				int num = 0;
				while ((float)num < this.d)
				{
					this.a[this.b] = true;
					this.b++;
					num++;
				}
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.e * 3f;
			}
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00071501 File Offset: 0x00070501
		private void b(ref float A_0)
		{
			A_0 += this.e;
			this.d = 1f;
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0007151C File Offset: 0x0007051C
		private void a(ref float A_0)
		{
			if (this.c)
			{
				this.a[this.b] = false;
				this.b++;
				A_0 += this.e;
				this.c = false;
			}
			else
			{
				int num = 0;
				while ((float)num < this.d)
				{
					this.a[this.b] = true;
					this.b++;
					num++;
				}
				this.a[this.b] = false;
				this.b++;
				A_0 += this.e;
			}
		}

		// Token: 0x0400044C RID: 1100
		private BitArray a;

		// Token: 0x0400044D RID: 1101
		private int b;

		// Token: 0x0400044E RID: 1102
		private bool c = true;

		// Token: 0x0400044F RID: 1103
		private float d;

		// Token: 0x04000450 RID: 1104
		private float e = 1f;

		// Token: 0x04000451 RID: 1105
		private float f;

		// Token: 0x04000452 RID: 1106
		private char[] g;

		// Token: 0x04000453 RID: 1107
		private static int[] h = new int[]
		{
			196,
			0,
			0,
			0,
			168,
			42,
			0,
			0,
			0,
			0,
			148,
			138,
			0,
			133,
			388,
			162,
			52,
			289,
			97,
			352,
			49,
			304,
			112,
			37,
			292,
			100,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			265,
			73,
			328,
			25,
			280,
			88,
			13,
			268,
			76,
			28,
			259,
			67,
			322,
			19,
			274,
			82,
			7,
			262,
			70,
			22,
			385,
			193,
			448,
			145,
			400,
			208
		};

		// Token: 0x04000454 RID: 1108
		private static Dictionary<byte, string> i = new Dictionary<byte, string>
		{
			{
				0,
				"%U"
			},
			{
				1,
				"$A"
			},
			{
				2,
				"$B"
			},
			{
				3,
				"$C"
			},
			{
				4,
				"$D"
			},
			{
				5,
				"$E"
			},
			{
				6,
				"$F"
			},
			{
				7,
				"$G"
			},
			{
				8,
				"$H"
			},
			{
				9,
				"$I"
			},
			{
				10,
				"$J"
			},
			{
				11,
				"$K"
			},
			{
				12,
				"$L"
			},
			{
				13,
				"$M"
			},
			{
				14,
				"$N"
			},
			{
				15,
				"$O"
			},
			{
				16,
				"$P"
			},
			{
				17,
				"$Q"
			},
			{
				18,
				"$R"
			},
			{
				19,
				"$S"
			},
			{
				20,
				"$T"
			},
			{
				21,
				"$U"
			},
			{
				22,
				"$V"
			},
			{
				23,
				"$W"
			},
			{
				24,
				"$X"
			},
			{
				25,
				"$Y"
			},
			{
				26,
				"$Z"
			},
			{
				27,
				"%A"
			},
			{
				28,
				"%B"
			},
			{
				29,
				"%C"
			},
			{
				30,
				"%D"
			},
			{
				31,
				"%E"
			},
			{
				33,
				"/A"
			},
			{
				34,
				"/B"
			},
			{
				35,
				"/C"
			},
			{
				38,
				"/F"
			},
			{
				39,
				"/G"
			},
			{
				40,
				"/H"
			},
			{
				41,
				"/I"
			},
			{
				42,
				"/J"
			},
			{
				44,
				"/L"
			},
			{
				58,
				"/Z"
			},
			{
				59,
				"%F"
			},
			{
				60,
				"%G"
			},
			{
				61,
				"%H"
			},
			{
				62,
				"%I"
			},
			{
				63,
				"%J"
			},
			{
				64,
				"%V"
			},
			{
				91,
				"%K"
			},
			{
				92,
				"%L"
			},
			{
				93,
				"%M"
			},
			{
				94,
				"%N"
			},
			{
				95,
				"%O"
			},
			{
				96,
				"%W"
			},
			{
				97,
				"+A"
			},
			{
				98,
				"+B"
			},
			{
				99,
				"+C"
			},
			{
				100,
				"+D"
			},
			{
				101,
				"+E"
			},
			{
				102,
				"+F"
			},
			{
				103,
				"+G"
			},
			{
				104,
				"+H"
			},
			{
				105,
				"+I"
			},
			{
				106,
				"+J"
			},
			{
				107,
				"+K"
			},
			{
				108,
				"+L"
			},
			{
				109,
				"+M"
			},
			{
				110,
				"+N"
			},
			{
				111,
				"+O"
			},
			{
				112,
				"+P"
			},
			{
				113,
				"+Q"
			},
			{
				114,
				"+R"
			},
			{
				115,
				"+S"
			},
			{
				116,
				"+T"
			},
			{
				117,
				"+U"
			},
			{
				118,
				"+V"
			},
			{
				119,
				"+W"
			},
			{
				120,
				"+X"
			},
			{
				121,
				"+Y"
			},
			{
				122,
				"+Z"
			},
			{
				123,
				"%P"
			},
			{
				124,
				"%Q"
			},
			{
				125,
				"%R"
			},
			{
				126,
				"%S"
			},
			{
				127,
				"%T"
			}
		};
	}
}
