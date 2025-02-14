﻿using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000235 RID: 565
	public abstract class ObjectAuditRule : AuditRule
	{
		// Token: 0x06002044 RID: 8260 RVA: 0x00071510 File Offset: 0x0006F710
		protected ObjectAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, Guid objectType, Guid inheritedObjectType, AuditFlags auditFlags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, auditFlags)
		{
			if (!objectType.Equals(Guid.Empty) && (accessMask & ObjectAce.AccessMaskWithObjectType) != 0)
			{
				this._objectType = objectType;
				this._objectFlags |= ObjectAceFlags.ObjectAceTypePresent;
			}
			else
			{
				this._objectType = Guid.Empty;
			}
			if (!inheritedObjectType.Equals(Guid.Empty) && (inheritanceFlags & InheritanceFlags.ContainerInherit) != InheritanceFlags.None)
			{
				this._inheritedObjectType = inheritedObjectType;
				this._objectFlags |= ObjectAceFlags.InheritedObjectAceTypePresent;
				return;
			}
			this._inheritedObjectType = Guid.Empty;
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06002045 RID: 8261 RVA: 0x0007159C File Offset: 0x0006F79C
		public Guid ObjectType
		{
			get
			{
				return this._objectType;
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06002046 RID: 8262 RVA: 0x000715A4 File Offset: 0x0006F7A4
		public Guid InheritedObjectType
		{
			get
			{
				return this._inheritedObjectType;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06002047 RID: 8263 RVA: 0x000715AC File Offset: 0x0006F7AC
		public ObjectAceFlags ObjectFlags
		{
			get
			{
				return this._objectFlags;
			}
		}

		// Token: 0x04000BAC RID: 2988
		private readonly Guid _objectType;

		// Token: 0x04000BAD RID: 2989
		private readonly Guid _inheritedObjectType;

		// Token: 0x04000BAE RID: 2990
		private readonly ObjectAceFlags _objectFlags;
	}
}
