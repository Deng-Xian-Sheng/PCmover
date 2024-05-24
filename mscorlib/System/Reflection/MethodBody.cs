using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000612 RID: 1554
	[ComVisible(true)]
	public class MethodBody
	{
		// Token: 0x060047FF RID: 18431 RVA: 0x00105FA4 File Offset: 0x001041A4
		protected MethodBody()
		{
		}

		// Token: 0x17000B1D RID: 2845
		// (get) Token: 0x06004800 RID: 18432 RVA: 0x00105FAC File Offset: 0x001041AC
		public virtual int LocalSignatureMetadataToken
		{
			get
			{
				return this.m_localSignatureMetadataToken;
			}
		}

		// Token: 0x17000B1E RID: 2846
		// (get) Token: 0x06004801 RID: 18433 RVA: 0x00105FB4 File Offset: 0x001041B4
		public virtual IList<LocalVariableInfo> LocalVariables
		{
			get
			{
				return Array.AsReadOnly<LocalVariableInfo>(this.m_localVariables);
			}
		}

		// Token: 0x17000B1F RID: 2847
		// (get) Token: 0x06004802 RID: 18434 RVA: 0x00105FC1 File Offset: 0x001041C1
		public virtual int MaxStackSize
		{
			get
			{
				return this.m_maxStackSize;
			}
		}

		// Token: 0x17000B20 RID: 2848
		// (get) Token: 0x06004803 RID: 18435 RVA: 0x00105FC9 File Offset: 0x001041C9
		public virtual bool InitLocals
		{
			get
			{
				return this.m_initLocals;
			}
		}

		// Token: 0x06004804 RID: 18436 RVA: 0x00105FD1 File Offset: 0x001041D1
		public virtual byte[] GetILAsByteArray()
		{
			return this.m_IL;
		}

		// Token: 0x17000B21 RID: 2849
		// (get) Token: 0x06004805 RID: 18437 RVA: 0x00105FD9 File Offset: 0x001041D9
		public virtual IList<ExceptionHandlingClause> ExceptionHandlingClauses
		{
			get
			{
				return Array.AsReadOnly<ExceptionHandlingClause>(this.m_exceptionHandlingClauses);
			}
		}

		// Token: 0x04001DCF RID: 7631
		private byte[] m_IL;

		// Token: 0x04001DD0 RID: 7632
		private ExceptionHandlingClause[] m_exceptionHandlingClauses;

		// Token: 0x04001DD1 RID: 7633
		private LocalVariableInfo[] m_localVariables;

		// Token: 0x04001DD2 RID: 7634
		internal MethodBase m_methodBase;

		// Token: 0x04001DD3 RID: 7635
		private int m_localSignatureMetadataToken;

		// Token: 0x04001DD4 RID: 7636
		private int m_maxStackSize;

		// Token: 0x04001DD5 RID: 7637
		private bool m_initLocals;
	}
}
