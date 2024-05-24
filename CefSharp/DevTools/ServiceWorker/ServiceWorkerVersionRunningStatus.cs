using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x0200020D RID: 525
	public enum ServiceWorkerVersionRunningStatus
	{
		// Token: 0x040007AB RID: 1963
		[EnumMember(Value = "stopped")]
		Stopped,
		// Token: 0x040007AC RID: 1964
		[EnumMember(Value = "starting")]
		Starting,
		// Token: 0x040007AD RID: 1965
		[EnumMember(Value = "running")]
		Running,
		// Token: 0x040007AE RID: 1966
		[EnumMember(Value = "stopping")]
		Stopping
	}
}
