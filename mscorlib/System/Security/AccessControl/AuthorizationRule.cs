using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000231 RID: 561
	public abstract class AuthorizationRule
	{
		// Token: 0x06002036 RID: 8246 RVA: 0x00071224 File Offset: 0x0006F424
		protected internal AuthorizationRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			if (accessMask == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ArgumentZero"), "accessMask");
			}
			if (inheritanceFlags < InheritanceFlags.None || inheritanceFlags > (InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit))
			{
				throw new ArgumentOutOfRangeException("inheritanceFlags", Environment.GetResourceString("Argument_InvalidEnumValue", new object[]
				{
					inheritanceFlags,
					"InheritanceFlags"
				}));
			}
			if (propagationFlags < PropagationFlags.None || propagationFlags > (PropagationFlags.NoPropagateInherit | PropagationFlags.InheritOnly))
			{
				throw new ArgumentOutOfRangeException("propagationFlags", Environment.GetResourceString("Argument_InvalidEnumValue", new object[]
				{
					inheritanceFlags,
					"PropagationFlags"
				}));
			}
			if (!identity.IsValidTargetType(typeof(SecurityIdentifier)))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeIdentityReferenceType"), "identity");
			}
			this._identity = identity;
			this._accessMask = accessMask;
			this._isInherited = isInherited;
			this._inheritanceFlags = inheritanceFlags;
			if (inheritanceFlags != InheritanceFlags.None)
			{
				this._propagationFlags = propagationFlags;
				return;
			}
			this._propagationFlags = PropagationFlags.None;
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06002037 RID: 8247 RVA: 0x00071329 File Offset: 0x0006F529
		public IdentityReference IdentityReference
		{
			get
			{
				return this._identity;
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06002038 RID: 8248 RVA: 0x00071331 File Offset: 0x0006F531
		protected internal int AccessMask
		{
			get
			{
				return this._accessMask;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06002039 RID: 8249 RVA: 0x00071339 File Offset: 0x0006F539
		public bool IsInherited
		{
			get
			{
				return this._isInherited;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600203A RID: 8250 RVA: 0x00071341 File Offset: 0x0006F541
		public InheritanceFlags InheritanceFlags
		{
			get
			{
				return this._inheritanceFlags;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600203B RID: 8251 RVA: 0x00071349 File Offset: 0x0006F549
		public PropagationFlags PropagationFlags
		{
			get
			{
				return this._propagationFlags;
			}
		}

		// Token: 0x04000BA2 RID: 2978
		private readonly IdentityReference _identity;

		// Token: 0x04000BA3 RID: 2979
		private readonly int _accessMask;

		// Token: 0x04000BA4 RID: 2980
		private readonly bool _isInherited;

		// Token: 0x04000BA5 RID: 2981
		private readonly InheritanceFlags _inheritanceFlags;

		// Token: 0x04000BA6 RID: 2982
		private readonly PropagationFlags _propagationFlags;
	}
}
