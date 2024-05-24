using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000515 RID: 1301
	internal class ah5 : ahu
	{
		// Token: 0x060034C4 RID: 13508 RVA: 0x001D1966 File Offset: 0x001D0966
		internal ah5(ahq A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060034C5 RID: 13509 RVA: 0x001D1994 File Offset: 0x001D0994
		internal override object me()
		{
			this.a(0, this.c - 1, this.b);
			object result;
			if (this.c == 0)
			{
				result = DBNull.Value;
			}
			else if (this.c % 2 == 0)
			{
				result = (this.b[this.c / 2 - 1] + this.b[this.c / 2]) / 2m;
			}
			else
			{
				result = this.b[this.c / 2];
			}
			return result;
		}

		// Token: 0x060034C6 RID: 13510 RVA: 0x001D1A50 File Offset: 0x001D0A50
		private void a(int A_0, int A_1, decimal[] A_2)
		{
			if (A_1 > A_0)
			{
				int i = A_0;
				int num = A_1;
				int num2 = (A_0 + A_1) / 2;
				decimal num3 = A_2[num2];
				while (i <= num)
				{
					while (A_2[i] < num3 && i < A_1)
					{
						i++;
					}
					while (num3 < A_2[num] && num > A_0)
					{
						num--;
					}
					if (i <= num)
					{
						decimal num4 = A_2[i];
						A_2[i] = A_2[num];
						A_2[num] = num4;
						i++;
						num--;
					}
				}
				if (A_0 < num)
				{
					this.a(A_0, num, A_2);
				}
				if (i < A_1)
				{
					this.a(i, A_1, A_2);
				}
			}
		}

		// Token: 0x060034C7 RID: 13511 RVA: 0x001D1B68 File Offset: 0x001D0B68
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

		// Token: 0x060034C8 RID: 13512 RVA: 0x001D1C50 File Offset: 0x001D0C50
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

		// Token: 0x060034C9 RID: 13513 RVA: 0x001D1DA8 File Offset: 0x001D0DA8
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

		// Token: 0x060034CA RID: 13514 RVA: 0x001D1E18 File Offset: 0x001D0E18
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

		// Token: 0x060034CB RID: 13515 RVA: 0x001D1EC8 File Offset: 0x001D0EC8
		internal override void mh(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.a.ma(A_0));
		}

		// Token: 0x060034CC RID: 13516 RVA: 0x001D1F0D File Offset: 0x001D0F0D
		internal override void mj()
		{
			this.c++;
			base.a(base.d() + 1);
		}

		// Token: 0x060034CD RID: 13517 RVA: 0x001D1F30 File Offset: 0x001D0F30
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

		// Token: 0x060034CE RID: 13518 RVA: 0x001D209E File Offset: 0x001D109E
		internal override void ml()
		{
			this.c = 0;
			this.b = null;
		}

		// Token: 0x0400197A RID: 6522
		private new ahq a;

		// Token: 0x0400197B RID: 6523
		private new decimal[] b = new decimal[10];

		// Token: 0x0400197C RID: 6524
		private int c = 0;

		// Token: 0x0400197D RID: 6525
		private ArrayList d;

		// Token: 0x0400197E RID: 6526
		private object e = null;
	}
}
