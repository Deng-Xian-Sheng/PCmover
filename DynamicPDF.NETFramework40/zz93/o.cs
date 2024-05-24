using System;
using System.Collections;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x02000011 RID: 17
	internal class o
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x0001D704 File Offset: 0x0001C704
		internal o(string A_0)
		{
			this.c = A_0;
			this.d = this.c();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0001D724 File Offset: 0x0001C724
		internal string d()
		{
			return this.e;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0001D73C File Offset: 0x0001C73C
		internal string e()
		{
			return this.c;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0001D754 File Offset: 0x0001C754
		internal BitArray f()
		{
			this.a = new BitArray(this.g(), true);
			this.b();
			foreach (int a_ in this.d)
			{
				this.c(a_);
			}
			this.b();
			this.a();
			return this.a;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0001D7BC File Offset: 0x0001C7BC
		internal int g()
		{
			return 9 + this.d.Length * 9 + 9 + 1;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0001D7E4 File Offset: 0x0001C7E4
		private int[] c()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < this.c.Length; i++)
			{
				byte b = (byte)this.c[i];
				if (o.g.ContainsKey(b))
				{
					string text = o.g[b];
					if (text[0] == '$')
					{
						list.Add(43);
					}
					else if (text[0] == '%')
					{
						list.Add(44);
					}
					else if (text[0] == '/')
					{
						list.Add(45);
					}
					else if (text[0] == '+')
					{
						list.Add(46);
					}
					list.Add(this.a((byte)text[1]));
				}
				else
				{
					list.Add(this.a(b));
				}
			}
			int num = 1;
			int num2 = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				num2 += list[i] * num++;
				if (num == 21)
				{
					num = 1;
				}
			}
			int num3 = num2 % 47;
			list.Add(num3);
			if (num3 != 43 && num3 != 44 && num3 != 45 && num3 != 46)
			{
				this.e += (char)this.d(num3);
			}
			num = 1;
			num2 = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				num2 += list[i] * num++;
				if (num == 16)
				{
					num = 1;
				}
			}
			int num4 = num2 % 47;
			list.Add(num4);
			if (num4 != 43 && num4 != 44 && num4 != 45 && num4 != 46)
			{
				this.e += (char)this.d(num4);
			}
			return list.ToArray();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0001DA30 File Offset: 0x0001CA30
		private byte d(int A_0)
		{
			foreach (KeyValuePair<byte, int> keyValuePair in o.f)
			{
				if (keyValuePair.Value == A_0)
				{
					return keyValuePair.Key;
				}
			}
			throw new ap("Invalid Code 93 character.");
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0001DAAC File Offset: 0x0001CAAC
		private int a(byte A_0)
		{
			if (o.f.ContainsKey(A_0))
			{
				return o.f[A_0];
			}
			throw new ap("Invalid Code 93 character.");
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0001DAE8 File Offset: 0x0001CAE8
		private void c(int A_0)
		{
			switch (A_0)
			{
			case 0:
				this.a(1);
				this.b(3);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(2);
				break;
			case 1:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(3);
				break;
			case 2:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(3);
				this.a(1);
				this.b(2);
				break;
			case 3:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(4);
				this.a(1);
				this.b(1);
				break;
			case 4:
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(3);
				break;
			case 5:
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(2);
				break;
			case 6:
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(3);
				this.a(1);
				this.b(1);
				break;
			case 7:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(4);
				break;
			case 8:
				this.a(1);
				this.b(3);
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(1);
				break;
			case 9:
				this.a(1);
				this.b(4);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 10:
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(3);
				break;
			case 11:
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(2);
				break;
			case 12:
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(3);
				this.a(1);
				this.b(1);
				break;
			case 13:
				this.a(2);
				this.b(2);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(2);
				break;
			case 14:
				this.a(2);
				this.b(2);
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(1);
				break;
			case 15:
				this.a(2);
				this.b(3);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 16:
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(3);
				break;
			case 17:
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(2);
				this.a(1);
				this.b(2);
				break;
			case 18:
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(3);
				this.a(1);
				this.b(1);
				break;
			case 19:
				this.a(1);
				this.b(2);
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(2);
				break;
			case 20:
				this.a(1);
				this.b(3);
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 21:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(3);
				break;
			case 22:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(2);
				this.a(2);
				this.b(2);
				break;
			case 23:
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(3);
				this.a(2);
				this.b(1);
				break;
			case 24:
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(2);
				break;
			case 25:
				this.a(1);
				this.b(3);
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(1);
				break;
			case 26:
				this.a(2);
				this.b(1);
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(2);
				break;
			case 27:
				this.a(2);
				this.b(1);
				this.a(2);
				this.b(2);
				this.a(1);
				this.b(1);
				break;
			case 28:
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(2);
				break;
			case 29:
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(2);
				this.a(2);
				this.b(1);
				break;
			case 30:
				this.a(2);
				this.b(2);
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(1);
				break;
			case 31:
				this.a(2);
				this.b(2);
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 32:
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(1);
				this.a(2);
				this.b(2);
				break;
			case 33:
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(2);
				this.a(2);
				this.b(1);
				break;
			case 34:
				this.a(1);
				this.b(2);
				this.a(2);
				this.b(1);
				this.a(2);
				this.b(1);
				break;
			case 35:
				this.a(1);
				this.b(2);
				this.a(3);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 36:
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(1);
				this.a(3);
				this.b(1);
				break;
			case 37:
				this.a(3);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(2);
				break;
			case 38:
				this.a(3);
				this.b(1);
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(1);
				break;
			case 39:
				this.a(3);
				this.b(2);
				this.a(1);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 40:
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(1);
				this.a(3);
				this.b(1);
				break;
			case 41:
				this.a(1);
				this.b(1);
				this.a(3);
				this.b(1);
				this.a(2);
				this.b(1);
				break;
			case 42:
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(3);
				this.b(1);
				break;
			case 43:
				this.a(1);
				this.b(2);
				this.a(1);
				this.b(2);
				this.a(2);
				this.b(1);
				break;
			case 44:
				this.a(3);
				this.b(1);
				this.a(2);
				this.b(1);
				this.a(1);
				this.b(1);
				break;
			case 45:
				this.a(3);
				this.b(1);
				this.a(1);
				this.b(1);
				this.a(2);
				this.b(1);
				break;
			case 46:
				this.a(1);
				this.b(2);
				this.a(2);
				this.b(2);
				this.a(1);
				this.b(1);
				break;
			default:
				throw new ap("Invalid Code 93 character.");
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0001E57C File Offset: 0x0001D57C
		private void b(int A_0)
		{
			for (int i = 0; i < A_0; i++)
			{
				this.a[this.b++] = true;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0001E5BC File Offset: 0x0001D5BC
		private void a(int A_0)
		{
			for (int i = 0; i < A_0; i++)
			{
				this.a[this.b++] = false;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0001E5FA File Offset: 0x0001D5FA
		private void b()
		{
			this.a(1);
			this.b(1);
			this.a(1);
			this.b(1);
			this.a(4);
			this.b(1);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0001E62D File Offset: 0x0001D62D
		private void a()
		{
			this.a(1);
		}

		// Token: 0x04000072 RID: 114
		private BitArray a;

		// Token: 0x04000073 RID: 115
		private int b;

		// Token: 0x04000074 RID: 116
		private string c;

		// Token: 0x04000075 RID: 117
		private int[] d;

		// Token: 0x04000076 RID: 118
		private string e;

		// Token: 0x04000077 RID: 119
		private static Dictionary<byte, int> f = new Dictionary<byte, int>
		{
			{
				48,
				0
			},
			{
				49,
				1
			},
			{
				50,
				2
			},
			{
				51,
				3
			},
			{
				52,
				4
			},
			{
				53,
				5
			},
			{
				54,
				6
			},
			{
				55,
				7
			},
			{
				56,
				8
			},
			{
				57,
				9
			},
			{
				65,
				10
			},
			{
				66,
				11
			},
			{
				67,
				12
			},
			{
				68,
				13
			},
			{
				69,
				14
			},
			{
				70,
				15
			},
			{
				71,
				16
			},
			{
				72,
				17
			},
			{
				73,
				18
			},
			{
				74,
				19
			},
			{
				75,
				20
			},
			{
				76,
				21
			},
			{
				77,
				22
			},
			{
				78,
				23
			},
			{
				79,
				24
			},
			{
				80,
				25
			},
			{
				81,
				26
			},
			{
				82,
				27
			},
			{
				83,
				28
			},
			{
				84,
				29
			},
			{
				85,
				30
			},
			{
				86,
				31
			},
			{
				87,
				32
			},
			{
				88,
				33
			},
			{
				89,
				34
			},
			{
				90,
				35
			},
			{
				45,
				36
			},
			{
				46,
				37
			},
			{
				32,
				38
			},
			{
				36,
				39
			},
			{
				47,
				40
			},
			{
				43,
				41
			},
			{
				37,
				42
			}
		};

		// Token: 0x04000078 RID: 120
		private static Dictionary<byte, string> g = new Dictionary<byte, string>
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
