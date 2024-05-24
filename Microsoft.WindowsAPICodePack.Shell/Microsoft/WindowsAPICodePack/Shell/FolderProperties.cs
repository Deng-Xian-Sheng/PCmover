using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000061 RID: 97
	internal struct FolderProperties
	{
		// Token: 0x0400019E RID: 414
		internal string name;

		// Token: 0x0400019F RID: 415
		internal FolderCategory category;

		// Token: 0x040001A0 RID: 416
		internal string canonicalName;

		// Token: 0x040001A1 RID: 417
		internal string description;

		// Token: 0x040001A2 RID: 418
		internal Guid parentId;

		// Token: 0x040001A3 RID: 419
		internal string parent;

		// Token: 0x040001A4 RID: 420
		internal string relativePath;

		// Token: 0x040001A5 RID: 421
		internal string parsingName;

		// Token: 0x040001A6 RID: 422
		internal string tooltipResourceId;

		// Token: 0x040001A7 RID: 423
		internal string tooltip;

		// Token: 0x040001A8 RID: 424
		internal string localizedName;

		// Token: 0x040001A9 RID: 425
		internal string localizedNameResourceId;

		// Token: 0x040001AA RID: 426
		internal string iconResourceId;

		// Token: 0x040001AB RID: 427
		internal BitmapSource icon;

		// Token: 0x040001AC RID: 428
		internal DefinitionOptions definitionOptions;

		// Token: 0x040001AD RID: 429
		internal FileAttributes fileAttributes;

		// Token: 0x040001AE RID: 430
		internal Guid folderTypeId;

		// Token: 0x040001AF RID: 431
		internal string folderType;

		// Token: 0x040001B0 RID: 432
		internal Guid folderId;

		// Token: 0x040001B1 RID: 433
		internal string path;

		// Token: 0x040001B2 RID: 434
		internal bool pathExists;

		// Token: 0x040001B3 RID: 435
		internal RedirectionCapability redirection;

		// Token: 0x040001B4 RID: 436
		internal string security;
	}
}
