using System;
using System.Collections.Generic;
using System.Threading;

namespace CefSharp.DevTools
{
	// Token: 0x02000124 RID: 292
	internal struct DevToolsMethodResponseContext
	{
		// Token: 0x06000885 RID: 2181 RVA: 0x0000DB6B File Offset: 0x0000BD6B
		public DevToolsMethodResponseContext(Type type, Func<object, bool> setResult, Func<Exception, bool> setException, SynchronizationContext syncContext)
		{
			this.Type = type;
			this.setResult = setResult;
			this.setException = setException;
			this.syncContext = syncContext;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0000DB8A File Offset: 0x0000BD8A
		public void SetResult(object result)
		{
			this.InvokeOnSyncContext<object>(this.setResult, result);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0000DB99 File Offset: 0x0000BD99
		public void SetException(Exception ex)
		{
			this.InvokeOnSyncContext<Exception>(this.setException, ex);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x0000DBA8 File Offset: 0x0000BDA8
		private void InvokeOnSyncContext<T>(Func<T, bool> fn, T value)
		{
			if (this.syncContext == null || this.syncContext == SynchronizationContext.Current)
			{
				fn(value);
				return;
			}
			this.syncContext.Post(delegate(object state)
			{
				KeyValuePair<Func<T, bool>, T> keyValuePair = (KeyValuePair<Func<T, bool>, T>)state;
				keyValuePair.Key(keyValuePair.Value);
			}, new KeyValuePair<Func<T, bool>, T>(fn, value));
		}

		// Token: 0x0400048E RID: 1166
		public readonly Type Type;

		// Token: 0x0400048F RID: 1167
		private readonly Func<object, bool> setResult;

		// Token: 0x04000490 RID: 1168
		private readonly Func<Exception, bool> setException;

		// Token: 0x04000491 RID: 1169
		private readonly SynchronizationContext syncContext;
	}
}
