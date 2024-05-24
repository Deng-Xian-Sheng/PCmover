using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000051 RID: 81
	public class PcmoverStatusInfo
	{
		// Token: 0x06000233 RID: 563 RVA: 0x00002050 File Offset: 0x00000250
		public PcmoverStatusInfo()
		{
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00003333 File Offset: 0x00001533
		public PcmoverStatusInfo(PcmoverState state, bool hasController, int numCallbacksPending)
		{
			this.State = state;
			this.HasController = hasController;
			this.NumCallbacksPending = numCallbacksPending;
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00003350 File Offset: 0x00001550
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00003358 File Offset: 0x00001558
		public PcmoverState State { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00003361 File Offset: 0x00001561
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00003369 File Offset: 0x00001569
		public bool HasController { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00003372 File Offset: 0x00001572
		// (set) Token: 0x0600023A RID: 570 RVA: 0x0000337A File Offset: 0x0000157A
		public int NumCallbacksPending { get; set; }

		// Token: 0x0600023B RID: 571 RVA: 0x00003383 File Offset: 0x00001583
		public override string ToString()
		{
			return string.Format("State: {0}, HasController: {1}, Callbacks: {2}", this.State, this.HasController, this.NumCallbacksPending);
		}
	}
}
