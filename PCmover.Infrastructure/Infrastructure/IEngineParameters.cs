using System;
using System.ServiceModel;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace PCmover.Infrastructure
{
	// Token: 0x02000027 RID: 39
	public interface IEngineParameters
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060001CB RID: 459
		// (set) Token: 0x060001CC RID: 460
		AuthorizationRequestData AuthInfo { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060001CD RID: 461
		// (set) Token: 0x060001CE RID: 462
		string ConnectionId { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060001CF RID: 463
		IConnectToService ConnectToService { get; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060001D0 RID: 464
		string DeferredVan { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060001D1 RID: 465
		bool LaunchDownloadManager { get; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060001D2 RID: 466
		// (set) Token: 0x060001D3 RID: 467
		EndpointAddress PcmoverServiceAddress { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060001D4 RID: 468
		EnvLookup ServiceEnvironment { get; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060001D5 RID: 469
		// (set) Token: 0x060001D6 RID: 470
		bool? SingleMachineMode { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060001D7 RID: 471
		// (set) Token: 0x060001D8 RID: 472
		string Source { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060001D9 RID: 473
		string HostName { get; }
	}
}
