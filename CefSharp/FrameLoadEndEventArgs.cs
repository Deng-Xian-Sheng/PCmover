using System;

namespace CefSharp
{
	// Token: 0x02000046 RID: 70
	public class FrameLoadEndEventArgs : EventArgs
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00003303 File Offset: 0x00001503
		public FrameLoadEndEventArgs(IBrowser browser, IFrame frame, int httpStatusCode)
		{
			this.Browser = browser;
			this.Frame = frame;
			if (frame.IsValid)
			{
				this.Url = frame.Url;
			}
			this.HttpStatusCode = httpStatusCode;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00003334 File Offset: 0x00001534
		// (set) Token: 0x060000EF RID: 239 RVA: 0x0000333C File Offset: 0x0000153C
		public IBrowser Browser { get; private set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00003345 File Offset: 0x00001545
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x0000334D File Offset: 0x0000154D
		public IFrame Frame { get; private set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00003356 File Offset: 0x00001556
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x0000335E File Offset: 0x0000155E
		public string Url { get; private set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003367 File Offset: 0x00001567
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x0000336F File Offset: 0x0000156F
		public int HttpStatusCode { get; set; }
	}
}
