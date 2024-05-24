using System;

namespace zz93
{
	// Token: 0x02000042 RID: 66
	internal class bb
	{
		// Token: 0x06000267 RID: 615 RVA: 0x0003C400 File Offset: 0x0003B400
		internal bb()
		{
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0003C40B File Offset: 0x0003B40B
		internal bb(ax A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0003C420 File Offset: 0x0003B420
		internal int[] a(byte[] A_0)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				if ((A_0[i] < 32 || A_0[i] > 126) && A_0[i] != 9 && A_0[i] != 10 && A_0[i] != 13)
				{
					throw new ap("Text is out of range.");
				}
			}
			this.k = 0;
			int a_ = this.k;
			return this.b(A_0, a_);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0003C498 File Offset: 0x0003B498
		internal int[] h()
		{
			byte[] array = this.l.c();
			int a_ = this.l.e();
			int num = this.l.d();
			for (int i = num; i < array.Length; i++)
			{
				if ((array[i] < 32 || array[i] > 126) && array[i] != 9 && array[i] != 10 && array[i] != 13)
				{
					throw new ap("Text is out of range.");
				}
			}
			this.k = num;
			int[] result = this.a(array, a_);
			this.l.b(this.k);
			return result;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0003C54C File Offset: 0x0003B54C
		internal int[] d(byte[] A_0, int A_1)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				if ((A_0[i] < 32 || A_0[i] > 126) && A_0[i] != 9 && A_0[i] != 10 && A_0[i] != 13)
				{
					throw new ap("Text is out of range.");
				}
			}
			this.k = 0;
			int[] array = this.a(A_0, A_1);
			if (array != null)
			{
				A_1 -= array.Length;
			}
			this.l.a(A_1);
			this.l.b(this.k);
			return array;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0003C5F0 File Offset: 0x0003B5F0
		private int g()
		{
			return 25;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0003C604 File Offset: 0x0003B604
		private int f()
		{
			return 27;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0003C618 File Offset: 0x0003B618
		private int e()
		{
			return 27;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0003C62C File Offset: 0x0003B62C
		private int d()
		{
			return 28;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0003C640 File Offset: 0x0003B640
		private int c()
		{
			return 28;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0003C654 File Offset: 0x0003B654
		private int b()
		{
			return 29;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0003C668 File Offset: 0x0003B668
		private int a()
		{
			return 29;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0003C67C File Offset: 0x0003B67C
		private int c(byte[] A_0, int A_1)
		{
			int result;
			if (A_1 >= A_0.Length)
			{
				result = 0;
			}
			else
			{
				char c = (char)(A_0[A_1] & byte.MaxValue);
				if (c >= 'A' && c <= 'Z')
				{
					result = 65536 + (int)c - 65;
				}
				else if (c >= 'a' && c <= 'z')
				{
					result = 131072 + (int)c - 97;
				}
				else if (c == ' ')
				{
					result = 458778;
				}
				else
				{
					int num = bb.i.IndexOf(c);
					int num2 = bb.j.IndexOf(c);
					if (num < 0 && num2 < 0)
					{
						result = 1048576 + (int)c;
					}
					else if (num == num2)
					{
						result = 786432 + num;
					}
					else if (num >= 0)
					{
						result = 262144 + num;
					}
					else
					{
						result = 524288 + num2;
					}
				}
			}
			return result;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0003C774 File Offset: 0x0003B774
		private int[] b(byte[] A_0, int A_1)
		{
			int[] array = new int[7400];
			int num = 65536;
			int i = 0;
			int num2 = 0;
			int num3 = A_0.Length;
			for (int j = A_1; j < num3; j++)
			{
				int num4 = this.c(A_0, j);
				if ((num4 & num) != 0)
				{
					array[i++] = (num4 & 255);
				}
				else if ((num4 & 1048576) != 0)
				{
					if ((i & 1) != 0)
					{
						array[i++] = (((num & 524288) != 0) ? this.a() : this.b());
						num = (((num & 524288) != 0) ? 65536 : num);
					}
					array[i++] = 913;
					array[i++] = (num4 & 255);
					num2 += 2;
				}
				else
				{
					int num5 = num;
					if (num5 <= 131072)
					{
						if (num5 != 65536)
						{
							if (num5 == 131072)
							{
								if ((num4 & 65536) != 0)
								{
									if ((this.c(A_0, j + 1) & this.c(A_0, j + 2) & 65536) != 0)
									{
										array[i++] = this.d();
										array[i++] = this.c();
										num = 65536;
									}
									else
									{
										array[i++] = this.e();
									}
									array[i++] = (num4 & 255);
								}
								else if ((num4 & 262144) != 0)
								{
									array[i++] = this.d();
									array[i++] = (num4 & 255);
									num = 262144;
								}
								else if ((this.c(A_0, j + 1) & this.c(A_0, j + 2) & 524288) != 0)
								{
									array[i++] = this.d();
									array[i++] = this.g();
									array[i++] = (num4 & 255);
									num = 524288;
								}
								else
								{
									array[i++] = this.b();
									array[i++] = (num4 & 255);
								}
							}
						}
						else if ((num4 & 131072) != 0)
						{
							array[i++] = this.f();
							array[i++] = (num4 & 255);
							num = 131072;
						}
						else if ((num4 & 262144) != 0)
						{
							array[i++] = this.d();
							array[i++] = (num4 & 255);
							num = 262144;
						}
						else if ((this.c(A_0, j + 1) & this.c(A_0, j + 2) & 524288) != 0)
						{
							array[i++] = this.d();
							array[i++] = this.g();
							array[i++] = (num4 & 255);
							num = 524288;
						}
						else
						{
							array[i++] = this.b();
							array[i++] = (num4 & 255);
						}
					}
					else if (num5 != 262144)
					{
						if (num5 == 524288)
						{
							array[i++] = this.a();
							num = 65536;
							j--;
						}
					}
					else if ((num4 & 131072) != 0)
					{
						array[i++] = this.f();
						array[i++] = (num4 & 255);
						num = 131072;
					}
					else if ((num4 & 65536) != 0)
					{
						array[i++] = this.c();
						array[i++] = (num4 & 255);
						num = 65536;
					}
					else if ((this.c(A_0, j + 1) & this.c(A_0, j + 2) & 524288) != 0)
					{
						array[i++] = this.g();
						array[i++] = (num4 & 255);
						num = 524288;
					}
					else
					{
						array[i++] = this.b();
						array[i++] = (num4 & 255);
					}
				}
			}
			if ((i & 1) != 0)
			{
				array[i++] = this.b();
			}
			int num6 = i / 2;
			num3 = i;
			i = 0;
			int num7 = 0;
			int[] array2 = new int[num6];
			while (i < num3)
			{
				int num4 = array[i++];
				if (num4 >= 30)
				{
					array2[num7++] = num4;
					array2[num7++] = array[i++];
				}
				else
				{
					array2[num7++] = num4 * 30 + array[i++];
				}
			}
			return array2;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0003CC54 File Offset: 0x0003BC54
		private int[] a(byte[] A_0, int A_1)
		{
			int[] array = new int[7400];
			int num = 65536;
			int i = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = A_0.Length;
			int num5 = A_1 * 2;
			while (this.k < num4 && i < num5)
			{
				int num6 = this.c(A_0, this.k);
				if ((num6 & num) != 0)
				{
					array[i++] = (num6 & 255);
					if (i <= num5)
					{
						this.k++;
					}
				}
				else if ((num6 & 1048576) != 0)
				{
					if ((i & 1) != 0)
					{
						array[i++] = (((num & 524288) != 0) ? this.a() : this.b());
						num = (((num & 524288) != 0) ? 65536 : num);
					}
					array[i++] = 913;
					array[i++] = (num6 & 255);
					num2 += 2;
				}
				else
				{
					int num7 = num;
					if (num7 <= 131072)
					{
						if (num7 != 65536)
						{
							if (num7 == 131072)
							{
								if ((num6 & 65536) != 0)
								{
									if ((this.c(A_0, this.k + 1) & this.c(A_0, this.k + 2) & 65536) != 0)
									{
										array[i++] = this.d();
										array[i++] = this.c();
										num = 65536;
									}
									else
									{
										array[i++] = this.e();
									}
									array[i++] = (num6 & 255);
								}
								else if ((num6 & 262144) != 0)
								{
									array[i++] = this.d();
									array[i++] = (num6 & 255);
									num = 262144;
								}
								else if ((this.c(A_0, this.k + 1) & this.c(A_0, this.k + 2) & 524288) != 0)
								{
									array[i++] = this.d();
									array[i++] = this.g();
									array[i++] = (num6 & 255);
									num = 524288;
								}
								else
								{
									array[i++] = this.b();
									array[i++] = (num6 & 255);
								}
							}
						}
						else if ((num6 & 131072) != 0)
						{
							array[i++] = this.f();
							array[i++] = (num6 & 255);
							num = 131072;
						}
						else if ((num6 & 262144) != 0)
						{
							array[i++] = this.d();
							array[i++] = (num6 & 255);
							num = 262144;
						}
						else if ((this.c(A_0, this.k + 1) & this.c(A_0, this.k + 2) & 524288) != 0)
						{
							array[i++] = this.d();
							array[i++] = this.g();
							array[i++] = (num6 & 255);
							num = 524288;
						}
						else
						{
							array[i++] = this.b();
							array[i++] = (num6 & 255);
						}
					}
					else if (num7 != 262144)
					{
						if (num7 == 524288)
						{
							array[i++] = this.a();
							num = 65536;
							if (i <= num5)
							{
								this.k--;
							}
						}
					}
					else if ((num6 & 131072) != 0)
					{
						array[i++] = this.f();
						array[i++] = (num6 & 255);
						num = 131072;
					}
					else if ((num6 & 65536) != 0)
					{
						array[i++] = this.c();
						array[i++] = (num6 & 255);
						num = 65536;
					}
					else if ((this.c(A_0, this.k + 1) & this.c(A_0, this.k + 2) & 524288) != 0)
					{
						array[i++] = this.g();
						array[i++] = (num6 & 255);
						num = 524288;
					}
					else
					{
						array[i++] = this.b();
						array[i++] = (num6 & 255);
					}
					if (i <= num5)
					{
						this.k++;
					}
				}
			}
			if ((i & 1) != 0)
			{
				array[i++] = this.b();
			}
			if (i < num5)
			{
				num3 = i / 2;
				num4 = i;
			}
			else if (i >= num5)
			{
				num3 = A_1;
				num4 = num5;
			}
			i = 0;
			int num8 = 0;
			int[] array2 = new int[num3];
			while (i < num4)
			{
				int num6 = array[i++];
				if (num6 >= 30)
				{
					array2[num8++] = num6;
					array2[num8++] = array[i++];
				}
				else
				{
					array2[num8++] = num6 * 30 + array[i++];
				}
			}
			return array2;
		}

		// Token: 0x0400019D RID: 413
		private const int a = 65536;

		// Token: 0x0400019E RID: 414
		private const int b = 131072;

		// Token: 0x0400019F RID: 415
		private const int c = 262144;

		// Token: 0x040001A0 RID: 416
		private const int d = 524288;

		// Token: 0x040001A1 RID: 417
		private const int e = 1048576;

		// Token: 0x040001A2 RID: 418
		private const int f = 913;

		// Token: 0x040001A3 RID: 419
		private const int g = 26;

		// Token: 0x040001A4 RID: 420
		private const int h = 1850;

		// Token: 0x040001A5 RID: 421
		private static string i = "0123456789&\r\t,:#-.$/+%*=^";

		// Token: 0x040001A6 RID: 422
		private static string j = ";<>@[\\]_`~!\r\t,:\n-.$/\"|*()?{}'";

		// Token: 0x040001A7 RID: 423
		private int k;

		// Token: 0x040001A8 RID: 424
		private ax l;
	}
}
