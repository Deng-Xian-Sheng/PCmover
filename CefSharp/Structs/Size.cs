using System;

namespace CefSharp.Structs
{
	// Token: 0x020000AA RID: 170
	public struct Size
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x00008370 File Offset: 0x00006570
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x00008378 File Offset: 0x00006578
		public int Width { get; private set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x00008381 File Offset: 0x00006581
		// (set) Token: 0x06000540 RID: 1344 RVA: 0x00008389 File Offset: 0x00006589
		public int Height { get; private set; }

		// Token: 0x06000541 RID: 1345 RVA: 0x00008392 File Offset: 0x00006592
		public Size(int width, int height)
		{
			this = default(Size);
			this.Width = width;
			this.Height = height;
		}
	}
}
