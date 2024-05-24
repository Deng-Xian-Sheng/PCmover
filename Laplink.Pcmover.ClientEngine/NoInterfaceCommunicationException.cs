using System;
using System.ServiceModel;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000008 RID: 8
	public class NoInterfaceCommunicationException : CommunicationException
	{
		// Token: 0x06000049 RID: 73 RVA: 0x0000280B File Offset: 0x00000A0B
		public NoInterfaceCommunicationException()
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002813 File Offset: 0x00000A13
		public NoInterfaceCommunicationException(string message) : base(message)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000281C File Offset: 0x00000A1C
		public NoInterfaceCommunicationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
