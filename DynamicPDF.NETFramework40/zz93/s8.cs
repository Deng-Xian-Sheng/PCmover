using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002E1 RID: 737
	internal class s8 : s1
	{
		// Token: 0x06002117 RID: 8471 RVA: 0x00142B08 File Offset: 0x00141B08
		internal s8(q7 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002118 RID: 8472 RVA: 0x00142B30 File Offset: 0x00141B30
		internal override object fo()
		{
			object obj = this.d;
			this.d = null;
			return (obj == null) ? DBNull.Value : obj;
		}

		// Token: 0x06002119 RID: 8473 RVA: 0x00142B5C File Offset: 0x00141B5C
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

		// Token: 0x0600211A RID: 8474 RVA: 0x00142C1C File Offset: 0x00141C1C
		internal override object fq(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x0600211B RID: 8475 RVA: 0x00142C3C File Offset: 0x00141C3C
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
					if (num > d)
					{
						this.d = num;
					}
				}
			}
		}

		// Token: 0x0600211C RID: 8476 RVA: 0x00142CD0 File Offset: 0x00141CD0
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

		// Token: 0x0600211D RID: 8477 RVA: 0x00142D60 File Offset: 0x00141D60
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
					if (d > d2)
					{
						this.d = this.b[0];
					}
				}
			}
			this.b = s1.a(this.b);
			base.a(base.d() + 1);
		}

		// Token: 0x0600211E RID: 8478 RVA: 0x00142E14 File Offset: 0x00141E14
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
				if (base.c()[base.c().Count - 1] is DBNull || q7.e(base.c()[base.c().Count - 1]) < q7.e(this.d))
				{
					base.c()[base.c().Count - 1] = this.d;
				}
			}
			this.d = null;
			base.a(A_0);
		}

		// Token: 0x04000E7E RID: 3710
		private new int a = 0;

		// Token: 0x04000E7F RID: 3711
		private new object[] b = null;

		// Token: 0x04000E80 RID: 3712
		private q7 c;

		// Token: 0x04000E81 RID: 3713
		private object d = null;
	}
}
