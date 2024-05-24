using System;
using System.Globalization;
using System.IO;
using Prism.Properties;

namespace Prism.Logging
{
	// Token: 0x0200006D RID: 109
	public class TextLogger : ILoggerFacade, IDisposable
	{
		// Token: 0x06000339 RID: 825 RVA: 0x00008799 File Offset: 0x00006999
		public TextLogger() : this(Console.Out)
		{
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000087A6 File Offset: 0x000069A6
		public TextLogger(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000087C4 File Offset: 0x000069C4
		public void Log(string message, Category category, Priority priority)
		{
			string value = string.Format(CultureInfo.InvariantCulture, Resources.DefaultTextLoggerPattern, new object[]
			{
				DateTime.Now,
				category.ToString().ToUpper(CultureInfo.InvariantCulture),
				message,
				priority.ToString()
			});
			this.writer.WriteLine(value);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000882E File Offset: 0x00006A2E
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && this.writer != null)
			{
				this.writer.Dispose();
			}
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00008846 File Offset: 0x00006A46
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000097 RID: 151
		private readonly TextWriter writer;
	}
}
