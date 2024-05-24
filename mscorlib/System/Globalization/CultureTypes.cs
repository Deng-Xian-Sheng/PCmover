using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003AA RID: 938
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum CultureTypes
	{
		// Token: 0x04001352 RID: 4946
		NeutralCultures = 1,
		// Token: 0x04001353 RID: 4947
		SpecificCultures = 2,
		// Token: 0x04001354 RID: 4948
		InstalledWin32Cultures = 4,
		// Token: 0x04001355 RID: 4949
		AllCultures = 7,
		// Token: 0x04001356 RID: 4950
		UserCustomCulture = 8,
		// Token: 0x04001357 RID: 4951
		ReplacementCultures = 16,
		// Token: 0x04001358 RID: 4952
		[Obsolete("This value has been deprecated.  Please use other values in CultureTypes.")]
		WindowsOnlyCultures = 32,
		// Token: 0x04001359 RID: 4953
		[Obsolete("This value has been deprecated.  Please use other values in CultureTypes.")]
		FrameworkCultures = 64
	}
}
