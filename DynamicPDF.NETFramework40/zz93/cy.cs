using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000084 RID: 132
	internal class cy : cu
	{
		// Token: 0x06000614 RID: 1556 RVA: 0x00055F7C File Offset: 0x00054F7C
		internal cy(int A_0, int A_1, StructureElement A_2) : base(A_0, A_1)
		{
			this.a = A_2;
			if (A_2 is c5)
			{
				base.b(((c5)A_2).j());
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00055FC4 File Offset: 0x00054FC4
		internal StructureElement a()
		{
			return this.a;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00055FDC File Offset: 0x00054FDC
		internal override bool bb()
		{
			return false;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00055FEF File Offset: 0x00054FEF
		internal override void a9(DocumentWriter A_0, int A_1)
		{
			A_0.WriteReferenceShallow(Convert.ToInt32(A_0.Document.j().f()[this.a]));
		}

		// Token: 0x0400033C RID: 828
		private StructureElement a = null;
	}
}
