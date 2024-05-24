using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Diagnostics
{
	// Token: 0x020003E5 RID: 997
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class Debugger
	{
		// Token: 0x060032F6 RID: 13046 RVA: 0x000C4A69 File Offset: 0x000C2C69
		[Obsolete("Do not create instances of the Debugger class.  Call the static methods directly on this type instead", true)]
		public Debugger()
		{
		}

		// Token: 0x060032F7 RID: 13047 RVA: 0x000C4A74 File Offset: 0x000C2C74
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void Break()
		{
			if (!Debugger.IsAttached)
			{
				try
				{
					new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
				}
				catch (SecurityException)
				{
					return;
				}
			}
			Debugger.BreakInternal();
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x000C4AB0 File Offset: 0x000C2CB0
		[SecuritySafeCritical]
		private static void BreakCanThrow()
		{
			if (!Debugger.IsAttached)
			{
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
			}
			Debugger.BreakInternal();
		}

		// Token: 0x060032F9 RID: 13049
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BreakInternal();

		// Token: 0x060032FA RID: 13050 RVA: 0x000C4ACC File Offset: 0x000C2CCC
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static bool Launch()
		{
			if (Debugger.IsAttached)
			{
				return true;
			}
			try
			{
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
			}
			catch (SecurityException)
			{
				return false;
			}
			return Debugger.LaunchInternal();
		}

		// Token: 0x060032FB RID: 13051 RVA: 0x000C4B0C File Offset: 0x000C2D0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void NotifyOfCrossThreadDependencySlow()
		{
			Debugger.CrossThreadDependencyNotification data = new Debugger.CrossThreadDependencyNotification();
			Debugger.CustomNotification(data);
			if (Debugger.s_triggerThreadAbortExceptionForDebugger)
			{
				throw new ThreadAbortException();
			}
		}

		// Token: 0x060032FC RID: 13052 RVA: 0x000C4B32 File Offset: 0x000C2D32
		[ComVisible(false)]
		public static void NotifyOfCrossThreadDependency()
		{
			if (Debugger.IsAttached)
			{
				Debugger.NotifyOfCrossThreadDependencySlow();
			}
		}

		// Token: 0x060032FD RID: 13053
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool LaunchInternal();

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x060032FE RID: 13054
		[__DynamicallyInvokable]
		public static extern bool IsAttached { [SecuritySafeCritical] [__DynamicallyInvokable] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060032FF RID: 13055
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Log(int level, string category, string message);

		// Token: 0x06003300 RID: 13056
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsLogging();

		// Token: 0x06003301 RID: 13057
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CustomNotification(ICustomDebuggerNotification data);

		// Token: 0x04001699 RID: 5785
		private static bool s_triggerThreadAbortExceptionForDebugger;

		// Token: 0x0400169A RID: 5786
		public static readonly string DefaultCategory;

		// Token: 0x02000B7F RID: 2943
		private class CrossThreadDependencyNotification : ICustomDebuggerNotification
		{
		}
	}
}
