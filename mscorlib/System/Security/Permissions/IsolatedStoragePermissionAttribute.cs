using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002FE RID: 766
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public abstract class IsolatedStoragePermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026F2 RID: 9970 RVA: 0x0008CF36 File Offset: 0x0008B136
		protected IsolatedStoragePermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060026F4 RID: 9972 RVA: 0x0008CF48 File Offset: 0x0008B148
		// (set) Token: 0x060026F3 RID: 9971 RVA: 0x0008CF3F File Offset: 0x0008B13F
		public long UserQuota
		{
			get
			{
				return this.m_userQuota;
			}
			set
			{
				this.m_userQuota = value;
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x060026F6 RID: 9974 RVA: 0x0008CF59 File Offset: 0x0008B159
		// (set) Token: 0x060026F5 RID: 9973 RVA: 0x0008CF50 File Offset: 0x0008B150
		public IsolatedStorageContainment UsageAllowed
		{
			get
			{
				return this.m_allowed;
			}
			set
			{
				this.m_allowed = value;
			}
		}

		// Token: 0x04000F07 RID: 3847
		internal long m_userQuota;

		// Token: 0x04000F08 RID: 3848
		internal IsolatedStorageContainment m_allowed;
	}
}
