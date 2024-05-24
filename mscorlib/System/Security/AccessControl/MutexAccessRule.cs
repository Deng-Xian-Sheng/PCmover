using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x0200021F RID: 543
	public sealed class MutexAccessRule : AccessRule
	{
		// Token: 0x06001F5E RID: 8030 RVA: 0x0006DB98 File Offset: 0x0006BD98
		public MutexAccessRule(IdentityReference identity, MutexRights eventRights, AccessControlType type) : this(identity, (int)eventRights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001F5F RID: 8031 RVA: 0x0006DBA6 File Offset: 0x0006BDA6
		public MutexAccessRule(string identity, MutexRights eventRights, AccessControlType type) : this(new NTAccount(identity), (int)eventRights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001F60 RID: 8032 RVA: 0x0006DBB9 File Offset: 0x0006BDB9
		internal MutexAccessRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06001F61 RID: 8033 RVA: 0x0006DBCA File Offset: 0x0006BDCA
		public MutexRights MutexRights
		{
			get
			{
				return (MutexRights)base.AccessMask;
			}
		}
	}
}
