using System;

namespace Prism.Regions
{
	// Token: 0x0200002C RID: 44
	public class RegionNavigationFailedEventArgs : EventArgs
	{
		// Token: 0x0600011B RID: 283 RVA: 0x00003E24 File Offset: 0x00002024
		public RegionNavigationFailedEventArgs(NavigationContext navigationContext)
		{
			if (navigationContext == null)
			{
				throw new ArgumentNullException("navigationContext");
			}
			this.NavigationContext = navigationContext;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00003E41 File Offset: 0x00002041
		public RegionNavigationFailedEventArgs(NavigationContext navigationContext, Exception error) : this(navigationContext)
		{
			this.Error = error;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00003E51 File Offset: 0x00002051
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00003E59 File Offset: 0x00002059
		public NavigationContext NavigationContext { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00003E62 File Offset: 0x00002062
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00003E6A File Offset: 0x0000206A
		public Exception Error { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00003E73 File Offset: 0x00002073
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
