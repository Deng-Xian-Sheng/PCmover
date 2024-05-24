using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200008E RID: 142
	[CompilerGenerated]
	[Guid("77F21E17-1D06-43FB-A9DF-31AA7BCF43AB")]
	[TypeIdentifier]
	[ComImport]
	public interface IStringMap
	{
		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600049E RID: 1182
		[DispId(1)]
		int Count { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600049F RID: 1183
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetByIndex([In] int index, [MarshalAs(UnmanagedType.BStr)] out string pKey, [MarshalAs(UnmanagedType.BStr)] out string pVal);
	}
}
