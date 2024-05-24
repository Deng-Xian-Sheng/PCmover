using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x0200036A RID: 874
	[ComVisible(true)]
	[Serializable]
	public sealed class SiteMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002B3C RID: 11068 RVA: 0x000A139C File Offset: 0x0009F59C
		internal SiteMembershipCondition()
		{
			this.m_site = null;
		}

		// Token: 0x06002B3D RID: 11069 RVA: 0x000A13AB File Offset: 0x0009F5AB
		public SiteMembershipCondition(string site)
		{
			if (site == null)
			{
				throw new ArgumentNullException("site");
			}
			this.m_site = new SiteString(site);
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06002B3F RID: 11071 RVA: 0x000A13E9 File Offset: 0x0009F5E9
		// (set) Token: 0x06002B3E RID: 11070 RVA: 0x000A13CD File Offset: 0x0009F5CD
		public string Site
		{
			get
			{
				if (this.m_site == null && this.m_element != null)
				{
					this.ParseSite();
				}
				if (this.m_site != null)
				{
					return this.m_site.ToString();
				}
				return "";
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.m_site = new SiteString(value);
			}
		}

		// Token: 0x06002B40 RID: 11072 RVA: 0x000A141C File Offset: 0x0009F61C
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002B41 RID: 11073 RVA: 0x000A1434 File Offset: 0x0009F634
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Site hostEvidence = evidence.GetHostEvidence<Site>();
			if (hostEvidence != null)
			{
				if (this.m_site == null && this.m_element != null)
				{
					this.ParseSite();
				}
				if (hostEvidence.GetSiteString().IsSubsetOf(this.m_site))
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002B42 RID: 11074 RVA: 0x000A1482 File Offset: 0x0009F682
		public IMembershipCondition Copy()
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			return new SiteMembershipCondition(this.m_site.ToString());
		}

		// Token: 0x06002B43 RID: 11075 RVA: 0x000A14AA File Offset: 0x0009F6AA
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002B44 RID: 11076 RVA: 0x000A14B3 File Offset: 0x0009F6B3
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002B45 RID: 11077 RVA: 0x000A14C0 File Offset: 0x0009F6C0
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.SiteMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_site != null)
			{
				securityElement.AddAttribute("Site", this.m_site.ToString());
			}
			return securityElement;
		}

		// Token: 0x06002B46 RID: 11078 RVA: 0x000A1530 File Offset: 0x0009F730
		public void FromXml(SecurityElement e, PolicyLevel level)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (!e.Tag.Equals("IMembershipCondition"))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MembershipConditionElement"));
			}
			lock (this)
			{
				this.m_site = null;
				this.m_element = e;
			}
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x000A15A4 File Offset: 0x0009F7A4
		private void ParseSite()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Site");
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_SiteCannotBeNull"));
					}
					this.m_site = new SiteString(text);
					this.m_element = null;
				}
			}
		}

		// Token: 0x06002B48 RID: 11080 RVA: 0x000A161C File Offset: 0x0009F81C
		public override bool Equals(object o)
		{
			SiteMembershipCondition siteMembershipCondition = o as SiteMembershipCondition;
			if (siteMembershipCondition != null)
			{
				if (this.m_site == null && this.m_element != null)
				{
					this.ParseSite();
				}
				if (siteMembershipCondition.m_site == null && siteMembershipCondition.m_element != null)
				{
					siteMembershipCondition.ParseSite();
				}
				if (object.Equals(this.m_site, siteMembershipCondition.m_site))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002B49 RID: 11081 RVA: 0x000A1675 File Offset: 0x0009F875
		public override int GetHashCode()
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			if (this.m_site != null)
			{
				return this.m_site.GetHashCode();
			}
			return typeof(SiteMembershipCondition).GetHashCode();
		}

		// Token: 0x06002B4A RID: 11082 RVA: 0x000A16B0 File Offset: 0x0009F8B0
		public override string ToString()
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			if (this.m_site != null)
			{
				return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Site_ToStringArg"), this.m_site);
			}
			return Environment.GetResourceString("Site_ToString");
		}

		// Token: 0x04001192 RID: 4498
		private SiteString m_site;

		// Token: 0x04001193 RID: 4499
		private SecurityElement m_element;
	}
}
