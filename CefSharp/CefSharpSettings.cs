using System;

namespace CefSharp
{
	// Token: 0x0200001C RID: 28
	public static class CefSharpSettings
	{
		// Token: 0x06000074 RID: 116 RVA: 0x0000280B File Offset: 0x00000A0B
		static CefSharpSettings()
		{
			CefSharpSettings.WcfTimeout = TimeSpan.FromSeconds(2.0);
			CefSharpSettings.SubprocessExitIfParentProcessClosed = true;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000282C File Offset: 0x00000A2C
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002833 File Offset: 0x00000A33
		public static bool WcfEnabled { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000283B File Offset: 0x00000A3B
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002842 File Offset: 0x00000A42
		public static TimeSpan WcfTimeout { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000284A File Offset: 0x00000A4A
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002851 File Offset: 0x00000A51
		public static bool ShutdownOnExit { get; set; } = true;

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002859 File Offset: 0x00000A59
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002860 File Offset: 0x00000A60
		public static bool SubprocessExitIfParentProcessClosed { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002868 File Offset: 0x00000A68
		// (set) Token: 0x0600007E RID: 126 RVA: 0x0000286F File Offset: 0x00000A6F
		public static ProxyOptions Proxy { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002877 File Offset: 0x00000A77
		// (set) Token: 0x06000080 RID: 128 RVA: 0x0000287E File Offset: 0x00000A7E
		public static bool ConcurrentTaskExecution { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002886 File Offset: 0x00000A86
		// (set) Token: 0x06000082 RID: 130 RVA: 0x0000288D File Offset: 0x00000A8D
		public static bool FocusedNodeChangedEnabled { get; set; }
	}
}
