using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x0200036F RID: 879
	[ComVisible(true)]
	[Serializable]
	public sealed class UrlMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002B89 RID: 11145 RVA: 0x000A255A File Offset: 0x000A075A
		internal UrlMembershipCondition()
		{
			this.m_url = null;
		}

		// Token: 0x06002B8A RID: 11146 RVA: 0x000A256C File Offset: 0x000A076C
		public UrlMembershipCondition(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			this.m_url = new URLString(url, false, true);
			if (this.m_url.IsRelativeFileUrl)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_RelativeUrlMembershipCondition"), "url");
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06002B8C RID: 11148 RVA: 0x000A2606 File Offset: 0x000A0806
		// (set) Token: 0x06002B8B RID: 11147 RVA: 0x000A25C0 File Offset: 0x000A07C0
		public string Url
		{
			get
			{
				if (this.m_url == null && this.m_element != null)
				{
					this.ParseURL();
				}
				return this.m_url.ToString();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				URLString urlstring = new URLString(value);
				if (urlstring.IsRelativeFileUrl)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_RelativeUrlMembershipCondition"), "value");
				}
				this.m_url = urlstring;
			}
		}

		// Token: 0x06002B8D RID: 11149 RVA: 0x000A262C File Offset: 0x000A082C
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002B8E RID: 11150 RVA: 0x000A2644 File Offset: 0x000A0844
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Url hostEvidence = evidence.GetHostEvidence<Url>();
			if (hostEvidence != null)
			{
				if (this.m_url == null && this.m_element != null)
				{
					this.ParseURL();
				}
				if (hostEvidence.GetURLString().IsSubsetOf(this.m_url))
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002B8F RID: 11151 RVA: 0x000A2694 File Offset: 0x000A0894
		public IMembershipCondition Copy()
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			return new UrlMembershipCondition
			{
				m_url = new URLString(this.m_url.ToString())
			};
		}

		// Token: 0x06002B90 RID: 11152 RVA: 0x000A26D4 File Offset: 0x000A08D4
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002B91 RID: 11153 RVA: 0x000A26DD File Offset: 0x000A08DD
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002B92 RID: 11154 RVA: 0x000A26E8 File Offset: 0x000A08E8
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.UrlMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_url != null)
			{
				securityElement.AddAttribute("Url", this.m_url.ToString());
			}
			return securityElement;
		}

		// Token: 0x06002B93 RID: 11155 RVA: 0x000A2758 File Offset: 0x000A0958
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
				this.m_element = e;
				this.m_url = null;
			}
		}

		// Token: 0x06002B94 RID: 11156 RVA: 0x000A27CC File Offset: 0x000A09CC
		private void ParseURL()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Url");
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_UrlCannotBeNull"));
					}
					URLString urlstring = new URLString(text);
					if (urlstring.IsRelativeFileUrl)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_RelativeUrlMembershipCondition"));
					}
					this.m_url = urlstring;
					this.m_element = null;
				}
			}
		}

		// Token: 0x06002B95 RID: 11157 RVA: 0x000A285C File Offset: 0x000A0A5C
		public override bool Equals(object o)
		{
			UrlMembershipCondition urlMembershipCondition = o as UrlMembershipCondition;
			if (urlMembershipCondition != null)
			{
				if (this.m_url == null && this.m_element != null)
				{
					this.ParseURL();
				}
				if (urlMembershipCondition.m_url == null && urlMembershipCondition.m_element != null)
				{
					urlMembershipCondition.ParseURL();
				}
				if (object.Equals(this.m_url, urlMembershipCondition.m_url))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002B96 RID: 11158 RVA: 0x000A28B5 File Offset: 0x000A0AB5
		public override int GetHashCode()
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			if (this.m_url != null)
			{
				return this.m_url.GetHashCode();
			}
			return typeof(UrlMembershipCondition).GetHashCode();
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x000A28F0 File Offset: 0x000A0AF0
		public override string ToString()
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			if (this.m_url != null)
			{
				return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Url_ToStringArg"), this.m_url.ToString());
			}
			return Environment.GetResourceString("Url_ToString");
		}

		// Token: 0x040011A1 RID: 4513
		private URLString m_url;

		// Token: 0x040011A2 RID: 4514
		private SecurityElement m_element;
	}
}
