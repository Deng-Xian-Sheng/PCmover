using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000511 RID: 1297
	internal class ah1 : ahu
	{
		// Token: 0x060034AE RID: 13486 RVA: 0x001D0BD4 File Offset: 0x001CFBD4
		internal ah1(ahq A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060034AF RID: 13487 RVA: 0x001D0BFC File Offset: 0x001CFBFC
		internal override object me()
		{
			object obj = this.d;
			this.d = null;
			return (obj == null) ? DBNull.Value : obj;
		}

		// Token: 0x060034B0 RID: 13488 RVA: 0x001D0C28 File Offset: 0x001CFC28
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

		// Token: 0x060034B1 RID: 13489 RVA: 0x001D0CE8 File Offset: 0x001CFCE8
		internal override object mg(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x060034B2 RID: 13490 RVA: 0x001D0D08 File Offset: 0x001CFD08
		internal override void mi(LayoutWriter A_0)
		{
			if (!this.c.l4(A_0))
			{
				if (this.d is DBNull || this.d == null)
				{
					this.d = this.c.l7(A_0);
				}
				else
				{
					decimal d = ahq.e(this.d);
					decimal num = this.c.l7(A_0);
					if (num > d)
					{
						this.d = num;
					}
				}
			}
		}

		// Token: 0x060034B3 RID: 13491 RVA: 0x001D0D9C File Offset: 0x001CFD9C
		internal override void mh(LayoutWriter A_0)
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
			this.b[this.a++] = this.c.ma(A_0);
		}

		// Token: 0x060034B4 RID: 13492 RVA: 0x001D0E2C File Offset: 0x001CFE2C
		internal override void mj()
		{
			if (!(this.b[0] is DBNull))
			{
				if (this.d is DBNull || this.d == null)
				{
					this.d = this.b[0];
				}
				else
				{
					decimal d = ahq.e(this.b[0]);
					decimal d2 = ahq.e(this.d);
					if (d > d2)
					{
						this.d = this.b[0];
					}
				}
			}
			this.b = ahu.a(this.b);
			base.a(base.d() + 1);
		}

		// Token: 0x060034B5 RID: 13493 RVA: 0x001D0EE0 File Offset: 0x001CFEE0
		internal override void mk(Page A_0)
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
				if (base.c()[base.c().Count - 1] is DBNull || ahq.e(base.c()[base.c().Count - 1]) < ahq.e(this.d))
				{
					base.c()[base.c().Count - 1] = this.d;
				}
			}
			this.d = null;
			base.a(A_0);
		}

		// Token: 0x0400196F RID: 6511
		private new int a = 0;

		// Token: 0x04001970 RID: 6512
		private new object[] b = null;

		// Token: 0x04001971 RID: 6513
		private ahq c;

		// Token: 0x04001972 RID: 6514
		private object d = null;
	}
}
