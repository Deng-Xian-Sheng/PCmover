using System;
using System.Globalization;
using Prism.Properties;

namespace Prism.Logging
{
	// Token: 0x02000009 RID: 9
	public class DebugLogger : ILoggerFacade
	{
		// Token: 0x06000032 RID: 50 RVA: 0x000025F0 File Offset: 0x000007F0
		public void Log(string message, Category category, Priority priority)
		{
			string.Format(CultureInfo.InvariantCulture, Resources.DefaultDebugLoggerPattern, new object[]
			{
				DateTime.Now,
				category.ToString().ToUpper(),
				message,
				priority
			});
		}
	}
}
