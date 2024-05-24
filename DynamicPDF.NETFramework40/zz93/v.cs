using System;

namespace zz93
{
	// Token: 0x02000018 RID: 24
	internal class v : r
	{
		// Token: 0x06000118 RID: 280 RVA: 0x00023789 File Offset: 0x00022789
		internal v(int A_0, bool A_1, bool A_2, int A_3, bool A_4) : base(A_0, A_3, A_2, A_1, A_4)
		{
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0002379C File Offset: 0x0002279C
		internal i a(byte[] A_0, bool A_1, bool A_2, i A_3, int A_4)
		{
			int num;
			if (base.d())
			{
				num = 5;
			}
			else
			{
				num = 1;
			}
			if (A_2)
			{
				if (!base.d() || A_0.Length + 2 + 1 + 3 + A_3.a() <= base.c() - 4)
				{
					int num2 = 0;
					for (int i = 0; i < A_0.Length; i++)
					{
						if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 49)
						{
							if (i == 0 || i == num2)
							{
								if (base.b() != 1)
								{
									base.b(base.b(), A_3);
								}
								A_3.a(232);
								i++;
								num2 += 2;
							}
							else
							{
								byte[] array = new byte[i - num2];
								if (array.Length > 0)
								{
									Array.Copy(A_0, num2, array, 0, i - num2);
									this.a(array, false, A_3);
								}
								if (base.b() != 1)
								{
									base.b(base.b(), A_3);
								}
								A_3.a(232);
								num2 = i + 2;
								i++;
							}
						}
						else if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 50 && i + 7 <= A_0.Length)
						{
							if (i == 0 || i == num2)
							{
								if (base.b() != 1)
								{
									base.b(base.b(), A_3);
								}
							}
							else
							{
								byte[] array = new byte[i - num2];
								if (array.Length > 0)
								{
									Array.Copy(A_0, num2, array, 0, i - num2);
									this.a(array, false, A_3);
								}
								if (base.b() != 1)
								{
									base.b(base.b(), A_3);
								}
							}
							base.a(A_0, i + 2, i + 8, A_3);
							num2 = i + 8;
							i += 7;
						}
					}
					if (num2 < A_0.Length)
					{
						byte[] array = new byte[A_0.Length - num2];
						Array.Copy(A_0, num2, array, 0, A_0.Length - num2);
						this.a(array, false, A_3);
					}
					if (base.e())
					{
						A_3 = base.b(A_3);
					}
				}
				else
				{
					int num3 = base.c() - A_3.a() - 3 - 4 - 4;
					if (num3 < 0)
					{
						throw new ao("Invalid symbol size for overflow.");
					}
					int num4 = A_0.Length + num3;
					int num2 = 0;
					for (;;)
					{
						if (num2 != 0)
						{
							if (A_3.a() == 0)
							{
								break;
							}
							A_3 = base.a(A_3);
						}
						num4 -= num3;
						if (num4 >= num3)
						{
							byte[] array2 = new byte[num3];
							Array.Copy(A_0, num2, array2, 0, num3);
							int num5 = 0;
							bool a_ = true;
							for (int i = 0; i < array2.Length; i++)
							{
								if (array2[i] == 126 && i < array2.Length - 1 && array2[i + 1] == 49)
								{
									if (i == 0 || num5 == i)
									{
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
										A_3.a(232);
										i++;
										num5 += 2;
									}
									else
									{
										byte[] array = new byte[i - num5];
										if (array.Length > 0)
										{
											Array.Copy(array2, num5, array, 0, i - num5);
											this.a(array, a_, A_3);
										}
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
										A_3.a(232);
										num5 = i + 2;
										i++;
									}
								}
								else if (array2[i] == 126 && i < array2.Length - 1 && array2[i + 1] == 50 && i + 7 <= array2.Length)
								{
									if (i == 0 || i == num2)
									{
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
									}
									else
									{
										byte[] array = new byte[i - num5];
										if (array.Length > 0)
										{
											Array.Copy(array2, num5, array, 0, i - num5);
											this.a(array, a_, A_3);
										}
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
									}
									if (array2.Length > i + 7)
									{
										base.a(array2, i + 2, i + 8, A_3);
										num5 = i + 8;
										i += 7;
									}
									else
									{
										base.a(array2, i + 2, array2.Length, A_3);
										num5 = i + 8;
										i += 7;
									}
								}
							}
							if (num5 < array2.Length)
							{
								byte[] array = new byte[array2.Length - num5];
								Array.Copy(array2, num5, array, 0, array2.Length - num5);
								this.a(array, a_, A_3);
							}
						}
						else
						{
							byte[] array2 = new byte[num4];
							Array.Copy(A_0, num2, array2, 0, num4);
							int num5 = 0;
							bool a_ = true;
							for (int i = 0; i < array2.Length; i++)
							{
								if (array2[i] == 126 && i < array2.Length - 1 && array2[i + 1] == 49)
								{
									if (i == 0 || i == num5)
									{
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
										A_3.a(232);
										i++;
										num5 += 2;
									}
									else
									{
										byte[] array = new byte[i - num5];
										if (array.Length > 0)
										{
											Array.Copy(array2, num5, array, 0, i - num5);
											this.a(array, a_, A_3);
										}
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
										A_3.a(232);
										num5 = i + 2;
										i++;
									}
								}
								else if (array2[i] == 126 && array2[i + 1] == 50 && i + 7 <= array2.Length)
								{
									if (i == 0 || i == num2)
									{
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
									}
									else
									{
										byte[] array = new byte[i - num5];
										if (array.Length > 0)
										{
											Array.Copy(array2, num5, array, 0, i - num5);
											this.a(array, a_, A_3);
										}
										if (base.b() != 1)
										{
											base.b(base.b(), A_3);
										}
									}
									if (array2.Length >= i + 7)
									{
										base.a(array2, i + 2, i + 8, A_3);
										num5 = i + 8;
										i += 7;
									}
									else
									{
										base.a(array2, i + 2, array2.Length, A_3);
										num5 = i + 8;
										i += 7;
									}
								}
							}
							if (num5 < array2.Length)
							{
								byte[] array = new byte[array2.Length - num5];
								Array.Copy(array2, num5, array, 0, array2.Length - num5);
								this.a(array, a_, A_3);
							}
						}
						num2 += num3;
						if (num2 >= A_0.Length)
						{
							goto Block_68;
						}
					}
					throw new ao("Invalid symbol size for overflow.");
					Block_68:
					if (base.e())
					{
						A_3 = base.b(A_3);
					}
				}
			}
			else if (!base.d() || A_0.Length + 2 + 1 + A_3.a() <= base.c() - 4)
			{
				if (base.b() != 9)
				{
					base.b(base.b(), A_3);
					base.c(9, A_3);
				}
				int num6 = A_0.Length;
				if (num6 < 250)
				{
					int num7 = 149 * (A_3.a() + num) % 255 + 1;
					num7 += num6;
					if (num7 <= 255)
					{
						A_3.a((byte)num7);
					}
					else
					{
						A_3.a((byte)(num7 - 256));
					}
				}
				else
				{
					int num4 = num6 / 250 + 249;
					int num7 = 149 * (A_3.a() + num) % 255 + 1;
					num7 += num4;
					if (num7 <= 255)
					{
						A_3.a((byte)num7);
					}
					else
					{
						A_3.a((byte)(num7 - 256));
					}
					num4 = num6 % 250;
					num7 = 149 * (A_3.a() + num) % 255 + 1;
					num7 += num4;
					if (num7 <= 255)
					{
						A_3.a((byte)num7);
					}
					else
					{
						A_3.a((byte)(num7 - 256));
					}
				}
				for (int j = 0; j < num6; j++)
				{
					int num7 = 149 * (A_3.a() + num) % 255 + 1;
					num7 += (int)A_0[j];
					if (num7 <= 255)
					{
						A_3.a((byte)num7);
					}
					else
					{
						A_3.a((byte)(num7 - 256));
					}
				}
				if (base.e() && A_1)
				{
					A_3 = base.b(A_3);
				}
			}
			else
			{
				int num3 = base.c() - A_3.a() - 3 - 4;
				int num4 = A_0.Length + num3;
				int num2 = 0;
				for (;;)
				{
					if (num2 != 0)
					{
						if (A_3.a() == 0)
						{
							break;
						}
						A_3 = base.a(A_3);
					}
					num4 -= num3;
					byte[] array2;
					if (num4 >= num3)
					{
						array2 = new byte[num3];
						Array.Copy(A_0, num2, array2, 0, num3);
					}
					else
					{
						array2 = new byte[num4];
						Array.Copy(A_0, num2, array2, 0, num4);
					}
					A_3 = this.a(array2, false, A_2, A_3, A_4);
					num2 += num3;
					if (num2 >= A_0.Length)
					{
						goto Block_84;
					}
				}
				throw new ao("Invalid symbol size for overflow.");
				Block_84:
				if (base.e())
				{
					A_3 = base.b(A_3);
				}
			}
			return A_3;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000242E8 File Offset: 0x000232E8
		private void a(byte[] A_0, bool A_1, i A_2)
		{
			int num;
			if (A_1)
			{
				num = 5;
			}
			else
			{
				num = 1;
			}
			if (base.b() != 9)
			{
				base.b(base.b(), A_2);
				base.c(9, A_2);
			}
			int num2 = A_0.Length;
			if (num2 < 250)
			{
				int num3 = 149 * (A_2.a() + num) % 255 + 1;
				num3 += num2;
				if (num3 <= 255)
				{
					A_2.a((byte)num3);
				}
				else
				{
					A_2.a((byte)(num3 - 256));
				}
			}
			else
			{
				int num4 = num2 / 250 + 249;
				int num3 = 149 * (A_2.a() + num) % 255 + 1;
				num3 += num4;
				if (num3 <= 255)
				{
					A_2.a((byte)num3);
				}
				else
				{
					A_2.a((byte)(num3 - 256));
				}
				num4 = num2 % 250;
				num3 = 149 * (A_2.a() + num) % 255 + 1;
				num3 += num4;
				if (num3 <= 255)
				{
					A_2.a((byte)num3);
				}
				else
				{
					A_2.a((byte)(num3 - 256));
				}
			}
			for (int i = 0; i < num2; i++)
			{
				int num3 = 149 * (A_2.a() + num) % 255 + 1;
				num3 += (int)A_0[i];
				if (num3 <= 255)
				{
					A_2.a((byte)num3);
				}
				else
				{
					A_2.a((byte)(num3 - 256));
				}
			}
		}
	}
}
