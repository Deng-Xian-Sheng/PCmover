using System;
using System.Security.Permissions;

namespace System.Diagnostics
{
	// Token: 0x020003F1 RID: 1009
	// (Invoke) Token: 0x0600332D RID: 13101
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	[Serializable]
	internal delegate void LogMessageEventHandler(LoggingLevels level, LogSwitch category, string message, StackTrace location);
}
