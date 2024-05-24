using System;
using System.Security;

namespace System.Diagnostics
{
	// Token: 0x020003E2 RID: 994
	internal class DefaultFilter : AssertFilter
	{
		// Token: 0x060032F2 RID: 13042 RVA: 0x000C4A37 File Offset: 0x000C2C37
		internal DefaultFilter()
		{
		}

		// Token: 0x060032F3 RID: 13043 RVA: 0x000C4A3F File Offset: 0x000C2C3F
		[SecuritySafeCritical]
		public override AssertFilters AssertFailure(string condition, string message, StackTrace location, StackTrace.TraceFormat stackTraceFormat, string windowTitle)
		{
			return (AssertFilters)Assert.ShowDefaultAssertDialog(condition, message, location.ToString(stackTraceFormat), windowTitle);
		}
	}
}
