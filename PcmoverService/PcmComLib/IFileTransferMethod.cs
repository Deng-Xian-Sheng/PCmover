using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200006C RID: 108
	[CompilerGenerated]
	[Guid("1E71BB0E-32DD-4F32-9101-B69F5B37D189")]
	[TypeIdentifier]
	[ComImport]
	public interface IFileTransferMethod : ITransferMethod
	{
		// Token: 0x06000321 RID: 801
		void _VtblGap1_3();

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000322 RID: 802
		// (set) Token: 0x06000323 RID: 803
		[DispId(6)]
		string FileName { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000324 RID: 804
		// (set) Token: 0x06000325 RID: 805
		[DispId(7)]
		bool Span { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000326 RID: 806
		// (set) Token: 0x06000327 RID: 807
		[DispId(8)]
		ulong SpanSize { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000328 RID: 808
		// (set) Token: 0x06000329 RID: 809
		[DispId(9)]
		bool SpanNotify { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x170000C1 RID: 193
		// (set) Token: 0x0600032A RID: 810
		[DispId(10)]
		string CloudToken { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }
	}
}
