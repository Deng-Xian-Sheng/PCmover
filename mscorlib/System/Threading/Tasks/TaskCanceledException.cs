using System;
using System.Runtime.Serialization;

namespace System.Threading.Tasks
{
	// Token: 0x02000572 RID: 1394
	[__DynamicallyInvokable]
	[Serializable]
	public class TaskCanceledException : OperationCanceledException
	{
		// Token: 0x06004186 RID: 16774 RVA: 0x000F4BF4 File Offset: 0x000F2DF4
		[__DynamicallyInvokable]
		public TaskCanceledException() : base(Environment.GetResourceString("TaskCanceledException_ctor_DefaultMessage"))
		{
		}

		// Token: 0x06004187 RID: 16775 RVA: 0x000F4C06 File Offset: 0x000F2E06
		[__DynamicallyInvokable]
		public TaskCanceledException(string message) : base(message)
		{
		}

		// Token: 0x06004188 RID: 16776 RVA: 0x000F4C0F File Offset: 0x000F2E0F
		[__DynamicallyInvokable]
		public TaskCanceledException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06004189 RID: 16777 RVA: 0x000F4C1C File Offset: 0x000F2E1C
		[__DynamicallyInvokable]
		public TaskCanceledException(Task task) : base(Environment.GetResourceString("TaskCanceledException_ctor_DefaultMessage"), (task != null) ? task.CancellationToken : default(CancellationToken))
		{
			this.m_canceledTask = task;
		}

		// Token: 0x0600418A RID: 16778 RVA: 0x000F4C54 File Offset: 0x000F2E54
		protected TaskCanceledException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x0600418B RID: 16779 RVA: 0x000F4C5E File Offset: 0x000F2E5E
		[__DynamicallyInvokable]
		public Task Task
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_canceledTask;
			}
		}

		// Token: 0x04001B5A RID: 7002
		[NonSerialized]
		private Task m_canceledTask;
	}
}
