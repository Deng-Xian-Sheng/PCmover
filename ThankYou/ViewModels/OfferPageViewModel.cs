using System;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using ThankYou.UIData;

namespace ThankYou.ViewModels
{
	// Token: 0x02000011 RID: 17
	public class OfferPageViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00002B34 File Offset: 0x00000D34
		public OfferPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnInfo = new DelegateCommand(new Action(this.OnInfoCommand), new Func<bool>(this.CanOnInfoCommand));
			this.OnContentButton1 = new DelegateCommand(new Action(this.OnContentButton1Command), new Func<bool>(this.CanOnOnContentButton1Command));
			this.OnContentButton2 = new DelegateCommand(new Action(this.OnContentButton2Command), new Func<bool>(this.CanOnOnContentButton2Command));
			this.OnContentButton3 = new DelegateCommand(new Action(this.OnContentButton3Command), new Func<bool>(this.CanOnOnContentButton3Command));
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002C0B File Offset: 0x00000E0B
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002C13 File Offset: 0x00000E13
		public Offer Offer
		{
			get
			{
				return this._Offer;
			}
			set
			{
				this.SetProperty<Offer>(ref this._Offer, value, "Offer");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002C28 File Offset: 0x00000E28
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002C30 File Offset: 0x00000E30
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000055 RID: 85 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002C39 File Offset: 0x00000E39
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate("ContentRegion", new Uri("StartPage", UriKind.Relative));
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002C56 File Offset: 0x00000E56
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002C5E File Offset: 0x00000E5E
		public DelegateCommand OnInfo { get; private set; }

		// Token: 0x06000059 RID: 89 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnInfoCommand()
		{
			return true;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002C67 File Offset: 0x00000E67
		private void OnInfoCommand()
		{
			Tools.LaunchURL(this._Offer.PageContent.ContentURL);
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002C7E File Offset: 0x00000E7E
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002C86 File Offset: 0x00000E86
		public DelegateCommand OnContentButton1 { get; private set; }

		// Token: 0x0600005D RID: 93 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnOnContentButton1Command()
		{
			return true;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002C8F File Offset: 0x00000E8F
		private void OnContentButton1Command()
		{
			Tools.LaunchURL(this._Offer.PageContent.ContentButton1Url);
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002CA6 File Offset: 0x00000EA6
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002CAE File Offset: 0x00000EAE
		public DelegateCommand OnContentButton2 { get; private set; }

		// Token: 0x06000061 RID: 97 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnOnContentButton2Command()
		{
			return true;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002CB7 File Offset: 0x00000EB7
		private void OnContentButton2Command()
		{
			Tools.LaunchURL(this._Offer.PageContent.ContentButton2Url);
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002CCE File Offset: 0x00000ECE
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002CD6 File Offset: 0x00000ED6
		public DelegateCommand OnContentButton3 { get; private set; }

		// Token: 0x06000065 RID: 101 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnOnContentButton3Command()
		{
			return true;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002CDF File Offset: 0x00000EDF
		private void OnContentButton3Command()
		{
			Tools.LaunchURL(this._Offer.PageContent.ContentButton3Url);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002A9F File Offset: 0x00000C9F
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002062 File Offset: 0x00000262
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002CF8 File Offset: 0x00000EF8
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Offer offer = (Offer)navigationContext.Parameters["Offer"];
			this.Offer = offer;
			this.eventAggregator.GetEvent<PrismEvents.SetHeaderTitle>().Publish(offer.PageContent.HeaderTitle);
			this.eventAggregator.GetEvent<PrismEvents.HideFooterChanged>().Publish(offer.HideFooter);
		}

		// Token: 0x04000019 RID: 25
		private readonly IRegionManager regionManager;

		// Token: 0x0400001A RID: 26
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400001B RID: 27
		private readonly IUnityContainer container;

		// Token: 0x0400001C RID: 28
		private Offer _Offer;
	}
}
