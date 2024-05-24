using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002EE RID: 750
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public abstract class SecurityAttribute : Attribute
	{
		// Token: 0x06002652 RID: 9810 RVA: 0x0008C2B8 File Offset: 0x0008A4B8
		protected SecurityAttribute(SecurityAction action)
		{
			this.m_action = action;
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06002653 RID: 9811 RVA: 0x0008C2C7 File Offset: 0x0008A4C7
		// (set) Token: 0x06002654 RID: 9812 RVA: 0x0008C2CF File Offset: 0x0008A4CF
		public SecurityAction Action
		{
			get
			{
				return this.m_action;
			}
			set
			{
				this.m_action = value;
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06002655 RID: 9813 RVA: 0x0008C2D8 File Offset: 0x0008A4D8
		// (set) Token: 0x06002656 RID: 9814 RVA: 0x0008C2E0 File Offset: 0x0008A4E0
		public bool Unrestricted
		{
			get
			{
				return this.m_unrestricted;
			}
			set
			{
				this.m_unrestricted = value;
			}
		}

		// Token: 0x06002657 RID: 9815
		public abstract IPermission CreatePermission();

		// Token: 0x06002658 RID: 9816 RVA: 0x0008C2EC File Offset: 0x0008A4EC
		[SecurityCritical]
		internal static IntPtr FindSecurityAttributeTypeHandle(string typeName)
		{
			PermissionSet.s_fullTrust.Assert();
			Type type = Type.GetType(typeName, false, false);
			if (type == null)
			{
				return IntPtr.Zero;
			}
			return type.TypeHandle.Value;
		}

		// Token: 0x04000EDF RID: 3807
		internal SecurityAction m_action;

		// Token: 0x04000EE0 RID: 3808
		internal bool m_unrestricted;
	}
}
