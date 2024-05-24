using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200085B RID: 2139
	[ComVisible(true)]
	public interface IMethodReturnMessage : IMethodMessage, IMessage
	{
		// Token: 0x17000F31 RID: 3889
		// (get) Token: 0x06005A8B RID: 23179
		int OutArgCount { [SecurityCritical] get; }

		// Token: 0x06005A8C RID: 23180
		[SecurityCritical]
		string GetOutArgName(int index);

		// Token: 0x06005A8D RID: 23181
		[SecurityCritical]
		object GetOutArg(int argNum);

		// Token: 0x17000F32 RID: 3890
		// (get) Token: 0x06005A8E RID: 23182
		object[] OutArgs { [SecurityCritical] get; }

		// Token: 0x17000F33 RID: 3891
		// (get) Token: 0x06005A8F RID: 23183
		Exception Exception { [SecurityCritical] get; }

		// Token: 0x17000F34 RID: 3892
		// (get) Token: 0x06005A90 RID: 23184
		object ReturnValue { [SecurityCritical] get; }
	}
}
