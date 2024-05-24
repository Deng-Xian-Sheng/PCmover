using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008A0 RID: 2208
	[__DynamicallyInvokable]
	public static class ContractHelper
	{
		// Token: 0x06005D68 RID: 23912 RVA: 0x00148F00 File Offset: 0x00147100
		[DebuggerNonUserCode]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public static string RaiseContractFailedEvent(ContractFailureKind failureKind, string userMessage, string conditionText, Exception innerException)
		{
			string result = "Contract failed";
			ContractHelper.RaiseContractFailedEventImplementation(failureKind, userMessage, conditionText, innerException, ref result);
			return result;
		}

		// Token: 0x06005D69 RID: 23913 RVA: 0x00148F1F File Offset: 0x0014711F
		[DebuggerNonUserCode]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void TriggerFailure(ContractFailureKind kind, string displayMessage, string userMessage, string conditionText, Exception innerException)
		{
			ContractHelper.TriggerFailureImplementation(kind, displayMessage, userMessage, conditionText, innerException);
		}

		// Token: 0x06005D6A RID: 23914 RVA: 0x00148F2C File Offset: 0x0014712C
		[DebuggerNonUserCode]
		[SecuritySafeCritical]
		private static void RaiseContractFailedEventImplementation(ContractFailureKind failureKind, string userMessage, string conditionText, Exception innerException, ref string resultFailureMessage)
		{
			if (failureKind < ContractFailureKind.Precondition || failureKind > ContractFailureKind.Assume)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					failureKind
				}), "failureKind");
			}
			string text = "contract failed.";
			ContractFailedEventArgs contractFailedEventArgs = null;
			RuntimeHelpers.PrepareConstrainedRegions();
			string text2;
			try
			{
				text = ContractHelper.GetDisplayMessage(failureKind, userMessage, conditionText);
				EventHandler<ContractFailedEventArgs> eventHandler = ContractHelper.contractFailedEvent;
				if (eventHandler != null)
				{
					contractFailedEventArgs = new ContractFailedEventArgs(failureKind, text, conditionText, innerException);
					foreach (EventHandler<ContractFailedEventArgs> eventHandler2 in eventHandler.GetInvocationList())
					{
						try
						{
							eventHandler2(null, contractFailedEventArgs);
						}
						catch (Exception thrownDuringHandler)
						{
							contractFailedEventArgs.thrownDuringHandler = thrownDuringHandler;
							contractFailedEventArgs.SetUnwind();
						}
					}
					if (contractFailedEventArgs.Unwind)
					{
						if (Environment.IsCLRHosted)
						{
							ContractHelper.TriggerCodeContractEscalationPolicy(failureKind, text, conditionText, innerException);
						}
						if (innerException == null)
						{
							innerException = contractFailedEventArgs.thrownDuringHandler;
						}
						throw new ContractException(failureKind, text, userMessage, conditionText, innerException);
					}
				}
			}
			finally
			{
				if (contractFailedEventArgs != null && contractFailedEventArgs.Handled)
				{
					text2 = null;
				}
				else
				{
					text2 = text;
				}
			}
			resultFailureMessage = text2;
		}

		// Token: 0x06005D6B RID: 23915 RVA: 0x00149038 File Offset: 0x00147238
		[DebuggerNonUserCode]
		[SecuritySafeCritical]
		private static void TriggerFailureImplementation(ContractFailureKind kind, string displayMessage, string userMessage, string conditionText, Exception innerException)
		{
			if (Environment.IsCLRHosted)
			{
				ContractHelper.TriggerCodeContractEscalationPolicy(kind, displayMessage, conditionText, innerException);
				throw new ContractException(kind, displayMessage, userMessage, conditionText, innerException);
			}
			if (!Environment.UserInteractive)
			{
				throw new ContractException(kind, displayMessage, userMessage, conditionText, innerException);
			}
			string resourceString = Environment.GetResourceString(ContractHelper.GetResourceNameForFailure(kind));
			Assert.Fail(conditionText, displayMessage, resourceString, -2146233022, StackTrace.TraceFormat.Normal, 2);
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06005D6C RID: 23916 RVA: 0x00149090 File Offset: 0x00147290
		// (remove) Token: 0x06005D6D RID: 23917 RVA: 0x001490E8 File Offset: 0x001472E8
		internal static event EventHandler<ContractFailedEventArgs> InternalContractFailed
		{
			[SecurityCritical]
			add
			{
				RuntimeHelpers.PrepareContractedDelegate(value);
				object obj = ContractHelper.lockObject;
				lock (obj)
				{
					ContractHelper.contractFailedEvent = (EventHandler<ContractFailedEventArgs>)Delegate.Combine(ContractHelper.contractFailedEvent, value);
				}
			}
			[SecurityCritical]
			remove
			{
				object obj = ContractHelper.lockObject;
				lock (obj)
				{
					ContractHelper.contractFailedEvent = (EventHandler<ContractFailedEventArgs>)Delegate.Remove(ContractHelper.contractFailedEvent, value);
				}
			}
		}

		// Token: 0x06005D6E RID: 23918 RVA: 0x0014913C File Offset: 0x0014733C
		private static string GetResourceNameForFailure(ContractFailureKind failureKind)
		{
			string result;
			switch (failureKind)
			{
			case ContractFailureKind.Precondition:
				result = "PreconditionFailed";
				break;
			case ContractFailureKind.Postcondition:
				result = "PostconditionFailed";
				break;
			case ContractFailureKind.PostconditionOnException:
				result = "PostconditionOnExceptionFailed";
				break;
			case ContractFailureKind.Invariant:
				result = "InvariantFailed";
				break;
			case ContractFailureKind.Assert:
				result = "AssertionFailed";
				break;
			case ContractFailureKind.Assume:
				result = "AssumptionFailed";
				break;
			default:
				Contract.Assume(false, "Unreachable code");
				result = "AssumptionFailed";
				break;
			}
			return result;
		}

		// Token: 0x06005D6F RID: 23919 RVA: 0x001491B0 File Offset: 0x001473B0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		private static string GetDisplayMessage(ContractFailureKind failureKind, string userMessage, string conditionText)
		{
			string text = ContractHelper.GetResourceNameForFailure(failureKind);
			string resourceString;
			if (!string.IsNullOrEmpty(conditionText))
			{
				text += "_Cnd";
				resourceString = Environment.GetResourceString(text, new object[]
				{
					conditionText
				});
			}
			else
			{
				resourceString = Environment.GetResourceString(text);
			}
			if (!string.IsNullOrEmpty(userMessage))
			{
				return resourceString + "  " + userMessage;
			}
			return resourceString;
		}

		// Token: 0x06005D70 RID: 23920 RVA: 0x00149208 File Offset: 0x00147408
		[SecuritySafeCritical]
		[DebuggerNonUserCode]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static void TriggerCodeContractEscalationPolicy(ContractFailureKind failureKind, string message, string conditionText, Exception innerException)
		{
			string exceptionAsString = null;
			if (innerException != null)
			{
				exceptionAsString = innerException.ToString();
			}
			Environment.TriggerCodeContractFailure(failureKind, message, conditionText, exceptionAsString);
		}

		// Token: 0x04002A05 RID: 10757
		private static volatile EventHandler<ContractFailedEventArgs> contractFailedEvent;

		// Token: 0x04002A06 RID: 10758
		private static readonly object lockObject = new object();

		// Token: 0x04002A07 RID: 10759
		internal const int COR_E_CODECONTRACTFAILED = -2146233022;
	}
}
