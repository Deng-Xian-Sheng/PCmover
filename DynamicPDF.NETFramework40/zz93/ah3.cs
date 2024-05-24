using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000513 RID: 1299
	internal class ah3 : ahu
	{
		// Token: 0x060034B9 RID: 13497 RVA: 0x001D117E File Offset: 0x001D017E
		internal ah3(ahq A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060034BA RID: 13498 RVA: 0x001D11AC File Offset: 0x001D01AC
		internal override object me()
		{
			object result;
			if (this.a == 0)
			{
				result = DBNull.Value;
			}
			else
			{
				decimal d = this.a;
				decimal d2 = this.b;
				decimal num = d2 / d;
				this.a = 0;
				this.b = 0m;
				result = num;
			}
			return result;
		}

		// Token: 0x060034BB RID: 13499 RVA: 0x001D120C File Offset: 0x001D020C
		internal override object mf(bool A_0)
		{
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (this.e == null)
					{
						this.e = 0m;
					}
					object result = this.e;
					if (!(ahq.e(base.c()[1]) == 0m))
					{
						this.e = ahq.e(base.c()[0]) / ahq.e(base.c()[1]);
					}
					else
					{
						this.e = DBNull.Value;
					}
					base.c().RemoveAt(0);
					base.c().RemoveAt(0);
					return result;
				}
				if (!(ahq.e(base.c()[1]) == 0m))
				{
					this.e = ahq.e(base.c()[0]) / ahq.e(base.c()[1]);
				}
				else
				{
					this.e = DBNull.Value;
				}
				base.c().RemoveAt(0);
				base.c().RemoveAt(0);
			}
			return this.e;
		}

		// Token: 0x060034BC RID: 13500 RVA: 0x001D138C File Offset: 0x001D038C
		internal override object mg(bool A_0, Page A_1)
		{
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (A_1 != base.e())
					{
						if (base.f())
						{
							this.e = 0;
						}
						if (base.c().Count > 1 && !base.f())
						{
							if (!(ahq.e(base.c()[1]) == 0m))
							{
								this.e = ahq.e(base.c()[0]) / ahq.e(base.c()[1]);
							}
							else
							{
								this.e = DBNull.Value;
							}
							base.c().RemoveAt(0);
							base.c().RemoveAt(0);
						}
					}
					base.a(A_1);
					base.b(false);
					return this.e;
				}
				if (A_1 != base.e())
				{
					if (base.c().Count > 1 && !base.f())
					{
						base.c().RemoveAt(0);
						base.c().RemoveAt(0);
					}
					if (!(ahq.e(base.c()[1]) == 0m))
					{
						this.e = ahq.e(base.c()[0]) / ahq.e(base.c()[1]);
					}
					else
					{
						this.e = DBNull.Value;
					}
				}
				base.a(A_1);
				base.b(false);
			}
			return this.e;
		}

		// Token: 0x060034BD RID: 13501 RVA: 0x001D1580 File Offset: 0x001D0580
		internal override void mi(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.a++;
			}
			else if (!this.c.l4(A_0))
			{
				this.a++;
				this.b += this.c.l7(A_0);
			}
		}

		// Token: 0x060034BE RID: 13502 RVA: 0x001D15F0 File Offset: 0x001D05F0
		internal override void mh(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.c.ma(A_0));
		}

		// Token: 0x060034BF RID: 13503 RVA: 0x001D1638 File Offset: 0x001D0638
		internal override void mj()
		{
			if (this.c == null)
			{
				this.a++;
			}
			else
			{
				if (!(this.d[0] is DBNull))
				{
					this.a++;
					this.b += ahq.e(this.d[0]);
				}
				this.d.RemoveAt(0);
			}
			base.a(base.d() + 1);
		}

		// Token: 0x060034C0 RID: 13504 RVA: 0x001D16D0 File Offset: 0x001D06D0
		internal override void mk(Page A_0)
		{
			if (base.e() != A_0)
			{
				base.c().Add(this.b);
				base.c().Add(this.a);
			}
			else
			{
				base.c()[base.c().Count - 1] = (int)base.c()[base.c().Count - 1] + this.a;
				base.c()[base.c().Count - 2] = (decimal)base.c()[base.c().Count - 2] + this.b;
			}
			this.b = 0m;
			this.a = 0;
			base.a(A_0);
		}

		// Token: 0x04001974 RID: 6516
		private new int a = 0;

		// Token: 0x04001975 RID: 6517
		private new decimal b = 0m;

		// Token: 0x04001976 RID: 6518
		private ahq c;

		// Token: 0x04001977 RID: 6519
		private ArrayList d;

		// Token: 0x04001978 RID: 6520
		private object e = null;
	}
}
