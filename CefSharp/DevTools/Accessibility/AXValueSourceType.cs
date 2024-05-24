using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000440 RID: 1088
	public enum AXValueSourceType
	{
		// Token: 0x04001123 RID: 4387
		[EnumMember(Value = "attribute")]
		Attribute,
		// Token: 0x04001124 RID: 4388
		[EnumMember(Value = "implicit")]
		Implicit,
		// Token: 0x04001125 RID: 4389
		[EnumMember(Value = "style")]
		Style,
		// Token: 0x04001126 RID: 4390
		[EnumMember(Value = "contents")]
		Contents,
		// Token: 0x04001127 RID: 4391
		[EnumMember(Value = "placeholder")]
		Placeholder,
		// Token: 0x04001128 RID: 4392
		[EnumMember(Value = "relatedElement")]
		RelatedElement
	}
}
