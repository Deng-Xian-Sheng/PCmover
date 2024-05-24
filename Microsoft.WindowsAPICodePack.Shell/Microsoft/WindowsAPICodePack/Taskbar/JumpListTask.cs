using System;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000124 RID: 292
	public abstract class JumpListTask
	{
		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06000D18 RID: 3352
		internal abstract IShellLinkW NativeShellLink { get; }
	}
}
