using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002DA RID: 730
	internal abstract class s1
	{
		// Token: 0x060020E0 RID: 8416 RVA: 0x00141BA0 File Offset: 0x00140BA0
		internal s1()
		{
		}

		// Token: 0x060020E1 RID: 8417 RVA: 0x00141BCC File Offset: 0x00140BCC
		internal vf a()
		{
			return this.a;
		}

		// Token: 0x060020E2 RID: 8418 RVA: 0x00141BE4 File Offset: 0x00140BE4
		internal void b()
		{
			object a_ = this.fo();
			this.a.a(a_);
			this.fv();
		}

		// Token: 0x060020E3 RID: 8419 RVA: 0x00141C0D File Offset: 0x00140C0D
		internal virtual void fv()
		{
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x00141C10 File Offset: 0x00140C10
		internal void a(bool A_0)
		{
			object a_ = this.fp(A_0);
			this.a.b(a_);
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x00141C34 File Offset: 0x00140C34
		internal virtual object fp(bool A_0)
		{
			return 0;
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x00141C4C File Offset: 0x00140C4C
		internal void a(bool A_0, Page A_1)
		{
			object a_ = this.fq(A_0, A_1);
			this.a.b(a_);
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x00141C70 File Offset: 0x00140C70
		internal virtual object fq(bool A_0, Page A_1)
		{
			return 0;
		}

		// Token: 0x060020E8 RID: 8424 RVA: 0x00141C88 File Offset: 0x00140C88
		internal object a(bool A_0, Page A_1, ref object A_2)
		{
			object result = 0;
			if (this.c() != null && this.c().Count != 0 && this.c()[0] != null)
			{
				if (A_0)
				{
					if (A_1 != this.d)
					{
						if (this.e)
						{
							A_2 = 0;
						}
						if (this.c().Count > 1 && !this.e)
						{
							A_2 = this.c()[0];
							this.c().RemoveAt(0);
						}
					}
					this.d = A_1;
					this.e = false;
					return A_2;
				}
				if (A_1 != this.d)
				{
					if (this.c().Count > 1 && !this.e)
					{
						this.c().RemoveAt(0);
					}
				}
				result = this.c()[0];
				this.d = A_1;
				this.e = false;
			}
			return result;
		}

		// Token: 0x060020E9 RID: 8425
		internal abstract void fs(LayoutWriter A_0);

		// Token: 0x060020EA RID: 8426
		internal abstract object fo();

		// Token: 0x060020EB RID: 8427 RVA: 0x00141DA5 File Offset: 0x00140DA5
		internal virtual void fr(LayoutWriter A_0)
		{
		}

		// Token: 0x060020EC RID: 8428 RVA: 0x00141DA8 File Offset: 0x00140DA8
		internal virtual void ft()
		{
		}

		// Token: 0x060020ED RID: 8429 RVA: 0x00141DAC File Offset: 0x00140DAC
		internal ArrayList c()
		{
			ArrayList result;
			if (this.b == null)
			{
				this.b = new ArrayList(2);
				result = this.b;
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x060020EE RID: 8430 RVA: 0x00141DEB File Offset: 0x00140DEB
		internal virtual void fu(Page A_0)
		{
		}

		// Token: 0x060020EF RID: 8431 RVA: 0x00141DF0 File Offset: 0x00140DF0
		internal static object[] a(object[] A_0)
		{
			object[] array = new object[A_0.Length - 1];
			Array.Copy(A_0, 1, array, 0, array.Length);
			A_0 = null;
			return array;
		}

		// Token: 0x060020F0 RID: 8432 RVA: 0x00141E20 File Offset: 0x00140E20
		internal int d()
		{
			return this.c;
		}

		// Token: 0x060020F1 RID: 8433 RVA: 0x00141E38 File Offset: 0x00140E38
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x00141E44 File Offset: 0x00140E44
		internal Page e()
		{
			return this.d;
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x00141E5C File Offset: 0x00140E5C
		internal void a(Page A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x00141E68 File Offset: 0x00140E68
		internal bool f()
		{
			return this.e;
		}

		// Token: 0x060020F5 RID: 8437 RVA: 0x00141E80 File Offset: 0x00140E80
		internal void b(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x04000E69 RID: 3689
		private vf a = new vf();

		// Token: 0x04000E6A RID: 3690
		private ArrayList b;

		// Token: 0x04000E6B RID: 3691
		private int c = 0;

		// Token: 0x04000E6C RID: 3692
		private Page d = null;

		// Token: 0x04000E6D RID: 3693
		private bool e = true;
	}
}
