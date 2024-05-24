using System;
using System.Security.Principal;
using System.ServiceModel;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000004 RID: 4
	public class ControlCallbackStateData<T> where T : class
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002219 File Offset: 0x00000419
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002221 File Offset: 0x00000421
		public string ControllerName { get; set; } = "Controller";

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000222A File Offset: 0x0000042A
		public object ControllerLock { get; } = new object();

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002232 File Offset: 0x00000432
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000223A File Offset: 0x0000043A
		public string ControllerSessionId { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002243 File Offset: 0x00000443
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000224B File Offset: 0x0000044B
		public IIdentity ControllerIIdentity { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002254 File Offset: 0x00000454
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000225C File Offset: 0x0000045C
		public WindowsIdentity ControllerWindowsIdentity
		{
			get
			{
				return this._controllerWindowsIdentity;
			}
			protected set
			{
				this._controllerWindowsIdentity = value;
				if (value == null)
				{
					this.Ts.TraceInformation(this.ControllerName + " taken by a null identity");
					return;
				}
				this.Ts.TraceInformation(this.ControllerName + " taken by " + value.Name);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000022B0 File Offset: 0x000004B0
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000022B8 File Offset: 0x000004B8
		public string ControllerScheme { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000022C1 File Offset: 0x000004C1
		public LlTraceSource Ts
		{
			get
			{
				return this._its.Ts;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000022CE File Offset: 0x000004CE
		public T ControlCallback
		{
			get
			{
				return this._controlCallback;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000022D8 File Offset: 0x000004D8
		public void SetControlCallback(T controlCallback, string sessionId)
		{
			if (this._controlCallback != controlCallback)
			{
				T oldVal = default(T);
				object controllerLock = this.ControllerLock;
				lock (controllerLock)
				{
					if (this._controlCallback == controlCallback)
					{
						return;
					}
					oldVal = this._controlCallback;
					this._controlCallback = controlCallback;
					this.ControllerSessionId = sessionId;
				}
				if (controlCallback == null)
				{
					this.Ts.TraceInformation(this.ControllerName + " disabled");
				}
				else
				{
					this.Ts.TraceInformation(this.ControllerName + " set to " + sessionId);
				}
				this.OnControlCallbackChanged(oldVal, controlCallback);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000023A4 File Offset: 0x000005A4
		public bool HasController
		{
			get
			{
				return this.ControlCallback != null;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002109 File Offset: 0x00000309
		protected virtual void OnControlCallbackChanged(T oldVal, T newVal)
		{
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000023B4 File Offset: 0x000005B4
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000023BC File Offset: 0x000005BC
		public CallbackState ControlCallbackState
		{
			get
			{
				return this._controlCallbackState;
			}
			set
			{
				if (this._controlCallbackState == value)
				{
					return;
				}
				this._controlCallbackState = value;
				this.OnControlCallbackStateChanged(value, value);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002109 File Offset: 0x00000309
		protected virtual void OnControlCallbackStateChanged(CallbackState oldVal, CallbackState newVal)
		{
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000023E4 File Offset: 0x000005E4
		public virtual bool CanSendControlCallback
		{
			get
			{
				return this.ControlCallbackState == CallbackState.Active && this.ControlCallback != null;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000023FF File Offset: 0x000005FF
		public ControlCallbackStateData(ILlTraceSource its)
		{
			this._its = its;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002424 File Offset: 0x00000624
		public void ClearController()
		{
			object controllerLock = this.ControllerLock;
			lock (controllerLock)
			{
				this.SetControlCallback(default(T), null);
				this.ControllerIIdentity = null;
				this.ControllerWindowsIdentity = null;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000247C File Offset: 0x0000067C
		public virtual bool ValidateControlCallback()
		{
			if (this.ControlCallback == null)
			{
				return true;
			}
			try
			{
				if (((ICommunicationObject)((object)this.ControlCallback)).State == CommunicationState.Opened)
				{
					return true;
				}
			}
			catch (Exception)
			{
			}
			this.Ts.TraceCaller("ControlCallback is invalid. Clear it.", "ValidateControlCallback");
			this.ClearController();
			return false;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024E8 File Offset: 0x000006E8
		public bool IsController(string sessionId)
		{
			string controllerSessionId = this.ControllerSessionId;
			return controllerSessionId != null && controllerSessionId == sessionId;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000250C File Offset: 0x0000070C
		public bool SetController(T callback, IIdentity identity, WindowsIdentity windowsIdentity, string scheme, CallbackState state, string sessionId)
		{
			this.ValidateControlCallback();
			object controllerLock = this.ControllerLock;
			lock (controllerLock)
			{
				if (this.ControlCallback != null)
				{
					if (!this.IsController(sessionId))
					{
						this.Ts.TraceCaller("Denying request because someone else is the controller", "SetController");
						return false;
					}
					this.Ts.TraceCaller("Current controller requesting access again via " + scheme, "SetController");
				}
				else
				{
					this.Ts.TraceCaller("New request to SetController via " + scheme, "SetController");
				}
				this.SetControlCallback(callback, sessionId);
				this.ControllerIIdentity = identity;
				this.ControllerWindowsIdentity = windowsIdentity;
				this.ControllerScheme = scheme;
				this.ControlCallbackState = state;
			}
			return true;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000025E4 File Offset: 0x000007E4
		public void CallControlCallback(Action<T> func)
		{
			if (this.CanSendControlCallback)
			{
				try
				{
					func(this.ControlCallback);
				}
				catch (Exception ex)
				{
					this.Ts.TraceException(ex, "CallControlCallback");
					this.ClearController();
				}
			}
		}

		// Token: 0x0400000C RID: 12
		private WindowsIdentity _controllerWindowsIdentity;

		// Token: 0x0400000E RID: 14
		private ILlTraceSource _its;

		// Token: 0x0400000F RID: 15
		private T _controlCallback;

		// Token: 0x04000010 RID: 16
		private CallbackState _controlCallbackState;
	}
}
