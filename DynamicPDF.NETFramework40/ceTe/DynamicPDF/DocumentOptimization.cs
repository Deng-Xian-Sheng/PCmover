using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200065D RID: 1629
	public class DocumentOptimization
	{
		// Token: 0x06003D8F RID: 15759 RVA: 0x00215AFE File Offset: 0x00214AFE
		public DocumentOptimization()
		{
			this.a = true;
		}

		// Token: 0x06003D90 RID: 15760 RVA: 0x00215B10 File Offset: 0x00214B10
		public DocumentOptimization(bool images)
		{
			this.a = images;
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06003D91 RID: 15761 RVA: 0x00215B24 File Offset: 0x00214B24
		// (set) Token: 0x06003D92 RID: 15762 RVA: 0x00215B3C File Offset: 0x00214B3C
		public bool Images
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x04002131 RID: 8497
		private bool a;
	}
}
