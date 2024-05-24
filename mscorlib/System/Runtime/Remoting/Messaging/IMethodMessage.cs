using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000859 RID: 2137
	[ComVisible(true)]
	public interface IMethodMessage : IMessage
	{
		// Token: 0x17000F26 RID: 3878
		// (get) Token: 0x06005A7C RID: 23164
		string Uri { [SecurityCritical] get; }

		// Token: 0x17000F27 RID: 3879
		// (get) Token: 0x06005A7D RID: 23165
		string MethodName { [SecurityCritical] get; }

		// Token: 0x17000F28 RID: 3880
		// (get) Token: 0x06005A7E RID: 23166
		string TypeName { [SecurityCritical] get; }

		// Token: 0x17000F29 RID: 3881
		// (get) Token: 0x06005A7F RID: 23167
		object MethodSignature { [SecurityCritical] get; }

		// Token: 0x17000F2A RID: 3882
		// (get) Token: 0x06005A80 RID: 23168
		int ArgCount { [SecurityCritical] get; }

		// Token: 0x06005A81 RID: 23169
		[SecurityCritical]
		string GetArgName(int index);

		// Token: 0x06005A82 RID: 23170
		[SecurityCritical]
		object GetArg(int argNum);

		// Token: 0x17000F2B RID: 3883
		// (get) Token: 0x06005A83 RID: 23171
		object[] Args { [SecurityCritical] get; }

		// Token: 0x17000F2C RID: 3884
		// (get) Token: 0x06005A84 RID: 23172
		bool HasVarArgs { [SecurityCritical] get; }

		// Token: 0x17000F2D RID: 3885
		// (get) Token: 0x06005A85 RID: 23173
		LogicalCallContext LogicalCallContext { [SecurityCritical] get; }

		// Token: 0x17000F2E RID: 3886
		// (get) Token: 0x06005A86 RID: 23174
		MethodBase MethodBase { [SecurityCritical] get; }
	}
}
