using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200067E RID: 1662
	internal struct CATEGORY_INSTANCE
	{
		// Token: 0x040021F2 RID: 8690
		public IDefinitionAppId DefinitionAppId_Application;

		// Token: 0x040021F3 RID: 8691
		[MarshalAs(UnmanagedType.LPWStr)]
		public string XMLSnippet;
	}
}
