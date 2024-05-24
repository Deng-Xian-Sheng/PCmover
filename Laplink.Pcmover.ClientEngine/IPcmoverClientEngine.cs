using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000005 RID: 5
	public interface IPcmoverClientEngine : IPcmoverController
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000030 RID: 48
		LlTraceSource Ts { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000031 RID: 49
		ActivityClients ActivityClients { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000032 RID: 50
		// (set) Token: 0x06000033 RID: 51
		bool IsResuming { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000034 RID: 52
		PcmoverServiceData ServiceData { get; }

		// Token: 0x06000035 RID: 53
		bool CatchCommEx(Action func, [CallerMemberName] string caller = "");

		// Token: 0x06000036 RID: 54
		void FireActivityInfoEvent(ActivityInfo info);

		// Token: 0x06000037 RID: 55
		void OnActivityChanged(ActivityInfo activityInfo, MonitorChangeType change);

		// Token: 0x06000038 RID: 56
		void Progress(ActivityInfo activityInfo, ProgressInfo progressInfo);
	}
}
