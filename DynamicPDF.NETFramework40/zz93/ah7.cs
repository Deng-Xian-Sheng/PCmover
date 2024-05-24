using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000517 RID: 1303
	internal class ah7 : ahu
	{
		// Token: 0x060034D2 RID: 13522 RVA: 0x001D223C File Offset: 0x001D123C
		internal ah7(ahq A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060034D3 RID: 13523 RVA: 0x001D2264 File Offset: 0x001D1264
		internal override object me()
		{
			object obj = this.d;
			this.d = null;
			return (obj == null) ? DBNull.Value : obj;
		}

		// Token: 0x060034D4 RID: 13524 RVA: 0x001D2290 File Offset: 0x001D1290
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

		// Token: 0x060034D5 RID: 13525 RVA: 0x001D2350 File Offset: 0x001D1350
		internal override object mg(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.d);
		}

		// Token: 0x060034D6 RID: 13526 RVA: 0x001D2370 File Offset: 0x001D1370
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
					if (num < d)
					{
						this.d = num;
					}
				}
			}
		}

		// Token: 0x060034D7 RID: 13527 RVA: 0x001D2404 File Offset: 0x001D1404
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

		// Token: 0x060034D8 RID: 13528 RVA: 0x001D2494 File Offset: 0x001D1494
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
					if (d < d2)
					{
						this.d = this.b[0];
					}
				}
			}
			this.b = ahu.a(this.b);
			base.a(base.d() + 1);
		}

		// Token: 0x060034D9 RID: 13529 RVA: 0x001D2548 File Offset: 0x001D1548
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
				if (base.c()[base.c().Count - 1] is DBNull || ahq.e(base.c()[base.c().Count - 1]) > ahq.e(this.d))
				{
					base.c()[base.c().Count - 1] = this.d;
				}
			}
			this.d = null;
			base.a(A_0);
		}

		// Token: 0x04001980 RID: 6528
		private new int a = 0;

		// Token: 0x04001981 RID: 6529
		private new object[] b = null;

		// Token: 0x04001982 RID: 6530
		private ahq c;

		// Token: 0x04001983 RID: 6531
		private object d = null;
	}
}
