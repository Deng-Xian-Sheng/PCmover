using System;
using System.Text;

namespace zz93
{
	// Token: 0x02000031 RID: 49
	internal class au
	{
		// Token: 0x060001C3 RID: 451 RVA: 0x0002EAF5 File Offset: 0x0002DAF5
		internal au()
		{
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0002EB00 File Offset: 0x0002DB00
		internal au(ax A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0002EB14 File Offset: 0x0002DB14
		internal int[] a(byte[] A_0)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] < 48 || A_0[i] > 57)
				{
					throw new ap("Invalid numeric data");
				}
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[15];
			int j = A_0.Length;
			int[] array2 = new int[j * 15 / 44 + 1];
			string text = "123";
			string text2 = "123";
			while (j > 0)
			{
				if (j >= 44)
				{
					text = Encoding.ASCII.GetString(A_0, num2, 44);
					num3 = text.Length;
				}
				else
				{
					text2 = Encoding.ASCII.GetString(A_0, num2, A_0.Length - num2);
				}
				if (num3 == 44)
				{
					text = "1" + text;
					h a_ = new h(text, 10);
					array = this.a(a_);
					for (int k = 0; k < array.Length; k++)
					{
						if (num < array2.Length)
						{
							array2[num] = array[k];
							num++;
						}
						else
						{
							array2 = this.a(array2);
							array2[num] = array[k];
							num++;
						}
					}
					num3 = 0;
				}
				else
				{
					text2 = "1" + text2;
					h a_ = new h(text2, 10);
					array = this.a(a_);
					for (int k = 0; k < array.Length; k++)
					{
						if (num < array2.Length)
						{
							array2[num] = array[k];
							num++;
						}
						else
						{
							array2 = this.a(array2);
							array2[num] = array[k];
							num++;
						}
					}
				}
				j -= 44;
				num2 += 44;
			}
			int[] array3 = new int[num];
			Array.Copy(array2, 0, array3, 0, num);
			return array3;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0002ED14 File Offset: 0x0002DD14
		internal int[] a()
		{
			int num = 0;
			int num2 = 0;
			int[] array = new int[15];
			byte[] array2 = this.a.c();
			int num3 = this.a.e();
			int num4 = this.a.d();
			for (int i = num4; i < array2.Length; i++)
			{
				if (array2[i] < 48 || array2[i] > 57)
				{
					throw new ap("Invalid numeric data");
				}
			}
			int num5 = array2.Length - num4;
			int[] array3 = new int[128];
			string text = "123";
			string text2 = "123";
			num3--;
			int num6 = num3 / 15;
			int num7 = num3 % 15;
			while (num5 > 0 && num6 > 0)
			{
				if (num5 >= 44)
				{
					text = Encoding.ASCII.GetString(array2, num4, 44);
					num2 = text.Length;
				}
				else
				{
					text2 = Encoding.ASCII.GetString(array2, num4, array2.Length - num4);
				}
				if (num2 == 44)
				{
					text = "1" + text;
					h a_ = new h(text, 10);
					array = this.a(a_);
					for (int j = 0; j < array.Length; j++)
					{
						if (num < array3.Length)
						{
							array3[num] = array[j];
							num++;
						}
						else
						{
							array3 = this.a(array3);
							array3[num] = array[j];
							num++;
						}
					}
					num2 = 0;
					num5 -= 44;
					num4 += 44;
					num6--;
				}
				else
				{
					int length = text2.Length;
					text2 = "1" + text2;
					h a_ = new h(text2, 10);
					array = this.a(a_);
					for (int j = 0; j < array.Length; j++)
					{
						if (num < array3.Length)
						{
							array3[num] = array[j];
							num++;
						}
						else
						{
							array3 = this.a(array3);
							array3[num] = array[j];
							num++;
						}
					}
					num5 -= length;
					num4 += length;
					num7 -= array.Length;
				}
			}
			if (num7 > 0 && num6 == 0)
			{
				for (int i = 0; i < num7; i++)
				{
					if (num < array3.Length)
					{
						array3[num] = 900;
						num++;
					}
					else
					{
						array3 = this.a(array3);
						array3[num] = 900;
						num++;
					}
				}
			}
			this.a.b(num4);
			int[] array4 = new int[num];
			Array.Copy(array3, 0, array4, 0, num);
			return array4;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0002EFFC File Offset: 0x0002DFFC
		internal int[] a(byte[] A_0, int A_1)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[15];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] < 48 || A_0[i] > 57)
				{
					throw new ap("Invalid numeric data");
				}
			}
			int num4 = A_0.Length;
			int[] array2 = new int[num4 * 15 / 44 + 1];
			string text = "123";
			string text2 = "123";
			while (num4 > 0 && A_1 > 0)
			{
				if (num4 >= 44)
				{
					text = Encoding.ASCII.GetString(A_0, num2, 44);
					num3 = text.Length;
				}
				else
				{
					text2 = Encoding.ASCII.GetString(A_0, num2, A_0.Length - num2);
				}
				if (num3 == 44)
				{
					if (A_1 >= 15)
					{
						text = "1" + text;
						h a_ = new h(text, 10);
						array = this.a(a_);
						for (int j = 0; j < array.Length; j++)
						{
							if (num < array2.Length)
							{
								array2[num] = array[j];
								num++;
							}
							else
							{
								array2 = this.a(array2);
								array2[num] = array[j];
								num++;
							}
						}
						num4 -= 44;
						num2 += 44;
						num3 = 0;
						A_1 -= array.Length;
					}
					else
					{
						int j;
						for (j = 0; j < A_1; j++)
						{
							if (num < array2.Length)
							{
								array2[num] = 900;
								num++;
							}
							else
							{
								array2 = this.a(array2);
								array2[num] = 900;
								num++;
							}
						}
						A_1 -= j;
					}
				}
				else
				{
					int length = text2.Length;
					text2 = "1" + text2;
					h a_ = new h(text2, 10);
					array = this.a(a_);
					for (int j = 0; j < array.Length; j++)
					{
						if (num < array2.Length)
						{
							array2[num] = array[j];
							num++;
						}
						else
						{
							array2 = this.a(array2);
							array2[num] = array[j];
							num++;
						}
					}
					num4 -= length;
					num2 += length;
					A_1 -= array.Length;
				}
			}
			this.a.b(num2);
			this.a.a(A_1);
			int[] array3 = new int[num];
			Array.Copy(array2, 0, array3, 0, num);
			return array3;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0002F2B0 File Offset: 0x0002E2B0
		private int[] a(h A_0)
		{
			int[] array = new int[15];
			int[] array2 = new int[15];
			int num = 0;
			int num2 = 0;
			h a_ = new h("900", 10);
			h a_2 = new h("0", 10);
			for (int i = 0; i < 15; i++)
			{
				h h = h.d(A_0, a_);
				A_0 = h.e(A_0, a_);
				int num3 = h.b();
				array[num] = num3;
				num++;
				if (h.k(A_0, a_2))
				{
					break;
				}
			}
			int[] array3 = new int[num];
			Array.Copy(array, 0, array3, 0, num);
			array2 = new int[array3.Length];
			for (int j = array3.Length - 1; j >= 0; j--)
			{
				array2[num2] = array3[j];
				num2++;
			}
			return array2;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0002F394 File Offset: 0x0002E394
		private int[] a(int[] A_0)
		{
			int[] array = new int[A_0.Length * 2];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			return array;
		}

		// Token: 0x0400013E RID: 318
		private ax a;
	}
}
