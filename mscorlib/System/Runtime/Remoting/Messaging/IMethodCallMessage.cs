using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200085A RID: 2138
	[ComVisible(true)]
	public interface IMethodCallMessage : IMethodMessage, IMessage
	{
		// Token: 0x17000F2F RID: 3887
		// (get) Token: 0x06005A87 RID: 23175
		int InArgCount { [SecurityCritical] get; }

		// Token: 0x06005A88 RID: 23176
		[SecurityCritical]
		string GetInArgName(int index);

		// Token: 0x06005A89 RID: 23177
		[SecurityCritical]
		object GetInArg(int argNum);

		// Token: 0x17000F30 RID: 3888
		// (get) Token: 0x06005A8A RID: 23178
		object[] InArgs { [SecurityCritical] get; }
	}
}
