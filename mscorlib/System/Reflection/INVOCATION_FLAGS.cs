﻿using System;

namespace System.Reflection
{
	// Token: 0x02000604 RID: 1540
	[Flags]
	internal enum INVOCATION_FLAGS : uint
	{
		// Token: 0x04001D7A RID: 7546
		INVOCATION_FLAGS_UNKNOWN = 0U,
		// Token: 0x04001D7B RID: 7547
		INVOCATION_FLAGS_INITIALIZED = 1U,
		// Token: 0x04001D7C RID: 7548
		INVOCATION_FLAGS_NO_INVOKE = 2U,
		// Token: 0x04001D7D RID: 7549
		INVOCATION_FLAGS_NEED_SECURITY = 4U,
		// Token: 0x04001D7E RID: 7550
		INVOCATION_FLAGS_NO_CTOR_INVOKE = 8U,
		// Token: 0x04001D7F RID: 7551
		INVOCATION_FLAGS_IS_CTOR = 16U,
		// Token: 0x04001D80 RID: 7552
		INVOCATION_FLAGS_RISKY_METHOD = 32U,
		// Token: 0x04001D81 RID: 7553
		INVOCATION_FLAGS_NON_W8P_FX_API = 64U,
		// Token: 0x04001D82 RID: 7554
		INVOCATION_FLAGS_IS_DELEGATE_CTOR = 128U,
		// Token: 0x04001D83 RID: 7555
		INVOCATION_FLAGS_CONTAINS_STACK_POINTERS = 256U,
		// Token: 0x04001D84 RID: 7556
		INVOCATION_FLAGS_SPECIAL_FIELD = 16U,
		// Token: 0x04001D85 RID: 7557
		INVOCATION_FLAGS_FIELD_SPECIAL_CAST = 32U,
		// Token: 0x04001D86 RID: 7558
		INVOCATION_FLAGS_CONSTRUCTOR_INVOKE = 268435456U
	}
}
