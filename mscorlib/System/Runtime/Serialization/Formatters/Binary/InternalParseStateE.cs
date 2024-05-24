using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000772 RID: 1906
	[Serializable]
	internal enum InternalParseStateE
	{
		// Token: 0x04002535 RID: 9525
		Initial,
		// Token: 0x04002536 RID: 9526
		Object,
		// Token: 0x04002537 RID: 9527
		Member,
		// Token: 0x04002538 RID: 9528
		MemberChild
	}
}
