using System;
using System.Runtime.CompilerServices;

namespace System.StubHelpers
{
	// Token: 0x020005A4 RID: 1444
	internal static class WinRTTypeNameConverter
	{
		// Token: 0x0600431E RID: 17182
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string ConvertToWinRTTypeName(Type managedType, out bool isPrimitive);

		// Token: 0x0600431F RID: 17183
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Type GetTypeFromWinRTTypeName(string typeName, out bool isPrimitive);
	}
}
