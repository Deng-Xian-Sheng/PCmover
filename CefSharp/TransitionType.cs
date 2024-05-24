using System;

namespace CefSharp
{
	// Token: 0x02000040 RID: 64
	[Flags]
	public enum TransitionType : uint
	{
		// Token: 0x0400021C RID: 540
		LinkClicked = 0U,
		// Token: 0x0400021D RID: 541
		Explicit = 1U,
		// Token: 0x0400021E RID: 542
		AutoSubFrame = 3U,
		// Token: 0x0400021F RID: 543
		ManualSubFrame = 4U,
		// Token: 0x04000220 RID: 544
		FormSubmit = 7U,
		// Token: 0x04000221 RID: 545
		Reload = 8U,
		// Token: 0x04000222 RID: 546
		SourceMask = 255U,
		// Token: 0x04000223 RID: 547
		Blocked = 8388608U,
		// Token: 0x04000224 RID: 548
		ForwardBack = 16777216U,
		// Token: 0x04000225 RID: 549
		DirectLoad = 33554432U,
		// Token: 0x04000226 RID: 550
		ChainStart = 268435456U,
		// Token: 0x04000227 RID: 551
		ChainEnd = 536870912U,
		// Token: 0x04000228 RID: 552
		ClientRedirect = 1073741824U,
		// Token: 0x04000229 RID: 553
		ServerRedirect = 2147483648U,
		// Token: 0x0400022A RID: 554
		IsRedirect = 3221225472U,
		// Token: 0x0400022B RID: 555
		QualifierMask = 4294967040U
	}
}
