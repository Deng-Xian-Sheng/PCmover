using System;
using System.Runtime.ConstrainedExecution;

namespace System.Runtime.ExceptionServices
{
	// Token: 0x020007A8 RID: 1960
	public class FirstChanceExceptionEventArgs : EventArgs
	{
		// Token: 0x060054FC RID: 21756 RVA: 0x0012E15B File Offset: 0x0012C35B
		public FirstChanceExceptionEventArgs(Exception exception)
		{
			this.m_Exception = exception;
		}

		// Token: 0x17000DEF RID: 3567
		// (get) Token: 0x060054FD RID: 21757 RVA: 0x0012E16A File Offset: 0x0012C36A
		public Exception Exception
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.m_Exception;
			}
		}

		// Token: 0x04002718 RID: 10008
		private Exception m_Exception;
	}
}
