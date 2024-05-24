using System;
using System.Collections;
using System.Reflection;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000870 RID: 2160
	internal class ErrorMessage : IMethodCallMessage, IMethodMessage, IMessage
	{
		// Token: 0x17000FB2 RID: 4018
		// (get) Token: 0x06005BE5 RID: 23525 RVA: 0x00142A29 File Offset: 0x00140C29
		public IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000FB3 RID: 4019
		// (get) Token: 0x06005BE6 RID: 23526 RVA: 0x00142A2C File Offset: 0x00140C2C
		public string Uri
		{
			[SecurityCritical]
			get
			{
				return this.m_URI;
			}
		}

		// Token: 0x17000FB4 RID: 4020
		// (get) Token: 0x06005BE7 RID: 23527 RVA: 0x00142A34 File Offset: 0x00140C34
		public string MethodName
		{
			[SecurityCritical]
			get
			{
				return this.m_MethodName;
			}
		}

		// Token: 0x17000FB5 RID: 4021
		// (get) Token: 0x06005BE8 RID: 23528 RVA: 0x00142A3C File Offset: 0x00140C3C
		public string TypeName
		{
			[SecurityCritical]
			get
			{
				return this.m_TypeName;
			}
		}

		// Token: 0x17000FB6 RID: 4022
		// (get) Token: 0x06005BE9 RID: 23529 RVA: 0x00142A44 File Offset: 0x00140C44
		public object MethodSignature
		{
			[SecurityCritical]
			get
			{
				return this.m_MethodSignature;
			}
		}

		// Token: 0x17000FB7 RID: 4023
		// (get) Token: 0x06005BEA RID: 23530 RVA: 0x00142A4C File Offset: 0x00140C4C
		public MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000FB8 RID: 4024
		// (get) Token: 0x06005BEB RID: 23531 RVA: 0x00142A4F File Offset: 0x00140C4F
		public int ArgCount
		{
			[SecurityCritical]
			get
			{
				return this.m_ArgCount;
			}
		}

		// Token: 0x06005BEC RID: 23532 RVA: 0x00142A57 File Offset: 0x00140C57
		[SecurityCritical]
		public string GetArgName(int index)
		{
			return this.m_ArgName;
		}

		// Token: 0x06005BED RID: 23533 RVA: 0x00142A5F File Offset: 0x00140C5F
		[SecurityCritical]
		public object GetArg(int argNum)
		{
			return null;
		}

		// Token: 0x17000FB9 RID: 4025
		// (get) Token: 0x06005BEE RID: 23534 RVA: 0x00142A62 File Offset: 0x00140C62
		public object[] Args
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000FBA RID: 4026
		// (get) Token: 0x06005BEF RID: 23535 RVA: 0x00142A65 File Offset: 0x00140C65
		public bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return false;
			}
		}

		// Token: 0x17000FBB RID: 4027
		// (get) Token: 0x06005BF0 RID: 23536 RVA: 0x00142A68 File Offset: 0x00140C68
		public int InArgCount
		{
			[SecurityCritical]
			get
			{
				return this.m_ArgCount;
			}
		}

		// Token: 0x06005BF1 RID: 23537 RVA: 0x00142A70 File Offset: 0x00140C70
		[SecurityCritical]
		public string GetInArgName(int index)
		{
			return null;
		}

		// Token: 0x06005BF2 RID: 23538 RVA: 0x00142A73 File Offset: 0x00140C73
		[SecurityCritical]
		public object GetInArg(int argNum)
		{
			return null;
		}

		// Token: 0x17000FBC RID: 4028
		// (get) Token: 0x06005BF3 RID: 23539 RVA: 0x00142A76 File Offset: 0x00140C76
		public object[] InArgs
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000FBD RID: 4029
		// (get) Token: 0x06005BF4 RID: 23540 RVA: 0x00142A79 File Offset: 0x00140C79
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x04002986 RID: 10630
		private string m_URI = "Exception";

		// Token: 0x04002987 RID: 10631
		private string m_MethodName = "Unknown";

		// Token: 0x04002988 RID: 10632
		private string m_TypeName = "Unknown";

		// Token: 0x04002989 RID: 10633
		private object m_MethodSignature;

		// Token: 0x0400298A RID: 10634
		private int m_ArgCount;

		// Token: 0x0400298B RID: 10635
		private string m_ArgName = "Unknown";
	}
}
