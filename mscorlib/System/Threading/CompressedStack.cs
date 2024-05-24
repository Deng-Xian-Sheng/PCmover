using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004F0 RID: 1264
	[Serializable]
	public sealed class CompressedStack : ISerializable
	{
		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06003BA8 RID: 15272 RVA: 0x000E2876 File Offset: 0x000E0A76
		// (set) Token: 0x06003BA9 RID: 15273 RVA: 0x000E287E File Offset: 0x000E0A7E
		internal bool CanSkipEvaluation
		{
			get
			{
				return this.m_canSkipEvaluation;
			}
			private set
			{
				this.m_canSkipEvaluation = value;
			}
		}

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x06003BAA RID: 15274 RVA: 0x000E2887 File Offset: 0x000E0A87
		internal PermissionListSet PLS
		{
			get
			{
				return this.m_pls;
			}
		}

		// Token: 0x06003BAB RID: 15275 RVA: 0x000E2891 File Offset: 0x000E0A91
		[SecurityCritical]
		internal CompressedStack(SafeCompressedStackHandle csHandle)
		{
			this.m_csHandle = csHandle;
		}

		// Token: 0x06003BAC RID: 15276 RVA: 0x000E28A2 File Offset: 0x000E0AA2
		[SecurityCritical]
		private CompressedStack(SafeCompressedStackHandle csHandle, PermissionListSet pls)
		{
			this.m_csHandle = csHandle;
			this.m_pls = pls;
		}

		// Token: 0x06003BAD RID: 15277 RVA: 0x000E28BC File Offset: 0x000E0ABC
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.CompleteConstruction(null);
			info.AddValue("PLS", this.m_pls);
		}

		// Token: 0x06003BAE RID: 15278 RVA: 0x000E28E6 File Offset: 0x000E0AE6
		private CompressedStack(SerializationInfo info, StreamingContext context)
		{
			this.m_pls = (PermissionListSet)info.GetValue("PLS", typeof(PermissionListSet));
		}

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x06003BAF RID: 15279 RVA: 0x000E2910 File Offset: 0x000E0B10
		// (set) Token: 0x06003BB0 RID: 15280 RVA: 0x000E291A File Offset: 0x000E0B1A
		internal SafeCompressedStackHandle CompressedStackHandle
		{
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.m_csHandle;
			}
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			private set
			{
				this.m_csHandle = value;
			}
		}

		// Token: 0x06003BB1 RID: 15281 RVA: 0x000E2928 File Offset: 0x000E0B28
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static CompressedStack GetCompressedStack()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return CompressedStack.GetCompressedStack(ref stackCrawlMark);
		}

		// Token: 0x06003BB2 RID: 15282 RVA: 0x000E2940 File Offset: 0x000E0B40
		[SecurityCritical]
		internal static CompressedStack GetCompressedStack(ref StackCrawlMark stackMark)
		{
			CompressedStack innerCS = null;
			CompressedStack compressedStack;
			if (CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				compressedStack = new CompressedStack(null);
				compressedStack.CanSkipEvaluation = true;
			}
			else if (CodeAccessSecurityEngine.AllDomainsHomogeneousWithNoStackModifiers())
			{
				compressedStack = new CompressedStack(CompressedStack.GetDelayedCompressedStack(ref stackMark, false));
				compressedStack.m_pls = PermissionListSet.CreateCompressedState_HG();
			}
			else
			{
				compressedStack = new CompressedStack(null);
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
				}
				finally
				{
					compressedStack.CompressedStackHandle = CompressedStack.GetDelayedCompressedStack(ref stackMark, true);
					if (compressedStack.CompressedStackHandle != null && CompressedStack.IsImmediateCompletionCandidate(compressedStack.CompressedStackHandle, out innerCS))
					{
						try
						{
							compressedStack.CompleteConstruction(innerCS);
						}
						finally
						{
							CompressedStack.DestroyDCSList(compressedStack.CompressedStackHandle);
						}
					}
				}
			}
			return compressedStack;
		}

		// Token: 0x06003BB3 RID: 15283 RVA: 0x000E29F0 File Offset: 0x000E0BF0
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static CompressedStack Capture()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return CompressedStack.GetCompressedStack(ref stackCrawlMark);
		}

		// Token: 0x06003BB4 RID: 15284 RVA: 0x000E2A08 File Offset: 0x000E0C08
		[SecurityCritical]
		public static void Run(CompressedStack compressedStack, ContextCallback callback, object state)
		{
			if (compressedStack == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_NamedParamNull"), "compressedStack");
			}
			if (CompressedStack.cleanupCode == null)
			{
				CompressedStack.tryCode = new RuntimeHelpers.TryCode(CompressedStack.runTryCode);
				CompressedStack.cleanupCode = new RuntimeHelpers.CleanupCode(CompressedStack.runFinallyCode);
			}
			CompressedStack.CompressedStackRunData userData = new CompressedStack.CompressedStackRunData(compressedStack, callback, state);
			RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(CompressedStack.tryCode, CompressedStack.cleanupCode, userData);
		}

		// Token: 0x06003BB5 RID: 15285 RVA: 0x000E2A7C File Offset: 0x000E0C7C
		[SecurityCritical]
		internal static void runTryCode(object userData)
		{
			CompressedStack.CompressedStackRunData compressedStackRunData = (CompressedStack.CompressedStackRunData)userData;
			compressedStackRunData.cssw = CompressedStack.SetCompressedStack(compressedStackRunData.cs, CompressedStack.GetCompressedStackThread());
			compressedStackRunData.callBack(compressedStackRunData.state);
		}

		// Token: 0x06003BB6 RID: 15286 RVA: 0x000E2AB8 File Offset: 0x000E0CB8
		[SecurityCritical]
		[PrePrepareMethod]
		internal static void runFinallyCode(object userData, bool exceptionThrown)
		{
			CompressedStack.CompressedStackRunData compressedStackRunData = (CompressedStack.CompressedStackRunData)userData;
			compressedStackRunData.cssw.Undo();
		}

		// Token: 0x06003BB7 RID: 15287 RVA: 0x000E2AD8 File Offset: 0x000E0CD8
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static CompressedStackSwitcher SetCompressedStack(CompressedStack cs, CompressedStack prevCS)
		{
			CompressedStackSwitcher result = default(CompressedStackSwitcher);
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
				}
				finally
				{
					CompressedStack.SetCompressedStackThread(cs);
					result.prev_CS = prevCS;
					result.curr_CS = cs;
					result.prev_ADStack = CompressedStack.SetAppDomainStack(cs);
				}
			}
			catch
			{
				result.UndoNoThrow();
				throw;
			}
			return result;
		}

		// Token: 0x06003BB8 RID: 15288 RVA: 0x000E2B48 File Offset: 0x000E0D48
		[SecuritySafeCritical]
		[ComVisible(false)]
		public CompressedStack CreateCopy()
		{
			return new CompressedStack(this.m_csHandle, this.m_pls);
		}

		// Token: 0x06003BB9 RID: 15289 RVA: 0x000E2B5F File Offset: 0x000E0D5F
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal static IntPtr SetAppDomainStack(CompressedStack cs)
		{
			return Thread.CurrentThread.SetAppDomainStack((cs == null) ? null : cs.CompressedStackHandle);
		}

		// Token: 0x06003BBA RID: 15290 RVA: 0x000E2B77 File Offset: 0x000E0D77
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal static void RestoreAppDomainStack(IntPtr appDomainStack)
		{
			Thread.CurrentThread.RestoreAppDomainStack(appDomainStack);
		}

		// Token: 0x06003BBB RID: 15291 RVA: 0x000E2B84 File Offset: 0x000E0D84
		[SecurityCritical]
		internal static CompressedStack GetCompressedStackThread()
		{
			return Thread.CurrentThread.GetExecutionContextReader().SecurityContext.CompressedStack;
		}

		// Token: 0x06003BBC RID: 15292 RVA: 0x000E2BAC File Offset: 0x000E0DAC
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal static void SetCompressedStackThread(CompressedStack cs)
		{
			Thread currentThread = Thread.CurrentThread;
			if (currentThread.GetExecutionContextReader().SecurityContext.CompressedStack != cs)
			{
				ExecutionContext mutableExecutionContext = currentThread.GetMutableExecutionContext();
				if (mutableExecutionContext.SecurityContext != null)
				{
					mutableExecutionContext.SecurityContext.CompressedStack = cs;
					return;
				}
				if (cs != null)
				{
					mutableExecutionContext.SecurityContext = new SecurityContext
					{
						CompressedStack = cs
					};
				}
			}
		}

		// Token: 0x06003BBD RID: 15293 RVA: 0x000E2C0E File Offset: 0x000E0E0E
		[SecurityCritical]
		internal bool CheckDemand(CodeAccessPermission demand, PermissionToken permToken, RuntimeMethodHandleInternal rmh)
		{
			this.CompleteConstruction(null);
			if (this.PLS == null)
			{
				return false;
			}
			this.PLS.CheckDemand(demand, permToken, rmh);
			return false;
		}

		// Token: 0x06003BBE RID: 15294 RVA: 0x000E2C31 File Offset: 0x000E0E31
		[SecurityCritical]
		internal bool CheckDemandNoHalt(CodeAccessPermission demand, PermissionToken permToken, RuntimeMethodHandleInternal rmh)
		{
			this.CompleteConstruction(null);
			return this.PLS == null || this.PLS.CheckDemand(demand, permToken, rmh);
		}

		// Token: 0x06003BBF RID: 15295 RVA: 0x000E2C52 File Offset: 0x000E0E52
		[SecurityCritical]
		internal bool CheckSetDemand(PermissionSet pset, RuntimeMethodHandleInternal rmh)
		{
			this.CompleteConstruction(null);
			return this.PLS != null && this.PLS.CheckSetDemand(pset, rmh);
		}

		// Token: 0x06003BC0 RID: 15296 RVA: 0x000E2C72 File Offset: 0x000E0E72
		[SecurityCritical]
		internal bool CheckSetDemandWithModificationNoHalt(PermissionSet pset, out PermissionSet alteredDemandSet, RuntimeMethodHandleInternal rmh)
		{
			alteredDemandSet = null;
			this.CompleteConstruction(null);
			return this.PLS == null || this.PLS.CheckSetDemandWithModification(pset, out alteredDemandSet, rmh);
		}

		// Token: 0x06003BC1 RID: 15297 RVA: 0x000E2C96 File Offset: 0x000E0E96
		[SecurityCritical]
		internal void DemandFlagsOrGrantSet(int flags, PermissionSet grantSet)
		{
			this.CompleteConstruction(null);
			if (this.PLS == null)
			{
				return;
			}
			this.PLS.DemandFlagsOrGrantSet(flags, grantSet);
		}

		// Token: 0x06003BC2 RID: 15298 RVA: 0x000E2CB5 File Offset: 0x000E0EB5
		[SecurityCritical]
		internal void GetZoneAndOrigin(ArrayList zoneList, ArrayList originList, PermissionToken zoneToken, PermissionToken originToken)
		{
			this.CompleteConstruction(null);
			if (this.PLS != null)
			{
				this.PLS.GetZoneAndOrigin(zoneList, originList, zoneToken, originToken);
			}
		}

		// Token: 0x06003BC3 RID: 15299 RVA: 0x000E2CD8 File Offset: 0x000E0ED8
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal void CompleteConstruction(CompressedStack innerCS)
		{
			if (this.PLS != null)
			{
				return;
			}
			PermissionListSet pls = PermissionListSet.CreateCompressedState(this, innerCS);
			lock (this)
			{
				if (this.PLS == null)
				{
					this.m_pls = pls;
				}
			}
		}

		// Token: 0x06003BC4 RID: 15300
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern SafeCompressedStackHandle GetDelayedCompressedStack(ref StackCrawlMark stackMark, bool walkStack);

		// Token: 0x06003BC5 RID: 15301
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void DestroyDelayedCompressedStack(IntPtr unmanagedCompressedStack);

		// Token: 0x06003BC6 RID: 15302
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void DestroyDCSList(SafeCompressedStackHandle compressedStack);

		// Token: 0x06003BC7 RID: 15303
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetDCSCount(SafeCompressedStackHandle compressedStack);

		// Token: 0x06003BC8 RID: 15304
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsImmediateCompletionCandidate(SafeCompressedStackHandle compressedStack, out CompressedStack innerCS);

		// Token: 0x06003BC9 RID: 15305
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern DomainCompressedStack GetDomainCompressedStack(SafeCompressedStackHandle compressedStack, int index);

		// Token: 0x06003BCA RID: 15306
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void GetHomogeneousPLS(PermissionListSet hgPLS);

		// Token: 0x04001971 RID: 6513
		private volatile PermissionListSet m_pls;

		// Token: 0x04001972 RID: 6514
		[SecurityCritical]
		private volatile SafeCompressedStackHandle m_csHandle;

		// Token: 0x04001973 RID: 6515
		private bool m_canSkipEvaluation;

		// Token: 0x04001974 RID: 6516
		internal static volatile RuntimeHelpers.TryCode tryCode;

		// Token: 0x04001975 RID: 6517
		internal static volatile RuntimeHelpers.CleanupCode cleanupCode;

		// Token: 0x02000BEB RID: 3051
		internal class CompressedStackRunData
		{
			// Token: 0x06006F4E RID: 28494 RVA: 0x0017F928 File Offset: 0x0017DB28
			internal CompressedStackRunData(CompressedStack cs, ContextCallback cb, object state)
			{
				this.cs = cs;
				this.callBack = cb;
				this.state = state;
				this.cssw = default(CompressedStackSwitcher);
			}

			// Token: 0x04003606 RID: 13830
			internal CompressedStack cs;

			// Token: 0x04003607 RID: 13831
			internal ContextCallback callBack;

			// Token: 0x04003608 RID: 13832
			internal object state;

			// Token: 0x04003609 RID: 13833
			internal CompressedStackSwitcher cssw;
		}
	}
}
