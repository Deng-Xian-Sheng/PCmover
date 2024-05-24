using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

namespace System.Security.AccessControl
{
	// Token: 0x0200022F RID: 559
	public sealed class RegistrySecurity : NativeObjectSecurity
	{
		// Token: 0x06002021 RID: 8225 RVA: 0x0007102C File Offset: 0x0006F22C
		public RegistrySecurity() : base(true, ResourceType.RegistryKey)
		{
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x00071036 File Offset: 0x0006F236
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal RegistrySecurity(SafeRegistryHandle hKey, string name, AccessControlSections includeSections) : base(true, ResourceType.RegistryKey, hKey, includeSections, new NativeObjectSecurity.ExceptionFromErrorCode(RegistrySecurity._HandleErrorCode), null)
		{
			new RegistryPermission(RegistryPermissionAccess.NoAccess, AccessControlActions.View, name).Demand();
		}

		// Token: 0x06002023 RID: 8227 RVA: 0x0007105C File Offset: 0x0006F25C
		[SecurityCritical]
		private static Exception _HandleErrorCode(int errorCode, string name, SafeHandle handle, object context)
		{
			Exception result = null;
			if (errorCode != 2)
			{
				if (errorCode != 6)
				{
					if (errorCode == 123)
					{
						result = new ArgumentException(Environment.GetResourceString("Arg_RegInvalidKeyName", new object[]
						{
							"name"
						}));
					}
				}
				else
				{
					result = new ArgumentException(Environment.GetResourceString("AccessControl_InvalidHandle"));
				}
			}
			else
			{
				result = new IOException(Environment.GetResourceString("Arg_RegKeyNotFound", new object[]
				{
					errorCode
				}));
			}
			return result;
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x000710CC File Offset: 0x0006F2CC
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new RegistryAccessRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
		}

		// Token: 0x06002025 RID: 8229 RVA: 0x000710DC File Offset: 0x0006F2DC
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new RegistryAuditRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x000710EC File Offset: 0x0006F2EC
		internal AccessControlSections GetAccessControlSectionsFromChanges()
		{
			AccessControlSections accessControlSections = AccessControlSections.None;
			if (base.AccessRulesModified)
			{
				accessControlSections = AccessControlSections.Access;
			}
			if (base.AuditRulesModified)
			{
				accessControlSections |= AccessControlSections.Audit;
			}
			if (base.OwnerModified)
			{
				accessControlSections |= AccessControlSections.Owner;
			}
			if (base.GroupModified)
			{
				accessControlSections |= AccessControlSections.Group;
			}
			return accessControlSections;
		}

		// Token: 0x06002027 RID: 8231 RVA: 0x0007112C File Offset: 0x0006F32C
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal void Persist(SafeRegistryHandle hKey, string keyName)
		{
			new RegistryPermission(RegistryPermissionAccess.NoAccess, AccessControlActions.Change, keyName).Demand();
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				if (accessControlSectionsFromChanges != AccessControlSections.None)
				{
					base.Persist(hKey, accessControlSectionsFromChanges);
					base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
				}
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x0007119C File Offset: 0x0006F39C
		public void AddAccessRule(RegistryAccessRule rule)
		{
			base.AddAccessRule(rule);
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x000711A5 File Offset: 0x0006F3A5
		public void SetAccessRule(RegistryAccessRule rule)
		{
			base.SetAccessRule(rule);
		}

		// Token: 0x0600202A RID: 8234 RVA: 0x000711AE File Offset: 0x0006F3AE
		public void ResetAccessRule(RegistryAccessRule rule)
		{
			base.ResetAccessRule(rule);
		}

		// Token: 0x0600202B RID: 8235 RVA: 0x000711B7 File Offset: 0x0006F3B7
		public bool RemoveAccessRule(RegistryAccessRule rule)
		{
			return base.RemoveAccessRule(rule);
		}

		// Token: 0x0600202C RID: 8236 RVA: 0x000711C0 File Offset: 0x0006F3C0
		public void RemoveAccessRuleAll(RegistryAccessRule rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		// Token: 0x0600202D RID: 8237 RVA: 0x000711C9 File Offset: 0x0006F3C9
		public void RemoveAccessRuleSpecific(RegistryAccessRule rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		// Token: 0x0600202E RID: 8238 RVA: 0x000711D2 File Offset: 0x0006F3D2
		public void AddAuditRule(RegistryAuditRule rule)
		{
			base.AddAuditRule(rule);
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x000711DB File Offset: 0x0006F3DB
		public void SetAuditRule(RegistryAuditRule rule)
		{
			base.SetAuditRule(rule);
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x000711E4 File Offset: 0x0006F3E4
		public bool RemoveAuditRule(RegistryAuditRule rule)
		{
			return base.RemoveAuditRule(rule);
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x000711ED File Offset: 0x0006F3ED
		public void RemoveAuditRuleAll(RegistryAuditRule rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		// Token: 0x06002032 RID: 8242 RVA: 0x000711F6 File Offset: 0x0006F3F6
		public void RemoveAuditRuleSpecific(RegistryAuditRule rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06002033 RID: 8243 RVA: 0x000711FF File Offset: 0x0006F3FF
		public override Type AccessRightType
		{
			get
			{
				return typeof(RegistryRights);
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06002034 RID: 8244 RVA: 0x0007120B File Offset: 0x0006F40B
		public override Type AccessRuleType
		{
			get
			{
				return typeof(RegistryAccessRule);
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06002035 RID: 8245 RVA: 0x00071217 File Offset: 0x0006F417
		public override Type AuditRuleType
		{
			get
			{
				return typeof(RegistryAuditRule);
			}
		}
	}
}
