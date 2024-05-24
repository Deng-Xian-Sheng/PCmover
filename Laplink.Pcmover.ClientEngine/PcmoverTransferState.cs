using System;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000010 RID: 16
	public class PcmoverTransferState
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00004529 File Offset: 0x00002729
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00004531 File Offset: 0x00002731
		public PcmoverState PcmoverState { get; protected set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000DB RID: 219 RVA: 0x0000453A File Offset: 0x0000273A
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00004542 File Offset: 0x00002742
		public DownloadState DownloadState { get; protected set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000454B File Offset: 0x0000274B
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00004553 File Offset: 0x00002753
		public bool PcmoverHasController { get; protected set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000455C File Offset: 0x0000275C
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00004564 File Offset: 0x00002764
		public bool DownloadHasController { get; protected set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000456D File Offset: 0x0000276D
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00004575 File Offset: 0x00002775
		public MachineData ThisMachine { get; protected set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000457E File Offset: 0x0000277E
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00004586 File Offset: 0x00002786
		public bool? SingleMachineTransfer { get; protected set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004590 File Offset: 0x00002790
		public bool KnowSingleMachineTransfer
		{
			get
			{
				return this.SingleMachineTransfer != null;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x000045AC File Offset: 0x000027AC
		public bool IsSingleMachineTransfer
		{
			get
			{
				return this.KnowSingleMachineTransfer && this.SingleMachineTransfer.Value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000045D1 File Offset: 0x000027D1
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000045D9 File Offset: 0x000027D9
		public string TransferId { get; protected set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000045E2 File Offset: 0x000027E2
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000045EA File Offset: 0x000027EA
		public MachineData OtherMachineData { get; protected set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000045F3 File Offset: 0x000027F3
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00004619 File Offset: 0x00002819
		public string OtherComputerMachineName
		{
			get
			{
				if (this.OtherMachineData != null)
				{
					return this.OtherMachineData.NetName;
				}
				return this._otherComputerMachineName ?? this._otherComputerHostName;
			}
			protected set
			{
				this._otherComputerMachineName = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00004622 File Offset: 0x00002822
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00004634 File Offset: 0x00002834
		public string OtherComputerHostName
		{
			get
			{
				return this._otherComputerHostName ?? this.OtherComputerMachineName;
			}
			protected set
			{
				this._otherComputerHostName = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000463D File Offset: 0x0000283D
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00004645 File Offset: 0x00002845
		public PcmoverTransferState.TransferRole Role { get; protected set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000464E File Offset: 0x0000284E
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x00004656 File Offset: 0x00002856
		public PcmoverTransferState.TransferTypeEnum TransferType { get; protected set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000465F File Offset: 0x0000285F
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x00004667 File Offset: 0x00002867
		public PcmoverTransferState.TransferStep Step { get; protected set; }

		// Token: 0x060000F5 RID: 245 RVA: 0x00004670 File Offset: 0x00002870
		public PcmoverTransferState()
		{
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004678 File Offset: 0x00002878
		public PcmoverTransferState(PcmoverTransferState other)
		{
			this.PcmoverState = other.PcmoverState;
			this.DownloadState = other.DownloadState;
			this.PcmoverHasController = other.PcmoverHasController;
			this.DownloadHasController = other.DownloadHasController;
			this.SingleMachineTransfer = other.SingleMachineTransfer;
			this.TransferId = other.TransferId;
			this.Role = other.Role;
			this.TransferType = other.TransferType;
			this.Step = other.Step;
			this.ThisMachine = other.ThisMachine;
			this.OtherMachineData = other.OtherMachineData;
			this.OtherComputerHostName = other.OtherComputerHostName;
			this.OtherComputerMachineName = other.OtherComputerMachineName;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004728 File Offset: 0x00002928
		public void Reset()
		{
			this.PcmoverState = PcmoverState.idle;
			this.DownloadState = DownloadState.Idle;
			this.PcmoverHasController = false;
			this.DownloadHasController = false;
			this.SingleMachineTransfer = null;
			this.TransferId = null;
			this.Role = PcmoverTransferState.TransferRole.Unknown;
			this.TransferType = PcmoverTransferState.TransferTypeEnum.Unknown;
			this.Step = PcmoverTransferState.TransferStep.NotStarted;
			this.ThisMachine = null;
			this.OtherMachineData = null;
			this.OtherComputerHostName = null;
			this.OtherComputerMachineName = null;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004798 File Offset: 0x00002998
		public bool Equals(PcmoverTransferState other)
		{
			if (this.PcmoverState == other.PcmoverState && this.DownloadState == other.DownloadState && this.PcmoverHasController == other.PcmoverHasController && this.DownloadHasController == other.DownloadHasController)
			{
				bool? singleMachineTransfer = this.SingleMachineTransfer;
				bool? singleMachineTransfer2 = other.SingleMachineTransfer;
				if ((singleMachineTransfer.GetValueOrDefault() == singleMachineTransfer2.GetValueOrDefault() & singleMachineTransfer != null == (singleMachineTransfer2 != null)) && this.TransferId == other.TransferId && this.Role == other.Role && this.TransferType == other.TransferType && this.Step == other.Step && this.ThisMachine == other.ThisMachine && this.OtherMachineData == other.OtherMachineData && this.OtherComputerHostName == other.OtherComputerHostName)
				{
					return this.OtherComputerMachineName == other.OtherComputerMachineName;
				}
			}
			return false;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004899 File Offset: 0x00002A99
		private string MachineName(MachineData machineData)
		{
			return this.MachineName((machineData != null) ? machineData.NetName : null);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000048AD File Offset: 0x00002AAD
		private string MachineName(string name)
		{
			return name ?? "None";
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000048BC File Offset: 0x00002ABC
		public string WhatChanged(PcmoverTransferState other)
		{
			string text = "";
			if (this.PcmoverState != other.PcmoverState)
			{
				text += string.Format("PcmoverState {0}->{1}; ", this.PcmoverState, other.PcmoverState);
			}
			if (this.DownloadState != other.DownloadState)
			{
				text += string.Format("DownloadState {0}->{1}; ", this.DownloadState, other.DownloadState);
			}
			if (this.PcmoverHasController != other.PcmoverHasController)
			{
				text += string.Format("PcmoverHasController {0}->{1}; ", this.PcmoverHasController, other.PcmoverHasController);
			}
			if (this.DownloadHasController != other.DownloadHasController)
			{
				text += string.Format("PcmoverHasController {0}->{1}; ", this.DownloadHasController, other.DownloadHasController);
			}
			if (this.KnowSingleMachineTransfer != other.KnowSingleMachineTransfer)
			{
				text += string.Format("KnowSingleMachineTransfer {0}->{1}; ", this.KnowSingleMachineTransfer, other.KnowSingleMachineTransfer);
			}
			if (this.IsSingleMachineTransfer != other.IsSingleMachineTransfer)
			{
				text += string.Format("IsSingleMachineTransfer {0}->{1}; ", this.IsSingleMachineTransfer, other.IsSingleMachineTransfer);
			}
			if (this.TransferId != other.TransferId)
			{
				text = string.Concat(new string[]
				{
					text,
					"TransferId ",
					this.TransferId,
					"->",
					other.TransferId,
					"; "
				});
			}
			if (this.Role != other.Role)
			{
				text += string.Format("Role {0}->{1}; ", this.Role, other.Role);
			}
			if (this.TransferType != other.TransferType)
			{
				text += string.Format("Type {0}->{1}; ", this.TransferType, other.TransferType);
			}
			if (this.Step != other.Step)
			{
				text += string.Format("Step {0}->{1}; ", this.Step, other.Step);
			}
			if (this.ThisMachine != other.ThisMachine)
			{
				text = string.Concat(new string[]
				{
					text,
					"ThisMachine ",
					this.MachineName(this.ThisMachine),
					"->",
					this.MachineName(other.ThisMachine),
					"; "
				});
			}
			if (this.OtherMachineData != other.OtherMachineData)
			{
				text = string.Concat(new string[]
				{
					text,
					"OtherMachineData ",
					this.MachineName(this.OtherMachineData),
					"->",
					this.MachineName(other.OtherMachineData),
					"; "
				});
			}
			if (this.OtherComputerHostName != other.OtherComputerHostName)
			{
				text = string.Concat(new string[]
				{
					text,
					"OtherComputerHostName ",
					this.MachineName(this.OtherComputerHostName),
					"->",
					this.MachineName(other.OtherComputerHostName),
					"; "
				});
			}
			if (this.OtherComputerMachineName != other.OtherComputerMachineName)
			{
				text = string.Concat(new string[]
				{
					text,
					"OtherComputerMachineName ",
					this.MachineName(this.OtherComputerMachineName),
					"->",
					this.MachineName(other.OtherComputerMachineName),
					"; "
				});
			}
			return text;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00004C54 File Offset: 0x00002E54
		public string AnalysisSummary
		{
			get
			{
				return string.Format("Role: {0}, Type: {1}, Step: {2}", this.Role, this.TransferType, this.Step);
			}
		}

		// Token: 0x0400003F RID: 63
		private string _otherComputerMachineName;

		// Token: 0x04000040 RID: 64
		private string _otherComputerHostName;

		// Token: 0x02000027 RID: 39
		public enum TransferRole
		{
			// Token: 0x04000072 RID: 114
			Unknown,
			// Token: 0x04000073 RID: 115
			Source,
			// Token: 0x04000074 RID: 116
			Destination
		}

		// Token: 0x02000028 RID: 40
		public enum TransferTypeEnum
		{
			// Token: 0x04000076 RID: 118
			Unknown,
			// Token: 0x04000077 RID: 119
			PcToPc,
			// Token: 0x04000078 RID: 120
			Image,
			// Token: 0x04000079 RID: 121
			Profile,
			// Token: 0x0400007A RID: 122
			File,
			// Token: 0x0400007B RID: 123
			Undo
		}

		// Token: 0x02000029 RID: 41
		public enum TransferStep
		{
			// Token: 0x0400007D RID: 125
			NotStarted,
			// Token: 0x0400007E RID: 126
			Preparing,
			// Token: 0x0400007F RID: 127
			Customizing,
			// Token: 0x04000080 RID: 128
			Transferring,
			// Token: 0x04000081 RID: 129
			Downloading,
			// Token: 0x04000082 RID: 130
			Done
		}
	}
}
