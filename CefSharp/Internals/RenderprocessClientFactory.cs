using System;

namespace CefSharp.Internals
{
	// Token: 0x020000E9 RID: 233
	public class RenderprocessClientFactory
	{
		// Token: 0x060006F2 RID: 1778 RVA: 0x0000B604 File Offset: 0x00009804
		public static string GetServiceName(int parentProcessId, int browserId)
		{
			return string.Join("/", new object[]
			{
				"net.pipe://localhost",
				"CefSharpSubProcessProxy",
				parentProcessId,
				browserId
			});
		}

		// Token: 0x0400038C RID: 908
		private const string BaseAddress = "net.pipe://localhost";

		// Token: 0x0400038D RID: 909
		private const string ServiceName = "CefSharpSubProcessProxy";
	}
}
