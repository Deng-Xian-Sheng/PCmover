using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x0200022E RID: 558
	public sealed class RegistryAuditRule : AuditRule
	{
		// Token: 0x0600201D RID: 8221 RVA: 0x00070FEE File Offset: 0x0006F1EE
		public RegistryAuditRule(IdentityReference identity, RegistryRights registryRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(identity, (int)registryRights, false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x0600201E RID: 8222 RVA: 0x00070FFE File Offset: 0x0006F1FE
		public RegistryAuditRule(string identity, RegistryRights registryRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(new NTAccount(identity), (int)registryRights, false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x0600201F RID: 8223 RVA: 0x00071013 File Offset: 0x0006F213
		internal RegistryAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06002020 RID: 8224 RVA: 0x00071024 File Offset: 0x0006F224
		public RegistryRights RegistryRights
		{
			get
			{
				return (RegistryRights)base.AccessMask;
			}
		}
	}
}
