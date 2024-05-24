using System;

namespace System.Reflection.Emit
{
	// Token: 0x02000635 RID: 1589
	internal sealed class GenericFieldInfo
	{
		// Token: 0x06004A29 RID: 18985 RVA: 0x0010C613 File Offset: 0x0010A813
		internal GenericFieldInfo(RuntimeFieldHandle fieldHandle, RuntimeTypeHandle context)
		{
			this.m_fieldHandle = fieldHandle;
			this.m_context = context;
		}

		// Token: 0x04001E91 RID: 7825
		internal RuntimeFieldHandle m_fieldHandle;

		// Token: 0x04001E92 RID: 7826
		internal RuntimeTypeHandle m_context;
	}
}
