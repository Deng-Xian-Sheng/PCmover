using System;

namespace System.Threading
{
	// Token: 0x02000514 RID: 1300
	internal struct ThreadHandle
	{
		// Token: 0x06003D1C RID: 15644 RVA: 0x000E617C File Offset: 0x000E437C
		internal ThreadHandle(IntPtr pThread)
		{
			this.m_ptr = pThread;
		}

		// Token: 0x040019E0 RID: 6624
		private IntPtr m_ptr;
	}
}
