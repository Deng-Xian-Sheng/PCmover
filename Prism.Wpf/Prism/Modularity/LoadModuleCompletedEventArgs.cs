using System;

namespace Prism.Modularity
{
	// Token: 0x02000057 RID: 87
	public class LoadModuleCompletedEventArgs : EventArgs
	{
		// Token: 0x06000263 RID: 611 RVA: 0x00006DB6 File Offset: 0x00004FB6
		public LoadModuleCompletedEventArgs(ModuleInfo moduleInfo, Exception error)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			this.ModuleInfo = moduleInfo;
			this.Error = error;
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00006DDA File Offset: 0x00004FDA
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00006DE2 File Offset: 0x00004FE2
		public ModuleInfo ModuleInfo { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00006DEB File Offset: 0x00004FEB
		// (set) Token: 0x06000267 RID: 615 RVA: 0x00006DF3 File Offset: 0x00004FF3
		public Exception Error { get; private set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00006DFC File Offset: 0x00004FFC
		// (set) Token: 0x06000269 RID: 617 RVA: 0x00006E04 File Offset: 0x00005004
		public bool IsErrorHandled { get; set; }
	}
}
