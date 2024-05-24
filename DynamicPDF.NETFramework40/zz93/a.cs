using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace zz93
{
	// Token: 0x02000003 RID: 3
	internal class a
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00014058 File Offset: 0x00013058
		internal a(string A_0, b A_1)
		{
			this.i = A_0;
			this.e = A_1;
			this.e();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000140AC File Offset: 0x000130AC
		internal int f()
		{
			this.h = 0;
			this.g();
			return this.h / 3;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000140D4 File Offset: 0x000130D4
		internal BitArray g()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.c(this.a));
			stringBuilder.Append(this.c(this.b));
			if (this.f == zz93.c.a)
			{
				stringBuilder.Append("3");
			}
			stringBuilder.Append(this.a(this.c, this.e, this.d));
			string str = this.b(stringBuilder.ToString());
			return this.e(this.a("AT" + str + "AT"));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0001417C File Offset: 0x0001317C
		internal string h()
		{
			return string.Concat(new string[]
			{
				this.a,
				" ",
				this.b,
				" ",
				this.c
			});
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000141C8 File Offset: 0x000131C8
		private void e()
		{
			if (this.i.Length < 10)
			{
				throw new ap("Invalid Australia Post barcode data. Insufficient data.");
			}
			this.a = this.i.Substring(0, 2);
			this.b = this.i.Substring(2, 8);
			this.c = this.i.Substring(10);
			if (this.a.Equals("00") && !this.b.Equals("00000000"))
			{
				throw new ap("FCC 00 may have only 00000000 as DPID.");
			}
			if (this.a.Equals("11"))
			{
				this.d = 0;
			}
			else if (this.a.Equals("59"))
			{
				this.d = 16;
				this.f = zz93.c.b;
			}
			else if (this.a.Equals("62"))
			{
				this.d = 31;
				this.f = zz93.c.c;
			}
			if (!this.a.Equals("59") && !this.a.Equals("62") && this.c != string.Empty)
			{
				throw new ap("The FCC used may not have Customer data.");
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00014324 File Offset: 0x00013324
		private BitArray e(string A_0)
		{
			this.g = new BitArray(3 * A_0.Length, true);
			foreach (char c in A_0)
			{
				char c2 = c;
				if (c2 != 'A')
				{
					switch (c2)
					{
					case 'D':
						this.c();
						break;
					case 'E':
						break;
					case 'F':
						this.b();
						break;
					default:
						if (c2 == 'T')
						{
							this.a();
						}
						break;
					}
				}
				else
				{
					this.d();
				}
			}
			BitArray bitArray = new BitArray(this.h * 2);
			int num = this.h / 3;
			int num2 = num * 2 - 1;
			int num3 = 0;
			int num4 = 0;
			for (int j = 0; j < num2; j++)
			{
				if (j % 2 == 0)
				{
					for (int k = 0; k < 3; k++)
					{
						bitArray[num4] = this.g[num3];
						num3++;
						num4++;
					}
				}
				else
				{
					for (int k = 0; k < 3; k++)
					{
						bitArray[num4] = true;
						num4++;
						this.h++;
					}
				}
			}
			this.g = bitArray;
			bitArray = new BitArray(this.h);
			num3 = 0;
			for (int j = 0; j < this.h / num2; j++)
			{
				num4 = j;
				for (int k = 0; k < num2; k++)
				{
					bitArray[num3] = this.g[num4];
					num3++;
					num4 += this.h / num2;
				}
			}
			return bitArray;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00014508 File Offset: 0x00013508
		private void d()
		{
			for (int i = 0; i < 2; i++)
			{
				this.g[this.h] = false;
				this.h++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.g[this.h] = true;
				this.h++;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0001457C File Offset: 0x0001357C
		private void c()
		{
			for (int i = 0; i < 1; i++)
			{
				this.g[this.h] = true;
				this.h++;
			}
			for (int i = 0; i < 2; i++)
			{
				this.g[this.h] = false;
				this.h++;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000145F0 File Offset: 0x000135F0
		private void b()
		{
			for (int i = 0; i < 3; i++)
			{
				this.g[this.h] = false;
				this.h++;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00014634 File Offset: 0x00013634
		private void a()
		{
			for (int i = 0; i < 1; i++)
			{
				this.g[this.h] = true;
				this.h++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.g[this.h] = false;
				this.h++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.g[this.h] = true;
				this.h++;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000146DC File Offset: 0x000136DC
		private string a(string A_0, b A_1, int A_2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			switch (A_1)
			{
			case zz93.b.a:
				stringBuilder.Append(this.c(A_0));
				break;
			case zz93.b.b:
				stringBuilder.Append(this.d(A_0));
				break;
			case zz93.b.c:
				foreach (char c in A_0)
				{
					if (c != '0' && c != '1' && c != '2' && c != '3')
					{
						throw new ap("Invalid customer data for the selected encoding.");
					}
				}
				stringBuilder.Append(A_0);
				break;
			}
			if (stringBuilder.Length > A_2)
			{
				throw new ap("Customer data exceeded the limit to the given FCC.");
			}
			while (stringBuilder.Length < A_2)
			{
				stringBuilder.Append("3");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000147C8 File Offset: 0x000137C8
		private string d(string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in A_0)
			{
				if (!zz93.a.k.ContainsKey((int)((byte)c)))
				{
					throw new ap("Value is out of the Customer encoding table.");
				}
				stringBuilder.Append(zz93.a.k[(int)((byte)c)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00014844 File Offset: 0x00013844
		private string c(string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in A_0)
			{
				if (!zz93.a.j.ContainsKey((byte)c))
				{
					throw new ap("Numeric encoding may have only digits.");
				}
				stringBuilder.Append(zz93.a.j[(byte)c]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000148C0 File Offset: 0x000138C0
		private string b(string A_0)
		{
			int[] array = new int[A_0.Length / 3];
			int num = 0;
			int i = 0;
			while (i < A_0.Length)
			{
				string key = (i + 3 >= A_0.Length) ? (A_0.Substring(i, 2) + "3") : A_0.Substring(i, 3);
				i += 3;
				if (!zz93.a.l.ContainsKey(key))
				{
					throw new ap("Some issue with ECC table data.");
				}
				array[num++] = zz93.a.l[key];
			}
			int[] array2 = new int[array.Length + 4 + 1];
			Array.Copy(array, array2, array.Length);
			int[] array3 = this.a(array2, array.Length, array2.Length - array.Length - 1, 64, 67);
			array2 = new int[array3.Length - 1];
			Array.Copy(array3, array2, array2.Length);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int num2 in array2)
			{
				foreach (KeyValuePair<string, int> keyValuePair in zz93.a.l)
				{
					if (keyValuePair.Value == num2)
					{
						stringBuilder.Append(keyValuePair.Key);
						break;
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00014A50 File Offset: 0x00013A50
		private string a(string A_0)
		{
			return A_0.Replace('0', 'F').Replace('1', 'A').Replace('2', 'D').Replace('3', 'T');
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00014A88 File Offset: 0x00013A88
		private int[] a(int[] A_0, int A_1, int A_2, int A_3, int A_4)
		{
			int[] array = new int[A_3];
			int[] array2 = new int[A_3];
			array[0] = 1 - A_3;
			array2[0] = 1;
			for (int i = 1; i < A_3; i++)
			{
				array2[i] = array2[i - 1] * 2;
				if (array2[i] >= A_3)
				{
					array2[i] ^= A_4;
				}
				array[array2[i]] = i;
			}
			int[] array3 = new int[A_2 + 1];
			for (int i = 1; i <= A_2; i++)
			{
				array3[i] = 0;
			}
			array3[0] = 1;
			for (int i = 1; i <= A_2; i++)
			{
				array3[i] = array3[i - 1];
				for (int j = i - 1; j >= 1; j--)
				{
					array3[j] = (array3[j - 1] ^ this.a(array3[j], array2[i], ref array, ref array2, A_3));
				}
				array3[0] = this.a(array3[0], array2[i], ref array, ref array2, A_3);
			}
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				A_0[i] = 0;
			}
			for (int i = 0; i < A_1; i++)
			{
				int a_ = A_0[A_1] ^ A_0[i];
				for (int j = 0; j < A_2; j++)
				{
					A_0[A_1 + j] = (int)((short)(A_0[A_1 + j + 1] ^ this.a(a_, array3[A_2 - j - 1], ref array, ref array2, A_3)));
				}
			}
			return A_0;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00014C0C File Offset: 0x00013C0C
		private int a(int A_0, int A_1, ref int[] A_2, ref int[] A_3, int A_4)
		{
			int result;
			if (!Convert.ToBoolean(A_0) || !Convert.ToBoolean(A_1))
			{
				result = 0;
			}
			else
			{
				result = A_3[(A_2[A_0] + A_2[A_1]) % (A_4 - 1)];
			}
			return result;
		}

		// Token: 0x04000003 RID: 3
		private string a = string.Empty;

		// Token: 0x04000004 RID: 4
		private string b = string.Empty;

		// Token: 0x04000005 RID: 5
		private string c = string.Empty;

		// Token: 0x04000006 RID: 6
		private int d;

		// Token: 0x04000007 RID: 7
		private b e;

		// Token: 0x04000008 RID: 8
		private c f = zz93.c.a;

		// Token: 0x04000009 RID: 9
		private BitArray g;

		// Token: 0x0400000A RID: 10
		private int h;

		// Token: 0x0400000B RID: 11
		private string i;

		// Token: 0x0400000C RID: 12
		private static Dictionary<byte, string> j = new Dictionary<byte, string>
		{
			{
				48,
				"00"
			},
			{
				49,
				"01"
			},
			{
				50,
				"02"
			},
			{
				51,
				"10"
			},
			{
				52,
				"11"
			},
			{
				53,
				"12"
			},
			{
				54,
				"20"
			},
			{
				55,
				"21"
			},
			{
				56,
				"22"
			},
			{
				57,
				"30"
			}
		};

		// Token: 0x0400000D RID: 13
		private static Dictionary<int, string> k = new Dictionary<int, string>
		{
			{
				48,
				"222"
			},
			{
				49,
				"300"
			},
			{
				50,
				"301"
			},
			{
				51,
				"302"
			},
			{
				52,
				"310"
			},
			{
				53,
				"311"
			},
			{
				54,
				"312"
			},
			{
				55,
				"320"
			},
			{
				56,
				"321"
			},
			{
				57,
				"322"
			},
			{
				32,
				"003"
			},
			{
				35,
				"013"
			},
			{
				65,
				"000"
			},
			{
				66,
				"001"
			},
			{
				67,
				"002"
			},
			{
				68,
				"010"
			},
			{
				69,
				"011"
			},
			{
				70,
				"012"
			},
			{
				71,
				"020"
			},
			{
				72,
				"021"
			},
			{
				73,
				"022"
			},
			{
				74,
				"100"
			},
			{
				75,
				"101"
			},
			{
				76,
				"102"
			},
			{
				77,
				"110"
			},
			{
				78,
				"111"
			},
			{
				79,
				"112"
			},
			{
				80,
				"120"
			},
			{
				81,
				"121"
			},
			{
				82,
				"122"
			},
			{
				83,
				"200"
			},
			{
				84,
				"201"
			},
			{
				85,
				"202"
			},
			{
				86,
				"210"
			},
			{
				87,
				"211"
			},
			{
				88,
				"212"
			},
			{
				89,
				"220"
			},
			{
				90,
				"221"
			},
			{
				97,
				"023"
			},
			{
				98,
				"030"
			},
			{
				99,
				"031"
			},
			{
				100,
				"032"
			},
			{
				101,
				"033"
			},
			{
				102,
				"103"
			},
			{
				103,
				"113"
			},
			{
				104,
				"123"
			},
			{
				105,
				"130"
			},
			{
				106,
				"131"
			},
			{
				107,
				"132"
			},
			{
				108,
				"133"
			},
			{
				109,
				"203"
			},
			{
				110,
				"213"
			},
			{
				111,
				"223"
			},
			{
				112,
				"230"
			},
			{
				113,
				"231"
			},
			{
				114,
				"232"
			},
			{
				115,
				"233"
			},
			{
				116,
				"303"
			},
			{
				117,
				"313"
			},
			{
				118,
				"323"
			},
			{
				119,
				"330"
			},
			{
				120,
				"331"
			},
			{
				121,
				"332"
			},
			{
				122,
				"333"
			}
		};

		// Token: 0x0400000E RID: 14
		private static Dictionary<string, int> l = new Dictionary<string, int>
		{
			{
				"000",
				0
			},
			{
				"001",
				1
			},
			{
				"002",
				2
			},
			{
				"003",
				3
			},
			{
				"010",
				4
			},
			{
				"011",
				5
			},
			{
				"012",
				6
			},
			{
				"013",
				7
			},
			{
				"020",
				8
			},
			{
				"021",
				9
			},
			{
				"022",
				10
			},
			{
				"023",
				11
			},
			{
				"030",
				12
			},
			{
				"031",
				13
			},
			{
				"032",
				14
			},
			{
				"033",
				15
			},
			{
				"100",
				16
			},
			{
				"101",
				17
			},
			{
				"102",
				18
			},
			{
				"103",
				19
			},
			{
				"110",
				20
			},
			{
				"111",
				21
			},
			{
				"112",
				22
			},
			{
				"113",
				23
			},
			{
				"120",
				24
			},
			{
				"121",
				25
			},
			{
				"122",
				26
			},
			{
				"123",
				27
			},
			{
				"130",
				28
			},
			{
				"131",
				29
			},
			{
				"132",
				30
			},
			{
				"133",
				31
			},
			{
				"200",
				32
			},
			{
				"201",
				33
			},
			{
				"202",
				34
			},
			{
				"203",
				35
			},
			{
				"210",
				36
			},
			{
				"211",
				37
			},
			{
				"212",
				38
			},
			{
				"213",
				39
			},
			{
				"220",
				40
			},
			{
				"221",
				41
			},
			{
				"222",
				42
			},
			{
				"223",
				43
			},
			{
				"230",
				44
			},
			{
				"231",
				45
			},
			{
				"232",
				46
			},
			{
				"233",
				47
			},
			{
				"300",
				48
			},
			{
				"301",
				49
			},
			{
				"302",
				50
			},
			{
				"303",
				51
			},
			{
				"310",
				52
			},
			{
				"311",
				53
			},
			{
				"312",
				54
			},
			{
				"313",
				55
			},
			{
				"320",
				56
			},
			{
				"321",
				57
			},
			{
				"322",
				58
			},
			{
				"323",
				59
			},
			{
				"330",
				60
			},
			{
				"331",
				61
			},
			{
				"332",
				62
			},
			{
				"333",
				63
			}
		};
	}
}
