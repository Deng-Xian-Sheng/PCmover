using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000126 RID: 294
	public class JumpListLink : JumpListTask, IJumpListItem, IDisposable
	{
		// Token: 0x06000D1C RID: 3356 RVA: 0x00030D08 File Offset: 0x0002EF08
		public JumpListLink(string pathValue, string titleValue)
		{
			if (string.IsNullOrEmpty(pathValue))
			{
				throw new ArgumentNullException("pathValue", LocalizedMessages.JumpListLinkPathRequired);
			}
			if (string.IsNullOrEmpty(titleValue))
			{
				throw new ArgumentNullException("titleValue", LocalizedMessages.JumpListLinkTitleRequired);
			}
			this.Path = pathValue;
			this.Title = titleValue;
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00030D6C File Offset: 0x0002EF6C
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x00030D84 File Offset: 0x0002EF84
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value", LocalizedMessages.JumpListLinkTitleRequired);
				}
				this.title = value;
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x00030DB8 File Offset: 0x0002EFB8
		// (set) Token: 0x06000D20 RID: 3360 RVA: 0x00030DD0 File Offset: 0x0002EFD0
		public string Path
		{
			get
			{
				return this.path;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value", LocalizedMessages.JumpListLinkTitleRequired);
				}
				this.path = value;
			}
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00030E04 File Offset: 0x0002F004
		// (set) Token: 0x06000D22 RID: 3362 RVA: 0x00030E1B File Offset: 0x0002F01B
		public IconReference IconReference { get; set; }

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x00030E24 File Offset: 0x0002F024
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x00030E3B File Offset: 0x0002F03B
		public string Arguments { get; set; }

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00030E44 File Offset: 0x0002F044
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00030E5B File Offset: 0x0002F05B
		public string WorkingDirectory { get; set; }

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00030E64 File Offset: 0x0002F064
		// (set) Token: 0x06000D28 RID: 3368 RVA: 0x00030E7B File Offset: 0x0002F07B
		public WindowShowCommand ShowCommand { get; set; }

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x00030E84 File Offset: 0x0002F084
		internal override IShellLinkW NativeShellLink
		{
			get
			{
				if (this.nativeShellLink != null)
				{
					Marshal.ReleaseComObject(this.nativeShellLink);
					this.nativeShellLink = null;
				}
				this.nativeShellLink = (IShellLinkW)new CShellLink();
				if (this.nativePropertyStore != null)
				{
					Marshal.ReleaseComObject(this.nativePropertyStore);
					this.nativePropertyStore = null;
				}
				this.nativePropertyStore = (IPropertyStore)this.nativeShellLink;
				this.nativeShellLink.SetPath(this.Path);
				if (!string.IsNullOrEmpty(this.IconReference.ModuleName))
				{
					this.nativeShellLink.SetIconLocation(this.IconReference.ModuleName, this.IconReference.ResourceId);
				}
				if (!string.IsNullOrEmpty(this.Arguments))
				{
					this.nativeShellLink.SetArguments(this.Arguments);
				}
				if (!string.IsNullOrEmpty(this.WorkingDirectory))
				{
					this.nativeShellLink.SetWorkingDirectory(this.WorkingDirectory);
				}
				this.nativeShellLink.SetShowCmd((uint)this.ShowCommand);
				using (PropVariant propVariant = new PropVariant(this.Title))
				{
					HResult result = this.nativePropertyStore.SetValue(ref JumpListLink.PKEY_Title, propVariant);
					if (!CoreErrorHelper.Succeeded(result))
					{
						throw new ShellException(result);
					}
					this.nativePropertyStore.Commit();
				}
				return this.nativeShellLink;
			}
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x00031010 File Offset: 0x0002F210
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.title = null;
			}
			if (this.nativePropertyStore != null)
			{
				Marshal.ReleaseComObject(this.nativePropertyStore);
				this.nativePropertyStore = null;
			}
			if (this.nativeShellLink != null)
			{
				Marshal.ReleaseComObject(this.nativeShellLink);
				this.nativeShellLink = null;
			}
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x00031073 File Offset: 0x0002F273
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00031088 File Offset: 0x0002F288
		~JumpListLink()
		{
			this.Dispose(false);
		}

		// Token: 0x040004F6 RID: 1270
		internal static PropertyKey PKEY_Title = SystemProperties.System.Title;

		// Token: 0x040004F7 RID: 1271
		private string title;

		// Token: 0x040004F8 RID: 1272
		private string path;

		// Token: 0x040004F9 RID: 1273
		private IPropertyStore nativePropertyStore;

		// Token: 0x040004FA RID: 1274
		private IShellLinkW nativeShellLink;
	}
}
