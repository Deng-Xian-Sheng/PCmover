using System;

namespace zz93
{
	// Token: 0x0200025F RID: 607
	internal class px : d3
	{
		// Token: 0x06001B8E RID: 7054 RVA: 0x0011CDA3 File Offset: 0x0011BDA3
		internal px(kg A_0, p1 A_1, ij A_2) : base(A_0)
		{
			this.b = A_2;
			this.a = new d3(A_0, A_1, A_2);
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x0011CDDC File Offset: 0x0011BDDC
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 144937050)
					{
						base.l().f(a_);
						break;
					}
					this.cs(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == 144937050)
					{
						base.l().ax();
						if (this.c != null)
						{
							base.a(this.c);
						}
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

		// Token: 0x06001B90 RID: 7056 RVA: 0x0011CF04 File Offset: 0x0011BF04
		protected internal override void cs(int A_0)
		{
			if (A_0 <= 165445)
			{
				if (A_0 <= 3034)
				{
					if (A_0 == 1946)
					{
						if (this.c != null)
						{
							base.a(this.c);
							this.c = null;
						}
						this.a(new qp(base.l(), this.b));
						return;
					}
					if (A_0 == 3034)
					{
						this.a(new qm(base.l(), this.b));
						return;
					}
				}
				else
				{
					if (A_0 == 3418)
					{
						this.a(new p8(base.l(), this.b));
						return;
					}
					if (A_0 == 165445)
					{
						this.a(new e9(base.l(), this.b));
						return;
					}
				}
			}
			else if (A_0 <= 442866842)
			{
				if (A_0 == 258605815)
				{
					this.a(new eu(base.l(), this.b));
					return;
				}
				if (A_0 == 442866842)
				{
					this.a(new qg(base.l(), this.b));
					return;
				}
			}
			else
			{
				if (A_0 == 506116087)
				{
					this.a(new e7(base.l(), this.b));
					return;
				}
				if (A_0 == 718642778)
				{
					this.a(new p5(base.l(), this.b));
					return;
				}
				if (A_0 == 889490394)
				{
					this.a(new ql(base.l(), this.b));
					return;
				}
			}
			base.l().ax();
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x0011D0C8 File Offset: 0x0011C0C8
		private new void a(p8 A_0)
		{
			p6 a_ = new p6(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001B92 RID: 7058 RVA: 0x0011D130 File Offset: 0x0011C130
		private new void a(qm A_0)
		{
			qh a_ = new qh(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001B93 RID: 7059 RVA: 0x0011D198 File Offset: 0x0011C198
		private new void a(qp A_0)
		{
			qn a_ = new qn(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001B94 RID: 7060 RVA: 0x0011D1C8 File Offset: 0x0011C1C8
		private new void a(eu A_0)
		{
			es a_ = new es(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001B95 RID: 7061 RVA: 0x0011D1F8 File Offset: 0x0011C1F8
		private new void a(p5 A_0)
		{
			p3 a_ = new p3(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x0011D228 File Offset: 0x0011C228
		private new void a(qg A_0)
		{
			qe a_ = new qe(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x0011D258 File Offset: 0x0011C258
		private new void a(ql A_0)
		{
			qj a_ = new qj(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x0011D288 File Offset: 0x0011C288
		private new void a(e7 A_0)
		{
			e5 a_ = new e5(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x0011D2B8 File Offset: 0x0011C2B8
		private new void a(e9 A_0)
		{
			e3 a_ = new e3(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x04000C69 RID: 3177
		private new d3 a = null;

		// Token: 0x04000C6A RID: 3178
		private new ij b = null;

		// Token: 0x04000C6B RID: 3179
		private new qn c = null;
	}
}
