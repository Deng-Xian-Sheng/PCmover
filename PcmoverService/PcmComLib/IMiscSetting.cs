using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000076 RID: 118
	[CompilerGenerated]
	[Guid("58AD1D73-DEDB-46E6-9714-4A4FEAE9BA24")]
	[TypeIdentifier]
	[ComImport]
	public interface IMiscSetting : IPCmoverObject
	{
		// Token: 0x06000388 RID: 904
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x06000389 RID: 905
		void _VtblGap1_1();

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600038A RID: 906
		[DispId(3)]
		string Name { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600038B RID: 907
		[DispId(4)]
		string Text { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600038C RID: 908
		[DispId(5)]
		string Help { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600038D RID: 909
		// (set) Token: 0x0600038E RID: 910
		[DispId(6)]
		bool Selected { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600038F RID: 911
		[DispId(7)]
		bool Modify { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
