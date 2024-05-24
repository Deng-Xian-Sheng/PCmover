using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F9 RID: 761
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class ZoneIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026D6 RID: 9942 RVA: 0x0008CCCD File Offset: 0x0008AECD
		public ZoneIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060026D7 RID: 9943 RVA: 0x0008CCDD File Offset: 0x0008AEDD
		// (set) Token: 0x060026D8 RID: 9944 RVA: 0x0008CCE5 File Offset: 0x0008AEE5
		public SecurityZone Zone
		{
			get
			{
				return this.m_flag;
			}
			set
			{
				this.m_flag = value;
			}
		}

		// Token: 0x060026D9 RID: 9945 RVA: 0x0008CCEE File Offset: 0x0008AEEE
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new ZoneIdentityPermission(PermissionState.Unrestricted);
			}
			return new ZoneIdentityPermission(this.m_flag);
		}

		// Token: 0x04000EFE RID: 3838
		private SecurityZone m_flag = SecurityZone.NoZone;
	}
}
