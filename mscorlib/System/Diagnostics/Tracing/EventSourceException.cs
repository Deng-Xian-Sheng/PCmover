using System;
using System.Runtime.Serialization;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000432 RID: 1074
	[__DynamicallyInvokable]
	[Serializable]
	public class EventSourceException : Exception
	{
		// Token: 0x06003587 RID: 13703 RVA: 0x000D10B4 File Offset: 0x000CF2B4
		[__DynamicallyInvokable]
		public EventSourceException() : base(Environment.GetResourceString("EventSource_ListenerWriteFailure"))
		{
		}

		// Token: 0x06003588 RID: 13704 RVA: 0x000D10C6 File Offset: 0x000CF2C6
		[__DynamicallyInvokable]
		public EventSourceException(string message) : base(message)
		{
		}

		// Token: 0x06003589 RID: 13705 RVA: 0x000D10CF File Offset: 0x000CF2CF
		[__DynamicallyInvokable]
		public EventSourceException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600358A RID: 13706 RVA: 0x000D10D9 File Offset: 0x000CF2D9
		protected EventSourceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600358B RID: 13707 RVA: 0x000D10E3 File Offset: 0x000CF2E3
		internal EventSourceException(Exception innerException) : base(Environment.GetResourceString("EventSource_ListenerWriteFailure"), innerException)
		{
		}
	}
}
