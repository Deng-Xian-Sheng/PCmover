using System;

namespace System.Reflection.Emit
{
	// Token: 0x02000636 RID: 1590
	internal sealed class VarArgMethod
	{
		// Token: 0x06004A2A RID: 18986 RVA: 0x0010C629 File Offset: 0x0010A829
		internal VarArgMethod(DynamicMethod dm, SignatureHelper signature)
		{
			this.m_dynamicMethod = dm;
			this.m_signature = signature;
		}

		// Token: 0x06004A2B RID: 18987 RVA: 0x0010C63F File Offset: 0x0010A83F
		internal VarArgMethod(RuntimeMethodInfo method, SignatureHelper signature)
		{
			this.m_method = method;
			this.m_signature = signature;
		}

		// Token: 0x04001E93 RID: 7827
		internal RuntimeMethodInfo m_method;

		// Token: 0x04001E94 RID: 7828
		internal DynamicMethod m_dynamicMethod;

		// Token: 0x04001E95 RID: 7829
		internal SignatureHelper m_signature;
	}
}
