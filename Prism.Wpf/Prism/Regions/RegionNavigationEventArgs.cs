using System;

namespace Prism.Regions
{
	// Token: 0x0200002B RID: 43
	public class RegionNavigationEventArgs : EventArgs
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00003DDF File Offset: 0x00001FDF
		public RegionNavigationEventArgs(NavigationContext navigationContext)
		{
			if (navigationContext == null)
			{
				throw new ArgumentNullException("navigationContext");
			}
			this.NavigationContext = navigationContext;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00003DFC File Offset: 0x00001FFC
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00003E04 File Offset: 0x00002004
		public NavigationContext NavigationContext { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00003E0D File Offset: 0x0000200D
		public Uri Uri
		{
			get
			{
				if (this.NavigationContext != null)
				{
					return this.NavigationContext.Uri;
				}
				return null;
			}
		}
	}
}
