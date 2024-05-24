using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x020004ED RID: 1261
	[__DynamicallyInvokable]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = (SecurityPermissionFlag.ControlEvidence | SecurityPermissionFlag.ControlPolicy))]
	public class SynchronizationContext
	{
		// Token: 0x06003B8C RID: 15244 RVA: 0x000E24BB File Offset: 0x000E06BB
		[__DynamicallyInvokable]
		public SynchronizationContext()
		{
		}

		// Token: 0x06003B8D RID: 15245 RVA: 0x000E24C4 File Offset: 0x000E06C4
		[SecuritySafeCritical]
		protected void SetWaitNotificationRequired()
		{
			Type type = base.GetType();
			if (SynchronizationContext.s_cachedPreparedType1 != type && SynchronizationContext.s_cachedPreparedType2 != type && SynchronizationContext.s_cachedPreparedType3 != type && SynchronizationContext.s_cachedPreparedType4 != type && SynchronizationContext.s_cachedPreparedType5 != type)
			{
				RuntimeHelpers.PrepareDelegate(new SynchronizationContext.WaitDelegate(this.Wait));
				if (SynchronizationContext.s_cachedPreparedType1 == null)
				{
					SynchronizationContext.s_cachedPreparedType1 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType2 == null)
				{
					SynchronizationContext.s_cachedPreparedType2 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType3 == null)
				{
					SynchronizationContext.s_cachedPreparedType3 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType4 == null)
				{
					SynchronizationContext.s_cachedPreparedType4 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType5 == null)
				{
					SynchronizationContext.s_cachedPreparedType5 = type;
				}
			}
			this._props |= SynchronizationContextProperties.RequireWaitNotification;
		}

		// Token: 0x06003B8E RID: 15246 RVA: 0x000E25AC File Offset: 0x000E07AC
		public bool IsWaitNotificationRequired()
		{
			return (this._props & SynchronizationContextProperties.RequireWaitNotification) > SynchronizationContextProperties.None;
		}

		// Token: 0x06003B8F RID: 15247 RVA: 0x000E25B9 File Offset: 0x000E07B9
		[__DynamicallyInvokable]
		public virtual void Send(SendOrPostCallback d, object state)
		{
			d(state);
		}

		// Token: 0x06003B90 RID: 15248 RVA: 0x000E25C2 File Offset: 0x000E07C2
		[__DynamicallyInvokable]
		public virtual void Post(SendOrPostCallback d, object state)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(d.Invoke), state);
		}

		// Token: 0x06003B91 RID: 15249 RVA: 0x000E25D7 File Offset: 0x000E07D7
		[__DynamicallyInvokable]
		public virtual void OperationStarted()
		{
		}

		// Token: 0x06003B92 RID: 15250 RVA: 0x000E25D9 File Offset: 0x000E07D9
		[__DynamicallyInvokable]
		public virtual void OperationCompleted()
		{
		}

		// Token: 0x06003B93 RID: 15251 RVA: 0x000E25DB File Offset: 0x000E07DB
		[SecurityCritical]
		[CLSCompliant(false)]
		[PrePrepareMethod]
		public virtual int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
		{
			if (waitHandles == null)
			{
				throw new ArgumentNullException("waitHandles");
			}
			return SynchronizationContext.WaitHelper(waitHandles, waitAll, millisecondsTimeout);
		}

		// Token: 0x06003B94 RID: 15252
		[SecurityCritical]
		[CLSCompliant(false)]
		[PrePrepareMethod]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		protected static extern int WaitHelper(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout);

		// Token: 0x06003B95 RID: 15253 RVA: 0x000E25F4 File Offset: 0x000E07F4
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void SetSynchronizationContext(SynchronizationContext syncContext)
		{
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			mutableExecutionContext.SynchronizationContext = syncContext;
			mutableExecutionContext.SynchronizationContextNoFlow = syncContext;
		}

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06003B96 RID: 15254 RVA: 0x000E261C File Offset: 0x000E081C
		[__DynamicallyInvokable]
		public static SynchronizationContext Current
		{
			[__DynamicallyInvokable]
			get
			{
				return Thread.CurrentThread.GetExecutionContextReader().SynchronizationContext ?? SynchronizationContext.GetThreadLocalContext();
			}
		}

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x06003B97 RID: 15255 RVA: 0x000E2644 File Offset: 0x000E0844
		internal static SynchronizationContext CurrentNoFlow
		{
			[FriendAccessAllowed]
			get
			{
				return Thread.CurrentThread.GetExecutionContextReader().SynchronizationContextNoFlow ?? SynchronizationContext.GetThreadLocalContext();
			}
		}

		// Token: 0x06003B98 RID: 15256 RVA: 0x000E266C File Offset: 0x000E086C
		private static SynchronizationContext GetThreadLocalContext()
		{
			SynchronizationContext synchronizationContext = null;
			if (synchronizationContext == null && Environment.IsWinRTSupported)
			{
				synchronizationContext = SynchronizationContext.GetWinRTContext();
			}
			return synchronizationContext;
		}

		// Token: 0x06003B99 RID: 15257 RVA: 0x000E268C File Offset: 0x000E088C
		[SecuritySafeCritical]
		private static SynchronizationContext GetWinRTContext()
		{
			if (!AppDomain.IsAppXModel())
			{
				return null;
			}
			object winRTDispatcherForCurrentThread = SynchronizationContext.GetWinRTDispatcherForCurrentThread();
			if (winRTDispatcherForCurrentThread != null)
			{
				return SynchronizationContext.GetWinRTSynchronizationContextFactory().Create(winRTDispatcherForCurrentThread);
			}
			return null;
		}

		// Token: 0x06003B9A RID: 15258 RVA: 0x000E26B8 File Offset: 0x000E08B8
		[SecurityCritical]
		private static WinRTSynchronizationContextFactoryBase GetWinRTSynchronizationContextFactory()
		{
			WinRTSynchronizationContextFactoryBase winRTSynchronizationContextFactoryBase = SynchronizationContext.s_winRTContextFactory;
			if (winRTSynchronizationContextFactoryBase == null)
			{
				Type type = Type.GetType("System.Threading.WinRTSynchronizationContextFactory, System.Runtime.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true);
				winRTSynchronizationContextFactoryBase = (SynchronizationContext.s_winRTContextFactory = (WinRTSynchronizationContextFactoryBase)Activator.CreateInstance(type, true));
			}
			return winRTSynchronizationContextFactoryBase;
		}

		// Token: 0x06003B9B RID: 15259
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Interface)]
		private static extern object GetWinRTDispatcherForCurrentThread();

		// Token: 0x06003B9C RID: 15260 RVA: 0x000E26EE File Offset: 0x000E08EE
		[__DynamicallyInvokable]
		public virtual SynchronizationContext CreateCopy()
		{
			return new SynchronizationContext();
		}

		// Token: 0x06003B9D RID: 15261 RVA: 0x000E26F5 File Offset: 0x000E08F5
		[SecurityCritical]
		private static int InvokeWaitMethodHelper(SynchronizationContext syncContext, IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
		{
			return syncContext.Wait(waitHandles, waitAll, millisecondsTimeout);
		}

		// Token: 0x04001967 RID: 6503
		private SynchronizationContextProperties _props;

		// Token: 0x04001968 RID: 6504
		private static Type s_cachedPreparedType1;

		// Token: 0x04001969 RID: 6505
		private static Type s_cachedPreparedType2;

		// Token: 0x0400196A RID: 6506
		private static Type s_cachedPreparedType3;

		// Token: 0x0400196B RID: 6507
		private static Type s_cachedPreparedType4;

		// Token: 0x0400196C RID: 6508
		private static Type s_cachedPreparedType5;

		// Token: 0x0400196D RID: 6509
		[SecurityCritical]
		private static WinRTSynchronizationContextFactoryBase s_winRTContextFactory;

		// Token: 0x02000BEA RID: 3050
		// (Invoke) Token: 0x06006F4B RID: 28491
		private delegate int WaitDelegate(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout);
	}
}
