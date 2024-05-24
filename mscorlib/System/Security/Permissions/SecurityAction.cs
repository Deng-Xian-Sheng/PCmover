using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002ED RID: 749
	[ComVisible(true)]
	[Serializable]
	public enum SecurityAction
	{
		// Token: 0x04000ED6 RID: 3798
		Demand = 2,
		// Token: 0x04000ED7 RID: 3799
		Assert,
		// Token: 0x04000ED8 RID: 3800
		[Obsolete("Deny is obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		Deny,
		// Token: 0x04000ED9 RID: 3801
		PermitOnly,
		// Token: 0x04000EDA RID: 3802
		LinkDemand,
		// Token: 0x04000EDB RID: 3803
		InheritanceDemand,
		// Token: 0x04000EDC RID: 3804
		[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		RequestMinimum,
		// Token: 0x04000EDD RID: 3805
		[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		RequestOptional,
		// Token: 0x04000EDE RID: 3806
		[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		RequestRefuse
	}
}
