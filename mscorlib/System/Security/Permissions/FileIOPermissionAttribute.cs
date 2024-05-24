using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.AccessControl;

namespace System.Security.Permissions
{
	// Token: 0x020002F2 RID: 754
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class FileIOPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x06002668 RID: 9832 RVA: 0x0008C449 File Offset: 0x0008A649
		public FileIOPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06002669 RID: 9833 RVA: 0x0008C452 File Offset: 0x0008A652
		// (set) Token: 0x0600266A RID: 9834 RVA: 0x0008C45A File Offset: 0x0008A65A
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

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x0600266B RID: 9835 RVA: 0x0008C463 File Offset: 0x0008A663
		// (set) Token: 0x0600266C RID: 9836 RVA: 0x0008C46B File Offset: 0x0008A66B
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

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x0600266D RID: 9837 RVA: 0x0008C474 File Offset: 0x0008A674
		// (set) Token: 0x0600266E RID: 9838 RVA: 0x0008C47C File Offset: 0x0008A67C
		public string Append
		{
			get
			{
				return this.m_append;
			}
			set
			{
				this.m_append = value;
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x0600266F RID: 9839 RVA: 0x0008C485 File Offset: 0x0008A685
		// (set) Token: 0x06002670 RID: 9840 RVA: 0x0008C48D File Offset: 0x0008A68D
		public string PathDiscovery
		{
			get
			{
				return this.m_pathDiscovery;
			}
			set
			{
				this.m_pathDiscovery = value;
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06002671 RID: 9841 RVA: 0x0008C496 File Offset: 0x0008A696
		// (set) Token: 0x06002672 RID: 9842 RVA: 0x0008C49E File Offset: 0x0008A69E
		public string ViewAccessControl
		{
			get
			{
				return this.m_viewAccess;
			}
			set
			{
				this.m_viewAccess = value;
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06002673 RID: 9843 RVA: 0x0008C4A7 File Offset: 0x0008A6A7
		// (set) Token: 0x06002674 RID: 9844 RVA: 0x0008C4AF File Offset: 0x0008A6AF
		public string ChangeAccessControl
		{
			get
			{
				return this.m_changeAccess;
			}
			set
			{
				this.m_changeAccess = value;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06002676 RID: 9846 RVA: 0x0008C4D6 File Offset: 0x0008A6D6
		// (set) Token: 0x06002675 RID: 9845 RVA: 0x0008C4B8 File Offset: 0x0008A6B8
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
				this.m_append = value;
				this.m_pathDiscovery = value;
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06002677 RID: 9847 RVA: 0x0008C4E7 File Offset: 0x0008A6E7
		// (set) Token: 0x06002678 RID: 9848 RVA: 0x0008C4F8 File Offset: 0x0008A6F8
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
				this.m_append = value;
				this.m_pathDiscovery = value;
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06002679 RID: 9849 RVA: 0x0008C516 File Offset: 0x0008A716
		// (set) Token: 0x0600267A RID: 9850 RVA: 0x0008C51E File Offset: 0x0008A71E
		public FileIOPermissionAccess AllFiles
		{
			get
			{
				return this.m_allFiles;
			}
			set
			{
				this.m_allFiles = value;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600267B RID: 9851 RVA: 0x0008C527 File Offset: 0x0008A727
		// (set) Token: 0x0600267C RID: 9852 RVA: 0x0008C52F File Offset: 0x0008A72F
		public FileIOPermissionAccess AllLocalFiles
		{
			get
			{
				return this.m_allLocalFiles;
			}
			set
			{
				this.m_allLocalFiles = value;
			}
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x0008C538 File Offset: 0x0008A738
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new FileIOPermission(PermissionState.Unrestricted);
			}
			FileIOPermission fileIOPermission = new FileIOPermission(PermissionState.None);
			if (this.m_read != null)
			{
				fileIOPermission.SetPathList(FileIOPermissionAccess.Read, this.m_read);
			}
			if (this.m_write != null)
			{
				fileIOPermission.SetPathList(FileIOPermissionAccess.Write, this.m_write);
			}
			if (this.m_append != null)
			{
				fileIOPermission.SetPathList(FileIOPermissionAccess.Append, this.m_append);
			}
			if (this.m_pathDiscovery != null)
			{
				fileIOPermission.SetPathList(FileIOPermissionAccess.PathDiscovery, this.m_pathDiscovery);
			}
			if (this.m_viewAccess != null)
			{
				fileIOPermission.SetPathList(FileIOPermissionAccess.NoAccess, AccessControlActions.View, new string[]
				{
					this.m_viewAccess
				}, false);
			}
			if (this.m_changeAccess != null)
			{
				fileIOPermission.SetPathList(FileIOPermissionAccess.NoAccess, AccessControlActions.Change, new string[]
				{
					this.m_changeAccess
				}, false);
			}
			fileIOPermission.AllFiles = this.m_allFiles;
			fileIOPermission.AllLocalFiles = this.m_allLocalFiles;
			return fileIOPermission;
		}

		// Token: 0x04000EE4 RID: 3812
		private string m_read;

		// Token: 0x04000EE5 RID: 3813
		private string m_write;

		// Token: 0x04000EE6 RID: 3814
		private string m_append;

		// Token: 0x04000EE7 RID: 3815
		private string m_pathDiscovery;

		// Token: 0x04000EE8 RID: 3816
		private string m_viewAccess;

		// Token: 0x04000EE9 RID: 3817
		private string m_changeAccess;

		// Token: 0x04000EEA RID: 3818
		[OptionalField(VersionAdded = 2)]
		private FileIOPermissionAccess m_allLocalFiles;

		// Token: 0x04000EEB RID: 3819
		[OptionalField(VersionAdded = 2)]
		private FileIOPermissionAccess m_allFiles;
	}
}
