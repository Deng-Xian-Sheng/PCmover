using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200043F RID: 1087
	public enum AXValueType
	{
		// Token: 0x04001111 RID: 4369
		[EnumMember(Value = "boolean")]
		Boolean,
		// Token: 0x04001112 RID: 4370
		[EnumMember(Value = "tristate")]
		Tristate,
		// Token: 0x04001113 RID: 4371
		[EnumMember(Value = "booleanOrUndefined")]
		BooleanOrUndefined,
		// Token: 0x04001114 RID: 4372
		[EnumMember(Value = "idref")]
		Idref,
		// Token: 0x04001115 RID: 4373
		[EnumMember(Value = "idrefList")]
		IdrefList,
		// Token: 0x04001116 RID: 4374
		[EnumMember(Value = "integer")]
		Integer,
		// Token: 0x04001117 RID: 4375
		[EnumMember(Value = "node")]
		Node,
		// Token: 0x04001118 RID: 4376
		[EnumMember(Value = "nodeList")]
		NodeList,
		// Token: 0x04001119 RID: 4377
		[EnumMember(Value = "number")]
		Number,
		// Token: 0x0400111A RID: 4378
		[EnumMember(Value = "string")]
		String,
		// Token: 0x0400111B RID: 4379
		[EnumMember(Value = "computedString")]
		ComputedString,
		// Token: 0x0400111C RID: 4380
		[EnumMember(Value = "token")]
		Token,
		// Token: 0x0400111D RID: 4381
		[EnumMember(Value = "tokenList")]
		TokenList,
		// Token: 0x0400111E RID: 4382
		[EnumMember(Value = "domRelation")]
		DomRelation,
		// Token: 0x0400111F RID: 4383
		[EnumMember(Value = "role")]
		Role,
		// Token: 0x04001120 RID: 4384
		[EnumMember(Value = "internalRole")]
		InternalRole,
		// Token: 0x04001121 RID: 4385
		[EnumMember(Value = "valueUndefined")]
		ValueUndefined
	}
}
