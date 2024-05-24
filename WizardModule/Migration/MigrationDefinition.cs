using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Events;

namespace WizardModule.Migration
{
	// Token: 0x020000BA RID: 186
	public class MigrationDefinition : IMigrationDefinition
	{
		// Token: 0x06000FC7 RID: 4039 RVA: 0x00028C74 File Offset: 0x00026E74
		public MigrationDefinition(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.PCName1 = "";
			this.PCName2 = "";
			this.IsPCName1Old = true;
			this.NetworkName = "";
			this.ShowReports = false;
			this.SimulateOtherComputerNotFound = false;
			this.SimulateComputerNotOnInternet = false;
			this.UIConnectableMachines = new ObservableCollection<ConnectableMachine>();
		}

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x00028CD6 File Offset: 0x00026ED6
		// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x00028CDE File Offset: 0x00026EDE
		public string PCName1 { get; set; }

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00028CE7 File Offset: 0x00026EE7
		// (set) Token: 0x06000FCB RID: 4043 RVA: 0x00028CEF File Offset: 0x00026EEF
		public string PCName2 { get; set; }

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x00028CF8 File Offset: 0x00026EF8
		// (set) Token: 0x06000FCD RID: 4045 RVA: 0x00028D00 File Offset: 0x00026F00
		public bool IsPCName1Old { get; set; }

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x00028D09 File Offset: 0x00026F09
		// (set) Token: 0x06000FCF RID: 4047 RVA: 0x00028D11 File Offset: 0x00026F11
		public string NetworkName { get; set; }

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x00028D1A File Offset: 0x00026F1A
		// (set) Token: 0x06000FD1 RID: 4049 RVA: 0x00028D22 File Offset: 0x00026F22
		public bool ShowReports { get; set; }

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x00028D2B File Offset: 0x00026F2B
		// (set) Token: 0x06000FD3 RID: 4051 RVA: 0x00028D33 File Offset: 0x00026F33
		public ObservableCollection<ConnectableMachine> UIConnectableMachines { get; set; }

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06000FD4 RID: 4052 RVA: 0x00028D3C File Offset: 0x00026F3C
		// (set) Token: 0x06000FD5 RID: 4053 RVA: 0x00028D44 File Offset: 0x00026F44
		public ImageMapData ImageAssistData { get; set; }

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x00028D4D File Offset: 0x00026F4D
		// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x00028D55 File Offset: 0x00026F55
		public Events.FileBasedParameters FilesBasedParameters { get; set; }

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x00028D5E File Offset: 0x00026F5E
		// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x00028D66 File Offset: 0x00026F66
		public bool IsUserMappingSaved { get; set; }

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x00028D6F File Offset: 0x00026F6F
		// (set) Token: 0x06000FDB RID: 4059 RVA: 0x00028D77 File Offset: 0x00026F77
		public bool IsRedirectionSaved { get; set; }

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x00028D80 File Offset: 0x00026F80
		// (set) Token: 0x06000FDD RID: 4061 RVA: 0x00028D88 File Offset: 0x00026F88
		public TransferMethodType MigrationType { get; set; }

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x06000FDE RID: 4062 RVA: 0x00028D91 File Offset: 0x00026F91
		// (set) Token: 0x06000FDF RID: 4063 RVA: 0x00028D99 File Offset: 0x00026F99
		public CustomizationAffects DirtyCustomizationItems { get; set; }

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x00028DA2 File Offset: 0x00026FA2
		// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x00028DAA File Offset: 0x00026FAA
		public TimeSpan EstimatedTransferTime { get; set; }

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x00028DB3 File Offset: 0x00026FB3
		// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x00028DBB File Offset: 0x00026FBB
		public TimeSpan TotalElapsedTransferTime { get; set; }

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x00028DC4 File Offset: 0x00026FC4
		// (set) Token: 0x06000FE5 RID: 4069 RVA: 0x00028DCC File Offset: 0x00026FCC
		public bool BuildChangelistsRequired { get; set; }

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x00028DD5 File Offset: 0x00026FD5
		// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x00028DDD File Offset: 0x00026FDD
		public bool LaunchDownloadManager { get; set; }

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x00028DE6 File Offset: 0x00026FE6
		// (set) Token: 0x06000FE9 RID: 4073 RVA: 0x00028DEE File Offset: 0x00026FEE
		public ulong TransferSpeed { get; set; }

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06000FEA RID: 4074 RVA: 0x00028DF7 File Offset: 0x00026FF7
		// (set) Token: 0x06000FEB RID: 4075 RVA: 0x00028DFF File Offset: 0x00026FFF
		public bool IsSelfTransfer { get; set; }

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06000FEC RID: 4076 RVA: 0x00028E08 File Offset: 0x00027008
		// (set) Token: 0x06000FED RID: 4077 RVA: 0x00028E10 File Offset: 0x00027010
		public PcmoverServiceData ServiceData { get; set; }

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06000FEE RID: 4078 RVA: 0x00028E19 File Offset: 0x00027019
		// (set) Token: 0x06000FEF RID: 4079 RVA: 0x00028E21 File Offset: 0x00027021
		public CustomizationScreen CustomizeScreen { get; set; }

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x00028E2A File Offset: 0x0002702A
		// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x00028E32 File Offset: 0x00027032
		public bool IsResuming { get; set; }

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x00028E3B File Offset: 0x0002703B
		// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00028E5B File Offset: 0x0002705B
		public bool PromptForBackNavigation
		{
			get
			{
				return Resources.Edition.ToLower().StartsWith("enterprise") && this._PromptForBackNavigation;
			}
			set
			{
				this._PromptForBackNavigation = value;
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x00028E64 File Offset: 0x00027064
		// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x00028E6C File Offset: 0x0002706C
		public bool IsThunderbolt { get; set; }

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x00028E75 File Offset: 0x00027075
		// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x00028E7D File Offset: 0x0002707D
		public bool IsAuthenticated { get; set; }

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x00028E86 File Offset: 0x00027086
		// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x00028E8E File Offset: 0x0002708E
		public bool UseRecordedPolicy { get; set; }

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x00028E97 File Offset: 0x00027097
		// (set) Token: 0x06000FFB RID: 4091 RVA: 0x00028E9F File Offset: 0x0002709F
		public bool IsUseRecordedPolicySet { get; set; }

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00028EA8 File Offset: 0x000270A8
		// (set) Token: 0x06000FFD RID: 4093 RVA: 0x00028EB0 File Offset: 0x000270B0
		public bool SimulateOtherComputerNotFound { get; set; }

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06000FFE RID: 4094 RVA: 0x00028EB9 File Offset: 0x000270B9
		// (set) Token: 0x06000FFF RID: 4095 RVA: 0x00028EC1 File Offset: 0x000270C1
		public bool SimulateComputerNotOnInternet { get; set; }

		// Token: 0x0400054B RID: 1355
		private IEventAggregator eventAggregator;

		// Token: 0x04000561 RID: 1377
		private bool _PromptForBackNavigation;
	}
}
