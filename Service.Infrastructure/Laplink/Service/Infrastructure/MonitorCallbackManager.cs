using System;
using System.Collections.Generic;
using System.Linq;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000009 RID: 9
	public class MonitorCallbackManager<T>
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002E30 File Offset: 0x00001030
		protected List<MonitorCallback<T>> MonitorCallbacks { get; } = new List<MonitorCallback<T>>();

		// Token: 0x06000054 RID: 84 RVA: 0x00002E38 File Offset: 0x00001038
		public MonitorCallbackManager(LlTraceSource ts)
		{
			this._ts = ts;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002E54 File Offset: 0x00001054
		public void Configure(CallbackState callbackState, string sessionId, T callback)
		{
			List<MonitorCallback<T>> monitorCallbacks = this.MonitorCallbacks;
			lock (monitorCallbacks)
			{
				MonitorCallback<T> monitorCallback = this.MonitorCallbacks.Find((MonitorCallback<T> cb) => cb.Key == sessionId);
				if (monitorCallback != null)
				{
					if (callbackState == CallbackState.Inactive)
					{
						this._ts.TraceCaller("Removing monitor of " + sessionId, "Configure");
						this.MonitorCallbacks.Remove(monitorCallback);
					}
					else
					{
						this._ts.TraceCaller(string.Format("Changing monitor of {0} to {1}", sessionId, callbackState), "Configure");
						monitorCallback.State = callbackState;
					}
				}
				else if (callbackState != CallbackState.Inactive)
				{
					this._ts.TraceCaller(string.Format("Adding monitor of {0} as {1}", sessionId, callbackState), "Configure");
					this.MonitorCallbacks.Add(new MonitorCallback<T>(sessionId, callback, callbackState, this._ts));
				}
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002F64 File Offset: 0x00001164
		public void Call(Action<T> func, bool isProgress = false)
		{
			List<MonitorCallback<T>> list = null;
			List<MonitorCallback<T>> monitorCallbacks = this.MonitorCallbacks;
			lock (monitorCallbacks)
			{
				list = this.MonitorCallbacks.ToList<MonitorCallback<T>>();
			}
			foreach (MonitorCallback<T> monitorCallback in list)
			{
				monitorCallback.Call(func, isProgress);
			}
			foreach (MonitorCallback<T> monitorCallback2 in (from cb in list
			where cb.State == CallbackState.Inactive
			select cb).ToList<MonitorCallback<T>>())
			{
				this._ts.TraceCaller("Removing inactive callback " + monitorCallback2.Key, "Call");
				monitorCallbacks = this.MonitorCallbacks;
				lock (monitorCallbacks)
				{
					this.MonitorCallbacks.Remove(monitorCallback2);
				}
			}
		}

		// Token: 0x0400001D RID: 29
		private readonly LlTraceSource _ts;
	}
}
