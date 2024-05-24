using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

namespace System.Security.AccessControl
{
	// Token: 0x0200021B RID: 539
	public abstract class FileSystemSecurity : NativeObjectSecurity
	{
		// Token: 0x06001F42 RID: 8002 RVA: 0x0006D6F7 File Offset: 0x0006B8F7
		[SecurityCritical]
		internal FileSystemSecurity(bool isContainer) : base(isContainer, ResourceType.FileObject, new NativeObjectSecurity.ExceptionFromErrorCode(FileSystemSecurity._HandleErrorCode), isContainer)
		{
		}

		// Token: 0x06001F43 RID: 8003 RVA: 0x0006D713 File Offset: 0x0006B913
		[SecurityCritical]
		internal FileSystemSecurity(bool isContainer, string name, AccessControlSections includeSections, bool isDirectory) : base(isContainer, ResourceType.FileObject, name, includeSections, new NativeObjectSecurity.ExceptionFromErrorCode(FileSystemSecurity._HandleErrorCode), isDirectory)
		{
		}

		// Token: 0x06001F44 RID: 8004 RVA: 0x0006D732 File Offset: 0x0006B932
		[SecurityCritical]
		internal FileSystemSecurity(bool isContainer, SafeFileHandle handle, AccessControlSections includeSections, bool isDirectory) : base(isContainer, ResourceType.FileObject, handle, includeSections, new NativeObjectSecurity.ExceptionFromErrorCode(FileSystemSecurity._HandleErrorCode), isDirectory)
		{
		}

