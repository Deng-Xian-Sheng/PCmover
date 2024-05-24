using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A6 RID: 166
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
	[ComImport]
	internal interface IPropertyStore
	{
		// Token: 0x060002A2 RID: 674
		uint GetCount();

		// Token: 0x060002A3 RID: 675
		PKEY GetAt(uint iProp);

		// Token: 0x060002A4 RID: 676
		void GetValue([In] ref PKEY pkey, [In] [Out] PROPVARIANT pv);

		// Token: 0x060002A5 RID: 677
		void SetValue([In] ref PKEY pkey, PROPVARIANT pv);

		// Token: 0x060002A6 RID: 678
		void Commit();
	}
}
