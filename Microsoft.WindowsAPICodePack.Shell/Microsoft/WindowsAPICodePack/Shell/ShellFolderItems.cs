using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000012 RID: 18
	internal class ShellFolderItems : IEnumerator<ShellObject>, IDisposable, IEnumerator
	{
		// Token: 0x06000097 RID: 151 RVA: 0x000042BC File Offset: 0x000024BC
		internal ShellFolderItems(ShellContainer nativeShellFolder)
		{
			this.nativeShellFolder = nativeShellFolder;
			HResult hresult = nativeShellFolder.NativeShellFolder.EnumObjects(IntPtr.Zero, ShellNativeMethods.ShellFolderEnumerationOptions.Folders | ShellNativeMethods.ShellFolderEnumerationOptions.NonFolders, out this.nativeEnumIdList);
			if (CoreErrorHelper.Succeeded(hresult))
			{
				return;
			}
			if (hresult == HResult.Canceled)
			{
				throw new FileNotFoundException();
			}
			throw new ShellException(hresult);
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000431C File Offset: 0x0000251C
		public ShellObject Current
		{
			get
			{
				return this.currentItem;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004334 File Offset: 0x00002534
		public void Dispose()
		{
			if (this.nativeEnumIdList != null)
			{
				Marshal.ReleaseComObject(this.nativeEnumIdList);
				this.nativeEnumIdList = null;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00004364 File Offset: 0x00002564
		object IEnumerator.Current
		{
			get
			{
				return this.currentItem;
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000437C File Offset: 0x0000257C
		public bool MoveNext()
		{
			bool result;
			if (this.nativeEnumIdList == null)
			{
				result = false;
			}
			else
			{
				uint num = 1U;
				IntPtr idListPtr;
				uint num2;
				HResult hresult = this.nativeEnumIdList.Next(num, out idListPtr, out num2);
				if (num2 < num || hresult != HResult.Ok)
				{
					result = false;
				}
				else
				{
					this.currentItem = ShellObjectFactory.Create(idListPtr, this.nativeShellFolder);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000043E8 File Offset: 0x000025E8
		public void Reset()
		{
			if (this.nativeEnumIdList != null)
			{
				this.nativeEnumIdList.Reset();
			}
		}

		// Token: 0x04000024 RID: 36
		private IEnumIDList nativeEnumIdList;

		// Token: 0x04000025 RID: 37
		private ShellObject currentItem;

		// Token: 0x04000026 RID: 38
		private ShellContainer nativeShellFolder;
	}
}
