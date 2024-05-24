using System;

namespace zz93
{
	// Token: 0x02000248 RID: 584
	internal class pa : dy
	{
		// Token: 0x06001AC6 RID: 6854 RVA: 0x00116958 File Offset: 0x00115958
		internal pa(char[] A_0, int A_1, int A_2, p1 A_3) : base(A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x001169A8 File Offset: 0x001159A8
		internal bool a()
		{
			return this.b - 1 >= 0 && this.a[this.b - 1] == ' ';
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x001169E0 File Offset: 0x001159E0
		internal bool b()
		{
			return this.c - this.b + 1 <= this.a.Length && this.a[this.c - this.b + 1] == ' ';
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x00116A30 File Offset: 0x00115A30
		internal char[] c()
		{
			return this.a;
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x00116A48 File Offset: 0x00115A48
		internal int d()
		{
			return this.b;
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x00116A60 File Offset: 0x00115A60
		internal int e()
		{
			return this.c;
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x00116A78 File Offset: 0x00115A78
		internal bool f()
		{
			return this.d;
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x00116A90 File Offset: 0x00115A90
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x00116A9C File Offset: 0x00115A9C
		internal override bool d5()
		{
			return this.e;
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x00116AB4 File Offset: 0x00115AB4
		internal override void d6(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x00116AC0 File Offset: 0x00115AC0
		internal override kz cm(ij A_0, kz A_1)
		{
			kz result;
			if (this.c == 1 && this.a[0] == ' ')
			{
				nk nk = new nk();
				nk.j(A_1);
				nk.dc(A_1.db());
				result = nk;
			}
			else
			{
				n3 n = new n3(this.a, this.b, this.c, A_0);
				n.j(A_1);
				n.dc(A_1.db());
				n.a(true);
				int num = A_1.dg();
				if (num == 23684646)
				{
					((n2)A_1).a(n.j());
					n.a(false);
					this.cj(false);
				}
				result = n;
			}
			return result;
		}

		// Token: 0x04000C2C RID: 3116
		private new char[] a = null;

		// Token: 0x04000C2D RID: 3117
		private int b = 0;

		// Token: 0x04000C2E RID: 3118
		private int c = 0;

		// Token: 0x04000C2F RID: 3119
		private new bool d = false;

		// Token: 0x04000C30 RID: 3120
		private new bool e = false;
	}
}
