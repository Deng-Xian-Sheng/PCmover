using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000030 RID: 48
	public class UiCallbacksHandler : PcmUICallbacks, IPcmUICallbacks
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0001061A File Offset: 0x0000E81A
		private LlTraceSource Ts
		{
			get
			{
				return this._manager.Ts;
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00010627 File Offset: 0x0000E827
		public UiCallbacksHandler(PcmActivity activity)
		{
			this._activity = activity;
			this._manager = this._activity.Manager;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00010648 File Offset: 0x0000E848
		private void uiAssignMissingPassword(NetUser netUser)
		{
			ITaskActivity taskActivity = this._activity as ITaskActivity;
			if (taskActivity == null)
			{
				this.Ts.TraceInformation("Cannot handle uiAssignMissingPassword for a non-TransferActivity");
				return;
			}
			ServiceTask serviceTask = taskActivity.ActivityServiceTask;
			if (serviceTask == null)
			{
				this.Ts.TraceInformation("Cannot handle uiAssignMissingPassword with no ServiceTask");
				return;
			}
			UserDetail user = this._manager.CreateUserDetail(netUser);
			this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiAssignMissingPassword(replyHandle, this._activity.Info, serviceTask.Handle, user);
			}, 0, "uiAssignMissingPassword");
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000106D8 File Offset: 0x0000E8D8
		public void uiAssignMissingPasswords(UnloadVanTask task)
		{
			uint nUsersWithoutPasswords = task.nUsersWithoutPasswords;
			for (uint num = 0U; num < nUsersWithoutPasswords; num += 1U)
			{
				this.uiAssignMissingPassword(task.get_UsersWithoutPasswords(num));
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00010708 File Offset: 0x0000E908
		public bool uiWrongMachine(string loadedMachineNetName, bool bUnload)
		{
			return this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiWrongMachine(replyHandle, this._activity.Info, loadedMachineNetName);
			}, 0, "uiWrongMachine") != 0;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0001074C File Offset: 0x0000E94C
		public bool uiCheckDiskSpace(DriveSpaceRequiredMap driveSpaceRequired)
		{
			List<DriveSpaceRequired> list = this._manager.ConvertRequiredMap(driveSpaceRequired);
			return this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiCheckDiskSpace(replyHandle, this._activity.Info, list);
			}, 1, "uiCheckDiskSpace") != 0;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00010798 File Offset: 0x0000E998
		public bool uiEarlierVersion(UnloadVanTask task)
		{
			ServiceTask serviceTask = this._manager.ServiceTasks.FindTask(task);
			ServiceMachine serviceMachine;
			ServiceMachine serviceMachine2;
			if (serviceTask != null)
			{
				serviceMachine = serviceTask.SrcServiceMachine;
				serviceMachine2 = serviceTask.DstServiceMachine;
			}
			else
			{
				serviceMachine = this._manager.GetServiceMachine(task.srcMachine);
				serviceMachine2 = this._manager.GetServiceMachine(task.destMachine);
			}
			WindowsVersionData srcVersion = serviceMachine.Data.WindowsVersion;
			WindowsVersionData destVersion = serviceMachine2.Data.WindowsVersion;
			return this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiEarlierVersion(replyHandle, this._activity.Info, srcVersion, destVersion);
			}, 0, "uiEarlierVersion") != 0;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00003A90 File Offset: 0x00001C90
		public void uiGetPassword(ref string pPassword)
		{
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00010840 File Offset: 0x0000EA40
		public void uiConfirmUserMatches(UnloadVanTask task, bool bShowUsersOnly)
		{
			ITaskActivity taskActivity = this._activity as ITaskActivity;
			if (taskActivity == null)
			{
				this.Ts.TraceInformation("Cannot handle uiConfirmUserMatches for a non-TransferActivity");
				return;
			}
			ServiceTask serviceTask = taskActivity.ActivityServiceTask;
			if (serviceTask == null)
			{
				this.Ts.TraceInformation("Cannot handle uiConfirmUserMatches with no ServiceTask");
				return;
			}
			this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiConfirmUserMatches(replyHandle, this._activity.Info, serviceTask.Handle, bShowUsersOnly);
			}, 0, "uiConfirmUserMatches");
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000108C4 File Offset: 0x0000EAC4
		public void uiDisplayDriveMap(UnloadVanTask task)
		{
			ITaskActivity taskActivity = this._activity as ITaskActivity;
			if (taskActivity == null)
			{
				this.Ts.TraceInformation("Cannot handle uiDisplayDriveMap for a non-TransferActivity");
				return;
			}
			ServiceTask serviceTask = taskActivity.ActivityServiceTask;
			if (serviceTask == null)
			{
				this.Ts.TraceInformation("Cannot handle uiDisplayDriveMap with no ServiceTask");
				return;
			}
			this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiDisplayDriveMap(replyHandle, this._activity.Info, serviceTask.Handle);
			}, 0, "uiDisplayDriveMap");
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00010944 File Offset: 0x0000EB44
		public void uiDisplayAppSelection(UnloadVanTask task)
		{
			ITaskActivity taskActivity = this._activity as ITaskActivity;
			if (taskActivity == null)
			{
				this.Ts.TraceInformation("Cannot handle uiDisplayAppSelection for a non-TransferActivity");
				return;
			}
			ServiceTask serviceTask = taskActivity.ActivityServiceTask;
			if (serviceTask == null)
			{
				this.Ts.TraceInformation("Cannot handle uiDisplayAppSelection with no ServiceTask");
				return;
			}
			this._manager.CallUiControlCallback(delegate(int replyHandle)
			{
				this._manager.ControlCallback.UiDisplayAppSelection(replyHandle, this._activity.Info, serviceTask.Handle);
			}, 0, "uiDisplayAppSelection");
		}

		// Token: 0x040000B8 RID: 184
		private readonly PcmActivity _activity;

		// Token: 0x040000B9 RID: 185
		private readonly PcmoverManager _manager;
	}
}
