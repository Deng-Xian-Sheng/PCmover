using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000513 RID: 1299
	internal class ThreadHelper
	{
		// Token: 0x06003D17 RID: 15639 RVA: 0x000E60B9 File Offset: 0x000E42B9
		internal ThreadHelper(Delegate start)
		{
			this._start = start;
		}

		// Token: 0x06003D18 RID: 15640 RVA: 0x000E60C8 File Offset: 0x000E42C8
		internal void SetExecutionContextHelper(ExecutionContext ec)
		{
			this._executionContext = ec;
		}

		// Token: 0x06003D19 RID: 15641 RVA: 0x000E60D4 File Offset: 0x000E42D4
		[SecurityCritical]
		private static void ThreadStart_Context(object state)
		{
			ThreadHelper threadHelper = (ThreadHelper)state;
			if (threadHelper._start is ThreadStart)
			{
				((ThreadStart)threadHelper._start)();
				return;
			}
			((ParameterizedThreadStart)threadHelper._start)(threadHelper._startArg);
		}

		// Token: 0x06003D1A RID: 15642 RVA: 0x000E611C File Offset: 0x000E431C
		[SecurityCritical]
		internal void ThreadStart(object obj)
		{
			this._startArg = obj;
			if (this._executionContext != null)
			{
				ExecutionContext.Run(this._executionContext, ThreadHelper._ccb, this);
				return;
			}
			((ParameterizedThreadStart)this._start)(obj);
		}

		// Token: 0x06003D1B RID: 15643 RVA: 0x000E6150 File Offset: 0x000E4350
		[SecurityCritical]
		internal void ThreadStart()
		{
			if (this._executionContext != null)
			{
				ExecutionContext.Run(this._executionContext, ThreadHelper._ccb, this);
				return;
			}
			((ThreadStart)this._start)();
		}

		// Token: 0x040019DC RID: 6620
		private Delegate _start;

		// Token: 0x040019DD RID: 6621
		private object _startArg;

		// Token: 0x040019DE RID: 6622
		private ExecutionContext _executionContext;

		// Token: 0x040019DF RID: 6623
		[SecurityCritical]
		internal static ContextCallback _ccb = new ContextCallback(ThreadHelper.ThreadStart_Context);
	}
}
