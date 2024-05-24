using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000441 RID: 1089
	public enum AXValueNativeSourceType
	{
		// Token: 0x0400112A RID: 4394
		[EnumMember(Value = "description")]
		Description,
		// Token: 0x0400112B RID: 4395
		[EnumMember(Value = "figcaption")]
		Figcaption,
		// Token: 0x0400112C RID: 4396
		[EnumMember(Value = "label")]
		Label,
		// Token: 0x0400112D RID: 4397
		[EnumMember(Value = "labelfor")]
		Labelfor,
		// Token: 0x0400112E RID: 4398
		[EnumMember(Value = "labelwrapped")]
		Labelwrapped,
		// Token: 0x0400112F RID: 4399
		[EnumMember(Value = "legend")]
		Legend,
		// Token: 0x04001130 RID: 4400
		[EnumMember(Value = "rubyannotation")]
		Rubyannotation,
		// Token: 0x04001131 RID: 4401
		[EnumMember(Value = "tablecaption")]
		Tablecaption,
		// Token: 0x04001132 RID: 4402
		[EnumMember(Value = "title")]
		Title,
		// Token: 0x04001133 RID: 4403
		[EnumMember(Value = "other")]
		Other
	}
}
