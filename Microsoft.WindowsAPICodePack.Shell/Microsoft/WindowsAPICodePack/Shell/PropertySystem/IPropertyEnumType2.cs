using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000A0 RID: 160
	[Guid("9B6E051C-5DDD-4321-9070-FE2ACB55E794")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPropertyEnumType2 : IPropertyEnumType
	{
		// Token: 0x06000542 RID: 1346
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetEnumType(out PropEnumType penumtype);

		// Token: 0x06000543 RID: 1347
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetValue([Out] PropVariant ppropvar);

		// Token: 0x06000544 RID: 1348
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRangeMinValue([Out] PropVariant ppropvar);

		// Token: 0x06000545 RID: 1349
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRangeSetValue([Out] PropVariant ppropvar);

		// Token: 0x06000546 RID: 1350
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDisplayText([MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);

		// Token: 0x06000547 RID: 1351
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetImageReference([MarshalAs(UnmanagedType.LPWStr)] out string ppszImageRes);
	}
}
