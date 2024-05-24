using System;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200080D RID: 2061
	public abstract class DocumentLayoutPart
	{
		// Token: 0x0600536B RID: 21355 RVA: 0x00291BA0 File Offset: 0x00290BA0
		internal DocumentLayoutPart(DocumentLayout A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x0600536C RID: 21356 RVA: 0x00291BB4 File Offset: 0x00290BB4
		public DocumentLayout DocumentLayout
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x0600536D RID: 21357
		internal abstract vj ex();

		// Token: 0x0600536E RID: 21358
		internal abstract bool ey();

		// Token: 0x0600536F RID: 21359
		internal abstract void ew(wu A_0);

		// Token: 0x06005370 RID: 21360
		internal abstract void ev();

		// Token: 0x04002CBB RID: 11451
		private DocumentLayout a;
	}
}
