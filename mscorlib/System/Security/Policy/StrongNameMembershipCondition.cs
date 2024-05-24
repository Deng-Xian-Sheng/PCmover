using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x0200036C RID: 876
	[ComVisible(true)]
	[Serializable]
	public sealed class StrongNameMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002B5E RID: 11102 RVA: 0x000A1AE9 File Offset: 0x0009FCE9
		internal StrongNameMembershipCondition()
		{
		}

		// Token: 0x06002B5F RID: 11103 RVA: 0x000A1AF4 File Offset: 0x0009FCF4
		public StrongNameMembershipCondition(StrongNamePublicKeyBlob blob, string name, Version version)
		{
			if (blob == null)
			{
				throw new ArgumentNullException("blob");
			}
			if (name != null && name.Equals(""))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyStrongName"));
			}
			this.m_publicKeyBlob = blob;
			this.m_name = name;
			this.m_version = version;
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06002B61 RID: 11105 RVA: 0x000A1B61 File Offset: 0x0009FD61
		// (set) Token: 0x06002B60 RID: 11104 RVA: 0x000A1B4A File Offset: 0x0009FD4A
		public StrongNamePublicKeyBlob PublicKey
		{
			get
			{
				if (this.m_publicKeyBlob == null && this.m_element != null)
				{
					this.ParseKeyBlob();
				}
				return this.m_publicKeyBlob;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PublicKey");
				}
				this.m_publicKeyBlob = value;
			}
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06002B63 RID: 11107 RVA: 0x000A1BE4 File Offset: 0x0009FDE4
		// (set) Token: 0x06002B62 RID: 11106 RVA: 0x000A1B80 File Offset: 0x0009FD80
		public string Name
		{
			get
			{
				if (this.m_name == null && this.m_element != null)
				{
					this.ParseName();
				}
				return this.m_name;
			}
			set
			{
				if (value == null)
				{
					if (this.m_publicKeyBlob == null && this.m_element != null)
					{
						this.ParseKeyBlob();
					}
					if (this.m_version == null && this.m_element != null)
					{
						this.ParseVersion();
					}
					this.m_element = null;
				}
				else if (value.Length == 0)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"));
				}
				this.m_name = value;
			}
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06002B65 RID: 11109 RVA: 0x000A1C54 File Offset: 0x0009FE54
		// (set) Token: 0x06002B64 RID: 11108 RVA: 0x000A1C04 File Offset: 0x0009FE04
		public Version Version
		{
			get
			{
				if (this.m_version == null && this.m_element != null)
				{
					this.ParseVersion();
				}
				return this.m_version;
			}
			set
			{
				if (value == null)
				{
					if (this.m_name == null && this.m_element != null)
					{
						this.ParseName();
					}
					if (this.m_publicKeyBlob == null && this.m_element != null)
					{
						this.ParseKeyBlob();
					}
					this.m_element = null;
				}
				this.m_version = value;
			}
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x000A1C74 File Offset: 0x0009FE74
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002B67 RID: 11111 RVA: 0x000A1C8C File Offset: 0x0009FE8C
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			StrongName delayEvaluatedHostEvidence = evidence.GetDelayEvaluatedHostEvidence<StrongName>();
			if (delayEvaluatedHostEvidence != null)
			{
				bool flag = this.PublicKey != null && this.PublicKey.Equals(delayEvaluatedHostEvidence.PublicKey);
				bool flag2 = this.Name == null || (delayEvaluatedHostEvidence.Name != null && StrongName.CompareNames(delayEvaluatedHostEvidence.Name, this.Name));
				bool flag3 = this.Version == null || (delayEvaluatedHostEvidence.Version != null && delayEvaluatedHostEvidence.Version.CompareTo(this.Version) == 0);
				if (flag && flag2 && flag3)
				{
					usedEvidence = delayEvaluatedHostEvidence;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002B68 RID: 11112 RVA: 0x000A1D28 File Offset: 0x0009FF28
		public IMembershipCondition Copy()
		{
			return new StrongNameMembershipCondition(this.PublicKey, this.Name, this.Version);
		}

		// Token: 0x06002B69 RID: 11113 RVA: 0x000A1D41 File Offset: 0x0009FF41
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002B6A RID: 11114 RVA: 0x000A1D4A File Offset: 0x0009FF4A
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002B6B RID: 11115 RVA: 0x000A1D54 File Offset: 0x0009FF54
		public SecurityElement ToXml(PolicyLevel level)
		{
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.StrongNameMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.PublicKey != null)
			{
				securityElement.AddAttribute("PublicKeyBlob", Hex.EncodeHexString(this.PublicKey.PublicKey));
			}
			if (this.Name != null)
			{
				securityElement.AddAttribute("Name", this.Name);
			}
			if (this.Version != null)
			{
				securityElement.AddAttribute("AssemblyVersion", this.Version.ToString());
			}
			return securityElement;
		}

		// Token: 0x06002B6C RID: 11116 RVA: 0x000A1DE8 File Offset: 0x0009FFE8
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
				this.m_name = null;
				this.m_publicKeyBlob = null;
				this.m_version = null;
				this.m_element = e;
			}
		}

		// Token: 0x06002B6D RID: 11117 RVA: 0x000A1E6C File Offset: 0x000A006C
		private void ParseName()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Name");
					this.m_name = ((text == null) ? null : text);
					if (this.m_version != null && this.m_name != null && this.m_publicKeyBlob != null)
					{
						this.m_element = null;
					}
				}
			}
		}

		// Token: 0x06002B6E RID: 11118 RVA: 0x000A1EE8 File Offset: 0x000A00E8
		private void ParseKeyBlob()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("PublicKeyBlob");
					StrongNamePublicKeyBlob strongNamePublicKeyBlob = new StrongNamePublicKeyBlob();
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_BlobCannotBeNull"));
					}
					strongNamePublicKeyBlob.PublicKey = Hex.DecodeHexString(text);
					this.m_publicKeyBlob = strongNamePublicKeyBlob;
					if (this.m_version != null && this.m_name != null && this.m_publicKeyBlob != null)
					{
						this.m_element = null;
					}
				}
			}
		}

		// Token: 0x06002B6F RID: 11119 RVA: 0x000A1F88 File Offset: 0x000A0188
		private void ParseVersion()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("AssemblyVersion");
					this.m_version = ((text == null) ? null : new Version(text));
					if (this.m_version != null && this.m_name != null && this.m_publicKeyBlob != null)
					{
						this.m_element = null;
					}
				}
			}
		}

		// Token: 0x06002B70 RID: 11120 RVA: 0x000A200C File Offset: 0x000A020C
		public override string ToString()
		{
			string arg = "";
			string arg2 = "";
			if (this.Name != null)
			{
				arg = " " + string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("StrongName_Name"), this.Name);
			}
			if (this.Version != null)
			{
				arg2 = " " + string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("StrongName_Version"), this.Version);
			}
			return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("StrongName_ToString"), Hex.EncodeHexString(this.PublicKey.PublicKey), arg, arg2);
		}

		// Token: 0x06002B71 RID: 11121 RVA: 0x000A20A8 File Offset: 0x000A02A8
		public override bool Equals(object o)
		{
			StrongNameMembershipCondition strongNameMembershipCondition = o as StrongNameMembershipCondition;
			if (strongNameMembershipCondition != null)
			{
				if (this.m_publicKeyBlob == null && this.m_element != null)
				{
					this.ParseKeyBlob();
				}
				if (strongNameMembershipCondition.m_publicKeyBlob == null && strongNameMembershipCondition.m_element != null)
				{
					strongNameMembershipCondition.ParseKeyBlob();
				}
				if (object.Equals(this.m_publicKeyBlob, strongNameMembershipCondition.m_publicKeyBlob))
				{
					if (this.m_name == null && this.m_element != null)
					{
						this.ParseName();
					}
					if (strongNameMembershipCondition.m_name == null && strongNameMembershipCondition.m_element != null)
					{
						strongNameMembershipCondition.ParseName();
					}
					if (object.Equals(this.m_name, strongNameMembershipCondition.m_name))
					{
						if (this.m_version == null && this.m_element != null)
						{
							this.ParseVersion();
						}
						if (strongNameMembershipCondition.m_version == null && strongNameMembershipCondition.m_element != null)
						{
							strongNameMembershipCondition.ParseVersion();
						}
						if (object.Equals(this.m_version, strongNameMembershipCondition.m_version))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06002B72 RID: 11122 RVA: 0x000A2194 File Offset: 0x000A0394
		public override int GetHashCode()
		{
			if (this.m_publicKeyBlob == null && this.m_element != null)
			{
				this.ParseKeyBlob();
			}
			if (this.m_publicKeyBlob != null)
			{
				return this.m_publicKeyBlob.GetHashCode();
			}
			if (this.m_name == null && this.m_element != null)
			{
				this.ParseName();
			}
			if (this.m_version == null && this.m_element != null)
			{
				this.ParseVersion();
			}
			if (this.m_name != null || this.m_version != null)
			{
				return ((this.m_name == null) ? 0 : this.m_name.GetHashCode()) + ((this.m_version == null) ? 0 : this.m_version.GetHashCode());
			}
			return typeof(StrongNameMembershipCondition).GetHashCode();
		}

		// Token: 0x04001199 RID: 4505
		private StrongNamePublicKeyBlob m_publicKeyBlob;

		// Token: 0x0400119A RID: 4506
		private string m_name;

		// Token: 0x0400119B RID: 4507
		private Version m_version;

		// Token: 0x0400119C RID: 4508
		private SecurityElement m_element;

		// Token: 0x0400119D RID: 4509
		private const string s_tagName = "Name";

		// Token: 0x0400119E RID: 4510
		private const string s_tagVersion = "AssemblyVersion";

		// Token: 0x0400119F RID: 4511
		private const string s_tagPublicKeyBlob = "PublicKeyBlob";
	}
}
