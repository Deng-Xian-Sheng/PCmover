using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000311 RID: 785
	[ComVisible(true)]
	[Serializable]
	public sealed class GacIdentityPermission : CodeAccessPermission, IBuiltInPermission
	{
		// Token: 0x060027A8 RID: 10152 RVA: 0x000905B7 File Offset: 0x0008E7B7
		public GacIdentityPermission(PermissionState state)
		{
			if (state != PermissionState.Unrestricted && state != PermissionState.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
			}
		}

		// Token: 0x060027A9 RID: 10153 RVA: 0x000905D6 File Offset: 0x0008E7D6
		public GacIdentityPermission()
		{
		}

		// Token: 0x060027AA RID: 10154 RVA: 0x000905DE File Offset: 0x0008E7DE
		public override IPermission Copy()
		{
			return new GacIdentityPermission();
		}

		// Token: 0x060027AB RID: 10155 RVA: 0x000905E5 File Offset: 0x0008E7E5
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return false;
			}
			if (!(target is GacIdentityPermission))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return true;
		}

		// Token: 0x060027AC RID: 10156 RVA: 0x00090619 File Offset: 0x0008E819
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!(target is GacIdentityPermission))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return this.Copy();
		}

		// Token: 0x060027AD RID: 10157 RVA: 0x00090652 File Offset: 0x0008E852
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!(target is GacIdentityPermission))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return this.Copy();
		}

		// Token: 0x060027AE RID: 10158 RVA: 0x00090690 File Offset: 0x0008E890
		public override SecurityElement ToXml()
		{
			return CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.GacIdentityPermission");
		}

		// Token: 0x060027AF RID: 10159 RVA: 0x000906AA File Offset: 0x0008E8AA
		public override void FromXml(SecurityElement securityElement)
		{
			CodeAccessPermission.ValidateElement(securityElement, this);
		}

		// Token: 0x060027B0 RID: 10160 RVA: 0x000906B3 File Offset: 0x0008E8B3
		int IBuiltInPermission.GetTokenIndex()
		{
			return GacIdentityPermission.GetTokenIndex();
		}

		// Token: 0x060027B1 RID: 10161 RVA: 0x000906BA File Offset: 0x0008E8BA
		internal static int GetTokenIndex()
		{
			return 15;
		}
	}
}
