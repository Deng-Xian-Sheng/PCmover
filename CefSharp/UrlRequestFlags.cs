using System;

namespace CefSharp
{
	// Token: 0x02000041 RID: 65
	[Flags]
	public enum UrlRequestFlags
	{
		// Token: 0x0400022D RID: 557
		None = 0,
		// Token: 0x0400022E RID: 558
		SkipCache = 1,
		// Token: 0x0400022F RID: 559
		OnlyFromCache = 2,
		// Token: 0x04000230 RID: 560
		DisableCache = 4,
		// Token: 0x04000231 RID: 561
		AllowStoredCredentials = 8,
		// Token: 0x04000232 RID: 562
		ReportUploadProgress = 16,
		// Token: 0x04000233 RID: 563
		NoDownloadData = 32,
		// Token: 0x04000234 RID: 564
		NoRetryOn5XX = 64,
		// Token: 0x04000235 RID: 565
		StopOnRedirect = 128
	}
}
