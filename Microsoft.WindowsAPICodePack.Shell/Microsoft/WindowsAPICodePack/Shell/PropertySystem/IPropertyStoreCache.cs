using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200009A RID: 154
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3017056d-9a91-4e90-937d-746c72abbf4f")]
	[ComImport]
	internal interface IPropertyStoreCache
	{
		// Token: 0x06000507 RID: 1287
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult GetState(ref PropertyKey key, out PropertyStoreCacheState state);

		// Token: 0x06000508 RID: 1288
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult GetValueAndState(ref PropertyKey propKey, [Out] PropVariant pv, out PropertyStoreCacheState state);

		// Token: 0x06000509 RID: 1289
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult SetState(ref PropertyKey propKey, PropertyStoreCacheState state);

		// Token: 0x0600050A RID: 1290
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult SetValueAndState(ref PropertyKey propKey, [In] PropVariant pv, PropertyStoreCacheState state);
	}
}
