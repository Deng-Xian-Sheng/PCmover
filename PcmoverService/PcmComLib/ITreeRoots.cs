using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000096 RID: 150
	[CompilerGenerated]
	[DefaultMember("Item")]
	[Guid("F6E82DFE-DE37-4FB0-8C1E-B5E42DC92873")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeRoots : IPCmoverObject, IEnumerable
	{
		// Token: 0x060004C3 RID: 1219
		void _VtblGap1_5();

		// Token: 0x060004C4 RID: 1220
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		TreeRoot GetTreeRoot([In] ENUM_TTID ttid);
	}
}
