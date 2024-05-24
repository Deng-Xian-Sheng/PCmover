using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008D4 RID: 2260
	internal struct StackCrawlMarkHandle
	{
		// Token: 0x06005DC0 RID: 24000 RVA: 0x0014981B File Offset: 0x00147A1B
		internal StackCrawlMarkHandle(IntPtr stackMark)
		{
			this.m_ptr = stackMark;
		}

		// Token: 0x04002A2F RID: 10799
		private IntPtr m_ptr;
	}
}
