using System;

namespace CefSharp
{
	// Token: 0x0200005B RID: 91
	public interface IKeyboardHandler
	{
		// Token: 0x0600015A RID: 346
		bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut);

		// Token: 0x0600015B RID: 347
		bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey);
	}
}
