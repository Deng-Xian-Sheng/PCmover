using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200095B RID: 2395
	public class ImageLaidOutEventArgs : EventArgs
	{
		// Token: 0x0600614D RID: 24909 RVA: 0x00363084 File Offset: 0x00362084
		internal ImageLaidOutEventArgs(LayoutWriter A_0, Image A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x0600614E RID: 24910 RVA: 0x003630A0 File Offset: 0x003620A0
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x0600614F RID: 24911 RVA: 0x003630B8 File Offset: 0x003620B8
		public Image Image
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003233 RID: 12851
		private LayoutWriter a;

		// Token: 0x04003234 RID: 12852
		private Image b;
	}
}
