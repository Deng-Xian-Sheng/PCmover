using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000507 RID: 1287
	internal class ahs
	{
		// Token: 0x06003465 RID: 13413 RVA: 0x001CF6BD File Offset: 0x001CE6BD
		internal ahs()
		{
		}

		// Token: 0x06003466 RID: 13414 RVA: 0x001CF6EC File Offset: 0x001CE6EC
		internal void a(LayoutWriter A_0)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				if (string.Compare(a.a.b(), "CurrentPage", true) == 0 || string.Compare(a.a.b(), "PreviousPage", true) == 0)
				{
					A_0.m4().a(a.a).mh(A_0);
				}
				else
				{
					A_0.m4().a(a.a).mi(A_0);
				}
			}
		}

		// Token: 0x06003467 RID: 13415 RVA: 0x001CF78C File Offset: 0x001CE78C
		internal void b(LayoutWriter A_0)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				if (!a.a.d())
				{
					A_0.m4().a(a.a).b();
				}
			}
		}

		// Token: 0x06003468 RID: 13416 RVA: 0x001CF7E0 File Offset: 0x001CE7E0
		internal void c(LayoutWriter A_0)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				if (a.a.d())
				{
					A_0.m4().a(a.a).b();
				}
			}
		}

		// Token: 0x06003469 RID: 13417 RVA: 0x001CF834 File Offset: 0x001CE834
		internal void d(LayoutWriter A_0)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				A_0.m4().a(a.a).a(string.Compare(a.a.b(), "PreviousPage", true) == 0);
			}
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x001CF890 File Offset: 0x001CE890
		internal void a(HybridDictionary A_0, Page A_1)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				((ahu)A_0[a.a]).a(string.Compare(a.a.b(), "PreviousPage", true) == 0, A_1);
			}
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x001CF8EC File Offset: 0x001CE8EC
		internal void a(LayoutWriter A_0, int A_1)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				ahu ahu = A_0.m4().a(a.a);
				if (A_1 == ahu.d())
				{
					ahu.mj();
				}
			}
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x001CF944 File Offset: 0x001CE944
		internal void a(int A_0, HybridDictionary A_1)
		{
			for (ahs.a a = this.a; a != null; a = a.b)
			{
				ahu ahu = (ahu)A_1[a.a];
				if (A_0 == ahu.d())
				{
					ahu.mj();
				}
			}
		}

		// Token: 0x0600346D RID: 13421 RVA: 0x001CF99C File Offset: 0x001CE99C
		internal ahs.a a()
		{
			return this.a;
		}

		// Token: 0x0600346E RID: 13422 RVA: 0x001CF9B4 File Offset: 0x001CE9B4
		internal int b()
		{
			return this.c;
		}

		// Token: 0x0600346F RID: 13423 RVA: 0x001CF9CC File Offset: 0x001CE9CC
		internal void a(ahr A_0)
		{
			if (string.Compare(A_0.b(), "CurrentPage", true) == 0 || string.Compare(A_0.b(), "PreviousPage", true) == 0)
			{
				this.d = true;
			}
			if (this.b == null)
			{
				this.a = (this.b = new ahs.a(A_0));
			}
			else
			{
				this.b = (this.b.b = new ahs.a(A_0));
			}
			this.c++;
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x001CFA68 File Offset: 0x001CEA68
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x06003471 RID: 13425 RVA: 0x001CFA80 File Offset: 0x001CEA80
		internal SubReport d()
		{
			return this.e;
		}

		// Token: 0x06003472 RID: 13426 RVA: 0x001CFA98 File Offset: 0x001CEA98
		internal void a(SubReport A_0)
		{
			this.e = A_0;
		}

		// Token: 0x04001952 RID: 6482
		private ahs.a a = null;

		// Token: 0x04001953 RID: 6483
		private ahs.a b = null;

		// Token: 0x04001954 RID: 6484
		private int c = 0;

		// Token: 0x04001955 RID: 6485
		private bool d = false;

		// Token: 0x04001956 RID: 6486
		private SubReport e = null;

		// Token: 0x02000508 RID: 1288
		internal class a
		{
			// Token: 0x06003473 RID: 13427 RVA: 0x001CFAA2 File Offset: 0x001CEAA2
			internal a(ahr A_0)
			{
				this.a = A_0;
				this.b = null;
			}

			// Token: 0x04001957 RID: 6487
			internal ahr a;

			// Token: 0x04001958 RID: 6488
			internal ahs.a b;
		}
	}
}
