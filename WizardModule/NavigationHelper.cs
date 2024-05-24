using System;
using System.Collections.Generic;
using System.Linq;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Regions;

namespace WizardModule
{
	// Token: 0x02000002 RID: 2
	public class NavigationHelper
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public Uri PreviousPage { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public bool IsPlayingBackRecordedPolicy { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public bool IsNavigatingBack { get; set; }

		// Token: 0x06000007 RID: 7 RVA: 0x00002084 File Offset: 0x00000284
		public void Init(IUnityContainer container, DefaultPolicy policy, LlTraceSource ts)
		{
			this.policy = policy;
			this.ts = ts;
			this.navigationStack = new Stack<Uri>();
			this.regionManager = container.Resolve(Array.Empty<ResolverOverride>());
			this.regionManager.Regions.First((IRegion x) => x.Name == RegionNames.WizardRegion).NavigationService.Navigating += this.NavigationService_Navigating;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002100 File Offset: 0x00000300
		public void GoBack(NavigationParameters parameters = null)
		{
			try
			{
				if (this.PreviousPage != null)
				{
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, this.PreviousPage, parameters);
				}
			}
			catch (Exception ex)
			{
				this.ts.TraceException(ex, "GoBack");
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002158 File Offset: 0x00000358
		public void SetCustomizePath()
		{
			if (this.navigationStack.Any((Uri p) => p.OriginalString == "AnalyzePCPage"))
			{
				while (this.navigationStack.Peek().OriginalString != "AnalyzePCPage")
				{
					this.navigationStack.Pop();
				}
				this.navigationStack.Push(new Uri("CustomTransferPage", UriKind.Relative));
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021D4 File Offset: 0x000003D4
		private void NavigationService_Navigating(object sender, RegionNavigationEventArgs e)
		{
			Uri uri = e.Uri;
			if (this.IsPlayingBackRecordedPolicy)
			{
				if (uri.OriginalString == this.policy.CurrentPage)
				{
					this.IsPlayingBackRecordedPolicy = false;
				}
			}
			else
			{
				this.policy.CurrentPage = uri.OriginalString;
				this.policy.WriteProfile();
			}
			if (this.navigationStack.Count > 0)
			{
				this.PreviousPage = this.navigationStack.Peek();
			}
			this.IsNavigatingBack = this.navigationStack.Contains(uri);
			if (this.IsNavigatingBack)
			{
				while (this.navigationStack.Peek() != uri)
				{
					this.navigationStack.Pop();
				}
				if (this.navigationStack.Count > 1)
				{
					this.PreviousPage = this.navigationStack.ElementAt(1);
				}
				else
				{
					this.PreviousPage = null;
				}
				this.ts.TraceInformation(string.Format("Navigating back to {0}.  PreviousPage={1}", uri, this.PreviousPage));
				return;
			}
			this.navigationStack.Push(uri);
		}

		// Token: 0x04000001 RID: 1
		private Stack<Uri> navigationStack;

		// Token: 0x04000002 RID: 2
		private DefaultPolicy policy;

		// Token: 0x04000003 RID: 3
		private IRegionManager regionManager;

		// Token: 0x04000004 RID: 4
		private LlTraceSource ts;
	}
}
