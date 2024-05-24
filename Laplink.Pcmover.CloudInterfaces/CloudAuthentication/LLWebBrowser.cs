using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace Laplink.Pcmover.CloudAuthentication
{
	// Token: 0x0200000A RID: 10
	internal class LLWebBrowser : WebBrowser
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000299C File Offset: 0x00000B9C
		protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
		{
			return new LLWebBrowser.LLCustomSite(this);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000029A4 File Offset: 0x00000BA4
		static LLWebBrowser()
		{
			LLWebBrowser.shortcutBlacklist.Add(Shortcut.AltBksp);
			LLWebBrowser.shortcutBlacklist.Add(Shortcut.AltDownArrow);
			LLWebBrowser.shortcutBlacklist.Add(Shortcut.AltLeftArrow);
			LLWebBrowser.shortcutBlacklist.Add(Shortcut.AltRightArrow);
			LLWebBrowser.shortcutBlacklist.Add(Shortcut.AltUpArrow);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002A0C File Offset: 0x00000C0C
		protected override void CreateSink()
		{
			base.CreateSink();
			object activeXInstance = base.ActiveXInstance;
			if (activeXInstance != null)
			{
				this.m_event = new LLWebBrowser.LLWebBrowserEvent(this);
				this.connectionPointCookie = new AxHost.ConnectionPointCookie(activeXInstance, this.m_event, typeof(NativeWrapper.DWebBrowserEvents2));
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002A51 File Offset: 0x00000C51
		protected override void DetachSink()
		{
			if (this.connectionPointCookie != null)
			{
				this.connectionPointCookie.Disconnect();
				this.connectionPointCookie = null;
			}
			base.DetachSink();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002A73 File Offset: 0x00000C73
		protected virtual void OnNavigateError(WebBrowserNavigateErrorEventArgs e)
		{
			if (this.NavigateError != null)
			{
				this.NavigateError(this, e);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600004B RID: 75 RVA: 0x00002A8C File Offset: 0x00000C8C
		// (remove) Token: 0x0600004C RID: 76 RVA: 0x00002AC4 File Offset: 0x00000CC4
		public event WebBrowserNavigateErrorEventHandler NavigateError;

		// Token: 0x0400000C RID: 12
		private const int S_OK = 0;

		// Token: 0x0400000D RID: 13
		private const int S_FALSE = 1;

		// Token: 0x0400000E RID: 14
		private const int E_NOTIMPL = -2147467263;

		// Token: 0x0400000F RID: 15
		private const int WM_CHAR = 258;

		// Token: 0x04000010 RID: 16
		private AxHost.ConnectionPointCookie connectionPointCookie;

		// Token: 0x04000011 RID: 17
		private LLWebBrowser.LLWebBrowserEvent m_event;

		// Token: 0x04000012 RID: 18
		private static readonly HashSet<Shortcut> shortcutBlacklist = new HashSet<Shortcut>();

		// Token: 0x02000013 RID: 19
		[ClassInterface(ClassInterfaceType.None)]
		private sealed class LLWebBrowserEvent : StandardOleMarshalObject, NativeWrapper.DWebBrowserEvents2
		{
			// Token: 0x06000061 RID: 97 RVA: 0x00002DCE File Offset: 0x00000FCE
			public LLWebBrowserEvent(LLWebBrowser parent)
			{
				this.parent = parent;
			}

			// Token: 0x06000062 RID: 98 RVA: 0x00002DE0 File Offset: 0x00000FE0
			public void NavigateError(object pDisp, ref object url, ref object frame, ref object statusCode, ref bool cancel)
			{
				string url2 = (url == null) ? "" : ((string)url);
				string targetFrameName = (frame == null) ? "" : ((string)frame);
				int statusCode2 = (statusCode == null) ? 0 : ((int)statusCode);
				WebBrowserNavigateErrorEventArgs webBrowserNavigateErrorEventArgs = new WebBrowserNavigateErrorEventArgs(url2, targetFrameName, statusCode2, pDisp);
				this.parent.OnNavigateError(webBrowserNavigateErrorEventArgs);
				cancel = webBrowserNavigateErrorEventArgs.Cancel;
			}

			// Token: 0x06000063 RID: 99 RVA: 0x00002E41 File Offset: 0x00001041
			public void BeforeNavigate2(object pDisp, ref object urlObject, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
			{
			}

			// Token: 0x06000064 RID: 100 RVA: 0x00002E43 File Offset: 0x00001043
			public void ClientToHostWindow(ref long cX, ref long cY)
			{
			}

			// Token: 0x06000065 RID: 101 RVA: 0x00002E45 File Offset: 0x00001045
			public void CommandStateChange(long command, bool enable)
			{
			}

			// Token: 0x06000066 RID: 102 RVA: 0x00002E47 File Offset: 0x00001047
			public void DocumentComplete(object pDisp, ref object urlObject)
			{
			}

			// Token: 0x06000067 RID: 103 RVA: 0x00002E49 File Offset: 0x00001049
			public void DownloadBegin()
			{
			}

			// Token: 0x06000068 RID: 104 RVA: 0x00002E4B File Offset: 0x0000104B
			public void DownloadComplete()
			{
			}

			// Token: 0x06000069 RID: 105 RVA: 0x00002E4D File Offset: 0x0000104D
			public void FileDownload(ref bool cancel)
			{
			}

			// Token: 0x0600006A RID: 106 RVA: 0x00002E4F File Offset: 0x0000104F
			public void NavigateComplete2(object pDisp, ref object urlObject)
			{
			}

			// Token: 0x0600006B RID: 107 RVA: 0x00002E51 File Offset: 0x00001051
			public void NewWindow2(ref object ppDisp, ref bool cancel)
			{
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00002E53 File Offset: 0x00001053
			public void OnFullScreen(bool fullScreen)
			{
			}

			// Token: 0x0600006D RID: 109 RVA: 0x00002E55 File Offset: 0x00001055
			public void OnMenuBar(bool menuBar)
			{
			}

			// Token: 0x0600006E RID: 110 RVA: 0x00002E57 File Offset: 0x00001057
			public void OnQuit()
			{
			}

			// Token: 0x0600006F RID: 111 RVA: 0x00002E59 File Offset: 0x00001059
			public void OnStatusBar(bool statusBar)
			{
			}

			// Token: 0x06000070 RID: 112 RVA: 0x00002E5B File Offset: 0x0000105B
			public void OnTheaterMode(bool theaterMode)
			{
			}

			// Token: 0x06000071 RID: 113 RVA: 0x00002E5D File Offset: 0x0000105D
			public void OnToolBar(bool toolBar)
			{
			}

			// Token: 0x06000072 RID: 114 RVA: 0x00002E5F File Offset: 0x0000105F
			public void OnVisible(bool visible)
			{
			}

			// Token: 0x06000073 RID: 115 RVA: 0x00002E61 File Offset: 0x00001061
			public void PrintTemplateInstantiation(object pDisp)
			{
			}

			// Token: 0x06000074 RID: 116 RVA: 0x00002E63 File Offset: 0x00001063
			public void PrintTemplateTeardown(object pDisp)
			{
			}

			// Token: 0x06000075 RID: 117 RVA: 0x00002E65 File Offset: 0x00001065
			public void PrivacyImpactedStateChange(bool bImpacted)
			{
			}

			// Token: 0x06000076 RID: 118 RVA: 0x00002E67 File Offset: 0x00001067
			public void ProgressChange(int progress, int progressMax)
			{
			}

			// Token: 0x06000077 RID: 119 RVA: 0x00002E69 File Offset: 0x00001069
			public void PropertyChange(string szProperty)
			{
			}

			// Token: 0x06000078 RID: 120 RVA: 0x00002E6B File Offset: 0x0000106B
			public void SetSecureLockIcon(int secureLockIcon)
			{
			}

			// Token: 0x06000079 RID: 121 RVA: 0x00002E6D File Offset: 0x0000106D
			public void StatusTextChange(string text)
			{
			}

			// Token: 0x0600007A RID: 122 RVA: 0x00002E6F File Offset: 0x0000106F
			public void TitleChange(string text)
			{
			}

			// Token: 0x0600007B RID: 123 RVA: 0x00002E71 File Offset: 0x00001071
			public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
			{
			}

			// Token: 0x0600007C RID: 124 RVA: 0x00002E73 File Offset: 0x00001073
			public void WindowClosing(bool isChildWindow, ref bool cancel)
			{
			}

			// Token: 0x0600007D RID: 125 RVA: 0x00002E75 File Offset: 0x00001075
			public void WindowSetHeight(int height)
			{
			}

			// Token: 0x0600007E RID: 126 RVA: 0x00002E77 File Offset: 0x00001077
			public void WindowSetLeft(int left)
			{
			}

			// Token: 0x0600007F RID: 127 RVA: 0x00002E79 File Offset: 0x00001079
			public void WindowSetResizable(bool resizable)
			{
			}

			// Token: 0x06000080 RID: 128 RVA: 0x00002E7B File Offset: 0x0000107B
			public void WindowSetTop(int top)
			{
			}

			// Token: 0x06000081 RID: 129 RVA: 0x00002E7D File Offset: 0x0000107D
			public void WindowSetWidth(int width)
			{
			}

			// Token: 0x0400002F RID: 47
			private readonly LLWebBrowser parent;
		}

		// Token: 0x02000014 RID: 20
		[ComVisible(true)]
		[ComDefaultInterface(typeof(NativeWrapper.IDocHostUIHandler))]
		protected class LLCustomSite : WebBrowser.WebBrowserSite, NativeWrapper.IDocHostUIHandler, ICustomQueryInterface
		{
			// Token: 0x06000082 RID: 130 RVA: 0x00002E7F File Offset: 0x0000107F
			public LLCustomSite(WebBrowser host) : base(host)
			{
				this.host = host;
			}

			// Token: 0x06000083 RID: 131 RVA: 0x00002E8F File Offset: 0x0000108F
			public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
			{
				ppv = IntPtr.Zero;
				if (iid == typeof(NativeWrapper.IDocHostUIHandler).GUID)
				{
					ppv = Marshal.GetComInterfaceForObject(this, typeof(NativeWrapper.IDocHostUIHandler), CustomQueryInterfaceMode.Ignore);
					return CustomQueryInterfaceResult.Handled;
				}
				return CustomQueryInterfaceResult.NotHandled;
			}

			// Token: 0x06000084 RID: 132 RVA: 0x00002ECA File Offset: 0x000010CA
			public int EnableModeless(bool fEnable)
			{
				return -2147467263;
			}

			// Token: 0x06000085 RID: 133 RVA: 0x00002ED1 File Offset: 0x000010D1
			public int FilterDataObject(System.Runtime.InteropServices.ComTypes.IDataObject pDO, out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet)
			{
				ppDORet = null;
				return 1;
			}

			// Token: 0x06000086 RID: 134 RVA: 0x00002ED7 File Offset: 0x000010D7
			public int GetDropTarget(NativeWrapper.IOleDropTarget pDropTarget, out NativeWrapper.IOleDropTarget ppDropTarget)
			{
				ppDropTarget = null;
				return 0;
			}

			// Token: 0x06000087 RID: 135 RVA: 0x00002EDD File Offset: 0x000010DD
			public int GetExternal(out object ppDispatch)
			{
				ppDispatch = this.host.ObjectForScripting;
				return 0;
			}

			// Token: 0x06000088 RID: 136 RVA: 0x00002EF0 File Offset: 0x000010F0
			public int GetHostInfo(NativeWrapper.DOCHOSTUIINFO info)
			{
				info.dwDoubleClick = 0;
				info.dwFlags = 131088;
				if (NativeWrapper.NativeMethods.IsProcessDPIAware())
				{
					info.dwFlags |= 1073741824;
				}
				if (this.host.ScrollBarsEnabled)
				{
					info.dwFlags |= 128;
				}
				else
				{
					info.dwFlags |= 8;
				}
				if (Application.RenderWithVisualStyles)
				{
					info.dwFlags |= 262144;
				}
				else
				{
					info.dwFlags |= 524288;
				}
				info.dwFlags |= 67108864;
				return 0;
			}

			// Token: 0x06000089 RID: 137 RVA: 0x00002F97 File Offset: 0x00001197
			public int GetOptionKeyPath(string[] pbstrKey, int dw)
			{
				return -2147467263;
			}

			// Token: 0x0600008A RID: 138 RVA: 0x00002F9E File Offset: 0x0000119E
			public int HideUI()
			{
				return -2147467263;
			}

			// Token: 0x0600008B RID: 139 RVA: 0x00002FA5 File Offset: 0x000011A5
			public int OnDocWindowActivate(bool fActivate)
			{
				return -2147467263;
			}

			// Token: 0x0600008C RID: 140 RVA: 0x00002FAC File Offset: 0x000011AC
			public int OnFrameWindowActivate(bool fActivate)
			{
				return -2147467263;
			}

			// Token: 0x0600008D RID: 141 RVA: 0x00002FB3 File Offset: 0x000011B3
			public int ResizeBorder(NativeWrapper.COMRECT rect, NativeWrapper.IOleInPlaceUIWindow doc, bool fFrameWindow)
			{
				return -2147467263;
			}

			// Token: 0x0600008E RID: 142 RVA: 0x00002FBA File Offset: 0x000011BA
			public int ShowContextMenu(int dwID, NativeWrapper.POINT pt, object pcmdtReserved, object pdispReserved)
			{
				if (dwID <= 4)
				{
					if (dwID != 2 && dwID != 4)
					{
						return 0;
					}
				}
				else if (dwID != 9 && dwID != 16)
				{
					return 0;
				}
				return 1;
			}

			// Token: 0x0600008F RID: 143 RVA: 0x00002FD7 File Offset: 0x000011D7
			public int ShowUI(int dwID, NativeWrapper.IOleInPlaceActiveObject activeObject, NativeWrapper.IOleCommandTarget commandTarget, NativeWrapper.IOleInPlaceFrame frame, NativeWrapper.IOleInPlaceUIWindow doc)
			{
				return 1;
			}

			// Token: 0x06000090 RID: 144 RVA: 0x00002FDA File Offset: 0x000011DA
			public int TranslateAccelerator(ref NativeWrapper.MSG msg, ref Guid group, int nCmdID)
			{
				if (msg.message != 258 && (Control.ModifierKeys & (Keys.Shift | Keys.Control | Keys.Alt)) != Keys.None && LLWebBrowser.shortcutBlacklist.Contains((Shortcut)((int)msg.wParam | (int)Control.ModifierKeys)))
				{
					return 0;
				}
				return 1;
			}

			// Token: 0x06000091 RID: 145 RVA: 0x00003016 File Offset: 0x00001216
			public int TranslateUrl(int dwTranslate, string strUrlIn, out string pstrUrlOut)
			{
				pstrUrlOut = null;
				return 1;
			}

			// Token: 0x06000092 RID: 146 RVA: 0x0000301C File Offset: 0x0000121C
			public int UpdateUI()
			{
				return -2147467263;
			}

			// Token: 0x04000030 RID: 48
			private readonly WebBrowser host;
		}
	}
}
