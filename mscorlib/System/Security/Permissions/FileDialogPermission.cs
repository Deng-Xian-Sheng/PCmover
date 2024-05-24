using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x020002DF RID: 735
	[ComVisible(true)]
	[Serializable]
	public sealed class FileDialogPermission : CodeAccessPermission, IUnrestrictedPermission, IBuiltInPermission
	{
		// Token: 0x060025C5 RID: 9669 RVA: 0x00089B9D File Offset: 0x00087D9D
		public FileDialogPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.SetUnrestricted(true);
				return;
			}
			if (state == PermissionState.None)
			{
				this.SetUnrestricted(false);
				this.Reset();
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		// Token: 0x060025C6 RID: 9670 RVA: 0x00089BD1 File Offset: 0x00087DD1
		public FileDialogPermission(FileDialogPermissionAccess access)
		{
			FileDialogPermission.VerifyAccess(access);
			this.access = access;
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x060025C7 RID: 9671 RVA: 0x00089BE6 File Offset: 0x00087DE6
		// (set) Token: 0x060025C8 RID: 9672 RVA: 0x00089BEE File Offset: 0x00087DEE
		public FileDialogPermissionAccess Access
		{
			get
			{
				return this.access;
			}
			set
			{
				FileDialogPermission.VerifyAccess(value);
				this.access = value;
			}
		}

		// Token: 0x060025C9 RID: 9673 RVA: 0x00089BFD File Offset: 0x00087DFD
		public override IPermission Copy()
		{
			return new FileDialogPermission(this.access);
		}

		// Token: 0x060025CA RID: 9674 RVA: 0x00089C0C File Offset: 0x00087E0C
		public override void FromXml(SecurityElement esd)
		{
			CodeAccessPermission.ValidateElement(esd, this);
			if (XMLUtil.IsUnrestricted(esd))
			{
				this.SetUnrestricted(true);
				return;
			}
			this.access = FileDialogPermissionAccess.None;
			string text = esd.Attribute("Access");
			if (text != null)
			{
				this.access = (FileDialogPermissionAccess)Enum.Parse(typeof(FileDialogPermissionAccess), text);
			}
		}

		// Token: 0x060025CB RID: 9675 RVA: 0x00089C61 File Offset: 0x00087E61
		int IBuiltInPermission.GetTokenIndex()
		{
			return FileDialogPermission.GetTokenIndex();
		}

		// Token: 0x060025CC RID: 9676 RVA: 0x00089C68 File Offset: 0x00087E68
		internal static int GetTokenIndex()
		{
			return 1;
		}

		// Token: 0x060025CD RID: 9677 RVA: 0x00089C6C File Offset: 0x00087E6C
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			FileDialogPermission fileDialogPermission = (FileDialogPermission)target;
			FileDialogPermissionAccess fileDialogPermissionAccess = this.access & fileDialogPermission.Access;
			if (fileDialogPermissionAccess == FileDialogPermissionAccess.None)
			{
				return null;
			}
			return new FileDialogPermission(fileDialogPermissionAccess);
		}

		// Token: 0x060025CE RID: 9678 RVA: 0x00089CCC File Offset: 0x00087ECC
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.access == FileDialogPermissionAccess.None;
			}
			bool result;
			try
			{
				FileDialogPermission fileDialogPermission = (FileDialogPermission)target;
				if (fileDialogPermission.IsUnrestricted())
				{
					result = true;
				}
				else if (this.IsUnrestricted())
				{
					result = false;
				}
				else
				{
					int num = (int)(this.access & FileDialogPermissionAccess.Open);
					int num2 = (int)(this.access & FileDialogPermissionAccess.Save);
					int num3 = (int)(fileDialogPermission.Access & FileDialogPermissionAccess.Open);
					int num4 = (int)(fileDialogPermission.Access & FileDialogPermissionAccess.Save);
					result = (num <= num3 && num2 <= num4);
				}
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return result;
		}

		// Token: 0x060025CF RID: 9679 RVA: 0x00089D78 File Offset: 0x00087F78
		public bool IsUnrestricted()
		{
			return this.access == FileDialogPermissionAccess.OpenSave;
		}

		// Token: 0x060025D0 RID: 9680 RVA: 0x00089D83 File Offset: 0x00087F83
		private void Reset()
		{
			this.access = FileDialogPermissionAccess.None;
		}

		// Token: 0x060025D1 RID: 9681 RVA: 0x00089D8C File Offset: 0x00087F8C
		private void SetUnrestricted(bool unrestricted)
		{
			if (unrestricted)
			{
				this.access = FileDialogPermissionAccess.OpenSave;
			}
		}

		// Token: 0x060025D2 RID: 9682 RVA: 0x00089D98 File Offset: 0x00087F98
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.FileDialogPermission");
			if (!this.IsUnrestricted())
			{
				if (this.access != FileDialogPermissionAccess.None)
				{
					securityElement.AddAttribute("Access", Enum.GetName(typeof(FileDialogPermissionAccess), this.access));
				}
			}
			else
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			return securityElement;
		}

		// Token: 0x060025D3 RID: 9683 RVA: 0x00089DFC File Offset: 0x00087FFC
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			FileDialogPermission fileDialogPermission = (FileDialogPermission)target;
			return new FileDialogPermission(this.access | fileDialogPermission.Access);
		}

		// Token: 0x060025D4 RID: 9684 RVA: 0x00089E59 File Offset: 0x00088059
		private static void VerifyAccess(FileDialogPermissionAccess access)
		{
			if ((access & ~(FileDialogPermissionAccess.Open | FileDialogPermissionAccess.Save)) != FileDialogPermissionAccess.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)access
				}));
			}
		}

		// Token: 0x04000E74 RID: 3700
		private FileDialogPermissionAccess access;
	}
}
