using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002DD RID: 733
	internal class s4 : s1
	{
		// Token: 0x06002101 RID: 8449 RVA: 0x001422F4 File Offset: 0x001412F4
		internal s4(q7 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002102 RID: 8450 RVA: 0x00142320 File Offset: 0x00141320
		internal override object fo()
		{
			object result = this.b;
			this.b = DBNull.Value;
			this.a = false;
			return result;
		}

		// Token: 0x06002103 RID: 8451 RVA: 0x0014234C File Offset: 0x0014134C
		internal override object fp(bool A_0)
		{
			object result = null;
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (this.e == null)
					{
						this.e = 0;
					}
					object result2 = this.e;
					this.e = base.c()[0];
					base.c().RemoveAt(0);
					return result2;
				}
				result = base.c()[0];
				base.c().RemoveAt(0);
			}
			return result;
		}

		// Token: 0x06002104 RID: 8452 RVA: 0x001423FC File Offset: 0x001413FC
		internal override object fq(bool A_0, Page A_1)
		{
			return base.a(A_0, A_1, ref this.e);
		}

		// Token: 0x06002105 RID: 8453 RVA: 0x0014241C File Offset: 0x0014141C
		internal override void fs(LayoutWriter A_0)
		{
			if (!this.a)
			{
				this.b = this.c.es(A_0);
				if (!(this.b is DBNull))
				{
					this.a = true;
				}
			}
		}

		// Token: 0x06002106 RID: 8454 RVA: 0x00142464 File Offset: 0x00141464
		internal override void fr(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.c.es(A_0));
		}

		// Token: 0x06002107 RID: 8455 RVA: 0x001424AC File Offset: 0x001414AC
		internal override void ft()
		{
			if (!this.a)
			{
				this.b = this.d[0];
				if (!(this.b is DBNull))
				{
					this.a = true;
				}
			}
			this.d.RemoveAt(0);
			base.a(base.d() + 1);
		}

		// Token: 0x06002108 RID: 8456 RVA: 0x00142510 File Offset: 0x00141510
		internal override void fu(Page A_0)
		{
			this.a = false;
			if (A_0 != base.e())
			{
				base.c().Add(this.b);
			}
			else if (base.c()[base.c().Count - 1] is DBNull)
			{
				base.c()[base.c().Count - 1] = this.b;
			}
			base.a(A_0);
			this.b = DBNull.Value;
		}

		// Token: 0x04000E73 RID: 3699
		private new bool a = false;

		// Token: 0x04000E74 RID: 3700
		private new object b = DBNull.Value;

		// Token: 0x04000E75 RID: 3701
		private q7 c;

		// Token: 0x04000E76 RID: 3702
		private ArrayList d;

		// Token: 0x04000E77 RID: 3703
		private object e = null;
	}
}
