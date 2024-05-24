using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Diagnostics
{
	// Token: 0x020003E0 RID: 992
	internal static class Assert
	{
		// Token: 0x060032E9 RID: 13033 RVA: 0x000C497D File Offset: 0x000C2B7D
		internal static void Check(bool condition, string conditionString, string message)
		{
			if (!condition)
			{
				Assert.Fail(conditionString, message, null, -2146232797);
			}
		}

		// Token: 0x060032EA RID: 13034 RVA: 0x000C498F File Offset: 0x000C2B8F
		internal static void Check(bool condition, string conditionString, string message, int exitCode)
		{
			if (!condition)
			{
				Assert.Fail(conditionString, message, null, exitCode);
			}
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x000C499D File Offset: 0x000C2B9D
		internal static void Fail(string conditionString, string message)
		{
			Assert.Fail(conditionString, message, null, -2146232797);
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x000C49AC File Offset: 0x000C2BAC
		internal static void Fail(string conditionString, string message, string windowTitle, int exitCode)
		{
			Assert.Fail(conditionString, message, windowTitle, exitCode, StackTrace.TraceFormat.Normal, 0);
		}

		// Token: 0x060032ED RID: 13037 RVA: 0x000C49B9 File Offset: 0x000C2BB9
		internal static void Fail(string conditionString, string message, int exitCode, StackTrace.TraceFormat stackTraceFormat)
		{
			Assert.Fail(conditionString, message, null, exitCode, stackTraceFormat, 0);
		}

		// Token: 0x060032EE RID: 13038 RVA: 0x000C49C8 File Offset: 0x000C2BC8
		[SecuritySafeCritical]
		internal static void Fail(string conditionString, string message, string windowTitle, int exitCode, StackTrace.TraceFormat stackTraceFormat, int numStackFramesToSkip)
		{
			StackTrace location = new StackTrace(numStackFramesToSkip, true);
			AssertFilters assertFilters = Assert.Filter.AssertFailure(conditionString, message, location, stackTraceFormat, windowTitle);
			if (assertFilters == AssertFilters.FailDebug)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					return;
				}
				if (!Debugger.Launch())
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DebuggerLaunchFailed"));
				}
			}
			else if (assertFilters == AssertFilters.FailTerminate)
			{
				if (Debugger.IsAttached)
				{
					Environment._Exit(exitCode);
					return;
				}
				Environment.FailFast(message, (uint)exitCode);
			}
		}

		// Token: 0x060032EF RID: 13039
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int ShowDefaultAssertDialog(string conditionString, string message, string stackTrace, string windowTitle);

		// Token: 0x04001691 RID: 5777
		internal const int COR_E_FAILFAST = -2146232797;

		// Token: 0x04001692 RID: 5778
		private static AssertFilter Filter = new DefaultFilter();
	}
}
