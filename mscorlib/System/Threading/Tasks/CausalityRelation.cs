using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200057D RID: 1405
	internal enum CausalityRelation
	{
		// Token: 0x04001B7C RID: 7036
		AssignDelegate,
		// Token: 0x04001B7D RID: 7037
		Join,
		// Token: 0x04001B7E RID: 7038
		Choice,
		// Token: 0x04001B7F RID: 7039
		Cancel,
		// Token: 0x04001B80 RID: 7040
		Error
	}
}
