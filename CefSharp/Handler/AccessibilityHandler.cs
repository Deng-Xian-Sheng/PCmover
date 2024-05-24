using System;

namespace CefSharp.Handler
{
	// Token: 0x020000F6 RID: 246
	public class AccessibilityHandler : IAccessibilityHandler
	{
		// Token: 0x06000736 RID: 1846 RVA: 0x0000C0E9 File Offset: 0x0000A2E9
		void IAccessibilityHandler.OnAccessibilityLocationChange(IValue value)
		{
			this.OnAccessibilityLocationChange(value);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0000C0F2 File Offset: 0x0000A2F2
		protected virtual void OnAccessibilityLocationChange(IValue value)
		{
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0000C0F4 File Offset: 0x0000A2F4
		void IAccessibilityHandler.OnAccessibilityTreeChange(IValue value)
		{
			this.OnAccessibilityTreeChange(value);
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0000C0FD File Offset: 0x0000A2FD
		protected virtual void OnAccessibilityTreeChange(IValue value)
		{
		}
	}
}
