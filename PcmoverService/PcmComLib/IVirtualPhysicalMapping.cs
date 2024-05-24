using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200009D RID: 157
	[CompilerGenerated]
	[Guid("D0F0090C-0F51-4425-BA7C-4C9178B5379D")]
	[TypeIdentifier]
	[ComImport]
	public interface IVirtualPhysicalMapping : IPCmoverObject
	{
		// Token: 0x060004FD RID: 1277
		void _VtblGap1_2();

		// Token: 0x060004FE RID: 1278
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AppendPair([MarshalAs(UnmanagedType.BStr)] [In] string Vstr, [MarshalAs(UnmanagedType.BStr)] [In] string Pstr);

		// Token: 0x060004FF RID: 1279
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPair([In] uint index, [MarshalAs(UnmanagedType.BStr)] out string pVstr, [MarshalAs(UnmanagedType.BStr)] out string pPstr);
	}
}
