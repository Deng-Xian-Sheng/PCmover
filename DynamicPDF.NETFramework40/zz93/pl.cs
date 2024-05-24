using System;

namespace zz93
{
	// Token: 0x02000253 RID: 595
	internal class pl : dy
	{
		// Token: 0x06001B23 RID: 6947 RVA: 0x001197B0 File Offset: 0x001187B0
		internal bool a()
		{
			return this.b - 1 >= 0 && this.a[this.b - 1] == ' ';
		}

		// Token: 0x06001B24 RID: 6948 RVA: 0x001197E8 File Offset: 0x001187E8
		internal bool b()
		{
			return this.c - this.b + 1 <= this.a.Length && this.a[this.c - this.b + 1] == ' ';
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x00119838 File Offset: 0x00118838
		internal char[] c()
		{
			return this.a;
		}

		// Token: 0x06001B26 RID: 6950 RVA: 0x00119850 File Offset: 0x00118850
		internal void a(char[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x0011985C File Offset: 0x0011885C
		internal int d()
		{
			return this.b;
		}

		// Token: 0x06001B28 RID: 6952 RVA: 0x00119874 File Offset: 0x00118874
		internal int e()
		{
			return this.c;
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x0011988C File Offset: 0x0011888C
		internal bool f()
		{
			return this.d;
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x001198A4 File Offset: 0x001188A4
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x001198B0 File Offset: 0x001188B0
		internal bool g()
		{
			return this.e;
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x001198C8 File Offset: 0x001188C8
		internal void b(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x001198D4 File Offset: 0x001188D4
		internal override fa cr()
		{
			return fa.e;
		}

		// Token: 0x06001B2E RID: 6958 RVA: 0x001198E8 File Offset: 0x001188E8
		internal bool h()
		{
			return this.f;
		}

		// Token: 0x06001B2F RID: 6959 RVA: 0x00119900 File Offset: 0x00118900
		internal void c(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001B30 RID: 6960 RVA: 0x0011990C File Offset: 0x0011890C
		internal override kz cm(ij A_0, kz A_1)
		{
			nk nk = new nk();
			nk.a(A_0);
			nk.dc(A_1.db().du());
			nk.j(A_1);
			return nk;
		}

		// Token: 0x04000C46 RID: 3142
		private new char[] a = null;

		// Token: 0x04000C47 RID: 3143
		private int b = 0;

		// Token: 0x04000C48 RID: 3144
		private int c = 0;

		// Token: 0x04000C49 RID: 3145
		private new bool d = false;

		// Token: 0x04000C4A RID: 3146
		private new bool e = false;

		// Token: 0x04000C4B RID: 3147
		private new bool f = false;
	}
}
