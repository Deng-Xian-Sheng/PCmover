using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200003B RID: 59
	internal static class IntPtrExtensions
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000A89C File Offset: 0x00008A9C
		public static T MarshalAs<T>(this IntPtr ptr)
		{
			return (T)((object)Marshal.PtrToStructure(ptr, typeof(T)));
		}
	}
}
