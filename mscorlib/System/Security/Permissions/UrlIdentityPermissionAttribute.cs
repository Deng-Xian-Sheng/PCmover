using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002FC RID: 764
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class UrlIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026E6 RID: 9958 RVA: 0x0008CE2B File Offset: 0x0008B02B
		public UrlIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060026E7 RID: 9959 RVA: 0x0008CE34 File Offset: 0x0008B034
		// (set) Token: 0x060026E8 RID: 9960 RVA: 0x0008CE3C File Offset: 0x0008B03C
		public string Url
		{
			get
			{
				return this.m_url;
			}
			set
			{
				this.m_url = value;
			}
		}

		// Token: 0x060026E9 RID: 9961 RVA: 0x0008CE45 File Offset: 0x0008B045
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new UrlIdentityPermission(PermissionState.Unrestricted);
			}
			if (this.m_url == null)
			{
				return new UrlIdentityPermission(PermissionState.None);
			}
			return new UrlIdentityPermission(this.m_url);
		}

		// Token: 0x04000F03 RID: 3843
		private string m_url;
	}
}
