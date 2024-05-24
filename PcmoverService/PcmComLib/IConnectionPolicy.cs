using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000063 RID: 99
	[CompilerGenerated]
	[Guid("64145DE1-7B6B-496B-9769-14B6D3F58DEF")]
	[TypeIdentifier]
	[ComImport]
	public interface IConnectionPolicy
	{
		// Token: 0x060002EF RID: 751
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsEnabled([In] CONNECTION_POLICY_METHODS method);

		// Token: 0x060002F0 RID: 752
		void _VtblGap1_2();

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002F1 RID: 753
		[DispId(4)]
		string strNetworkTarget { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060002F2 RID: 754
		void _VtblGap2_5();

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002F3 RID: 755
		[DispId(10)]
		FileConnectionPolicy FileConnectionPolicy { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060002F4 RID: 756
		void _VtblGap3_3();

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002F5 RID: 757
		[DispId(14)]
		CONNECTION_POLICY_METHODS Methods { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002F6 RID: 758
		// (set) Token: 0x060002F7 RID: 759
		[DispId(15)]
		SSL_FLAGS SSLFlags { [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002F8 RID: 760
		[DispId(16)]
		TRIBOOL_VALUE IsNetworkMachineOld { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
