using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008D3 RID: 2259
	internal struct ObjectHandleOnStack
	{
		// Token: 0x06005DBF RID: 23999 RVA: 0x00149812 File Offset: 0x00147A12
		internal ObjectHandleOnStack(IntPtr pObject)
		{
			this.m_ptr = pObject;
		}

		// Token: 0x04002A2E RID: 10798
		private IntPtr m_ptr;
	}
}
