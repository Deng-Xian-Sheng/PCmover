using System;

namespace zz93
{
	// Token: 0x020005B9 RID: 1465
	internal abstract class amk : amj
	{
		// Token: 0x06003A13 RID: 14867 RVA: 0x001F347E File Offset: 0x001F247E
		internal amk(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003A14 RID: 14868 RVA: 0x001F3490 File Offset: 0x001F2490
		internal x5 d()
		{
			return this.a;
		}

		// Token: 0x06003A15 RID: 14869 RVA: 0x001F34A8 File Offset: 0x001F24A8
		internal void a(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003A16 RID: 14870 RVA: 0x001F34B4 File Offset: 0x001F24B4
		internal amk e()
		{
			return this.b;
		}

		// Token: 0x06003A17 RID: 14871 RVA: 0x001F34CC File Offset: 0x001F24CC
		internal void a(amk A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003A18 RID: 14872
		internal abstract int nn();

		// Token: 0x06003A19 RID: 14873
		internal abstract void no(int A_0);

		// Token: 0x06003A1A RID: 14874 RVA: 0x001F34D8 File Offset: 0x001F24D8
		internal virtual bool ns()
		{
			return false;
		}

		// Token: 0x06003A1B RID: 14875 RVA: 0x001F34EC File Offset: 0x001F24EC
		internal aml f()
		{
			am6 am = base.h();
			aml aml = new aml(this.d());
			while (am != null)
			{
				aml.b(am.c());
				am = am.b();
			}
			aml.no(this.nn());
			return aml;
		}

		// Token: 0x06003A1C RID: 14876 RVA: 0x001F3544 File Offset: 0x001F2544
		internal x5 g()
		{
			am6 am = base.h();
			x5 x = x5.a();
			while (am != null)
			{
				if (!am.a().fe() && x5.c(am.a().b8(), this.a) && !am.a().gf() && x5.d(x, am.a().b8()))
				{
					if (am.a().cb() == 239 && !am.a().gg())
					{
						x = am.a().b8();
					}
				}
				am = am.b();
			}
			x5 result;
			if (x5.d(this.a, x))
			{
				result = x;
			}
			else
			{
				result = this.a;
			}
			return result;
		}

		// Token: 0x04001B88 RID: 7048
		private new x5 a;

		// Token: 0x04001B89 RID: 7049
		private new amk b;
	}
}
