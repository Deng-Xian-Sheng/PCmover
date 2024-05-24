using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002E7 RID: 743
	internal class te : s1
	{
		// Token: 0x0600213B RID: 8507 RVA: 0x00144170 File Offset: 0x00143170
		internal te(q7 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600213C RID: 8508 RVA: 0x00144198 File Offset: 0x00143198
		internal override object fo()
		{
			object obj = this.d;
			this.d = null;
			return (obj == null) ? DBNull.Value : obj;
		}

		// Token: 0x0600213D RID: 8509 RVA: 0x001441C4 File Offset: 0x001431C4
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

		// Token: 0x0600213E RID: 8510 RVA: 0x00144284 File Offset: 0x00143284
		internal override object fq(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x0600213F RID: 8511 RVA: 0x001442A4 File Offset: 0x001432A4
		internal override void fs(LayoutWriter A_0)
		{
			if (!this.c.eq(A_0))
			{
				if (this.d is DBNull || this.d == null)
				{
					this.d = this.c.ei(A_0);
				}
				else
				{
					decimal d = q7.e(this.d);
					decimal num = this.c.ei(A_0);
					if (num < d)
					{
						this.d = num;
					}
				}
			}
		}

		// Token: 0x06002140 RID: 8512 RVA: 0x00144338 File Offset: 0x00143338
		internal override void fr(LayoutWriter A_0)
		{
			if (this.b == null)
			{
				this.b = new object[10];
			}
			if (this.a == this.b.Length)
			{
				object[] array = new object[this.b.Length * 2];
				this.b.CopyTo(array, 0);
				this.b = array;
			}
			this.b[this.a++] = this.c.es(A_0);
		}

		// Token: 0x06002141 RID: 8513 RVA: 0x001443C8 File Offset: 0x001433C8
		internal override void ft()
		{
			if (!(this.b[0] is DBNull))
			{
				if (this.d is DBNull || this.d == null)
				{
					this.d = this.b[0];
				}
				else
				{
					decimal d = q7.e(this.b[0]);
					decimal d2 = q7.e(this.d);
					if (d < d2)
					{
						this.d = this.b[0];
					}
				}
			}
			this.b = s1.a(this.b);
			base.a(base.d() + 1);
		}

		// Token: 0x06002142 RID: 8514 RVA: 0x0014447C File Offset: 0x0014347C
		internal override void fu(Page A_0)
		{
			if (base.e() != A_0)
			{
				base.c().Add((this.d == null) ? DBNull.Value : this.d);
			}
			else
			{
				base.c().TrimToSize();
				if (this.d is DBNull || this.d == null)
				{
					return;
				}
				if (base.c()[base.c().Count - 1] is DBNull || q7.e(base.c()[base.c().Count - 1]) > q7.e(this.d))
				{
					base.c()[base.c().Count - 1] = this.d;
				}
			}
			this.d = null;
			base.a(A_0);
		}

		// Token: 0x04000E8F RID: 3727
		private new int a = 0;

		// Token: 0x04000E90 RID: 3728
		private new object[] b = null;

		// Token: 0x04000E91 RID: 3729
		private q7 c;

		// Token: 0x04000E92 RID: 3730
		private object d = null;
	}
}
