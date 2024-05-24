using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000047 RID: 71
	public class AssemblyResolver : IAssemblyResolver, IDisposable
	{
		// Token: 0x06000220 RID: 544 RVA: 0x000065AC File Offset: 0x000047AC
		public void LoadAssemblyFrom(string assemblyFilePath)
		{
			if (!this.handlesAssemblyResolve)
			{
				AppDomain.CurrentDomain.AssemblyResolve += this.CurrentDomain_AssemblyResolve;
				this.handlesAssemblyResolve = true;
			}
			Uri fileUri = AssemblyResolver.GetFileUri(assemblyFilePath);
			if (fileUri == null)
			{
				throw new ArgumentException(Resources.InvalidArgumentAssemblyUri, "assemblyFilePath");
			}
			if (!File.Exists(fileUri.LocalPath))
			{
				throw new FileNotFoundException();
			}
			AssemblyName assemblyName = AssemblyName.GetAssemblyName(fileUri.LocalPath);
			AssemblyResolver.AssemblyInfo assemblyInfo = this.registeredAssemblies.FirstOrDefault((AssemblyResolver.AssemblyInfo a) => assemblyName == a.AssemblyName);
			if (assemblyInfo != null)
			{
				return;
			}
			assemblyInfo = new AssemblyResolver.AssemblyInfo
			{
				AssemblyName = assemblyName,
				AssemblyUri = fileUri
			};
			this.registeredAssemblies.Add(assemblyInfo);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000666C File Offset: 0x0000486C
		private static Uri GetFileUri(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return null;
			}
			Uri uri;
			if (!Uri.TryCreate(filePath, UriKind.Absolute, out uri))
			{
				return null;
			}
			if (!uri.IsFile)
			{
				return null;
			}
			return uri;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000669C File Offset: 0x0000489C
		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			AssemblyName assemblyName = new AssemblyName(args.Name);
			AssemblyResolver.AssemblyInfo assemblyInfo = this.registeredAssemblies.FirstOrDefault((AssemblyResolver.AssemblyInfo a) => AssemblyName.ReferenceMatchesDefinition(assemblyName, a.AssemblyName));
			if (assemblyInfo != null)
			{
				if (assemblyInfo.Assembly == null)
				{
					assemblyInfo.Assembly = Assembly.LoadFrom(assemblyInfo.AssemblyUri.LocalPath);
				}
				return assemblyInfo.Assembly;
			}
			return null;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00006707 File Offset: 0x00004907
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00006716 File Offset: 0x00004916
		protected virtual void Dispose(bool disposing)
		{
			if (this.handlesAssemblyResolve)
			{
				AppDomain.CurrentDomain.AssemblyResolve -= this.CurrentDomain_AssemblyResolve;
				this.handlesAssemblyResolve = false;
			}
		}

		// Token: 0x04000064 RID: 100
		private readonly List<AssemblyResolver.AssemblyInfo> registeredAssemblies = new List<AssemblyResolver.AssemblyInfo>();

		// Token: 0x04000065 RID: 101
		private bool handlesAssemblyResolve;

		// Token: 0x0200009A RID: 154
		private class AssemblyInfo
		{
			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000A1AF File Offset: 0x000083AF
			// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000A1B7 File Offset: 0x000083B7
			public AssemblyName AssemblyName { get; set; }

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000A1C0 File Offset: 0x000083C0
			// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000A1C8 File Offset: 0x000083C8
			public Uri AssemblyUri { get; set; }

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000A1D1 File Offset: 0x000083D1
			// (set) Token: 0x0600041C RID: 1052 RVA: 0x0000A1D9 File Offset: 0x000083D9
			public Assembly Assembly { get; set; }
		}
	}
}
