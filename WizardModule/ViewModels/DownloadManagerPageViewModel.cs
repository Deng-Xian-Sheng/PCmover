using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Laplink.Download.Contracts;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000080 RID: 128
	public class DownloadManagerPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x00011464 File Offset: 0x0000F664
		private LlTraceSource Ts { get; }

		// Token: 0x060007AB RID: 1963 RVA: 0x0001146C File Offset: 0x0000F66C
		public DownloadManagerPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.policy = policy;
			this.Ts = ts;
			this.OnFinish = new DelegateCommand(new Action(this.OnFinishCommand), new Func<bool>(this.CanOnFinishCommand));
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnCancel = new DelegateCommand<string>(new Action<string>(this.OnCancelCommand), new Func<string, bool>(this.CanOnCancelCommand));
			this.OnProceed = new DelegateCommand(new Action(this.OnProceedCommand), new Func<bool>(this.CanOnProceedCommand));
			this.OnResume = new DelegateCommand(new Action(this.OnResumeCommand), new Func<bool>(this.CanOnResumeCommand));
			this.OnRebootNow = new DelegateCommand(new Action(this.OnRebootNowCommand), new Func<bool>(this.CanOnRebootNowCommand));
			eventAggregator.GetEvent<DownloadManagerEvents.PackageUpdatedEvent>().Subscribe(new Action<DownloadPackage>(this.OnPackageChanged), ThreadOption.UIThread);
			eventAggregator.GetEvent<DownloadManagerEvents.DownloadManagerCompletedEvent>().Subscribe(new Action<bool>(this.OnCompleted), ThreadOption.UIThread);
			eventAggregator.GetEvent<DownloadManagerEvents.DownloadManagerRebootRequiredEvent>().Subscribe(new Action(this.OnRebootRequired), ThreadOption.UIThread);
			eventAggregator.GetEvent<DownloadManagerEvents.DownloadManagerDisplayErrorEvent>().Subscribe(new Action<IEnumerable<string>>(this.OnDisplayError), ThreadOption.UIThread);
			eventAggregator.GetEvent<Events.EngineInitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnEngineInitialized));
			if (migration.LaunchDownloadManager)
			{
				eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_DownloadManagerPage);
				this._Reboot = false;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x00011618 File Offset: 0x0000F818
		// (set) Token: 0x060007AD RID: 1965 RVA: 0x00011620 File Offset: 0x0000F820
		public ObservableCollection<DownloadPackage> Packages
		{
			get
			{
				return this._Packages;
			}
			private set
			{
				this.SetProperty<ObservableCollection<DownloadPackage>>(ref this._Packages, value, "Packages");
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00011635 File Offset: 0x0000F835
		// (set) Token: 0x060007AF RID: 1967 RVA: 0x0001163D File Offset: 0x0000F83D
		public bool IsComplete
		{
			get
			{
				return this._IsComplete;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsComplete, value, "IsComplete");
				this.OnFinish.RaiseCanExecuteChanged();
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x00011668 File Offset: 0x0000F868
		// (set) Token: 0x060007B1 RID: 1969 RVA: 0x00011670 File Offset: 0x0000F870
		public bool IsCancelWarningPopupOpen
		{
			get
			{
				return this._IsCancelWarningPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCancelWarningPopupOpen, value, "IsCancelWarningPopupOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x00011696 File Offset: 0x0000F896
		// (set) Token: 0x060007B3 RID: 1971 RVA: 0x0001169E File Offset: 0x0000F89E
		public bool Acknowledged
		{
			get
			{
				return this._Acknowledged;
			}
			set
			{
				this.SetProperty<bool>(ref this._Acknowledged, value, "Acknowledged");
				this.OnProceed.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x000116BE File Offset: 0x0000F8BE
		// (set) Token: 0x060007B5 RID: 1973 RVA: 0x000116C6 File Offset: 0x0000F8C6
		public bool IsNextVisible
		{
			get
			{
				return this._IsNextVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsNextVisible, value, "IsNextVisible");
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x000116DB File Offset: 0x0000F8DB
		// (set) Token: 0x060007B7 RID: 1975 RVA: 0x000116E3 File Offset: 0x0000F8E3
		public bool IsRebootInProgress
		{
			get
			{
				return this._IsRebootInProgress;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsRebootInProgress, value, "IsRebootInProgress");
				if (this._IsRebootInProgress)
				{
					this.IsRebootPending = false;
				}
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x00011707 File Offset: 0x0000F907
		// (set) Token: 0x060007B9 RID: 1977 RVA: 0x0001170F File Offset: 0x0000F90F
		public bool IsRebootPending
		{
			get
			{
				return this._IsRebootPending;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsRebootPending, value, "IsRebootPending");
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x00011724 File Offset: 0x0000F924
		// (set) Token: 0x060007BB RID: 1979 RVA: 0x0001172C File Offset: 0x0000F92C
		public DelegateCommand OnFinish { get; private set; }

		// Token: 0x060007BC RID: 1980 RVA: 0x00011735 File Offset: 0x0000F935
		private bool CanOnFinishCommand()
		{
			return this.IsComplete;
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00011740 File Offset: 0x0000F940
		private void OnFinishCommand()
		{
			DownloadManagerPageViewModel.<OnFinishCommand>d__45 <OnFinishCommand>d__;
			<OnFinishCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnFinishCommand>d__.<>4__this = this;
			<OnFinishCommand>d__.<>1__state = -1;
			<OnFinishCommand>d__.<>t__builder.Start<DownloadManagerPageViewModel.<OnFinishCommand>d__45>(ref <OnFinishCommand>d__);
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x00011777 File Offset: 0x0000F977
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x0001177F File Offset: 0x0000F97F
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060007C0 RID: 1984 RVA: 0x00011735 File Offset: 0x0000F935
		private bool CanOnNextCommand()
		{
			return this.IsComplete;
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00011788 File Offset: 0x0000F988
		private void OnNextCommand()
		{
			if (this._PackageCancelled)
			{
				this.IsCancelWarningPopupOpen = true;
				return;
			}
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("IsPartial", this._IsPartialMigration);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferCompletePage", UriKind.Relative), navigationParameters);
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x000117DD File Offset: 0x0000F9DD
		// (set) Token: 0x060007C3 RID: 1987 RVA: 0x000117E5 File Offset: 0x0000F9E5
		public DelegateCommand<string> OnCancel { get; private set; }

		// Token: 0x060007C4 RID: 1988 RVA: 0x000117F0 File Offset: 0x0000F9F0
		private bool CanOnCancelCommand(string Id)
		{
			DownloadPackage downloadPackage = this.Packages.FirstOrDefault((DownloadPackage x) => x.Id == Id);
			return downloadPackage != null && (downloadPackage.State != PackageState.Cancelled && downloadPackage.State != PackageState.Complete && downloadPackage.State != PackageState.Error && downloadPackage.State != PackageState.Fail) && downloadPackage.State != PackageState.Installing;
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00011859 File Offset: 0x0000FA59
		private void OnCancelCommand(string Id)
		{
			Action <>9__1;
			Task.Run(delegate()
			{
				IPCmoverEngine pcmoverEngine = this.pcmoverEngine;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this._DlMgr.CancelPackage(Id);
						this._PackageCancelled = true;
					});
				}
				pcmoverEngine.CatchCommEx(func, "OnCancelCommand");
			});
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0001187F File Offset: 0x0000FA7F
		// (set) Token: 0x060007C7 RID: 1991 RVA: 0x00011887 File Offset: 0x0000FA87
		public DelegateCommand OnProceed { get; private set; }

		// Token: 0x060007C8 RID: 1992 RVA: 0x00011890 File Offset: 0x0000FA90
		private bool CanOnProceedCommand()
		{
			return this.Acknowledged;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00011898 File Offset: 0x0000FA98
		private void OnProceedCommand()
		{
			DownloadManagerPageViewModel.<OnProceedCommand>d__63 <OnProceedCommand>d__;
			<OnProceedCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnProceedCommand>d__.<>4__this = this;
			<OnProceedCommand>d__.<>1__state = -1;
			<OnProceedCommand>d__.<>t__builder.Start<DownloadManagerPageViewModel.<OnProceedCommand>d__63>(ref <OnProceedCommand>d__);
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x000118CF File Offset: 0x0000FACF
		// (set) Token: 0x060007CB RID: 1995 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public DelegateCommand OnResume { get; private set; }

		// Token: 0x060007CC RID: 1996 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnResumeCommand()
		{
			return true;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x000118E0 File Offset: 0x0000FAE0
		private void OnResumeCommand()
		{
			this.IsCancelWarningPopupOpen = false;
			this.IsComplete = false;
			this._PackageCancelled = false;
			Task.Run(delegate()
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.Packages = this._DlMgr.GetDownloadPackages();
					this._DlMgr.ProcessAll();
				}, "OnResumeCommand");
			});
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x00011909 File Offset: 0x0000FB09
		// (set) Token: 0x060007CF RID: 1999 RVA: 0x00011911 File Offset: 0x0000FB11
		public DelegateCommand OnRebootNow { get; private set; }

		// Token: 0x060007D0 RID: 2000 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnRebootNowCommand()
		{
			return true;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001191A File Offset: 0x0000FB1A
		private void OnRebootNowCommand()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.Reboot(1000U);
			}, "OnRebootNowCommand");
			this.IsRebootInProgress = true;
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x00011940 File Offset: 0x0000FB40
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.DownloadManager);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_DownloadManagerPage);
			this.eventAggregator.GetEvent<Events.ShowSSLIcon>().Publish(false);
			this.IsComplete = false;
			this.IsNextVisible = true;
			Action <>9__1;
			Task.Run(delegate()
			{
				IPCmoverEngine pcmoverEngine = this.pcmoverEngine;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this._DlMgr = this.pcmoverEngine.GetDownloadManager();
						if (this.pcmoverEngine.IsResuming)
						{
							FinishTransferData finishTransferData = this.pcmoverEngine.PerformPostTransferActions(false);
							this._DlMgr.SetDataFile((finishTransferData != null) ? finishTransferData.Arguments : null);
							this._IsPartialMigration = Convert.ToBoolean(this.pcmoverEngine.GetControllerProperty(ControllerProperties.IsPartialMigration));
							this.pcmoverEngine.IsResuming = false;
							this.migrationDefinition.IsResuming = false;
						}
						else if (navigationContext.Parameters != null)
						{
							IDownloadControl dlMgr = this._DlMgr;
							NavigationParameters parameters = navigationContext.Parameters;
							dlMgr.SetDataFile((string)((parameters != null) ? parameters["DataFile"] : null));
							DownloadManagerPageViewModel <>4__this = this;
							NavigationParameters parameters2 = navigationContext.Parameters;
							<>4__this._IsPartialMigration = (bool)((parameters2 != null) ? parameters2["IsPartial"] : null);
						}
						this.Packages = this._DlMgr.GetDownloadPackages();
						ObservableCollection<DownloadPackage> packages = this.Packages;
						if (packages != null && packages.Count > 0)
						{
							this._DlMgr.ProcessAll();
							this.SetRunKey();
							return;
						}
						this.IsComplete = true;
					});
				}
				pcmoverEngine.CatchCommEx(func, "OnNavigatedTo");
			});
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000119B6 File Offset: 0x0000FBB6
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.policy.WriteProfile();
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000119C4 File Offset: 0x0000FBC4
		private void OnRebootRequired()
		{
			DownloadManagerPageViewModel.<OnRebootRequired>d__79 <OnRebootRequired>d__;
			<OnRebootRequired>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnRebootRequired>d__.<>4__this = this;
			<OnRebootRequired>d__.<>1__state = -1;
			<OnRebootRequired>d__.<>t__builder.Start<DownloadManagerPageViewModel.<OnRebootRequired>d__79>(ref <OnRebootRequired>d__);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000119FC File Offset: 0x0000FBFC
		private void OnEngineReinitialized(PcmoverServiceData data)
		{
			this.IsRebootInProgress = false;
			this.IsRebootPending = false;
			this.eventAggregator.GetEvent<Events.EngineReinitializedEvent>().Unsubscribe(new Action<PcmoverServiceData>(this.OnEngineReinitialized));
			if (data == null)
			{
				WPFMessageBox.ShowDialogAsyncNoSuppress(this.container, this.eventAggregator, Resources.DMP_ReinitializationFailed, Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None);
				return;
			}
			Task.Run(delegate()
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this._DlMgr = base.pcmoverEngine.GetDownloadManager();
					this.Packages = this._DlMgr.GetDownloadPackages();
					ObservableCollection<DownloadPackage> packages = this.Packages;
					if (packages != null && packages.Count > 0)
					{
						this._DlMgr.ProcessAll();
						return;
					}
					this.IsComplete = true;
				}, "OnEngineReinitialized");
			});
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00011A68 File Offset: 0x0000FC68
		private void OnCompleted(bool restart)
		{
			this._Reboot = restart;
			this.IsComplete = true;
			this.SetRunKey();
			if (base.pcmoverEngine.IsRemoteUI && this._Reboot)
			{
				ObservableCollection<DownloadPackage> packages = this.Packages;
				bool flag;
				if (packages == null)
				{
					flag = false;
				}
				else
				{
					flag = ((from x in packages
					where x.State == PackageState.Error
					select x).Count<DownloadPackage>() > 0);
				}
				if (flag)
				{
					this.OnRebootRequired();
					return;
				}
			}
			if ((!this.policy.downloadManagerPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy) && this.CanOnNextCommand())
			{
				this.OnNextCommand();
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00011B10 File Offset: 0x0000FD10
		private void OnPackageChanged(DownloadPackage obj)
		{
			ObservableCollection<DownloadPackage> packages = this.Packages;
			DownloadPackage downloadPackage = (packages != null) ? packages.FirstOrDefault((DownloadPackage x) => x.Id == obj.Id) : null;
			if (downloadPackage != null)
			{
				int index = this.Packages.IndexOf(downloadPackage);
				this.Packages[index] = obj;
				this.OnCancel.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00011B76 File Offset: 0x0000FD76
		private void ShutdownApp(Events.TransferStateEnum transferState)
		{
			this.eventAggregator.GetEvent<Events.CloseConfirmationRequiredChanged>().Publish(false);
			this.eventAggregator.GetEvent<Events.ProcessShutdownRequest>().Publish(new Events.ShutdownEventArgs(transferState));
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00011BA0 File Offset: 0x0000FDA0
		private void OnDisplayError(IEnumerable<string> FailedPackages)
		{
			DownloadManagerPageViewModel.<OnDisplayError>d__84 <OnDisplayError>d__;
			<OnDisplayError>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnDisplayError>d__.<>4__this = this;
			<OnDisplayError>d__.FailedPackages = FailedPackages;
			<OnDisplayError>d__.<>1__state = -1;
			<OnDisplayError>d__.<>t__builder.Start<DownloadManagerPageViewModel.<OnDisplayError>d__84>(ref <OnDisplayError>d__);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00011BDF File Offset: 0x0000FDDF
		private void OnEngineInitialized(PcmoverServiceData serviceData)
		{
			if (this.migrationDefinition.LaunchDownloadManager)
			{
				if (serviceData != null && serviceData.IsIdle)
				{
					base.pcmoverEngine.CatchCommEx(delegate
					{
						this._DlMgr = base.pcmoverEngine.GetDownloadManager();
						Task.Run(delegate()
						{
							base.pcmoverEngine.CatchCommEx(delegate
							{
								this.Packages = this._DlMgr.GetDownloadPackages();
								ObservableCollection<DownloadPackage> packages = this.Packages;
								if (packages != null && packages.Count > 0)
								{
									this._DlMgr.ProcessAll();
									this.SetRunKey();
									return;
								}
								this.IsComplete = true;
							}, "OnEngineInitialized");
						});
					}, "OnEngineInitialized");
					return;
				}
				this.IsComplete = true;
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00011C20 File Offset: 0x0000FE20
		private void SetRunKey()
		{
			if (base.pcmoverEngine.IsRemoteUI)
			{
				return;
			}
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			string value = "\"" + entryAssembly.Location + "\" /DownloadManager";
			ObservableCollection<DownloadPackage> packages = this.Packages;
			bool flag;
			if (packages == null)
			{
				flag = false;
			}
			else
			{
				flag = ((from x in packages
				where x.State == PackageState.Error
				select x).Count<DownloadPackage>() > 0);
			}
			if (!flag)
			{
				ObservableCollection<DownloadPackage> packages2 = this.Packages;
				bool flag2;
				if (packages2 == null)
				{
					flag2 = false;
				}
				else
				{
					flag2 = ((from x in packages2
					where x.State == PackageState.WaitingToInstall
					select x).Count<DownloadPackage>() > 0);
				}
				if (!flag2)
				{
					ObservableCollection<DownloadPackage> packages3 = this.Packages;
					bool flag3;
					if (packages3 == null)
					{
						flag3 = false;
					}
					else
					{
						flag3 = ((from x in packages3
						where x.State == PackageState.DownloadComplete
						select x).Count<DownloadPackage>() > 0);
					}
					if (!flag3)
					{
						ObservableCollection<DownloadPackage> packages4 = this.Packages;
						bool flag4;
						if (packages4 == null)
						{
							flag4 = false;
						}
						else
						{
							flag4 = ((from x in packages4
							where x.State == PackageState.Downloading
							select x).Count<DownloadPackage>() > 0);
						}
						if (!flag4)
						{
							ObservableCollection<DownloadPackage> packages5 = this.Packages;
							bool flag5;
							if (packages5 == null)
							{
								flag5 = false;
							}
							else
							{
								flag5 = ((from x in packages5
								where x.State == PackageState.Installing
								select x).Count<DownloadPackage>() > 0);
							}
							if (!flag5)
							{
								ObservableCollection<DownloadPackage> packages6 = this.Packages;
								bool flag6;
								if (packages6 == null)
								{
									flag6 = false;
								}
								else
								{
									flag6 = ((from x in packages6
									where x.State == PackageState.Ready
									select x).Count<DownloadPackage>() > 0);
								}
								if (!flag6)
								{
									IDownloadControl dlMgr = this._DlMgr;
									if (dlMgr == null)
									{
										return;
									}
									dlMgr.UpdateRunKey("PCmoverConfigurationManager", value, true);
									return;
								}
							}
						}
					}
				}
			}
			IDownloadControl dlMgr2 = this._DlMgr;
			if (dlMgr2 == null)
			{
				return;
			}
			dlMgr2.UpdateRunKey("PCmoverConfigurationManager", value, false);
		}

		// Token: 0x0400020B RID: 523
		private readonly IRegionManager regionManager;

		// Token: 0x0400020C RID: 524
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x0400020D RID: 525
		private bool _Reboot;

		// Token: 0x0400020E RID: 526
		private IDownloadControl _DlMgr;

		// Token: 0x0400020F RID: 527
		private bool _PackageCancelled;

		// Token: 0x04000210 RID: 528
		private bool _IsPartialMigration;

		// Token: 0x04000211 RID: 529
		private DefaultPolicy policy;

		// Token: 0x04000212 RID: 530
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000214 RID: 532
		private ObservableCollection<DownloadPackage> _Packages;

		// Token: 0x04000215 RID: 533
		private bool _IsComplete;

		// Token: 0x04000216 RID: 534
		private bool _IsCancelWarningPopupOpen;

		// Token: 0x04000217 RID: 535
		private bool _Acknowledged;

		// Token: 0x04000218 RID: 536
		private bool _IsNextVisible;

		// Token: 0x04000219 RID: 537
		private bool _IsRebootInProgress;

		// Token: 0x0400021A RID: 538
		private bool _IsRebootPending;
	}
}
