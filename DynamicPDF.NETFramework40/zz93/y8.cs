using System;

namespace zz93
{
	// Token: 0x020003C5 RID: 965
	internal class y8 : y7
	{
		// Token: 0x060028B3 RID: 10419 RVA: 0x00178CD0 File Offset: 0x00177CD0
		internal y8(byte[] A_0)
		{
			this.a = A_0;
			for (int i = 0; i < 256; i++)
			{
				this.k[i] = new byte[]
				{
					(byte)i
				};
			}
			this.b = (this.d = (int)(A_0[this.f++] + 1));
			this.r = (int)A_0[this.f++] + this.f;
			this.c = 1;
			this.l = 1;
			for (int i = 1; i < this.b; i++)
			{
				this.c = (this.c << 1 | 1);
				this.l *= 2;
			}
			this.e = this.c;
			this.p = this.l * 2;
			this.o = this.l++;
			this.n = this.l++;
		}

		// Token: 0x060028B4 RID: 10420 RVA: 0x00178E08 File Offset: 0x00177E08
		internal override void g6(byte[] A_0, int A_1)
		{
			int a_ = 0;
			this.i = A_0;
			this.j = A_1;
			int num;
			while (this.j < A_0.Length && (num = this.c()) != this.n)
			{
				if (num == this.o)
				{
					this.a();
					num = this.c();
					if (num == this.n)
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

		// Token: 0x060028B5 RID: 10421 RVA: 0x00178F0C File Offset: 0x00177F0C
		private int c()
		{
			while (this.h < this.d)
			{
				if (this.f == this.r)
				{
					this.r = (int)this.a[this.f++] + this.f;
				}
				this.g |= (int)this.a[this.f++] << (this.h & 31);
				this.h += 8;
			}
			int result = this.g & this.e;
			this.h -= this.d;
			this.g >>= this.d;
			return result;
		}

		// Token: 0x060028B6 RID: 10422 RVA: 0x00178FE8 File Offset: 0x00177FE8
		private void b()
		{
			this.d++;
			this.e = (this.e << 1 | 1);
			this.q *= 2;
		}

		// Token: 0x060028B7 RID: 10423 RVA: 0x00179017 File Offset: 0x00178017
		private void b(byte[] A_0)
		{
			A_0.CopyTo(this.i, this.j);
			this.j += A_0.Length;
		}

		// Token: 0x060028B8 RID: 10424 RVA: 0x0017903D File Offset: 0x0017803D
		private void a()
		{
			this.m = this.l;
			this.d = this.b;
			this.e = this.c;
			this.q = this.p;
		}

		// Token: 0x060028B9 RID: 10425 RVA: 0x00179070 File Offset: 0x00178070
		private void a(byte[] A_0)
		{
			this.k[this.m++] = A_0;
			if (this.m == this.q && this.m < 4096)
			{
				this.b();
			}
		}

		// Token: 0x060028BA RID: 10426 RVA: 0x001790C8 File Offset: 0x001780C8
		private byte[] a(byte[] A_0, byte A_1)
		{
			byte[] array = new byte[A_0.Length + 1];
			A_0.CopyTo(array, 0);
			array[A_0.Length] = A_1;
			return array;
		}

		// Token: 0x060028BB RID: 10427 RVA: 0x001790F8 File Offset: 0x001780F8
		private byte[] b(int A_0)
		{
			return this.k[A_0];
		}

		// Token: 0x060028BC RID: 10428 RVA: 0x00179114 File Offset: 0x00178114
		private bool a(int A_0)
		{
			return A_0 < this.m;
		}

		// Token: 0x0400122D RID: 4653
		private new byte[] a;

		// Token: 0x0400122E RID: 4654
		private int b;

		// Token: 0x0400122F RID: 4655
		private int c;

		// Token: 0x04001230 RID: 4656
		private int d;

		// Token: 0x04001231 RID: 4657
		private int e;

		// Token: 0x04001232 RID: 4658
		private int f = 0;

		// Token: 0x04001233 RID: 4659
		private int g = 0;

		// Token: 0x04001234 RID: 4660
		private int h = 0;

		// Token: 0x04001235 RID: 4661
		private byte[] i;

		// Token: 0x04001236 RID: 4662
		private int j;

		// Token: 0x04001237 RID: 4663
		private byte[][] k = y7.a();

		// Token: 0x04001238 RID: 4664
		private int l;

		// Token: 0x04001239 RID: 4665
		private int m;

		// Token: 0x0400123A RID: 4666
		private int n;

		// Token: 0x0400123B RID: 4667
		private int o;

		// Token: 0x0400123C RID: 4668
		private int p;

		// Token: 0x0400123D RID: 4669
		private int q;

		// Token: 0x0400123E RID: 4670
		private int r;
	}
}
