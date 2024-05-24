using System;
using System.Threading.Tasks;
using CefSharp.Core;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000003 RID: 3
	public static class Cef
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002359 File Offset: 0x00000559
		public static TaskFactory UIThreadTaskFactory
		{
			get
			{
				return Cef.UIThreadTaskFactory;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002360 File Offset: 0x00000560
		public static TaskFactory IOThreadTaskFactory
		{
			get
			{
				return Cef.IOThreadTaskFactory;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002367 File Offset: 0x00000567
		public static TaskFactory FileThreadTaskFactory
		{
			get
			{
				return Cef.FileThreadTaskFactory;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000236E File Offset: 0x0000056E
		public static void AddDisposable(IDisposable item)
		{
			Cef.AddDisposable(item);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002376 File Offset: 0x00000576
		public static void RemoveDisposable(IDisposable item)
		{
			Cef.RemoveDisposable(item);
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000237E File Offset: 0x0000057E
		public static bool IsInitialized
		{
			get
			{
				return Cef.IsInitialized;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002385 File Offset: 0x00000585
		public static bool IsShutdown
		{
			get
			{
				return Cef.IsShutdown;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000042 RID: 66 RVA: 0x0000238C File Offset: 0x0000058C
		public static string CefSharpVersion
		{
			get
			{
				return Cef.CefSharpVersion;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002393 File Offset: 0x00000593
		public static string CefVersion
		{
			get
			{
				return Cef.CefVersion;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000239A File Offset: 0x0000059A
		public static string ChromiumVersion
		{
			get
			{
				return Cef.ChromiumVersion;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000023A1 File Offset: 0x000005A1
		public static string CefCommitHash
		{
			get
			{
				return Cef.CefCommitHash;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000023A8 File Offset: 0x000005A8
		public static UrlParts ParseUrl(string url)
		{
			return Cef.ParseUrl(url);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000023B0 File Offset: 0x000005B0
		public static bool Initialize(CefSettingsBase settings)
		{
			bool result;
			try
			{
				result = Cef.Initialize(settings.settings);
			}
			finally
			{
				if (settings != null)
				{
					((IDisposable)settings).Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000023E8 File Offset: 0x000005E8
		public static bool Initialize(CefSettingsBase settings, bool performDependencyCheck)
		{
			bool result;
			try
			{
				result = Cef.Initialize(settings.settings, performDependencyCheck);
			}
			finally
			{
				if (settings != null)
				{
					((IDisposable)settings).Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002424 File Offset: 0x00000624
		public static bool Initialize(CefSettingsBase settings, bool performDependencyCheck, IBrowserProcessHandler browserProcessHandler)
		{
			bool result;
			try
			{
				result = Cef.Initialize(settings.settings, performDependencyCheck, browserProcessHandler);
			}
			finally
			{
				if (settings != null)
				{
					((IDisposable)settings).Dispose();
				}
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002460 File Offset: 0x00000660
		public static bool Initialize(CefSettingsBase settings, bool performDependencyCheck, IApp cefApp)
		{
			bool result;
			try
			{
				result = Cef.Initialize(settings.settings, performDependencyCheck, cefApp);
			}
			finally
			{
				if (settings != null)
				{
					((IDisposable)settings).Dispose();
				}
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000249C File Offset: 0x0000069C
		public static Task<bool> InitializeAsync(CefSettingsBase settings, bool performDependencyCheck = true, IBrowserProcessHandler browserProcessHandler = null)
		{
			try
			{
				Cef.Initialize(settings.settings, performDependencyCheck, browserProcessHandler);
			}
			catch (Exception exception)
			{
				GlobalContextInitialized.SetException(exception);
			}
			finally
			{
				if (settings != null)
				{
					((IDisposable)settings).Dispose();
				}
			}
			return GlobalContextInitialized.Task;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000024F0 File Offset: 0x000006F0
		public static void RunMessageLoop()
		{
			Cef.RunMessageLoop();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000024F7 File Offset: 0x000006F7
		public static void QuitMessageLoop()
		{
			Cef.QuitMessageLoop();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000024FE File Offset: 0x000006FE
		public static void DoMessageLoopWork()
		{
			Cef.DoMessageLoopWork();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002505 File Offset: 0x00000705
		public static int ExecuteProcess()
		{
			return Cef.ExecuteProcess();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000250C File Offset: 0x0000070C
		public static bool AddCrossOriginWhitelistEntry(string sourceOrigin, string targetProtocol, string targetDomain, bool allowTargetSubdomains)
		{
			return Cef.AddCrossOriginWhitelistEntry(sourceOrigin, targetProtocol, targetDomain, allowTargetSubdomains);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002517 File Offset: 0x00000717
		public static bool RemoveCrossOriginWhitelistEntry(string sourceOrigin, string targetProtocol, string targetDomain, bool allowTargetSubdomains)
		{
			return Cef.RemoveCrossOriginWhitelistEntry(sourceOrigin, targetProtocol, targetDomain, allowTargetSubdomains);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002522 File Offset: 0x00000722
		public static bool ClearCrossOriginWhitelist()
		{
			return Cef.ClearCrossOriginWhitelist();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002529 File Offset: 0x00000729
		public static ICookieManager GetGlobalCookieManager(ICompletionCallback callback = null)
		{
			return Cef.GetGlobalCookieManager(callback);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002531 File Offset: 0x00000731
		public static void PreShutdown()
		{
			Cef.PreShutdown();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002538 File Offset: 0x00000738
		public static void Shutdown()
		{
			Cef.Shutdown();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000253F File Offset: 0x0000073F
		public static void ShutdownWithoutChecks()
		{
			Cef.ShutdownWithoutChecks();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002546 File Offset: 0x00000746
		public static bool ClearSchemeHandlerFactories()
		{
			return Cef.ClearSchemeHandlerFactories();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000254D File Offset: 0x0000074D
		public static void EnableHighDPISupport()
		{
			Cef.EnableHighDPISupport();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002554 File Offset: 0x00000754
		public static bool CurrentlyOnThread(CefThreadIds threadId)
		{
			return Cef.CurrentlyOnThread(threadId);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000255C File Offset: 0x0000075C
		public static IRequestContext GetGlobalRequestContext()
		{
			return Cef.GetGlobalRequestContext();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002563 File Offset: 0x00000763
		public static uint ColorSetARGB(uint a, uint r, uint g, uint b)
		{
			return Cef.ColorSetARGB(a, r, g, b);
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000256E File Offset: 0x0000076E
		public static bool CrashReportingEnabled
		{
			get
			{
				return Cef.CrashReportingEnabled;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002575 File Offset: 0x00000775
		public static void SetCrashKeyValue(string key, string value)
		{
			Cef.SetCrashKeyValue(key, value);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002580 File Offset: 0x00000780
		public static LogSeverity GetMinLogLevel()
		{
			int minLogLevel = Cef.GetMinLogLevel();
			if (minLogLevel == -1)
			{
				return LogSeverity.Verbose;
			}
			if (minLogLevel == 0)
			{
				return LogSeverity.Info;
			}
			if (minLogLevel == 1)
			{
				return LogSeverity.Warning;
			}
			if (minLogLevel == 2)
			{
				return LogSeverity.Error;
			}
			if (minLogLevel == 3)
			{
				return LogSeverity.Fatal;
			}
			return (LogSeverity)minLogLevel;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000025B1 File Offset: 0x000007B1
		public static string GetMimeType(string extension)
		{
			return Cef.GetMimeType(extension);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000025B9 File Offset: 0x000007B9
		public static void EnableWaitForBrowsersToClose()
		{
			Cef.EnableWaitForBrowsersToClose();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000025C0 File Offset: 0x000007C0
		public static void WaitForBrowsersToClose()
		{
			Cef.WaitForBrowsersToClose();
		}
	}
}
