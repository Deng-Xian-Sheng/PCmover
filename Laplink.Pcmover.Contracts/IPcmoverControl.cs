using System;
using System.Collections.Generic;
using System.ServiceModel;
using Laplink.Service.Contracts;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000040 RID: 64
	[ServiceContract(Namespace = "http://laplink.com/services/contracts/v2.0056", SessionMode = SessionMode.Required, CallbackContract = typeof(IPcmoverControlCallback))]
	[StandardFaults]
	public interface IPcmoverControl : IPcmoverMonitor, IPcmoverQuery
	{
		// Token: 0x06000171 RID: 369
		[OperationContract(IsOneWay = true)]
		void SendCallbackReply(int replyHandle, int reply);

		// Token: 0x06000172 RID: 370
		[OperationContract]
		TestResultData RunTest(TestParameterData p);

		// Token: 0x06000173 RID: 371
		[OperationContract]
		bool SetPolicy(string p, int fullSize, bool firstPage, bool lastPage);

		// Token: 0x06000174 RID: 372
		[OperationContract]
		string GetPolicy(RequestedPage page);

		// Token: 0x06000175 RID: 373
		[OperationContract]
		PcmoverState InitPcmoverApp(InitPcmoverData data);

		// Token: 0x06000176 RID: 374
		[OperationContract]
		PcmoverState ShutdownPcmoverApp(bool terminateService);

		// Token: 0x06000177 RID: 375
		[OperationContract(Name = "BecomeControllerPcmover")]
		bool BecomeController(CallbackState controlCallbackState);

		// Token: 0x06000178 RID: 376
		[OperationContract(Name = "StopBeingControllerPcmover")]
		void StopBeingController();

		// Token: 0x06000179 RID: 377
		[OperationContract(Name = "ConfigureControlCallbacksPcmover")]
		void ConfigureControlCallbacks(CallbackState controlCallbackState);

		// Token: 0x0600017A RID: 378
		[OperationContract]
		IDictionary<string, string> GetAllControllerProperties();

		// Token: 0x0600017B RID: 379
		[OperationContract]
		string GetControllerProperty(string key);

		// Token: 0x0600017C RID: 380
		[OperationContract]
		void SetControllerProperty(string key, string value);

		// Token: 0x0600017D RID: 381
		[OperationContract]
		void SetPublicProperty(string key, string value);

		// Token: 0x0600017E RID: 382
		[OperationContract]
		void ClearAllProperties();

		// Token: 0x0600017F RID: 383
		[OperationContract]
		PolicyData GetPolicyData();

		// Token: 0x06000180 RID: 384
		[OperationContract]
		void SetProductCulture(string language, string country);

		// Token: 0x06000181 RID: 385
		[OperationContract]
		AuthorizationRequestData GetAuthorizationData();

		// Token: 0x06000182 RID: 386
		[OperationContract]
		bool SetAuthorizationData(AuthorizationRequestData authRequest);

		// Token: 0x06000183 RID: 387
		[OperationContract]
		SerialNumberInfo GetSerialNumberInfo(string serialNumber);

		// Token: 0x06000184 RID: 388
		[OperationContract]
		string GetDefaultCertificateName();

		// Token: 0x06000185 RID: 389
		[OperationContract]
		AppUpdateData CheckForUpdate();

		// Token: 0x06000186 RID: 390
		[OperationContract]
		bool ApplyDataUpdate();

		// Token: 0x06000187 RID: 391
		[OperationContract]
		void SetEngineLogData(EngineLogData data);

		// Token: 0x06000188 RID: 392
		[OperationContract]
		EngineLogData GetEngineLogData();

		// Token: 0x06000189 RID: 393
		[OperationContract]
		DateTime GetUndoTime();

		// Token: 0x0600018A RID: 394
		[OperationContract]
		string GetWindowsOld();

		// Token: 0x0600018B RID: 395
		[OperationContract]
		SecurityProductsData GetSecurityProducts();

		// Token: 0x0600018C RID: 396
		[OperationContract]
		bool SuspendSleep(bool suspend);

		// Token: 0x0600018D RID: 397
		[OperationContract]
		bool Reboot(uint delay);

		// Token: 0x0600018E RID: 398
		[OperationContract]
		bool SetProxyAuth(string proxy, string username, string Password);

		// Token: 0x0600018F RID: 399
		[OperationContract]
		IEnumerable<NetworkInfo> GetNetworkInfos();

		// Token: 0x06000190 RID: 400
		[OperationContract]
		RebootPendingReasons CheckRebootPending();

		// Token: 0x06000191 RID: 401
		[OperationContract]
		bool LaunchStartupAutoRun();

		// Token: 0x06000192 RID: 402
		[OperationContract]
		bool MarkUserDeferredComplete(string userName, string userSid);

		// Token: 0x06000193 RID: 403
		[OperationContract]
		bool DeleteMachine(int machineHandle);

		// Token: 0x06000194 RID: 404
		[OperationContract]
		IEnumerable<CategoryDefinition> MachineGetCategories(int machineHandle, CategoryParameters categoryParameters, RequestedPage page);

		// Token: 0x06000195 RID: 405
		[OperationContract]
		IEnumerable<DriveSpaceData> MachineGetDriveSpace(int machineHandle);

		// Token: 0x06000196 RID: 406
		[OperationContract]
		MachineDriveInfo MachineGetDriveInfo(int machineHandle);

		// Token: 0x06000197 RID: 407
		[OperationContract]
		IEnumerable<ApplicationData> MachineGetApplications(int machineHandle, GetApplicationsParameters parameters, RequestedPage page);

		// Token: 0x06000198 RID: 408
		[OperationContract]
		IEnumerable<ApplicationData> MachineGetMicrosoftOfficeTrialApps(int machineHandle, GetApplicationsParameters parameters);

		// Token: 0x06000199 RID: 409
		[OperationContract]
		int CreateTransferMethod(TransferMethodType tm);

		// Token: 0x0600019A RID: 410
		[OperationContract]
		IEnumerable<TransferMethodType> GetDiscoveryTransferMethods();

		// Token: 0x0600019B RID: 411
		[OperationContract]
		bool DeleteTransferMethod(int transferMethodHandle);

		// Token: 0x0600019C RID: 412
		[OperationContract]
		bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info);

		// Token: 0x0600019D RID: 413
		[OperationContract]
		SslInfo GetSslInfo(int networkTransferMethodHandle);

		// Token: 0x0600019E RID: 414
		[OperationContract]
		SslInfo GetLocalSslInfo();

		// Token: 0x0600019F RID: 415
		[OperationContract]
		bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData);

		// Token: 0x060001A0 RID: 416
		[OperationContract]
		bool SetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle, WinUpgradeTransferMethodInfo info);

		// Token: 0x060001A1 RID: 417
		[OperationContract]
		bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info);

		// Token: 0x060001A2 RID: 418
		[OperationContract]
		bool RefreshNetworkAdapters();

		// Token: 0x060001A3 RID: 419
		[OperationContract]
		uint GetValidNetworkAdapterCount();

		// Token: 0x060001A4 RID: 420
		[OperationContract]
		ActivityInfo StartActivity(int activityHandle);

		// Token: 0x060001A5 RID: 421
		[OperationContract]
		ActivityInfo StopActivity(int activityHandle);

		// Token: 0x060001A6 RID: 422
		[OperationContract]
		bool DeleteActivity(int activityHandle);

		// Token: 0x060001A7 RID: 423
		[OperationContract]
		ActivityInfo CreateAppInventoryActivity(int machineHandle, AppInventoryAmount amount);

		// Token: 0x060001A8 RID: 424
		[OperationContract]
		bool ConfigureAppInventoryActivity(int appInventoryActivityHandle, AppInventoryAmount amount);

		// Token: 0x060001A9 RID: 425
		[OperationContract]
		ActivityInfo CreateDiscoveryActivity(IEnumerable<int> transferMethodHandles, int timeout, string discoveryId);

		// Token: 0x060001AA RID: 426
		[OperationContract]
		IEnumerable<ConnectableMachine> GetConnectableMachines(int discoveryActivityHandle);

		// Token: 0x060001AB RID: 427
		[OperationContract]
		bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure);

		// Token: 0x060001AC RID: 428
		[OperationContract]
		ActivityInfo CreateSaveSnapshotActivity(int fileTransferMethodHandle, int machineHandle);

		// Token: 0x060001AD RID: 429
		[OperationContract]
		ActivityInfo CreateGetSnapshotActivity(int transferMethodHandle);

		// Token: 0x060001AE RID: 430
		[OperationContract]
		ActivityInfo CreateBuildChangeListsActivity(int fillTaskHandle);

		// Token: 0x060001AF RID: 431
		[OperationContract]
		ActivityInfo CreateSaveMovingVanActivity(int fileTransferMethodHandle, int fillTaskHandle);

		// Token: 0x060001B0 RID: 432
		[OperationContract]
		ActivityInfo CreateTransferActivity(TransferActivityParameters transferActivityParameters);

		// Token: 0x060001B1 RID: 433
		[OperationContract]
		ActivityInfo CreateListenActivity(IEnumerable<int> transferMethodHandles, string discoveryId);

		// Token: 0x060001B2 RID: 434
		[OperationContract]
		bool SetDirection(ConnectableMachine remoteMachine);

		// Token: 0x060001B3 RID: 435
		[OperationContract]
		ActivityInfo CreateUndoActivity();

		// Token: 0x060001B4 RID: 436
		[OperationContract]
		ActivityInfo CreateExpandSnapshotActivity(ExpandSnapshotActivityParameters esaParameters);

		// Token: 0x060001B5 RID: 437
		[OperationContract]
		ActivityInfo CreateGenerateReportsActivity(int taskHandle, IEnumerable<ReportData> reports);

		// Token: 0x060001B6 RID: 438
		[OperationContract]
		ActivityInfo CreateLoadMovingJournalActivity(int transferMethodHandle);

		// Token: 0x060001B7 RID: 439
		[OperationContract]
		FillTaskData CreateFillTask(int oldMachineHandle, int newMachineHandle, int transferMethodHandle, string selectionRoots);

		// Token: 0x060001B8 RID: 440
		[OperationContract]
		bool DeleteTask(int taskHandle);

		// Token: 0x060001B9 RID: 441
		[OperationContract]
		MigrationItemsOption? TaskGetMigrationItems(int fillTaskHandle);

		// Token: 0x060001BA RID: 442
		[OperationContract]
		CustomizationData TaskChangeMigrationItems(int fillTaskHandle, MigrationItemsOption items);

		// Token: 0x060001BB RID: 443
		[OperationContract]
		MiscSettingsData TaskGetMiscSettings(int fillTaskHandle, string uiCultureName);

		// Token: 0x060001BC RID: 444
		[OperationContract]
		CustomizationData TaskChangeMiscSetting(int fillTaskHandle, MiscSettingData setting);

		// Token: 0x060001BD RID: 445
		[OperationContract]
		IEnumerable<ApplicationData> TaskGetApplications(int taskHandle, GetApplicationsParameters parameters, RequestedPage page);

		// Token: 0x060001BE RID: 446
		[OperationContract]
		ApplicationData TaskGetApplicationData(int taskHandle, ulong applicationId);

		// Token: 0x060001BF RID: 447
		[OperationContract]
		CustomizationData TaskChangeApplicationData(int taskHandle, ApplicationData data);

		// Token: 0x060001C0 RID: 448
		[OperationContract]
		UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly);

		// Token: 0x060001C1 RID: 449
		[OperationContract]
		CustomizationData TaskChangeUserMapping(int taskHandle, UserMapping userMapping);

		// Token: 0x060001C2 RID: 450
		[OperationContract]
		CustomizationData TaskSetUserPassword(int taskHandle, UserDetail user, string password);

		// Token: 0x060001C3 RID: 451
		[OperationContract]
		DriveData TaskGetDriveData(int taskHandle);

		// Token: 0x060001C4 RID: 452
		[OperationContract]
		CustomizationData TaskChangeDriveMapping(int taskHandle, DrivePair drivePair);

		// Token: 0x060001C5 RID: 453
		[OperationContract]
		TransferrableContainerData TaskGetTransferrableContainerData(int taskHandle, ItemType type, string path, bool withinBranch, CountDetail countDetail, bool includeTargets, bool allAppsOnly, RequestedPage page);

		// Token: 0x060001C6 RID: 454
		[OperationContract]
		CustomizationData TaskChangeContainerData(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool? userSelected, string target, bool containerAllAppsOnly);

		// Token: 0x060001C7 RID: 455
		[OperationContract]
		CustomizationData TaskRemoveRedirection(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool containerAllAppsOnly);

		// Token: 0x060001C8 RID: 456
		[OperationContract]
		IEnumerable<ItemFilterData> TaskGetItemFilters(int taskHandle, ItemType type);

		// Token: 0x060001C9 RID: 457
		[OperationContract]
		CustomizationData TaskChangeItemFilter(int taskHandle, ItemType type, int index, ItemFilterData filter);

		// Token: 0x060001CA RID: 458
		[OperationContract]
		CustomizationData TaskSwapItemFilters(int taskHandle, ItemType type, int index1, int index2);

		// Token: 0x060001CB RID: 459
		[OperationContract]
		bool TaskSetVanPassword(int taskHandle, string password);

		// Token: 0x060001CC RID: 460
		[OperationContract]
		TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace);

		// Token: 0x060001CD RID: 461
		[OperationContract]
		IEnumerable<TransferrableCategoryDefinition> TaskGetCategories(int taskHandle, CategoryParameters categoryParameters, RequestedPage page);

		// Token: 0x060001CE RID: 462
		[OperationContract]
		TransferContainerData TaskGetTransferContainerData(int taskHandle, ItemType type, CategoryDefinition category, string path, CountDetail countDetail, RequestedPage page);

		// Token: 0x060001CF RID: 463
		[OperationContract]
		bool TaskUploadApplicationReport(int taskHandle);

		// Token: 0x060001D0 RID: 464
		[OperationContract]
		IEnumerable<string> TaskGetRedistPackages(int unloadTaskHandle);

		// Token: 0x060001D1 RID: 465
		[OperationContract]
		FinishTransferData TaskPerformPostTransferActions(int taskHandle, bool dlmgrReboot);

		// Token: 0x060001D2 RID: 466
		[OperationContract]
		AuthorizationInfo TaskGetAuthorizationInfo(int taskHandle);

		// Token: 0x060001D3 RID: 467
		[OperationContract]
		bool TaskPrepareAuthorization(int taskHandle, AuthorizationRequestData authRequest);

		// Token: 0x060001D4 RID: 468
		[OperationContract]
		TaskAlertData PolicyGetInteractiveAlert(TaskAlertData.AlertType alertType);

		// Token: 0x060001D5 RID: 469
		[OperationContract]
		bool TaskPostAlerts(int taskHandle, TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, string statusMessage);
	}
}
