using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000697 RID: 1687
	public class Template
	{
		// Token: 0x06004000 RID: 16384 RVA: 0x00220540 File Offset: 0x0021F540
		public virtual void Draw(PageWriter writer)
		{
			writer.Write_q_(true);
			this.a.Draw(writer);
			writer.Write_Q(true);
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06004001 RID: 16385 RVA: 0x00220560 File Offset: 0x0021F560
		public Group Elements
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06004002 RID: 16386 RVA: 0x00220578 File Offset: 0x0021F578
		public virtual bool HasPageElements(int pageNumber)
		{
			return this.a.Count > 0;
		}

		// Token: 0x06004003 RID: 16387 RVA: 0x00220598 File Offset: 0x0021F598
		internal virtual int j2()
		{
			return this.b;
		}

		// Token: 0x0400238D RID: 9101
		private Group a = new Group();

		// Token: 0x0400238E RID: 9102
		private int b = 0;
	}
}
