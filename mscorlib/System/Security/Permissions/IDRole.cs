using System;
using System.Security.Principal;

namespace System.Security.Permissions
{
	// Token: 0x02000303 RID: 771
	[Serializable]
	internal class IDRole
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06002718 RID: 10008 RVA: 0x0008D43C File Offset: 0x0008B63C
		internal SecurityIdentifier Sid
		{
			[SecurityCritical]
			get
			{
				if (string.IsNullOrEmpty(this.m_role))
				{
					return null;
				}
				if (this.m_sid == null)
				{
					NTAccount identity = new NTAccount(this.m_role);
					IdentityReferenceCollection identityReferenceCollection = NTAccount.Translate(new IdentityReferenceCollection(1)
					{
						identity
					}, typeof(SecurityIdentifier), false);
					this.m_sid = (identityReferenceCollection[0] as SecurityIdentifier);
				}
				return this.m_sid;
			}
		}

		// Token: 0x06002719 RID: 10009 RVA: 0x0008D4AC File Offset: 0x0008B6AC
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("Identity");
			if (this.m_authenticated)
			{
				securityElement.AddAttribute("Authenticated", "true");
			}
			if (this.m_id != null)
			{
				securityElement.AddAttribute("ID", SecurityElement.Escape(this.m_id));
			}
			if (this.m_role != null)
			{
				securityElement.AddAttribute("Role", SecurityElement.Escape(this.m_role));
			}
			return securityElement;
		}

		// Token: 0x0600271A RID: 10010 RVA: 0x0008D51C File Offset: 0x0008B71C
		internal void FromXml(SecurityElement e)
		{
			string text = e.Attribute("Authenticated");
			if (text != null)
			{
				this.m_authenticated = (string.Compare(text, "true", StringComparison.OrdinalIgnoreCase) == 0);
			}
			else
			{
				this.m_authenticated = false;
			}
			string text2 = e.Attribute("ID");
			if (text2 != null)
			{
				this.m_id = text2;
			}
			else
			{
				this.m_id = null;
			}
			string text3 = e.Attribute("Role");
			if (text3 != null)
			{
				this.m_role = text3;
				return;
			}
			this.m_role = null;
		}

		// Token: 0x0600271B RID: 10011 RVA: 0x0008D593 File Offset: 0x0008B793
		public override int GetHashCode()
		{
			return (this.m_authenticated ? 0 : 101) + ((this.m_id == null) ? 0 : this.m_id.GetHashCode()) + ((this.m_role == null) ? 0 : this.m_role.GetHashCode());
		}

		// Token: 0x04000F17 RID: 3863
		internal bool m_authenticated;

		// Token: 0x04000F18 RID: 3864
		internal string m_id;

		// Token: 0x04000F19 RID: 3865
		internal string m_role;

		// Token: 0x04000F1A RID: 3866
		[NonSerialized]
		private SecurityIdentifier m_sid;
	}
}
