using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using Prism.Events;

namespace PCmover.Infrastructure
{
	// Token: 0x02000016 RID: 22
	public class EngineEvents
	{
		// Token: 0x02000078 RID: 120
		public class ConnectableMachineStatusEvent : PubSubEvent<ConnectableMachine>
		{
		}

		// Token: 0x02000079 RID: 121
		public class SetDirectionEvent : PubSubEvent<ConnectableMachine>
		{
		}

		// Token: 0x0200007A RID: 122
		public class CreateFillTaskEvent : PubSubEvent<FillTaskData>
		{
		}

		// Token: 0x0200007B RID: 123
		public class ReadyForCustomizationEvent : PubSubEvent
		{
		}

		// Token: 0x0200007C RID: 124
		public class AnalyzeComputerEvent : PubSubEvent<TaskStats>
		{
		}

		// Token: 0x0200007D RID: 125
		public class TransferComplete : PubSubEvent<TransferCompleteInfo>
		{
		}

		// Token: 0x0200007E RID: 126
		public class ReportsGenerated : PubSubEvent<string>
		{
		}

		// Token: 0x0200007F RID: 127
		public class ThisMachineAppInventoryProgressChanged : PubSubEvent<ProgressInfo>
		{
		}

		// Token: 0x02000080 RID: 128
		public class ImageAppInventoryProgressChanged : PubSubEvent<ProgressInfo>
		{
		}

		// Token: 0x02000081 RID: 129
		public class SnapshotProgressChanged : PubSubEvent<ProgressInfo>
		{
		}

		// Token: 0x02000082 RID: 130
		public class AnalysisProgressChanged : PubSubEvent<ProgressInfo>
		{
		}

		// Token: 0x02000083 RID: 131
		public class TransferProgressChanged : PubSubEvent<TransferProgressInfo>
		{
		}

		// Token: 0x02000084 RID: 132
		public class ListenProgressChanged : PubSubEvent<ProgressInfo>
		{
		}

		// Token: 0x02000085 RID: 133
		public class ActivityInfoChanged : PubSubEvent<ActivityInfo>
		{
		}

		// Token: 0x02000086 RID: 134
		public class ConfirmUserMatches : PubSubEvent<Action>
		{
		}

		// Token: 0x02000087 RID: 135
		public class DisplayDriveMap : PubSubEvent<Action>
		{
		}

		// Token: 0x02000088 RID: 136
		public class DisplayAppSelection : PubSubEvent<Action>
		{
		}

		// Token: 0x02000089 RID: 137
		public class AssignMissingPassword : PubSubEvent<Events.MissingPasswordEventArgs>
		{
		}

		// Token: 0x0200008A RID: 138
		public class PromptForVanPassword : PubSubEvent<Events.PasswordEventArgs>
		{
		}

		// Token: 0x0200008B RID: 139
		public class ServiceStateChanged : PubSubEvent<PcmoverState>
		{
		}

		// Token: 0x0200008C RID: 140
		public class AuthorizationError : PubSubEvent<Events.AuthorizationErrorEventArgs>
		{
		}

		// Token: 0x0200008D RID: 141
		public class CommunicationExceptionEvent : PubSubEvent<Exception>
		{
		}

		// Token: 0x0200008E RID: 142
		public class ShowOfficeTrialPopupEvent : PubSubEvent<IEnumerable<ApplicationData>>
		{
		}

		// Token: 0x0200008F RID: 143
		public class ProxyCredentialsData
		{
			// Token: 0x170001FA RID: 506
			// (get) Token: 0x06000501 RID: 1281 RVA: 0x0000D2B2 File Offset: 0x0000B4B2
			// (set) Token: 0x06000502 RID: 1282 RVA: 0x0000D2BA File Offset: 0x0000B4BA
			public string ProxyServer { get; set; }

			// Token: 0x170001FB RID: 507
			// (get) Token: 0x06000503 RID: 1283 RVA: 0x0000D2C3 File Offset: 0x0000B4C3
			// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000D2CB File Offset: 0x0000B4CB
			public int ReplyHandle { get; set; }

			// Token: 0x170001FC RID: 508
			// (get) Token: 0x06000505 RID: 1285 RVA: 0x0000D2D4 File Offset: 0x0000B4D4
			// (set) Token: 0x06000506 RID: 1286 RVA: 0x0000D2DC File Offset: 0x0000B4DC
			public TaskCompletionSource<bool> Tcs { get; set; }
		}

		// Token: 0x02000090 RID: 144
		public class ShowProxyCredentialsPopupEvent : PubSubEvent<EngineEvents.ProxyCredentialsData>
		{
		}
	}
}
