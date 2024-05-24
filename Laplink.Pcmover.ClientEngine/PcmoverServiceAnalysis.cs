using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x0200000E RID: 14
	public class PcmoverServiceAnalysis : PcmoverTransferState
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x000031D8 File Offset: 0x000013D8
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x000031E0 File Offset: 0x000013E0
		public IPcmoverServiceData Data { get; protected set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000031E9 File Offset: 0x000013E9
		public LlTraceSource Ts { get; }

		// Token: 0x060000A3 RID: 163 RVA: 0x000031F1 File Offset: 0x000013F1
		public PcmoverServiceAnalysis(LlTraceSource ts)
		{
			this.Ts = ts;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003200 File Offset: 0x00001400
		public PcmoverServiceAnalysis(IPcmoverServiceData pcmoverServiceData, LlTraceSource ts) : this(ts)
		{
			this.Data = pcmoverServiceData;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003210 File Offset: 0x00001410
		private void SetRoleIfUnknown(PcmoverTransferState.TransferRole role)
		{
			if (base.Role == PcmoverTransferState.TransferRole.Unknown)
			{
				base.Role = role;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003224 File Offset: 0x00001424
		public void Analyze()
		{
			base.Reset();
			base.PcmoverState = this.Data.PcmoverInfo.State;
			base.PcmoverHasController = this.Data.PcmoverInfo.HasController;
			base.DownloadState = this.Data.DownloadInfo.State;
			base.DownloadHasController = this.Data.DownloadInfo.HasController;
			if (!base.PcmoverState.IsActive())
			{
				return;
			}
			base.TransferId = this.Data.GetPublicProperty(PublicProperties.TransferIdProperty);
			base.OtherComputerHostName = this.Data.GetPublicProperty(PublicProperties.ConfiguredTargetProperty);
			base.SingleMachineTransfer = PcmoverProperties.GetNullableBool(this.Data.GetPublicProperty(PublicProperties.IsSingleMachineModeProperty));
			string publicProperty = this.Data.GetPublicProperty(PublicProperties.SrcOrDstProperty);
			if (publicProperty == PublicProperties.SrcValue)
			{
				base.Role = PcmoverTransferState.TransferRole.Source;
			}
			else if (publicProperty == PublicProperties.DstValue)
			{
				base.Role = PcmoverTransferState.TransferRole.Destination;
			}
			foreach (MachineData machineData in this.Data.Machines)
			{
				if (machineData.Type == MachineType.This)
				{
					base.ThisMachine = machineData;
				}
				else
				{
					base.OtherMachineData = machineData;
				}
			}
			if (base.ThisMachine == null)
			{
				this.TraceCaller("No current machine info, and so we'll assume nothing is happening", "Analyze");
				return;
			}
			int num = this.Data.Machines.Count<MachineData>();
			if (num > 2)
			{
				this.TraceCaller(string.Format("Unexpectedly found {0} machines. Not a standard transfer", num), "Analyze");
				return;
			}
			if (!this.DoActivityAnalysis() && !this.DoTaskAnalysis())
			{
				this.DoMachineAnalysis();
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000033D8 File Offset: 0x000015D8
		private void TraceCaller(string msg, [CallerMemberName] string caller = "")
		{
			this.Ts.TraceCaller(TraceEventType.Verbose, this.Data.HostName + " " + msg, caller);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003400 File Offset: 0x00001600
		private bool DoActivityAnalysis()
		{
			if (this.GetActivity(ActivityType.Undo) != null)
			{
				base.Role = PcmoverTransferState.TransferRole.Destination;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.Undo;
				base.Step = PcmoverTransferState.TransferStep.Transferring;
				base.OtherMachineData = base.ThisMachine;
				this.TraceCaller("Undo", "DoActivityAnalysis");
				return true;
			}
			if (this.GetActivity(ActivityType.SaveMovingVan) != null)
			{
				base.Role = PcmoverTransferState.TransferRole.Source;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.File;
				base.Step = PcmoverTransferState.TransferStep.Transferring;
				this.TraceCaller("SaveMovingVan", "DoActivityAnalysis");
				return true;
			}
			return this.AnalyzeTransferActivity(this.GetActivity(ActivityType.Transfer)) || this.AnalyzeListenActivity(this.GetActivity(ActivityType.Listen));
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000034A0 File Offset: 0x000016A0
		private bool AnalyzeTransferActivity(ActivityInfo activityInfo)
		{
			if (activityInfo == null)
			{
				return false;
			}
			base.Role = PcmoverTransferState.TransferRole.Destination;
			if (activityInfo.IsDone)
			{
				base.Step = (base.DownloadState.IsActive() ? PcmoverTransferState.TransferStep.Downloading : PcmoverTransferState.TransferStep.Done);
			}
			else
			{
				base.Step = PcmoverTransferState.TransferStep.Transferring;
			}
			TransferActivityParameters transferActivityParameters = this.Data.GetTransferActivityParameters(activityInfo.Handle);
			if (transferActivityParameters != null)
			{
				TransferMethodData transferMethodData = this.GetTransferMethodData(transferActivityParameters.TransferMethodHandle);
				if (transferMethodData == null)
				{
					this.TraceCaller(string.Format("Unexpectedly could not find transfer method {0} for transfer activity", transferActivityParameters.TransferMethodHandle), "AnalyzeTransferActivity");
					return true;
				}
				TransferMethodType transferMethodType = transferMethodData.TransferMethodType;
				if (transferMethodType <= TransferMethodType.Image)
				{
					if (transferMethodType == TransferMethodType.File)
					{
						base.TransferType = PcmoverTransferState.TransferTypeEnum.File;
						goto IL_FE;
					}
					if (transferMethodType == TransferMethodType.Image)
					{
						if (this.Data.Machines.Count<MachineData>() == 1)
						{
							base.TransferType = PcmoverTransferState.TransferTypeEnum.Profile;
							goto IL_FE;
						}
						base.TransferType = PcmoverTransferState.TransferTypeEnum.Image;
						goto IL_FE;
					}
				}
				else if (transferMethodType == TransferMethodType.Network || transferMethodType == TransferMethodType.SSL || transferMethodType == TransferMethodType.Usb)
				{
					base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
					goto IL_FE;
				}
				this.TraceCaller(string.Format("Unexpected transfer method type {0} for transfer activity", transferMethodData.TransferMethodType), "AnalyzeTransferActivity");
				IL_FE:
				this.TraceCaller(base.TransferType.ToString(), "AnalyzeTransferActivity");
			}
			else
			{
				this.TraceCaller(string.Format("Could not retrieve transfer activity parameters for activity {0}", activityInfo.Handle), "AnalyzeTransferActivity");
			}
			return true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000035F0 File Offset: 0x000017F0
		private bool AnalyzeListenActivity(ActivityInfo activityInfo)
		{
			if (activityInfo == null)
			{
				return false;
			}
			this.SetRoleIfUnknown(PcmoverTransferState.TransferRole.Source);
			int activityTaskHandle = this.Data.GetActivityTaskHandle(activityInfo.Handle);
			if (activityInfo.IsDone)
			{
				if (activityTaskHandle == 0)
				{
					this.TraceCaller("No fill task found with completed listen activity", "AnalyzeListenActivity");
					return false;
				}
				base.Step = PcmoverTransferState.TransferStep.Done;
			}
			else if (activityTaskHandle != 0)
			{
				base.Role = PcmoverTransferState.TransferRole.Source;
				base.Step = PcmoverTransferState.TransferStep.Transferring;
			}
			else
			{
				ListenActivityPhase phase = (ListenActivityPhase)activityInfo.Phase;
				if (phase == ListenActivityPhase.WaitingForConnection)
				{
					return false;
				}
				if (phase - ListenActivityPhase.StartingTransfer <= 3 || phase == ListenActivityPhase.EndReceived)
				{
					base.Role = PcmoverTransferState.TransferRole.Source;
					base.Step = PcmoverTransferState.TransferStep.Transferring;
				}
				else
				{
					base.Step = PcmoverTransferState.TransferStep.Preparing;
				}
			}
			base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
			this.TraceCaller(string.Format("{0} {1}", base.TransferType, base.Step), "AnalyzeListenActivity");
			return true;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000036B8 File Offset: 0x000018B8
		private bool DoTaskAnalysis()
		{
			PcmTaskData task = this.GetTask(PcmTaskType.Unload);
			if (task != null)
			{
				this.DoUnloadTaskAnalysis(task);
				return true;
			}
			task = this.GetTask(PcmTaskType.Fill);
			if (task != null)
			{
				this.DoFillTaskAnalysis(task);
				return true;
			}
			return false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000036F0 File Offset: 0x000018F0
		private void DoUnloadTaskAnalysis(PcmTaskData task)
		{
			base.Role = PcmoverTransferState.TransferRole.Destination;
			base.Step = (base.DownloadState.IsActive() ? PcmoverTransferState.TransferStep.Downloading : PcmoverTransferState.TransferStep.Done);
			TaskSummaryData taskSummaryData = this.Data.GetTaskSummaryData(task.Handle, true);
			if (taskSummaryData == null)
			{
				this.TraceCaller("Unable to get summary data for unload task", "DoUnloadTaskAnalysis");
				return;
			}
			if (taskSummaryData.Action == TaskAction.Undo)
			{
				base.TransferType = PcmoverTransferState.TransferTypeEnum.Undo;
				base.OtherMachineData = base.ThisMachine;
				this.TraceCaller("Undo", "DoUnloadTaskAnalysis");
				return;
			}
			TransferMethodType transferMethodType = taskSummaryData.TransferMethodType;
			if (transferMethodType <= TransferMethodType.Image)
			{
				if (transferMethodType == TransferMethodType.File)
				{
					base.TransferType = PcmoverTransferState.TransferTypeEnum.File;
					this.TraceCaller("File", "DoUnloadTaskAnalysis");
					return;
				}
				if (transferMethodType == TransferMethodType.Image)
				{
					if (this.Data.Machines.Count<MachineData>() == 1)
					{
						base.TransferType = PcmoverTransferState.TransferTypeEnum.Profile;
						base.OtherMachineData = base.ThisMachine;
						this.TraceCaller("Profile", "DoUnloadTaskAnalysis");
						return;
					}
					base.TransferType = PcmoverTransferState.TransferTypeEnum.Image;
					this.TraceCaller("Image", "DoUnloadTaskAnalysis");
					return;
				}
			}
			else if (transferMethodType == TransferMethodType.Network || transferMethodType == TransferMethodType.SSL || transferMethodType == TransferMethodType.Usb)
			{
				base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
				this.TraceCaller("PcToPc", "DoUnloadTaskAnalysis");
				return;
			}
			this.TraceCaller(string.Format("Unexpected transfer method type {0} for unload task", taskSummaryData.TransferMethodType), "DoUnloadTaskAnalysis");
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000383C File Offset: 0x00001A3C
		private void DoFillTaskAnalysis(PcmTaskData task)
		{
			base.Step = PcmoverTransferState.TransferStep.Customizing;
			MachineData machine = this.GetMachine(task.DestMachineHandle);
			if (machine == null)
			{
				this.TraceCaller("Cannot determine the destination computer for the Fill task", "DoFillTaskAnalysis");
				return;
			}
			MachineData machine2 = this.GetMachine(task.SourceMachineHandle);
			if (machine2 == null)
			{
				this.TraceCaller("Cannot determine the source computer for the Fill task", "DoFillTaskAnalysis");
				return;
			}
			if (machine2.Type == MachineType.This)
			{
				if (machine.Type == MachineType.Any)
				{
					base.Role = PcmoverTransferState.TransferRole.Source;
					base.TransferType = PcmoverTransferState.TransferTypeEnum.File;
					base.OtherMachineData = machine;
					this.TraceCaller("This->Any", "DoFillTaskAnalysis");
					return;
				}
				if (machine.Type == MachineType.This)
				{
					base.Role = PcmoverTransferState.TransferRole.Destination;
					base.TransferType = PcmoverTransferState.TransferTypeEnum.Profile;
					base.OtherMachineData = base.ThisMachine;
					this.TraceCaller("This->This", "DoFillTaskAnalysis");
					return;
				}
				if (machine2.Type == MachineType.This && machine.Type == MachineType.Snapshot)
				{
					base.Role = PcmoverTransferState.TransferRole.Source;
					base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
					base.OtherMachineData = machine;
					this.TraceCaller("This->Snapshot", "DoFillTaskAnalysis");
					return;
				}
			}
			if (machine2.Type == MachineType.Image && machine.Type == MachineType.This)
			{
				base.Role = PcmoverTransferState.TransferRole.Destination;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.Image;
				this.TraceCaller("Image->This", "DoFillTaskAnalysis");
				return;
			}
			if (machine2.Type == MachineType.Snapshot && machine.Type == MachineType.This)
			{
				base.Role = PcmoverTransferState.TransferRole.Destination;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
				this.TraceCaller("Snapshot->This", "DoFillTaskAnalysis");
				return;
			}
			this.TraceCaller(string.Format("Unexpected machine types {0} to {1} for the Fill task", machine2.Type, machine.Type), "DoFillTaskAnalysis");
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000039C6 File Offset: 0x00001BC6
		private void DoMachineAnalysis()
		{
			if (this.Data.Machines.Count<MachineData>() == 1)
			{
				this.Do1MachineAnalysis();
				return;
			}
			this.Do2MachineAnalysis();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000039E8 File Offset: 0x00001BE8
		private void Do1MachineAnalysis()
		{
			TransferMethodData transferMethodData = null;
			NetworkTransferMethodInfo networkTransferMethodInfo = null;
			ActivityInfo activity = this.GetActivity(ActivityType.GetSnapshot);
			if (activity == null)
			{
				foreach (TransferMethodData transferMethodData2 in this.Data.TransferMethods)
				{
					if (transferMethodData2.TransferMethodType.IsNetwork())
					{
						networkTransferMethodInfo = this.Data.GetNetworkTransferMethodInfo(transferMethodData2.Handle);
						if (!string.IsNullOrWhiteSpace((networkTransferMethodInfo != null) ? networkTransferMethodInfo.Target : null))
						{
							transferMethodData = transferMethodData2;
							break;
						}
					}
				}
				if (transferMethodData == null)
				{
					if (base.OtherComputerMachineName == null)
					{
						this.TraceCaller("No GetSnapshot activity or named network transfer method or public properties", "Do1MachineAnalysis");
						return;
					}
					base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
					base.Step = PcmoverTransferState.TransferStep.Preparing;
					this.TraceCaller("From Public Properties, PcToPc with " + base.OtherComputerMachineName, "Do1MachineAnalysis");
					return;
				}
				else
				{
					base.Step = PcmoverTransferState.TransferStep.Preparing;
				}
			}
			else
			{
				base.Step = PcmoverTransferState.TransferStep.Preparing;
				int activityTransferMethodHandle = this.Data.GetActivityTransferMethodHandle(activity.Handle);
				if (activityTransferMethodHandle == 0)
				{
					this.TraceCaller(string.Format("Cannot get transfer method handle for GetSnapshot activity {0}", activity.Handle), "Do1MachineAnalysis");
					return;
				}
				transferMethodData = this.GetTransferMethodData(activityTransferMethodHandle);
				if (transferMethodData == null)
				{
					this.TraceCaller(string.Format("Cannot get transfer method data for GetSnapshot transfer method {0}", activityTransferMethodHandle), "Do1MachineAnalysis");
					return;
				}
				if (transferMethodData.TransferMethodType.IsNetwork())
				{
					networkTransferMethodInfo = this.Data.GetNetworkTransferMethodInfo(transferMethodData.Handle);
				}
			}
			TransferMethodType transferMethodType = transferMethodData.TransferMethodType;
			if (transferMethodType > TransferMethodType.Image)
			{
				if (transferMethodType != TransferMethodType.Network)
				{
					switch (transferMethodType)
					{
					case TransferMethodType.SSL:
					case TransferMethodType.Usb:
						break;
					case (TransferMethodType)84:
					case (TransferMethodType)86:
						goto IL_207;
					case TransferMethodType.WinUpgrade:
						goto IL_198;
					default:
						goto IL_207;
					}
				}
				this.SetRoleIfUnknown(PcmoverTransferState.TransferRole.Destination);
				base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
				base.OtherComputerHostName = ((networkTransferMethodInfo != null) ? networkTransferMethodInfo.Target : null);
				this.TraceCaller("PcToPc", "Do1MachineAnalysis");
				return;
			}
			if (transferMethodType == TransferMethodType.File)
			{
				base.Role = PcmoverTransferState.TransferRole.Source;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.File;
				this.TraceCaller("File", "Do1MachineAnalysis");
				return;
			}
			if (transferMethodType != TransferMethodType.Image)
			{
				goto IL_207;
			}
			IL_198:
			base.Role = PcmoverTransferState.TransferRole.Destination;
			base.TransferType = PcmoverTransferState.TransferTypeEnum.Image;
			this.TraceCaller("Image", "Do1MachineAnalysis");
			return;
			IL_207:
			this.TraceCaller(string.Format("Unexpected {0} transfer method for GetSnapshot activity", transferMethodData.TransferMethodType), "Do1MachineAnalysis");
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003C2C File Offset: 0x00001E2C
		private void Do2MachineAnalysis()
		{
			if (base.OtherMachineData == null)
			{
				this.TraceCaller("OtherMachine not determined", "Do2MachineAnalysis");
				return;
			}
			base.Step = PcmoverTransferState.TransferStep.Preparing;
			switch (base.OtherMachineData.Type)
			{
			case MachineType.Image:
				base.Role = PcmoverTransferState.TransferRole.Destination;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.Image;
				this.TraceCaller("Destination Image", "Do2MachineAnalysis");
				return;
			case MachineType.Snapshot:
				base.Role = PcmoverTransferState.TransferRole.Destination;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.PcToPc;
				this.TraceCaller("Destination PcToPc", "Do2MachineAnalysis");
				return;
			case MachineType.Any:
				base.Role = PcmoverTransferState.TransferRole.Source;
				base.TransferType = PcmoverTransferState.TransferTypeEnum.File;
				this.TraceCaller("Source File", "Do2MachineAnalysis");
				return;
			default:
				this.TraceCaller(string.Format("Unexpected other machine type {0}", base.OtherMachineData.Type), "Do2MachineAnalysis");
				return;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003D00 File Offset: 0x00001F00
		public ActivityInfo GetMachineActivity(ActivityType type, int machineHandle)
		{
			IEnumerable<ActivityInfo> activities = this.Data.Activities;
			Func<ActivityInfo, bool> <>9__0;
			Func<ActivityInfo, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((ActivityInfo a) => a.Type == type));
			}
			foreach (ActivityInfo activityInfo in activities.Where(predicate))
			{
				if (this.Data.GetActivityMachineHandle(activityInfo.Handle) == machineHandle)
				{
					return activityInfo;
				}
			}
			return null;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003D9C File Offset: 0x00001F9C
		public TransferMethodData GetNetworkTransferMethodData(string target)
		{
			return this.GetNetworkTransferMethodData(from tmd in this.Data.TransferMethods
			where tmd.TransferMethodType.IsNetwork()
			select tmd, target);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003DD4 File Offset: 0x00001FD4
		public TransferMethodData GetNetworkTransferMethodData(TransferMethodType networkTme, string target)
		{
			return this.GetNetworkTransferMethodData(from tmd in this.Data.TransferMethods
			where tmd.TransferMethodType == networkTme
			select tmd, target);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003E14 File Offset: 0x00002014
		private TransferMethodData GetNetworkTransferMethodData(IEnumerable<TransferMethodData> networkTms, string target)
		{
			foreach (TransferMethodData transferMethodData in networkTms)
			{
				NetworkTransferMethodInfo networkTransferMethodInfo = this.Data.GetNetworkTransferMethodInfo(transferMethodData.Handle);
				if (networkTransferMethodInfo == null)
				{
					this.TraceCaller(string.Format("Could not get Network Transfer Method Info for {0}", transferMethodData.Handle), "GetNetworkTransferMethodData");
				}
				else if (string.Compare(networkTransferMethodInfo.Target, target, true) == 0)
				{
					return transferMethodData;
				}
			}
			return null;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003EA4 File Offset: 0x000020A4
		public ActivityInfo GetActivity(ActivityType type)
		{
			return this.Data.Activities.FirstOrDefault((ActivityInfo a) => a.Type == type);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003EDC File Offset: 0x000020DC
		public PcmTaskData GetTask(PcmTaskType type)
		{
			return this.Data.Tasks.FirstOrDefault((PcmTaskData t) => t.TaskType == type);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003F14 File Offset: 0x00002114
		public MachineData GetMachine(int handle)
		{
			return this.Data.Machines.FirstOrDefault((MachineData m) => m.Handle == handle);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003F4C File Offset: 0x0000214C
		public TransferMethodData GetTransferMethodData(int handle)
		{
			return this.Data.TransferMethods.FirstOrDefault((TransferMethodData tm) => tm.Handle == handle);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003F84 File Offset: 0x00002184
		public TransferMethodData GetTransferMethodData(TransferMethodType method)
		{
			return this.Data.TransferMethods.FirstOrDefault((TransferMethodData tm) => tm.TransferMethodType == method);
		}
	}
}
