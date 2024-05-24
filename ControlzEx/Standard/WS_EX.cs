using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000039 RID: 57
	[Flags]
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public enum WS_EX : uint
	{
		// Token: 0x040003F4 RID: 1012
		None = 0U,
		// Token: 0x040003F5 RID: 1013
		DLGMODALFRAME = 1U,
		// Token: 0x040003F6 RID: 1014
		NOPARENTNOTIFY = 4U,
		// Token: 0x040003F7 RID: 1015
		TOPMOST = 8U,
		// Token: 0x040003F8 RID: 1016
		ACCEPTFILES = 16U,
		// Token: 0x040003F9 RID: 1017
		TRANSPARENT = 32U,
		// Token: 0x040003FA RID: 1018
		MDICHILD = 64U,
		// Token: 0x040003FB RID: 1019
		TOOLWINDOW = 128U,
		// Token: 0x040003FC RID: 1020
		WINDOWEDGE = 256U,
		// Token: 0x040003FD RID: 1021
		CLIENTEDGE = 512U,
		// Token: 0x040003FE RID: 1022
		CONTEXTHELP = 1024U,
		// Token: 0x040003FF RID: 1023
		RIGHT = 4096U,
		// Token: 0x04000400 RID: 1024
		LEFT = 0U,
		// Token: 0x04000401 RID: 1025
		RTLREADING = 8192U,
		// Token: 0x04000402 RID: 1026
		LTRREADING = 0U,
		// Token: 0x04000403 RID: 1027
		LEFTSCROLLBAR = 16384U,
		// Token: 0x04000404 RID: 1028
		RIGHTSCROLLBAR = 0U,
		// Token: 0x04000405 RID: 1029
		CONTROLPARENT = 65536U,
		// Token: 0x04000406 RID: 1030
		STATICEDGE = 131072U,
		// Token: 0x04000407 RID: 1031
		APPWINDOW = 262144U,
		// Token: 0x04000408 RID: 1032
		LAYERED = 524288U,
		// Token: 0x04000409 RID: 1033
		NOINHERITLAYOUT = 1048576U,
		// Token: 0x0400040A RID: 1034
		LAYOUTRTL = 4194304U,
		// Token: 0x0400040B RID: 1035
		COMPOSITED = 33554432U,
		// Token: 0x0400040C RID: 1036
		NOACTIVATE = 134217728U,
		// Token: 0x0400040D RID: 1037
		OVERLAPPEDWINDOW = 768U,
		// Token: 0x0400040E RID: 1038
		PALETTEWINDOW = 392U
	}
}
