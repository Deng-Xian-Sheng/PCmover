using System;

namespace Prism.Regions
{
	// Token: 0x02000035 RID: 53
	public class ViewRegisteredEventArgs : EventArgs
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00004869 File Offset: 0x00002A69
		public ViewRegisteredEventArgs(string regionName, Func<object> getViewDelegate)
		{
			this.GetView = getViewDelegate;
			this.RegionName = regionName;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000487F File Offset: 0x00002A7F
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00004887 File Offset: 0x00002A87
		public string RegionName { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00004890 File Offset: 0x00002A90
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00004898 File Offset: 0x00002A98
		public Func<object> GetView { get; private set; }
	}
}
