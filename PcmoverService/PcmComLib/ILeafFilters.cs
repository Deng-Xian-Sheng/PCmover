using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000071 RID: 113
	[CompilerGenerated]
	[Guid("6FD06A3A-13D1-4BEE-8EE8-23E6BF1272C5")]
	[TypeIdentifier]
	[ComImport]
	public interface ILeafFilters : IPCmoverObject, IEnumerable
	{
		// Token: 0x06000350 RID: 848
		void _VtblGap1_3();

		// Token: 0x170000CF RID: 207
		[DispId(0)]
		LeafFilter this[[In] int n]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		// Token: 0x06000352 RID: 850
		[DispId(-4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler)]
		IEnumerator GetEnumerator();

		// Token: 0x06000353 RID: 851
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Add([MarshalAs(UnmanagedType.BStr)] [In] string FullName, [MarshalAs(UnmanagedType.BStr)] [In] string Target, [In] TriBool Migrate, [In] bool Modify);

		// Token: 0x06000354 RID: 852
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Delete([In] int index);

		// Token: 0x06000355 RID: 853
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Swap([In] int index1, [In] int index2);
	}
}
