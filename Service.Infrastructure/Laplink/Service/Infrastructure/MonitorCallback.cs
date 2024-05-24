using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000008 RID: 8
	public class MonitorCallback<T>
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public string Key { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002AD8 File Offset: 0x00000CD8
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002AE0 File Offset: 0x00000CE0
		public CallbackState State
		{
			get
			{
				return this._state;
			}
			set
			{
				bool flag = this._state == CallbackState.Suspended;
				this._state = value;
				if (flag && !this.IsSuspended)
				{
					this.FireDeferredCallbacks();
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002B02 File Offset: 0x00000D02
		public bool IsInactive
		{
			get
			{
				return this.State == CallbackState.Inactive;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002B0D File Offset: 0x00000D0D
		public bool IsSuspended
		{
			get
			{
				return this.State == CallbackState.Suspended;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002B18 File Offset: 0x00000D18
		public bool IsActive
		{
			get
			{
				return this.State == CallbackState.Active;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002B23 File Offset: 0x00000D23
		public MonitorCallback(string key, T callback, CallbackState state, LlTraceSource ts)
		{
			this.Key = key;
			this._callback = callback;
			this._ts = ts;
			this.State = state;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002B53 File Offset: 0x00000D53
		private void Trace(string msg)
		{
			this._ts.TraceVerbose(this.Key + ": " + msg);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002B74 File Offset: 0x00000D74
		public void Call(Action<T> func, bool isProgress = false)
		{
			CallbackState state = this.State;
			if (state == CallbackState.Inactive)
			{
				return;
			}
			List<Action<T>> deferredFuncs = this._deferredFuncs;
			lock (deferredFuncs)
			{
				if (state == CallbackState.Suspended || this._deferredFuncs.Count > 0 || this._firingDeferredFuncs)
				{
					this.Trace("Deferring callback " + func.Method.Name);
					if (isProgress && this._lastIsProgress && this._deferredFuncs.Count > 0)
					{
						this._deferredFuncs.RemoveAt(this._deferredFuncs.Count - 1);
					}
					this._deferredFuncs.Add(func);
					this._lastIsProgress = isProgress;
					return;
				}
			}
			try
			{
				this.Trace("Direct calling monitor callback " + func.Method.Name);
				func(this._callback);
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "Call");
				this.State = CallbackState.Inactive;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002C88 File Offset: 0x00000E88
		public void FireDeferredCallbacks()
		{
			this.Trace("Starting thread to fire deferred callbacks");
			Task.Run(delegate()
			{
				this.Trace("Inside lock of thread to fire deferred callbacks");
				for (;;)
				{
					List<Action<T>> list = new List<Action<T>>();
					List<Action<T>> deferredFuncs = this._deferredFuncs;
					lock (deferredFuncs)
					{
						if (this._firingDeferredFuncs)
						{
							break;
						}
						if (this._deferredFuncs.Count == 0)
						{
							break;
						}
						this._firingDeferredFuncs = true;
						if (!this.IsInactive)
						{
							foreach (Action<T> item in this._deferredFuncs)
							{
								list.Add(item);
							}
						}
						this._deferredFuncs.Clear();
					}
					foreach (Action<T> action in list)
					{
						try
						{
							this.Trace("Deferred calling monitor callback " + action.Method.Name);
							action(this._callback);
						}
						catch (Exception ex)
						{
							this._ts.TraceException(ex, "FireDeferredCallbacks");
							this.State = CallbackState.Inactive;
							break;
						}
					}
					deferredFuncs = this._deferredFuncs;
					lock (deferredFuncs)
					{
						this._firingDeferredFuncs = false;
						continue;
					}
					break;
				}
			});
		}

		// Token: 0x04000015 RID: 21
		private readonly T _callback;

		// Token: 0x04000016 RID: 22
		private readonly LlTraceSource _ts;

		// Token: 0x04000017 RID: 23
		private readonly List<Action<T>> _deferredFuncs = new List<Action<T>>();

		// Token: 0x04000018 RID: 24
		private bool _firingDeferredFuncs;

		// Token: 0x04000019 RID: 25
		private bool _lastIsProgress;

		// Token: 0x0400001B RID: 27
		private CallbackState _state;
	}
}
