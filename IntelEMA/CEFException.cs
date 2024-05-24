using System;

namespace IntelEMA
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class CEFException : Exception
	{
		// Token: 0x0600000A RID: 10 RVA: 0x0000215A File Offset: 0x0000035A
		public CEFException()
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002162 File Offset: 0x00000362
		public CEFException(string message) : base(message)
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000216B File Offset: 0x0000036B
		public CEFException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
