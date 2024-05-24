using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200050D RID: 1293
	internal class ahx : ahu
	{
		// Token: 0x06003498 RID: 13464 RVA: 0x001D03C0 File Offset: 0x001CF3C0
		internal ahx(ahq A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003499 RID: 13465 RVA: 0x001D03EC File Offset: 0x001CF3EC
		internal override object me()
		{
			object result = this.b;
			this.b = DBNull.Value;
			this.a = false;
			return result;
		}

		// Token: 0x0600349A RID: 13466 RVA: 0x001D0418 File Offset: 0x001CF418
		internal override object mf(bool A_0)
		{
			object result = null;
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (this.e == null)
					{
						this.e = 0;
					}
					object result2 = this.e;
					this.e = base.c()[0];
					base.c().RemoveAt(0);
					return result2;
				}
				result = base.c()[0];
				base.c().RemoveAt(0);
			}
			return result;
		}

		// Token: 0x0600349B RID: 13467 RVA: 0x001D04C8 File Offset: 0x001CF4C8
		internal override object mg(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.e);
		}

		// Token: 0x0600349C RID: 13468 RVA: 0x001D04E8 File Offset: 0x001CF4E8
		internal override void mi(LayoutWriter A_0)
		{
			if (!this.a)
			{
				this.b = this.c.ma(A_0);
				if (!(this.b is DBNull))
				{
					this.a = true;
				}
			}
		}

		// Token: 0x0600349D RID: 13469 RVA: 0x001D0530 File Offset: 0x001CF530
		internal override void mh(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.c.ma(A_0));
		}

		// Token: 0x0600349E RID: 13470 RVA: 0x001D0578 File Offset: 0x001CF578
		internal override void mj()
		{
			if (!this.a)
			{
				this.b = this.d[0];
				if (!(this.b is DBNull))
				{
					this.a = true;
				}
			}
			this.d.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x0600349F RID: 13471 RVA: 0x001D05DC File Offset: 0x001CF5DC
		internal override void mk(Page A_0)
		{
			this.a = false;
			if (A_0 != base.e())
			{
				base.c().Add(this.b);
			}
			else if (base.c()[base.c().Count - 1] is DBNull)
			{
				base.c()[base.c().Count - 1] = this.b;
			}
			base.a(A_0);
			this.b = DBNull.Value;
		}

		// Token: 0x04001964 RID: 6500
		private new bool a = false;

		// Token: 0x04001965 RID: 6501
		private new object b = DBNull.Value;

		// Token: 0x04001966 RID: 6502
		private ahq c;

		// Token: 0x04001967 RID: 6503
		private ArrayList d;

		// Token: 0x04001968 RID: 6504
		private object e = null;
	}
}
