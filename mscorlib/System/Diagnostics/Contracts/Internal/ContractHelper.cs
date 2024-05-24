using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System.Diagnostics.Contracts.Internal
{
	// Token: 0x02000418 RID: 1048
	[Obsolete("Use the ContractHelper class in the System.Runtime.CompilerServices namespace instead.")]
	[__DynamicallyInvokable]
	public static class ContractHelper
	{
		// Token: 0x06003427 RID: 13351 RVA: 0x000C6C4D File Offset: 0x000C4E4D
		[DebuggerNonUserCode]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public static string RaiseContractFailedEvent(ContractFailureKind failureKind, string userMessage, string conditionText, Exception innerException)
		{
			return ContractHelper.RaiseContractFailedEvent(failureKind, userMessage, conditionText, innerException);
		}

		// Token: 0x06003428 RID: 13352 RVA: 0x000C6C58 File Offset: 0x000C4E58
		[DebuggerNonUserCode]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void TriggerFailure(ContractFailureKind kind, string displayMessage, string userMessage, string conditionText, Exception innerException)
		{
			ContractHelper.TriggerFailure(kind, displayMessage, userMessage, conditionText, innerException);
		}
	}
}
