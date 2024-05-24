using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000951 RID: 2385
	public class PlaceHolderLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006129 RID: 24873 RVA: 0x00362F1A File Offset: 0x00361F1A
		internal PlaceHolderLaidOutEventArgs(LayoutWriter A_0, ContentArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x0600612A RID: 24874 RVA: 0x00362F34 File Offset: 0x00361F34
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x0600612B RID: 24875 RVA: 0x00362F4C File Offset: 0x00361F4C
		public ContentArea ContentArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x0400322A RID: 12842
		private LayoutWriter a;

		// Token: 0x0400322B RID: 12843
		private ContentArea b;
	}
}
