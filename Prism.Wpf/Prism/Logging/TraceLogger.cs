using System;
using System.Diagnostics;

namespace Prism.Logging
{
	// Token: 0x0200006E RID: 110
	public class TraceLogger : ILoggerFacade
	{
		// Token: 0x0600033E RID: 830 RVA: 0x00008855 File Offset: 0x00006A55
		public void Log(string message, Category category, Priority priority)
		{
			if (category == Category.Exception)
			{
				Trace.TraceError(message);
				return;
			}
			Trace.TraceInformation(message);
		}
	}
}
