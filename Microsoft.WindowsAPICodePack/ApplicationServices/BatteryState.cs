using System;
using System.Globalization;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200003C RID: 60
	public class BatteryState
	{
		// Token: 0x06000101 RID: 257 RVA: 0x000044C4 File Offset: 0x000026C4
		internal BatteryState()
		{
			PowerManagementNativeMethods.SystemBatteryState systemBatteryState = Power.GetSystemBatteryState();
			if (!systemBatteryState.BatteryPresent)
			{
				throw new InvalidOperationException(LocalizedMessages.PowerManagerBatteryNotPresent);
			}
			this.ACOnline = systemBatteryState.AcOnLine;
			this.MaxCharge = (int)systemBatteryState.MaxCapacity;
			this.CurrentCharge = (int)systemBatteryState.RemainingCapacity;
			this.ChargeRate = (int)systemBatteryState.Rate;
			uint estimatedTime = systemBatteryState.EstimatedTime;
			if (estimatedTime != 4294967295U)
			{
				this.EstimatedTimeRemaining = new TimeSpan(0, 0, (int)estimatedTime);
			}
			else
			{
				this.EstimatedTimeRemaining = TimeSpan.MaxValue;
			}
			this.SuggestedCriticalBatteryCharge = (int)systemBatteryState.DefaultAlert1;
			this.SuggestedBatteryWarningCharge = (int)systemBatteryState.DefaultAlert2;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000102 RID: 258 RVA: 0x0000457C File Offset: 0x0000277C
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00004593 File Offset: 0x00002793
		public bool ACOnline { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000104 RID: 260 RVA: 0x0000459C File Offset: 0x0000279C
		// (set) Token: 0x06000105 RID: 261 RVA: 0x000045B3 File Offset: 0x000027B3
		public int MaxCharge { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000106 RID: 262 RVA: 0x000045BC File Offset: 0x000027BC
		// (set) Token: 0x06000107 RID: 263 RVA: 0x000045D3 File Offset: 0x000027D3
		public int CurrentCharge { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000108 RID: 264 RVA: 0x000045DC File Offset: 0x000027DC
		// (set) Token: 0x06000109 RID: 265 RVA: 0x000045F3 File Offset: 0x000027F3
		public int ChargeRate { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600010A RID: 266 RVA: 0x000045FC File Offset: 0x000027FC
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00004613 File Offset: 0x00002813
		public TimeSpan EstimatedTimeRemaining { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600010C RID: 268 RVA: 0x0000461C File Offset: 0x0000281C
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00004633 File Offset: 0x00002833
		public int SuggestedCriticalBatteryCharge { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0000463C File Offset: 0x0000283C
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00004653 File Offset: 0x00002853
		public int SuggestedBatteryWarningCharge { get; private set; }

		// Token: 0x06000110 RID: 272 RVA: 0x0000465C File Offset: 0x0000285C
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, LocalizedMessages.BatteryStateStringRepresentation, new object[]
			{
				Environment.NewLine,
				this.ACOnline,
				this.MaxCharge,
				this.CurrentCharge,
				this.ChargeRate,
				this.EstimatedTimeRemaining,
				this.SuggestedCriticalBatteryCharge,
				this.SuggestedBatteryWarningCharge
			});
		}
	}
}
