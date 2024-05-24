using System;

namespace CefSharp.Internals
{
	// Token: 0x020000E0 RID: 224
	public class MethodParameter
	{
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x0000B069 File Offset: 0x00009269
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x0000B071 File Offset: 0x00009271
		public bool IsParamArray { get; set; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x0000B07A File Offset: 0x0000927A
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x0000B082 File Offset: 0x00009282
		public Type Type { get; set; }
	}
}
