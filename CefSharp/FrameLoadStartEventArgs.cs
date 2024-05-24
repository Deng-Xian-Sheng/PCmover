using System;

namespace CefSharp
{
	// Token: 0x02000047 RID: 71
	public class FrameLoadStartEventArgs : EventArgs
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00003378 File Offset: 0x00001578
		public FrameLoadStartEventArgs(IBrowser browser, IFrame frame, TransitionType transitionType)
		{
			this.Browser = browser;
			this.Frame = frame;
			if (frame.IsValid)
			{
				this.Url = frame.Url;
			}
			this.TransitionType = transitionType;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000033A9 File Offset: 0x000015A9
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x000033B1 File Offset: 0x000015B1
		public IBrowser Browser { get; private set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x000033BA File Offset: 0x000015BA
		// (set) Token: 0x060000FA RID: 250 RVA: 0x000033C2 File Offset: 0x000015C2
		public IFrame Frame { get; private set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000033CB File Offset: 0x000015CB
		// (set) Token: 0x060000FC RID: 252 RVA: 0x000033D3 File Offset: 0x000015D3
		public string Url { get; private set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000FD RID: 253 RVA: 0x000033DC File Offset: 0x000015DC
		// (set) Token: 0x060000FE RID: 254 RVA: 0x000033E4 File Offset: 0x000015E4
		public TransitionType TransitionType { get; private set; }
	}
}
