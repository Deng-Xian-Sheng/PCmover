using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;

namespace Laplink.Pcmover.Proxies
{
	// Token: 0x02000002 RID: 2
	public class PcmoverControlClient : PcmoverMonitorClient<IPcmoverControl>, IPcmoverControl, IPcmoverMonitor, IPcmoverQuery
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public PcmoverControlClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress) : base(callbackInstance, binding, remoteAddress)
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205B File Offset: 0x0000025B
		public PcmoverControlClient(InstanceContext callbackInstance, string endpointConfigurationName) : base(callbackInstance, endpointConfigurationName)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002065 File Offset: 0x00000265
		public bool BecomeController(CallbackState controlCallbackState)
		{
			return base.Channel.BecomeController(controlCallbackState);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002073 File Offset: 0x00000273
		public void StopBeingController()
		{
			base.Channel.StopBeingController();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002080 File Offset: 0x00000280
		public void ConfigureControlCallbacks(CallbackState controlCallbackState)
		{
			base.Channel.ConfigureControlCallbacks(controlCallbackState);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000208E File Offset: 0x0000028E
		public void SendCallbackReply(int replyHandle, int reply)
		{
			base.Channel.SendCallbackReply(replyHandle, reply);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000209D File Offset: 0x0000029D
		public TestResultData RunTest(TestParameterData p)
		{
			return base.Channel.RunTest(p);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020AB File Offset: 0x000002AB
		public bool SetPolicy(string p, int fullSize, bool firstPage, bool lastPage)
		{
			return base.Channel.SetPolicy(p, fullSize, firstPage, lastPage);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020BD File Offset: 0x000002BD
		public string GetPolicy(RequestedPage page)
		{
			return base.Channel.GetPolicy(page);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020CB File Offset: 0x000002CB
		public PcmoverState InitPcmoverApp(InitPcmoverData data)
		{
			return base.Channel.InitPcmoverApp(data);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020D9 File Offset: 0x000002D9
		public PcmoverState ShutdownPcmoverApp(bool terminateService)
		{
			return base.Channel.ShutdownPcmoverApp(terminateService);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020E7 File Offset: 0x000002E7
		public IDictionary<string, string> GetAllControllerProperties()
		{
			return base.Channel.GetAllControllerProperties();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020F4 File Offset: 0x000002F4
		public string GetControllerProperty(string key)
		{
			return base.Channel.GetControllerProperty(key);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002102 File Offset: 0x00000302
		public void SetControllerProperty(string key, string value)
		{
			base.Channel.SetControllerProperty(key, value);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002111 File Offset: 0x00000311
		public void SetPublicProperty(string key, string value)
		{
			base.Channel.SetPublicProperty(key, value);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002120 File Offset: 0x00000320
		public void ClearAllProperties()
		{
			base.Channel.ClearAllProperties();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000212D File Offset: 0x0000032D
		public PolicyData GetPolicyData()
		{
			return base.Channel.GetPolicyData();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000213A File Offset: 0x0000033A
		public void SetProductCulture(string language, string country)
		{
			base.Channel.SetProductCulture(language, country);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002149 File Offset: 0x00000349
		public AuthorizationRequestData GetAuthorizationData()
		{
			return base.Channel.GetAuthorizationData();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002156 File Offset: 0x00000356
		public bool SetAuthorizationData(AuthorizationRequestData authRequest)
		{
			return base.Channel.SetAuthorizationData(authRequest);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002164 File Offset: 0x00000364
		public SerialNumberInfo GetSerialNumberInfo(string serialNumber)
		{
			return base.Channel.GetSerialNumberInfo(serialNumber);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002172 File Offset: 0x00000372
		public string GetDefaultCertificateName()
		{
			return base.Channel.GetDefaultCertificateName();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000217F File Offset: 0x0000037F
		public AppUpdateData CheckForUpdate()
		{
			return base.Channel.CheckForUpdate();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000218C File Offset: 0x0000038C
		public bool ApplyDataUpdate()
		{
			return base.Channel.ApplyDataUpdate();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002199 File Offset: 0x00000399
		public void SetEngineLogData(EngineLogData data)
		{
			base.Channel.SetEngineLogData(data);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000021A7 File Offset: 0x000003A7
		public EngineLogData GetEngineLogData()
		{
			return base.Channel.GetEngineLogData();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000021B4 File Offset: 0x000003B4
		public DateTime GetUndoTime()
		{
			return base.Channel.GetUndoTime();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000021C1 File Offset: 0x000003C1
		public string GetWindowsOld()
		{
			return base.Channel.GetWindowsOld();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000021CE File Offset: 0x000003CE
		public SecurityProductsData GetSecurityProducts()
		{
			return base.Channel.GetSecurityProducts();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000021DB File Offset: 0x000003DB
		public bool SuspendSleep(bool suspend)
		{
			return base.Channel.SuspendSleep(suspend);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000021E9 File Offset: 0x000003E9
		public bool Reboot(uint delay)
		{
			return base.Channel.Reboot(delay);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000021F7 File Offset: 0x000003F7
		public bool LaunchStartupAutoRun()
		{
			return base.Channel.LaunchStartupAutoRun();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002204 File Offset: 0x00000404
		public bool MarkUserDeferredComplete(string userName, string userSid)
		{
			return base.Channel.MarkUserDeferredComplete(userName, userSid);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002213 File Offset: 0x00000413
		public bool SetProxyAuth(string proxy, string username, string password)
		{
			return base.Channel.SetProxyAuth(proxy, username, password);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002223 File Offset: 0x00000423
		public IEnumerable<NetworkInfo> GetNetworkInfos()
		{
			return base.Channel.GetNetworkInfos();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002230 File Offset: 0x00000430
		public RebootPendingReasons CheckRebootPending()
		{
			return base.Channel.CheckRebootPending();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000223D File Offset: 0x0000043D
		public bool DeleteMachine(int machineHandle)
		{
			return base.Channel.DeleteMachine(machineHandle);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000224B File Offset: 0x0000044B
		public IEnumerable<CategoryDefinition> MachineGetCategories(int machineHandle, CategoryParameters categoryParameters, RequestedPage page)
		{
			return base.Channel.MachineGetCategories(machineHandle, categoryParameters, page);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000225B File Offset: 0x0000045B
		public IEnumerable<DriveSpaceData> MachineGetDriveSpace(int machineHandle)
		{
			return base.Channel.MachineGetDriveSpace(machineHandle);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002269 File Offset: 0x00000469
		public MachineDriveInfo MachineGetDriveInfo(int machineHandle)
		{
			return base.Channel.MachineGetDriveInfo(machineHandle);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002277 File Offset: 0x00000477
		public IEnumerable<ApplicationData> MachineGetApplications(int machineHandle, GetApplicationsParameters parameters, RequestedPage page)
		{
			return base.Channel.MachineGetApplications(machineHandle, parameters, page);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002287 File Offset: 0x00000487
		public IEnumerable<ApplicationData> MachineGetMicrosoftOfficeTrialApps(int machineHandle, GetApplicationsParameters parameters)
		{
			return base.Channel.MachineGetMicrosoftOfficeTrialApps(machineHandle, parameters);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002296 File Offset: 0x00000496
		public int CreateTransferMethod(TransferMethodType tm)
		{
			return base.Channel.CreateTransferMethod(tm);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000022A4 File Offset: 0x000004A4
		public IEnumerable<TransferMethodType> GetDiscoveryTransferMethods()
		{
			return base.Channel.GetDiscoveryTransferMethods();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000022B1 File Offset: 0x000004B1
		public bool DeleteTransferMethod(int transferMethodHandle)
		{
			return base.Channel.DeleteTransferMethod(transferMethodHandle);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000022BF File Offset: 0x000004BF
		public bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info)
		{
			return base.Channel.SetNetworkTransferMethodInfo(networkTransferMethodHandle, info);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000022CE File Offset: 0x000004CE
		public SslInfo GetSslInfo(int networkTransferMethodHandle)
		{
			return base.Channel.GetSslInfo(networkTransferMethodHandle);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000022DC File Offset: 0x000004DC
		public SslInfo GetLocalSslInfo()
		{
			return base.Channel.GetLocalSslInfo();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000022E9 File Offset: 0x000004E9
		public bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData)
		{
			return base.Channel.SetImageTransferMethodInfo(imageTransferMethodHandle, imageMapData);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000022F8 File Offset: 0x000004F8
		public bool SetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle, WinUpgradeTransferMethodInfo info)
		{
			return base.Channel.SetWinUpgradeTransferMethodInfo(winUpgradeTransferMethodHandle, info);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002307 File Offset: 0x00000507
		public bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info)
		{
			return base.Channel.SetFileTransferMethodInfo(fileTransferMethodHandle, info);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002316 File Offset: 0x00000516
		public bool RefreshNetworkAdapters()
		{
			return base.Channel.RefreshNetworkAdapters();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002323 File Offset: 0x00000523
		public uint GetValidNetworkAdapterCount()
		{
			return base.Channel.GetValidNetworkAdapterCount();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002330 File Offset: 0x00000530
		public ActivityInfo StartActivity(int activityHandle)
		{
			return base.Channel.StartActivity(activityHandle);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000233E File Offset: 0x0000053E
		public ActivityInfo StopActivity(int activityHandle)
		{
			return base.Channel.StopActivity(activityHandle);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000234C File Offset: 0x0000054C
		public bool DeleteActivity(int activityHandle)
		{
			return base.Channel.DeleteActivity(activityHandle);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000235A File Offset: 0x0000055A
		public ActivityInfo CreateAppInventoryActivity(int machineHandle, AppInventoryAmount amount)
		{
			return base.Channel.CreateAppInventoryActivity(machineHandle, amount);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002369 File Offset: 0x00000569
		public bool ConfigureAppInventoryActivity(int appInventoryActivityHandle, AppInventoryAmount amount)
		{
			return base.Channel.ConfigureAppInventoryActivity(appInventoryActivityHandle, amount);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002378 File Offset: 0x00000578
		public ActivityInfo CreateDiscoveryActivity(IEnumerable<int> transferMethodHandles, int timeout, string discoveryId)
		{
			return base.Channel.CreateDiscoveryActivity(transferMethodHandles, timeout, discoveryId);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002388 File Offset: 0x00000588
		public IEnumerable<ConnectableMachine> GetConnectableMachines(int discoveryActivityHandle)
		{
			return base.Channel.GetConnectableMachines(discoveryActivityHandle);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002396 File Offset: 0x00000596
		public bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure)
		{
			return base.Channel.AddRemoteMachine(machine, discoveryId, bSecure);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000023A6 File Offset: 0x000005A6
		public ActivityInfo CreateSaveSnapshotActivity(int fileTransferMethodHandle, int machineHandle)
		{
			return base.Channel.CreateSaveSnapshotActivity(fileTransferMethodHandle, machineHandle);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000023B5 File Offset: 0x000005B5
		public ActivityInfo CreateGetSnapshotActivity(int transferMethodHandle)
		{
			return base.Channel.CreateGetSnapshotActivity(transferMethodHandle);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000023C3 File Offset: 0x000005C3
		public ActivityInfo CreateBuildChangeListsActivity(int fillTaskHandle)
		{
			return base.Channel.CreateBuildChangeListsActivity(fillTaskHandle);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000023D1 File Offset: 0x000005D1
		public ActivityInfo CreateSaveMovingVanActivity(int fileTransferMethodHandle, int fillTaskHandle)
		{
			return base.Channel.CreateSaveMovingVanActivity(fileTransferMethodHandle, fillTaskHandle);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000023E0 File Offset: 0x000005E0
		public ActivityInfo CreateTransferActivity(TransferActivityParameters transferActivityParameters)
		{
			return base.Channel.CreateTransferActivity(transferActivityParameters);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000023EE File Offset: 0x000005EE
		public ActivityInfo CreateListenActivity(IEnumerable<int> transferMethodHandles, string discoveryId)
		{
			return base.Channel.CreateListenActivity(transferMethodHandles, discoveryId);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000023FD File Offset: 0x000005FD
		public bool SetDirection(ConnectableMachine remoteMachine)
		{
			return base.Channel.SetDirection(remoteMachine);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000240B File Offset: 0x0000060B
		public ActivityInfo CreateUndoActivity()
		{
			return base.Channel.CreateUndoActivity();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002418 File Offset: 0x00000618
		public ActivityInfo CreateExpandSnapshotActivity(ExpandSnapshotActivityParameters esaParameters)
		{
			return base.Channel.CreateExpandSnapshotActivity(esaParameters);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002426 File Offset: 0x00000626
		public ActivityInfo CreateGenerateReportsActivity(int taskHandle, IEnumerable<ReportData> reports)
		{
			return base.Channel.CreateGenerateReportsActivity(taskHandle, reports);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002435 File Offset: 0x00000635
		public ActivityInfo CreateLoadMovingJournalActivity(int transferMethodHandle)
		{
			return base.Channel.CreateLoadMovingJournalActivity(transferMethodHandle);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002443 File Offset: 0x00000643
		public FillTaskData CreateFillTask(int oldMachineHandle, int newMachineHandle, int transferMethodHandle, string selectionRoots)
		{
			return base.Channel.CreateFillTask(oldMachineHandle, newMachineHandle, transferMethodHandle, selectionRoots);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002455 File Offset: 0x00000655
		public bool DeleteTask(int taskHandle)
		{
			return base.Channel.DeleteTask(taskHandle);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002463 File Offset: 0x00000663
		public MigrationItemsOption? TaskGetMigrationItems(int fillTaskHandle)
		{
			return base.Channel.TaskGetMigrationItems(fillTaskHandle);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002471 File Offset: 0x00000671
		public CustomizationData TaskChangeMigrationItems(int fillTaskHandle, MigrationItemsOption items)
		{
			return base.Channel.TaskChangeMigrationItems(fillTaskHandle, items);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002480 File Offset: 0x00000680
		public MiscSettingsData TaskGetMiscSettings(int fillTaskHandle, string uiCultureName)
		{
			return base.Channel.TaskGetMiscSettings(fillTaskHandle, uiCultureName);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000248F File Offset: 0x0000068F
		public CustomizationData TaskChangeMiscSetting(int fillTaskHandle, MiscSettingData setting)
		{
			return base.Channel.TaskChangeMiscSetting(fillTaskHandle, setting);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000249E File Offset: 0x0000069E
		public IEnumerable<ApplicationData> TaskGetApplications(int taskHandle, GetApplicationsParameters parameters, RequestedPage page)
		{
			return base.Channel.TaskGetApplications(taskHandle, parameters, page);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000024AE File Offset: 0x000006AE
		public ApplicationData TaskGetApplicationData(int taskHandle, ulong applicationId)
		{
			return base.Channel.TaskGetApplicationData(taskHandle, applicationId);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000024BD File Offset: 0x000006BD
		public CustomizationData TaskChangeApplicationData(int taskHandle, ApplicationData data)
		{
			return base.Channel.TaskChangeApplicationData(taskHandle, data);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000024CC File Offset: 0x000006CC
		public UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly)
		{
			return base.Channel.TaskGetUserMappings(taskHandle, regularUsersOnly);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000024DB File Offset: 0x000006DB
		public CustomizationData TaskChangeUserMapping(int taskHandle, UserMapping userMapping)
		{
			return base.Channel.TaskChangeUserMapping(taskHandle, userMapping);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000024EA File Offset: 0x000006EA
		public CustomizationData TaskSetUserPassword(int taskHandle, UserDetail user, string password)
		{
			return base.Channel.TaskSetUserPassword(taskHandle, user, password);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000024FA File Offset: 0x000006FA
		public DriveData TaskGetDriveData(int taskHandle)
		{
			return base.Channel.TaskGetDriveData(taskHandle);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002508 File Offset: 0x00000708
		public CustomizationData TaskChangeDriveMapping(int taskHandle, DrivePair drivePair)
		{
			return base.Channel.TaskChangeDriveMapping(taskHandle, drivePair);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002518 File Offset: 0x00000718
		public TransferrableContainerData TaskGetTransferrableContainerData(int taskHandle, ItemType type, string path, bool withinBranch, CountDetail countDetail, bool includeTargets, bool allAppsOnly, RequestedPage page)
		{
			return base.Channel.TaskGetTransferrableContainerData(taskHandle, type, path, withinBranch, countDetail, includeTargets, allAppsOnly, page);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002540 File Offset: 0x00000740
		public CustomizationData TaskChangeContainerData(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool? userSelected, string target, bool containerAllAppsOnly)
		{
			return base.Channel.TaskChangeContainerData(taskHandle, type, containerPath, itemName, isContainer, userSelected, target, containerAllAppsOnly);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002565 File Offset: 0x00000765
		public CustomizationData TaskRemoveRedirection(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool containerAllAppsOnly)
		{
			return base.Channel.TaskRemoveRedirection(taskHandle, type, containerPath, itemName, isContainer, containerAllAppsOnly);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000257B File Offset: 0x0000077B
		public IEnumerable<ItemFilterData> TaskGetItemFilters(int taskHandle, ItemType type)
		{
			return base.Channel.TaskGetItemFilters(taskHandle, type);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000258A File Offset: 0x0000078A
		public CustomizationData TaskChangeItemFilter(int taskHandle, ItemType type, int index, ItemFilterData filter)
		{
			return base.Channel.TaskChangeItemFilter(taskHandle, type, index, filter);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000259C File Offset: 0x0000079C
		public CustomizationData TaskSwapItemFilters(int taskHandle, ItemType type, int index1, int index2)
		{
			return base.Channel.TaskSwapItemFilters(taskHandle, type, index1, index2);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000025AE File Offset: 0x000007AE
		public bool TaskSetVanPassword(int taskHandle, string password)
		{
			return base.Channel.TaskSetVanPassword(taskHandle, password);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000025BD File Offset: 0x000007BD
		public TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace)
		{
			return base.Channel.TaskGetStats(taskHandle, includeDriveSpace);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000025CC File Offset: 0x000007CC
		public IEnumerable<TransferrableCategoryDefinition> TaskGetCategories(int taskHandle, CategoryParameters categoryParameters, RequestedPage page)
		{
			return base.Channel.TaskGetCategories(taskHandle, categoryParameters, page);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000025DC File Offset: 0x000007DC
		public TransferContainerData TaskGetTransferContainerData(int taskHandle, ItemType type, CategoryDefinition category, string path, CountDetail countDetail, RequestedPage page)
		{
			return base.Channel.TaskGetTransferContainerData(taskHandle, type, category, path, countDetail, page);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000025F2 File Offset: 0x000007F2
		public bool TaskUploadApplicationReport(int taskHandle)
		{
			return base.Channel.TaskUploadApplicationReport(taskHandle);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002600 File Offset: 0x00000800
		public IEnumerable<string> TaskGetRedistPackages(int unloadTaskHandle)
		{
			return base.Channel.TaskGetRedistPackages(unloadTaskHandle);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000260E File Offset: 0x0000080E
		public FinishTransferData TaskPerformPostTransferActions(int taskHandle, bool dlmgrReboot)
		{
			return base.Channel.TaskPerformPostTransferActions(taskHandle, dlmgrReboot);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000261D File Offset: 0x0000081D
		public AuthorizationInfo TaskGetAuthorizationInfo(int taskHandle)
		{
			return base.Channel.TaskGetAuthorizationInfo(taskHandle);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000262B File Offset: 0x0000082B
		public bool TaskPrepareAuthorization(int taskHandle, AuthorizationRequestData authRequest)
		{
			return base.Channel.TaskPrepareAuthorization(taskHandle, authRequest);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000263A File Offset: 0x0000083A
		public TaskAlertData PolicyGetInteractiveAlert(TaskAlertData.AlertType alertType)
		{
			return base.Channel.PolicyGetInteractiveAlert(alertType);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002648 File Offset: 0x00000848
		public bool TaskPostAlerts(int taskHandle, TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, string statusMessage)
		{
			return base.Channel.TaskPostAlerts(taskHandle, alertType, interactiveAlert, statusMessage);
		}
	}
}
