using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000421 RID: 1057
	public enum AttributionReportingIssueType
	{
		// Token: 0x04001086 RID: 4230
		[EnumMember(Value = "PermissionPolicyDisabled")]
		PermissionPolicyDisabled,
		// Token: 0x04001087 RID: 4231
		[EnumMember(Value = "InvalidAttributionSourceEventId")]
		InvalidAttributionSourceEventId,
		// Token: 0x04001088 RID: 4232
		[EnumMember(Value = "InvalidAttributionData")]
		InvalidAttributionData,
		// Token: 0x04001089 RID: 4233
		[EnumMember(Value = "AttributionSourceUntrustworthyOrigin")]
		AttributionSourceUntrustworthyOrigin,
		// Token: 0x0400108A RID: 4234
		[EnumMember(Value = "AttributionUntrustworthyOrigin")]
		AttributionUntrustworthyOrigin,
		// Token: 0x0400108B RID: 4235
		[EnumMember(Value = "AttributionTriggerDataTooLarge")]
		AttributionTriggerDataTooLarge,
		// Token: 0x0400108C RID: 4236
		[EnumMember(Value = "AttributionEventSourceTriggerDataTooLarge")]
		AttributionEventSourceTriggerDataTooLarge,
		// Token: 0x0400108D RID: 4237
		[EnumMember(Value = "InvalidAttributionSourceExpiry")]
		InvalidAttributionSourceExpiry,
		// Token: 0x0400108E RID: 4238
		[EnumMember(Value = "InvalidAttributionSourcePriority")]
		InvalidAttributionSourcePriority,
		// Token: 0x0400108F RID: 4239
		[EnumMember(Value = "InvalidEventSourceTriggerData")]
		InvalidEventSourceTriggerData,
		// Token: 0x04001090 RID: 4240
		[EnumMember(Value = "InvalidTriggerPriority")]
		InvalidTriggerPriority,
		// Token: 0x04001091 RID: 4241
		[EnumMember(Value = "InvalidTriggerDedupKey")]
		InvalidTriggerDedupKey
	}
}
