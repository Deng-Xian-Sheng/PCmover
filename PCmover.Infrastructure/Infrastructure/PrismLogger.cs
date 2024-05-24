using System;
using Laplink.Tools.Helpers;
using Prism.Logging;

namespace PCmover.Infrastructure
{
	// Token: 0x02000031 RID: 49
	public class PrismLogger : ILoggerFacade
	{
		// Token: 0x060002B5 RID: 693 RVA: 0x00007856 File Offset: 0x00005A56
		public PrismLogger(LlTraceSource ts)
		{
			this._ts = ts;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00007865 File Offset: 0x00005A65
		public void Log(string message, Category category, Priority priority)
		{
			this._ts.TraceInformation(string.Format("Prism {0} {1} {2}", category, priority, message));
		}

		// Token: 0x040000C0 RID: 192
		private LlTraceSource _ts;
	}
}
