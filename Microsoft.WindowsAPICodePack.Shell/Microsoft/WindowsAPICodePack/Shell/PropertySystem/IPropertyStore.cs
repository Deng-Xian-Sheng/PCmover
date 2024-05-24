using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200009B RID: 155
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
	[ComImport]
	internal interface IPropertyStore
	{
		// Token: 0x0600050B RID: 1291
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult GetCount(out uint propertyCount);

		// Token: 0x0600050C RID: 1292
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult GetAt([In] uint propertyIndex, out PropertyKey key);

		// Token: 0x0600050D RID: 1293
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult GetValue([In] ref PropertyKey key, [Out] PropVariant pv);

		// Token: 0x0600050E RID: 1294
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult SetValue([In] ref PropertyKey key, [In] PropVariant pv);

		// Token: 0x0600050F RID: 1295
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Commit();
	}
}
