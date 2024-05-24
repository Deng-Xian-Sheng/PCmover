using System;
using System.ComponentModel;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x02000002 RID: 2
	public class BrowserSettings : IBrowserSettings, IDisposable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public BrowserSettings(bool autoDispose = false)
		{
			this.settings = new BrowserSettings(autoDispose);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002071 File Offset: 0x00000271
		public string StandardFontFamily
		{
			get
			{
				return this.settings.StandardFontFamily;
			}
			set
			{
				this.settings.StandardFontFamily = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000207F File Offset: 0x0000027F
		// (set) Token: 0x06000005 RID: 5 RVA: 0x0000208C File Offset: 0x0000028C
		public string FixedFontFamily
		{
			get
			{
				return this.settings.FixedFontFamily;
			}
			set
			{
				this.settings.FixedFontFamily = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000209A File Offset: 0x0000029A
		// (set) Token: 0x06000007 RID: 7 RVA: 0x000020A7 File Offset: 0x000002A7
		public string SerifFontFamily
		{
			get
			{
				return this.settings.SerifFontFamily;
			}
			set
			{
				this.settings.SerifFontFamily = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020B5 File Offset: 0x000002B5
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020C2 File Offset: 0x000002C2
		public string SansSerifFontFamily
		{
			get
			{
				return this.settings.SansSerifFontFamily;
			}
			set
			{
				this.settings.SansSerifFontFamily = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020D0 File Offset: 0x000002D0
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020DD File Offset: 0x000002DD
		public string CursiveFontFamily
		{
			get
			{
				return this.settings.CursiveFontFamily;
			}
			set
			{
				this.settings.CursiveFontFamily = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020EB File Offset: 0x000002EB
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020F8 File Offset: 0x000002F8
		public string FantasyFontFamily
		{
			get
			{
				return this.settings.FantasyFontFamily;
			}
			set
			{
				this.settings.FantasyFontFamily = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002106 File Offset: 0x00000306
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002113 File Offset: 0x00000313
		public int DefaultFontSize
		{
			get
			{
				return this.settings.DefaultFontSize;
			}
			set
			{
				this.settings.DefaultFontSize = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002121 File Offset: 0x00000321
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000212E File Offset: 0x0000032E
		public int DefaultFixedFontSize
		{
			get
			{
				return this.settings.DefaultFixedFontSize;
			}
			set
			{
				this.settings.DefaultFixedFontSize = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000012 RID: 18 RVA: 0x0000213C File Offset: 0x0000033C
		// (set) Token: 0x06000013 RID: 19 RVA: 0x00002149 File Offset: 0x00000349
		public int MinimumFontSize
		{
			get
			{
				return this.settings.MinimumFontSize;
			}
			set
			{
				this.settings.MinimumFontSize = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002157 File Offset: 0x00000357
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00002164 File Offset: 0x00000364
		public int MinimumLogicalFontSize
		{
			get
			{
				return this.settings.MinimumLogicalFontSize;
			}
			set
			{
				this.settings.MinimumLogicalFontSize = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002172 File Offset: 0x00000372
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000217F File Offset: 0x0000037F
		public string DefaultEncoding
		{
			get
			{
				return this.settings.DefaultEncoding;
			}
			set
			{
				this.settings.DefaultEncoding = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000018 RID: 24 RVA: 0x0000218D File Offset: 0x0000038D
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000219A File Offset: 0x0000039A
		public CefState RemoteFonts
		{
			get
			{
				return this.settings.RemoteFonts;
			}
			set
			{
				this.settings.RemoteFonts = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000021A8 File Offset: 0x000003A8
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000021B5 File Offset: 0x000003B5
		public CefState Javascript
		{
			get
			{
				return this.settings.Javascript;
			}
			set
			{
				this.settings.Javascript = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000021C3 File Offset: 0x000003C3
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000021D0 File Offset: 0x000003D0
		public CefState JavascriptCloseWindows
		{
			get
			{
				return this.settings.JavascriptCloseWindows;
			}
			set
			{
				this.settings.JavascriptCloseWindows = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000021DE File Offset: 0x000003DE
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000021EB File Offset: 0x000003EB
		public CefState JavascriptAccessClipboard
		{
			get
			{
				return this.settings.JavascriptAccessClipboard;
			}
			set
			{
				this.settings.JavascriptAccessClipboard = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000021F9 File Offset: 0x000003F9
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002206 File Offset: 0x00000406
		public CefState JavascriptDomPaste
		{
			get
			{
				return this.settings.JavascriptDomPaste;
			}
			set
			{
				this.settings.JavascriptDomPaste = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002214 File Offset: 0x00000414
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002221 File Offset: 0x00000421
		public CefState ImageLoading
		{
			get
			{
				return this.settings.ImageLoading;
			}
			set
			{
				this.settings.ImageLoading = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000222F File Offset: 0x0000042F
		// (set) Token: 0x06000025 RID: 37 RVA: 0x0000223C File Offset: 0x0000043C
		public CefState ImageShrinkStandaloneToFit
		{
			get
			{
				return this.settings.ImageShrinkStandaloneToFit;
			}
			set
			{
				this.settings.ImageShrinkStandaloneToFit = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000224A File Offset: 0x0000044A
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002257 File Offset: 0x00000457
		public CefState TextAreaResize
		{
			get
			{
				return this.settings.TextAreaResize;
			}
			set
			{
				this.settings.TextAreaResize = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002265 File Offset: 0x00000465
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002272 File Offset: 0x00000472
		public CefState TabToLinks
		{
			get
			{
				return this.settings.TabToLinks;
			}
			set
			{
				this.settings.TabToLinks = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002280 File Offset: 0x00000480
		// (set) Token: 0x0600002B RID: 43 RVA: 0x0000228D File Offset: 0x0000048D
		public CefState LocalStorage
		{
			get
			{
				return this.settings.LocalStorage;
			}
			set
			{
				this.settings.LocalStorage = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000229B File Offset: 0x0000049B
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000022A8 File Offset: 0x000004A8
		public CefState Databases
		{
			get
			{
				return this.settings.Databases;
			}
			set
			{
				this.settings.Databases = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000022B6 File Offset: 0x000004B6
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000022C3 File Offset: 0x000004C3
		public CefState WebGl
		{
			get
			{
				return this.settings.WebGl;
			}
			set
			{
				this.settings.WebGl = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000022D1 File Offset: 0x000004D1
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000022DE File Offset: 0x000004DE
		public uint BackgroundColor
		{
			get
			{
				return this.settings.BackgroundColor;
			}
			set
			{
				this.settings.BackgroundColor = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000022EC File Offset: 0x000004EC
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000022F9 File Offset: 0x000004F9
		public string AcceptLanguageList
		{
			get
			{
				return this.settings.AcceptLanguageList;
			}
			set
			{
				this.settings.AcceptLanguageList = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002307 File Offset: 0x00000507
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002314 File Offset: 0x00000514
		public int WindowlessFrameRate
		{
			get
			{
				return this.settings.WindowlessFrameRate;
			}
			set
			{
				this.settings.WindowlessFrameRate = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002322 File Offset: 0x00000522
		public bool IsDisposed
		{
			get
			{
				return this.settings.IsDisposed;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000232F File Offset: 0x0000052F
		public bool AutoDispose
		{
			get
			{
				return this.settings.AutoDispose;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000233C File Offset: 0x0000053C
		public void Dispose()
		{
			this.settings.Dispose();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002349 File Offset: 0x00000549
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IBrowserSettings UnWrap()
		{
			return this.settings;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002351 File Offset: 0x00000551
		public static IBrowserSettings Create(bool autoDispose = false)
		{
			return new BrowserSettings(autoDispose);
		}

		// Token: 0x04000001 RID: 1
		private BrowserSettings settings;
	}
}
