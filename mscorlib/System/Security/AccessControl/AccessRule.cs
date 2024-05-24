using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000225 RID: 549
	public class AccessRule<T> : AccessRule where T : struct
	{
		// Token: 0x06001FBB RID: 8123 RVA: 0x0006ECFE File Offset: 0x0006CEFE
		public AccessRule(IdentityReference identity, T rights, AccessControlType type) : this(identity, (int)((object)rights), false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001FBC RID: 8124 RVA: 0x0006ED16 File Offset: 0x0006CF16
		public AccessRule(string identity, T rights, AccessControlType type) : this(new NTAccount(identity), (int)((object)rights), false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001FBD RID: 8125 RVA: 0x0006ED33 File Offset: 0x0006CF33
		public AccessRule(IdentityReference identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : this(identity, (int)((object)rights), false, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x06001FBE RID: 8126 RVA: 0x0006ED4D File Offset: 0x0006CF4D
		public AccessRule(string identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : this(new NTAccount(identity), (int)((object)rights), false, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x06001FBF RID: 8127 RVA: 0x0006ED6C File Offset: 0x0006CF6C
		internal AccessRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06001FC0 RID: 8128 RVA: 0x0006ED7D File Offset: 0x0006CF7D
		public T Rights
		{
			get
			{
				return (T)((object)base.AccessMask);
			}
		}
	}
}
