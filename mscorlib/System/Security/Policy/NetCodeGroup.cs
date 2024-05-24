using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace System.Security.Policy
{
	// Token: 0x0200035E RID: 862
	[ComVisible(true)]
	[Serializable]
	public sealed class NetCodeGroup : CodeGroup, IUnionSemanticCodeGroup
	{
		// Token: 0x06002A98 RID: 10904 RVA: 0x0009D571 File Offset: 0x0009B771
		[SecurityCritical]
		[Conditional("_DEBUG")]
		private static void DEBUG_OUT(string str)
		{
		}

		// Token: 0x06002A99 RID: 10905 RVA: 0x0009D573 File Offset: 0x0009B773
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
			this.m_schemesList = null;
			this.m_accessList = null;
		}

		// Token: 0x06002A9A RID: 10906 RVA: 0x0009D583 File Offset: 0x0009B783
		internal NetCodeGroup()
		{
			this.SetDefaults();
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x0009D591 File Offset: 0x0009B791
		public NetCodeGroup(IMembershipCondition membershipCondition) : base(membershipCondition, null)
		{
			this.SetDefaults();
		}

		// Token: 0x06002A9C RID: 10908 RVA: 0x0009D5A1 File Offset: 0x0009B7A1
		public void ResetConnectAccess()
		{
			this.m_schemesList = null;
			this.m_accessList = null;
		}

		// Token: 0x06002A9D RID: 10909 RVA: 0x0009D5B4 File Offset: 0x0009B7B4
		public void AddConnectAccess(string originScheme, CodeConnectAccess connectAccess)
		{
			if (originScheme == null)
			{
				throw new ArgumentNullException("originScheme");
			}
			if (originScheme != NetCodeGroup.AbsentOriginScheme && originScheme != NetCodeGroup.AnyOtherOriginScheme && !CodeConnectAccess.IsValidScheme(originScheme))
			{
				throw new ArgumentOutOfRangeException("originScheme");
			}
			if (originScheme == NetCodeGroup.AbsentOriginScheme && connectAccess.IsOriginScheme)
			{
				throw new ArgumentOutOfRangeException("connectAccess");
			}
			if (this.m_schemesList == null)
			{
				this.m_schemesList = new ArrayList();
				this.m_accessList = new ArrayList();
			}
			originScheme = originScheme.ToLower(CultureInfo.InvariantCulture);
			int i = 0;
			while (i < this.m_schemesList.Count)
			{
				if ((string)this.m_schemesList[i] == originScheme)
				{
					if (connectAccess == null)
					{
						return;
					}
					ArrayList arrayList = (ArrayList)this.m_accessList[i];
					for (i = 0; i < arrayList.Count; i++)
					{
						if (((CodeConnectAccess)arrayList[i]).Equals(connectAccess))
						{
							return;
						}
					}
					arrayList.Add(connectAccess);
					return;
				}
				else
				{
					i++;
				}
			}
			this.m_schemesList.Add(originScheme);
			ArrayList arrayList2 = new ArrayList();
			this.m_accessList.Add(arrayList2);
			if (connectAccess != null)
			{
				arrayList2.Add(connectAccess);
			}
		}

		// Token: 0x06002A9E RID: 10910 RVA: 0x0009D6E8 File Offset: 0x0009B8E8
		public DictionaryEntry[] GetConnectAccessRules()
		{
			if (this.m_schemesList == null)
			{
				return null;
			}
			DictionaryEntry[] array = new DictionaryEntry[this.m_schemesList.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Key = this.m_schemesList[i];
				array[i].Value = ((ArrayList)this.m_accessList[i]).ToArray(typeof(CodeConnectAccess));
			}
			return array;
		}

		// Token: 0x06002A9F RID: 10911 RVA: 0x0009D764 File Offset: 0x0009B964
		[SecuritySafeCritical]
		public override PolicyStatement Resolve(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			object obj = null;
			if (PolicyManager.CheckMembershipCondition(base.MembershipCondition, evidence, out obj))
			{
				PolicyStatement policyStatement = this.CalculateAssemblyPolicy(evidence);
				IDelayEvaluatedEvidence delayEvaluatedEvidence = obj as IDelayEvaluatedEvidence;
				bool flag = delayEvaluatedEvidence != null && !delayEvaluatedEvidence.IsVerified;
				if (flag)
				{
					policyStatement.AddDependentEvidence(delayEvaluatedEvidence);
				}
				bool flag2 = false;
				IEnumerator enumerator = base.Children.GetEnumerator();
				while (enumerator.MoveNext() && !flag2)
				{
					PolicyStatement policyStatement2 = PolicyManager.ResolveCodeGroup(enumerator.Current as CodeGroup, evidence);
					if (policyStatement2 != null)
					{
						policyStatement.InplaceUnion(policyStatement2);
						if ((policyStatement2.Attributes & PolicyStatementAttribute.Exclusive) == PolicyStatementAttribute.Exclusive)
						{
							flag2 = true;
						}
					}
				}
				return policyStatement;
			}
			return null;
		}

		// Token: 0x06002AA0 RID: 10912 RVA: 0x0009D80B File Offset: 0x0009BA0B
		PolicyStatement IUnionSemanticCodeGroup.InternalResolve(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			if (base.MembershipCondition.Check(evidence))
			{
				return this.CalculateAssemblyPolicy(evidence);
			}
			return null;
		}

		// Token: 0x06002AA1 RID: 10913 RVA: 0x0009D834 File Offset: 0x0009BA34
		public override CodeGroup ResolveMatchingCodeGroups(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			if (base.MembershipCondition.Check(evidence))
			{
				CodeGroup codeGroup = this.Copy();
				codeGroup.Children = new ArrayList();
				foreach (object obj in base.Children)
				{
					CodeGroup codeGroup2 = ((CodeGroup)obj).ResolveMatchingCodeGroups(evidence);
					if (codeGroup2 != null)
					{
						codeGroup.AddChild(codeGroup2);
					}
				}
				return codeGroup;
			}
			return null;
		}

		// Token: 0x06002AA2 RID: 10914 RVA: 0x0009D8A4 File Offset: 0x0009BAA4
		private string EscapeStringForRegex(string str)
		{
			int num = 0;
			StringBuilder stringBuilder = null;
			int num2;
			while (num < str.Length && (num2 = str.IndexOfAny(NetCodeGroup.c_SomeRegexChars, num)) != -1)
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(str.Length * 2);
				}
				stringBuilder.Append(str, num, num2 - num).Append('\\').Append(str[num2]);
				num = num2 + 1;
			}
			if (stringBuilder == null)
			{
				return str;
			}
			if (num < str.Length)
			{
				stringBuilder.Append(str, num, str.Length - num);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06002AA3 RID: 10915 RVA: 0x0009D92C File Offset: 0x0009BB2C
		internal SecurityElement CreateWebPermission(string host, string scheme, string port, string assemblyOverride)
		{
			if (scheme == null)
			{
				scheme = string.Empty;
			}
			if (host == null || host.Length == 0)
			{
				return null;
			}
			host = host.ToLower(CultureInfo.InvariantCulture);
			scheme = scheme.ToLower(CultureInfo.InvariantCulture);
			int intPort = -1;
			if (port != null && port.Length != 0)
			{
				intPort = int.Parse(port, CultureInfo.InvariantCulture);
			}
			else
			{
				port = string.Empty;
			}
			CodeConnectAccess[] array = this.FindAccessRulesForScheme(scheme);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			SecurityElement securityElement = new SecurityElement("IPermission");
			string str = (assemblyOverride == null) ? "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" : assemblyOverride;
			securityElement.AddAttribute("class", "System.Net.WebPermission, " + str);
			securityElement.AddAttribute("version", "1");
			SecurityElement securityElement2 = new SecurityElement("ConnectAccess");
			host = this.EscapeStringForRegex(host);
			scheme = this.EscapeStringForRegex(scheme);
			string text = this.TryPermissionAsOneString(array, scheme, host, intPort);
			if (text != null)
			{
				SecurityElement securityElement3 = new SecurityElement("URI");
				securityElement3.AddAttribute("uri", text);
				securityElement2.AddChild(securityElement3);
			}
			else
			{
				if (port.Length != 0)
				{
					port = ":" + port;
				}
				for (int i = 0; i < array.Length; i++)
				{
					text = this.GetPermissionAccessElementString(array[i], scheme, host, port);
					SecurityElement securityElement4 = new SecurityElement("URI");
					securityElement4.AddAttribute("uri", text);
					securityElement2.AddChild(securityElement4);
				}
			}
			securityElement.AddChild(securityElement2);
			return securityElement;
		}

		// Token: 0x06002AA4 RID: 10916 RVA: 0x0009DA94 File Offset: 0x0009BC94
		private CodeConnectAccess[] FindAccessRulesForScheme(string lowerCaseScheme)
		{
			if (this.m_schemesList == null)
			{
				return null;
			}
			int num = this.m_schemesList.IndexOf(lowerCaseScheme);
			if (num == -1 && (lowerCaseScheme == NetCodeGroup.AbsentOriginScheme || (num = this.m_schemesList.IndexOf(NetCodeGroup.AnyOtherOriginScheme)) == -1))
			{
				return null;
			}
			ArrayList arrayList = (ArrayList)this.m_accessList[num];
			return (CodeConnectAccess[])arrayList.ToArray(typeof(CodeConnectAccess));
		}

		// Token: 0x06002AA5 RID: 10917 RVA: 0x0009DB08 File Offset: 0x0009BD08
		private string TryPermissionAsOneString(CodeConnectAccess[] access, string escapedScheme, string escapedHost, int intPort)
		{
			bool flag = true;
			bool flag2 = true;
			bool flag3 = false;
			int num = -2;
			for (int i = 0; i < access.Length; i++)
			{
				flag &= (access[i].IsDefaultPort || (access[i].IsOriginPort && intPort == -1));
				flag2 &= (access[i].IsOriginPort || access[i].Port == intPort);
				if (access[i].Port >= 0)
				{
					if (num == -2)
					{
						num = access[i].Port;
					}
					else if (access[i].Port != num)
					{
						num = -1;
					}
				}
				else
				{
					num = -1;
				}
				if (access[i].IsAnyScheme)
				{
					flag3 = true;
				}
			}
			if (!flag && !flag2 && num == -1)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder("([0-9a-z+\\-\\.]+)://".Length * access.Length + "".Length * 2 + escapedHost.Length);
			if (flag3)
			{
				stringBuilder.Append("([0-9a-z+\\-\\.]+)://");
			}
			else
			{
				stringBuilder.Append('(');
				for (int j = 0; j < access.Length; j++)
				{
					int num2 = 0;
					while (num2 < j && !(access[j].Scheme == access[num2].Scheme))
					{
						num2++;
					}
					if (num2 == j)
					{
						if (j != 0)
						{
							stringBuilder.Append('|');
						}
						stringBuilder.Append(access[j].IsOriginScheme ? escapedScheme : this.EscapeStringForRegex(access[j].Scheme));
					}
				}
				stringBuilder.Append(")://");
			}
			stringBuilder.Append("").Append(escapedHost);
			if (!flag)
			{
				if (flag2)
				{
					stringBuilder.Append(':').Append(intPort);
				}
				else
				{
					stringBuilder.Append(':').Append(num);
				}
			}
			stringBuilder.Append("/.*");
			return stringBuilder.ToString();
		}

		// Token: 0x06002AA6 RID: 10918 RVA: 0x0009DCDC File Offset: 0x0009BEDC
		private string GetPermissionAccessElementString(CodeConnectAccess access, string escapedScheme, string escapedHost, string strPort)
		{
			StringBuilder stringBuilder = new StringBuilder("([0-9a-z+\\-\\.]+)://".Length * 2 + "".Length + escapedHost.Length);
			if (access.IsAnyScheme)
			{
				stringBuilder.Append("([0-9a-z+\\-\\.]+)://");
			}
			else if (access.IsOriginScheme)
			{
				stringBuilder.Append(escapedScheme).Append("://");
			}
			else
			{
				stringBuilder.Append(this.EscapeStringForRegex(access.Scheme)).Append("://");
			}
			stringBuilder.Append("").Append(escapedHost);
			if (!access.IsDefaultPort)
			{
				if (access.IsOriginPort)
				{
					stringBuilder.Append(strPort);
				}
				else
				{
					stringBuilder.Append(':').Append(access.StrPort);
				}
			}
			stringBuilder.Append("/.*");
			return stringBuilder.ToString();
		}

		// Token: 0x06002AA7 RID: 10919 RVA: 0x0009DDB0 File Offset: 0x0009BFB0
		internal PolicyStatement CalculatePolicy(string host, string scheme, string port)
		{
			SecurityElement securityElement = this.CreateWebPermission(host, scheme, port, null);
			SecurityElement securityElement2 = new SecurityElement("PolicyStatement");
			SecurityElement securityElement3 = new SecurityElement("PermissionSet");
			securityElement3.AddAttribute("class", "System.Security.PermissionSet");
			securityElement3.AddAttribute("version", "1");
			if (securityElement != null)
			{
				securityElement3.AddChild(securityElement);
			}
			securityElement2.AddChild(securityElement3);
			PolicyStatement policyStatement = new PolicyStatement();
			policyStatement.FromXml(securityElement2);
			return policyStatement;
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x0009DE20 File Offset: 0x0009C020
		private PolicyStatement CalculateAssemblyPolicy(Evidence evidence)
		{
			PolicyStatement policyStatement = null;
			Url hostEvidence = evidence.GetHostEvidence<Url>();
			if (hostEvidence != null)
			{
				policyStatement = this.CalculatePolicy(hostEvidence.GetURLString().Host, hostEvidence.GetURLString().Scheme, hostEvidence.GetURLString().Port);
			}
			if (policyStatement == null)
			{
				Site hostEvidence2 = evidence.GetHostEvidence<Site>();
				if (hostEvidence2 != null)
				{
					policyStatement = this.CalculatePolicy(hostEvidence2.Name, null, null);
				}
			}
			if (policyStatement == null)
			{
				policyStatement = new PolicyStatement(new PermissionSet(false), PolicyStatementAttribute.Nothing);
			}
			return policyStatement;
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x0009DE90 File Offset: 0x0009C090
		public override CodeGroup Copy()
		{
			NetCodeGroup netCodeGroup = new NetCodeGroup(base.MembershipCondition);
			netCodeGroup.Name = base.Name;
			netCodeGroup.Description = base.Description;
			if (this.m_schemesList != null)
			{
				netCodeGroup.m_schemesList = (ArrayList)this.m_schemesList.Clone();
				netCodeGroup.m_accessList = new ArrayList(this.m_accessList.Count);
				for (int i = 0; i < this.m_accessList.Count; i++)
				{
					netCodeGroup.m_accessList.Add(((ArrayList)this.m_accessList[i]).Clone());
				}
			}
			foreach (object obj in base.Children)
			{
				netCodeGroup.AddChild((CodeGroup)obj);
			}
			return netCodeGroup;
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06002AAA RID: 10922 RVA: 0x0009DF55 File Offset: 0x0009C155
		public override string MergeLogic
		{
			get
			{
				return Environment.GetResourceString("MergeLogic_Union");
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x06002AAB RID: 10923 RVA: 0x0009DF61 File Offset: 0x0009C161
		public override string PermissionSetName
		{
			get
			{
				return Environment.GetResourceString("NetCodeGroup_PermissionSet");
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06002AAC RID: 10924 RVA: 0x0009DF6D File Offset: 0x0009C16D
		public override string AttributeString
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06002AAD RID: 10925 RVA: 0x0009DF70 File Offset: 0x0009C170
		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			NetCodeGroup netCodeGroup = o as NetCodeGroup;
			if (netCodeGroup == null || !base.Equals(netCodeGroup))
			{
				return false;
			}
			if (this.m_schemesList == null != (netCodeGroup.m_schemesList == null))
			{
				return false;
			}
			if (this.m_schemesList == null)
			{
				return true;
			}
			if (this.m_schemesList.Count != netCodeGroup.m_schemesList.Count)
			{
				return false;
			}
			for (int i = 0; i < this.m_schemesList.Count; i++)
			{
				int num = netCodeGroup.m_schemesList.IndexOf(this.m_schemesList[i]);
				if (num == -1)
				{
					return false;
				}
				ArrayList arrayList = (ArrayList)this.m_accessList[i];
				ArrayList arrayList2 = (ArrayList)netCodeGroup.m_accessList[num];
				if (arrayList.Count != arrayList2.Count)
				{
					return false;
				}
				for (int j = 0; j < arrayList.Count; j++)
				{
					if (!arrayList2.Contains(arrayList[j]))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06002AAE RID: 10926 RVA: 0x0009E06B File Offset: 0x0009C26B
		public override int GetHashCode()
		{
			return base.GetHashCode() + this.GetRulesHashCode();
		}

		// Token: 0x06002AAF RID: 10927 RVA: 0x0009E07C File Offset: 0x0009C27C
		private int GetRulesHashCode()
		{
			if (this.m_schemesList == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < this.m_schemesList.Count; i++)
			{
				num += ((string)this.m_schemesList[i]).GetHashCode();
			}
			foreach (object obj in this.m_accessList)
			{
				ArrayList arrayList = (ArrayList)obj;
				for (int j = 0; j < arrayList.Count; j++)
				{
					num += ((CodeConnectAccess)arrayList[j]).GetHashCode();
				}
			}
			return num;
		}

		// Token: 0x06002AB0 RID: 10928 RVA: 0x0009E138 File Offset: 0x0009C338
		protected override void CreateXml(SecurityElement element, PolicyLevel level)
		{
			DictionaryEntry[] connectAccessRules = this.GetConnectAccessRules();
			if (connectAccessRules == null)
			{
				return;
			}
			SecurityElement securityElement = new SecurityElement("connectAccessRules");
			foreach (DictionaryEntry dictionaryEntry in connectAccessRules)
			{
				SecurityElement securityElement2 = new SecurityElement("codeOrigin");
				securityElement2.AddAttribute("scheme", (string)dictionaryEntry.Key);
				foreach (CodeConnectAccess codeConnectAccess in (CodeConnectAccess[])dictionaryEntry.Value)
				{
					SecurityElement securityElement3 = new SecurityElement("connectAccess");
					securityElement3.AddAttribute("scheme", codeConnectAccess.Scheme);
					securityElement3.AddAttribute("port", codeConnectAccess.StrPort);
					securityElement2.AddChild(securityElement3);
				}
				securityElement.AddChild(securityElement2);
			}
			element.AddChild(securityElement);
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x0009E210 File Offset: 0x0009C410
		protected override void ParseXml(SecurityElement e, PolicyLevel level)
		{
			this.ResetConnectAccess();
			SecurityElement securityElement = e.SearchForChildByTag("connectAccessRules");
			if (securityElement == null || securityElement.Children == null)
			{
				this.SetDefaults();
				return;
			}
			foreach (object obj in securityElement.Children)
			{
				SecurityElement securityElement2 = (SecurityElement)obj;
				if (securityElement2.Tag.Equals("codeOrigin"))
				{
					string originScheme = securityElement2.Attribute("scheme");
					bool flag = false;
					if (securityElement2.Children != null)
					{
						foreach (object obj2 in securityElement2.Children)
						{
							SecurityElement securityElement3 = (SecurityElement)obj2;
							if (securityElement3.Tag.Equals("connectAccess"))
							{
								string allowScheme = securityElement3.Attribute("scheme");
								string allowPort = securityElement3.Attribute("port");
								this.AddConnectAccess(originScheme, new CodeConnectAccess(allowScheme, allowPort));
								flag = true;
							}
						}
					}
					if (!flag)
					{
						this.AddConnectAccess(originScheme, null);
					}
				}
			}
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x0009E354 File Offset: 0x0009C554
		internal override string GetTypeName()
		{
			return "System.Security.Policy.NetCodeGroup";
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x0009E35C File Offset: 0x0009C55C
		private void SetDefaults()
		{
			this.AddConnectAccess("file", null);
			this.AddConnectAccess("http", new CodeConnectAccess("http", CodeConnectAccess.OriginPort));
			this.AddConnectAccess("http", new CodeConnectAccess("https", CodeConnectAccess.OriginPort));
			this.AddConnectAccess("https", new CodeConnectAccess("https", CodeConnectAccess.OriginPort));
			this.AddConnectAccess(NetCodeGroup.AbsentOriginScheme, CodeConnectAccess.CreateAnySchemeAccess(CodeConnectAccess.OriginPort));
			this.AddConnectAccess(NetCodeGroup.AnyOtherOriginScheme, CodeConnectAccess.CreateOriginSchemeAccess(CodeConnectAccess.OriginPort));
		}

		// Token: 0x04001151 RID: 4433
		[OptionalField(VersionAdded = 2)]
		private ArrayList m_schemesList;

		// Token: 0x04001152 RID: 4434
		[OptionalField(VersionAdded = 2)]
		private ArrayList m_accessList;

		// Token: 0x04001153 RID: 4435
		private const string c_IgnoreUserInfo = "";

		// Token: 0x04001154 RID: 4436
		private const string c_AnyScheme = "([0-9a-z+\\-\\.]+)://";

		// Token: 0x04001155 RID: 4437
		private static readonly char[] c_SomeRegexChars = new char[]
		{
			'.',
			'-',
			'+',
			'[',
			']',
			'{',
			'$',
			'^',
			'#',
			')',
			'(',
			' '
		};

		// Token: 0x04001156 RID: 4438
		public static readonly string AnyOtherOriginScheme = CodeConnectAccess.AnyScheme;

		// Token: 0x04001157 RID: 4439
		public static readonly string AbsentOriginScheme = string.Empty;
	}
}
