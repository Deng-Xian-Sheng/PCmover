using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;

namespace WizardModule.ViewModels
{
	// Token: 0x02000092 RID: 146
	public class SectionUsers_SelfViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000BE8 RID: 3048 RVA: 0x0001F130 File Offset: 0x0001D330
		public SectionUsers_SelfViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, IWizardParameters wizardParameters, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardParameters = wizardParameters;
			this._navigationHelper = navigationHelper;
			this.OnMapUsers = new DelegateCommand(new Action(this.OnMapUsersCommand), new Func<bool>(this.CanOnMapUsersCommand));
			this.OnSourceUserChanged = new DelegateCommand<UserDetail>(new Action<UserDetail>(this.OnSourceUserChangedCommand), new Func<UserDetail, bool>(this.CanOnSourceUserChangedCommand));
			this.OnTargetUserChanged = new DelegateCommand<UserDetail>(new Action<UserDetail>(this.OnTargetUserChangedCommand), new Func<UserDetail, bool>(this.CanOnTargetUserChangedCommand));
			this.OnDeleteMapping = new DelegateCommand<UserMapping>(new Action<UserMapping>(this.OnDeleteMappingCommand), new Func<UserMapping, bool>(this.CanOnDeleteMappingCommand));
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0001F1FA File Offset: 0x0001D3FA
		// (set) Token: 0x06000BEA RID: 3050 RVA: 0x0001F202 File Offset: 0x0001D402
		public bool IsReadOnly
		{
			get
			{
				return this._IsReadOnly;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsReadOnly, value, "IsReadOnly");
			}
		}

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x0001F217 File Offset: 0x0001D417
		// (set) Token: 0x06000BEC RID: 3052 RVA: 0x0001F21F File Offset: 0x0001D41F
		public ObservableCollection<UserMapping> Mappings
		{
			get
			{
				return this._Mappings;
			}
			private set
			{
				this.SetProperty<ObservableCollection<UserMapping>>(ref this._Mappings, value, "Mappings");
			}
		}

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x0001F234 File Offset: 0x0001D434
		// (set) Token: 0x06000BEE RID: 3054 RVA: 0x0001F23C File Offset: 0x0001D43C
		public ObservableCollection<UserDetail> SourceUsers
		{
			get
			{
				return this._SourceUsers;
			}
			private set
			{
				this.SetProperty<ObservableCollection<UserDetail>>(ref this._SourceUsers, value, "SourceUsers");
			}
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06000BEF RID: 3055 RVA: 0x0001F251 File Offset: 0x0001D451
		// (set) Token: 0x06000BF0 RID: 3056 RVA: 0x0001F259 File Offset: 0x0001D459
		public ObservableCollection<UserDetail> TargetUsers
		{
			get
			{
				return this._TargetUsers;
			}
			private set
			{
				this.SetProperty<ObservableCollection<UserDetail>>(ref this._TargetUsers, value, "TargetUsers");
			}
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x0001F26E File Offset: 0x0001D46E
		// (set) Token: 0x06000BF2 RID: 3058 RVA: 0x0001F276 File Offset: 0x0001D476
		public UserDetail SelectedSourceUser
		{
			get
			{
				return this._SelectedRegularUser;
			}
			set
			{
				this.SetProperty<UserDetail>(ref this._SelectedRegularUser, value, "SelectedSourceUser");
				this.OnMapUsers.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x0001F296 File Offset: 0x0001D496
		// (set) Token: 0x06000BF4 RID: 3060 RVA: 0x0001F29E File Offset: 0x0001D49E
		public UserDetail SelectedTargetUser
		{
			get
			{
				return this._SelectedAzureUser;
			}
			set
			{
				this.SetProperty<UserDetail>(ref this._SelectedAzureUser, value, "SelectedTargetUser");
				this.OnMapUsers.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x0001F2BE File Offset: 0x0001D4BE
		// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x0001F2C6 File Offset: 0x0001D4C6
		public DelegateCommand<UserDetail> OnSourceUserChanged { get; private set; }

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0001F2CF File Offset: 0x0001D4CF
		private bool CanOnSourceUserChangedCommand(UserDetail arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0001F2DA File Offset: 0x0001D4DA
		private void OnSourceUserChangedCommand(UserDetail user)
		{
			this.SelectedSourceUser = user;
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x0001F2E3 File Offset: 0x0001D4E3
		// (set) Token: 0x06000BFA RID: 3066 RVA: 0x0001F2EB File Offset: 0x0001D4EB
		public DelegateCommand<UserDetail> OnTargetUserChanged { get; private set; }

		// Token: 0x06000BFB RID: 3067 RVA: 0x0001F2CF File Offset: 0x0001D4CF
		private bool CanOnTargetUserChangedCommand(UserDetail arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0001F2F4 File Offset: 0x0001D4F4
		private void OnTargetUserChangedCommand(UserDetail user)
		{
			this.SelectedTargetUser = user;
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x0001F2FD File Offset: 0x0001D4FD
		// (set) Token: 0x06000BFE RID: 3070 RVA: 0x0001F305 File Offset: 0x0001D505
		public DelegateCommand OnMapUsers { get; private set; }

		// Token: 0x06000BFF RID: 3071 RVA: 0x0001F310 File Offset: 0x0001D510
		private bool CanOnMapUsersCommand()
		{
			return this.SelectedSourceUser != null && this.SelectedTargetUser != null && !this.IsReadOnly && this.SourceUsers.Contains(this.SelectedSourceUser) && this.TargetUsers.Contains(this.SelectedTargetUser) && this.SelectedSourceUser.AccountName != this.SelectedTargetUser.AccountName;
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0001F37C File Offset: 0x0001D57C
		private void OnMapUsersCommand()
		{
			SectionUsers_SelfViewModel.<OnMapUsersCommand>d__48 <OnMapUsersCommand>d__;
			<OnMapUsersCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnMapUsersCommand>d__.<>4__this = this;
			<OnMapUsersCommand>d__.<>1__state = -1;
			<OnMapUsersCommand>d__.<>t__builder.Start<SectionUsers_SelfViewModel.<OnMapUsersCommand>d__48>(ref <OnMapUsersCommand>d__);
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x0001F3B3 File Offset: 0x0001D5B3
		// (set) Token: 0x06000C02 RID: 3074 RVA: 0x0001F3BB File Offset: 0x0001D5BB
		public DelegateCommand<UserMapping> OnDeleteMapping { get; private set; }

		// Token: 0x06000C03 RID: 3075 RVA: 0x0001F2CF File Offset: 0x0001D4CF
		private bool CanOnDeleteMappingCommand(UserMapping arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0001F3C4 File Offset: 0x0001D5C4
		private void OnDeleteMappingCommand(UserMapping map)
		{
			this.TargetUsers.Add(map.New);
			this.TargetUsers.Add(map.Old);
			this.SourceUsers.Add(map.New);
			this.SourceUsers.Add(map.Old);
			map.New = null;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.ChangeUserMapping(map);
			}, "OnDeleteMappingCommand"))
			{
				return;
			}
			ObservableCollection<EnginePolicy.UserPolicy> users = this.policy.enginePolicy.UserMap.Users;
			EnginePolicy.UserPolicy userPolicy = (users != null) ? users.FirstOrDefault((EnginePolicy.UserPolicy x) => x.Source == map.Old.FriendlyName) : null;
			if (userPolicy != null)
			{
				this.policy.enginePolicy.UserMap.Users.Remove(userPolicy);
			}
			this.migrationDefinition.DirtyCustomizationItems |= CustomizationAffects.DiskItems;
			this.Update();
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0001F4CF File Offset: 0x0001D6CF
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(false);
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0001F4E4 File Offset: 0x0001D6E4
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			SectionUsers_SelfViewModel.<OnNavigatedTo>d__57 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.navigationContext = navigationContext;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<SectionUsers_SelfViewModel.<OnNavigatedTo>d__57>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0001F524 File Offset: 0x0001D724
		private void Update()
		{
			SectionUsers_SelfViewModel.<Update>d__58 <Update>d__;
			<Update>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<SectionUsers_SelfViewModel.<Update>d__58>(ref <Update>d__);
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0001F55C File Offset: 0x0001D75C
		private void PopulateUserLists()
		{
			UserMappings users = base.pcmoverEngine.Users;
			IEnumerable<UserMapping> enumerable;
			if (users == null)
			{
				enumerable = null;
			}
			else
			{
				IEnumerable<UserMapping> mappings = users.Mappings;
				if (mappings == null)
				{
					enumerable = null;
				}
				else
				{
					enumerable = from x in mappings
					where x.Old != null && x.New == null
					select x;
				}
			}
			IEnumerable<UserMapping> enumerable2 = enumerable;
			IEnumerable<UserDetail> collection;
			if (enumerable2 == null)
			{
				collection = null;
			}
			else
			{
				collection = from x in enumerable2
				select x.Old;
			}
			this.SourceUsers = new ObservableCollection<UserDetail>(collection);
			UserMappings users2 = base.pcmoverEngine.Users;
			IEnumerable<UserMapping> collection2;
			if (users2 == null)
			{
				collection2 = null;
			}
			else
			{
				IEnumerable<UserMapping> mappings2 = users2.Mappings;
				if (mappings2 == null)
				{
					collection2 = null;
				}
				else
				{
					collection2 = from x in mappings2
					where x.New != null
					select x;
				}
			}
			this.Mappings = new ObservableCollection<UserMapping>(collection2);
			using (IEnumerator<UserMapping> enumerator = this.Mappings.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UserMapping mapping = enumerator.Current;
					UserDetail userDetail = this.SourceUsers.FirstOrDefault((UserDetail x) => x.AccountName == mapping.New.AccountName);
					if (userDetail != null)
					{
						this.SourceUsers.Remove(userDetail);
					}
				}
			}
			this.TargetUsers = new ObservableCollection<UserDetail>(this.SourceUsers);
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0001F6AC File Offset: 0x0001D8AC
		private void ExpandEnvVariables()
		{
			this.policy.WriteProfile();
		}

		// Token: 0x040003CB RID: 971
		private readonly IRegionManager regionManager;

		// Token: 0x040003CC RID: 972
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040003CD RID: 973
		private bool _MappingInitialized;

		// Token: 0x040003CE RID: 974
		private readonly DefaultPolicy policy;

		// Token: 0x040003CF RID: 975
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x040003D0 RID: 976
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040003D1 RID: 977
		private bool _IsReadOnly;

		// Token: 0x040003D2 RID: 978
		private ObservableCollection<UserMapping> _Mappings;

		// Token: 0x040003D3 RID: 979
		private ObservableCollection<UserDetail> _SourceUsers;

		// Token: 0x040003D4 RID: 980
		private ObservableCollection<UserDetail> _TargetUsers;

		// Token: 0x040003D5 RID: 981
		private UserDetail _SelectedRegularUser;

		// Token: 0x040003D6 RID: 982
		private UserDetail _SelectedAzureUser;
	}
}
