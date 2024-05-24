using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000E5 RID: 229
	public static class ParentProcessMonitor
	{
		// Token: 0x060006E5 RID: 1765 RVA: 0x0000B344 File Offset: 0x00009544
		public static void StartMonitorTask(int parentProcessId)
		{
			Task.Factory.StartNew(delegate()
			{
				ParentProcessMonitor.AwaitParentProcessExit(parentProcessId);
			}, TaskCreationOptions.LongRunning);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0000B378 File Offset: 0x00009578
		private static void AwaitParentProcessExit(int parentProcessId)
		{
			ParentProcessMonitor.<AwaitParentProcessExit>d__1 <AwaitParentProcessExit>d__;
			<AwaitParentProcessExit>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<AwaitParentProcessExit>d__.parentProcessId = parentProcessId;
			<AwaitParentProcessExit>d__.<>1__state = -1;
			<AwaitParentProcessExit>d__.<>t__builder.Start<ParentProcessMonitor.<AwaitParentProcessExit>d__1>(ref <AwaitParentProcessExit>d__);
		}
	}
}
