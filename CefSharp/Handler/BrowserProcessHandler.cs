using System;

namespace CefSharp.Handler
{
	// Token: 0x020000F8 RID: 248
	public class BrowserProcessHandler : IBrowserProcessHandler, IDisposable
	{
		// Token: 0x06000749 RID: 1865 RVA: 0x0000C176 File Offset: 0x0000A376
		void IBrowserProcessHandler.OnContextInitialized()
		{
			this.OnContextInitialized();
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0000C17E File Offset: 0x0000A37E
		protected virtual void OnContextInitialized()
		{
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0000C180 File Offset: 0x0000A380
		void IBrowserProcessHandler.OnScheduleMessagePumpWork(long delay)
		{
			this.OnScheduleMessagePumpWork(delay);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0000C189 File Offset: 0x0000A389
		protected virtual void OnScheduleMessagePumpWork(long delay)
		{
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0000C18B File Offset: 0x0000A38B
		public bool IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0000C193 File Offset: 0x0000A393
		protected virtual void Dispose(bool disposing)
		{
			this.isDisposed = true;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0000C19C File Offset: 0x0000A39C
		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040003A1 RID: 929
		private bool isDisposed;
	}
}
