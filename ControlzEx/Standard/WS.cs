using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000037 RID: 55
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Flags]
	public enum WS : uint
	{
		// Token: 0x04000351 RID: 849
		OVERLAPPED = 0U,
		// Token: 0x04000352 RID: 850
		POPUP = 2147483648U,
		// Token: 0x04000353 RID: 851
		CHILD = 1073741824U,
		// Token: 0x04000354 RID: 852
		MINIMIZE = 536870912U,
		// Token: 0x04000355 RID: 853
		VISIBLE = 268435456U,
		// Token: 0x04000356 RID: 854
		DISABLED = 134217728U,
		// Token: 0x04000357 RID: 855
		CLIPSIBLINGS = 67108864U,
		// Token: 0x04000358 RID: 856
		CLIPCHILDREN = 33554432U,
		// Token: 0x04000359 RID: 857
		MAXIMIZE = 16777216U,
		// Token: 0x0400035A RID: 858
		BORDER = 8388608U,
		// Token: 0x0400035B RID: 859
		DLGFRAME = 4194304U,
		// Token: 0x0400035C RID: 860
		VSCROLL = 2097152U,
		// Token: 0x0400035D RID: 861
		HSCROLL = 1048576U,
		// Token: 0x0400035E RID: 862
		SYSMENU = 524288U,
		// Token: 0x0400035F RID: 863
		THICKFRAME = 262144U,
		// Token: 0x04000360 RID: 864
		GROUP = 131072U,
		// Token: 0x04000361 RID: 865
		TABSTOP = 65536U,
		// Token: 0x04000362 RID: 866
		MINIMIZEBOX = 131072U,
		// Token: 0x04000363 RID: 867
		MAXIMIZEBOX = 65536U,
		// Token: 0x04000364 RID: 868
		CAPTION = 12582912U,
		// Token: 0x04000365 RID: 869
		TILED = 0U,
		// Token: 0x04000366 RID: 870
		ICONIC = 536870912U,
		// Token: 0x04000367 RID: 871
		SIZEBOX = 262144U,
		// Token: 0x04000368 RID: 872
		TILEDWINDOW = 13565952U,
		// Token: 0x04000369 RID: 873
		OVERLAPPEDWINDOW = 13565952U,
		// Token: 0x0400036A RID: 874
		POPUPWINDOW = 2156396544U,
		// Token: 0x0400036B RID: 875
		CHILDWINDOW = 1073741824U
	}
}
