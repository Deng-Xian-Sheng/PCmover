using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200051F RID: 1311
	internal abstract class aif
	{
		// Token: 0x06003506 RID: 13574 RVA: 0x001D3CBE File Offset: 0x001D2CBE
		internal aif(rv A_0, akk A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06003507 RID: 13575
		internal abstract void mm(LayoutWriter A_0, bool A_1);

		// Token: 0x06003508 RID: 13576 RVA: 0x001D3CD8 File Offset: 0x001D2CD8
		internal aif a()
		{
			return this.c;
		}

		// Token: 0x06003509 RID: 13577 RVA: 0x001D3CF0 File Offset: 0x001D2CF0
		internal void a(aif A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600350A RID: 13578 RVA: 0x001D3CFC File Offset: 0x001D2CFC
		internal rv b()
		{
			return this.a;
		}

		// Token: 0x0600350B RID: 13579 RVA: 0x001D3D14 File Offset: 0x001D2D14
		internal akk c()
		{
			return this.b;
		}

		// Token: 0x04001996 RID: 6550
		private rv a;

		// Token: 0x04001997 RID: 6551
		private akk b;

		// Token: 0x04001998 RID: 6552
		private aif c;
	}
}
