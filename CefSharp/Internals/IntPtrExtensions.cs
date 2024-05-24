using System;

namespace CefSharp.Internals
{
	// Token: 0x020000D4 RID: 212
	public static class IntPtrExtensions
	{
		// Token: 0x06000628 RID: 1576 RVA: 0x00009C2F File Offset: 0x00007E2F
		public static int CastToInt32(this IntPtr intPtr)
		{
			return (int)intPtr.ToInt64();
		}
	}
}
