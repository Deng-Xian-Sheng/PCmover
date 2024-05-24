using System;

namespace zz93
{
	// Token: 0x020000D8 RID: 216
	internal class e4 : d3
	{
		// Token: 0x060009B9 RID: 2489 RVA: 0x0007F1F3 File Offset: 0x0007E1F3
		internal e4(kg A_0, d3 A_1, ij A_2) : base(A_0)
		{
			this.a = A_1;
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0007F210 File Offset: 0x0007E210
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
					if (base.l().v() == 165445)
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

		// Token: 0x060009BB RID: 2491 RVA: 0x0007F337 File Offset: 0x0007E337
		protected internal override void cs(int A_0)
		{
			this.a.cs(A_0);
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0007F34C File Offset: 0x0007E34C
		private new bool a(int A_0)
		{
			if (A_0 <= 144937050)
			{
				if (A_0 <= 3034)
				{
					if (A_0 != 1946 && A_0 != 3034)
					{
						goto IL_77;
					}
				}
				else if (A_0 != 3418 && A_0 != 165445 && A_0 != 144937050)
				{
					goto IL_77;
				}
			}
			else if (A_0 <= 442866842)
			{
				if (A_0 != 258605815 && A_0 != 442866842)
				{
					goto IL_77;
				}
			}
			else if (A_0 != 506116087 && A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_77;
			}
			return true;
			IL_77:
			return false;
		}

		// Token: 0x040004E3 RID: 1251
		private new d3 a = null;
	}
}
