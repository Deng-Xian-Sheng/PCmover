using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Security.Claims
{
	// Token: 0x02000320 RID: 800
	[ComVisible(false)]
	internal class RoleClaimProvider
	{
		// Token: 0x06002885 RID: 10373 RVA: 0x00094B55 File Offset: 0x00092D55
		public RoleClaimProvider(string issuer, string[] roles, ClaimsIdentity subject)
		{
			this.m_issuer = issuer;
			this.m_roles = roles;
			this.m_subject = subject;
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06002886 RID: 10374 RVA: 0x00094B74 File Offset: 0x00092D74
		public IEnumerable<Claim> Claims
		{
			get
			{
				int num;
				for (int i = 0; i < this.m_roles.Length; i = num + 1)
				{
					if (this.m_roles[i] != null)
					{
						yield return new Claim(this.m_subject.RoleClaimType, this.m_roles[i], "http://www.w3.org/2001/XMLSchema#string", this.m_issuer, this.m_issuer, this.m_subject);
					}
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x04001000 RID: 4096
		private string m_issuer;

		// Token: 0x04001001 RID: 4097
		private string[] m_roles;

		// Token: 0x04001002 RID: 4098
		private ClaimsIdentity m_subject;
	}
}
