using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;
using WizardModule.Views.Dialogs;

namespace WizardModule.ViewModels
{
	// Token: 0x02000093 RID: 147
	public class SelectImagePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000C14 RID: 3092 RVA: 0x0001F850 File Offset: 0x0001DA50
		public SelectImagePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnBrowseSingle = new DelegateCommand(new Action(this.OnBrowseSingleCommand), new Func<bool>(this.CanOnBrowseSingleCommand));
			this.OnDriveDeleted = new DelegateCommand<ImageFolderMapping>(new Action<ImageFolderMapping>(this.OnDriveDeletedCommand), new Func<ImageFolderMapping, bool>(this.CanOnDriveDeletedCommand));
			this.OnAddMultiple = new DelegateCommand(new Action(this.OnAddMultipleCommand), new Func<bool>(this.CanOnAddMultipleCommand));
			this.OnInfoButton = new DelegateCommand(new Action(this.OnInfoButtonCommand), new Func<bool>(this.CanOnInfoButtonCommand));
			this.SingleDrive = string.Empty;
			this.SingleSelected = true;
			this.FolderMappings = new ObservableCollection<ImageFolderMapping>();
		}

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x0001F97D File Offset: 0x0001DB7D
		// (set) Token: 0x06000C16 RID: 3094 RVA: 0x0001F985 File Offset: 0x0001DB85
		public string SingleDrive
		{
			get
			{
				return this._SingleDrive;
			}
			set
			{
				this.SetProperty<string>(ref this._SingleDrive, value, "SingleDrive");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x0001F9A5 File Offset: 0x0001DBA5
		// (set) Token: 0x06000C18 RID: 3096 RVA: 0x0001F9AD File Offset: 0x0001DBAD
		public bool SingleSelected
		{
			get
			{
				return this._SingleSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._SingleSelected, value, "SingleSelected");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x0001F9CD File Offset: 0x0001DBCD
		// (set) Token: 0x06000C1A RID: 3098 RVA: 0x0001F9D5 File Offset: 0x0001DBD5
		public bool ShowMultipleMappings
		{
			get
			{
				return this._ShowMultipleMappings;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowMultipleMappings, value, "ShowMultipleMappings");
			}
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06000C1B RID: 3099 RVA: 0x0001F9EA File Offset: 0x0001DBEA
		// (set) Token: 0x06000C1C RID: 3100 RVA: 0x0001F9F2 File Offset: 0x0001DBF2
		public ObservableCollection<ImageFolderMapping> FolderMappings
		{
			get
			{
				return this._FolderMappings;
			}
			set
			{
				this.SetProperty<ObservableCollection<ImageFolderMapping>>(ref this._FolderMappings, value, "FolderMappings");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06000C1D RID: 3101 RVA: 0x0001FA12 File Offset: 0x0001DC12
		// (set) Token: 0x06000C1E RID: 3102 RVA: 0x0001FA1A File Offset: 0x0001DC1A
		public DelegateCommand OnAddMultiple { get; private set; }

		// Token: 0x06000C1F RID: 3103 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnAddMultipleCommand()
		{
			return true;
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0001FA24 File Offset: 0x0001DC24
		private void OnAddMultipleCommand()
		{
			Events.OverlayPopupResolveArgs payload = new Events.OverlayPopupResolveArgs
			{
				Title = Resources.SIP_AddDrivesTitle,
				Parameter = new ImageFolderMapping(),
				Type = typeof(AddImageAssistMapping),
				PopupResultCallback = new Action<object>(this.OnCloseAddMultiple)
			};
			this.eventAggregator.GetEvent<Events.ShowOverlayPopupResolve>().Publish(payload);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0001FA80 File Offset: 0x0001DC80
		private void OnCloseAddMultiple(object obj)
		{
			if (obj != null)
			{
				ImageFolderMapping mapping = (ImageFolderMapping)obj;
				try
				{
					if (this.FolderMappings.FirstOrDefault((ImageFolderMapping x) => x.VStr == mapping.VStr) != null)
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, string.Format(Resources.SIP_MapAlreadyExists, mapping.VStr), Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.Exclamation, MessageBoxResult.None).ConfigureAwait(false);
						return;
					}
				}
				catch (Exception)
				{
				}
				this.FolderMappings.Add(mapping);
			}
			this.OnNext.RaiseCanExecuteChanged();
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x0001FB24 File Offset: 0x0001DD24
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x0001FB2C File Offset: 0x0001DD2C
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000C24 RID: 3108 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0001FB35 File Offset: 0x0001DD35
		private void OnBackCommand()
		{
			this.migrationDefinition.ImageAssistData = null;
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x0001FB4F File Offset: 0x0001DD4F
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x0001FB57 File Offset: 0x0001DD57
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000C28 RID: 3112 RVA: 0x0001FB60 File Offset: 0x0001DD60
		private bool CanOnNextCommand()
		{
			if (!this.SingleSelected)
			{
				return this.FolderMappings.Count > 0;
			}
			string singleDrive = this.SingleDrive;
			return singleDrive != null && singleDrive.Length > 0;
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0001FB90 File Offset: 0x0001DD90
		private void OnNextCommand()
		{
			if (this.SingleSelected)
			{
				if (this.SingleDrive.Length == 1 && Regex.IsMatch(this.SingleDrive, "^[a-zA-Z]+$"))
				{
					this.SingleDrive += ":";
				}
				if (this.SingleDrive.EndsWith(":"))
				{
					this.SingleDrive += "\\";
				}
				this.FolderMappings.Clear();
				this.FolderMappings.Add(new ImageFolderMapping
				{
					PStr = this.SingleDrive,
					VStr = "C:\\"
				});
			}
			else
			{
				this.SingleDrive = string.Empty;
			}
			this.policy.enginePolicy.MigType.Image.DiskMapping = new ObservableCollection<EnginePolicy.VirtualToPhysical>();
			foreach (ImageFolderMapping mapping in this.FolderMappings)
			{
				this.policy.enginePolicy.MigType.Image.DiskMapping.Add(new EnginePolicy.VirtualToPhysical(mapping));
			}
			this.migrationDefinition.ImageAssistData = new ImageMapData
			{
				ImageName = base.pcmoverEngine.Policy.MigrationType.Image.ImageName,
				WinDir = base.pcmoverEngine.Policy.MigrationType.Image.WinDir,
				Folders = this.FolderMappings.ToList<ImageFolderMapping>()
			};
			string drives = string.Empty;
			foreach (ImageFolderMapping imageFolderMapping in this.FolderMappings)
			{
				drives = string.Concat(new string[]
				{
					drives,
					imageFolderMapping.VStr,
					",",
					imageFolderMapping.PStr,
					";"
				});
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.SetControllerProperty(ControllerProperties.ImageDrives, drives);
			}, "OnNextCommand");
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (string.IsNullOrWhiteSpace(this.pcmoverEngine.License.SerialNumber))
				{
					NavigationParameters navigationParameters = new NavigationParameters();
					navigationParameters.Add("NextPage", "AnalyzePCPage");
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LicensePage", UriKind.Relative), navigationParameters);
					return;
				}
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("AnalyzePCPage", UriKind.Relative));
			}, "OnNextCommand");
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x0001FDE8 File Offset: 0x0001DFE8
		// (set) Token: 0x06000C2B RID: 3115 RVA: 0x0001FDF0 File Offset: 0x0001DFF0
		public DelegateCommand OnBrowseSingle { get; private set; }

		// Token: 0x06000C2C RID: 3116 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBrowseSingleCommand()
		{
			return true;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0001FDF9 File Offset: 0x0001DFF9
		private void OnBrowseSingleCommand()
		{
			this.ShowFolderDialog();
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06000C2E RID: 3118 RVA: 0x0001FE01 File Offset: 0x0001E001
		// (set) Token: 0x06000C2F RID: 3119 RVA: 0x0001FE09 File Offset: 0x0001E009
		public DelegateCommand<ImageFolderMapping> OnDriveDeleted { get; private set; }

		// Token: 0x06000C30 RID: 3120 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDriveDeletedCommand(ImageFolderMapping arg)
		{
			return true;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0001FE12 File Offset: 0x0001E012
		private void OnDriveDeletedCommand(ImageFolderMapping arg)
		{
			if (this.FolderMappings.Contains(arg))
			{
				this.FolderMappings.Remove(arg);
			}
			this.OnNext.RaiseCanExecuteChanged();
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x0001FE3A File Offset: 0x0001E03A
		// (set) Token: 0x06000C33 RID: 3123 RVA: 0x0001FE42 File Offset: 0x0001E042
		public DelegateCommand OnInfoButton { get; private set; }

		// Token: 0x06000C34 RID: 3124 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnInfoButtonCommand()
		{
			return true;
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0001FE4B File Offset: 0x0001E04B
		private void OnInfoButtonCommand()
		{
			WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SIP_Info, Resources.AOIAD_Header, PopupEvents.MBType.MB_OK, MessageBoxImage.Asterisk, MessageBoxResult.None).ConfigureAwait(false);
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0001FE74 File Offset: 0x0001E074
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !base.pcmoverEngine.Policy.Interactive.ImageTransfer)
			{
				this.OnBack.Execute();
				return;
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.SelectImage);
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_SelectImagePage);
				this.migrationDefinition.MigrationType = TransferMethodType.Image;
				this.migrationDefinition.PCName2 = base.pcmoverEngine.ThisMachine.FriendlyName;
				this.FolderMappings = new ObservableCollection<ImageFolderMapping>(base.pcmoverEngine.Policy.MigrationType.Image.Folders);
				if (this.FolderMappings.Any<ImageFolderMapping>())
				{
					if (this.FolderMappings.Count == 1 && this.FolderMappings[0].IsDriveC)
					{
						this.SingleSelected = true;
						this.SingleDrive = this.FolderMappings[0].PStr;
					}
					else
					{
						this.SingleSelected = false;
						this.SingleDrive = string.Empty;
					}
				}
				else
				{
					this.SingleSelected = true;
					this.SingleDrive = string.Empty;
				}
				if (this.migrationDefinition.IsResuming)
				{
					this.Resume();
					return;
				}
				if (this.CanOnNextCommand() && (!base.pcmoverEngine.Policy.Interactive.ImageTransfer || this._navigationHelper.IsPlayingBackRecordedPolicy))
				{
					this.OnNext.Execute();
				}
			}, "OnNavigatedTo");
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x0001FECE File Offset: 0x0001E0CE
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.policy.WriteProfile();
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0001FEDB File Offset: 0x0001E0DB
		private void ShowFolderDialog()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				Events.OverlayPopupResolveArgs payload = new Events.OverlayPopupResolveArgs
				{
					Title = Resources.SIP_BrowseTitle,
					Parameter = base.pcmoverEngine.GetMachineDriveInfo(),
					Type = typeof(IABrowse),
					PopupResultCallback = new Action<object>(this.OnCloseBrowseIA)
				};
				this.eventAggregator.GetEvent<Events.ShowOverlayPopupResolve>().Publish(payload);
			}, "ShowFolderDialog");
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0001FEFA File Offset: 0x0001E0FA
		private void OnCloseBrowseIA(object obj)
		{
			this.SingleDrive = (string)obj;
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0001FF08 File Offset: 0x0001E108
		private void Resume()
		{
			string drives = string.Empty;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				drives = this.pcmoverEngine.GetControllerProperty(ControllerProperties.ImageDrives);
			}, "Resume");
			string[] array = drives.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 1)
			{
				string drives2 = drives;
				this.SingleDrive = ((drives2 != null) ? drives2.Substring(drives.IndexOf(",") + 1).Replace(";", string.Empty) : null);
			}
			else
			{
				this.FolderMappings = new ObservableCollection<ImageFolderMapping>();
				foreach (string text in array)
				{
				}
			}
			PcmoverTransferState.TransferStep step = this.migrationDefinition.ServiceData.Step;
			if (step != PcmoverTransferState.TransferStep.NotStarted)
			{
				if (step == PcmoverTransferState.TransferStep.Downloading)
				{
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("DownloadManagerPage", UriKind.Relative));
					return;
				}
				this.OnNext.Execute();
			}
		}

		// Token: 0x040003DB RID: 987
		private readonly IRegionManager regionManager;

		// Token: 0x040003DC RID: 988
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040003DD RID: 989
		private readonly DefaultPolicy policy;

		// Token: 0x040003DE RID: 990
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x040003DF RID: 991
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040003E0 RID: 992
		private string _SingleDrive;

		// Token: 0x040003E1 RID: 993
		private bool _SingleSelected;

		// Token: 0x040003E2 RID: 994
		private bool _ShowMultipleMappings;

		// Token: 0x040003E3 RID: 995
		private ObservableCollection<ImageFolderMapping> _FolderMappings;
	}
}
