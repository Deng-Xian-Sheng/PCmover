using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002EB RID: 747
	internal class ti : s1
	{
		// Token: 0x06002154 RID: 8532 RVA: 0x00145044 File Offset: 0x00144044
		internal ti(q7 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002155 RID: 8533 RVA: 0x00145074 File Offset: 0x00144074
		internal override object fo()
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

		// Token: 0x06002156 RID: 8534 RVA: 0x00145100 File Offset: 0x00144100
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

		// Token: 0x06002157 RID: 8535 RVA: 0x001451E8 File Offset: 0x001441E8
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

		// Token: 0x06002158 RID: 8536 RVA: 0x00145340 File Offset: 0x00144340
		private void a(object[] A_0)
		{
			this.b = 0;
			this.c = new double[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] != null)
				{
					this.c[this.b] = q7.d(A_0[i]);
					this.b++;
				}
			}
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x001453A8 File Offset: 0x001443A8
		internal override void fs(LayoutWriter A_0)
		{
			if (!this.a.eq(A_0))
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
				this.c[this.b++] = this.a.ek(A_0);
			}
		}

		// Token: 0x0600215A RID: 8538 RVA: 0x0014544C File Offset: 0x0014444C
		private double a(double[] A_0)
		{
			double num = 0.0;
			for (int i = 0; i < this.b; i++)
			{
				num += A_0[i];
			}
			return num / (double)this.b;
		}

		// Token: 0x0600215B RID: 8539 RVA: 0x00145490 File Offset: 0x00144490
		internal override void fr(LayoutWriter A_0)
		{
			if (this.d == null)
			{
				this.d = new ArrayList(10);
			}
			this.d.Add(this.a.es(A_0));
		}

		// Token: 0x0600215C RID: 8540 RVA: 0x001454D5 File Offset: 0x001444D5
		internal override void ft()
		{
			this.b++;
			base.a(base.d() + 1);
		}

		// Token: 0x0600215D RID: 8541 RVA: 0x001454F8 File Offset: 0x001444F8
		internal override void fu(Page A_0)
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

		// Token: 0x0600215E RID: 8542 RVA: 0x00145666 File Offset: 0x00144666
		internal override void fv()
		{
			this.b = 0;
			this.c = null;
		}

		// Token: 0x04000E9A RID: 3738
		private new q7 a;

		// Token: 0x04000E9B RID: 3739
		private new int b = 0;

		// Token: 0x04000E9C RID: 3740
		private double[] c = new double[10];

		// Token: 0x04000E9D RID: 3741
		private ArrayList d;

		// Token: 0x04000E9E RID: 3742
		private object e = null;
	}
}
