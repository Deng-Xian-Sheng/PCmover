using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B7 RID: 695
	public enum ServiceWorkerResponseSource
	{
		// Token: 0x04000B39 RID: 2873
		[EnumMember(Value = "cache-storage")]
		CacheStorage,
		// Token: 0x04000B3A RID: 2874
		[EnumMember(Value = "http-cache")]
		HttpCache,
		// Token: 0x04000B3B RID: 2875
		[EnumMember(Value = "fallback-code")]
		FallbackCode,
		// Token: 0x04000B3C RID: 2876
		[EnumMember(Value = "network")]
		Network
	}
}
