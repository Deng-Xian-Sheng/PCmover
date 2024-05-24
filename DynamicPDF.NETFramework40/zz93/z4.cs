using System;
using System.IO;
using System.Reflection;

namespace zz93
{
	// Token: 0x020003E5 RID: 997
	[DefaultMember("Item")]
	internal class z4
	{
		// Token: 0x060029C4 RID: 10692 RVA: 0x00185F48 File Offset: 0x00184F48
		internal z4(b3 A_0, zz[] A_1)
		{
			this.k = A_0;
			this.a = A_1;
			this.a();
			if (A_0.j() != null)
			{
				this.a(A_0);
			}
			this.j = new zw(this);
			this.c();
			this.g.a(A_1[this.e].c());
			this.b();
		}

		// Token: 0x060029C5 RID: 10693 RVA: 0x00185FCC File Offset: 0x00184FCC
		private void c()
		{
			int num = this.h.a() + this.h.b();
			this.j.a(num);
			num += this.j.b();
			for (int i = this.b; i < this.c; i++)
			{
				this.a[i].a(num);
				num += this.a[i].d();
			}
			this.g.b(num);
			for (int i = this.c; i < this.a.Length; i++)
			{
				this.a[i].a(num);
				num += this.a[i].d();
			}
			this.m = num;
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(num);
				num += this.a[i].d();
			}
		}

		// Token: 0x060029C6 RID: 10694 RVA: 0x001860D0 File Offset: 0x001850D0
		private void b()
		{
			int num = this.g.a() + this.g.b();
			for (int i = this.c; i < this.a.Length; i++)
			{
				this.a[i].a(num);
				num += this.a[i].d();
			}
			this.m = num;
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(num);
				num += this.a[i].d();
			}
			this.i = new z5(this);
			this.i.a(num);
			this.l = num + this.i.b();
		}

		// Token: 0x060029C7 RID: 10695 RVA: 0x0018619C File Offset: 0x0018519C
		private void a(b3 A_0)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				this.a[i].a(A_0);
			}
		}

		// Token: 0x060029C8 RID: 10696 RVA: 0x001861D0 File Offset: 0x001851D0
		private void a()
		{
			int num = 1;
			int i = 0;
			while (this.a[i].j() < 2147483544)
			{
				this.a[i++].a(this.k, num++);
			}
			this.e = i;
			while (this.a[i].j() < 2147483645)
			{
				this.a[i++].a(this.k, num++);
			}
			this.f = i - this.e;
			while (this.a[i].j() < 2147483646)
			{
				this.a[i++].a(this.k, num++);
			}
			this.b = i;
			int a_ = num++;
			while (this.a[i].j() < 2147483647)
			{
				this.a[i++].a(this.k, num++);
			}
			this.c = i;
			this.d = this.a.Length - i;
			while (i < this.a.Length)
			{
				this.a[i++].a(this.k, num++);
			}
			this.h = new z3(this, a_);
			this.g = new zx(this, num++);
		}

		// Token: 0x060029C9 RID: 10697 RVA: 0x00186344 File Offset: 0x00185344
		internal z3 d()
		{
			return this.h;
		}

		// Token: 0x060029CA RID: 10698 RVA: 0x0018635C File Offset: 0x0018535C
		internal zx e()
		{
			return this.g;
		}

		// Token: 0x060029CB RID: 10699 RVA: 0x00186374 File Offset: 0x00185374
		internal z5 f()
		{
			return this.i;
		}

		// Token: 0x060029CC RID: 10700 RVA: 0x0018638C File Offset: 0x0018538C
		internal zw g()
		{
			return this.j;
		}

		// Token: 0x060029CD RID: 10701 RVA: 0x001863A4 File Offset: 0x001853A4
		internal b3 h()
		{
			return this.k;
		}

		// Token: 0x060029CE RID: 10702 RVA: 0x001863BC File Offset: 0x001853BC
		internal int i()
		{
			return this.c;
		}

		// Token: 0x060029CF RID: 10703 RVA: 0x001863D4 File Offset: 0x001853D4
		internal int j()
		{
			return this.d;
		}

		// Token: 0x060029D0 RID: 10704 RVA: 0x001863EC File Offset: 0x001853EC
		internal int k()
		{
			return this.e;
		}

		// Token: 0x060029D1 RID: 10705 RVA: 0x00186404 File Offset: 0x00185404
		internal int l()
		{
			return this.f;
		}

		// Token: 0x060029D2 RID: 10706 RVA: 0x0018641C File Offset: 0x0018541C
		internal int m()
		{
			return this.b;
		}

		// Token: 0x060029D3 RID: 10707 RVA: 0x00186434 File Offset: 0x00185434
		internal int n()
		{
			return this.a.Length;
		}

		// Token: 0x060029D4 RID: 10708 RVA: 0x00186450 File Offset: 0x00185450
		internal int o()
		{
			return this.l;
		}

		// Token: 0x060029D5 RID: 10709 RVA: 0x00186468 File Offset: 0x00185468
		internal int p()
		{
			return this.m;
		}

		// Token: 0x060029D6 RID: 10710 RVA: 0x00186480 File Offset: 0x00185480
		internal zz a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060029D7 RID: 10711 RVA: 0x0018649C File Offset: 0x0018549C
		internal void a(Stream A_0)
		{
			this.h.a(A_0);
			this.j.a(A_0);
			for (int i = this.b; i < this.c; i++)
			{
				this.a[i].a(A_0);
			}
			this.g.a(A_0);
			for (int i = this.c; i < this.a.Length; i++)
			{
				this.a[i].a(A_0);
			}
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0);
			}
			this.i.a(A_0);
		}

		// Token: 0x04001312 RID: 4882
		private zz[] a;

		// Token: 0x04001313 RID: 4883
		private int b;

		// Token: 0x04001314 RID: 4884
		private int c;

		// Token: 0x04001315 RID: 4885
		private int d;

		// Token: 0x04001316 RID: 4886
		private int e;

		// Token: 0x04001317 RID: 4887
		private int f;

		// Token: 0x04001318 RID: 4888
		private zx g;

		// Token: 0x04001319 RID: 4889
		private z3 h;

		// Token: 0x0400131A RID: 4890
		private z5 i;

		// Token: 0x0400131B RID: 4891
		private zw j;

		// Token: 0x0400131C RID: 4892
		private b3 k;

		// Token: 0x0400131D RID: 4893
		private int l = 0;

		// Token: 0x0400131E RID: 4894
		private int m = 0;
	}
}
