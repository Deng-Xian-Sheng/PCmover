using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000041 RID: 65
	public interface IPcmoverControlCallback : IPcmoverMonitorCallback
	{
		// Token: 0x060001D6 RID: 470
		[OperationContract(IsOneWay = true)]
		void OnDiscoveredMachine(int discoveryActivityHandle, ConnectableMachine machine);

		// Token: 0x060001D7 RID: 471
		[OperationContract(IsOneWay = true)]
		void OnSetDirection(ConnectableMachine machine);

		// Token: 0x060001D8 RID: 472
		[OperationContract(IsOneWay = true)]
		void UiMessageBox(int replyHandle, string msg, uint nType, uint nIDHelp, int nDefault);

		// Token: 0x060001D9 RID: 473
		[OperationContract(IsOneWay = true)]
		void UiDisplayUiccMessage(int replyHandle, UiCallbackCode code, string msg, uint nType, uint nIDHelp, int nDefault);

		// Token: 0x060001DA RID: 474
		[OperationContract(IsOneWay = true)]
		void UiDisplayUiccMessage1Param(int replyHandle, UiCallbackCode code, string param, string msg, uint nType, uint nIDHelp, int nDefault);

		// Token: 0x060001DB RID: 475
		[OperationContract(IsOneWay = true)]
		void UiDisplayUiccMessageAndUrl(int replyHandle, UiCallbackCode code, string url, string msg, uint nType, uint nIDHelp, int nDefault);

		// Token: 0x060001DC RID: 476
		[OperationContract(IsOneWay = true)]
		void UiDisplaySaveLoadException(int replyHandle, UiExceptionType uxt, int cause, int errorCode, string strFileName, bool bSaving, bool bNetwork, string msg);

		// Token: 0x060001DD RID: 477
		[OperationContract(IsOneWay = true)]
		void UiAssignMissingPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, UserDetail detail);

		// Token: 0x060001DE RID: 478
		[OperationContract(IsOneWay = true)]
		void UiDisplayWrongEditionError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, PcmoverEdition otherEdition, PcmoverEdition myEdition, string msg);

		// Token: 0x060001DF RID: 479
		[OperationContract(IsOneWay = true)]
		void UiPromptForVanPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle);

		// Token: 0x060001E0 RID: 480
		[OperationContract(IsOneWay = true)]
		void UiAuthorizationError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, ValidationResult validationResult);

		// Token: 0x060001E1 RID: 481
		[OperationContract(IsOneWay = true)]
		void UiPromptForProxyAuth(int replyHandle, string proxy);

		// Token: 0x060001E2 RID: 482
		[OperationContract(IsOneWay = true)]
		void UiWrongMachine(int replyHandle, ActivityInfo activityInfo, string loadedMachineNetName);

		// Token: 0x060001E3 RID: 483
		[OperationContract(IsOneWay = true)]
		void UiEarlierVersion(int replyHandle, ActivityInfo activityInfo, WindowsVersionData srcWindowsVersion, WindowsVersionData destWindowsVersion);

		// Token: 0x060001E4 RID: 484
		[OperationContract(IsOneWay = true)]
		void UiCheckDiskSpace(int replyHandle, ActivityInfo activityInfo, List<DriveSpaceRequired> requiredList);

		// Token: 0x060001E5 RID: 485
		[OperationContract(IsOneWay = true)]
		void UiDisplaySpanNotification(int replyHandle, UiCallbackCode code, string fileName, string msg, bool showCheckbox);

		// Token: 0x060001E6 RID: 486
		[OperationContract(IsOneWay = true)]
		void UiConfirmUserMatches(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, bool bShowUsersOnly);

		// Token: 0x060001E7 RID: 487
		[OperationContract(IsOneWay = true)]
		void UiDisplayDriveMap(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle);

		// Token: 0x060001E8 RID: 488
		[OperationContract(IsOneWay = true)]
		void UiDisplayAppSelection(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle);
	}
}
