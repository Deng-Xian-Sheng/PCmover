using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x020001FE RID: 510
	public enum InterestGroupAccessType
	{
		// Token: 0x04000780 RID: 1920
		[EnumMember(Value = "join")]
		Join,
		// Token: 0x04000781 RID: 1921
		[EnumMember(Value = "leave")]
		Leave,
		// Token: 0x04000782 RID: 1922
		[EnumMember(Value = "update")]
		Update,
		// Token: 0x04000783 RID: 1923
		[EnumMember(Value = "bid")]
		Bid,
		// Token: 0x04000784 RID: 1924
		[EnumMember(Value = "win")]
		Win
	}
}
