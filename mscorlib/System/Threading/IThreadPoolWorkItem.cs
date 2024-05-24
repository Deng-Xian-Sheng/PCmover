using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000521 RID: 1313
	internal interface IThreadPoolWorkItem
	{
		// Token: 0x06003DDE RID: 15838
		[SecurityCritical]
		void ExecuteWorkItem();

		// Token: 0x06003DDF RID: 15839
		[SecurityCritical]
		void MarkAborted(ThreadAbortException tae);
	}
}
