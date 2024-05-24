using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000081 RID: 129
	public class FileFilterPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060007E7 RID: 2023 RVA: 0x00011F90 File Offset: 0x00010190
		public FileFilterPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.policy = policy;
			this.IsFilterOpen = false;
			this.OnDone = new DelegateCommand(new Action(this.OnDoneCommand), new Func<bool>(this.CanOnDoneCommand));
			this.OnAdd = new DelegateCommand(new Action(this.OnAddCommand), new Func<bool>(this.CanOnAddCommand));
			this.OnEdit = new DelegateCommand(new Action(this.OnEditCommand), new Func<bool>(this.CanOnEditCommand));
			this.OnRemove = new DelegateCommand(new Action(this.OnRemoveCommand), new Func<bool>(this.CanOnRemoveCommand));
			this.OnUp = new DelegateCommand(new Action(this.OnUpCommand), new Func<bool>(this.CanOnUpCommand));
			this.OnDown = new DelegateCommand(new Action(this.OnDownCommand), new Func<bool>(this.CanOnDownCommand));
			this.OnOk = new DelegateCommand(new Action(this.OnOkCommand), new Func<bool>(this.CanOnOkCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
			this.OnYes = new DelegateCommand(new Action(this.OnYesCommand), new Func<bool>(this.CanOnYesCommand));
			this.OnNo = new DelegateCommand(new Action(this.OnNoCommand), new Func<bool>(this.CanOnNoCommand));
			this._FileFilters = new ObservableCollection<FileFilter>();
			this.FileSpecBorder = Brushes.Black;
			this.TargetBorder = Brushes.Black;
			this.EditFilter = null;
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00012153 File Offset: 0x00010353
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x0001215B File Offset: 0x0001035B
		public bool IsFilterOpen
		{
			get
			{
				return this._IsFilterOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsFilterOpen, value, "IsFilterOpen");
				this._FileExtentionWarningDisplayed = false;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x00012177 File Offset: 0x00010377
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x0001217F File Offset: 0x0001037F
		public ObservableCollection<FileFilter> FileFilters
		{
			get
			{
				return this._FileFilters;
			}
			private set
			{
				this.SetProperty<ObservableCollection<FileFilter>>(ref this._FileFilters, value, "FileFilters");
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x00012194 File Offset: 0x00010394
		// (set) Token: 0x060007ED RID: 2029 RVA: 0x0001219C File Offset: 0x0001039C
		public string FileSpec
		{
			get
			{
				return this._FileSpec;
			}
			set
			{
				this.SetProperty<string>(ref this._FileSpec, value, "FileSpec");
				this.ErrorMsg = string.Empty;
				this._FileExtentionWarningDisplayed = false;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x000121C3 File Offset: 0x000103C3
		// (set) Token: 0x060007EF RID: 2031 RVA: 0x000121CB File Offset: 0x000103CB
		public string Target
		{
			get
			{
				return this._Target;
			}
			set
			{
				this.SetProperty<string>(ref this._Target, value, "Target");
				this.ErrorMsg = string.Empty;
				this._FileExtentionWarningDisplayed = false;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x000121F2 File Offset: 0x000103F2
		// (set) Token: 0x060007F1 RID: 2033 RVA: 0x000121FA File Offset: 0x000103FA
		public bool? Transfer
		{
			get
			{
				return this._Transfer;
			}
			set
			{
				this.SetProperty<bool?>(ref this._Transfer, value, "Transfer");
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0001220F File Offset: 0x0001040F
		// (set) Token: 0x060007F3 RID: 2035 RVA: 0x00012218 File Offset: 0x00010418
		public bool IsTempFiles
		{
			get
			{
				return this._IsTempFiles;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsTempFiles, value, "IsTempFiles");
				string filespec = "*.tmp";
				if (value)
				{
					if (this.FindFilter(filespec) == null)
					{
						this.AddFilter(filespec, new bool?(false), "");
						return;
					}
				}
				else
				{
					this.RemoveFilter(filespec);
				}
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x00012264 File Offset: 0x00010464
		// (set) Token: 0x060007F5 RID: 2037 RVA: 0x0001226C File Offset: 0x0001046C
		public bool IsBackupFiles
		{
			get
			{
				return this._IsBackupFiles;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBackupFiles, value, "IsBackupFiles");
				string filespec = "*.bak";
				if (value)
				{
					if (this.FindFilter(filespec) == null)
					{
						this.AddFilter(filespec, new bool?(false), "");
						return;
					}
				}
				else
				{
					this.RemoveFilter(filespec);
				}
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x060007F6 RID: 2038 RVA: 0x000122B8 File Offset: 0x000104B8
		// (set) Token: 0x060007F7 RID: 2039 RVA: 0x000122C0 File Offset: 0x000104C0
		public bool IsOfficeFiles
		{
			get
			{
				return this._IsOfficeFiles;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsOfficeFiles, value, "IsOfficeFiles");
				string filespec = "~$*.*";
				if (value)
				{
					if (this.FindFilter(filespec) == null)
					{
						this.AddFilter(filespec, new bool?(false), "");
						return;
					}
				}
				else
				{
					this.RemoveFilter(filespec);
				}
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x060007F8 RID: 2040 RVA: 0x0001230C File Offset: 0x0001050C
		// (set) Token: 0x060007F9 RID: 2041 RVA: 0x00012314 File Offset: 0x00010514
		public Brush FileSpecBorder
		{
			get
			{
				return this._FileSpecBorder;
			}
			private set
			{
				this.SetProperty<Brush>(ref this._FileSpecBorder, value, "FileSpecBorder");
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x00012329 File Offset: 0x00010529
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x00012331 File Offset: 0x00010531
		public Brush TargetBorder
		{
			get
			{
				return this._TargetBorder;
			}
			private set
			{
				this.SetProperty<Brush>(ref this._TargetBorder, value, "TargetBorder");
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x00012346 File Offset: 0x00010546
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0001234E File Offset: 0x0001054E
		public string ErrorMsg
		{
			get
			{
				return this._ErrorMsg;
			}
			private set
			{
				this.SetProperty<string>(ref this._ErrorMsg, value, "ErrorMsg");
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x00012363 File Offset: 0x00010563
		// (set) Token: 0x060007FF RID: 2047 RVA: 0x0001236B File Offset: 0x0001056B
		public bool ShowErrorButtons
		{
			get
			{
				return this._ShowErrorButtons;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowErrorButtons, value, "ShowErrorButtons");
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00012380 File Offset: 0x00010580
		private int SelectedIndex
		{
			get
			{
				return this.FileFilters.IndexOf(this.SelectedFilter);
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x00012393 File Offset: 0x00010593
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x0001239C File Offset: 0x0001059C
		public FileFilter SelectedFilter
		{
			get
			{
				return this._SelectedFilter;
			}
			set
			{
				this.SetProperty<FileFilter>(ref this._SelectedFilter, value, "SelectedFilter");
				this.OnEdit.RaiseCanExecuteChanged();
				this.OnRemove.RaiseCanExecuteChanged();
				this.OnUp.RaiseCanExecuteChanged();
				this.OnDown.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool EnableDone
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x000123E8 File Offset: 0x000105E8
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x000123F0 File Offset: 0x000105F0
		public DelegateCommand OnDone { get; private set; }

		// Token: 0x06000806 RID: 2054 RVA: 0x000123F9 File Offset: 0x000105F9
		private bool CanOnDoneCommand()
		{
			return this.EnableDone;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00012404 File Offset: 0x00010604
		private void OnDoneCommand()
		{
			if (this.somethingChanged && !base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.FileFilters = new List<FileFilter>(this.FileFilters);
				base.pcmoverEngine.RetrieveDiskData();
			}, "OnDoneCommand"))
			{
				return;
			}
			if (this.navigationContext.NavigationService.Journal.CanGoBack)
			{
				this.navigationContext.NavigationService.Journal.GoBack();
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x00012464 File Offset: 0x00010664
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x0001246C File Offset: 0x0001066C
		public DelegateCommand OnAdd { get; private set; }

		// Token: 0x0600080A RID: 2058 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnAddCommand()
		{
			return true;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00012475 File Offset: 0x00010675
		private void OnAddCommand()
		{
			this.FileSpec = "";
			this.Target = "";
			this.Transfer = new bool?(false);
			this.IsFilterOpen = true;
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x000124A0 File Offset: 0x000106A0
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x000124A8 File Offset: 0x000106A8
		public DelegateCommand OnEdit { get; private set; }

		// Token: 0x0600080E RID: 2062 RVA: 0x000124B1 File Offset: 0x000106B1
		private bool CanOnEditCommand()
		{
			return this.SelectedFilter != null;
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x000124BC File Offset: 0x000106BC
		private void OnEditCommand()
		{
			this.EditFilter = this.SelectedFilter;
			if (this.EditFilter != null)
			{
				this.FileSpec = this.EditFilter.filter;
				this.Target = this.EditFilter.target;
				this.Transfer = this.EditFilter.transfer;
			}
			this.IsFilterOpen = true;
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x00012517 File Offset: 0x00010717
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x0001251F File Offset: 0x0001071F
		public DelegateCommand OnRemove { get; private set; }

		// Token: 0x06000812 RID: 2066 RVA: 0x000124B1 File Offset: 0x000106B1
		private bool CanOnRemoveCommand()
		{
			return this.SelectedFilter != null;
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00012528 File Offset: 0x00010728
		private void OnRemoveCommand()
		{
			FileFilter selectedFilter = this.SelectedFilter;
			if (selectedFilter != null)
			{
				this.RemoveFilter(selectedFilter.filter);
			}
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0001254C File Offset: 0x0001074C
		private void SwapFilters(int low, int high)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.SwapFileFilters(low, high);
				FileFilter value = this.FileFilters[high];
				this.FileFilters[high] = this.FileFilters[low];
				this.FileFilters[low] = value;
				this.somethingChanged = true;
			}, "SwapFilters");
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x00012591 File Offset: 0x00010791
		// (set) Token: 0x06000816 RID: 2070 RVA: 0x00012599 File Offset: 0x00010799
		public DelegateCommand OnUp { get; private set; }

		// Token: 0x06000817 RID: 2071 RVA: 0x000125A2 File Offset: 0x000107A2
		private bool CanOnUpCommand()
		{
			return this.SelectedIndex > 0;
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x000125B0 File Offset: 0x000107B0
		private void OnUpCommand()
		{
			int selectedIndex = this.SelectedIndex;
			if (selectedIndex <= 0)
			{
				return;
			}
			this.SwapFilters(selectedIndex - 1, selectedIndex);
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x000125D3 File Offset: 0x000107D3
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x000125DB File Offset: 0x000107DB
		public DelegateCommand OnDown { get; private set; }

		// Token: 0x0600081B RID: 2075 RVA: 0x000125E4 File Offset: 0x000107E4
		private bool CanOnDownCommand()
		{
			int selectedIndex = this.SelectedIndex;
			return selectedIndex >= 0 && selectedIndex < this.FileFilters.Count - 1;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00012610 File Offset: 0x00010810
		private void OnDownCommand()
		{
			int selectedIndex = this.SelectedIndex;
			if (selectedIndex < 0 || selectedIndex >= this.FileFilters.Count - 1)
			{
				return;
			}
			this.SwapFilters(selectedIndex, selectedIndex + 1);
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x00012643 File Offset: 0x00010843
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x0001264B File Offset: 0x0001084B
		public DelegateCommand OnOk { get; private set; }

		// Token: 0x0600081F RID: 2079 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnOkCommand()
		{
			return true;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00012654 File Offset: 0x00010854
		public static bool ContainsAny(string haystack, params string[] needles)
		{
			foreach (string value in needles)
			{
				if (haystack.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00012684 File Offset: 0x00010884
		private void OnOkCommand()
		{
			string text = this.FileSpec.Trim();
			int num = text.IndexOfAny(new char[]
			{
				'"',
				'<',
				'>',
				'/'
			});
			if (string.IsNullOrEmpty(text) || num != -1)
			{
				this.FileSpecBorder = Brushes.Red;
				this.ErrorMsg = Resources.FFP_FilterError1;
				return;
			}
			int num2 = text.LastIndexOf('\\');
			if (num2 != -1)
			{
				num = text.IndexOfAny(new char[]
				{
					'*',
					'?'
				});
				if (num != -1 && num < num2)
				{
					this.FileSpecBorder = Brushes.Red;
					this.ErrorMsg = Resources.FFP_FilterError2;
					return;
				}
			}
			bool? transfer = this.Transfer;
			bool flag = true;
			if ((transfer.GetValueOrDefault() == flag & transfer != null) && !string.IsNullOrEmpty(this.Target) && ((text.Contains("*") && !this.Target.Contains("*")) || (text.Contains("?") && !this.Target.Contains("?"))))
			{
				this.FileSpecBorder = Brushes.Red;
				this.ErrorMsg = Resources.FFP_FilterError4;
				return;
			}
			transfer = this.Transfer;
			flag = true;
			if ((transfer.GetValueOrDefault() == flag & transfer != null) && !string.IsNullOrEmpty(Path.GetExtension(text)) && string.IsNullOrEmpty(Path.GetExtension(this.Target)) && !this.Target.EndsWith("*") && !this.Target.EndsWith("\\"))
			{
				this.ErrorMsg = Resources.FFP_FileExtensionWarning;
				if (!this._FileExtentionWarningDisplayed)
				{
					this._FileExtentionWarningDisplayed = true;
					return;
				}
			}
			if (FileFilterPageViewModel.ContainsAny(text, new string[]
			{
				"*.*",
				"*.???",
				"*.ini",
				"*.dll",
				"*.exe"
			}))
			{
				this.FileSpecBorder = Brushes.Red;
				this.ErrorMsg = Resources.FFP_FilterError3;
				this.ShowErrorButtons = true;
				return;
			}
			this.AddFilter(this.FileSpec, this.Transfer, this.Target);
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x00012885 File Offset: 0x00010A85
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x0001288D File Offset: 0x00010A8D
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000824 RID: 2084 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00012896 File Offset: 0x00010A96
		private void OnCancelCommand()
		{
			this.IsFilterOpen = false;
			this.ResetErrorText();
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x000128A5 File Offset: 0x00010AA5
		// (set) Token: 0x06000827 RID: 2087 RVA: 0x000128AD File Offset: 0x00010AAD
		public DelegateCommand OnYes { get; private set; }

		// Token: 0x06000828 RID: 2088 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnYesCommand()
		{
			return true;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000128B8 File Offset: 0x00010AB8
		private void OnYesCommand()
		{
			FileFilter item = new FileFilter(this.FileSpec, this.Transfer, this.Target);
			this.FileFilters.Add(item);
			this.IsFilterOpen = false;
			this.ResetErrorText();
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x000128F8 File Offset: 0x00010AF8
		private void AddFilter(string filespec, bool? transfer, string target)
		{
			bool flag = true;
			foreach (FileFilter fileFilter in this.FileFilters)
			{
				if (string.Equals(fileFilter.filter, filespec, StringComparison.OrdinalIgnoreCase))
				{
					bool? transfer2 = fileFilter.transfer;
					bool? transfer3 = transfer;
					if ((transfer2.GetValueOrDefault() == transfer3.GetValueOrDefault() & transfer2 != null == (transfer3 != null)) && string.Equals(fileFilter.target, target, StringComparison.OrdinalIgnoreCase))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				if (!base.pcmoverEngine.CatchCommEx(delegate
				{
					if (this.EditFilter == null)
					{
						FileFilter fileFilter2 = new FileFilter(filespec, transfer, target);
						this.FileFilters.Add(fileFilter2);
						this.pcmoverEngine.AddFileFilter(fileFilter2);
						this.somethingChanged = true;
						return;
					}
					int num = 0;
					foreach (FileFilter fileFilter3 in this.FileFilters)
					{
						if (string.Equals(fileFilter3.filter, this.EditFilter.filter, StringComparison.OrdinalIgnoreCase))
						{
							bool? transfer4 = fileFilter3.transfer;
							bool? transfer5 = this.EditFilter.transfer;
							if ((transfer4.GetValueOrDefault() == transfer5.GetValueOrDefault() & transfer4 != null == (transfer5 != null)) && string.Equals(fileFilter3.target, this.EditFilter.target, StringComparison.OrdinalIgnoreCase))
							{
								fileFilter3.filter = filespec;
								fileFilter3.transfer = transfer;
								fileFilter3.target = target;
								this.pcmoverEngine.ChangeFileFilter(num, fileFilter3);
								this.somethingChanged = true;
								break;
							}
						}
						num++;
					}
				}, "AddFilter"))
				{
					return;
				}
				this.EditFilter = null;
				this.CheckForCheckboxes();
			}
			this.IsFilterOpen = false;
			this.ResetErrorText();
			EnginePolicy.FileFilterItem fileFilterItem = this.policy.enginePolicy.FileFilter.Filters.FirstOrDefault((EnginePolicy.FileFilterItem x) => x.Source == filespec);
			if (fileFilterItem != null)
			{
				this.policy.enginePolicy.FileFilter.Filters.Remove(fileFilterItem);
			}
			this.policy.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem(filespec, target, transfer));
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00012A78 File Offset: 0x00010C78
		private void RemoveFilter(string filespec)
		{
			if (filespec != null)
			{
				int index = this.FindFilterIndex(filespec);
				if (index != -1)
				{
					if (!base.pcmoverEngine.CatchCommEx(delegate
					{
						this.pcmoverEngine.DeleteFileFilter(index);
					}, "RemoveFilter"))
					{
						return;
					}
					this.somethingChanged = true;
					FileFilter fileFilter = this.FileFilters[index];
					this.FileFilters.RemoveAt(index);
					if (string.Equals(fileFilter.filter, "*.tmp", StringComparison.OrdinalIgnoreCase))
					{
						this.IsTempFiles = false;
					}
					if (string.Equals(fileFilter.filter, "*.bak", StringComparison.OrdinalIgnoreCase))
					{
						this.IsBackupFiles = false;
					}
					if (string.Equals(fileFilter.filter, "~$*.*", StringComparison.OrdinalIgnoreCase))
					{
						this.IsOfficeFiles = false;
					}
				}
				this.policy.enginePolicy.FileFilter.Filters.Remove(this.policy.enginePolicy.FileFilter.Filters.FirstOrDefault((EnginePolicy.FileFilterItem x) => x.Source == filespec));
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00012BB0 File Offset: 0x00010DB0
		private FileFilter FindFilter(string filespec)
		{
			int num = this.FindFilterIndex(filespec);
			if (num == -1)
			{
				return null;
			}
			return this.FileFilters[num];
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00012BD8 File Offset: 0x00010DD8
		private int FindFilterIndex(string filespec)
		{
			int num = 0;
			using (IEnumerator<FileFilter> enumerator = this.FileFilters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (string.Equals(enumerator.Current.filter, filespec, StringComparison.OrdinalIgnoreCase))
					{
						return num;
					}
					num++;
				}
			}
			return -1;
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x00012C38 File Offset: 0x00010E38
		// (set) Token: 0x0600082F RID: 2095 RVA: 0x00012C40 File Offset: 0x00010E40
		public DelegateCommand OnNo { get; private set; }

		// Token: 0x06000830 RID: 2096 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNoCommand()
		{
			return true;
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00012C49 File Offset: 0x00010E49
		private void OnNoCommand()
		{
			this.ResetErrorText();
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00012C51 File Offset: 0x00010E51
		private void ResetErrorText()
		{
			this.FileSpecBorder = Brushes.Black;
			this.TargetBorder = Brushes.Black;
			this.ErrorMsg = "";
			this.ShowErrorButtons = false;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00012C7C File Offset: 0x00010E7C
		private void CheckForCheckboxes()
		{
			bool isTempFiles = this.IsTempFiles;
			bool isBackupFiles = this.IsBackupFiles;
			bool isOfficeFiles = this.IsOfficeFiles;
			foreach (FileFilter fileFilter in this.FileFilters)
			{
				if (string.Equals(fileFilter.filter, "*.tmp", StringComparison.OrdinalIgnoreCase))
				{
					isTempFiles = true;
				}
				if (string.Equals(fileFilter.filter, "*.bak", StringComparison.OrdinalIgnoreCase))
				{
					isBackupFiles = true;
				}
				if (string.Equals(fileFilter.filter, "~$*.*", StringComparison.OrdinalIgnoreCase))
				{
					isOfficeFiles = true;
				}
			}
			this.IsTempFiles = isTempFiles;
			this.IsBackupFiles = isBackupFiles;
			this.IsOfficeFiles = isOfficeFiles;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x00012D2C File Offset: 0x00010F2C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.FileFilter);
			this.FileSpecBorder = Brushes.Black;
			this.TargetBorder = Brushes.Black;
			this.ErrorMsg = "";
			this.ShowErrorButtons = false;
			this.navigationContext = navigationContext;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.RetrieveFileFilters();
				this.FileFilters = new ObservableCollection<FileFilter>(base.pcmoverEngine.FileFilters);
			}, "OnNavigatedTo"))
			{
				return;
			}
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_FileFilterPage);
			this.CheckForCheckboxes();
			this.FileSpec = "";
			this.Target = "";
			this.Transfer = new bool?(false);
			this.EditFilter = null;
			this.somethingChanged = false;
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00012DE4 File Offset: 0x00010FE4
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				GroupInfo documentsGroup = base.pcmoverEngine.DocumentsGroup;
				if (documentsGroup != null)
				{
					documentsGroup.RefreshDetails();
				}
				GroupInfo musicGroup = base.pcmoverEngine.MusicGroup;
				if (musicGroup != null)
				{
					musicGroup.RefreshDetails();
				}
				GroupInfo picturesGroup = base.pcmoverEngine.PicturesGroup;
				if (picturesGroup != null)
				{
					picturesGroup.RefreshDetails();
				}
				GroupInfo videoGroup = base.pcmoverEngine.VideoGroup;
				if (videoGroup != null)
				{
					videoGroup.RefreshDetails();
				}
				GroupInfo otherGroup = base.pcmoverEngine.OtherGroup;
				if (otherGroup != null)
				{
					otherGroup.RefreshDetails();
				}
				this.policy.WriteProfile();
			}, "OnNavigatedFrom");
		}

		// Token: 0x04000221 RID: 545
		private readonly IRegionManager regionManager;

		// Token: 0x04000222 RID: 546
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000223 RID: 547
		private NavigationContext navigationContext;

		// Token: 0x04000224 RID: 548
		private FileFilter EditFilter;

		// Token: 0x04000225 RID: 549
		private readonly DefaultPolicy policy;

		// Token: 0x04000226 RID: 550
		private bool _FileExtentionWarningDisplayed;

		// Token: 0x04000227 RID: 551
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000228 RID: 552
		private bool _IsFilterOpen;

		// Token: 0x04000229 RID: 553
		private ObservableCollection<FileFilter> _FileFilters;

		// Token: 0x0400022A RID: 554
		private string _FileSpec;

		// Token: 0x0400022B RID: 555
		private string _Target;

		// Token: 0x0400022C RID: 556
		private bool? _Transfer;

		// Token: 0x0400022D RID: 557
		private bool _IsTempFiles;

		// Token: 0x0400022E RID: 558
		private bool _IsBackupFiles;

		// Token: 0x0400022F RID: 559
		private bool _IsOfficeFiles;

		// Token: 0x04000230 RID: 560
		private Brush _FileSpecBorder;

		// Token: 0x04000231 RID: 561
		private Brush _TargetBorder;

		// Token: 0x04000232 RID: 562
		private string _ErrorMsg;

		// Token: 0x04000233 RID: 563
		private bool _ShowErrorButtons;

		// Token: 0x04000234 RID: 564
		private FileFilter _SelectedFilter;

		// Token: 0x04000235 RID: 565
		private bool somethingChanged;
	}
}
