using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading.Tasks;
using Laplink.Download.Contracts;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;
using Prism.Events;

namespace PCmover.Infrastructure
{
	// Token: 0x02000028 RID: 40
	public interface IPCmoverEngine
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060001DA RID: 474
		IEventAggregator EventAggregator { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060001DB RID: 475
		// (set) Token: 0x060001DC RID: 476
		LicenseInfo License { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060001DD RID: 477
		VersionInfo Version { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060001DE RID: 478
		// (set) Token: 0x060001DF RID: 479
		bool IsLive { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060001E0 RID: 480
		bool IsScript { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001E1 RID: 481
		bool IsRebooting { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001E2 RID: 482
		DateTime UndoTime { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001E3 RID: 483
		string WindowsOldFolder { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001E4 RID: 484
		MachineData ThisMachine { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001E5 RID: 485
		MachineData OtherMachine { get; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001E6 RID: 486
		IEnumerable<DriveSpaceData> ThisMachineDriveSpace { get; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001E7 RID: 487
		SecurityProductsData SecurityProducts { get; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001E8 RID: 488
		// (set) Token: 0x060001E9 RID: 489
		bool UseSSL { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001EA RID: 490
		// (set) Token: 0x060001EB RID: 491
		string CertificateName { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001EC RID: 492
		IEnumerable<NetworkInfo> NetworkInfos { get; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001ED RID: 493
		RebootPendingReasons RebootPending { get; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001EE RID: 494
		LlTraceSource Ts { get; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001EF RID: 495
		// (set) Token: 0x060001F0 RID: 496
		bool IsResuming { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001F1 RID: 497
		bool IsConnected { get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001F2 RID: 498
		// (set) Token: 0x060001F3 RID: 499
		string CloudToken { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001F4 RID: 500
		IEnumerable<CategoryDefinition> CloudCategories { get; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001F5 RID: 501
		// (set) Token: 0x060001F6 RID: 502
		TaskAlertData InteractiveDoneAlert { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001F7 RID: 503
		PolicyData Policy { get; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001F8 RID: 504
		// (set) Token: 0x060001F9 RID: 505
		bool ThisMachineIsOld { get; set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001FA RID: 506
		// (set) Token: 0x060001FB RID: 507
		AppInventoryAmount ThisMachineAppInventoryRequirement { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001FC RID: 508
		bool IsThisMachineAppInventoryComplete { get; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001FD RID: 509
		// (set) Token: 0x060001FE RID: 510
		bool GodMode { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060001FF RID: 511
		// (set) Token: 0x06000200 RID: 512
		ConnectableMachine TargetMachine { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000201 RID: 513
		// (set) Token: 0x06000202 RID: 514
		TransferProgressInfo TransferInfo { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000203 RID: 515
		TimeSpan TotalTransferTime { get; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000204 RID: 516
		// (set) Token: 0x06000205 RID: 517
		double TotalTransferSize { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000206 RID: 518
		// (set) Token: 0x06000207 RID: 519
		Settings Settings { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000208 RID: 520
		bool IsRemoteUI { get; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000209 RID: 521
		string DefaultCertificateName { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600020A RID: 522
		NetworkStatsData NetworkStats { get; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600020B RID: 523
		// (set) Token: 0x0600020C RID: 524
		bool AllowUndo { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600020D RID: 525
		CommunicationState ControlProxyState { get; }

		// Token: 0x0600020E RID: 526
		void SetControllerProperty(string property, string value);

		// Token: 0x0600020F RID: 527
		string GetControllerProperty(string property);

		// Token: 0x06000210 RID: 528
		void SetPublicProperty(string property, string value);

		// Token: 0x06000211 RID: 529
		string GetPublicProperty(string property);

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000212 RID: 530
		GroupInfo DocumentsGroup { get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000213 RID: 531
		GroupInfo PicturesGroup { get; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000214 RID: 532
		GroupInfo MusicGroup { get; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000215 RID: 533
		GroupInfo VideoGroup { get; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000216 RID: 534
		GroupInfo OtherGroup { get; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000217 RID: 535
		IEnumerable<ApplicationInfo> ApplicationList { get; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000218 RID: 536
		DriveData Drives { get; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000219 RID: 537
		MiscSettingsData MiscSettingsData { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600021A RID: 538
		// (set) Token: 0x0600021B RID: 539
		MigrationItemsOption MigrationItemsSelection { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600021C RID: 540
		MigrationItemsOption MigrationItems { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600021D RID: 541
		UserMappings Users { get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600021E RID: 542
		// (set) Token: 0x0600021F RID: 543
		List<FileFilter> FileFilters { get; set; }

		// Token: 0x06000220 RID: 544
		Task<bool> ConnectToPcmoverServiceAsync();

		// Token: 0x06000221 RID: 545
		Task ShutdownAndRestartPcmoverAsync();

		// Token: 0x06000222 RID: 546
		Task ShutdownPcmoverAppAsync(bool terminateService);

		// Token: 0x06000223 RID: 547
		void DisconnectFromPcmoverService();

		// Token: 0x06000224 RID: 548
		void SetProductCulture(string language, string country);

		// Token: 0x06000225 RID: 549
		Task<SerialNumberInfo> GetSerialNumberInfoAsync(string serialNumber);

		// Token: 0x06000226 RID: 550
		AuthorizationInfo TaskGetAuthorizationInfo();

		// Token: 0x06000227 RID: 551
		bool TaskPrepareAuthorization(LicenseInfo license);

		// Token: 0x06000228 RID: 552
		IEnumerable<ConnectableMachine> GetConnectableMachines();

		// Token: 0x06000229 RID: 553
		bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure);

		// Token: 0x0600022A RID: 554
		bool SetDirection(ConnectableMachine remoteMachine);

		// Token: 0x0600022B RID: 555
		void SetEngineLogData(EngineLogData data);

		// Token: 0x0600022C RID: 556
		EngineLogData GetEngineLogData();

		// Token: 0x0600022D RID: 557
		Task<bool> CleanupAsync(uint timeout = 9000U);

		// Token: 0x0600022E RID: 558
		IEnumerable<string> GetRedistributables();

		// Token: 0x0600022F RID: 559
		bool UploadApplicationReport();

		// Token: 0x06000230 RID: 560
		FinishTransferData PerformPostTransferActions(bool dlmgrReboot);

		// Token: 0x06000231 RID: 561
		bool Reboot(uint delay);

		// Token: 0x06000232 RID: 562
		bool ApplyDataUpdate();

		// Token: 0x06000233 RID: 563
		IEnumerable<DriveSpaceAndNeeded> DetermineInsufficientDiskSpace(IEnumerable<DriveSpaceRequired> requiredList);

		// Token: 0x06000234 RID: 564
		Task<FindResponse> FindServiceHostsAsync();

		// Token: 0x06000235 RID: 565
		FindResponse FindServiceHosts();

		// Token: 0x06000236 RID: 566
		IDownloadControl GetDownloadManager();

		// Token: 0x06000237 RID: 567
		bool SuspendSleep(bool suspend);

		// Token: 0x06000238 RID: 568
		bool SendAlerts(TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, TransferProcessResult status);

		// Token: 0x06000239 RID: 569
		bool MarkUserDeferredComplete(string userName, string userSid);

		// Token: 0x0600023A RID: 570
		bool SetAuthorizationData(AuthorizationRequestData authRequest);

		// Token: 0x0600023B RID: 571
		ActivityClient GetActivityClient(ActivityType type);

		// Token: 0x0600023C RID: 572
		ActivityClient GetActivityClient(int handle);

		// Token: 0x0600023D RID: 573
		Task StopActivityAsync(ActivityClient activityClient, bool waitUntilDone = true);

		// Token: 0x0600023E RID: 574
		Task StopActivityAsync(ActivityType type, bool waitUntilDone = true);

		// Token: 0x0600023F RID: 575
		Task<ActivityClient> StartFindComputerAsync();

		// Token: 0x06000240 RID: 576
		ActivityClient StartListenActivity(string discoveryId = null, string password = "");

		// Token: 0x06000241 RID: 577
		ActivityClient StartLoadMovingJournal(string fileName);

		// Token: 0x06000242 RID: 578
		ActivityClient StartReadSnapshot();

		// Token: 0x06000243 RID: 579
		ActivityClient StartReadSnapshot(ConnectableMachine targetMachine);

		// Token: 0x06000244 RID: 580
		Task StopReadSnapshotAsync(bool waitUntilDone = true);

		// Token: 0x06000245 RID: 581
		ActivityClient StartCreateImageMachine(ImageMapData imageMachineData);

		// Token: 0x06000246 RID: 582
		ActivityClient StartCreateWinUpgradeMachine(string windowsOld);

		// Token: 0x06000247 RID: 583
		ActivityClient StartBuildChangeLists();

		// Token: 0x06000248 RID: 584
		ActivityClient StartUndoActivity();

		// Token: 0x06000249 RID: 585
		ActivityClient StartCreateAnyMachine();

		// Token: 0x0600024A RID: 586
		ActivityClient StartSaveMovingVan(string fileName, ulong? spanSize, bool? canSpan, bool? notifySpan);

		// Token: 0x0600024B RID: 587
		bool AddSelf();

		// Token: 0x0600024C RID: 588
		ActivityClient StartTransfer();

		// Token: 0x0600024D RID: 589
		ActivityClient StartTransferMovingVan(string fileName);

		// Token: 0x0600024E RID: 590
		TransferSpeeds GetTransferSpeeds(ActivityClient transferClient);

		// Token: 0x0600024F RID: 591
		int CreateNetworkTransferMethod(string networkTarget);

		// Token: 0x06000250 RID: 592
		int CreateTransferMethod(TransferMethodType tm, string networkTarget);

		// Token: 0x06000251 RID: 593
		int CreateTransferMethod(TransferMethodType tm);

		// Token: 0x06000252 RID: 594
		TransferMethodData GetTransferMethodData(int transferMethodHandle);

		// Token: 0x06000253 RID: 595
		bool DeleteTransferMethod(int transferMethodHandle);

		// Token: 0x06000254 RID: 596
		bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info);

		// Token: 0x06000255 RID: 597
		SslInfo GetSslInfo();

		// Token: 0x06000256 RID: 598
		SslInfo GetLocalSslInfo();

		// Token: 0x06000257 RID: 599
		bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData);

		// Token: 0x06000258 RID: 600
		bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info);

		// Token: 0x06000259 RID: 601
		FileTransferMethodInfo GetFileTransferMethodInfo();

		// Token: 0x0600025A RID: 602
		ImageMapData GetImageTransferMethodInfo();

		// Token: 0x0600025B RID: 603
		bool RefreshNetworkAdapters();

		// Token: 0x0600025C RID: 604
		uint GetValidNetworkAdapterCount();

		// Token: 0x0600025D RID: 605
		TransferrableContainerData GetFolderData(string path, bool withinBranch, bool onlyRoot);

		// Token: 0x0600025E RID: 606
		CustomizationData ChangeDiskData(string path, string fileName, bool isFolder, bool? isFiltered, string target);

		// Token: 0x0600025F RID: 607
		bool RetrieveDiskData();

		// Token: 0x06000260 RID: 608
		CustomizationData ChangeMigrationItems(MigrationItemsOption migItems);

		// Token: 0x06000261 RID: 609
		void RetrieveMigrationItems();

		// Token: 0x06000262 RID: 610
		CustomizationData ChangeApplicationSelection(ApplicationInfo appInfo);

		// Token: 0x06000263 RID: 611
		CustomizationData ChangeApplicationInfo(ApplicationInfo appInfo);

		// Token: 0x06000264 RID: 612
		Task RetrieveApplicationListAsync();

		// Token: 0x06000265 RID: 613
		CustomizationData ChangeDriveMapping(DrivePair drivePair);

		// Token: 0x06000266 RID: 614
		void RetrieveDrives();

		// Token: 0x06000267 RID: 615
		CustomizationData ChangeMiscSetting(MiscSettingData miscSetting);

		// Token: 0x06000268 RID: 616
		void RetrieveMiscSettings();

		// Token: 0x06000269 RID: 617
		CustomizationData ChangeUserMapping(UserMapping userMapping);

		// Token: 0x0600026A RID: 618
		CustomizationData SetUserPassword(string accountName, string password);

		// Token: 0x0600026B RID: 619
		void RetrieveUsers();

		// Token: 0x0600026C RID: 620
		void RetrieveFileFilters();

		// Token: 0x0600026D RID: 621
		CustomizationData ChangeFileFilter(int index, FileFilter filter);

		// Token: 0x0600026E RID: 622
		CustomizationData AddFileFilter(FileFilter filter);

		// Token: 0x0600026F RID: 623
		CustomizationData DeleteFileFilter(int index);

		// Token: 0x06000270 RID: 624
		CustomizationData SwapFileFilters(int index1, int index2);

		// Token: 0x06000271 RID: 625
		bool SetVanPassword(string password);

		// Token: 0x06000272 RID: 626
		bool SetProxyAuth(string proxy, string username, string password);

		// Token: 0x06000273 RID: 627
		MachineDriveInfo GetMachineDriveInfo();

		// Token: 0x06000274 RID: 628
		bool CatchCommEx(Action func, [CallerMemberName] string caller = "");

		// Token: 0x06000275 RID: 629
		Task<bool> CatchCommExAsync(Func<Task> func, [CallerMemberName] string caller = "");

		// Token: 0x06000276 RID: 630
		Task PrepareCustomizationAsync();

		// Token: 0x06000277 RID: 631
		Task CancelPrepareCustomizationAsync();

		// Token: 0x06000278 RID: 632
		List<ApplicationData> GetApplications(int taskHandle, GetApplicationsParameters parameters);

		// Token: 0x06000279 RID: 633
		UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly);

		// Token: 0x0600027A RID: 634
		TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace);

		// Token: 0x0600027B RID: 635
		TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly);

		// Token: 0x0600027C RID: 636
		void SendCallbackReply(int replyHandle, int reply);
	}
}
