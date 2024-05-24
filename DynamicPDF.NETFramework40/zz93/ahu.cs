using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200050A RID: 1290
	internal abstract class ahu
	{
		// Token: 0x06003477 RID: 13431 RVA: 0x001CFC6C File Offset: 0x001CEC6C
		internal ahu()
		{
		}

		// Token: 0x06003478 RID: 13432 RVA: 0x001CFC98 File Offset: 0x001CEC98
		internal aki a()
		{
			return this.a;
		}

		// Token: 0x06003479 RID: 13433 RVA: 0x001CFCB0 File Offset: 0x001CECB0
		internal void b()
		{
			object a_ = this.me();
			this.a.a(a_);
			this.ml();
		}

		// Token: 0x0600347A RID: 13434 RVA: 0x001CFCD9 File Offset: 0x001CECD9
		internal virtual void ml()
		{
		}

		// Token: 0x0600347B RID: 13435 RVA: 0x001CFCDC File Offset: 0x001CECDC
		internal void a(bool A_0)
		{
			object a_ = this.mf(A_0);
			this.a.b(a_);
		}

		// Token: 0x0600347C RID: 13436 RVA: 0x001CFD00 File Offset: 0x001CED00
		internal virtual object mf(bool A_0)
		{
			return 0;
		}

		// Token: 0x0600347D RID: 13437 RVA: 0x001CFD18 File Offset: 0x001CED18
		internal void a(bool A_0, Page A_1)
		{
			object a_ = this.mg(A_0, A_1);
			this.a.b(a_);
		}

		// Token: 0x0600347E RID: 13438 RVA: 0x001CFD3C File Offset: 0x001CED3C
		internal virtual object mg(bool A_0, Page A_1)
		{
			return 0;
		}

		// Token: 0x0600347F RID: 13439 RVA: 0x001CFD54 File Offset: 0x001CED54
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

		// Token: 0x06003480 RID: 13440
		internal abstract void mi(LayoutWriter A_0);

		// Token: 0x06003481 RID: 13441
		internal abstract object me();

		// Token: 0x06003482 RID: 13442 RVA: 0x001CFE71 File Offset: 0x001CEE71
		internal virtual void mh(LayoutWriter A_0)
		{
		}

		// Token: 0x06003483 RID: 13443 RVA: 0x001CFE74 File Offset: 0x001CEE74
		internal virtual void mj()
		{
		}

		// Token: 0x06003484 RID: 13444 RVA: 0x001CFE78 File Offset: 0x001CEE78
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

		// Token: 0x06003485 RID: 13445 RVA: 0x001CFEB7 File Offset: 0x001CEEB7
		internal virtual void mk(Page A_0)
		{
		}

		// Token: 0x06003486 RID: 13446 RVA: 0x001CFEBC File Offset: 0x001CEEBC
		internal static object[] a(object[] A_0)
		{
			object[] array = new object[A_0.Length - 1];
			Array.Copy(A_0, 1, array, 0, array.Length);
			A_0 = null;
			return array;
		}

		// Token: 0x06003487 RID: 13447 RVA: 0x001CFEEC File Offset: 0x001CEEEC
		internal int d()
		{
			return this.c;
		}

		// Token: 0x06003488 RID: 13448 RVA: 0x001CFF04 File Offset: 0x001CEF04
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003489 RID: 13449 RVA: 0x001CFF10 File Offset: 0x001CEF10
		internal Page e()
		{
			return this.d;
		}

		// Token: 0x0600348A RID: 13450 RVA: 0x001CFF28 File Offset: 0x001CEF28
		internal void a(Page A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600348B RID: 13451 RVA: 0x001CFF34 File Offset: 0x001CEF34
		internal bool f()
		{
			return this.e;
		}

		// Token: 0x0600348C RID: 13452 RVA: 0x001CFF4C File Offset: 0x001CEF4C
		internal void b(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0400195A RID: 6490
		private aki a = new aki();

		// Token: 0x0400195B RID: 6491
		private ArrayList b;

		// Token: 0x0400195C RID: 6492
		private int c = 0;

		// Token: 0x0400195D RID: 6493
		private Page d = null;

		// Token: 0x0400195E RID: 6494
		private bool e = true;
	}
}
