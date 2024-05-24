using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x020002D7 RID: 727
	internal class sz
	{
		// Token: 0x060020CE RID: 8398 RVA: 0x001415F1 File Offset: 0x001405F1
		internal sz()
		{
		}

		// Token: 0x060020CF RID: 8399 RVA: 0x00141620 File Offset: 0x00140620
		internal void a(LayoutWriter A_0)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				if (string.Compare(a.a.b(), "CurrentPage", true) == 0 || string.Compare(a.a.b(), "PreviousPage", true) == 0)
				{
					A_0.e1().a(a.a).fr(A_0);
				}
				else
				{
					A_0.e1().a(a.a).fs(A_0);
				}
			}
		}

		// Token: 0x060020D0 RID: 8400 RVA: 0x001416C0 File Offset: 0x001406C0
		internal void b(LayoutWriter A_0)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				if (!a.a.d())
				{
					A_0.e1().a(a.a).b();
				}
			}
		}

		// Token: 0x060020D1 RID: 8401 RVA: 0x00141714 File Offset: 0x00140714
		internal void c(LayoutWriter A_0)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				if (a.a.d())
				{
					A_0.e1().a(a.a).b();
				}
			}
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x00141768 File Offset: 0x00140768
		internal void d(LayoutWriter A_0)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				A_0.e1().a(a.a).a(string.Compare(a.a.b(), "PreviousPage", true) == 0);
			}
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x001417C4 File Offset: 0x001407C4
		internal void a(HybridDictionary A_0, Page A_1)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				((s1)A_0[a.a]).a(string.Compare(a.a.b(), "PreviousPage", true) == 0, A_1);
			}
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x00141820 File Offset: 0x00140820
		internal void a(LayoutWriter A_0, int A_1)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				s1 s = A_0.e1().a(a.a);
				if (A_1 == s.d())
				{
					s.ft();
				}
			}
		}

		// Token: 0x060020D5 RID: 8405 RVA: 0x00141878 File Offset: 0x00140878
		internal void a(int A_0, HybridDictionary A_1)
		{
			for (sz.a a = this.a; a != null; a = a.b)
			{
				s1 s = (s1)A_1[a.a];
				if (A_0 == s.d())
				{
					s.ft();
				}
			}
		}

		// Token: 0x060020D6 RID: 8406 RVA: 0x001418D0 File Offset: 0x001408D0
		internal sz.a a()
		{
			return this.a;
		}

		// Token: 0x060020D7 RID: 8407 RVA: 0x001418E8 File Offset: 0x001408E8
		internal int b()
		{
			return this.c;
		}

		// Token: 0x060020D8 RID: 8408 RVA: 0x00141900 File Offset: 0x00140900
		internal void a(sy A_0)
		{
			if (string.Compare(A_0.b(), "CurrentPage", true) == 0 || string.Compare(A_0.b(), "PreviousPage", true) == 0)
			{
				this.d = true;
			}
			if (this.b == null)
			{
				this.a = (this.b = new sz.a(A_0));
			}
			else
			{
				this.b = (this.b.b = new sz.a(A_0));
			}
			this.c++;
		}

		// Token: 0x060020D9 RID: 8409 RVA: 0x0014199C File Offset: 0x0014099C
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x001419B4 File Offset: 0x001409B4
		internal SubReport d()
		{
			return this.e;
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x001419CC File Offset: 0x001409CC
		internal void a(SubReport A_0)
		{
			this.e = A_0;
		}

		// Token: 0x04000E61 RID: 3681
		private sz.a a = null;

		// Token: 0x04000E62 RID: 3682
		private sz.a b = null;

		// Token: 0x04000E63 RID: 3683
		private int c = 0;

		// Token: 0x04000E64 RID: 3684
		private bool d = false;

		// Token: 0x04000E65 RID: 3685
		private SubReport e = null;

		// Token: 0x020002D8 RID: 728
		internal class a
		{
			// Token: 0x060020DC RID: 8412 RVA: 0x001419D6 File Offset: 0x001409D6
			internal a(sy A_0)
			{
				this.a = A_0;
				this.b = null;
			}

			// Token: 0x04000E66 RID: 3686
			internal sy a;

			// Token: 0x04000E67 RID: 3687
			internal sz.a b;
		}
	}
}
