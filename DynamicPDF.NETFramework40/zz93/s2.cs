using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002DB RID: 731
	internal class s2 : s1
	{
		// Token: 0x060020F6 RID: 8438 RVA: 0x00141E8A File Offset: 0x00140E8A
		internal s2(q7 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x00141EAC File Offset: 0x00140EAC
		internal override object fo()
		{
			int num = this.a;
			this.a = 0;
			return num;
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x00141ED4 File Offset: 0x00140ED4
		internal override object fp(bool A_0)
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

		// Token: 0x060020F9 RID: 8441 RVA: 0x00141F8C File Offset: 0x00140F8C
		internal override object fq(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x00141FAC File Offset: 0x00140FAC
		internal override void fr(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList(10);
			}
			if (this.b == null)
			{
				this.c.Add(1);
			}
			else if (this.b.eq(A_0))
			{
				this.c.Add(0);
			}
			else
			{
				this.c.Add(1);
			}
		}

		// Token: 0x060020FB RID: 8443 RVA: 0x00142040 File Offset: 0x00141040
		internal override void fs(LayoutWriter A_0)
		{
			if (this.b == null)
			{
				this.a++;
			}
			else if (!this.b.eq(A_0))
			{
				this.a++;
			}
		}

		// Token: 0x060020FC RID: 8444 RVA: 0x00142090 File Offset: 0x00141090
		internal override void ft()
		{
			this.a += q7.c(this.c[0]);
			this.c.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x060020FD RID: 8445 RVA: 0x001420D0 File Offset: 0x001410D0
		internal override void fu(Page A_0)
		{
			if (A_0 == base.e())
			{
				base.c().TrimToSize();
				base.c()[base.c().Count - 1] = q7.c(base.c()[base.c().Count - 1]) + this.a;
			}
			else
			{
				base.c().Add(this.a);
			}
			this.a = 0;
			base.a(A_0);
		}

		// Token: 0x04000E6E RID: 3694
		private new int a = 0;

		// Token: 0x04000E6F RID: 3695
		private new q7 b;

		// Token: 0x04000E70 RID: 3696
		private ArrayList c;

		// Token: 0x04000E71 RID: 3697
		private object d = null;
	}
}
