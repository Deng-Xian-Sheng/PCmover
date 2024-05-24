using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200007F RID: 127
	[CompilerGenerated]
	[Guid("01CD3C56-E5A9-41F5-9431-8E958474A97E")]
	[TypeIdentifier]
	[ComImport]
	public interface IPasswordPolicy
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060003EE RID: 1006
		[DispId(1)]
		string strPw { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060003EF RID: 1007
		[DispId(2)]
		bool bModify { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060003F0 RID: 1008
		[DispId(3)]
		bool bRequired { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
