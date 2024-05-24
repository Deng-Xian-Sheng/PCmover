using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Common;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x0200002F RID: 47
	public class RegionNavigationService : IRegionNavigationService, INavigateAsync
	{
		// Token: 0x06000134 RID: 308 RVA: 0x00004080 File Offset: 0x00002280
		public RegionNavigationService(IServiceLocator serviceLocator, IRegionNavigationContentLoader regionNavigationContentLoader, IRegionNavigationJournal journal)
		{
			if (serviceLocator == null)
			{
				throw new ArgumentNullException("serviceLocator");
			}
			if (regionNavigationContentLoader == null)
			{
				throw new ArgumentNullException("regionNavigationContentLoader");
			}
			if (journal == null)
			{
				throw new ArgumentNullException("journal");
			}
			this.serviceLocator = serviceLocator;
			this.regionNavigationContentLoader = regionNavigationContentLoader;
			this.journal = journal;
			this.journal.NavigationTarget = this;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000040DE File Offset: 0x000022DE
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000040E6 File Offset: 0x000022E6
		public IRegion Region { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000040EF File Offset: 0x000022EF
		public IRegionNavigationJournal Journal
		{
			get
			{
				return this.journal;
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000138 RID: 312 RVA: 0x000040F8 File Offset: 0x000022F8
		// (remove) Token: 0x06000139 RID: 313 RVA: 0x00004130 File Offset: 0x00002330
		public event EventHandler<RegionNavigationEventArgs> Navigating;

		// Token: 0x0600013A RID: 314 RVA: 0x00004165 File Offset: 0x00002365
		private void RaiseNavigating(NavigationContext navigationContext)
		{
			if (this.Navigating != null)
			{
				this.Navigating(this, new RegionNavigationEventArgs(navigationContext));
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600013B RID: 315 RVA: 0x00004184 File Offset: 0x00002384
		// (remove) Token: 0x0600013C RID: 316 RVA: 0x000041BC File Offset: 0x000023BC
		public event EventHandler<RegionNavigationEventArgs> Navigated;

		// Token: 0x0600013D RID: 317 RVA: 0x000041F1 File Offset: 0x000023F1
		private void RaiseNavigated(NavigationContext navigationContext)
		{
			if (this.Navigated != null)
			{
				this.Navigated(this, new RegionNavigationEventArgs(navigationContext));
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600013E RID: 318 RVA: 0x00004210 File Offset: 0x00002410
		// (remove) Token: 0x0600013F RID: 319 RVA: 0x00004248 File Offset: 0x00002448
		public event EventHandler<RegionNavigationFailedEventArgs> NavigationFailed;

		// Token: 0x06000140 RID: 320 RVA: 0x0000427D File Offset: 0x0000247D
		private void RaiseNavigationFailed(NavigationContext navigationContext, Exception error)
		{
			if (this.NavigationFailed != null)
			{
				this.NavigationFailed(this, new RegionNavigationFailedEventArgs(navigationContext, error));
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000429A File Offset: 0x0000249A
		public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback)
		{
			this.RequestNavigate(target, navigationCallback, null);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000042A8 File Offset: 0x000024A8
		public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
		{
			if (navigationCallback == null)
			{
				throw new ArgumentNullException("navigationCallback");
			}
			try
			{
				this.DoNavigate(target, navigationCallback, navigationParameters);
			}
			catch (Exception e)
			{
				this.NotifyNavigationFailed(new NavigationContext(this, target), navigationCallback, e);
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000042F4 File Offset: 0x000024F4
		private void DoNavigate(Uri source, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (this.Region == null)
			{
				throw new InvalidOperationException(Resources.NavigationServiceHasNoRegion);
			}
			this.currentNavigationContext = new NavigationContext(this, source, navigationParameters);
			this.RequestCanNavigateFromOnCurrentlyActiveView(this.currentNavigationContext, navigationCallback, this.Region.ActiveViews.ToArray<object>(), 0);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004354 File Offset: 0x00002554
		private void RequestCanNavigateFromOnCurrentlyActiveView(NavigationContext navigationContext, Action<NavigationResult> navigationCallback, object[] activeViews, int currentViewIndex)
		{
			if (currentViewIndex >= activeViews.Length)
			{
				this.ExecuteNavigation(navigationContext, activeViews, navigationCallback);
				return;
			}
			IConfirmNavigationRequest confirmNavigationRequest = activeViews[currentViewIndex] as IConfirmNavigationRequest;
			if (confirmNavigationRequest != null)
			{
				confirmNavigationRequest.ConfirmNavigationRequest(navigationContext, delegate(bool canNavigate)
				{
					if (this.currentNavigationContext == navigationContext && canNavigate)
					{
						this.RequestCanNavigateFromOnCurrentlyActiveViewModel(navigationContext, navigationCallback, activeViews, currentViewIndex);
						return;
					}
					this.NotifyNavigationFailed(navigationContext, navigationCallback, null);
				});
				return;
			}
			this.RequestCanNavigateFromOnCurrentlyActiveViewModel(navigationContext, navigationCallback, activeViews, currentViewIndex);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004404 File Offset: 0x00002604
		private void RequestCanNavigateFromOnCurrentlyActiveViewModel(NavigationContext navigationContext, Action<NavigationResult> navigationCallback, object[] activeViews, int currentViewIndex)
		{
			FrameworkElement frameworkElement = activeViews[currentViewIndex] as FrameworkElement;
			if (frameworkElement != null)
			{
				IConfirmNavigationRequest confirmNavigationRequest = frameworkElement.DataContext as IConfirmNavigationRequest;
				if (confirmNavigationRequest != null)
				{
					confirmNavigationRequest.ConfirmNavigationRequest(navigationContext, delegate(bool canNavigate)
					{
						if (this.currentNavigationContext == navigationContext && canNavigate)
						{
							this.RequestCanNavigateFromOnCurrentlyActiveView(navigationContext, navigationCallback, activeViews, currentViewIndex + 1);
							return;
						}
						this.NotifyNavigationFailed(navigationContext, navigationCallback, null);
					});
					return;
				}
			}
			this.RequestCanNavigateFromOnCurrentlyActiveView(navigationContext, navigationCallback, activeViews, currentViewIndex + 1);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000449C File Offset: 0x0000269C
		private void ExecuteNavigation(NavigationContext navigationContext, object[] activeViews, Action<NavigationResult> navigationCallback)
		{
			try
			{
				RegionNavigationService.NotifyActiveViewsNavigatingFrom(navigationContext, activeViews);
				object view = this.regionNavigationContentLoader.LoadContent(this.Region, navigationContext);
				this.RaiseNavigating(navigationContext);
				this.Region.Activate(view);
				IRegionNavigationJournalEntry instance = this.serviceLocator.GetInstance<IRegionNavigationJournalEntry>();
				instance.Uri = navigationContext.Uri;
				instance.Parameters = navigationContext.Parameters;
				this.journal.RecordNavigation(instance);
				Action<INavigationAware> action = delegate(INavigationAware n)
				{
					n.OnNavigatedTo(navigationContext);
				};
				MvvmHelpers.ViewAndViewModelAction<INavigationAware>(view, action);
				navigationCallback(new NavigationResult(navigationContext, new bool?(true)));
				this.RaiseNavigated(navigationContext);
			}
			catch (Exception e)
			{
				this.NotifyNavigationFailed(navigationContext, navigationCallback, e);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004588 File Offset: 0x00002788
		private void NotifyNavigationFailed(NavigationContext navigationContext, Action<NavigationResult> navigationCallback, Exception e)
		{
			NavigationResult obj = (e != null) ? new NavigationResult(navigationContext, e) : new NavigationResult(navigationContext, new bool?(false));
			navigationCallback(obj);
			this.RaiseNavigationFailed(navigationContext, e);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000045C0 File Offset: 0x000027C0
		private static void NotifyActiveViewsNavigatingFrom(NavigationContext navigationContext, object[] activeViews)
		{
			RegionNavigationService.InvokeOnNavigationAwareElements(activeViews, delegate(INavigationAware n)
			{
				n.OnNavigatedFrom(navigationContext);
			});
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000045EC File Offset: 0x000027EC
		private static void InvokeOnNavigationAwareElements(IEnumerable<object> items, Action<INavigationAware> invocation)
		{
			foreach (object view in items)
			{
				MvvmHelpers.ViewAndViewModelAction<INavigationAware>(view, invocation);
			}
		}

		// Token: 0x04000035 RID: 53
		private readonly IServiceLocator serviceLocator;

		// Token: 0x04000036 RID: 54
		private readonly IRegionNavigationContentLoader regionNavigationContentLoader;

		// Token: 0x04000037 RID: 55
		private IRegionNavigationJournal journal;

		// Token: 0x04000038 RID: 56
		private NavigationContext currentNavigationContext;
	}
}
