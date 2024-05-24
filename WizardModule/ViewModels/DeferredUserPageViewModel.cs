using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.ServiceModel;
using System.Windows;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200007D RID: 125
	public class DeferredUserPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060006FB RID: 1787 RVA: 0x0000FCC0 File Offset: 0x0000DEC0
		public DeferredUserPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, DefaultPolicy policy, LlTraceSource ts) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.policy = policy;
			this.ShowWelcome = true;
			this.CanCancel = true;
			this.Ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
			this.OnPostpone = new DelegateCommand(new Action(this.OnPostponeCommand), new Func<bool>(this.CanOnPostponeCommand));
			eventAggregator.GetEvent<Events.EngineInitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnEngineInitialized), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.ThisMachineAppInventoryCompleteEvent>().Subscribe(new Action(this.OnAppInventoryComplete), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Subscribe(new Action<TransferProgressInfo>(this.OnProgressChanged), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.TransferComplete>().Subscribe(new Action<TransferCompleteInfo>(this.OnTransferComplete), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.AuthorizationError>().Subscribe(new Action<Events.AuthorizationErrorEventArgs>(this.OnAuthorizationErrorAsync), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.ConfirmUserMatches>().Subscribe(delegate(Action O)
			{
				if (O != null)
				{
					O();
				}
			}, ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.DisplayDriveMap>().Subscribe(delegate(Action O)
			{
				if (O != null)
				{
					O();
				}
			}, ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.AssignMissingPassword>().Subscribe(delegate(Events.MissingPasswordEventArgs O)
			{
				if (O != null)
				{
					Action resumeAction = O.ResumeAction;
					if (resumeAction == null)
					{
						return;
					}
					resumeAction();
				}
			}, ThreadOption.UIThread);
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x0000FE67 File Offset: 0x0000E067
		// (set) Token: 0x060006FD RID: 1789 RVA: 0x0000FE6F File Offset: 0x0000E06F
		public bool ShowWelcome
		{
			get
			{
				return this._ShowWelcome;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowWelcome, value, "ShowWelcome");
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x0000FE84 File Offset: 0x0000E084
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x0000FE8C File Offset: 0x0000E08C
		public bool ShowInventory
		{
			get
			{
				return this._ShowInventory;
			}
			set
			{
				if (value)
				{
					this.ShowWelcome = false;
					this.ShowProgress = false;
				}
				this.SetProperty<bool>(ref this._ShowInventory, value, "ShowInventory");
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x0000FEB2 File Offset: 0x0000E0B2
		// (set) Token: 0x06000701 RID: 1793 RVA: 0x0000FEBA File Offset: 0x0000E0BA
		public bool ShowProgress
		{
			get
			{
				return this._ShowProgress;
			}
			set
			{
				if (value)
				{
					this.ShowWelcome = false;
					this.ShowInventory = false;
				}
				this.SetProperty<bool>(ref this._ShowProgress, value, "ShowProgress");
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x0000FEE0 File Offset: 0x0000E0E0
		// (set) Token: 0x06000703 RID: 1795 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
		public double Progress
		{
			get
			{
				return this._Progress;
			}
			set
			{
				this.SetProperty<double>(ref this._Progress, value, "Progress");
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x0000FEFD File Offset: 0x0000E0FD
		// (set) Token: 0x06000705 RID: 1797 RVA: 0x0000FF05 File Offset: 0x0000E105
		public bool CanCancel
		{
			get
			{
				return this._CanCancel;
			}
			set
			{
				this.SetProperty<bool>(ref this._CanCancel, value, "CanCancel");
				DelegateCommand onPostpone = this.OnPostpone;
				if (onPostpone != null)
				{
					onPostpone.RaiseCanExecuteChanged();
				}
				DelegateCommand onCancel = this.OnCancel;
				if (onCancel == null)
				{
					return;
				}
				onCancel.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x0000FF3B File Offset: 0x0000E13B
		private LlTraceSource Ts { get; }

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0000FF43 File Offset: 0x0000E143
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x0000FF4B File Offset: 0x0000E14B
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000709 RID: 1801 RVA: 0x0000FF54 File Offset: 0x0000E154
		private bool CanOnNextCommand()
		{
			return this.isEngineInitialized && !this.nextClicked;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0000FF69 File Offset: 0x0000E169
		private void OnNextCommand()
		{
			this.nextClicked = true;
			this.CanCancel = false;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (base.pcmoverEngine.IsThisMachineAppInventoryComplete)
				{
					IWizardParameters wizardParameters = this.container.Resolve(Array.Empty<ResolverOverride>());
					base.pcmoverEngine.StartTransferMovingVan(wizardParameters.DeferredVan);
					this.Progress = 1.0;
					this.ShowProgress = true;
				}
				else
				{
					this.ShowInventory = true;
					base.pcmoverEngine.ThisMachineAppInventoryRequirement = AppInventoryAmount.Minimum;
				}
				this.OnNext.RaiseCanExecuteChanged();
			}, "OnNextCommand");
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x0000FF96 File Offset: 0x0000E196
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x0000FF9E File Offset: 0x0000E19E
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x0600070D RID: 1805 RVA: 0x0000FFA7 File Offset: 0x0000E1A7
		private bool CanOnCancelCommand()
		{
			return this.CanCancel;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0000FFAF File Offset: 0x0000E1AF
		private void OnCancelCommand()
		{
			this.SetDeferredComplete();
			this.Ts.TraceCaller("Posting shutdown request from DeferredUserPageViewModel", "OnCancelCommand");
			this.eventAggregator.GetEvent<Events.ShutdownEvent>().Publish();
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x0000FFDD File Offset: 0x0000E1DD
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x0000FFE5 File Offset: 0x0000E1E5
		public DelegateCommand OnPostpone { get; private set; }

		// Token: 0x06000711 RID: 1809 RVA: 0x0000FFA7 File Offset: 0x0000E1A7
		private bool CanOnPostponeCommand()
		{
			return this.CanCancel;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0000FFEE File Offset: 0x0000E1EE
		private void OnPostponeCommand()
		{
			this.Ts.TraceCaller("Posting shutdown request from DeferredUserPageViewModel", "OnPostponeCommand");
			this.eventAggregator.GetEvent<Events.ShutdownEvent>().Publish();
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00010018 File Offset: 0x0000E218
		private void OnEngineInitialized(PcmoverServiceData serviceData)
		{
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_DeferredUserPage);
			this.eventAggregator.GetEvent<Events.CloseConfirmationRequiredChanged>().Publish(true);
			this.isEngineInitialized = (serviceData != null && serviceData.IsIdle);
			this.OnNext.RaiseCanExecuteChanged();
			base.pcmoverEngine.Ts.TraceInformation("DeferredUserPageViewModel.OnEngineInitialized: Set ThisMachineIsOld = false");
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.ThisMachineIsOld = false;
			}, "OnEngineInitialized");
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0001009C File Offset: 0x0000E29C
		private void OnAppInventoryComplete()
		{
			if (this.nextClicked)
			{
				this.Progress = 1.0;
				this.ShowProgress = true;
				IWizardParameters p = this.container.Resolve(Array.Empty<ResolverOverride>());
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.pcmoverEngine.StartTransferMovingVan(p.DeferredVan);
				}, "OnAppInventoryComplete");
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00010107 File Offset: 0x0000E307
		private void OnProgressChanged(TransferProgressInfo progress)
		{
			this.Progress = Tools.GetTotalUnloadProgress(this.Progress, progress);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0001011C File Offset: 0x0000E31C
		private void OnTransferComplete(TransferCompleteInfo info)
		{
			if (info.TransferSucceeded)
			{
				if (info.TransferComplete)
				{
					this.Progress = 100.0;
					this.SetDeferredComplete();
					base.pcmoverEngine.TotalTransferSize = info.Stats.Disk.TotalSize + info.Stats.Registry.TotalSize;
					NavigationParameters navigationParameters = new NavigationParameters();
					navigationParameters.Add("IsPartial", false);
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferCompletePage", UriKind.Relative), navigationParameters);
					return;
				}
				string arg = Resources.TEPP_UnknownError;
				TransferProcessResult transferResult = info.TransferResult;
				if (transferResult != TransferProcessResult.UserStop)
				{
					if (transferResult != TransferProcessResult.EofIntentional && transferResult == TransferProcessResult.DiskFull)
					{
						arg = Resources.TEPP_DiskFull;
					}
				}
				else
				{
					arg = Resources.TEPP_UserCancelledTransfer;
				}
				string message = string.Format(Resources.TEPP_TransferInterrupted2, arg);
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, message, Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				return;
			}
			else
			{
				ActivityInfo activityInfo = info.ActivityInfo;
				if (((activityInfo != null) ? new int?(activityInfo.FailureReason) : null).Value == 10)
				{
					return;
				}
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.TEPP_TransferInterrupted1, Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				return;
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00010260 File Offset: 0x0000E460
		private void OnAuthorizationErrorAsync(Events.AuthorizationErrorEventArgs args)
		{
			DeferredUserPageViewModel.<OnAuthorizationErrorAsync>d__50 <OnAuthorizationErrorAsync>d__;
			<OnAuthorizationErrorAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAuthorizationErrorAsync>d__.<>4__this = this;
			<OnAuthorizationErrorAsync>d__.args = args;
			<OnAuthorizationErrorAsync>d__.<>1__state = -1;
			<OnAuthorizationErrorAsync>d__.<>t__builder.Start<DeferredUserPageViewModel.<OnAuthorizationErrorAsync>d__50>(ref <OnAuthorizationErrorAsync>d__);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001029F File Offset: 0x0000E49F
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_DeferredUserPage);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x000102B8 File Offset: 0x0000E4B8
		private bool SetDeferredComplete()
		{
			try
			{
				WindowsIdentity current = WindowsIdentity.GetCurrent();
				try
				{
					if (base.pcmoverEngine.MarkUserDeferredComplete(string.Empty, current.User.Value))
					{
						return true;
					}
				}
				catch (SystemException ex) when (ex is CommunicationException || ex is TimeoutException)
				{
					this.Ts.TraceException(ex, "SetDeferredComplete");
					this.eventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Publish(ex);
					return false;
				}
				catch (Exception ex2)
				{
					this.Ts.TraceException(ex2, "SetDeferredComplete");
				}
				return base.pcmoverEngine.MarkUserDeferredComplete(current.Name, string.Empty);
			}
			catch (SystemException ex3) when (ex3 is CommunicationException || ex3 is TimeoutException)
			{
				this.Ts.TraceException(ex3, "SetDeferredComplete");
				this.eventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Publish(ex3);
			}
			catch (Exception ex4)
			{
				this.Ts.TraceException(ex4, "SetDeferredComplete");
			}
			return false;
		}

		// Token: 0x040001C3 RID: 451
		private readonly IRegionManager regionManager;

		// Token: 0x040001C4 RID: 452
		private bool nextClicked;

		// Token: 0x040001C5 RID: 453
		private bool isEngineInitialized;

		// Token: 0x040001C6 RID: 454
		private DefaultPolicy policy;

		// Token: 0x040001C7 RID: 455
		private bool _ShowWelcome;

		// Token: 0x040001C8 RID: 456
		private bool _ShowInventory;

		// Token: 0x040001C9 RID: 457
		private bool _ShowProgress;

		// Token: 0x040001CA RID: 458
		private double _Progress;

		// Token: 0x040001CB RID: 459
		private bool _CanCancel;
	}
}
