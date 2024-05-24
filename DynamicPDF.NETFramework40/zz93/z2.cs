using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003E3 RID: 995
	internal class z2
	{
		// Token: 0x060029B2 RID: 10674 RVA: 0x001857DC File Offset: 0x001847DC
		internal z2()
		{
		}

		// Token: 0x060029B3 RID: 10675 RVA: 0x00185808 File Offset: 0x00184808
		internal void a(zq A_0)
		{
			if (this.b == this.a.Length)
			{
				zq[] array = new zq[this.b * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x060029B4 RID: 10676 RVA: 0x0018586C File Offset: 0x0018486C
		internal int a()
		{
			int num = 0;
			for (int i = 0; i < this.b; i++)
			{
				num += this.a[i].g8();
			}
			return num;
		}

		// Token: 0x060029B5 RID: 10677 RVA: 0x001858A8 File Offset: 0x001848A8
		internal void a(b3 A_0, int A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i] is zr)
				{
					((zr)this.a[i]).a(A_0, A_1);
				}
			}
		}

		// Token: 0x060029B6 RID: 10678 RVA: 0x001858FC File Offset: 0x001848FC
		internal void b()
		{
			for (int i = 0; i < this.d; i++)
			{
				this.c[i].a().i();
			}
		}

		// Token: 0x060029B7 RID: 10679 RVA: 0x00185934 File Offset: 0x00184934
		internal int c()
		{
			int result;
			if (this.d == 0)
			{
				result = 1;
			}
			else
			{
				int num = 1;
				for (int i = 0; i < this.d; i++)
				{
					if (this.c[i].a().j() < 2147483544)
					{
						num += this.c[i].a().f();
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060029B8 RID: 10680 RVA: 0x001859AC File Offset: 0x001849AC
		internal int d()
		{
			int result;
			if (this.d == 0)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				for (int i = 0; i < this.d; i++)
				{
					num += this.c[i].a().g();
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060029B9 RID: 10681 RVA: 0x00185A04 File Offset: 0x00184A04
		internal void a(zy A_0, int A_1, aaa A_2)
		{
			for (int i = 0; i < this.d; i++)
			{
				this.c[i].a().a(A_0, A_1, A_2);
			}
		}

		// Token: 0x060029BA RID: 10682 RVA: 0x00185A40 File Offset: 0x00184A40
		internal void a(zy A_0)
		{
			for (int i = 0; i < this.d; i++)
			{
				this.c[i].a().a(A_0);
			}
		}

		// Token: 0x060029BB RID: 10683 RVA: 0x00185A7C File Offset: 0x00184A7C
		internal int e()
		{
			int result;
			if (this.d == 0)
			{
				result = 1;
			}
			else
			{
				int num = 1;
				for (int i = 0; i < this.d; i++)
				{
					if (this.c[i].a().j() >= 2147483647)
					{
						num += this.c[i].a().h();
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060029BC RID: 10684 RVA: 0x00185AF0 File Offset: 0x00184AF0
		internal void a(int A_0)
		{
			for (int i = 0; i < this.d; i++)
			{
				this.c[i].a().b(A_0);
			}
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x00185B2C File Offset: 0x00184B2C
		internal void a(z9 A_0)
		{
			if (this.b == this.a.Length)
			{
				zq[] array = new zq[this.b * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			if (this.c == null)
			{
				this.c = new z9[3];
			}
			else if (this.d == this.c.Length)
			{
				z9[] array2 = new z9[this.d * 3];
				this.c.CopyTo(array2, 0);
				this.c = array2;
			}
			this.a[this.b++] = A_0;
			this.c[this.d++] = A_0;
		}

		// Token: 0x060029BE RID: 10686 RVA: 0x00185C04 File Offset: 0x00184C04
		internal void b(z9 A_0)
		{
			if (this.b == this.a.Length)
			{
				zq[] array = new zq[this.b * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x060029BF RID: 10687 RVA: 0x00185C68 File Offset: 0x00184C68
		internal void a(Stream A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].g7(A_0);
			}
		}

		// Token: 0x04001308 RID: 4872
		private zq[] a = new zq[1];

		// Token: 0x04001309 RID: 4873
		private int b = 0;

		// Token: 0x0400130A RID: 4874
		private z9[] c = null;

		// Token: 0x0400130B RID: 4875
		private int d = 0;
	}
}
