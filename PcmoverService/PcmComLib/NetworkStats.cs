using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x020000B2 RID: 178
	[CompilerGenerated]
	[Guid("A07E4C54-E508-44AB-B01B-87A4AA9E5BD3")]
	[TypeIdentifier("014D1DE2-7A0B-457C-8B9C-A20AD2BF0977", "PcmComLib.NetworkStats")]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct NetworkStats
	{
		// Token: 0x0400015C RID: 348
		public ulong totalBytes;

		// Token: 0x0400015D RID: 349
		public ulong TxTries;

		// Token: 0x0400015E RID: 350
		public ulong TxPackets;

		// Token: 0x0400015F RID: 351
		public ulong RxTries;

		// Token: 0x04000160 RID: 352
		public ulong RxPackets;

		// Token: 0x04000161 RID: 353
		public ulong TotalRxErrors;

		// Token: 0x04000162 RID: 354
		public uint TimeSinceReceive;

		// Token: 0x04000163 RID: 355
		public int ieee80211;

		// Token: 0x04000164 RID: 356
		public int hardwired;

		// Token: 0x04000165 RID: 357
		public __MIDL___MIDL_itf_PcmCom_0000_0000_0008 USBState;
	}
}
