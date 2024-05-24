using System;

namespace CefSharp.DevTools
{
	// Token: 0x02000122 RID: 290
	public class DevToolsEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
		// (set) Token: 0x0600087A RID: 2170 RVA: 0x0000DB00 File Offset: 0x0000BD00
		public string EventName { get; private set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x0000DB09 File Offset: 0x0000BD09
		// (set) Token: 0x0600087C RID: 2172 RVA: 0x0000DB11 File Offset: 0x0000BD11
		public string ParametersAsJsonString { get; private set; }

		// Token: 0x0600087D RID: 2173 RVA: 0x0000DB1A File Offset: 0x0000BD1A
		public DevToolsEventArgs(string eventName, string paramsAsJsonString)
		{
			this.EventName = eventName;
			this.ParametersAsJsonString = paramsAsJsonString;
		}
	}
}
