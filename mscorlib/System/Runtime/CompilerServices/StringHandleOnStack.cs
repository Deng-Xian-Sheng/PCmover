using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008D2 RID: 2258
	internal struct StringHandleOnStack
	{
		// Token: 0x06005DBE RID: 23998 RVA: 0x00149809 File Offset: 0x00147A09
		internal StringHandleOnStack(IntPtr pString)
		{
			this.m_ptr = pString;
		}

		// Token: 0x04002A2D RID: 10797
		private IntPtr m_ptr;
	}
}
