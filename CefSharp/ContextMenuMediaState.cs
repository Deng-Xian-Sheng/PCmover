using System;

namespace CefSharp
{
	// Token: 0x02000031 RID: 49
	[Flags]
	public enum ContextMenuMediaState
	{
		// Token: 0x040001A8 RID: 424
		None = 0,
		// Token: 0x040001A9 RID: 425
		Error = 1,
		// Token: 0x040001AA RID: 426
		Paused = 2,
		// Token: 0x040001AB RID: 427
		Muted = 4,
		// Token: 0x040001AC RID: 428
		Loop = 8,
		// Token: 0x040001AD RID: 429
		CanSave = 16,
		// Token: 0x040001AE RID: 430
		HasAudio = 32,
		// Token: 0x040001AF RID: 431
		CanToggleControls = 64,
		// Token: 0x040001B0 RID: 432
		Controls = 128,
		// Token: 0x040001B1 RID: 433
		CanPrint = 256,
		// Token: 0x040001B2 RID: 434
		CanRotate = 512,
		// Token: 0x040001B3 RID: 435
		CanPictureInPicture = 1024,
		// Token: 0x040001B4 RID: 436
		PictureInPicture = 2048,
		// Token: 0x040001B5 RID: 437
		CanLoop = 4096
	}
}
