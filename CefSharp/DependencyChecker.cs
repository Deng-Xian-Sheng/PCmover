using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CefSharp
{
	// Token: 0x0200001F RID: 31
	public static class DependencyChecker
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x00002A9B File Offset: 0x00000C9B
		public static List<string> CheckDependencies(bool checkOptional, bool packLoadingDisabled, string path, string resourcesDirPath, string browserSubProcessPath, string localePackFile = "locales\\en-US.pak")
		{
			return DependencyChecker.CheckDependencies(checkOptional, packLoadingDisabled, path, path, resourcesDirPath, browserSubProcessPath, localePackFile);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002AAC File Offset: 0x00000CAC
		public static List<string> CheckDependencies(bool checkOptional, bool packLoadingDisabled, string managedLibPath, string nativeLibPath, string resourcesDirPath, string browserSubProcessPath, string localePackFile = "locales\\en-US.pak")
		{
			List<string> list = new List<string>();
			list.AddRange(DependencyChecker.CheckDependencyList(nativeLibPath, DependencyChecker.CefDependencies));
			if (!packLoadingDisabled)
			{
				list.AddRange(DependencyChecker.CheckDependencyList(resourcesDirPath, DependencyChecker.CefResources));
			}
			if (checkOptional)
			{
				list.AddRange(DependencyChecker.CheckDependencyList(nativeLibPath, DependencyChecker.CefOptionalDependencies));
			}
			list.AddRange(DependencyChecker.CheckDependencyList(nativeLibPath, DependencyChecker.CefSharpArchSpecificDependencies));
			list.AddRange(DependencyChecker.CheckDependencyList(managedLibPath, DependencyChecker.CefSharpManagedDependencies));
			if (!File.Exists(browserSubProcessPath))
			{
				list.Add(browserSubProcessPath);
			}
			string directoryName = Path.GetDirectoryName(browserSubProcessPath);
			if (directoryName == null)
			{
				list.AddRange(DependencyChecker.BrowserSubprocessDependencies);
			}
			else
			{
				list.AddRange(DependencyChecker.CheckDependencyList(directoryName, DependencyChecker.BrowserSubprocessDependencies));
			}
			string path = Path.IsPathRooted(localePackFile) ? localePackFile : Path.Combine(nativeLibPath, localePackFile);
			if (!File.Exists(path))
			{
				list.Add(localePackFile);
			}
			return list;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002B7C File Offset: 0x00000D7C
		private static List<string> CheckDependencyList(string dir, IEnumerable<string> files)
		{
			List<string> list = new List<string>();
			foreach (string text in files)
			{
				string text2 = string.IsNullOrEmpty(dir) ? text : Path.Combine(dir, text);
				if (!File.Exists(text2))
				{
					list.Add(text2);
				}
			}
			return list;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002BE8 File Offset: 0x00000DE8
		public static void AssertAllDependenciesPresent(string locale = null, string localesDirPath = null, string resourcesDirPath = null, bool packLoadingDisabled = false, string browserSubProcessPath = "CefSharp.BrowserSubProcess.exe")
		{
			string directoryName = Path.GetDirectoryName(typeof(DependencyChecker).Assembly.Location);
			Uri uri;
			string directoryName2;
			if (Uri.TryCreate(browserSubProcessPath, UriKind.Absolute, out uri) && uri.IsAbsoluteUri)
			{
				directoryName2 = Path.GetDirectoryName(browserSubProcessPath);
			}
			else
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				directoryName2 = Path.GetDirectoryName(executingAssembly.Location);
			}
			if (string.IsNullOrEmpty(locale))
			{
				locale = "en-US";
			}
			if (string.IsNullOrEmpty(localesDirPath))
			{
				localesDirPath = Path.Combine(directoryName2, "locales");
			}
			if (string.IsNullOrEmpty(resourcesDirPath))
			{
				resourcesDirPath = directoryName2;
			}
			List<string> list = DependencyChecker.CheckDependencies(true, packLoadingDisabled, directoryName, directoryName2, resourcesDirPath, browserSubProcessPath, Path.Combine(localesDirPath, locale + ".pak"));
			if (list.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Unable to locate required Cef/CefSharp dependencies:");
				foreach (string str in list)
				{
					stringBuilder.AppendLine("Missing:" + str);
				}
				stringBuilder.AppendLine("Executing Assembly Path:" + directoryName2);
				throw new Exception(stringBuilder.ToString());
			}
		}

		// Token: 0x0400002E RID: 46
		public const string LocalesPackFile = "locales\\en-US.pak";

		// Token: 0x0400002F RID: 47
		private const string D3DCompilerDll = "d3dcompiler_47.dll";

		// Token: 0x04000030 RID: 48
		public static string[] CefDependencies = new string[]
		{
			"libcef.dll",
			"icudtl.dat",
			"snapshot_blob.bin",
			"v8_context_snapshot.bin"
		};

		// Token: 0x04000031 RID: 49
		public static string[] CefResources = new string[]
		{
			"resources.pak",
			"chrome_100_percent.pak",
			"chrome_200_percent.pak"
		};

		// Token: 0x04000032 RID: 50
		public static string[] CefOptionalDependencies = new string[]
		{
			"libEGL.dll",
			"libGLESv2.dll",
			"d3dcompiler_47.dll",
			"chrome_elf.dll"
		};

		// Token: 0x04000033 RID: 51
		public static string[] CefSharpManagedDependencies = new string[]
		{
			"CefSharp.Core.dll",
			"CefSharp.dll"
		};

		// Token: 0x04000034 RID: 52
		public static string[] CefSharpArchSpecificDependencies = new string[]
		{
			"CefSharp.Core.Runtime.dll"
		};

		// Token: 0x04000035 RID: 53
		public static string[] BrowserSubprocessDependencies = new string[]
		{
			"CefSharp.BrowserSubprocess.Core.dll",
			"CefSharp.dll",
			"icudtl.dat",
			"libcef.dll"
		};
	}
}
