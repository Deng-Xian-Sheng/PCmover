using System;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200008D RID: 141
	public static class CommonFileDialogStandardFilters
	{
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00011F58 File Offset: 0x00010158
		public static CommonFileDialogFilter TextFiles
		{
			get
			{
				if (CommonFileDialogStandardFilters.textFilesFilter == null)
				{
					CommonFileDialogStandardFilters.textFilesFilter = new CommonFileDialogFilter(LocalizedMessages.CommonFiltersText, "*.txt");
				}
				return CommonFileDialogStandardFilters.textFilesFilter;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00011F94 File Offset: 0x00010194
		public static CommonFileDialogFilter PictureFiles
		{
			get
			{
				if (CommonFileDialogStandardFilters.pictureFilesFilter == null)
				{
					CommonFileDialogStandardFilters.pictureFilesFilter = new CommonFileDialogFilter(LocalizedMessages.CommonFiltersPicture, "*.bmp, *.jpg, *.jpeg, *.png, *.ico");
				}
				return CommonFileDialogStandardFilters.pictureFilesFilter;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00011FD0 File Offset: 0x000101D0
		public static CommonFileDialogFilter OfficeFiles
		{
			get
			{
				if (CommonFileDialogStandardFilters.officeFilesFilter == null)
				{
					CommonFileDialogStandardFilters.officeFilesFilter = new CommonFileDialogFilter(LocalizedMessages.CommonFiltersOffice, "*.doc, *.docx, *.xls, *.xlsx, *.ppt, *.pptx");
				}
				return CommonFileDialogStandardFilters.officeFilesFilter;
			}
		}

		// Token: 0x040002FB RID: 763
		private static CommonFileDialogFilter textFilesFilter;

		// Token: 0x040002FC RID: 764
		private static CommonFileDialogFilter pictureFilesFilter;

		// Token: 0x040002FD RID: 765
		private static CommonFileDialogFilter officeFilesFilter;
	}
}
