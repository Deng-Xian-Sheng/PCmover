using System;
using ceTe.DynamicPDF.Merger;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B7 RID: 1719
	public class PageInfo
	{
		// Token: 0x06004253 RID: 16979 RVA: 0x00228B77 File Offset: 0x00227B77
		public PageInfo(PageSize size, PageOrientation orientation)
		{
			this.a = new PageDimensions(size, orientation);
		}

		// Token: 0x06004254 RID: 16980 RVA: 0x00228B8F File Offset: 0x00227B8F
		public PageInfo(float width, float height)
		{
			this.a = new PageDimensions(width, height);
		}

		// Token: 0x06004255 RID: 16981 RVA: 0x00228BA7 File Offset: 0x00227BA7
		public PageInfo(PdfPage inputPage)
		{
			this.b = inputPage;
			this.a = inputPage.GetDimensions();
		}

		// Token: 0x06004256 RID: 16982 RVA: 0x00228BC5 File Offset: 0x00227BC5
		public PageInfo(string filePath, int pageNumber)
		{
			this.b = new PdfDocument(filePath).GetPage(pageNumber);
			this.a = this.b.GetDimensions();
		}

		// Token: 0x06004257 RID: 16983 RVA: 0x00228BF4 File Offset: 0x00227BF4
		internal PageDimensions a()
		{
			return this.a;
		}

		// Token: 0x06004258 RID: 16984 RVA: 0x00228C0C File Offset: 0x00227C0C
		internal void a(PageDimensions A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06004259 RID: 16985 RVA: 0x00228C18 File Offset: 0x00227C18
		internal PdfPage b()
		{
			return this.b;
		}

		// Token: 0x040024CA RID: 9418
		private PageDimensions a;

		// Token: 0x040024CB RID: 9419
		private PdfPage b;
	}
}
