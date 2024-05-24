using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000578 RID: 1400
	[__DynamicallyInvokable]
	public class UnobservedTaskExceptionEventArgs : EventArgs
	{
		// Token: 0x0600421A RID: 16922 RVA: 0x000F647B File Offset: 0x000F467B
		[__DynamicallyInvokable]
		public UnobservedTaskExceptionEventArgs(AggregateException exception)
		{
			this.m_exception = exception;
		}

		// Token: 0x0600421B RID: 16923 RVA: 0x000F648A File Offset: 0x000F468A
		[__DynamicallyInvokable]
		public void SetObserved()
		{
			this.m_observed = true;
		}

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x0600421C RID: 16924 RVA: 0x000F6493 File Offset: 0x000F4693
		[__DynamicallyInvokable]
		public bool Observed
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_observed;
			}
		}

		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x0600421D RID: 16925 RVA: 0x000F649B File Offset: 0x000F469B
		[__DynamicallyInvokable]
		public AggregateException Exception
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_exception;
			}
		}

		// Token: 0x04001B6E RID: 7022
		private AggregateException m_exception;

		// Token: 0x04001B6F RID: 7023
		internal bool m_observed;
	}
}
