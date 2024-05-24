using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Laplink.Pcmover.Contracts;
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
	// Token: 0x02000090 RID: 144
	public class SectionDocumentsViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000B87 RID: 2951 RVA: 0x0001CF2C File Offset: 0x0001B12C
		public SectionDocumentsViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this.OnFolderSelectedChanged = new DelegateCommand<FolderDetail>(new Action<FolderDetail>(this.OnFolderSelectedChangedCommand), new Func<FolderDetail, bool>(this.CanOnFolderSelectedChangedCommand));
			this.OnFileSelectedChanged = new DelegateCommand<FileDetail>(new Action<FileDetail>(this.OnFileSelectedChangedCommand), new Func<FileDetail, bool>(this.CanOnFileSelectedChangedCommand));
			this.OnApply = new DelegateCommand(new Action(this.OnApplyCommand), new Func<bool>(this.CanOnApplyCommand));
			this.OnRestore = new DelegateCommand(new Action(this.OnRestoreCommand), new Func<bool>(this.CanOnRestoreCommand));
			this.OnFolderItemChanged = new DelegateCommand<object>(new Action<object>(this.OnFolderItemChangedCommand), new Func<object, bool>(this.CanOnFolderItemChangedCommand));
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x0001D009 File Offset: 0x0001B209
		// (set) Token: 0x06000B89 RID: 2953 RVA: 0x0001D011 File Offset: 0x0001B211
		public bool IsReadOnly
		{
			get
			{
				return this._IsReadOnly;
			}
			private set
			{
				if (this.isViewReadonly)
				{
					this.SetProperty<bool>(ref this._IsReadOnly, true, "IsReadOnly");
					return;
				}
				this.SetProperty<bool>(ref this._IsReadOnly, value, "IsReadOnly");
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x0001D044 File Offset: 0x0001B244
		public bool CanRedirect
		{
			get
			{
				if (this.IsReadOnly)
				{
					return false;
				}
				if (this.IsSelectedFolder)
				{
					return this.SelectedFolder.CanRedirect && this.SelectedFolder.FullPath.Length > 3;
				}
				return this.IsSelectedFile && this.SelectedFile.CanRedirect;
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0001D09B File Offset: 0x0001B29B
		// (set) Token: 0x06000B8C RID: 2956 RVA: 0x0001D0A3 File Offset: 0x0001B2A3
		public ObservableCollection<FolderDetail> Folders
		{
			get
			{
				return this._Folders;
			}
			private set
			{
				this.SetProperty<ObservableCollection<FolderDetail>>(ref this._Folders, value, "Folders");
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0001D0B8 File Offset: 0x0001B2B8
		// (set) Token: 0x06000B8E RID: 2958 RVA: 0x0001D0C0 File Offset: 0x0001B2C0
		public FolderDetail SelectedFolder
		{
			get
			{
				return this._selectedFolder;
			}
			private set
			{
				bool? interactive = this.policy.enginePolicy.DirFilter.Interactive;
				bool flag = false;
				this.IsReadOnly = (interactive.GetValueOrDefault() == flag & interactive != null);
				FolderDetail selectedFolder = this._selectedFolder;
				if (this.SetProperty<FolderDetail>(ref this._selectedFolder, value, "SelectedFolder"))
				{
					this._selectedFile = null;
					if (selectedFolder == null || this._selectedFolder == null)
					{
						base.RaisePropertyChanged("IsSelectedFolder");
						base.RaisePropertyChanged("IsSelectedFile");
					}
					base.RaisePropertyChanged("CanRedirect");
				}
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x0001D14B File Offset: 0x0001B34B
		// (set) Token: 0x06000B90 RID: 2960 RVA: 0x0001D154 File Offset: 0x0001B354
		public FileDetail SelectedFile
		{
			get
			{
				return this._selectedFile;
			}
			private set
			{
				bool? interactive = this.policy.enginePolicy.FileFilter.Interactive;
				bool flag = false;
				this.IsReadOnly = (interactive.GetValueOrDefault() == flag & interactive != null);
				FileDetail selectedFile = this._selectedFile;
				if (this.SetProperty<FileDetail>(ref this._selectedFile, value, "SelectedFile"))
				{
					this._selectedFolder = null;
					if (selectedFile == null || this._selectedFile == null)
					{
						base.RaisePropertyChanged("IsSelectedFolder");
						base.RaisePropertyChanged("IsSelectedFile");
					}
					base.RaisePropertyChanged("CanRedirect");
				}
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0001D1DF File Offset: 0x0001B3DF
		public bool IsSelectedFolder
		{
			get
			{
				return this.SelectedFolder != null;
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0001D1EA File Offset: 0x0001B3EA
		public bool IsSelectedFile
		{
			get
			{
				return this.SelectedFile != null;
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0001D1F5 File Offset: 0x0001B3F5
		// (set) Token: 0x06000B94 RID: 2964 RVA: 0x0001D1FD File Offset: 0x0001B3FD
		public string FileTarget
		{
			get
			{
				return this._FileTarget;
			}
			set
			{
				this.SetProperty<string>(ref this._FileTarget, value, "FileTarget");
				DelegateCommand onApply = this.OnApply;
				if (onApply != null)
				{
					onApply.RaiseCanExecuteChanged();
				}
				DelegateCommand onRestore = this.OnRestore;
				if (onRestore == null)
				{
					return;
				}
				onRestore.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x0001D233 File Offset: 0x0001B433
		// (set) Token: 0x06000B96 RID: 2966 RVA: 0x0001D23B File Offset: 0x0001B43B
		public string FolderTarget
		{
			get
			{
				return this._FolderTarget;
			}
			set
			{
				this.SetProperty<string>(ref this._FolderTarget, value, "FolderTarget");
				DelegateCommand onApply = this.OnApply;
				if (onApply != null)
				{
					onApply.RaiseCanExecuteChanged();
				}
				DelegateCommand onRestore = this.OnRestore;
				if (onRestore == null)
				{
					return;
				}
				onRestore.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x0001D271 File Offset: 0x0001B471
		// (set) Token: 0x06000B98 RID: 2968 RVA: 0x0001D279 File Offset: 0x0001B479
		public DelegateCommand<object> OnFolderItemChanged { get; private set; }

		// Token: 0x06000B99 RID: 2969 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnFolderItemChangedCommand(object arg)
		{
			return true;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0001D284 File Offset: 0x0001B484
		private void OnFolderItemChangedCommand(object obj)
		{
			SectionDocumentsViewModel.<OnFolderItemChangedCommand>d__40 <OnFolderItemChangedCommand>d__;
			<OnFolderItemChangedCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnFolderItemChangedCommand>d__.<>4__this = this;
			<OnFolderItemChangedCommand>d__.obj = obj;
			<OnFolderItemChangedCommand>d__.<>1__state = -1;
			<OnFolderItemChangedCommand>d__.<>t__builder.Start<SectionDocumentsViewModel.<OnFolderItemChangedCommand>d__40>(ref <OnFolderItemChangedCommand>d__);
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0001D2C3 File Offset: 0x0001B4C3
		// (set) Token: 0x06000B9C RID: 2972 RVA: 0x0001D2CB File Offset: 0x0001B4CB
		public DelegateCommand<FolderDetail> OnFolderSelectedChanged { get; private set; }

		// Token: 0x06000B9D RID: 2973 RVA: 0x0001D2D4 File Offset: 0x0001B4D4
		private bool CanOnFolderSelectedChangedCommand(FolderDetail arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0001D2E0 File Offset: 0x0001B4E0
		private void OnFolderSelectedChangedCommand(FolderDetail obj)
		{
			if (this.IsSelectedFolder && obj.FullPath == this.SelectedFolder.FullPath)
			{
				this.FolderTarget = ((this.SelectedFolder.Transferrable == Transferrable.Transfer) ? this.SelectedFolder.Target : string.Empty);
			}
			EnginePolicy.DirFilterItem dirFilterItem = this.policy.enginePolicy.DirFilter.Filters.FirstOrDefault((EnginePolicy.DirFilterItem x) => x.Source == obj.FullPath);
			if (dirFilterItem == null)
			{
				dirFilterItem = new EnginePolicy.DirFilterItem
				{
					Source = obj.FullPath
				};
				this.policy.enginePolicy.DirFilter.Filters.Add(dirFilterItem);
			}
			if (this.IsSelectedFolder && this.FolderTarget != null && obj.Transferrable == Transferrable.Transfer)
			{
				dirFilterItem.TargetNonApp = this.FolderTarget;
				dirFilterItem.Migrate = new bool?(true);
				return;
			}
			if (obj.Transferrable == Transferrable.Transfer)
			{
				dirFilterItem.TargetNonApp = obj.Target;
				dirFilterItem.Migrate = new bool?(true);
				return;
			}
			dirFilterItem.TargetNonApp = string.Empty;
			dirFilterItem.Migrate = new bool?(false);
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x0001D418 File Offset: 0x0001B618
		// (set) Token: 0x06000BA0 RID: 2976 RVA: 0x0001D420 File Offset: 0x0001B620
		public DelegateCommand<FileDetail> OnFileSelectedChanged { get; private set; }

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0001D2D4 File Offset: 0x0001B4D4
		private bool CanOnFileSelectedChangedCommand(FileDetail arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0001D42C File Offset: 0x0001B62C
		private void OnFileSelectedChangedCommand(FileDetail obj)
		{
			if (this.IsSelectedFile && obj.FullPath == this.SelectedFile.FullPath)
			{
				this.FileTarget = ((this.SelectedFile.Selected == Transferrable.Transfer) ? this.SelectedFile.Target : string.Empty);
			}
			EnginePolicy.FileFilterItem fileFilterItem = this.policy.enginePolicy.FileFilter.Filters.FirstOrDefault((EnginePolicy.FileFilterItem x) => x.Source == obj.FullPath);
			if (fileFilterItem == null)
			{
				fileFilterItem = new EnginePolicy.FileFilterItem
				{
					Source = obj.FullPath
				};
				this.policy.enginePolicy.FileFilter.Filters.Add(fileFilterItem);
			}
			if (this.IsSelectedFile && this.FileTarget != null && obj.Selected == Transferrable.Transfer)
			{
				fileFilterItem.Target = this.FileTarget;
				fileFilterItem.Migrate = new bool?(true);
				return;
			}
			if (obj.Selected == Transferrable.Transfer)
			{
				fileFilterItem.Target = obj.Target;
				fileFilterItem.Migrate = new bool?(true);
				return;
			}
			fileFilterItem.Target = string.Empty;
			fileFilterItem.Migrate = new bool?(false);
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x0001D564 File Offset: 0x0001B764
		// (set) Token: 0x06000BA4 RID: 2980 RVA: 0x0001D56C File Offset: 0x0001B76C
		public DelegateCommand OnApply { get; private set; }

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0001D578 File Offset: 0x0001B778
		private bool CanOnApplyCommand()
		{
			if (this.IsReadOnly)
			{
				return false;
			}
			if (this.IsSelectedFolder)
			{
				string text = this.FolderTarget;
				if (!string.IsNullOrEmpty(text))
				{
					while (text.EndsWith("\\"))
					{
						text = text.Substring(0, text.Length - 1);
					}
					if (this.SelectedFolder.Target.EndsWith("\\"))
					{
						text += "\\";
					}
				}
				if (this.SelectedFolder.CanRedirect && !string.IsNullOrWhiteSpace(text) && text != this.SelectedFolder.Target && this.SelectedFolder.Transferrable == Transferrable.Transfer)
				{
					this.migrationDefinition.IsRedirectionSaved = false;
					return true;
				}
			}
			else if (this.IsSelectedFile && this.SelectedFile.CanRedirect && !string.IsNullOrWhiteSpace(this.FileTarget) && this.FileTarget != this.SelectedFile.Target && this.SelectedFile.Selected == Transferrable.Transfer)
			{
				this.migrationDefinition.IsRedirectionSaved = false;
				return true;
			}
			return false;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0001D68C File Offset: 0x0001B88C
		private void OnApplyCommand()
		{
			if (this.CanOnApplyCommand())
			{
				this.migrationDefinition.IsRedirectionSaved = true;
				if (this.IsSelectedFolder)
				{
					if (this.SelectedFolder.FullPath == Path.GetPathRoot(this.SelectedFolder.FullPath))
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SD_RedirectRootError, Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
						this.OnRestoreCommand();
						return;
					}
					this.SelectedFolder.Target = this._FolderTarget;
					EnginePolicy.DirFilterItem dirFilterItem = this.policy.enginePolicy.DirFilter.Filters.FirstOrDefault((EnginePolicy.DirFilterItem x) => x.Source == this.SelectedFolder.FullPath);
					if (dirFilterItem != null)
					{
						dirFilterItem.TargetNonApp = this._FolderTarget;
						dirFilterItem.Migrate = new bool?(true);
					}
					else
					{
						this.policy.enginePolicy.DirFilter.Filters.Add(new EnginePolicy.DirFilterItem(this.SelectedFolder.FullPath, this._FolderTarget, new bool?(this.SelectedFolder.Transferrable == Transferrable.Transfer)));
					}
				}
				else
				{
					this.SelectedFile.Target = this._FileTarget;
					if (!string.IsNullOrEmpty(Path.GetExtension(this.SelectedFile.FullPath)) && string.IsNullOrEmpty(Path.GetExtension(this.SelectedFile.Target)) && !this.SelectedFile.Target.EndsWith("*") && !this.SelectedFile.Target.EndsWith("\\"))
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.FFP_FileExtensionWarning, Resources.strWarning, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					}
					EnginePolicy.FileFilterItem fileFilterItem = this.policy.enginePolicy.FileFilter.Filters.FirstOrDefault((EnginePolicy.FileFilterItem x) => x.Source == this.SelectedFile.FullPath);
					if (fileFilterItem != null)
					{
						fileFilterItem.Target = this._FileTarget;
					}
					else
					{
						this.policy.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem(this.SelectedFile.FullPath, this._FileTarget, new bool?(this.SelectedFile.Selected == Transferrable.Transfer)));
					}
				}
				DelegateCommand onApply = this.OnApply;
				if (onApply == null)
				{
					return;
				}
				onApply.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x0001D8C6 File Offset: 0x0001BAC6
		// (set) Token: 0x06000BA8 RID: 2984 RVA: 0x0001D8CE File Offset: 0x0001BACE
		public DelegateCommand OnRestore { get; private set; }

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0001D8D8 File Offset: 0x0001BAD8
		private bool CanOnRestoreCommand()
		{
			if (this.IsReadOnly)
			{
				return false;
			}
			bool result = false;
			if (this.IsSelectedFolder && this.SelectedFolder.Transferrable == Transferrable.Transfer)
			{
				string target = this.SelectedFolder.Target;
				this.SelectedFolder.Target = "";
				if (string.Compare(this.SelectedFolder.Target, this.FolderTarget, StringComparison.OrdinalIgnoreCase) != 0)
				{
					result = true;
				}
				this.SelectedFolder.Target = target;
			}
			if (this.IsSelectedFile && this.SelectedFile.Selected == Transferrable.Transfer)
			{
				string target2 = this.SelectedFile.Target;
				this.SelectedFile.Target = "";
				if (string.Compare(this.SelectedFile.Target, this.FileTarget, StringComparison.OrdinalIgnoreCase) != 0)
				{
					result = true;
				}
				this.SelectedFile.Target = target2;
			}
			return result;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0001D9A4 File Offset: 0x0001BBA4
		private void OnRestoreCommand()
		{
			if (this.CanOnRestoreCommand())
			{
				if (this.IsSelectedFolder)
				{
					this.SelectedFolder.Target = "";
					this.FolderTarget = this.SelectedFolder.Target;
					EnginePolicy.DirFilterItem dirFilterItem = this.policy.enginePolicy.DirFilter.Filters.FirstOrDefault((EnginePolicy.DirFilterItem x) => x.Source == this.SelectedFolder.FullPath);
					if (dirFilterItem != null)
					{
						this.policy.enginePolicy.DirFilter.Filters.Remove(dirFilterItem);
					}
				}
				else if (this.IsSelectedFile)
				{
					this.SelectedFile.Target = "";
					this.FileTarget = this.SelectedFile.Target;
					EnginePolicy.FileFilterItem fileFilterItem = this.policy.enginePolicy.FileFilter.Filters.FirstOrDefault((EnginePolicy.FileFilterItem x) => x.Source == this.SelectedFile.FullPath);
					if (fileFilterItem != null)
					{
						this.policy.enginePolicy.FileFilter.Filters.Remove(fileFilterItem);
					}
				}
				this.migrationDefinition.IsRedirectionSaved = true;
			}
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0001DAAC File Offset: 0x0001BCAC
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.SecDocuments);
			this.isViewReadonly = (navigationContext.NavigationService.Region.Name == RegionNames.TransferCompleteDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.SummaryDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.FilesBasedSummaryDetailButtons);
			this.SelectedFolder = null;
			base.RaisePropertyChanged("SelectedFolder");
			this.SelectedFile = null;
			base.RaisePropertyChanged("SelectedFile");
			this.FolderTarget = string.Empty;
			this.FileTarget = string.Empty;
			this.Update((DefaultPolicy.SelectedButtonEnum)navigationContext.Parameters["Index"]);
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(true);
			this.migrationDefinition.IsRedirectionSaved = true;
			this.migrationDefinition.IsUserMappingSaved = true;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0001DBA4 File Offset: 0x0001BDA4
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(false);
			this.policy.WriteProfile();
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0001DBC4 File Offset: 0x0001BDC4
		private void Update(DefaultPolicy.SelectedButtonEnum viewIndex)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (this.migrationDefinition.DirtyCustomizationItems.HasFlag(CustomizationAffects.DiskItems))
				{
					this.pcmoverEngine.RetrieveDiskData();
					this.migrationDefinition.DirtyCustomizationItems &= ~CustomizationAffects.DiskItems;
				}
				if (this.migrationDefinition.DirtyCustomizationItems.HasFlag(CustomizationAffects.Drives))
				{
					this.pcmoverEngine.RetrieveDrives();
					this.migrationDefinition.DirtyCustomizationItems &= ~CustomizationAffects.Drives;
				}
				switch (viewIndex)
				{
				case DefaultPolicy.SelectedButtonEnum.Documents:
					this.Folders = new ObservableCollection<FolderDetail>(this.pcmoverEngine.DocumentsGroup.Folders);
					return;
				case DefaultPolicy.SelectedButtonEnum.Pictures:
					this.Folders = new ObservableCollection<FolderDetail>(this.pcmoverEngine.PicturesGroup.Folders);
					return;
				case DefaultPolicy.SelectedButtonEnum.Videos:
					this.Folders = new ObservableCollection<FolderDetail>(this.pcmoverEngine.VideoGroup.Folders);
					return;
				case DefaultPolicy.SelectedButtonEnum.Music:
					this.Folders = new ObservableCollection<FolderDetail>(this.pcmoverEngine.MusicGroup.Folders);
					return;
				case DefaultPolicy.SelectedButtonEnum.Others:
					this.Folders = new ObservableCollection<FolderDetail>(this.pcmoverEngine.OtherGroup.Folders);
					return;
				default:
					return;
				}
			}, "Update");
		}

		// Token: 0x040003A4 RID: 932
		private readonly IRegionManager regionManager;

		// Token: 0x040003A5 RID: 933
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040003A6 RID: 934
		private DefaultPolicy policy;

		// Token: 0x040003A7 RID: 935
		private bool isViewReadonly;

		// Token: 0x040003A8 RID: 936
		private bool _IsReadOnly;

		// Token: 0x040003A9 RID: 937
		private ObservableCollection<FolderDetail> _Folders;

		// Token: 0x040003AA RID: 938
		private FolderDetail _selectedFolder;

		// Token: 0x040003AB RID: 939
		private FileDetail _selectedFile;

		// Token: 0x040003AC RID: 940
		private string _FileTarget;

		// Token: 0x040003AD RID: 941
		private string _FolderTarget;
	}
}
