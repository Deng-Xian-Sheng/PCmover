using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000610 RID: 1552
	[Flags]
	[ComVisible(true)]
	public enum ExceptionHandlingClauseOptions
	{
		// Token: 0x04001DC3 RID: 7619
		Clause = 0,
		// Token: 0x04001DC4 RID: 7620
		Filter = 1,
		// Token: 0x04001DC5 RID: 7621
		Finally = 2,
		// Token: 0x04001DC6 RID: 7622
		Fault = 4
	}
}
