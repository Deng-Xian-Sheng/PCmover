using System;
using System.Collections.Generic;
using CefSharp.Core;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000004 RID: 4
	public abstract class CefSettingsBase : IDisposable
	{
		// Token: 0x06000062 RID: 98 RVA: 0x000025C7 File Offset: 0x000007C7
		public void Dispose()
		{
			this.disposed = true;
			this.settings = null;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000025D7 File Offset: 0x000007D7
		public bool IsDisposed
		{
			get
			{
				return this.disposed;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000025DF File Offset: 0x000007DF
		public IEnumerable<CefCustomScheme> CefCustomSchemes
		{
			get
			{
				return this.settings.CefCustomSchemes;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000025EC File Offset: 0x000007EC
		public CommandLineArgDictionary CefCommandLineArgs
		{
			get
			{
				return this.settings.CefCommandLineArgs;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000025F9 File Offset: 0x000007F9
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002606 File Offset: 0x00000806
		public bool ChromeRuntime
		{
			get
			{
				return this.settings.ChromeRuntime;
			}
			set
			{
				this.settings.ChromeRuntime = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002614 File Offset: 0x00000814
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002621 File Offset: 0x00000821
		public bool CommandLineArgsDisabled
		{
			get
			{
				return this.settings.CommandLineArgsDisabled;
			}
			set
			{
				this.settings.CommandLineArgsDisabled = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000262F File Offset: 0x0000082F
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000263C File Offset: 0x0000083C
		public bool ExternalMessagePump
		{
			get
			{
				return this.settings.ExternalMessagePump;
			}
			set
			{
				this.settings.ExternalMessagePump = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000264A File Offset: 0x0000084A
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002657 File Offset: 0x00000857
		public bool MultiThreadedMessageLoop
		{
			get
			{
				return this.settings.MultiThreadedMessageLoop;
			}
			set
			{
				this.settings.MultiThreadedMessageLoop = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002665 File Offset: 0x00000865
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00002672 File Offset: 0x00000872
		public string BrowserSubprocessPath
		{
			get
			{
				return this.settings.BrowserSubprocessPath;
			}
			set
			{
				this.settings.BrowserSubprocessPath = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002680 File Offset: 0x00000880
		// (set) Token: 0x06000071 RID: 113 RVA: 0x0000268D File Offset: 0x0000088D
		public string CachePath
		{
			get
			{
				return this.settings.CachePath;
			}
			set
			{
				this.settings.CachePath = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000269B File Offset: 0x0000089B
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000026A8 File Offset: 0x000008A8
		public string RootCachePath
		{
			get
			{
				return this.settings.RootCachePath;
			}
			set
			{
				this.settings.RootCachePath = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000026B6 File Offset: 0x000008B6
		// (set) Token: 0x06000075 RID: 117 RVA: 0x000026C3 File Offset: 0x000008C3
		public string UserDataPath
		{
			get
			{
				return this.settings.UserDataPath;
			}
			set
			{
				this.settings.UserDataPath = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000026D1 File Offset: 0x000008D1
		// (set) Token: 0x06000077 RID: 119 RVA: 0x000026E8 File Offset: 0x000008E8
		public bool IgnoreCertificateErrors
		{
			get
			{
				return this.settings.CefCommandLineArgs.ContainsKey("ignore-certificate-errors");
			}
			set
			{
				if (value)
				{
					if (!this.settings.CefCommandLineArgs.ContainsKey("ignore-certificate-errors"))
					{
						this.settings.CefCommandLineArgs.Add("ignore-certificate-errors");
						return;
					}
				}
				else if (this.settings.CefCommandLineArgs.ContainsKey("ignore-certificate-errors"))
				{
					this.settings.CefCommandLineArgs.Remove("ignore-certificate-errors");
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002752 File Offset: 0x00000952
		// (set) Token: 0x06000079 RID: 121 RVA: 0x0000275F File Offset: 0x0000095F
		public string Locale
		{
			get
			{
				return this.settings.Locale;
			}
			set
			{
				this.settings.Locale = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000276D File Offset: 0x0000096D
		// (set) Token: 0x0600007B RID: 123 RVA: 0x0000277A File Offset: 0x0000097A
		public string LocalesDirPath
		{
			get
			{
				return this.settings.LocalesDirPath;
			}
			set
			{
				this.settings.LocalesDirPath = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002788 File Offset: 0x00000988
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00002795 File Offset: 0x00000995
		public string ResourcesDirPath
		{
			get
			{
				return this.settings.ResourcesDirPath;
			}
			set
			{
				this.settings.ResourcesDirPath = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000027A3 File Offset: 0x000009A3
		// (set) Token: 0x0600007F RID: 127 RVA: 0x000027B0 File Offset: 0x000009B0
		public string LogFile
		{
			get
			{
				return this.settings.LogFile;
			}
			set
			{
				this.settings.LogFile = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000027BE File Offset: 0x000009BE
		// (set) Token: 0x06000081 RID: 129 RVA: 0x000027CB File Offset: 0x000009CB
		public LogSeverity LogSeverity
		{
			get
			{
				return this.settings.LogSeverity;
			}
			set
			{
				this.settings.LogSeverity = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000027D9 File Offset: 0x000009D9
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000027E6 File Offset: 0x000009E6
		public string JavascriptFlags
		{
			get
			{
				return this.settings.JavascriptFlags;
			}
			set
			{
				this.settings.JavascriptFlags = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000027F4 File Offset: 0x000009F4
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00002801 File Offset: 0x00000A01
		public bool PackLoadingDisabled
		{
			get
			{
				return this.settings.PackLoadingDisabled;
			}
			set
			{
				this.settings.PackLoadingDisabled = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000280F File Offset: 0x00000A0F
		// (set) Token: 0x06000087 RID: 135 RVA: 0x0000281C File Offset: 0x00000A1C
		public string UserAgentProduct
		{
			get
			{
				return this.settings.UserAgentProduct;
			}
			set
			{
				this.settings.UserAgentProduct = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000282A File Offset: 0x00000A2A
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00002837 File Offset: 0x00000A37
		public int RemoteDebuggingPort
		{
			get
			{
				return this.settings.RemoteDebuggingPort;
			}
			set
			{
				this.settings.RemoteDebuggingPort = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00002845 File Offset: 0x00000A45
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00002852 File Offset: 0x00000A52
		public int UncaughtExceptionStackSize
		{
			get
			{
				return this.settings.UncaughtExceptionStackSize;
			}
			set
			{
				this.settings.UncaughtExceptionStackSize = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00002860 File Offset: 0x00000A60
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000286D File Offset: 0x00000A6D
		public string UserAgent
		{
			get
			{
				return this.settings.UserAgent;
			}
			set
			{
				this.settings.UserAgent = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600008E RID: 142 RVA: 0x0000287B File Offset: 0x00000A7B
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00002888 File Offset: 0x00000A88
		public bool WindowlessRenderingEnabled
		{
			get
			{
				return this.settings.WindowlessRenderingEnabled;
			}
			set
			{
				this.settings.WindowlessRenderingEnabled = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00002896 File Offset: 0x00000A96
		// (set) Token: 0x06000091 RID: 145 RVA: 0x000028A3 File Offset: 0x00000AA3
		public bool PersistSessionCookies
		{
			get
			{
				return this.settings.PersistSessionCookies;
			}
			set
			{
				this.settings.PersistSessionCookies = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000028B1 File Offset: 0x00000AB1
		// (set) Token: 0x06000093 RID: 147 RVA: 0x000028BE File Offset: 0x00000ABE
		public bool PersistUserPreferences
		{
			get
			{
				return this.settings.PersistUserPreferences;
			}
			set
			{
				this.settings.PersistUserPreferences = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000028CC File Offset: 0x00000ACC
		// (set) Token: 0x06000095 RID: 149 RVA: 0x000028D9 File Offset: 0x00000AD9
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

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000028E7 File Offset: 0x00000AE7
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000028F4 File Offset: 0x00000AF4
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

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002902 File Offset: 0x00000B02
		// (set) Token: 0x06000099 RID: 153 RVA: 0x0000290F File Offset: 0x00000B0F
		public string CookieableSchemesList
		{
			get
			{
				return this.settings.CookieableSchemesList;
			}
			set
			{
				this.settings.CookieableSchemesList = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000291D File Offset: 0x00000B1D
		// (set) Token: 0x0600009B RID: 155 RVA: 0x0000292A File Offset: 0x00000B2A
		public bool CookieableSchemesExcludeDefaults
		{
			get
			{
				return this.settings.CookieableSchemesExcludeDefaults;
			}
			set
			{
				this.settings.CookieableSchemesExcludeDefaults = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00002938 File Offset: 0x00000B38
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00002945 File Offset: 0x00000B45
		public string ApplicationClientIdForFileScanning
		{
			get
			{
				return this.settings.ApplicationClientIdForFileScanning;
			}
			set
			{
				this.settings.ApplicationClientIdForFileScanning = value;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00002953 File Offset: 0x00000B53
		public void RegisterScheme(CefCustomScheme scheme)
		{
			this.settings.RegisterScheme(scheme);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00002961 File Offset: 0x00000B61
		public void DisableGpuAcceleration()
		{
			if (!this.settings.CefCommandLineArgs.ContainsKey("disable-gpu"))
			{
				this.settings.CefCommandLineArgs.Add("disable-gpu");
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000298F File Offset: 0x00000B8F
		public void EnablePrintPreview()
		{
			if (!this.settings.CefCommandLineArgs.ContainsKey("enable-print-preview"))
			{
				this.settings.CefCommandLineArgs.Add("enable-print-preview");
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000029C0 File Offset: 0x00000BC0
		public void SetOffScreenRenderingBestPerformanceArgs()
		{
			if (!this.settings.CefCommandLineArgs.ContainsKey("disable-gpu"))
			{
				this.settings.CefCommandLineArgs.Add("disable-gpu");
			}
			if (!this.settings.CefCommandLineArgs.ContainsKey("disable-gpu-compositing"))
			{
				this.settings.CefCommandLineArgs.Add("disable-gpu-compositing");
			}
			if (!this.settings.CefCommandLineArgs.ContainsKey("enable-begin-frame-scheduling"))
			{
				this.settings.CefCommandLineArgs.Add("enable-begin-frame-scheduling");
			}
		}

		// Token: 0x04000002 RID: 2
		private bool disposed;

		// Token: 0x04000003 RID: 3
		internal CefSettingsBase settings = new CefSettingsBase();
	}
}