		// Token: 0x06001F45 RID: 8005 RVA: 0x0006D754 File Offset: 0x0006B954
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
						result = new ArgumentException(Environment.GetResourceString("Argument_InvalidName"), "name");
					}
				}
				else
				{
					result = new ArgumentException(Environment.GetResourceString("AccessControl_InvalidHandle"));
				}
			}
			else if (context != null && context is bool && (bool)context)
			{
				if (name != null && name.Length != 0)
				{
					result = new DirectoryNotFoundException(name);
				}
				else
				{
					result = new DirectoryNotFoundException();
				}
			}
			else if (name != null && name.Length != 0)
			{
				result = new FileNotFoundException(name);
			}
			else
			{
				result = new FileNotFoundException();
			}
			return result;
		}

		// Token: 0x06001F46 RID: 8006 RVA: 0x0006D7E3 File Offset: 0x0006B9E3
		public sealed override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new FileSystemAccessRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
		}

		// Token: 0x06001F47 RID: 8007 RVA: 0x0006D7F3 File Offset: 0x0006B9F3
		public sealed override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new FileSystemAuditRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
		}

		// Token: 0x06001F48 RID: 8008 RVA: 0x0006D804 File Offset: 0x0006BA04
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

		// Token: 0x06001F49 RID: 8009 RVA: 0x0006D844 File Offset: 0x0006BA44
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal void Persist(string fullPath)
		{
			FileIOPermission.QuickDemand(FileIOPermissionAccess.NoAccess, AccessControlActions.Change, fullPath, false, true);
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				base.Persist(fullPath, accessControlSectionsFromChanges);
				base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		// Token: 0x06001F4A RID: 8010 RVA: 0x0006D8AC File Offset: 0x0006BAAC
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal void Persist(SafeFileHandle handle, string fullPath)
		{
			if (fullPath != null)
			{
				FileIOPermission.QuickDemand(FileIOPermissionAccess.NoAccess, AccessControlActions.Change, fullPath, false, true);
			}
			else
			{
				FileIOPermission.QuickDemand(PermissionState.Unrestricted);
			}
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				base.Persist(handle, accessControlSectionsFromChanges);
				base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		// Token: 0x06001F4B RID: 8011 RVA: 0x0006D920 File Offset: 0x0006BB20
		public void AddAccessRule(FileSystemAccessRule rule)
		{
			base.AddAccessRule(rule);
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x0006D929 File Offset: 0x0006BB29
		public void SetAccessRule(FileSystemAccessRule rule)
		{
			base.SetAccessRule(rule);
		}

		// Token: 0x06001F4D RID: 8013 RVA: 0x0006D932 File Offset: 0x0006BB32
		public void ResetAccessRule(FileSystemAccessRule rule)
		{
			base.ResetAccessRule(rule);
		}

		// Token: 0x06001F4E RID: 8014 RVA: 0x0006D93C File Offset: 0x0006BB3C
		public bool RemoveAccessRule(FileSystemAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			AuthorizationRuleCollection accessRules = base.GetAccessRules(true, true, rule.IdentityReference.GetType());
			for (int i = 0; i < accessRules.Count; i++)
			{
				FileSystemAccessRule fileSystemAccessRule = accessRules[i] as FileSystemAccessRule;
				if (fileSystemAccessRule != null && fileSystemAccessRule.FileSystemRights == rule.FileSystemRights && fileSystemAccessRule.IdentityReference == rule.IdentityReference && fileSystemAccessRule.AccessControlType == rule.AccessControlType)
				{
					return base.RemoveAccessRule(rule);
				}
			}
			FileSystemAccessRule rule2 = new FileSystemAccessRule(rule.IdentityReference, FileSystemAccessRule.AccessMaskFromRights(rule.FileSystemRights, AccessControlType.Deny), rule.IsInherited, rule.InheritanceFlags, rule.PropagationFlags, rule.AccessControlType);
			return base.RemoveAccessRule(rule2);
		}

		// Token: 0x06001F4F RID: 8015 RVA: 0x0006D9FA File Offset: 0x0006BBFA
		public void RemoveAccessRuleAll(FileSystemAccessRule rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		// Token: 0x06001F50 RID: 8016 RVA: 0x0006DA04 File Offset: 0x0006BC04
		public void RemoveAccessRuleSpecific(FileSystemAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			AuthorizationRuleCollection accessRules = base.GetAccessRules(true, true, rule.IdentityReference.GetType());
			for (int i = 0; i < accessRules.Count; i++)
			{
				FileSystemAccessRule fileSystemAccessRule = accessRules[i] as FileSystemAccessRule;
				if (fileSystemAccessRule != null && fileSystemAccessRule.FileSystemRights == rule.FileSystemRights && fileSystemAccessRule.IdentityReference == rule.IdentityReference && fileSystemAccessRule.AccessControlType == rule.AccessControlType)
				{
					base.RemoveAccessRuleSpecific(rule);
					return;
				}
			}
			FileSystemAccessRule rule2 = new FileSystemAccessRule(rule.IdentityReference, FileSystemAccessRule.AccessMaskFromRights(rule.FileSystemRights, AccessControlType.Deny), rule.IsInherited, rule.InheritanceFlags, rule.PropagationFlags, rule.AccessControlType);
			base.RemoveAccessRuleSpecific(rule2);
		}

		// Token: 0x06001F51 RID: 8017 RVA: 0x0006DAC2 File Offset: 0x0006BCC2
		public void AddAuditRule(FileSystemAuditRule rule)
		{
			base.AddAuditRule(rule);
		}

		// Token: 0x06001F52 RID: 8018 RVA: 0x0006DACB File Offset: 0x0006BCCB
		public void SetAuditRule(FileSystemAuditRule rule)
		{
			base.SetAuditRule(rule);
		}

		// Token: 0x06001F53 RID: 8019 RVA: 0x0006DAD4 File Offset: 0x0006BCD4
		public bool RemoveAuditRule(FileSystemAuditRule rule)
		{
			return base.RemoveAuditRule(rule);
		}

		// Token: 0x06001F54 RID: 8020 RVA: 0x0006DADD File Offset: 0x0006BCDD
		public void RemoveAuditRuleAll(FileSystemAuditRule rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		// Token: 0x06001F55 RID: 8021 RVA: 0x0006DAE6 File Offset: 0x0006BCE6
		public void RemoveAuditRuleSpecific(FileSystemAuditRule rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06001F56 RID: 8022 RVA: 0x0006DAEF File Offset: 0x0006BCEF
		public override Type AccessRightType
		{
			get
			{
				return typeof(FileSystemRights);
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06001F57 RID: 8023 RVA: 0x0006DAFB File Offset: 0x0006BCFB
		public override Type AccessRuleType
		{
			get
			{
				return typeof(FileSystemAccessRule);
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06001F58 RID: 8024 RVA: 0x0006DB07 File Offset: 0x0006BD07
		public override Type AuditRuleType
		{
			get
			{
				return typeof(FileSystemAuditRule);
			}
		}

		// Token: 0x04000B46 RID: 2886
		private const ResourceType s_ResourceType = ResourceType.FileObject;
	}
}
