using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002E5 RID: 741
	internal class tc : s1
	{
		// Token: 0x0600212D RID: 8493 RVA: 0x0014389A File Offset: 0x0014289A
		internal tc(q7 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600212E RID: 8494 RVA: 0x001438C8 File Offset: 0x001428C8
		internal override object fo()
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

		// Token: 0x0600212F RID: 8495 RVA: 0x00143984 File Offset: 0x00142984
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

		// Token: 0x06002130 RID: 8496 RVA: 0x00143A9C File Offset: 0x00142A9C
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

		// Token: 0x06002131 RID: 8497 RVA: 0x00143B84 File Offset: 0x00142B84
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

		// Token: 0x06002132 RID: 8498 RVA: 0x00143CDC File Offset: 0x00142CDC
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

		// Token: 0x06002133 RID: 8499 RVA: 0x00143D4C File Offset: 0x00142D4C
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

		// Token: 0x06002134 RID: 8500 RVA: 0x00143DFC File Offset: 0x00142DFC
		internal override void fr(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.a.es(A_0));
		}

		// Token: 0x06002135 RID: 8501 RVA: 0x00143E41 File Offset: 0x00142E41
		internal override void ft()
		{
			this.c++;
			base.a(base.d() + 1);
		}

		// Token: 0x06002136 RID: 8502 RVA: 0x00143E64 File Offset: 0x00142E64
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

		// Token: 0x06002137 RID: 8503 RVA: 0x00143FD2 File Offset: 0x00142FD2
		internal override void fv()
		{
			this.c = 0;
			this.b = null;
		}

		// Token: 0x04000E89 RID: 3721
		private new q7 a;

		// Token: 0x04000E8A RID: 3722
		private new decimal[] b = new decimal[10];

		// Token: 0x04000E8B RID: 3723
		private int c = 0;

		// Token: 0x04000E8C RID: 3724
		private ArrayList d;

		// Token: 0x04000E8D RID: 3725
		private object e = null;
	}
}
