using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000226 RID: 550
	public class AuditRule<T> : AuditRule where T : struct
	{
		// Token: 0x06001FC1 RID: 8129 RVA: 0x0006ED8F File Offset: 0x0006CF8F
		public AuditRule(IdentityReference identity, T rights, AuditFlags flags) : this(identity, rights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001FC2 RID: 8130 RVA: 0x0006ED9C File Offset: 0x0006CF9C
		public AuditRule(IdentityReference identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(identity, (int)((object)rights), false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x06001FC3 RID: 8131 RVA: 0x0006EDB6 File Offset: 0x0006CFB6
		public AuditRule(string identity, T rights, AuditFlags flags) : this(new NTAccount(identity), rights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x0006EDC8 File Offset: 0x0006CFC8
		public AuditRule(string identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(new NTAccount(identity), (int)((object)rights), false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x0006EDE7 File Offset: 0x0006CFE7
		internal AuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001FC6 RID: 8134 RVA: 0x0006EDF8 File Offset: 0x0006CFF8
		public T Rights
		{
			get
			{
				return (T)((object)base.AccessMask);
			}
		}
	}
}
