using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x0200020E RID: 526
	public enum ServiceWorkerVersionStatus
	{
		// Token: 0x040007B0 RID: 1968
		[EnumMember(Value = "new")]
		New,
		// Token: 0x040007B1 RID: 1969
		[EnumMember(Value = "installing")]
		Installing,
		// Token: 0x040007B2 RID: 1970
		[EnumMember(Value = "installed")]
		Installed,
		// Token: 0x040007B3 RID: 1971
		[EnumMember(Value = "activating")]
		Activating,
		// Token: 0x040007B4 RID: 1972
		[EnumMember(Value = "activated")]
		Activated,
		// Token: 0x040007B5 RID: 1973
		[EnumMember(Value = "redundant")]
		Redundant
	}
}
