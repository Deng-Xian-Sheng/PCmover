using System;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x0200001F RID: 31
	internal struct Margins
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00006168 File Offset: 0x00004368
		public Margins(bool fullWindow)
		{
			this.LeftWidth = (this.RightWidth = (this.TopHeight = (this.BottomHeight = (fullWindow ? -1 : 0))));
		}

		// Token: 0x04000048 RID: 72
		public int LeftWidth;

		// Token: 0x04000049 RID: 73
		public int RightWidth;

		// Token: 0x0400004A RID: 74
		public int TopHeight;

		// Token: 0x0400004B RID: 75
		public int BottomHeight;
	}
}
