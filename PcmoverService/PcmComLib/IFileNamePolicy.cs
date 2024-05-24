using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200006B RID: 107
	[CompilerGenerated]
	[Guid("A65290A4-FF87-4B1A-AEA3-CC00339B843E")]
	[TypeIdentifier]
	[ComImport]
	public interface IFileNamePolicy
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600031F RID: 799
		[DispId(1)]
		string strFileName { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000320 RID: 800
		[DispId(2)]
		bool bModify { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
