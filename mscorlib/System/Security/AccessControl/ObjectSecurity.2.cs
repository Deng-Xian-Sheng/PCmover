using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000227 RID: 551
	public abstract class ObjectSecurity<T> : NativeObjectSecurity where T : struct
	{
		// Token: 0x06001FC7 RID: 8135 RVA: 0x0006EE0A File Offset: 0x0006D00A
		protected ObjectSecurity(bool isContainer, ResourceType resourceType) : base(isContainer, resourceType, null, null)
		{
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x0006EE16 File Offset: 0x0006D016
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections) : base(isContainer, resourceType, name, includeSections, null, null)
		{
		}

		// Token: 0x06001FC9 RID: 8137 RVA: 0x0006EE25 File Offset: 0x0006D025
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections, NativeObjectSecurity.ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext) : base(isContainer, resourceType, name, includeSections, exceptionFromErrorCode, exceptionContext)
		{
		}

		// Token: 0x06001FCA RID: 8138 RVA: 0x0006EE36 File Offset: 0x0006D036
		[SecuritySafeCritical]
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, SafeHandle safeHandle, AccessControlSections includeSections) : base(isContainer, resourceType, safeHandle, includeSections, null, null)
		{
		}

		// Token: 0x06001FCB RID: 8139 RVA: 0x0006EE45 File Offset: 0x0006D045
		[SecuritySafeCritical]
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, SafeHandle safeHandle, AccessControlSections includeSections, NativeObjectSecurity.ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext) : base(isContainer, resourceType, safeHandle, includeSections, exceptionFromErrorCode, exceptionContext)
		{
		}

		// Token: 0x06001FCC RID: 8140 RVA: 0x0006EE56 File Offset: 0x0006D056
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new AccessRule<T>(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
		}

		// Token: 0x06001FCD RID: 8141 RVA: 0x0006EE66 File Offset: 0x0006D066
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new AuditRule<T>(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
		}

		// Token: 0x06001FCE RID: 8142 RVA: 0x0006EE78 File Offset: 0x0006D078
		private AccessControlSections GetAccessControlSectionsFromChanges()
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

		// Token: 0x06001FCF RID: 8143 RVA: 0x0006EEB8 File Offset: 0x0006D0B8
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		protected internal void Persist(SafeHandle handle)
		{
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

		// Token: 0x06001FD0 RID: 8144 RVA: 0x0006EF18 File Offset: 0x0006D118
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		protected internal void Persist(string name)
		{
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				base.Persist(name, accessControlSectionsFromChanges);
				base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		// Token: 0x06001FD1 RID: 8145 RVA: 0x0006EF78 File Offset: 0x0006D178
		public virtual void AddAccessRule(AccessRule<T> rule)
		{
			base.AddAccessRule(rule);
		}

		// Token: 0x06001FD2 RID: 8146 RVA: 0x0006EF81 File Offset: 0x0006D181
		public virtual void SetAccessRule(AccessRule<T> rule)
		{
			base.SetAccessRule(rule);
		}

		// Token: 0x06001FD3 RID: 8147 RVA: 0x0006EF8A File Offset: 0x0006D18A
		public virtual void ResetAccessRule(AccessRule<T> rule)
		{
			base.ResetAccessRule(rule);
		}

		// Token: 0x06001FD4 RID: 8148 RVA: 0x0006EF93 File Offset: 0x0006D193
		public virtual bool RemoveAccessRule(AccessRule<T> rule)
		{
			return base.RemoveAccessRule(rule);
		}

		// Token: 0x06001FD5 RID: 8149 RVA: 0x0006EF9C File Offset: 0x0006D19C
		public virtual void RemoveAccessRuleAll(AccessRule<T> rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x0006EFA5 File Offset: 0x0006D1A5
		public virtual void RemoveAccessRuleSpecific(AccessRule<T> rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x0006EFAE File Offset: 0x0006D1AE
		public virtual void AddAuditRule(AuditRule<T> rule)
		{
			base.AddAuditRule(rule);
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x0006EFB7 File Offset: 0x0006D1B7
		public virtual void SetAuditRule(AuditRule<T> rule)
		{
			base.SetAuditRule(rule);
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x0006EFC0 File Offset: 0x0006D1C0
		public virtual bool RemoveAuditRule(AuditRule<T> rule)
		{
			return base.RemoveAuditRule(rule);
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x0006EFC9 File Offset: 0x0006D1C9
		public virtual void RemoveAuditRuleAll(AuditRule<T> rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		// Token: 0x06001FDB RID: 8155 RVA: 0x0006EFD2 File Offset: 0x0006D1D2
		public virtual void RemoveAuditRuleSpecific(AuditRule<T> rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001FDC RID: 8156 RVA: 0x0006EFDB File Offset: 0x0006D1DB
		public override Type AccessRightType
		{
			get
			{
				return typeof(T);
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001FDD RID: 8157 RVA: 0x0006EFE7 File Offset: 0x0006D1E7
		public override Type AccessRuleType
		{
			get
			{
				return typeof(AccessRule<T>);
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06001FDE RID: 8158 RVA: 0x0006EFF3 File Offset: 0x0006D1F3
		public override Type AuditRuleType
		{
			get
			{
				return typeof(AuditRule<T>);
			}
		}
	}
}
