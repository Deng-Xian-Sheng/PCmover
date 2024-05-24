using System;

namespace zz93
{
	// Token: 0x0200023D RID: 573
	internal class oz : d3
	{
		// Token: 0x06001A8C RID: 6796 RVA: 0x001147CD File Offset: 0x001137CD
		internal oz(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
			this.a = A_2;
			this.b = A_1;
		}

		// Token: 0x06001A8D RID: 6797 RVA: 0x001147E9 File Offset: 0x001137E9
		private new void a(o4 A_0)
		{
			base.a(new o1(A_0, this.b, base.l(), this.a));
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x0011480C File Offset: 0x0011380C
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (!base.b(base.l().v(), a_))
					{
						if (base.l().v() == 506042859)
						{
							kg kg = base.l();
							kg.c(kg.ad() + 1);
						}
						this.cs(base.l().v());
					}
					else if (base.l().v() == 506042859 || base.l().v() == 86147604)
					{
						break;
					}
				}
				else
				{
					if (base.l().u())
					{
						int num = base.l().v();
						if (num <= 3418)
						{
							if (num != 1977)
							{
								if (num != 3418)
								{
									goto IL_169;
								}
								break;
							}
							else
							{
								this.cs(base.l().v());
							}
						}
						else
						{
							if (num == 11228793)
							{
								break;
							}
							if (num != 506042859)
							{
								goto IL_169;
							}
							if (base.l().ad() > 1)
							{
								kg kg2 = base.l();
								kg2.c(kg2.ad() - 1);
							}
							base.d(base.l().v());
							break;
						}
						continue;
						IL_169:
						base.d(base.l().v());
						continue;
						break;
					}
					if (base.l().aa())
					{
						base.l().az();
					}
				}
			}
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x001149D0 File Offset: 0x001139D0
		protected internal override void cs(int A_0)
		{
			if (A_0 == 423471123)
			{
				this.a(new o4(base.l(), this.a));
			}
		}

		// Token: 0x04000C16 RID: 3094
		private new ij a;

		// Token: 0x04000C17 RID: 3095
		private new p1 b;
	}
}
