using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000073 RID: 115
	public class TransferActivityParameters
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00003E79 File Offset: 0x00002079
		// (set) Token: 0x0600031E RID: 798 RVA: 0x00003E81 File Offset: 0x00002081
		public int TransferMethodHandle { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00003E8A File Offset: 0x0000208A
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00003E92 File Offset: 0x00002092
		public int FillTaskHandle { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00003E9B File Offset: 0x0000209B
		// (set) Token: 0x06000322 RID: 802 RVA: 0x00003EA3 File Offset: 0x000020A3
		public bool AllowUndo { get; set; }

		// Token: 0x06000323 RID: 803 RVA: 0x00003EAC File Offset: 0x000020AC
		public TransferActivityParameters()
		{
			this.AllowUndo = true;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00003EBB File Offset: 0x000020BB
		public TransferActivityParameters(int transferMethodHandle, int fillTaskHandle, bool allowUndo)
		{
			this.TransferMethodHandle = transferMethodHandle;
			this.FillTaskHandle = fillTaskHandle;
			this.AllowUndo = allowUndo;
		}
	}
}
