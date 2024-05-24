using System;

namespace CefSharp.Enums
{
	// Token: 0x02000116 RID: 278
	[Flags]
	public enum SchemeOptions
	{
		// Token: 0x0400042A RID: 1066
		None = 0,
		// Token: 0x0400042B RID: 1067
		Standard = 1,
		// Token: 0x0400042C RID: 1068
		Local = 2,
		// Token: 0x0400042D RID: 1069
		DisplayIsolated = 4,
		// Token: 0x0400042E RID: 1070
		Secure = 8,
		// Token: 0x0400042F RID: 1071
		CorsEnabled = 16,
		// Token: 0x04000430 RID: 1072
		CspBypassing = 32,
		// Token: 0x04000431 RID: 1073
		FetchEnabled = 64
	}
}
