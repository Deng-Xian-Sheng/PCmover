using System;

namespace zz93
{
	// Token: 0x02000271 RID: 625
	internal class qf : d3
	{
		// Token: 0x06001C1D RID: 7197 RVA: 0x001218AF File Offset: 0x001208AF
		internal qf(kg A_0, d3 A_1, ij A_2) : base(A_0)
		{
			this.a = A_1;
			this.b = A_2;
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x001218D8 File Offset: 0x001208D8
		private new bool a(int A_0, int A_1)
		{
			if (A_0 <= 258605815)
			{
				if (A_0 != 165445 && A_0 != 144937050 && A_0 != 258605815)
				{
					goto IL_72;
				}
			}
			else if (A_0 <= 506116087)
			{
				if (A_0 == 442866842)
				{
					base.l().ax();
					return true;
				}
				if (A_0 != 506116087)
				{
					goto IL_72;
				}
			}
			else if (A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_72;
			}
			base.l().f(A_1);
			return true;
			IL_72:
			return false;
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x0012195C File Offset: 0x0012095C
		private new void a(p8 A_0)
		{
			p6 a_ = new p6(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x001219C4 File Offset: 0x001209C4
		private new void a(qm A_0)
		{
			qh a_ = new qh(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00121A2C File Offset: 0x00120A2C
		private new void a(qp A_0)
		{
			qn a_ = new qn(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x00121A5C File Offset: 0x00120A5C
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
					if (base.l().v() == 442866842)
					{
						if (this.c != null)
						{
							base.a(this.c);
						}
						break;
					}
					base.d(base.l().v());
				}
				else if (base.l().aa())
				{
					this.a.r();
				}
			}
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x00121B8C File Offset: 0x00120B8C
		protected internal override void cs(int A_0)
		{
			if (A_0 != 1946)
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
			else
			{
				if (this.c != null)
				{
					base.a(this.c);
					this.c = null;
				}
				this.a(new qp(base.l(), this.b));
			}
		}

		// Token: 0x04000CAC RID: 3244
		private new d3 a = null;

		// Token: 0x04000CAD RID: 3245
		private new ij b;

		// Token: 0x04000CAE RID: 3246
		private new qn c = null;
	}
}
