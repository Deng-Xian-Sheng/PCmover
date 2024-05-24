using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WUApiLib
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	[Guid("3442D4FE-224D-4CEE-98CF-30E0C4D229E6")]
	[TypeIdentifier]
	[ComImport]
	public interface IUpdateInstaller2 : IUpdateInstaller
	{
		// Token: 0x06000059 RID: 89
		void _VtblGap1_16();

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600005A RID: 90
		[DispId(1610743820)]
		bool IsBusy { [DispId(1610743820)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600005B RID: 91
		void _VtblGap2_3();

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600005C RID: 92
		[DispId(1610743823)]
		bool RebootRequiredBeforeInstallation { [DispId(1610743823)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
