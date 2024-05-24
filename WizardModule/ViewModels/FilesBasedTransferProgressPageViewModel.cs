using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;
using WizardModule.Views.Popups;

namespace WizardModule.ViewModels
{
	// Token: 0x02000086 RID: 134
	public class FilesBasedTransferProgressPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060008D3 RID: 2259 RVA: 0x00014B50 File Offset: 0x00012D50
		public FilesBasedTransferProgressPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.policy = policy;
			this._ts = ts;
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnSave = new DelegateCommand(new Action(this.OnSaveCommand), new Func<bool>(this.CanOnSaveCommand));
			this.OnFinish = new DelegateCommand(new Action(this.OnFinishCommand), new Func<bool>(this.CanOnFinishCommand));
			this.OnExit = new DelegateCommand(new Action(this.OnExitCommand), new Func<bool>(this.CanOnExitCommand));
			this.OnCloseCustomize = new DelegateCommand(new Action(this.OnCloseCustomizeCommand), new Func<bool>(this.CanOnCloseCustomizeCommand));
			this.OnViewDetails = new DelegateCommand(new Action(this.OnViewDetailsCommand), new Func<bool>(this.CanOnViewDetailsCommand));
			this.OnSavePassword = new DelegateCommand<object>(new Action<object>(this.OnSavePasswordCommand), new Func<object, bool>(this.CanOnSavePasswordCommand));
			this.OnSaveVanPassword = new DelegateCommand<object>(new Action<object>(this.OnSaveVanPasswordCommand), new Func<object, bool>(this.CanOnSaveVanPasswordCommand));
			this.OnCancelVanPassword = new DelegateCommand(new Action(this.OnCancelVanPasswordCommand), new Func<bool>(this.CanOnCancelVanPasswordCommand));
			this.OnStop = new DelegateCommand(new Action(this.OnStopCommand), new Func<bool>(this.CanOnStopCommand));
			this.OnShowAlertsPopup = new DelegateCommand(new Action(this.OnShowAlertsPopupCommand), new Func<bool>(this.CanOnShowAlertsPopupCommand));
			this.ShowEstimateTime = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowEstimatedTime);
			this.TimeRemainingTimer.Interval = new TimeSpan(0, 0, 1);
			this.TimeRemainingTimer.Tick += this.TimeRemainingTimer_Tick;
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x00014D5F File Offset: 0x00012F5F
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x00014D67 File Offset: 0x00012F67
		public bool IsOld
		{
			get
			{
				return this._IsOld;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsOld, value, "IsOld");
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x00014D7C File Offset: 0x00012F7C
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x00014D84 File Offset: 0x00012F84
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

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x00014D99 File Offset: 0x00012F99
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x00014DA1 File Offset: 0x00012FA1
		public bool IsSaving
		{
			get
			{
				return this._IsSaving;
			}
			set
			{
				if (value)
				{
					this.IsSaveReady = false;
				}
				this.SetProperty<bool>(ref this._IsSaving, value, "IsSaving");
				this.OnSave.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x00014DCB File Offset: 0x00012FCB
		// (set) Token: 0x060008DB RID: 2267 RVA: 0x00014DD4 File Offset: 0x00012FD4
		public string TransferFile
		{
			get
			{
				return this._TransferFile;
			}
			set
			{
				this.SetProperty<string>(ref this._TransferFile, value, "TransferFile");
				if (!string.IsNullOrWhiteSpace(this._TransferFile))
				{
					try
					{
						this.TransferFolder = Path.GetDirectoryName(this.TransferFile);
						if (Path.IsPathRooted(this.TransferFolder))
						{
							this.TransferFolder = Path.GetFullPath(this.TransferFolder);
						}
						else
						{
							this.TransferFolder = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), this.TransferFolder);
						}
						this.TransferFilePath = this.TransferFolder + "\\" + Path.GetFileName(this.TransferFile);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x00014E90 File Offset: 0x00013090
		// (set) Token: 0x060008DD RID: 2269 RVA: 0x00014E98 File Offset: 0x00013098
		public string TransferFolder
		{
			get
			{
				return this._TransferFolder;
			}
			set
			{
				this.SetProperty<string>(ref this._TransferFolder, value, "TransferFolder");
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x00014EAD File Offset: 0x000130AD
		// (set) Token: 0x060008DF RID: 2271 RVA: 0x00014EB5 File Offset: 0x000130B5
		public string TransferFilePath
		{
			get
			{
				return this._TransferFilePath;
			}
			set
			{
				this.SetProperty<string>(ref this._TransferFilePath, value, "TransferFilePath");
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x00014ECA File Offset: 0x000130CA
		// (set) Token: 0x060008E1 RID: 2273 RVA: 0x00014ED2 File Offset: 0x000130D2
		public bool IsFinishedPopupOpen
		{
			get
			{
				return this._IsFinishedPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsFinishedPopupOpen, value, "IsFinishedPopupOpen");
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x00014EE7 File Offset: 0x000130E7
		// (set) Token: 0x060008E3 RID: 2275 RVA: 0x00014EEF File Offset: 0x000130EF
		public bool IsSaveComplete
		{
			get
			{
				return this._IsSaveComplete;
			}
			set
			{
				if (value)
				{
					this.IsSaving = false;
				}
				this.SetProperty<bool>(ref this._IsSaveComplete, value, "IsSaveComplete");
				this.OnFinish.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x00014F19 File Offset: 0x00013119
		// (set) Token: 0x060008E5 RID: 2277 RVA: 0x00014F21 File Offset: 0x00013121
		public bool IsCustomizePopupOpen
		{
			get
			{
				return this._IsCustomizePopupOpen;
			}
			set
			{
				if (!value)
				{
					this.policy.WriteProfile();
					Action callbackHandler = this._callbackHandler;
					if (callbackHandler != null)
					{
						callbackHandler();
					}
				}
				this.SetProperty<bool>(ref this._IsCustomizePopupOpen, value, "IsCustomizePopupOpen");
				this.OnStop.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00014F60 File Offset: 0x00013160
		// (set) Token: 0x060008E7 RID: 2279 RVA: 0x00014F68 File Offset: 0x00013168
		public bool IsAnalyzing
		{
			get
			{
				return this._IsAnalyzing;
			}
			set
			{
				if (value)
				{
					this.IsSaveReady = false;
				}
				this.SetProperty<bool>(ref this._IsAnalyzing, value, "IsAnalyzing");
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00014F87 File Offset: 0x00013187
		// (set) Token: 0x060008E9 RID: 2281 RVA: 0x00014F8F File Offset: 0x0001318F
		public double PercentDone
		{
			get
			{
				return this._PercentDone;
			}
			set
			{
				this.SetProperty<double>(ref this._PercentDone, value, "PercentDone");
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x060008EA RID: 2282 RVA: 0x00014FA4 File Offset: 0x000131A4
		// (set) Token: 0x060008EB RID: 2283 RVA: 0x00014FAC File Offset: 0x000131AC
		public bool IsSaveReady
		{
			get
			{
				return this._IsSaveReady;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsSaveReady, value, "IsSaveReady");
				this.OnSave.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x00014FCC File Offset: 0x000131CC
		// (set) Token: 0x060008ED RID: 2285 RVA: 0x00014FD4 File Offset: 0x000131D4
		public string VanSize
		{
			get
			{
				return this._VanSize;
			}
			set
			{
				this.SetProperty<string>(ref this._VanSize, value, "VanSize");
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x00014FE9 File Offset: 0x000131E9
		// (set) Token: 0x060008EF RID: 2287 RVA: 0x00014FF1 File Offset: 0x000131F1
		public string CurrentCategory
		{
			get
			{
				return this._CurrentCategory;
			}
			set
			{
				this.SetProperty<string>(ref this._CurrentCategory, value, "CurrentCategory");
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00015006 File Offset: 0x00013206
		// (set) Token: 0x060008F1 RID: 2289 RVA: 0x0001500E File Offset: 0x0001320E
		public string CurrentItem
		{
			get
			{
				return this._CurrentItem;
			}
			set
			{
				this.SetProperty<string>(ref this._CurrentItem, value, "CurrentItem");
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00015023 File Offset: 0x00013223
		// (set) Token: 0x060008F3 RID: 2291 RVA: 0x0001502B File Offset: 0x0001322B
		public int ItemsRemaining
		{
			get
			{
				return this._ItemsRemaining;
			}
			set
			{
				this.SetProperty<int>(ref this._ItemsRemaining, value, "ItemsRemaining");
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00015040 File Offset: 0x00013240
		// (set) Token: 0x060008F5 RID: 2293 RVA: 0x00015048 File Offset: 0x00013248
		public int TotalItems
		{
			get
			{
				return this._TotalItems;
			}
			set
			{
				this.SetProperty<int>(ref this._TotalItems, value, "TotalItems");
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x0001505D File Offset: 0x0001325D
		// (set) Token: 0x060008F7 RID: 2295 RVA: 0x00015065 File Offset: 0x00013265
		public string TimeRemaining
		{
			get
			{
				return this._TimeRemaining;
			}
			private set
			{
				this.SetProperty<string>(ref this._TimeRemaining, value, "TimeRemaining");
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x0001507A File Offset: 0x0001327A
		// (set) Token: 0x060008F9 RID: 2297 RVA: 0x00015082 File Offset: 0x00013282
		public bool IsPasswordMismatch
		{
			get
			{
				return this._IsPasswordMismatch;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsPasswordMismatch, value, "IsPasswordMismatch");
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x00015097 File Offset: 0x00013297
		// (set) Token: 0x060008FB RID: 2299 RVA: 0x0001509F File Offset: 0x0001329F
		public bool IsPasswordPopupOpen
		{
			get
			{
				return this._IsPasswordPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsPasswordPopupOpen, value, "IsPasswordPopupOpen");
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x000150B4 File Offset: 0x000132B4
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x000150BC File Offset: 0x000132BC
		public bool IsVanPasswordPopupOpen
		{
			get
			{
				return this._IsVanPasswordPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVanPasswordPopupOpen, value, "IsVanPasswordPopupOpen");
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x000150D1 File Offset: 0x000132D1
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x000150D9 File Offset: 0x000132D9
		public string MissingPasswordAccount
		{
			get
			{
				return this._MissingPasswordAccount;
			}
			set
			{
				this.SetProperty<string>(ref this._MissingPasswordAccount, value, "MissingPasswordAccount");
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x000150EE File Offset: 0x000132EE
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x000150F6 File Offset: 0x000132F6
		public bool IsStopEnabled
		{
			get
			{
				return this._IsStopEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsStopEnabled, value, "IsStopEnabled");
				this.OnStop.RaiseCanExecuteChanged();
				this.OnBack.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00015121 File Offset: 0x00013321
		// (set) Token: 0x06000903 RID: 2307 RVA: 0x00015129 File Offset: 0x00013329
		public string TimeRemainingString
		{
			get
			{
				return this._TimeRemainingString;
			}
			set
			{
				this.SetProperty<string>(ref this._TimeRemainingString, value, "TimeRemainingString");
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0001513E File Offset: 0x0001333E
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x00015146 File Offset: 0x00013346
		public bool IsVanPasswordIncorrect
		{
			get
			{
				return this._IsVanPasswordIncorrect;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVanPasswordIncorrect, value, "IsVanPasswordIncorrect");
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0001515B File Offset: 0x0001335B
		public bool IsAlertEnabled
		{
			get
			{
				IPCmoverEngine pcmoverEngine = base.pcmoverEngine;
				return ((pcmoverEngine != null) ? pcmoverEngine.InteractiveDoneAlert : null) != null;
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x00015172 File Offset: 0x00013372
		// (set) Token: 0x06000908 RID: 2312 RVA: 0x0001517A File Offset: 0x0001337A
		public bool IsCloudBased
		{
			get
			{
				return this._IsCloudBased;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCloudBased, value, "IsCloudBased");
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x0001518F File Offset: 0x0001338F
		// (set) Token: 0x0600090A RID: 2314 RVA: 0x00015197 File Offset: 0x00013397
		public string FinishedSavingText
		{
			get
			{
				return this._FinishedSavingText;
			}
			set
			{
				this.SetProperty<string>(ref this._FinishedSavingText, value, "FinishedSavingText");
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x000151AC File Offset: 0x000133AC
		// (set) Token: 0x0600090C RID: 2316 RVA: 0x000151B4 File Offset: 0x000133B4
		public bool ShowEstimateTime
		{
			get
			{
				return this._ShowEstimateTime;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowEstimateTime, value, "ShowEstimateTime");
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x000151C9 File Offset: 0x000133C9
		// (set) Token: 0x0600090E RID: 2318 RVA: 0x000151D1 File Offset: 0x000133D1
		public bool ShowViewDetails
		{
			get
			{
				return this._ShowViewDetails;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowViewDetails, value, "ShowViewDetails");
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x000151E6 File Offset: 0x000133E6
		// (set) Token: 0x06000910 RID: 2320 RVA: 0x000151EE File Offset: 0x000133EE
		public DelegateCommand OnSave { get; private set; }

		// Token: 0x06000911 RID: 2321 RVA: 0x000151F7 File Offset: 0x000133F7
		private bool CanOnSaveCommand()
		{
			return this.IsSaveReady && !this._IsSaving && !this._IsSaveComplete;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00015214 File Offset: 0x00013414
		private void OnSaveCommand()
		{
			if (!this.IsSaving)
			{
				this.IsSaving = true;
				this.Progress = 0.0;
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this._ts.TraceInformation("Calling StartSaveMovingVan");
					base.pcmoverEngine.StartSaveMovingVan(this.TransferFile, null, null, null);
					this.IsStopEnabled = false;
				}, "OnSaveCommand");
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x00015251 File Offset: 0x00013451
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x00015259 File Offset: 0x00013459
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000915 RID: 2325 RVA: 0x00015262 File Offset: 0x00013462
		private bool CanOnBackCommand()
		{
			return this.IsStopEnabled;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0001526C File Offset: 0x0001346C
		private void OnBackCommand()
		{
			FilesBasedTransferProgressPageViewModel.<OnBackCommand>d__145 <OnBackCommand>d__;
			<OnBackCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnBackCommand>d__.<>4__this = this;
			<OnBackCommand>d__.<>1__state = -1;
			<OnBackCommand>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnBackCommand>d__145>(ref <OnBackCommand>d__);
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x000152A3 File Offset: 0x000134A3
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x000152AB File Offset: 0x000134AB
		public DelegateCommand OnFinish { get; private set; }

		// Token: 0x06000919 RID: 2329 RVA: 0x00014EE7 File Offset: 0x000130E7
		private bool CanOnFinishCommand()
		{
			return this._IsSaveComplete;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x000152B4 File Offset: 0x000134B4
		private void OnFinishCommand()
		{
			this.IsFinishedPopupOpen = !this.IsFinishedPopupOpen;
			this.eventAggregator.GetEvent<Events.TransferStateChanged>().Publish(Events.TransferStateEnum.CompleteSuccess);
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x000152D6 File Offset: 0x000134D6
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x000152DE File Offset: 0x000134DE
		public DelegateCommand OnExit { get; private set; }

		// Token: 0x0600091D RID: 2333 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnExitCommand()
		{
			return true;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000152E7 File Offset: 0x000134E7
		private void OnExitCommand()
		{
			this.eventAggregator.GetEvent<Events.CloseConfirmationRequiredChanged>().Publish(false);
			this.eventAggregator.GetEvent<Events.ProcessShutdownRequest>().Publish(new Events.ShutdownEventArgs(Events.TransferStateEnum.CompleteSuccess));
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00015310 File Offset: 0x00013510
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x00015318 File Offset: 0x00013518
		public DelegateCommand OnCloseCustomize { get; private set; }

		// Token: 0x06000921 RID: 2337 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCustomizeCommand()
		{
			return true;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00015324 File Offset: 0x00013524
		private void OnCloseCustomizeCommand()
		{
			FilesBasedTransferProgressPageViewModel.<OnCloseCustomizeCommand>d__163 <OnCloseCustomizeCommand>d__;
			<OnCloseCustomizeCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCloseCustomizeCommand>d__.<>4__this = this;
			<OnCloseCustomizeCommand>d__.<>1__state = -1;
			<OnCloseCustomizeCommand>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnCloseCustomizeCommand>d__163>(ref <OnCloseCustomizeCommand>d__);
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0001535B File Offset: 0x0001355B
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x00015363 File Offset: 0x00013563
		public DelegateCommand OnViewDetails { get; private set; }

		// Token: 0x06000925 RID: 2341 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnViewDetailsCommand()
		{
			return true;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0001536C File Offset: 0x0001356C
		private void OnViewDetailsCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FilesBasedSummaryPage", UriKind.Relative));
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x00015389 File Offset: 0x00013589
		// (set) Token: 0x06000928 RID: 2344 RVA: 0x00015391 File Offset: 0x00013591
		public DelegateCommand<object> OnSavePassword { get; private set; }

		// Token: 0x06000929 RID: 2345 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSavePasswordCommand(object parameter)
		{
			return true;
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0001539C File Offset: 0x0001359C
		private void OnSavePasswordCommand(object parameter)
		{
			FilesBasedTransferProgressPageViewModel.<OnSavePasswordCommand>d__175 <OnSavePasswordCommand>d__;
			<OnSavePasswordCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSavePasswordCommand>d__.<>4__this = this;
			<OnSavePasswordCommand>d__.parameter = parameter;
			<OnSavePasswordCommand>d__.<>1__state = -1;
			<OnSavePasswordCommand>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnSavePasswordCommand>d__175>(ref <OnSavePasswordCommand>d__);
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x000153DB File Offset: 0x000135DB
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x000153E3 File Offset: 0x000135E3
		public DelegateCommand<object> OnSaveVanPassword { get; private set; }

		// Token: 0x0600092D RID: 2349 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSaveVanPasswordCommand(object pwBox)
		{
			return true;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000153EC File Offset: 0x000135EC
		private void OnSaveVanPasswordCommand(object pwBox)
		{
			PasswordBox passwordBox = pwBox as PasswordBox;
			if (!string.IsNullOrEmpty(passwordBox.Password))
			{
				this._VanPasswordEventArgs.Password = passwordBox.Password;
				this._VanPasswordEventArgs.Canceled = false;
				this.IsVanPasswordPopupOpen = false;
				passwordBox.Clear();
				Action resumeAction = this._VanPasswordEventArgs.ResumeAction;
				if (resumeAction == null)
				{
					return;
				}
				resumeAction();
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0001544C File Offset: 0x0001364C
		// (set) Token: 0x06000930 RID: 2352 RVA: 0x00015454 File Offset: 0x00013654
		public DelegateCommand OnCancelVanPassword { get; private set; }

		// Token: 0x06000931 RID: 2353 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelVanPasswordCommand()
		{
			return true;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001545D File Offset: 0x0001365D
		private void OnCancelVanPasswordCommand()
		{
			this._VanPasswordEventArgs.Password = string.Empty;
			this._VanPasswordEventArgs.Canceled = true;
			this.IsVanPasswordPopupOpen = false;
			Action resumeAction = this._VanPasswordEventArgs.ResumeAction;
			if (resumeAction == null)
			{
				return;
			}
			resumeAction();
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x00015497 File Offset: 0x00013697
		// (set) Token: 0x06000934 RID: 2356 RVA: 0x0001549F File Offset: 0x0001369F
		public DelegateCommand OnStop { get; private set; }

		// Token: 0x06000935 RID: 2357 RVA: 0x000154A8 File Offset: 0x000136A8
		private bool CanOnStopCommand()
		{
			return this.IsStopEnabled && !this.IsCustomizePopupOpen;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x000154C0 File Offset: 0x000136C0
		private void OnStopCommand()
		{
			FilesBasedTransferProgressPageViewModel.<OnStopCommand>d__193 <OnStopCommand>d__;
			<OnStopCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnStopCommand>d__.<>4__this = this;
			<OnStopCommand>d__.<>1__state = -1;
			<OnStopCommand>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnStopCommand>d__193>(ref <OnStopCommand>d__);
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x000154F7 File Offset: 0x000136F7
		// (set) Token: 0x06000938 RID: 2360 RVA: 0x000154FF File Offset: 0x000136FF
		public DelegateCommand OnShowAlertsPopup { get; private set; }

		// Token: 0x06000939 RID: 2361 RVA: 0x00015508 File Offset: 0x00013708
		private bool CanOnShowAlertsPopupCommand()
		{
			return this.IsAlertEnabled;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001345E File Offset: 0x0001165E
		private void OnShowAlertsPopupCommand()
		{
			this.eventAggregator.GetEvent<PopupEvents.ShowPopup>().Publish(new PopupEvents.ResolveInfo(typeof(InteractiveAlert), null));
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00015510 File Offset: 0x00013710
		private void OnAnalysisProgressChanged(ProgressInfo progressInfo)
		{
			if (progressInfo.Percentage == 0)
			{
				this.PercentDone += 1.0;
			}
			this.PercentDone = Math.Max(this.PercentDone, (double)progressInfo.Percentage);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00015548 File Offset: 0x00013748
		private void OnAnalysisComplete(TaskStats stats)
		{
			if (stats != null && !this.migrationDefinition.IsResuming)
			{
				if (!string.IsNullOrEmpty(this.TransferFile) && !this.TransferFile.StartsWith("\\\\") && !this.IsCloudBased)
				{
					string targetDrive = Directory.GetDirectoryRoot(this.TransferFile);
					ulong freeSpace = 0UL;
					bool checkDriveSpace = false;
					try
					{
						if (base.pcmoverEngine.IsRemoteUI)
						{
							Func<DriveSpaceData, bool> <>9__1;
							base.pcmoverEngine.CatchCommEx(delegate
							{
								IEnumerable<DriveSpaceData> thisMachineDriveSpace = this.pcmoverEngine.ThisMachineDriveSpace;
								Func<DriveSpaceData, bool> predicate;
								if ((predicate = <>9__1) == null)
								{
									predicate = (<>9__1 = ((DriveSpaceData x) => x.Drive.ToUpper() == targetDrive.ToUpper()));
								}
								DriveSpaceData driveSpaceData = thisMachineDriveSpace.FirstOrDefault(predicate);
								if (driveSpaceData != null)
								{
									freeSpace = driveSpaceData.FreeBytes;
									checkDriveSpace = true;
								}
							}, "OnAnalysisComplete");
						}
						else
						{
							DriveInfo driveInfo = new DriveInfo(targetDrive);
							if (driveInfo != null)
							{
								freeSpace = (ulong)driveInfo.TotalFreeSpace;
								checkDriveSpace = true;
							}
						}
					}
					catch (Exception ex)
					{
						this._ts.TraceException(ex, "OnAnalysisComplete");
						checkDriveSpace = false;
					}
					if (checkDriveSpace && freeSpace < stats.Disk.TotalSize)
					{
						if (base.pcmoverEngine.IsScript)
						{
							string message = string.Format(WizardModule.Properties.Resources.FBTPP_DiskSpaceWarningScript, targetDrive.Substring(0, targetDrive.Length - 1), Tools.GetDisplaySize(stats.Disk.TotalSize));
							WPFMessageBox.ShowDialogAsyncNoSuppress(this.container, this.eventAggregator, message, WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.Hand, MessageBoxResult.None).ConfigureAwait(false);
							this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FilesBasedTransferPage", UriKind.Relative));
							return;
						}
						string message2 = string.Format(WizardModule.Properties.Resources.FBTPP_DiskSpaceWarning, targetDrive.Substring(0, targetDrive.Length - 1), Tools.GetDisplaySize(stats.Disk.TotalSize), WizardModule.Properties.Resources.FBTPP_Customize);
						WPFMessageBox.ShowDialogAsyncNoSuppress(this.container, this.eventAggregator, message2, WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.Hand, MessageBoxResult.None).ConfigureAwait(false);
						this.navigationContext.NavigationService.Journal.GoBack();
						return;
					}
				}
				this.VanSize = Tools.GetDisplaySize(stats.Disk.TotalSize);
				this.migrationDefinition.EstimatedTransferTime = new TimeSpan(0, 0, (int)stats.Disk.TotalSize / 100000000);
			}
			this.IsAnalyzing = false;
			this.IsSaveReady = true;
			IWizardParameters wizardParameters = this.container.Resolve(Array.Empty<ResolverOverride>());
			if ((!this.policy.filesBasedTransferProgressPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy || !string.IsNullOrWhiteSpace(wizardParameters.VanFile)) && this.CanOnSaveCommand())
			{
				this.OnSaveCommand();
			}
			if (this.migrationDefinition.IsResuming && this.migrationDefinition.ServiceData.Step == PcmoverTransferState.TransferStep.Transferring)
			{
				this.OnSaveCommand();
				this._ts.TraceInformation("Saving Transfer file still in progress. Turning off IsResuming.");
				base.pcmoverEngine.IsResuming = false;
			}
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00015834 File Offset: 0x00013A34
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			FilesBasedTransferProgressPageViewModel.<OnActivityInfo>d__202 <OnActivityInfo>d__;
			<OnActivityInfo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnActivityInfo>d__.<>4__this = this;
			<OnActivityInfo>d__.activityInfo = activityInfo;
			<OnActivityInfo>d__.<>1__state = -1;
			<OnActivityInfo>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnActivityInfo>d__202>(ref <OnActivityInfo>d__);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00015874 File Offset: 0x00013A74
		private void OnProgressChanged(TransferProgressInfo progress)
		{
			if (this.migrationDefinition.MigrationType != TransferMethodType.File)
			{
				return;
			}
			if (!this.IsOld)
			{
				this.Progress = Tools.GetTotalUnloadProgress(this.Progress, progress);
				UiCallbackCode uiCallbackCode = progress.ProgressInfo.ActionCode;
				if (uiCallbackCode != UiCallbackCode.Empty)
				{
					if (uiCallbackCode == UiCallbackCode.Custom)
					{
						this.CurrentCategory = progress.ProgressInfo.Action;
					}
					else
					{
						this.CurrentCategory = Tools.TranslateUICallback(progress.ProgressInfo.ActionCode, progress.ProgressInfo.Action);
					}
				}
				uiCallbackCode = progress.ProgressInfo.ItemCode;
				if (uiCallbackCode != UiCallbackCode.Empty)
				{
					if (uiCallbackCode == UiCallbackCode.Custom)
					{
						this.CurrentItem = progress.ProgressInfo.Item;
					}
					else
					{
						this.CurrentItem = Tools.TranslateUICallback(progress.ProgressInfo.ItemCode, progress.ProgressInfo.Item);
					}
				}
				this.ItemsRemaining = progress.ItemsRemaining;
				this.TotalItems = progress.TotalItems;
				this._CalculatedSecondsRemaining = Tools.GetTimeRemaining(this.Progress, progress, this.migrationDefinition);
				this.UpdateTimeRemaining();
				this.migrationDefinition.TotalElapsedTransferTime = progress.ElapsedTime;
				return;
			}
			if (progress != null)
			{
				ProgressInfo progressInfo = progress.ProgressInfo;
				if (((progressInfo != null) ? progressInfo.Action : null) != null)
				{
					if (progress.ProgressInfo.Action.Contains(": Disk"))
					{
						this.Progress = Math.Max((double)Convert.ToInt16(progress.Progress * 0.75), this.Progress);
						return;
					}
					if (progress.ProgressInfo.Action.Contains(": Registry"))
					{
						this.Progress = Math.Max((double)(75 + Convert.ToInt16(progress.Progress * 0.2)), this.Progress);
						return;
					}
					this.Progress = Math.Max((double)(95 + Convert.ToInt16(progress.Progress * 0.05)), this.Progress);
				}
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00015A4C File Offset: 0x00013C4C
		private void OnTransferComplete(TransferCompleteInfo info)
		{
			FilesBasedTransferProgressPageViewModel.<OnTransferComplete>d__204 <OnTransferComplete>d__;
			<OnTransferComplete>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnTransferComplete>d__.<>4__this = this;
			<OnTransferComplete>d__.info = info;
			<OnTransferComplete>d__.<>1__state = -1;
			<OnTransferComplete>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnTransferComplete>d__204>(ref <OnTransferComplete>d__);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00015A8C File Offset: 0x00013C8C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.filesBasedTransferProgressPagePolicy.IsPageDisplayed)
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.FileTransferProgress);
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Subscribe(new Action<TransferProgressInfo>(this.OnProgressChanged), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.TransferComplete>().Subscribe(new Action<TransferCompleteInfo>(this.OnTransferComplete), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.ConfirmUserMatches>().Subscribe(new Action<Action>(this.OnConfirmUserMatches), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.DisplayDriveMap>().Subscribe(new Action<Action>(this.OnDisplayDriveMap), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.DisplayAppSelection>().Subscribe(new Action<Action>(this.OnDisplayAppSelection), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.AssignMissingPassword>().Subscribe(new Action<Events.MissingPasswordEventArgs>(this.OnAssignMissingPassword), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.AnalysisProgressChanged>().Subscribe(new Action<ProgressInfo>(this.OnAnalysisProgressChanged), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Subscribe(new Action<TaskStats>(this.OnAnalysisComplete), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.PromptForVanPassword>().Subscribe(new Action<Events.PasswordEventArgs>(this.OnPromptForVanPassword), ThreadOption.UIThread);
			this.TimeRemainingString = WizardModule.Properties.Resources.TEPP_TimeRemaining;
			this.IsCloudBased = (this.policy.enginePolicy.Connection.File.Settings.CloudBased != "Local");
			this._callbackHandler = null;
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_FilesBasedTransferPage);
			this.ShowViewDetails = !base.pcmoverEngine.IsScript;
			if (this.migrationDefinition.IsResuming)
			{
				if (this.migrationDefinition.ServiceData.Step == PcmoverTransferState.TransferStep.Customizing)
				{
					this.migrationDefinition.IsResuming = false;
				}
			}
			else if (!this._TransferInProgress)
			{
				this.Progress = 0.0;
				this.PercentDone = 0.0;
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.SetControllerProperty(ControllerProperties.CustomizationScreen, CustomizationScreen.StartTransfer.ToString());
				}, "OnNavigatedTo");
			}
			this.TimeRemainingTimer.Start();
			if (this.migrationDefinition.FilesBasedParameters != null)
			{
				this.TransferFile = this.migrationDefinition.FilesBasedParameters.TransferFile;
				this.IsOld = this.migrationDefinition.FilesBasedParameters.IsOld;
				this.IsStopEnabled = true;
				base.pcmoverEngine.CatchCommEx(delegate
				{
					if (this.IsOld)
					{
						if (this.migrationDefinition.FilesBasedParameters.BuildChangelistsRequired)
						{
							base.pcmoverEngine.StartBuildChangeLists();
							this.IsAnalyzing = true;
							this.IsSaving = false;
							this.IsSaveComplete = false;
							this.migrationDefinition.FilesBasedParameters.BuildChangelistsRequired = false;
							return;
						}
					}
					else
					{
						this.eventAggregator.GetEvent<EngineEvents.AuthorizationError>().Subscribe(new Action<Events.AuthorizationErrorEventArgs>(this.OnAuthorizationErrorAsync), ThreadOption.UIThread);
						if (!this._TransferInProgress)
						{
							base.pcmoverEngine.StartTransferMovingVan(this._TransferFile);
							this._TransferInProgress = true;
							base.pcmoverEngine.IsResuming = false;
						}
					}
				}, "OnNavigatedTo");
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00015D4C File Offset: 0x00013F4C
		private void OnPromptForVanPassword(Events.PasswordEventArgs obj)
		{
			this._PasswordPromptCounter++;
			this._VanPasswordEventArgs = obj;
			if (this._PasswordPromptCounter > 10)
			{
				this.OnCancelVanPasswordCommand();
				return;
			}
			if (this._PasswordPromptCounter > 1)
			{
				this.IsVanPasswordIncorrect = true;
			}
			this.IsVanPasswordPopupOpen = true;
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00015D8C File Offset: 0x00013F8C
		private void OnAuthorizationErrorAsync(Events.AuthorizationErrorEventArgs args)
		{
			FilesBasedTransferProgressPageViewModel.<OnAuthorizationErrorAsync>d__207 <OnAuthorizationErrorAsync>d__;
			<OnAuthorizationErrorAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAuthorizationErrorAsync>d__.<>4__this = this;
			<OnAuthorizationErrorAsync>d__.args = args;
			<OnAuthorizationErrorAsync>d__.<>1__state = -1;
			<OnAuthorizationErrorAsync>d__.<>t__builder.Start<FilesBasedTransferProgressPageViewModel.<OnAuthorizationErrorAsync>d__207>(ref <OnAuthorizationErrorAsync>d__);
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00015DCB File Offset: 0x00013FCB
		private void OnAssignMissingPassword(Events.MissingPasswordEventArgs obj)
		{
			this._ts.TraceInformation("Password required.  Prompting user...");
			this._callbackHandler = obj.ResumeAction;
			this.MissingPasswordAccount = obj.User.AccountName;
			this.IsPasswordMismatch = false;
			this.IsPasswordPopupOpen = true;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00015E08 File Offset: 0x00014008
		private void OnDisplayDriveMap(Action c)
		{
			if (this.policy.filesBasedTransferProgressPagePolicy.SuppressUnloadDialogs)
			{
				if (c != null)
				{
					c();
				}
				return;
			}
			this._callbackHandler = c;
			this.regionManager.RequestNavigate(RegionNames.FilesBasedCustomizationRegion, new Uri("SectionAdvanced", UriKind.Relative));
			this.migrationDefinition.IsUserMappingSaved = true;
			this.IsCustomizePopupOpen = true;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00015E68 File Offset: 0x00014068
		private void OnConfirmUserMatches(Action c)
		{
			if (this.policy.filesBasedTransferProgressPagePolicy.SuppressUnloadDialogs || !base.pcmoverEngine.Users.Mappings.Any<UserMapping>())
			{
				if (c != null)
				{
					c();
				}
				return;
			}
			this._callbackHandler = c;
			this.regionManager.RequestNavigate(RegionNames.FilesBasedCustomizationRegion, new Uri("SectionUsers", UriKind.Relative));
			this.migrationDefinition.IsUserMappingSaved = true;
			this.IsCustomizePopupOpen = true;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00015EE0 File Offset: 0x000140E0
		private void OnDisplayAppSelection(Action c)
		{
			if (this.policy.filesBasedTransferProgressPagePolicy.SuppressApplicationUnloadDialog)
			{
				if (c != null)
				{
					c();
				}
				return;
			}
			this._callbackHandler = c;
			this.regionManager.RequestNavigate(RegionNames.FilesBasedCustomizationRegion, new Uri("SectionApplications", UriKind.Relative));
			this.migrationDefinition.IsUserMappingSaved = true;
			this.IsCustomizePopupOpen = true;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00015F40 File Offset: 0x00014140
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
			this.eventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Unsubscribe(new Action<TransferProgressInfo>(this.OnProgressChanged));
			this.eventAggregator.GetEvent<EngineEvents.TransferComplete>().Unsubscribe(new Action<TransferCompleteInfo>(this.OnTransferComplete));
			this.eventAggregator.GetEvent<EngineEvents.ConfirmUserMatches>().Unsubscribe(new Action<Action>(this.OnConfirmUserMatches));
			this.eventAggregator.GetEvent<EngineEvents.DisplayDriveMap>().Unsubscribe(new Action<Action>(this.OnDisplayDriveMap));
			this.eventAggregator.GetEvent<EngineEvents.AssignMissingPassword>().Unsubscribe(new Action<Events.MissingPasswordEventArgs>(this.OnAssignMissingPassword));
			this.eventAggregator.GetEvent<EngineEvents.AnalysisProgressChanged>().Unsubscribe(new Action<ProgressInfo>(this.OnAnalysisProgressChanged));
			this.eventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Unsubscribe(new Action<TaskStats>(this.OnAnalysisComplete));
			this.eventAggregator.GetEvent<EngineEvents.AuthorizationError>().Unsubscribe(new Action<Events.AuthorizationErrorEventArgs>(this.OnAuthorizationErrorAsync));
			this.eventAggregator.GetEvent<EngineEvents.PromptForVanPassword>().Unsubscribe(new Action<Events.PasswordEventArgs>(this.OnPromptForVanPassword));
			this.TimeRemainingTimer.Stop();
			this.policy.WriteProfile();
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0001607B File Offset: 0x0001427B
		private void TimeRemainingTimer_Tick(object sender, EventArgs e)
		{
			this.UpdateTimeRemaining();
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00016084 File Offset: 0x00014284
		private void UpdateTimeRemaining()
		{
			if (this.Progress <= 3.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strCalculating;
				return;
			}
			if (this.Progress >= 98.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strTimeRemainingAlmostFinished;
				this.TimeRemainingString = string.Empty;
				return;
			}
			if (this.Progress > 50.0 && this._DisplayedSecondsRemaining < 121.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strTimeRemainingAlmostFinished;
				this.TimeRemainingString = string.Empty;
				return;
			}
			TimeSpan timeSpan = DateTime.Now - this._TimeRemainingChanged;
			if (Math.Abs(this._CalculatedSecondsRemaining - this._DisplayedSecondsRemaining) > 150.0)
			{
				this._DisplayedSecondsRemaining = this._CalculatedSecondsRemaining;
				this._TimeRemainingChanged = DateTime.Now;
			}
			else if (this._DisplayedSecondsRemaining > 10.0 && timeSpan.TotalMilliseconds > 1000.0)
			{
				this._DisplayedSecondsRemaining -= 1.0;
				this._TimeRemainingChanged = DateTime.Now;
			}
			else if (timeSpan.TotalMilliseconds > 4000.0)
			{
				if (this._DisplayedSecondsRemaining > 1.0)
				{
					this._DisplayedSecondsRemaining -= 1.0;
					this._TimeRemainingChanged = DateTime.Now;
				}
				else
				{
					this._DisplayedSecondsRemaining += 29.0;
					this._TimeRemainingChanged = DateTime.Now;
				}
			}
			this.TimeRemaining = new TimeSpan(0, 0, (int)this._DisplayedSecondsRemaining).ToString("hh\\:mm\\:ss");
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00016228 File Offset: 0x00014428
		public ulong GetSize(string size)
		{
			ulong num = 0UL;
			try
			{
				if (!string.IsNullOrWhiteSpace(size))
				{
					string text = size.Substring(size.Length - 1);
					if (char.IsLetter(char.Parse(text)))
					{
						num = Convert.ToUInt64(size.Substring(0, size.Length - 1));
						string a = text.ToUpper();
						if (!(a == "K"))
						{
							if (!(a == "M"))
							{
								if (!(a == "G"))
								{
									if (a == "T")
									{
										num *= (ulong)Math.Pow(1024.0, 4.0);
									}
								}
								else
								{
									num *= (ulong)Math.Pow(1024.0, 3.0);
								}
							}
							else
							{
								num *= (ulong)Math.Pow(1024.0, 2.0);
							}
						}
						else
						{
							num *= 1024UL;
						}
					}
					else
					{
						num = Convert.ToUInt64(size);
					}
				}
			}
			catch
			{
				this._ts.TraceInformation("Error parsing span size ({0})", new object[]
				{
					size
				});
			}
			return num;
		}

		// Token: 0x04000287 RID: 647
		private readonly IRegionManager regionManager;

		// Token: 0x04000288 RID: 648
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000289 RID: 649
		private NavigationContext navigationContext;

		// Token: 0x0400028A RID: 650
		private Action _callbackHandler;

		// Token: 0x0400028B RID: 651
		private Action<bool> _activationCallbackHandler;

		// Token: 0x0400028C RID: 652
		private Events.PasswordEventArgs _VanPasswordEventArgs;

		// Token: 0x0400028D RID: 653
		private double _DisplayedSecondsRemaining;

		// Token: 0x0400028E RID: 654
		private double _CalculatedSecondsRemaining;

		// Token: 0x0400028F RID: 655
		private DateTime _TimeRemainingChanged = DateTime.Now;

		// Token: 0x04000290 RID: 656
		private readonly DispatcherTimer TimeRemainingTimer = new DispatcherTimer();

		// Token: 0x04000291 RID: 657
		private bool _TransferInProgress;

		// Token: 0x04000292 RID: 658
		private DefaultPolicy policy;

		// Token: 0x04000293 RID: 659
		private LlTraceSource _ts;

		// Token: 0x04000294 RID: 660
		private int _PasswordPromptCounter;

		// Token: 0x04000295 RID: 661
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000296 RID: 662
		private bool _IsOld;

		// Token: 0x04000297 RID: 663
		private double _Progress;

		// Token: 0x04000298 RID: 664
		private bool _IsSaving;

		// Token: 0x04000299 RID: 665
		private string _TransferFile;

		// Token: 0x0400029A RID: 666
		private string _TransferFolder;

		// Token: 0x0400029B RID: 667
		private string _TransferFilePath;

		// Token: 0x0400029C RID: 668
		private bool _IsFinishedPopupOpen;

		// Token: 0x0400029D RID: 669
		private bool _IsSaveComplete;

		// Token: 0x0400029E RID: 670
		private bool _IsCustomizePopupOpen;

		// Token: 0x0400029F RID: 671
		private bool _IsAnalyzing;

		// Token: 0x040002A0 RID: 672
		private double _PercentDone;

		// Token: 0x040002A1 RID: 673
		private bool _IsSaveReady;

		// Token: 0x040002A2 RID: 674
		private string _VanSize;

		// Token: 0x040002A3 RID: 675
		private string _CurrentCategory;

		// Token: 0x040002A4 RID: 676
		private string _CurrentItem;

		// Token: 0x040002A5 RID: 677
		private int _ItemsRemaining;

		// Token: 0x040002A6 RID: 678
		private int _TotalItems;

		// Token: 0x040002A7 RID: 679
		private string _TimeRemaining;

		// Token: 0x040002A8 RID: 680
		private bool _IsPasswordMismatch;

		// Token: 0x040002A9 RID: 681
		private bool _IsPasswordPopupOpen;

		// Token: 0x040002AA RID: 682
		private bool _IsVanPasswordPopupOpen;

		// Token: 0x040002AB RID: 683
		private string _MissingPasswordAccount;

		// Token: 0x040002AC RID: 684
		private bool _IsStopEnabled;

		// Token: 0x040002AD RID: 685
		private string _TimeRemainingString;

		// Token: 0x040002AE RID: 686
		private bool _IsVanPasswordIncorrect;

		// Token: 0x040002AF RID: 687
		private bool _IsCloudBased;

		// Token: 0x040002B0 RID: 688
		private string _FinishedSavingText;

		// Token: 0x040002B1 RID: 689
		private bool _ShowEstimateTime;

		// Token: 0x040002B2 RID: 690
		private bool _ShowViewDetails;
	}
}
