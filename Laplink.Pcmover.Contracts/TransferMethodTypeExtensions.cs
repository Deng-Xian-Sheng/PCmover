using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200007C RID: 124
	public static class TransferMethodTypeExtensions
	{
		// Token: 0x06000347 RID: 839 RVA: 0x00003FDF File Offset: 0x000021DF
		public static bool IsNetwork(this TransferMethodType tme)
		{
			return tme == TransferMethodType.Network || tme == TransferMethodType.SSL;
		}
	}
}
