using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200009E RID: 158
	public class WarningPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x00025B88 File Offset: 0x00023D88
		// (set) Token: 0x06000DF5 RID: 3573 RVA: 0x00025B90 File Offset: 0x00023D90
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this.SetProperty<string>(ref this._Title, value, "Title");
			}
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x00025BA5 File Offset: 0x00023DA5
		// (set) Token: 0x06000DF7 RID: 3575 RVA: 0x00025BAD File Offset: 0x00023DAD
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				this.SetProperty<string>(ref this._Description, value, "Description");
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x00025BC2 File Offset: 0x00023DC2
		// (set) Token: 0x06000DF9 RID: 3577 RVA: 0x00025BCA File Offset: 0x00023DCA
		public string BeforeStart1
		{
			get
			{
				return this._BeforeStart1;
			}
			set
			{
				this.SetProperty<string>(ref this._BeforeStart1, value, "BeforeStart1");
			}
		}

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x06000DFA RID: 3578 RVA: 0x00025BDF File Offset: 0x00023DDF
		// (set) Token: 0x06000DFB RID: 3579 RVA: 0x00025BE7 File Offset: 0x00023DE7
		public string BeforeStart2
		{
			get
			{
				return this._BeforeStart2;
			}
			set
			{
				this.SetProperty<string>(ref this._BeforeStart2, value, "BeforeStart2");
			}
		}

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06000DFC RID: 3580 RVA: 0x00025BFC File Offset: 0x00023DFC
		// (set) Token: 0x06000DFD RID: 3581 RVA: 0x00025C04 File Offset: 0x00023E04
		public string BeforeStart3
		{
			get
			{
				return this._BeforeStart3;
			}
			set
			{
				this.SetProperty<string>(ref this._BeforeStart3, value, "BeforeStart3");
			}
		}

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x00025C19 File Offset: 0x00023E19
		// (set) Token: 0x06000DFF RID: 3583 RVA: 0x00025C21 File Offset: 0x00023E21
		public string BeforeStart4
		{
			get
			{
				return this._BeforeStart4;
			}
			set
			{
				this.SetProperty<string>(ref this._BeforeStart4, value, "BeforeStart4");
			}
		}

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06000E00 RID: 3584 RVA: 0x00025C36 File Offset: 0x00023E36
		// (set) Token: 0x06000E01 RID: 3585 RVA: 0x00025C3E File Offset: 0x00023E3E
		public string Limitation1
		{
			get
			{
				return this._Limitation1;
			}
			set
			{
				this.SetProperty<string>(ref this._Limitation1, value, "Limitation1");
			}
		}

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x00025C53 File Offset: 0x00023E53
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x00025C5B File Offset: 0x00023E5B
		public string Limitation2
		{
			get
			{
				return this._Limitation2;
			}
			set
			{
				this.SetProperty<string>(ref this._Limitation2, value, "Limitation2");
			}
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x00025C70 File Offset: 0x00023E70
		// (set) Token: 0x06000E05 RID: 3589 RVA: 0x00025C78 File Offset: 0x00023E78
		public string Limitation3
		{
			get
			{
				return this._Limitation3;
			}
			set
			{
				this.SetProperty<string>(ref this._Limitation3, value, "Limitation3");
			}
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x00025C8D File Offset: 0x00023E8D
		// (set) Token: 0x06000E07 RID: 3591 RVA: 0x00025C95 File Offset: 0x00023E95
		public string Limitation4
		{
			get
			{
				return this._Limitation4;
			}
			set
			{
				this.SetProperty<string>(ref this._Limitation4, value, "Limitation4");
			}
		}

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x00025CAA File Offset: 0x00023EAA
		// (set) Token: 0x06000E09 RID: 3593 RVA: 0x00025CB2 File Offset: 0x00023EB2
		public bool IsChecked
		{
			get
			{
				return this._IsChecked;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsChecked, value, "IsChecked");
			}
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00025CC8 File Offset: 0x00023EC8
		public WarningPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, LlTraceSource ts) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._ts = ts;
			this._canTransferApps = true;
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand));
			this.OnChecked = new DelegateCommand(new Action(this.OnCheckedCommand));
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x00025D68 File Offset: 0x00023F68
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x00025D70 File Offset: 0x00023F70
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000E0D RID: 3597 RVA: 0x00025D79 File Offset: 0x00023F79
		private bool CanOnNextCommand()
		{
			return this.IsChecked;
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x00025D84 File Offset: 0x00023F84
		private void OnNextCommand()
		{
			WarningPageViewModel.<OnNextCommand>d__58 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<WarningPageViewModel.<OnNextCommand>d__58>(ref <OnNextCommand>d__);
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00025DBB File Offset: 0x00023FBB
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00025DC3 File Offset: 0x00023FC3
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000E11 RID: 3601 RVA: 0x00025DCC File Offset: 0x00023FCC
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri(this.backPage, UriKind.Relative));
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x06000E12 RID: 3602 RVA: 0x00025DEA File Offset: 0x00023FEA
		// (set) Token: 0x06000E13 RID: 3603 RVA: 0x00025DF2 File Offset: 0x00023FF2
		public DelegateCommand OnChecked { get; private set; }

		// Token: 0x06000E14 RID: 3604 RVA: 0x00025DFB File Offset: 0x00023FFB
		private void OnCheckedCommand()
		{
			this.OnNext.RaiseCanExecuteChanged();
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00025E08 File Offset: 0x00024008
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.navigationContext = navigationContext;
			NavigationParameters parameters = navigationContext.Parameters;
			TransferMethodType transferMethodType = TransferMethodType.None;
			if (parameters["MigrationType"] != null)
			{
				transferMethodType = (TransferMethodType)parameters["MigrationType"];
			}
			if (parameters["BackPage"] != null)
			{
				this.backPage = (string)parameters["BackPage"];
			}
			if (parameters["OptionSelected"] != null)
			{
				this.optionSelected = (MigrationTypeOption)parameters["OptionSelected"];
			}
			if (transferMethodType <= TransferMethodType.File)
			{
				if (transferMethodType == TransferMethodType.None)
				{
					this.Title = Resources.IDS_WARN_TITLE4;
					this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.IDS_WARN_TITLE4);
					this.Description = Resources.IDS_WARN_TITLE_DESC5;
					this.BeforeStart1 = Resources.IDS_WARN_BEFORE1;
					this.BeforeStart2 = Resources.IDS_WARN_BEFORE2;
					this.BeforeStart3 = Resources.IDS_WARN_BEFORE3;
					this.BeforeStart4 = Resources.IDS_WARN_BEFORE4;
					this.Limitation1 = string.Empty;
					this.Limitation2 = string.Empty;
					this.Limitation3 = string.Empty;
					this.Limitation4 = string.Empty;
					return;
				}
				if (transferMethodType != TransferMethodType.File)
				{
					return;
				}
			}
			else if (transferMethodType != TransferMethodType.Image)
			{
				if (transferMethodType != TransferMethodType.Network)
				{
					switch (transferMethodType)
					{
					case TransferMethodType.SSL:
					case TransferMethodType.Usb:
						break;
					case (TransferMethodType)84:
					case (TransferMethodType)86:
						return;
					case TransferMethodType.WinUpgrade:
						this.Title = Resources.IDS_WARN_TITLE2;
						this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.IDS_WARN_TITLE2);
						this.Description = Resources.IDS_WARN_TITLE_DESC3;
						this.BeforeStart1 = Resources.IDS_WARN_BEFORE1;
						this.BeforeStart2 = Resources.IDS_WARN_BEFORE2;
						this.BeforeStart3 = Resources.IDS_WARN_BEFORE3;
						this.BeforeStart4 = string.Empty;
						if (this._canTransferApps)
						{
							this.Limitation1 = Resources.IDS_WARN_LIMITS1;
							this.Limitation2 = Resources.IDS_WARN_LIMITS2;
							this.Limitation3 = Resources.IDS_WARN_LIMITS3;
							this.Limitation4 = Resources.IDS_WARN_LIMITS_CLOUD;
							return;
						}
						this.Description = Resources.IDS_WARN_TITLE_DESC2;
						this.Limitation1 = Resources.IDS_WARN_LIMITS1_NOAPP;
						this.Limitation2 = Resources.IDS_WARN_LIMITS_CLOUD;
						this.Limitation3 = string.Empty;
						this.Limitation4 = string.Empty;
						return;
					default:
						return;
					}
				}
			}
			else
			{
				this.Title = Resources.IDS_WARN_TITLE3;
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.IDS_WARN_TITLE3);
				this.BeforeStart1 = Resources.IDS_WARN_BEFORE1;
				this.BeforeStart2 = Resources.IDS_WARN_BEFORE2;
				this.BeforeStart3 = Resources.IDS_WARN_BEFORE3;
				this.BeforeStart4 = Resources.IDS_WARN_BEFORE4;
				if (this._canTransferApps)
				{
					this.Description = Resources.IDS_WARN_TITLE_DESC4;
					this.Limitation1 = Resources.IDS_WARN_LIMITS1;
					this.Limitation2 = Resources.IDS_WARN_LIMITS2;
					this.Limitation3 = Resources.IDS_WARN_LIMITS3;
					this.Limitation4 = Resources.IDS_WARN_LIMITS_CLOUD;
					return;
				}
				this.Description = Resources.IDS_WARN_TITLE_DESC4_NOAPPS;
				this.Limitation1 = Resources.IDS_WARN_LIMITS1_NOAPP;
				this.Limitation2 = Resources.IDS_WARN_LIMITS_CLOUD;
				this.Limitation3 = string.Empty;
				this.Limitation4 = string.Empty;
				return;
			}
			this.Title = Resources.IDS_WARN_TITLE1;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.IDS_WARN_TITLE1);
			this.BeforeStart1 = Resources.IDS_WARN_BEFORE1;
			this.BeforeStart2 = Resources.IDS_WARN_BEFORE2;
			this.BeforeStart3 = Resources.IDS_WARN_BEFORE3;
			this.BeforeStart4 = Resources.IDS_WARN_BEFORE4;
			if (this._canTransferApps)
			{
				this.Description = Resources.IDS_WARN_TITLE_DESC1;
				this.Limitation1 = Resources.IDS_WARN_LIMITS1;
				this.Limitation2 = Resources.IDS_WARN_LIMITS2;
				this.Limitation3 = Resources.IDS_WARN_LIMITS3;
				this.Limitation4 = Resources.IDS_WARN_LIMITS_CLOUD;
				return;
			}
			this.Description = Resources.IDS_WARN_TITLE_DESC2;
			this.Limitation1 = Resources.IDS_WARN_LIMITS1_NOAPP;
			this.Limitation2 = Resources.IDS_WARN_LIMITS_CLOUD;
			this.Limitation3 = string.Empty;
			this.Limitation4 = string.Empty;
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x040004A6 RID: 1190
		private readonly IRegionManager regionManager;

		// Token: 0x040004A7 RID: 1191
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040004A8 RID: 1192
		private NavigationContext navigationContext;

		// Token: 0x040004A9 RID: 1193
		private readonly DefaultPolicy policy;

		// Token: 0x040004AA RID: 1194
		private readonly LlTraceSource _ts;

		// Token: 0x040004AB RID: 1195
		private readonly bool _canTransferApps;

		// Token: 0x040004AC RID: 1196
		private string backPage = "WelcomePage";

		// Token: 0x040004AD RID: 1197
		private MigrationTypeOption optionSelected = MigrationTypeOption.Nothing;

		// Token: 0x040004AE RID: 1198
		private string _Title;

		// Token: 0x040004AF RID: 1199
		private string _Description;

		// Token: 0x040004B0 RID: 1200
		private string _BeforeStart1;

		// Token: 0x040004B1 RID: 1201
		private string _BeforeStart2;

		// Token: 0x040004B2 RID: 1202
		private string _BeforeStart3;

		// Token: 0x040004B3 RID: 1203
		private string _BeforeStart4;

		// Token: 0x040004B4 RID: 1204
		private string _Limitation1;

		// Token: 0x040004B5 RID: 1205
		private string _Limitation2;

		// Token: 0x040004B6 RID: 1206
		private string _Limitation3;

		// Token: 0x040004B7 RID: 1207
		private string _Limitation4;

		// Token: 0x040004B8 RID: 1208
		private bool _IsChecked;
	}
}
