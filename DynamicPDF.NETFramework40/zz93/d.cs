using System;
using System.Collections;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x02000006 RID: 6
	internal class d
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00015400 File Offset: 0x00014400
		internal d()
		{
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00015438 File Offset: 0x00014438
		internal int d()
		{
			return this.o;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00015450 File Offset: 0x00014450
		internal int e()
		{
			return this.p;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00015468 File Offset: 0x00014468
		internal int f()
		{
			return this.q;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00015480 File Offset: 0x00014480
		internal void a(int A_0)
		{
			this.q = A_0;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0001548C File Offset: 0x0001448C
		internal int g()
		{
			return this.r;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000154A4 File Offset: 0x000144A4
		internal void b(int A_0)
		{
			this.r = A_0;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000154B0 File Offset: 0x000144B0
		internal bool h()
		{
			return this.s;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000154C8 File Offset: 0x000144C8
		internal void a(bool A_0)
		{
			this.s = A_0;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000154D4 File Offset: 0x000144D4
		internal bool i()
		{
			return this.t;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000154EC File Offset: 0x000144EC
		internal void b(bool A_0)
		{
			this.t = A_0;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000154F8 File Offset: 0x000144F8
		internal byte[] j()
		{
			return this.u;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00015510 File Offset: 0x00014510
		internal void a(byte[] A_0)
		{
			this.u = A_0;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0001551A File Offset: 0x0001451A
		internal void c(int A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00015524 File Offset: 0x00014524
		internal int k()
		{
			return this.w;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0001553C File Offset: 0x0001453C
		internal void d(int A_0)
		{
			this.w = A_0;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00015546 File Offset: 0x00014546
		internal void a(string A_0)
		{
			this.x = A_0;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00015550 File Offset: 0x00014550
		internal void c(bool A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0001555C File Offset: 0x0001455C
		internal bool l()
		{
			return this.z;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00015574 File Offset: 0x00014574
		internal void d(bool A_0)
		{
			this.z = A_0;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00015580 File Offset: 0x00014580
		internal List<byte[]> m()
		{
			return this.aa;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00015598 File Offset: 0x00014598
		internal void a(List<byte[]> A_0)
		{
			this.aa = A_0;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000155A4 File Offset: 0x000145A4
		internal BitArray n()
		{
			this.ab = new e();
			if (this.v == 3)
			{
				List<string> list = this.ab.a(this.u, this.z);
				int[] array = this.a(list);
				int[] array2 = new int[8];
				Array.Copy(array, array2, array.Length);
				int[] sourceArray = this.a(array2, array.Length, array2.Length - array.Length - 1, zz93.d.j[0, 0], zz93.d.j[0, 1]);
				array2 = new int[7];
				Array.Copy(sourceArray, array2, array2.Length);
				short[] array3 = new short[array2.Length * 4];
				int num = 0;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] ^= 10;
					string text = Convert.ToString(array2[i], 2).PadLeft(4, '0');
					for (int j = 0; j < text.Length; j++)
					{
						array3[num++] = short.Parse(text[j].ToString());
					}
				}
				this.a(this.b(7, 0));
				this.a(array3, true);
			}
			else
			{
				List<string> list = this.ab.a(this.u, this.z, 1);
				int num2 = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num2 += list[i].ToString().Length;
				}
				int num3 = (int)Math.Ceiling((double)num2 * 100.0 / (double)(100 - this.w));
				int num4 = (int)Math.Ceiling(300.0 / (double)(100 - this.w));
				int[] array4 = this.b(num3, num4);
				if (array4[3] < num3 + num4 * array4[2])
				{
					throw new ao("Symbol size is not sufficient to draw all the data. Please increase the symbol size or manage the barcode's overflow.");
				}
				bool a_ = false;
				if (array4.Length == 9)
				{
					a_ = true;
				}
				int a_2 = array4[2];
				int num5 = array4[1];
				int num6 = array4[7];
				List<string> a_3 = this.a(a_2, list, false);
				int[] array = this.a(a_3);
				int[] array2 = new int[num5 + 1];
				Array.Copy(array, array2, array.Length);
				int[] sourceArray2 = this.a(array2, array.Length, array2.Length - array.Length - 1, zz93.d.j[num6, 0], zz93.d.j[num6, 1]);
				array2 = new int[num5];
				Array.Copy(sourceArray2, array2, array2.Length);
				int[] a_4 = this.a(num6, array.Length, array4);
				this.a(array4);
				this.a(a_4, a_);
				this.a(array2, array4);
			}
			return this.c();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00015874 File Offset: 0x00014874
		internal BitArray o()
		{
			int[] array = this.b(0, 0);
			List<string> a_ = this.ab.a(this.x, this.r, this.aa.Count, this.aa[this.r - 1], this.z);
			bool a_2 = false;
			if (array.Length == 9)
			{
				a_2 = true;
			}
			int a_3 = array[2];
			int num = array[1];
			int num2 = array[7];
			List<string> a_4 = this.a(a_3, a_, false);
			int[] array2 = this.a(a_4);
			int[] array3 = new int[num + 1];
			Array.Copy(array2, array3, array2.Length);
			int[] sourceArray = this.a(array3, array2.Length, array3.Length - array2.Length - 1, zz93.d.j[num2, 0], zz93.d.j[num2, 1]);
			array3 = new int[num];
			Array.Copy(sourceArray, array3, array3.Length);
			int[] a_5 = this.a(num2, array2.Length, array);
			this.a(array);
			this.a(a_5, a_2);
			this.a(array3, array);
			return this.c();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00015998 File Offset: 0x00014998
		internal void p()
		{
			if (this.v != 0 && this.v != 1 && this.v != 2 && this.v != 3)
			{
				this.ab = new e();
				List<string> list = this.ab.a(this.u, this.z, 1);
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].ToString().Length;
				}
				int num2 = (int)Math.Ceiling((double)num * 100.0 / (double)(100 - this.w));
				int num3 = (int)Math.Ceiling(300.0 / (double)(100 - this.w));
				int[] array = this.b(num2, num3);
				if (this.y)
				{
					List<byte> list2 = new List<byte>();
					list2.AddRange(this.u);
					int num4 = 0;
					for (;;)
					{
						do
						{
							this.ab = new e();
							list = this.ab.a(this.x, 11, 26, list2.ToArray(), this.z);
							num = 0;
							for (int i = 0; i < list.Count; i++)
							{
								num += list[i].ToString().Length;
							}
							num2 = (int)Math.Ceiling((double)num * 100.0 / (double)(100 - this.w));
							num3 = (int)Math.Ceiling(300.0 / (double)(100 - this.w));
							if (num2 + num3 * array[2] > array[3])
							{
								if (this.z && list2.Count > "~1".Length && this.a(list2))
								{
									list2.RemoveRange(list2.Count - 2, 2);
								}
								else if (this.z && list2.Count > "~2".Length + 6 && this.b(list2))
								{
									list2.RemoveRange(list2.Count - 8, 8);
								}
								else
								{
									list2.RemoveAt(list2.Count - 1);
								}
							}
							if (list2.Count == 0)
							{
								goto Block_15;
							}
						}
						while (num2 + num3 * array[2] > array[3]);
						num4 += list2.Count;
						this.aa.Add(list2.ToArray());
						list2 = new List<byte>();
						for (int i = num4; i < this.u.Length; i++)
						{
							list2.Add(this.u[i]);
						}
						if (list2.Count <= 0)
						{
							goto IL_2E6;
						}
					}
					Block_15:
					throw new ao("Symbol size is not sufficient to draw all the data. Please increase the symbol size.");
				}
				IL_2E6:
				this.q = this.aa.Count;
				this.s = true;
				if (this.q > 26)
				{
					throw new ao("Total number of symbols cannot exceed 26. Try increasing the symbol size.");
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00015CC4 File Offset: 0x00014CC4
		private BitArray c()
		{
			int num = 0;
			BitArray bitArray = new BitArray(this.n.GetLength(0) * this.n.GetLength(0));
			for (int i = 0; i < this.n.GetLength(0); i++)
			{
				for (int j = 0; j < this.n.GetLength(1); j++)
				{
					if (this.n[i, j] == 1)
					{
						bitArray[num++] = false;
					}
					else
					{
						bitArray[num++] = true;
					}
				}
			}
			return bitArray;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00015D70 File Offset: 0x00014D70
		private void a(int[] A_0, int[] A_1)
		{
			bool flag = false;
			if (A_1.Length == 9)
			{
				flag = true;
			}
			if (flag)
			{
				short[] array = new short[A_0.Length * A_1[2]];
				int num = 0;
				for (int i = 0; i < A_0.Length; i++)
				{
					string text = Convert.ToString(A_0[i], 2).PadLeft(A_1[2], '0');
					for (int j = 0; j < text.Length; j++)
					{
						array[num++] = short.Parse(text[j].ToString());
					}
				}
				int num2 = this.n.GetLength(0) / 2;
				int num3 = num2 - 6;
				int num4 = num2 - 5;
				int num5 = 0;
				int num6 = 13;
				int num7 = 0;
				for (int i = array.Length - 1; i >= 0; i--)
				{
					switch (num5)
					{
					case 0:
						this.a(array[i], num3, num4, array[i - 1], num3 - 1, num4);
						num7++;
						num4++;
						if (num7 >= num6)
						{
							num3++;
							num4--;
							num4--;
							num7 = 0;
							num5 = 1;
						}
						break;
					case 1:
						this.a(array[i], num3, num4, array[i - 1], num3, num4 + 1);
						num7++;
						num3++;
						if (num7 >= num6)
						{
							num3--;
							num3--;
							num4--;
							num7 = 0;
							num5 = 2;
						}
						break;
					case 2:
						this.a(array[i], num3, num4, array[i - 1], num3 + 1, num4);
						num7++;
						num4--;
						if (num7 >= num6)
						{
							num4++;
							num4++;
							num3--;
							num7 = 0;
							num5 = 3;
						}
						break;
					case 3:
						this.a(array[i], num3, num4, array[i - 1], num3, num4 - 1);
						num7++;
						num3--;
						if (num7 >= num6)
						{
							num4--;
							num7 = 0;
							num5 = 0;
							num6 += 4;
						}
						break;
					}
					i--;
				}
			}
			else
			{
				short[] array = new short[A_0.Length * A_1[2]];
				int num = 0;
				for (int i = 0; i < A_0.Length; i++)
				{
					string text = Convert.ToString(A_0[i], 2).PadLeft(A_1[2], '0');
					for (int j = 0; j < text.Length; j++)
					{
						array[num++] = short.Parse(text[j].ToString());
					}
				}
				int num2 = this.n.GetLength(0) / 2;
				int num3 = num2 - 8;
				int num4 = num2 - 7;
				int num5 = 0;
				int num8 = 1;
				int num6 = 17;
				int num7 = 0;
				for (int i = array.Length - 1; i >= 0; i--)
				{
					switch (num5)
					{
					case 0:
						if (num8 == 12 || num8 == 27)
						{
							this.a(array[i], num3, num4, array[i - 1], num3 - 2, num4);
						}
						else
						{
							this.a(array[i], num3, num4, array[i - 1], num3 - 1, num4);
						}
						i--;
						num7++;
						num4++;
						if (num7 >= num6)
						{
							num3++;
							num4--;
							num4--;
							if (num8 == 12 || num8 == 27)
							{
								num4--;
							}
							num7 = 0;
							num5 = 1;
						}
						break;
					case 1:
						if (num8 == 12 || num8 == 27)
						{
							this.a(array[i], num3, num4, array[i - 1], num3, num4 + 2);
						}
						else
						{
							this.a(array[i], num3, num4, array[i - 1], num3, num4 + 1);
						}
						i--;
						num7++;
						num3++;
						if (num7 >= num6)
						{
							num3--;
							num3--;
							if (num8 == 12 || num8 == 27)
							{
								num3--;
							}
							num4--;
							num7 = 0;
							num5 = 2;
						}
						break;
					case 2:
						if (num8 == 12 || num8 == 27)
						{
							this.a(array[i], num3, num4, array[i - 1], num3 + 2, num4);
						}
						else
						{
							this.a(array[i], num3, num4, array[i - 1], num3 + 1, num4);
						}
						i--;
						num7++;
						num4--;
						if (num7 >= num6)
						{
							num4++;
							num4++;
							if (num8 == 12 || num8 == 27)
							{
								num4++;
							}
							num3--;
							num7 = 0;
							num5 = 3;
						}
						break;
					case 3:
						if (num8 == 12 || num8 == 27)
						{
							this.a(array[i], num3, num4, array[i - 1], num3, num4 - 2);
						}
						else
						{
							this.a(array[i], num3, num4, array[i - 1], num3, num4 - 1);
						}
						i--;
						num7++;
						num3--;
						if (num7 >= num6)
						{
							num4--;
							if (num8 == 12 || num8 == 27)
							{
								num4--;
							}
							num7 = 0;
							num5 = 0;
							num6 += 4;
							if (num8 == 4 || num8 == 19)
							{
								num6 += 2;
								num7++;
								num3--;
							}
							else if (num8 == 11 || num8 == 12 || num8 == 26 || num8 == 27)
							{
								num6++;
							}
							num8++;
						}
						break;
					}
					if (this.c(num3, num4))
					{
						switch (num5)
						{
						case 0:
							num4++;
							break;
						case 1:
							num3++;
							break;
						case 2:
							num4--;
							break;
						case 3:
							num3--;
							break;
						}
						num7++;
					}
				}
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000163EC File Offset: 0x000153EC
		private bool c(int A_0, int A_1)
		{
			int num = A_0 - this.n.GetLength(0) / 2;
			int num2 = A_1 - this.n.GetLength(0) / 2;
			return num % 16 == 0 || num2 % 16 == 0;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0001643D File Offset: 0x0001543D
		private void a(short A_0, int A_1, int A_2, short A_3, int A_4, int A_5)
		{
			this.n[A_1, A_2] = A_0;
			this.n[A_4, A_5] = A_3;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00016460 File Offset: 0x00015460
		private void a(int[] A_0, bool A_1)
		{
			if (A_1)
			{
				short[] array = new short[A_0.Length * 4];
				int num = 0;
				for (int i = 0; i < A_0.Length; i++)
				{
					string text = Convert.ToString(A_0[i], 2).PadLeft(4, '0');
					for (int j = 0; j < text.Length; j++)
					{
						array[num++] = short.Parse(text[j].ToString());
					}
				}
				this.a(array, A_1);
			}
			else
			{
				short[] array = new short[A_0.Length * 4];
				int num = 0;
				for (int i = 0; i < A_0.Length; i++)
				{
					string text = Convert.ToString(A_0[i], 2).PadLeft(4, '0');
					for (int j = 0; j < text.Length; j++)
					{
						array[num++] = short.Parse(text[j].ToString());
					}
				}
				this.a(array, A_1);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0001656C File Offset: 0x0001556C
		private void a(short[] A_0, bool A_1)
		{
			if (!A_1)
			{
				int num = this.n.GetLength(0) / 2;
				int num2 = num - 7;
				int num3 = num - 7 + 2;
				for (int i = 0; i < 10; i++)
				{
					this.n[num2, num3++] = A_0[i];
					if (i == 4)
					{
						num3++;
					}
				}
				num2 += 2;
				num3++;
				for (int i = 10; i < 20; i++)
				{
					this.n[num2++, num3] = A_0[i];
					if (i == 14)
					{
						num2++;
					}
				}
				num2++;
				num3 -= 2;
				for (int i = 20; i < 30; i++)
				{
					this.n[num2, num3--] = A_0[i];
					if (i == 24)
					{
						num3--;
					}
				}
				num3--;
				num2 -= 2;
				for (int i = 30; i < 40; i++)
				{
					this.n[num2--, num3] = A_0[i];
					if (i == 34)
					{
						num2--;
					}
				}
			}
			else
			{
				int num = this.n.GetLength(0) / 2;
				int num2 = num - 5;
				int num3 = num - 5 + 2;
				for (int i = 0; i < 7; i++)
				{
					this.n[num2, num3++] = A_0[i];
				}
				num2 += 2;
				num3++;
				for (int i = 7; i < 14; i++)
				{
					this.n[num2++, num3] = A_0[i];
				}
				num2++;
				num3 -= 2;
				for (int i = 14; i < 21; i++)
				{
					this.n[num2, num3--] = A_0[i];
				}
				num3--;
				num2 -= 2;
				for (int i = 21; i < 28; i++)
				{
					this.n[num2--, num3] = A_0[i];
				}
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00016778 File Offset: 0x00015778
		private void a(int[] A_0)
		{
			this.n = new short[A_0[0], A_0[0]];
			if (A_0.Length == 9 || A_0.Length == 3)
			{
				this.a();
			}
			else
			{
				this.b();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000167C0 File Offset: 0x000157C0
		private void b()
		{
			int num = this.n.GetLength(0) / 2;
			int i = num - 7;
			int j = num - 7;
			for (int k = 0; k < 15; k++)
			{
				for (int l = 0; l < 15; l++)
				{
					if (zz93.d.l[k, l] == 1)
					{
						this.n[i, j] = 1;
					}
					else
					{
						this.n[i, j] = 0;
					}
					j++;
				}
				j = num - 7;
				i++;
			}
			for (i = 0; i < this.n.GetLength(0); i++)
			{
				for (j = 0; j < this.n.GetLength(0); j++)
				{
					int num2 = i - this.n.GetLength(0) / 2;
					int num3 = j - this.n.GetLength(0) / 2;
					if (num2 % 16 == 0 || num3 % 16 == 0)
					{
						if ((num2 + num3 + 1) % 2 == 0)
						{
							this.n[i, j] = 0;
						}
						else
						{
							this.n[i, j] = 1;
						}
					}
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00016914 File Offset: 0x00015914
		private void a()
		{
			int num = this.n.GetLength(0) / 2;
			int num2 = num - 5;
			int num3 = num - 5;
			for (int i = 0; i < 11; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					if (zz93.d.m[i, j] == 1)
					{
						this.n[num2, num3] = 1;
					}
					else
					{
						this.n[num2, num3] = 0;
					}
					num3++;
				}
				num3 = num - 5;
				num2++;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000169AC File Offset: 0x000159AC
		private int[] a(int A_0, int A_1, int[] A_2)
		{
			List<string> list = new List<string>();
			int num;
			if (A_2.Length == 9)
			{
				list.Add(Convert.ToString(A_0 - 1, 2).PadLeft(2, '0'));
				if (this.t)
				{
					list.Add(Convert.ToString(A_2[1] + 1, 2).PadLeft(6, '0'));
				}
				else
				{
					list.Add(Convert.ToString(A_1 - 1, 2).PadLeft(6, '0'));
				}
				num = 7;
			}
			else
			{
				list.Add(Convert.ToString(A_0 - 1, 2).PadLeft(5, '0'));
				if (this.t)
				{
					list.Add(Convert.ToString(A_2[1] + 1, 2).PadLeft(11, '0'));
				}
				else
				{
					list.Add(Convert.ToString(A_1 - 1, 2).PadLeft(11, '0'));
				}
				num = 10;
			}
			List<string> a_ = this.a(4, list, true);
			int[] array = this.a(a_);
			int[] array2 = new int[num + 1];
			Array.Copy(array, array2, array.Length);
			int[] sourceArray = this.a(array2, array.Length, array2.Length - array.Length - 1, zz93.d.j[0, 0], zz93.d.j[0, 1]);
			array2 = new int[num];
			Array.Copy(sourceArray, array2, array2.Length);
			return array2;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00016B0C File Offset: 0x00015B0C
		private int[] a(List<string> A_0)
		{
			int[] array = new int[A_0.Count];
			for (int i = 0; i < A_0.Count; i++)
			{
				array[i] = Convert.ToInt32(A_0[i].ToString(), 2);
			}
			return array;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00016B58 File Offset: 0x00015B58
		private List<string> a(int A_0, List<string> A_1, bool A_2)
		{
			int num = 0;
			int num2 = 0;
			List<string> list = new List<string>();
			string text = string.Empty;
			for (int i = 0; i < A_1.Count; i++)
			{
				for (int j = 0; j < A_1[i].ToString().Length; j++)
				{
					char c = A_1[i].ToString()[j];
					if (c == '0')
					{
						num++;
					}
					else if (c == '1')
					{
						num2++;
					}
					text += c;
					if (!A_2)
					{
						if (text.Length == A_0 - 1 && num == A_0 - 1)
						{
							text += '1';
						}
						else if (text.Length == A_0 - 1 && num2 == A_0 - 1)
						{
							text += '0';
						}
					}
					if (text.Length == A_0)
					{
						list.Add(text);
						text = string.Empty;
						num = 0;
						num2 = 0;
					}
				}
			}
			if (text.Length != 0)
			{
				for (int i = text.Length; i < A_0; i++)
				{
					text += '1';
				}
				list.Add(text);
			}
			return list;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00016CE8 File Offset: 0x00015CE8
		private int[] b(int A_0, int A_1)
		{
			int[] array = new int[8];
			switch (this.v)
			{
			case 1:
				if (this.t)
				{
					throw new ao("Please select allowed sizes for ReaderInitializedSymbol or set size to Auto.");
				}
				array = this.a(A_0, A_1, false);
				break;
			case 2:
				if (this.t)
				{
					throw new ao("Please select allowed sizes for ReaderInitializedSymbol or set size to Auto.");
				}
				array = new int[9];
				array = this.a(A_0, A_1, true);
				break;
			case 3:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[36];
				break;
			case 4:
				array = new int[9];
				array = zz93.d.k[0];
				break;
			case 5:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = new int[9];
				array = zz93.d.k[1];
				break;
			case 6:
				array = zz93.d.k[4];
				break;
			case 7:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = new int[9];
				array = zz93.d.k[2];
				break;
			case 8:
				array = zz93.d.k[5];
				break;
			case 9:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = new int[9];
				array = zz93.d.k[3];
				break;
			case 10:
				array = zz93.d.k[6];
				break;
			case 11:
				array = zz93.d.k[7];
				break;
			case 12:
				array = zz93.d.k[8];
				break;
			case 13:
				array = zz93.d.k[9];
				break;
			case 14:
				array = zz93.d.k[10];
				break;
			case 15:
				array = zz93.d.k[11];
				break;
			case 16:
				array = zz93.d.k[12];
				break;
			case 17:
				array = zz93.d.k[13];
				break;
			case 18:
				array = zz93.d.k[14];
				break;
			case 19:
				array = zz93.d.k[15];
				break;
			case 20:
				array = zz93.d.k[16];
				break;
			case 21:
				array = zz93.d.k[17];
				break;
			case 22:
				array = zz93.d.k[18];
				break;
			case 23:
				array = zz93.d.k[19];
				break;
			case 24:
				array = zz93.d.k[20];
				break;
			case 25:
				array = zz93.d.k[21];
				break;
			case 26:
				array = zz93.d.k[22];
				break;
			case 27:
				array = zz93.d.k[23];
				break;
			case 28:
				array = zz93.d.k[24];
				break;
			case 29:
				array = zz93.d.k[25];
				break;
			case 30:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[26];
				break;
			case 31:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[27];
				break;
			case 32:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[28];
				break;
			case 33:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[29];
				break;
			case 34:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[30];
				break;
			case 35:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[31];
				break;
			case 36:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[32];
				break;
			case 37:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[33];
				break;
			case 38:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[34];
				break;
			case 39:
				if (this.t)
				{
					throw new ao("A ReaderInitializedSymbol may not be of this SymbolSize");
				}
				array = zz93.d.k[35];
				break;
			default:
				array = this.a(A_0, A_1);
				break;
			}
			this.o = array[0];
			this.p = array[0];
			return array;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00017188 File Offset: 0x00016188
		private int[] a(int A_0, int A_1)
		{
			int[] result = new int[9];
			int num = int.MaxValue;
			for (int i = 0; i < zz93.d.k.Length; i++)
			{
				if (zz93.d.k[i].Length != 3)
				{
					if (!this.t || ((zz93.d.k[i].Length != 9 || (zz93.d.k[i][0] != 19 && zz93.d.k[i][0] != 23 && zz93.d.k[i][0] != 27)) && (zz93.d.k[i][0] != 113 && zz93.d.k[i][0] != 117 && zz93.d.k[i][0] != 121 && zz93.d.k[i][0] != 125 && zz93.d.k[i][0] != 131 && zz93.d.k[i][0] != 135 && zz93.d.k[i][0] != 139 && zz93.d.k[i][0] != 143 && zz93.d.k[i][0] != 147) && zz93.d.k[i][0] != 151))
					{
						int num2 = zz93.d.k[i][3] - (A_0 + A_1 * zz93.d.k[i][2]);
						if (Math.Sign(num2) != -1)
						{
							if (num > num2)
							{
								num = num2;
								result = new int[zz93.d.k[i].Length];
								result = zz93.d.k[i];
								if (Math.Sign(num2) == 1 && zz93.d.k[i].Length == 9)
								{
									break;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00017354 File Offset: 0x00016354
		private int[] a(int A_0, int A_1, bool A_2)
		{
			int[] result;
			if (A_2)
			{
				result = new int[9];
			}
			else
			{
				result = new int[8];
			}
			int num = int.MaxValue;
			for (int i = 0; i < zz93.d.k.Length; i++)
			{
				if (!A_2 || zz93.d.k[i].Length != 8)
				{
					if (A_2 || zz93.d.k[i].Length != 9)
					{
						if (zz93.d.k[i].Length != 3)
						{
							int num2 = zz93.d.k[i][3] - (A_0 + A_1 * zz93.d.k[i][2]);
							if (Math.Sign(num2) != -1)
							{
								if (num > num2)
								{
									num = num2;
									result = zz93.d.k[i];
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00017444 File Offset: 0x00016444
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

		// Token: 0x0600003F RID: 63 RVA: 0x000175C8 File Offset: 0x000165C8
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

		// Token: 0x06000040 RID: 64 RVA: 0x00017608 File Offset: 0x00016608
		private bool b(List<byte> A_0)
		{
			return A_0[A_0.Count - 6 - 1] == 50 && A_0[A_0.Count - 7 - 1] == 126;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00017654 File Offset: 0x00016654
		private bool a(List<byte> A_0)
		{
			return A_0[A_0.Count - 1] == 49 && A_0[A_0.Count - 1 - 1] == 126;
		}

		// Token: 0x04000017 RID: 23
		private const int a = 7;

		// Token: 0x04000018 RID: 24
		private const int b = 10;

		// Token: 0x04000019 RID: 25
		private const int c = 9;

		// Token: 0x0400001A RID: 26
		private const int d = 3;

		// Token: 0x0400001B RID: 27
		private const int e = 4;

		// Token: 0x0400001C RID: 28
		private const int f = 8;

		// Token: 0x0400001D RID: 29
		private const int g = 26;

		// Token: 0x0400001E RID: 30
		private const string h = "~1";

		// Token: 0x0400001F RID: 31
		private const string i = "~2";

		// Token: 0x04000020 RID: 32
		private static int[,] j = new int[,]
		{
			{
				16,
				19
			},
			{
				64,
				67
			},
			{
				64,
				67
			},
			{
				256,
				301
			},
			{
				256,
				301
			},
			{
				256,
				301
			},
			{
				256,
				301
			},
			{
				256,
				301
			},
			{
				256,
				301
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				1024,
				1033
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			},
			{
				4096,
				4201
			}
		};

		// Token: 0x04000021 RID: 33
		private static int[][] k = new int[][]
		{
			new int[]
			{
				15,
				17,
				6,
				102,
				13,
				12,
				6,
				1,
				0
			},
			new int[]
			{
				19,
				40,
				6,
				240,
				40,
				33,
				19,
				2,
				0
			},
			new int[]
			{
				23,
				51,
				8,
				408,
				70,
				57,
				33,
				3,
				0
			},
			new int[]
			{
				27,
				76,
				8,
				608,
				110,
				89,
				53,
				4,
				0
			},
			new int[]
			{
				19,
				21,
				6,
				126,
				18,
				15,
				8,
				1
			},
			new int[]
			{
				23,
				48,
				6,
				288,
				49,
				40,
				24,
				2
			},
			new int[]
			{
				27,
				60,
				8,
				480,
				84,
				68,
				40,
				3
			},
			new int[]
			{
				31,
				88,
				8,
				704,
				128,
				104,
				62,
				4
			},
			new int[]
			{
				37,
				120,
				8,
				960,
				178,
				144,
				87,
				5
			},
			new int[]
			{
				41,
				156,
				8,
				1248,
				232,
				187,
				114,
				6
			},
			new int[]
			{
				45,
				196,
				8,
				1568,
				294,
				236,
				145,
				7
			},
			new int[]
			{
				49,
				240,
				8,
				1920,
				362,
				291,
				179,
				8
			},
			new int[]
			{
				53,
				230,
				10,
				2300,
				433,
				348,
				214,
				9
			},
			new int[]
			{
				57,
				272,
				10,
				2720,
				516,
				414,
				256,
				10
			},
			new int[]
			{
				61,
				316,
				10,
				3160,
				601,
				482,
				298,
				11
			},
			new int[]
			{
				67,
				364,
				10,
				3640,
				691,
				554,
				343,
				12
			},
			new int[]
			{
				71,
				416,
				10,
				4160,
				793,
				636,
				394,
				13
			},
			new int[]
			{
				75,
				470,
				10,
				4700,
				896,
				718,
				446,
				14
			},
			new int[]
			{
				79,
				528,
				10,
				5280,
				1008,
				808,
				502,
				15
			},
			new int[]
			{
				83,
				588,
				10,
				5880,
				1123,
				900,
				559,
				16
			},
			new int[]
			{
				87,
				652,
				10,
				6520,
				1246,
				998,
				621,
				17
			},
			new int[]
			{
				91,
				720,
				10,
				7200,
				1378,
				1104,
				687,
				18
			},
			new int[]
			{
				95,
				790,
				10,
				7900,
				1511,
				1210,
				753,
				19
			},
			new int[]
			{
				101,
				864,
				10,
				8640,
				1653,
				1324,
				824,
				20
			},
			new int[]
			{
				105,
				940,
				10,
				9400,
				1801,
				1442,
				898,
				21
			},
			new int[]
			{
				109,
				1020,
				10,
				10200,
				1956,
				1566,
				976,
				22
			},
			new int[]
			{
				113,
				920,
				12,
				11040,
				2116,
				1694,
				1056,
				23
			},
			new int[]
			{
				117,
				992,
				12,
				11904,
				2281,
				1826,
				1138,
				24
			},
			new int[]
			{
				121,
				1066,
				12,
				12792,
				2452,
				1963,
				1224,
				25
			},
			new int[]
			{
				125,
				1144,
				12,
				13728,
				2632,
				2107,
				1314,
				26
			},
			new int[]
			{
				131,
				1224,
				12,
				14688,
				2818,
				2256,
				1407,
				27
			},
			new int[]
			{
				135,
				1306,
				12,
				15672,
				3007,
				2407,
				1501,
				28
			},
			new int[]
			{
				139,
				1392,
				12,
				16704,
				3205,
				2565,
				1600,
				29
			},
			new int[]
			{
				143,
				1480,
				12,
				17760,
				3409,
				2728,
				1702,
				30
			},
			new int[]
			{
				147,
				1570,
				12,
				18840,
				3616,
				2894,
				1806,
				31
			},
			new int[]
			{
				151,
				1664,
				12,
				19968,
				3832,
				3067,
				1914,
				32
			},
			new int[]
			{
				11,
				7,
				4
			}
		};

		// Token: 0x04000022 RID: 34
		private static short[,] l = new short[,]
		{
			{
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1
			},
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1
			},
			{
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0
			},
			{
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1
			},
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}
		};

		// Token: 0x04000023 RID: 35
		private static short[,] m = new short[,]
		{
			{
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1
			},
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1
			},
			{
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0
			},
			{
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0
			},
			{
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1
			},
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}
		};

		// Token: 0x04000024 RID: 36
		private short[,] n;

		// Token: 0x04000025 RID: 37
		private int o;

		// Token: 0x04000026 RID: 38
		private int p;

		// Token: 0x04000027 RID: 39
		private int q = 1;

		// Token: 0x04000028 RID: 40
		private int r = 0;

		// Token: 0x04000029 RID: 41
		private bool s;

		// Token: 0x0400002A RID: 42
		private bool t;

		// Token: 0x0400002B RID: 43
		private byte[] u;

		// Token: 0x0400002C RID: 44
		private int v;

		// Token: 0x0400002D RID: 45
		private int w;

		// Token: 0x0400002E RID: 46
		private string x;

		// Token: 0x0400002F RID: 47
		private bool y = false;

		// Token: 0x04000030 RID: 48
		private bool z;

		// Token: 0x04000031 RID: 49
		private List<byte[]> aa = new List<byte[]>();

		// Token: 0x04000032 RID: 50
		private e ab = new e();
	}
}
