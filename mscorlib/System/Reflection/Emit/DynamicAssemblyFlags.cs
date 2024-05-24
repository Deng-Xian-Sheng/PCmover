using System;

namespace System.Reflection.Emit
{
	// Token: 0x02000627 RID: 1575
	[Flags]
	internal enum DynamicAssemblyFlags
	{
		// Token: 0x04001E3C RID: 7740
		None = 0,
		// Token: 0x04001E3D RID: 7741
		AllCritical = 1,
		// Token: 0x04001E3E RID: 7742
		Aptca = 2,
		// Token: 0x04001E3F RID: 7743
		Critical = 4,
		// Token: 0x04001E40 RID: 7744
		Transparent = 8,
		// Token: 0x04001E41 RID: 7745
		TreatAsSafe = 16
	}
}
