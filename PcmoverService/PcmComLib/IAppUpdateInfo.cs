using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200005F RID: 95
	[CompilerGenerated]
	[Guid("404E2EB9-DF2F-417A-BDA5-63209DBE6F5D")]
	[TypeIdentifier]
	[ComImport]
	public interface IAppUpdateInfo
	{
		// Token: 0x060002D3 RID: 723
		void _VtblGap1_1();

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002D4 RID: 724
		[DispId(4)]
		bool AppUpdateAvailable { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002D5 RID: 725
		[DispId(5)]
		bool AppUpdateRequired { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002D6 RID: 726
		[DispId(6)]
		string AppUpdateUrl { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002D7 RID: 727
		[DispId(7)]
		bool DataUpdateAvailable { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002D8 RID: 728
		[DispId(8)]
		bool DataUpdateRequired { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002D9 RID: 729
		[DispId(9)]
		bool Checked { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
