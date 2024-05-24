using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000014 RID: 20
	internal class r
	{
		// Token: 0x060000CC RID: 204 RVA: 0x0001F0FE File Offset: 0x0001E0FE
		internal r(int A_0, int A_1, bool A_2, bool A_3, bool A_4)
		{
			this.f = A_0;
			this.d = A_2;
			this.e = A_3;
			this.c = A_1;
			this.g = A_4;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0001F138 File Offset: 0x0001E138
		internal int a()
		{
			return this.b;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0001F150 File Offset: 0x0001E150
		internal void b(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0001F15C File Offset: 0x0001E15C
		internal int b()
		{
			return this.c;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0001F174 File Offset: 0x0001E174
		internal void c(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0001F180 File Offset: 0x0001E180
		internal int c()
		{
			return this.f;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0001F198 File Offset: 0x0001E198
		internal bool d()
		{
			return this.e;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0001F1B0 File Offset: 0x0001E1B0
		internal bool e()
		{
			return this.d;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0001F1C8 File Offset: 0x0001E1C8
		internal ArrayList f()
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
			}
			return this.a;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0001F1FB File Offset: 0x0001E1FB
		internal void a(ArrayList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0001F208 File Offset: 0x0001E208
		internal void a(byte[] A_0, int A_1, int A_2, i A_3)
		{
			int num = 0;
			for (int i = A_1; i < A_2; i++)
			{
				if (A_0[i] <= 47 || A_0[i] >= 58)
				{
					throw new an("ECI number must be 6 digits long.");
				}
				num += (int)(A_0[i] - 48);
				num *= 10;
			}
			num /= 10;
			this.a(num, A_3);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0001F270 File Offset: 0x0001E270
		internal void a(int A_0, i A_1)
		{
			if (A_0 <= 126)
			{
				A_1.a(241);
				A_1.a((byte)(A_0 + 1));
			}
			else if (A_0 > 126 && A_0 <= 16382)
			{
				A_1.a(241);
				A_1.a((byte)((A_0 - 127) / 254 + 128));
			}
			else if (A_0 > 16382 && A_0 <= 999999)
			{
				A_1.a(241);
				A_1.a((byte)((A_0 - 16383) / 64516 + 192));
				A_1.a((byte)((A_0 - 16383) / 254 % 254 + 1));
				A_1.a((byte)((A_0 - 16383) % 254 + 1));
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0001F358 File Offset: 0x0001E358
		internal i a(i A_0)
		{
			i result;
			if (!this.g)
			{
				this.b(this.b(), A_0);
				byte[] array = new byte[A_0.a()];
				Array.Copy(A_0.a, 0, array, 0, A_0.a());
				if (this.f() == null)
				{
					this.a(new ArrayList());
				}
				this.f().Add(array);
				A_0 = new i();
				this.b++;
				this.c(1);
				result = A_0;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0001F3F4 File Offset: 0x0001E3F4
		internal i b(i A_0)
		{
			i result;
			if (!this.g)
			{
				this.b(this.b(), A_0);
				byte[] array = new byte[A_0.a()];
				Array.Copy(A_0.a, 0, array, 0, A_0.a());
				if (this.f() == null)
				{
					this.a(new ArrayList());
				}
				this.f().Add(array);
				A_0 = new i();
				result = A_0;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0001F478 File Offset: 0x0001E478
		internal bool a(int A_0, int A_1)
		{
			return A_0 <= A_1 - 4;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0001F49C File Offset: 0x0001E49C
		internal int d(int A_0)
		{
			int num = 0;
			num += A_0 / 3;
			num *= 2;
			if (A_0 % 3 != 0)
			{
				num += 4;
			}
			return num;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0001F4CC File Offset: 0x0001E4CC
		internal void b(int A_0, i A_1)
		{
			switch (A_0)
			{
			case 1:
			case 2:
			case 4:
			case 9:
				this.c(1);
				break;
			case 5:
			case 6:
			case 7:
				A_1.a(254);
				this.c(1);
				break;
			case 8:
				A_1.a(31);
				this.c(1);
				break;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0001F540 File Offset: 0x0001E540
		internal void c(int A_0, i A_1)
		{
			switch (A_0)
			{
			case 1:
				this.c(1);
				break;
			case 5:
				A_1.a(230);
				this.c(5);
				break;
			case 6:
				A_1.a(239);
				this.c(6);
				break;
			case 7:
				A_1.a(238);
				this.c(7);
				break;
			case 8:
				A_1.a(240);
				this.c(8);
				break;
			case 9:
				A_1.a(231);
				this.c(9);
				break;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0001F5F8 File Offset: 0x0001E5F8
		internal void b(i A_0, i A_1)
		{
			int num = A_0.a();
			int num2 = num % 3;
			if (num2 == 0)
			{
				for (int i = 0; i <= num - 2; i++)
				{
					ushort num3 = (ushort)((int)A_0.b(i) * 1600 + (int)(A_0.b(i + 1) * 40) + (int)A_0.b(i + 2) + 1);
					A_1.a((byte)(num3 / 256));
					A_1.a((byte)(num3 % 256));
					i += 2;
				}
			}
			else
			{
				num -= num2;
				for (int i = 0; i < num; i++)
				{
					ushort num3 = (ushort)((int)A_0.b(i) * 1600 + (int)(A_0.b(i + 1) * 40) + (int)A_0.b(i + 2) + 1);
					A_1.a((byte)(num3 / 256));
					A_1.a((byte)(num3 % 256));
					i += 2;
				}
				if (num2 == 2)
				{
					ushort num3 = (ushort)((int)A_0.b(num) * 1600 + (int)(A_0.b(num + 1) * 40) + 1);
					A_1.a((byte)(num3 / 256));
					A_1.a((byte)(num3 % 256));
				}
				else if (num2 == 1)
				{
					ushort num3 = (ushort)((int)A_0.b(num) * 1600 + 1);
					A_1.a((byte)(num3 / 256));
					A_1.a((byte)(num3 % 256));
				}
			}
			if (this.b() != 1)
			{
				this.b(this.c, A_1);
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0001F798 File Offset: 0x0001E798
		internal void a(i A_0, i A_1, byte[] A_2, int A_3, int A_4, bool A_5, i A_6, int A_7)
		{
			int num;
			if (A_5)
			{
				num = 1;
			}
			else
			{
				num = 4;
			}
			if (A_0.a() > 0)
			{
				if (!this.d() || this.a(A_6.a() + this.d(A_0.a()), this.c() - 2))
				{
					if (this.b() != A_7)
					{
						this.c(A_7, A_6);
						this.c(A_7);
					}
					this.b(A_0, A_6);
					if (this.b() != 1)
					{
						this.b(this.b(), A_6);
					}
					if (!this.d() || this.a(A_6.a() + num, this.c()))
					{
						if (A_5)
						{
							A_6.a(232);
						}
						else
						{
							this.a(A_2, A_3, A_4, A_6);
						}
					}
					else
					{
						A_6 = this.a(A_6);
						if (A_5)
						{
							A_6.a(232);
						}
						else
						{
							this.a(A_2, A_3, A_4, A_6);
						}
					}
				}
				else
				{
					A_6 = this.a(A_6);
					this.c(A_7, A_6);
					this.b(A_0, A_6);
					if (this.b() != 1)
					{
						this.b(this.b(), A_6);
					}
					if (A_5)
					{
						A_6.a(232);
					}
					else
					{
						this.a(A_2, A_3, A_4, A_6);
					}
				}
			}
			else if (A_0.a() == 0 && A_1.a() > 0)
			{
				if (!this.d() || this.a(A_6.a() + this.d(A_1.a()), this.c() - 2))
				{
					if (this.b() != A_7)
					{
						this.c(A_7, A_6);
						this.c(A_7);
					}
					this.b(A_1, A_6);
					if (this.b() != 1)
					{
						this.b(this.b(), A_6);
					}
					if (!this.d() || this.a(A_6.a() + num, this.c()))
					{
						if (A_5)
						{
							A_6.a(232);
						}
						else
						{
							this.a(A_2, A_3, A_4, A_6);
						}
					}
					else
					{
						A_6 = this.a(A_6);
						if (A_5)
						{
							A_6.a(232);
						}
						else
						{
							this.a(A_2, A_3, A_4, A_6);
						}
					}
				}
				else
				{
					A_6 = this.a(A_6);
					this.c(A_7, A_6);
					this.b(A_0, A_6);
					if (this.b() != 1)
					{
						this.b(this.b(), A_6);
					}
					if (A_5)
					{
						A_6.a(232);
					}
					else
					{
						this.a(A_2, A_3, A_4, A_6);
					}
				}
			}
			else if (A_0.a() == 0)
			{
				if (this.b() != 1)
				{
					this.b(this.b(), A_6);
				}
				if (!this.d() || this.a(A_6.a() + num, this.c()))
				{
					if (A_5)
					{
						A_6.a(232);
					}
					else
					{
						this.a(A_2, A_3, A_4, A_6);
					}
				}
				else
				{
					A_6 = this.a(A_6);
					if (A_5)
					{
						A_6.a(232);
					}
					else
					{
						this.a(A_2, A_3, A_4, A_6);
					}
				}
			}
		}

		// Token: 0x04000085 RID: 133
		private ArrayList a;

		// Token: 0x04000086 RID: 134
		private int b;

		// Token: 0x04000087 RID: 135
		private int c;

		// Token: 0x04000088 RID: 136
		private bool d = false;

		// Token: 0x04000089 RID: 137
		private bool e;

		// Token: 0x0400008A RID: 138
		private int f;

		// Token: 0x0400008B RID: 139
		private bool g;
	}
}
