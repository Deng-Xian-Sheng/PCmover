using System;

namespace zz93
{
	// Token: 0x02000266 RID: 614
	internal class p4 : d3
	{
		// Token: 0x06001BC5 RID: 7109 RVA: 0x0011E500 File Offset: 0x0011D500
		internal p4(kg A_0, d3 A_1, ij A_2) : base(A_0, A_1.k(), A_2)
		{
			this.a = A_1;
			this.b = A_2;
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x0011E530 File Offset: 0x0011D530
		private new bool a(int A_0, int A_1, ref bool A_2)
		{
			if (A_0 <= 258605815)
			{
				if (A_0 <= 141185593)
				{
					if (A_0 != 165445)
					{
						if (A_0 != 141185593)
						{
							goto IL_87;
						}
						base.l().ay();
						A_2 = true;
						return false;
					}
				}
				else if (A_0 != 144937050 && A_0 != 258605815)
				{
					goto IL_87;
				}
			}
			else if (A_0 <= 506116087)
			{
				if (A_0 != 442866842 && A_0 != 506116087)
				{
					goto IL_87;
				}
			}
			else if (A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_87;
			}
			base.l().f(A_1);
			return true;
			IL_87:
			return false;
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x0011E5CC File Offset: 0x0011D5CC
		private new void a(p8 A_0)
		{
			p6 a_ = new p6(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x0011E634 File Offset: 0x0011D634
		private new void a(qm A_0)
		{
			qh a_ = new qh(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x0011E69C File Offset: 0x0011D69C
		private new void a(qp A_0)
		{
			qn a_ = new qn(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x0011E6CC File Offset: 0x0011D6CC
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int num = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					bool flag = false;
					if (this.a(base.l().v(), num, ref flag))
					{
						break;
					}
					if (!flag)
					{
						this.cs(base.l().v());
					}
				}
				else if (base.l().u())
				{
					if (base.l().v() == 144937050)
					{
						base.l().f(num);
						break;
					}
					if (base.l().v() == 718642778)
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

		// Token: 0x06001BCB RID: 7115 RVA: 0x0011E808 File Offset: 0x0011D808
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

		// Token: 0x04000C8C RID: 3212
		private new d3 a = null;

		// Token: 0x04000C8D RID: 3213
		private new ij b;

		// Token: 0x04000C8E RID: 3214
		private new qn c = null;
	}
}
