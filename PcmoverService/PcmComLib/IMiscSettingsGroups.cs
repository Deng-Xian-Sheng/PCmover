using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000079 RID: 121
	[CompilerGenerated]
	[DefaultMember("Item")]
	[Guid("DFAEF589-5542-4BB4-A860-0872CDB6D2DC")]
	[TypeIdentifier]
	[ComImport]
	public interface IMiscSettingsGroups : IPCmoverObject, IEnumerable
	{
		// Token: 0x06000397 RID: 919
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x06000398 RID: 920
		void _VtblGap1_3();

		// Token: 0x06000399 RID: 921
		[DispId(-4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler)]
		IEnumerator GetEnumerator();

		// Token: 0x0600039A RID: 922
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		MiscSetting FindMigMod([MarshalAs(UnmanagedType.BStr)] [In] string Name);
	}
}
