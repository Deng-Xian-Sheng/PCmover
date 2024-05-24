using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000022 RID: 34
	public class AeroGlassCompositionChangedEventArgs : EventArgs
	{
		// Token: 0x0600011C RID: 284 RVA: 0x0000619F File Offset: 0x0000439F
		internal AeroGlassCompositionChangedEventArgs(bool avialbility)
		{
			this.GlassAvailable = avialbility;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600011D RID: 285 RVA: 0x000061B4 File Offset: 0x000043B4
		// (set) Token: 0x0600011E RID: 286 RVA: 0x000061CB File Offset: 0x000043CB
		public bool GlassAvailable { get; private set; }
	}
}
