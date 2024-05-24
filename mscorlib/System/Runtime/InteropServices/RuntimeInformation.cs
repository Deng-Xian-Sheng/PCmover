using System;
using System.Reflection;
using System.Security;
using Microsoft.Win32;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009AA RID: 2474
	public static class RuntimeInformation
	{
		// Token: 0x1700111B RID: 4379
		// (get) Token: 0x06006302 RID: 25346 RVA: 0x00151790 File Offset: 0x0014F990
		public static string FrameworkDescription
		{
			get
			{
				if (RuntimeInformation.s_frameworkDescription == null)
				{
					AssemblyFileVersionAttribute assemblyFileVersionAttribute = (AssemblyFileVersionAttribute)typeof(object).GetTypeInfo().Assembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute));
					RuntimeInformation.s_frameworkDescription = ".NET Framework " + assemblyFileVersionAttribute.Version;
				}
				return RuntimeInformation.s_frameworkDescription;
			}
		}

		// Token: 0x06006303 RID: 25347 RVA: 0x001517E7 File Offset: 0x0014F9E7
		public static bool IsOSPlatform(OSPlatform osPlatform)
		{
			return OSPlatform.Windows == osPlatform;
		}

		// Token: 0x1700111C RID: 4380
		// (get) Token: 0x06006304 RID: 25348 RVA: 0x001517F4 File Offset: 0x0014F9F4
		public static string OSDescription
		{
			[SecuritySafeCritical]
			get
			{
				if (RuntimeInformation.s_osDescription == null)
				{
					RuntimeInformation.s_osDescription = RuntimeInformation.RtlGetVersion();
				}
				return RuntimeInformation.s_osDescription;
			}
		}

		// Token: 0x1700111D RID: 4381
		// (get) Token: 0x06006305 RID: 25349 RVA: 0x0015180C File Offset: 0x0014FA0C
		public static Architecture OSArchitecture
		{
			[SecuritySafeCritical]
			get
			{
				object obj = RuntimeInformation.s_osLock;
				lock (obj)
				{
					if (RuntimeInformation.s_osArch == null)
					{
						Win32Native.SYSTEM_INFO system_INFO;
						Win32Native.GetNativeSystemInfo(out system_INFO);
						RuntimeInformation.s_osArch = new Architecture?(RuntimeInformation.GetArchitecture(system_INFO.wProcessorArchitecture));
					}
				}
				return RuntimeInformation.s_osArch.Value;
			}
		}

		// Token: 0x1700111E RID: 4382
		// (get) Token: 0x06006306 RID: 25350 RVA: 0x00151878 File Offset: 0x0014FA78
		public static Architecture ProcessArchitecture
		{
			[SecuritySafeCritical]
			get
			{
				object obj = RuntimeInformation.s_processLock;
				lock (obj)
				{
					if (RuntimeInformation.s_processArch == null)
					{
						Win32Native.SYSTEM_INFO system_INFO = default(Win32Native.SYSTEM_INFO);
						Win32Native.GetSystemInfo(ref system_INFO);
						RuntimeInformation.s_processArch = new Architecture?(RuntimeInformation.GetArchitecture(system_INFO.wProcessorArchitecture));
					}
				}
				return RuntimeInformation.s_processArch.Value;
			}
		}

		// Token: 0x06006307 RID: 25351 RVA: 0x001518EC File Offset: 0x0014FAEC
		private static Architecture GetArchitecture(ushort wProcessorArchitecture)
		{
			Architecture result = Architecture.X86;
			if (wProcessorArchitecture <= 5)
			{
				if (wProcessorArchitecture != 0)
				{
					if (wProcessorArchitecture == 5)
					{
						result = Architecture.Arm;
					}
				}
				else
				{
					result = Architecture.X86;
				}
			}
			else if (wProcessorArchitecture != 9)
			{
				if (wProcessorArchitecture == 12)
				{
					result = Architecture.Arm64;
				}
			}
			else
			{
				result = Architecture.X64;
			}
			return result;
		}

		// Token: 0x06006308 RID: 25352 RVA: 0x00151924 File Offset: 0x0014FB24
		[SecuritySafeCritical]
		private static string RtlGetVersion()
		{
			Win32Native.RTL_OSVERSIONINFOEX rtl_OSVERSIONINFOEX = default(Win32Native.RTL_OSVERSIONINFOEX);
			rtl_OSVERSIONINFOEX.dwOSVersionInfoSize = (uint)Marshal.SizeOf<Win32Native.RTL_OSVERSIONINFOEX>(rtl_OSVERSIONINFOEX);
			if (Win32Native.RtlGetVersion(out rtl_OSVERSIONINFOEX) == 0)
			{
				return string.Format("{0} {1}.{2}.{3} {4}", new object[]
				{
					"Microsoft Windows",
					rtl_OSVERSIONINFOEX.dwMajorVersion,
					rtl_OSVERSIONINFOEX.dwMinorVersion,
					rtl_OSVERSIONINFOEX.dwBuildNumber,
					rtl_OSVERSIONINFOEX.szCSDVersion
				});
			}
			return "Microsoft Windows";
		}

		// Token: 0x04002CA7 RID: 11431
		private const string FrameworkName = ".NET Framework";

		// Token: 0x04002CA8 RID: 11432
		private static string s_frameworkDescription;

		// Token: 0x04002CA9 RID: 11433
		private static string s_osDescription = null;

		// Token: 0x04002CAA RID: 11434
		private static object s_osLock = new object();

		// Token: 0x04002CAB RID: 11435
		private static object s_processLock = new object();

		// Token: 0x04002CAC RID: 11436
		private static Architecture? s_osArch = null;

		// Token: 0x04002CAD RID: 11437
		private static Architecture? s_processArch = null;
	}
}
