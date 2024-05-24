using System;

namespace CefSharp
{
	// Token: 0x02000024 RID: 36
	[Flags]
	public enum CefEventFlags : uint
	{
		// Token: 0x04000135 RID: 309
		None = 0U,
		// Token: 0x04000136 RID: 310
		CapsLockOn = 1U,
		// Token: 0x04000137 RID: 311
		ShiftDown = 2U,
		// Token: 0x04000138 RID: 312
		ControlDown = 4U,
		// Token: 0x04000139 RID: 313
		AltDown = 8U,
		// Token: 0x0400013A RID: 314
		LeftMouseButton = 16U,
		// Token: 0x0400013B RID: 315
		MiddleMouseButton = 32U,
		// Token: 0x0400013C RID: 316
		RightMouseButton = 64U,
		// Token: 0x0400013D RID: 317
		CommandDown = 128U,
		// Token: 0x0400013E RID: 318
		NumLockOn = 256U,
		// Token: 0x0400013F RID: 319
		IsKeyPad = 512U,
		// Token: 0x04000140 RID: 320
		IsLeft = 1024U,
		// Token: 0x04000141 RID: 321
		IsRight = 2048U,
		// Token: 0x04000142 RID: 322
		AltGrDown = 4096U
	}
}
