using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000840 RID: 2112
	public class NoSplitZone : ReportElement
	{
		// Token: 0x0600552F RID: 21807 RVA: 0x00297170 File Offset: 0x00296170
		internal NoSplitZone(rm A_0, v6 A_1)
		{
			if (x5.c(A_1.a(), A_1.b()))
			{
				this.a = A_1.b();
				this.b = A_1.a();
			}
			else
			{
				this.a = A_1.a();
				this.b = A_1.b();
			}
			A_0.b().DocumentLayout.a(A_1.f0(), this);
		}

		// Token: 0x06005530 RID: 21808 RVA: 0x002971EC File Offset: 0x002961EC
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (A_0.k() == null)
			{
				A_0.a(new x1());
			}
			if (x5.c(this.a, x5.a()) && x5.c(this.b, x5.a()) && this.c != null)
			{
				A_0.k().a(this.a, this.b, this.c);
			}
		}

		// Token: 0x06005531 RID: 21809 RVA: 0x00297270 File Offset: 0x00296270
		internal override void go(short A_0, wx A_1)
		{
			if (this.c == null)
			{
				this.c = new wv();
			}
			this.c.a(A_0, A_1);
		}

		// Token: 0x06005532 RID: 21810 RVA: 0x002972A7 File Offset: 0x002962A7
		internal void a(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005533 RID: 21811 RVA: 0x002972B1 File Offset: 0x002962B1
		internal void b(x5 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005534 RID: 21812 RVA: 0x002972BC File Offset: 0x002962BC
		internal override x5 gm()
		{
			return this.a;
		}

		// Token: 0x06005535 RID: 21813 RVA: 0x002972D4 File Offset: 0x002962D4
		internal override x5 gn()
		{
			return this.b;
		}

		// Token: 0x06005536 RID: 21814 RVA: 0x002972EC File Offset: 0x002962EC
		internal override ushort fk()
		{
			return 61443;
		}

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06005537 RID: 21815 RVA: 0x00297304 File Offset: 0x00296304
		// (set) Token: 0x06005538 RID: 21816 RVA: 0x00297322 File Offset: 0x00296322
		public float Top
		{
			get
			{
				return x5.b(this.a);
			}
			set
			{
				this.a = x5.a(value);
			}
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06005539 RID: 21817 RVA: 0x00297334 File Offset: 0x00296334
		// (set) Token: 0x0600553A RID: 21818 RVA: 0x00297352 File Offset: 0x00296352
		public float Bottom
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x04002D87 RID: 11655
		private x5 a;

		// Token: 0x04002D88 RID: 11656
		private x5 b;

		// Token: 0x04002D89 RID: 11657
		private wv c;
	}
}
