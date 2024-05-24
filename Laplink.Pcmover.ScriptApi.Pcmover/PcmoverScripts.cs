using System;

namespace Laplink.Pcmover.ScriptApi.Pcmover
{
	// Token: 0x02000003 RID: 3
	public static class PcmoverScripts
	{
		// Token: 0x04000004 RID: 4
		public static string IncludeFiles = "include(\"PcmoverBase.cscs\");";

		// Token: 0x04000005 RID: 5
		public static string InitPcmover = "SimpleInitPcmover();";

		// Token: 0x04000006 RID: 6
		public static string GetConnectionStatus = "GetConnectionStatus();";

		// Token: 0x04000007 RID: 7
		public static string StartCollectingEvents = "pcmover.StartCollectingEvents();";

		// Token: 0x04000008 RID: 8
		public static string GetPendingEvents = "pcmover.GetPendingEvents();";

		// Token: 0x04000009 RID: 9
		public static string BecomeControllerAndInit = "BecomeControllerAndInit();";

		// Token: 0x0400000A RID: 10
		public static string CurrentStatus = "currentStatus;";
	}
}
