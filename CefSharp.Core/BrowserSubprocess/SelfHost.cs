using System;
using System.IO;
using System.Reflection;
using CefSharp.Core;
using CefSharp.Internals;

namespace CefSharp.BrowserSubprocess
{
	// Token: 0x0200001D RID: 29
	public class SelfHost
	{
		// Token: 0x06000182 RID: 386 RVA: 0x000037B4 File Offset: 0x000019B4
		public static int Main(string[] args)
		{
			string argumentValue = args.GetArgumentValue("--type");
			if (string.IsNullOrEmpty(argumentValue))
			{
				return -1;
			}
			string assemblyFile = Path.Combine(Path.GetDirectoryName(typeof(BrowserSettings).Assembly.Location), "CefSharp.BrowserSubprocess.Core.dll");
			Assembly assembly = Assembly.LoadFrom(assemblyFile);
			Type type = assembly.GetType("CefSharp.BrowserSubprocess.BrowserSubprocessExecutable");
			object obj = Activator.CreateInstance(type);
			MethodInfo method = type.GetMethod("MainSelfHost", BindingFlags.Static | BindingFlags.Public);
			ParameterInfo[] parameters = method.GetParameters();
			object[] parameters2 = new object[]
			{
				args
			};
			object obj2 = method.Invoke(null, parameters2);
			return (int)obj2;
		}
	}
}
