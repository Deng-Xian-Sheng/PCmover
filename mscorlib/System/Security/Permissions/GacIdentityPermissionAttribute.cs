using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000310 RID: 784
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class GacIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060027A6 RID: 10150 RVA: 0x000905A7 File Offset: 0x0008E7A7
		public GacIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x000905B0 File Offset: 0x0008E7B0
		public override IPermission CreatePermission()
		{
			return new GacIdentityPermission();
		}
	}
}
