using System;

namespace zz93
{
	// Token: 0x02000274 RID: 628
	internal class qi : d3
	{
		// Token: 0x06001C30 RID: 7216 RVA: 0x0012285B File Offset: 0x0012185B
		internal qi(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x0012286C File Offset: 0x0012186C
		private new bool a(int A_0, int A_1)
		{
			if (A_0 <= 165445)
			{
				if (A_0 <= 3034)
				{
					if (A_0 != 1946 && A_0 != 3034)
					{
						goto IL_7C;
					}
				}
				else if (A_0 != 3418 && A_0 != 165445)
				{
					goto IL_7C;
				}
			}
			else if (A_0 <= 442866842)
			{
				if (A_0 != 258605815 && A_0 != 442866842)
				{
					goto IL_7C;
				}
			}
			else if (A_0 != 506116087 && A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_7C;
			}
			base.l().f(A_1);
			return true;
			IL_7C:
			return false;
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x001228FC File Offset: 0x001218FC
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int num = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (this.a(base.l().v(), num))
					{
						break;
					}
					this.cs(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == 144937050)
					{
						base.l().f(num);
						break;
					}
					if (base.l().v() == 3034)
					{
						break;
					}
					base.d(base.l().v());
				}
				else if (base.l().aa())
				{
					base.r();
				}
			}
		}
	}
}
