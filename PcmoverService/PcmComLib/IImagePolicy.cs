using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200006F RID: 111
	[CompilerGenerated]
	[Guid("735A33F7-5B38-49EA-8B28-F75303A7E093")]
	[TypeIdentifier]
	[ComImport]
	public interface IImagePolicy
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000344 RID: 836
		[DispId(1)]
		string ImageName { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000345 RID: 837
		[DispId(2)]
		string WindowsDir { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000346 RID: 838
		[DispId(3)]
		VirtualPhysicalMapping VirtualPhysicalMapping { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000347 RID: 839
		[DispId(4)]
		bool bInteractive { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
