using System;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace PCmover.Infrastructure
{
	// Token: 0x02000018 RID: 24
	public class Events
	{
		// Token: 0x020000B5 RID: 181
		public class UpdateTitle : PubSubEvent<string>
		{
		}

		// Token: 0x020000B6 RID: 182
		public class UpdateProgramTitle : PubSubEvent<string>
		{
		}

		// Token: 0x020000B7 RID: 183
		public class IsLatestVersionEvent : PubSubEvent<VersionInfo>
		{
		}

		// Token: 0x020000B8 RID: 184
		public enum TransferStateEnum
		{
			// Token: 0x040002AE RID: 686
			Unknown,
			// Token: 0x040002AF RID: 687
			CanceledEngineRunning,
			// Token: 0x040002B0 RID: 688
			CanceledEngineTerminated,
			// Token: 0x040002B1 RID: 689
			CompleteSuccess,
			// Token: 0x040002B2 RID: 690
			CompleteFailure
		}

		// Token: 0x020000B9 RID: 185
		public class ChangedCustomSelection : PubSubEvent<MigrationItemsOption>
		{
		}

		// Token: 0x020000BA RID: 186
		public class ChangedOptionSelections : PubSubEvent<MigrationTypeOption>
		{
		}

		// Token: 0x020000BB RID: 187
		public class MigrationDefinitionChange : PubSubEvent<bool>
		{
		}

		// Token: 0x020000BC RID: 188
		public class ConnectionReceived : PubSubEvent<ConnectionReceivedInfo>
		{
		}

		// Token: 0x020000BD RID: 189
		public class SetQuickstepPage : PubSubEvent<QuickstepPage>
		{
		}

		// Token: 0x020000BE RID: 190
		public class EngineChanged : PubSubEvent
		{
		}

		// Token: 0x020000BF RID: 191
		public class BlackoutWindow : PubSubEvent<bool>
		{
		}

		// Token: 0x020000C0 RID: 192
		public class ThisPcChanged : PubSubEvent<string>
		{
		}

		// Token: 0x020000C1 RID: 193
		public class OtherPcChanged : PubSubEvent<string>
		{
		}

		// Token: 0x020000C2 RID: 194
		public class CloseConfirmationRequiredChanged : PubSubEvent<bool>
		{
		}

		// Token: 0x020000C3 RID: 195
		public class CloseConfirmationPromptChanged : PubSubEvent<string>
		{
		}

		// Token: 0x020000C4 RID: 196
		public class PreviousInstanceShuttingDown : PubSubEvent
		{
		}

		// Token: 0x020000C5 RID: 197
		public class CloseOverlayPopup : PubSubEvent
		{
		}

		// Token: 0x020000C6 RID: 198
		public class ShowOverlayPopup : PubSubEvent<Events.OverlayPopupArgs>
		{
		}

		// Token: 0x020000C7 RID: 199
		public class OverlayPopupArgs
		{
			// Token: 0x17000290 RID: 656
			// (get) Token: 0x0600067D RID: 1661 RVA: 0x0000E7A8 File Offset: 0x0000C9A8
			// (set) Token: 0x0600067E RID: 1662 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
			public string Title { get; set; }

			// Token: 0x17000291 RID: 657
			// (get) Token: 0x0600067F RID: 1663 RVA: 0x0000E7B9 File Offset: 0x0000C9B9
			// (set) Token: 0x06000680 RID: 1664 RVA: 0x0000E7C1 File Offset: 0x0000C9C1
			public string ContentRegion { get; set; }

			// Token: 0x17000292 RID: 658
			// (get) Token: 0x06000681 RID: 1665 RVA: 0x0000E7CA File Offset: 0x0000C9CA
			// (set) Token: 0x06000682 RID: 1666 RVA: 0x0000E7D2 File Offset: 0x0000C9D2
			public object Parameter { get; set; }

			// Token: 0x17000293 RID: 659
			// (get) Token: 0x06000683 RID: 1667 RVA: 0x0000E7DB File Offset: 0x0000C9DB
			// (set) Token: 0x06000684 RID: 1668 RVA: 0x0000E7E3 File Offset: 0x0000C9E3
			public Action<object> PopupResultCallback { get; set; }

			// Token: 0x17000294 RID: 660
			// (get) Token: 0x06000685 RID: 1669 RVA: 0x0000E7EC File Offset: 0x0000C9EC
			// (set) Token: 0x06000686 RID: 1670 RVA: 0x0000E7F4 File Offset: 0x0000C9F4
			public Action ClosePopupCallback { get; set; }
		}

		// Token: 0x020000C8 RID: 200
		public class OverlayPopupResolveArgs
		{
			// Token: 0x17000295 RID: 661
			// (get) Token: 0x06000688 RID: 1672 RVA: 0x0000E7FD File Offset: 0x0000C9FD
			// (set) Token: 0x06000689 RID: 1673 RVA: 0x0000E805 File Offset: 0x0000CA05
			public string Title { get; set; }

			// Token: 0x17000296 RID: 662
			// (get) Token: 0x0600068A RID: 1674 RVA: 0x0000E80E File Offset: 0x0000CA0E
			// (set) Token: 0x0600068B RID: 1675 RVA: 0x0000E816 File Offset: 0x0000CA16
			public Type Type { get; set; }

			// Token: 0x17000297 RID: 663
			// (get) Token: 0x0600068C RID: 1676 RVA: 0x0000E81F File Offset: 0x0000CA1F
			// (set) Token: 0x0600068D RID: 1677 RVA: 0x0000E827 File Offset: 0x0000CA27
			public object Parameter { get; set; }

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x0600068E RID: 1678 RVA: 0x0000E830 File Offset: 0x0000CA30
			// (set) Token: 0x0600068F RID: 1679 RVA: 0x0000E838 File Offset: 0x0000CA38
			public Action<object> PopupResultCallback { get; set; }

			// Token: 0x17000299 RID: 665
			// (get) Token: 0x06000690 RID: 1680 RVA: 0x0000E841 File Offset: 0x0000CA41
			// (set) Token: 0x06000691 RID: 1681 RVA: 0x0000E849 File Offset: 0x0000CA49
			public Action ClosePopupCallback { get; set; }

			// Token: 0x1700029A RID: 666
			// (get) Token: 0x06000692 RID: 1682 RVA: 0x0000E852 File Offset: 0x0000CA52
			// (set) Token: 0x06000693 RID: 1683 RVA: 0x0000E85A File Offset: 0x0000CA5A
			public bool UseOverlay { get; set; }

			// Token: 0x06000694 RID: 1684 RVA: 0x0000E863 File Offset: 0x0000CA63
			public PopupEvents.ResolveInfo GetResolveInfo(Type t)
			{
				return new PopupEvents.ResolveInfo(t, new ParameterOverride("overlayArgs", this));
			}
		}

		// Token: 0x020000C9 RID: 201
		public class ShutdownEventArgs
		{
			// Token: 0x1700029B RID: 667
			// (get) Token: 0x06000696 RID: 1686 RVA: 0x0000E876 File Offset: 0x0000CA76
			// (set) Token: 0x06000697 RID: 1687 RVA: 0x0000E87E File Offset: 0x0000CA7E
			public Events.TransferStateEnum TransferState { get; set; }

			// Token: 0x1700029C RID: 668
			// (get) Token: 0x06000698 RID: 1688 RVA: 0x0000E887 File Offset: 0x0000CA87
			// (set) Token: 0x06000699 RID: 1689 RVA: 0x0000E88F File Offset: 0x0000CA8F
			public bool TerminateService { get; set; }

			// Token: 0x0600069A RID: 1690 RVA: 0x0000E898 File Offset: 0x0000CA98
			public ShutdownEventArgs(Events.TransferStateEnum state)
			{
				this.TransferState = state;
				this.TerminateService = (state != Events.TransferStateEnum.CanceledEngineRunning);
			}
		}

		// Token: 0x020000CA RID: 202
		public class ShowOverlayPopupResolve : PubSubEvent<Events.OverlayPopupResolveArgs>
		{
		}

		// Token: 0x020000CB RID: 203
		public class ShutdownEvent : PubSubEvent
		{
		}

		// Token: 0x020000CC RID: 204
		public class ProcessShutdownRequest : PubSubEvent<Events.ShutdownEventArgs>
		{
		}

		// Token: 0x020000CD RID: 205
		public class ReverseConnectionArgs
		{
			// Token: 0x1700029D RID: 669
			// (get) Token: 0x0600069E RID: 1694 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
			// (set) Token: 0x0600069F RID: 1695 RVA: 0x0000E8CC File Offset: 0x0000CACC
			public ConnectableMachine machine { get; set; }

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0000E8D5 File Offset: 0x0000CAD5
			// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0000E8DD File Offset: 0x0000CADD
			public bool SetDirection { get; set; }

			// Token: 0x1700029F RID: 671
			// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0000E8E6 File Offset: 0x0000CAE6
			// (set) Token: 0x060006A3 RID: 1699 RVA: 0x0000E8EE File Offset: 0x0000CAEE
			public bool UseSSL { get; set; }
		}

		// Token: 0x020000CE RID: 206
		public class RequestReverseConnection : PubSubEvent<Events.ReverseConnectionArgs>
		{
		}

		// Token: 0x020000CF RID: 207
		public class ShowSSLIcon : PubSubEvent<bool>
		{
		}

		// Token: 0x020000D0 RID: 208
		public class SSLInfoChanged : PubSubEvent
		{
		}

		// Token: 0x020000D1 RID: 209
		public class EngineInitializedEvent : PubSubEvent<PcmoverServiceData>
		{
		}

		// Token: 0x020000D2 RID: 210
		public class EngineReinitializedEvent : PubSubEvent<PcmoverServiceData>
		{
		}

		// Token: 0x020000D3 RID: 211
		public class ThisMachineAppInventoryCompleteEvent : PubSubEvent
		{
		}

		// Token: 0x020000D4 RID: 212
		public class InSectionPage : PubSubEvent<bool>
		{
		}

		// Token: 0x020000D5 RID: 213
		public class CustomizationSettingChanged : PubSubEvent
		{
		}

		// Token: 0x020000D6 RID: 214
		public class CheckUserModeRestrictions : PubSubEvent
		{
		}

		// Token: 0x020000D7 RID: 215
		public class CompactUserSelected : PubSubEvent
		{
		}

		// Token: 0x020000D8 RID: 216
		public class CompactUserMappingComplete : PubSubEvent<bool>
		{
		}

		// Token: 0x020000D9 RID: 217
		public class FileBasedParameters
		{
			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0000E907 File Offset: 0x0000CB07
			// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0000E90F File Offset: 0x0000CB0F
			public string TransferFile { get; set; }

			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0000E918 File Offset: 0x0000CB18
			// (set) Token: 0x060006B3 RID: 1715 RVA: 0x0000E920 File Offset: 0x0000CB20
			public bool SaveVan { get; set; }

			// Token: 0x170002A2 RID: 674
			// (get) Token: 0x060006B4 RID: 1716 RVA: 0x0000E929 File Offset: 0x0000CB29
			// (set) Token: 0x060006B5 RID: 1717 RVA: 0x0000E931 File Offset: 0x0000CB31
			public bool IsOld { get; set; }

			// Token: 0x170002A3 RID: 675
			// (get) Token: 0x060006B6 RID: 1718 RVA: 0x0000E93A File Offset: 0x0000CB3A
			// (set) Token: 0x060006B7 RID: 1719 RVA: 0x0000E942 File Offset: 0x0000CB42
			public bool BuildChangelistsRequired { get; set; }
		}

		// Token: 0x020000DA RID: 218
		public class MissingPasswordEventArgs
		{
			// Token: 0x170002A4 RID: 676
			// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0000E94B File Offset: 0x0000CB4B
			// (set) Token: 0x060006BA RID: 1722 RVA: 0x0000E953 File Offset: 0x0000CB53
			public Action ResumeAction { get; set; }

			// Token: 0x170002A5 RID: 677
			// (get) Token: 0x060006BB RID: 1723 RVA: 0x0000E95C File Offset: 0x0000CB5C
			// (set) Token: 0x060006BC RID: 1724 RVA: 0x0000E964 File Offset: 0x0000CB64
			public UserDetail User { get; set; }
		}

		// Token: 0x020000DB RID: 219
		public class AuthorizationErrorEventArgs
		{
			// Token: 0x170002A6 RID: 678
			// (get) Token: 0x060006BE RID: 1726 RVA: 0x0000E96D File Offset: 0x0000CB6D
			// (set) Token: 0x060006BF RID: 1727 RVA: 0x0000E975 File Offset: 0x0000CB75
			public Action<bool> ResumeAction { get; set; }

			// Token: 0x170002A7 RID: 679
			// (get) Token: 0x060006C0 RID: 1728 RVA: 0x0000E97E File Offset: 0x0000CB7E
			// (set) Token: 0x060006C1 RID: 1729 RVA: 0x0000E986 File Offset: 0x0000CB86
			public ValidationResult Result { get; set; }
		}

		// Token: 0x020000DC RID: 220
		public class PasswordEventArgs
		{
			// Token: 0x170002A8 RID: 680
			// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0000E98F File Offset: 0x0000CB8F
			// (set) Token: 0x060006C4 RID: 1732 RVA: 0x0000E997 File Offset: 0x0000CB97
			public Action ResumeAction { get; set; }

			// Token: 0x170002A9 RID: 681
			// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
			// (set) Token: 0x060006C6 RID: 1734 RVA: 0x0000E9A8 File Offset: 0x0000CBA8
			public string Password { get; set; }

			// Token: 0x170002AA RID: 682
			// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0000E9B1 File Offset: 0x0000CBB1
			// (set) Token: 0x060006C8 RID: 1736 RVA: 0x0000E9B9 File Offset: 0x0000CBB9
			public bool Canceled { get; set; }
		}

		// Token: 0x020000DD RID: 221
		public class ProxyEventArgs
		{
			// Token: 0x170002AB RID: 683
			// (get) Token: 0x060006CA RID: 1738 RVA: 0x0000E9C2 File Offset: 0x0000CBC2
			// (set) Token: 0x060006CB RID: 1739 RVA: 0x0000E9CA File Offset: 0x0000CBCA
			public Action ResumeAction { get; set; }

			// Token: 0x170002AC RID: 684
			// (get) Token: 0x060006CC RID: 1740 RVA: 0x0000E9D3 File Offset: 0x0000CBD3
			// (set) Token: 0x060006CD RID: 1741 RVA: 0x0000E9DB File Offset: 0x0000CBDB
			public string ProxyServer { get; set; }

			// Token: 0x170002AD RID: 685
			// (get) Token: 0x060006CE RID: 1742 RVA: 0x0000E9E4 File Offset: 0x0000CBE4
			// (set) Token: 0x060006CF RID: 1743 RVA: 0x0000E9EC File Offset: 0x0000CBEC
			public string ProxyUsername { get; set; }

			// Token: 0x170002AE RID: 686
			// (get) Token: 0x060006D0 RID: 1744 RVA: 0x0000E9F5 File Offset: 0x0000CBF5
			// (set) Token: 0x060006D1 RID: 1745 RVA: 0x0000E9FD File Offset: 0x0000CBFD
			public string ProxyPassword { get; set; }
		}

		// Token: 0x020000DE RID: 222
		public class PolicyChangeSimMode : PubSubEvent<bool>
		{
		}

		// Token: 0x020000DF RID: 223
		public class NoLocalEvent : PubSubEvent
		{
		}

		// Token: 0x020000E0 RID: 224
		public class PolicyInitialized : PubSubEvent<DefaultPolicy>
		{
		}

		// Token: 0x020000E1 RID: 225
		public class TransferStateChanged : PubSubEvent<Events.TransferStateEnum>
		{
		}

		// Token: 0x020000E2 RID: 226
		public class MachineDisappeared : PubSubEvent<string>
		{
		}
	}
}
