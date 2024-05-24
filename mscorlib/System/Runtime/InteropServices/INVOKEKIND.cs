using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200099F RID: 2463
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.INVOKEKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum INVOKEKIND
	{
		// Token: 0x04002C64 RID: 11364
		INVOKE_FUNC = 1,
		// Token: 0x04002C65 RID: 11365
		INVOKE_PROPERTYGET,
		// Token: 0x04002C66 RID: 11366
		INVOKE_PROPERTYPUT = 4,
		// Token: 0x04002C67 RID: 11367
		INVOKE_PROPERTYPUTREF = 8
	}
}
