using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000446 RID: 1094
	internal sealed class EventSourceActivity : IDisposable
	{
		// Token: 0x0600361A RID: 13850 RVA: 0x000D25B4 File Offset: 0x000D07B4
		public EventSourceActivity(EventSource eventSource)
		{
			if (eventSource == null)
			{
				throw new ArgumentNullException("eventSource");
			}
			this.eventSource = eventSource;
		}

		// Token: 0x0600361B RID: 13851 RVA: 0x000D25D1 File Offset: 0x000D07D1
		public static implicit operator EventSourceActivity(EventSource eventSource)
		{
			return new EventSourceActivity(eventSource);
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x0600361C RID: 13852 RVA: 0x000D25D9 File Offset: 0x000D07D9
		public EventSource EventSource
		{
			get
			{
				return this.eventSource;
			}
		}

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x0600361D RID: 13853 RVA: 0x000D25E1 File Offset: 0x000D07E1
		public Guid Id
		{
			get
			{
				return this.activityId;
			}
		}

		// Token: 0x0600361E RID: 13854 RVA: 0x000D25E9 File Offset: 0x000D07E9
		public EventSourceActivity Start<T>(string eventName, EventSourceOptions options, T data)
		{
			return this.Start<T>(eventName, ref options, ref data);
		}

		// Token: 0x0600361F RID: 13855 RVA: 0x000D25F8 File Offset: 0x000D07F8
		public EventSourceActivity Start(string eventName)
		{
			EventSourceOptions eventSourceOptions = default(EventSourceOptions);
			EmptyStruct emptyStruct = default(EmptyStruct);
			return this.Start<EmptyStruct>(eventName, ref eventSourceOptions, ref emptyStruct);
		}

		// Token: 0x06003620 RID: 13856 RVA: 0x000D2620 File Offset: 0x000D0820
		public EventSourceActivity Start(string eventName, EventSourceOptions options)
		{
			EmptyStruct emptyStruct = default(EmptyStruct);
			return this.Start<EmptyStruct>(eventName, ref options, ref emptyStruct);
		}

		// Token: 0x06003621 RID: 13857 RVA: 0x000D2640 File Offset: 0x000D0840
		public EventSourceActivity Start<T>(string eventName, T data)
		{
			EventSourceOptions eventSourceOptions = default(EventSourceOptions);
			return this.Start<T>(eventName, ref eventSourceOptions, ref data);
		}

		// Token: 0x06003622 RID: 13858 RVA: 0x000D2660 File Offset: 0x000D0860
		public void Stop<T>(T data)
		{
			this.Stop<T>(null, ref data);
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x000D266C File Offset: 0x000D086C
		public void Stop<T>(string eventName)
		{
			EmptyStruct emptyStruct = default(EmptyStruct);
			this.Stop<EmptyStruct>(eventName, ref emptyStruct);
		}

		// Token: 0x06003624 RID: 13860 RVA: 0x000D268A File Offset: 0x000D088A
		public void Stop<T>(string eventName, T data)
		{
			this.Stop<T>(eventName, ref data);
		}

		// Token: 0x06003625 RID: 13861 RVA: 0x000D2695 File Offset: 0x000D0895
		public void Write<T>(string eventName, EventSourceOptions options, T data)
		{
			this.Write<T>(this.eventSource, eventName, ref options, ref data);
		}

		// Token: 0x06003626 RID: 13862 RVA: 0x000D26A8 File Offset: 0x000D08A8
		public void Write<T>(string eventName, T data)
		{
			EventSourceOptions eventSourceOptions = default(EventSourceOptions);
			this.Write<T>(this.eventSource, eventName, ref eventSourceOptions, ref data);
		}

		// Token: 0x06003627 RID: 13863 RVA: 0x000D26D0 File Offset: 0x000D08D0
		public void Write(string eventName, EventSourceOptions options)
		{
			EmptyStruct emptyStruct = default(EmptyStruct);
			this.Write<EmptyStruct>(this.eventSource, eventName, ref options, ref emptyStruct);
		}

		// Token: 0x06003628 RID: 13864 RVA: 0x000D26F8 File Offset: 0x000D08F8
		public void Write(string eventName)
		{
			EventSourceOptions eventSourceOptions = default(EventSourceOptions);
			EmptyStruct emptyStruct = default(EmptyStruct);
			this.Write<EmptyStruct>(this.eventSource, eventName, ref eventSourceOptions, ref emptyStruct);
		}

		// Token: 0x06003629 RID: 13865 RVA: 0x000D2726 File Offset: 0x000D0926
		public void Write<T>(EventSource source, string eventName, EventSourceOptions options, T data)
		{
			this.Write<T>(source, eventName, ref options, ref data);
		}

		// Token: 0x0600362A RID: 13866 RVA: 0x000D2734 File Offset: 0x000D0934
		public void Dispose()
		{
			if (this.state == EventSourceActivity.State.Started)
			{
				EmptyStruct emptyStruct = default(EmptyStruct);
				this.Stop<EmptyStruct>(null, ref emptyStruct);
			}
		}

		// Token: 0x0600362B RID: 13867 RVA: 0x000D275C File Offset: 0x000D095C
		private EventSourceActivity Start<T>(string eventName, ref EventSourceOptions options, ref T data)
		{
			if (this.state != EventSourceActivity.State.Started)
			{
				throw new InvalidOperationException();
			}
			if (!this.eventSource.IsEnabled())
			{
				return this;
			}
			EventSourceActivity eventSourceActivity = new EventSourceActivity(this.eventSource);
			if (!this.eventSource.IsEnabled(options.Level, options.Keywords))
			{
				Guid id = this.Id;
				eventSourceActivity.activityId = Guid.NewGuid();
				eventSourceActivity.startStopOptions = options;
				eventSourceActivity.eventName = eventName;
				eventSourceActivity.startStopOptions.Opcode = EventOpcode.Start;
				this.eventSource.Write<T>(eventName, ref eventSourceActivity.startStopOptions, ref eventSourceActivity.activityId, ref id, ref data);
			}
			else
			{
				eventSourceActivity.activityId = this.Id;
			}
			return eventSourceActivity;
		}

		// Token: 0x0600362C RID: 13868 RVA: 0x000D2806 File Offset: 0x000D0A06
		private void Write<T>(EventSource eventSource, string eventName, ref EventSourceOptions options, ref T data)
		{
			if (this.state != EventSourceActivity.State.Started)
			{
				throw new InvalidOperationException();
			}
			if (eventName == null)
			{
				throw new ArgumentNullException();
			}
			eventSource.Write<T>(eventName, ref options, ref this.activityId, ref EventSourceActivity.s_empty, ref data);
		}

		// Token: 0x0600362D RID: 13869 RVA: 0x000D2834 File Offset: 0x000D0A34
		private void Stop<T>(string eventName, ref T data)
		{
			if (this.state != EventSourceActivity.State.Started)
			{
				throw new InvalidOperationException();
			}
			if (!this.StartEventWasFired)
			{
				return;
			}
			this.state = EventSourceActivity.State.Stopped;
			if (eventName == null)
			{
				eventName = this.eventName;
				if (eventName.EndsWith("Start"))
				{
					eventName = eventName.Substring(0, eventName.Length - 5);
				}
				eventName += "Stop";
			}
			this.startStopOptions.Opcode = EventOpcode.Stop;
			this.eventSource.Write<T>(eventName, ref this.startStopOptions, ref this.activityId, ref EventSourceActivity.s_empty, ref data);
		}

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x0600362E RID: 13870 RVA: 0x000D28BF File Offset: 0x000D0ABF
		private bool StartEventWasFired
		{
			get
			{
				return this.eventName != null;
			}
		}

		// Token: 0x0400182A RID: 6186
		private readonly EventSource eventSource;

		// Token: 0x0400182B RID: 6187
		private EventSourceOptions startStopOptions;

		// Token: 0x0400182C RID: 6188
		internal Guid activityId;

		// Token: 0x0400182D RID: 6189
		private EventSourceActivity.State state;

		// Token: 0x0400182E RID: 6190
		private string eventName;

		// Token: 0x0400182F RID: 6191
		internal static Guid s_empty;

		// Token: 0x02000B9B RID: 2971
		private enum State
		{
			// Token: 0x0400352C RID: 13612
			Started,
			// Token: 0x0400352D RID: 13613
			Stopped
		}
	}
}
