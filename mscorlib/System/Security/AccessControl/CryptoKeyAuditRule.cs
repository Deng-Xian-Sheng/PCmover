using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000212 RID: 530
	public sealed class CryptoKeyAuditRule : AuditRule
	{
		// Token: 0x06001EFD RID: 7933 RVA: 0x0006D19A File Offset: 0x0006B39A
		public CryptoKeyAuditRule(IdentityReference identity, CryptoKeyRights cryptoKeyRights, AuditFlags flags) : this(identity, CryptoKeyAuditRule.AccessMaskFromRights(cryptoKeyRights), false, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x0006D1AD File Offset: 0x0006B3AD
		public CryptoKeyAuditRule(string identity, CryptoKeyRights cryptoKeyRights, AuditFlags flags) : this(new NTAccount(identity), CryptoKeyAuditRule.AccessMaskFromRights(cryptoKeyRights), false, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001EFF RID: 7935 RVA: 0x0006D1C5 File Offset: 0x0006B3C5
		private CryptoKeyAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06001F00 RID: 7936 RVA: 0x0006D1D6 File Offset: 0x0006B3D6
		public CryptoKeyRights CryptoKeyRights
		{
			get
			{
				return CryptoKeyAuditRule.RightsFromAccessMask(base.AccessMask);
			}
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x0006D1E3 File Offset: 0x0006B3E3
		private static int AccessMaskFromRights(CryptoKeyRights cryptoKeyRights)
		{
			return (int)cryptoKeyRights;
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x0006D1E6 File Offset: 0x0006B3E6
		internal static CryptoKeyRights RightsFromAccessMask(int accessMask)
		{
			return (CryptoKeyRights)accessMask;
		}
	}
}
