using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000070 RID: 112
	[CompilerGenerated]
	[Guid("0866D78D-7742-4DBA-81A3-6DE3B1136A47")]
	[TypeIdentifier]
	[ComImport]
	public interface ILeafFilter : IPCmoverObject
	{
		// Token: 0x06000348 RID: 840
		void _VtblGap1_2();

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000349 RID: 841
		// (set) Token: 0x0600034A RID: 842
		[DispId(3)]
		string FullName { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600034B RID: 843
		// (set) Token: 0x0600034C RID: 844
		[DispId(4)]
		string Target { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600034D RID: 845
		[DispId(5)]
		bool Modify { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600034E RID: 846
		// (set) Token: 0x0600034F RID: 847
		[DispId(6)]
		TriBool Migrate { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
