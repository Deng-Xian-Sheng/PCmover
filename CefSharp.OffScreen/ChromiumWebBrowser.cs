using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CefSharp.Core;
using CefSharp.DevTools.DOM;
using CefSharp.DevTools.Page;
using CefSharp.Enums;
using CefSharp.Internals;
using CefSharp.Structs;
using CefSharp.Web;

namespace CefSharp.OffScreen
{
	// Token: 0x02000004 RID: 4
	public class ChromiumWebBrowser : IRenderWebBrowser, IWebBrowserInternal, IWebBrowser, IChromiumWebBrowserBase, IDisposable
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002268 File Offset: 0x00000468
		public bool IsDisposed
		{
			get
			{
				return Interlocked.CompareExchange(ref this.disposeSignaled, 1, 1) == 1;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000227A File Offset: 0x0000047A
		public bool IsBrowserInitialized
		{
			get
			{
				return this.InternalIsBrowserInitialized();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002282 File Offset: 0x00000482
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000228A File Offset: 0x0000048A
		public bool IsLoading { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002293 File Offset: 0x00000493
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000229B File Offset: 0x0000049B
		public string TooltipText { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000022A4 File Offset: 0x000004A4
		// (set) Token: 0x06000019 RID: 25 RVA: 0x000022AC File Offset: 0x000004AC
		public string Address { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000022B5 File Offset: 0x000004B5
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000022BD File Offset: 0x000004BD
		public bool CanGoBack { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000022C6 File Offset: 0x000004C6
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000022CE File Offset: 0x000004CE
		public bool CanGoForward { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000022D7 File Offset: 0x000004D7
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000022DF File Offset: 0x000004DF
		public IRequestContext RequestContext { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000022E8 File Offset: 0x000004E8
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000022F0 File Offset: 0x000004F0
		public IRenderHandler RenderHandler { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000022F9 File Offset: 0x000004F9
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002301 File Offset: 0x00000501
		public IAccessibilityHandler AccessibilityHandler { get; set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000024 RID: 36 RVA: 0x0000230C File Offset: 0x0000050C
		// (remove) Token: 0x06000025 RID: 37 RVA: 0x00002344 File Offset: 0x00000544
		public event EventHandler BrowserInitialized;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000026 RID: 38 RVA: 0x0000237C File Offset: 0x0000057C
		// (remove) Token: 0x06000027 RID: 39 RVA: 0x000023B4 File Offset: 0x000005B4
		public event EventHandler<AddressChangedEventArgs> AddressChanged;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000028 RID: 40 RVA: 0x000023EC File Offset: 0x000005EC
		// (remove) Token: 0x06000029 RID: 41 RVA: 0x00002424 File Offset: 0x00000624
		public event EventHandler<TitleChangedEventArgs> TitleChanged;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600002A RID: 42 RVA: 0x0000245C File Offset: 0x0000065C
		// (remove) Token: 0x0600002B RID: 43 RVA: 0x00002494 File Offset: 0x00000694
		public event EventHandler<OnPaintEventArgs> Paint;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600002C RID: 44 RVA: 0x000024CC File Offset: 0x000006CC
		// (remove) Token: 0x0600002D RID: 45 RVA: 0x00002504 File Offset: 0x00000704
		private event EventHandler<OnPaintEventArgs> AfterPaint;

		// Token: 0x0600002E RID: 46 RVA: 0x00002539 File Offset: 0x00000739
		public ChromiumWebBrowser(HtmlString html, IBrowserSettings browserSettings = null, IRequestContext requestContext = null, bool automaticallyCreateBrowser = true, Action<IBrowser> onAfterBrowserCreated = null) : this(html.ToDataUriString(), browserSettings, requestContext, automaticallyCreateBrowser, onAfterBrowserCreated)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002550 File Offset: 0x00000750
		public ChromiumWebBrowser(string address = "", IBrowserSettings browserSettings = null, IRequestContext requestContext = null, bool automaticallyCreateBrowser = true, Action<IBrowser> onAfterBrowserCreated = null)
		{
			if (!Cef.IsInitialized)
			{
				CefSettings settings = new CefSettings();
				if (!Cef.Initialize(settings))
				{
					throw new InvalidOperationException("Cef.Initialize() failed.Check the log file see https://github.com/cefsharp/CefSharp/wiki/Trouble-Shooting#log-file for details.");
				}
			}
			this.RequestContext = requestContext;
			Cef.AddDisposable(this);
			this.Address = address;
			this.onAfterBrowserCreatedDelegate = onAfterBrowserCreated;
			this.managedCefBrowserAdapter = ManagedCefBrowserAdapter.Create(this, true);
			if (automaticallyCreateBrowser)
			{
				this.CreateBrowser(null, browserSettings);
			}
			this.RenderHandler = new DefaultRenderHandler(this);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000025F0 File Offset: 0x000007F0
		~ChromiumWebBrowser()
		{
			this.Dispose(false);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002620 File Offset: 0x00000820
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002630 File Offset: 0x00000830
		protected virtual void Dispose(bool disposing)
		{
			if (Interlocked.CompareExchange(ref this.disposeSignaled, 1, 0) != 0)
			{
				return;
			}
			if (disposing)
			{
				this.CanExecuteJavascriptInMainFrame = false;
				Interlocked.Exchange(ref this.browserInitialized, 0);
				this.AddressChanged = null;
				this.BrowserInitialized = null;
				this.ConsoleMessage = null;
				this.FrameLoadEnd = null;
				this.FrameLoadStart = null;
				this.LoadError = null;
				this.LoadingStateChanged = null;
				this.Paint = null;
				this.AfterPaint = null;
				this.StatusMessage = null;
				this.TitleChanged = null;
				this.JavascriptMessageReceived = null;
				this.FreeHandlersExceptLifeSpanAndFocus();
				this.FocusHandler = new NoFocusHandler();
				this.browser = null;
				this.BrowserCore = null;
				if (this.managedCefBrowserAdapter != null)
				{
					this.managedCefBrowserAdapter.Dispose();
					this.managedCefBrowserAdapter = null;
				}
				this.LifeSpanHandler = null;
			}
			Cef.RemoveDisposable(this);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002704 File Offset: 0x00000904
		public void CreateBrowser(IWindowInfo windowInfo = null, IBrowserSettings browserSettings = null)
		{
			if (this.browserCreated)
			{
				throw new Exception("An instance of the underlying offscreen browser has already been created, this method can only be called once.");
			}
			this.browserCreated = true;
			if (browserSettings == null)
			{
				browserSettings = ObjectFactory.CreateBrowserSettings(true);
			}
			if (windowInfo == null)
			{
				windowInfo = ObjectFactory.CreateWindowInfo();
				windowInfo.SetAsWindowless(IntPtr.Zero);
			}
			GlobalContextInitialized.ExecuteOrEnqueue(delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				this.managedCefBrowserAdapter.CreateBrowser(windowInfo, browserSettings, this.RequestContext, this.Address);
				if (browserSettings.AutoDispose)
				{
					browserSettings.Dispose();
				}
				browserSettings = null;
			});
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002790 File Offset: 0x00000990
		public Task<IBrowser> CreateBrowserAsync(IWindowInfo windowInfo = null, IBrowserSettings browserSettings = null)
		{
			TaskCompletionSource<IBrowser> tcs = new TaskCompletionSource<IBrowser>();
			this.onAfterBrowserCreatedDelegate = (Action<IBrowser>)Delegate.Combine(this.onAfterBrowserCreatedDelegate, new Action<IBrowser>(delegate(IBrowser b)
			{
				tcs.TrySetResultAsync(b);
			}));
			try
			{
				this.CreateBrowser(windowInfo, browserSettings);
			}
			catch (Exception ex)
			{
				tcs.TrySetExceptionAsync(ex);
			}
			return tcs.Task;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002804 File Offset: 0x00000A04
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000280C File Offset: 0x00000A0C
		public System.Drawing.Size Size
		{
			get
			{
				return this.size;
			}
			set
			{
				if (this.size != value)
				{
					this.size = value;
					if (this.IsBrowserInitialized)
					{
						this.browser.GetHost().WasResized();
					}
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000283B File Offset: 0x00000A3B
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002843 File Offset: 0x00000A43
		public float DeviceScaleFactor
		{
			get
			{
				return this.deviceScaleFactor;
			}
			set
			{
				this.deviceScaleFactor = value;
				if (this.IsBrowserInitialized)
				{
					this.browser.GetHost().NotifyScreenInfoChanged();
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002864 File Offset: 0x00000A64
		public Bitmap ScreenshotOrNull(PopupBlending blend = PopupBlending.Main)
		{
			if (this.RenderHandler == null)
			{
				throw new NullReferenceException("RenderHandler cannot be null. Use DefaultRenderHandler unless implementing your own");
			}
			DefaultRenderHandler defaultRenderHandler = this.RenderHandler as DefaultRenderHandler;
			if (defaultRenderHandler == null)
			{
				throw new Exception("ScreenshotOrNull and ScreenshotAsync can only be used in combination with the DefaultRenderHandler");
			}
			object bitmapLock = defaultRenderHandler.BitmapLock;
			Bitmap result;
			lock (bitmapLock)
			{
				if (blend == PopupBlending.Main)
				{
					result = defaultRenderHandler.BitmapBuffer.CreateBitmap();
				}
				else if (blend == PopupBlending.Popup)
				{
					result = (defaultRenderHandler.PopupOpen ? defaultRenderHandler.PopupBuffer.CreateBitmap() : null);
				}
				else
				{
					Bitmap bitmap = defaultRenderHandler.BitmapBuffer.CreateBitmap();
					if (defaultRenderHandler.PopupOpen && bitmap != null)
					{
						Bitmap bitmap2 = defaultRenderHandler.PopupBuffer.CreateBitmap();
						if (bitmap2 == null)
						{
							result = bitmap;
						}
						else
						{
							result = this.MergeBitmaps(bitmap, bitmap2, defaultRenderHandler.PopupPosition);
						}
					}
					else
					{
						result = bitmap;
					}
				}
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002944 File Offset: 0x00000B44
		[Obsolete("Use CaptureScreenshotAsync instead.")]
		public Task<Bitmap> ScreenshotAsync(bool ignoreExistingScreenshot = false, PopupBlending blend = PopupBlending.Main)
		{
			this.ThrowExceptionIfDisposed();
			Bitmap bitmap = this.ScreenshotOrNull(blend);
			TaskCompletionSource<Bitmap> completionSource = new TaskCompletionSource<Bitmap>();
			if (bitmap == null || ignoreExistingScreenshot)
			{
				EventHandler<OnPaintEventArgs> afterPaint = null;
				afterPaint = delegate(object sender, OnPaintEventArgs e)
				{
					this.AfterPaint -= afterPaint;
					if (e.Handled)
					{
						completionSource.TrySetException(new InvalidOperationException("OnPaintEventArgs.Handled = true, unable to process request. The buffer has not been updated"));
						return;
					}
					completionSource.TrySetResultAsync(this.ScreenshotOrNull(blend));
				};
				this.AfterPaint += afterPaint;
			}
			else
			{
				completionSource.TrySetResultAsync(bitmap);
			}
			return completionSource.Task;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000029CC File Offset: 0x00000BCC
		public Task<byte[]> CaptureScreenshotAsync(CaptureScreenshotFormat? format = null, int? quality = null, Viewport viewport = null)
		{
			ChromiumWebBrowser.<CaptureScreenshotAsync>d__71 <CaptureScreenshotAsync>d__;
			<CaptureScreenshotAsync>d__.<>t__builder = AsyncTaskMethodBuilder<byte[]>.Create();
			<CaptureScreenshotAsync>d__.<>4__this = this;
			<CaptureScreenshotAsync>d__.format = format;
			<CaptureScreenshotAsync>d__.quality = quality;
			<CaptureScreenshotAsync>d__.viewport = viewport;
			<CaptureScreenshotAsync>d__.<>1__state = -1;
			<CaptureScreenshotAsync>d__.<>t__builder.Start<ChromiumWebBrowser.<CaptureScreenshotAsync>d__71>(ref <CaptureScreenshotAsync>d__);
			return <CaptureScreenshotAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002A28 File Offset: 0x00000C28
		public Task ResizeAsync(int width, int height, float? deviceScaleFactor = null)
		{
			this.ThrowExceptionIfDisposed();
			this.ThrowExceptionIfBrowserNotInitialized();
			if (this.size.Width == width && this.size.Height == height)
			{
				if (deviceScaleFactor != null)
				{
					float? num = deviceScaleFactor;
					float num2 = this.DeviceScaleFactor;
					if (!(num.GetValueOrDefault() == num2 & num != null))
					{
						goto IL_62;
					}
				}
				return Task.FromResult<bool>(true);
			}
			IL_62:
			int scaledWidth = (int)((float)width * this.DeviceScaleFactor);
			int scaledHeight = (int)((float)height * this.DeviceScaleFactor);
			TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
			EventHandler<OnPaintEventArgs> handler = null;
			handler = delegate(object s, OnPaintEventArgs e)
			{
				if (e.Width == scaledWidth && e.Height == scaledHeight)
				{
					this.AfterPaint -= handler;
					tcs.TrySetResultAsync(true);
				}
			};
			this.AfterPaint += handler;
			if (deviceScaleFactor != null)
			{
				scaledWidth = (int)((float)width * deviceScaleFactor.Value);
				scaledHeight = (int)((float)height * deviceScaleFactor.Value);
				this.DeviceScaleFactor = deviceScaleFactor.Value;
			}
			this.Size = new System.Drawing.Size(width, height);
			return tcs.Task;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002B38 File Offset: 0x00000D38
		public Task<CefSharp.DevTools.DOM.Rect> GetContentSizeAsync()
		{
			ChromiumWebBrowser.<GetContentSizeAsync>d__73 <GetContentSizeAsync>d__;
			<GetContentSizeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<CefSharp.DevTools.DOM.Rect>.Create();
			<GetContentSizeAsync>d__.<>4__this = this;
			<GetContentSizeAsync>d__.<>1__state = -1;
			<GetContentSizeAsync>d__.<>t__builder.Start<ChromiumWebBrowser.<GetContentSizeAsync>d__73>(ref <GetContentSizeAsync>d__);
			return <GetContentSizeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002B7C File Offset: 0x00000D7C
		public void Load(string url)
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (this.IsBrowserInitialized)
			{
				using (IFrame mainFrame = this.GetMainFrame())
				{
					mainFrame.LoadUrl(url);
					return;
				}
			}
			this.Address = url;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002BCC File Offset: 0x00000DCC
		public IJavascriptObjectRepository JavascriptObjectRepository
		{
			get
			{
				IBrowserAdapter browserAdapter = this.managedCefBrowserAdapter;
				if (browserAdapter == null)
				{
					return null;
				}
				return browserAdapter.JavascriptObjectRepository;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002BDF File Offset: 0x00000DDF
		bool IChromiumWebBrowserBase.Focus()
		{
			return false;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002BE2 File Offset: 0x00000DE2
		public IBrowser GetBrowser()
		{
			this.ThrowExceptionIfDisposed();
			this.ThrowExceptionIfBrowserNotInitialized();
			return this.browser;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002BF6 File Offset: 0x00000DF6
		ScreenInfo? IRenderWebBrowser.GetScreenInfo()
		{
			return this.GetScreenInfo();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002C00 File Offset: 0x00000E00
		protected virtual ScreenInfo? GetScreenInfo()
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return null;
			}
			return renderHandler.GetScreenInfo();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002C26 File Offset: 0x00000E26
		CefSharp.Structs.Rect IRenderWebBrowser.GetViewRect()
		{
			return this.GetViewRect();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002C2E File Offset: 0x00000E2E
		protected virtual CefSharp.Structs.Rect GetViewRect()
		{
			if (this.RenderHandler == null)
			{
				return new CefSharp.Structs.Rect(0, 0, 640, 480);
			}
			return this.RenderHandler.GetViewRect();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002C55 File Offset: 0x00000E55
		bool IRenderWebBrowser.GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY)
		{
			return this.GetScreenPoint(viewX, viewY, out screenX, out screenY);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002C62 File Offset: 0x00000E62
		protected virtual bool GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY)
		{
			screenX = 0;
			screenY = 0;
			IRenderHandler renderHandler = this.RenderHandler;
			return renderHandler != null && renderHandler.GetScreenPoint(viewX, viewY, out screenX, out screenY);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002C81 File Offset: 0x00000E81
		void IRenderWebBrowser.OnAcceleratedPaint(PaintElementType type, CefSharp.Structs.Rect dirtyRect, IntPtr sharedHandle)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.OnAcceleratedPaint(type, dirtyRect, sharedHandle);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C98 File Offset: 0x00000E98
		void IRenderWebBrowser.OnPaint(PaintElementType type, CefSharp.Structs.Rect dirtyRect, IntPtr buffer, int width, int height)
		{
			bool flag = false;
			OnPaintEventArgs onPaintEventArgs = new OnPaintEventArgs(type == PaintElementType.Popup, dirtyRect, buffer, width, height);
			EventHandler<OnPaintEventArgs> paint = this.Paint;
			if (paint != null)
			{
				paint(this, onPaintEventArgs);
				flag = onPaintEventArgs.Handled;
			}
			if (!flag)
			{
				IRenderHandler renderHandler = this.RenderHandler;
				if (renderHandler != null)
				{
					renderHandler.OnPaint(type, dirtyRect, buffer, width, height);
				}
			}
			EventHandler<OnPaintEventArgs> afterPaint = this.AfterPaint;
			if (afterPaint != null)
			{
				afterPaint(this, onPaintEventArgs);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002CFD File Offset: 0x00000EFD
		void IRenderWebBrowser.OnCursorChange(IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.OnCursorChange(cursor, type, customCursorInfo);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002D12 File Offset: 0x00000F12
		bool IRenderWebBrowser.StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			return renderHandler != null && renderHandler.StartDragging(dragData, mask, x, y);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D2A File Offset: 0x00000F2A
		void IRenderWebBrowser.UpdateDragCursor(DragOperationsMask operation)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.UpdateDragCursor(operation);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D3D File Offset: 0x00000F3D
		void IRenderWebBrowser.OnPopupShow(bool show)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.OnPopupShow(show);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D50 File Offset: 0x00000F50
		void IRenderWebBrowser.OnPopupSize(CefSharp.Structs.Rect rect)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.OnPopupSize(rect);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D63 File Offset: 0x00000F63
		void IRenderWebBrowser.OnImeCompositionRangeChanged(Range selectedRange, CefSharp.Structs.Rect[] characterBounds)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.OnImeCompositionRangeChanged(selectedRange, characterBounds);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002D77 File Offset: 0x00000F77
		void IRenderWebBrowser.OnVirtualKeyboardRequested(IBrowser browser, TextInputMode inputMode)
		{
			IRenderHandler renderHandler = this.RenderHandler;
			if (renderHandler == null)
			{
				return;
			}
			renderHandler.OnVirtualKeyboardRequested(browser, inputMode);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002D8B File Offset: 0x00000F8B
		void IWebBrowserInternal.SetAddress(AddressChangedEventArgs args)
		{
			this.Address = args.Address;
			EventHandler<AddressChangedEventArgs> addressChanged = this.AddressChanged;
			if (addressChanged == null)
			{
				return;
			}
			addressChanged(this, args);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002DAB File Offset: 0x00000FAB
		void IWebBrowserInternal.SetTitle(TitleChangedEventArgs args)
		{
			EventHandler<TitleChangedEventArgs> titleChanged = this.TitleChanged;
			if (titleChanged == null)
			{
				return;
			}
			titleChanged(this, args);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002DBF File Offset: 0x00000FBF
		void IWebBrowserInternal.SetTooltipText(string tooltipText)
		{
			this.TooltipText = tooltipText;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002DC8 File Offset: 0x00000FC8
		private Bitmap MergeBitmaps(Bitmap firstBitmap, Bitmap secondBitmap, System.Drawing.Point secondBitmapPosition)
		{
			Bitmap bitmap = new Bitmap(firstBitmap.Width, firstBitmap.Height, PixelFormat.Format32bppPArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(firstBitmap, new Rectangle(0, 0, firstBitmap.Width, firstBitmap.Height));
				graphics.DrawImage(secondBitmap, new Rectangle(secondBitmapPosition.X, secondBitmapPosition.Y, secondBitmap.Width, secondBitmap.Height));
			}
			return bitmap;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002E50 File Offset: 0x00001050
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002E58 File Offset: 0x00001058
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IBrowser BrowserCore { get; internal set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002E61 File Offset: 0x00001061
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002E69 File Offset: 0x00001069
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		public bool CanExecuteJavascriptInMainFrame { get; private set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002E72 File Offset: 0x00001072
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002E7A File Offset: 0x0000107A
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IDialogHandler DialogHandler { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002E83 File Offset: 0x00001083
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002E8B File Offset: 0x0000108B
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IJsDialogHandler JsDialogHandler { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002E94 File Offset: 0x00001094
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002E9C File Offset: 0x0000109C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IKeyboardHandler KeyboardHandler { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002EA5 File Offset: 0x000010A5
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002EAD File Offset: 0x000010AD
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IRequestHandler RequestHandler { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002EB6 File Offset: 0x000010B6
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002EBE File Offset: 0x000010BE
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IDownloadHandler DownloadHandler { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002EC7 File Offset: 0x000010C7
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002ECF File Offset: 0x000010CF
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public ILoadHandler LoadHandler { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002ED8 File Offset: 0x000010D8
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002EE0 File Offset: 0x000010E0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public ILifeSpanHandler LifeSpanHandler { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002EE9 File Offset: 0x000010E9
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002EF1 File Offset: 0x000010F1
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IDisplayHandler DisplayHandler { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002EFA File Offset: 0x000010FA
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00002F02 File Offset: 0x00001102
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IContextMenuHandler MenuHandler { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002F0B File Offset: 0x0000110B
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00002F13 File Offset: 0x00001113
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IRenderProcessMessageHandler RenderProcessMessageHandler { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002F1C File Offset: 0x0000111C
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002F24 File Offset: 0x00001124
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IFindHandler FindHandler { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002F2D File Offset: 0x0000112D
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002F35 File Offset: 0x00001135
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IAudioHandler AudioHandler { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002F3E File Offset: 0x0000113E
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00002F46 File Offset: 0x00001146
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IFrameHandler FrameHandler { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002F4F File Offset: 0x0000114F
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002F57 File Offset: 0x00001157
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IFocusHandler FocusHandler { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002F60 File Offset: 0x00001160
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002F68 File Offset: 0x00001168
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IDragHandler DragHandler { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002F71 File Offset: 0x00001171
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002F79 File Offset: 0x00001179
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public IResourceRequestHandlerFactory ResourceRequestHandlerFactory { get; set; }

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000079 RID: 121 RVA: 0x00002F84 File Offset: 0x00001184
		// (remove) Token: 0x0600007A RID: 122 RVA: 0x00002FBC File Offset: 0x000011BC
		public event EventHandler<LoadErrorEventArgs> LoadError;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600007B RID: 123 RVA: 0x00002FF4 File Offset: 0x000011F4
		// (remove) Token: 0x0600007C RID: 124 RVA: 0x0000302C File Offset: 0x0000122C
		public event EventHandler<FrameLoadStartEventArgs> FrameLoadStart;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600007D RID: 125 RVA: 0x00003064 File Offset: 0x00001264
		// (remove) Token: 0x0600007E RID: 126 RVA: 0x0000309C File Offset: 0x0000129C
		public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600007F RID: 127 RVA: 0x000030D4 File Offset: 0x000012D4
		// (remove) Token: 0x06000080 RID: 128 RVA: 0x0000310C File Offset: 0x0000130C
		public event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000081 RID: 129 RVA: 0x00003144 File Offset: 0x00001344
		// (remove) Token: 0x06000082 RID: 130 RVA: 0x0000317C File Offset: 0x0000137C
		public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000083 RID: 131 RVA: 0x000031B4 File Offset: 0x000013B4
		// (remove) Token: 0x06000084 RID: 132 RVA: 0x000031EC File Offset: 0x000013EC
		public event EventHandler<StatusMessageEventArgs> StatusMessage;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000085 RID: 133 RVA: 0x00003224 File Offset: 0x00001424
		// (remove) Token: 0x06000086 RID: 134 RVA: 0x0000325C File Offset: 0x0000145C
		public event EventHandler<JavascriptMessageReceivedEventArgs> JavascriptMessageReceived;

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003291 File Offset: 0x00001491
		bool IChromiumWebBrowserBase.IsBrowserInitialized
		{
			get
			{
				return this.InternalIsBrowserInitialized();
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003299 File Offset: 0x00001499
		void IWebBrowserInternal.SetCanExecuteJavascriptOnMainFrame(long frameId, bool canExecute)
		{
			if (frameId > this.canExecuteJavascriptInMainFrameId && !canExecute)
			{
				return;
			}
			this.canExecuteJavascriptInMainFrameId = frameId;
			this.CanExecuteJavascriptInMainFrame = canExecute;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000032B8 File Offset: 0x000014B8
		void IWebBrowserInternal.SetJavascriptMessageReceived(JavascriptMessageReceivedEventArgs args)
		{
			Task.Run(delegate()
			{
				EventHandler<JavascriptMessageReceivedEventArgs> javascriptMessageReceived = this.JavascriptMessageReceived;
				if (javascriptMessageReceived == null)
				{
					return;
				}
				javascriptMessageReceived(this, args);
			});
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000032EB File Offset: 0x000014EB
		void IWebBrowserInternal.OnFrameLoadStart(FrameLoadStartEventArgs args)
		{
			EventHandler<FrameLoadStartEventArgs> frameLoadStart = this.FrameLoadStart;
			if (frameLoadStart == null)
			{
				return;
			}
			frameLoadStart(this, args);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000032FF File Offset: 0x000014FF
		void IWebBrowserInternal.OnFrameLoadEnd(FrameLoadEndEventArgs args)
		{
			EventHandler<FrameLoadEndEventArgs> frameLoadEnd = this.FrameLoadEnd;
			if (frameLoadEnd == null)
			{
				return;
			}
			frameLoadEnd(this, args);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003313 File Offset: 0x00001513
		void IWebBrowserInternal.OnConsoleMessage(ConsoleMessageEventArgs args)
		{
			EventHandler<ConsoleMessageEventArgs> consoleMessage = this.ConsoleMessage;
			if (consoleMessage == null)
			{
				return;
			}
			consoleMessage(this, args);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003327 File Offset: 0x00001527
		void IWebBrowserInternal.OnStatusMessage(StatusMessageEventArgs args)
		{
			EventHandler<StatusMessageEventArgs> statusMessage = this.StatusMessage;
			if (statusMessage == null)
			{
				return;
			}
			statusMessage(this, args);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000333C File Offset: 0x0000153C
		void IWebBrowserInternal.OnLoadError(LoadErrorEventArgs args)
		{
			EventHandler<LoadErrorEventArgs> loadError = this.LoadError;
			if (loadError != null)
			{
				loadError(this, args);
			}
			Action<bool?, CefErrorCode?> action = this.initialLoadAction;
			if (action == null)
			{
				return;
			}
			action(null, new CefErrorCode?(args.ErrorCode));
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00003380 File Offset: 0x00001580
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00003388 File Offset: 0x00001588
		bool IWebBrowserInternal.HasParent { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003391 File Offset: 0x00001591
		IBrowserAdapter IWebBrowserInternal.BrowserAdapter
		{
			get
			{
				return this.managedCefBrowserAdapter;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000339C File Offset: 0x0000159C
		void IWebBrowserInternal.OnAfterBrowserCreated(IBrowser browser)
		{
			if (this.IsDisposed || browser.IsDisposed)
			{
				return;
			}
			this.browser = browser;
			this.BrowserCore = browser;
			this.initialLoadAction = new Action<bool?, CefErrorCode?>(this.InitialLoad);
			Interlocked.Exchange(ref this.browserInitialized, 1);
			this.OnAfterBrowserCreated(browser);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000033F0 File Offset: 0x000015F0
		void IWebBrowserInternal.SetLoadingStateChange(LoadingStateChangedEventArgs args)
		{
			this.SetLoadingStateChange(args);
			EventHandler<LoadingStateChangedEventArgs> loadingStateChanged = this.LoadingStateChanged;
			if (loadingStateChanged != null)
			{
				loadingStateChanged(this, args);
			}
			Action<bool?, CefErrorCode?> action = this.initialLoadAction;
			if (action == null)
			{
				return;
			}
			action(new bool?(args.IsLoading), null);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000343B File Offset: 0x0000163B
		public void LoadUrl(string url)
		{
			this.Load(url);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003444 File Offset: 0x00001644
		public Task<LoadUrlAsyncResponse> LoadUrlAsync(string url)
		{
			return WebBrowserExtensions.LoadUrlAsync(this, url);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000344D File Offset: 0x0000164D
		public Task<LoadUrlAsyncResponse> WaitForInitialLoadAsync()
		{
			return this.initialLoadTaskCompletionSource.Task;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000345C File Offset: 0x0000165C
		public bool TryGetBrowserCoreById(int browserId, out IBrowser browser)
		{
			IBrowserAdapter browserAdapter = this.managedCefBrowserAdapter;
			if (this.IsDisposed || browserAdapter == null || browserAdapter.IsDisposed)
			{
				browser = null;
				return false;
			}
			browser = browserAdapter.GetBrowser(browserId);
			return browser != null;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003498 File Offset: 0x00001698
		private void InitialLoad(bool? isLoading, CefErrorCode? errorCode)
		{
			if (this.IsDisposed)
			{
				this.initialLoadAction = null;
				this.initialLoadTaskCompletionSource.TrySetCanceled();
				return;
			}
			if (isLoading == null)
			{
				if (errorCode != null)
				{
					CefErrorCode? cefErrorCode = errorCode;
					CefErrorCode cefErrorCode2 = CefErrorCode.Aborted;
					if (cefErrorCode.GetValueOrDefault() == cefErrorCode2 & cefErrorCode != null)
					{
						return;
					}
					this.initialLoadAction = null;
					this.initialLoadTaskCompletionSource.TrySetResultAsync(new LoadUrlAsyncResponse(errorCode.Value, -1));
				}
				return;
			}
			if (isLoading.Value)
			{
				return;
			}
			this.initialLoadAction = null;
			IBrowser browser = this.browser;
			IBrowserHost browserHost = (browser != null) ? browser.GetHost() : null;
			NavigationEntry navigationEntry = (browserHost != null) ? browserHost.GetVisibleNavigationEntry() : null;
			int num = (navigationEntry != null) ? navigationEntry.HttpStatusCode : -1;
			if (num == 0)
			{
				num = -1;
			}
			this.initialLoadTaskCompletionSource.TrySetResultAsync(new LoadUrlAsyncResponse(CefErrorCode.None, num));
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003564 File Offset: 0x00001764
		private void OnAfterBrowserCreated(IBrowser browser)
		{
			Action<IBrowser> action = this.onAfterBrowserCreatedDelegate;
			if (action != null)
			{
				action(browser);
			}
			EventHandler eventHandler = this.BrowserInitialized;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000358E File Offset: 0x0000178E
		private void SetLoadingStateChange(LoadingStateChangedEventArgs args)
		{
			this.CanGoBack = args.CanGoBack;
			this.CanGoForward = args.CanGoForward;
			this.IsLoading = args.IsLoading;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000035B4 File Offset: 0x000017B4
		private void FreeHandlersExceptLifeSpanAndFocus()
		{
			IAudioHandler audioHandler = this.AudioHandler;
			if (audioHandler != null)
			{
				audioHandler.Dispose();
			}
			this.AudioHandler = null;
			this.DialogHandler = null;
			this.FindHandler = null;
			this.RequestHandler = null;
			this.DisplayHandler = null;
			this.LoadHandler = null;
			this.KeyboardHandler = null;
			this.JsDialogHandler = null;
			this.DragHandler = null;
			this.DownloadHandler = null;
			this.MenuHandler = null;
			this.ResourceRequestHandlerFactory = null;
			this.RenderProcessMessageHandler = null;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000362D File Offset: 0x0000182D
		private bool InternalIsBrowserInitialized()
		{
			return Interlocked.CompareExchange(ref this.browserInitialized, 0, 0) == 1;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000363F File Offset: 0x0000183F
		private void ThrowExceptionIfBrowserNotInitialized()
		{
			if (!this.InternalIsBrowserInitialized())
			{
				throw new Exception("The ChromiumWebBrowser instance creates the underlying Chromium Embedded Framework (CEF) browser instance in an async fashion. The undelying CefBrowser instance is not yet initialized. Use the IsBrowserInitializedChanged event and check the IsBrowserInitialized property to determine when the browser has been initialized.");
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003654 File Offset: 0x00001854
		private void ThrowExceptionIfDisposed()
		{
			if (this.IsDisposed)
			{
				throw new ObjectDisposedException("browser", "Browser has been disposed");
			}
		}

		// Token: 0x04000009 RID: 9
		private IBrowserAdapter managedCefBrowserAdapter;

		// Token: 0x0400000A RID: 10
		private System.Drawing.Size size = new System.Drawing.Size(1366, 768);

		// Token: 0x0400000B RID: 11
		private bool browserCreated;

		// Token: 0x0400000C RID: 12
		private Action<IBrowser> onAfterBrowserCreatedDelegate;

		// Token: 0x0400000D RID: 13
		private float deviceScaleFactor = 1f;

		// Token: 0x0400001B RID: 27
		public const string BrowserNotInitializedExceptionErrorMessage = "The ChromiumWebBrowser instance creates the underlying Chromium Embedded Framework (CEF) browser instance in an async fashion. The undelying CefBrowser instance is not yet initialized. Use the IsBrowserInitializedChanged event and check the IsBrowserInitialized property to determine when the browser has been initialized.";

		// Token: 0x0400001C RID: 28
		private const string CefInitializeFailedErrorMessage = "Cef.Initialize() failed.Check the log file see https://github.com/cefsharp/CefSharp/wiki/Trouble-Shooting#log-file for details.";

		// Token: 0x0400001D RID: 29
		private long canExecuteJavascriptInMainFrameId;

		// Token: 0x0400001E RID: 30
		private int browserInitialized;

		// Token: 0x0400001F RID: 31
		private int disposeSignaled;

		// Token: 0x04000020 RID: 32
		private IBrowser browser;

		// Token: 0x04000021 RID: 33
		private TaskCompletionSource<LoadUrlAsyncResponse> initialLoadTaskCompletionSource = new TaskCompletionSource<LoadUrlAsyncResponse>();

		// Token: 0x04000022 RID: 34
		private Action<bool?, CefErrorCode?> initialLoadAction;
	}
}
