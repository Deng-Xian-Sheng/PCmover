using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200054F RID: 1359
	[__DynamicallyInvokable]
	public class ParallelOptions
	{
		// Token: 0x06004007 RID: 16391 RVA: 0x000EE1C9 File Offset: 0x000EC3C9
		[__DynamicallyInvokable]
		public ParallelOptions()
		{
			this.m_scheduler = TaskScheduler.Default;
			this.m_maxDegreeOfParallelism = -1;
			this.m_cancellationToken = CancellationToken.None;
		}

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06004008 RID: 16392 RVA: 0x000EE1EE File Offset: 0x000EC3EE
		// (set) Token: 0x06004009 RID: 16393 RVA: 0x000EE1F6 File Offset: 0x000EC3F6
		[__DynamicallyInvokable]
		public TaskScheduler TaskScheduler
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_scheduler;
			}
			[__DynamicallyInvokable]
			set
			{
				this.m_scheduler = value;
			}
		}

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x0600400A RID: 16394 RVA: 0x000EE1FF File Offset: 0x000EC3FF
		internal TaskScheduler EffectiveTaskScheduler
		{
			get
			{
				if (this.m_scheduler == null)
				{
					return TaskScheduler.Current;
				}
				return this.m_scheduler;
			}
		}

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x0600400B RID: 16395 RVA: 0x000EE215 File Offset: 0x000EC415
		// (set) Token: 0x0600400C RID: 16396 RVA: 0x000EE21D File Offset: 0x000EC41D
		[__DynamicallyInvokable]
		public int MaxDegreeOfParallelism
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_maxDegreeOfParallelism;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == 0 || value < -1)
				{
					throw new ArgumentOutOfRangeException("MaxDegreeOfParallelism");
				}
				this.m_maxDegreeOfParallelism = value;
			}
		}

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x0600400D RID: 16397 RVA: 0x000EE238 File Offset: 0x000EC438
		// (set) Token: 0x0600400E RID: 16398 RVA: 0x000EE240 File Offset: 0x000EC440
		[__DynamicallyInvokable]
		public CancellationToken CancellationToken
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_cancellationToken;
			}
			[__DynamicallyInvokable]
			set
			{
				this.m_cancellationToken = value;
			}
		}

		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x0600400F RID: 16399 RVA: 0x000EE24C File Offset: 0x000EC44C
		internal int EffectiveMaxConcurrencyLevel
		{
			get
			{
				int num = this.MaxDegreeOfParallelism;
				int maximumConcurrencyLevel = this.EffectiveTaskScheduler.MaximumConcurrencyLevel;
				if (maximumConcurrencyLevel > 0 && maximumConcurrencyLevel != 2147483647)
				{
					num = ((num == -1) ? maximumConcurrencyLevel : Math.Min(maximumConcurrencyLevel, num));
				}
				return num;
			}
		}

		// Token: 0x04001AC3 RID: 6851
		private TaskScheduler m_scheduler;

		// Token: 0x04001AC4 RID: 6852
		private int m_maxDegreeOfParallelism;

		// Token: 0x04001AC5 RID: 6853
		private CancellationToken m_cancellationToken;
	}
}
