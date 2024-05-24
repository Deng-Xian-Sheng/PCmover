using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200008A RID: 138
	[CompilerGenerated]
	[Guid("67744BA7-B7D4-4C56-BCFA-7FF3B452114B")]
	[TypeIdentifier]
	[ComImport]
	public interface IRemoteMachine
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600047B RID: 1147
		[DispId(1)]
		string Name { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x0600047C RID: 1148
		void _VtblGap1_1();

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600047D RID: 1149
		[DispId(3)]
		bool bBonjour { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600047E RID: 1150
		[DispId(4)]
		bool bUSB { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600047F RID: 1151
		[DispId(5)]
		uint userDataLength { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000480 RID: 1152
		void _VtblGap2_1();

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000481 RID: 1153
		[DispId(7)]
		byte[] UserData { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }
	}
}
