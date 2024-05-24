using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
	// Token: 0x0200008F RID: 143
	public class SectionApplicationsViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000B53 RID: 2899 RVA: 0x0001C198 File Offset: 0x0001A398
		public SectionApplicationsViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this.OnSelected = new DelegateCommand<ApplicationInfo>(new Action<ApplicationInfo>(this.OnAppSelectedCommand), new Func<ApplicationInfo, bool>(this.CanOnAppSelectedCommand));
			this.ViewUserMismatchInfo = new DelegateCommand<string>(new Action<string>(this.OnViewUserMismatchInfo), new Func<string, bool>(this.CanOnViewUserMismatchInfo));
			this.RestoreDefault = new DelegateCommand<string>(new Action<string>(this.OnRestoreDefault), new Func<string, bool>(this.CanOnRestoreDefault));
			this.DeselectAll = new DelegateCommand<string>(new Action<string>(this.OnDeselectAll), new Func<string, bool>(this.CanOnDeselectAll));
			this.SelectAll = new DelegateCommand<string>(new Action<string>(this.OnSelectAll), new Func<string, bool>(this.CanOnSelectAll));
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x0001C275 File Offset: 0x0001A475
		// (set) Token: 0x06000B55 RID: 2901 RVA: 0x0001C27D File Offset: 0x0001A47D
		public bool IsReadOnly { get; set; }

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x0001C286 File Offset: 0x0001A486
		// (set) Token: 0x06000B57 RID: 2903 RVA: 0x0001C28E File Offset: 0x0001A48E
		public ObservableCollection<ApplicationInfo> GreenApps
		{
			get
			{
				return this._GreenApps;
			}
			set
			{
				this.SetProperty<ObservableCollection<ApplicationInfo>>(ref this._GreenApps, value, "GreenApps");
			}
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x0001C2A3 File Offset: 0x0001A4A3
		// (set) Token: 0x06000B59 RID: 2905 RVA: 0x0001C2AB File Offset: 0x0001A4AB
		public ObservableCollection<ApplicationInfo> YellowApps
		{
			get
			{
				return this._YellowApps;
			}
			set
			{
				this.SetProperty<ObservableCollection<ApplicationInfo>>(ref this._YellowApps, value, "YellowApps");
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x0001C2C0 File Offset: 0x0001A4C0
		// (set) Token: 0x06000B5B RID: 2907 RVA: 0x0001C2C8 File Offset: 0x0001A4C8
		public ObservableCollection<ApplicationInfo> RedApps
		{
			get
			{
				return this._RedApps;
			}
			set
			{
				this.SetProperty<ObservableCollection<ApplicationInfo>>(ref this._RedApps, value, "RedApps");
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0001C2DD File Offset: 0x0001A4DD
		// (set) Token: 0x06000B5D RID: 2909 RVA: 0x0001C2E5 File Offset: 0x0001A4E5
		public bool ShowMatchingApplications
		{
			get
			{
				return this._ShowMatchingApplications;
			}
			set
			{
				if (this._ShowMatchingApplications != value)
				{
					this.SetProperty<bool>(ref this._ShowMatchingApplications, value, "ShowMatchingApplications");
					this.RefreshAppList(AppColor.Green);
					this.RefreshAppList(AppColor.Yellow);
					this.RefreshAppList(AppColor.Red);
				}
			}
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0001C318 File Offset: 0x0001A518
		// (set) Token: 0x06000B5F RID: 2911 RVA: 0x0001C320 File Offset: 0x0001A520
		public bool ShowUndisplayedApplications
		{
			get
			{
				return this._ShowUndisplayedApplications;
			}
			set
			{
				if (this._ShowUndisplayedApplications != value)
				{
					this.SetProperty<bool>(ref this._ShowUndisplayedApplications, value, "ShowUndisplayedApplications");
					this.RefreshAppList(AppColor.Green);
					this.RefreshAppList(AppColor.Yellow);
					this.RefreshAppList(AppColor.Red);
				}
			}
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0001C353 File Offset: 0x0001A553
		// (set) Token: 0x06000B61 RID: 2913 RVA: 0x0001C35B File Offset: 0x0001A55B
		public int GreenSelected
		{
			get
			{
				return this._GreenSelected;
			}
			set
			{
				this.SetProperty<int>(ref this._GreenSelected, value, "GreenSelected");
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0001C370 File Offset: 0x0001A570
		// (set) Token: 0x06000B63 RID: 2915 RVA: 0x0001C378 File Offset: 0x0001A578
		public int YellowSelected
		{
			get
			{
				return this._YellowSelected;
			}
			set
			{
				this.SetProperty<int>(ref this._YellowSelected, value, "YellowSelected");
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0001C38D File Offset: 0x0001A58D
		// (set) Token: 0x06000B65 RID: 2917 RVA: 0x0001C395 File Offset: 0x0001A595
		public int RedSelected
		{
			get
			{
				return this._RedSelected;
			}
			set
			{
				this.SetProperty<int>(ref this._RedSelected, value, "RedSelected");
			}
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x0001C3AA File Offset: 0x0001A5AA
		// (set) Token: 0x06000B67 RID: 2919 RVA: 0x0001C3B2 File Offset: 0x0001A5B2
		public bool UserMismatchDetected
		{
			get
			{
				return this._UserMismatchDetected;
			}
			set
			{
				this.SetProperty<bool>(ref this._UserMismatchDetected, value, "UserMismatchDetected");
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0001C3C7 File Offset: 0x0001A5C7
		// (set) Token: 0x06000B69 RID: 2921 RVA: 0x0001C3CF File Offset: 0x0001A5CF
		public DelegateCommand<ApplicationInfo> OnSelected { get; private set; }

		// Token: 0x06000B6A RID: 2922 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnAppSelectedCommand(ApplicationInfo arg)
		{
			return true;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0001C3D8 File Offset: 0x0001A5D8
		private void OnAppSelectedCommand(ApplicationInfo app)
		{
			if (this.IsReadOnly || !app.Data.IsModifiable)
			{
				return;
			}
			if (app != null)
			{
				app.Selected = !app.Selected;
				CustomizationData cData = null;
				if (!base.pcmoverEngine.CatchCommEx(delegate
				{
					cData = this.pcmoverEngine.ChangeApplicationSelection(app);
				}, "OnAppSelectedCommand"))
				{
					return;
				}
				if (cData.Result != CustomizationResult.Success)
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, cData.Message, Resources.strError + " " + cData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					app.Selected = !app.Selected;
				}
				else if (!string.IsNullOrEmpty(cData.Message))
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, cData.Message, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				}
				this.migrationDefinition.DirtyCustomizationItems |= cData.Affects;
				if (this.policy.enginePolicy.AppSel == null)
				{
					this.policy.enginePolicy.AppSel = new EnginePolicy.ApplicationsPolicy();
				}
				if (this.policy.enginePolicy.AppSel.Applications == null)
				{
					this.policy.enginePolicy.AppSel.Applications = new ObservableCollection<EnginePolicy.AppData>();
				}
				EnginePolicy.AppData appData = this.policy.enginePolicy.AppSel.Applications.FirstOrDefault((EnginePolicy.AppData x) => x.Id == app.AppId);
				if (appData == null)
				{
					this.policy.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
					{
						Id = app.AppId,
						Name = app.AppName,
						Migrate = app.Selected,
						Modify = true
					});
				}
				else
				{
					appData.Migrate = app.Selected;
				}
				this.RefreshSelectedCount(app.Color);
			}
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0001C66C File Offset: 0x0001A86C
		public DelegateCommand<string> ViewUserMismatchInfo { get; }

		// Token: 0x06000B6D RID: 2925 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnViewUserMismatchInfo(string url)
		{
			return true;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0001C674 File Offset: 0x0001A874
		private void OnViewUserMismatchInfo(string url)
		{
			try
			{
				Process.Start(new ProcessStartInfo(url));
			}
			catch
			{
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0001C6A4 File Offset: 0x0001A8A4
		// (set) Token: 0x06000B70 RID: 2928 RVA: 0x0001C6AC File Offset: 0x0001A8AC
		public DelegateCommand<string> RestoreDefault { get; set; }

		// Token: 0x06000B71 RID: 2929 RVA: 0x0001C6B5 File Offset: 0x0001A8B5
		private bool CanOnRestoreDefault(string color)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		private void OnRestoreDefault(string color)
		{
			try
			{
				if (!(color == "Green"))
				{
					if (!(color == "Yellow"))
					{
						if (!(color == "Red"))
						{
							goto IL_F5;
						}
						goto IL_B4;
					}
				}
				else
				{
					using (IEnumerator<ApplicationInfo> enumerator = (from a in this.GreenApps
					where a.Selected != this.defaultSelection[a.AppId]
					select a).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ApplicationInfo app = enumerator.Current;
							this.OnAppSelectedCommand(app);
						}
						goto IL_F5;
					}
				}
				using (IEnumerator<ApplicationInfo> enumerator = (from a in this.YellowApps
				where a.Selected != this.defaultSelection[a.AppId]
				select a).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ApplicationInfo app2 = enumerator.Current;
						this.OnAppSelectedCommand(app2);
					}
					goto IL_F5;
				}
				IL_B4:
				foreach (ApplicationInfo app3 in from a in this.RedApps
				where a.Selected != this.defaultSelection[a.AppId]
				select a)
				{
					this.OnAppSelectedCommand(app3);
				}
				IL_F5:;
			}
			catch (Exception ex)
			{
				base.pcmoverEngine.Ts.TraceException(ex, "OnRestoreDefault");
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x0001C814 File Offset: 0x0001AA14
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x0001C81C File Offset: 0x0001AA1C
		public DelegateCommand<string> DeselectAll { get; private set; }

		// Token: 0x06000B75 RID: 2933 RVA: 0x0001C6B5 File Offset: 0x0001A8B5
		private bool CanOnDeselectAll(string color)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x0001C828 File Offset: 0x0001AA28
		private void OnDeselectAll(string color)
		{
			try
			{
				if (!(color == "Green"))
				{
					if (!(color == "Yellow"))
					{
						if (!(color == "Red"))
						{
							goto IL_12E;
						}
						goto IL_DA;
					}
				}
				else
				{
					using (IEnumerator<ApplicationInfo> enumerator = (from x in this.GreenApps
					where x.Selected && x.Data.IsModifiable
					select x).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ApplicationInfo app = enumerator.Current;
							this.OnAppSelectedCommand(app);
						}
						goto IL_12E;
					}
				}
				using (IEnumerator<ApplicationInfo> enumerator = (from x in this.YellowApps
				where x.Selected && x.Data.IsModifiable
				select x).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ApplicationInfo app2 = enumerator.Current;
						this.OnAppSelectedCommand(app2);
					}
					goto IL_12E;
				}
				IL_DA:
				foreach (ApplicationInfo app3 in from x in this.RedApps
				where x.Selected && x.Data.IsModifiable
				select x)
				{
					this.OnAppSelectedCommand(app3);
				}
				IL_12E:;
			}
			catch (Exception ex)
			{
				base.pcmoverEngine.Ts.TraceException(ex, "OnDeselectAll");
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
		// (set) Token: 0x06000B78 RID: 2936 RVA: 0x0001C9EC File Offset: 0x0001ABEC
		public DelegateCommand<string> SelectAll { get; private set; }

		// Token: 0x06000B79 RID: 2937 RVA: 0x0001C6B5 File Offset: 0x0001A8B5
		private bool CanOnSelectAll(string color)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x0001C9F8 File Offset: 0x0001ABF8
		private void OnSelectAll(string color)
		{
			try
			{
				if (!(color == "Green"))
				{
					if (!(color == "Yellow"))
					{
						if (!(color == "Red"))
						{
							goto IL_12E;
						}
						goto IL_DA;
					}
				}
				else
				{
					using (IEnumerator<ApplicationInfo> enumerator = (from x in this.GreenApps
					where !x.Selected && x.Data.IsModifiable
					select x).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ApplicationInfo app = enumerator.Current;
							this.OnAppSelectedCommand(app);
						}
						goto IL_12E;
					}
				}
				using (IEnumerator<ApplicationInfo> enumerator = (from x in this.YellowApps
				where !x.Selected && x.Data.IsModifiable
				select x).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ApplicationInfo app2 = enumerator.Current;
						this.OnAppSelectedCommand(app2);
					}
					goto IL_12E;
				}
				IL_DA:
				foreach (ApplicationInfo app3 in from x in this.RedApps
				where !x.Selected && x.Data.IsModifiable
				select x)
				{
					this.OnAppSelectedCommand(app3);
				}
				IL_12E:;
			}
			catch (Exception ex)
			{
				base.pcmoverEngine.Ts.TraceException(ex, "OnSelectAll");
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0001CBB4 File Offset: 0x0001ADB4
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.SecApplications);
			this.IsReadOnly = (navigationContext.NavigationService.Region.Name == RegionNames.TransferCompleteDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.SummaryDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.FilesBasedSummaryDetailButtons);
			this.Update();
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(true);
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0001CC4C File Offset: 0x0001AE4C
		private void Update()
		{
			SectionApplicationsViewModel.<Update>d__76 <Update>d__;
			<Update>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<SectionApplicationsViewModel.<Update>d__76>(ref <Update>d__);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0001CC84 File Offset: 0x0001AE84
		private void RefreshAppList(AppColor color)
		{
			SectionApplicationsViewModel.<>c__DisplayClass77_0 CS$<>8__locals1 = new SectionApplicationsViewModel.<>c__DisplayClass77_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.color = color;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				MachineData otherMachine = CS$<>8__locals1.<>4__this.pcmoverEngine.OtherMachine;
				ObservableCollection<ApplicationInfo> observableCollection;
				if (otherMachine != null && !otherMachine.IsEngineRunningAsAdmin)
				{
					MachineData thisMachine = CS$<>8__locals1.<>4__this.pcmoverEngine.ThisMachine;
					if (thisMachine != null && !thisMachine.IsEngineRunningAsAdmin)
					{
						SectionApplicationsViewModel.<>c__DisplayClass77_1 CS$<>8__locals2 = new SectionApplicationsViewModel.<>c__DisplayClass77_1();
						CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
						CS$<>8__locals2.userOnOld = string.Empty;
						try
						{
							SectionApplicationsViewModel.<>c__DisplayClass77_1 CS$<>8__locals3 = CS$<>8__locals2;
							UserMappings users = CS$<>8__locals1.<>4__this.pcmoverEngine.Users;
							string userOnOld;
							if (users == null)
							{
								userOnOld = null;
							}
							else
							{
								IEnumerable<UserMapping> mappings = users.Mappings;
								if (mappings == null)
								{
									userOnOld = null;
								}
								else
								{
									userOnOld = mappings.FirstOrDefault((UserMapping x) => x.Old.IsCurrentUser).Old.AccountName;
								}
							}
							CS$<>8__locals3.userOnOld = userOnOld;
						}
						catch
						{
						}
						if (CS$<>8__locals1.<>4__this.ShowMatchingApplications && CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
						{
							observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
							where x.Color == CS$<>8__locals2.CS$<>8__locals1.color && x.Data.User == CS$<>8__locals2.userOnOld
							select x into a
							orderby a.Data.IsMatching
							orderby !a.Data.IsDisplayable
							select a);
							goto IL_7EA;
						}
						if (CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
						{
							observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
							where x.Color == CS$<>8__locals2.CS$<>8__locals1.color && !x.Data.IsMatching && x.Data.User == CS$<>8__locals2.userOnOld
							select x into a
							orderby !a.Data.IsDisplayable
							select a);
							goto IL_7EA;
						}
						if (CS$<>8__locals1.<>4__this.ShowMatchingApplications)
						{
							observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
							where x.Color == CS$<>8__locals2.CS$<>8__locals1.color && x.Data.IsDisplayable && x.Data.User == CS$<>8__locals2.userOnOld
							select x into a
							orderby a.Data.IsMatching
							select a);
							goto IL_7EA;
						}
						observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
						where x.Color == CS$<>8__locals2.CS$<>8__locals1.color && x.Data.IsDisplayable && !x.Data.IsMatching && x.Data.User == CS$<>8__locals2.userOnOld
						select x);
						goto IL_7EA;
					}
				}
				MachineData otherMachine2 = CS$<>8__locals1.<>4__this.pcmoverEngine.OtherMachine;
				if (otherMachine2 != null && !otherMachine2.IsEngineRunningAsAdmin)
				{
					SectionApplicationsViewModel.<>c__DisplayClass77_2 CS$<>8__locals4 = new SectionApplicationsViewModel.<>c__DisplayClass77_2();
					CS$<>8__locals4.CS$<>8__locals2 = CS$<>8__locals1;
					CS$<>8__locals4.userOnOld = string.Empty;
					try
					{
						SectionApplicationsViewModel.<>c__DisplayClass77_2 CS$<>8__locals5 = CS$<>8__locals4;
						UserMappings users2 = CS$<>8__locals1.<>4__this.pcmoverEngine.Users;
						string userOnOld2;
						if (users2 == null)
						{
							userOnOld2 = null;
						}
						else
						{
							IEnumerable<UserMapping> mappings2 = users2.Mappings;
							if (mappings2 == null)
							{
								userOnOld2 = null;
							}
							else
							{
								userOnOld2 = mappings2.FirstOrDefault((UserMapping x) => x.Old.IsCurrentUser).Old.AccountName;
							}
						}
						CS$<>8__locals5.userOnOld = userOnOld2;
					}
					catch
					{
					}
					if (CS$<>8__locals1.<>4__this.ShowMatchingApplications && CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
					{
						observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
						where x.Color == CS$<>8__locals4.CS$<>8__locals2.color && x.Data.User == CS$<>8__locals4.userOnOld
						select x into a
						orderby a.Data.IsMatching
						orderby !a.Data.IsDisplayable
						select a);
					}
					else if (CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
					{
						observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
						where x.Color == CS$<>8__locals4.CS$<>8__locals2.color && !x.Data.IsMatching && (x.Data.User == CS$<>8__locals4.userOnOld || string.IsNullOrEmpty(x.Data.User))
						select x into a
						orderby !a.Data.IsDisplayable
						select a);
					}
					else if (CS$<>8__locals1.<>4__this.ShowMatchingApplications)
					{
						observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
						where x.Color == CS$<>8__locals4.CS$<>8__locals2.color && x.Data.IsDisplayable && (x.Data.User == CS$<>8__locals4.userOnOld || string.IsNullOrEmpty(x.Data.User))
						select x into a
						orderby a.Data.IsMatching
						select a);
					}
					else
					{
						observableCollection = new ObservableCollection<ApplicationInfo>(from x in CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList
						where x.Color == CS$<>8__locals4.CS$<>8__locals2.color && x.Data.IsDisplayable && !x.Data.IsMatching && (x.Data.User == CS$<>8__locals4.userOnOld || string.IsNullOrEmpty(x.Data.User))
						select x);
					}
				}
				else
				{
					MachineData thisMachine2 = CS$<>8__locals1.<>4__this.pcmoverEngine.ThisMachine;
					if (thisMachine2 != null && !thisMachine2.IsEngineRunningAsAdmin)
					{
						if (CS$<>8__locals1.<>4__this.ShowMatchingApplications && CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
						{
							IEnumerable<ApplicationInfo> applicationList = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
							Func<ApplicationInfo, bool> predicate;
							if ((predicate = CS$<>8__locals1.<>9__1) == null)
							{
								predicate = (CS$<>8__locals1.<>9__1 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && !string.IsNullOrEmpty(x.Data.User)));
							}
							observableCollection = new ObservableCollection<ApplicationInfo>(from a in applicationList.Where(predicate)
							orderby a.Data.IsMatching
							orderby !a.Data.IsDisplayable
							select a);
						}
						else if (CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
						{
							IEnumerable<ApplicationInfo> applicationList2 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
							Func<ApplicationInfo, bool> predicate2;
							if ((predicate2 = CS$<>8__locals1.<>9__4) == null)
							{
								predicate2 = (CS$<>8__locals1.<>9__4 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && !x.Data.IsMatching && !string.IsNullOrEmpty(x.Data.User)));
							}
							observableCollection = new ObservableCollection<ApplicationInfo>(from a in applicationList2.Where(predicate2)
							orderby !a.Data.IsDisplayable
							select a);
						}
						else if (CS$<>8__locals1.<>4__this.ShowMatchingApplications)
						{
							IEnumerable<ApplicationInfo> applicationList3 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
							Func<ApplicationInfo, bool> predicate3;
							if ((predicate3 = CS$<>8__locals1.<>9__6) == null)
							{
								predicate3 = (CS$<>8__locals1.<>9__6 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && x.Data.IsDisplayable && !string.IsNullOrEmpty(x.Data.User)));
							}
							observableCollection = new ObservableCollection<ApplicationInfo>(from a in applicationList3.Where(predicate3)
							orderby a.Data.IsMatching
							select a);
						}
						else
						{
							IEnumerable<ApplicationInfo> applicationList4 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
							Func<ApplicationInfo, bool> predicate4;
							if ((predicate4 = CS$<>8__locals1.<>9__8) == null)
							{
								predicate4 = (CS$<>8__locals1.<>9__8 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && x.Data.IsDisplayable && !x.Data.IsMatching && !string.IsNullOrEmpty(x.Data.User)));
							}
							observableCollection = new ObservableCollection<ApplicationInfo>(applicationList4.Where(predicate4));
						}
					}
					else if (CS$<>8__locals1.<>4__this.ShowMatchingApplications && CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
					{
						IEnumerable<ApplicationInfo> applicationList5 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
						Func<ApplicationInfo, bool> predicate5;
						if ((predicate5 = CS$<>8__locals1.<>9__9) == null)
						{
							predicate5 = (CS$<>8__locals1.<>9__9 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color));
						}
						observableCollection = new ObservableCollection<ApplicationInfo>(from a in applicationList5.Where(predicate5)
						orderby a.Data.IsMatching
						orderby !a.Data.IsDisplayable
						select a);
					}
					else if (CS$<>8__locals1.<>4__this.ShowUndisplayedApplications)
					{
						IEnumerable<ApplicationInfo> applicationList6 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
						Func<ApplicationInfo, bool> predicate6;
						if ((predicate6 = CS$<>8__locals1.<>9__12) == null)
						{
							predicate6 = (CS$<>8__locals1.<>9__12 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && !x.Data.IsMatching));
						}
						observableCollection = new ObservableCollection<ApplicationInfo>(from a in applicationList6.Where(predicate6)
						orderby !a.Data.IsDisplayable
						select a);
					}
					else if (CS$<>8__locals1.<>4__this.ShowMatchingApplications)
					{
						IEnumerable<ApplicationInfo> applicationList7 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
						Func<ApplicationInfo, bool> predicate7;
						if ((predicate7 = CS$<>8__locals1.<>9__14) == null)
						{
							predicate7 = (CS$<>8__locals1.<>9__14 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && x.Data.IsDisplayable));
						}
						observableCollection = new ObservableCollection<ApplicationInfo>(from a in applicationList7.Where(predicate7)
						orderby a.Data.IsMatching
						select a);
					}
					else
					{
						IEnumerable<ApplicationInfo> applicationList8 = CS$<>8__locals1.<>4__this.pcmoverEngine.ApplicationList;
						Func<ApplicationInfo, bool> predicate8;
						if ((predicate8 = CS$<>8__locals1.<>9__16) == null)
						{
							predicate8 = (CS$<>8__locals1.<>9__16 = ((ApplicationInfo x) => x.Color == CS$<>8__locals1.color && x.Data.IsDisplayable && !x.Data.IsMatching));
						}
						observableCollection = new ObservableCollection<ApplicationInfo>(applicationList8.Where(predicate8));
					}
				}
				IL_7EA:
				switch (CS$<>8__locals1.color)
				{
				case AppColor.Green:
					CS$<>8__locals1.<>4__this.GreenApps = observableCollection;
					break;
				case AppColor.Yellow:
					CS$<>8__locals1.<>4__this.YellowApps = observableCollection;
					break;
				case AppColor.Red:
					CS$<>8__locals1.<>4__this.RedApps = observableCollection;
					break;
				}
				CS$<>8__locals1.<>4__this.RefreshSelectedCount(CS$<>8__locals1.color);
			}, "RefreshAppList");
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0001CCC4 File Offset: 0x0001AEC4
		private void SetDefaultAppSelection()
		{
			if (this.defaultSelection == null)
			{
				this.defaultSelection = new Dictionary<string, bool>();
				foreach (ApplicationInfo applicationInfo in base.pcmoverEngine.ApplicationList)
				{
					if (!this.defaultSelection.ContainsKey(applicationInfo.AppId))
					{
						this.defaultSelection.Add(applicationInfo.AppId, applicationInfo.Selected);
					}
				}
			}
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0001CD4C File Offset: 0x0001AF4C
		private void RefreshSelectedCount(AppColor color)
		{
			switch (color)
			{
			case AppColor.Green:
				this.GreenSelected = this.GreenApps.Count((ApplicationInfo x) => x.Selected);
				return;
			case AppColor.Yellow:
				this.YellowSelected = this.YellowApps.Count((ApplicationInfo x) => x.Selected);
				return;
			case AppColor.Red:
				this.RedSelected = this.RedApps.Count((ApplicationInfo x) => x.Selected);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0001CDFE File Offset: 0x0001AFFE
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(false);
			this.policy.WriteProfile();
		}

		// Token: 0x04000390 RID: 912
		private readonly IRegionManager regionManager;

		// Token: 0x04000391 RID: 913
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000392 RID: 914
		private DefaultPolicy policy;

		// Token: 0x04000393 RID: 915
		private Dictionary<string, bool> defaultSelection;

		// Token: 0x04000394 RID: 916
		private NavigationContext navigationContext;

		// Token: 0x04000396 RID: 918
		private ObservableCollection<ApplicationInfo> _GreenApps;

		// Token: 0x04000397 RID: 919
		private ObservableCollection<ApplicationInfo> _YellowApps;

		// Token: 0x04000398 RID: 920
		private ObservableCollection<ApplicationInfo> _RedApps;

		// Token: 0x04000399 RID: 921
		private bool _ShowMatchingApplications;

		// Token: 0x0400039A RID: 922
		private bool _ShowUndisplayedApplications;

		// Token: 0x0400039B RID: 923
		private int _GreenSelected;

		// Token: 0x0400039C RID: 924
		private int _YellowSelected;

		// Token: 0x0400039D RID: 925
		private int _RedSelected;

		// Token: 0x0400039E RID: 926
		private bool _UserMismatchDetected;
	}
}
