using System;
using System.Collections.Generic;
using Prism.Common;

namespace Prism.Regions
{
	// Token: 0x0200001E RID: 30
	public class NavigationContext
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00002866 File Offset: 0x00000A66
		public NavigationContext(IRegionNavigationService navigationService, Uri uri) : this(navigationService, uri, null)
		{
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002871 File Offset: 0x00000A71
		public NavigationContext(IRegionNavigationService navigationService, Uri uri, NavigationParameters navigationParameters)
		{
			this.NavigationService = navigationService;
			this.Uri = uri;
			this.Parameters = ((uri != null) ? UriParsingHelper.ParseQuery(uri) : null);
			this.GetNavigationParameters(navigationParameters);
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000028A6 File Offset: 0x00000AA6
		// (set) Token: 0x06000099 RID: 153 RVA: 0x000028AE File Offset: 0x00000AAE
		public IRegionNavigationService NavigationService { get; private set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000028B7 File Offset: 0x00000AB7
		// (set) Token: 0x0600009B RID: 155 RVA: 0x000028BF File Offset: 0x00000ABF
		public Uri Uri { get; private set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000028C8 File Offset: 0x00000AC8
		// (set) Token: 0x0600009D RID: 157 RVA: 0x000028D0 File Offset: 0x00000AD0
		public NavigationParameters Parameters { get; private set; }

		// Token: 0x0600009E RID: 158 RVA: 0x000028DC File Offset: 0x00000ADC
		private void GetNavigationParameters(NavigationParameters navigationParameters)
		{
			if (this.Parameters == null || this.NavigationService == null || this.NavigationService.Region == null)
			{
				this.Parameters = new NavigationParameters();
				return;
			}
			if (navigationParameters != null)
			{
				foreach (KeyValuePair<string, object> keyValuePair in navigationParameters)
				{
					this.Parameters.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}
	}
}
