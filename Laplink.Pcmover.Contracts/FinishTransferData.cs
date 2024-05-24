using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200003D RID: 61
	public class FinishTransferData
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00002FCE File Offset: 0x000011CE
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00002FD6 File Offset: 0x000011D6
		public bool Succeeded { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00002FDF File Offset: 0x000011DF
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00002FE7 File Offset: 0x000011E7
		public string FailureReason { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00002FF0 File Offset: 0x000011F0
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00002FF8 File Offset: 0x000011F8
		public bool Rebooting { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00003001 File Offset: 0x00001201
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00003009 File Offset: 0x00001209
		public bool LaunchExe { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00003012 File Offset: 0x00001212
		// (set) Token: 0x0600016D RID: 365 RVA: 0x0000301A File Offset: 0x0000121A
		public string ExeFileName { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00003023 File Offset: 0x00001223
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0000302B File Offset: 0x0000122B
		public string Arguments { get; set; }
	}
}
