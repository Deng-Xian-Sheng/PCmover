using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000990 RID: 2448
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.TYPEKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum TYPEKIND
	{
		// Token: 0x04002BF8 RID: 11256
		TKIND_ENUM,
		// Token: 0x04002BF9 RID: 11257
		TKIND_RECORD,
		// Token: 0x04002BFA RID: 11258
		TKIND_MODULE,
		// Token: 0x04002BFB RID: 11259
		TKIND_INTERFACE,
		// Token: 0x04002BFC RID: 11260
		TKIND_DISPATCH,
		// Token: 0x04002BFD RID: 11261
		TKIND_COCLASS,
		// Token: 0x04002BFE RID: 11262
		TKIND_ALIAS,
		// Token: 0x04002BFF RID: 11263
		TKIND_UNION,
		// Token: 0x04002C00 RID: 11264
		TKIND_MAX
	}
}
