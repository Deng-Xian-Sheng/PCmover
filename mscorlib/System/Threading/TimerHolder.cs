using System;
using System.Runtime.CompilerServices;
using System.Threading.NetCore;

namespace System.Threading
{
	// Token: 0x0200052F RID: 1327
	internal sealed class TimerHolder
	{
		// Token: 0x06003E47 RID: 15943 RVA: 0x000E848D File Offset: 0x000E668D
		public TimerHolder(object timer)
		{
			this.m_timer = timer;
		}

		// Token: 0x06003E48 RID: 15944 RVA: 0x000E849C File Offset: 0x000E669C
		~TimerHolder()
		{
			if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload())
			{
				if (Timer.UseNetCoreTimer)
				{
					this.NetCoreTimer.Close();
				}
				else
				{
					this.NetFxTimer.Close();
				}
			}
		}

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x06003E49 RID: 15945 RVA: 0x000E84F8 File Offset: 0x000E66F8
		private TimerQueueTimer NetFxTimer
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (TimerQueueTimer)this.m_timer;
			}
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x06003E4A RID: 15946 RVA: 0x000E8505 File Offset: 0x000E6705
		private TimerQueueTimer NetCoreTimer
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (TimerQueueTimer)this.m_timer;
			}
		}

		// Token: 0x06003E4B RID: 15947 RVA: 0x000E8512 File Offset: 0x000E6712
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Change(uint dueTime, uint period)
		{
			if (!Timer.UseNetCoreTimer)
			{
				return this.NetFxTimer.Change(dueTime, period);
			}
			return this.NetCoreTimer.Change(dueTime, period);
		}

		// Token: 0x06003E4C RID: 15948 RVA: 0x000E8536 File Offset: 0x000E6736
		public void Close()
		{
			if (Timer.UseNetCoreTimer)
			{
				this.NetCoreTimer.Close();
			}
			else
			{
				this.NetFxTimer.Close();
			}
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003E4D RID: 15949 RVA: 0x000E8560 File Offset: 0x000E6760
		public bool Close(WaitHandle notifyObject)
		{
			bool result = Timer.UseNetCoreTimer ? this.NetCoreTimer.Close(notifyObject) : this.NetFxTimer.Close(notifyObject);
			GC.SuppressFinalize(this);
			return result;
		}

		// Token: 0x04001A3E RID: 6718
		private object m_timer;
	}
}
