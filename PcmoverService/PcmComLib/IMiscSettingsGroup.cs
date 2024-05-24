using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000078 RID: 120
	[CompilerGenerated]
	[Guid("C3DD80E6-857C-44EB-BAE2-D7BDFEE834DC")]
	[TypeIdentifier]
	[ComImport]
	public interface IMiscSettingsGroup : IPCmoverObject
	{
		// Token: 0x06000392 RID: 914
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x06000393 RID: 915
		void _VtblGap1_1();

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000394 RID: 916
		[DispId(3)]
		string Name { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000395 RID: 917
		[DispId(4)]
		string DisplayName { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000396 RID: 918
		[DispId(5)]
		MiscSettings Settings { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
