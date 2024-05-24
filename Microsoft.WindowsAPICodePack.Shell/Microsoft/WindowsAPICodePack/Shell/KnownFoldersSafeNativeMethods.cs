using System;
using System.Security;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000097 RID: 151
	[SuppressUnmanagedCodeSecurity]
	internal static class KnownFoldersSafeNativeMethods
	{
		// Token: 0x02000098 RID: 152
		internal struct NativeFolderDefinition
		{
			// Token: 0x04000310 RID: 784
			internal FolderCategory category;

			// Token: 0x04000311 RID: 785
			internal IntPtr name;

			// Token: 0x04000312 RID: 786
			internal IntPtr description;

			// Token: 0x04000313 RID: 787
			internal Guid parentId;

			// Token: 0x04000314 RID: 788
			internal IntPtr relativePath;

			// Token: 0x04000315 RID: 789
			internal IntPtr parsingName;

			// Token: 0x04000316 RID: 790
			internal IntPtr tooltip;

			// Token: 0x04000317 RID: 791
			internal IntPtr localizedName;

			// Token: 0x04000318 RID: 792
			internal IntPtr icon;

			// Token: 0x04000319 RID: 793
			internal IntPtr security;

			// Token: 0x0400031A RID: 794
			internal uint attributes;

			// Token: 0x0400031B RID: 795
			internal DefinitionOptions definitionOptions;

			// Token: 0x0400031C RID: 796
			internal Guid folderTypeId;
		}
	}
}
