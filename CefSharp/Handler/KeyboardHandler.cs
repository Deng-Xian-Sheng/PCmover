using System;

namespace CefSharp.Handler
{
	// Token: 0x02000104 RID: 260
	public class KeyboardHandler : IKeyboardHandler
	{
		// Token: 0x060007B2 RID: 1970 RVA: 0x0000C554 File Offset: 0x0000A754
		bool IKeyboardHandler.OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
		{
			return this.OnPreKeyEvent(chromiumWebBrowser, browser, type, windowsKeyCode, nativeKeyCode, modifiers, isSystemKey, ref isKeyboardShortcut);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0000C574 File Offset: 0x0000A774
		protected virtual bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
		{
			return false;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0000C577 File Offset: 0x0000A777
		bool IKeyboardHandler.OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
		{
			return this.OnKeyEvent(chromiumWebBrowser, browser, type, windowsKeyCode, nativeKeyCode, modifiers, isSystemKey);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0000C58A File Offset: 0x0000A78A
		protected virtual bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
		{
			return false;
		}
	}
}
