using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004F9 RID: 1273
	internal class HostExecutionContextSwitcher
	{
		// Token: 0x06003C36 RID: 15414 RVA: 0x000E3E84 File Offset: 0x000E2084
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Undo(object switcherObject)
		{
			if (switcherObject == null)
			{
				return;
			}
			HostExecutionContextManager currentHostExecutionContextManager = HostExecutionContextManager.GetCurrentHostExecutionContextManager();
			if (currentHostExecutionContextManager != null)
			{
				currentHostExecutionContextManager.Revert(switcherObject);
			}
		}

		// Token: 0x04001991 RID: 6545
		internal ExecutionContext executionContext;

		// Token: 0x04001992 RID: 6546
		internal HostExecutionContext previousHostContext;

		// Token: 0x04001993 RID: 6547
		internal HostExecutionContext currentHostContext;
	}
}
