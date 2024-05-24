using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F0 RID: 752
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class EnvironmentPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x0600265A RID: 9818 RVA: 0x0008C334 File Offset: 0x0008A534
		public EnvironmentPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x0600265B RID: 9819 RVA: 0x0008C33D File Offset: 0x0008A53D
		// (set) Token: 0x0600265C RID: 9820 RVA: 0x0008C345 File Offset: 0x0008A545
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

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x0600265D RID: 9821 RVA: 0x0008C34E File Offset: 0x0008A54E
		// (set) Token: 0x0600265E RID: 9822 RVA: 0x0008C356 File Offset: 0x0008A556
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

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x0600265F RID: 9823 RVA: 0x0008C35F File Offset: 0x0008A55F
		// (set) Token: 0x06002660 RID: 9824 RVA: 0x0008C370 File Offset: 0x0008A570
		public string All
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_GetMethod"));
			}
			set
			{
				this.m_write = value;
				this.m_read = value;
			}
		}

		// Token: 0x06002661 RID: 9825 RVA: 0x0008C380 File Offset: 0x0008A580
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new EnvironmentPermission(PermissionState.Unrestricted);
			}
			EnvironmentPermission environmentPermission = new EnvironmentPermission(PermissionState.None);
			if (this.m_read != null)
			{
				environmentPermission.SetPathList(EnvironmentPermissionAccess.Read, this.m_read);
			}
			if (this.m_write != null)
			{
				environmentPermission.SetPathList(EnvironmentPermissionAccess.Write, this.m_write);
			}
			return environmentPermission;
		}

		// Token: 0x04000EE1 RID: 3809
		private string m_read;

		// Token: 0x04000EE2 RID: 3810
		private string m_write;
	}
}
