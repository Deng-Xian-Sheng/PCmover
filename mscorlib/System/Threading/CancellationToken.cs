using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x0200054A RID: 1354
	[ComVisible(false)]
	[DebuggerDisplay("IsCancellationRequested = {IsCancellationRequested}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct CancellationToken
	{
		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x06003F73 RID: 16243 RVA: 0x000EC31C File Offset: 0x000EA51C
		[__DynamicallyInvokable]
		public static CancellationToken None
		{
			[__DynamicallyInvokable]
			get
			{
				return default(CancellationToken);
			}
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06003F74 RID: 16244 RVA: 0x000EC332 File Offset: 0x000EA532
		[__DynamicallyInvokable]
		public bool IsCancellationRequested
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_source != null && this.m_source.IsCancellationRequested;
			}
		}

		// Token: 0x17000969 RID: 2409
		// (get) Token: 0x06003F75 RID: 16245 RVA: 0x000EC349 File Offset: 0x000EA549
		[__DynamicallyInvokable]
		public bool CanBeCanceled
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_source != null && this.m_source.CanBeCanceled;
			}
		}

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06003F76 RID: 16246 RVA: 0x000EC360 File Offset: 0x000EA560
		[__DynamicallyInvokable]
		public WaitHandle WaitHandle
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_source == null)
				{
					this.InitializeDefaultSource();
				}
				return this.m_source.WaitHandle;
			}
		}

		// Token: 0x06003F77 RID: 16247 RVA: 0x000EC37B File Offset: 0x000EA57B
		internal CancellationToken(CancellationTokenSource source)
		{
			this.m_source = source;
		}

		// Token: 0x06003F78 RID: 16248 RVA: 0x000EC384 File Offset: 0x000EA584
		[__DynamicallyInvokable]
		public CancellationToken(bool canceled)
		{
			this = default(CancellationToken);
			if (canceled)
			{
				this.m_source = CancellationTokenSource.InternalGetStaticSource(canceled);
			}
		}

		// Token: 0x06003F79 RID: 16249 RVA: 0x000EC39C File Offset: 0x000EA59C
		private static void ActionToActionObjShunt(object obj)
		{
			Action action = obj as Action;
			action();
		}

		// Token: 0x06003F7A RID: 16250 RVA: 0x000EC3B6 File Offset: 0x000EA5B6
		[__DynamicallyInvokable]
		public CancellationTokenRegistration Register(Action callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			return this.Register(CancellationToken.s_ActionToActionObjShunt, callback, false, true);
		}

		// Token: 0x06003F7B RID: 16251 RVA: 0x000EC3D4 File Offset: 0x000EA5D4
		[__DynamicallyInvokable]
		public CancellationTokenRegistration Register(Action callback, bool useSynchronizationContext)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			return this.Register(CancellationToken.s_ActionToActionObjShunt, callback, useSynchronizationContext, true);
		}

		// Token: 0x06003F7C RID: 16252 RVA: 0x000EC3F2 File Offset: 0x000EA5F2
		[__DynamicallyInvokable]
		public CancellationTokenRegistration Register(Action<object> callback, object state)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			return this.Register(callback, state, false, true);
		}

		// Token: 0x06003F7D RID: 16253 RVA: 0x000EC40C File Offset: 0x000EA60C
		[__DynamicallyInvokable]
		public CancellationTokenRegistration Register(Action<object> callback, object state, bool useSynchronizationContext)
		{
			return this.Register(callback, state, useSynchronizationContext, true);
		}

		// Token: 0x06003F7E RID: 16254 RVA: 0x000EC418 File Offset: 0x000EA618
		internal CancellationTokenRegistration InternalRegisterWithoutEC(Action<object> callback, object state)
		{
			return this.Register(callback, state, false, false);
		}

		// Token: 0x06003F7F RID: 16255 RVA: 0x000EC424 File Offset: 0x000EA624
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		private CancellationTokenRegistration Register(Action<object> callback, object state, bool useSynchronizationContext, bool useExecutionContext)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (!this.CanBeCanceled)
			{
				return default(CancellationTokenRegistration);
			}
			SynchronizationContext targetSyncContext = null;
			ExecutionContext executionContext = null;
			if (!this.IsCancellationRequested)
			{
				if (useSynchronizationContext)
				{
					targetSyncContext = SynchronizationContext.Current;
				}
				if (useExecutionContext)
				{
					executionContext = ExecutionContext.Capture(ref stackCrawlMark, ExecutionContext.CaptureOptions.OptimizeDefaultCase);
				}
			}
			return this.m_source.InternalRegister(callback, state, targetSyncContext, executionContext);
		}

		// Token: 0x06003F80 RID: 16256 RVA: 0x000EC484 File Offset: 0x000EA684
		[__DynamicallyInvokable]
		public bool Equals(CancellationToken other)
		{
			if (this.m_source == null && other.m_source == null)
			{
				return true;
			}
			if (this.m_source == null)
			{
				return other.m_source == CancellationTokenSource.InternalGetStaticSource(false);
			}
			if (other.m_source == null)
			{
				return this.m_source == CancellationTokenSource.InternalGetStaticSource(false);
			}
			return this.m_source == other.m_source;
		}

		// Token: 0x06003F81 RID: 16257 RVA: 0x000EC4DF File Offset: 0x000EA6DF
		[__DynamicallyInvokable]
		public override bool Equals(object other)
		{
			return other is CancellationToken && this.Equals((CancellationToken)other);
		}

		// Token: 0x06003F82 RID: 16258 RVA: 0x000EC4F7 File Offset: 0x000EA6F7
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			if (this.m_source == null)
			{
				return CancellationTokenSource.InternalGetStaticSource(false).GetHashCode();
			}
			return this.m_source.GetHashCode();
		}

		// Token: 0x06003F83 RID: 16259 RVA: 0x000EC518 File Offset: 0x000EA718
		[__DynamicallyInvokable]
		public static bool operator ==(CancellationToken left, CancellationToken right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003F84 RID: 16260 RVA: 0x000EC522 File Offset: 0x000EA722
		[__DynamicallyInvokable]
		public static bool operator !=(CancellationToken left, CancellationToken right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003F85 RID: 16261 RVA: 0x000EC52F File Offset: 0x000EA72F
		[__DynamicallyInvokable]
		public void ThrowIfCancellationRequested()
		{
			if (this.IsCancellationRequested)
			{
				this.ThrowOperationCanceledException();
			}
		}

		// Token: 0x06003F86 RID: 16262 RVA: 0x000EC53F File Offset: 0x000EA73F
		internal void ThrowIfSourceDisposed()
		{
			if (this.m_source != null && this.m_source.IsDisposed)
			{
				CancellationToken.ThrowObjectDisposedException();
			}
		}

		// Token: 0x06003F87 RID: 16263 RVA: 0x000EC55B File Offset: 0x000EA75B
		private void ThrowOperationCanceledException()
		{
			throw new OperationCanceledException(Environment.GetResourceString("OperationCanceled"), this);
		}

		// Token: 0x06003F88 RID: 16264 RVA: 0x000EC572 File Offset: 0x000EA772
		private static void ThrowObjectDisposedException()
		{
			throw new ObjectDisposedException(null, Environment.GetResourceString("CancellationToken_SourceDisposed"));
		}

		// Token: 0x06003F89 RID: 16265 RVA: 0x000EC584 File Offset: 0x000EA784
		private void InitializeDefaultSource()
		{
			this.m_source = CancellationTokenSource.InternalGetStaticSource(false);
		}

		// Token: 0x04001AB5 RID: 6837
		private CancellationTokenSource m_source;

		// Token: 0x04001AB6 RID: 6838
		private static readonly Action<object> s_ActionToActionObjShunt = new Action<object>(CancellationToken.ActionToActionObjShunt);
	}
}
