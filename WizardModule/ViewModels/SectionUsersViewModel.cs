using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
	// Token: 0x02000091 RID: 145
	public class SectionUsersViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000BB3 RID: 2995 RVA: 0x0001DC34 File Offset: 0x0001BE34
		public SectionUsersViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this.OnSave = new DelegateCommand<UserMap>(new Action<UserMap>(this.OnSaveCommand), new Func<UserMap, bool>(this.CanOnSaveCommand));
			this.OnCancel = new DelegateCommand<UserMap>(new Action<UserMap>(this.OnCancelCommand), new Func<UserMap, bool>(this.CanOnCancelCommand));
			this.OnEdit = new DelegateCommand<UserMap>(new Action<UserMap>(this.OnEditCommand), new Func<UserMap, bool>(this.CanOnEditCommand));
			this.OnFilesBasedUserSelectionChanged = new DelegateCommand<string>(new Action<string>(this.OnFilesBasedUserSelectionChangedCommand), new Func<string, bool>(this.CanOnFilesBasedUserSelectionChangedCommand));
			this.AccountTypes = new Dictionary<string, UserType>();
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x0001DCF9 File Offset: 0x0001BEF9
		// (set) Token: 0x06000BB5 RID: 2997 RVA: 0x0001DD01 File Offset: 0x0001BF01
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

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x0001DD16 File Offset: 0x0001BF16
		// (set) Token: 0x06000BB7 RID: 2999 RVA: 0x0001DD1E File Offset: 0x0001BF1E
		public bool IsFilesBased
		{
			get
			{
				return this._IsFilesBased;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsFilesBased, value, "IsFilesBased");
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x0001DD33 File Offset: 0x0001BF33
		// (set) Token: 0x06000BB9 RID: 3001 RVA: 0x0001DD3B File Offset: 0x0001BF3B
		public ObservableCollection<UserMap> Mappings
		{
			get
			{
				return this._Mappings;
			}
			private set
			{
				this.SetProperty<ObservableCollection<UserMap>>(ref this._Mappings, value, "Mappings");
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x0001DD50 File Offset: 0x0001BF50
		// (set) Token: 0x06000BBB RID: 3003 RVA: 0x0001DD58 File Offset: 0x0001BF58
		public IEnumerable<UserDetail> UnusedUsersOnNew
		{
			get
			{
				return this._UnusedUsersOnNew;
			}
			private set
			{
				this.SetProperty<IEnumerable<UserDetail>>(ref this._UnusedUsersOnNew, value, "UnusedUsersOnNew");
			}
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x0001DD6D File Offset: 0x0001BF6D
		// (set) Token: 0x06000BBD RID: 3005 RVA: 0x0001DD75 File Offset: 0x0001BF75
		public ExistingUsers ExistingUsersOnNew
		{
			get
			{
				return this._ExistingUsersOnNew;
			}
			private set
			{
				this.SetProperty<ExistingUsers>(ref this._ExistingUsersOnNew, value, "ExistingUsersOnNew");
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x0001DD8A File Offset: 0x0001BF8A
		// (set) Token: 0x06000BBF RID: 3007 RVA: 0x0001DD92 File Offset: 0x0001BF92
		public UserDetail CurrentUser
		{
			get
			{
				return this._CurrentUser;
			}
			private set
			{
				this.SetProperty<UserDetail>(ref this._CurrentUser, value, "CurrentUser");
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0001DDA7 File Offset: 0x0001BFA7
		// (set) Token: 0x06000BC1 RID: 3009 RVA: 0x0001DDAF File Offset: 0x0001BFAF
		public string DomainMessage
		{
			get
			{
				return this._DomainMessage;
			}
			private set
			{
				this.SetProperty<string>(ref this._DomainMessage, value, "DomainMessage");
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0001DDC4 File Offset: 0x0001BFC4
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x0001DDCC File Offset: 0x0001BFCC
		public bool CompactDisplayEditMapping
		{
			get
			{
				return this._CompactDisplayEditMapping;
			}
			private set
			{
				this.SetProperty<bool>(ref this._CompactDisplayEditMapping, value, "CompactDisplayEditMapping");
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0001DDE1 File Offset: 0x0001BFE1
		// (set) Token: 0x06000BC5 RID: 3013 RVA: 0x0001DDEC File Offset: 0x0001BFEC
		public UserMap SelectedMapping
		{
			get
			{
				return this._SelectedMapping;
			}
			set
			{
				this.SetProperty<UserMap>(ref this._SelectedMapping, value, "SelectedMapping");
				if (value != null)
				{
					string su_TransferCurrent = Resources.SU_TransferCurrent;
					UserDetail old = value.Old;
					object arg = (old != null) ? old.DisplayName : null;
					UserDetail currentUser = this.CurrentUser;
					this.CurrentLoggedInUser = string.Format(su_TransferCurrent, arg, (currentUser != null) ? currentUser.DisplayName : null);
					base.RaisePropertyChanged("CurrentLoggedInUser");
					string su_CreateAUser = Resources.SU_CreateAUser;
					UserDetail old2 = value.Old;
					this.CreateAUser = string.Format(su_CreateAUser, (old2 != null) ? old2.DisplayName : null);
					base.RaisePropertyChanged("CreateAUser");
					string su_MapAUser = Resources.SU_MapAUser;
					UserDetail old3 = value.Old;
					this.MapAUser = string.Format(su_MapAUser, (old3 != null) ? old3.DisplayName : null);
					base.RaisePropertyChanged("MapAUser");
					string su_DontTransferUser = Resources.SU_DontTransferUser;
					UserDetail old4 = value.Old;
					this.DontTransferUser = string.Format(su_DontTransferUser, (old4 != null) ? old4.DisplayName : null);
					base.RaisePropertyChanged("DontTransferUser");
					List<string> availableProfiles = this._SelectedMapping.AvailableProfiles;
					this.ProfilesExist = (availableProfiles != null && availableProfiles.Count > 0);
					base.RaisePropertyChanged("ProfilesExist");
				}
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x0001DF03 File Offset: 0x0001C103
		// (set) Token: 0x06000BC7 RID: 3015 RVA: 0x0001DF0B File Offset: 0x0001C10B
		public bool ProfilesExist
		{
			get
			{
				return this._ProfilesExist;
			}
			set
			{
				this.SetProperty<bool>(ref this._ProfilesExist, value, "ProfilesExist");
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0001DF20 File Offset: 0x0001C120
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x0001DF28 File Offset: 0x0001C128
		public string CurrentLoggedInUser
		{
			get
			{
				return this._CurrentLoggedInUser;
			}
			set
			{
				this.SetProperty<string>(ref this._CurrentLoggedInUser, value, "CurrentLoggedInUser");
			}
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x0001DF3D File Offset: 0x0001C13D
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x0001DF45 File Offset: 0x0001C145
		public string CreateAUser
		{
			get
			{
				return this._CreateAUser;
			}
			set
			{
				this.SetProperty<string>(ref this._CreateAUser, value, "CreateAUser");
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x0001DF5A File Offset: 0x0001C15A
		// (set) Token: 0x06000BCD RID: 3021 RVA: 0x0001DF62 File Offset: 0x0001C162
		public string MapAUser
		{
			get
			{
				return this._MapAUser;
			}
			set
			{
				this.SetProperty<string>(ref this._MapAUser, value, "MapAUser");
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x0001DF77 File Offset: 0x0001C177
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x0001DF7F File Offset: 0x0001C17F
		public string DontTransferUser
		{
			get
			{
				return this._DontTransferUser;
			}
			set
			{
				this.SetProperty<string>(ref this._DontTransferUser, value, "DontTransferUser");
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0001DF94 File Offset: 0x0001C194
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x0001DF9C File Offset: 0x0001C19C
		public DelegateCommand<UserMap> OnSave { get; private set; }

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSaveCommand(UserMap arg)
		{
			return true;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0001DFA8 File Offset: 0x0001C1A8
		private void OnSaveCommand(UserMap m)
		{
			m.IsUserTypeEnabled = false;
			if (m.Create)
			{
				if (m.New == null)
				{
					m.New = new UserDetail();
				}
				if (!this.ValidateMapping(m.Old, m.Old.FriendlyName))
				{
					return;
				}
				m.New.AccountName = m.Old.FriendlyName;
				m.New.FriendlyName = m.Old.FriendlyName;
				m.New.FullName = m.Old.FullName;
				m.New.UserType = m.Old.UserType;
			}
			else if (m.Current)
			{
				if (this.CurrentUser != null)
				{
					if (m.New == null)
					{
						m.New = new UserDetail();
					}
					if (!this.ValidateMapping(m.Old, this.CurrentUser.FriendlyName))
					{
						return;
					}
					m.New.AccountName = this.CurrentUser.AccountName;
					m.New.FriendlyName = this.CurrentUser.FriendlyName;
					m.New.FullName = this.CurrentUser.FullName;
					m.New.UserType = this.CurrentUser.UserType;
				}
			}
			else if (m.DontMigrate)
			{
				m.New = null;
			}
			else if (m.NewUser)
			{
				if (!Tools.IsValidWindowsAccountName(m.NewAccountName))
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_EnterName, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					return;
				}
				if (!this.ValidateMapping(m.Old, m.NewAccountName))
				{
					return;
				}
				if (m.NewAccountName.Contains("\\") && !this.Mappings.Any((UserMap x) => x.Old.FriendlyName.ToLower() == m.NewAccountName.ToLower()))
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_CantCreateDomainFromLocal, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					return;
				}
				m.New = new UserDetail();
				m.New.AccountName = m.NewAccountName;
				m.New.FriendlyName = m.NewAccountName;
				m.New.FullName = m.NewAccountName;
				if (this._IsUserElevated)
				{
					m.New.UserType = m.Old.UserType;
					m.Old.UserType = this.AccountTypes[m.Old.AccountName];
				}
				else
				{
					m.New.UserType = this.AccountTypes[m.Old.AccountName];
				}
			}
			else if (m.Existing)
			{
				if (m.New == null)
				{
					m.New = new UserDetail();
				}
				if (this.ExistingUsersOnNew.SelectedUser == null)
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_SelectUser, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					return;
				}
				if (!this.ValidateMapping(m.Old, this.ExistingUsersOnNew.SelectedUser.FriendlyName))
				{
					return;
				}
				m.New.AccountName = this.ExistingUsersOnNew.SelectedUser.AccountName;
				m.New.FriendlyName = this.ExistingUsersOnNew.SelectedUser.FriendlyName;
				m.New.FullName = this.ExistingUsersOnNew.SelectedUser.FullName;
				m.New.UserType = this.AccountTypes[this.ExistingUsersOnNew.SelectedUser.AccountName];
			}
			base.RaisePropertyChanged("Mappings");
			Func<UserMapping, bool> <>9__2;
			Func<EnginePolicy.UserPolicy, bool> <>9__3;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				IEnumerable<UserMapping> mappings = this.pcmoverEngine.Users.Mappings;
				Func<UserMapping, bool> predicate;
				if ((predicate = <>9__2) == null)
				{
					predicate = (<>9__2 = ((UserMapping x) => x.Old.AccountName == m.Old.AccountName));
				}
				UserMapping userMapping = mappings.FirstOrDefault(predicate);
				if (userMapping != null)
				{
					UserMapping userMapping2 = new UserMapping
					{
						Old = userMapping.Old,
						New = userMapping.New,
						Create = userMapping.Create,
						MapiProfileMappings = userMapping.MapiProfileMappings
					};
					using (List<MapiProfileMapping>.Enumerator enumerator = m.MapiProfileMappings.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							MapiProfileMapping profileMapping = enumerator.Current;
							if (!profileMapping.Transfer)
							{
								profileMapping.NewProfile = string.Empty;
							}
							else if (string.IsNullOrEmpty(profileMapping.NewProfile))
							{
								WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_InvalidProfileName, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
								return;
							}
							List<MapiProfileMapping> mapiProfileMappings = m.MapiProfileMappings;
							if (mapiProfileMappings != null && mapiProfileMappings.Count((MapiProfileMapping p) => !string.IsNullOrEmpty(p.NewProfile) && p.NewProfile == profileMapping.NewProfile) > 1)
							{
								WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_ProfileNameAlreadyUsed, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
								return;
							}
						}
					}
					userMapping.MapiProfileMappings = m.MapiProfileMappings;
					userMapping.Create = (m.NewUser || m.Create);
					userMapping.New = m.New;
					CustomizationData customizationData = this.pcmoverEngine.ChangeUserMapping(userMapping);
					if (customizationData.Result != CustomizationResult.Success)
					{
						if (!string.IsNullOrEmpty(customizationData.Message))
						{
							WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, customizationData.Message, Resources.strError + " " + customizationData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
						}
						else
						{
							WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_Error, Resources.strError + " " + customizationData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
						}
						userMapping.New = userMapping2.New;
						userMapping.Create = userMapping2.Create;
						userMapping.MapiProfileMappings = userMapping2.MapiProfileMappings;
					}
					else if (!string.IsNullOrEmpty(customizationData.Message))
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, customizationData.Message, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					}
					this.migrationDefinition.DirtyCustomizationItems |= customizationData.Affects;
				}
				IEnumerable<EnginePolicy.UserPolicy> users = this.policy.enginePolicy.UserMap.Users;
				Func<EnginePolicy.UserPolicy, bool> predicate2;
				if ((predicate2 = <>9__3) == null)
				{
					predicate2 = (<>9__3 = ((EnginePolicy.UserPolicy x) => x.Source == m.Old.FriendlyName));
				}
				EnginePolicy.UserPolicy userPolicy = users.FirstOrDefault(predicate2);
				if (userPolicy == null)
				{
					userPolicy = new EnginePolicy.UserPolicy
					{
						Source = m.Old.FriendlyName
					};
					this.policy.enginePolicy.UserMap.Users.Add(userPolicy);
				}
				if (m.New != null)
				{
					userPolicy.Target = m.New.FriendlyName;
					userPolicy.TargetType = m.New.UserType.ToString();
					userPolicy.Migrate = true;
				}
				else
				{
					userPolicy.Target = null;
					userPolicy.TargetType = null;
					userPolicy.Migrate = false;
				}
				m.EditMode = false;
				this.Update();
			}, "OnSaveCommand");
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0001E46E File Offset: 0x0001C66E
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x0001E476 File Offset: 0x0001C676
		public DelegateCommand<UserMap> OnCancel { get; private set; }

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand(UserMap arg)
		{
			return true;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0001E47F File Offset: 0x0001C67F
		private void OnCancelCommand(UserMap m)
		{
			m.EditMode = false;
			m.IsUserTypeEnabled = false;
			this.Update();
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0001E495 File Offset: 0x0001C695
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x0001E49D File Offset: 0x0001C69D
		public DelegateCommand<UserMap> OnEdit { get; private set; }

		// Token: 0x06000BDA RID: 3034 RVA: 0x0001E4A6 File Offset: 0x0001C6A6
		private bool CanOnEditCommand(UserMap map)
		{
			return this.migrationDefinition.IsUserMappingSaved;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0001E4B4 File Offset: 0x0001C6B4
		private void OnEditCommand(UserMap m)
		{
			if (this.container.Resolve(Array.Empty<ResolverOverride>()).CompactUI && this.IsReadOnly)
			{
				return;
			}
			this.SelectedMapping = m;
			if (!m.NewUser)
			{
				m.NewAccountName = string.Empty;
			}
			m.EditMode = true;
			this.migrationDefinition.IsUserMappingSaved = false;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				string text = m.Old.FriendlyName.Contains("\\") ? m.Old.FriendlyName.Substring(0, m.Old.FriendlyName.IndexOf("\\")) : string.Empty;
				string a = string.IsNullOrEmpty(this.pcmoverEngine.ThisMachine.JoinedDomain) ? string.Empty : this.pcmoverEngine.ThisMachine.JoinedDomain;
				if (this.pcmoverEngine.Users.Settings.RequireJoinedDomain && !string.IsNullOrEmpty(text) && a != text)
				{
					this.DomainMessage = Resources.SU_DomainCreate;
				}
				else
				{
					this.DomainMessage = string.Empty;
				}
				this.OnEdit.RaiseCanExecuteChanged();
				if (this.container.Resolve(Array.Empty<ResolverOverride>()).CompactUI)
				{
					this.eventAggregator.GetEvent<Events.CompactUserSelected>().Publish();
					this.CompactDisplayEditMapping = true;
				}
			}, "OnEditCommand");
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x0001E553 File Offset: 0x0001C753
		// (set) Token: 0x06000BDD RID: 3037 RVA: 0x0001E55B File Offset: 0x0001C75B
		public DelegateCommand<string> OnFilesBasedUserSelectionChanged { get; private set; }

		// Token: 0x06000BDE RID: 3038 RVA: 0x0001E564 File Offset: 0x0001C764
		private bool CanOnFilesBasedUserSelectionChangedCommand(string arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0001E570 File Offset: 0x0001C770
		private void OnFilesBasedUserSelectionChangedCommand(string user)
		{
			Func<UserMap, bool> <>9__1;
			Func<UserMapping, bool> <>9__2;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				SectionUsersViewModel.<>c__DisplayClass86_1 CS$<>8__locals2 = new SectionUsersViewModel.<>c__DisplayClass86_1();
				SectionUsersViewModel.<>c__DisplayClass86_1 CS$<>8__locals3 = CS$<>8__locals2;
				IEnumerable<UserMap> mappings = this.Mappings;
				Func<UserMap, bool> predicate;
				if ((predicate = <>9__1) == null)
				{
					predicate = (<>9__1 = ((UserMap x) => x.Old.AccountName == user));
				}
				CS$<>8__locals3.m = mappings.First(predicate);
				IEnumerable<UserMapping> mappings2 = this.pcmoverEngine.Users.Mappings;
				Func<UserMapping, bool> predicate2;
				if ((predicate2 = <>9__2) == null)
				{
					predicate2 = (<>9__2 = ((UserMapping x) => x.Old.AccountName == user));
				}
				UserMapping userMapping = mappings2.FirstOrDefault(predicate2);
				if (userMapping != null)
				{
					userMapping.Create = false;
					userMapping.New = (CS$<>8__locals2.m.Selected ? userMapping.Old : null);
					CustomizationData customizationData = this.pcmoverEngine.ChangeUserMapping(userMapping);
					if (customizationData.Result != CustomizationResult.Success)
					{
						if (!string.IsNullOrEmpty(customizationData.Message))
						{
							WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, customizationData.Message, Resources.strError + " " + customizationData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
						}
						else
						{
							WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.SU_Error, Resources.strError + " " + customizationData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
						}
					}
					else if (!string.IsNullOrEmpty(customizationData.Message))
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, customizationData.Message, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					}
					this.migrationDefinition.DirtyCustomizationItems |= customizationData.Affects;
					CS$<>8__locals2.m.EditMode = false;
					EnginePolicy.UserPolicy userPolicy = this.policy.enginePolicy.UserMap.Users.FirstOrDefault((EnginePolicy.UserPolicy x) => x.Source == CS$<>8__locals2.m.Old.FriendlyName);
					if (userPolicy == null)
					{
						userPolicy = new EnginePolicy.UserPolicy
						{
							Source = CS$<>8__locals2.m.Old.FriendlyName
						};
						this.policy.enginePolicy.UserMap.Users.Add(userPolicy);
					}
					EnginePolicy.UserPolicy userPolicy2 = userPolicy;
					string target;
					if (!CS$<>8__locals2.m.Selected)
					{
						target = null;
					}
					else
					{
						UserDetail old = userMapping.Old;
						target = ((old != null) ? old.AccountName : null);
					}
					userPolicy2.Target = target;
					EnginePolicy.UserPolicy userPolicy3 = userPolicy;
					string targetType;
					if (!CS$<>8__locals2.m.Selected)
					{
						targetType = null;
					}
					else
					{
						UserDetail old2 = userMapping.Old;
						targetType = ((old2 != null) ? old2.UserType.ToString() : null);
					}
					userPolicy3.TargetType = targetType;
					userPolicy.Migrate = CS$<>8__locals2.m.Selected;
				}
			}, "OnFilesBasedUserSelectionChangedCommand");
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0001E5AE File Offset: 0x0001C7AE
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(false);
			this.policy.WriteProfile();
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0001E5CC File Offset: 0x0001C7CC
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.SecUsers);
			this.IsReadOnly = (navigationContext.NavigationService.Region.Name == RegionNames.TransferCompleteDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.SummaryDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.FilesBasedSummaryDetailButtons);
			if (!this._MappingInitialized)
			{
				if (!base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.RetrieveUsers();
					foreach (UserMapping userMapping in base.pcmoverEngine.Users.Mappings)
					{
						if (userMapping.Old != null && !this.AccountTypes.ContainsKey(userMapping.Old.AccountName))
						{
							this.AccountTypes.Add(userMapping.Old.AccountName, userMapping.Old.UserType);
						}
						if (userMapping.New != null)
						{
							Dictionary<string, UserType> accountTypes = this.AccountTypes;
							UserDetail @new = userMapping.New;
							if (!accountTypes.ContainsKey((@new != null) ? @new.AccountName : null))
							{
								Dictionary<string, UserType> accountTypes2 = this.AccountTypes;
								UserDetail new2 = userMapping.New;
								accountTypes2.Add((new2 != null) ? new2.AccountName : null, userMapping.New.UserType);
							}
						}
					}
					foreach (UserDetail userDetail in base.pcmoverEngine.Users.UnusedOnNew)
					{
						if (!this.AccountTypes.ContainsKey(userDetail.AccountName))
						{
							this.AccountTypes.Add(userDetail.AccountName, userDetail.UserType);
						}
					}
				}, "OnNavigatedTo"))
				{
					return;
				}
				this._MappingInitialized = true;
			}
			this.Update();
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(true);
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0001E68B File Offset: 0x0001C88B
		private void OnCompactUserMappingCompleted(bool save)
		{
			if (save && this.CompactDisplayEditMapping)
			{
				this.OnSaveCommand(this.SelectedMapping);
			}
			this.CompactDisplayEditMapping = false;
			this.Update();
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x0001E6B1 File Offset: 0x0001C8B1
		private void Update()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (this.container.Resolve(Array.Empty<ResolverOverride>()).CompactUI)
				{
					this.eventAggregator.GetEvent<Events.CompactUserMappingComplete>().Subscribe(new Action<bool>(this.OnCompactUserMappingCompleted), ThreadOption.UIThread);
				}
				this._IsUserElevated = base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin;
				if (this.migrationDefinition.DirtyCustomizationItems.HasFlag(CustomizationAffects.Users))
				{
					base.pcmoverEngine.RetrieveUsers();
					this.migrationDefinition.DirtyCustomizationItems &= ~CustomizationAffects.Users;
				}
				UserMappings users = base.pcmoverEngine.Users;
				this.UnusedUsersOnNew = ((users != null) ? users.UnusedOnNew : null);
				this.Mappings = new ObservableCollection<UserMap>();
				this.migrationDefinition.IsRedirectionSaved = true;
				this.migrationDefinition.IsUserMappingSaved = true;
				this.IsFilesBased = (this.migrationDefinition.MigrationType == TransferMethodType.File && base.pcmoverEngine.ThisMachineIsOld);
				if (this.CurrentUser == null)
				{
					IEnumerable<UserMapping> mappings = base.pcmoverEngine.Users.Mappings;
					UserDetail currentUser;
					if (mappings == null)
					{
						currentUser = null;
					}
					else
					{
						UserMapping userMapping = mappings.FirstOrDefault((UserMapping x) => x.New != null && x.New.IsCurrentUser);
						currentUser = ((userMapping != null) ? userMapping.New : null);
					}
					this.CurrentUser = currentUser;
					if (this.CurrentUser == null)
					{
						IEnumerable<UserDetail> unusedOnNew = base.pcmoverEngine.Users.UnusedOnNew;
						UserDetail currentUser2;
						if (unusedOnNew == null)
						{
							currentUser2 = null;
						}
						else
						{
							currentUser2 = unusedOnNew.FirstOrDefault((UserDetail x) => x.IsCurrentUser);
						}
						this.CurrentUser = currentUser2;
					}
				}
				if (this.ExistingUsersOnNew == null)
				{
					this.ExistingUsersOnNew = new ExistingUsers();
					foreach (UserDetail item in base.pcmoverEngine.Users.UnusedOnNew)
					{
						this.ExistingUsersOnNew.Users.Add(item);
					}
					foreach (UserMapping userMapping2 in base.pcmoverEngine.Users.Mappings)
					{
						if (!userMapping2.Create && userMapping2.New != null && !this.UnusedUsersOnNew.Contains(userMapping2.New))
						{
							this.ExistingUsersOnNew.Users.Add(userMapping2.New);
						}
					}
				}
				using (IEnumerator<UserMapping> enumerator2 = base.pcmoverEngine.Users.Mappings.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						UserMapping engineMap = enumerator2.Current;
						if (base.pcmoverEngine.OtherMachine == null || base.pcmoverEngine.OtherMachine.IsEngineRunningAsAdmin || engineMap.Old.IsCurrentUser)
						{
							UserMap uiMap = new UserMap(engineMap.Old, this._IsUserElevated);
							if (engineMap.AvailableProfiles != null)
							{
								uiMap.AvailableProfiles = engineMap.AvailableProfiles.ToList<string>();
							}
							else
							{
								uiMap.AvailableProfiles = new List<string>();
							}
							uiMap.MapiProfileMappings = new List<MapiProfileMapping>();
							if (engineMap.MapiProfileMappings != null)
							{
								foreach (MapiProfileMapping mapiProfileMapping in engineMap.MapiProfileMappings)
								{
									uiMap.MapiProfileMappings.Add(new MapiProfileMapping
									{
										OldProfile = (mapiProfileMapping.OldProfile ?? string.Empty),
										NewProfile = (mapiProfileMapping.NewProfile ?? string.Empty),
										Transfer = !string.IsNullOrEmpty(mapiProfileMapping.NewProfile)
									});
								}
							}
							if (engineMap.New != null)
							{
								uiMap.Selected = true;
								uiMap.New = new UserDetail
								{
									AccountName = engineMap.New.AccountName,
									FriendlyName = engineMap.New.FriendlyName,
									FullName = engineMap.New.FullName,
									UserType = engineMap.New.UserType,
									IsCurrentUser = engineMap.New.IsCurrentUser
								};
							}
							uiMap.IsNewUserOptionAvailable = base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin;
							uiMap.IsCreateOptionAvailable = (this.ExistingUsersOnNew.Users.Count((UserDetail x) => ((x != null) ? x.AccountName : null) == uiMap.Old.AccountName) == 0 && base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin);
							if (uiMap.IsCreateOptionAvailable && engineMap.Old.FriendlyName.Contains("\\") && base.pcmoverEngine.Users.Settings.RequireJoinedDomain)
							{
								if (string.IsNullOrWhiteSpace(base.pcmoverEngine.ThisMachine.JoinedDomain))
								{
									uiMap.IsCreateOptionAvailable = false;
								}
								else
								{
									uiMap.IsCreateOptionAvailable = engineMap.Old.FriendlyName.StartsWith(base.pcmoverEngine.ThisMachine.JoinedDomain);
								}
							}
							uiMap.IsCurrentToCurrentOptionAvailable = (this.CurrentUser != null);
							uiMap.IsMapToExistingOptionAvailable = base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin;
							if (engineMap.Create)
							{
								if (engineMap.Old.AccountName == engineMap.New.AccountName)
								{
									uiMap.Create = true;
								}
								else
								{
									uiMap.NewUser = true;
									uiMap.NewAccountName = engineMap.New.AccountName;
								}
							}
							else if (engineMap.New == null || string.IsNullOrWhiteSpace(engineMap.New.AccountName))
							{
								uiMap.DontMigrate = true;
								uiMap.Selected = false;
							}
							else
							{
								string accountName = engineMap.New.AccountName;
								UserDetail currentUser3 = this.CurrentUser;
								if (accountName == ((currentUser3 != null) ? currentUser3.AccountName : null))
								{
									uiMap.Current = true;
								}
								else if (this.ExistingUsersOnNew.Users.Count((UserDetail x) => x.AccountName == engineMap.New.AccountName) > 0)
								{
									uiMap.Existing = true;
									this.ExistingUsersOnNew.SelectedUser = engineMap.New;
								}
								else
								{
									LlTraceSource ts = base.pcmoverEngine.Ts;
									string str = "Error setting user mapping options - User ";
									UserDetail @new = engineMap.New;
									ts.TraceError(str + ((@new != null) ? @new.AccountName : null) + " does not exist.");
								}
							}
							uiMap.ShowCreateLabel = engineMap.Create;
							this.Mappings.Add(uiMap);
						}
					}
				}
				base.RaisePropertyChanged("Mappings");
			}, "Update");
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0001E6D0 File Offset: 0x0001C8D0
		private bool ValidateMapping(UserDetail OldAccount, string RequestedNewAccountName)
		{
			int num = this.Mappings.Count(delegate(UserMap x)
			{
				string a2;
				if (x == null)
				{
					a2 = null;
				}
				else
				{
					UserDetail @new = x.New;
					if (@new == null)
					{
						a2 = null;
					}
					else
					{
						string friendlyName3 = @new.FriendlyName;
						a2 = ((friendlyName3 != null) ? friendlyName3.ToLower() : null);
					}
				}
				string requestedNewAccountName = RequestedNewAccountName;
				return a2 == ((requestedNewAccountName != null) ? requestedNewAccountName.ToLower() : null);
			});
			if (num <= 0)
			{
				return true;
			}
			if (num > 1)
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, string.Concat(new string[]
				{
					Resources.SU_Error1,
					" ",
					RequestedNewAccountName,
					" ",
					Resources.SU_Error2
				}), Resources.SU_ErrorCaption, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				return false;
			}
			UserMap userMap = this.Mappings.FirstOrDefault(delegate(UserMap x)
			{
				string a2;
				if (x == null)
				{
					a2 = null;
				}
				else
				{
					UserDetail @new = x.New;
					if (@new == null)
					{
						a2 = null;
					}
					else
					{
						string friendlyName3 = @new.FriendlyName;
						a2 = ((friendlyName3 != null) ? friendlyName3.ToLower() : null);
					}
				}
				string requestedNewAccountName = RequestedNewAccountName;
				return a2 == ((requestedNewAccountName != null) ? requestedNewAccountName.ToLower() : null);
			});
			string a;
			if (userMap == null)
			{
				a = null;
			}
			else
			{
				UserDetail old = userMap.Old;
				if (old == null)
				{
					a = null;
				}
				else
				{
					string friendlyName = old.FriendlyName;
					a = ((friendlyName != null) ? friendlyName.ToLower() : null);
				}
			}
			string b;
			if (OldAccount == null)
			{
				b = null;
			}
			else
			{
				string friendlyName2 = OldAccount.FriendlyName;
				b = ((friendlyName2 != null) ? friendlyName2.ToLower() : null);
			}
			if (a != b)
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, string.Concat(new string[]
				{
					Resources.SU_Error1,
					" ",
					RequestedNewAccountName,
					" ",
					Resources.SU_Error2
				}), Resources.SU_ErrorCaption, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				return false;
			}
			return true;
		}

		// Token: 0x040003B3 RID: 947
		private readonly IRegionManager regionManager;

		// Token: 0x040003B4 RID: 948
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040003B5 RID: 949
		private bool _IsUserElevated;

		// Token: 0x040003B6 RID: 950
		private bool _MappingInitialized;

		// Token: 0x040003B7 RID: 951
		private Dictionary<string, UserType> AccountTypes;

		// Token: 0x040003B8 RID: 952
		private DefaultPolicy policy;

		// Token: 0x040003B9 RID: 953
		private bool _IsReadOnly;

		// Token: 0x040003BA RID: 954
		private bool _IsFilesBased;

		// Token: 0x040003BB RID: 955
		private ObservableCollection<UserMap> _Mappings;

		// Token: 0x040003BC RID: 956
		private IEnumerable<UserDetail> _UnusedUsersOnNew;

		// Token: 0x040003BD RID: 957
		private ExistingUsers _ExistingUsersOnNew;

		// Token: 0x040003BE RID: 958
		private UserDetail _CurrentUser;

		// Token: 0x040003BF RID: 959
		private string _DomainMessage;

		// Token: 0x040003C0 RID: 960
		private bool _CompactDisplayEditMapping;

		// Token: 0x040003C1 RID: 961
		private UserMap _SelectedMapping;

		// Token: 0x040003C2 RID: 962
		private bool _ProfilesExist;

		// Token: 0x040003C3 RID: 963
		private string _CurrentLoggedInUser;

		// Token: 0x040003C4 RID: 964
		private string _CreateAUser;

		// Token: 0x040003C5 RID: 965
		private string _MapAUser;

		// Token: 0x040003C6 RID: 966
		private string _DontTransferUser;
	}
}
