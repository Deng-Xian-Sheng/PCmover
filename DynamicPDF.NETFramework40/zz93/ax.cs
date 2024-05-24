using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000034 RID: 52
	internal class ax
	{
		// Token: 0x0600020F RID: 527 RVA: 0x00031121 File Offset: 0x00030121
		internal ax(byte[] A_0, int A_1)
		{
			this.e = A_0;
			this.d = A_1;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0003113A File Offset: 0x0003013A
		internal void a(int A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00031144 File Offset: 0x00030144
		internal byte[] c()
		{
			return this.e;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0003115C File Offset: 0x0003015C
		internal int d()
		{
			return this.f;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00031174 File Offset: 0x00030174
		internal void b(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00031180 File Offset: 0x00030180
		internal int e()
		{
			return this.g;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00031198 File Offset: 0x00030198
		internal void c(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000311A4 File Offset: 0x000301A4
		internal int[] f()
		{
			int[] array = null;
			switch (this.d)
			{
			case 0:
			{
				int num = 0;
				this.b = new j(this);
				int[] array2 = this.b.a(this.e);
				int num2 = this.e.Length;
				if (num2 % 6 == 0)
				{
					num = p.c();
				}
				else if (num2 == 1)
				{
					num = p.a();
				}
				else if (num2 % 6 != 0)
				{
					num = p.d();
				}
				array = new int[array2.Length + 1];
				array[0] = num;
				Array.Copy(array2, 0, array, 1, array2.Length);
				break;
			}
			case 1:
				this.a = new bb(this);
				array = this.a.a(this.e);
				break;
			case 2:
			{
				int num3 = p.b();
				this.c = new au(this);
				int[] array3 = this.c.a(this.e);
				array = new int[array3.Length + 1];
				array[0] = num3;
				Array.Copy(array3, 0, array, 1, array3.Length);
				break;
			}
			case 3:
				array = this.b();
				break;
			}
			return array;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000312E0 File Offset: 0x000302E0
		internal int[] a(int A_0, int A_1)
		{
			int[] array = null;
			this.f = A_0;
			this.g = A_1;
			switch (this.d)
			{
			case 0:
			{
				int num = 0;
				this.b = new j(this);
				int[] array2 = this.b.a();
				int num2 = this.h;
				if (num2 % 6 == 0)
				{
					num = p.c();
				}
				else if (num2 == 1)
				{
					num = p.a();
				}
				else if (num2 % 6 != 0)
				{
					num = p.d();
				}
				array = new int[array2.Length + 1];
				array[0] = num;
				Array.Copy(array2, 0, array, 1, array2.Length);
				break;
			}
			case 1:
				this.a = new bb(this);
				array = this.a.h();
				break;
			case 2:
			{
				int num3 = p.b();
				this.c = new au(this);
				int[] array3 = this.c.a();
				array = new int[array3.Length + 1];
				array[0] = num3;
				Array.Copy(array3, 0, array, 1, array3.Length);
				break;
			}
			case 3:
				array = this.a();
				break;
			}
			return array;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00031414 File Offset: 0x00030414
		private int[] b()
		{
			int[] array = new int[128];
			int num = 0;
			int i = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			this.c = new au(this);
			this.a = new bb(this);
			this.b = new j(this);
			ArrayList arrayList = new ArrayList();
			arrayList.Add(p.e());
			for (;;)
			{
				while (i < this.e.Length)
				{
					for (int j = i; j < this.e.Length; j++)
					{
						if (this.e[j] < 48 || this.e[j] > 57)
						{
							break;
						}
						num2++;
					}
					if (num2 >= 13)
					{
						arrayList.Add(p.b());
						byte[] array2 = new byte[num2];
						int k = 0;
						for (int j = i; j < i + num2; j++)
						{
							array2[k] = this.e[j];
							k++;
						}
						int[] value = this.c.a(array2);
						arrayList.Add(value);
						i += num2;
						num2 = 0;
					}
					else
					{
						if (num2 < 13)
						{
							num2 = 0;
							num3 = 0;
							num4 = 0;
							for (int j = i; j < this.e.Length; j++)
							{
								if ((this.e[j] < 32 || this.e[j] > 126) && this.e[j] != 9 && this.e[j] != 10 && this.e[j] != 13)
								{
									break;
								}
								num3++;
								if (this.e[j] >= 48 && this.e[j] <= 57)
								{
									num2++;
								}
								else
								{
									num2 = 0;
								}
								if (num2 >= 13)
								{
									num3 -= num2;
									num2 = 0;
									break;
								}
							}
						}
						if (num3 >= 5)
						{
							arrayList.Add(p.e());
							byte[] array3 = new byte[num3];
							int k = 0;
							for (int j = i; j < i + num3; j++)
							{
								array3[k] = this.e[j];
								k++;
							}
							int[] value2 = this.a.a(array3);
							arrayList.Add(value2);
							i += num3;
							num3 = 0;
						}
						else
						{
							if (num3 < 5)
							{
								num3 = 0;
								num2 = 0;
								num4 = 0;
								for (int j = i; j < this.e.Length; j++)
								{
									if (this.e[j] >= 0 && this.e[j] <= 255)
									{
										num4++;
										if ((this.e[j] >= 32 && this.e[j] <= 126) || this.e[j] == 9 || this.e[j] == 10 || this.e[j] == 13)
										{
											if (this.e[j] >= 48 && this.e[j] <= 57)
											{
												num2++;
												num3 = 0;
											}
											else
											{
												num3++;
												num2 = 0;
											}
										}
										else
										{
											num3 = 0;
										}
									}
									if (num3 >= 5)
									{
										num4 -= num3;
										num3 = 0;
										num2 = 0;
										break;
									}
									if (num2 >= 13)
									{
										num4 -= num2;
										num2 = 0;
										num3 = 0;
										break;
									}
								}
							}
							if (num4 == 1)
							{
								arrayList.Add(p.a());
								byte[] array4 = new byte[1];
								for (int j = i; j < i + 1; j++)
								{
									array4[0] = this.e[j];
								}
								int[] value3 = this.b.a(array4);
								arrayList.Add(value3);
								i += num4;
								num4 = 0;
							}
							else if (num4 > 1)
							{
								byte[] array4 = new byte[num4];
								int k = 0;
								for (int j = i; j < i + num4; j++)
								{
									array4[k] = this.e[j];
									k++;
								}
								if (array4.Length % 6 == 0)
								{
									arrayList.Add(p.c());
								}
								else if (array4.Length % 6 != 0)
								{
									arrayList.Add(p.d());
								}
								int[] value3 = this.b.a(array4);
								arrayList.Add(value3);
								i += num4;
								num4 = 0;
							}
						}
					}
				}
				break;
			}
			int count = arrayList.Count;
			for (int j = 0; j < count; j++)
			{
				object obj = arrayList[j];
				if (obj is int)
				{
					int num5 = (int)obj;
					if (num < array.Length)
					{
						array[num] = num5;
						num++;
					}
					else
					{
						array = this.a(array);
						array[num] = num5;
						num++;
					}
				}
				else if (obj is int[])
				{
					int[] array5 = (int[])obj;
					for (int k = 0; k < array5.Length; k++)
					{
						if (num < array.Length)
						{
							array[num] = array5[k];
							num++;
						}
						else
						{
							array = this.a(array);
							array[num] = array5[k];
							num++;
						}
					}
				}
			}
			int[] array6 = new int[num];
			Array.Copy(array, 0, array6, 0, num);
			return array6;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00031A30 File Offset: 0x00030A30
		private int[] a()
		{
			int[] array = new int[128];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			this.c = new au(this);
			this.a = new bb(this);
			this.b = new j(this);
			this.i = this.g;
			int num5 = this.f;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(p.e());
			this.i--;
			for (;;)
			{
				while (num5 < this.e.Length && this.i > 0)
				{
					for (int i = num5; i < this.e.Length; i++)
					{
						if (this.e[i] < 48 || this.e[i] > 57)
						{
							break;
						}
						num2++;
					}
					if (num2 >= 13)
					{
						arrayList.Add(p.b());
						this.i--;
						byte[] array2 = new byte[num2];
						int j = 0;
						for (int i = num5; i < num5 + num2; i++)
						{
							array2[j] = this.e[i];
							j++;
						}
						int[] value = this.c.a(array2, this.i);
						arrayList.Add(value);
						if (num2 == this.f)
						{
							num5 += num2;
						}
						else
						{
							num5 += this.f;
						}
						num2 = 0;
						if (this.i == 0)
						{
							this.b(num5);
						}
						else if (num5 == this.e.Length)
						{
							this.b(num5);
						}
					}
					else
					{
						if (num2 < 13)
						{
							num2 = 0;
							num3 = 0;
							num4 = 0;
							for (int i = num5; i < this.e.Length; i++)
							{
								if ((this.e[i] < 32 || this.e[i] > 126) && this.e[i] != 9 && this.e[i] != 10 && this.e[i] != 13)
								{
									break;
								}
								num3++;
								if (this.e[i] >= 48 && this.e[i] <= 57)
								{
									num2++;
								}
								else
								{
									num2 = 0;
								}
								if (num2 >= 13)
								{
									num3 -= num2;
									num2 = 0;
									break;
								}
							}
						}
						if (num3 >= 5)
						{
							arrayList.Add(p.e());
							this.i--;
							byte[] array3 = new byte[num3];
							int j = 0;
							for (int i = num5; i < num5 + num3; i++)
							{
								array3[j] = this.e[i];
								j++;
							}
							int[] value2 = this.a.d(array3, this.i);
							arrayList.Add(value2);
							if (num3 == this.f)
							{
								num5 += num3;
							}
							else
							{
								num5 += this.f;
							}
							num3 = 0;
							if (this.i == 0)
							{
								this.b(num5);
							}
							else if (num5 == this.e.Length)
							{
								this.b(num5);
							}
						}
						else
						{
							if (num3 < 5)
							{
								num3 = 0;
								num2 = 0;
								num4 = 0;
								for (int i = num5; i < this.e.Length; i++)
								{
									if (this.e[i] >= 0 && this.e[i] <= 255)
									{
										num4++;
										if ((this.e[i] >= 32 && this.e[i] <= 126) || this.e[i] == 9 || this.e[i] == 10 || this.e[i] == 13)
										{
											if (this.e[i] >= 48 && this.e[i] <= 57)
											{
												num2++;
												num3 = 0;
											}
											else
											{
												num3++;
												num2 = 0;
											}
										}
										else
										{
											num3 = 0;
										}
									}
									if (num3 >= 5)
									{
										num4 -= num3;
										num3 = 0;
										num2 = 0;
										break;
									}
									if (num2 >= 13)
									{
										num4 -= num2;
										num2 = 0;
										num3 = 0;
										break;
									}
								}
							}
							if (num4 == 1)
							{
								arrayList.Add(p.a());
								this.i--;
								byte[] array4 = new byte[1];
								for (int i = num5; i < num5 + 1; i++)
								{
									array4[0] = this.e[i];
								}
								int[] value3 = this.b.a(array4, this.i);
								arrayList.Add(value3);
								if (num4 == this.f)
								{
									num5 += num4;
								}
								else
								{
									num5 += this.f;
								}
								num4 = 0;
								if (this.i == 0)
								{
									this.b(num5);
								}
								else if (num5 == this.e.Length)
								{
									this.b(num5);
								}
							}
							else if (num4 > 1)
							{
								byte[] array4 = new byte[num4];
								int j = 0;
								for (int i = num5; i < num5 + num4; i++)
								{
									array4[j] = this.e[i];
									j++;
								}
								this.i--;
								int[] value3 = this.b.a(array4, this.i);
								if (this.f == num4)
								{
									num5 += num4;
									if (array4.Length % 6 == 0)
									{
										arrayList.Add(p.c());
									}
									else if (array4.Length % 6 != 0)
									{
										arrayList.Add(p.d());
									}
								}
								else
								{
									num5 += this.f;
									if (this.f % 6 == 0)
									{
										arrayList.Add(p.c());
									}
									else if (this.f % 6 != 0)
									{
										arrayList.Add(p.d());
									}
								}
								arrayList.Add(value3);
								num4 = 0;
								if (this.i == 0)
								{
									this.b(num5);
								}
								else if (num5 == this.e.Length)
								{
									this.b(num5);
								}
							}
						}
					}
				}
				break;
			}
			int count = arrayList.Count;
			for (int i = 0; i < count; i++)
			{
				object obj = arrayList[i];
				if (obj is int)
				{
					int num6 = (int)obj;
					if (num < array.Length)
					{
						array[num] = num6;
						num++;
					}
					else
					{
						array = this.a(array);
						array[num] = num6;
						num++;
					}
				}
				else if (obj is int[])
				{
					int[] array5 = (int[])obj;
					for (int j = 0; j < array5.Length; j++)
					{
						if (num < array.Length)
						{
							array[num] = array5[j];
							num++;
						}
						else
						{
							array = this.a(array);
							array[num] = array5[j];
							num++;
						}
					}
				}
			}
			int[] array6 = new int[num];
			Array.Copy(array, 0, array6, 0, num);
			return array6;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000322A8 File Offset: 0x000312A8
		private int[] a(int[] A_0)
		{
			int[] array = new int[A_0.Length * 2];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			return array;
		}

		// Token: 0x04000166 RID: 358
		private bb a;

		// Token: 0x04000167 RID: 359
		private j b;

		// Token: 0x04000168 RID: 360
		private au c;

		// Token: 0x04000169 RID: 361
		private int d;

		// Token: 0x0400016A RID: 362
		private byte[] e;

		// Token: 0x0400016B RID: 363
		private int f;

		// Token: 0x0400016C RID: 364
		private int g;

		// Token: 0x0400016D RID: 365
		private int h;

		// Token: 0x0400016E RID: 366
		private int i;
	}
}
