using System;

namespace zz93
{
	// Token: 0x0200019D RID: 413
	internal class kl : d3
	{
		// Token: 0x06000E7F RID: 3711 RVA: 0x000AD36B File Offset: 0x000AC36B
		internal kl(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x000AD37D File Offset: 0x000AC37D
		internal kl(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
			this.a = A_0.v();
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x000AD398 File Offset: 0x000AC398
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == this.a)
					{
						base.d(this.a);
						break;
					}
					if (base.l().v() == 1977)
					{
						this.cs(base.l().v());
					}
					else
					{
						if (base.l().v() == 11228793 && base.l().v() == 3418)
						{
							break;
						}
						base.d(base.l().v());
					}
				}
				else if (base.l().aa())
				{
					if (!base.k().e(this.a))
					{
						break;
					}
					base.r();
					base.l().e(false);
				}
			}
		}

		// Token: 0x04000722 RID: 1826
		private new int a;
	}
}
