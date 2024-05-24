using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200051D RID: 1309
	internal class aid : ahu
	{
		// Token: 0x060034F9 RID: 13561 RVA: 0x001D38AC File Offset: 0x001D28AC
		internal aid(ahq A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060034FA RID: 13562 RVA: 0x001D38D4 File Offset: 0x001D28D4
		internal override object me()
		{
			decimal num = this.a;
			this.a = 0m;
			return num;
		}

		// Token: 0x060034FB RID: 13563 RVA: 0x001D3900 File Offset: 0x001D2900
		internal override object mf(bool A_0)
		{
			object result = 0m;
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (this.d == null)
					{
						this.d = 0m;
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

		// Token: 0x060034FC RID: 13564 RVA: 0x001D39C0 File Offset: 0x001D29C0
		internal override object mg(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x060034FD RID: 13565 RVA: 0x001D39E0 File Offset: 0x001D29E0
		internal override void mi(LayoutWriter A_0)
		{
			object obj = this.b.ma(A_0);
			if (!(obj is DBNull) && obj != null)
			{
				this.a += ahq.e(obj);
			}
		}

		// Token: 0x060034FE RID: 13566 RVA: 0x001D3A28 File Offset: 0x001D2A28
		internal override void mh(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList(10);
			}
			this.c.Add(this.b.ma(A_0));
		}

		// Token: 0x060034FF RID: 13567 RVA: 0x001D3A70 File Offset: 0x001D2A70
		internal override void mj()
		{
			if (!(this.c[0] is DBNull))
			{
				this.a += ahq.e(this.c[0]);
			}
			this.c.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x06003500 RID: 13568 RVA: 0x001D3AD8 File Offset: 0x001D2AD8
		internal override void mk(Page A_0)
		{
			if (A_0 == base.e())
			{
				base.c().TrimToSize();
				base.c()[base.c().Count - 1] = ahq.e(base.c()[base.c().Count - 1]) + this.a;
			}
			else
			{
				base.c().Add(this.a);
			}
			this.a = 0m;
			base.a(A_0);
		}

		// Token: 0x04001991 RID: 6545
		private new decimal a = 0m;

		// Token: 0x04001992 RID: 6546
		private new ahq b;

		// Token: 0x04001993 RID: 6547
		private ArrayList c;

		// Token: 0x04001994 RID: 6548
		private object d = null;
	}
}
