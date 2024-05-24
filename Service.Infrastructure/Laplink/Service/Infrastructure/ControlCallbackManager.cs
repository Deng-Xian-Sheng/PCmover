using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.ServiceModel;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000003 RID: 3
	public class ControlCallbackManager<T> where T : class
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020F0 File Offset: 0x000002F0
		private LlTraceSource Ts
		{
			get
			{
				return this.State.Ts;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020FD File Offset: 0x000002FD
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002109 File Offset: 0x00000309
		public virtual string SessionId
		{
			get
			{
				return OperationContext.Current.SessionId;
			}
			set
			{
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000210B File Offset: 0x0000030B
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002113 File Offset: 0x00000313
		protected bool TraceControlFunctions { get; set; } = true;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000211C File Offset: 0x0000031C
		public ControlCallbackStateData<T> State { get; }

		// Token: 0x0600000B RID: 11 RVA: 0x00002124 File Offset: 0x00000324
		public ControlCallbackManager(ControlCallbackStateData<T> state)
		{
			this.State = state;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000213A File Offset: 0x0000033A
		public bool IsController
		{
			get
			{
				return this.State.IsController(this.SessionId);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002150 File Offset: 0x00000350
		public void VerifyControl([CallerMemberName] string caller = "")
		{
			if (this.IsController)
			{
				if (this.TraceControlFunctions)
				{
					this.Ts.TraceVerbose(this.State.ControllerName + " function " + caller);
				}
				return;
			}
			UnauthorizedAccessException ex = new UnauthorizedAccessException("Attempted to call " + caller + " when not the controller");
			this.Ts.TraceException(ex, "VerifyControl");
			throw new FaultException<UnauthorizedAccessException>(ex);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021BC File Offset: 0x000003BC
		public bool SetController(T callback, IIdentity identity, WindowsIdentity windowsIdentity, string scheme, CallbackState state)
		{
			return this.State.SetController(callback, identity, windowsIdentity, scheme, state, this.SessionId);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021D6 File Offset: 0x000003D6
		public void StopBeingController()
		{
			if (this.IsController)
			{
				this.Ts.TraceCaller("ClearController", "StopBeingController");
				this.State.ClearController();
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002200 File Offset: 0x00000400
		public void ConfigureControlCallbacks(CallbackState controlCallbackState)
		{
			this.VerifyControl("ConfigureControlCallbacks");
			this.State.ControlCallbackState = controlCallbackState;
		}
	}
}
