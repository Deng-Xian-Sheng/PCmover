using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F8 RID: 760
	public enum TrustTokenOperationDoneStatus
	{
		// Token: 0x04000C8F RID: 3215
		[EnumMember(Value = "Ok")]
		Ok,
		// Token: 0x04000C90 RID: 3216
		[EnumMember(Value = "InvalidArgument")]
		InvalidArgument,
		// Token: 0x04000C91 RID: 3217
		[EnumMember(Value = "FailedPrecondition")]
		FailedPrecondition,
		// Token: 0x04000C92 RID: 3218
		[EnumMember(Value = "ResourceExhausted")]
		ResourceExhausted,
		// Token: 0x04000C93 RID: 3219
		[EnumMember(Value = "AlreadyExists")]
		AlreadyExists,
		// Token: 0x04000C94 RID: 3220
		[EnumMember(Value = "Unavailable")]
		Unavailable,
		// Token: 0x04000C95 RID: 3221
		[EnumMember(Value = "BadResponse")]
		BadResponse,
		// Token: 0x04000C96 RID: 3222
		[EnumMember(Value = "InternalError")]
		InternalError,
		// Token: 0x04000C97 RID: 3223
		[EnumMember(Value = "UnknownError")]
		UnknownError,
		// Token: 0x04000C98 RID: 3224
		[EnumMember(Value = "FulfilledLocally")]
		FulfilledLocally
	}
}
