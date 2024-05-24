using System;

namespace CefSharp
{
	// Token: 0x0200004D RID: 77
	public interface IAccessibilityHandler
	{
		// Token: 0x06000128 RID: 296
		void OnAccessibilityLocationChange(IValue value);

		// Token: 0x06000129 RID: 297
		void OnAccessibilityTreeChange(IValue value);
	}
}
