using System;
using CefSharp.Structs;

namespace CefSharp
{
	// Token: 0x0200004E RID: 78
	public interface IAudioHandler : IDisposable
	{
		// Token: 0x0600012A RID: 298
		bool GetAudioParameters(IWebBrowser chromiumWebBrowser, IBrowser browser, ref AudioParameters parameters);

		// Token: 0x0600012B RID: 299
		void OnAudioStreamStarted(IWebBrowser chromiumWebBrowser, IBrowser browser, AudioParameters parameters, int channels);

		// Token: 0x0600012C RID: 300
		void OnAudioStreamPacket(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr data, int noOfFrames, long pts);

		// Token: 0x0600012D RID: 301
		void OnAudioStreamStopped(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x0600012E RID: 302
		void OnAudioStreamError(IWebBrowser chromiumWebBrowser, IBrowser browser, string errorMessage);
	}
}
