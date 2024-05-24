using System;

namespace CefSharp
{
	// Token: 0x02000045 RID: 69
	public class ConsoleMessageEventArgs : EventArgs
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00003281 File Offset: 0x00001481
		public ConsoleMessageEventArgs(IBrowser browser, LogSeverity level, string message, string source, int line)
		{
			this.Browser = browser;
			this.Level = level;
			this.Message = message;
			this.Source = source;
			this.Line = line;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x000032AE File Offset: 0x000014AE
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x000032B6 File Offset: 0x000014B6
		public IBrowser Browser { get; private set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x000032BF File Offset: 0x000014BF
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x000032C7 File Offset: 0x000014C7
		public LogSeverity Level { get; private set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000032D0 File Offset: 0x000014D0
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000032D8 File Offset: 0x000014D8
		public string Message { get; private set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000032E1 File Offset: 0x000014E1
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000032E9 File Offset: 0x000014E9
		public string Source { get; private set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000032F2 File Offset: 0x000014F2
		// (set) Token: 0x060000EC RID: 236 RVA: 0x000032FA File Offset: 0x000014FA
		public int Line { get; private set; }
	}
}
