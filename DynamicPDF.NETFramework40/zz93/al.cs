using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace zz93
{
	// Token: 0x02000028 RID: 40
	internal class al
	{
		// Token: 0x06000188 RID: 392 RVA: 0x0002CBED File Offset: 0x0002BBED
		internal al(string A_0, float A_1, int A_2)
		{
			this.h = A_0;
			this.i = A_1;
			this.j = A_2;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0002CC20 File Offset: 0x0002BC20
		internal BitArray e()
		{
			this.h = this.h.Replace(" ", "");
			this.h = this.h.Replace("-", "");
			if (this.h.Length > 20)
			{
				this.a = this.h.Substring(20);
			}
			if (!Regex.IsMatch(this.h, "^[0-9][0-4](([0-9]{18})|([0-9]{23})|([0-9]{27})|([0-9]{29}))$"))
			{
				throw new ap("Invalid Intelligent Mail barcode Value.");
			}
			string text = string.Empty;
			long a_ = this.a(this.a);
			string a_2 = this.a(this.h, a_);
			string a_3 = this.c(a_2);
			byte[] a_4 = this.d(a_3);
			this.c = this.a(a_4);
			this.b = this.e(a_2);
			this.b[9] = Convert.ToInt16((int)(this.b[9] * 2));
			if (this.c >> 10 != 0)
			{
				short[] array = this.b;
				int num = 0;
				array[num] += 659;
			}
			this.b = this.a(this.b);
			string[] array2 = this.b(this.b);
			for (int i = 0; i < 65; i++)
			{
				bool flag = false;
				bool flag2 = false;
				if (array2[(int)al.e[i, 0]][(int)al.e[i, 1]] == '1')
				{
					flag = true;
				}
				if (array2[(int)al.d[i, 0]][(int)al.d[i, 1]] == '1')
				{
					flag2 = true;
				}
				if (flag && flag2)
				{
					text += 'F';
				}
				else if (flag)
				{
					text += 'A';
				}
				else if (flag2)
				{
					text += 'D';
				}
				else
				{
					text += 'T';
				}
			}
			return this.f(text);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0002CE70 File Offset: 0x0002BE70
		internal float f()
		{
			return 129f * this.i;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0002CE90 File Offset: 0x0002BE90
		internal float g()
		{
			return 65f * this.i - this.i * 0.5f;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0002CEBC File Offset: 0x0002BEBC
		internal string h()
		{
			string text = this.h;
			int length = text.Length;
			text = text.Replace("-", " ");
			if (text[2] != ' ')
			{
				text = text.Insert(2, " ");
			}
			if (text[6] != ' ')
			{
				text = text.Insert(6, " ");
			}
			if (this.j == 0 && text[13] != ' ')
			{
				text = text.Insert(13, " ");
			}
			else if (text[16] != ' ')
			{
				text = text.Insert(16, " ");
			}
			if (length > 23 && text[23] != ' ')
			{
				text = text.Insert(23, " ");
			}
			if (length > 29 && text[29] != ' ')
			{
				text = text.Insert(29, " ");
			}
			if (length > 34 && text[34] != ' ')
			{
				text = text.Insert(34, " ");
			}
			return text;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0002CFE8 File Offset: 0x0002BFE8
		private BitArray f(string A_0)
		{
			this.f = new BitArray(3 * A_0.Length, true);
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
			BitArray bitArray = new BitArray(this.g * 2);
			int num = this.g / 3;
			int num2 = num * 2 - 1;
			int num3 = 0;
			int num4 = 0;
			for (int j = 0; j < num2; j++)
			{
				if (j % 2 == 0)
				{
					for (int k = 0; k < 3; k++)
					{
						bitArray[num4] = this.f[num3];
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
						this.g++;
					}
				}
			}
			this.f = bitArray;
			bitArray = new BitArray(this.g);
			num3 = 0;
			for (int j = 0; j < this.g / num2; j++)
			{
				num4 = j;
				for (int k = 0; k < num2; k++)
				{
					bitArray[num3] = this.f[num4];
					num3++;
					num4 += this.g / num2;
				}
			}
			return bitArray;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0002D1CC File Offset: 0x0002C1CC
		private void d()
		{
			for (int i = 0; i < 2; i++)
			{
				this.f[this.g] = false;
				this.g++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.f[this.g] = true;
				this.g++;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0002D240 File Offset: 0x0002C240
		private void c()
		{
			for (int i = 0; i < 1; i++)
			{
				this.f[this.g] = true;
				this.g++;
			}
			for (int i = 0; i < 2; i++)
			{
				this.f[this.g] = false;
				this.g++;
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0002D2B4 File Offset: 0x0002C2B4
		private void b()
		{
			for (int i = 0; i < 3; i++)
			{
				this.f[this.g] = false;
				this.g++;
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0002D2F8 File Offset: 0x0002C2F8
		private void a()
		{
			for (int i = 0; i < 1; i++)
			{
				this.f[this.g] = true;
				this.g++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.f[this.g] = false;
				this.g++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.f[this.g] = true;
				this.g++;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0002D3A0 File Offset: 0x0002C3A0
		private string[] b(short[] A_0)
		{
			string[] array = new string[10];
			for (int i = 0; i < A_0.Length; i++)
			{
				bool flag = false;
				int num = (int)A_0[i];
				string text = string.Empty;
				if ((this.c & 1 << i) != 0)
				{
					flag = true;
				}
				for (int j = 0; j < 13; j++)
				{
					int num2 = num % 2;
					if (flag)
					{
						num2 ^= 1;
					}
					text += num2;
					num /= 2;
				}
				array[i] = text;
			}
			return array;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0002D448 File Offset: 0x0002C448
		private short[] a(short[] A_0)
		{
			short[] array = new short[10];
			short[] array2 = this.a(5, 1287);
			short[] array3 = this.a(2, 78);
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] <= 1286)
				{
					array[i] = array2[(int)A_0[i]];
				}
				else
				{
					array[i] = array3[(int)(A_0[i] - 1287)];
				}
			}
			return array;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0002D4C0 File Offset: 0x0002C4C0
		private short[] e(string A_0)
		{
			short[] array = new short[10];
			string[] array2 = this.a(A_0, 636);
			array[9] = short.Parse(array2[0]);
			for (int i = 8; i >= 1; i--)
			{
				array2 = this.a(array2[1], 1365);
				array[i] = short.Parse(array2[0]);
			}
			array[0] = short.Parse(array2[1]);
			return array;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0002D530 File Offset: 0x0002C530
		private string[] a(string A_0, int A_1)
		{
			string text = string.Empty;
			string text2 = A_0;
			string text3 = "0";
			int length = text2.Length;
			for (int i = 1; i <= length; i++)
			{
				int num = int.Parse(text2.Substring(0, i));
				while (num < A_1 & i < length - 1)
				{
					text += "0";
					i++;
					num = int.Parse(text2.Substring(0, i));
				}
				text += (num / A_1).ToString();
				text3 = (num % A_1).ToString().PadLeft(i, '0');
				text2 = text3 + text2.Substring(i);
			}
			string text4 = text.TrimStart(new char[]
			{
				'0'
			});
			string[] array = new string[2];
			array[0] = int.Parse(text3).ToString();
			text = text.TrimStart(new char[]
			{
				'0'
			});
			if (text == null || text == string.Empty)
			{
				text = "0";
			}
			array[1] = text;
			return array;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0002D67C File Offset: 0x0002C67C
		private byte[] d(string A_0)
		{
			byte[] array = new byte[13];
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				string s = new string(new char[]
				{
					A_0[num],
					A_0[num + 1]
				});
				array[i] = byte.Parse(s, NumberStyles.HexNumber);
				num += 2;
			}
			return array;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0002D6EC File Offset: 0x0002C6EC
		private string c(string A_0)
		{
			string text = A_0;
			string text2 = string.Empty;
			for (int i = 26; i >= 1; i += -1)
			{
				string text3 = string.Empty;
				string text4 = text;
				string text5 = "0";
				int num = 16;
				int length = text4.Length;
				for (int j = 1; j <= length; j++)
				{
					int num2 = int.Parse(text4.Substring(0, j));
					while (num2 < num & j < length - 1)
					{
						text3 += "0";
						j++;
						num2 = int.Parse(text4.Substring(0, j));
					}
					text3 += (num2 / num).ToString();
					text5 = (num2 % num).ToString().PadLeft(j, '0');
					text4 = text5 + text4.Substring(j);
				}
				text = text3.TrimStart(new char[]
				{
					'0'
				});
				if (text == null || text == string.Empty)
				{
					text = "0";
				}
				if (int.Parse(text5) == 10)
				{
					text2 += "A";
				}
				else if (int.Parse(text5) == 11)
				{
					text2 += "B";
				}
				else if (int.Parse(text5) == 12)
				{
					text2 += "C";
				}
				else if (int.Parse(text5) == 13)
				{
					text2 += "D";
				}
				else if (int.Parse(text5) == 14)
				{
					text2 += "E";
				}
				else if (int.Parse(text5) == 15)
				{
					text2 += "F";
				}
				else
				{
					text2 += int.Parse(text5).ToString();
				}
			}
			return this.b(text2);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0002D91C File Offset: 0x0002C91C
		private string b(string A_0)
		{
			string text = string.Empty;
			for (int i = A_0.Length - 1; i >= 0; i--)
			{
				text += A_0[i];
			}
			A_0 = text;
			return A_0;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0002D968 File Offset: 0x0002C968
		private long a(string A_0)
		{
			long result = 0L;
			if (A_0.Length == 5)
			{
				result = long.Parse(A_0) + 1L;
			}
			else if (A_0.Length == 9)
			{
				result = long.Parse(A_0) + 100001L;
			}
			else if (A_0.Length == 11)
			{
				result = long.Parse(A_0) + 1000100001L;
			}
			return result;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0002D9DC File Offset: 0x0002C9DC
		private string a(string A_0, long A_1)
		{
			A_1 = A_1 * 10L + (long)int.Parse(A_0.Substring(0, 1));
			A_1 = A_1 * 5L + (long)int.Parse(A_0.Substring(1, 1));
			return A_1.ToString() + A_0.Substring(2, 18);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0002DA30 File Offset: 0x0002CA30
		private int a(byte[] A_0)
		{
			ushort num = 3893;
			ushort num2 = 2047;
			ushort num3 = (ushort)(A_0[0] << 5);
			for (ushort num4 = 2; num4 < 8; num4 += 1)
			{
				if (Convert.ToBoolean((int)((num2 ^ num3) & 1024)))
				{
					num2 = (ushort)((int)num2 << 1 ^ (int)num);
				}
				else
				{
					num2 = (ushort)(num2 << 1);
				}
				num2 &= 2047;
				num3 = (ushort)(num3 << 1);
			}
			for (ushort num5 = 1; num5 < 13; num5 += 1)
			{
				num3 = (ushort)(A_0[(int)num5] << 3);
				for (ushort num4 = 0; num4 < 8; num4 += 1)
				{
					if (Convert.ToBoolean((int)((num2 ^ num3) & 1024)))
					{
						num2 = (ushort)((int)num2 << 1 ^ (int)num);
					}
					else
					{
						num2 = (ushort)(num2 << 1);
					}
					num2 &= 2047;
					num3 = (ushort)(num3 << 1);
				}
			}
			return (int)num2;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0002DB18 File Offset: 0x0002CB18
		private short[] a(short A_0, short A_1)
		{
			short[] array = new short[(int)A_1];
			short num = 0;
			short num2 = Convert.ToInt16((int)(A_1 - 1));
			for (short num3 = 0; num3 < 8192; num3 += 1)
			{
				int num4 = 0;
				for (int i = 0; i < 13; i++)
				{
					int num5 = Convert.ToInt32(((int)num3 & 1 << i) != 0);
					if (num5 != 0)
					{
						num4 += num5;
					}
				}
				if (num4 == (int)A_0)
				{
					short num6 = Convert.ToInt16(this.a((ushort)num3) >> 3);
					if (num6 >= num3)
					{
						if (num3 == num6)
						{
							array[(int)num2] = num3;
							num2 -= 1;
						}
						else
						{
							array[(int)num] = num3;
							num += 1;
							array[(int)num] = num6;
							num += 1;
						}
					}
				}
			}
			return array;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0002DC04 File Offset: 0x0002CC04
		private ushort a(ushort A_0)
		{
			ushort num = 0;
			for (int i = 0; i < 16; i++)
			{
				num = (ushort)(num << 1);
				num |= (A_0 & 1);
				A_0 = (ushort)(A_0 >> 1);
			}
			return num;
		}

		// Token: 0x04000117 RID: 279
		private string a = string.Empty;

		// Token: 0x04000118 RID: 280
		private short[] b;

		// Token: 0x04000119 RID: 281
		private int c;

		// Token: 0x0400011A RID: 282
		private static byte[,] d = new byte[,]
		{
			{
				7,
				2
			},
			{
				1,
				10
			},
			{
				9,
				12
			},
			{
				5,
				5
			},
			{
				8,
				9
			},
			{
				0,
				1
			},
			{
				2,
				5
			},
			{
				4,
				4
			},
			{
				6,
				3
			},
			{
				3,
				9
			},
			{
				5,
				11
			},
			{
				8,
				5
			},
			{
				9,
				10
			},
			{
				7,
				1
			},
			{
				3,
				6
			},
			{
				0,
				3
			},
			{
				6,
				4
			},
			{
				1,
				1
			},
			{
				7,
				10
			},
			{
				4,
				0
			},
			{
				6,
				2
			},
			{
				8,
				11
			},
			{
				9,
				8
			},
			{
				2,
				6
			},
			{
				5,
				1
			},
			{
				1,
				12
			},
			{
				7,
				3
			},
			{
				5,
				8
			},
			{
				4,
				6
			},
			{
				3,
				4
			},
			{
				8,
				4
			},
			{
				7,
				11
			},
			{
				6,
				0
			},
			{
				0,
				6
			},
			{
				2,
				1
			},
			{
				5,
				9
			},
			{
				4,
				11
			},
			{
				9,
				5
			},
			{
				3,
				3
			},
			{
				0,
				7
			},
			{
				1,
				3
			},
			{
				6,
				10
			},
			{
				8,
				7
			},
			{
				2,
				11
			},
			{
				0,
				8
			},
			{
				4,
				2
			},
			{
				5,
				10
			},
			{
				9,
				3
			},
			{
				6,
				5
			},
			{
				7,
				8
			},
			{
				5,
				0
			},
			{
				2,
				3
			},
			{
				6,
				12
			},
			{
				3,
				11
			},
			{
				8,
				8
			},
			{
				5,
				4
			},
			{
				1,
				5
			},
			{
				9,
				1
			},
			{
				8,
				3
			},
			{
				7,
				0
			},
			{
				4,
				7
			},
			{
				0,
				12
			},
			{
				2,
				9
			},
			{
				6,
				8
			},
			{
				3,
				10
			}
		};

		// Token: 0x0400011B RID: 283
		private static byte[,] e = new byte[,]
		{
			{
				4,
				3
			},
			{
				0,
				0
			},
			{
				2,
				8
			},
			{
				6,
				11
			},
			{
				3,
				1
			},
			{
				5,
				12
			},
			{
				1,
				8
			},
			{
				9,
				11
			},
			{
				8,
				10
			},
			{
				7,
				6
			},
			{
				1,
				4
			},
			{
				2,
				12
			},
			{
				0,
				2
			},
			{
				6,
				7
			},
			{
				4,
				9
			},
			{
				8,
				6
			},
			{
				2,
				7
			},
			{
				9,
				9
			},
			{
				5,
				2
			},
			{
				3,
				8
			},
			{
				0,
				4
			},
			{
				1,
				0
			},
			{
				3,
				12
			},
			{
				7,
				7
			},
			{
				4,
				10
			},
			{
				6,
				9
			},
			{
				8,
				0
			},
			{
				9,
				7
			},
			{
				2,
				10
			},
			{
				0,
				5
			},
			{
				5,
				7
			},
			{
				1,
				9
			},
			{
				9,
				6
			},
			{
				4,
				8
			},
			{
				3,
				2
			},
			{
				8,
				12
			},
			{
				6,
				1
			},
			{
				7,
				4
			},
			{
				1,
				2
			},
			{
				2,
				0
			},
			{
				4,
				1
			},
			{
				3,
				5
			},
			{
				9,
				4
			},
			{
				5,
				6
			},
			{
				7,
				12
			},
			{
				8,
				1
			},
			{
				3,
				0
			},
			{
				0,
				9
			},
			{
				2,
				4
			},
			{
				1,
				7
			},
			{
				4,
				5
			},
			{
				0,
				10
			},
			{
				9,
				2
			},
			{
				1,
				6
			},
			{
				7,
				9
			},
			{
				0,
				11
			},
			{
				2,
				2
			},
			{
				4,
				12
			},
			{
				6,
				6
			},
			{
				3,
				7
			},
			{
				7,
				5
			},
			{
				1,
				11
			},
			{
				9,
				0
			},
			{
				5,
				3
			},
			{
				8,
				2
			}
		};

		// Token: 0x0400011C RID: 284
		private BitArray f;

		// Token: 0x0400011D RID: 285
		private int g;

		// Token: 0x0400011E RID: 286
		private string h;

		// Token: 0x0400011F RID: 287
		private float i;

		// Token: 0x04000120 RID: 288
		private int j = 0;
	}
}
