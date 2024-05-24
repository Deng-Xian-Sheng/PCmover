using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000938 RID: 2360
	public class ReportHeader
	{
		// Token: 0x06005FFC RID: 24572 RVA: 0x0035F9AC File Offset: 0x0035E9AC
		internal ReportHeader(alo A_0, ak3 A_1)
		{
			this.a = A_1.mv();
			this.b = A_1.mx();
			if (A_1.b() != null && A_1.b().a() > 0)
			{
				this.c = new LayoutElementList(A_0, A_1.b());
			}
			A_0.b().DocumentLayout.a(this.a, this);
			if (A_1.a() != null)
			{
				this.d = new aho(A_0, A_1.a());
			}
		}

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x06005FFD RID: 24573 RVA: 0x0035FA58 File Offset: 0x0035EA58
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x06005FFE RID: 24574 RVA: 0x0035FA78 File Offset: 0x0035EA78
		internal LayoutElementList a()
		{
			return this.c;
		}

		// Token: 0x06005FFF RID: 24575 RVA: 0x0035FA90 File Offset: 0x0035EA90
		internal aho b()
		{
			return this.d;
		}

		// Token: 0x06006000 RID: 24576 RVA: 0x0035FAA8 File Offset: 0x0035EAA8
		internal string c()
		{
			return this.a;
		}

		// Token: 0x04003167 RID: 12647
		private string a;

		// Token: 0x04003168 RID: 12648
		private x5 b;

		// Token: 0x04003169 RID: 12649
		private LayoutElementList c = null;

		// Token: 0x0400316A RID: 12650
		private aho d = null;
	}
}
