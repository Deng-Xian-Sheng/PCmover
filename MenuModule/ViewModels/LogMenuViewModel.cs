using System;
using System.IO;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MenuModule.ViewModels
{
	// Token: 0x02000008 RID: 8
	public class LogMenuViewModel : BindableBase
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000024DF File Offset: 0x000006DF
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000024E7 File Offset: 0x000006E7
		private Action OnClosePopup { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000024F0 File Offset: 0x000006F0
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000024F8 File Offset: 0x000006F8
		public bool DetailErrors
		{
			get
			{
				return this._DetailErrors;
			}
			set
			{
				this.SetProperty<bool>(ref this._DetailErrors, value, "DetailErrors");
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000250D File Offset: 0x0000070D
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002515 File Offset: 0x00000715
		public bool DetailStatus
		{
			get
			{
				return this._DetailStatus;
			}
			set
			{
				this.SetProperty<bool>(ref this._DetailStatus, value, "DetailStatus");
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000252A File Offset: 0x0000072A
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002532 File Offset: 0x00000732
		public bool DetailVerbose
		{
			get
			{
				return this._DetailVerbose;
			}
			set
			{
				this.SetProperty<bool>(ref this._DetailVerbose, value, "DetailVerbose");
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002547 File Offset: 0x00000747
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000254F File Offset: 0x0000074F
		public string LogFileName
		{
			get
			{
				return this._LogFileName;
			}
			set
			{
				this.SetProperty<string>(ref this._LogFileName, value, "LogFileName");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002564 File Offset: 0x00000764
		// (set) Token: 0x06000025 RID: 37 RVA: 0x0000256C File Offset: 0x0000076C
		public bool MethodFile
		{
			get
			{
				return this._MethodFile;
			}
			set
			{
				this.SetProperty<bool>(ref this._MethodFile, value, "MethodFile");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002581 File Offset: 0x00000781
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002589 File Offset: 0x00000789
		public bool MethodCsv
		{
			get
			{
				return this._MethodCsv;
			}
			set
			{
				this.SetProperty<bool>(ref this._MethodCsv, value, "MethodCsv");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000259E File Offset: 0x0000079E
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000025A6 File Offset: 0x000007A6
		public bool MethodPopup
		{
			get
			{
				return this._MethodPopup;
			}
			set
			{
				this.SetProperty<bool>(ref this._MethodPopup, value, "MethodPopup");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000025BB File Offset: 0x000007BB
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000025C3 File Offset: 0x000007C3
		public bool MethodThread
		{
			get
			{
				return this._MethodThread;
			}
			set
			{
				this.SetProperty<bool>(ref this._MethodThread, value, "MethodThread");
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000025D8 File Offset: 0x000007D8
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000025E0 File Offset: 0x000007E0
		public bool WhatBuild
		{
			get
			{
				return this._WhatBuild;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatBuild, value, "WhatBuild");
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000025F5 File Offset: 0x000007F5
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000025FD File Offset: 0x000007FD
		public bool WhatNetwork
		{
			get
			{
				return this._WhatNetwork;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatNetwork, value, "WhatNetwork");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002612 File Offset: 0x00000812
		// (set) Token: 0x06000031 RID: 49 RVA: 0x0000261A File Offset: 0x0000081A
		public bool WhatStartup
		{
			get
			{
				return this._WhatStartup;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatStartup, value, "WhatStartup");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000262F File Offset: 0x0000082F
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002637 File Offset: 0x00000837
		public bool WhatUnload
		{
			get
			{
				return this._WhatUnload;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatUnload, value, "WhatUnload");
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000034 RID: 52 RVA: 0x0000264C File Offset: 0x0000084C
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002654 File Offset: 0x00000854
		public bool WhatFill
		{
			get
			{
				return this._WhatFill;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatFill, value, "WhatFill");
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002669 File Offset: 0x00000869
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002671 File Offset: 0x00000871
		public bool WhatSnapshot
		{
			get
			{
				return this._WhatSnapshot;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatSnapshot, value, "WhatSnapshot");
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002686 File Offset: 0x00000886
		// (set) Token: 0x06000039 RID: 57 RVA: 0x0000268E File Offset: 0x0000088E
		public bool WhatProgress
		{
			get
			{
				return this._WhatProgress;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatProgress, value, "WhatProgress");
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000026A3 File Offset: 0x000008A3
		// (set) Token: 0x0600003B RID: 59 RVA: 0x000026AB File Offset: 0x000008AB
		public bool WhatUsers
		{
			get
			{
				return this._WhatUsers;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatUsers, value, "WhatUsers");
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000026C0 File Offset: 0x000008C0
		// (set) Token: 0x0600003D RID: 61 RVA: 0x000026C8 File Offset: 0x000008C8
		public bool WhatApps
		{
			get
			{
				return this._WhatApps;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatApps, value, "WhatApps");
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000026DD File Offset: 0x000008DD
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000026E5 File Offset: 0x000008E5
		public bool WhatWizard
		{
			get
			{
				return this._WhatWizard;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatWizard, value, "WhatWizard");
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000026FA File Offset: 0x000008FA
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002702 File Offset: 0x00000902
		public bool WhatThread
		{
			get
			{
				return this._WhatThread;
			}
			set
			{
				this.SetProperty<bool>(ref this._WhatThread, value, "WhatThread");
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002718 File Offset: 0x00000918
		public LogMenuViewModel(IUnityContainer container, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.eventAggregator = eventAggregator;
			this.pcmoverEngine = pcmoverEngine;
			this.container = container;
			this._DetailErrors = false;
			this._DetailStatus = false;
			this._DetailVerbose = false;
			this._LogFileName = "";
			this._MethodFile = false;
			this._MethodCsv = false;
			this._MethodPopup = false;
			this._MethodThread = false;
			this._WhatBuild = false;
			this._WhatNetwork = false;
			this._WhatStartup = false;
			this._WhatUnload = false;
			this._WhatFill = false;
			this._WhatSnapshot = false;
			this._WhatProgress = false;
			this._WhatUsers = false;
			this._WhatApps = false;
			this._WhatWizard = false;
			this._WhatThread = false;
			this.OnApply = new DelegateCommand(new Action(this.OnApplyCommand));
			this.OnBrowse = new DelegateCommand(new Action(this.OnBrowseCommand));
			this.OnViewLogFile = new DelegateCommand(new Action(this.OnViewLogFileCommand));
			this.OnApplyExit = new DelegateCommand(new Action(this.OnApplyExitCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand));
			this.OnClosePopup = overlayArgs.ClosePopupCallback;
			this.ReadConfig();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002850 File Offset: 0x00000A50
		private void ReadConfig()
		{
			if (!this.pcmoverEngine.CatchCommEx(delegate
			{
				this.engineLogData = this.pcmoverEngine.GetEngineLogData();
			}, "ReadConfig"))
			{
				return;
			}
			this.DetailErrors = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_ERROR) > SpInfoBox_Type.SIBT_NONE);
			this.DetailStatus = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_STATUS) > SpInfoBox_Type.SIBT_NONE);
			this.DetailVerbose = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_VERBOSE) > SpInfoBox_Type.SIBT_NONE);
			this.WhatNetwork = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_NETWORK) > SpInfoBox_Type.SIBT_NONE);
			this.WhatStartup = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_STARTUP) > SpInfoBox_Type.SIBT_NONE);
			this.WhatUnload = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_UNLOAD) > SpInfoBox_Type.SIBT_NONE);
			this.WhatFill = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_FILL) > SpInfoBox_Type.SIBT_NONE);
			this.WhatBuild = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_BUILD) > SpInfoBox_Type.SIBT_NONE);
			this.WhatSnapshot = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_SNAPSHOT) > SpInfoBox_Type.SIBT_NONE);
			this.WhatProgress = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_PROGRESS) > SpInfoBox_Type.SIBT_NONE);
			this.WhatUsers = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_USERS) > SpInfoBox_Type.SIBT_NONE);
			this.WhatApps = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_APPS) > SpInfoBox_Type.SIBT_NONE);
			this.WhatWizard = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_WIZARD) > SpInfoBox_Type.SIBT_NONE);
			this.WhatThread = ((this.engineLogData.Type & SpInfoBox_Type.SIBT_THREAD) > SpInfoBox_Type.SIBT_NONE);
			this.MethodPopup = ((this.engineLogData.Method & SpInfoBox_Method.SIBM_POPUP) > SpInfoBox_Method.SIBM_NONE);
			this.MethodFile = ((this.engineLogData.Method & SpInfoBox_Method.SIBM_FILE) > SpInfoBox_Method.SIBM_NONE);
			this.MethodCsv = ((this.engineLogData.Method & SpInfoBox_Method.SIBM_CSV) > SpInfoBox_Method.SIBM_NONE);
			this.MethodThread = ((this.engineLogData.Method & SpInfoBox_Method.SIBM_THREAD) > SpInfoBox_Method.SIBM_NONE);
			this.LogFileName = this.engineLogData.FileName;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002A3E File Offset: 0x00000C3E
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002A46 File Offset: 0x00000C46
		public DelegateCommand OnApply { get; private set; }

		// Token: 0x06000046 RID: 70 RVA: 0x00002A50 File Offset: 0x00000C50
		private void OnApplyCommand()
		{
			uint type = 0U;
			uint method = 0U;
			this.SetFlagFromBool(this._DetailErrors, ref type, 1U);
			this.SetFlagFromBool(this._DetailStatus, ref type, 2U);
			this.SetFlagFromBool(this._DetailVerbose, ref type, 4U);
			this.SetFlagFromBool(this._WhatNetwork, ref type, 16U);
			this.SetFlagFromBool(this._WhatStartup, ref type, 32U);
			this.SetFlagFromBool(this._WhatUnload, ref type, 64U);
			this.SetFlagFromBool(this._WhatFill, ref type, 128U);
			this.SetFlagFromBool(this._WhatBuild, ref type, 256U);
			this.SetFlagFromBool(this._WhatSnapshot, ref type, 512U);
			this.SetFlagFromBool(this._WhatProgress, ref type, 1024U);
			this.SetFlagFromBool(this._WhatUsers, ref type, 2048U);
			this.SetFlagFromBool(this._WhatApps, ref type, 4096U);
			this.SetFlagFromBool(this._WhatWizard, ref type, 8192U);
			this.SetFlagFromBool(this._WhatThread, ref type, 16384U);
			this.SetFlagFromBool(this._MethodPopup, ref method, 1U);
			this.SetFlagFromBool(this._MethodFile, ref method, 2U);
			this.SetFlagFromBool(this._MethodCsv, ref method, 16U);
			this.SetFlagFromBool(this._MethodThread, ref method, 32U);
			this.engineLogData.Type = (SpInfoBox_Type)type;
			this.engineLogData.Method = (SpInfoBox_Method)method;
			this.engineLogData.FileName = this.LogFileName;
			this.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.SetEngineLogData(this.engineLogData);
			}, "OnApplyCommand");
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002BDA File Offset: 0x00000DDA
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002BE2 File Offset: 0x00000DE2
		public DelegateCommand OnBrowse { get; private set; }

		// Token: 0x06000049 RID: 73 RVA: 0x00002BEC File Offset: 0x00000DEC
		private void OnBrowseCommand()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Path.GetDirectoryName(this.PersistLogFile);
			openFileDialog.FileName = this.PersistLogFile;
			openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			openFileDialog.CheckFileExists = false;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.PersistLogFile = openFileDialog.FileName;
				this.LogFileName = this.PersistLogFile;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002C63 File Offset: 0x00000E63
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002C6B File Offset: 0x00000E6B
		public DelegateCommand OnViewLogFile { get; private set; }

		// Token: 0x0600004C RID: 76 RVA: 0x00002C74 File Offset: 0x00000E74
		private void OnViewLogFileCommand()
		{
			LogMenuViewModel.<OnViewLogFileCommand>d__101 <OnViewLogFileCommand>d__;
			<OnViewLogFileCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnViewLogFileCommand>d__.<>4__this = this;
			<OnViewLogFileCommand>d__.<>1__state = -1;
			<OnViewLogFileCommand>d__.<>t__builder.Start<LogMenuViewModel.<OnViewLogFileCommand>d__101>(ref <OnViewLogFileCommand>d__);
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002CAB File Offset: 0x00000EAB
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002CB3 File Offset: 0x00000EB3
		public DelegateCommand OnApplyExit { get; private set; }

		// Token: 0x0600004F RID: 79 RVA: 0x00002CBC File Offset: 0x00000EBC
		private void OnApplyExitCommand()
		{
			this.OnApplyCommand();
			this.OnCancelCommand();
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002CDA File Offset: 0x00000EDA
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002CE2 File Offset: 0x00000EE2
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000052 RID: 82 RVA: 0x00002CEB File Offset: 0x00000EEB
		private void OnCancelCommand()
		{
			this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(false);
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002D0E File Offset: 0x00000F0E
		private void SetBoolFromFlag(ref bool b, uint dwFlags, uint dwBit)
		{
			b = ((dwFlags & dwBit) > 0U);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002D18 File Offset: 0x00000F18
		private void SetFlagFromBool(bool b, ref uint dwFlags, uint dwBit)
		{
			if (b)
			{
				dwFlags |= dwBit;
				return;
			}
			dwFlags &= ~dwBit;
		}

		// Token: 0x04000024 RID: 36
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000025 RID: 37
		private readonly IPCmoverEngine pcmoverEngine;

		// Token: 0x04000026 RID: 38
		private readonly IUnityContainer container;

		// Token: 0x04000028 RID: 40
		private string PersistLogFile;

		// Token: 0x04000029 RID: 41
		private EngineLogData engineLogData;

		// Token: 0x0400002A RID: 42
		private bool _DetailErrors;

		// Token: 0x0400002B RID: 43
		private bool _DetailStatus;

		// Token: 0x0400002C RID: 44
		private bool _DetailVerbose;

		// Token: 0x0400002D RID: 45
		private string _LogFileName;

		// Token: 0x0400002E RID: 46
		private bool _MethodFile;

		// Token: 0x0400002F RID: 47
		private bool _MethodCsv;

		// Token: 0x04000030 RID: 48
		private bool _MethodPopup;

		// Token: 0x04000031 RID: 49
		private bool _MethodThread;

		// Token: 0x04000032 RID: 50
		private bool _WhatBuild;

		// Token: 0x04000033 RID: 51
		private bool _WhatNetwork;

		// Token: 0x04000034 RID: 52
		private bool _WhatStartup;

		// Token: 0x04000035 RID: 53
		private bool _WhatUnload;

		// Token: 0x04000036 RID: 54
		private bool _WhatFill;

		// Token: 0x04000037 RID: 55
		private bool _WhatSnapshot;

		// Token: 0x04000038 RID: 56
		private bool _WhatProgress;

		// Token: 0x04000039 RID: 57
		private bool _WhatUsers;

		// Token: 0x0400003A RID: 58
		private bool _WhatApps;

		// Token: 0x0400003B RID: 59
		private bool _WhatWizard;

		// Token: 0x0400003C RID: 60
		private bool _WhatThread;
	}
}
