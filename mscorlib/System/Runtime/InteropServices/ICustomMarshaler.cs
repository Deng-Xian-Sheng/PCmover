using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200094A RID: 2378
	[ComVisible(true)]
	public interface ICustomMarshaler
	{
		// Token: 0x060060A5 RID: 24741
		object MarshalNativeToManaged(IntPtr pNativeData);

		// Token: 0x060060A6 RID: 24742
		IntPtr MarshalManagedToNative(object ManagedObj);

		// Token: 0x060060A7 RID: 24743
		void CleanUpNativeData(IntPtr pNativeData);

		// Token: 0x060060A8 RID: 24744
		void CleanUpManagedData(object ManagedObj);

		// Token: 0x060060A9 RID: 24745
		int GetNativeDataSize();
	}
}
