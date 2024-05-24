using System;

namespace zz93
{
	// Token: 0x02000276 RID: 630
	internal class qk : d3
	{
		// Token: 0x06001C3B RID: 7227 RVA: 0x00122FEB File Offset: 0x00121FEB
		internal qk(kg A_0, d3 A_1, ij A_2) : base(A_0, A_1.k(), A_2)
		{
			this.a = A_1;
			this.b = A_2;
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x00123024 File Offset: 0x00122024
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
				if (A_0 != 442866842 && A_0 != 506116087)
				{
					goto IL_72;
				}
			}
			else if (A_0 != 718642778)
			{
				if (A_0 != 889490394)
				{
					goto IL_72;
				}
				base.l().ax();
				return true;
			}
			base.l().f(A_1);
			return true;
			IL_72:
			return false;
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x001230A8 File Offset: 0x001220A8
		private new void a(p8 A_0)
		{
			p6 a_ = new p6(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x00123110 File Offset: 0x00122110
		private new void a(qm A_0)
		{
			qh a_ = new qh(A_0, base.l(), this.a, this.b);
			if (this.c == null)
			{
				this.c = new qn(new qp(base.l(), this.b));
			}
			this.c.cg().a(a_);
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x00123178 File Offset: 0x00122178
		private new void a(qp A_0)
		{
			qn a_ = new qn(A_0, base.l(), this.a, this.b);
			base.a(a_);
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x001231A8 File Offset: 0x001221A8
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
					if (base.l().v() == 889490394)
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

		// Token: 0x06001C41 RID: 7233 RVA: 0x001232D8 File Offset: 0x001222D8
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

		// Token: 0x04000CB4 RID: 3252
		private new d3 a = null;

		// Token: 0x04000CB5 RID: 3253
		private new ij b = null;

		// Token: 0x04000CB6 RID: 3254
		private new qn c = null;
	}
}
