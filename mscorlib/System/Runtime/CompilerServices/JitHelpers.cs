using System;
using System.Security;
using System.Threading;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008D6 RID: 2262
	[FriendAccessAllowed]
	internal static class JitHelpers
	{
		// Token: 0x06005DC2 RID: 24002 RVA: 0x0014982C File Offset: 0x00147A2C
		[SecurityCritical]
		internal static StringHandleOnStack GetStringHandleOnStack(ref string s)
		{
			return new StringHandleOnStack(JitHelpers.UnsafeCastToStackPointer<string>(ref s));
		}

		// Token: 0x06005DC3 RID: 24003 RVA: 0x00149839 File Offset: 0x00147A39
		[SecurityCritical]
		internal static ObjectHandleOnStack GetObjectHandleOnStack<T>(ref T o) where T : class
		{
			return new ObjectHandleOnStack(JitHelpers.UnsafeCastToStackPointer<T>(ref o));
		}

		// Token: 0x06005DC4 RID: 24004 RVA: 0x00149846 File Offset: 0x00147A46
		[SecurityCritical]
		internal static StackCrawlMarkHandle GetStackCrawlMarkHandle(ref StackCrawlMark stackMark)
		{
			return new StackCrawlMarkHandle(JitHelpers.UnsafeCastToStackPointer<StackCrawlMark>(ref stackMark));
		}

		// Token: 0x06005DC5 RID: 24005 RVA: 0x00149853 File Offset: 0x00147A53
		[SecurityCritical]
		[FriendAccessAllowed]
		internal static T UnsafeCast<T>(object o) where T : class
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06005DC6 RID: 24006 RVA: 0x0014985A File Offset: 0x00147A5A
		internal static int UnsafeEnumCast<T>(T val) where T : struct
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06005DC7 RID: 24007 RVA: 0x00149861 File Offset: 0x00147A61
		internal static long UnsafeEnumCastLong<T>(T val) where T : struct
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06005DC8 RID: 24008 RVA: 0x00149868 File Offset: 0x00147A68
		[SecurityCritical]
		internal static IntPtr UnsafeCastToStackPointer<T>(ref T val)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06005DC9 RID: 24009
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void UnsafeSetArrayElement(object[] target, int index, object element);

		// Token: 0x06005DCA RID: 24010 RVA: 0x0014986F File Offset: 0x00147A6F
		[SecurityCritical]
		internal static PinningHelper GetPinningHelper(object o)
		{
			return JitHelpers.UnsafeCast<PinningHelper>(o);
		}

		// Token: 0x04002A31 RID: 10801
		internal const string QCall = "QCall";
	}
}
