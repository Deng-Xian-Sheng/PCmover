using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000127 RID: 295
	public class JumpListSeparator : JumpListTask, IDisposable
	{
		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x000310C8 File Offset: 0x0002F2C8
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
				using (PropVariant propVariant = new PropVariant(true))
				{
					HResult result = this.nativePropertyStore.SetValue(ref JumpListSeparator.PKEY_AppUserModel_IsDestListSeparator, propVariant);
					if (!CoreErrorHelper.Succeeded(result))
					{
						throw new ShellException(result);
					}
					this.nativePropertyStore.Commit();
				}
				return this.nativeShellLink;
			}
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x000311A4 File Offset: 0x0002F3A4
		protected virtual void Dispose(bool disposing)
		{
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

		// Token: 0x06000D30 RID: 3376 RVA: 0x000311F6 File Offset: 0x0002F3F6
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00031208 File Offset: 0x0002F408
		~JumpListSeparator()
		{
			this.Dispose(false);
		}

		// Token: 0x040004FF RID: 1279
		internal static PropertyKey PKEY_AppUserModel_IsDestListSeparator = SystemProperties.System.AppUserModel.IsDestinationListSeparator;

		// Token: 0x04000500 RID: 1280
		private IPropertyStore nativePropertyStore;

		// Token: 0x04000501 RID: 1281
		private IShellLinkW nativeShellLink;
	}
}
