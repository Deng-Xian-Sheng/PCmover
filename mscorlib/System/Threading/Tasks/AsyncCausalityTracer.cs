using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using Microsoft.Win32;
using Windows.Foundation.Diagnostics;

namespace System.Threading.Tasks
{
	// Token: 0x0200057F RID: 1407
	[FriendAccessAllowed]
	internal static class AsyncCausalityTracer
	{
		// Token: 0x06004238 RID: 16952 RVA: 0x000F683B File Offset: 0x000F4A3B
		internal static void EnableToETW(bool enabled)
		{
			if (enabled)
			{
				AsyncCausalityTracer.f_LoggingOn |= AsyncCausalityTracer.Loggers.ETW;
				return;
			}
			AsyncCausalityTracer.f_LoggingOn &= ~AsyncCausalityTracer.Loggers.ETW;
		}

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06004239 RID: 16953 RVA: 0x000F685D File Offset: 0x000F4A5D
		[FriendAccessAllowed]
		internal static bool LoggingOn
		{
			[FriendAccessAllowed]
			get
			{
				return AsyncCausalityTracer.f_LoggingOn > (AsyncCausalityTracer.Loggers)0;
			}
		}

		// Token: 0x0600423A RID: 16954 RVA: 0x000F6868 File Offset: 0x000F4A68
		[SecuritySafeCritical]
		static AsyncCausalityTracer()
		{
			if (!Environment.IsWinRTSupported)
			{
				return;
			}
			string activatableClassId = "Windows.Foundation.Diagnostics.AsyncCausalityTracer";
			Guid guid = new Guid(1350896422, 9854, 17691, 168, 144, 171, 106, 55, 2, 69, 238);
			object obj = null;
			try
			{
				int num = Microsoft.Win32.UnsafeNativeMethods.RoGetActivationFactory(activatableClassId, ref guid, out obj);
				if (num >= 0 && obj != null)
				{
					AsyncCausalityTracer.s_TracerFactory = (IAsyncCausalityTracerStatics)obj;
					EventRegistrationToken eventRegistrationToken = AsyncCausalityTracer.s_TracerFactory.add_TracingStatusChanged(new EventHandler<TracingStatusChangedEventArgs>(AsyncCausalityTracer.TracingStatusChangedHandler));
				}
			}
			catch (Exception ex)
			{
				AsyncCausalityTracer.LogAndDisable(ex);
			}
		}

		// Token: 0x0600423B RID: 16955 RVA: 0x000F693C File Offset: 0x000F4B3C
		[SecuritySafeCritical]
		private static void TracingStatusChangedHandler(object sender, TracingStatusChangedEventArgs args)
		{
			if (args.Enabled)
			{
				AsyncCausalityTracer.f_LoggingOn |= AsyncCausalityTracer.Loggers.CausalityTracer;
				return;
			}
			AsyncCausalityTracer.f_LoggingOn &= ~AsyncCausalityTracer.Loggers.CausalityTracer;
		}

