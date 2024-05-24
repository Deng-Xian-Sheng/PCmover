using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000049 RID: 73
	public class MachineData
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00003041 File Offset: 0x00001241
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00003049 File Offset: 0x00001249
		public int Handle { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00003052 File Offset: 0x00001252
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x0000305A File Offset: 0x0000125A
		public MachineType Type { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00003063 File Offset: 0x00001263
		public bool IsThisMachine
		{
			get
			{
				return this.Type == MachineType.This;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000306E File Offset: 0x0000126E
		public bool IsLive
		{
			get
			{
				return this.Type == MachineType.This || this.Type == MachineType.Image;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00003084 File Offset: 0x00001284
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x0000308C File Offset: 0x0000128C
		public string NetName { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00003095 File Offset: 0x00001295
		// (set) Token: 0x060001FB RID: 507 RVA: 0x0000309D File Offset: 0x0000129D
		public string FriendlyName { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001FC RID: 508 RVA: 0x000030A6 File Offset: 0x000012A6
		// (set) Token: 0x060001FD RID: 509 RVA: 0x000030AE File Offset: 0x000012AE
		public string MachineId { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001FE RID: 510 RVA: 0x000030B7 File Offset: 0x000012B7
		// (set) Token: 0x060001FF RID: 511 RVA: 0x000030BF File Offset: 0x000012BF
		public string Manufacturer { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000200 RID: 512 RVA: 0x000030C8 File Offset: 0x000012C8
		// (set) Token: 0x06000201 RID: 513 RVA: 0x000030D0 File Offset: 0x000012D0
		public WindowsVersionData WindowsVersion { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000030D9 File Offset: 0x000012D9
		// (set) Token: 0x06000203 RID: 515 RVA: 0x000030E1 File Offset: 0x000012E1
		public string JoinedDomain { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000204 RID: 516 RVA: 0x000030EA File Offset: 0x000012EA
		// (set) Token: 0x06000205 RID: 517 RVA: 0x000030F2 File Offset: 0x000012F2
		public bool IsJoinedToAzureAd { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000206 RID: 518 RVA: 0x000030FB File Offset: 0x000012FB
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00003103 File Offset: 0x00001303
		public bool IsEngineRunningAsAdmin { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000310C File Offset: 0x0000130C
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00003114 File Offset: 0x00001314
		public DateTime Age { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000311D File Offset: 0x0000131D
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00003125 File Offset: 0x00001325
		public uint OemId { get; set; }

		// Token: 0x0600020C RID: 524 RVA: 0x0000312E File Offset: 0x0000132E
		public MachineData Clone()
		{
			return (MachineData)base.MemberwiseClone();
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000313C File Offset: 0x0000133C
		public override string ToString()
		{
			string text = string.Format("Handle: {0}\nType: {1}\nNetName={2}\nFriendlyName={3}", new object[]
			{
				this.Handle,
				this.Type,
				this.NetName,
				this.FriendlyName
			});
			text = string.Concat(new string[]
			{
				text,
				"\nMachineId: ",
				this.MachineId,
				"\nManufacturer: ",
				this.Manufacturer
			});
			text += string.Format("\nJoinedDomain: {0}\nIsJoinedToAzureAd: {1}\nIsEngineRunningAsAdmin: {2}", this.JoinedDomain, this.IsJoinedToAzureAd, this.IsEngineRunningAsAdmin);
			text += string.Format("\nAge: {0}\nOemId: {1}", this.Age, this.OemId);
			text += "\nWindowsVersion...\n";
			return text + this.WindowsVersion.ToString();
		}
	}
}
