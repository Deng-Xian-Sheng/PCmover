using System;
using Laplink.Service.Infrastructure;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000017 RID: 23
	public class PcmoverObjectHandleManager<T> : HandleManager<T> where T : IPCmoverObject
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00004138 File Offset: 0x00002338
		public PcmoverObjectHandleManager(int startHandle) : base(startHandle, new PcmoverObjectComparer<T>())
		{
		}
	}
}
