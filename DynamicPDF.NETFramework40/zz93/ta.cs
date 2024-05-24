using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002E3 RID: 739
	internal class ta : s1
	{
		// Token: 0x06002122 RID: 8482 RVA: 0x001430B2 File Offset: 0x001420B2
		internal ta(q7 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x001430E0 File Offset: 0x001420E0
		internal override object fo()
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

		// Token: 0x06002124 RID: 8484 RVA: 0x00143140 File Offset: 0x00142140
		internal override object fp(bool A_0)
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
					if (!(q7.e(base.c()[1]) == 0m))
					{
						this.e = q7.e(base.c()[0]) / q7.e(base.c()[1]);
					}
					else
					{
						this.e = DBNull.Value;
					}
					base.c().RemoveAt(0);
					base.c().RemoveAt(0);
					return result;
				}
				if (!(q7.e(base.c()[1]) == 0m))
				{
					this.e = q7.e(base.c()[0]) / q7.e(base.c()[1]);
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

		// Token: 0x06002125 RID: 8485 RVA: 0x001432C0 File Offset: 0x001422C0
		internal override object fq(bool A_0, Page A_1)
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
							if (!(q7.e(base.c()[1]) == 0m))
							{
								this.e = q7.e(base.c()[0]) / q7.e(base.c()[1]);
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
					if (!(q7.e(base.c()[1]) == 0m))
					{
						this.e = q7.e(base.c()[0]) / q7.e(base.c()[1]);
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

		// Token: 0x06002126 RID: 8486 RVA: 0x001434B4 File Offset: 0x001424B4
		internal override void fs(LayoutWriter A_0)
		{
			if (this.c == null)
			{
				this.a++;
			}
			else if (!this.c.eq(A_0))
			{
				this.a++;
				this.b += this.c.ei(A_0);
			}
		}

		// Token: 0x06002127 RID: 8487 RVA: 0x00143524 File Offset: 0x00142524
		internal override void fr(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.c.es(A_0));
		}

		// Token: 0x06002128 RID: 8488 RVA: 0x0014356C File Offset: 0x0014256C
		internal override void ft()
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
					this.b += q7.e(this.d[0]);
				}
				this.d.RemoveAt(0);
			}
			base.a(base.d() + 1);
		}

		// Token: 0x06002129 RID: 8489 RVA: 0x00143604 File Offset: 0x00142604
		internal override void fu(Page A_0)
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

		// Token: 0x04000E83 RID: 3715
		private new int a = 0;

		// Token: 0x04000E84 RID: 3716
		private new decimal b = 0m;

		// Token: 0x04000E85 RID: 3717
		private q7 c;

		// Token: 0x04000E86 RID: 3718
		private ArrayList d;

		// Token: 0x04000E87 RID: 3719
		private object e = null;
	}
}
