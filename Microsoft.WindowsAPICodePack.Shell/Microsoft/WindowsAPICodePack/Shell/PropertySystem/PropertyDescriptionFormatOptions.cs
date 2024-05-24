using System;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000D3 RID: 211
	[Flags]
	public enum PropertyDescriptionFormatOptions
	{
		// Token: 0x040003A8 RID: 936
		None = 0,
		// Token: 0x040003A9 RID: 937
		PrefixName = 1,
		// Token: 0x040003AA RID: 938
		FileName = 2,
		// Token: 0x040003AB RID: 939
		AlwaysKB = 4,
		// Token: 0x040003AC RID: 940
		RightToLeft = 8,
		// Token: 0x040003AD RID: 941
		ShortTime = 16,
		// Token: 0x040003AE RID: 942
		LongTime = 32,
		// Token: 0x040003AF RID: 943
		HideTime = 64,
		// Token: 0x040003B0 RID: 944
		ShortDate = 128,
		// Token: 0x040003B1 RID: 945
		LongDate = 256,
		// Token: 0x040003B2 RID: 946
		HideDate = 512,
		// Token: 0x040003B3 RID: 947
		RelativeDate = 1024,
		// Token: 0x040003B4 RID: 948
		UseEditInvitation = 2048,
		// Token: 0x040003B5 RID: 949
		ReadOnly = 4096,
		// Token: 0x040003B6 RID: 950
		NoAutoReadingOrder = 8192,
		// Token: 0x040003B7 RID: 951
		SmartDateTime = 16384
	}
}
