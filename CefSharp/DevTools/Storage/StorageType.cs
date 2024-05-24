using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x020001FB RID: 507
	public enum StorageType
	{
		// Token: 0x0400076F RID: 1903
		[EnumMember(Value = "appcache")]
		Appcache,
		// Token: 0x04000770 RID: 1904
		[EnumMember(Value = "cookies")]
		Cookies,
		// Token: 0x04000771 RID: 1905
		[EnumMember(Value = "file_systems")]
		FileSystems,
		// Token: 0x04000772 RID: 1906
		[EnumMember(Value = "indexeddb")]
		Indexeddb,
		// Token: 0x04000773 RID: 1907
		[EnumMember(Value = "local_storage")]
		LocalStorage,
		// Token: 0x04000774 RID: 1908
		[EnumMember(Value = "shader_cache")]
		ShaderCache,
		// Token: 0x04000775 RID: 1909
		[EnumMember(Value = "websql")]
		Websql,
		// Token: 0x04000776 RID: 1910
		[EnumMember(Value = "service_workers")]
		ServiceWorkers,
		// Token: 0x04000777 RID: 1911
		[EnumMember(Value = "cache_storage")]
		CacheStorage,
		// Token: 0x04000778 RID: 1912
		[EnumMember(Value = "interest_groups")]
		InterestGroups,
		// Token: 0x04000779 RID: 1913
		[EnumMember(Value = "all")]
		All,
		// Token: 0x0400077A RID: 1914
		[EnumMember(Value = "other")]
		Other
	}
}
