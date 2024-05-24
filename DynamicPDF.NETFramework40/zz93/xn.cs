using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000386 RID: 902
	internal class xn : Rectangle
	{
		// Token: 0x0600267C RID: 9852 RVA: 0x00164164 File Offset: 0x00163164
		internal xn(float A_0, float A_1, float A_2, float A_3, Color A_4, Color A_5, float A_6, LineStyle A_7) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7)
		{
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x00164192 File Offset: 0x00163192
		private xn(Rectangle A_0, x5 A_1, x5 A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x0600267E RID: 9854 RVA: 0x001641AB File Offset: 0x001631AB
		internal override void b5(dv A_0)
		{
			base.a(A_0);
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x001641B6 File Offset: 0x001631B6
		protected override void DrawRotated(PageWriter writer)
		{
			base.DrawRotated(writer);
		}

		// Token: 0x06002680 RID: 9856 RVA: 0x001641C1 File Offset: 0x001631C1
		internal override void b6(acw A_0)
		{
		}

		// Token: 0x06002681 RID: 9857 RVA: 0x001641C4 File Offset: 0x001631C4
		internal override void ge(xg A_0)
		{
			xx xx = A_0.h();
			wy e = this.a.a;
			while (xx != null)
			{
				if (e != null && xx.a().fd() == e.a)
				{
					e.b = xx;
					if (x5.c(this.b8(), xx.a().b8()))
					{
						e.c = x5.e(this.b8(), xx.a().b8());
					}
					e = e.e;
				}
				xx = xx.b();
			}
		}

		// Token: 0x06002682 RID: 9858 RVA: 0x00164268 File Offset: 0x00163268
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (this.a == null || this.a.a == null)
			{
				result = w0.d;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x06002683 RID: 9859 RVA: 0x001642A8 File Offset: 0x001632A8
		internal override PageElement fb(x5 A_0)
		{
			this.Height = x5.b(A_0);
			xn xn = new xn(this, x5.c(), new x5(0.0001f));
			xn.a(this.a());
			xn.b = this.b;
			return xn;
		}

		// Token: 0x06002684 RID: 9860 RVA: 0x001642F8 File Offset: 0x001632F8
		internal bool a(w3 A_0)
		{
			wy e = this.a.a;
			bool flag = false;
			while (e != null)
			{
				for (ww c = A_0.a; c != null; c = c.c)
				{
					if (c.b.a().fd() == e.a)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
				e = e.e;
			}
			return flag;
		}

		// Token: 0x06002685 RID: 9861 RVA: 0x00164384 File Offset: 0x00163384
		internal bool a(xg A_0)
		{
			wy e = this.a.a;
			bool result = false;
			this.Height = 0f;
			while (e != null)
			{
				for (xx xx = A_0.h(); xx != null; xx = xx.b())
				{
					if (xx.a().fd() == e.a)
					{
						result = true;
						if (this.Height < x5.b(x5.f(xx.a().b8(), e.c)) + 0.001f)
						{
							this.Height = x5.b(x5.f(xx.a().b8(), e.c)) + 0.001f;
						}
					}
				}
				e = e.e;
			}
			return result;
		}

		// Token: 0x06002686 RID: 9862 RVA: 0x00164470 File Offset: 0x00163470
		internal void a(short A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002687 RID: 9863 RVA: 0x0016447C File Offset: 0x0016347C
		internal override PageElement fc()
		{
			return new xn(this, base.l(), base.m())
			{
				b = this.b,
				a = this.a
			};
		}

		// Token: 0x06002688 RID: 9864 RVA: 0x001644BC File Offset: 0x001634BC
		internal wv a()
		{
			return this.a;
		}

		// Token: 0x06002689 RID: 9865 RVA: 0x001644D4 File Offset: 0x001634D4
		internal void a(wv A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600268A RID: 9866 RVA: 0x001644E0 File Offset: 0x001634E0
		internal override bool gf()
		{
			return this.a != null && this.a.a != null;
		}

		// Token: 0x0600268B RID: 9867 RVA: 0x00164518 File Offset: 0x00163518
		internal override short fd()
		{
			return this.b;
		}

		// Token: 0x040010C1 RID: 4289
		private new wv a;

		// Token: 0x040010C2 RID: 4290
		private short b = short.MinValue;
	}
}
