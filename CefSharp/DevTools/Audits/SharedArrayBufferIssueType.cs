using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200041B RID: 1051
	public enum SharedArrayBufferIssueType
	{
		// Token: 0x04001069 RID: 4201
		[EnumMember(Value = "TransferIssue")]
		TransferIssue,
		// Token: 0x0400106A RID: 4202
		[EnumMember(Value = "CreationIssue")]
		CreationIssue
	}
}
