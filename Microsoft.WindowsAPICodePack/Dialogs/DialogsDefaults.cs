using System;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200000D RID: 13
	internal static class DialogsDefaults
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002828 File Offset: 0x00000A28
		internal static string Caption
		{
			get
			{
				return LocalizedMessages.DialogDefaultCaption;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002840 File Offset: 0x00000A40
		internal static string MainInstruction
		{
			get
			{
				return LocalizedMessages.DialogDefaultMainInstruction;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002858 File Offset: 0x00000A58
		internal static string Content
		{
			get
			{
				return LocalizedMessages.DialogDefaultContent;
			}
		}

		// Token: 0x040000E2 RID: 226
		internal const int ProgressBarStartingValue = 0;

		// Token: 0x040000E3 RID: 227
		internal const int ProgressBarMinimumValue = 0;

		// Token: 0x040000E4 RID: 228
		internal const int ProgressBarMaximumValue = 100;

		// Token: 0x040000E5 RID: 229
		internal const int IdealWidth = 0;

		// Token: 0x040000E6 RID: 230
		internal const int MinimumDialogControlId = 9;
	}
}
