using System;
using System.Collections.Generic;
using System.ServiceModel;
using Laplink.Pcmover.Contracts;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x0200000C RID: 12
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class PcmoverControlCallbackBase : PcmoverMonitorCallbackBase, IPcmoverControlCallback, IPcmoverMonitorCallback
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003040 File Offset: 0x00001240
		protected IPcmoverControl ControlInterface
		{
			get
			{
				return base.Engine.ControlInterface;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000304D File Offset: 0x0000124D
		public PcmoverControlCallbackBase(IPcmoverClientEngine engine) : base(engine)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003056 File Offset: 0x00001256
		public virtual void OnDiscoveredMachine(int discoveryActivityHandle, ConnectableMachine machine)
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003058 File Offset: 0x00001258
		public virtual void OnSetDirection(ConnectableMachine machine)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000305A File Offset: 0x0000125A
		public virtual void UiAssignMissingPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, UserDetail detail)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003069 File Offset: 0x00001269
		public virtual void UiPromptForProxyAuth(int replyHandle, string proxy)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003078 File Offset: 0x00001278
		public virtual void UiAuthorizationError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, ValidationResult validationResult)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003087 File Offset: 0x00001287
		public virtual void UiCheckDiskSpace(int replyHandle, ActivityInfo activityInfo, List<DriveSpaceRequired> requiredList)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 1);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003096 File Offset: 0x00001296
		public virtual void UiConfirmUserMatches(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, bool bShowUsersOnly)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000030A5 File Offset: 0x000012A5
		public virtual void UiDisplayDriveMap(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000030B4 File Offset: 0x000012B4
		public virtual void UiDisplayAppSelection(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000030C3 File Offset: 0x000012C3
		public virtual void UiDisplaySaveLoadException(int replyHandle, UiExceptionType uxt, int cause, int errorCode, string strFileName, bool bSaving, bool bNetwork, string msg)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000030D2 File Offset: 0x000012D2
		public virtual void UiDisplaySpanNotification(int replyHandle, UiCallbackCode code, string fileName, string msg, bool showCheckbox)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 1);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000030E1 File Offset: 0x000012E1
		public virtual void UiDisplayUiccMessage(int replyHandle, UiCallbackCode code, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, nDefault);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000030F1 File Offset: 0x000012F1
		public virtual void UiDisplayUiccMessage1Param(int replyHandle, UiCallbackCode code, string param, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, nDefault);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003101 File Offset: 0x00001301
		public virtual void UiDisplayUiccMessageAndUrl(int replyHandle, UiCallbackCode code, string url, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, nDefault);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003111 File Offset: 0x00001311
		public virtual void UiDisplayWrongEditionError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, PcmoverEdition otherEdition, PcmoverEdition myEdition, string msg)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003120 File Offset: 0x00001320
		public virtual void UiEarlierVersion(int replyHandle, ActivityInfo activityInfo, WindowsVersionData srcWindowsVersion, WindowsVersionData destWindowsVersion)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000312F File Offset: 0x0000132F
		public virtual void UiMessageBox(int replyHandle, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, nDefault);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000313F File Offset: 0x0000133F
		public virtual void UiPromptForVanPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000314E File Offset: 0x0000134E
		public virtual void UiWrongMachine(int replyHandle, ActivityInfo activityInfo, string loadedMachineNetName)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, 0);
		}
	}
}
