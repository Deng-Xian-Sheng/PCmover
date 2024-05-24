using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003B4 RID: 948
	public enum CachedResponseType
	{
		// Token: 0x04000EE6 RID: 3814
		[EnumMember(Value = "basic")]
		Basic,
		// Token: 0x04000EE7 RID: 3815
		[EnumMember(Value = "cors")]
		Cors,
		// Token: 0x04000EE8 RID: 3816
		[EnumMember(Value = "default")]
		Default,
		// Token: 0x04000EE9 RID: 3817
		[EnumMember(Value = "error")]
		Error,
		// Token: 0x04000EEA RID: 3818
		[EnumMember(Value = "opaqueResponse")]
		OpaqueResponse,
		// Token: 0x04000EEB RID: 3819
		[EnumMember(Value = "opaqueRedirect")]
		OpaqueRedirect
	}
}
