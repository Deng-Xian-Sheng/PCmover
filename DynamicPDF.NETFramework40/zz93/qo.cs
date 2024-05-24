using System;

namespace zz93
{
	// Token: 0x0200027A RID: 634
	internal class qo : d3
	{
		// Token: 0x06001C5A RID: 7258 RVA: 0x001242E1 File Offset: 0x001232E1
		internal qo() : base(null)
		{
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x001242F4 File Offset: 0x001232F4
		internal qo(kg A_0, d3 A_1, ij A_2) : base(A_0, A_1.k(), A_2)
		{
			this.a = A_1;
			this.b = A_2;
		}

		// Token: 0x06001C5C RID: 7260 RVA: 0x0012431C File Offset: 0x0012331C
		private new bool a(int A_0, int A_1)
		{
			if (A_0 <= 258605815)
			{
				if (A_0 <= 165445)
				{
					if (A_0 != 1946 && A_0 != 165445)
					{
						goto IL_74;
					}
				}
				else if (A_0 != 144937050 && A_0 != 258605815)
				{
					goto IL_74;
				}
			}
			else if (A_0 <= 506116087)
			{
				if (A_0 != 442866842 && A_0 != 506116087)
				{
					goto IL_74;
				}
			}
			else if (A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_74;
			}
			base.l().f(A_1);
			return true;
			IL_74:
			return false;
		}

		// Token: 0x06001C5D RID: 7261 RVA: 0x001243A4 File Offset: 0x001233A4
		private new void a(p8 A_0)
		{
			p6 a_ = new p6(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001C5E RID: 7262 RVA: 0x001243D4 File Offset: 0x001233D4
		private new void a(qm A_0)
		{
			qh a_ = new qh(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001C5F RID: 7263 RVA: 0x00124404 File Offset: 0x00123404
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
					if (base.l().v() == 1946)
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

		// Token: 0x06001C60 RID: 7264 RVA: 0x00124520 File Offset: 0x00123520
		protected internal override void cs(int A_0)
		{
			if (A_0 != 3034)
			{
				if (A_0 != 3418)
				{
					this.a.cs(A_0);
				}
				else
				{
					this.a(new p8(base.l(), this.b));
				}
			}
			else
			{
				this.a(new qm(base.l(), this.b));
			}
		}

		// Token: 0x04000CC0 RID: 3264
		private new d3 a = null;

		// Token: 0x04000CC1 RID: 3265
		private new ij b;
	}
}
