using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell.Interop
{
	// Token: 0x0200003F RID: 63
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct WindowClassEx
	{
		// Token: 0x040000E9 RID: 233
		internal uint Size;

		// Token: 0x040000EA RID: 234
		internal uint Style;

		// Token: 0x040000EB RID: 235
		internal ShellObjectWatcherNativeMethods.WndProcDelegate WndProc;

		// Token: 0x040000EC RID: 236
		internal int ExtraClassBytes;

		// Token: 0x040000ED RID: 237
		internal int ExtraWindowBytes;

		// Token: 0x040000EE RID: 238
		internal IntPtr InstanceHandle;

		// Token: 0x040000EF RID: 239
		internal IntPtr IconHandle;

		// Token: 0x040000F0 RID: 240
		internal IntPtr CursorHandle;

		// Token: 0x040000F1 RID: 241
		internal IntPtr BackgroundBrushHandle;

		// Token: 0x040000F2 RID: 242
		internal string MenuName;

		// Token: 0x040000F3 RID: 243
		internal string ClassName;

		// Token: 0x040000F4 RID: 244
		internal IntPtr SmallIconHandle;
	}
}
