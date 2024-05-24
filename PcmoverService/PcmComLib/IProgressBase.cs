using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000086 RID: 134
	[CompilerGenerated]
	[Guid("4D32B114-CCB3-4083-85CB-C3682C1C5A59")]
	[TypeIdentifier]
	[ComImport]
	public interface IProgressBase
	{
		// Token: 0x06000457 RID: 1111
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Set();

		// Token: 0x06000458 RID: 1112
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetCancel();

		// Token: 0x06000459 RID: 1113
		void _VtblGap1_5();

		// Token: 0x0600045A RID: 1114
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetProgressHandlers([MarshalAs(UnmanagedType.Interface)] [In] ProgressCallbacks pCallbacks);

		// Token: 0x0600045B RID: 1115
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Reset();
	}
}
