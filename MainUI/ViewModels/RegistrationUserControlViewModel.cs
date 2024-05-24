using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using Laplink.Tools.Helpers;
using MainUI.Properties;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MainUI.ViewModels
{
	// Token: 0x0200001A RID: 26
	public class RegistrationUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000062A0 File Offset: 0x000044A0
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000062A8 File Offset: 0x000044A8
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				this.SetProperty<string>(ref this._FirstName, value, "FirstName");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600015B RID: 347 RVA: 0x000062C8 File Offset: 0x000044C8
		// (set) Token: 0x0600015C RID: 348 RVA: 0x000062D0 File Offset: 0x000044D0
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				this.SetProperty<string>(ref this._LastName, value, "LastName");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600015D RID: 349 RVA: 0x000062F0 File Offset: 0x000044F0
		// (set) Token: 0x0600015E RID: 350 RVA: 0x000062F8 File Offset: 0x000044F8
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this.SetProperty<string>(ref this._Email, value, "Email");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00006318 File Offset: 0x00004518
		// (set) Token: 0x06000160 RID: 352 RVA: 0x00006320 File Offset: 0x00004520
		public string ErrorMessage
		{
			get
			{
				return this._ErrorMessage;
			}
			set
			{
				this.SetProperty<string>(ref this._ErrorMessage, value, "ErrorMessage");
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00006335 File Offset: 0x00004535
		// (set) Token: 0x06000162 RID: 354 RVA: 0x0000633D File Offset: 0x0000453D
		public bool ShowErrorMessage
		{
			get
			{
				return this._ShowErrorMessage;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowErrorMessage, value, "ShowErrorMessage");
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006354 File Offset: 0x00004554
		public RegistrationUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, LlTraceSource ts)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnPurchase = new DelegateCommand(new Action(this.OnPurchaseCommand));
			RegSettings regSettings = new RegSettings(ts);
			if (!string.IsNullOrEmpty(regSettings.FirstName) && !string.IsNullOrEmpty(regSettings.LastName) && !string.IsNullOrEmpty(regSettings.Email))
			{
				this.FirstName = regSettings.FirstName;
				this.LastName = regSettings.LastName;
				this.Email = regSettings.Email;
			}
			else
			{
				this.FirstName = "";
				this.LastName = "";
				this.Email = "";
			}
			this.ShowErrorMessage = false;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00006432 File Offset: 0x00004632
		// (set) Token: 0x06000165 RID: 357 RVA: 0x0000643A File Offset: 0x0000463A
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000166 RID: 358 RVA: 0x00006443 File Offset: 0x00004643
		private bool CanOnNextCommand()
		{
			return !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName) && !string.IsNullOrEmpty(this.Email);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00006470 File Offset: 0x00004670
		internal static bool IsValidEmailAddress(string address)
		{
			if (string.IsNullOrEmpty(address))
			{
				return false;
			}
			try
			{
				new MailAddress(address);
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000064AC File Offset: 0x000046AC
		private void OnNextCommand()
		{
			RegistrationUserControlViewModel.<OnNextCommand>d__31 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<RegistrationUserControlViewModel.<OnNextCommand>d__31>(ref <OnNextCommand>d__);
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000064E3 File Offset: 0x000046E3
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000064EB File Offset: 0x000046EB
		public DelegateCommand OnPurchase { get; private set; }

		// Token: 0x0600016B RID: 363 RVA: 0x000064F4 File Offset: 0x000046F4
		private void OnPurchaseCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(Resources.URL_Upsell));
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006528 File Offset: 0x00004728
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000652A File Offset: 0x0000472A
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000652D File Offset: 0x0000472D
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000092 RID: 146
		private readonly IRegionManager regionManager;

		// Token: 0x04000093 RID: 147
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000094 RID: 148
		private readonly LlTraceSource ts;

		// Token: 0x04000095 RID: 149
		private static readonly HttpClient client = new HttpClient();

		// Token: 0x04000096 RID: 150
		private string _FirstName;

		// Token: 0x04000097 RID: 151
		private string _LastName;

		// Token: 0x04000098 RID: 152
		private string _Email;

		// Token: 0x04000099 RID: 153
		private string _ErrorMessage;

		// Token: 0x0400009A RID: 154
		private bool _ShowErrorMessage;
	}
}
