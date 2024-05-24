using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000213 RID: 531
	public sealed class CryptoKeySecurity : NativeObjectSecurity
	{
		// Token: 0x06001F03 RID: 7939 RVA: 0x0006D1E9 File Offset: 0x0006B3E9
		public CryptoKeySecurity() : base(false, ResourceType.FileObject)
		{
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x0006D1F3 File Offset: 0x0006B3F3
		[SecuritySafeCritical]
		public CryptoKeySecurity(CommonSecurityDescriptor securityDescriptor) : base(ResourceType.FileObject, securityDescriptor)
		{
		}

		// Token: 0x06001F05 RID: 7941 RVA: 0x0006D1FD File Offset: 0x0006B3FD
		public sealed override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new CryptoKeyAccessRule(identityReference, CryptoKeyAccessRule.RightsFromAccessMask(accessMask), type);
		}

		// Token: 0x06001F06 RID: 7942 RVA: 0x0006D20D File Offset: 0x0006B40D
		public sealed override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new CryptoKeyAuditRule(identityReference, CryptoKeyAuditRule.RightsFromAccessMask(accessMask), flags);
		}

		// Token: 0x06001F07 RID: 7943 RVA: 0x0006D21D File Offset: 0x0006B41D
		public void AddAccessRule(CryptoKeyAccessRule rule)
		{
			base.AddAccessRule(rule);
		}

		// Token: 0x06001F08 RID: 7944 RVA: 0x0006D226 File Offset: 0x0006B426
		public void SetAccessRule(CryptoKeyAccessRule rule)
		{
			base.SetAccessRule(rule);
		}

		// Token: 0x06001F09 RID: 7945 RVA: 0x0006D22F File Offset: 0x0006B42F
		public void ResetAccessRule(CryptoKeyAccessRule rule)
		{
			base.ResetAccessRule(rule);
		}

		// Token: 0x06001F0A RID: 7946 RVA: 0x0006D238 File Offset: 0x0006B438
		public bool RemoveAccessRule(CryptoKeyAccessRule rule)
		{
			return base.RemoveAccessRule(rule);
		}

		// Token: 0x06001F0B RID: 7947 RVA: 0x0006D241 File Offset: 0x0006B441
		public void RemoveAccessRuleAll(CryptoKeyAccessRule rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		// Token: 0x06001F0C RID: 7948 RVA: 0x0006D24A File Offset: 0x0006B44A
		public void RemoveAccessRuleSpecific(CryptoKeyAccessRule rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		// Token: 0x06001F0D RID: 7949 RVA: 0x0006D253 File Offset: 0x0006B453
		public void AddAuditRule(CryptoKeyAuditRule rule)
		{
			base.AddAuditRule(rule);
		}

		// Token: 0x06001F0E RID: 7950 RVA: 0x0006D25C File Offset: 0x0006B45C
		public void SetAuditRule(CryptoKeyAuditRule rule)
		{
			base.SetAuditRule(rule);
		}

		// Token: 0x06001F0F RID: 7951 RVA: 0x0006D265 File Offset: 0x0006B465
		public bool RemoveAuditRule(CryptoKeyAuditRule rule)
		{
			return base.RemoveAuditRule(rule);
		}

		// Token: 0x06001F10 RID: 7952 RVA: 0x0006D26E File Offset: 0x0006B46E
		public void RemoveAuditRuleAll(CryptoKeyAuditRule rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		// Token: 0x06001F11 RID: 7953 RVA: 0x0006D277 File Offset: 0x0006B477
		public void RemoveAuditRuleSpecific(CryptoKeyAuditRule rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06001F12 RID: 7954 RVA: 0x0006D280 File Offset: 0x0006B480
		public override Type AccessRightType
		{
			get
			{
				return typeof(CryptoKeyRights);
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06001F13 RID: 7955 RVA: 0x0006D28C File Offset: 0x0006B48C
		public override Type AccessRuleType
		{
			get
			{
				return typeof(CryptoKeyAccessRule);
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06001F14 RID: 7956 RVA: 0x0006D298 File Offset: 0x0006B498
		public override Type AuditRuleType
		{
			get
			{
				return typeof(CryptoKeyAuditRule);
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06001F15 RID: 7957 RVA: 0x0006D2A4 File Offset: 0x0006B4A4
		internal AccessControlSections ChangedAccessControlSections
		{
			[SecurityCritical]
			get
			{
				AccessControlSections accessControlSections = AccessControlSections.None;
				bool flag = false;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
					}
					finally
					{
						base.ReadLock();
						flag = true;
					}
					if (base.AccessRulesModified)
					{
						accessControlSections |= AccessControlSections.Access;
					}
					if (base.AuditRulesModified)
					{
						accessControlSections |= AccessControlSections.Audit;
					}
					if (base.GroupModified)
					{
						accessControlSections |= AccessControlSections.Group;
					}
					if (base.OwnerModified)
					{
						accessControlSections |= AccessControlSections.Owner;
					}
				}
				finally
				{
					if (flag)
					{
						base.ReadUnlock();
					}
				}
				return accessControlSections;
			}
		}

		// Token: 0x04000B25 RID: 2853
		private const ResourceType s_ResourceType = ResourceType.FileObject;
	}
}
