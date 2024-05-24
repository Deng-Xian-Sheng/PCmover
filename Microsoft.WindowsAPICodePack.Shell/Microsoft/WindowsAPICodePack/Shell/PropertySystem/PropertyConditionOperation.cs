using System;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000D9 RID: 217
	public enum PropertyConditionOperation
	{
		// Token: 0x040003E9 RID: 1001
		Implicit,
		// Token: 0x040003EA RID: 1002
		Equal,
		// Token: 0x040003EB RID: 1003
		NotEqual,
		// Token: 0x040003EC RID: 1004
		LessThan,
		// Token: 0x040003ED RID: 1005
		GreaterThan,
		// Token: 0x040003EE RID: 1006
		LessThanOrEqual,
		// Token: 0x040003EF RID: 1007
		GreaterThanOrEqual,
		// Token: 0x040003F0 RID: 1008
		ValueStartsWith,
		// Token: 0x040003F1 RID: 1009
		ValueEndsWith,
		// Token: 0x040003F2 RID: 1010
		ValueContains,
		// Token: 0x040003F3 RID: 1011
		ValueNotContains,
		// Token: 0x040003F4 RID: 1012
		DOSWildCards,
		// Token: 0x040003F5 RID: 1013
		WordEqual,
		// Token: 0x040003F6 RID: 1014
		WordStartsWith,
		// Token: 0x040003F7 RID: 1015
		ApplicationSpecific
	}
}
