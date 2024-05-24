using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200007F RID: 127
	public class DetailButtonListViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x0600071F RID: 1823 RVA: 0x00010498 File Offset: 0x0000E698
		public DetailButtonListViewModel(IUnityContainer container, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.policy = policy;
			this.OnApplicationsSelected = new DelegateCommand(new Action(this.ApplicationsSelected), new Func<bool>(this.CanSelectApps));
			this.OnMusicSelected = new DelegateCommand(new Action(this.MusicSelected), new Func<bool>(this.CanSelectMusic));
			this.OnDocumentsSelected = new DelegateCommand(new Action(this.DocumentsSelected), new Func<bool>(this.CanSelectDocuments));
			this.OnOtherSelected = new DelegateCommand(new Action(this.OtherSelected), new Func<bool>(this.CanSelectOther));
			this.OnPicturesSelected = new DelegateCommand(new Action(this.PicturesSelected), new Func<bool>(this.CanSelectPictures));
			this.OnUsersSelected = new DelegateCommand(new Action(this.UsersSelected), new Func<bool>(this.CanSelectUsers));
			this.OnVideosSelected = new DelegateCommand(new Action(this.VideosSelected), new Func<bool>(this.CanSelectVideos));
			this.OnAdvancedSelected = new DelegateCommand(new Action(this.AdvancedSelected), new Func<bool>(this.CanSelectAdvanced));
			this.OnSizeInfo = new DelegateCommand(new Action(this.OnSizeInfoCommand), new Func<bool>(this.CanOnSizeInfoCommand));
			this.OnAppsUpgradeSelected = new DelegateCommand(new Action(this.OnAppsUpgradeCommand), new Func<bool>(this.CanOnAppsUpgradeCommand));
			this.OnUsersUpgradeSelected = new DelegateCommand(new Action(this.OnUsersUpgradeCommand), new Func<bool>(this.CanOnUsersUpgradeCommand));
			eventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Subscribe(new Action<TaskStats>(this.OnAnalyzeComputer));
			this.ShowAppButton = false;
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00010671 File Offset: 0x0000E871
		// (set) Token: 0x06000721 RID: 1825 RVA: 0x00010679 File Offset: 0x0000E879
		public int GreenApplicationCount
		{
			get
			{
				return this._GreenApplicationCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._GreenApplicationCount, value, "GreenApplicationCount");
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x0001068E File Offset: 0x0000E88E
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x00010696 File Offset: 0x0000E896
		public int YellowApplicationCount
		{
			get
			{
				return this._YellowApplicationCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._YellowApplicationCount, value, "YellowApplicationCount");
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x000106AB File Offset: 0x0000E8AB
		// (set) Token: 0x06000725 RID: 1829 RVA: 0x000106B3 File Offset: 0x0000E8B3
		public int RedApplicationCount
		{
			get
			{
				return this._RedApplicationCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._RedApplicationCount, value, "RedApplicationCount");
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x000106C8 File Offset: 0x0000E8C8
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x000106D0 File Offset: 0x0000E8D0
		public int GreenSelectedApplicationCount
		{
			get
			{
				return this._GreenSelectedApplicationCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._GreenSelectedApplicationCount, value, "GreenSelectedApplicationCount");
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x000106E5 File Offset: 0x0000E8E5
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x000106ED File Offset: 0x0000E8ED
		public int YellowSelectedApplicationCount
		{
			get
			{
				return this._YellowSelectedApplicationCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._YellowSelectedApplicationCount, value, "YellowSelectedApplicationCount");
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00010702 File Offset: 0x0000E902
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x0001070A File Offset: 0x0000E90A
		public int RedSelectedApplicationCount
		{
			get
			{
				return this._RedSelectedApplicationCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._RedSelectedApplicationCount, value, "RedSelectedApplicationCount");
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x0001071F File Offset: 0x0000E91F
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x00010727 File Offset: 0x0000E927
		public string TotalApplicationSize
		{
			get
			{
				return this._TotalApplicationSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._TotalApplicationSize, value, "TotalApplicationSize");
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x0001073C File Offset: 0x0000E93C
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x00010744 File Offset: 0x0000E944
		public int DocumentsFolderCount
		{
			get
			{
				return this._DocumentsFolderCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._DocumentsFolderCount, value, "DocumentsFolderCount");
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00010759 File Offset: 0x0000E959
		// (set) Token: 0x06000731 RID: 1841 RVA: 0x00010761 File Offset: 0x0000E961
		public int DocumentsFileCount
		{
			get
			{
				return this._DocumentsFileCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._DocumentsFileCount, value, "DocumentsFileCount");
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00010776 File Offset: 0x0000E976
		// (set) Token: 0x06000733 RID: 1843 RVA: 0x0001077E File Offset: 0x0000E97E
		public string FormattedDocumentsSize
		{
			get
			{
				return this._FormattedDocumentsSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._FormattedDocumentsSize, value, "FormattedDocumentsSize");
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00010793 File Offset: 0x0000E993
		// (set) Token: 0x06000735 RID: 1845 RVA: 0x0001079B File Offset: 0x0000E99B
		public int MusicFolderCount
		{
			get
			{
				return this._MusicFolderCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._MusicFolderCount, value, "MusicFolderCount");
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x000107B0 File Offset: 0x0000E9B0
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x000107B8 File Offset: 0x0000E9B8
		public int MusicFileCount
		{
			get
			{
				return this._MusicFileCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._MusicFileCount, value, "MusicFileCount");
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x000107CD File Offset: 0x0000E9CD
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x000107D5 File Offset: 0x0000E9D5
		public string FormattedMusicSize
		{
			get
			{
				return this._FormattedMusicSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._FormattedMusicSize, value, "FormattedMusicSize");
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x000107EA File Offset: 0x0000E9EA
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x000107F2 File Offset: 0x0000E9F2
		public int PicturesFolderCount
		{
			get
			{
				return this._PicturesFolderCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._PicturesFolderCount, value, "PicturesFolderCount");
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x00010807 File Offset: 0x0000EA07
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x0001080F File Offset: 0x0000EA0F
		public int PicturesFileCount
		{
			get
			{
				return this._PicturesFileCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._PicturesFileCount, value, "PicturesFileCount");
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00010824 File Offset: 0x0000EA24
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x0001082C File Offset: 0x0000EA2C
		public string FormattedPicturesSize
		{
			get
			{
				return this._FormattedPicturesSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._FormattedPicturesSize, value, "FormattedPicturesSize");
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x00010841 File Offset: 0x0000EA41
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x00010849 File Offset: 0x0000EA49
		public int VideoFolderCount
		{
			get
			{
				return this._VideoFolderCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._VideoFolderCount, value, "VideoFolderCount");
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x0001085E File Offset: 0x0000EA5E
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x00010866 File Offset: 0x0000EA66
		public int VideoFileCount
		{
			get
			{
				return this._VideoFileCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._VideoFileCount, value, "VideoFileCount");
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x0001087B File Offset: 0x0000EA7B
		// (set) Token: 0x06000745 RID: 1861 RVA: 0x00010883 File Offset: 0x0000EA83
		public string FormattedVideoSize
		{
			get
			{
				return this._FormattedVideoSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._FormattedVideoSize, value, "FormattedVideoSize");
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x00010898 File Offset: 0x0000EA98
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x000108A0 File Offset: 0x0000EAA0
		public int OtherFolderCount
		{
			get
			{
				return this._OtherFolderCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._OtherFolderCount, value, "OtherFolderCount");
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x000108B5 File Offset: 0x0000EAB5
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x000108BD File Offset: 0x0000EABD
		public int OtherFileCount
		{
			get
			{
				return this._OtherFileCount;
			}
			private set
			{
				this.SetProperty<int>(ref this._OtherFileCount, value, "OtherFileCount");
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x000108D2 File Offset: 0x0000EAD2
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x000108DA File Offset: 0x0000EADA
		public string FormattedOtherSize
		{
			get
			{
				return this._FormattedOtherSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._FormattedOtherSize, value, "FormattedOtherSize");
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x000108EF File Offset: 0x0000EAEF
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x000108F7 File Offset: 0x0000EAF7
		public string UsersCount
		{
			get
			{
				return this._UsersCount;
			}
			private set
			{
				this.SetProperty<string>(ref this._UsersCount, value, "UsersCount");
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x0001090C File Offset: 0x0000EB0C
		// (set) Token: 0x0600074F RID: 1871 RVA: 0x00010914 File Offset: 0x0000EB14
		public double TotalSize
		{
			get
			{
				return this._TotalSize;
			}
			private set
			{
				this.SetProperty<double>(ref this._TotalSize, value, "TotalSize");
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x00010929 File Offset: 0x0000EB29
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x00010931 File Offset: 0x0000EB31
		public string TotalTime
		{
			get
			{
				return this._TotalTime;
			}
			private set
			{
				this.SetProperty<string>(ref this._TotalTime, value, "TotalTime");
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x00010946 File Offset: 0x0000EB46
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x0001094E File Offset: 0x0000EB4E
		public string Title
		{
			get
			{
				return this._Title;
			}
			private set
			{
				this.SetProperty<string>(ref this._Title, value, "Title");
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x00010963 File Offset: 0x0000EB63
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x0001096B File Offset: 0x0000EB6B
		public bool IsApplicationTransferEnabled
		{
			get
			{
				return this._IsApplicationTransferEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsApplicationTransferEnabled, value, "IsApplicationTransferEnabled");
				this.OnApplicationsSelected.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x0001098B File Offset: 0x0000EB8B
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x00010993 File Offset: 0x0000EB93
		public bool IsSizeDisplayed
		{
			get
			{
				return this._IsSizeDisplayed;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsSizeDisplayed, value, "IsSizeDisplayed");
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x000109A8 File Offset: 0x0000EBA8
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x000109B0 File Offset: 0x0000EBB0
		public bool IsEstimated
		{
			get
			{
				return this._IsEstimated;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsEstimated, value, "IsEstimated");
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x000109C5 File Offset: 0x0000EBC5
		// (set) Token: 0x0600075B RID: 1883 RVA: 0x000109CD File Offset: 0x0000EBCD
		public bool IsUserMappingEnabled
		{
			get
			{
				return this._IsUserMappingEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsUserMappingEnabled, value, "IsUserMappingEnabled");
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x000109E2 File Offset: 0x0000EBE2
		// (set) Token: 0x0600075D RID: 1885 RVA: 0x000109EA File Offset: 0x0000EBEA
		public bool IsDirFilterEnabled
		{
			get
			{
				return this._IsDirFilterEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsDirFilterEnabled, value, "IsDirFilterEnabled");
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x000109FF File Offset: 0x0000EBFF
		// (set) Token: 0x0600075F RID: 1887 RVA: 0x00010A07 File Offset: 0x0000EC07
		public DefaultPolicy.SelectedButtonEnum SelectedButton
		{
			get
			{
				return this._SelectedButton;
			}
			private set
			{
				this.SetProperty<DefaultPolicy.SelectedButtonEnum>(ref this._SelectedButton, value, "SelectedButton");
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00010A1C File Offset: 0x0000EC1C
		// (set) Token: 0x06000761 RID: 1889 RVA: 0x00010A24 File Offset: 0x0000EC24
		public bool ShowAppButton
		{
			get
			{
				return this._ShowAppButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowAppButton, value, "ShowAppButton");
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x00010A39 File Offset: 0x0000EC39
		// (set) Token: 0x06000763 RID: 1891 RVA: 0x00010A41 File Offset: 0x0000EC41
		public bool ShowAppButtonUnavalable
		{
			get
			{
				return this._ShowAppButtonUnavalable;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowAppButtonUnavalable, value, "ShowAppButtonUnavalable");
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x00010A56 File Offset: 0x0000EC56
		// (set) Token: 0x06000765 RID: 1893 RVA: 0x00010A5E File Offset: 0x0000EC5E
		public bool ShowDocsButton
		{
			get
			{
				return this._ShowDocsButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowDocsButton, value, "ShowDocsButton");
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00010A73 File Offset: 0x0000EC73
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x00010A7B File Offset: 0x0000EC7B
		public bool ShowPicsButton
		{
			get
			{
				return this._ShowPicsButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowPicsButton, value, "ShowPicsButton");
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x00010A90 File Offset: 0x0000EC90
		// (set) Token: 0x06000769 RID: 1897 RVA: 0x00010A98 File Offset: 0x0000EC98
		public bool ShowVideoButton
		{
			get
			{
				return this._ShowVideoButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowVideoButton, value, "ShowVideoButton");
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x00010AAD File Offset: 0x0000ECAD
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x00010AB5 File Offset: 0x0000ECB5
		public bool ShowMusicButton
		{
			get
			{
				return this._ShowMusicButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowMusicButton, value, "ShowMusicButton");
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x00010ACA File Offset: 0x0000ECCA
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x00010AD2 File Offset: 0x0000ECD2
		public bool ShowOtherButton
		{
			get
			{
				return this._ShowOtherButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowOtherButton, value, "ShowOtherButton");
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x00010AE7 File Offset: 0x0000ECE7
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x00010AEF File Offset: 0x0000ECEF
		public bool ShowUserButton
		{
			get
			{
				return this._ShowUserButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowUserButton, value, "ShowUserButton");
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x00010B04 File Offset: 0x0000ED04
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00010B0C File Offset: 0x0000ED0C
		public bool ShowUserOnlyButton
		{
			get
			{
				return this._ShowUserOnlyButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowUserOnlyButton, value, "ShowUserOnlyButton");
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x00010B21 File Offset: 0x0000ED21
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x00010B29 File Offset: 0x0000ED29
		public bool ShowAdvancedButton
		{
			get
			{
				return this._ShowAdvancedButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowAdvancedButton, value, "ShowAdvancedButton");
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00010B3E File Offset: 0x0000ED3E
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x00010B46 File Offset: 0x0000ED46
		public DelegateCommand OnApplicationsSelected { get; private set; }

		// Token: 0x06000776 RID: 1910 RVA: 0x00010B4F File Offset: 0x0000ED4F
		private bool CanSelectApps()
		{
			return this.IsApplicationTransferEnabled;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00010B57 File Offset: 0x0000ED57
		private void ApplicationsSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Applications, WizardModule.Properties.Resources.DBL_Applications, "SectionApplications");
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x00010B6A File Offset: 0x0000ED6A
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x00010B72 File Offset: 0x0000ED72
		public DelegateCommand OnMusicSelected { get; private set; }

		// Token: 0x0600077A RID: 1914 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanSelectMusic()
		{
			return true;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00010B7B File Offset: 0x0000ED7B
		private void MusicSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Music, WizardModule.Properties.Resources.DBL_Music, "SectionDocuments");
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x00010B8E File Offset: 0x0000ED8E
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x00010B96 File Offset: 0x0000ED96
		public DelegateCommand OnDocumentsSelected { get; private set; }

		// Token: 0x0600077E RID: 1918 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanSelectDocuments()
		{
			return true;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00010B9F File Offset: 0x0000ED9F
		private void DocumentsSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Documents, WizardModule.Properties.Resources.DBL_Documents, "SectionDocuments");
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x00010BB2 File Offset: 0x0000EDB2
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x00010BBA File Offset: 0x0000EDBA
		public DelegateCommand OnOtherSelected { get; private set; }

		// Token: 0x06000782 RID: 1922 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanSelectOther()
		{
			return true;
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00010BC3 File Offset: 0x0000EDC3
		private void OtherSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Others, WizardModule.Properties.Resources.DBL_Other, "SectionDocuments");
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00010BD6 File Offset: 0x0000EDD6
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x00010BDE File Offset: 0x0000EDDE
		public DelegateCommand OnPicturesSelected { get; private set; }

		// Token: 0x06000786 RID: 1926 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanSelectPictures()
		{
			return true;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00010BE7 File Offset: 0x0000EDE7
		private void PicturesSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Pictures, WizardModule.Properties.Resources.DBL_Pictures, "SectionDocuments");
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x00010BFA File Offset: 0x0000EDFA
		// (set) Token: 0x06000789 RID: 1929 RVA: 0x00010C02 File Offset: 0x0000EE02
		public DelegateCommand OnUsersSelected { get; private set; }

		// Token: 0x0600078A RID: 1930 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanSelectUsers()
		{
			return true;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00010C0B File Offset: 0x0000EE0B
		private void UsersSelected()
		{
			if (this.migrationDefinition.IsSelfTransfer)
			{
				this.Navigate(DefaultPolicy.SelectedButtonEnum.Users, WizardModule.Properties.Resources.DBL_Users, "SectionUsers_Self");
				return;
			}
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Users, WizardModule.Properties.Resources.DBL_Users, "SectionUsers");
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x00010C3D File Offset: 0x0000EE3D
		// (set) Token: 0x0600078D RID: 1933 RVA: 0x00010C45 File Offset: 0x0000EE45
		public DelegateCommand OnVideosSelected { get; private set; }

		// Token: 0x0600078E RID: 1934 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanSelectVideos()
		{
			return true;
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00010C4E File Offset: 0x0000EE4E
		private void VideosSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Videos, WizardModule.Properties.Resources.DBL_Videos, "SectionDocuments");
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x00010C61 File Offset: 0x0000EE61
		// (set) Token: 0x06000791 RID: 1937 RVA: 0x00010C69 File Offset: 0x0000EE69
		public DelegateCommand OnAdvancedSelected { get; private set; }

		// Token: 0x06000792 RID: 1938 RVA: 0x00010C74 File Offset: 0x0000EE74
		private bool CanSelectAdvanced()
		{
			bool? interactive = this.policy.enginePolicy.DriveMap.Interactive;
			bool flag = false;
			if (interactive.GetValueOrDefault() == flag & interactive != null)
			{
				interactive = this.policy.enginePolicy.MigMod.Interactive;
				flag = false;
				if (interactive.GetValueOrDefault() == flag & interactive != null)
				{
					interactive = this.policy.enginePolicy.FileFilter.Interactive;
					flag = false;
					return !(interactive.GetValueOrDefault() == flag & interactive != null);
				}
			}
			return true;
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00010D08 File Offset: 0x0000EF08
		private void AdvancedSelected()
		{
			this.Navigate(DefaultPolicy.SelectedButtonEnum.Advanced, WizardModule.Properties.Resources.DBL_Advanced, "SectionAdvanced");
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x00010D1B File Offset: 0x0000EF1B
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x00010D23 File Offset: 0x0000EF23
		public DelegateCommand OnSizeInfo { get; private set; }

		// Token: 0x06000796 RID: 1942 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSizeInfoCommand()
		{
			return true;
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00010D2C File Offset: 0x0000EF2C
		private void OnSizeInfoCommand()
		{
			DetailButtonListViewModel.<OnSizeInfoCommand>d__228 <OnSizeInfoCommand>d__;
			<OnSizeInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSizeInfoCommand>d__.<>4__this = this;
			<OnSizeInfoCommand>d__.<>1__state = -1;
			<OnSizeInfoCommand>d__.<>t__builder.Start<DetailButtonListViewModel.<OnSizeInfoCommand>d__228>(ref <OnSizeInfoCommand>d__);
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x00010D63 File Offset: 0x0000EF63
		// (set) Token: 0x06000799 RID: 1945 RVA: 0x00010D6B File Offset: 0x0000EF6B
		public DelegateCommand OnAppsUpgradeSelected { get; private set; }

		// Token: 0x0600079A RID: 1946 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnAppsUpgradeCommand()
		{
			return true;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00010D74 File Offset: 0x0000EF74
		private void OnAppsUpgradeCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.URL_Upsell_ApplicationsButton));
			}
			catch
			{
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x00010DA8 File Offset: 0x0000EFA8
		// (set) Token: 0x0600079D RID: 1949 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		public DelegateCommand OnUsersUpgradeSelected { get; private set; }

		// Token: 0x0600079E RID: 1950 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnUsersUpgradeCommand()
		{
			return true;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00010DBC File Offset: 0x0000EFBC
		private void OnUsersUpgradeCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.URL_Upsell_UsersButton));
			}
			catch
			{
			}
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00010DF0 File Offset: 0x0000EFF0
		private void OnAnalyzeComputer(TaskStats stats)
		{
			try
			{
				bool flag = false;
				try
				{
					MiscSettingsGroupData miscSettingsGroupData = base.pcmoverEngine.MiscSettingsData.Groups.FirstOrDefault((MiscSettingsGroupData group) => ((group != null) ? group.Name : null) == "Troubleshooting");
					if (miscSettingsGroupData != null)
					{
						MiscSettingData miscSettingData = miscSettingsGroupData.Settings.FirstOrDefault((MiscSettingData setting) => setting.Name == "Move Nothing");
						if (miscSettingData != null)
						{
							flag = miscSettingData.Selected;
						}
					}
				}
				catch
				{
					flag = false;
				}
				if (flag)
				{
					base.pcmoverEngine.TotalTransferSize = 0.0;
					this.TotalSize = base.pcmoverEngine.TotalTransferSize;
				}
				else if (stats != null)
				{
					ContainerStats disk = stats.Disk;
					ulong? num = (disk != null) ? new ulong?(disk.TotalSize) : null;
					ulong num2 = 0UL;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						base.pcmoverEngine.TotalTransferSize = stats.Disk.TotalSize;
						this.TotalSize = base.pcmoverEngine.TotalTransferSize;
					}
				}
			}
			catch
			{
			}
			this.CalculateSpeed();
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00010F44 File Offset: 0x0000F144
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this._navigationContext = navigationContext;
			this.ShowAppButton = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowApps);
			this.ShowAppButtonUnavalable = !Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowApps);
			this.ShowUserButton = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowUsers);
			this.ShowUserOnlyButton = !Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowUsers);
			this.ShowDocsButton = this.policy.detailButtonListPolicy.DblShowDocsButton;
			this.ShowPicsButton = this.policy.detailButtonListPolicy.DblShowPicsButton;
			this.ShowVideoButton = this.policy.detailButtonListPolicy.DblShowVideoButton;
			this.ShowMusicButton = this.policy.detailButtonListPolicy.DblShowMusicButton;
			this.ShowOtherButton = this.policy.detailButtonListPolicy.DblShowOtherButton;
			this.ShowAdvancedButton = this.policy.detailButtonListPolicy.DblShowAdvancedButton;
			this.Update();
			if (navigationContext.NavigationService.Region.Name == RegionNames.SummaryDetailButtons)
			{
				this.Title = WizardModule.Properties.Resources.DBL_WhatWill;
			}
			else if (navigationContext.NavigationService.Region.Name == RegionNames.TransferCompleteDetailButtons)
			{
				this.Title = WizardModule.Properties.Resources.DBL_WhatWas;
			}
			else if (navigationContext.NavigationService.Region.Name == RegionNames.FilesBasedSummaryDetailButtons)
			{
				this.Title = WizardModule.Properties.Resources.DBL_WhatWill;
			}
			else
			{
				this.Title = WizardModule.Properties.Resources.DBL_Select;
			}
			if (this.policy.detailButtonListPolicy.DblSelectedButton != DefaultPolicy.SelectedButtonEnum.None && (!this.policy.detailButtonListPolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy) && !this._PolicyAutoNavigated)
			{
				this._PolicyAutoNavigated = true;
				this.Navigate(this.policy.detailButtonListPolicy.DblSelectedButton, this.policy.detailButtonListPolicy.DblTitle, this.policy.detailButtonListPolicy.DblRegion);
				return;
			}
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				this.IsUserMappingEnabled = (base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin || base.pcmoverEngine.OtherMachine.IsEngineRunningAsAdmin);
			}, "OnNavigatedTo"))
			{
				return;
			}
			if (this.IsUserMappingEnabled)
			{
				bool? interactive = this.policy.enginePolicy.UserMap.Interactive;
				bool flag = false;
				this.IsUserMappingEnabled = !(interactive.GetValueOrDefault() == flag & interactive != null);
			}
			if (navigationContext.Parameters["PPMCustomizationMode"] != null || this.migrationDefinition.CustomizeScreen == CustomizationScreen.PPMCustomize)
			{
				this._PPMCustomizationMode = true;
			}
			if (!this._PPMCustomizationMode && this.migrationDefinition.IsSelfTransfer)
			{
				this.Navigate(DefaultPolicy.SelectedButtonEnum.Users, WizardModule.Properties.Resources.DBL_Users, "SectionUsers_Self");
			}
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x000111CC File Offset: 0x0000F3CC
		private void Navigate(DefaultPolicy.SelectedButtonEnum selectedButton, string Title, string RegionName)
		{
			this.SelectedButton = selectedButton;
			this.policy.detailButtonListPolicy.DblSelectedButton = this.SelectedButton;
			this.policy.detailButtonListPolicy.DblTitle = Title;
			this.policy.detailButtonListPolicy.DblRegion = RegionName;
			this.policy.WriteProfile();
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("Index", (int)selectedButton);
			navigationParameters.Add("Title", Title);
			navigationParameters.Add("Region", RegionName);
			this.eventAggregator.GetEvent<SelectionChanged>().Publish(navigationParameters);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00011264 File Offset: 0x0000F464
		private void Update()
		{
			DetailButtonListViewModel.<Update>d__246 <Update>d__;
			<Update>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<DetailButtonListViewModel.<Update>d__246>(ref <Update>d__);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001129B File Offset: 0x0000F49B
		private void CalculateSpeed()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (this.migrationDefinition.TotalElapsedTransferTime != TimeSpan.Zero)
				{
					this.TotalTime = Tools.GetDisplayTime(this.migrationDefinition.TotalElapsedTransferTime);
					return;
				}
				if (base.pcmoverEngine.TotalTransferTime == TimeSpan.Zero)
				{
					ulong num = 100000000UL;
					ConnectableMachine targetMachine = base.pcmoverEngine.TargetMachine;
					TransferMethodType? transferMethodType = (targetMachine != null) ? new TransferMethodType?(targetMachine.Method) : null;
					if (transferMethodType != null)
					{
						TransferMethodType valueOrDefault = transferMethodType.GetValueOrDefault();
						if (valueOrDefault <= TransferMethodType.Image)
						{
							if (valueOrDefault != TransferMethodType.File && valueOrDefault != TransferMethodType.Image)
							{
							}
						}
						else if (valueOrDefault != TransferMethodType.Network)
						{
							if (valueOrDefault == TransferMethodType.Usb && this.migrationDefinition.TransferSpeed > 0UL)
							{
								num = this.migrationDefinition.TransferSpeed * 57UL / 100UL;
							}
						}
						else if (this.migrationDefinition.TransferSpeed > 0UL)
						{
							num = this.migrationDefinition.TransferSpeed * 49UL / 100UL;
						}
					}
					int seconds = (int)(this.TotalSize / num) + 59;
					TimeSpan span = new TimeSpan(0, 0, seconds);
					this.TotalTime = Tools.GetDisplayTime(span);
					return;
				}
				this.TotalTime = Tools.GetDisplayTime(base.pcmoverEngine.TotalTransferTime);
			}, "CalculateSpeed");
		}

		// Token: 0x040001D0 RID: 464
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040001D1 RID: 465
		private NavigationContext _navigationContext;

		// Token: 0x040001D2 RID: 466
		private readonly DefaultPolicy policy;

		// Token: 0x040001D3 RID: 467
		private bool _PolicyAutoNavigated;

		// Token: 0x040001D4 RID: 468
		private bool _PPMCustomizationMode;

		// Token: 0x040001D5 RID: 469
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040001D6 RID: 470
		private int _GreenApplicationCount;

		// Token: 0x040001D7 RID: 471
		private int _YellowApplicationCount;

		// Token: 0x040001D8 RID: 472
		private int _RedApplicationCount;

		// Token: 0x040001D9 RID: 473
		private int _GreenSelectedApplicationCount;

		// Token: 0x040001DA RID: 474
		private int _YellowSelectedApplicationCount;

		// Token: 0x040001DB RID: 475
		private int _RedSelectedApplicationCount;

		// Token: 0x040001DC RID: 476
		private string _TotalApplicationSize;

		// Token: 0x040001DD RID: 477
		private int _DocumentsFolderCount;

		// Token: 0x040001DE RID: 478
		private int _DocumentsFileCount;

		// Token: 0x040001DF RID: 479
		private string _FormattedDocumentsSize;

		// Token: 0x040001E0 RID: 480
		private int _MusicFolderCount;

		// Token: 0x040001E1 RID: 481
		private int _MusicFileCount;

		// Token: 0x040001E2 RID: 482
		private string _FormattedMusicSize;

		// Token: 0x040001E3 RID: 483
		private int _PicturesFolderCount;

		// Token: 0x040001E4 RID: 484
		private int _PicturesFileCount;

		// Token: 0x040001E5 RID: 485
		private string _FormattedPicturesSize;

		// Token: 0x040001E6 RID: 486
		private int _VideoFolderCount;

		// Token: 0x040001E7 RID: 487
		private int _VideoFileCount;

		// Token: 0x040001E8 RID: 488
		private string _FormattedVideoSize;

		// Token: 0x040001E9 RID: 489
		private int _OtherFolderCount;

		// Token: 0x040001EA RID: 490
		private int _OtherFileCount;

		// Token: 0x040001EB RID: 491
		private string _FormattedOtherSize;

		// Token: 0x040001EC RID: 492
		private string _UsersCount;

		// Token: 0x040001ED RID: 493
		private double _TotalSize;

		// Token: 0x040001EE RID: 494
		private string _TotalTime = string.Empty;

		// Token: 0x040001EF RID: 495
		private string _Title;

		// Token: 0x040001F0 RID: 496
		private bool _IsApplicationTransferEnabled;

		// Token: 0x040001F1 RID: 497
		private bool _IsSizeDisplayed;

		// Token: 0x040001F2 RID: 498
		private bool _IsEstimated;

		// Token: 0x040001F3 RID: 499
		private bool _IsUserMappingEnabled;

		// Token: 0x040001F4 RID: 500
		private bool _IsDirFilterEnabled;

		// Token: 0x040001F5 RID: 501
		private DefaultPolicy.SelectedButtonEnum _SelectedButton;

		// Token: 0x040001F6 RID: 502
		private bool _ShowAppButton;

		// Token: 0x040001F7 RID: 503
		private bool _ShowAppButtonUnavalable;

		// Token: 0x040001F8 RID: 504
		private bool _ShowDocsButton;

		// Token: 0x040001F9 RID: 505
		private bool _ShowPicsButton;

		// Token: 0x040001FA RID: 506
		private bool _ShowVideoButton;

		// Token: 0x040001FB RID: 507
		private bool _ShowMusicButton;

		// Token: 0x040001FC RID: 508
		private bool _ShowOtherButton;

		// Token: 0x040001FD RID: 509
		private bool _ShowUserButton;

		// Token: 0x040001FE RID: 510
		private bool _ShowUserOnlyButton;

		// Token: 0x040001FF RID: 511
		private bool _ShowAdvancedButton;
	}
}
