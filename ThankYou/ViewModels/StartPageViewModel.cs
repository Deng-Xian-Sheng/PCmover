using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using ThankYou.UIData;

namespace ThankYou.ViewModels
{
	// Token: 0x02000012 RID: 18
	public class StartPageViewModel : BindableBase, INavigationAware
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00002D54 File Offset: 0x00000F54
		public StartPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.container = container;
			Task.Run(() => this.DownloadUI()).Wait();
			if (this.Data == null)
			{
				Environment.Exit(0);
			}
			StartData startDetail = this.Data.StartDetail;
			this._FeedbackUri = ((startDetail != null) ? startDetail.FeedbackUri : null);
			eventAggregator.GetEvent<PrismEvents.UIDownloadComplete>().Publish(this.Data.MainDetail);
			PubSubEvent<string> @event = eventAggregator.GetEvent<PrismEvents.SetHeaderTitle>();
			StartData startDetail2 = this.Data.StartDetail;
			@event.Publish((startDetail2 != null) ? startDetail2.HeaderTitle : null);
			this.OnSubmit = new DelegateCommand(new Action(this.Submit), new Func<bool>(this.CanSubmit));
			this.OnSelected = new DelegateCommand<Offer>(new Action<Offer>(this.OnOfferSelectedCommand), new Func<Offer, bool>(this.CanOnOfferSelectedCommand));
			this.OnRatingChanged = new DelegateCommand<string>(new Action<string>(this.OnRatingChangedCommand), new Func<string, bool>(this.CanOnRatingChangedCommand));
			this.UserName = Tools.GetRegistrationInfo("UserName");
			this.UserEmail = Tools.GetRegistrationInfo("Email");
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002E7E File Offset: 0x0000107E
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00002E86 File Offset: 0x00001086
		public ThankYouModel Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if (value != null)
				{
					this.SetProperty<ThankYouModel>(ref this._Data, value, "Data");
					ObservableCollection<Offer> offers = this._Data.Offers;
					this.SeparatorVisible = (offers != null && offers.Count > 0);
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002EBE File Offset: 0x000010BE
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002EC6 File Offset: 0x000010C6
		public string LabelNameError
		{
			get
			{
				return this._LabelNameError;
			}
			set
			{
				this.SetProperty<string>(ref this._LabelNameError, value, "LabelNameError");
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002EDB File Offset: 0x000010DB
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002EE3 File Offset: 0x000010E3
		public string LabelEmailError
		{
			get
			{
				return this._LabelEmailError;
			}
			set
			{
				this.SetProperty<string>(ref this._LabelEmailError, value, "LabelEmailError");
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002EF8 File Offset: 0x000010F8
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00002F00 File Offset: 0x00001100
		public string LabelFeedbackError
		{
			get
			{
				return this._LabelFeedbackError;
			}
			set
			{
				this.SetProperty<string>(ref this._LabelFeedbackError, value, "LabelFeedbackError");
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002F15 File Offset: 0x00001115
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002F1D File Offset: 0x0000111D
		public string LabelFeedbackStatus
		{
			get
			{
				return this._LabelFeedbackStatus;
			}
			set
			{
				this.SetProperty<string>(ref this._LabelFeedbackStatus, value, "LabelFeedbackStatus");
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002F32 File Offset: 0x00001132
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002F3A File Offset: 0x0000113A
		public bool SeparatorVisible
		{
			get
			{
				return this._SeparatorVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._SeparatorVisible, value, "SeparatorVisible");
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002F4F File Offset: 0x0000114F
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002F57 File Offset: 0x00001157
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this.SetProperty<string>(ref this._UserName, value, "UserName");
				this.LabelNameError = string.Empty;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002F77 File Offset: 0x00001177
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002F7F File Offset: 0x0000117F
		public string UserEmail
		{
			get
			{
				return this._UserEmail;
			}
			set
			{
				this.SetProperty<string>(ref this._UserEmail, value, "UserEmail");
				if (Tools.IsValidEmailAddress(this._UserEmail))
				{
					this.LabelEmailError = string.Empty;
				}
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002FAC File Offset: 0x000011AC
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002FB4 File Offset: 0x000011B4
		public string UserComments
		{
			get
			{
				return this._UserComments;
			}
			set
			{
				this.SetProperty<string>(ref this._UserComments, value, "UserComments");
				this.LabelFeedbackError = string.Empty;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002FD4 File Offset: 0x000011D4
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00002FDC File Offset: 0x000011DC
		public int SelectedRating
		{
			get
			{
				return this._SelectedRating;
			}
			set
			{
				this.SetProperty<int>(ref this._SelectedRating, value, "SelectedRating");
				this.LabelFeedbackError = string.Empty;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002FFC File Offset: 0x000011FC
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00003004 File Offset: 0x00001204
		public DelegateCommand<Offer> OnSelected { get; private set; }

		// Token: 0x06000081 RID: 129 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnOfferSelectedCommand(Offer arg)
		{
			return true;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003010 File Offset: 0x00001210
		private void OnOfferSelectedCommand(Offer offer)
		{
			if (offer != null)
			{
				NavigationParameters navigationParameters = new NavigationParameters();
				navigationParameters.Add("Offer", offer);
				this.regionManager.RequestNavigate("ContentRegion", new Uri("OfferPage", UriKind.Relative), navigationParameters);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000304E File Offset: 0x0000124E
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00003056 File Offset: 0x00001256
		public DelegateCommand OnSubmit { get; private set; }

		// Token: 0x06000085 RID: 133 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanSubmit()
		{
			return true;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003060 File Offset: 0x00001260
		private void Submit()
		{
			if (this._FeebackCounter < 4)
			{
				if (string.IsNullOrWhiteSpace(this._UserName))
				{
					this.LabelNameError = this.Data.StartDetail.NameError;
					return;
				}
				this.LabelNameError = string.Empty;
				if (!Tools.IsValidEmailAddress(this._UserEmail))
				{
					this.LabelEmailError = this.Data.StartDetail.EmailError;
					return;
				}
				this.LabelEmailError = string.Empty;
				if (string.IsNullOrWhiteSpace(this._UserComments) && this._SelectedRating == 0)
				{
					this.LabelFeedbackError = this.Data.StartDetail.FeedbackError;
					return;
				}
				this.LabelFeedbackError = string.Empty;
				if (Tools.SendFeedback(this._UserComments, this._UserName, this._UserEmail, this._SelectedRating, false, this._FeedbackUri))
				{
					this._FeebackCounter++;
					this.LabelFeedbackStatus = this.Data.StartDetail.FeedbackStatusSuccess;
					this.eventAggregator.GetEvent<PrismEvents.DontShowCheckChanged>().Publish(true);
					DispatcherTimer timer = new DispatcherTimer
					{
						Interval = TimeSpan.FromSeconds(5.0)
					};
					timer.Tick += delegate(object sender, EventArgs args)
					{
						this.LabelFeedbackStatus = string.Empty;
						timer.Stop();
					};
					timer.Start();
					return;
				}
				this.LabelFeedbackStatus = this.Data.StartDetail.FeedbackStatusError;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000031CE File Offset: 0x000013CE
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000031D6 File Offset: 0x000013D6
		public DelegateCommand<string> OnRatingChanged { get; private set; }

		// Token: 0x06000089 RID: 137 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanOnRatingChangedCommand(string arg)
		{
			return true;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000031E0 File Offset: 0x000013E0
		private void OnRatingChangedCommand(string rating)
		{
			try
			{
				this.SelectedRating = Convert.ToInt32(rating);
			}
			catch
			{
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003210 File Offset: 0x00001410
		private Task DownloadUI()
		{
			StartPageViewModel.<DownloadUI>d__64 <DownloadUI>d__;
			<DownloadUI>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DownloadUI>d__.<>4__this = this;
			<DownloadUI>d__.<>1__state = -1;
			<DownloadUI>d__.<>t__builder.Start<StartPageViewModel.<DownloadUI>d__64>(ref <DownloadUI>d__);
			return <DownloadUI>d__.<>t__builder.Task;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003253 File Offset: 0x00001453
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<PrismEvents.SetHeaderTitle>().Publish(this.Data.StartDetail.HeaderTitle);
			this.eventAggregator.GetEvent<PrismEvents.HideFooterChanged>().Publish(false);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002A9F File Offset: 0x00000C9F
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002062 File Offset: 0x00000262
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000022 RID: 34
		private readonly IRegionManager regionManager;

		// Token: 0x04000023 RID: 35
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000024 RID: 36
		private readonly IUnityContainer container;

		// Token: 0x04000025 RID: 37
		private string _FeedbackUri;

		// Token: 0x04000026 RID: 38
		private int _FeebackCounter;

		// Token: 0x04000027 RID: 39
		private ThankYouModel _Data;

		// Token: 0x04000028 RID: 40
		private string _LabelNameError;

		// Token: 0x04000029 RID: 41
		private string _LabelEmailError;

		// Token: 0x0400002A RID: 42
		private string _LabelFeedbackError;

		// Token: 0x0400002B RID: 43
		private string _LabelFeedbackStatus;

		// Token: 0x0400002C RID: 44
		private bool _SeparatorVisible;

		// Token: 0x0400002D RID: 45
		private string _UserName;

		// Token: 0x0400002E RID: 46
		private string _UserEmail;

		// Token: 0x0400002F RID: 47
		private string _UserComments;

		// Token: 0x04000030 RID: 48
		private int _SelectedRating;
	}
}
