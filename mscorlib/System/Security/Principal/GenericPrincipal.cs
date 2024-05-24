using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace System.Security.Principal
{
	// Token: 0x02000322 RID: 802
	[ComVisible(true)]
	[Serializable]
	public class GenericPrincipal : ClaimsPrincipal
	{
		// Token: 0x06002892 RID: 10386 RVA: 0x00094CE4 File Offset: 0x00092EE4
		public GenericPrincipal(IIdentity identity, string[] roles)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			this.m_identity = identity;
			if (roles != null)
			{
				this.m_roles = new string[roles.Length];
				for (int i = 0; i < roles.Length; i++)
				{
					this.m_roles[i] = roles[i];
				}
			}
			else
			{
				this.m_roles = null;
			}
			this.AddIdentityWithRoles(this.m_identity, this.m_roles);
		}

		// Token: 0x06002893 RID: 10387 RVA: 0x00094D54 File Offset: 0x00092F54
		[OnDeserialized]
		private void OnDeserializedMethod(StreamingContext context)
		{
			ClaimsIdentity claimsIdentity = null;
			foreach (ClaimsIdentity claimsIdentity2 in base.Identities)
			{
				if (claimsIdentity2 != null)
				{
					claimsIdentity = claimsIdentity2;
					break;
				}
			}
			if (this.m_roles != null && this.m_roles.Length != 0 && claimsIdentity != null)
			{
				claimsIdentity.ExternalClaims.Add(new RoleClaimProvider("LOCAL AUTHORITY", this.m_roles, claimsIdentity).Claims);
				return;
			}
			if (claimsIdentity == null)
			{
				this.AddIdentityWithRoles(this.m_identity, this.m_roles);
			}
		}

		// Token: 0x06002894 RID: 10388 RVA: 0x00094DF0 File Offset: 0x00092FF0
		[SecuritySafeCritical]
		private void AddIdentityWithRoles(IIdentity identity, string[] roles)
		{
			ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
			if (claimsIdentity != null)
			{
				claimsIdentity = claimsIdentity.Clone();
			}
			else
			{
				claimsIdentity = new ClaimsIdentity(identity);
			}
			if (roles != null && roles.Length != 0)
			{
				claimsIdentity.ExternalClaims.Add(new RoleClaimProvider("LOCAL AUTHORITY", roles, claimsIdentity).Claims);
			}
			base.AddIdentity(claimsIdentity);
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06002895 RID: 10389 RVA: 0x00094E41 File Offset: 0x00093041
		public override IIdentity Identity
		{
			get
			{
				return this.m_identity;
			}
		}

		// Token: 0x06002896 RID: 10390 RVA: 0x00094E4C File Offset: 0x0009304C
		public override bool IsInRole(string role)
		{
			if (role == null || this.m_roles == null)
			{
				return false;
			}
			for (int i = 0; i < this.m_roles.Length; i++)
			{
				if (this.m_roles[i] != null && string.Compare(this.m_roles[i], role, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return true;
				}
			}
			return base.IsInRole(role);
		}

		// Token: 0x04001005 RID: 4101
		private IIdentity m_identity;

		// Token: 0x04001006 RID: 4102
		private string[] m_roles;
	}
}
