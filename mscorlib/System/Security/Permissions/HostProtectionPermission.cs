using System;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x020002E5 RID: 741
	[Serializable]
	internal sealed class HostProtectionPermission : CodeAccessPermission, IUnrestrictedPermission, IBuiltInPermission
	{
		// Token: 0x0600262E RID: 9774 RVA: 0x0008B981 File Offset: 0x00089B81
		public HostProtectionPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.Resources = HostProtectionResource.All;
				return;
			}
			if (state == PermissionState.None)
			{
				this.Resources = HostProtectionResource.None;
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		// Token: 0x0600262F RID: 9775 RVA: 0x0008B9B3 File Offset: 0x00089BB3
		public HostProtectionPermission(HostProtectionResource resources)
		{
			this.Resources = resources;
		}

		// Token: 0x06002630 RID: 9776 RVA: 0x0008B9C2 File Offset: 0x00089BC2
		public bool IsUnrestricted()
		{
			return this.Resources == HostProtectionResource.All;
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06002632 RID: 9778 RVA: 0x0008BA05 File Offset: 0x00089C05
		// (set) Token: 0x06002631 RID: 9777 RVA: 0x0008B9D1 File Offset: 0x00089BD1
		public HostProtectionResource Resources
		{
			get
			{
				return this.m_resources;
			}
			set
			{
				if (value < HostProtectionResource.None || value > HostProtectionResource.All)
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
					{
						(int)value
					}));
				}
				this.m_resources = value;
			}
		}

		// Token: 0x06002633 RID: 9779 RVA: 0x0008BA10 File Offset: 0x00089C10
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.m_resources == HostProtectionResource.None;
			}
			if (base.GetType() != target.GetType())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return (this.m_resources & ((HostProtectionPermission)target).m_resources) == this.m_resources;
		}

		// Token: 0x06002634 RID: 9780 RVA: 0x0008BA7C File Offset: 0x00089C7C
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (base.GetType() != target.GetType())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			HostProtectionResource resources = this.m_resources | ((HostProtectionPermission)target).m_resources;
			return new HostProtectionPermission(resources);
		}

		// Token: 0x06002635 RID: 9781 RVA: 0x0008BAE4 File Offset: 0x00089CE4
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (base.GetType() != target.GetType())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			HostProtectionResource hostProtectionResource = this.m_resources & ((HostProtectionPermission)target).m_resources;
			if (hostProtectionResource == HostProtectionResource.None)
			{
				return null;
			}
			return new HostProtectionPermission(hostProtectionResource);
		}

		// Token: 0x06002636 RID: 9782 RVA: 0x0008BB4B File Offset: 0x00089D4B
		public override IPermission Copy()
		{
			return new HostProtectionPermission(this.m_resources);
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x0008BB58 File Offset: 0x00089D58
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, base.GetType().FullName);
			if (this.IsUnrestricted())
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			else
			{
				securityElement.AddAttribute("Resources", XMLUtil.BitFieldEnumToString(typeof(HostProtectionResource), this.Resources));
			}
			return securityElement;
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x0008BBB8 File Offset: 0x00089DB8
		public override void FromXml(SecurityElement esd)
		{
			CodeAccessPermission.ValidateElement(esd, this);
			if (XMLUtil.IsUnrestricted(esd))
			{
				this.Resources = HostProtectionResource.All;
				return;
			}
			string text = esd.Attribute("Resources");
			if (text == null)
			{
				this.Resources = HostProtectionResource.None;
				return;
			}
			this.Resources = (HostProtectionResource)Enum.Parse(typeof(HostProtectionResource), text);
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x0008BC12 File Offset: 0x00089E12
		int IBuiltInPermission.GetTokenIndex()
		{
			return HostProtectionPermission.GetTokenIndex();
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x0008BC19 File Offset: 0x00089E19
		internal static int GetTokenIndex()
		{
			return 9;
		}

		// Token: 0x04000E97 RID: 3735
		internal static volatile HostProtectionResource protectedResources;

		// Token: 0x04000E98 RID: 3736
		private HostProtectionResource m_resources;
	}
}
