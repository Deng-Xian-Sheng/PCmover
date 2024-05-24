using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000416 RID: 1046
	[__DynamicallyInvokable]
	public sealed class ContractFailedEventArgs : EventArgs
	{
		// Token: 0x06003416 RID: 13334 RVA: 0x000C6AFC File Offset: 0x000C4CFC
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public ContractFailedEventArgs(ContractFailureKind failureKind, string message, string condition, Exception originalException)
		{
			this._failureKind = failureKind;
			this._message = message;
			this._condition = condition;
			this._originalException = originalException;
		}

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06003417 RID: 13335 RVA: 0x000C6B21 File Offset: 0x000C4D21
		[__DynamicallyInvokable]
		public string Message
		{
			[__DynamicallyInvokable]
			get
			{
				return this._message;
			}
		}

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x06003418 RID: 13336 RVA: 0x000C6B29 File Offset: 0x000C4D29
		[__DynamicallyInvokable]
		public string Condition
		{
			[__DynamicallyInvokable]
			get
			{
				return this._condition;
			}
		}

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06003419 RID: 13337 RVA: 0x000C6B31 File Offset: 0x000C4D31
		[__DynamicallyInvokable]
		public ContractFailureKind FailureKind
		{
			[__DynamicallyInvokable]
			get
			{
				return this._failureKind;
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x0600341A RID: 13338 RVA: 0x000C6B39 File Offset: 0x000C4D39
		[__DynamicallyInvokable]
		public Exception OriginalException
		{
			[__DynamicallyInvokable]
			get
			{
				return this._originalException;
			}
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x0600341B RID: 13339 RVA: 0x000C6B41 File Offset: 0x000C4D41
		[__DynamicallyInvokable]
		public bool Handled
		{
			[__DynamicallyInvokable]
			get
			{
				return this._handled;
			}
		}

		// Token: 0x0600341C RID: 13340 RVA: 0x000C6B49 File Offset: 0x000C4D49
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void SetHandled()
		{
			this._handled = true;
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x0600341D RID: 13341 RVA: 0x000C6B52 File Offset: 0x000C4D52
		[__DynamicallyInvokable]
		public bool Unwind
		{
			[__DynamicallyInvokable]
			get
			{
				return this._unwind;
			}
		}

		// Token: 0x0600341E RID: 13342 RVA: 0x000C6B5A File Offset: 0x000C4D5A
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void SetUnwind()
		{
			this._unwind = true;
		}

		// Token: 0x04001710 RID: 5904
		private ContractFailureKind _failureKind;

		// Token: 0x04001711 RID: 5905
		private string _message;

		// Token: 0x04001712 RID: 5906
		private string _condition;

		// Token: 0x04001713 RID: 5907
		private Exception _originalException;

		// Token: 0x04001714 RID: 5908
		private bool _handled;

		// Token: 0x04001715 RID: 5909
		private bool _unwind;

		// Token: 0x04001716 RID: 5910
		internal Exception thrownDuringHandler;
	}
}
