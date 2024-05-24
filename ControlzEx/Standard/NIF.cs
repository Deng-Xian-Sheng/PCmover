using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200004E RID: 78
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Flags]
	public enum NIF : uint
	{
		// Token: 0x040004BE RID: 1214
		MESSAGE = 1U,
		// Token: 0x040004BF RID: 1215
		ICON = 2U,
		// Token: 0x040004C0 RID: 1216
		TIP = 4U,
		// Token: 0x040004C1 RID: 1217
		STATE = 8U,
		// Token: 0x040004C2 RID: 1218
		INFO = 16U,
		// Token: 0x040004C3 RID: 1219
		GUID = 32U,
		// Token: 0x040004C4 RID: 1220
		REALTIME = 64U,
		// Token: 0x040004C5 RID: 1221
		SHOWTIP = 128U,
		// Token: 0x040004C6 RID: 1222
		XP_MASK = 59U,
		// Token: 0x040004C7 RID: 1223
		VISTA_MASK = 251U
	}
}
