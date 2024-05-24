using System;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200095B RID: 2395
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class BStrWrapper
	{
		// Token: 0x0600620E RID: 25102 RVA: 0x0014F553 File Offset: 0x0014D753
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public BStrWrapper(string value)
		{
			this.m_WrappedObject = value;
		}

		// Token: 0x0600620F RID: 25103 RVA: 0x0014F562 File Offset: 0x0014D762
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public BStrWrapper(object value)
		{
			this.m_WrappedObject = (string)value;
		}

		// Token: 0x17001110 RID: 4368
		// (get) Token: 0x06006210 RID: 25104 RVA: 0x0014F576 File Offset: 0x0014D776
		[__DynamicallyInvokable]
		public string WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002B84 RID: 11140
		private string m_WrappedObject;
	}
}
