using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace System.Security.AccessControl
{
	// Token: 0x02000221 RID: 545
	public sealed class MutexSecurity : NativeObjectSecurity
	{
		// Token: 0x06001F65 RID: 8037 RVA: 0x0006DBF9 File Offset: 0x0006BDF9
		public MutexSecurity() : base(true, ResourceType.KernelObject)
		{
		}

		// Token: 0x06001F66 RID: 8038 RVA: 0x0006DC03 File Offset: 0x0006BE03
		[SecuritySafeCritical]
		public MutexSecurity(string name, AccessControlSections includeSections) : base(true, ResourceType.KernelObject, name, includeSections, new NativeObjectSecurity.ExceptionFromErrorCode(MutexSecurity._HandleErrorCode), null)
		{
		}

		// Token: 0x06001F67 RID: 8039 RVA: 0x0006DC1C File Offset: 0x0006BE1C
		[SecurityCritical]
		internal MutexSecurity(SafeWaitHandle handle, AccessControlSections includeSections) : base(true, ResourceType.KernelObject, handle, includeSections, new NativeObjectSecurity.ExceptionFromErrorCode(MutexSecurity._HandleErrorCode), null)
		{
		}

		// Token: 0x06001F68 RID: 8040 RVA: 0x0006DC38 File Offset: 0x0006BE38
		[SecurityCritical]
		private static Exception _HandleErrorCode(int errorCode, string name, SafeHandle handle, object context)
		{
			Exception result = null;
			if (errorCode == 2 || errorCode == 6 || errorCode == 123)
			{
				if (name != null && name.Length != 0)
				{
					result = new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", new object[]
					{
						name
					}));
				}
				else
				{
					result = new WaitHandleCannotBeOpenedException();
				}
			}
			return result;
		}

		// Token: 0x06001F69 RID: 8041 RVA: 0x0006DC82 File Offset: 0x0006BE82
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new MutexAccessRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
		}

		// Token: 0x06001F6A RID: 8042 RVA: 0x0006DC92 File Offset: 0x0006BE92
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new MutexAuditRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x0006DCA4 File Offset: 0x0006BEA4
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

		// Token: 0x06001F6C RID: 8044 RVA: 0x0006DCE4 File Offset: 0x0006BEE4
		[SecurityCritical]
		internal void Persist(SafeWaitHandle handle)
		{
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				if (accessControlSectionsFromChanges != AccessControlSections.None)
				{
					base.Persist(handle, accessControlSectionsFromChanges);
					base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
				}
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x0006DD48 File Offset: 0x0006BF48
		public void AddAccessRule(MutexAccessRule rule)
		{
			base.AddAccessRule(rule);
		}

		// Token: 0x06001F6E RID: 8046 RVA: 0x0006DD51 File Offset: 0x0006BF51
		public void SetAccessRule(MutexAccessRule rule)
		{
			base.SetAccessRule(rule);
		}

		// Token: 0x06001F6F RID: 8047 RVA: 0x0006DD5A File Offset: 0x0006BF5A
		public void ResetAccessRule(MutexAccessRule rule)
		{
			base.ResetAccessRule(rule);
		}

		// Token: 0x06001F70 RID: 8048 RVA: 0x0006DD63 File Offset: 0x0006BF63
		public bool RemoveAccessRule(MutexAccessRule rule)
		{
			return base.RemoveAccessRule(rule);
		}

		// Token: 0x06001F71 RID: 8049 RVA: 0x0006DD6C File Offset: 0x0006BF6C
		public void RemoveAccessRuleAll(MutexAccessRule rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		// Token: 0x06001F72 RID: 8050 RVA: 0x0006DD75 File Offset: 0x0006BF75
		public void RemoveAccessRuleSpecific(MutexAccessRule rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		// Token: 0x06001F73 RID: 8051 RVA: 0x0006DD7E File Offset: 0x0006BF7E
		public void AddAuditRule(MutexAuditRule rule)
		{
			base.AddAuditRule(rule);
		}

		// Token: 0x06001F74 RID: 8052 RVA: 0x0006DD87 File Offset: 0x0006BF87
		public void SetAuditRule(MutexAuditRule rule)
		{
			base.SetAuditRule(rule);
		}

		// Token: 0x06001F75 RID: 8053 RVA: 0x0006DD90 File Offset: 0x0006BF90
		public bool RemoveAuditRule(MutexAuditRule rule)
		{
			return base.RemoveAuditRule(rule);
		}

		// Token: 0x06001F76 RID: 8054 RVA: 0x0006DD99 File Offset: 0x0006BF99
		public void RemoveAuditRuleAll(MutexAuditRule rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		// Token: 0x06001F77 RID: 8055 RVA: 0x0006DDA2 File Offset: 0x0006BFA2
		public void RemoveAuditRuleSpecific(MutexAuditRule rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06001F78 RID: 8056 RVA: 0x0006DDAB File Offset: 0x0006BFAB
		public override Type AccessRightType
		{
			get
			{
				return typeof(MutexRights);
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06001F79 RID: 8057 RVA: 0x0006DDB7 File Offset: 0x0006BFB7
		public override Type AccessRuleType
		{
			get
			{
				return typeof(MutexAccessRule);
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06001F7A RID: 8058 RVA: 0x0006DDC3 File Offset: 0x0006BFC3
		public override Type AuditRuleType
		{
			get
			{
				return typeof(MutexAuditRule);
			}
		}
	}
}
