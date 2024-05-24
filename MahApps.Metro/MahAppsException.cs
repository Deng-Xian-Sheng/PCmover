using System;
using System.Runtime.Serialization;

namespace MahApps.Metro
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class MahAppsException : Exception
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020C6 File Offset: 0x000002C6
		public MahAppsException()
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020CE File Offset: 0x000002CE
		public MahAppsException(string message) : base(message)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020D7 File Offset: 0x000002D7
		public MahAppsException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020E1 File Offset: 0x000002E1
		protected MahAppsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
