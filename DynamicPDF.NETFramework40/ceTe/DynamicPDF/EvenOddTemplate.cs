using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000698 RID: 1688
	public class EvenOddTemplate : Template
	{
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06004005 RID: 16389 RVA: 0x002205D4 File Offset: 0x0021F5D4
		public Group EvenElements
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06004006 RID: 16390 RVA: 0x002205EC File Offset: 0x0021F5EC
		public Group OddElements
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06004007 RID: 16391 RVA: 0x00220604 File Offset: 0x0021F604
		public override void Draw(PageWriter writer)
		{
			base.Elements.Draw(writer);
			if (writer.PageNumber % 2 == 0)
			{
				this.a.Draw(writer);
			}
			else
			{
				this.b.Draw(writer);
			}
		}

		// Token: 0x06004008 RID: 16392 RVA: 0x00220650 File Offset: 0x0021F650
		public override bool HasPageElements(int pageNumber)
		{
			bool result;
			if (base.Elements.Count > 0)
			{
				result = true;
			}
			else if (pageNumber % 2 == 0)
			{
				result = (this.a.Count > 0);
			}
			else
			{
				result = (this.b.Count > 0);
			}
			return result;
		}

		// Token: 0x0400238F RID: 9103
		private Group a = new Group();

		// Token: 0x04002390 RID: 9104
		private Group b = new Group();
	}
}
