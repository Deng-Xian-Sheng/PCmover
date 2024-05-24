using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002EF RID: 751
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public abstract class CodeAccessSecurityAttribute : SecurityAttribute
	{
		// Token: 0x06002659 RID: 9817 RVA: 0x0008C32B File Offset: 0x0008A52B
		protected CodeAccessSecurityAttribute(SecurityAction action) : base(action)
		{
		}
	}
}
