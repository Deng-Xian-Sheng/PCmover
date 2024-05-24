using System;
using System.Collections.Generic;
using System.IO;

namespace Prism.Modularity
{
	// Token: 0x0200004D RID: 77
	public class FileModuleTypeLoader : IModuleTypeLoader, IDisposable
	{
		// Token: 0x0600023E RID: 574 RVA: 0x00006ACC File Offset: 0x00004CCC
		public FileModuleTypeLoader() : this(new AssemblyResolver())
		{
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00006AD9 File Offset: 0x00004CD9
		public FileModuleTypeLoader(IAssemblyResolver assemblyResolver)
		{
			this.assemblyResolver = assemblyResolver;
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000240 RID: 576 RVA: 0x00006AF4 File Offset: 0x00004CF4
		// (remove) Token: 0x06000241 RID: 577 RVA: 0x00006B2C File Offset: 0x00004D2C
		public event EventHandler<ModuleDownloadProgressChangedEventArgs> ModuleDownloadProgressChanged;

		// Token: 0x06000242 RID: 578 RVA: 0x00006B61 File Offset: 0x00004D61
		private void RaiseModuleDownloadProgressChanged(ModuleInfo moduleInfo, long bytesReceived, long totalBytesToReceive)
		{
			this.RaiseModuleDownloadProgressChanged(new ModuleDownloadProgressChangedEventArgs(moduleInfo, bytesReceived, totalBytesToReceive));
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00006B71 File Offset: 0x00004D71
		private void RaiseModuleDownloadProgressChanged(ModuleDownloadProgressChangedEventArgs e)
		{
			if (this.ModuleDownloadProgressChanged != null)
			{
				this.ModuleDownloadProgressChanged(this, e);
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000244 RID: 580 RVA: 0x00006B88 File Offset: 0x00004D88
		// (remove) Token: 0x06000245 RID: 581 RVA: 0x00006BC0 File Offset: 0x00004DC0
		public event EventHandler<LoadModuleCompletedEventArgs> LoadModuleCompleted;

		// Token: 0x06000246 RID: 582 RVA: 0x00006BF5 File Offset: 0x00004DF5
		private void RaiseLoadModuleCompleted(ModuleInfo moduleInfo, Exception error)
		{
			this.RaiseLoadModuleCompleted(new LoadModuleCompletedEventArgs(moduleInfo, error));
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00006C04 File Offset: 0x00004E04
		private void RaiseLoadModuleCompleted(LoadModuleCompletedEventArgs e)
		{
			if (this.LoadModuleCompleted != null)
			{
				this.LoadModuleCompleted(this, e);
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00006C1B File Offset: 0x00004E1B
		public bool CanLoadModuleType(ModuleInfo moduleInfo)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			return moduleInfo.Ref != null && moduleInfo.Ref.StartsWith("file://", StringComparison.Ordinal);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00006C48 File Offset: 0x00004E48
		public void LoadModuleType(ModuleInfo moduleInfo)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			try
			{
				Uri uri = new Uri(moduleInfo.Ref, UriKind.RelativeOrAbsolute);
				if (this.IsSuccessfullyDownloaded(uri))
				{
					this.RaiseLoadModuleCompleted(moduleInfo, null);
				}
				else
				{
					string localPath = uri.LocalPath;
					long num = -1L;
					if (File.Exists(localPath))
					{
						num = new FileInfo(localPath).Length;
					}
					this.RaiseModuleDownloadProgressChanged(moduleInfo, 0L, num);
					this.assemblyResolver.LoadAssemblyFrom(moduleInfo.Ref);
					this.RaiseModuleDownloadProgressChanged(moduleInfo, num, num);
					this.RecordDownloadSuccess(uri);
					this.RaiseLoadModuleCompleted(moduleInfo, null);
				}
			}
			catch (Exception error)
			{
				this.RaiseLoadModuleCompleted(moduleInfo, error);
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00006CF4 File Offset: 0x00004EF4
		private bool IsSuccessfullyDownloaded(Uri uri)
		{
			HashSet<Uri> obj = this.downloadedUris;
			bool result;
			lock (obj)
			{
				result = this.downloadedUris.Contains(uri);
			}
			return result;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00006D3C File Offset: 0x00004F3C
		private void RecordDownloadSuccess(Uri uri)
		{
			HashSet<Uri> obj = this.downloadedUris;
			lock (obj)
			{
				this.downloadedUris.Add(uri);
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00006D84 File Offset: 0x00004F84
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00006D94 File Offset: 0x00004F94
		protected virtual void Dispose(bool disposing)
		{
			IDisposable disposable = this.assemblyResolver as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}

		// Token: 0x04000068 RID: 104
		private const string RefFilePrefix = "file://";

		// Token: 0x04000069 RID: 105
		private readonly IAssemblyResolver assemblyResolver;

		// Token: 0x0400006A RID: 106
		private HashSet<Uri> downloadedUris = new HashSet<Uri>();
	}
}
