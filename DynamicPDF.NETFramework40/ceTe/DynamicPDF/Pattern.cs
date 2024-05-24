using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200064F RID: 1615
	public abstract class Pattern : Color
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06003D2D RID: 15661 RVA: 0x00213BDC File Offset: 0x00212BDC
		public override ColorSpace ColorSpace
		{
			get
			{
				return ColorSpace.Pattern;
			}
		}
	}
}
