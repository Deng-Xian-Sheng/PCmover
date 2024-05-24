using System;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000181 RID: 385
	public class ShellSavedSearchCollection : ShellSearchCollection
	{
		// Token: 0x06000EE6 RID: 3814 RVA: 0x00033E08 File Offset: 0x00032008
		internal ShellSavedSearchCollection(IShellItem2 shellItem) : base(shellItem)
		{
			CoreHelpers.ThrowIfNotVista();
		}
	}
}
