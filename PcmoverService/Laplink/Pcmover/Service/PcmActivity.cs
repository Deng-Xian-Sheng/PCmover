using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000013 RID: 19
	public abstract class PcmActivity : ProgressEventsHandler
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000387C File Offset: 0x00001A7C
		public bool IsComplete
		{
			get
			{
				ActivityInfo info = this.Info;
				bool result;
				lock (info)
				{
					result = (this.Info.State == ActivityState.Success || this.Info.State == ActivityState.Failure);
				}
				return result;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000038D8 File Offset: 0x00001AD8
		public PcmoverManager Manager { get; }

		// Token: 0x0600005D RID: 93 RVA: 0x000038E0 File Offset: 0x00001AE0
		public PcmActivity(ActivityType type, PcmoverManager manager)
		{
			this.Manager = manager;
			this.m_app = this.Manager._app;
			this.m_ts = this.Manager.Ts;
			this.Info = new ActivityInfo
			{
				Type = type,
				State = ActivityState.Idle,
				Phase = 0,
				FailureReason = 0
			};
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003950 File Offset: 0x00001B50
		protected void TerminateOnFailure(int failureReason, string message)
		{
			ActivityInfo info = this.Info;
			lock (info)
			{
				this.Info.State = ActivityState.Failure;
				this.Info.FailureReason = failureReason;
				this.Info.Message = message;
				this.Info.EndTimeUtc = DateTime.UtcNow;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000039C0 File Offset: 0x00001BC0
		protected void TerminateOnException(Exception ex, [CallerMemberName] string caller = "")
		{
			this.m_ts.TraceException(ex, LlTraceSource.ExceptionDetails.All, caller);
			this.TerminateOnFailure(3, ex.Message);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000039E0 File Offset: 0x00001BE0
		public virtual bool Start()
		{
			if (this.m_task != null)
			{
				return false;
			}
			try
			{
				ActivityInfo info = this.Info;
				lock (info)
				{
					this.Info.State = ActivityState.Active;
					this.Info.StartTimeUtc = DateTime.UtcNow;
				}
				this.m_task = Task.Factory.StartNew<Task>(delegate()
				{
					PcmActivity.<<Start>b__18_0>d <<Start>b__18_0>d;
					<<Start>b__18_0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
					<<Start>b__18_0>d.<>4__this = this;
					<<Start>b__18_0>d.<>1__state = -1;
					<<Start>b__18_0>d.<>t__builder.Start<PcmActivity.<<Start>b__18_0>d>(ref <<Start>b__18_0>d);
					return <<Start>b__18_0>d.<>t__builder.Task;
				}, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			}
			catch (Exception ex)
			{
				this.m_ts.TraceException(ex, "Start");
				return false;
			}
			return true;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003A90 File Offset: 0x00001C90
		protected virtual void OnTaskComplete()
		{
		}

		// Token: 0x06000062 RID: 98
		protected abstract void Run();

		// Token: 0x06000063 RID: 99 RVA: 0x00003A94 File Offset: 0x00001C94
		protected virtual Task RunAsync()
		{
			PcmActivity.<RunAsync>d__21 <RunAsync>d__;
			<RunAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RunAsync>d__.<>1__state = -1;
			<RunAsync>d__.<>t__builder.Start<PcmActivity.<RunAsync>d__21>(ref <RunAsync>d__);
			return <RunAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003AD0 File Offset: 0x00001CD0
		public void Cancel()
		{
			bool flag = false;
			ActivityInfo info = this.Info;
			lock (info)
			{
				if (this.Info.State == ActivityState.Active)
				{
					this.Info.State = ActivityState.CancelPending;
					flag = true;
				}
			}
			if (flag)
			{
				lock (this)
				{
					this.m_bCancel = true;
					this.m_ts.TraceInformation("Setting cancel event");
					this.m_cancelEvent.Set();
					if (this.m_progressBase != null)
					{
						this.m_ts.TraceInformation("Setting cancel in the progress base");
						this.m_progressBase.SetCancel();
					}
					this.OnCancel();
					this.m_ts.TraceInformation("Done requesting cancel");
					return;
				}
			}
			this.m_ts.TraceInformation(string.Format("Not cancelling {0}, state = {1}", this.Info.Type, this.Info.State));
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003A90 File Offset: 0x00001C90
		protected virtual void OnCancel()
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003BE0 File Offset: 0x00001DE0
		public bool stop()
		{
			this.Cancel();
			Task task;
			lock (this)
			{
				task = this.m_task;
				this.m_task = null;
			}
			if (task != null)
			{
				task.Wait();
				task = null;
			}
			this.OnTaskStopped();
			return this.m_bDone;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003A90 File Offset: 0x00001C90
		protected virtual void OnTaskStopped()
		{
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003C40 File Offset: 0x00001E40
		protected override void OnProgressChanged(ProgressInfo progressInfo)
		{
			this.Manager.ProgressChanged(this, progressInfo);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003C4F File Offset: 0x00001E4F
		protected void NotifyActivityInfoChanged()
		{
			this.Manager.NotifyActivityChanged(this, MonitorChangeType.Changed);
		}

		// Token: 0x04000027 RID: 39
		public ActivityInfo Info;

		// Token: 0x04000029 RID: 41
		protected PCmoverApp m_app;

		// Token: 0x0400002A RID: 42
		protected LlTraceSource m_ts;

		// Token: 0x0400002B RID: 43
		protected ProgressBase m_progressBase;

		// Token: 0x0400002C RID: 44
		protected Task m_task;

		// Token: 0x0400002D RID: 45
		protected bool m_bDone;

		// Token: 0x0400002E RID: 46
		protected bool m_bSuccess;

		// Token: 0x0400002F RID: 47
		protected bool m_bCancel;

		// Token: 0x04000030 RID: 48
		protected ManualResetEvent m_cancelEvent = new ManualResetEvent(false);

		// Token: 0x04000031 RID: 49
		protected bool m_bAsync;
	}
}
