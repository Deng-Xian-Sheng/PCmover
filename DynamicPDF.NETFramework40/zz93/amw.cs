using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005C5 RID: 1477
	internal class amw : Rectangle
	{
		// Token: 0x06003A75 RID: 14965 RVA: 0x001F5748 File Offset: 0x001F4748
		internal amw(float A_0, float A_1, float A_2, float A_3, Color A_4, Color A_5, float A_6, LineStyle A_7) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7)
		{
		}

		// Token: 0x06003A76 RID: 14966 RVA: 0x001F5776 File Offset: 0x001F4776
		private amw(Rectangle A_0, x5 A_1, x5 A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06003A77 RID: 14967 RVA: 0x001F578F File Offset: 0x001F478F
		internal override void b5(dv A_0)
		{
			base.a(A_0);
		}

		// Token: 0x06003A78 RID: 14968 RVA: 0x001F579A File Offset: 0x001F479A
		protected override void DrawRotated(PageWriter writer)
		{
			base.DrawRotated(writer);
		}

		// Token: 0x06003A79 RID: 14969 RVA: 0x001F57A5 File Offset: 0x001F47A5
		internal override void b6(acw A_0)
		{
		}

		// Token: 0x06003A7A RID: 14970 RVA: 0x001F57A8 File Offset: 0x001F47A8
		internal override void nq(amk A_0)
		{
			am6 am = A_0.h();
			alw e = this.a.a;
			while (am != null)
			{
				if (e != null && am.a().fd() == e.a)
				{
					e.b = am;
					if (x5.c(this.b8(), am.a().b8()))
					{
						e.c = x5.e(this.b8(), am.a().b8());
					}
					e = e.e;
				}
				am = am.b();
			}
		}

		// Token: 0x06003A7B RID: 14971 RVA: 0x001F584C File Offset: 0x001F484C
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (this.a == null || this.a.a == null)
			{
				result = al1.d;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x06003A7C RID: 14972 RVA: 0x001F588C File Offset: 0x001F488C
		internal override PageElement fb(x5 A_0)
		{
			this.Height = x5.b(A_0);
			amw amw = new amw(this, x5.c(), new x5(0.0001f));
			amw.a(this.a());
			amw.b = this.b;
			return amw;
		}

		// Token: 0x06003A7D RID: 14973 RVA: 0x001F58DC File Offset: 0x001F48DC
		internal bool a(alx A_0)
		{
			alw e = this.a.a;
			bool flag = false;
			while (e != null)
			{
				for (alu c = A_0.a; c != null; c = c.c)
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

		// Token: 0x06003A7E RID: 14974 RVA: 0x001F5968 File Offset: 0x001F4968
		internal bool a(amk A_0)
		{
			alw e = this.a.a;
			bool result = false;
			this.Height = 0f;
			while (e != null)
			{
				for (am6 am = A_0.h(); am != null; am = am.b())
				{
					if (am.a().fd() == e.a)
					{
						result = true;
						if (this.Height < x5.b(x5.f(am.a().b8(), e.c)) + 0.001f)
						{
							this.Height = x5.b(x5.f(am.a().b8(), e.c)) + 0.001f;
						}
					}
				}
				e = e.e;
			}
			return result;
		}

		// Token: 0x06003A7F RID: 14975 RVA: 0x001F5A54 File Offset: 0x001F4A54
		internal void a(short A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003A80 RID: 14976 RVA: 0x001F5A60 File Offset: 0x001F4A60
		internal override PageElement fc()
		{
			return new amw(this, base.l(), base.m())
			{
				b = this.b,
				a = this.a
			};
		}

		// Token: 0x06003A81 RID: 14977 RVA: 0x001F5AA0 File Offset: 0x001F4AA0
		internal alt a()
		{
			return this.a;
		}

		// Token: 0x06003A82 RID: 14978 RVA: 0x001F5AB8 File Offset: 0x001F4AB8
		internal void a(alt A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003A83 RID: 14979 RVA: 0x001F5AC4 File Offset: 0x001F4AC4
		internal override bool gf()
		{
			return this.a != null && this.a.a != null;
		}

		// Token: 0x06003A84 RID: 14980 RVA: 0x001F5AFC File Offset: 0x001F4AFC
		internal override short fd()
		{
			return this.b;
		}

		// Token: 0x04001BA4 RID: 7076
		private new alt a;

		// Token: 0x04001BA5 RID: 7077
		private short b = short.MinValue;
	}
}
