using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x02000550 RID: 1360
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public static class Parallel
	{
		// Token: 0x06004010 RID: 16400 RVA: 0x000EE288 File Offset: 0x000EC488
		[__DynamicallyInvokable]
		public static void Invoke(params Action[] actions)
		{
			Parallel.Invoke(Parallel.s_defaultParallelOptions, actions);
		}

		// Token: 0x06004011 RID: 16401 RVA: 0x000EE298 File Offset: 0x000EC498
		[__DynamicallyInvokable]
		public static void Invoke(ParallelOptions parallelOptions, params Action[] actions)
		{
			if (actions == null)
			{
				throw new ArgumentNullException("actions");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			if (parallelOptions.CancellationToken.CanBeCanceled && AppContextSwitches.ThrowExceptionIfDisposedCancellationTokenSource)
			{
				parallelOptions.CancellationToken.ThrowIfSourceDisposed();
			}
			if (parallelOptions.CancellationToken.IsCancellationRequested)
			{
				throw new OperationCanceledException(parallelOptions.CancellationToken);
			}
			Action[] actionsCopy = new Action[actions.Length];
			for (int i = 0; i < actionsCopy.Length; i++)
			{
				actionsCopy[i] = actions[i];
				if (actionsCopy[i] == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Parallel_Invoke_ActionNull"));
				}
			}
			int forkJoinContextID = 0;
			Task task = null;
			if (TplEtwProvider.Log.IsEnabled())
			{
				forkJoinContextID = Interlocked.Increment(ref Parallel.s_forkJoinContextID);
				task = Task.InternalCurrent;
				TplEtwProvider.Log.ParallelInvokeBegin((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, TplEtwProvider.ForkJoinOperationType.ParallelInvoke, actionsCopy.Length);
			}
			if (actionsCopy.Length < 1)
			{
				return;
			}
			try
			{
				if (actionsCopy.Length > 10 || (parallelOptions.MaxDegreeOfParallelism != -1 && parallelOptions.MaxDegreeOfParallelism < actionsCopy.Length))
				{
					ConcurrentQueue<Exception> exceptionQ = null;
					try
					{
						int actionIndex = 0;
						ParallelForReplicatingTask parallelForReplicatingTask = new ParallelForReplicatingTask(parallelOptions, delegate()
						{
							for (int l = Interlocked.Increment(ref actionIndex); l <= actionsCopy.Length; l = Interlocked.Increment(ref actionIndex))
							{
								try
								{
									actionsCopy[l - 1]();
								}
								catch (Exception item2)
								{
									LazyInitializer.EnsureInitialized<ConcurrentQueue<Exception>>(ref exceptionQ, () => new ConcurrentQueue<Exception>());
									exceptionQ.Enqueue(item2);
								}
								if (parallelOptions.CancellationToken.IsCancellationRequested)
								{
									throw new OperationCanceledException(parallelOptions.CancellationToken);
								}
							}
						}, TaskCreationOptions.None, InternalTaskOptions.SelfReplicating);
						parallelForReplicatingTask.RunSynchronously(parallelOptions.EffectiveTaskScheduler);
						parallelForReplicatingTask.Wait();
					}
					catch (Exception ex)
					{
						LazyInitializer.EnsureInitialized<ConcurrentQueue<Exception>>(ref exceptionQ, () => new ConcurrentQueue<Exception>());
						AggregateException ex2 = ex as AggregateException;
						if (ex2 != null)
						{
							using (IEnumerator<Exception> enumerator = ex2.InnerExceptions.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									Exception item = enumerator.Current;
									exceptionQ.Enqueue(item);
								}
								goto IL_23C;
							}
						}
						exceptionQ.Enqueue(ex);
						IL_23C:;
					}
					if (exceptionQ != null && exceptionQ.Count > 0)
					{
						Parallel.ThrowIfReducableToSingleOCE(exceptionQ, parallelOptions.CancellationToken);
						throw new AggregateException(exceptionQ);
					}
				}
				else
				{
					Task[] array = new Task[actionsCopy.Length];
					if (parallelOptions.CancellationToken.IsCancellationRequested)
					{
						throw new OperationCanceledException(parallelOptions.CancellationToken);
					}
					for (int j = 1; j < array.Length; j++)
					{
						array[j] = Task.Factory.StartNew(actionsCopy[j], parallelOptions.CancellationToken, TaskCreationOptions.None, InternalTaskOptions.None, parallelOptions.EffectiveTaskScheduler);
					}
					array[0] = new Task(actionsCopy[0]);
					array[0].RunSynchronously(parallelOptions.EffectiveTaskScheduler);
					try
					{
						if (array.Length <= 4)
						{
							Task.FastWaitAll(array);
						}
						else
						{
							Task.WaitAll(array);
						}
					}
					catch (AggregateException ex3)
					{
						Parallel.ThrowIfReducableToSingleOCE(ex3.InnerExceptions, parallelOptions.CancellationToken);
						throw;
					}
					finally
					{
						for (int k = 0; k < array.Length; k++)
						{
							if (array[k].IsCompleted)
							{
								array[k].Dispose();
							}
						}
					}
				}
			}
			finally
			{
				if (TplEtwProvider.Log.IsEnabled())
				{
					TplEtwProvider.Log.ParallelInvokeEnd((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID);
				}
			}
		}

		// Token: 0x06004012 RID: 16402 RVA: 0x000EE6DC File Offset: 0x000EC8DC
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(int fromInclusive, int toExclusive, Action<int> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForWorker<object>(fromInclusive, toExclusive, Parallel.s_defaultParallelOptions, body, null, null, null, null);
		}

		// Token: 0x06004013 RID: 16403 RVA: 0x000EE6FD File Offset: 0x000EC8FD
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(long fromInclusive, long toExclusive, Action<long> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForWorker64<object>(fromInclusive, toExclusive, Parallel.s_defaultParallelOptions, body, null, null, null, null);
		}

		// Token: 0x06004014 RID: 16404 RVA: 0x000EE71E File Offset: 0x000EC91E
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Action<int> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForWorker<object>(fromInclusive, toExclusive, parallelOptions, body, null, null, null, null);
		}

		// Token: 0x06004015 RID: 16405 RVA: 0x000EE749 File Offset: 0x000EC949
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, Action<long> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForWorker64<object>(fromInclusive, toExclusive, parallelOptions, body, null, null, null, null);
		}

		// Token: 0x06004016 RID: 16406 RVA: 0x000EE774 File Offset: 0x000EC974
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(int fromInclusive, int toExclusive, Action<int, ParallelLoopState> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForWorker<object>(fromInclusive, toExclusive, Parallel.s_defaultParallelOptions, null, body, null, null, null);
		}

		// Token: 0x06004017 RID: 16407 RVA: 0x000EE795 File Offset: 0x000EC995
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(long fromInclusive, long toExclusive, Action<long, ParallelLoopState> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForWorker64<object>(fromInclusive, toExclusive, Parallel.s_defaultParallelOptions, null, body, null, null, null);
		}

		// Token: 0x06004018 RID: 16408 RVA: 0x000EE7B6 File Offset: 0x000EC9B6
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Action<int, ParallelLoopState> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForWorker<object>(fromInclusive, toExclusive, parallelOptions, null, body, null, null, null);
		}

		// Token: 0x06004019 RID: 16409 RVA: 0x000EE7E1 File Offset: 0x000EC9E1
		[__DynamicallyInvokable]
		public static ParallelLoopResult For(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, Action<long, ParallelLoopState> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForWorker64<object>(fromInclusive, toExclusive, parallelOptions, null, body, null, null, null);
		}

		// Token: 0x0600401A RID: 16410 RVA: 0x000EE80C File Offset: 0x000ECA0C
		[__DynamicallyInvokable]
		public static ParallelLoopResult For<TLocal>(int fromInclusive, int toExclusive, Func<TLocal> localInit, Func<int, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			return Parallel.ForWorker<TLocal>(fromInclusive, toExclusive, Parallel.s_defaultParallelOptions, null, null, body, localInit, localFinally);
		}

		// Token: 0x0600401B RID: 16411 RVA: 0x000EE84B File Offset: 0x000ECA4B
		[__DynamicallyInvokable]
		public static ParallelLoopResult For<TLocal>(long fromInclusive, long toExclusive, Func<TLocal> localInit, Func<long, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			return Parallel.ForWorker64<TLocal>(fromInclusive, toExclusive, Parallel.s_defaultParallelOptions, null, null, body, localInit, localFinally);
		}

		// Token: 0x0600401C RID: 16412 RVA: 0x000EE88C File Offset: 0x000ECA8C
		[__DynamicallyInvokable]
		public static ParallelLoopResult For<TLocal>(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Func<TLocal> localInit, Func<int, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForWorker<TLocal>(fromInclusive, toExclusive, parallelOptions, null, null, body, localInit, localFinally);
		}

		// Token: 0x0600401D RID: 16413 RVA: 0x000EE8E4 File Offset: 0x000ECAE4
		[__DynamicallyInvokable]
		public static ParallelLoopResult For<TLocal>(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, Func<TLocal> localInit, Func<long, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForWorker64<TLocal>(fromInclusive, toExclusive, parallelOptions, null, null, body, localInit, localFinally);
		}

		// Token: 0x0600401E RID: 16414 RVA: 0x000EE93C File Offset: 0x000ECB3C
		private static ParallelLoopResult ForWorker<TLocal>(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Action<int> body, Action<int, ParallelLoopState> bodyWithState, Func<int, ParallelLoopState, TLocal, TLocal> bodyWithLocal, Func<TLocal> localInit, Action<TLocal> localFinally)
		{
			ParallelLoopResult result = default(ParallelLoopResult);
			if (toExclusive <= fromInclusive)
			{
				result.m_completed = true;
				return result;
			}
			ParallelLoopStateFlags32 sharedPStateFlags = new ParallelLoopStateFlags32();
			TaskCreationOptions creationOptions = TaskCreationOptions.None;
			InternalTaskOptions internalOptions = InternalTaskOptions.SelfReplicating;
			if (parallelOptions.CancellationToken.IsCancellationRequested)
			{
				throw new OperationCanceledException(parallelOptions.CancellationToken);
			}
			int nNumExpectedWorkers = (parallelOptions.EffectiveMaxConcurrencyLevel == -1) ? PlatformHelper.ProcessorCount : parallelOptions.EffectiveMaxConcurrencyLevel;
			RangeManager rangeManager = new RangeManager((long)fromInclusive, (long)toExclusive, 1L, nNumExpectedWorkers);
			OperationCanceledException oce = null;
			CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
			if (parallelOptions.CancellationToken.CanBeCanceled)
			{
				cancellationTokenRegistration = parallelOptions.CancellationToken.InternalRegisterWithoutEC(delegate(object o)
				{
					sharedPStateFlags.Cancel();
					oce = new OperationCanceledException(parallelOptions.CancellationToken);
				}, null);
			}
			int forkJoinContextID = 0;
			Task task = null;
			if (TplEtwProvider.Log.IsEnabled())
			{
				forkJoinContextID = Interlocked.Increment(ref Parallel.s_forkJoinContextID);
				task = Task.InternalCurrent;
				TplEtwProvider.Log.ParallelLoopBegin((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, TplEtwProvider.ForkJoinOperationType.ParallelFor, (long)fromInclusive, (long)toExclusive);
			}
			ParallelForReplicatingTask rootTask = null;
			try
			{
				rootTask = new ParallelForReplicatingTask(parallelOptions, delegate()
				{
					Task internalCurrent = Task.InternalCurrent;
					bool flag = internalCurrent == rootTask;
					RangeWorker rangeWorker = default(RangeWorker);
					object savedStateFromPreviousReplica = internalCurrent.SavedStateFromPreviousReplica;
					if (savedStateFromPreviousReplica is RangeWorker)
					{
						rangeWorker = (RangeWorker)savedStateFromPreviousReplica;
					}
					else
					{
						rangeWorker = rangeManager.RegisterNewWorker();
					}
					int num2;
					int num3;
					if (!rangeWorker.FindNewWork32(out num2, out num3) || sharedPStateFlags.ShouldExitLoop(num2))
					{
						return;
					}
					if (TplEtwProvider.Log.IsEnabled())
					{
						TplEtwProvider.Log.ParallelFork((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, forkJoinContextID);
					}
					TLocal tlocal = default(TLocal);
					bool flag2 = false;
					try
					{
						ParallelLoopState32 parallelLoopState = null;
						if (bodyWithState != null)
						{
							parallelLoopState = new ParallelLoopState32(sharedPStateFlags);
						}
						else if (bodyWithLocal != null)
						{
							parallelLoopState = new ParallelLoopState32(sharedPStateFlags);
							if (localInit != null)
							{
								tlocal = localInit();
								flag2 = true;
							}
						}
						Parallel.LoopTimer loopTimer = new Parallel.LoopTimer(rootTask.ActiveChildCount);
						for (;;)
						{
							if (body != null)
							{
								for (int i = num2; i < num3; i++)
								{
									if (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE && sharedPStateFlags.ShouldExitLoop())
									{
										break;
									}
									body(i);
								}
							}
							else if (bodyWithState != null)
							{
								for (int j = num2; j < num3; j++)
								{
									if (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE && sharedPStateFlags.ShouldExitLoop(j))
									{
										break;
									}
									parallelLoopState.CurrentIteration = j;
									bodyWithState(j, parallelLoopState);
								}
							}
							else
							{
								int num4 = num2;
								while (num4 < num3 && (sharedPStateFlags.LoopStateFlags == ParallelLoopStateFlags.PLS_NONE || !sharedPStateFlags.ShouldExitLoop(num4)))
								{
									parallelLoopState.CurrentIteration = num4;
									tlocal = bodyWithLocal(num4, parallelLoopState, tlocal);
									num4++;
								}
							}
							if (!flag && loopTimer.LimitExceeded())
							{
								break;
							}
							if (!rangeWorker.FindNewWork32(out num2, out num3) || (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE && sharedPStateFlags.ShouldExitLoop(num2)))
							{
								goto IL_23F;
							}
						}
						internalCurrent.SavedStateForNextReplica = rangeWorker;
						IL_23F:;
					}
					catch
					{
						sharedPStateFlags.SetExceptional();
						throw;
					}
					finally
					{
						if (localFinally != null && flag2)
						{
							localFinally(tlocal);
						}
						if (TplEtwProvider.Log.IsEnabled())
						{
							TplEtwProvider.Log.ParallelJoin((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, forkJoinContextID);
						}
					}
				}, creationOptions, internalOptions);
				rootTask.RunSynchronously(parallelOptions.EffectiveTaskScheduler);
				rootTask.Wait();
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				if (oce != null)
				{
					throw oce;
				}
			}
			catch (AggregateException ex)
			{
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				Parallel.ThrowIfReducableToSingleOCE(ex.InnerExceptions, parallelOptions.CancellationToken);
				throw;
			}
			catch (TaskSchedulerException)
			{
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				throw;
			}
			finally
			{
				int loopStateFlags = sharedPStateFlags.LoopStateFlags;
				result.m_completed = (loopStateFlags == ParallelLoopStateFlags.PLS_NONE);
				if ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0)
				{
					result.m_lowestBreakIteration = new long?((long)sharedPStateFlags.LowestBreakIteration);
				}
				if (rootTask != null && rootTask.IsCompleted)
				{
					rootTask.Dispose();
				}
				if (TplEtwProvider.Log.IsEnabled())
				{
					int num;
					if (loopStateFlags == ParallelLoopStateFlags.PLS_NONE)
					{
						num = toExclusive - fromInclusive;
					}
					else if ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0)
					{
						num = sharedPStateFlags.LowestBreakIteration - fromInclusive;
					}
					else
					{
						num = -1;
					}
					TplEtwProvider.Log.ParallelLoopEnd((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, (long)num);
				}
			}
			return result;
		}

		// Token: 0x0600401F RID: 16415 RVA: 0x000EEC8C File Offset: 0x000ECE8C
		private static ParallelLoopResult ForWorker64<TLocal>(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, Action<long> body, Action<long, ParallelLoopState> bodyWithState, Func<long, ParallelLoopState, TLocal, TLocal> bodyWithLocal, Func<TLocal> localInit, Action<TLocal> localFinally)
		{
			ParallelLoopResult result = default(ParallelLoopResult);
			if (toExclusive <= fromInclusive)
			{
				result.m_completed = true;
				return result;
			}
			ParallelLoopStateFlags64 sharedPStateFlags = new ParallelLoopStateFlags64();
			TaskCreationOptions creationOptions = TaskCreationOptions.None;
			InternalTaskOptions internalOptions = InternalTaskOptions.SelfReplicating;
			if (parallelOptions.CancellationToken.IsCancellationRequested)
			{
				throw new OperationCanceledException(parallelOptions.CancellationToken);
			}
			int nNumExpectedWorkers = (parallelOptions.EffectiveMaxConcurrencyLevel == -1) ? PlatformHelper.ProcessorCount : parallelOptions.EffectiveMaxConcurrencyLevel;
			RangeManager rangeManager = new RangeManager(fromInclusive, toExclusive, 1L, nNumExpectedWorkers);
			OperationCanceledException oce = null;
			CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
			if (parallelOptions.CancellationToken.CanBeCanceled)
			{
				cancellationTokenRegistration = parallelOptions.CancellationToken.InternalRegisterWithoutEC(delegate(object o)
				{
					sharedPStateFlags.Cancel();
					oce = new OperationCanceledException(parallelOptions.CancellationToken);
				}, null);
			}
			Task task = null;
			int forkJoinContextID = 0;
			if (TplEtwProvider.Log.IsEnabled())
			{
				forkJoinContextID = Interlocked.Increment(ref Parallel.s_forkJoinContextID);
				task = Task.InternalCurrent;
				TplEtwProvider.Log.ParallelLoopBegin((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, TplEtwProvider.ForkJoinOperationType.ParallelFor, fromInclusive, toExclusive);
			}
			ParallelForReplicatingTask rootTask = null;
			try
			{
				rootTask = new ParallelForReplicatingTask(parallelOptions, delegate()
				{
					Task internalCurrent = Task.InternalCurrent;
					bool flag = internalCurrent == rootTask;
					RangeWorker rangeWorker = default(RangeWorker);
					object savedStateFromPreviousReplica = internalCurrent.SavedStateFromPreviousReplica;
					if (savedStateFromPreviousReplica is RangeWorker)
					{
						rangeWorker = (RangeWorker)savedStateFromPreviousReplica;
					}
					else
					{
						rangeWorker = rangeManager.RegisterNewWorker();
					}
					long num;
					long num2;
					if (!rangeWorker.FindNewWork(out num, out num2) || sharedPStateFlags.ShouldExitLoop(num))
					{
						return;
					}
					if (TplEtwProvider.Log.IsEnabled())
					{
						TplEtwProvider.Log.ParallelFork((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, forkJoinContextID);
					}
					TLocal tlocal = default(TLocal);
					bool flag2 = false;
					try
					{
						ParallelLoopState64 parallelLoopState = null;
						if (bodyWithState != null)
						{
							parallelLoopState = new ParallelLoopState64(sharedPStateFlags);
						}
						else if (bodyWithLocal != null)
						{
							parallelLoopState = new ParallelLoopState64(sharedPStateFlags);
							if (localInit != null)
							{
								tlocal = localInit();
								flag2 = true;
							}
						}
						Parallel.LoopTimer loopTimer = new Parallel.LoopTimer(rootTask.ActiveChildCount);
						for (;;)
						{
							if (body != null)
							{
								for (long num3 = num; num3 < num2; num3 += 1L)
								{
									if (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE && sharedPStateFlags.ShouldExitLoop())
									{
										break;
									}
									body(num3);
								}
							}
							else if (bodyWithState != null)
							{
								for (long num4 = num; num4 < num2; num4 += 1L)
								{
									if (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE && sharedPStateFlags.ShouldExitLoop(num4))
									{
										break;
									}
									parallelLoopState.CurrentIteration = num4;
									bodyWithState(num4, parallelLoopState);
								}
							}
							else
							{
								long num5 = num;
								while (num5 < num2 && (sharedPStateFlags.LoopStateFlags == ParallelLoopStateFlags.PLS_NONE || !sharedPStateFlags.ShouldExitLoop(num5)))
								{
									parallelLoopState.CurrentIteration = num5;
									tlocal = bodyWithLocal(num5, parallelLoopState, tlocal);
									num5 += 1L;
								}
							}
							if (!flag && loopTimer.LimitExceeded())
							{
								break;
							}
							if (!rangeWorker.FindNewWork(out num, out num2) || (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE && sharedPStateFlags.ShouldExitLoop(num)))
							{
								goto IL_242;
							}
						}
						internalCurrent.SavedStateForNextReplica = rangeWorker;
						IL_242:;
					}
					catch
					{
						sharedPStateFlags.SetExceptional();
						throw;
					}
					finally
					{
						if (localFinally != null && flag2)
						{
							localFinally(tlocal);
						}
						if (TplEtwProvider.Log.IsEnabled())
						{
							TplEtwProvider.Log.ParallelJoin((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, forkJoinContextID);
						}
					}
				}, creationOptions, internalOptions);
				rootTask.RunSynchronously(parallelOptions.EffectiveTaskScheduler);
				rootTask.Wait();
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				if (oce != null)
				{
					throw oce;
				}
			}
			catch (AggregateException ex)
			{
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				Parallel.ThrowIfReducableToSingleOCE(ex.InnerExceptions, parallelOptions.CancellationToken);
				throw;
			}
			catch (TaskSchedulerException)
			{
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				throw;
			}
			finally
			{
				int loopStateFlags = sharedPStateFlags.LoopStateFlags;
				result.m_completed = (loopStateFlags == ParallelLoopStateFlags.PLS_NONE);
				if ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0)
				{
					result.m_lowestBreakIteration = new long?(sharedPStateFlags.LowestBreakIteration);
				}
				if (rootTask != null && rootTask.IsCompleted)
				{
					rootTask.Dispose();
				}
				if (TplEtwProvider.Log.IsEnabled())
				{
					long totalIterations;
					if (loopStateFlags == ParallelLoopStateFlags.PLS_NONE)
					{
						totalIterations = toExclusive - fromInclusive;
					}
					else if ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0)
					{
						totalIterations = sharedPStateFlags.LowestBreakIteration - fromInclusive;
					}
					else
					{
						totalIterations = -1L;
					}
					TplEtwProvider.Log.ParallelLoopEnd((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, totalIterations);
				}
			}
			return result;
		}

		// Token: 0x06004020 RID: 16416 RVA: 0x000EEFD8 File Offset: 0x000ED1D8
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForEachWorker<TSource, object>(source, Parallel.s_defaultParallelOptions, body, null, null, null, null, null, null);
		}

		// Token: 0x06004021 RID: 16417 RVA: 0x000EF014 File Offset: 0x000ED214
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForEachWorker<TSource, object>(source, parallelOptions, body, null, null, null, null, null, null);
		}

		// Token: 0x06004022 RID: 16418 RVA: 0x000EF05C File Offset: 0x000ED25C
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, Action<TSource, ParallelLoopState> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForEachWorker<TSource, object>(source, Parallel.s_defaultParallelOptions, null, body, null, null, null, null, null);
		}

		// Token: 0x06004023 RID: 16419 RVA: 0x000EF098 File Offset: 0x000ED298
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource, ParallelLoopState> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForEachWorker<TSource, object>(source, parallelOptions, null, body, null, null, null, null, null);
		}

		// Token: 0x06004024 RID: 16420 RVA: 0x000EF0E0 File Offset: 0x000ED2E0
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, Action<TSource, ParallelLoopState, long> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.ForEachWorker<TSource, object>(source, Parallel.s_defaultParallelOptions, null, null, body, null, null, null, null);
		}

		// Token: 0x06004025 RID: 16421 RVA: 0x000EF11C File Offset: 0x000ED31C
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource, ParallelLoopState, long> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForEachWorker<TSource, object>(source, parallelOptions, null, null, body, null, null, null, null);
		}

		// Token: 0x06004026 RID: 16422 RVA: 0x000EF164 File Offset: 0x000ED364
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(IEnumerable<TSource> source, Func<TLocal> localInit, Func<TSource, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			return Parallel.ForEachWorker<TSource, TLocal>(source, Parallel.s_defaultParallelOptions, null, null, null, body, null, localInit, localFinally);
		}

		// Token: 0x06004027 RID: 16423 RVA: 0x000EF1BC File Offset: 0x000ED3BC
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Func<TLocal> localInit, Func<TSource, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForEachWorker<TSource, TLocal>(source, parallelOptions, null, null, null, body, null, localInit, localFinally);
		}

		// Token: 0x06004028 RID: 16424 RVA: 0x000EF220 File Offset: 0x000ED420
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(IEnumerable<TSource> source, Func<TLocal> localInit, Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			return Parallel.ForEachWorker<TSource, TLocal>(source, Parallel.s_defaultParallelOptions, null, null, null, null, body, localInit, localFinally);
		}

		// Token: 0x06004029 RID: 16425 RVA: 0x000EF278 File Offset: 0x000ED478
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Func<TLocal> localInit, Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.ForEachWorker<TSource, TLocal>(source, parallelOptions, null, null, null, null, body, localInit, localFinally);
		}

		// Token: 0x0600402A RID: 16426 RVA: 0x000EF2DC File Offset: 0x000ED4DC
		private static ParallelLoopResult ForEachWorker<TSource, TLocal>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource> body, Action<TSource, ParallelLoopState> bodyWithState, Action<TSource, ParallelLoopState, long> bodyWithStateAndIndex, Func<TSource, ParallelLoopState, TLocal, TLocal> bodyWithStateAndLocal, Func<TSource, ParallelLoopState, long, TLocal, TLocal> bodyWithEverything, Func<TLocal> localInit, Action<TLocal> localFinally)
		{
			if (parallelOptions.CancellationToken.IsCancellationRequested)
			{
				throw new OperationCanceledException(parallelOptions.CancellationToken);
			}
			TSource[] array = source as TSource[];
			if (array != null)
			{
				return Parallel.ForEachWorker<TSource, TLocal>(array, parallelOptions, body, bodyWithState, bodyWithStateAndIndex, bodyWithStateAndLocal, bodyWithEverything, localInit, localFinally);
			}
			IList<TSource> list = source as IList<TSource>;
			if (list != null)
			{
				return Parallel.ForEachWorker<TSource, TLocal>(list, parallelOptions, body, bodyWithState, bodyWithStateAndIndex, bodyWithStateAndLocal, bodyWithEverything, localInit, localFinally);
			}
			return Parallel.PartitionerForEachWorker<TSource, TLocal>(Partitioner.Create<TSource>(source), parallelOptions, body, bodyWithState, bodyWithStateAndIndex, bodyWithStateAndLocal, bodyWithEverything, localInit, localFinally);
		}

		// Token: 0x0600402B RID: 16427 RVA: 0x000EF35C File Offset: 0x000ED55C
		private static ParallelLoopResult ForEachWorker<TSource, TLocal>(TSource[] array, ParallelOptions parallelOptions, Action<TSource> body, Action<TSource, ParallelLoopState> bodyWithState, Action<TSource, ParallelLoopState, long> bodyWithStateAndIndex, Func<TSource, ParallelLoopState, TLocal, TLocal> bodyWithStateAndLocal, Func<TSource, ParallelLoopState, long, TLocal, TLocal> bodyWithEverything, Func<TLocal> localInit, Action<TLocal> localFinally)
		{
			int lowerBound = array.GetLowerBound(0);
			int toExclusive = array.GetUpperBound(0) + 1;
			if (body != null)
			{
				return Parallel.ForWorker<object>(lowerBound, toExclusive, parallelOptions, delegate(int i)
				{
					body(array[i]);
				}, null, null, null, null);
			}
			if (bodyWithState != null)
			{
				return Parallel.ForWorker<object>(lowerBound, toExclusive, parallelOptions, null, delegate(int i, ParallelLoopState state)
				{
					bodyWithState(array[i], state);
				}, null, null, null);
			}
			if (bodyWithStateAndIndex != null)
			{
				return Parallel.ForWorker<object>(lowerBound, toExclusive, parallelOptions, null, delegate(int i, ParallelLoopState state)
				{
					bodyWithStateAndIndex(array[i], state, (long)i);
				}, null, null, null);
			}
			if (bodyWithStateAndLocal != null)
			{
				return Parallel.ForWorker<TLocal>(lowerBound, toExclusive, parallelOptions, null, null, (int i, ParallelLoopState state, TLocal local) => bodyWithStateAndLocal(array[i], state, local), localInit, localFinally);
			}
			return Parallel.ForWorker<TLocal>(lowerBound, toExclusive, parallelOptions, null, null, (int i, ParallelLoopState state, TLocal local) => bodyWithEverything(array[i], state, (long)i, local), localInit, localFinally);
		}

		// Token: 0x0600402C RID: 16428 RVA: 0x000EF458 File Offset: 0x000ED658
		private static ParallelLoopResult ForEachWorker<TSource, TLocal>(IList<TSource> list, ParallelOptions parallelOptions, Action<TSource> body, Action<TSource, ParallelLoopState> bodyWithState, Action<TSource, ParallelLoopState, long> bodyWithStateAndIndex, Func<TSource, ParallelLoopState, TLocal, TLocal> bodyWithStateAndLocal, Func<TSource, ParallelLoopState, long, TLocal, TLocal> bodyWithEverything, Func<TLocal> localInit, Action<TLocal> localFinally)
		{
			if (body != null)
			{
				return Parallel.ForWorker<object>(0, list.Count, parallelOptions, delegate(int i)
				{
					body(list[i]);
				}, null, null, null, null);
			}
			if (bodyWithState != null)
			{
				return Parallel.ForWorker<object>(0, list.Count, parallelOptions, null, delegate(int i, ParallelLoopState state)
				{
					bodyWithState(list[i], state);
				}, null, null, null);
			}
			if (bodyWithStateAndIndex != null)
			{
				return Parallel.ForWorker<object>(0, list.Count, parallelOptions, null, delegate(int i, ParallelLoopState state)
				{
					bodyWithStateAndIndex(list[i], state, (long)i);
				}, null, null, null);
			}
			if (bodyWithStateAndLocal != null)
			{
				return Parallel.ForWorker<TLocal>(0, list.Count, parallelOptions, null, null, (int i, ParallelLoopState state, TLocal local) => bodyWithStateAndLocal(list[i], state, local), localInit, localFinally);
			}
			return Parallel.ForWorker<TLocal>(0, list.Count, parallelOptions, null, null, (int i, ParallelLoopState state, TLocal local) => bodyWithEverything(list[i], state, (long)i, local), localInit, localFinally);
		}

		// Token: 0x0600402D RID: 16429 RVA: 0x000EF56C File Offset: 0x000ED76C
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(Partitioner<TSource> source, Action<TSource> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.PartitionerForEachWorker<TSource, object>(source, Parallel.s_defaultParallelOptions, body, null, null, null, null, null, null);
		}

		// Token: 0x0600402E RID: 16430 RVA: 0x000EF5A8 File Offset: 0x000ED7A8
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(Partitioner<TSource> source, Action<TSource, ParallelLoopState> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			return Parallel.PartitionerForEachWorker<TSource, object>(source, Parallel.s_defaultParallelOptions, null, body, null, null, null, null, null);
		}

		// Token: 0x0600402F RID: 16431 RVA: 0x000EF5E4 File Offset: 0x000ED7E4
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(OrderablePartitioner<TSource> source, Action<TSource, ParallelLoopState, long> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (!source.KeysNormalized)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_OrderedPartitionerKeysNotNormalized"));
			}
			return Parallel.PartitionerForEachWorker<TSource, object>(source, Parallel.s_defaultParallelOptions, null, null, body, null, null, null, null);
		}

		// Token: 0x06004030 RID: 16432 RVA: 0x000EF638 File Offset: 0x000ED838
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(Partitioner<TSource> source, Func<TLocal> localInit, Func<TSource, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			return Parallel.PartitionerForEachWorker<TSource, TLocal>(source, Parallel.s_defaultParallelOptions, null, null, null, body, null, localInit, localFinally);
		}

		// Token: 0x06004031 RID: 16433 RVA: 0x000EF690 File Offset: 0x000ED890
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(OrderablePartitioner<TSource> source, Func<TLocal> localInit, Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (!source.KeysNormalized)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_OrderedPartitionerKeysNotNormalized"));
			}
			return Parallel.PartitionerForEachWorker<TSource, TLocal>(source, Parallel.s_defaultParallelOptions, null, null, null, null, body, localInit, localFinally);
		}

		// Token: 0x06004032 RID: 16434 RVA: 0x000EF700 File Offset: 0x000ED900
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(Partitioner<TSource> source, ParallelOptions parallelOptions, Action<TSource> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.PartitionerForEachWorker<TSource, object>(source, parallelOptions, body, null, null, null, null, null, null);
		}

		// Token: 0x06004033 RID: 16435 RVA: 0x000EF748 File Offset: 0x000ED948
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(Partitioner<TSource> source, ParallelOptions parallelOptions, Action<TSource, ParallelLoopState> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.PartitionerForEachWorker<TSource, object>(source, parallelOptions, null, body, null, null, null, null, null);
		}

		// Token: 0x06004034 RID: 16436 RVA: 0x000EF790 File Offset: 0x000ED990
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource>(OrderablePartitioner<TSource> source, ParallelOptions parallelOptions, Action<TSource, ParallelLoopState, long> body)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			if (!source.KeysNormalized)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_OrderedPartitionerKeysNotNormalized"));
			}
			return Parallel.PartitionerForEachWorker<TSource, object>(source, parallelOptions, null, null, body, null, null, null, null);
		}

		// Token: 0x06004035 RID: 16437 RVA: 0x000EF7F0 File Offset: 0x000ED9F0
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(Partitioner<TSource> source, ParallelOptions parallelOptions, Func<TLocal> localInit, Func<TSource, ParallelLoopState, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			return Parallel.PartitionerForEachWorker<TSource, TLocal>(source, parallelOptions, null, null, null, body, null, localInit, localFinally);
		}

		// Token: 0x06004036 RID: 16438 RVA: 0x000EF854 File Offset: 0x000EDA54
		[__DynamicallyInvokable]
		public static ParallelLoopResult ForEach<TSource, TLocal>(OrderablePartitioner<TSource> source, ParallelOptions parallelOptions, Func<TLocal> localInit, Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, Action<TLocal> localFinally)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (localInit == null)
			{
				throw new ArgumentNullException("localInit");
			}
			if (localFinally == null)
			{
				throw new ArgumentNullException("localFinally");
			}
			if (parallelOptions == null)
			{
				throw new ArgumentNullException("parallelOptions");
			}
			if (!source.KeysNormalized)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_OrderedPartitionerKeysNotNormalized"));
			}
			return Parallel.PartitionerForEachWorker<TSource, TLocal>(source, parallelOptions, null, null, null, null, body, localInit, localFinally);
		}

		// Token: 0x06004037 RID: 16439 RVA: 0x000EF8D0 File Offset: 0x000EDAD0
		private static ParallelLoopResult PartitionerForEachWorker<TSource, TLocal>(Partitioner<TSource> source, ParallelOptions parallelOptions, Action<TSource> simpleBody, Action<TSource, ParallelLoopState> bodyWithState, Action<TSource, ParallelLoopState, long> bodyWithStateAndIndex, Func<TSource, ParallelLoopState, TLocal, TLocal> bodyWithStateAndLocal, Func<TSource, ParallelLoopState, long, TLocal, TLocal> bodyWithEverything, Func<TLocal> localInit, Action<TLocal> localFinally)
		{
			OrderablePartitioner<TSource> orderedSource = source as OrderablePartitioner<TSource>;
			if (!source.SupportsDynamicPartitions)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_PartitionerNotDynamic"));
			}
			if (parallelOptions.CancellationToken.IsCancellationRequested)
			{
				throw new OperationCanceledException(parallelOptions.CancellationToken);
			}
			int forkJoinContextID = 0;
			Task task = null;
			if (TplEtwProvider.Log.IsEnabled())
			{
				forkJoinContextID = Interlocked.Increment(ref Parallel.s_forkJoinContextID);
				task = Task.InternalCurrent;
				TplEtwProvider.Log.ParallelLoopBegin((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, TplEtwProvider.ForkJoinOperationType.ParallelForEach, 0L, 0L);
			}
			ParallelLoopStateFlags64 sharedPStateFlags = new ParallelLoopStateFlags64();
			ParallelLoopResult result = default(ParallelLoopResult);
			OperationCanceledException oce = null;
			CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
			if (parallelOptions.CancellationToken.CanBeCanceled)
			{
				cancellationTokenRegistration = parallelOptions.CancellationToken.InternalRegisterWithoutEC(delegate(object o)
				{
					sharedPStateFlags.Cancel();
					oce = new OperationCanceledException(parallelOptions.CancellationToken);
				}, null);
			}
			IEnumerable<TSource> partitionerSource = null;
			IEnumerable<KeyValuePair<long, TSource>> orderablePartitionerSource = null;
			if (orderedSource != null)
			{
				orderablePartitionerSource = orderedSource.GetOrderableDynamicPartitions();
				if (orderablePartitionerSource == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_PartitionerReturnedNull"));
				}
			}
			else
			{
				partitionerSource = source.GetDynamicPartitions();
				if (partitionerSource == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_PartitionerReturnedNull"));
				}
			}
			ParallelForReplicatingTask rootTask = null;
			Action action = delegate()
			{
				Task internalCurrent = Task.InternalCurrent;
				if (TplEtwProvider.Log.IsEnabled())
				{
					TplEtwProvider.Log.ParallelFork((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, forkJoinContextID);
				}
				TLocal tlocal = default(TLocal);
				bool flag = false;
				IDisposable disposable2 = null;
				try
				{
					ParallelLoopState64 parallelLoopState = null;
					if (bodyWithState != null || bodyWithStateAndIndex != null)
					{
						parallelLoopState = new ParallelLoopState64(sharedPStateFlags);
					}
					else if (bodyWithStateAndLocal != null || bodyWithEverything != null)
					{
						parallelLoopState = new ParallelLoopState64(sharedPStateFlags);
						if (localInit != null)
						{
							tlocal = localInit();
							flag = true;
						}
					}
					bool flag2 = rootTask == internalCurrent;
					Parallel.LoopTimer loopTimer = new Parallel.LoopTimer(rootTask.ActiveChildCount);
					if (orderedSource != null)
					{
						IEnumerator<KeyValuePair<long, TSource>> enumerator = internalCurrent.SavedStateFromPreviousReplica as IEnumerator<KeyValuePair<long, TSource>>;
						if (enumerator == null)
						{
							enumerator = orderablePartitionerSource.GetEnumerator();
							if (enumerator == null)
							{
								throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_NullEnumerator"));
							}
						}
						disposable2 = enumerator;
						while (enumerator.MoveNext())
						{
							KeyValuePair<long, TSource> keyValuePair = enumerator.Current;
							long key = keyValuePair.Key;
							TSource value = keyValuePair.Value;
							if (parallelLoopState != null)
							{
								parallelLoopState.CurrentIteration = key;
							}
							if (simpleBody != null)
							{
								simpleBody(value);
							}
							else if (bodyWithState != null)
							{
								bodyWithState(value, parallelLoopState);
							}
							else if (bodyWithStateAndIndex != null)
							{
								bodyWithStateAndIndex(value, parallelLoopState, key);
							}
							else if (bodyWithStateAndLocal != null)
							{
								tlocal = bodyWithStateAndLocal(value, parallelLoopState, tlocal);
							}
							else
							{
								tlocal = bodyWithEverything(value, parallelLoopState, key, tlocal);
							}
							if (sharedPStateFlags.ShouldExitLoop(key))
							{
								break;
							}
							if (!flag2 && loopTimer.LimitExceeded())
							{
								internalCurrent.SavedStateForNextReplica = enumerator;
								disposable2 = null;
								break;
							}
						}
					}
					else
					{
						IEnumerator<TSource> enumerator2 = internalCurrent.SavedStateFromPreviousReplica as IEnumerator<!0>;
						if (enumerator2 == null)
						{
							enumerator2 = partitionerSource.GetEnumerator();
							if (enumerator2 == null)
							{
								throw new InvalidOperationException(Environment.GetResourceString("Parallel_ForEach_NullEnumerator"));
							}
						}
						disposable2 = enumerator2;
						if (parallelLoopState != null)
						{
							parallelLoopState.CurrentIteration = 0L;
						}
						while (enumerator2.MoveNext())
						{
							TSource tsource = enumerator2.Current;
							if (simpleBody != null)
							{
								simpleBody(tsource);
							}
							else if (bodyWithState != null)
							{
								bodyWithState(tsource, parallelLoopState);
							}
							else if (bodyWithStateAndLocal != null)
							{
								tlocal = bodyWithStateAndLocal(tsource, parallelLoopState, tlocal);
							}
							if (sharedPStateFlags.LoopStateFlags != ParallelLoopStateFlags.PLS_NONE)
							{
								break;
							}
							if (!flag2 && loopTimer.LimitExceeded())
							{
								internalCurrent.SavedStateForNextReplica = enumerator2;
								disposable2 = null;
								break;
							}
						}
					}
				}
				catch
				{
					sharedPStateFlags.SetExceptional();
					throw;
				}
				finally
				{
					if (localFinally != null && flag)
					{
						localFinally(tlocal);
					}
					if (disposable2 != null)
					{
						disposable2.Dispose();
					}
					if (TplEtwProvider.Log.IsEnabled())
					{
						TplEtwProvider.Log.ParallelJoin((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, forkJoinContextID);
					}
				}
			};
			try
			{
				rootTask = new ParallelForReplicatingTask(parallelOptions, action, TaskCreationOptions.None, InternalTaskOptions.SelfReplicating);
				rootTask.RunSynchronously(parallelOptions.EffectiveTaskScheduler);
				rootTask.Wait();
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				if (oce != null)
				{
					throw oce;
				}
			}
			catch (AggregateException ex)
			{
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				Parallel.ThrowIfReducableToSingleOCE(ex.InnerExceptions, parallelOptions.CancellationToken);
				throw;
			}
			catch (TaskSchedulerException)
			{
				if (parallelOptions.CancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration.Dispose();
				}
				throw;
			}
			finally
			{
				int loopStateFlags = sharedPStateFlags.LoopStateFlags;
				result.m_completed = (loopStateFlags == ParallelLoopStateFlags.PLS_NONE);
				if ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0)
				{
					result.m_lowestBreakIteration = new long?(sharedPStateFlags.LowestBreakIteration);
				}
				if (rootTask != null && rootTask.IsCompleted)
				{
					rootTask.Dispose();
				}
				IDisposable disposable;
				if (orderablePartitionerSource != null)
				{
					disposable = (orderablePartitionerSource as IDisposable);
				}
				else
				{
					disposable = (partitionerSource as IDisposable);
				}
				if (disposable != null)
				{
					disposable.Dispose();
				}
				if (TplEtwProvider.Log.IsEnabled())
				{
					TplEtwProvider.Log.ParallelLoopEnd((task != null) ? task.m_taskScheduler.Id : TaskScheduler.Current.Id, (task != null) ? task.Id : 0, forkJoinContextID, 0L);
				}
			}
			return result;
		}

		// Token: 0x06004038 RID: 16440 RVA: 0x000EFC64 File Offset: 0x000EDE64
		internal static void ThrowIfReducableToSingleOCE(IEnumerable<Exception> excCollection, CancellationToken ct)
		{
			bool flag = false;
			if (ct.IsCancellationRequested)
			{
				foreach (Exception ex in excCollection)
				{
					flag = true;
					OperationCanceledException ex2 = ex as OperationCanceledException;
					if (ex2 == null || ex2.CancellationToken != ct)
					{
						return;
					}
				}
				if (flag)
				{
					throw new OperationCanceledException(ct);
				}
			}
		}

		// Token: 0x04001AC6 RID: 6854
		internal static int s_forkJoinContextID;

		// Token: 0x04001AC7 RID: 6855
		internal const int DEFAULT_LOOP_STRIDE = 16;

		// Token: 0x04001AC8 RID: 6856
		internal static ParallelOptions s_defaultParallelOptions = new ParallelOptions();

		// Token: 0x02000C09 RID: 3081
		internal struct LoopTimer
		{
			// Token: 0x06006FB0 RID: 28592 RVA: 0x00180F6C File Offset: 0x0017F16C
			public LoopTimer(int nWorkerTaskIndex)
			{
				int num = 100 + nWorkerTaskIndex % PlatformHelper.ProcessorCount * 50;
				this.m_timeLimit = Environment.TickCount + num;
			}

			// Token: 0x06006FB1 RID: 28593 RVA: 0x00180F94 File Offset: 0x0017F194
			public bool LimitExceeded()
			{
				return Environment.TickCount > this.m_timeLimit;
			}

			// Token: 0x0400366E RID: 13934
			private const int s_BaseNotifyPeriodMS = 100;

			// Token: 0x0400366F RID: 13935
			private const int s_NotifyPeriodIncrementMS = 50;

			// Token: 0x04003670 RID: 13936
			private int m_timeLimit;
		}
	}
}
