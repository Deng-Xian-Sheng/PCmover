using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200065B RID: 1627
	public class GoToAction : OutlineAnnotationAction
	{
		// Token: 0x06003D87 RID: 15751 RVA: 0x002159C0 File Offset: 0x002149C0
		public GoToAction(int pageNumber, PageZoom zoom)
		{
			this.a = zoom;
			this.b = pageNumber;
		}

		// Token: 0x06003D88 RID: 15752 RVA: 0x002159DC File Offset: 0x002149DC
		internal new PageZoom a()
		{
			return this.a;
		}

		// Token: 0x06003D89 RID: 15753 RVA: 0x002159F4 File Offset: 0x002149F4
		internal new int b()
		{
			return this.b;
		}

		// Token: 0x06003D8A RID: 15754 RVA: 0x00215A0C File Offset: 0x00214A0C
		public override void Draw(DocumentWriter writer)
		{
			writer.Document.RequireLicense(3);
			writer.WriteReferenceUnique(new bo(this));
		}

		// Token: 0x0400212C RID: 8492
		private new PageZoom a;

		// Token: 0x0400212D RID: 8493
		private new int b;
	}
}
