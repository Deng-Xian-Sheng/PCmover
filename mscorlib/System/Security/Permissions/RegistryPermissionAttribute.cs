using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace System.Security.Permissions
{
	// Token: 0x020002F6 RID: 758
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class RegistryPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026A0 RID: 9888 RVA: 0x0008C861 File Offset: 0x0008AA61
		public RegistryPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060026A1 RID: 9889 RVA: 0x0008C86A File Offset: 0x0008AA6A
		// (set) Token: 0x060026A2 RID: 9890 RVA: 0x0008C872 File Offset: 0x0008AA72
		public string Read
		{
			get
			{
				return this.m_read;
			}
			set
			{
				this.m_read = value;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060026A3 RID: 9891 RVA: 0x0008C87B File Offset: 0x0008AA7B
		// (set) Token: 0x060026A4 RID: 9892 RVA: 0x0008C883 File Offset: 0x0008AA83
		public string Write
		{
			get
			{
				return this.m_write;
			}
			set
			{
				this.m_write = value;
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060026A5 RID: 9893 RVA: 0x0008C88C File Offset: 0x0008AA8C
		// (set) Token: 0x060026A6 RID: 9894 RVA: 0x0008C894 File Offset: 0x0008AA94
		public string Create
		{
			get
			{
				return this.m_create;
			}
			set
			{
				this.m_create = value;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060026A7 RID: 9895 RVA: 0x0008C89D File Offset: 0x0008AA9D
		// (set) Token: 0x060026A8 RID: 9896 RVA: 0x0008C8A5 File Offset: 0x0008AAA5
		public string ViewAccessControl
		{
			get
			{
				return this.m_viewAcl;
			}
			set
			{
				this.m_viewAcl = value;
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060026A9 RID: 9897 RVA: 0x0008C8AE File Offset: 0x0008AAAE
		// (set) Token: 0x060026AA RID: 9898 RVA: 0x0008C8B6 File Offset: 0x0008AAB6
		public string ChangeAccessControl
		{
			get
			{
				return this.m_changeAcl;
			}
			set
			{
				this.m_changeAcl = value;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060026AB RID: 9899 RVA: 0x0008C8BF File Offset: 0x0008AABF
		// (set) Token: 0x060026AC RID: 9900 RVA: 0x0008C8D0 File Offset: 0x0008AAD0
		public string ViewAndModify
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_GetMethod"));
			}
			set
			{
				this.m_read = value;
				this.m_write = value;
				this.m_create = value;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060026AD RID: 9901 RVA: 0x0008C8E7 File Offset: 0x0008AAE7
		// (set) Token: 0x060026AE RID: 9902 RVA: 0x0008C8F8 File Offset: 0x0008AAF8
		[Obsolete("Please use the ViewAndModify property instead.")]
		public string All
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_GetMethod"));
			}
			set
			{
				this.m_read = value;
				this.m_write = value;
				this.m_create = value;
			}
		}

		// Token: 0x060026AF RID: 9903 RVA: 0x0008C910 File Offset: 0x0008AB10
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new RegistryPermission(PermissionState.Unrestricted);
			}
			RegistryPermission registryPermission = new RegistryPermission(PermissionState.None);
			if (this.m_read != null)
			{
				registryPermission.SetPathList(RegistryPermissionAccess.Read, this.m_read);
			}
			if (this.m_write != null)
			{
				registryPermission.SetPathList(RegistryPermissionAccess.Write, this.m_write);
			}
			if (this.m_create != null)
			{
				registryPermission.SetPathList(RegistryPermissionAccess.Create, this.m_create);
			}
			if (this.m_viewAcl != null)
			{
				registryPermission.SetPathList(AccessControlActions.View, this.m_viewAcl);
			}
			if (this.m_changeAcl != null)
			{
				registryPermission.SetPathList(AccessControlActions.Change, this.m_changeAcl);
			}
			return registryPermission;
		}

		// Token: 0x04000EF6 RID: 3830
		private string m_read;

		// Token: 0x04000EF7 RID: 3831
		private string m_write;

		// Token: 0x04000EF8 RID: 3832
		private string m_create;

		// Token: 0x04000EF9 RID: 3833
		private string m_viewAcl;

		// Token: 0x04000EFA RID: 3834
		private string m_changeAcl;
	}
}
