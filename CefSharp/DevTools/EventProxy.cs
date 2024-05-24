using System;
using System.IO;
using System.Threading;

namespace CefSharp.DevTools
{
	// Token: 0x02000125 RID: 293
	internal class EventProxy<T> : IEventProxy, IDisposable
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000889 RID: 2185 RVA: 0x0000DC0C File Offset: 0x0000BE0C
		// (remove) Token: 0x0600088A RID: 2186 RVA: 0x0000DC44 File Offset: 0x0000BE44
		private event EventHandler<T> handlers;

		// Token: 0x0600088B RID: 2187 RVA: 0x0000DC79 File Offset: 0x0000BE79
		public EventProxy(Func<string, Stream, T> convert)
		{
			this.convert = convert;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0000DC88 File Offset: 0x0000BE88
		public void AddHandler(EventHandler<T> handler)
		{
			this.handlers += handler;
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0000DC91 File Offset: 0x0000BE91
		public bool RemoveHandler(EventHandler<T> handler)
		{
			this.handlers -= handler;
			return this.handlers == null;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0000DCA4 File Offset: 0x0000BEA4
		public void Raise(object sender, string eventName, Stream stream, SynchronizationContext syncContext)
		{
			stream.Position = 0L;
			T args = this.convert(eventName, stream);
			if (syncContext != null)
			{
				syncContext.Post(delegate(object state)
				{
					EventHandler<T> eventHandler2 = this.handlers;
					if (eventHandler2 == null)
					{
						return;
					}
					eventHandler2(sender, args);
				}, null);
				return;
			}
			EventHandler<T> eventHandler = this.handlers;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(sender, args);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0000DD15 File Offset: 0x0000BF15
		public void Dispose()
		{
			this.handlers = null;
		}

		// Token: 0x04000493 RID: 1171
		private Func<string, Stream, T> convert;
	}
}
