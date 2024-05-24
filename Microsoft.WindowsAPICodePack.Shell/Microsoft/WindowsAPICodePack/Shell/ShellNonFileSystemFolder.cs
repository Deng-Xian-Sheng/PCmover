using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x020000E1 RID: 225
	public class ShellNonFileSystemFolder : ShellFolder
	{
		// Token: 0x060008A0 RID: 2208 RVA: 0x00024FE7 File Offset: 0x000231E7
		internal ShellNonFileSystemFolder()
		{
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00024FF2 File Offset: 0x000231F2
		internal ShellNonFileSystemFolder(IShellItem2 shellItem)
		{
			this.nativeShellItem = shellItem;
		}
	}
}
