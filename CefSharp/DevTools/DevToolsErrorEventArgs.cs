using System;

namespace CefSharp.DevTools
{
	// Token: 0x02000121 RID: 289
	public class DevToolsErrorEventArgs : EventArgs
	{
		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0000DAA8 File Offset: 0x0000BCA8
		// (set) Token: 0x06000873 RID: 2163 RVA: 0x0000DAB0 File Offset: 0x0000BCB0
		public string EventName { get; private set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0000DAB9 File Offset: 0x0000BCB9
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x0000DAC1 File Offset: 0x0000BCC1
		public string Json { get; private set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0000DACA File Offset: 0x0000BCCA
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x0000DAD2 File Offset: 0x0000BCD2
		public Exception Exception { get; private set; }

		// Token: 0x06000878 RID: 2168 RVA: 0x0000DADB File Offset: 0x0000BCDB
		public DevToolsErrorEventArgs(string eventName, string json, Exception ex)
		{
			this.EventName = eventName;
			this.Json = json;
			this.Exception = ex;
		}
	}
}
