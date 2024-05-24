using System;

namespace zz93
{
	// Token: 0x020000DA RID: 218
	internal class e6 : d3
	{
		// Token: 0x060009C9 RID: 2505 RVA: 0x0007F8F5 File Offset: 0x0007E8F5
		internal e6(kg A_0, d3 A_1, ij A_2) : base(A_0)
		{
			this.a = A_1;
			this.b = A_2;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0007F920 File Offset: 0x0007E920
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (this.a(base.l().v()))
					{
						base.l().f(a_);
						break;
					}
					this.cs(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == 144937050)
					{
						base.l().f(a_);
						break;
					}
					if (base.l().v() == 506116087)
					{
						break;
					}
					this.a.d(base.l().v());
				}
				else if (base.l().aa())
				{
					this.a.r();
				}
			}
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0007FA48 File Offset: 0x0007EA48
		protected internal override void cs(int A_0)
		{
			if (A_0 != 165445)
			{
				this.a.cs(A_0);
			}
			else
			{
				this.a(new e9(base.l(), this.b));
			}
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x0007FA8C File Offset: 0x0007EA8C
		private new bool a(int A_0)
		{
			if (A_0 <= 144937050)
			{
				if (A_0 <= 3034)
				{
					if (A_0 != 1946 && A_0 != 3034)
					{
						goto IL_6F;
					}
				}
				else if (A_0 != 3418 && A_0 != 144937050)
				{
					goto IL_6F;
				}
			}
			else if (A_0 <= 442866842)
			{
				if (A_0 != 258605815 && A_0 != 442866842)
				{
					goto IL_6F;
				}
			}
			else if (A_0 != 506116087 && A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_6F;
			}
			return true;
			IL_6F:
			return false;
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0007FB10 File Offset: 0x0007EB10
		private new void a(e9 A_0)
		{
			e3 a_ = new e3(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x040004EA RID: 1258
		private new d3 a = null;

		// Token: 0x040004EB RID: 1259
		private new ij b = null;
	}
}
