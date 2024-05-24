using System;

namespace zz93
{
	// Token: 0x0200024F RID: 591
	internal class ph : d3
	{
		// Token: 0x06001B0A RID: 6922 RVA: 0x00118F6D File Offset: 0x00117F6D
		internal ph(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
			this.a = A_2;
			this.b = A_1;
		}

		// Token: 0x06001B0B RID: 6923 RVA: 0x00118F89 File Offset: 0x00117F89
		private new void a(o4 A_0)
		{
			base.a(new o1(A_0, this.b, base.l(), this.a));
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x00118FAB File Offset: 0x00117FAB
		private new void a(o0 A_0)
		{
			base.a(new oy(A_0, this.b, base.l(), this.a));
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x00118FD0 File Offset: 0x00117FD0
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
						this.cs(base.l().v());
					}
					else if (base.l().v() == 86147604)
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
									goto IL_F1;
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
							if (num != 86147604)
							{
								goto IL_F1;
							}
							base.l().ax();
							break;
						}
						continue;
						IL_F1:
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

		// Token: 0x06001B0E RID: 6926 RVA: 0x0011911C File Offset: 0x0011811C
		protected internal override void cs(int A_0)
		{
			if (A_0 != 423471123)
			{
				if (A_0 != 506042859)
				{
					base.cs(A_0);
				}
				else
				{
					this.a(new o0(base.l(), this.a));
				}
			}
			else
			{
				this.a(new o4(base.l(), this.a));
			}
		}

		// Token: 0x04000C3D RID: 3133
		private new ij a;

		// Token: 0x04000C3E RID: 3134
		private new p1 b;
	}
}
