using System;

namespace zz93
{
	// Token: 0x020003CA RID: 970
	internal class zd
	{
		// Token: 0x060028DD RID: 10461 RVA: 0x0017AB09 File Offset: 0x00179B09
		internal zd(byte[] A_0, int A_1) : this(A_0, 0, A_1)
		{
		}

		// Token: 0x060028DE RID: 10462 RVA: 0x0017AB18 File Offset: 0x00179B18
		internal zd(byte[] A_0, int A_1, int A_2)
		{
			this.d = A_1;
			this.g = new byte[A_2];
			this.a = A_0;
			for (int i = 0; i < 256; i++)
			{
				this.i[i] = new byte[]
				{
					(byte)i
				};
			}
			int a_ = 0;
			int num;
			while ((num = this.a()) != 257 && this.h < A_2)
			{
				if (num == 256)
				{
					this.b();
					num = this.a();
					if (num == 257)
					{
						break;
					}
					this.b(this.b(num));
					a_ = num;
				}
				else if (this.a(num))
				{
					this.b(this.b(num));
					this.a(this.a(this.b(a_), this.b(num)[0]));
					a_ = num;
				}
				else
				{
					byte[] a_2 = this.a(this.b(a_), this.b(a_)[0]);
					this.b(a_2);
					this.a(a_2);
					a_ = num;
				}
			}
		}

		// Token: 0x060028DF RID: 10463 RVA: 0x0017AC9E File Offset: 0x00179C9E
		private void c()
		{
			this.b++;
			this.c = (this.c << 1 | 1);
		}

		// Token: 0x060028E0 RID: 10464 RVA: 0x0017ACC0 File Offset: 0x00179CC0
		private void b(byte[] A_0)
		{
			if (this.h + A_0.Length > this.g.Length)
			{
				byte[] array = new byte[this.g.Length * 2];
				this.g.CopyTo(array, 0);
				this.g = array;
			}
			A_0.CopyTo(this.g, this.h);
			this.h += A_0.Length;
		}

		// Token: 0x060028E1 RID: 10465 RVA: 0x0017AD33 File Offset: 0x00179D33
		private void b()
		{
			this.j = 258;
			this.b = 9;
			this.c = 511;
		}

		// Token: 0x060028E2 RID: 10466 RVA: 0x0017AD54 File Offset: 0x00179D54
		private void a(byte[] A_0)
		{
			this.i[this.j++] = A_0;
			int num = this.j;
			if (num != 511)
			{
				if (num != 1023)
				{
					if (num == 2047)
					{
						this.c();
					}
				}
				else
				{
					this.c();
				}
			}
			else
			{
				this.c();
			}
		}

		// Token: 0x060028E3 RID: 10467 RVA: 0x0017ADB8 File Offset: 0x00179DB8
		private byte[] a(byte[] A_0, byte A_1)
		{
			byte[] array = new byte[A_0.Length + 1];
			A_0.CopyTo(array, 0);
			array[A_0.Length] = A_1;
			return array;
		}

		// Token: 0x060028E4 RID: 10468 RVA: 0x0017ADE8 File Offset: 0x00179DE8
		private byte[] b(int A_0)
		{
			return this.i[A_0];
		}

		// Token: 0x060028E5 RID: 10469 RVA: 0x0017AE04 File Offset: 0x00179E04
		private bool a(int A_0)
		{
			return A_0 < this.j;
		}

		// Token: 0x060028E6 RID: 10470 RVA: 0x0017AE20 File Offset: 0x00179E20
		private int a()
		{
			while (this.f < this.b && this.d < this.a.Length)
			{
				this.e <<= 8;
				this.e |= (int)this.a[this.d++];
				this.f += 8;
			}
			this.f -= this.b;
			int result;
			if (this.f < 0)
			{
				result = 257;
			}
			else
			{
				result = (this.e >> this.f & this.c);
			}
			return result;
		}

		// Token: 0x060028E7 RID: 10471 RVA: 0x0017AEE0 File Offset: 0x00179EE0
		internal byte[] d()
		{
			return this.g;
		}

		// Token: 0x060028E8 RID: 10472 RVA: 0x0017AEF8 File Offset: 0x00179EF8
		internal int e()
		{
			return this.h;
		}

		// Token: 0x0400127E RID: 4734
		private byte[] a;

		// Token: 0x0400127F RID: 4735
		private int b = 9;

		// Token: 0x04001280 RID: 4736
		private int c = 511;

		// Token: 0x04001281 RID: 4737
		private int d = 0;

		// Token: 0x04001282 RID: 4738
		private int e = 0;

		// Token: 0x04001283 RID: 4739
		private int f = 0;

		// Token: 0x04001284 RID: 4740
		private byte[] g;

		// Token: 0x04001285 RID: 4741
		private int h;

		// Token: 0x04001286 RID: 4742
		private byte[][] i = new byte[4096][];

		// Token: 0x04001287 RID: 4743
		private int j = 258;
	}
}
