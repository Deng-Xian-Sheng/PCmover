using System;

namespace zz93
{
	// Token: 0x02000269 RID: 617
	internal class p7 : d3
	{
		// Token: 0x06001BD8 RID: 7128 RVA: 0x0011F4C8 File Offset: 0x0011E4C8
		internal p7(kg A_0) : base(A_0)
		{
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x0011F4D4 File Offset: 0x0011E4D4
		internal p7(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x0011F4E4 File Offset: 0x0011E4E4
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

		// Token: 0x06001BDB RID: 7131 RVA: 0x0011F574 File Offset: 0x0011E574
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
					int num2 = base.l().v();
					if (num2 <= 352709791)
					{
						if (num2 != 144877216 && num2 != 352709791)
						{
							goto IL_A4;
						}
						goto IL_8B;
					}
					else
					{
						if (num2 != 504715003 && num2 != 557703508)
						{
							goto IL_A4;
						}
						goto IL_8B;
					}
					continue;
					IL_8B:
					base.l().g(base.l().v());
					continue;
					IL_A4:
					this.cs(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == 144937050)
					{
						base.l().f(num);
						break;
					}
					if (base.l().v() == 1977)
					{
						this.cs(base.l().v());
					}
					else
					{
						if (base.l().v() == 3418)
						{
							break;
						}
						base.d(base.l().v());
					}
				}
				else if (base.l().aa())
				{
					base.r();
				}
			}
		}
	}
}
