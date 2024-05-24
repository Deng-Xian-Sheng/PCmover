using System;
using CefSharp.Structs;

namespace CefSharp.Handler
{
	// Token: 0x020000F7 RID: 247
	public class AudioHandler : IAudioHandler, IDisposable
	{
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x0000C107 File Offset: 0x0000A307
		public bool IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0000C10F File Offset: 0x0000A30F
		bool IAudioHandler.GetAudioParameters(IWebBrowser chromiumWebBrowser, IBrowser browser, ref AudioParameters parameters)
		{
			return this.GetAudioParameters(chromiumWebBrowser, browser, ref parameters);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0000C11A File Offset: 0x0000A31A
		protected virtual bool GetAudioParameters(IWebBrowser chromiumWebBrowser, IBrowser browser, ref AudioParameters parameters)
		{
			return false;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0000C11D File Offset: 0x0000A31D
		void IAudioHandler.OnAudioStreamStarted(IWebBrowser chromiumWebBrowser, IBrowser browser, AudioParameters parameters, int channels)
		{
			this.OnAudioStreamStarted(chromiumWebBrowser, browser, parameters, channels);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0000C12A File Offset: 0x0000A32A
		protected virtual void OnAudioStreamStarted(IWebBrowser chromiumWebBrowser, IBrowser browser, AudioParameters parameters, int channels)
		{
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0000C12C File Offset: 0x0000A32C
		void IAudioHandler.OnAudioStreamPacket(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr data, int noOfFrames, long pts)
		{
			this.OnAudioStreamPacket(chromiumWebBrowser, browser, data, noOfFrames, pts);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0000C13B File Offset: 0x0000A33B
		protected virtual void OnAudioStreamPacket(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr data, int noOfFrames, long pts)
		{
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0000C13D File Offset: 0x0000A33D
		void IAudioHandler.OnAudioStreamStopped(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnAudioStreamStopped(chromiumWebBrowser, browser);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0000C147 File Offset: 0x0000A347
		protected virtual void OnAudioStreamStopped(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x0000C149 File Offset: 0x0000A349
		void IAudioHandler.OnAudioStreamError(IWebBrowser chromiumWebBrowser, IBrowser browser, string errorMessage)
		{
			this.OnAudioStreamError(chromiumWebBrowser, browser, errorMessage);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0000C154 File Offset: 0x0000A354
		protected virtual void OnAudioStreamError(IWebBrowser chromiumWebBrowser, IBrowser browser, string errorMessage)
		{
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0000C156 File Offset: 0x0000A356
		protected virtual void Dispose(bool disposing)
		{
			this.isDisposed = true;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0000C15F File Offset: 0x0000A35F
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040003A0 RID: 928
		private bool isDisposed;
	}
}
