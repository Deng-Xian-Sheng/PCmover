using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002ED RID: 749
	internal class tk : s1
	{
		// Token: 0x06002162 RID: 8546 RVA: 0x001457E0 File Offset: 0x001447E0
		internal tk(q7 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002163 RID: 8547 RVA: 0x00145808 File Offset: 0x00144808
		internal override object fo()
		{
			decimal num = this.a;
			this.a = 0m;
			return num;
		}

		// Token: 0x06002164 RID: 8548 RVA: 0x00145834 File Offset: 0x00144834
		internal override object fp(bool A_0)
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

		// Token: 0x06002165 RID: 8549 RVA: 0x001458F4 File Offset: 0x001448F4
		internal override object fq(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x06002166 RID: 8550 RVA: 0x00145914 File Offset: 0x00144914
		internal override void fs(LayoutWriter A_0)
		{
			object obj = this.b.es(A_0);
			if (!(obj is DBNull))
			{
				this.a += q7.e(obj);
			}
		}

		// Token: 0x06002167 RID: 8551 RVA: 0x00145954 File Offset: 0x00144954
		internal override void fr(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList(10);
			}
			this.c.Add(this.b.es(A_0));
		}

		// Token: 0x06002168 RID: 8552 RVA: 0x0014599C File Offset: 0x0014499C
		internal override void ft()
		{
			if (!(this.c[0] is DBNull))
			{
				this.a += q7.e(this.c[0]);
			}
			this.c.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x00145A04 File Offset: 0x00144A04
		internal override void fu(Page A_0)
		{
			if (A_0 == base.e())
			{
				base.c().TrimToSize();
				base.c()[base.c().Count - 1] = q7.e(base.c()[base.c().Count - 1]) + this.a;
			}
			else
			{
				base.c().Add(this.a);
			}
			this.a = 0m;
			base.a(A_0);
		}

		// Token: 0x04000EA0 RID: 3744
		private new decimal a = 0m;

		// Token: 0x04000EA1 RID: 3745
		private new q7 b;

		// Token: 0x04000EA2 RID: 3746
		private ArrayList c;

		// Token: 0x04000EA3 RID: 3747
		private object d = null;
	}
}
