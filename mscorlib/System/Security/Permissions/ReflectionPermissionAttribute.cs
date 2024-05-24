using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F5 RID: 757
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class ReflectionPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x06002694 RID: 9876 RVA: 0x0008C77F File Offset: 0x0008A97F
		public ReflectionPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06002695 RID: 9877 RVA: 0x0008C788 File Offset: 0x0008A988
		// (set) Token: 0x06002696 RID: 9878 RVA: 0x0008C790 File Offset: 0x0008A990
		public ReflectionPermissionFlag Flags
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

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06002697 RID: 9879 RVA: 0x0008C799 File Offset: 0x0008A999
		// (set) Token: 0x06002698 RID: 9880 RVA: 0x0008C7A6 File Offset: 0x0008A9A6
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public bool TypeInformation
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.TypeInformation) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.TypeInformation) : (this.m_flag & ~ReflectionPermissionFlag.TypeInformation));
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06002699 RID: 9881 RVA: 0x0008C7C4 File Offset: 0x0008A9C4
		// (set) Token: 0x0600269A RID: 9882 RVA: 0x0008C7D1 File Offset: 0x0008A9D1
		public bool MemberAccess
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.MemberAccess) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.MemberAccess) : (this.m_flag & ~ReflectionPermissionFlag.MemberAccess));
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x0600269B RID: 9883 RVA: 0x0008C7EF File Offset: 0x0008A9EF
		// (set) Token: 0x0600269C RID: 9884 RVA: 0x0008C7FC File Offset: 0x0008A9FC
		[Obsolete("This permission is no longer used by the CLR.")]
		public bool ReflectionEmit
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.ReflectionEmit) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.ReflectionEmit) : (this.m_flag & ~ReflectionPermissionFlag.ReflectionEmit));
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x0600269D RID: 9885 RVA: 0x0008C81A File Offset: 0x0008AA1A
		// (set) Token: 0x0600269E RID: 9886 RVA: 0x0008C827 File Offset: 0x0008AA27
		public bool RestrictedMemberAccess
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.RestrictedMemberAccess) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.RestrictedMemberAccess) : (this.m_flag & ~ReflectionPermissionFlag.RestrictedMemberAccess));
			}
		}

		// Token: 0x0600269F RID: 9887 RVA: 0x0008C845 File Offset: 0x0008AA45
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new ReflectionPermission(PermissionState.Unrestricted);
			}
			return new ReflectionPermission(this.m_flag);
		}

		// Token: 0x04000EF5 RID: 3829
		private ReflectionPermissionFlag m_flag;
	}
}
