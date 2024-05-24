using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Laplink.Pcmover.CloudAuthentication
{
	// Token: 0x02000008 RID: 8
	[ComVisible(true)]
	public partial class AuthenticationDialog : Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002192 File Offset: 0x00000392
		public AuthenticationDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000021A0 File Offset: 0x000003A0
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000021A8 File Offset: 0x000003A8
		public NameValueCollection Results { get; private set; }

		// Token: 0x06000032 RID: 50 RVA: 0x000021B4 File Offset: 0x000003B4
		private AuthenticationDialog(IntPtr ownerWindow)
		{
			AuthenticationDialog.SetBrowserFeatures();
			base.ControlBox = false;
			this.Text = string.Empty;
			this.ownerWindow = new AuthenticationDialog.WindowsFormsWin32Window
			{
				Handle = ownerWindow
			};
			this.webBrowser = new LLWebBrowser();
			base.Shown += this.FormShownHandler;
			this.webBrowser.DocumentTitleChanged += this.WebBrowserDocumentTitleChangedHandler;
			this.webBrowser.PreviewKeyDown += this.WebBrowser_PreviewKeyDown;
			this.webBrowser.ObjectForScripting = this;
			if (this.ownerWindow == null)
			{
				Screen primaryScreen = Screen.PrimaryScreen;
			}
			else
			{
				Screen.FromHandle(this.ownerWindow.Handle);
			}
			this.InitializeComponent();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002270 File Offset: 0x00000470
		public static Task<NameValueCollection> AuthenticateAsync(string requestUrl, string callbackUri, IntPtr ownerWindow)
		{
			AuthenticationDialog.<AuthenticateAsync>d__6 <AuthenticateAsync>d__;
			<AuthenticateAsync>d__.<>t__builder = AsyncTaskMethodBuilder<NameValueCollection>.Create();
			<AuthenticateAsync>d__.requestUrl = requestUrl;
			<AuthenticateAsync>d__.callbackUri = callbackUri;
			<AuthenticateAsync>d__.ownerWindow = ownerWindow;
			<AuthenticateAsync>d__.<>1__state = -1;
			<AuthenticateAsync>d__.<>t__builder.Start<AuthenticationDialog.<AuthenticateAsync>d__6>(ref <AuthenticateAsync>d__);
			return <AuthenticateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000022C4 File Offset: 0x000004C4
		private DialogResult Authenticate(string requestUrl, string callbackUri)
		{
			this.callbackUri = new Uri(callbackUri);
			this.Results = null;
			this.webBrowser.Navigating += this.NavigatingHandler;
			this.webBrowser.Navigated += this.NavigatedHandler;
			this.webBrowser.NavigateError += this.NavigateErrorHandler;
			Uri url = new Uri(requestUrl);
			this.webBrowser.Navigate(url);
			this.statusCode = 0;
			return this.ShowBrowser();
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000234B File Offset: 0x0000054B
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00002353 File Offset: 0x00000553
		protected IWin32Window ownerWindow { get; set; }

		// Token: 0x06000037 RID: 55 RVA: 0x0000235C File Offset: 0x0000055C
		private void WebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Back)
			{
				this._key = Keys.Back;
			}
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002380 File Offset: 0x00000580
		protected virtual void NavigatingHandler(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (this.webBrowser.IsDisposed || base.DialogResult == DialogResult.OK)
			{
				e.Cancel = true;
				return;
			}
			if (this._key == Keys.Back)
			{
				this._key = Keys.None;
				e.Cancel = true;
			}
			e.Cancel = this.CheckUrl(e.Url);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000023D4 File Offset: 0x000005D4
		private void NavigatedHandler(object sender, WebBrowserNavigatedEventArgs e)
		{
			if (this.CheckUrl(e.Url))
			{
				return;
			}
			AuthenticationDialog.InjectJavascript("function fixLogos()\r\n{\r\n    doFixLogos = function() {\r\n        var logos = $('.social-logo');\r\n        logos.each(function(index, value) {\r\n            value.setAttribute('width', logos[0].clientHeight);\r\n        });\r\n    }\r\n    window.onload = function() {\r\n        if (window.jQuery) doFixLogos();\r\n        else {   \r\n            var script = document.createElement('script'); \r\n            document.getElementsByTagName('head')[0].appendChild(script);\r\n            script.type = 'text/javascript';\r\n            script.src = \"//ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\";\r\n            script.onload = doFixLogos;\r\n        }\r\n    }\r\n}", this.webBrowser.Document);
			this.webBrowser.Document.InvokeScript("fixLogos");
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002410 File Offset: 0x00000610
		protected virtual void NavigateErrorHandler(object sender, WebBrowserNavigateErrorEventArgs e)
		{
			if (this.webBrowser.IsDisposed || base.DialogResult == DialogResult.OK)
			{
				e.Cancel = true;
				return;
			}
			if (this.webBrowser.ActiveXInstance != e.WebBrowserActiveXInstance)
			{
				return;
			}
			if (e.StatusCode >= 300 && e.StatusCode < 400)
			{
				return;
			}
			e.Cancel = true;
			this.StopWebBrowser();
			this.statusCode = e.StatusCode;
			base.DialogResult = ((e.StatusCode == 0) ? DialogResult.Cancel : DialogResult.Abort);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002498 File Offset: 0x00000698
		private bool CheckUrl(Uri url)
		{
			if (url.Scheme.Equals(this.callbackUri.Scheme, StringComparison.OrdinalIgnoreCase) && url.Authority.Equals(this.callbackUri.Authority, StringComparison.OrdinalIgnoreCase) && url.AbsolutePath.Equals(this.callbackUri.AbsolutePath))
			{
				base.DialogResult = DialogResult.OK;
				try
				{
					this.Results = HttpUtility.ParseQueryString(url.Query);
				}
				catch (Exception ex)
				{
					Trace.WriteLine("Exception extracting code and state: " + ex.Message);
				}
				this.StopWebBrowser();
				return true;
			}
			return false;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002564 File Offset: 0x00000764
		private DialogResult ShowBrowser()
		{
			DialogResult dialogResult = base.ShowDialog(this.ownerWindow);
			if (dialogResult != DialogResult.OK)
			{
			}
			return dialogResult;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002589 File Offset: 0x00000789
		private void StopWebBrowser()
		{
			if (this.webBrowser.IsDisposed || !this.webBrowser.IsBusy)
			{
				return;
			}
			this.webBrowser.Stop();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000278B File Offset: 0x0000098B
		private void WebBrowserDocumentTitleChangedHandler(object sender, EventArgs e)
		{
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000278D File Offset: 0x0000098D
		private void FormShownHandler(object sender, EventArgs e)
		{
			if (base.Owner == null)
			{
				base.Activate();
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000027A0 File Offset: 0x000009A0
		private static void SetBrowserFeatures()
		{
			string fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
			string str = "HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\";
			Registry.SetValue(str + "FEATURE_BROWSER_EMULATION", fileName, AuthenticationDialog.GetBrowserEmulationMode(), RegistryValueKind.DWord);
			Registry.SetValue(str + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1, RegistryValueKind.DWord);
			Registry.SetValue(str + "FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1, RegistryValueKind.DWord);
			Registry.SetValue(str + "FEATURE_GPU_RENDERING", fileName, 1, RegistryValueKind.DWord);
			Registry.SetValue(str + "FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1, RegistryValueKind.DWord);
			Registry.SetValue(str + "FEATURE_NINPUT_LEGACYMODE", fileName, 0, RegistryValueKind.DWord);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000285C File Offset: 0x00000A5C
		private static uint GetBrowserEmulationMode()
		{
			int num = 0;
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer", RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.QueryValues))
			{
				object value = registryKey.GetValue("svcVersion");
				if (value == null)
				{
					value = registryKey.GetValue("Version");
					if (value == null)
					{
						throw new ApplicationException("Microsoft Internet Explorer is required!");
					}
				}
				int.TryParse(value.ToString().Split(new char[]
				{
					'.'
				})[0], out num);
			}
			if (num < 7)
			{
				throw new ApplicationException("Unsupported version of Microsoft Internet Explorer!");
			}
			uint result = 11000U;
			switch (num)
			{
			case 7:
				result = 7000U;
				break;
			case 8:
				result = 8000U;
				break;
			case 9:
				result = 9000U;
				break;
			case 10:
				result = 10000U;
				break;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002930 File Offset: 0x00000B30
		public static void InjectJavascript(string javascript, HtmlDocument doc)
		{
			if (doc != null)
			{
				try
				{
					HtmlElement htmlElement = doc.GetElementsByTagName("head")[0];
					HtmlElement htmlElement2 = doc.CreateElement("script");
					((IHTMLScriptElement)htmlElement2.DomElement).Text = javascript;
					htmlElement.AppendChild(htmlElement2);
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex.Message);
				}
			}
		}

		// Token: 0x04000005 RID: 5
		private Keys _key;

		// Token: 0x04000006 RID: 6
		private Uri callbackUri;

		// Token: 0x04000007 RID: 7
		private int statusCode;

		// Token: 0x0400000A RID: 10
		private const int UIWidth = 566;

		// Token: 0x0200000F RID: 15
		private sealed class WindowsFormsWin32Window : IWin32Window
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000058 RID: 88 RVA: 0x00002B4E File Offset: 0x00000D4E
			// (set) Token: 0x06000059 RID: 89 RVA: 0x00002B56 File Offset: 0x00000D56
			public IntPtr Handle { get; set; }
		}

		// Token: 0x02000010 RID: 16
		protected static class DpiHelper
		{
			// Token: 0x0600005B RID: 91 RVA: 0x00002B68 File Offset: 0x00000D68
			static DpiHelper()
			{
				IntPtr dc = NativeWrapper.NativeMethods.GetDC(IntPtr.Zero);
				double num;
				double num2;
				if (dc != IntPtr.Zero)
				{
					num = (double)NativeWrapper.NativeMethods.GetDeviceCaps(dc, 88);
					num2 = (double)NativeWrapper.NativeMethods.GetDeviceCaps(dc, 90);
					NativeWrapper.NativeMethods.ReleaseDC(IntPtr.Zero, dc);
				}
				else
				{
					num = 96.0;
					num2 = 96.0;
				}
				int val = (int)(100.0 * (num / 96.0));
				int val2 = (int)(100.0 * (num2 / 96.0));
				AuthenticationDialog.DpiHelper.ZoomPercent = Math.Min(val, val2);
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600005C RID: 92 RVA: 0x00002BFB File Offset: 0x00000DFB
			public static int ZoomPercent { get; }
		}
	}
}
