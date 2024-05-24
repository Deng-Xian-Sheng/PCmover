using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000519 RID: 1305
	internal class ah9 : ahu
	{
		// Token: 0x060034DD RID: 13533 RVA: 0x001D27C2 File Offset: 0x001D17C2
		internal ah9(ahq A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060034DE RID: 13534 RVA: 0x001D27F0 File Offset: 0x001D17F0
		internal override object me()
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

		// Token: 0x060034DF RID: 13535 RVA: 0x001D28E4 File Offset: 0x001D18E4
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

		// Token: 0x060034E0 RID: 13536 RVA: 0x001D2A18 File Offset: 0x001D1A18
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

		// Token: 0x060034E1 RID: 13537 RVA: 0x001D2B00 File Offset: 0x001D1B00
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

		// Token: 0x060034E2 RID: 13538 RVA: 0x001D2C58 File Offset: 0x001D1C58
		private void a(object[] A_0)
		{
			this.c = 0;
			this.b = new decimal[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] != null)
				{
					this.b[this.c] = ahq.e(A_0[i]);
					this.c++;
				}
			}
		}

		// Token: 0x060034E3 RID: 13539 RVA: 0x001D2CC8 File Offset: 0x001D1CC8
		internal override void mi(LayoutWriter A_0)
		{
			if (!this.a.l4(A_0))
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
				this.b[this.c++] = this.a.l7(A_0);
			}
		}

		// Token: 0x060034E4 RID: 13540 RVA: 0x001D2D78 File Offset: 0x001D1D78
		internal override void mh(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.a.ma(A_0));
		}

		// Token: 0x060034E5 RID: 13541 RVA: 0x001D2DBD File Offset: 0x001D1DBD
		internal override void mj()
		{
			this.c++;
			base.a(base.d() + 1);
		}

		// Token: 0x060034E6 RID: 13542 RVA: 0x001D2DE0 File Offset: 0x001D1DE0
		internal override void mk(Page A_0)
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

		// Token: 0x060034E7 RID: 13543 RVA: 0x001D2F4E File Offset: 0x001D1F4E
		internal override void ml()
		{
			this.c = 0;
			this.b = null;
		}

		// Token: 0x04001985 RID: 6533
		private new ahq a;

		// Token: 0x04001986 RID: 6534
		private new decimal[] b = new decimal[10];

		// Token: 0x04001987 RID: 6535
		private int c = 0;

		// Token: 0x04001988 RID: 6536
		private ArrayList d;

		// Token: 0x04001989 RID: 6537
		private object e = null;
	}
}
