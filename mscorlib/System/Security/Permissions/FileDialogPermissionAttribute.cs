using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F1 RID: 753
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class FileDialogPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x06002662 RID: 9826 RVA: 0x0008C3CE File Offset: 0x0008A5CE
		public FileDialogPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06002663 RID: 9827 RVA: 0x0008C3D7 File Offset: 0x0008A5D7
		// (set) Token: 0x06002664 RID: 9828 RVA: 0x0008C3E4 File Offset: 0x0008A5E4
		public bool Open
		{
			get
			{
				return (this.m_access & FileDialogPermissionAccess.Open) > FileDialogPermissionAccess.None;
			}
			set
			{
				this.m_access = (value ? (this.m_access | FileDialogPermissionAccess.Open) : (this.m_access & ~FileDialogPermissionAccess.Open));
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06002665 RID: 9829 RVA: 0x0008C402 File Offset: 0x0008A602
		// (set) Token: 0x06002666 RID: 9830 RVA: 0x0008C40F File Offset: 0x0008A60F
		public bool Save
		{
			get
			{
				return (this.m_access & FileDialogPermissionAccess.Save) > FileDialogPermissionAccess.None;
			}
			set
			{
				this.m_access = (value ? (this.m_access | FileDialogPermissionAccess.Save) : (this.m_access & ~FileDialogPermissionAccess.Save));
			}
		}

		// Token: 0x06002667 RID: 9831 RVA: 0x0008C42D File Offset: 0x0008A62D
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new FileDialogPermission(PermissionState.Unrestricted);
			}
			return new FileDialogPermission(this.m_access);
		}

		// Token: 0x04000EE3 RID: 3811
		private FileDialogPermissionAccess m_access;
	}
}
