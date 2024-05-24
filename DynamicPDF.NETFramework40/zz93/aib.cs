using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200051B RID: 1307
	internal class aib : ahu
	{
		// Token: 0x060034EB RID: 13547 RVA: 0x001D3110 File Offset: 0x001D2110
		internal aib(ahq A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060034EC RID: 13548 RVA: 0x001D3140 File Offset: 0x001D2140
		internal override object me()
		{
			object result;
			if (this.b < 2)
			{
				result = DBNull.Value;
			}
			else
			{
				double num = this.a(this.c);
				double num2 = 0.0;
				for (int i = 0; i < this.b; i++)
				{
					num2 += Math.Pow(this.c[i] - num, 2.0);
				}
				result = Math.Sqrt(num2 / (double)(this.b - 1));
			}
			return result;
		}

		// Token: 0x060034ED RID: 13549 RVA: 0x001D31CC File Offset: 0x001D21CC
		internal override object mf(bool A_0)
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
					this.e = this.me();
					base.c().RemoveAt(0);
					return result2;
				}
				this.a((object[])base.c()[0]);
				result = this.me();
				base.c().RemoveAt(0);
			}
			return result;
		}

		// Token: 0x060034EE RID: 13550 RVA: 0x001D32B4 File Offset: 0x001D22B4
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
							this.a((object[])base.c()[0]);
							this.e = this.me();
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
					this.e = this.me();
				}
				base.a(A_1);
				base.b(false);
			}
			return this.e;
		}

		// Token: 0x060034EF RID: 13551 RVA: 0x001D340C File Offset: 0x001D240C
		private void a(object[] A_0)
		{
			this.b = 0;
			this.c = new double[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] != null)
				{
					this.c[this.b] = ahq.d(A_0[i]);
					this.b++;
				}
			}
		}

		// Token: 0x060034F0 RID: 13552 RVA: 0x001D3474 File Offset: 0x001D2474
		internal override void mi(LayoutWriter A_0)
		{
			if (!this.a.l4(A_0))
			{
				if (this.c == null)
				{
					this.c = new double[10];
				}
				if (this.b == this.c.Length)
				{
					double[] array = new double[this.c.Length * 2];
					this.c.CopyTo(array, 0);
					this.c = array;
				}
				this.c[this.b++] = this.a.l8(A_0);
			}
		}

		// Token: 0x060034F1 RID: 13553 RVA: 0x001D3518 File Offset: 0x001D2518
		private double a(double[] A_0)
		{
			double num = 0.0;
			for (int i = 0; i < this.b; i++)
			{
				num += A_0[i];
			}
			return num / (double)this.b;
		}

		// Token: 0x060034F2 RID: 13554 RVA: 0x001D355C File Offset: 0x001D255C
		internal override void mh(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.a.ma(A_0));
		}

		// Token: 0x060034F3 RID: 13555 RVA: 0x001D35A1 File Offset: 0x001D25A1
		internal override void mj()
		{
			this.b++;
			base.a(base.d() + 1);
		}

		// Token: 0x060034F4 RID: 13556 RVA: 0x001D35C4 File Offset: 0x001D25C4
		internal override void mk(Page A_0)
		{
			if (base.e() != A_0)
			{
				this.c = null;
			}
			object[] array = new object[this.b];
			int i = 0;
			while (i < this.b)
			{
				if (!(this.d[0] is DBNull))
				{
					array[i] = this.d[0];
					i++;
				}
				else
				{
					this.b--;
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
			this.b = 0;
			base.a(A_0);
		}

		// Token: 0x060034F5 RID: 13557 RVA: 0x001D3732 File Offset: 0x001D2732
		internal override void ml()
		{
			this.b = 0;
			this.c = null;
		}

		// Token: 0x0400198B RID: 6539
		private new ahq a;

		// Token: 0x0400198C RID: 6540
		private new int b = 0;

		// Token: 0x0400198D RID: 6541
		private double[] c = new double[10];

		// Token: 0x0400198E RID: 6542
		private ArrayList d;

		// Token: 0x0400198F RID: 6543
		private object e = null;
	}
}
