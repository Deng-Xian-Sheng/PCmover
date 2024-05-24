using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000059 RID: 89
	[CompilerGenerated]
	[Guid("6FBEEBED-66FF-471A-82CA-321C723D46CA")]
	[TypeIdentifier]
	[ComImport]
	public interface IAlertPolicy
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000298 RID: 664
		[DispId(1)]
		string strName { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000299 RID: 665
		[DispId(2)]
		string strEmail { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600029A RID: 666
		[DispId(3)]
		string strMessage { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x0600029B RID: 667
		void _VtblGap1_3();

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600029C RID: 668
		[DispId(7)]
		bool bInteractive { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
