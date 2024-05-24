using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200092B RID: 2347
	public abstract class DocumentLayoutPart
	{
		// Token: 0x06005F7E RID: 24446 RVA: 0x0035D99E File Offset: 0x0035C99E
		internal DocumentLayoutPart(DocumentLayout A_0)
		{
			this.a = A_0;
		}

		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x06005F7F RID: 24447 RVA: 0x0035D9B0 File Offset: 0x0035C9B0
		public DocumentLayout DocumentLayout
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005F80 RID: 24448
		internal abstract akm m1();

		// Token: 0x06005F81 RID: 24449
		internal abstract bool m2();

		// Token: 0x06005F82 RID: 24450
		internal abstract void m0(alr A_0);

		// Token: 0x06005F83 RID: 24451
		internal abstract void mz();

		// Token: 0x04003120 RID: 12576
		private DocumentLayout a;
	}
}
