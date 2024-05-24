using System;

namespace System.Reflection.Emit
{
	// Token: 0x02000634 RID: 1588
	internal sealed class GenericMethodInfo
	{
		// Token: 0x06004A28 RID: 18984 RVA: 0x0010C5FD File Offset: 0x0010A7FD
		internal GenericMethodInfo(RuntimeMethodHandle methodHandle, RuntimeTypeHandle context)
		{
			this.m_methodHandle = methodHandle;
			this.m_context = context;
		}

		// Token: 0x04001E8F RID: 7823
		internal RuntimeMethodHandle m_methodHandle;

		// Token: 0x04001E90 RID: 7824
		internal RuntimeTypeHandle m_context;
	}
}
