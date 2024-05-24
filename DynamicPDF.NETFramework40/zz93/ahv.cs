using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200050B RID: 1291
	internal class ahv : ahu
	{
		// Token: 0x0600348D RID: 13453 RVA: 0x001CFF56 File Offset: 0x001CEF56
		internal ahv(ahq A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600348E RID: 13454 RVA: 0x001CFF78 File Offset: 0x001CEF78
		internal override object me()
		{
			int num = this.a;
			this.a = 0;
			return num;
		}

		// Token: 0x0600348F RID: 13455 RVA: 0x001CFFA0 File Offset: 0x001CEFA0
		internal override object mf(bool A_0)
		{
			object result = 0;
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

		// Token: 0x06003490 RID: 13456 RVA: 0x001D0058 File Offset: 0x001CF058
		internal override object mg(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x06003491 RID: 13457 RVA: 0x001D0078 File Offset: 0x001CF078
		internal override void mh(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList(10);
			}
			if (this.b == null)
			{
				this.c.Add(1);
			}
			else if (this.b.l4(A_0))
			{
				this.c.Add(0);
			}
			else
			{
				this.c.Add(1);
			}
		}

		// Token: 0x06003492 RID: 13458 RVA: 0x001D010C File Offset: 0x001CF10C
		internal override void mi(LayoutWriter A_0)
		{
			if (this.b == null)
			{
				this.a++;
			}
			else if (!this.b.l4(A_0))
			{
				this.a++;
			}
		}

		// Token: 0x06003493 RID: 13459 RVA: 0x001D015C File Offset: 0x001CF15C
		internal override void mj()
		{
			this.a += ahq.c(this.c[0]);
			this.c.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x06003494 RID: 13460 RVA: 0x001D019C File Offset: 0x001CF19C
		internal override void mk(Page A_0)
		{
			if (A_0 == base.e())
			{
				base.c().TrimToSize();
				base.c()[base.c().Count - 1] = ahq.c(base.c()[base.c().Count - 1]) + this.a;
			}
			else
			{
				base.c().Add(this.a);
			}
			this.a = 0;
			base.a(A_0);
		}

		// Token: 0x0400195F RID: 6495
		private new int a = 0;

		// Token: 0x04001960 RID: 6496
		private new ahq b;

		// Token: 0x04001961 RID: 6497
		private ArrayList c;

		// Token: 0x04001962 RID: 6498
		private object d = null;
	}
}
