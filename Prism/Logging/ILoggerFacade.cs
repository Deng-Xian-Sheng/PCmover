using System;

namespace Prism.Logging
{
	// Token: 0x0200000B RID: 11
	public interface ILoggerFacade
	{
		// Token: 0x06000036 RID: 54
		void Log(string message, Category category, Priority priority);
	}
}
