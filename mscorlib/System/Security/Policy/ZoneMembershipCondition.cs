using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000371 RID: 881
	[ComVisible(true)]
	[Serializable]
	public sealed class ZoneMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002BA7 RID: 11175 RVA: 0x000A2AEF File Offset: 0x000A0CEF
		internal ZoneMembershipCondition()
		{
			this.m_zone = SecurityZone.NoZone;
		}

		// Token: 0x06002BA8 RID: 11176 RVA: 0x000A2AFE File Offset: 0x000A0CFE
		public ZoneMembershipCondition(SecurityZone zone)
		{
			ZoneMembershipCondition.VerifyZone(zone);
			this.SecurityZone = zone;
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06002BAA RID: 11178 RVA: 0x000A2B22 File Offset: 0x000A0D22
		// (set) Token: 0x06002BA9 RID: 11177 RVA: 0x000A2B13 File Offset: 0x000A0D13
		public SecurityZone SecurityZone
		{
			get
			{
				if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
				{
					this.ParseZone();
				}
				return this.m_zone;
			}
			set
			{
				ZoneMembershipCondition.VerifyZone(value);
				this.m_zone = value;
			}
		}

		// Token: 0x06002BAB RID: 11179 RVA: 0x000A2B41 File Offset: 0x000A0D41
		private static void VerifyZone(SecurityZone zone)
		{
			if (zone < SecurityZone.MyComputer || zone > SecurityZone.Untrusted)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalZone"));
			}
		}

		// Token: 0x06002BAC RID: 11180 RVA: 0x000A2B5C File Offset: 0x000A0D5C
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002BAD RID: 11181 RVA: 0x000A2B74 File Offset: 0x000A0D74
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Zone hostEvidence = evidence.GetHostEvidence<Zone>();
			if (hostEvidence != null)
			{
				if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
				{
					this.ParseZone();
				}
				if (hostEvidence.SecurityZone == this.m_zone)
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x000A2BBE File Offset: 0x000A0DBE
		public IMembershipCondition Copy()
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			return new ZoneMembershipCondition(this.m_zone);
		}

		// Token: 0x06002BAF RID: 11183 RVA: 0x000A2BE2 File Offset: 0x000A0DE2
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002BB0 RID: 11184 RVA: 0x000A2BEB File Offset: 0x000A0DEB
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002BB1 RID: 11185 RVA: 0x000A2BF8 File Offset: 0x000A0DF8
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.ZoneMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_zone != SecurityZone.NoZone)
			{
				securityElement.AddAttribute("Zone", Enum.GetName(typeof(SecurityZone), this.m_zone));
			}
			return securityElement;
		}

		// Token: 0x06002BB2 RID: 11186 RVA: 0x000A2C78 File Offset: 0x000A0E78
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
				this.m_zone = SecurityZone.NoZone;
				this.m_element = e;
			}
		}

		// Token: 0x06002BB3 RID: 11187 RVA: 0x000A2CEC File Offset: 0x000A0EEC
		private void ParseZone()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Zone");
					this.m_zone = SecurityZone.NoZone;
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_ZoneCannotBeNull"));
					}
					this.m_zone = (SecurityZone)Enum.Parse(typeof(SecurityZone), text);
					ZoneMembershipCondition.VerifyZone(this.m_zone);
					this.m_element = null;
				}
			}
		}

		// Token: 0x06002BB4 RID: 11188 RVA: 0x000A2D88 File Offset: 0x000A0F88
		public override bool Equals(object o)
		{
			ZoneMembershipCondition zoneMembershipCondition = o as ZoneMembershipCondition;
			if (zoneMembershipCondition != null)
			{
				if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
				{
					this.ParseZone();
				}
				if (zoneMembershipCondition.m_zone == SecurityZone.NoZone && zoneMembershipCondition.m_element != null)
				{
					zoneMembershipCondition.ParseZone();
				}
				if (this.m_zone == zoneMembershipCondition.m_zone)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002BB5 RID: 11189 RVA: 0x000A2DDE File Offset: 0x000A0FDE
		public override int GetHashCode()
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			return (int)this.m_zone;
		}

		// Token: 0x06002BB6 RID: 11190 RVA: 0x000A2DFD File Offset: 0x000A0FFD
		public override string ToString()
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Zone_ToString"), ZoneMembershipCondition.s_names[(int)this.m_zone]);
		}

		// Token: 0x040011A6 RID: 4518
		private static readonly string[] s_names = new string[]
		{
			"MyComputer",
			"Intranet",
			"Trusted",
			"Internet",
			"Untrusted"
		};

		// Token: 0x040011A7 RID: 4519
		private SecurityZone m_zone;

		// Token: 0x040011A8 RID: 4520
		private SecurityElement m_element;
	}
}
