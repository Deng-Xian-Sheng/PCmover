using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x0200036E RID: 878
	[ComVisible(true)]
	[Serializable]
	public sealed class Url : EvidenceBase, IIdentityPermissionFactory
	{
		// Token: 0x06002B7C RID: 11132 RVA: 0x000A242E File Offset: 0x000A062E
		internal Url(string name, bool parsed)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_url = new URLString(name, parsed);
		}

		// Token: 0x06002B7D RID: 11133 RVA: 0x000A2451 File Offset: 0x000A0651
		public Url(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_url = new URLString(name);
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x000A2473 File Offset: 0x000A0673
		private Url(Url url)
		{
			this.m_url = url.m_url;
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06002B7F RID: 11135 RVA: 0x000A2487 File Offset: 0x000A0687
		public string Value
		{
			get
			{
				return this.m_url.ToString();
			}
		}

		// Token: 0x06002B80 RID: 11136 RVA: 0x000A2494 File Offset: 0x000A0694
		internal URLString GetURLString()
		{
			return this.m_url;
		}

		// Token: 0x06002B81 RID: 11137 RVA: 0x000A249C File Offset: 0x000A069C
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new UrlIdentityPermission(this.m_url);
		}

		// Token: 0x06002B82 RID: 11138 RVA: 0x000A24AC File Offset: 0x000A06AC
		public override bool Equals(object o)
		{
			Url url = o as Url;
			return url != null && url.m_url.Equals(this.m_url);
		}

		// Token: 0x06002B83 RID: 11139 RVA: 0x000A24D6 File Offset: 0x000A06D6
		public override int GetHashCode()
		{
			return this.m_url.GetHashCode();
		}

		// Token: 0x06002B84 RID: 11140 RVA: 0x000A24E3 File Offset: 0x000A06E3
		public override EvidenceBase Clone()
		{
			return new Url(this);
		}

		// Token: 0x06002B85 RID: 11141 RVA: 0x000A24EB File Offset: 0x000A06EB
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002B86 RID: 11142 RVA: 0x000A24F4 File Offset: 0x000A06F4
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Url");
			securityElement.AddAttribute("version", "1");
			if (this.m_url != null)
			{
				securityElement.AddChild(new SecurityElement("Url", this.m_url.ToString()));
			}
			return securityElement;
		}

		// Token: 0x06002B87 RID: 11143 RVA: 0x000A2540 File Offset: 0x000A0740
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002B88 RID: 11144 RVA: 0x000A254D File Offset: 0x000A074D
		internal object Normalize()
		{
			return this.m_url.NormalizeUrl();
		}

		// Token: 0x040011A0 RID: 4512
		private URLString m_url;
	}
}
