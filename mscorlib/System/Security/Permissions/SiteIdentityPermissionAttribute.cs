using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002FB RID: 763
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class SiteIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026E2 RID: 9954 RVA: 0x0008CDE6 File Offset: 0x0008AFE6
		public SiteIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060026E3 RID: 9955 RVA: 0x0008CDEF File Offset: 0x0008AFEF
		// (set) Token: 0x060026E4 RID: 9956 RVA: 0x0008CDF7 File Offset: 0x0008AFF7
		public string Site
		{
			get
			{
				return this.m_site;
			}
			set
			{
				this.m_site = value;
			}
		}

		// Token: 0x060026E5 RID: 9957 RVA: 0x0008CE00 File Offset: 0x0008B000
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new SiteIdentityPermission(PermissionState.Unrestricted);
			}
			if (this.m_site == null)
			{
				return new SiteIdentityPermission(PermissionState.None);
			}
			return new SiteIdentityPermission(this.m_site);
		}

		// Token: 0x04000F02 RID: 3842
		private string m_site;
	}
}
