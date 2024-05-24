using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F3 RID: 755
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x0600267E RID: 9854 RVA: 0x0008C608 File Offset: 0x0008A808
		public KeyContainerPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x0600267F RID: 9855 RVA: 0x0008C61F File Offset: 0x0008A81F
		// (set) Token: 0x06002680 RID: 9856 RVA: 0x0008C627 File Offset: 0x0008A827
		public string KeyStore
		{
			get
			{
				return this.m_keyStore;
			}
			set
			{
				this.m_keyStore = value;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06002681 RID: 9857 RVA: 0x0008C630 File Offset: 0x0008A830
		// (set) Token: 0x06002682 RID: 9858 RVA: 0x0008C638 File Offset: 0x0008A838
		public string ProviderName
		{
			get
			{
				return this.m_providerName;
			}
			set
			{
				this.m_providerName = value;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002683 RID: 9859 RVA: 0x0008C641 File Offset: 0x0008A841
		// (set) Token: 0x06002684 RID: 9860 RVA: 0x0008C649 File Offset: 0x0008A849
		public int ProviderType
		{
			get
			{
				return this.m_providerType;
			}
			set
			{
				this.m_providerType = value;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002685 RID: 9861 RVA: 0x0008C652 File Offset: 0x0008A852
		// (set) Token: 0x06002686 RID: 9862 RVA: 0x0008C65A File Offset: 0x0008A85A
		public string KeyContainerName
		{
			get
			{
				return this.m_keyContainerName;
			}
			set
			{
				this.m_keyContainerName = value;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06002687 RID: 9863 RVA: 0x0008C663 File Offset: 0x0008A863
		// (set) Token: 0x06002688 RID: 9864 RVA: 0x0008C66B File Offset: 0x0008A86B
		public int KeySpec
		{
			get
			{
				return this.m_keySpec;
			}
			set
			{
				this.m_keySpec = value;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06002689 RID: 9865 RVA: 0x0008C674 File Offset: 0x0008A874
		// (set) Token: 0x0600268A RID: 9866 RVA: 0x0008C67C File Offset: 0x0008A87C
		public KeyContainerPermissionFlags Flags
		{
			get
			{
				return this.m_flags;
			}
			set
			{
				this.m_flags = value;
			}
		}

		// Token: 0x0600268B RID: 9867 RVA: 0x0008C688 File Offset: 0x0008A888
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new KeyContainerPermission(PermissionState.Unrestricted);
			}
			if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.m_keyStore, this.m_providerName, this.m_providerType, this.m_keyContainerName, this.m_keySpec))
			{
				return new KeyContainerPermission(this.m_flags);
			}
			KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
			KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this.m_keyStore, this.m_providerName, this.m_providerType, this.m_keyContainerName, this.m_keySpec, this.m_flags);
			keyContainerPermission.AccessEntries.Add(accessEntry);
			return keyContainerPermission;
		}

		// Token: 0x04000EEC RID: 3820
		private KeyContainerPermissionFlags m_flags;

		// Token: 0x04000EED RID: 3821
		private string m_keyStore;

		// Token: 0x04000EEE RID: 3822
		private string m_providerName;

		// Token: 0x04000EEF RID: 3823
		private int m_providerType = -1;

		// Token: 0x04000EF0 RID: 3824
		private string m_keyContainerName;

		// Token: 0x04000EF1 RID: 3825
		private int m_keySpec = -1;
	}
}
