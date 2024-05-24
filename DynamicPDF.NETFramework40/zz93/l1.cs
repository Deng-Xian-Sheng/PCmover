using System;

namespace zz93
{
	// Token: 0x020001D1 RID: 465
	internal class l1 : k6
	{
		// Token: 0x060013BD RID: 5053 RVA: 0x000DE720 File Offset: 0x000DD720
		internal l1()
		{
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x000DE73C File Offset: 0x000DD73C
		private void d()
		{
			x5 x = x5.a(base.j().Value, base.g());
			for (int i = 0; i < base.g(); i++)
			{
				this.b[i] = x;
			}
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x000DE790 File Offset: 0x000DD790
		private void c()
		{
			x5 x = x5.c();
			for (int i = 0; i < this.a; i++)
			{
				this.b[i] = base.h()[i];
				x = x5.f(x, base.h()[i]);
			}
			x5 a_ = x5.e(base.j().Value, x);
			for (int i = 0; i < this.b.Length; i++)
			{
				float num = x5.b(this.b[i]) * (100f / x5.b(x));
				x5[] array = this.b;
				int num2 = i;
				array[num2] = x5.f(array[num2], x5.a(x5.b(a_) * (num / 100f)));
			}
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x000DE880 File Offset: 0x000DD880
		private void b()
		{
			x5 x = x5.c();
			for (int i = 0; i < base.h().Length; i++)
			{
				this.b[i] = base.h()[i];
				x = x5.f(x, base.h()[i]);
			}
			x5 a_ = x5.e(base.j().Value, x);
			x5 x2 = x5.a(a_, base.g() - this.a);
			if (x5.c(x2, x5.c()))
			{
				for (int i = 0; i < this.b.Length; i++)
				{
					if (x5.h(this.b[i], x5.c()))
					{
						this.b[i] = x2;
					}
				}
			}
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x000DE97C File Offset: 0x000DD97C
		private bool a()
		{
			for (int i = 0; i < base.h().Length; i++)
			{
				if (x5.g(base.h()[i], x5.c()))
				{
					this.a++;
				}
			}
			return this.a > 0;
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x000DE9EC File Offset: 0x000DD9EC
		internal override x5[] dn()
		{
			this.b = new x5[base.g()];
			if (this.a == 0)
			{
				this.d();
			}
			else if (this.a == base.g())
			{
				this.c();
			}
			else
			{
				this.b();
			}
			return this.b;
		}

		// Token: 0x0400094E RID: 2382
		private int a = 0;

		// Token: 0x0400094F RID: 2383
		private x5[] b = null;
	}
}
