using System;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000069 RID: 105
	public sealed class ShellSearchConnector : ShellSearchCollection
	{
		// Token: 0x0600038E RID: 910 RVA: 0x0000E055 File Offset: 0x0000C255
		internal ShellSearchConnector()
		{
			CoreHelpers.ThrowIfNotWin7();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000E066 File Offset: 0x0000C266
		internal ShellSearchConnector(IShellItem2 shellItem) : this()
		{
			this.nativeShellItem = shellItem;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0000E078 File Offset: 0x0000C278
		public new static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnWin7;
			}
		}
	}
}
