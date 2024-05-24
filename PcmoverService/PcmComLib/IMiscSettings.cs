using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000077 RID: 119
	[CompilerGenerated]
	[DefaultMember("Item")]
	[Guid("1C294755-EAAB-4567-B978-8AA0F29D8827")]
	[TypeIdentifier]
	[ComImport]
	public interface IMiscSettings : IPCmoverObject, IEnumerable
	{
		// Token: 0x06000390 RID: 912
		void _VtblGap1_4();

		// Token: 0x06000391 RID: 913
		[DispId(-4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler)]
		IEnumerator GetEnumerator();
	}
}
