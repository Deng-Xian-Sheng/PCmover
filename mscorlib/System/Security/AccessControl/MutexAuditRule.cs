using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000220 RID: 544
	public sealed class MutexAuditRule : AuditRule
	{
		// Token: 0x06001F62 RID: 8034 RVA: 0x0006DBD2 File Offset: 0x0006BDD2
		public MutexAuditRule(IdentityReference identity, MutexRights eventRights, AuditFlags flags) : this(identity, (int)eventRights, false, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001F63 RID: 8035 RVA: 0x0006DBE0 File Offset: 0x0006BDE0
		internal MutexAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06001F64 RID: 8036 RVA: 0x0006DBF1 File Offset: 0x0006BDF1
		public MutexRights MutexRights
		{
			get
			{
				return (MutexRights)base.AccessMask;
			}
		}
	}
}
