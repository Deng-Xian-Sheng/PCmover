using System;

namespace zz93
{
	// Token: 0x02000015 RID: 21
	internal class s : r
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x0001FBB4 File Offset: 0x0001EBB4
		internal s(int A_0, bool A_1, bool A_2, int A_3, bool A_4) : base(A_0, A_3, A_2, A_1, A_4)
		{
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0001FBC8 File Offset: 0x0001EBC8
		internal i a(byte[] A_0, bool A_1, i A_2)
		{
			i i = new i();
			i i2 = new i();
			int j = 0;
			while (j < A_0.Length)
			{
				if (A_1)
				{
					if ((A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49) || (A_0[j] == 126 && A_0[j + 1] == 50 && j + 7 <= A_0.Length))
					{
						if (i2.a() > 0)
						{
							if (!base.d() || base.a(A_2.a() + this.a(i.a()), base.c() - 1))
							{
								if (base.b() != 7)
								{
									base.b(base.b(), A_2);
									base.c(7, A_2);
								}
								this.a(i2, A_2);
								i = new i();
								i2 = new i();
								if (base.b() != 1)
								{
									base.b(base.b(), A_2);
								}
								int num;
								if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
								{
									num = 2;
								}
								else
								{
									num = 4;
								}
								if (!base.d() || base.a(A_2.a() + num, base.c()))
								{
									if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
									{
										A_2.a(232);
									}
									else
									{
										base.a(A_0, j + 2, j + 8, A_2);
										j += 6;
									}
								}
								else
								{
									A_2 = base.a(A_2);
									if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
									{
										A_2.a(232);
									}
									else
									{
										base.a(A_0, j + 2, j + 8, A_2);
										j += 6;
									}
								}
								j++;
								goto IL_73E;
							}
							A_2 = base.a(A_2);
							if (base.b() != 7)
							{
								base.b(base.b(), A_2);
								base.c(7, A_2);
							}
							this.a(i2, A_2);
							if (base.b() != 1)
							{
								base.b(base.b(), A_2);
							}
							if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
							{
								A_2.a(232);
							}
							else
							{
								base.a(A_0, j + 2, j + 8, A_2);
								j += 6;
							}
							i2 = new i();
							i = new i();
							j++;
							goto IL_73E;
						}
						else
						{
							if (i2.a() == 0 && i.a() > 0)
							{
								if (i.a() >= 3)
								{
									if (base.b() != 7)
									{
										base.b(base.b(), A_2);
										base.c(7, A_2);
									}
								}
								this.a(i, A_2);
								i = new i();
								if (base.b() != 1)
								{
									base.b(base.b(), A_2);
								}
								if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
								{
									A_2.a(232);
								}
								else
								{
									base.a(A_0, j + 2, j + 8, A_2);
									j += 6;
								}
								j++;
								goto IL_73E;
							}
							if (i2.a() == 0)
							{
								if (base.b() != 1)
								{
									base.b(base.b(), A_2);
								}
								int num;
								if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
								{
									num = 2;
								}
								else
								{
									num = 4;
								}
								if (!base.d() || base.a(A_2.a() + num, base.c()))
								{
									if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
									{
										A_2.a(232);
									}
									else
									{
										base.a(A_0, j + 2, j + 8, A_2);
										j += 6;
									}
								}
								else
								{
									A_2 = base.a(A_2);
									if (A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49)
									{
										A_2.a(232);
									}
									else
									{
										base.a(A_0, j + 2, j + 8, A_2);
										j += 6;
									}
								}
								j++;
								goto IL_73E;
							}
						}
					}
					goto IL_4E9;
				}
				goto IL_4E9;
				IL_73E:
				j++;
				continue;
				IL_4E9:
				if ((A_0[j] >= 65 && A_0[j] <= 90) || (A_0[j] >= 48 && A_0[j] <= 57) || A_0[j] == 32 || A_0[j] == 13 || A_0[j] == 42 || A_0[j] == 62)
				{
					if (A_0[j] == 13)
					{
						i.a(0);
					}
					else if (A_0[j] == 42)
					{
						i.a(1);
					}
					else if (A_0[j] == 62)
					{
						i.a(2);
					}
					else if (A_0[j] == 32)
					{
						i.a(3);
					}
					else if (A_0[j] >= 48 && A_0[j] <= 57)
					{
						i.a(A_0[j] - 44);
					}
					else if (A_0[j] >= 65 && A_0[j] <= 90)
					{
						i.a(A_0[j] - 51);
					}
					if (base.d())
					{
						if (i.a() >= 3)
						{
							if (!base.d() || base.a(A_2.a() + this.a(i.a()), base.c() - 1))
							{
								i.a(ref i2);
							}
							else if (i2.a() == 0 && i.a() > 0)
							{
								A_2 = base.a(A_2);
								if (base.b() != 7)
								{
									base.b(base.b(), A_2);
									base.c(7, A_2);
								}
								this.a(i, A_2);
								i = new i();
								i2 = new i();
							}
							else if (i2.a() > 0)
							{
								if (base.b() != 7)
								{
									base.b(base.b(), A_2);
									base.c(7, A_2);
								}
								this.a(i2, A_2);
								j--;
								i = new i();
								i2 = new i();
								A_2 = base.a(A_2);
							}
						}
					}
					goto IL_73E;
				}
				throw new ap("Invalid barcode value");
			}
			if (i.a() > 0)
			{
				if (!base.d() || base.a(A_2.a() + this.a(i.a()), base.c() - 1))
				{
					if (base.b() != 7)
					{
						base.b(base.b(), A_2);
						base.c(7, A_2);
					}
					this.a(i, A_2);
				}
				else
				{
					A_2 = base.a(A_2);
					if (!base.d() || base.a(A_2.a() + this.a(i.a()), base.c() - 1))
					{
						if (base.b() != 7)
						{
							base.b(base.b(), A_2);
							base.c(7, A_2);
						}
						this.a(i, A_2);
					}
				}
			}
			if (base.e())
			{
				A_2 = base.b(A_2);
			}
			return A_2;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00020440 File Offset: 0x0001F440
		private int a(int A_0)
		{
			int num = 0;
			num += A_0 / 3;
			num *= 2;
			if (A_0 % 3 != 0)
			{
				num += 3;
				if (A_0 % 3 != 1)
				{
					num++;
					num++;
				}
			}
			return num;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00020484 File Offset: 0x0001F484
		private void a(i A_0, i A_1)
		{
			int num = A_0.a();
			int num2 = A_0.a() % 3;
			if (num2 == 0)
			{
				for (int i = 0; i < num; i++)
				{
					ushort num3 = (ushort)(1600 * Convert.ToInt32(A_0.b(i)) + 40 * Convert.ToInt32(A_0.b(i + 1)) + Convert.ToInt32(A_0.b(i + 2)) + 1);
					A_1.a((byte)(num3 / 256));
					A_1.a((byte)(num3 % 256));
					i += 2;
				}
			}
			else
			{
				num = A_0.a() - num2;
				for (int i = 0; i < num; i++)
				{
					ushort num3 = (ushort)(1600 * Convert.ToInt32(A_0.b(i)) + 40 * Convert.ToInt32(A_0.b(i + 1)) + Convert.ToInt32(A_0.b(i + 2)) + 1);
					A_1.a((byte)(num3 / 256));
					A_1.a((byte)(num3 % 256));
					i += 2;
				}
				if (base.b() != 1)
				{
					base.b(base.b(), A_1);
				}
				for (int i = 0; i < num2; i++)
				{
					if (A_0.b(num + i) == 0)
					{
						A_1.a(14);
					}
					else if (A_0.b(num + i) == 1)
					{
						A_1.a(43);
					}
					else if (A_0.b(num + i) == 2)
					{
						A_1.a(63);
					}
					else if (A_0.b(num + i) == 3)
					{
						A_1.a(33);
					}
					else if (A_0.b(num + i) >= 4 && A_0.b(num + i) <= 13)
					{
						A_1.a(A_0.b(num + i) + 45);
					}
					else if (A_0.b(num + i) >= 14 && A_0.b(num + i) <= 39)
					{
						A_1.a(A_0.b(num + i) + 52);
					}
				}
			}
		}
	}
}
