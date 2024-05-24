using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000002 RID: 2
	public class ActivityClient
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public ActivityType Type { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public int Handle { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public bool IsStopping { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000028B
		public ActivityInfo DeleteInfo { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00000294
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000029C
		public ActivityInfo LastInfo { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A5 File Offset: 0x000002A5
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020AD File Offset: 0x000002AD
		public IPcmoverClientEngine ClientEngine { get; protected set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020B6 File Offset: 0x000002B6
		protected IPcmoverControl ControlInterface
		{
			get
			{
				IPcmoverClientEngine clientEngine = this.ClientEngine;
				if (clientEngine == null)
				{
					return null;
				}
				return clientEngine.ControlInterface;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020C9 File Offset: 0x000002C9
		protected ActivityClients ActivityClients
		{
			get
			{
				IPcmoverClientEngine clientEngine = this.ClientEngine;
				if (clientEngine == null)
				{
					return null;
				}
				return clientEngine.ActivityClients;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000020DC File Offset: 0x000002DC
		protected bool IsResuming
		{
			get
			{
				return this.ClientEngine != null && this.ClientEngine.IsResuming;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020F3 File Offset: 0x000002F3
		protected PcmoverServiceData ServiceData
		{
			get
			{
				IPcmoverClientEngine clientEngine = this.ClientEngine;
				if (clientEngine == null)
				{
					return null;
				}
				return clientEngine.ServiceData;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002106 File Offset: 0x00000306
		protected LlTraceSource Ts
		{
			get
			{
				IPcmoverClientEngine clientEngine = this.ClientEngine;
				if (clientEngine == null)
				{
					return null;
				}
				return clientEngine.Ts;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002119 File Offset: 0x00000319
		public ActivityClient(IPcmoverClientEngine engine)
		{
			this.ClientEngine = engine;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002133 File Offset: 0x00000333
		public ActivityClient(IPcmoverClientEngine engine, ActivityType type, int handle) : this(engine)
		{
			this.Attach(type, handle);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002144 File Offset: 0x00000344
		public void Attach(ActivityType type, int handle)
		{
			this.Type = type;
			this.Handle = handle;
			LlTraceSource ts = this.Ts;
			if (ts != null)
			{
				ts.TraceInformation(string.Format("Adding activity {0} {1}", type, handle));
			}
			if (this.ActivityClients != null)
			{
				ActivityClients activityClients = this.ActivityClients;
				lock (activityClients)
				{
					this.ActivityClients.Add(this);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000021C8 File Offset: 0x000003C8
		public virtual void Start(ActivityInfo info)
		{
			if (info == null || info.Handle == 0)
			{
				return;
			}
			this.Attach(info.Type, info.Handle);
			this.LastInfo = info;
			IPcmoverClientEngine clientEngine = this.ClientEngine;
			if (clientEngine == null)
			{
				return;
			}
			clientEngine.CatchCommEx(delegate
			{
				this.ControlInterface.StartActivity(this.Handle);
			}, "Start");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000221C File Offset: 0x0000041C
		public void AddTcs(TaskCompletionSource<ActivityInfo> tcs)
		{
			if (tcs != null)
			{
				List<TaskCompletionSource<ActivityInfo>> tcsList = this._tcsList;
				lock (tcsList)
				{
					this._tcsList.Add(tcs);
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002268 File Offset: 0x00000468
		private void SignalTcs(ActivityInfo info)
		{
			List<TaskCompletionSource<ActivityInfo>> tcsList = this._tcsList;
			lock (tcsList)
			{
				foreach (TaskCompletionSource<ActivityInfo> taskCompletionSource in this._tcsList)
				{
					taskCompletionSource.TrySetResult(info);
				}
				this._tcsList.Clear();
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022F0 File Offset: 0x000004F0
		public void Stop(TaskCompletionSource<ActivityInfo> tcs = null)
		{
			Action <>9__1;
			CodeHelper.trycatch(this.Ts, delegate()
			{
				this.AddTcs(tcs);
				this.IsStopping = true;
				if (this.Handle != -1)
				{
					IPcmoverClientEngine clientEngine = this.ClientEngine;
					if (clientEngine == null)
					{
						return;
					}
					Action func;
					if ((func = <>9__1) == null)
					{
						func = (<>9__1 = delegate()
						{
							this.ControlInterface.StopActivity(this.Handle);
						});
					}
					clientEngine.CatchCommEx(func, "Stop");
				}
			}, "Stop");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002330 File Offset: 0x00000530
		public Task<ActivityInfo> StopAsync()
		{
			ActivityClient.<StopAsync>d__43 <StopAsync>d__;
			<StopAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ActivityInfo>.Create();
			<StopAsync>d__.<>4__this = this;
			<StopAsync>d__.<>1__state = -1;
			<StopAsync>d__.<>t__builder.Start<ActivityClient.<StopAsync>d__43>(ref <StopAsync>d__);
			return <StopAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002374 File Offset: 0x00000574
		public Task<ActivityInfo> CompleteAsync()
		{
			ActivityClient.<CompleteAsync>d__44 <CompleteAsync>d__;
			<CompleteAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ActivityInfo>.Create();
			<CompleteAsync>d__.<>4__this = this;
			<CompleteAsync>d__.<>1__state = -1;
			<CompleteAsync>d__.<>t__builder.Start<ActivityClient.<CompleteAsync>d__44>(ref <CompleteAsync>d__);
			return <CompleteAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000023B8 File Offset: 0x000005B8
		public void Delete(ActivityInfo info)
		{
			CodeHelper.trycatch(this.Ts, delegate()
			{
				this.DeleteInfo = info;
				int handle = this.Handle;
				this.Handle = 0;
				if (handle != 0)
				{
					this.IsStopping = true;
					if (handle != -1)
					{
						IPcmoverClientEngine clientEngine = this.ClientEngine;
						if (clientEngine != null)
						{
							clientEngine.CatchCommEx(delegate
							{
								this.ControlInterface.DeleteActivity(handle);
							}, "Delete");
						}
					}
				}
				this.Ts.TraceInformation(string.Format("Removing activity {0} {1}", this.Type, handle));
				if (this.ActivityClients != null)
				{
					ActivityClients activityClients = this.ActivityClients;
					lock (activityClients)
					{
						this.ActivityClients.Remove(this);
					}
				}
				this.IsStopping = false;
				this.SignalTcs(info);
			}, "Delete");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000023F5 File Offset: 0x000005F5
		public static bool ActivityDone(ActivityInfo info)
		{
			return info == null || info.IsDone;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002402 File Offset: 0x00000602
		public static bool ActivitySucceeded(ActivityInfo info)
		{
			return info != null && info.IsSucceeded;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002410 File Offset: 0x00000610
		public virtual void OnActivityInfoChanged(ActivityInfo info)
		{
			this.Ts.TraceInformation(string.Format("ActivityInfoChanged: {0}", info));
			this.LastInfo = info;
			IPcmoverClientEngine clientEngine = this.ClientEngine;
			if (clientEngine != null)
			{
				clientEngine.FireActivityInfoEvent(info);
			}
			ActivityClient.ActivityInfoDelegate onActivityInfoChangedCallback = this.OnActivityInfoChangedCallback;
			if (onActivityInfoChangedCallback != null)
			{
				onActivityInfoChangedCallback(info);
			}
			if (ActivityClient.ActivityDone(info))
			{
				this.OnDone(info);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000246D File Offset: 0x0000066D
		public virtual void OnDone(ActivityInfo info)
		{
			ActivityClient.ActivityInfoDelegate onDoneCallback = this.OnDoneCallback;
			if (onDoneCallback != null)
			{
				onDoneCallback(info);
			}
			if (ActivityClient.ActivitySucceeded(info))
			{
				this.OnSucceeded(info);
			}
			this.EndActivity(info);
			this.AfterDeleted(info);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000249E File Offset: 0x0000069E
		public virtual void OnSucceeded(ActivityInfo info)
		{
			ActivityClient.ActivityInfoDelegate onSucceededCallback = this.OnSucceededCallback;
			if (onSucceededCallback == null)
			{
				return;
			}
			onSucceededCallback(info);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000024B1 File Offset: 0x000006B1
		protected void EndActivity(ActivityInfo info)
		{
			this.Delete(info);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024BA File Offset: 0x000006BA
		protected virtual void AfterDeleted(ActivityInfo info)
		{
			ActivityClient.ActivityInfoDelegate afterDeletedCallback = this.AfterDeletedCallback;
			if (afterDeletedCallback == null)
			{
				return;
			}
			afterDeletedCallback(info);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000024CD File Offset: 0x000006CD
		public virtual void OnProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			ActivityClient.ProgressDelegate onProgressCallback = this.OnProgressCallback;
			if (onProgressCallback == null)
			{
				return;
			}
			onProgressCallback(activityInfo, progressInfo);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024E1 File Offset: 0x000006E1
		public void Resume(ActivityType type)
		{
			this.Resume(type, this.ServiceData.GetActivity(type));
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000024F8 File Offset: 0x000006F8
		public void Resume(ActivityType type, ActivityInfo activityInfo)
		{
			ActivityClient.<>c__DisplayClass62_0 CS$<>8__locals1 = new ActivityClient.<>c__DisplayClass62_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.activityInfo = activityInfo;
			this.Ts.TraceCaller(type.ToString(), "Resume");
			CS$<>8__locals1.delay = 100;
			if (CS$<>8__locals1.activityInfo != null)
			{
				this.Ts.TraceCaller(string.Format("Resuming ActivityInfo {0}", CS$<>8__locals1.activityInfo), "Resume");
				this.Attach(type, CS$<>8__locals1.activityInfo.Handle);
				Task.Run(delegate()
				{
					ActivityClient.<>c__DisplayClass62_0.<<Resume>b__0>d <<Resume>b__0>d;
					<<Resume>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
					<<Resume>b__0>d.<>4__this = CS$<>8__locals1;
					<<Resume>b__0>d.<>1__state = -1;
					<<Resume>b__0>d.<>t__builder.Start<ActivityClient.<>c__DisplayClass62_0.<<Resume>b__0>d>(ref <<Resume>b__0>d);
					return <<Resume>b__0>d.<>t__builder.Task;
				});
				return;
			}
			this.Ts.TraceCaller("Simulate completion", "Resume");
			this.Attach(type, -1);
			Task.Run(delegate()
			{
				ActivityClient.<>c__DisplayClass62_0.<<Resume>b__1>d <<Resume>b__1>d;
				<<Resume>b__1>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<Resume>b__1>d.<>4__this = CS$<>8__locals1;
				<<Resume>b__1>d.<>1__state = -1;
				<<Resume>b__1>d.<>t__builder.Start<ActivityClient.<>c__DisplayClass62_0.<<Resume>b__1>d>(ref <<Resume>b__1>d);
				return <<Resume>b__1>d.<>t__builder.Task;
			});
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000025BC File Offset: 0x000007BC
		protected virtual void OnSimulateCompletion()
		{
			ActivityInfo info = new ActivityInfo
			{
				Type = this.Type,
				StartTimeUtc = DateTime.UtcNow,
				EndTimeUtc = DateTime.UtcNow,
				State = ActivityState.Success,
				Handle = this.Handle
			};
			this.OnActivityInfoChanged(info);
		}

		// Token: 0x04000002 RID: 2
		public const int SIMULATED_HANDLE = -1;

		// Token: 0x04000008 RID: 8
		private readonly List<TaskCompletionSource<ActivityInfo>> _tcsList = new List<TaskCompletionSource<ActivityInfo>>();

		// Token: 0x04000009 RID: 9
		public ActivityClient.ActivityInfoDelegate OnActivityInfoChangedCallback;

		// Token: 0x0400000A RID: 10
		public ActivityClient.ActivityInfoDelegate OnDoneCallback;

		// Token: 0x0400000B RID: 11
		public ActivityClient.ActivityInfoDelegate OnSucceededCallback;

		// Token: 0x0400000C RID: 12
		public ActivityClient.ActivityInfoDelegate AfterDeletedCallback;

		// Token: 0x0400000D RID: 13
		public ActivityClient.ProgressDelegate OnProgressCallback;

		// Token: 0x02000011 RID: 17
		// (Invoke) Token: 0x060000FE RID: 254
		public delegate void ActivityInfoDelegate(ActivityInfo info);

		// Token: 0x02000012 RID: 18
		// (Invoke) Token: 0x06000102 RID: 258
		public delegate void ProgressDelegate(ActivityInfo activityInfo, ProgressInfo progressInfo);
	}
}
