using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000060 RID: 96
	[CompilerGenerated]
	[Guid("D92FD909-6AC6-4C51-8CF0-74B861A49F73")]
	[TypeIdentifier]
	[ComImport]
	public interface IBrandEnginePolicy
	{
		// Token: 0x060002DA RID: 730
		void _VtblGap1_3();

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002DB RID: 731
		[DispId(4)]
		string strOem { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
