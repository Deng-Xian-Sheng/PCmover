using System;

namespace ControlzEx.Native
{
	// Token: 0x0200000C RID: 12
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public static class Constants
	{
		// Token: 0x0400002D RID: 45
		public const int GCLP_HBRBACKGROUND = -10;

		// Token: 0x0400002E RID: 46
		public const uint TPM_RETURNCMD = 256U;

		// Token: 0x0400002F RID: 47
		public const uint TPM_LEFTBUTTON = 0U;

		// Token: 0x04000030 RID: 48
		public const uint SYSCOMMAND = 274U;

		// Token: 0x04000031 RID: 49
		public const int MF_GRAYED = 1;

		// Token: 0x04000032 RID: 50
		public const int MF_BYCOMMAND = 0;

		// Token: 0x04000033 RID: 51
		public const int MF_ENABLED = 0;

		// Token: 0x04000034 RID: 52
		public const int VK_SHIFT = 16;

		// Token: 0x04000035 RID: 53
		public const int VK_CONTROL = 17;

		// Token: 0x04000036 RID: 54
		public const int VK_MENU = 18;

		// Token: 0x04000037 RID: 55
		public const uint MAPVK_VK_TO_VSC = 0U;

		// Token: 0x04000038 RID: 56
		public const uint MAPVK_VSC_TO_VK = 1U;

		// Token: 0x04000039 RID: 57
		public const uint MAPVK_VK_TO_CHAR = 2U;

		// Token: 0x0400003A RID: 58
		public const uint MAPVK_VSC_TO_VK_EX = 3U;

		// Token: 0x0400003B RID: 59
		public const uint MAPVK_VK_TO_VSC_EX = 4U;

		// Token: 0x0400003C RID: 60
		public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

		// Token: 0x0400003D RID: 61
		public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

		// Token: 0x0400003E RID: 62
		public static readonly IntPtr HWND_TOP = new IntPtr(0);

		// Token: 0x0400003F RID: 63
		public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

		// Token: 0x04000040 RID: 64
		public const int CC_ANYCOLOR = 256;

		// Token: 0x020000C9 RID: 201
		[Flags]
		public enum RedrawWindowFlags : uint
		{
			// Token: 0x040006F7 RID: 1783
			Invalidate = 1U,
			// Token: 0x040006F8 RID: 1784
			InternalPaint = 2U,
			// Token: 0x040006F9 RID: 1785
			Erase = 4U,
			// Token: 0x040006FA RID: 1786
			Validate = 8U,
			// Token: 0x040006FB RID: 1787
			NoInternalPaint = 16U,
			// Token: 0x040006FC RID: 1788
			NoErase = 32U,
			// Token: 0x040006FD RID: 1789
			NoChildren = 64U,
			// Token: 0x040006FE RID: 1790
			AllChildren = 128U,
			// Token: 0x040006FF RID: 1791
			UpdateNow = 256U,
			// Token: 0x04000700 RID: 1792
			EraseNow = 512U,
			// Token: 0x04000701 RID: 1793
			Frame = 1024U,
			// Token: 0x04000702 RID: 1794
			NoFrame = 2048U
		}
	}
}
