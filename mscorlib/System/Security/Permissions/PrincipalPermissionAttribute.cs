using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F4 RID: 756
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class PrincipalPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x0600268C RID: 9868 RVA: 0x0008C714 File Offset: 0x0008A914
		public PrincipalPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600268D RID: 9869 RVA: 0x0008C724 File Offset: 0x0008A924
		// (set) Token: 0x0600268E RID: 9870 RVA: 0x0008C72C File Offset: 0x0008A92C
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600268F RID: 9871 RVA: 0x0008C735 File Offset: 0x0008A935
		// (set) Token: 0x06002690 RID: 9872 RVA: 0x0008C73D File Offset: 0x0008A93D
		public string Role
		{
			get
			{
				return this.m_role;
			}
			set
			{
				this.m_role = value;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06002691 RID: 9873 RVA: 0x0008C746 File Offset: 0x0008A946
		// (set) Token: 0x06002692 RID: 9874 RVA: 0x0008C74E File Offset: 0x0008A94E
		public bool Authenticated
		{
			get
			{
				return this.m_authenticated;
			}
			set
			{
				this.m_authenticated = value;
			}
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x0008C757 File Offset: 0x0008A957
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new PrincipalPermission(PermissionState.Unrestricted);
			}
			return new PrincipalPermission(this.m_name, this.m_role, this.m_authenticated);
		}

		// Token: 0x04000EF2 RID: 3826
		private string m_name;

		// Token: 0x04000EF3 RID: 3827
		private string m_role;

		// Token: 0x04000EF4 RID: 3828
		private bool m_authenticated = true;
	}
}
