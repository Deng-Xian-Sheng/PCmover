using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;

namespace WizardModule.Migration
{
	// Token: 0x020000B9 RID: 185
	public interface IMigrationDefinition
	{
		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06000F91 RID: 3985
		// (set) Token: 0x06000F92 RID: 3986
		string PCName1 { get; set; }

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06000F93 RID: 3987
		// (set) Token: 0x06000F94 RID: 3988
		bool IsPCName1Old { get; set; }

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06000F95 RID: 3989
		// (set) Token: 0x06000F96 RID: 3990
		string PCName2 { get; set; }

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06000F97 RID: 3991
		// (set) Token: 0x06000F98 RID: 3992
		string NetworkName { get; set; }

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06000F99 RID: 3993
		// (set) Token: 0x06000F9A RID: 3994
		bool ShowReports { get; set; }

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06000F9B RID: 3995
		// (set) Token: 0x06000F9C RID: 3996
		bool SimulateOtherComputerNotFound { get; set; }

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06000F9D RID: 3997
		// (set) Token: 0x06000F9E RID: 3998
		bool SimulateComputerNotOnInternet { get; set; }

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06000F9F RID: 3999
		// (set) Token: 0x06000FA0 RID: 4000
		ObservableCollection<ConnectableMachine> UIConnectableMachines { get; set; }

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06000FA1 RID: 4001
		// (set) Token: 0x06000FA2 RID: 4002
		ImageMapData ImageAssistData { get; set; }

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06000FA3 RID: 4003
		// (set) Token: 0x06000FA4 RID: 4004
		Events.FileBasedParameters FilesBasedParameters { get; set; }

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06000FA5 RID: 4005
		// (set) Token: 0x06000FA6 RID: 4006
		bool IsUserMappingSaved { get; set; }

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06000FA7 RID: 4007
		// (set) Token: 0x06000FA8 RID: 4008
		bool IsRedirectionSaved { get; set; }

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06000FA9 RID: 4009
		// (set) Token: 0x06000FAA RID: 4010
		TransferMethodType MigrationType { get; set; }

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x06000FAB RID: 4011
		// (set) Token: 0x06000FAC RID: 4012
		CustomizationAffects DirtyCustomizationItems { get; set; }

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06000FAD RID: 4013
		// (set) Token: 0x06000FAE RID: 4014
		TimeSpan EstimatedTransferTime { get; set; }

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06000FAF RID: 4015
		// (set) Token: 0x06000FB0 RID: 4016
		TimeSpan TotalElapsedTransferTime { get; set; }

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06000FB1 RID: 4017
		// (set) Token: 0x06000FB2 RID: 4018
		bool BuildChangelistsRequired { get; set; }

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06000FB3 RID: 4019
		// (set) Token: 0x06000FB4 RID: 4020
		bool LaunchDownloadManager { get; set; }

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06000FB5 RID: 4021
		// (set) Token: 0x06000FB6 RID: 4022
		ulong TransferSpeed { get; set; }

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x06000FB7 RID: 4023
		// (set) Token: 0x06000FB8 RID: 4024
		bool IsSelfTransfer { get; set; }

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x06000FB9 RID: 4025
		// (set) Token: 0x06000FBA RID: 4026
		PcmoverServiceData ServiceData { get; set; }

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x06000FBB RID: 4027
		// (set) Token: 0x06000FBC RID: 4028
		CustomizationScreen CustomizeScreen { get; set; }

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x06000FBD RID: 4029
		// (set) Token: 0x06000FBE RID: 4030
		bool IsResuming { get; set; }

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x06000FBF RID: 4031
		// (set) Token: 0x06000FC0 RID: 4032
		bool IsThunderbolt { get; set; }

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x06000FC1 RID: 4033
		// (set) Token: 0x06000FC2 RID: 4034
		bool IsAuthenticated { get; set; }

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x06000FC3 RID: 4035
		// (set) Token: 0x06000FC4 RID: 4036
		bool UseRecordedPolicy { get; set; }

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x06000FC5 RID: 4037
		// (set) Token: 0x06000FC6 RID: 4038
		bool IsUseRecordedPolicySet { get; set; }
	}
}
