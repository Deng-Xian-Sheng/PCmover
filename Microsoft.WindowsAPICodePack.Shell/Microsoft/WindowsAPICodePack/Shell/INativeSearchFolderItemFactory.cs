using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000178 RID: 376
	[Guid("a0ffbc28-5482-4366-be27-3e81e78e06c2")]
	[CoClass(typeof(SearchFolderItemFactoryCoClass))]
	[ComImport]
	internal interface INativeSearchFolderItemFactory : ISearchFolderItemFactory
	{
	}
}
