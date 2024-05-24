using System;

namespace zz93
{
	// Token: 0x02000169 RID: 361
	internal class i5 : fd
	{
		// Token: 0x06000D30 RID: 3376 RVA: 0x00097C1A File Offset: 0x00096C1A
		internal i5()
		{
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00097C25 File Offset: 0x00096C25
		internal i5(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00097C38 File Offset: 0x00096C38
		internal i6 a()
		{
			return this.a;
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00097C50 File Offset: 0x00096C50
		internal void a(i6 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00097C5C File Offset: 0x00096C5C
		internal override int cv()
		{
			return 202920309;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00097C74 File Offset: 0x00096C74
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00097C8C File Offset: 0x00096C8C
		internal override void cw(gi A_0)
		{
			if (A_0.ax())
			{
				string a_ = A_0.au().Trim();
				i4 a_2 = A_0.a(a_);
				if (a_2.b() == i2.b)
				{
					this.a = new i6(gs.k, x5.a(a_2.a()));
					this.a.a(true);
				}
				else
				{
					this.a = new i6(gs.j, m4.a(new h2(a_2)));
				}
			}
			else
			{
				int num = A_0.aj();
				int num2 = num;
				if (num2 <= 426354259)
				{
					if (num2 <= 235744)
					{
						if (num2 == 136794)
						{
							this.a = new i6(gs.e, x5.a(0f));
							goto IL_22A;
						}
						if (num2 == 235744)
						{
							this.a = new i6(gs.c, x5.a(0f));
							goto IL_22A;
						}
					}
					else
					{
						if (num2 == 247074557)
						{
							this.a = new i6(gs.i, x5.a(0f));
							goto IL_22A;
						}
						if (num2 == 426354259)
						{
							this.a = new i6(gs.h, x5.a(0f));
							goto IL_22A;
						}
					}
				}
				else if (num2 <= 505607249)
				{
					if (num2 == 505551072)
					{
						this.a = new i6(gs.d, x5.a(0f));
						goto IL_22A;
					}
					if (num2 == 505607249)
					{
						this.a = new i6(gs.b, x5.a(0f));
						this.a.d(true);
						goto IL_22A;
					}
				}
				else
				{
					if (num2 == 673387239)
					{
						this.a = new i6(gs.b, x5.a(0f));
						goto IL_22A;
					}
					if (num2 == 685200325)
					{
						this.a = new i6(gs.g, x5.a(0f));
						goto IL_22A;
					}
					if (num2 == 1013804718)
					{
						this.a = new i6(gs.f, x5.a(0f));
						goto IL_22A;
					}
				}
				this.a = new i6(gs.b, x5.a(0f));
				IL_22A:;
			}
		}

		// Token: 0x040006C2 RID: 1730
		private new i6 a;
	}
}
