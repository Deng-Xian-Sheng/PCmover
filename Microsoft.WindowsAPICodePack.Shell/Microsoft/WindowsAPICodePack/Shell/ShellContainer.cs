using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000009 RID: 9
	public abstract class ShellContainer : ShellObject, IEnumerable<ShellObject>, IEnumerable, IDisposable
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002C1C File Offset: 0x00000E1C
		internal IShellFolder NativeShellFolder
		{
			get
			{
				if (this.nativeShellFolder == null)
				{
					Guid guid = new Guid("000214E6-0000-0000-C000-000000000046");
					Guid guid2 = new Guid("3981e224-f559-11d3-8e3a-00c04f6837d5");
					HResult result = this.NativeShellItem.BindToHandler(IntPtr.Zero, ref guid2, ref guid, out this.nativeShellFolder);
					if (CoreErrorHelper.Failed(result))
					{
						string parsingName = ShellHelper.GetParsingName(this.NativeShellItem);
						if (parsingName != null && parsingName != Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
						{
							throw new ShellException(result);
						}
					}
				}
				return this.nativeShellFolder;
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002CCB File Offset: 0x00000ECB
		internal ShellContainer()
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002CD6 File Offset: 0x00000ED6
		internal ShellContainer(IShellItem2 shellItem) : base(shellItem)
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002CE4 File Offset: 0x00000EE4
		protected override void Dispose(bool disposing)
		{
			if (this.nativeShellFolder != null)
			{
				Marshal.ReleaseComObject(this.nativeShellFolder);
				this.nativeShellFolder = null;
			}
			if (this.desktopFolderEnumeration != null)
			{
				Marshal.ReleaseComObject(this.desktopFolderEnumeration);
				this.desktopFolderEnumeration = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D40 File Offset: 0x00000F40
		public IEnumerator<ShellObject> GetEnumerator()
		{
			if (this.NativeShellFolder == null)
			{
				if (this.desktopFolderEnumeration == null)
				{
					ShellNativeMethods.SHGetDesktopFolder(out this.desktopFolderEnumeration);
				}
				this.nativeShellFolder = this.desktopFolderEnumeration;
			}
			return new ShellFolderItems(this);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D94 File Offset: 0x00000F94
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ShellFolderItems(this);
		}

		// Token: 0x04000013 RID: 19
		private IShellFolder desktopFolderEnumeration;

		// Token: 0x04000014 RID: 20
		private IShellFolder nativeShellFolder;
	}
}
