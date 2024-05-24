using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000967 RID: 2407
	public class RectangleLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006177 RID: 24951 RVA: 0x0036324C File Offset: 0x0036224C
		internal RectangleLaidOutEventArgs(LayoutWriter A_0, Rectangle A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x06006178 RID: 24952 RVA: 0x00363268 File Offset: 0x00362268
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x06006179 RID: 24953 RVA: 0x00363280 File Offset: 0x00362280
		public Rectangle Rectangle
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x0400323F RID: 12863
		private LayoutWriter a;

		// Token: 0x04003240 RID: 12864
		private Rectangle b;
	}
}
