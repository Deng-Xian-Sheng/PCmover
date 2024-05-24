using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x02000543 RID: 1347
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct CancellationTokenRegistration : IEquatable<CancellationTokenRegistration>, IDisposable
	{
		// Token: 0x06003F39 RID: 16185 RVA: 0x000EB638 File Offset: 0x000E9838
		internal CancellationTokenRegistration(CancellationCallbackInfo callbackInfo, SparselyPopulatedArrayAddInfo<CancellationCallbackInfo> registrationInfo)
		{
			this.m_callbackInfo = callbackInfo;
			this.m_registrationInfo = registrationInfo;
		}

		// Token: 0x06003F3A RID: 16186 RVA: 0x000EB648 File Offset: 0x000E9848
		[FriendAccessAllowed]
		internal bool TryDeregister()
		{
			if (this.m_registrationInfo.Source == null)
			{
				return false;
			}
			CancellationCallbackInfo cancellationCallbackInfo = this.m_registrationInfo.Source.SafeAtomicRemove(this.m_registrationInfo.Index, this.m_callbackInfo);
			return cancellationCallbackInfo == this.m_callbackInfo;
		}

		// Token: 0x06003F3B RID: 16187 RVA: 0x000EB69C File Offset: 0x000E989C
		[__DynamicallyInvokable]
		public void Dispose()
		{
			bool flag = this.TryDeregister();
			CancellationCallbackInfo callbackInfo = this.m_callbackInfo;
			if (callbackInfo != null)
			{
				CancellationTokenSource cancellationTokenSource = callbackInfo.CancellationTokenSource;
				if (cancellationTokenSource.IsCancellationRequested && !cancellationTokenSource.IsCancellationCompleted && !flag && cancellationTokenSource.ThreadIDExecutingCallbacks != Thread.CurrentThread.ManagedThreadId)
				{
					cancellationTokenSource.WaitForCallbackToComplete(this.m_callbackInfo);
				}
			}
		}

		// Token: 0x06003F3C RID: 16188 RVA: 0x000EB6F2 File Offset: 0x000E98F2
		[__DynamicallyInvokable]
		public static bool operator ==(CancellationTokenRegistration left, CancellationTokenRegistration right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003F3D RID: 16189 RVA: 0x000EB6FC File Offset: 0x000E98FC
		[__DynamicallyInvokable]
		public static bool operator !=(CancellationTokenRegistration left, CancellationTokenRegistration right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003F3E RID: 16190 RVA: 0x000EB709 File Offset: 0x000E9909
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is CancellationTokenRegistration && this.Equals((CancellationTokenRegistration)obj);
		}

		// Token: 0x06003F3F RID: 16191 RVA: 0x000EB724 File Offset: 0x000E9924
		[__DynamicallyInvokable]
		public bool Equals(CancellationTokenRegistration other)
		{
			return this.m_callbackInfo == other.m_callbackInfo && this.m_registrationInfo.Source == other.m_registrationInfo.Source && this.m_registrationInfo.Index == other.m_registrationInfo.Index;
		}

		// Token: 0x06003F40 RID: 16192 RVA: 0x000EB780 File Offset: 0x000E9980
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			if (this.m_registrationInfo.Source != null)
			{
				return this.m_registrationInfo.Source.GetHashCode() ^ this.m_registrationInfo.Index.GetHashCode();
			}
			return this.m_registrationInfo.Index.GetHashCode();
		}

		// Token: 0x04001A92 RID: 6802
		private readonly CancellationCallbackInfo m_callbackInfo;

		// Token: 0x04001A93 RID: 6803
		private readonly SparselyPopulatedArrayAddInfo<CancellationCallbackInfo> m_registrationInfo;
	}
}
