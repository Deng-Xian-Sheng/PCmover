using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000053 RID: 83
	internal class br
	{
		// Token: 0x060002C0 RID: 704 RVA: 0x0003E74C File Offset: 0x0003D74C
		internal br(int A_0)
		{
			this.b = new byte[A_0];
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0003E774 File Offset: 0x0003D774
		internal byte[] a()
		{
			return this.b;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0003E78C File Offset: 0x0003D78C
		internal int b()
		{
			return this.c;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0003E7A4 File Offset: 0x0003D7A4
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0003E7B0 File Offset: 0x0003D7B0
		internal br c()
		{
			return this.a;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0003E7C8 File Offset: 0x0003D7C8
		internal void a(br A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0003E7D4 File Offset: 0x0003D7D4
		internal bool d()
		{
			return false;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0003E7E7 File Offset: 0x0003D7E7
		internal void b(int A_0)
		{
			this.b = new byte[A_0];
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0003E7F8 File Offset: 0x0003D7F8
		internal void a(Stream A_0, int A_1, int A_2)
		{
			if (this.b.Length - A_1 >= A_2)
			{
				A_0.Write(this.b, A_1, A_2);
			}
			else
			{
				int num = this.b.Length - A_1;
				A_0.Write(this.b, A_1, num);
				br br = this.a;
				do
				{
					int num2 = A_2 - num;
					if (br.a().Length < num2)
					{
						num2 = br.a().Length;
					}
					A_0.Write(br.a(), 0, num2);
					num += num2;
					br = br.c();
				}
				while (num < A_2);
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0003E894 File Offset: 0x0003D894
		internal void a(Stream A_0, int A_1, int A_2, Encrypter A_3)
		{
			if (this.b.Length - A_1 >= A_2)
			{
				A_3.Encrypt(A_0, this.b, A_1, A_2);
			}
			else if (A_3 is bz || A_3 is b0)
			{
				byte[] array = new byte[A_2];
				int num = this.b.Length - A_1;
				Array.Copy(this.b, A_1, array, 0, num);
				br br = this.a;
				do
				{
					int num2 = A_2 - num;
					if (br.a().Length < num2)
					{
						num2 = br.a().Length;
					}
					Array.Copy(br.a(), 0, array, num, num2);
					num += num2;
					br = br.c();
				}
				while (num < A_2);
				A_3.Encrypt(A_0, array, 0, A_2);
			}
			else
			{
				int num = this.b.Length - A_1;
				A_3.Encrypt(A_0, this.b, A_1, num);
				br br = this.a;
				do
				{
					int num2 = A_2 - num;
					if (br.a().Length < num2)
					{
						num2 = br.a().Length;
					}
					A_3.Encrypt(A_0, br.a(), 0, num2);
					num += num2;
					br = br.c();
				}
				while (num < A_2);
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0003E9E4 File Offset: 0x0003D9E4
		internal void a(byte A_0)
		{
			this.b[this.c++] = A_0;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0003EA0B File Offset: 0x0003DA0B
		internal void a(byte[] A_0)
		{
			Array.Copy(A_0, 0, this.b, this.c, A_0.Length);
			this.c += A_0.Length;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0003EA35 File Offset: 0x0003DA35
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			Array.Copy(A_0, A_1, this.b, this.c, A_2);
			this.c += A_2;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0003EA5C File Offset: 0x0003DA5C
		internal void e()
		{
			this.b[this.c++] = 32;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0003EA84 File Offset: 0x0003DA84
		internal void f()
		{
			this.b[this.c++] = 10;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0003EAAC File Offset: 0x0003DAAC
		internal void a(float A_0)
		{
			if (A_0 == 0f)
			{
				this.b[this.c++] = 48;
			}
			else
			{
				if (A_0 < 0f)
				{
					A_0 = -A_0;
					this.b[this.c++] = 45;
				}
				int num = (int)A_0;
				int i = 0;
				int j;
				int num2;
				if (num < 10)
				{
					this.b[this.c++] = (byte)(num + 48);
					j = (int)((A_0 - (float)num) * 100000f);
					num2 = 10000;
				}
				else if (num < 100)
				{
					i = 10;
					j = (int)((A_0 - (float)num) * 10000f);
					num2 = 1000;
				}
				else if (num < 1000)
				{
					i = 100;
					j = (int)((A_0 - (float)num) * 1000f);
					num2 = 100;
				}
				else if (num < 10000)
				{
					i = 1000;
					j = (int)((A_0 - (float)num) * 100f);
					num2 = 10;
				}
				else
				{
					if (num >= 100000)
					{
						throw new Exception("Exceeds float max");
					}
					i = 10000;
					j = (int)((A_0 - (float)num) * 10f);
					num2 = 1;
				}
				while (i > 0)
				{
					int num3 = num / i;
					this.b[this.c++] = (byte)(num3 + 48);
					num -= num3 * i;
					i /= 10;
				}
				if (j > 0)
				{
					this.b[this.c++] = 46;
					while (j > 0)
					{
						int num3 = j / num2;
						this.b[this.c++] = (byte)(num3 + 48);
						j -= num3 * num2;
						num2 /= 10;
					}
				}
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0003ECCC File Offset: 0x0003DCCC
		internal void b(float A_0)
		{
			if (A_0 <= 0f)
			{
				this.b[this.c++] = 48;
			}
			else if (A_0 >= 1f)
			{
				this.b[this.c++] = 49;
			}
			else
			{
				int i = (int)(A_0 * 10000f);
				bool flag = false;
				int num = 1000;
				this.b[this.c++] = 46;
				while (i > 0)
				{
					int num2 = (int)((byte)(i / num));
					this.b[this.c++] = (byte)(num2 + 48);
					flag = true;
					i -= num2 * num;
					num /= 10;
				}
				if (!flag)
				{
					this.c--;
					this.b[this.c++] = 48;
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0003EDE0 File Offset: 0x0003DDE0
		internal void c(float A_0)
		{
			int i = (int)(A_0 * 100f);
			bool flag = false;
			if (i < 0)
			{
				i = -i;
				this.b[this.c++] = 45;
			}
			int j;
			if (i < 100)
			{
				j = 10;
			}
			else
			{
				if (i < 10000)
				{
					j = 1000;
				}
				else if (i < 1000000)
				{
					j = 100000;
				}
				else
				{
					if (i >= 100000000)
					{
						throw new Exception("Maximum Float Value Exceeded.");
					}
					j = 10000000;
				}
				while (j >= 100)
				{
					int num = i / j;
					if (flag || num > 0)
					{
						this.b[this.c++] = (byte)(num + 48);
						flag = true;
					}
					i -= num * j;
					j /= 10;
				}
			}
			if (i > 0)
			{
				this.b[this.c++] = 46;
			}
			while (i > 0)
			{
				int num = i / j;
				this.b[this.c++] = (byte)(num + 48);
				flag = true;
				i -= num * j;
				j /= 10;
			}
			if (!flag)
			{
				this.b[this.c++] = 48;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0003EF78 File Offset: 0x0003DF78
		internal void c(int A_0)
		{
			if (A_0 < 0)
			{
				A_0 = -A_0;
				this.b[this.c++] = 45;
			}
			int i;
			if (A_0 < 10)
			{
				i = 1;
			}
			else if (A_0 < 100)
			{
				i = 10;
			}
			else if (A_0 < 1000)
			{
				i = 100;
			}
			else if (A_0 < 10000)
			{
				i = 1000;
			}
			else if (A_0 < 1000000)
			{
				i = 100000;
			}
			else
			{
				i = 1000000000;
			}
			bool flag = false;
			while (i >= 1)
			{
				int num = (int)((byte)(A_0 / i));
				if (flag || num > 0)
				{
					this.b[this.c++] = (byte)(num + 48);
					flag = true;
				}
				A_0 -= num * i;
				i /= 10;
			}
			if (!flag)
			{
				this.b[this.c++] = 48;
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0003F094 File Offset: 0x0003E094
		internal void b(byte[] A_0)
		{
			this.b[this.c++] = 40;
			for (int i = 0; i < A_0.Length; i++)
			{
				byte b = A_0[i];
				if (b != 13)
				{
					switch (b)
					{
					case 40:
						this.b[this.c++] = 92;
						break;
					case 41:
						this.b[this.c++] = 92;
						break;
					default:
						if (b == 92)
						{
							this.b[this.c++] = 92;
						}
						break;
					}
					this.b[this.c++] = A_0[i];
				}
				else
				{
					this.b[this.c++] = 92;
					this.b[this.c++] = 114;
				}
			}
			this.b[this.c++] = 41;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0003F1BC File Offset: 0x0003E1BC
		internal void a(SingleByteEncoder A_0, char[] A_1, int A_2, int A_3, bool A_4)
		{
			this.g();
			if (A_4)
			{
				for (int i = A_2 + A_3 - 1; i >= A_2; i--)
				{
					byte b = A_0.Encode(A_1[i]);
					if (b != 0)
					{
						this.b(b);
					}
				}
			}
			else
			{
				for (int i = A_2; i < A_2 + A_3; i++)
				{
					byte b = A_0.Encode(A_1[i]);
					if (b != 0)
					{
						this.b(b);
					}
				}
			}
			this.h();
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0003F250 File Offset: 0x0003E250
		internal void b(byte A_0)
		{
			if (A_0 != 13)
			{
				switch (A_0)
				{
				case 40:
					this.b[this.c++] = 92;
					break;
				case 41:
					this.b[this.c++] = 92;
					break;
				default:
					if (A_0 == 92)
					{
						this.b[this.c++] = 92;
					}
					break;
				}
				this.b[this.c++] = A_0;
			}
			else
			{
				this.b[this.c++] = 92;
				this.b[this.c++] = 114;
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0003F328 File Offset: 0x0003E328
		internal void g()
		{
			this.b[this.c++] = 40;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0003F350 File Offset: 0x0003E350
		internal void h()
		{
			this.b[this.c++] = 41;
		}

		// Token: 0x040001F1 RID: 497
		private br a = null;

		// Token: 0x040001F2 RID: 498
		private byte[] b;

		// Token: 0x040001F3 RID: 499
		private int c = 0;
	}
}
