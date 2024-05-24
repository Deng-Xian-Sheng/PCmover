using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;

namespace System.Threading
{
	// Token: 0x02000515 RID: 1301
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Thread))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class Thread : CriticalFinalizerObject, _Thread
	{
		// Token: 0x06003D1D RID: 15645 RVA: 0x000E6185 File Offset: 0x000E4385
		private static void AsyncLocalSetCurrentCulture(AsyncLocalValueChangedArgs<CultureInfo> args)
		{
			Thread.CurrentThread.m_CurrentCulture = args.CurrentValue;
		}

		// Token: 0x06003D1E RID: 15646 RVA: 0x000E6198 File Offset: 0x000E4398
		private static void AsyncLocalSetCurrentUICulture(AsyncLocalValueChangedArgs<CultureInfo> args)
		{
			Thread.CurrentThread.m_CurrentUICulture = args.CurrentValue;
		}

		// Token: 0x06003D1F RID: 15647 RVA: 0x000E61AB File Offset: 0x000E43AB
		[SecuritySafeCritical]
		public Thread(ThreadStart start)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			this.SetStartHelper(start, 0);
		}

		// Token: 0x06003D20 RID: 15648 RVA: 0x000E61C9 File Offset: 0x000E43C9
		[SecuritySafeCritical]
		public Thread(ThreadStart start, int maxStackSize)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			if (0 > maxStackSize)
			{
				throw new ArgumentOutOfRangeException("maxStackSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.SetStartHelper(start, maxStackSize);
		}

		// Token: 0x06003D21 RID: 15649 RVA: 0x000E6200 File Offset: 0x000E4400
		[SecuritySafeCritical]
		public Thread(ParameterizedThreadStart start)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			this.SetStartHelper(start, 0);
		}

		// Token: 0x06003D22 RID: 15650 RVA: 0x000E621E File Offset: 0x000E441E
		[SecuritySafeCritical]
		public Thread(ParameterizedThreadStart start, int maxStackSize)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			if (0 > maxStackSize)
			{
				throw new ArgumentOutOfRangeException("maxStackSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.SetStartHelper(start, maxStackSize);
		}

		// Token: 0x06003D23 RID: 15651 RVA: 0x000E6255 File Offset: 0x000E4455
		[ComVisible(false)]
		public override int GetHashCode()
		{
			return this.m_ManagedThreadId;
		}

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x06003D24 RID: 15652
		[__DynamicallyInvokable]
		public extern int ManagedThreadId { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] [SecuritySafeCritical] [__DynamicallyInvokable] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06003D25 RID: 15653 RVA: 0x000E6260 File Offset: 0x000E4460
		internal ThreadHandle GetNativeHandle()
		{
			IntPtr dont_USE_InternalThread = this.DONT_USE_InternalThread;
			if (dont_USE_InternalThread.IsNull())
			{
				throw new ArgumentException(null, Environment.GetResourceString("Argument_InvalidHandle"));
			}
			return new ThreadHandle(dont_USE_InternalThread);
		}

		// Token: 0x06003D26 RID: 15654 RVA: 0x000E6294 File Offset: 0x000E4494
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Start()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Start(ref stackCrawlMark);
		}

		// Token: 0x06003D27 RID: 15655 RVA: 0x000E62AC File Offset: 0x000E44AC
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Start(object parameter)
		{
			if (this.m_Delegate is ThreadStart)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ThreadWrongThreadStart"));
			}
			this.m_ThreadStartArg = parameter;
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Start(ref stackCrawlMark);
		}

		// Token: 0x06003D28 RID: 15656 RVA: 0x000E62E8 File Offset: 0x000E44E8
		[SecuritySafeCritical]
		private void Start(ref StackCrawlMark stackMark)
		{
			this.StartupSetApartmentStateInternal();
			if (this.m_Delegate != null)
			{
				ThreadHelper threadHelper = (ThreadHelper)this.m_Delegate.Target;
				ExecutionContext executionContextHelper = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx);
				threadHelper.SetExecutionContextHelper(executionContextHelper);
			}
			IPrincipal principal = CallContext.Principal;
			this.StartInternal(principal, ref stackMark);
		}

		// Token: 0x06003D29 RID: 15657 RVA: 0x000E6331 File Offset: 0x000E4531
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal ExecutionContext.Reader GetExecutionContextReader()
		{
			return new ExecutionContext.Reader(this.m_ExecutionContext);
		}

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x06003D2A RID: 15658 RVA: 0x000E633E File Offset: 0x000E453E
		// (set) Token: 0x06003D2B RID: 15659 RVA: 0x000E6349 File Offset: 0x000E4549
		internal bool ExecutionContextBelongsToCurrentScope
		{
			get
			{
				return !this.m_ExecutionContextBelongsToOuterScope;
			}
			set
			{
				this.m_ExecutionContextBelongsToOuterScope = !value;
			}
		}

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x06003D2C RID: 15660 RVA: 0x000E6358 File Offset: 0x000E4558
		public ExecutionContext ExecutionContext
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			get
			{
				ExecutionContext result;
				if (this == Thread.CurrentThread)
				{
					result = this.GetMutableExecutionContext();
				}
				else
				{
					result = this.m_ExecutionContext;
				}
				return result;
			}
		}

		// Token: 0x06003D2D RID: 15661 RVA: 0x000E6380 File Offset: 0x000E4580
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal ExecutionContext GetMutableExecutionContext()
		{
			if (this.m_ExecutionContext == null)
			{
				this.m_ExecutionContext = new ExecutionContext();
			}
			else if (!this.ExecutionContextBelongsToCurrentScope)
			{
				ExecutionContext executionContext = this.m_ExecutionContext.CreateMutableCopy();
				this.m_ExecutionContext = executionContext;
			}
			this.ExecutionContextBelongsToCurrentScope = true;
			return this.m_ExecutionContext;
		}

		// Token: 0x06003D2E RID: 15662 RVA: 0x000E63CA File Offset: 0x000E45CA
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal void SetExecutionContext(ExecutionContext value, bool belongsToCurrentScope)
		{
			this.m_ExecutionContext = value;
			this.ExecutionContextBelongsToCurrentScope = belongsToCurrentScope;
		}

		// Token: 0x06003D2F RID: 15663 RVA: 0x000E63DA File Offset: 0x000E45DA
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal void SetExecutionContext(ExecutionContext.Reader value, bool belongsToCurrentScope)
		{
			this.m_ExecutionContext = value.DangerousGetRawExecutionContext();
			this.ExecutionContextBelongsToCurrentScope = belongsToCurrentScope;
		}

		// Token: 0x06003D30 RID: 15664
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartInternal(IPrincipal principal, ref StackCrawlMark stackMark);

		// Token: 0x06003D31 RID: 15665 RVA: 0x000E63F0 File Offset: 0x000E45F0
		[SecurityCritical]
		[Obsolete("Thread.SetCompressedStack is no longer supported. Please use the System.Threading.CompressedStack class")]
		public void SetCompressedStack(CompressedStack stack)
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ThreadAPIsNotSupported"));
		}

		// Token: 0x06003D32 RID: 15666
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr SetAppDomainStack(SafeCompressedStackHandle csHandle);

		// Token: 0x06003D33 RID: 15667
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void RestoreAppDomainStack(IntPtr appDomainStack);

		// Token: 0x06003D34 RID: 15668 RVA: 0x000E6401 File Offset: 0x000E4601
		[SecurityCritical]
		[Obsolete("Thread.GetCompressedStack is no longer supported. Please use the System.Threading.CompressedStack class")]
		public CompressedStack GetCompressedStack()
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ThreadAPIsNotSupported"));
		}

		// Token: 0x06003D35 RID: 15669
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr InternalGetCurrentThread();

		// Token: 0x06003D36 RID: 15670 RVA: 0x000E6412 File Offset: 0x000E4612
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Abort(object stateInfo)
		{
			this.AbortReason = stateInfo;
			this.AbortInternal();
		}

		// Token: 0x06003D37 RID: 15671 RVA: 0x000E6421 File Offset: 0x000E4621
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Abort()
		{
			this.AbortInternal();
		}

		// Token: 0x06003D38 RID: 15672
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AbortInternal();

		// Token: 0x06003D39 RID: 15673 RVA: 0x000E642C File Offset: 0x000E462C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public static void ResetAbort()
		{
			Thread currentThread = Thread.CurrentThread;
			if ((currentThread.ThreadState & ThreadState.AbortRequested) == ThreadState.Running)
			{
				throw new ThreadStateException(Environment.GetResourceString("ThreadState_NoAbortRequested"));
			}
			currentThread.ResetAbortNative();
			currentThread.ClearAbortReason();
		}

		// Token: 0x06003D3A RID: 15674
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ResetAbortNative();

		// Token: 0x06003D3B RID: 15675 RVA: 0x000E6469 File Offset: 0x000E4669
		[SecuritySafeCritical]
		[Obsolete("Thread.Suspend has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false)]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Suspend()
		{
			this.SuspendInternal();
		}

		// Token: 0x06003D3C RID: 15676
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SuspendInternal();

		// Token: 0x06003D3D RID: 15677 RVA: 0x000E6471 File Offset: 0x000E4671
		[SecuritySafeCritical]
		[Obsolete("Thread.Resume has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false)]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Resume()
		{
			this.ResumeInternal();
		}

		// Token: 0x06003D3E RID: 15678
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ResumeInternal();

		// Token: 0x06003D3F RID: 15679 RVA: 0x000E6479 File Offset: 0x000E4679
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Interrupt()
		{
			this.InterruptInternal();
		}

		// Token: 0x06003D40 RID: 15680
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InterruptInternal();

		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x06003D41 RID: 15681 RVA: 0x000E6481 File Offset: 0x000E4681
		// (set) Token: 0x06003D42 RID: 15682 RVA: 0x000E6489 File Offset: 0x000E4689
		public ThreadPriority Priority
		{
			[SecuritySafeCritical]
			get
			{
				return (ThreadPriority)this.GetPriorityNative();
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, SelfAffectingThreading = true)]
			set
			{
				this.SetPriorityNative((int)value);
			}
		}

		// Token: 0x06003D43 RID: 15683
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetPriorityNative();

		// Token: 0x06003D44 RID: 15684
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetPriorityNative(int priority);

		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x06003D45 RID: 15685
		public extern bool IsAlive { [SecuritySafeCritical] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x06003D46 RID: 15686
		public extern bool IsThreadPoolThread { [SecuritySafeCritical] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06003D47 RID: 15687
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool JoinInternal(int millisecondsTimeout);

		// Token: 0x06003D48 RID: 15688 RVA: 0x000E6492 File Offset: 0x000E4692
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public void Join()
		{
			this.JoinInternal(-1);
		}

		// Token: 0x06003D49 RID: 15689 RVA: 0x000E649C File Offset: 0x000E469C
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public bool Join(int millisecondsTimeout)
		{
			return this.JoinInternal(millisecondsTimeout);
		}

		// Token: 0x06003D4A RID: 15690 RVA: 0x000E64A8 File Offset: 0x000E46A8
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public bool Join(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.Join((int)num);
		}

		// Token: 0x06003D4B RID: 15691
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SleepInternal(int millisecondsTimeout);

		// Token: 0x06003D4C RID: 15692 RVA: 0x000E64E9 File Offset: 0x000E46E9
		[SecuritySafeCritical]
		public static void Sleep(int millisecondsTimeout)
		{
			Thread.SleepInternal(millisecondsTimeout);
			if (AppDomainPauseManager.IsPaused)
			{
				AppDomainPauseManager.ResumeEvent.WaitOneWithoutFAS();
			}
		}

		// Token: 0x06003D4D RID: 15693 RVA: 0x000E6504 File Offset: 0x000E4704
		public static void Sleep(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			Thread.Sleep((int)num);
		}

		// Token: 0x06003D4E RID: 15694
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetCurrentProcessorNumber();

		// Token: 0x06003D4F RID: 15695 RVA: 0x000E6544 File Offset: 0x000E4744
		private static int RefreshCurrentProcessorId()
		{
			int num = Thread.GetCurrentProcessorNumber();
			if (num < 0)
			{
				num = Environment.CurrentManagedThreadId;
			}
			num += 100;
			Thread.t_currentProcessorIdCache = ((num << 16 & int.MaxValue) | 5000);
			return num;
		}

		// Token: 0x06003D50 RID: 15696 RVA: 0x000E657C File Offset: 0x000E477C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int GetCurrentProcessorId()
		{
			int num = Thread.t_currentProcessorIdCache--;
			if ((num & 65535) == 0)
			{
				return Thread.RefreshCurrentProcessorId();
			}
			return num >> 16;
		}

		// Token: 0x06003D51 RID: 15697
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SpinWaitInternal(int iterations);

		// Token: 0x06003D52 RID: 15698 RVA: 0x000E65AA File Offset: 0x000E47AA
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public static void SpinWait(int iterations)
		{
			Thread.SpinWaitInternal(iterations);
		}

		// Token: 0x06003D53 RID: 15699
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern bool YieldInternal();

		// Token: 0x06003D54 RID: 15700 RVA: 0x000E65B2 File Offset: 0x000E47B2
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public static bool Yield()
		{
			return Thread.YieldInternal();
		}

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x06003D55 RID: 15701 RVA: 0x000E65B9 File Offset: 0x000E47B9
		[__DynamicallyInvokable]
		public static Thread CurrentThread
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			[__DynamicallyInvokable]
			get
			{
				return Thread.GetCurrentThreadNative();
			}
		}

		// Token: 0x06003D56 RID: 15702
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Thread GetCurrentThreadNative();

		// Token: 0x06003D57 RID: 15703 RVA: 0x000E65C0 File Offset: 0x000E47C0
		[SecurityCritical]
		private void SetStartHelper(Delegate start, int maxStackSize)
		{
			ulong processDefaultStackSize = Thread.GetProcessDefaultStackSize();
			if ((ulong)maxStackSize > processDefaultStackSize)
			{
				try
				{
					CodeAccessPermission.Demand(PermissionType.FullTrust);
				}
				catch (SecurityException)
				{
					maxStackSize = (int)Math.Min(processDefaultStackSize, 2147483647UL);
				}
			}
			ThreadHelper @object = new ThreadHelper(start);
			if (start is ThreadStart)
			{
				this.SetStart(new ThreadStart(@object.ThreadStart), maxStackSize);
				return;
			}
			this.SetStart(new ParameterizedThreadStart(@object.ThreadStart), maxStackSize);
		}

		// Token: 0x06003D58 RID: 15704
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern ulong GetProcessDefaultStackSize();

		// Token: 0x06003D59 RID: 15705
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetStart(Delegate start, int maxStackSize);

		// Token: 0x06003D5A RID: 15706 RVA: 0x000E6638 File Offset: 0x000E4838
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		~Thread()
		{
			this.InternalFinalize();
		}

		// Token: 0x06003D5B RID: 15707
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalFinalize();

		// Token: 0x06003D5C RID: 15708
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DisableComObjectEagerCleanup();

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x06003D5D RID: 15709 RVA: 0x000E6664 File Offset: 0x000E4864
		// (set) Token: 0x06003D5E RID: 15710 RVA: 0x000E666C File Offset: 0x000E486C
		public bool IsBackground
		{
			[SecuritySafeCritical]
			get
			{
				return this.IsBackgroundNative();
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, SelfAffectingThreading = true)]
			set
			{
				this.SetBackgroundNative(value);
			}
		}

		// Token: 0x06003D5F RID: 15711
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool IsBackgroundNative();

		// Token: 0x06003D60 RID: 15712
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetBackgroundNative(bool isBackground);

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x06003D61 RID: 15713 RVA: 0x000E6675 File Offset: 0x000E4875
		public ThreadState ThreadState
		{
			[SecuritySafeCritical]
			get
			{
				return (ThreadState)this.GetThreadStateNative();
			}
		}

		// Token: 0x06003D62 RID: 15714
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetThreadStateNative();

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x06003D63 RID: 15715 RVA: 0x000E667D File Offset: 0x000E487D
		// (set) Token: 0x06003D64 RID: 15716 RVA: 0x000E6685 File Offset: 0x000E4885
		[Obsolete("The ApartmentState property has been deprecated.  Use GetApartmentState, SetApartmentState or TrySetApartmentState instead.", false)]
		public ApartmentState ApartmentState
		{
			[SecuritySafeCritical]
			get
			{
				return (ApartmentState)this.GetApartmentStateNative();
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, Synchronization = true, SelfAffectingThreading = true)]
			set
			{
				this.SetApartmentStateNative((int)value, true);
			}
		}

		// Token: 0x06003D65 RID: 15717 RVA: 0x000E6690 File Offset: 0x000E4890
		[SecuritySafeCritical]
		public ApartmentState GetApartmentState()
		{
			return (ApartmentState)this.GetApartmentStateNative();
		}

		// Token: 0x06003D66 RID: 15718 RVA: 0x000E6698 File Offset: 0x000E4898
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, SelfAffectingThreading = true)]
		public bool TrySetApartmentState(ApartmentState state)
		{
			return this.SetApartmentStateHelper(state, false);
		}

		// Token: 0x06003D67 RID: 15719 RVA: 0x000E66A4 File Offset: 0x000E48A4
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, SelfAffectingThreading = true)]
		public void SetApartmentState(ApartmentState state)
		{
			if (!this.SetApartmentStateHelper(state, true))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ApartmentStateSwitchFailed"));
			}
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x000E66D0 File Offset: 0x000E48D0
		[SecurityCritical]
		private bool SetApartmentStateHelper(ApartmentState state, bool fireMDAOnMismatch)
		{
			ApartmentState apartmentState = (ApartmentState)this.SetApartmentStateNative((int)state, fireMDAOnMismatch);
			return (state == ApartmentState.Unknown && apartmentState == ApartmentState.MTA) || apartmentState == state;
		}

		// Token: 0x06003D69 RID: 15721
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetApartmentStateNative();

		// Token: 0x06003D6A RID: 15722
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int SetApartmentStateNative(int state, bool fireMDAOnMismatch);

		// Token: 0x06003D6B RID: 15723
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartupSetApartmentStateInternal();

		// Token: 0x06003D6C RID: 15724 RVA: 0x000E66F7 File Offset: 0x000E48F7
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static LocalDataStoreSlot AllocateDataSlot()
		{
			return Thread.LocalDataStoreManager.AllocateDataSlot();
		}

		// Token: 0x06003D6D RID: 15725 RVA: 0x000E6703 File Offset: 0x000E4903
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static LocalDataStoreSlot AllocateNamedDataSlot(string name)
		{
			return Thread.LocalDataStoreManager.AllocateNamedDataSlot(name);
		}

		// Token: 0x06003D6E RID: 15726 RVA: 0x000E6710 File Offset: 0x000E4910
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static LocalDataStoreSlot GetNamedDataSlot(string name)
		{
			return Thread.LocalDataStoreManager.GetNamedDataSlot(name);
		}

		// Token: 0x06003D6F RID: 15727 RVA: 0x000E671D File Offset: 0x000E491D
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static void FreeNamedDataSlot(string name)
		{
			Thread.LocalDataStoreManager.FreeNamedDataSlot(name);
		}

		// Token: 0x06003D70 RID: 15728 RVA: 0x000E672C File Offset: 0x000E492C
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static object GetData(LocalDataStoreSlot slot)
		{
			LocalDataStoreHolder localDataStoreHolder = Thread.s_LocalDataStore;
			if (localDataStoreHolder == null)
			{
				Thread.LocalDataStoreManager.ValidateSlot(slot);
				return null;
			}
			return localDataStoreHolder.Store.GetData(slot);
		}

		// Token: 0x06003D71 RID: 15729 RVA: 0x000E675C File Offset: 0x000E495C
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static void SetData(LocalDataStoreSlot slot, object data)
		{
			LocalDataStoreHolder localDataStoreHolder = Thread.s_LocalDataStore;
			if (localDataStoreHolder == null)
			{
				localDataStoreHolder = Thread.LocalDataStoreManager.CreateLocalDataStore();
				Thread.s_LocalDataStore = localDataStoreHolder;
			}
			localDataStoreHolder.Store.SetData(slot, data);
		}

		// Token: 0x06003D72 RID: 15730
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool nativeGetSafeCulture(Thread t, int appDomainId, bool isUI, ref CultureInfo safeCulture);

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x06003D73 RID: 15731 RVA: 0x000E6790 File Offset: 0x000E4990
		// (set) Token: 0x06003D74 RID: 15732 RVA: 0x000E67B0 File Offset: 0x000E49B0
		[__DynamicallyInvokable]
		public CultureInfo CurrentUICulture
		{
			[__DynamicallyInvokable]
			get
			{
				if (AppDomain.IsAppXModel())
				{
					return CultureInfo.GetCultureInfoForUserPreferredLanguageInAppX() ?? this.GetCurrentUICultureNoAppX();
				}
				return this.GetCurrentUICultureNoAppX();
			}
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CultureInfo.VerifyCultureName(value, true);
				if (!Thread.nativeSetThreadUILocale(value.SortName))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidResourceCultureName", new object[]
					{
						value.Name
					}));
				}
				value.StartCrossDomainTracking();
				if (!AppContextSwitches.NoAsyncCurrentCulture)
				{
					if (Thread.s_asyncLocalCurrentUICulture == null)
					{
						Interlocked.CompareExchange<AsyncLocal<CultureInfo>>(ref Thread.s_asyncLocalCurrentUICulture, new AsyncLocal<CultureInfo>(new Action<AsyncLocalValueChangedArgs<CultureInfo>>(Thread.AsyncLocalSetCurrentUICulture)), null);
					}
					Thread.s_asyncLocalCurrentUICulture.Value = value;
					return;
				}
				this.m_CurrentUICulture = value;
			}
		}

		// Token: 0x06003D75 RID: 15733 RVA: 0x000E6844 File Offset: 0x000E4A44
		[SecuritySafeCritical]
		internal CultureInfo GetCurrentUICultureNoAppX()
		{
			if (this.m_CurrentUICulture == null)
			{
				CultureInfo defaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentUICulture;
				if (defaultThreadCurrentUICulture == null)
				{
					return CultureInfo.UserDefaultUICulture;
				}
				return defaultThreadCurrentUICulture;
			}
			else
			{
				CultureInfo cultureInfo = null;
				if (!Thread.nativeGetSafeCulture(this, Thread.GetDomainID(), true, ref cultureInfo) || cultureInfo == null)
				{
					return CultureInfo.UserDefaultUICulture;
				}
				return cultureInfo;
			}
		}

		// Token: 0x06003D76 RID: 15734
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool nativeSetThreadUILocale(string locale);

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x06003D77 RID: 15735 RVA: 0x000E6886 File Offset: 0x000E4A86
		// (set) Token: 0x06003D78 RID: 15736 RVA: 0x000E68A8 File Offset: 0x000E4AA8
		[__DynamicallyInvokable]
		public CultureInfo CurrentCulture
		{
			[__DynamicallyInvokable]
			get
			{
				if (AppDomain.IsAppXModel())
				{
					return CultureInfo.GetCultureInfoForUserPreferredLanguageInAppX() ?? this.GetCurrentCultureNoAppX();
				}
				return this.GetCurrentCultureNoAppX();
			}
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CultureInfo.nativeSetThreadLocale(value.SortName);
				value.StartCrossDomainTracking();
				if (!AppContextSwitches.NoAsyncCurrentCulture)
				{
					if (Thread.s_asyncLocalCurrentCulture == null)
					{
						Interlocked.CompareExchange<AsyncLocal<CultureInfo>>(ref Thread.s_asyncLocalCurrentCulture, new AsyncLocal<CultureInfo>(new Action<AsyncLocalValueChangedArgs<CultureInfo>>(Thread.AsyncLocalSetCurrentCulture)), null);
					}
					Thread.s_asyncLocalCurrentCulture.Value = value;
					return;
				}
				this.m_CurrentCulture = value;
			}
		}

		// Token: 0x06003D79 RID: 15737 RVA: 0x000E6914 File Offset: 0x000E4B14
		[SecuritySafeCritical]
		private CultureInfo GetCurrentCultureNoAppX()
		{
			if (this.m_CurrentCulture == null)
			{
				CultureInfo defaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentCulture;
				if (defaultThreadCurrentCulture == null)
				{
					return CultureInfo.UserDefaultCulture;
				}
				return defaultThreadCurrentCulture;
			}
			else
			{
				CultureInfo cultureInfo = null;
				if (!Thread.nativeGetSafeCulture(this, Thread.GetDomainID(), false, ref cultureInfo) || cultureInfo == null)
				{
					return CultureInfo.UserDefaultCulture;
				}
				return cultureInfo;
			}
		}

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x06003D7A RID: 15738 RVA: 0x000E6956 File Offset: 0x000E4B56
		public static Context CurrentContext
		{
			[SecurityCritical]
			get
			{
				return Thread.CurrentThread.GetCurrentContextInternal();
			}
		}

		// Token: 0x06003D7B RID: 15739 RVA: 0x000E6962 File Offset: 0x000E4B62
		[SecurityCritical]
		internal Context GetCurrentContextInternal()
		{
			if (this.m_Context == null)
			{
				this.m_Context = Context.DefaultContext;
			}
			return this.m_Context;
		}

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x06003D7C RID: 15740 RVA: 0x000E6980 File Offset: 0x000E4B80
		// (set) Token: 0x06003D7D RID: 15741 RVA: 0x000E69D8 File Offset: 0x000E4BD8
		public static IPrincipal CurrentPrincipal
		{
			[SecuritySafeCritical]
			get
			{
				Thread currentThread = Thread.CurrentThread;
				IPrincipal result;
				lock (currentThread)
				{
					IPrincipal principal = CallContext.Principal;
					if (principal == null)
					{
						principal = Thread.GetDomain().GetThreadPrincipal();
						CallContext.Principal = principal;
					}
					result = principal;
				}
				return result;
			}
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlPrincipal)]
			set
			{
				CallContext.Principal = value;
			}
		}

		// Token: 0x06003D7E RID: 15742 RVA: 0x000E69E0 File Offset: 0x000E4BE0
		[SecurityCritical]
		private void SetPrincipalInternal(IPrincipal principal)
		{
			this.GetMutableExecutionContext().LogicalCallContext.SecurityData.Principal = principal;
		}

		// Token: 0x06003D7F RID: 15743
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Context GetContextInternal(IntPtr id);

		// Token: 0x06003D80 RID: 15744
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object InternalCrossContextCallback(Context ctx, IntPtr ctxID, int appDomainID, InternalCrossContextDelegate ftnToCall, object[] args);

		// Token: 0x06003D81 RID: 15745 RVA: 0x000E69F8 File Offset: 0x000E4BF8
		[SecurityCritical]
		internal object InternalCrossContextCallback(Context ctx, InternalCrossContextDelegate ftnToCall, object[] args)
		{
			return this.InternalCrossContextCallback(ctx, ctx.InternalContextID, 0, ftnToCall, args);
		}

		// Token: 0x06003D82 RID: 15746 RVA: 0x000E6A0A File Offset: 0x000E4C0A
		private static object CompleteCrossContextCallback(InternalCrossContextDelegate ftnToCall, object[] args)
		{
			return ftnToCall(args);
		}

		// Token: 0x06003D83 RID: 15747
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain GetDomainInternal();

		// Token: 0x06003D84 RID: 15748
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain GetFastDomainInternal();

		// Token: 0x06003D85 RID: 15749 RVA: 0x000E6A14 File Offset: 0x000E4C14
		[SecuritySafeCritical]
		public static AppDomain GetDomain()
		{
			AppDomain appDomain = Thread.GetFastDomainInternal();
			if (appDomain == null)
			{
				appDomain = Thread.GetDomainInternal();
			}
			return appDomain;
		}

		// Token: 0x06003D86 RID: 15750 RVA: 0x000E6A31 File Offset: 0x000E4C31
		public static int GetDomainID()
		{
			return Thread.GetDomain().GetId();
		}

		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x06003D87 RID: 15751 RVA: 0x000E6A3D File Offset: 0x000E4C3D
		// (set) Token: 0x06003D88 RID: 15752 RVA: 0x000E6A48 File Offset: 0x000E4C48
		public string Name
		{
			get
			{
				return this.m_Name;
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
			set
			{
				lock (this)
				{
					if (this.m_Name != null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_WriteOnce"));
					}
					this.m_Name = value;
					Thread.InformThreadNameChange(this.GetNativeHandle(), value, (value != null) ? value.Length : 0);
				}
			}
		}

		// Token: 0x06003D89 RID: 15753
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void InformThreadNameChange(ThreadHandle t, string name, int len);

		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x06003D8A RID: 15754 RVA: 0x000E6AB4 File Offset: 0x000E4CB4
		// (set) Token: 0x06003D8B RID: 15755 RVA: 0x000E6AF0 File Offset: 0x000E4CF0
		internal object AbortReason
		{
			[SecurityCritical]
			get
			{
				object result = null;
				try
				{
					result = this.GetAbortReason();
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ExceptionStateCrossAppDomain"), innerException);
				}
				return result;
			}
			[SecurityCritical]
			set
			{
				this.SetAbortReason(value);
			}
		}

		// Token: 0x06003D8C RID: 15756
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginCriticalRegion();

		// Token: 0x06003D8D RID: 15757
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndCriticalRegion();

		// Token: 0x06003D8E RID: 15758
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginThreadAffinity();

		// Token: 0x06003D8F RID: 15759
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndThreadAffinity();

		// Token: 0x06003D90 RID: 15760 RVA: 0x000E6AFC File Offset: 0x000E4CFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte VolatileRead(ref byte address)
		{
			byte result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D91 RID: 15761 RVA: 0x000E6B14 File Offset: 0x000E4D14
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static short VolatileRead(ref short address)
		{
			short result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D92 RID: 15762 RVA: 0x000E6B2C File Offset: 0x000E4D2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static int VolatileRead(ref int address)
		{
			int result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D93 RID: 15763 RVA: 0x000E6B44 File Offset: 0x000E4D44
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static long VolatileRead(ref long address)
		{
			long result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D94 RID: 15764 RVA: 0x000E6B5C File Offset: 0x000E4D5C
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static sbyte VolatileRead(ref sbyte address)
		{
			sbyte result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D95 RID: 15765 RVA: 0x000E6B74 File Offset: 0x000E4D74
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ushort VolatileRead(ref ushort address)
		{
			ushort result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D96 RID: 15766 RVA: 0x000E6B8C File Offset: 0x000E4D8C
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static uint VolatileRead(ref uint address)
		{
			uint result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D97 RID: 15767 RVA: 0x000E6BA4 File Offset: 0x000E4DA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IntPtr VolatileRead(ref IntPtr address)
		{
			IntPtr result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D98 RID: 15768 RVA: 0x000E6BBC File Offset: 0x000E4DBC
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static UIntPtr VolatileRead(ref UIntPtr address)
		{
			UIntPtr result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D99 RID: 15769 RVA: 0x000E6BD4 File Offset: 0x000E4DD4
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ulong VolatileRead(ref ulong address)
		{
			ulong result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D9A RID: 15770 RVA: 0x000E6BEC File Offset: 0x000E4DEC
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static float VolatileRead(ref float address)
		{
			float result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D9B RID: 15771 RVA: 0x000E6C04 File Offset: 0x000E4E04
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double VolatileRead(ref double address)
		{
			double result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D9C RID: 15772 RVA: 0x000E6C1C File Offset: 0x000E4E1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object VolatileRead(ref object address)
		{
			object result = address;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003D9D RID: 15773 RVA: 0x000E6C32 File Offset: 0x000E4E32
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref byte address, byte value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003D9E RID: 15774 RVA: 0x000E6C3C File Offset: 0x000E4E3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref short address, short value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003D9F RID: 15775 RVA: 0x000E6C46 File Offset: 0x000E4E46
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref int address, int value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA0 RID: 15776 RVA: 0x000E6C50 File Offset: 0x000E4E50
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref long address, long value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA1 RID: 15777 RVA: 0x000E6C5A File Offset: 0x000E4E5A
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref sbyte address, sbyte value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA2 RID: 15778 RVA: 0x000E6C64 File Offset: 0x000E4E64
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref ushort address, ushort value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA3 RID: 15779 RVA: 0x000E6C6E File Offset: 0x000E4E6E
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref uint address, uint value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA4 RID: 15780 RVA: 0x000E6C78 File Offset: 0x000E4E78
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref IntPtr address, IntPtr value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA5 RID: 15781 RVA: 0x000E6C82 File Offset: 0x000E4E82
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref UIntPtr address, UIntPtr value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA6 RID: 15782 RVA: 0x000E6C8C File Offset: 0x000E4E8C
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref ulong address, ulong value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA7 RID: 15783 RVA: 0x000E6C96 File Offset: 0x000E4E96
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref float address, float value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA8 RID: 15784 RVA: 0x000E6CA0 File Offset: 0x000E4EA0
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref double address, double value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DA9 RID: 15785 RVA: 0x000E6CAA File Offset: 0x000E4EAA
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref object address, object value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		// Token: 0x06003DAA RID: 15786
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void MemoryBarrier();

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x06003DAB RID: 15787 RVA: 0x000E6CB4 File Offset: 0x000E4EB4
		private static LocalDataStoreMgr LocalDataStoreManager
		{
			get
			{
				if (Thread.s_LocalDataStoreMgr == null)
				{
					Interlocked.CompareExchange<LocalDataStoreMgr>(ref Thread.s_LocalDataStoreMgr, new LocalDataStoreMgr(), null);
				}
				return Thread.s_LocalDataStoreMgr;
			}
		}

		// Token: 0x06003DAC RID: 15788 RVA: 0x000E6CD3 File Offset: 0x000E4ED3
		void _Thread.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003DAD RID: 15789 RVA: 0x000E6CDA File Offset: 0x000E4EDA
		void _Thread.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003DAE RID: 15790 RVA: 0x000E6CE1 File Offset: 0x000E4EE1
		void _Thread.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003DAF RID: 15791 RVA: 0x000E6CE8 File Offset: 0x000E4EE8
		void _Thread.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003DB0 RID: 15792
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetAbortReason(object o);

		// Token: 0x06003DB1 RID: 15793
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object GetAbortReason();

		// Token: 0x06003DB2 RID: 15794
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void ClearAbortReason();

		// Token: 0x040019E1 RID: 6625
		private Context m_Context;

		// Token: 0x040019E2 RID: 6626
		private ExecutionContext m_ExecutionContext;

		// Token: 0x040019E3 RID: 6627
		private string m_Name;

		// Token: 0x040019E4 RID: 6628
		private Delegate m_Delegate;

		// Token: 0x040019E5 RID: 6629
		private CultureInfo m_CurrentCulture;

		// Token: 0x040019E6 RID: 6630
		private CultureInfo m_CurrentUICulture;

		// Token: 0x040019E7 RID: 6631
		private object m_ThreadStartArg;

		// Token: 0x040019E8 RID: 6632
		private IntPtr DONT_USE_InternalThread;

		// Token: 0x040019E9 RID: 6633
		private int m_Priority;

		// Token: 0x040019EA RID: 6634
		private int m_ManagedThreadId;

		// Token: 0x040019EB RID: 6635
		private bool m_ExecutionContextBelongsToOuterScope;

		// Token: 0x040019EC RID: 6636
		private static LocalDataStoreMgr s_LocalDataStoreMgr;

		// Token: 0x040019ED RID: 6637
		[ThreadStatic]
		private static LocalDataStoreHolder s_LocalDataStore;

		// Token: 0x040019EE RID: 6638
		private static AsyncLocal<CultureInfo> s_asyncLocalCurrentCulture;

		// Token: 0x040019EF RID: 6639
		private static AsyncLocal<CultureInfo> s_asyncLocalCurrentUICulture;

		// Token: 0x040019F0 RID: 6640
		[ThreadStatic]
		private static int t_currentProcessorIdCache;

		// Token: 0x040019F1 RID: 6641
		private const int ProcessorIdCacheShift = 16;

		// Token: 0x040019F2 RID: 6642
		private const int ProcessorIdCacheCountDownMask = 65535;

		// Token: 0x040019F3 RID: 6643
		private const int ProcessorIdRefreshRate = 5000;
	}
}
