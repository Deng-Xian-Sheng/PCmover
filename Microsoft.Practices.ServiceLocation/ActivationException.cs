using System;

namespace Microsoft.Practices.ServiceLocation
{
	// Token: 0x02000002 RID: 2
	public class ActivationException : Exception
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		public ActivationException()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020D8 File Offset: 0x000002D8
		public ActivationException(string message) : base(message)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020E1 File Offset: 0x000002E1
		public ActivationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
