using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200050F RID: 1295
	internal class ahz : ahu
	{
		// Token: 0x060034A3 RID: 13475 RVA: 0x001D07EA File Offset: 0x001CF7EA
		internal ahz(ahq A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060034A4 RID: 13476 RVA: 0x001D0810 File Offset: 0x001CF810
		internal override object me()
		{
			object result = this.a;
			this.a = DBNull.Value;
			return result;
		}

		// Token: 0x060034A5 RID: 13477 RVA: 0x001D0838 File Offset: 0x001CF838
		internal override object mf(bool A_0)
		{
			object result = null;
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (this.d == null)
					{
						this.d = 0;
					}
					object result2 = this.d;
					this.d = base.c()[0];
					base.c().RemoveAt(0);
					return result2;
				}
				result = base.c()[0];
				base.c().RemoveAt(0);
			}
			return result;
		}

		// Token: 0x060034A6 RID: 13478 RVA: 0x001D08E8 File Offset: 0x001CF8E8
		internal override object mg(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x060034A7 RID: 13479 RVA: 0x001D0908 File Offset: 0x001CF908
		internal override void mi(LayoutWriter A_0)
		{
			object obj = this.b.ma(A_0);
			if (!(obj is DBNull))
			{
				this.a = obj;
			}
		}

		// Token: 0x060034A8 RID: 13480 RVA: 0x001D0938 File Offset: 0x001CF938
		internal override void mh(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList(10);
			}
			this.c.Add(this.b.ma(A_0));
		}

		// Token: 0x060034A9 RID: 13481 RVA: 0x001D0980 File Offset: 0x001CF980
		internal override void mj()
		{
			if (!(this.c[0] is DBNull))
			{
				this.a = this.c[0];
			}
			this.c.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x060034AA RID: 13482 RVA: 0x001D09D4 File Offset: 0x001CF9D4
		internal override void mk(Page A_0)
		{
			if (base.e() != A_0)
			{
				base.c().Add(this.a);
			}
			else
			{
				base.c().TrimToSize();
				base.c()[base.c().Count - 1] = this.a;
			}
			this.a = DBNull.Value;
			base.a(A_0);
		}

		// Token: 0x0400196A RID: 6506
		private new object a = DBNull.Value;

		// Token: 0x0400196B RID: 6507
		private new ahq b;

		// Token: 0x0400196C RID: 6508
		private ArrayList c;

		// Token: 0x0400196D RID: 6509
		private object d = null;
	}
}
