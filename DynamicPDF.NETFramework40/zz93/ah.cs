using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x02000024 RID: 36
	internal class ah
	{
		// Token: 0x06000164 RID: 356 RVA: 0x000280F3 File Offset: 0x000270F3
		internal ah(string A_0, bool A_1)
		{
			this.ao = A_0;
			this.ap = A_1;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0002812C File Offset: 0x0002712C
		internal ah(string A_0, bool A_1, aj A_2)
		{
			this.ao = A_0;
			this.ap = A_1;
			this.aq = A_2;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0002816C File Offset: 0x0002716C
		internal void b(string A_0)
		{
			this.ao = A_0;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00028176 File Offset: 0x00027176
		internal void a(bool A_0)
		{
			this.ap = A_0;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00028180 File Offset: 0x00027180
		internal void b(aj A_0)
		{
			this.aq = A_0;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0002818C File Offset: 0x0002718C
		internal BitArray e()
		{
			long num = long.Parse(this.ao.Substring(4, 13));
			if (this.ap)
			{
				num = 10000000000000L + num;
			}
			long num2 = num / 4537077L;
			long num3 = num % 4537077L;
			int num4 = (int)num2 / 1597;
			int num5 = (int)num2 % 1597;
			int num6 = (int)num3 / 1597;
			int num7 = (int)num3 % 1597;
			int num8 = this.a(zz93.ah.av, num4);
			int a_ = (num4 - zz93.ah.av[num8][1]) / zz93.ah.av[num8][7];
			int a_2 = (num4 - zz93.ah.av[num8][1]) % zz93.ah.av[num8][7];
			int[] array = this.a(a_, zz93.ah.av[num8][2], 4, zz93.ah.av[num8][4], 1);
			int[] array2 = this.a(a_2, zz93.ah.av[num8][3], 4, zz93.ah.av[num8][5], 0);
			int num9 = 0;
			int num10 = 0;
			int[] array3 = new int[array2.Length + array.Length];
			for (int i = 0; i < array2.Length + array.Length; i++)
			{
				if (i % 2 == 0)
				{
					array3[num9++] = array[num10];
				}
				else
				{
					array3[num9++] = array2[num10++];
				}
			}
			int num11 = this.a(zz93.ah.aw, num5);
			int a_3 = (num5 - zz93.ah.aw[num11][1]) / zz93.ah.aw[num11][6];
			int a_4 = (num5 - zz93.ah.aw[num11][1]) % zz93.ah.aw[num11][6];
			int[] array4 = this.a(a_4, zz93.ah.aw[num11][2], 4, zz93.ah.aw[num11][4], 0);
			int[] array5 = this.a(a_3, zz93.ah.aw[num11][3], 4, zz93.ah.aw[num11][5], 1);
			num9 = 0;
			num10 = 0;
			int[] array6 = new int[array5.Length + array4.Length];
			for (int i = 0; i < array5.Length + array4.Length; i++)
			{
				if (i % 2 == 0)
				{
					array6[num9++] = array4[num10];
				}
				else
				{
					array6[num9++] = array5[num10++];
				}
			}
			int num12 = this.a(zz93.ah.av, num6);
			int a_5 = (num6 - zz93.ah.av[num12][1]) / zz93.ah.av[num12][7];
			int a_6 = (num6 - zz93.ah.av[num12][1]) % zz93.ah.av[num12][7];
			int[] array7 = this.a(a_5, zz93.ah.av[num12][2], 4, zz93.ah.av[num12][4], 1);
			int[] array8 = this.a(a_6, zz93.ah.av[num12][3], 4, zz93.ah.av[num12][5], 0);
			num9 = 0;
			num10 = 0;
			int[] array9 = new int[array8.Length + array7.Length];
			for (int i = 0; i < array8.Length + array7.Length; i++)
			{
				if (i % 2 == 0)
				{
					array9[num9++] = array7[num10];
				}
				else
				{
					array9[num9++] = array8[num10++];
				}
			}
			int num13 = this.a(zz93.ah.aw, num7);
			int a_7 = (num7 - zz93.ah.aw[num13][1]) / zz93.ah.aw[num13][6];
			int a_8 = (num7 - zz93.ah.aw[num13][1]) % zz93.ah.aw[num13][6];
			int[] array10 = this.a(a_8, zz93.ah.aw[num13][2], 4, zz93.ah.aw[num13][4], 0);
			int[] array11 = this.a(a_7, zz93.ah.aw[num13][3], 4, zz93.ah.aw[num13][5], 1);
			num9 = 0;
			num10 = 0;
			int[] array12 = new int[array11.Length + array10.Length];
			for (int i = 0; i < array11.Length + array10.Length; i++)
			{
				if (i % 2 == 0)
				{
					array12[num9++] = array10[num10];
				}
				else
				{
					array12[num9++] = array11[num10++];
				}
			}
			int num14 = 0;
			for (int j = 0; j < zz93.ah.ax[0].Length; j++)
			{
				num14 += zz93.ah.ax[0][j] * array3[j];
			}
			for (int j = 0; j < zz93.ah.ax[1].Length; j++)
			{
				num14 += zz93.ah.ax[1][j] * array6[j];
			}
			for (int j = 0; j < zz93.ah.ax[2].Length; j++)
			{
				num14 += zz93.ah.ax[2][j] * array9[j];
			}
			for (int j = 0; j < zz93.ah.ax[3].Length; j++)
			{
				num14 += zz93.ah.ax[3][j] * array12[j];
			}
			int num15 = num14 % 79;
			if (num15 >= 8)
			{
				num15++;
			}
			if (num15 >= 72)
			{
				num15++;
			}
			int num16 = num15 / 9;
			int num17 = num15 % 9;
			int[] array13 = zz93.ah.ay[num16];
			int[] array14 = zz93.ah.ay[num17];
			this.ar = new BitArray(96);
			num9 = 0;
			bool flag = true;
			for (int i = 0; i < zz93.ah.au.Length; i++)
			{
				for (int j = 0; j < zz93.ah.au[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < array3.Length; i++)
			{
				for (int j = 0; j < array3[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < array13.Length; i++)
			{
				for (int j = 0; j < array13[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = array6.Length - 1; i >= 0; i--)
			{
				for (int j = 0; j < array6[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < array12.Length; i++)
			{
				for (int j = 0; j < array12[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = array14.Length - 1; i >= 0; i--)
			{
				for (int j = 0; j < array14[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = array9.Length - 1; i >= 0; i--)
			{
				for (int j = 0; j < array9[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < zz93.ah.au.Length; i++)
			{
				for (int j = 0; j < zz93.ah.au[i]; j++)
				{
					this.ar[num9++] = flag;
				}
				flag = !flag;
			}
			return this.ar;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00028994 File Offset: 0x00027994
		internal BitArray f()
		{
			int num = 0;
			this.ar = this.e();
			this.@as = new BitArray(this.ar.Length / 2 + 2);
			for (int i = 0; i < this.ar.Length / 2; i++)
			{
				this.@as[num++] = this.ar[i];
			}
			this.@as[num++] = false;
			this.@as[num++] = true;
			return this.@as;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00028A34 File Offset: 0x00027A34
		internal BitArray g()
		{
			int num = 0;
			if (this.ar == null)
			{
				this.ar = this.e();
			}
			this.at = new BitArray(this.ar.Length / 2 + 2);
			this.at[num++] = false;
			this.at[num++] = true;
			for (int i = this.ar.Length / 2; i < this.ar.Length; i++)
			{
				this.at[num++] = this.ar[i];
			}
			return this.at;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00028AF0 File Offset: 0x00027AF0
		internal BitArray h()
		{
			int num = 0;
			if (this.@as == null)
			{
				this.@as = this.f();
			}
			if (this.at == null)
			{
				this.at = this.g();
			}
			bool flag = true;
			BitArray bitArray = new BitArray(this.@as.Length);
			for (int i = 0; i < this.@as.Length; i++)
			{
				if (this.@as[i] == this.at[i])
				{
					flag = !this.@as[i];
				}
				else
				{
					flag = !flag;
				}
				if (i < 4 || i >= this.@as.Length - 4)
				{
					flag = true;
				}
				bitArray[num++] = flag;
			}
			return bitArray;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00028BE0 File Offset: 0x00027BE0
		internal BitArray i()
		{
			int num = 0;
			if (this.@as == null)
			{
				this.@as = this.f();
			}
			if (this.at == null)
			{
				this.at = this.g();
			}
			int length = this.@as.Length;
			BitArray bitArray = new BitArray(length * 3);
			for (int i = 0; i < length; i++)
			{
				bool value = !this.@as[i];
				if (i < 4 || i >= length - 4)
				{
					value = true;
				}
				bitArray[num++] = value;
			}
			for (int i = 0; i < length; i++)
			{
				bool value = i % 2 == 0;
				if (i < 4 || i >= length - 4)
				{
					value = true;
				}
				bitArray[num++] = value;
			}
			for (int i = 0; i < length; i++)
			{
				bool value = !this.at[i];
				if (i < 4 || i >= length - 4)
				{
					value = true;
				}
				bitArray[num++] = value;
			}
			return bitArray;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00028D50 File Offset: 0x00027D50
		internal BitArray j()
		{
			string text = this.ao.Substring(4, 13);
			long num = long.Parse(text);
			if (num > 1999999999999L)
			{
				throw new ap("Item number is too large for barcode type Limited.");
			}
			if (this.ap)
			{
				num = 2015133531L + num;
			}
			long num2 = num / 2013571L;
			long num3 = num % 2013571L;
			int num4 = this.a(zz93.ah.az, (int)num2);
			int a_ = ((int)num2 - zz93.ah.az[num4][1]) / zz93.ah.az[num4][7];
			int a_2 = ((int)num2 - zz93.ah.az[num4][1]) % zz93.ah.az[num4][7];
			int[] array = this.a(a_, zz93.ah.az[num4][2], 7, zz93.ah.az[num4][4], 1);
			int[] array2 = this.a(a_2, zz93.ah.az[num4][3], 7, zz93.ah.az[num4][5], 0);
			int num5 = 0;
			int num6 = 0;
			int[] array3 = new int[array2.Length + array.Length];
			for (int i = 0; i < array2.Length + array.Length; i++)
			{
				if (i % 2 == 0)
				{
					array3[num5++] = array[num6];
				}
				else
				{
					array3[num5++] = array2[num6++];
				}
			}
			int num7 = this.a(zz93.ah.az, (int)num3);
			int a_3 = ((int)num3 - zz93.ah.az[num7][1]) / zz93.ah.az[num7][7];
			int a_4 = ((int)num3 - zz93.ah.az[num7][1]) % zz93.ah.az[num7][7];
			int[] array4 = this.a(a_3, zz93.ah.az[num7][2], 7, zz93.ah.az[num7][4], 1);
			int[] array5 = this.a(a_4, zz93.ah.az[num7][3], 7, zz93.ah.az[num7][5], 0);
			num5 = 0;
			num6 = 0;
			int[] array6 = new int[array5.Length + array4.Length];
			for (int i = 0; i < array5.Length + array4.Length; i++)
			{
				if (i % 2 == 0)
				{
					array6[num5++] = array4[num6];
				}
				else
				{
					array6[num5++] = array5[num6++];
				}
			}
			int num8 = 0;
			for (int j = 0; j < zz93.ah.a0[0].Length; j++)
			{
				num8 += zz93.ah.a0[0][j] * array3[j];
			}
			for (int j = 0; j < zz93.ah.a0[1].Length; j++)
			{
				num8 += zz93.ah.a0[1][j] * array6[j];
			}
			int num9 = num8 % 89;
			int[] array7 = zz93.ah.a1[num9];
			this.ar = new BitArray(79);
			num5 = 0;
			bool flag = true;
			for (int i = 0; i < zz93.ah.au.Length; i++)
			{
				for (int j = 0; j < zz93.ah.au[i]; j++)
				{
					this.ar[num5++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < array3.Length; i++)
			{
				for (int j = 0; j < array3[i]; j++)
				{
					this.ar[num5++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < array7.Length; i++)
			{
				for (int j = 0; j < array7[i]; j++)
				{
					this.ar[num5++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < array6.Length; i++)
			{
				for (int j = 0; j < array6[i]; j++)
				{
					this.ar[num5++] = flag;
				}
				flag = !flag;
			}
			for (int i = 0; i < zz93.ah.a2.Length; i++)
			{
				for (int j = 0; j < zz93.ah.a2[i]; j++)
				{
					this.ar[num5++] = flag;
				}
				flag = !flag;
			}
			return this.ar;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000291D4 File Offset: 0x000281D4
		internal BitArray k()
		{
			return this.a(this.d(), true, false);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000291F4 File Offset: 0x000281F4
		internal BitArray[] b(int A_0)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = this.d();
			if (A_0 % 2 != 0)
			{
				A_0--;
			}
			if (this.ap && A_0 < 4)
			{
				throw new an("Composite Symbol should have at least 4 symbol characters in the first row.");
			}
			BitArray[] result;
			if (A_0 > arrayList2.Count - 2)
			{
				result = new BitArray[]
				{
					this.a(arrayList2, true, false)
				};
			}
			else
			{
				arrayList2.RemoveAt(0);
				arrayList2.RemoveAt(arrayList2.Count - 1);
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				ArrayList arrayList3 = new ArrayList();
				int i = 0;
				while (i < arrayList2.Count)
				{
					arrayList3.Add(arrayList2[i]);
					i++;
					num2++;
					if (i < arrayList2.Count)
					{
						num++;
						arrayList3.Add(arrayList2[i]);
						i++;
					}
					if (i < arrayList2.Count)
					{
						num2++;
						arrayList3.Add(arrayList2[i]);
						i++;
					}
					if (num2 >= A_0)
					{
						num3++;
						arrayList3.Insert(0, "11");
						arrayList3.Add("11");
						if (num3 % 2 == 0 && A_0 % 4 == 0)
						{
							arrayList.Add(this.a(arrayList3, false, true));
						}
						else
						{
							arrayList.Add(this.a(arrayList3, num3 % 2 != 0, false));
						}
						arrayList3 = new ArrayList();
						num2 = 0;
						num = 0;
					}
				}
				if (arrayList3.Count > 0)
				{
					num3++;
					arrayList3.Insert(0, "11");
					arrayList3.Add("11");
					if (num2 < A_0 && num % 2 != 0)
					{
						BitArray bitArray = this.a(arrayList3, true, false);
						BitArray bitArray2 = new BitArray(bitArray.Length + 1);
						bitArray2.Set(0, true);
						for (i = 0; i < bitArray.Length; i++)
						{
							bitArray2[i + 1] = bitArray[i];
						}
						arrayList.Add(bitArray2);
					}
					else if (num3 % 2 == 0 && A_0 % 4 == 0)
					{
						arrayList.Add(this.a(arrayList3, false, true));
					}
					else
					{
						arrayList.Add(this.a(arrayList3, num3 % 2 != 0, false));
					}
				}
				if (num3 > 11)
				{
					throw new ao("Data did not fit in 11 rows, please try increasing the ExpandedStackedSegmentCount.");
				}
				result = this.a(arrayList);
			}
			return result;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000294D8 File Offset: 0x000284D8
		private BitArray[] a(ArrayList A_0)
		{
			BitArray[] result;
			if (A_0.Count == 1)
			{
				result = new BitArray[]
				{
					(BitArray)A_0[0]
				};
			}
			else
			{
				BitArray[] array = new BitArray[A_0.Count + A_0.Count - 1];
				int num = 0;
				for (int i = 0; i < A_0.Count; i++)
				{
					if (i + 1 == A_0.Count)
					{
						break;
					}
					BitArray bitArray = (BitArray)A_0[i];
					BitArray bitArray2 = (BitArray)A_0[i + 1];
					if (i == 0)
					{
						array[num++] = bitArray;
					}
					array[num++] = this.a(bitArray, bitArray2);
					array[num++] = bitArray2;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000295B4 File Offset: 0x000285B4
		private BitArray a(BitArray A_0, BitArray A_1)
		{
			int length = A_0.Length;
			int num = 0;
			int num2 = 19;
			BitArray bitArray = new BitArray(length * 3);
			for (int i = 0; i < length; i++)
			{
				bool value = !A_0[i];
				if (i < 4 || i >= length - 4)
				{
					value = true;
				}
				if (i >= num2 && i <= num2 + 15)
				{
					int num3 = 0;
					do
					{
						if (A_0[i])
						{
							if (num3 % 2 == 0)
							{
								bitArray[num++] = false;
							}
							else
							{
								bitArray[num++] = true;
							}
							num3++;
						}
						else
						{
							bitArray[num++] = true;
							num3 = 0;
						}
						i++;
					}
					while (i < num2 + 15);
					num2 += 49;
					i--;
				}
				else
				{
					bitArray[num++] = value;
				}
			}
			for (int i = 0; i < length; i++)
			{
				bool value = i % 2 == 0;
				if (i < 4 || i >= length - 4)
				{
					value = true;
				}
				bitArray[num++] = value;
			}
			num2 = 19;
			for (int i = 0; i < length; i++)
			{
				if (i > A_1.Length - 1)
				{
					bitArray[num++] = true;
				}
				else
				{
					bool value = !A_1[i];
					if (i < 4 || i >= A_1.Length - 4)
					{
						value = true;
					}
					if (i >= num2 && i <= num2 + 15)
					{
						int num3 = 0;
						do
						{
							if (A_1[i])
							{
								if (num3 % 2 == 0)
								{
									bitArray[num++] = false;
								}
								else
								{
									bitArray[num++] = true;
								}
								num3++;
							}
							else
							{
								bitArray[num++] = true;
								num3 = 0;
							}
							i++;
						}
						while (i < num2 + 15);
						num2 += 49;
						i--;
					}
					else
					{
						bitArray[num++] = value;
					}
				}
			}
			return bitArray;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0002985C File Offset: 0x0002885C
		private BitArray a(ArrayList A_0, bool A_1, bool A_2)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < A_0.Count; i++)
			{
				string text = A_0[i].ToString();
				for (int j = 0; j < text.Length; j++)
				{
					num += int.Parse(text[j].ToString());
				}
				num2 += text.Length;
			}
			BitArray bitArray = new BitArray(num);
			int[] array = new int[num2];
			num = 0;
			for (int i = 0; i < A_0.Count; i++)
			{
				string text = A_0[i].ToString();
				for (int j = 0; j < text.Length; j++)
				{
					array[num++] = int.Parse(text[j].ToString());
				}
			}
			if (A_2)
			{
				Array.Reverse(array);
			}
			int num3 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				for (int k = 0; k < array[i]; k++)
				{
					bitArray[num3++] = A_1;
				}
				A_1 = !A_1;
			}
			return bitArray;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000299A8 File Offset: 0x000289A8
		private ArrayList d()
		{
			this.a3 = zz93.ak.a;
			int num = 0;
			ArrayList arrayList = new ArrayList();
			if (this.ap)
			{
				arrayList.Add("1");
			}
			else
			{
				arrayList.Add("0");
			}
			num++;
			string text = this.a(this.aq);
			arrayList.Add(text);
			num += text.Length;
			string text2 = string.Empty;
			string empty = string.Empty;
			string a_ = string.Empty;
			switch (this.aq)
			{
			case zz93.aj.a:
				a_ = this.c(ref empty);
				text2 = this.a(a_, empty, ref this.a3);
				break;
			case zz93.aj.b:
				text2 = this.a(string.Empty, this.ao, ref this.a3);
				break;
			case zz93.aj.c:
				text2 = this.c();
				break;
			case zz93.aj.d:
				text2 = this.b();
				break;
			case zz93.aj.e:
				a_ = this.b(ref empty);
				text2 = this.a(a_, empty, ref this.a3);
				break;
			case zz93.aj.f:
				a_ = this.a(ref empty);
				text2 = this.a(a_, empty, ref this.a3);
				break;
			case zz93.aj.g:
			case zz93.aj.h:
			case zz93.aj.i:
			case zz93.aj.j:
			case zz93.aj.k:
			case zz93.aj.l:
			case zz93.aj.m:
			case zz93.aj.n:
				text2 = this.a();
				break;
			}
			if (this.aq == zz93.aj.a || this.aq == zz93.aj.b || this.aq == zz93.aj.e || this.aq == zz93.aj.f)
			{
				num += 2;
			}
			num += text2.Length;
			int num2 = num / 12;
			int num3 = (num % 12 > 0) ? (12 - num % 12) : 0;
			if (num3 > 0)
			{
				num2++;
			}
			if (num2 + 1 > 22)
			{
				throw new ao("Data length exceeds the limit");
			}
			string text3 = this.a(num2 + 1);
			if (text3.Length > 0)
			{
				arrayList.Add(text3);
			}
			arrayList.Add(text2);
			int i;
			if (num3 > 0)
			{
				if (num3 > 3 && this.a3 == zz93.ak.a)
				{
					arrayList.Add("0000");
					num3 -= 4;
				}
				else if (this.a3 == zz93.ak.a)
				{
					arrayList.Add("0000".Substring(0, num3 % 4));
					num3 -= num3 % 4;
				}
				for (i = 0; i < num3 / 5; i++)
				{
					arrayList.Add("00100");
				}
				if (num3 % 5 > 0)
				{
					arrayList.Add("00100".Substring(0, num3 % 5));
				}
			}
			string text4 = string.Empty;
			for (i = 0; i < arrayList.Count; i++)
			{
				text4 += arrayList[i];
			}
			ArrayList arrayList2 = new ArrayList();
			int num4 = 0;
			i = 0;
			int num6;
			int a_2;
			int a_3;
			int[] array;
			int[] array2;
			int num7;
			int num8;
			int[] array3;
			while (i < text4.Length)
			{
				int num5 = Convert.ToInt32(text4.Substring(i, 12), 2);
				i += 12;
				num6 = this.a(zz93.ah.a6, num5);
				a_2 = (num5 - zz93.ah.a6[num6][1]) / zz93.ah.a6[num6][7];
				a_3 = (num5 - zz93.ah.a6[num6][1]) % zz93.ah.a6[num6][7];
				array = this.a(a_2, zz93.ah.a6[num6][2], 4, zz93.ah.a6[num6][4], 0);
				array2 = this.a(a_3, zz93.ah.a6[num6][3], 4, zz93.ah.a6[num6][5], 1);
				num7 = 0;
				num8 = 0;
				array3 = new int[array2.Length + array.Length];
				for (int j = 0; j < array2.Length + array.Length; j++)
				{
					if (j % 2 == 0)
					{
						array3[num7++] = array[num8];
					}
					else
					{
						array3[num7++] = array2[num8++];
					}
				}
				arrayList2.Add(array3);
			}
			arrayList = new ArrayList();
			arrayList.Add("11");
			int[] array4;
			if (num2 + 1 == 4)
			{
				array4 = zz93.ah.a8[0];
			}
			else if (num2 + 1 == 5 || num2 + 1 == 6)
			{
				array4 = zz93.ah.a8[1];
			}
			else if (num2 + 1 == 7 || num2 + 1 == 8)
			{
				array4 = zz93.ah.a8[2];
			}
			else if (num2 + 1 == 9 || num2 + 1 == 10)
			{
				array4 = zz93.ah.a8[3];
			}
			else if (num2 + 1 == 11 || num2 + 1 == 12)
			{
				array4 = zz93.ah.a8[4];
			}
			else if (num2 + 1 == 13 || num2 + 1 == 14)
			{
				array4 = zz93.ah.a8[5];
			}
			else if (num2 + 1 == 15 || num2 + 1 == 16)
			{
				array4 = zz93.ah.a8[6];
			}
			else if (num2 + 1 == 17 || num2 + 1 == 18)
			{
				array4 = zz93.ah.a8[7];
			}
			else if (num2 + 1 == 19 || num2 + 1 == 20)
			{
				array4 = zz93.ah.a8[8];
			}
			else
			{
				array4 = zz93.ah.a8[9];
			}
			num8 = 0;
			for (i = 0; i < array4.Length; i++)
			{
				int num9 = array4[i];
				int num10 = Math.Abs(num9) * 4 - 1;
				if (num9 > 0)
				{
					num10 -= 2;
				}
				int[] array5;
				if (i > 0)
				{
					num10--;
					if (num8 >= arrayList2.Count)
					{
						break;
					}
					array5 = (int[])arrayList2[num8++];
					for (int k = 0; k < array5.Length; k++)
					{
						num4 += zz93.ah.a5[num10][k] * array5[k];
					}
					num10++;
				}
				if (num8 >= arrayList2.Count)
				{
					break;
				}
				array5 = (int[])arrayList2[num8++];
				for (int k = 0; k < array5.Length; k++)
				{
					num4 += zz93.ah.a5[num10][k] * array5[k];
				}
			}
			int num11 = num4 % 211;
			num11 = 211 * (arrayList2.Count + 1 - 4) + num11;
			num6 = this.a(zz93.ah.a6, num11);
			a_2 = (num11 - zz93.ah.a6[num6][1]) / zz93.ah.a6[num6][7];
			a_3 = (num11 - zz93.ah.a6[num6][1]) % zz93.ah.a6[num6][7];
			array = this.a(a_2, zz93.ah.a6[num6][2], 4, zz93.ah.a6[num6][4], 0);
			array2 = this.a(a_3, zz93.ah.a6[num6][3], 4, zz93.ah.a6[num6][5], 1);
			num7 = 0;
			num8 = 0;
			array3 = new int[array2.Length + array.Length];
			for (int j = 0; j < array2.Length + array.Length; j++)
			{
				if (j % 2 == 0)
				{
					array3[num7++] = array[num8];
				}
				else
				{
					array3[num7++] = array2[num8++];
				}
			}
			string text5 = string.Empty;
			for (i = 0; i < array3.Length; i++)
			{
				text5 += array3[i];
			}
			arrayList.Add(text5);
			num8 = 0;
			for (i = 0; i < array4.Length; i++)
			{
				int[] array6 = zz93.ah.a7[Math.Abs(array4[i]) - 1];
				string value = string.Empty;
				if (array4[i] < 0)
				{
					value = string.Concat(new string[]
					{
						array6[4].ToString(),
						array6[3].ToString(),
						array6[2].ToString(),
						array6[1].ToString(),
						array6[0].ToString()
					});
				}
				else
				{
					value = string.Concat(new string[]
					{
						array6[0].ToString(),
						array6[1].ToString(),
						array6[2].ToString(),
						array6[3].ToString(),
						array6[4].ToString()
					});
				}
				arrayList.Add(value);
				if (num8 >= arrayList2.Count)
				{
					break;
				}
				string text6 = string.Empty;
				int[] array5 = (int[])arrayList2[num8++];
				for (int k = array5.Length - 1; k >= 0; k--)
				{
					text6 += array5[k];
				}
				arrayList.Add(text6);
				if (num8 >= arrayList2.Count)
				{
					break;
				}
				text6 = string.Empty;
				array5 = (int[])arrayList2[num8++];
				for (int k = 0; k < array5.Length; k++)
				{
					text6 += array5[k];
				}
				arrayList.Add(text6);
			}
			arrayList.Add("11");
			return arrayList;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0002A3E0 File Offset: 0x000293E0
		private string a(aj A_0)
		{
			string result;
			switch (A_0)
			{
			case zz93.aj.b:
				result = "00";
				break;
			case zz93.aj.c:
				result = "0100";
				break;
			case zz93.aj.d:
				result = "0101";
				break;
			case zz93.aj.e:
				result = "01100";
				break;
			case zz93.aj.f:
				result = "01101";
				break;
			case zz93.aj.g:
				result = "0111000";
				break;
			case zz93.aj.h:
				result = "0111001";
				break;
			case zz93.aj.i:
				result = "0111010";
				break;
			case zz93.aj.j:
				result = "0111011";
				break;
			case zz93.aj.k:
				result = "0111100";
				break;
			case zz93.aj.l:
				result = "0111101";
				break;
			case zz93.aj.m:
				result = "0111110";
				break;
			case zz93.aj.n:
				result = "0111111";
				break;
			default:
				result = "1";
				break;
			}
			return result;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0002A4A0 File Offset: 0x000294A0
		private string a(int A_0)
		{
			string text = string.Empty;
			if (this.aq == zz93.aj.b || this.aq == zz93.aj.a || this.aq == zz93.aj.e || this.aq == zz93.aj.f)
			{
				if (A_0 % 2 == 0)
				{
					text += "0";
				}
				else
				{
					text += "1";
				}
				if (A_0 > 14)
				{
					text += "1";
				}
				else
				{
					text += "0";
				}
			}
			return text;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0002A538 File Offset: 0x00029538
		private string c(ref string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ao.Substring(4, 13);
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(0, 1)), 2).PadLeft(4, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(1, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(4, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(7, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(10, 3)), 2).PadLeft(10, '0'));
			A_0 = this.ao.Substring(18);
			return stringBuilder.ToString();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0002A624 File Offset: 0x00029624
		private string c()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ao.Substring(5, 12);
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(0, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(3, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(6, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(9, 3)), 2).PadLeft(10, '0'));
			int value = int.Parse(this.ao.Substring(24));
			stringBuilder.Append(Convert.ToString(value, 2).PadLeft(15, '0'));
			return stringBuilder.ToString();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0002A708 File Offset: 0x00029708
		private string b()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ao.Substring(5, 12);
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(0, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(3, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(6, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(9, 3)), 2).PadLeft(10, '0'));
			int num = int.Parse(this.ao.Substring(24));
			int num2 = int.Parse(this.ao.Substring(19, 4));
			if (num2 == 3202)
			{
				stringBuilder.Append(Convert.ToString(num, 2).PadLeft(15, '0'));
			}
			else if (num2 == 3203)
			{
				stringBuilder.Append(Convert.ToString(num + 10000, 2).PadLeft(15, '0'));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0002A844 File Offset: 0x00029844
		private string a()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ao.Substring(5, 12);
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(0, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(3, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(6, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(9, 3)), 2).PadLeft(10, '0'));
			string str = this.ao[22].ToString();
			string text2 = this.ao.Substring(24, 6);
			int value = int.Parse(str + text2.Substring(1));
			stringBuilder.Append(Convert.ToString(value, 2).PadLeft(20, '0'));
			int value2 = int.Parse(this.ao.Substring(34, 2)) * 384 + (int.Parse(this.ao.Substring(36, 2)) - 1) * 32 + int.Parse(this.ao.Substring(38, 2));
			stringBuilder.Append(Convert.ToString(value2, 2).PadLeft(16, '0'));
			return stringBuilder.ToString();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0002A9B4 File Offset: 0x000299B4
		private string b(ref string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ao.Substring(5, 12);
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(0, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(3, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(6, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(9, 3)), 2).PadLeft(10, '0'));
			int value = int.Parse(this.ao.Substring(22, 1));
			stringBuilder.Append(Convert.ToString(value, 2).PadLeft(2, '0'));
			A_0 = this.ao.Substring(24);
			return stringBuilder.ToString();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0002AAA8 File Offset: 0x00029AA8
		private string a(ref string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ao.Substring(5, 12);
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(0, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(3, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(6, 3)), 2).PadLeft(10, '0'));
			stringBuilder.Append(Convert.ToString(int.Parse(text.Substring(9, 3)), 2).PadLeft(10, '0'));
			int value = int.Parse(this.ao.Substring(22, 1));
			stringBuilder.Append(Convert.ToString(value, 2).PadLeft(2, '0'));
			int value2 = int.Parse(this.ao.Substring(24, 3));
			stringBuilder.Append(Convert.ToString(value2, 2).PadLeft(10, '0'));
			A_0 = this.ao.Substring(27);
			return stringBuilder.ToString();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0002ABC8 File Offset: 0x00029BC8
		private string a(string A_0, string A_1, ref ak A_2)
		{
			string result;
			if (A_1.Length <= 0)
			{
				result = ((A_0.Length > 0) ? A_0 : string.Empty);
			}
			else
			{
				byte[] array = this.a(A_1);
				int i = 0;
				StringBuilder stringBuilder = new StringBuilder();
				while (i < array.Length)
				{
					switch (A_2)
					{
					case zz93.ak.a:
						if (array[i] == 128 && i + 1 < array.Length)
						{
							if (array[i + 1] >= 48 && array[i + 1] <= 57)
							{
								stringBuilder.Append(this.b(10, (int)(array[i + 1] - 48)));
								i += 2;
								break;
							}
						}
						if (array[i] >= 48 && array[i] <= 57 && i + 1 < array.Length)
						{
							if (array[i + 1] >= 48 && array[i + 1] <= 57)
							{
								stringBuilder.Append(this.b((int)(array[i] - 48), (int)(array[i + 1] - 48)));
								i += 2;
								break;
							}
							if (array[i + 1] == 128)
							{
								stringBuilder.Append(this.b((int)(array[i] - 48), 10));
								i += 2;
								break;
							}
						}
						if (array[i] >= 48 && array[i] <= 57 && i + 1 == array.Length)
						{
							if (A_0 != string.Empty)
							{
								stringBuilder.Insert(0, A_0);
							}
							int num = stringBuilder.ToString().Length;
							num += this.a(this.aq).Length;
							num++;
							if (this.aq == zz93.aj.a || this.aq == zz93.aj.b || this.aq == zz93.aj.e || this.aq == zz93.aj.f)
							{
								num += 2;
							}
							int num2 = num / 12;
							int num3 = (num % 12 == 0) ? 0 : (12 - num % 12);
							if (num3 > 0)
							{
								num2++;
							}
							if (num3 >= 7)
							{
								stringBuilder.Append(this.b((int)(array[i] - 48), 10));
								num3 -= 7;
							}
							else if (num3 >= 4 && num3 <= 6)
							{
								stringBuilder.Append(Convert.ToString((int)(array[i] - 48 + 1), 2).PadLeft(4, '0'));
								num3 -= 4;
							}
							else
							{
								num3 += 12;
								stringBuilder.Append(this.b((int)(array[i] - 48), 10));
								num3 -= 7;
							}
							stringBuilder.Append(this.a(A_2, num3));
							return stringBuilder.ToString();
						}
						stringBuilder.Append("0000");
						A_2 = zz93.ak.b;
						break;
					case zz93.ak.b:
					{
						int num4 = this.a(i, array);
						if (num4 > 6 || (num4 > 4 && num4 + i == array.Length))
						{
							stringBuilder.Append("000");
							A_2 = zz93.ak.a;
						}
						else if (array[i] == 128)
						{
							stringBuilder.Append("01111");
							A_2 = zz93.ak.a;
							i++;
						}
						else if (array[i] >= 48 && array[i] <= 57)
						{
							stringBuilder.Append(Convert.ToString((int)(array[i] - 43), 2).PadLeft(5, '0'));
							i++;
						}
						else if (array[i] >= 65 && array[i] <= 90)
						{
							stringBuilder.Append(Convert.ToString((int)(array[i] - 33), 2).PadLeft(6, '0'));
							i++;
						}
						else if (array[i] == 42)
						{
							stringBuilder.Append("111010");
							i++;
						}
						else if (array[i] == 44)
						{
							stringBuilder.Append("111011");
							i++;
						}
						else if (array[i] == 45)
						{
							stringBuilder.Append("111100");
							i++;
						}
						else if (array[i] == 46)
						{
							stringBuilder.Append("111101");
							i++;
						}
						else if (array[i] == 47)
						{
							stringBuilder.Append("111110");
							i++;
						}
						else
						{
							stringBuilder.Append("00100");
							A_2 = zz93.ak.c;
						}
						break;
					}
					case zz93.ak.c:
						if (array[i] == 128)
						{
							stringBuilder.Append("01111");
							A_2 = zz93.ak.a;
							i++;
						}
						else
						{
							int num5 = 0;
							bool flag = true;
							bool flag2 = false;
							int num6 = 0;
							bool flag3 = true;
							for (int j = i; j < array.Length; j++)
							{
								if (j > i + 10 || flag2)
								{
									break;
								}
								if (array[j] >= 48 && array[j] <= 57 && flag)
								{
									num5++;
								}
								else
								{
									flag = false;
								}
								if (((array[j] >= 48 && array[j] <= 57) || (array[j] >= 65 && array[j] <= 90) || array[j] >= 42 || array[j] >= 44 || array[j] >= 45 || array[j] >= 46 || array[j] >= 47) && flag3)
								{
									num6++;
								}
								else
								{
									flag3 = false;
								}
								if ((array[j] >= 97 && array[j] <= 122) || array[j] == 32 || array[j] == 33 || array[j] == 34 || array[j] == 37 || array[j] == 38 || array[j] == 39 || array[j] == 40 || array[j] == 41 || array[j] == 43 || array[j] == 58 || array[j] == 59 || array[j] == 60 || array[j] == 61 || array[j] == 62 || array[j] == 63 || array[j] == 95)
								{
									flag2 = true;
								}
							}
							if (!flag2 && num5 > 3)
							{
								stringBuilder.Append("000");
								A_2 = zz93.ak.a;
							}
							else if (!flag2 && num6 > 4)
							{
								stringBuilder.Append("00100");
								A_2 = zz93.ak.b;
							}
							else if (array[i] >= 48 && array[i] <= 57)
							{
								stringBuilder.Append(Convert.ToString((int)(array[i] - 43), 2).PadLeft(5, '0'));
								i++;
							}
							else if (array[i] >= 65 && array[i] <= 90)
							{
								stringBuilder.Append(Convert.ToString((int)(array[i] - 1), 2).PadLeft(7, '0'));
								i++;
							}
							else if (array[i] >= 97 && array[i] <= 122)
							{
								stringBuilder.Append(Convert.ToString((int)(array[i] - 7), 2).PadLeft(7, '0'));
								i++;
							}
							else
							{
								byte b = array[i];
								switch (b)
								{
								case 32:
									stringBuilder.Append("11111100");
									i++;
									break;
								case 33:
									stringBuilder.Append("11101000");
									i++;
									break;
								case 34:
									stringBuilder.Append("11101001");
									i++;
									break;
								case 35:
								case 36:
								case 48:
								case 49:
								case 50:
								case 51:
								case 52:
								case 53:
								case 54:
								case 55:
								case 56:
								case 57:
									break;
								case 37:
									stringBuilder.Append("11101010");
									i++;
									break;
								case 38:
									stringBuilder.Append("11101011");
									i++;
									break;
								case 39:
									stringBuilder.Append("11101100");
									i++;
									break;
								case 40:
									stringBuilder.Append("11101101");
									i++;
									break;
								case 41:
									stringBuilder.Append("11101110");
									i++;
									break;
								case 42:
									stringBuilder.Append("11101111");
									i++;
									break;
								case 43:
									stringBuilder.Append("11110000");
									i++;
									break;
								case 44:
									stringBuilder.Append("11110001");
									i++;
									break;
								case 45:
									stringBuilder.Append("11110010");
									i++;
									break;
								case 46:
									stringBuilder.Append("11110011");
									i++;
									break;
								case 47:
									stringBuilder.Append("11110100");
									i++;
									break;
								case 58:
									stringBuilder.Append("11110101");
									i++;
									break;
								case 59:
									stringBuilder.Append("11110110");
									i++;
									break;
								case 60:
									stringBuilder.Append("11110111");
									i++;
									break;
								case 61:
									stringBuilder.Append("11111000");
									i++;
									break;
								case 62:
									stringBuilder.Append("11111001");
									i++;
									break;
								case 63:
									stringBuilder.Append("11111010");
									i++;
									break;
								default:
									if (b == 95)
									{
										stringBuilder.Append("11111011");
										i++;
									}
									break;
								}
							}
						}
						break;
					}
				}
				if (A_0 != string.Empty)
				{
					stringBuilder.Insert(0, A_0);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0002B598 File Offset: 0x0002A598
		private int a(int A_0, byte[] A_1)
		{
			int num = 0;
			for (int i = A_0; i < A_1.Length; i++)
			{
				if ((A_1[i] < 48 || A_1[i] > 57) && A_1[i] != 128)
				{
					break;
				}
				num++;
				if (num > 6)
				{
					break;
				}
			}
			return num;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0002B5FC File Offset: 0x0002A5FC
		private byte[] a(string A_0)
		{
			int num = 0;
			int num2 = 0;
			bool flag = false;
			int num3;
			do
			{
				bool flag2 = true;
				string text = string.Empty;
				num3 = A_0.IndexOf('(', num);
				if (num3 == -1)
				{
					flag2 = false;
				}
				num = A_0.IndexOf(')', num + 1);
				if (num == -1)
				{
					flag2 = false;
				}
				for (int i = num3 + 1; i < num; i++)
				{
					if ((byte)A_0[i] < 48 || (byte)A_0[i] > 57)
					{
						flag2 = false;
						break;
					}
					text += A_0[i];
				}
				if (flag2 && text.Length > 0)
				{
					A_0 = A_0.Remove(num3, 1);
					A_0 = A_0.Remove(--num, 1);
					if (flag)
					{
						A_0 = A_0.Insert(num3, "~1");
					}
					flag = !this.a(text, ref num2);
				}
			}
			while (num3 >= 0 && num >= 0);
			byte[] array = new byte[A_0.Length];
			int num4 = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				if ((byte)A_0[i] == 126 && (byte)A_0[i + 1] == 49)
				{
					array[num4++] = 128;
					i++;
				}
				else
				{
					array[num4++] = (byte)A_0[i];
				}
			}
			byte[] array2 = new byte[num4];
			Array.Copy(array, array2, array2.Length);
			return array2;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0002B7C4 File Offset: 0x0002A7C4
		private bool a(string A_0, ref int A_1)
		{
			for (int i = 0; i < zz93.ah.a9.Length; i++)
			{
				if (A_0.Substring(0, 2) == zz93.ah.a9[i][0].ToString())
				{
					A_1 = zz93.ah.a9[i][1];
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0002B828 File Offset: 0x0002A828
		private bool a(byte A_0)
		{
			for (int i = 0; i < zz93.ah.a4.Length; i++)
			{
				if (zz93.ah.a4[i] == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0002B868 File Offset: 0x0002A868
		private string b(int A_0, int A_1)
		{
			int num = 11 * A_0 + A_1 + 8;
			if (num < 8 || num > 127)
			{
				throw new ap("Wrong value for a Numeric encoding");
			}
			return Convert.ToString(num, 2).PadLeft(7, '0');
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0002B8B4 File Offset: 0x0002A8B4
		private int a(int[][] A_0, int A_1)
		{
			int result = -1;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_1 >= A_0[i][1] && A_1 <= A_0[i][0])
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0002B8FC File Offset: 0x0002A8FC
		private int[] a(int A_0, int A_1, int A_2, int A_3, int A_4)
		{
			int[] array = new int[A_2];
			int num = 0;
			int i;
			for (i = 0; i < A_2 - 1; i++)
			{
				int num2 = 1;
				num |= 1 << i;
				int num3;
				for (;;)
				{
					num3 = this.a(A_1 - num2 - 1, A_2 - i - 2);
					if (A_4 == 0 && num == 0 && A_1 - num2 - (A_2 - i - 1) >= A_2 - i - 1)
					{
						num3 -= this.a(A_1 - num2 - (A_2 - i), A_2 - i - 2);
					}
					if (A_2 - i - 1 > 1)
					{
						int num4 = 0;
						for (int j = A_1 - num2 - (A_2 - i - 2); j > A_3; j--)
						{
							num4 += this.a(A_1 - num2 - j - 1, A_2 - i - 3);
						}
						num3 -= num4 * (A_2 - 1 - i);
					}
					else if (A_1 - num2 > A_3)
					{
						num3--;
					}
					A_0 -= num3;
					if (A_0 < 0)
					{
						break;
					}
					num2++;
					num &= ~(1 << i);
				}
				A_0 += num3;
				A_1 -= num2;
				array[i] = num2;
			}
			array[i] = A_1;
			return array;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0002BA48 File Offset: 0x0002AA48
		private int a(int A_0, int A_1)
		{
			int i = 1;
			int num = 1;
			int num2;
			int num3;
			if (A_0 - A_1 > A_1)
			{
				num2 = A_1;
				num3 = A_0 - A_1;
			}
			else
			{
				num2 = A_0 - A_1;
				num3 = A_1;
			}
			for (int j = A_0; j > num3; j--)
			{
				num *= j;
				if (i <= num2)
				{
					num /= i;
					i++;
				}
			}
			while (i <= num2)
			{
				num /= i;
				i++;
			}
			return num;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0002BAD0 File Offset: 0x0002AAD0
		private string a(ak A_0, int A_1)
		{
			string text = string.Empty;
			if (A_1 > 0)
			{
				if (A_1 > 3 && A_0 == zz93.ak.a)
				{
					text += "0000";
					A_1 -= 4;
				}
				else if (A_0 == zz93.ak.a)
				{
					text += "0000".Substring(0, A_1 % 4);
					A_1 -= A_1 % 4;
				}
				for (int i = 0; i < A_1 / 5; i++)
				{
					text += "00100";
				}
				if (A_1 % 5 > 0)
				{
					text += "00100".Substring(0, A_1 % 5);
				}
			}
			return text;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0002BB8C File Offset: 0x0002AB8C
		// Note: this type is marked as 'beforefieldinit'.
		static ah()
		{
			int[][] array = new int[24][];
			int[][] array2 = array;
			int num = 0;
			int[] array3 = new int[8];
			array2[num] = array3;
			array[1] = new int[]
			{
				1,
				3,
				9,
				27,
				81,
				32,
				96,
				77
			};
			array[2] = new int[]
			{
				20,
				60,
				180,
				118,
				143,
				7,
				21,
				63
			};
			array[3] = new int[]
			{
				189,
				145,
				13,
				39,
				117,
				140,
				209,
				205
			};
			array[4] = new int[]
			{
				193,
				157,
				49,
				147,
				19,
				57,
				171,
				91
			};
			array[5] = new int[]
			{
				62,
				186,
				136,
				197,
				169,
				85,
				44,
				132
			};
			array[6] = new int[]
			{
				185,
				133,
				188,
				142,
				4,
				12,
				36,
				108
			};
			array[7] = new int[]
			{
				113,
				128,
				173,
				97,
				80,
				29,
				87,
				50
			};
			array[8] = new int[]
			{
				150,
				28,
				84,
				41,
				123,
				158,
				52,
				156
			};
			array[9] = new int[]
			{
				46,
				138,
				203,
				187,
				139,
				206,
				196,
				166
			};
			array[10] = new int[]
			{
				76,
				17,
				51,
				153,
				37,
				111,
				122,
				155
			};
			array[11] = new int[]
			{
				43,
				129,
				176,
				106,
				107,
				110,
				119,
				146
			};
			array[12] = new int[]
			{
				16,
				48,
				144,
				10,
				30,
				90,
				59,
				177
			};
			array[13] = new int[]
			{
				109,
				116,
				137,
				200,
				178,
				112,
				125,
				164
			};
			array[14] = new int[]
			{
				70,
				210,
				208,
				202,
				184,
				130,
				179,
				115
			};
			array[15] = new int[]
			{
				134,
				191,
				151,
				31,
				93,
				68,
				204,
				190
			};
			array[16] = new int[]
			{
				148,
				22,
				66,
				198,
				172,
				94,
				71,
				2
			};
			array[17] = new int[]
			{
				6,
				18,
				54,
				162,
				64,
				192,
				154,
				40
			};
			array[18] = new int[]
			{
				120,
				149,
				25,
				75,
				14,
				42,
				126,
				167
			};
			array[19] = new int[]
			{
				79,
				26,
				78,
				23,
				69,
				207,
				199,
				175
			};
			array[20] = new int[]
			{
				103,
				98,
				83,
				38,
				114,
				131,
				182,
				124
			};
			array[21] = new int[]
			{
				161,
				61,
				183,
				127,
				170,
				88,
				53,
				159
			};
			array[22] = new int[]
			{
				55,
				165,
				73,
				8,
				24,
				72,
				5,
				15
			};
			array[23] = new int[]
			{
				45,
				135,
				194,
				160,
				58,
				174,
				100,
				89
			};
			zz93.ah.a5 = array;
			zz93.ah.a6 = new int[][]
			{
				new int[]
				{
					347,
					0,
					12,
					5,
					7,
					2,
					87,
					4
				},
				new int[]
				{
					1387,
					348,
					10,
					7,
					5,
					4,
					52,
					20
				},
				new int[]
				{
					2947,
					1388,
					8,
					9,
					4,
					5,
					30,
					52
				},
				new int[]
				{
					3987,
					2948,
					6,
					11,
					3,
					6,
					10,
					104
				},
				new int[]
				{
					4191,
					3988,
					4,
					13,
					1,
					8,
					1,
					204
				}
			};
			zz93.ah.a7 = new int[][]
			{
				new int[]
				{
					1,
					8,
					4,
					1,
					1
				},
				new int[]
				{
					3,
					6,
					4,
					1,
					1
				},
				new int[]
				{
					3,
					4,
					6,
					1,
					1
				},
				new int[]
				{
					3,
					2,
					8,
					1,
					1
				},
				new int[]
				{
					2,
					6,
					5,
					1,
					1
				},
				new int[]
				{
					2,
					2,
					9,
					1,
					1
				}
			};
			zz93.ah.a8 = new int[][]
			{
				new int[]
				{
					1,
					-1
				},
				new int[]
				{
					1,
					-2,
					2
				},
				new int[]
				{
					1,
					-3,
					2,
					-4
				},
				new int[]
				{
					1,
					-5,
					2,
					-4,
					3
				},
				new int[]
				{
					1,
					-5,
					2,
					-4,
					4,
					-6
				},
				new int[]
				{
					1,
					-5,
					2,
					-4,
					5,
					-6,
					6
				},
				new int[]
				{
					1,
					-1,
					2,
					-2,
					3,
					-3,
					4,
					-4
				},
				new int[]
				{
					1,
					-1,
					2,
					-2,
					3,
					-3,
					4,
					-5,
					5
				},
				new int[]
				{
					1,
					-1,
					2,
					-2,
					3,
					-3,
					4,
					-5,
					6,
					-6
				},
				new int[]
				{
					1,
					-1,
					2,
					-2,
					3,
					-4,
					4,
					-5,
					5,
					-6,
					6
				}
			};
			array = new int[23][];
			array[0] = new int[]
			{
				0,
				20
			};
			array[1] = new int[]
			{
				1,
				16
			};
			array[2] = new int[]
			{
				2,
				16
			};
			array[3] = new int[]
			{
				3,
				16
			};
			array[4] = new int[]
			{
				4,
				18
			};
			array[5] = new int[]
			{
				11,
				8
			};
			array[6] = new int[]
			{
				12,
				8
			};
			array[7] = new int[]
			{
				13,
				8
			};
			array[8] = new int[]
			{
				14,
				8
			};
			array[9] = new int[]
			{
				15,
				8
			};
			array[10] = new int[]
			{
				16,
				8
			};
			array[11] = new int[]
			{
				17,
				8
			};
			array[12] = new int[]
			{
				18,
				8
			};
			array[13] = new int[]
			{
				19,
				8
			};
			array[14] = new int[]
			{
				20,
				4
			};
			int[][] array4 = array;
			int num2 = 15;
			array3 = new int[2];
			array3[0] = 23;
			array4[num2] = array3;
			array[16] = new int[]
			{
				31,
				10
			};
			array[17] = new int[]
			{
				32,
				10
			};
			array[18] = new int[]
			{
				33,
				10
			};
			array[19] = new int[]
			{
				34,
				10
			};
			array[20] = new int[]
			{
				35,
				10
			};
			array[21] = new int[]
			{
				36,
				10
			};
			array[22] = new int[]
			{
				41,
				16
			};
			zz93.ah.a9 = array;
		}

		// Token: 0x040000C2 RID: 194
		private const int a = 4537077;

		// Token: 0x040000C3 RID: 195
		private const int b = 2841;

		// Token: 0x040000C4 RID: 196
		private const int c = 1597;

		// Token: 0x040000C5 RID: 197
		private const int d = 96;

		// Token: 0x040000C6 RID: 198
		private const int e = 79;

		// Token: 0x040000C7 RID: 199
		private const int f = 2013571;

		// Token: 0x040000C8 RID: 200
		private const int g = 89;

		// Token: 0x040000C9 RID: 201
		private const int h = 2015133531;

		// Token: 0x040000CA RID: 202
		private const string i = "0000";

		// Token: 0x040000CB RID: 203
		private const string j = "01111";

		// Token: 0x040000CC RID: 204
		private const string k = "000";

		// Token: 0x040000CD RID: 205
		private const string l = "00100";

		// Token: 0x040000CE RID: 206
		private const string m = "111010";

		// Token: 0x040000CF RID: 207
		private const string n = "111011";

		// Token: 0x040000D0 RID: 208
		private const string o = "111100";

		// Token: 0x040000D1 RID: 209
		private const string p = "111101";

		// Token: 0x040000D2 RID: 210
		private const string q = "111110";

		// Token: 0x040000D3 RID: 211
		private const string r = "11101000";

		// Token: 0x040000D4 RID: 212
		private const string s = "11101001";

		// Token: 0x040000D5 RID: 213
		private const string t = "11101010";

		// Token: 0x040000D6 RID: 214
		private const string u = "11101011";

		// Token: 0x040000D7 RID: 215
		private const string v = "11101100";

		// Token: 0x040000D8 RID: 216
		private const string w = "11101101";

		// Token: 0x040000D9 RID: 217
		private const string x = "11101110";

		// Token: 0x040000DA RID: 218
		private const string y = "11101111";

		// Token: 0x040000DB RID: 219
		private const string z = "11110000";

		// Token: 0x040000DC RID: 220
		private const string aa = "11110001";

		// Token: 0x040000DD RID: 221
		private const string ab = "11110010";

		// Token: 0x040000DE RID: 222
		private const string ac = "11110011";

		// Token: 0x040000DF RID: 223
		private const string ad = "11110100";

		// Token: 0x040000E0 RID: 224
		private const string ae = "11110101";

		// Token: 0x040000E1 RID: 225
		private const string af = "11110110";

		// Token: 0x040000E2 RID: 226
		private const string ag = "11110111";

		// Token: 0x040000E3 RID: 227
		private const string ah = "11111000";

		// Token: 0x040000E4 RID: 228
		private const string ai = "11111001";

		// Token: 0x040000E5 RID: 229
		private const string aj = "11111010";

		// Token: 0x040000E6 RID: 230
		private const string ak = "11111011";

		// Token: 0x040000E7 RID: 231
		private const string al = "11111100";

		// Token: 0x040000E8 RID: 232
		private const string am = "00100";

		// Token: 0x040000E9 RID: 233
		private const string an = "11";

		// Token: 0x040000EA RID: 234
		private string ao = string.Empty;

		// Token: 0x040000EB RID: 235
		private bool ap = false;

		// Token: 0x040000EC RID: 236
		private aj aq = zz93.aj.a;

		// Token: 0x040000ED RID: 237
		private BitArray ar;

		// Token: 0x040000EE RID: 238
		private BitArray @as;

		// Token: 0x040000EF RID: 239
		private BitArray at;

		// Token: 0x040000F0 RID: 240
		private static int[] au = new int[]
		{
			1,
			1
		};

		// Token: 0x040000F1 RID: 241
		private static int[][] av = new int[][]
		{
			new int[]
			{
				160,
				0,
				12,
				4,
				8,
				1,
				161,
				1
			},
			new int[]
			{
				960,
				161,
				10,
				6,
				6,
				3,
				80,
				10
			},
			new int[]
			{
				2014,
				961,
				8,
				8,
				4,
				5,
				31,
				34
			},
			new int[]
			{
				2714,
				2015,
				6,
				10,
				3,
				6,
				10,
				70
			},
			new int[]
			{
				2840,
				2715,
				4,
				12,
				1,
				8,
				1,
				126
			}
		};

		// Token: 0x040000F2 RID: 242
		private static int[][] aw = new int[][]
		{
			new int[]
			{
				335,
				0,
				5,
				10,
				2,
				7,
				4,
				84
			},
			new int[]
			{
				1035,
				336,
				7,
				8,
				4,
				5,
				20,
				35
			},
			new int[]
			{
				1515,
				1036,
				9,
				6,
				6,
				3,
				48,
				10
			},
			new int[]
			{
				1596,
				1516,
				11,
				4,
				8,
				1,
				81,
				1
			}
		};

		// Token: 0x040000F3 RID: 243
		private static int[][] ax = new int[][]
		{
			new int[]
			{
				1,
				3,
				9,
				27,
				2,
				6,
				18,
				54
			},
			new int[]
			{
				4,
				12,
				36,
				29,
				8,
				24,
				72,
				58
			},
			new int[]
			{
				16,
				48,
				65,
				37,
				32,
				17,
				51,
				74
			},
			new int[]
			{
				64,
				34,
				23,
				69,
				49,
				68,
				46,
				59
			}
		};

		// Token: 0x040000F4 RID: 244
		private static int[][] ay = new int[][]
		{
			new int[]
			{
				3,
				8,
				2,
				1,
				1
			},
			new int[]
			{
				3,
				5,
				5,
				1,
				1
			},
			new int[]
			{
				3,
				3,
				7,
				1,
				1
			},
			new int[]
			{
				3,
				1,
				9,
				1,
				1
			},
			new int[]
			{
				2,
				7,
				4,
				1,
				1
			},
			new int[]
			{
				2,
				5,
				6,
				1,
				1
			},
			new int[]
			{
				2,
				3,
				8,
				1,
				1
			},
			new int[]
			{
				1,
				5,
				7,
				1,
				1
			},
			new int[]
			{
				1,
				3,
				9,
				1,
				1
			}
		};

		// Token: 0x040000F5 RID: 245
		private static int[][] az = new int[][]
		{
			new int[]
			{
				183063,
				0,
				17,
				9,
				6,
				3,
				6538,
				28
			},
			new int[]
			{
				820063,
				183064,
				13,
				13,
				5,
				4,
				875,
				728
			},
			new int[]
			{
				1000775,
				820064,
				9,
				17,
				3,
				6,
				28,
				6454
			},
			new int[]
			{
				1491020,
				1000776,
				15,
				11,
				5,
				4,
				2415,
				203
			},
			new int[]
			{
				1979844,
				1491021,
				11,
				15,
				4,
				5,
				203,
				2408
			},
			new int[]
			{
				1996938,
				1979845,
				19,
				7,
				8,
				1,
				17094,
				1
			},
			new int[]
			{
				2013570,
				1996939,
				7,
				19,
				1,
				8,
				1,
				16632
			}
		};

		// Token: 0x040000F6 RID: 246
		private static int[][] a0 = new int[][]
		{
			new int[]
			{
				1,
				3,
				9,
				27,
				81,
				65,
				17,
				51,
				64,
				14,
				42,
				37,
				22,
				66
			},
			new int[]
			{
				20,
				60,
				2,
				6,
				18,
				54,
				73,
				41,
				34,
				13,
				39,
				28,
				84,
				74
			}
		};

		// Token: 0x040000F7 RID: 247
		private static int[][] a1 = new int[][]
		{
			new int[]
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
				3,
				3,
				1,
				1
			},
			new int[]
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
				2,
				3,
				2,
				1,
				1
			},
			new int[]
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
				3,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				3,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				3,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				3,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				3,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				3,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				3,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				3,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				3,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				3,
				1,
				1,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				3,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				3,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				3,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				3,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				2,
				1,
				2,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				3,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				3,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				2,
				2,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				1,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				2,
				1,
				2,
				1,
				1,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				2,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				1,
				1
			},
			new int[]
			{
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				1,
				2,
				1,
				1
			}
		};

		// Token: 0x040000F8 RID: 248
		private static int[] a2 = new int[]
		{
			1,
			1,
			5
		};

		// Token: 0x040000F9 RID: 249
		private ak a3 = zz93.ak.a;

		// Token: 0x040000FA RID: 250
		private static byte[] a4 = new byte[]
		{
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			33,
			34,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			58,
			59,
			60,
			61,
			62,
			63,
			95,
			32
		};

		// Token: 0x040000FB RID: 251
		private static int[][] a5;

		// Token: 0x040000FC RID: 252
		private static int[][] a6;

		// Token: 0x040000FD RID: 253
		private static int[][] a7;

		// Token: 0x040000FE RID: 254
		private static int[][] a8;

		// Token: 0x040000FF RID: 255
		private static int[][] a9;
	}
}
