using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000369 RID: 873
	[ComVisible(true)]
	[Serializable]
	public sealed class Site : EvidenceBase, IIdentityPermissionFactory
	{
		// Token: 0x06002B2E RID: 11054 RVA: 0x000A122F File Offset: 0x0009F42F
		public Site(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_name = new SiteString(name);
		}

		// Token: 0x06002B2F RID: 11055 RVA: 0x000A1251 File Offset: 0x0009F451
		private Site(SiteString name)
		{
			this.m_name = name;
		}

		// Token: 0x06002B30 RID: 11056 RVA: 0x000A1260 File Offset: 0x0009F460
		public static Site CreateFromUrl(string url)
		{
			return new Site(Site.ParseSiteFromUrl(url));
		}

		// Token: 0x06002B31 RID: 11057 RVA: 0x000A1270 File Offset: 0x0009F470
		private static SiteString ParseSiteFromUrl(string name)
		{
			URLString urlstring = new URLString(name);
			if (string.Compare(urlstring.Scheme, "file", StringComparison.OrdinalIgnoreCase) == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
			}
			return new SiteString(new URLString(name).Host);
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06002B32 RID: 11058 RVA: 0x000A12B7 File Offset: 0x0009F4B7
		public string Name
		{
			get
			{
				return this.m_name.ToString();
			}
		}

		// Token: 0x06002B33 RID: 11059 RVA: 0x000A12C4 File Offset: 0x0009F4C4
		internal SiteString GetSiteString()
		{
			return this.m_name;
		}

		// Token: 0x06002B34 RID: 11060 RVA: 0x000A12CC File Offset: 0x0009F4CC
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new SiteIdentityPermission(this.Name);
		}

		// Token: 0x06002B35 RID: 11061 RVA: 0x000A12DC File Offset: 0x0009F4DC
		public override bool Equals(object o)
		{
			Site site = o as Site;
			return site != null && string.Equals(this.Name, site.Name, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x06002B36 RID: 11062 RVA: 0x000A1307 File Offset: 0x0009F507
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		// Token: 0x06002B37 RID: 11063 RVA: 0x000A1314 File Offset: 0x0009F514
		public override EvidenceBase Clone()
		{
			return new Site(this.m_name);
		}

		// Token: 0x06002B38 RID: 11064 RVA: 0x000A1321 File Offset: 0x0009F521
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002B39 RID: 11065 RVA: 0x000A132C File Offset: 0x0009F52C
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Site");
			securityElement.AddAttribute("version", "1");
			if (this.m_name != null)
			{
				securityElement.AddChild(new SecurityElement("Name", this.m_name.ToString()));
			}
			return securityElement;
		}

		// Token: 0x06002B3A RID: 11066 RVA: 0x000A1378 File Offset: 0x0009F578
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002B3B RID: 11067 RVA: 0x000A1385 File Offset: 0x0009F585
		internal object Normalize()
		{
			return this.m_name.ToString().ToUpper(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001191 RID: 4497
		private SiteString m_name;
	}
}
