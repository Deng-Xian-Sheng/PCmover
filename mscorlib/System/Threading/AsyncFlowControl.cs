using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004F6 RID: 1270
	public struct AsyncFlowControl : IDisposable
	{
		// Token: 0x06003BE7 RID: 15335 RVA: 0x000E320C File Offset: 0x000E140C
		[SecurityCritical]
		internal void Setup(SecurityContextDisableFlow flags)
		{
			this.useEC = false;
			Thread currentThread = Thread.CurrentThread;
			this._sc = currentThread.GetMutableExecutionContext().SecurityContext;
			this._sc._disableFlow = flags;
			this._thread = currentThread;
		}

		// Token: 0x06003BE8 RID: 15336 RVA: 0x000E324C File Offset: 0x000E144C
		[SecurityCritical]
		internal void Setup()
		{
			this.useEC = true;
			Thread currentThread = Thread.CurrentThread;
			this._ec = currentThread.GetMutableExecutionContext();
			this._ec.isFlowSuppressed = true;
			this._thread = currentThread;
		}

		// Token: 0x06003BE9 RID: 15337 RVA: 0x000E3285 File Offset: 0x000E1485
		public void Dispose()
		{
			this.Undo();
		}

		// Token: 0x06003BEA RID: 15338 RVA: 0x000E3290 File Offset: 0x000E1490
		[SecuritySafeCritical]
		public void Undo()
		{
			if (this._thread == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotUseAFCMultiple"));
			}
			if (this._thread != Thread.CurrentThread)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotUseAFCOtherThread"));
			}
			if (this.useEC)
			{
				if (Thread.CurrentThread.GetMutableExecutionContext() != this._ec)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_AsyncFlowCtrlCtxMismatch"));
				}
				ExecutionContext.RestoreFlow();
			}
			else
			{
				if (!Thread.CurrentThread.GetExecutionContextReader().SecurityContext.IsSame(this._sc))
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_AsyncFlowCtrlCtxMismatch"));
				}
				SecurityContext.RestoreFlow();
			}
			this._thread = null;
		}

		// Token: 0x06003BEB RID: 15339 RVA: 0x000E3341 File Offset: 0x000E1541
		public override int GetHashCode()
		{
			if (this._thread != null)
			{
				return this._thread.GetHashCode();
			}
			return this.ToString().GetHashCode();
		}

		// Token: 0x06003BEC RID: 15340 RVA: 0x000E3368 File Offset: 0x000E1568
		public override bool Equals(object obj)
		{
			return obj is AsyncFlowControl && this.Equals((AsyncFlowControl)obj);
		}

		// Token: 0x06003BED RID: 15341 RVA: 0x000E3380 File Offset: 0x000E1580
		public bool Equals(AsyncFlowControl obj)
		{
			return obj.useEC == this.useEC && obj._ec == this._ec && obj._sc == this._sc && obj._thread == this._thread;
		}

		// Token: 0x06003BEE RID: 15342 RVA: 0x000E33BC File Offset: 0x000E15BC
		public static bool operator ==(AsyncFlowControl a, AsyncFlowControl b)
		{
			return a.Equals(b);
		}

		// Token: 0x06003BEF RID: 15343 RVA: 0x000E33C6 File Offset: 0x000E15C6
		public static bool operator !=(AsyncFlowControl a, AsyncFlowControl b)
		{
			return !(a == b);
		}

		// Token: 0x04001983 RID: 6531
		private bool useEC;

		// Token: 0x04001984 RID: 6532
		private ExecutionContext _ec;

		// Token: 0x04001985 RID: 6533
		private SecurityContext _sc;

		// Token: 0x04001986 RID: 6534
		private Thread _thread;
	}
}
