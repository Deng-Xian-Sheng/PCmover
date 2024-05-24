using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x020000E0 RID: 224
	public class ShellNonFileSystemItem : ShellObject
	{
		// Token: 0x0600089F RID: 2207 RVA: 0x00024FD5 File Offset: 0x000231D5
		internal ShellNonFileSystemItem(IShellItem2 shellItem)
		{
			this.nativeShellItem = shellItem;
		}
	}
}
