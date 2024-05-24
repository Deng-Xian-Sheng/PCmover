using System;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000015 RID: 21
	[Flags]
	internal enum SetWindowPositionOptions
	{
		// Token: 0x04000024 RID: 36
		AsyncWindowPos = 16384,
		// Token: 0x04000025 RID: 37
		DeferErase = 8192,
		// Token: 0x04000026 RID: 38
		DrawFrame = 32,
		// Token: 0x04000027 RID: 39
		FrameChanged = 32,
		// Token: 0x04000028 RID: 40
		HideWindow = 128,
		// Token: 0x04000029 RID: 41
		NoActivate = 16,
		// Token: 0x0400002A RID: 42
		CoCopyBits = 256,
		// Token: 0x0400002B RID: 43
		NoMove = 2,
		// Token: 0x0400002C RID: 44
		NoOwnerZOrder = 512,
		// Token: 0x0400002D RID: 45
		NoRedraw = 8,
		// Token: 0x0400002E RID: 46
		NoResposition = 512,
		// Token: 0x0400002F RID: 47
		NoSendChanging = 1024,
		// Token: 0x04000030 RID: 48
		NoSize = 1,
		// Token: 0x04000031 RID: 49
		NoZOrder = 4,
		// Token: 0x04000032 RID: 50
		ShowWindow = 64
	}
}
