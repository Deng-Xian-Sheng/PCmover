using System;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200095E RID: 2398
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ErrorWrapper
	{
		// Token: 0x06006216 RID: 25110 RVA: 0x0014F5FB File Offset: 0x0014D7FB
		[__DynamicallyInvokable]
		public ErrorWrapper(int errorCode)
		{
			this.m_ErrorCode = errorCode;
		}

		// Token: 0x06006217 RID: 25111 RVA: 0x0014F60A File Offset: 0x0014D80A
		[__DynamicallyInvokable]
		public ErrorWrapper(object errorCode)
		{
			if (!(errorCode is int))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeInt32"), "errorCode");
			}
			this.m_ErrorCode = (int)errorCode;
		}

		// Token: 0x06006218 RID: 25112 RVA: 0x0014F63B File Offset: 0x0014D83B
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public ErrorWrapper(Exception e)
		{
			this.m_ErrorCode = Marshal.GetHRForException(e);
		}

		// Token: 0x17001113 RID: 4371
		// (get) Token: 0x06006219 RID: 25113 RVA: 0x0014F64F File Offset: 0x0014D84F
		[__DynamicallyInvokable]
		public int ErrorCode
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_ErrorCode;
			}
		}

		// Token: 0x04002B87 RID: 11143
		private int m_ErrorCode;
	}
}
