using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002DF RID: 735
	internal class s6 : s1
	{
		// Token: 0x0600210C RID: 8460 RVA: 0x0014271E File Offset: 0x0014171E
		internal s6(q7 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600210D RID: 8461 RVA: 0x00142744 File Offset: 0x00141744
		internal override object fo()
		{
			object result = this.a;
			this.a = DBNull.Value;
			return result;
		}

		// Token: 0x0600210E RID: 8462 RVA: 0x0014276C File Offset: 0x0014176C
		internal override object fp(bool A_0)
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

		// Token: 0x0600210F RID: 8463 RVA: 0x0014281C File Offset: 0x0014181C
		internal override object fq(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x06002110 RID: 8464 RVA: 0x0014283C File Offset: 0x0014183C
		internal override void fs(LayoutWriter A_0)
		{
			object obj = this.b.es(A_0);
			if (!(obj is DBNull))
			{
				this.a = obj;
			}
		}

		// Token: 0x06002111 RID: 8465 RVA: 0x0014286C File Offset: 0x0014186C
		internal override void fr(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList(10);
			}
			this.c.Add(this.b.es(A_0));
		}

		// Token: 0x06002112 RID: 8466 RVA: 0x001428B4 File Offset: 0x001418B4
		internal override void ft()
		{
			if (!(this.c[0] is DBNull))
			{
				this.a = this.c[0];
			}
			this.c.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x06002113 RID: 8467 RVA: 0x00142908 File Offset: 0x00141908
		internal override void fu(Page A_0)
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

		// Token: 0x04000E79 RID: 3705
		private new object a = DBNull.Value;

		// Token: 0x04000E7A RID: 3706
		private new q7 b;

		// Token: 0x04000E7B RID: 3707
		private ArrayList c;

		// Token: 0x04000E7C RID: 3708
		private object d = null;
	}
}
