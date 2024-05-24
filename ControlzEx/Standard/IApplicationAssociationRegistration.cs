using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A1 RID: 161
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("4e530b0a-e611-4c77-a3ac-9031d022281b")]
	[ComImport]
	internal interface IApplicationAssociationRegistration
	{
		// Token: 0x0600028C RID: 652
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string QueryCurrentDefault([MarshalAs(UnmanagedType.LPWStr)] string pszQuery, AT atQueryType, AL alQueryLevel);

		// Token: 0x0600028D RID: 653
		[return: MarshalAs(UnmanagedType.Bool)]
		bool QueryAppIsDefault([MarshalAs(UnmanagedType.LPWStr)] string pszQuery, AT atQueryType, AL alQueryLevel, [MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName);

		// Token: 0x0600028E RID: 654
		[return: MarshalAs(UnmanagedType.Bool)]
		bool QueryAppIsDefaultAll(AL alQueryLevel, [MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName);

		// Token: 0x0600028F RID: 655
		void SetAppAsDefault([MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName, [MarshalAs(UnmanagedType.LPWStr)] string pszSet, AT atSetType);

		// Token: 0x06000290 RID: 656
		void SetAppAsDefaultAll([MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName);

		// Token: 0x06000291 RID: 657
		void ClearUserAssociations();
	}
}
