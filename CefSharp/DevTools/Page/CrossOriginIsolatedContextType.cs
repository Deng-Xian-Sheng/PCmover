using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000231 RID: 561
	public enum CrossOriginIsolatedContextType
	{
		// Token: 0x04000839 RID: 2105
		[EnumMember(Value = "Isolated")]
		Isolated,
		// Token: 0x0400083A RID: 2106
		[EnumMember(Value = "NotIsolated")]
		NotIsolated,
		// Token: 0x0400083B RID: 2107
		[EnumMember(Value = "NotIsolatedFeatureDisabled")]
		NotIsolatedFeatureDisabled
	}
}
