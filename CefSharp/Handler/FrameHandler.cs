using System;
using System.Collections.Generic;

namespace CefSharp.Handler
{
	// Token: 0x02000102 RID: 258
	public class FrameHandler : IFrameHandler
	{
		// Token: 0x0600079F RID: 1951 RVA: 0x0000C428 File Offset: 0x0000A628
		void IFrameHandler.OnFrameAttached(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, bool reattached)
		{
			IFrame frameById = this.GetFrameById(frame.Identifier);
			this.OnFrameAttached(chromiumWebBrowser, browser, frameById ?? frame, reattached);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0000C452 File Offset: 0x0000A652
		protected virtual void OnFrameAttached(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, bool reattached)
		{
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0000C454 File Offset: 0x0000A654
		void IFrameHandler.OnFrameCreated(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{
			this.frames.Add(frame.Identifier, frame);
			this.OnFrameCreated(chromiumWebBrowser, browser, frame);
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0000C471 File Offset: 0x0000A671
		protected virtual void OnFrameCreated(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0000C473 File Offset: 0x0000A673
		void IFrameHandler.OnFrameDetached(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{
			this.frames.Remove(frame.Identifier);
			this.OnFrameDetached(chromiumWebBrowser, browser, frame);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0000C490 File Offset: 0x0000A690
		protected virtual void OnFrameDetached(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0000C494 File Offset: 0x0000A694
		void IFrameHandler.OnMainFrameChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame oldFrame, IFrame newFrame)
		{
			IFrame frame = (newFrame == null) ? null : this.GetFrameById(newFrame.Identifier);
			this.OnMainFrameChanged(chromiumWebBrowser, browser, oldFrame, frame ?? newFrame);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0000C4C6 File Offset: 0x0000A6C6
		protected virtual void OnMainFrameChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame oldFrame, IFrame newFrame)
		{
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0000C4C8 File Offset: 0x0000A6C8
		private IFrame GetFrameById(long frameId)
		{
			IFrame result;
			if (this.frames.TryGetValue(frameId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x040003A3 RID: 931
		private Dictionary<long, IFrame> frames = new Dictionary<long, IFrame>();
	}
}
