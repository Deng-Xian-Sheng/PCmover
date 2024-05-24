using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace System.Threading
{
	// Token: 0x02000541 RID: 1345
	[ComVisible(false)]
	[DebuggerDisplay("Current Count = {m_currentCount}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class SemaphoreSlim : IDisposable
	{
		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x06003EFE RID: 16126 RVA: 0x000EA6A1 File Offset: 0x000E88A1
		[__DynamicallyInvokable]
		public int CurrentCount
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_currentCount;
			}
		}

		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x06003EFF RID: 16127 RVA: 0x000EA6AC File Offset: 0x000E88AC
		[__DynamicallyInvokable]
		public WaitHandle AvailableWaitHandle
		{
			[__DynamicallyInvokable]
			get
			{
				this.CheckDispose();
				if (this.m_waitHandle != null)
				{
					return this.m_waitHandle;
				}
				object lockObj = this.m_lockObj;
				lock (lockObj)
				{
					if (this.m_waitHandle == null)
					{
						this.m_waitHandle = new ManualResetEvent(this.m_currentCount != 0);
					}
				}
				return this.m_waitHandle;
			}
		}

		// Token: 0x06003F00 RID: 16128 RVA: 0x000EA72C File Offset: 0x000E892C
		[__DynamicallyInvokable]
		public SemaphoreSlim(int initialCount) : this(initialCount, int.MaxValue)
		{
		}

		// Token: 0x06003F01 RID: 16129 RVA: 0x000EA73C File Offset: 0x000E893C
		[__DynamicallyInvokable]
		public SemaphoreSlim(int initialCount, int maxCount)
		{
			if (initialCount < 0 || initialCount > maxCount)
			{
				throw new ArgumentOutOfRangeException("initialCount", initialCount, SemaphoreSlim.GetResourceString("SemaphoreSlim_ctor_InitialCountWrong"));
			}
			if (maxCount <= 0)
			{
				throw new ArgumentOutOfRangeException("maxCount", maxCount, SemaphoreSlim.GetResourceString("SemaphoreSlim_ctor_MaxCountWrong"));
			}
			this.m_maxCount = maxCount;
			this.m_lockObj = new object();
			this.m_currentCount = initialCount;
		}

		// Token: 0x06003F02 RID: 16130 RVA: 0x000EA7AC File Offset: 0x000E89AC
		[__DynamicallyInvokable]
		public void Wait()
		{
			this.Wait(-1, default(CancellationToken));
		}

		// Token: 0x06003F03 RID: 16131 RVA: 0x000EA7CA File Offset: 0x000E89CA
		[__DynamicallyInvokable]
		public void Wait(CancellationToken cancellationToken)
		{
			this.Wait(-1, cancellationToken);
		}

		// Token: 0x06003F04 RID: 16132 RVA: 0x000EA7D8 File Offset: 0x000E89D8
		[__DynamicallyInvokable]
		public bool Wait(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			return this.Wait((int)timeout.TotalMilliseconds, default(CancellationToken));
		}

		// Token: 0x06003F05 RID: 16133 RVA: 0x000EA830 File Offset: 0x000E8A30
		[__DynamicallyInvokable]
		public bool Wait(TimeSpan timeout, CancellationToken cancellationToken)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			return this.Wait((int)timeout.TotalMilliseconds, cancellationToken);
		}

		// Token: 0x06003F06 RID: 16134 RVA: 0x000EA880 File Offset: 0x000E8A80
		[__DynamicallyInvokable]
		public bool Wait(int millisecondsTimeout)
		{
			return this.Wait(millisecondsTimeout, default(CancellationToken));
		}

		// Token: 0x06003F07 RID: 16135 RVA: 0x000EA8A0 File Offset: 0x000E8AA0
		[__DynamicallyInvokable]
		public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken)
		{
			this.CheckDispose();
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("totalMilliSeconds", millisecondsTimeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			cancellationToken.ThrowIfCancellationRequested();
			uint startTime = 0U;
			if (millisecondsTimeout != -1 && millisecondsTimeout > 0)
			{
				startTime = TimeoutHelper.GetTime();
			}
			bool result = false;
			Task<bool> task = null;
			bool flag = false;
			CancellationTokenRegistration cancellationTokenRegistration = cancellationToken.InternalRegisterWithoutEC(SemaphoreSlim.s_cancellationTokenCanceledEventHandler, this);
			try
			{
				SpinWait spinWait = default(SpinWait);
				while (this.m_currentCount == 0 && !spinWait.NextSpinWillYield)
				{
					spinWait.SpinOnce();
				}
				try
				{
				}
				finally
				{
					Monitor.Enter(this.m_lockObj, ref flag);
					if (flag)
					{
						this.m_waitCount++;
					}
				}
				if (this.m_asyncHead != null)
				{
					task = this.WaitAsync(millisecondsTimeout, cancellationToken);
				}
				else
				{
					OperationCanceledException ex = null;
					if (this.m_currentCount == 0)
					{
						if (millisecondsTimeout == 0)
						{
							return false;
						}
						try
						{
							result = this.WaitUntilCountOrTimeout(millisecondsTimeout, startTime, cancellationToken);
						}
						catch (OperationCanceledException ex2)
						{
							ex = ex2;
						}
					}
					if (this.m_currentCount > 0)
					{
						result = true;
						this.m_currentCount--;
					}
					else if (ex != null)
					{
						throw ex;
					}
					if (this.m_waitHandle != null && this.m_currentCount == 0)
					{
						this.m_waitHandle.Reset();
					}
				}
			}
			finally
			{
				if (flag)
				{
					this.m_waitCount--;
					Monitor.Exit(this.m_lockObj);
				}
				cancellationTokenRegistration.Dispose();
			}
			if (task == null)
			{
				return result;
			}
			return task.GetAwaiter().GetResult();
		}

		// Token: 0x06003F08 RID: 16136 RVA: 0x000EAA40 File Offset: 0x000E8C40
		private bool WaitUntilCountOrTimeout(int millisecondsTimeout, uint startTime, CancellationToken cancellationToken)
		{
			int num = -1;
			while (this.m_currentCount == 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (millisecondsTimeout != -1)
				{
					num = TimeoutHelper.UpdateTimeOut(startTime, millisecondsTimeout);
					if (num <= 0)
					{
						return false;
					}
				}
				if (!Monitor.Wait(this.m_lockObj, num))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06003F09 RID: 16137 RVA: 0x000EAA88 File Offset: 0x000E8C88
		[__DynamicallyInvokable]
		public Task WaitAsync()
		{
			return this.WaitAsync(-1, default(CancellationToken));
		}

		// Token: 0x06003F0A RID: 16138 RVA: 0x000EAAA5 File Offset: 0x000E8CA5
		[__DynamicallyInvokable]
		public Task WaitAsync(CancellationToken cancellationToken)
		{
			return this.WaitAsync(-1, cancellationToken);
		}

		// Token: 0x06003F0B RID: 16139 RVA: 0x000EAAB0 File Offset: 0x000E8CB0
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(int millisecondsTimeout)
		{
			return this.WaitAsync(millisecondsTimeout, default(CancellationToken));
		}

		// Token: 0x06003F0C RID: 16140 RVA: 0x000EAAD0 File Offset: 0x000E8CD0
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(TimeSpan timeout)
		{
			return this.WaitAsync(timeout, default(CancellationToken));
		}

		// Token: 0x06003F0D RID: 16141 RVA: 0x000EAAF0 File Offset: 0x000E8CF0
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			return this.WaitAsync((int)timeout.TotalMilliseconds, cancellationToken);
		}

		// Token: 0x06003F0E RID: 16142 RVA: 0x000EAB40 File Offset: 0x000E8D40
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(int millisecondsTimeout, CancellationToken cancellationToken)
		{
			this.CheckDispose();
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("totalMilliSeconds", millisecondsTimeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCancellation<bool>(cancellationToken);
			}
			object lockObj = this.m_lockObj;
			Task<bool> result;
			lock (lockObj)
			{
				if (this.m_currentCount > 0)
				{
					this.m_currentCount--;
					if (this.m_waitHandle != null && this.m_currentCount == 0)
					{
						this.m_waitHandle.Reset();
					}
					result = SemaphoreSlim.s_trueTask;
				}
				else
				{
					SemaphoreSlim.TaskNode taskNode = this.CreateAndAddAsyncWaiter();
					result = ((millisecondsTimeout == -1 && !cancellationToken.CanBeCanceled) ? taskNode : this.WaitUntilCountOrTimeoutAsync(taskNode, millisecondsTimeout, cancellationToken));
				}
			}
			return result;
		}

		// Token: 0x06003F0F RID: 16143 RVA: 0x000EAC18 File Offset: 0x000E8E18
		private SemaphoreSlim.TaskNode CreateAndAddAsyncWaiter()
		{
			SemaphoreSlim.TaskNode taskNode = new SemaphoreSlim.TaskNode();
			if (this.m_asyncHead == null)
			{
				this.m_asyncHead = taskNode;
				this.m_asyncTail = taskNode;
			}
			else
			{
				this.m_asyncTail.Next = taskNode;
				taskNode.Prev = this.m_asyncTail;
				this.m_asyncTail = taskNode;
			}
			return taskNode;
		}

		// Token: 0x06003F10 RID: 16144 RVA: 0x000EAC64 File Offset: 0x000E8E64
		private bool RemoveAsyncWaiter(SemaphoreSlim.TaskNode task)
		{
			bool result = this.m_asyncHead == task || task.Prev != null;
			if (task.Next != null)
			{
				task.Next.Prev = task.Prev;
			}
			if (task.Prev != null)
			{
				task.Prev.Next = task.Next;
			}
			if (this.m_asyncHead == task)
			{
				this.m_asyncHead = task.Next;
			}
			if (this.m_asyncTail == task)
			{
				this.m_asyncTail = task.Prev;
			}
			task.Next = (task.Prev = null);
			return result;
		}

		// Token: 0x06003F11 RID: 16145 RVA: 0x000EACF4 File Offset: 0x000E8EF4
		private Task<bool> WaitUntilCountOrTimeoutAsync(SemaphoreSlim.TaskNode asyncWaiter, int millisecondsTimeout, CancellationToken cancellationToken)
		{
			SemaphoreSlim.<WaitUntilCountOrTimeoutAsync>d__31 <WaitUntilCountOrTimeoutAsync>d__;
			<WaitUntilCountOrTimeoutAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<WaitUntilCountOrTimeoutAsync>d__.<>4__this = this;
			<WaitUntilCountOrTimeoutAsync>d__.asyncWaiter = asyncWaiter;
			<WaitUntilCountOrTimeoutAsync>d__.millisecondsTimeout = millisecondsTimeout;
			<WaitUntilCountOrTimeoutAsync>d__.cancellationToken = cancellationToken;
			<WaitUntilCountOrTimeoutAsync>d__.<>1__state = -1;
			<WaitUntilCountOrTimeoutAsync>d__.<>t__builder.Start<SemaphoreSlim.<WaitUntilCountOrTimeoutAsync>d__31>(ref <WaitUntilCountOrTimeoutAsync>d__);
			return <WaitUntilCountOrTimeoutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06003F12 RID: 16146 RVA: 0x000EAD4F File Offset: 0x000E8F4F
		[__DynamicallyInvokable]
		public int Release()
		{
			return this.Release(1);
		}

		// Token: 0x06003F13 RID: 16147 RVA: 0x000EAD58 File Offset: 0x000E8F58
		[__DynamicallyInvokable]
		public int Release(int releaseCount)
		{
			this.CheckDispose();
			if (releaseCount < 1)
			{
				throw new ArgumentOutOfRangeException("releaseCount", releaseCount, SemaphoreSlim.GetResourceString("SemaphoreSlim_Release_CountWrong"));
			}
			object lockObj = this.m_lockObj;
			int num2;
			lock (lockObj)
			{
				int num = this.m_currentCount;
				num2 = num;
				if (this.m_maxCount - num < releaseCount)
				{
					throw new SemaphoreFullException();
				}
				num += releaseCount;
				int waitCount = this.m_waitCount;
				if (num == 1 || waitCount == 1)
				{
					Monitor.Pulse(this.m_lockObj);
				}
				else if (waitCount > 1)
				{
					Monitor.PulseAll(this.m_lockObj);
				}
				if (this.m_asyncHead != null)
				{
					int num3 = num - waitCount;
					while (num3 > 0 && this.m_asyncHead != null)
					{
						num--;
						num3--;
						SemaphoreSlim.TaskNode asyncHead = this.m_asyncHead;
						this.RemoveAsyncWaiter(asyncHead);
						SemaphoreSlim.QueueWaiterTask(asyncHead);
					}
				}
				this.m_currentCount = num;
				if (this.m_waitHandle != null && num2 == 0 && num > 0)
				{
					this.m_waitHandle.Set();
				}
			}
			return num2;
		}

		// Token: 0x06003F14 RID: 16148 RVA: 0x000EAE70 File Offset: 0x000E9070
		[SecuritySafeCritical]
		private static void QueueWaiterTask(SemaphoreSlim.TaskNode waiterTask)
		{
			ThreadPool.UnsafeQueueCustomWorkItem(waiterTask, false);
		}

		// Token: 0x06003F15 RID: 16149 RVA: 0x000EAE79 File Offset: 0x000E9079
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003F16 RID: 16150 RVA: 0x000EAE88 File Offset: 0x000E9088
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.m_waitHandle != null)
				{
					this.m_waitHandle.Close();
					this.m_waitHandle = null;
				}
				this.m_lockObj = null;
				this.m_asyncHead = null;
				this.m_asyncTail = null;
			}
		}

		// Token: 0x06003F17 RID: 16151 RVA: 0x000EAEC4 File Offset: 0x000E90C4
		private static void CancellationTokenCanceledEventHandler(object obj)
		{
			SemaphoreSlim semaphoreSlim = obj as SemaphoreSlim;
			object lockObj = semaphoreSlim.m_lockObj;
			lock (lockObj)
			{
				Monitor.PulseAll(semaphoreSlim.m_lockObj);
			}
		}

		// Token: 0x06003F18 RID: 16152 RVA: 0x000EAF10 File Offset: 0x000E9110
		private void CheckDispose()
		{
			if (this.m_lockObj == null)
			{
				throw new ObjectDisposedException(null, SemaphoreSlim.GetResourceString("SemaphoreSlim_Disposed"));
			}
		}

		// Token: 0x06003F19 RID: 16153 RVA: 0x000EAF2B File Offset: 0x000E912B
		private static string GetResourceString(string str)
		{
			return Environment.GetResourceString(str);
		}

		// Token: 0x04001A79 RID: 6777
		private volatile int m_currentCount;

		// Token: 0x04001A7A RID: 6778
		private readonly int m_maxCount;

		// Token: 0x04001A7B RID: 6779
		private volatile int m_waitCount;

		// Token: 0x04001A7C RID: 6780
		private object m_lockObj;

		// Token: 0x04001A7D RID: 6781
		private volatile ManualResetEvent m_waitHandle;

		// Token: 0x04001A7E RID: 6782
		private SemaphoreSlim.TaskNode m_asyncHead;

		// Token: 0x04001A7F RID: 6783
		private SemaphoreSlim.TaskNode m_asyncTail;

		// Token: 0x04001A80 RID: 6784
		private static readonly Task<bool> s_trueTask = new Task<bool>(false, true, (TaskCreationOptions)16384, default(CancellationToken));

		// Token: 0x04001A81 RID: 6785
		private const int NO_MAXIMUM = 2147483647;

		// Token: 0x04001A82 RID: 6786
		private static Action<object> s_cancellationTokenCanceledEventHandler = new Action<object>(SemaphoreSlim.CancellationTokenCanceledEventHandler);

		// Token: 0x02000BFE RID: 3070
		private sealed class TaskNode : Task<bool>, IThreadPoolWorkItem
		{
			// Token: 0x06006F89 RID: 28553 RVA: 0x001808AC File Offset: 0x0017EAAC
			internal TaskNode()
			{
			}

			// Token: 0x06006F8A RID: 28554 RVA: 0x001808B4 File Offset: 0x0017EAB4
			[SecurityCritical]
			void IThreadPoolWorkItem.ExecuteWorkItem()
			{
				bool flag = base.TrySetResult(true);
			}

			// Token: 0x06006F8B RID: 28555 RVA: 0x001808C9 File Offset: 0x0017EAC9
			[SecurityCritical]
			void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae)
			{
			}

			// Token: 0x04003646 RID: 13894
			internal SemaphoreSlim.TaskNode Prev;

			// Token: 0x04003647 RID: 13895
			internal SemaphoreSlim.TaskNode Next;
		}
	}
}
