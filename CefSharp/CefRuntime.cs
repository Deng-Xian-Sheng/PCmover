using System;
using System.IO;
using System.Reflection;

namespace CefSharp
{
	// Token: 0x0200001B RID: 27
	public static class CefRuntime
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00002728 File Offset: 0x00000928
		public static void SubscribeAnyCpuAssemblyResolver(string basePath = null)
		{
			if (CefRuntime.currentDomainAssemblyResolveHandler != null)
			{
				throw new Exception("UseAnyCpuAssemblyResolver has already been called, call ");
			}
			if (basePath == null)
			{
				basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
			}
			CefRuntime.currentDomainAssemblyResolveHandler = delegate(object sender, ResolveEventArgs args)
			{
				if (!args.Name.StartsWith("CefSharp.Core.Runtime"))
				{
					return null;
				}
				string path = args.Name.Split(new char[]
				{
					','
				}, 2)[0] + ".dll";
				string path2 = Path.Combine(basePath, Environment.Is64BitProcess ? "x64" : "x86", path);
				if (!File.Exists(path2))
				{
					return null;
				}
				return Assembly.LoadFile(path2);
			};
			AppDomain.CurrentDomain.AssemblyResolve += CefRuntime.currentDomainAssemblyResolveHandler;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002791 File Offset: 0x00000991
		public static void UnsubscribeAnyCpuAssemblyResolver()
		{
			AppDomain.CurrentDomain.AssemblyResolve -= CefRuntime.currentDomainAssemblyResolveHandler;
			CefRuntime.currentDomainAssemblyResolveHandler = null;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000027A8 File Offset: 0x000009A8
		public static void LoadCefSharpCoreRuntimeAnyCpu(string basePath = null)
		{
			if (basePath == null)
			{
				basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
			}
			string text = Environment.Is64BitProcess ? "x64" : "x86";
			string text2 = Path.Combine(basePath, text, "CefSharp.Core.Runtime.dll");
			if (File.Exists(text2))
			{
				Assembly.LoadFile(text2);
				return;
			}
			throw new FileNotFoundException("Unable to load for arch " + text, text2);
		}

		// Token: 0x04000018 RID: 24
		private static ResolveEventHandler currentDomainAssemblyResolveHandler;
	}
}
