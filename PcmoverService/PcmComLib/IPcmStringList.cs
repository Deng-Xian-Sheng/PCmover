using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000081 RID: 129
	[CompilerGenerated]
	[Guid("70783070-9F87-4000-A4E4-5FCF5A0F6E08")]
	[DefaultMember("Item")]
	[TypeIdentifier]
	[ComImport]
	public interface IPcmStringList : IEnumerable
	{
		// Token: 0x0600040C RID: 1036
		void _VtblGap1_2();

		// Token: 0x0600040D RID: 1037
		[DispId(-4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler)]
		IEnumerator GetEnumerator();
	}
}
