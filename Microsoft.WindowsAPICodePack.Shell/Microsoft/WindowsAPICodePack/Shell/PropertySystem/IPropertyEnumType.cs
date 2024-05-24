using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200009F RID: 159
	[Guid("11E1FBF9-2D56-4A6B-8DB3-7CD193A471F2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPropertyEnumType
	{
		// Token: 0x0600053D RID: 1341
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetEnumType(out PropEnumType penumtype);

		// Token: 0x0600053E RID: 1342
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetValue([Out] PropVariant ppropvar);

		// Token: 0x0600053F RID: 1343
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRangeMinValue([Out] PropVariant ppropvar);

		// Token: 0x06000540 RID: 1344
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRangeSetValue([Out] PropVariant ppropvar);

		// Token: 0x06000541 RID: 1345
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDisplayText([MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);
	}
}
