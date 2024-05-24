using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200000C RID: 12
	public class AppInventoryStatus
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000024FA File Offset: 0x000006FA
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002502 File Offset: 0x00000702
		public AppInventoryAmount Configuration { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000250B File Offset: 0x0000070B
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002513 File Offset: 0x00000713
		public AppInventoryAmount Completed { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000251C File Offset: 0x0000071C
		public bool IsCompleted
		{
			get
			{
				return this.Completed >= this.Configuration;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000252F File Offset: 0x0000072F
		public override string ToString()
		{
			return string.Format("Configuration: {0}, Completed: {1}", this.Configuration, this.Completed);
		}
	}
}
