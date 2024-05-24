using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Laplink.Pcmover.Contracts;
using Laplink.Pcmover.ScriptApi;
using Laplink.Tools.Helpers;
using PCmover.Infrastructure;
using Prism.Events;

namespace ClientEngineModule.Scr
{
	// Token: 0x02000005 RID: 5
	public class PcmoverControlCallback : IPcmoverControlCallback, IPcmoverMonitorCallback
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020B5 File Offset: 0x000002B5
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020BD File Offset: 0x000002BD
		public IScriptChannel _ScriptConnection { get; set; }

		// Token: 0x0600000C RID: 12 RVA: 0x000020C8 File Offset: 0x000002C8
		public PcmoverControlCallback(PCmoverEngineScr engine, IEventAggregator eventAggregator, LlTraceSource llTraceSource)
		{
			this.Ts = llTraceSource;
			this._Engine = engine;
			this._EventAggregator = eventAggregator;
			this.PollItems = new Dictionary<PollItemName, PollItem>();
			foreach (object obj in Enum.GetValues(typeof(PollItemName)))
			{
				PollItemName key = (PollItemName)obj;
				this.PollItems.Add(key, new PollItem());
			}
			this._PollTimer = new System.Timers.Timer(2000.0);
			this._PollTimer.Elapsed += this._PollTimer_Elapsed;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002194 File Offset: 0x00000394
		// (set) Token: 0x0600000E RID: 14 RVA: 0x0000219C File Offset: 0x0000039C
		public Dictionary<PollItemName, PollItem> PollItems { get; private set; }

		// Token: 0x0600000F RID: 15 RVA: 0x000021A5 File Offset: 0x000003A5
		private void _PollTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			this._PollTimer.Stop();
			this.UiAuthorizationError();
			this.Done_ExpandSnapshot();
			this.Done_BuildChangeLists();
			this.Done_Transfer();
			this.Done_ReadSnapshot();
			this._PollTimer.Start();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021DB File Offset: 0x000003DB
		public void StartPolling()
		{
			this._PollTimer.Start();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021E8 File Offset: 0x000003E8
		public void StopPolling()
		{
			this._PollTimer.Stop();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021F8 File Offset: 0x000003F8
		private void UiAuthorizationError()
		{
			try
			{
				if (this._ScriptConnection.InvokeScript("authErrorPending;") == "1")
				{
					int replyHandle = Convert.ToInt32(this._ScriptConnection.InvokeScript("authErrorReplyHandle;"));
					Events.AuthorizationErrorEventArgs payload = new Events.AuthorizationErrorEventArgs
					{
						ResumeAction = new Action<bool>(this.ResumeAuthorizationCallbackThread),
						Result = new ValidationResult()
					};
					this._EventAggregator.GetEvent<EngineEvents.AuthorizationError>().Publish(payload);
					this._CallbackResetEvent.WaitOne();
					this.SendCallbackReply(replyHandle, this._AuthorizationReply);
					this._ScriptConnection.InvokeScript("authErrorPending=false;");
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "UiAuthorizationError");
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022BC File Offset: 0x000004BC
		private void Done_ExpandSnapshot()
		{
			if (!this.PollItems[PollItemName.ExpandSnapshot].Enabled)
			{
				return;
			}
			bool flag = false;
			try
			{
				flag = Convert.ToBoolean(Convert.ToInt16(this._ScriptConnection.InvokeScript("ExpandSnapshotComplete;")));
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "Done_ExpandSnapshot");
			}
			if (flag)
			{
				this.PollItems[PollItemName.ExpandSnapshot].Enabled = false;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002338 File Offset: 0x00000538
		private void Done_BuildChangeLists()
		{
			if (!this.PollItems[PollItemName.BuildChangeLists].Enabled)
			{
				return;
			}
			bool flag = false;
			try
			{
				flag = Convert.ToBoolean(Convert.ToInt16(this._ScriptConnection.InvokeScript("BuildChangeListsComplete;")));
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "Done_BuildChangeLists");
			}
			if (flag)
			{
				string value = this._ScriptConnection.InvokeScript("fillTaskHandle;");
				TaskStats payload = this._Engine.TaskGetStats(Convert.ToInt32(value), true);
				this.PollItems[PollItemName.BuildChangeLists].Enabled = false;
				this._EventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Publish(payload);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023E8 File Offset: 0x000005E8
		private void Done_Transfer()
		{
			if (!this.PollItems[PollItemName.Transfer].Enabled)
			{
				return;
			}
			bool flag = false;
			try
			{
				flag = Convert.ToBoolean(Convert.ToInt16(this._ScriptConnection.InvokeScript("TransferComplete;")));
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "Done_Transfer");
			}
			if (flag)
			{
				TransferCompleteInfo transferCompleteInfo = new TransferCompleteInfo();
				transferCompleteInfo.ActivityInfo = new ActivityInfo
				{
					State = ActivityState.Success
				};
				this.PollItems[PollItemName.Transfer].Enabled = false;
				this._EventAggregator.GetEvent<EngineEvents.TransferComplete>().Publish(transferCompleteInfo);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000248C File Offset: 0x0000068C
		private void Done_ReadSnapshot()
		{
			if (!this.PollItems[PollItemName.ReadSnapshot].Enabled)
			{
				return;
			}
			bool flag = false;
			try
			{
				flag = Convert.ToBoolean(Convert.ToInt16(this._ScriptConnection.InvokeScript("readSnapshotComplete;")));
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "Done_ReadSnapshot");
				flag = false;
			}
			if (flag)
			{
				this.PollItems[PollItemName.ReadSnapshot].Enabled = false;
				this._EventAggregator.GetEvent<EngineEvents.ReadyForCustomizationEvent>().Publish();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002518 File Offset: 0x00000718
		private void ResumeAuthorizationCallbackThread(bool Retry)
		{
			this._AuthorizationReply = (Retry ? 1 : 0);
			this._CallbackResetEvent.Set();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002533 File Offset: 0x00000733
		private void SendCallbackReply(int replyHandle, int result)
		{
			IScriptChannel scriptConnection = this._ScriptConnection;
			if (scriptConnection == null)
			{
				return;
			}
			scriptConnection.InvokeScript(string.Format("iPcmover.SendCallbackReply({0}, {1});", replyHandle, result));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000255C File Offset: 0x0000075C
		public void OnDiscoveredMachine(int discoveryActivityHandle, ConnectableMachine machine)
		{
			this._Engine.FireMachineFoundEvent(machine);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000256A File Offset: 0x0000076A
		public void OnSetDirection(ConnectableMachine machine)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002571 File Offset: 0x00000771
		public void UiMessageBox(int replyHandle, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002578 File Offset: 0x00000778
		public void UiDisplayUiccMessage(int replyHandle, UiCallbackCode code, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000257F File Offset: 0x0000077F
		public void UiDisplayUiccMessage1Param(int replyHandle, UiCallbackCode code, string param, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002586 File Offset: 0x00000786
		public void UiDisplayUiccMessageAndUrl(int replyHandle, UiCallbackCode code, string url, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000258D File Offset: 0x0000078D
		public void UiDisplaySaveLoadException(int replyHandle, UiExceptionType uxt, int cause, int errorCode, string strFileName, bool bSaving, bool bNetwork, string msg)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002594 File Offset: 0x00000794
		public void UiAssignMissingPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, UserDetail detail)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000259B File Offset: 0x0000079B
		public void UiDisplayWrongEditionError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, PcmoverEdition otherEdition, PcmoverEdition myEdition, string msg)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000025A2 File Offset: 0x000007A2
		public void UiPromptForVanPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025A9 File Offset: 0x000007A9
		public void UiAuthorizationError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, ValidationResult validationResult)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000025B0 File Offset: 0x000007B0
		public void UiPromptForProxyAuth(int replyHandle, string proxy)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000025B7 File Offset: 0x000007B7
		public void UiWrongMachine(int replyHandle, ActivityInfo activityInfo, string loadedMachineNetName)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000025BE File Offset: 0x000007BE
		public void UiEarlierVersion(int replyHandle, ActivityInfo activityInfo, WindowsVersionData srcWindowsVersion, WindowsVersionData destWindowsVersion)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000025C5 File Offset: 0x000007C5
		public void UiCheckDiskSpace(int replyHandle, ActivityInfo activityInfo, List<DriveSpaceRequired> requiredList)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000025CC File Offset: 0x000007CC
		public void UiDisplaySpanNotification(int replyHandle, UiCallbackCode code, string fileName, string msg, bool showCheckbox)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000025D3 File Offset: 0x000007D3
		public void UiConfirmUserMatches(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, bool bShowUsersOnly)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000025DA File Offset: 0x000007DA
		public void UiDisplayDriveMap(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000025E1 File Offset: 0x000007E1
		public void UiDisplayAppSelection(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025E8 File Offset: 0x000007E8
		public void PcmoverStatusChanged(PcmoverStatusInfo statusInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000025EF File Offset: 0x000007EF
		public void ActivityProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000025F6 File Offset: 0x000007F6
		public void ActivityChanged(ActivityInfo activityInfo, MonitorChangeType change)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000025F8 File Offset: 0x000007F8
		public void MachineChanged(MachineData machineData, MonitorChangeType change)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000025FA File Offset: 0x000007FA
		public void TaskChanged(PcmTaskData taskData, MonitorChangeType change)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002601 File Offset: 0x00000801
		public void TransferMethodChanged(TransferMethodData transferMethodData, MonitorChangeType change)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002608 File Offset: 0x00000808
		public void PublicPropertyChanged(string key, string value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400000B RID: 11
		private System.Timers.Timer _PollTimer;

		// Token: 0x0400000C RID: 12
		private IEventAggregator _EventAggregator;

		// Token: 0x0400000D RID: 13
		private readonly AutoResetEvent _CallbackResetEvent = new AutoResetEvent(false);

		// Token: 0x0400000E RID: 14
		private int _AuthorizationReply;

		// Token: 0x0400000F RID: 15
		private LlTraceSource Ts;

		// Token: 0x04000010 RID: 16
		private readonly PCmoverEngineScr _Engine;
	}
}
