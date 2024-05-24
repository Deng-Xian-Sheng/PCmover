using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Tools.Helpers;
using Laplink.Tools.NativeMethods;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200002C RID: 44
	public class SuspendSleep : IDisposable
	{
		// Token: 0x06000216 RID: 534 RVA: 0x0000FA40 File Offset: 0x0000DC40
		public SuspendSleep(LlTraceSource ts)
		{
			this._ts = ts;
			this._suspendLoop = Task.Factory.StartNew(new Action(this.SuspendLoop), TaskCreationOptions.LongRunning);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000FA78 File Offset: 0x0000DC78
		public void Suspend(bool suspend)
		{
			this._suspend = suspend;
			this._wakeUpEvent.Set();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000FA8F File Offset: 0x0000DC8F
		private ServiceController GetWindowsUpdateService()
		{
			return new ServiceController("wuauserv");
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000FA9C File Offset: 0x0000DC9C
		private void DisableWindowsUpdate()
		{
			ServiceController windowsUpdateService = this.GetWindowsUpdateService();
			if (windowsUpdateService != null)
			{
				try
				{
					if (this._initialWindowsUpdateStatus == null)
					{
						this._initialWindowsUpdateStatus = new ServiceControllerStatus?(windowsUpdateService.Status);
					}
					ServiceControllerStatus? initialWindowsUpdateStatus = this._initialWindowsUpdateStatus;
					ServiceControllerStatus serviceControllerStatus = ServiceControllerStatus.Running;
					if (initialWindowsUpdateStatus.GetValueOrDefault() == serviceControllerStatus & initialWindowsUpdateStatus != null)
					{
						windowsUpdateService.Stop();
					}
					windowsUpdateService.Close();
				}
				catch (Exception ex)
				{
					this._ts.TraceException(ex, "DisableWindowsUpdate");
				}
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000FB20 File Offset: 0x0000DD20
		private void EnableWindowsUpdate()
		{
			ServiceController windowsUpdateService = this.GetWindowsUpdateService();
			if (windowsUpdateService != null)
			{
				try
				{
					ServiceControllerStatus? initialWindowsUpdateStatus = this._initialWindowsUpdateStatus;
					ServiceControllerStatus serviceControllerStatus = ServiceControllerStatus.Running;
					if (initialWindowsUpdateStatus.GetValueOrDefault() == serviceControllerStatus & initialWindowsUpdateStatus != null)
					{
						ServiceControllerStatus status = windowsUpdateService.Status;
						if (status == ServiceControllerStatus.Stopped || status == ServiceControllerStatus.StopPending)
						{
							windowsUpdateService.Start();
						}
					}
					windowsUpdateService.Close();
				}
				catch (Exception ex)
				{
					this._ts.TraceException(ex, "EnableWindowsUpdate");
				}
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000FB98 File Offset: 0x0000DD98
		private void DoSuspend(bool suspend)
		{
			if (suspend)
			{
				if (!this._isSuspended)
				{
					Kernel32.SetThreadExecutionState(2147483713U);
					this.DisableWindowsUpdate();
					this._isSuspended = true;
					return;
				}
			}
			else if (this._isSuspended)
			{
				this.EnableWindowsUpdate();
				Kernel32.SetThreadExecutionState(2147483648U);
				this._isSuspended = false;
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000FBE9 File Offset: 0x0000DDE9
		private void SuspendLoop()
		{
			this.DoSuspend(this._suspend);
			while (this._wakeUpEvent.WaitOne() && !this._exitLoop)
			{
				this.DoSuspend(this._suspend);
			}
			this.DoSuspend(false);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000FC28 File Offset: 0x0000DE28
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					this._exitLoop = true;
					this._wakeUpEvent.Set();
					this._suspendLoop.Wait();
					this._suspendLoop = null;
					this._wakeUpEvent.Dispose();
					this._wakeUpEvent = null;
				}
				this.disposed = true;
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000FC80 File Offset: 0x0000DE80
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x0400009A RID: 154
		private readonly LlTraceSource _ts;

		// Token: 0x0400009B RID: 155
		private Task _suspendLoop;

		// Token: 0x0400009C RID: 156
		private AutoResetEvent _wakeUpEvent = new AutoResetEvent(false);

		// Token: 0x0400009D RID: 157
		private volatile bool _suspend;

		// Token: 0x0400009E RID: 158
		private bool _isSuspended;

		// Token: 0x0400009F RID: 159
		private volatile bool _exitLoop;

		// Token: 0x040000A0 RID: 160
		private ServiceControllerStatus? _initialWindowsUpdateStatus;

		// Token: 0x040000A1 RID: 161
		private bool disposed;
	}
}
