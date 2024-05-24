using System;
using System.Runtime.Serialization;

namespace System.Threading.Tasks
{
	// Token: 0x02000573 RID: 1395
	[__DynamicallyInvokable]
	[Serializable]
	public class TaskSchedulerException : Exception
	{
		// Token: 0x0600418C RID: 16780 RVA: 0x000F4C66 File Offset: 0x000F2E66
		[__DynamicallyInvokable]
		public TaskSchedulerException() : base(Environment.GetResourceString("TaskSchedulerException_ctor_DefaultMessage"))
		{
		}

		// Token: 0x0600418D RID: 16781 RVA: 0x000F4C78 File Offset: 0x000F2E78
		[__DynamicallyInvokable]
		public TaskSchedulerException(string message) : base(message)
		{
		}

		// Token: 0x0600418E RID: 16782 RVA: 0x000F4C81 File Offset: 0x000F2E81
		[__DynamicallyInvokable]
		public TaskSchedulerException(Exception innerException) : base(Environment.GetResourceString("TaskSchedulerException_ctor_DefaultMessage"), innerException)
		{
		}

		// Token: 0x0600418F RID: 16783 RVA: 0x000F4C94 File Offset: 0x000F2E94
		[__DynamicallyInvokable]
		public TaskSchedulerException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06004190 RID: 16784 RVA: 0x000F4C9E File Offset: 0x000F2E9E
		protected TaskSchedulerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