		// Token: 0x0600423C RID: 16956 RVA: 0x000F6964 File Offset: 0x000F4B64
		[FriendAccessAllowed]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TraceOperationCreation(CausalityTraceLevel traceLevel, int taskId, string operationName, ulong relatedContext)
		{
			try
			{
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.ETW) != (AsyncCausalityTracer.Loggers)0)
				{
					TplEtwProvider.Log.TraceOperationBegin(taskId, operationName, (long)relatedContext);
				}
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.CausalityTracer) != (AsyncCausalityTracer.Loggers)0)
				{
					AsyncCausalityTracer.s_TracerFactory.TraceOperationCreation((CausalityTraceLevel)traceLevel, CausalitySource.Library, AsyncCausalityTracer.s_PlatformId, AsyncCausalityTracer.GetOperationId((uint)taskId), operationName, relatedContext);
				}
			}
			catch (Exception ex)
			{
				AsyncCausalityTracer.LogAndDisable(ex);
			}
		}

		// Token: 0x0600423D RID: 16957 RVA: 0x000F69C4 File Offset: 0x000F4BC4
		[FriendAccessAllowed]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TraceOperationCompletion(CausalityTraceLevel traceLevel, int taskId, AsyncCausalityStatus status)
		{
			try
			{
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.ETW) != (AsyncCausalityTracer.Loggers)0)
				{
					TplEtwProvider.Log.TraceOperationEnd(taskId, status);
				}
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.CausalityTracer) != (AsyncCausalityTracer.Loggers)0)
				{
					AsyncCausalityTracer.s_TracerFactory.TraceOperationCompletion((CausalityTraceLevel)traceLevel, CausalitySource.Library, AsyncCausalityTracer.s_PlatformId, AsyncCausalityTracer.GetOperationId((uint)taskId), (AsyncCausalityStatus)status);
				}
			}
			catch (Exception ex)
			{
				AsyncCausalityTracer.LogAndDisable(ex);
			}
		}

		// Token: 0x0600423E RID: 16958 RVA: 0x000F6A24 File Offset: 0x000F4C24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TraceOperationRelation(CausalityTraceLevel traceLevel, int taskId, CausalityRelation relation)
		{
			try
			{
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.ETW) != (AsyncCausalityTracer.Loggers)0)
				{
					TplEtwProvider.Log.TraceOperationRelation(taskId, relation);
				}
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.CausalityTracer) != (AsyncCausalityTracer.Loggers)0)
				{
					AsyncCausalityTracer.s_TracerFactory.TraceOperationRelation((CausalityTraceLevel)traceLevel, CausalitySource.Library, AsyncCausalityTracer.s_PlatformId, AsyncCausalityTracer.GetOperationId((uint)taskId), (CausalityRelation)relation);
				}
			}
			catch (Exception ex)
			{
				AsyncCausalityTracer.LogAndDisable(ex);
			}
		}

		// Token: 0x0600423F RID: 16959 RVA: 0x000F6A84 File Offset: 0x000F4C84
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TraceSynchronousWorkStart(CausalityTraceLevel traceLevel, int taskId, CausalitySynchronousWork work)
		{
			try
			{
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.ETW) != (AsyncCausalityTracer.Loggers)0)
				{
					TplEtwProvider.Log.TraceSynchronousWorkBegin(taskId, work);
				}
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.CausalityTracer) != (AsyncCausalityTracer.Loggers)0)
				{
					AsyncCausalityTracer.s_TracerFactory.TraceSynchronousWorkStart((CausalityTraceLevel)traceLevel, CausalitySource.Library, AsyncCausalityTracer.s_PlatformId, AsyncCausalityTracer.GetOperationId((uint)taskId), (CausalitySynchronousWork)work);
				}
			}
			catch (Exception ex)
			{
				AsyncCausalityTracer.LogAndDisable(ex);
			}
		}

		// Token: 0x06004240 RID: 16960 RVA: 0x000F6AE4 File Offset: 0x000F4CE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TraceSynchronousWorkCompletion(CausalityTraceLevel traceLevel, CausalitySynchronousWork work)
		{
			try
			{
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.ETW) != (AsyncCausalityTracer.Loggers)0)
				{
					TplEtwProvider.Log.TraceSynchronousWorkEnd(work);
				}
				if ((AsyncCausalityTracer.f_LoggingOn & AsyncCausalityTracer.Loggers.CausalityTracer) != (AsyncCausalityTracer.Loggers)0)
				{
					AsyncCausalityTracer.s_TracerFactory.TraceSynchronousWorkCompletion((CausalityTraceLevel)traceLevel, CausalitySource.Library, (CausalitySynchronousWork)work);
				}
			}
			catch (Exception ex)
			{
				AsyncCausalityTracer.LogAndDisable(ex);
			}
		}

		// Token: 0x06004241 RID: 16961 RVA: 0x000F6B38 File Offset: 0x000F4D38
		private static void LogAndDisable(Exception ex)
		{
			AsyncCausalityTracer.f_LoggingOn = (AsyncCausalityTracer.Loggers)0;
			Debugger.Log(0, "AsyncCausalityTracer", ex.ToString());
		}

		// Token: 0x06004242 RID: 16962 RVA: 0x000F6B51 File Offset: 0x000F4D51
		private static ulong GetOperationId(uint taskId)
		{
			return (ulong)(((long)AppDomain.CurrentDomain.Id << 32) + (long)((ulong)taskId));
		}

		// Token: 0x04001B85 RID: 7045
		private static readonly Guid s_PlatformId = new Guid(1258385830U, 62416, 16800, 155, 51, 2, 85, 6, 82, 185, 149);

		// Token: 0x04001B86 RID: 7046
		private const CausalitySource s_CausalitySource = CausalitySource.Library;

		// Token: 0x04001B87 RID: 7047
		private static IAsyncCausalityTracerStatics s_TracerFactory;

		// Token: 0x04001B88 RID: 7048
		private static AsyncCausalityTracer.Loggers f_LoggingOn;

		// Token: 0x02000C23 RID: 3107
		[Flags]
		private enum Loggers : byte
		{
			// Token: 0x040036D8 RID: 14040
			CausalityTracer = 1,
			// Token: 0x040036D9 RID: 14041
			ETW = 2
		}
	}
}
