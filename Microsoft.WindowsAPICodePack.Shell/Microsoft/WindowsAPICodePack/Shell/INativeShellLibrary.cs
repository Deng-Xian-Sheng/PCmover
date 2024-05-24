using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000049 RID: 73
	[CoClass(typeof(ShellLibraryCoClass))]
	[Guid("11A66EFA-382E-451A-9234-1E0E12EF3085")]
	[ComImport]
	internal interface INativeShellLibrary : IShellLibrary
	{
	}
}
