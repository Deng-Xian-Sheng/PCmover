using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000216 RID: 534
	public sealed class EventWaitHandleAuditRule : AuditRule
	{
		// Token: 0x06001F1A RID: 7962 RVA: 0x0006D35E File Offset: 0x0006B55E
		public EventWaitHandleAuditRule(IdentityReference identity, EventWaitHandleRights eventRights, AuditFlags flags) : this(identity, (int)eventRights, false, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001F1B RID: 7963 RVA: 0x0006D36C File Offset: 0x0006B56C
		internal EventWaitHandleAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06001F1C RID: 7964 RVA: 0x0006D37D File Offset: 0x0006B57D
		public EventWaitHandleRights EventWaitHandleRights
		{
			get
			{
				return (EventWaitHandleRights)base.AccessMask;
			}
		}
	}
}
