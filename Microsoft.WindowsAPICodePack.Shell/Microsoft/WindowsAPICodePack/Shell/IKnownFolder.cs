using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000047 RID: 71
	public interface IKnownFolder : IDisposable, IEnumerable<ShellObject>, IEnumerable
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000277 RID: 631
		string Path { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000278 RID: 632
		FolderCategory Category { get; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000279 RID: 633
		string CanonicalName { get; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600027A RID: 634
		string Description { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600027B RID: 635
		Guid ParentId { get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600027C RID: 636
		string RelativePath { get; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600027D RID: 637
		string ParsingName { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600027E RID: 638
		string Tooltip { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600027F RID: 639
		string TooltipResourceId { get; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000280 RID: 640
		string LocalizedName { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000281 RID: 641
		string LocalizedNameResourceId { get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000282 RID: 642
		string Security { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000283 RID: 643
		FileAttributes FileAttributes { get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000284 RID: 644
		DefinitionOptions DefinitionOptions { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000285 RID: 645
		Guid FolderTypeId { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000286 RID: 646
		string FolderType { get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000287 RID: 647
		Guid FolderId { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000288 RID: 648
		bool PathExists { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000289 RID: 649
		RedirectionCapability Redirection { get; }
	}
}
