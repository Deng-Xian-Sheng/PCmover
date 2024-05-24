using System;

namespace System.Diagnostics
{
	// Token: 0x020003E1 RID: 993
	[Serializable]
	internal abstract class AssertFilter
	{
		// Token: 0x060032F0 RID: 13040
		public abstract AssertFilters AssertFailure(string condition, string message, StackTrace location, StackTrace.TraceFormat stackTraceFormat, string windowTitle);
	}
}
