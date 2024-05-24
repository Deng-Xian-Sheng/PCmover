using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x02000404 RID: 1028
	[ComVisible(true)]
	[Serializable]
	public enum SymAddressKind
	{
		// Token: 0x040016E8 RID: 5864
		ILOffset = 1,
		// Token: 0x040016E9 RID: 5865
		NativeRVA,
		// Token: 0x040016EA RID: 5866
		NativeRegister,
		// Token: 0x040016EB RID: 5867
		NativeRegisterRelative,
		// Token: 0x040016EC RID: 5868
		NativeOffset,
		// Token: 0x040016ED RID: 5869
		NativeRegisterRegister,
		// Token: 0x040016EE RID: 5870
		NativeRegisterStack,
		// Token: 0x040016EF RID: 5871
		NativeStackRegister,
		// Token: 0x040016F0 RID: 5872
		BitField,
		// Token: 0x040016F1 RID: 5873
		NativeSectionOffset
	}
}
