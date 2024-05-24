using System;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000055 RID: 85
	internal static class TaskDialogDefaults
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00008CD4 File Offset: 0x00006ED4
		public static string Caption
		{
			get
			{
				return LocalizedMessages.TaskDialogDefaultCaption;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00008CEC File Offset: 0x00006EEC
		public static string MainInstruction
		{
			get
			{
				return LocalizedMessages.TaskDialogDefaultMainInstruction;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00008D04 File Offset: 0x00006F04
		public static string Content
		{
			get
			{
				return LocalizedMessages.TaskDialogDefaultContent;
			}
		}

		// Token: 0x04000295 RID: 661
		public const int ProgressBarMinimumValue = 0;

		// Token: 0x04000296 RID: 662
		public const int ProgressBarMaximumValue = 100;

		// Token: 0x04000297 RID: 663
		public const int IdealWidth = 0;

		// Token: 0x04000298 RID: 664
		public const int MinimumDialogControlId = 9;
	}
}
