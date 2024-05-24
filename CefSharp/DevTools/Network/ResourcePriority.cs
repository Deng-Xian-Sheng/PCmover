using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002AD RID: 685
	public enum ResourcePriority
	{
		// Token: 0x04000AD5 RID: 2773
		[EnumMember(Value = "VeryLow")]
		VeryLow,
		// Token: 0x04000AD6 RID: 2774
		[EnumMember(Value = "Low")]
		Low,
		// Token: 0x04000AD7 RID: 2775
		[EnumMember(Value = "Medium")]
		Medium,
		// Token: 0x04000AD8 RID: 2776
		[EnumMember(Value = "High")]
		High,
		// Token: 0x04000AD9 RID: 2777
		[EnumMember(Value = "VeryHigh")]
		VeryHigh
	}
}
