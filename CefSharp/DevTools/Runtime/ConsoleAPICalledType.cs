using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000142 RID: 322
	public enum ConsoleAPICalledType
	{
		// Token: 0x0400053C RID: 1340
		[EnumMember(Value = "log")]
		Log,
		// Token: 0x0400053D RID: 1341
		[EnumMember(Value = "debug")]
		Debug,
		// Token: 0x0400053E RID: 1342
		[EnumMember(Value = "info")]
		Info,
		// Token: 0x0400053F RID: 1343
		[EnumMember(Value = "error")]
		Error,
		// Token: 0x04000540 RID: 1344
		[EnumMember(Value = "warning")]
		Warning,
		// Token: 0x04000541 RID: 1345
		[EnumMember(Value = "dir")]
		Dir,
		// Token: 0x04000542 RID: 1346
		[EnumMember(Value = "dirxml")]
		Dirxml,
		// Token: 0x04000543 RID: 1347
		[EnumMember(Value = "table")]
		Table,
		// Token: 0x04000544 RID: 1348
		[EnumMember(Value = "trace")]
		Trace,
		// Token: 0x04000545 RID: 1349
		[EnumMember(Value = "clear")]
		Clear,
		// Token: 0x04000546 RID: 1350
		[EnumMember(Value = "startGroup")]
		StartGroup,
		// Token: 0x04000547 RID: 1351
		[EnumMember(Value = "startGroupCollapsed")]
		StartGroupCollapsed,
		// Token: 0x04000548 RID: 1352
		[EnumMember(Value = "endGroup")]
		EndGroup,
		// Token: 0x04000549 RID: 1353
		[EnumMember(Value = "assert")]
		Assert,
		// Token: 0x0400054A RID: 1354
		[EnumMember(Value = "profile")]
		Profile,
		// Token: 0x0400054B RID: 1355
		[EnumMember(Value = "profileEnd")]
		ProfileEnd,
		// Token: 0x0400054C RID: 1356
		[EnumMember(Value = "count")]
		Count,
		// Token: 0x0400054D RID: 1357
		[EnumMember(Value = "timeEnd")]
		TimeEnd
	}
}
