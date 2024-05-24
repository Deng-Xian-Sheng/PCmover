using System;

namespace zz93
{
	// Token: 0x02000195 RID: 405
	internal class kd : d3
	{
		// Token: 0x06000DFC RID: 3580 RVA: 0x0009CFB0 File Offset: 0x0009BFB0
		internal kd(j4 A_0, kg A_1, p1 A_2, ij A_3) : base(A_1, A_2, A_3)
		{
			this.a = A_0;
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x0009CFD0 File Offset: 0x0009BFD0
		private new bool a(int A_0, int A_1)
		{
			if (A_0 <= 879)
			{
				if (A_0 != 431 && A_0 != 687 && A_0 != 879)
				{
					goto IL_50;
				}
			}
			else if (A_0 != 3119 && A_0 != 3375 && A_0 != 3567)
			{
				goto IL_50;
			}
			base.l().f(A_1);
			return true;
			IL_50:
			return false;
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x0009D034 File Offset: 0x0009C034
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (this.a(base.l().v(), a_))
					{
						break;
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == this.a.cn())
					{
						base.d(base.l().v());
						break;
					}
					if (base.l().v() == 1977)
					{
						this.cs(base.l().v());
					}
					else
					{
						if (base.l().v() == 11228793 || base.l().v() == 3418)
						{
							break;
						}
						if (base.k().e(base.l().v()))
						{
							base.d(base.l().v());
						}
						else
						{
							base.l().ax();
						}
					}
				}
				else if (base.l().aa())
				{
					base.r();
				}
			}
		}

		// Token: 0x040006FB RID: 1787
		private new j4 a = null;
	}
}
