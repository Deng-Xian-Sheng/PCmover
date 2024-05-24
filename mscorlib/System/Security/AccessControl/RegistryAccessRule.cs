using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x0200022D RID: 557
	public sealed class RegistryAccessRule : AccessRule
	{
		// Token: 0x06002017 RID: 8215 RVA: 0x00070F8F File Offset: 0x0006F18F
		public RegistryAccessRule(IdentityReference identity, RegistryRights registryRights, AccessControlType type) : this(identity, (int)registryRights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06002018 RID: 8216 RVA: 0x00070F9D File Offset: 0x0006F19D
		public RegistryAccessRule(string identity, RegistryRights registryRights, AccessControlType type) : this(new NTAccount(identity), (int)registryRights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06002019 RID: 8217 RVA: 0x00070FB0 File Offset: 0x0006F1B0
		public RegistryAccessRule(IdentityReference identity, RegistryRights registryRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : this(identity, (int)registryRights, false, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x0600201A RID: 8218 RVA: 0x00070FC0 File Offset: 0x0006F1C0
		public RegistryAccessRule(string identity, RegistryRights registryRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : this(new NTAccount(identity), (int)registryRights, false, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x0600201B RID: 8219 RVA: 0x00070FD5 File Offset: 0x0006F1D5
		internal RegistryAccessRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x0600201C RID: 8220 RVA: 0x00070FE6 File Offset: 0x0006F1E6
		public RegistryRights RegistryRights
		{
			get
			{
				return (RegistryRights)base.AccessMask;
			}
		}
	}
}
