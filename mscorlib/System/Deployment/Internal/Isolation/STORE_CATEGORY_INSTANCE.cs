using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200067B RID: 1659
	internal struct STORE_CATEGORY_INSTANCE
	{
		// Token: 0x040021EE RID: 8686
		public IDefinitionAppId DefinitionAppId_Application;

		// Token: 0x040021EF RID: 8687
		[MarshalAs(UnmanagedType.LPWStr)]
		public string XMLSnippet;
	}
}
