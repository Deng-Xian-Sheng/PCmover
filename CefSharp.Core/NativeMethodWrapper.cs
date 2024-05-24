using System;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x02000007 RID: 7
	public static class NativeMethodWrapper
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x00002A74 File Offset: 0x00000C74
		public static void MemoryCopy(IntPtr dest, IntPtr src, int numberOfBytes)
		{
			NativeMethodWrapper.MemoryCopy(dest, src, numberOfBytes);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002A7E File Offset: 0x00000C7E
		public static bool IsFocused(IntPtr handle)
		{
			return NativeMethodWrapper.IsFocused(handle);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002A86 File Offset: 0x00000C86
		public static void SetWindowPosition(IntPtr handle, int x, int y, int width, int height)
		{
			NativeMethodWrapper.SetWindowPosition(handle, x, y, width, height);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002A93 File Offset: 0x00000C93
		public static void SetWindowParent(IntPtr child, IntPtr newParent)
		{
			NativeMethodWrapper.SetWindowParent(child, newParent);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00002A9C File Offset: 0x00000C9C
		public static void RemoveExNoActivateStyle(IntPtr browserHwnd)
		{
			NativeMethodWrapper.RemoveExNoActivateStyle(browserHwnd);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public static IntPtr LoadCursorFromLibCef(int resourceIdentifier)
		{
			return NativeMethodWrapper.LoadCursorFromLibCef(resourceIdentifier);
		}
	}
}
