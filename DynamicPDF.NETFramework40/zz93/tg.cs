using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002E9 RID: 745
	internal class tg : s1
	{
		// Token: 0x06002146 RID: 8518 RVA: 0x001446F6 File Offset: 0x001436F6
		internal tg(q7 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002147 RID: 8519 RVA: 0x00144724 File Offset: 0x00143724
		internal override object fo()
		{
			object result;
			if (this.c == 0)
			{
				result = DBNull.Value;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int i = 0;
				int num3 = 0;
				this.a(0, this.c - 1);
				decimal d = this.b[0];
				while (i < this.c)
				{
					if (d == this.b[i])
					{
						num3++;
						if (num3 > num2)
						{
							num2 = num3;
							num = i;
						}
					}
					else
					{
						d = this.b[i];
						num3 = 1;
					}
					i++;
				}
				if (num2 == 1)
				{
					result = DBNull.Value;
				}
				else
				{
					result = this.b[num];
				}
			}
			return result;
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x00144818 File Offset: 0x00143818
		private void a(int A_0, int A_1)
		{
			if (A_1 > A_0)
			{
				int i = A_0;
				int num = A_1;
				int num2 = (A_0 + A_1) / 2;
				decimal num3 = this.b[num2];
				while (i <= num)
				{
					while (this.b[i] < num3 && i < A_1)
					{
						i++;
					}
					while (num3 < this.b[num] && num > A_0)
					{
						num--;
					}
					if (i <= num)
					{
						decimal num4 = this.b[i];
						this.b[i] = this.b[num];
						this.b[num] = num4;
						i++;
						num--;
					}
				}
				if (A_0 < num)
				{
					this.a(A_0, num);
				}
				if (i < A_1)
				{
					this.a(i, A_1);
				}
			}
		}

		// Token: 0x06002149 RID: 8521 RVA: 0x0014494C File Offset: 0x0014394C
		internal override object fp(bool A_0)
		{
			object result = 0m;
			if (base.c() != null && base.c().Count != 0 && base.c()[0] != null)
			{
				if (A_0)
				{
					if (this.e == null)
					{
						this.e = 0m;
					}
					object result2 = this.e;
					this.a((object[])base.c()[0]);
					this.e = this.fo();
					base.c().RemoveAt(0);
					return result2;
				}
				this.a((object[])base.c()[0]);
				result = this.fo();
				base.c().RemoveAt(0);
			}
			return result;
		}

		// Token: 0x0600214A RID: 8522 RVA: 0x00144A34 File Offset: 0x00143A34
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
							this.a((object[])base.c()[0]);
							this.e = this.fo();
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
					}
					this.a((object[])base.c()[0]);
					this.e = this.fo();
				}
				base.a(A_1);
				base.b(false);
			}
			return this.e;
		}

		// Token: 0x0600214B RID: 8523 RVA: 0x00144B8C File Offset: 0x00143B8C
		private void a(object[] A_0)
		{
			this.c = 0;
			this.b = new decimal[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] != null)
				{
					this.b[this.c] = q7.e(A_0[i]);
					this.c++;
				}
			}
		}

		// Token: 0x0600214C RID: 8524 RVA: 0x00144BFC File Offset: 0x00143BFC
		internal override void fs(LayoutWriter A_0)
		{
			if (!this.a.eq(A_0))
			{
				if (this.b == null)
				{
					this.b = new decimal[10];
				}
				if (this.c == this.b.Length)
				{
					decimal[] array = new decimal[this.b.Length * 2];
					this.b.CopyTo(array, 0);
					this.b = array;
				}
				this.b[this.c++] = this.a.ei(A_0);
			}
		}

		// Token: 0x0600214D RID: 8525 RVA: 0x00144CAC File Offset: 0x00143CAC
		internal override void fr(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.a.es(A_0));
		}

		// Token: 0x0600214E RID: 8526 RVA: 0x00144CF1 File Offset: 0x00143CF1
		internal override void ft()
		{
			this.c++;
			base.a(base.d() + 1);
		}

		// Token: 0x0600214F RID: 8527 RVA: 0x00144D14 File Offset: 0x00143D14
		internal override void fu(Page A_0)
		{
			if (base.e() != A_0)
			{
				this.b = null;
			}
			object[] array = new object[this.c];
			int i = 0;
			while (i < this.c)
			{
				if (!(this.d[0] is DBNull))
				{
					array[i] = this.d[0];
					i++;
				}
				else
				{
					this.c--;
				}
				this.d.RemoveAt(0);
				if (this.d.Count == 0)
				{
					break;
				}
			}
			if (base.e() != A_0)
			{
				base.c().Add(array);
			}
			else
			{
				object[] array2 = new object[array.Length + ((Array)base.c()[base.c().Count - 1]).Length];
				((Array)base.c()[base.c().Count - 1]).CopyTo(array2, 0);
				array.CopyTo(array2, ((Array)base.c()[base.c().Count - 1]).Length);
				base.c()[base.c().Count - 1] = array2;
			}
			this.c = 0;
			base.a(A_0);
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x00144E82 File Offset: 0x00143E82
		internal override void fv()
		{
			this.c = 0;
			this.b = null;
		}

		// Token: 0x04000E94 RID: 3732
		private new q7 a;

		// Token: 0x04000E95 RID: 3733
		private new decimal[] b = new decimal[10];

		// Token: 0x04000E96 RID: 3734
		private int c = 0;

		// Token: 0x04000E97 RID: 3735
		private ArrayList d;

		// Token: 0x04000E98 RID: 3736
		private object e = null;
	}
}
