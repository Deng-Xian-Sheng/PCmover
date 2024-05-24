using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000345 RID: 837
	[ComVisible(true)]
	[Serializable]
	public sealed class ApplicationTrust : EvidenceBase, ISecurityEncodable
	{
		// Token: 0x0600298E RID: 10638 RVA: 0x000998B3 File Offset: 0x00097AB3
		public ApplicationTrust(ApplicationIdentity applicationIdentity) : this()
		{
			this.ApplicationIdentity = applicationIdentity;
		}

		// Token: 0x0600298F RID: 10639 RVA: 0x000998C2 File Offset: 0x00097AC2
		public ApplicationTrust() : this(new PermissionSet(PermissionState.None))
		{
		}

		// Token: 0x06002990 RID: 10640 RVA: 0x000998D0 File Offset: 0x00097AD0
		internal ApplicationTrust(PermissionSet defaultGrantSet)
		{
			this.InitDefaultGrantSet(defaultGrantSet);
			this.m_fullTrustAssemblies = new List<StrongName>().AsReadOnly();
		}

		// Token: 0x06002991 RID: 10641 RVA: 0x000998F0 File Offset: 0x00097AF0
		public ApplicationTrust(PermissionSet defaultGrantSet, IEnumerable<StrongName> fullTrustAssemblies)
		{
			if (fullTrustAssemblies == null)
			{
				throw new ArgumentNullException("fullTrustAssemblies");
			}
			this.InitDefaultGrantSet(defaultGrantSet);
			List<StrongName> list = new List<StrongName>();
			foreach (StrongName strongName in fullTrustAssemblies)
			{
				if (strongName == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NullFullTrustAssembly"));
				}
				list.Add(new StrongName(strongName.PublicKey, strongName.Name, strongName.Version));
			}
			this.m_fullTrustAssemblies = list.AsReadOnly();
		}

		// Token: 0x06002992 RID: 10642 RVA: 0x00099990 File Offset: 0x00097B90
		private void InitDefaultGrantSet(PermissionSet defaultGrantSet)
		{
			if (defaultGrantSet == null)
			{
				throw new ArgumentNullException("defaultGrantSet");
			}
			this.DefaultGrantSet = new PolicyStatement(defaultGrantSet);
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06002993 RID: 10643 RVA: 0x000999AC File Offset: 0x00097BAC
		// (set) Token: 0x06002994 RID: 10644 RVA: 0x000999B4 File Offset: 0x00097BB4
		public ApplicationIdentity ApplicationIdentity
		{
			get
			{
				return this.m_appId;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(Environment.GetResourceString("Argument_InvalidAppId"));
				}
				this.m_appId = value;
			}
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06002995 RID: 10645 RVA: 0x000999D0 File Offset: 0x00097BD0
		// (set) Token: 0x06002996 RID: 10646 RVA: 0x000999EC File Offset: 0x00097BEC
		public PolicyStatement DefaultGrantSet
		{
			get
			{
				if (this.m_psDefaultGrant == null)
				{
					return new PolicyStatement(new PermissionSet(PermissionState.None));
				}
				return this.m_psDefaultGrant;
			}
			set
			{
				if (value == null)
				{
					this.m_psDefaultGrant = null;
					this.m_grantSetSpecialFlags = 0;
					return;
				}
				this.m_psDefaultGrant = value;
				this.m_grantSetSpecialFlags = SecurityManager.GetSpecialFlags(this.m_psDefaultGrant.PermissionSet, null);
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06002997 RID: 10647 RVA: 0x00099A1E File Offset: 0x00097C1E
		public IList<StrongName> FullTrustAssemblies
		{
			get
			{
				return this.m_fullTrustAssemblies;
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06002998 RID: 10648 RVA: 0x00099A26 File Offset: 0x00097C26
		// (set) Token: 0x06002999 RID: 10649 RVA: 0x00099A2E File Offset: 0x00097C2E
		public bool IsApplicationTrustedToRun
		{
			get
			{
				return this.m_appTrustedToRun;
			}
			set
			{
				this.m_appTrustedToRun = value;
			}
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x0600299A RID: 10650 RVA: 0x00099A37 File Offset: 0x00097C37
		// (set) Token: 0x0600299B RID: 10651 RVA: 0x00099A3F File Offset: 0x00097C3F
		public bool Persist
		{
			get
			{
				return this.m_persist;
			}
			set
			{
				this.m_persist = value;
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x0600299C RID: 10652 RVA: 0x00099A48 File Offset: 0x00097C48
		// (set) Token: 0x0600299D RID: 10653 RVA: 0x00099A70 File Offset: 0x00097C70
		public object ExtraInfo
		{
			get
			{
				if (this.m_elExtraInfo != null)
				{
					this.m_extraInfo = ApplicationTrust.ObjectFromXml(this.m_elExtraInfo);
					this.m_elExtraInfo = null;
				}
				return this.m_extraInfo;
			}
			set
			{
				this.m_elExtraInfo = null;
				this.m_extraInfo = value;
			}
		}

		// Token: 0x0600299E RID: 10654 RVA: 0x00099A80 File Offset: 0x00097C80
		public SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("ApplicationTrust");
			securityElement.AddAttribute("version", "1");
			if (this.m_appId != null)
			{
				securityElement.AddAttribute("FullName", SecurityElement.Escape(this.m_appId.FullName));
			}
			if (this.m_appTrustedToRun)
			{
				securityElement.AddAttribute("TrustedToRun", "true");
			}
			if (this.m_persist)
			{
				securityElement.AddAttribute("Persist", "true");
			}
			if (this.m_psDefaultGrant != null)
			{
				SecurityElement securityElement2 = new SecurityElement("DefaultGrant");
				securityElement2.AddChild(this.m_psDefaultGrant.ToXml());
				securityElement.AddChild(securityElement2);
			}
			if (this.m_fullTrustAssemblies.Count > 0)
			{
				SecurityElement securityElement3 = new SecurityElement("FullTrustAssemblies");
				foreach (StrongName strongName in this.m_fullTrustAssemblies)
				{
					securityElement3.AddChild(strongName.ToXml());
				}
				securityElement.AddChild(securityElement3);
			}
			if (this.ExtraInfo != null)
			{
				securityElement.AddChild(ApplicationTrust.ObjectToXml("ExtraInfo", this.ExtraInfo));
			}
			return securityElement;
		}

		// Token: 0x0600299F RID: 10655 RVA: 0x00099BAC File Offset: 0x00097DAC
		public void FromXml(SecurityElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (string.Compare(element.Tag, "ApplicationTrust", StringComparison.Ordinal) != 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidXML"));
			}
			this.m_appTrustedToRun = false;
			string text = element.Attribute("TrustedToRun");
			if (text != null && string.Compare(text, "true", StringComparison.Ordinal) == 0)
			{
				this.m_appTrustedToRun = true;
			}
			this.m_persist = false;
			string text2 = element.Attribute("Persist");
			if (text2 != null && string.Compare(text2, "true", StringComparison.Ordinal) == 0)
			{
				this.m_persist = true;
			}
			this.m_appId = null;
			string text3 = element.Attribute("FullName");
			if (text3 != null && text3.Length > 0)
			{
				this.m_appId = new ApplicationIdentity(text3);
			}
			this.m_psDefaultGrant = null;
			this.m_grantSetSpecialFlags = 0;
			SecurityElement securityElement = element.SearchForChildByTag("DefaultGrant");
			if (securityElement != null)
			{
				SecurityElement securityElement2 = securityElement.SearchForChildByTag("PolicyStatement");
				if (securityElement2 != null)
				{
					PolicyStatement policyStatement = new PolicyStatement(null);
					policyStatement.FromXml(securityElement2);
					this.m_psDefaultGrant = policyStatement;
					this.m_grantSetSpecialFlags = SecurityManager.GetSpecialFlags(policyStatement.PermissionSet, null);
				}
			}
			List<StrongName> list = new List<StrongName>();
			SecurityElement securityElement3 = element.SearchForChildByTag("FullTrustAssemblies");
			if (securityElement3 != null && securityElement3.InternalChildren != null)
			{
				IEnumerator enumerator = securityElement3.Children.GetEnumerator();
				while (enumerator.MoveNext())
				{
					StrongName strongName = new StrongName();
					strongName.FromXml(enumerator.Current as SecurityElement);
					list.Add(strongName);
				}
			}
			this.m_fullTrustAssemblies = list.AsReadOnly();
			this.m_elExtraInfo = element.SearchForChildByTag("ExtraInfo");
		}

		// Token: 0x060029A0 RID: 10656 RVA: 0x00099D40 File Offset: 0x00097F40
		private static SecurityElement ObjectToXml(string tag, object obj)
		{
			ISecurityEncodable securityEncodable = obj as ISecurityEncodable;
			SecurityElement securityElement;
			if (securityEncodable != null)
			{
				securityElement = securityEncodable.ToXml();
				if (!securityElement.Tag.Equals(tag))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidXML"));
				}
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, obj);
			byte[] sArray = memoryStream.ToArray();
			securityElement = new SecurityElement(tag);
			securityElement.AddAttribute("Data", Hex.EncodeHexString(sArray));
			return securityElement;
		}

		// Token: 0x060029A1 RID: 10657 RVA: 0x00099DB4 File Offset: 0x00097FB4
		private static object ObjectFromXml(SecurityElement elObject)
		{
			if (elObject.Attribute("class") != null)
			{
				ISecurityEncodable securityEncodable = XMLUtil.CreateCodeGroup(elObject) as ISecurityEncodable;
				if (securityEncodable != null)
				{
					securityEncodable.FromXml(elObject);
					return securityEncodable;
				}
			}
			string hexString = elObject.Attribute("Data");
			MemoryStream serializationStream = new MemoryStream(Hex.DecodeHexString(hexString));
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			return binaryFormatter.Deserialize(serializationStream);
		}

		// Token: 0x060029A2 RID: 10658 RVA: 0x00099E0B File Offset: 0x0009800B
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override EvidenceBase Clone()
		{
			return base.Clone();
		}

		// Token: 0x0400110D RID: 4365
		private ApplicationIdentity m_appId;

		// Token: 0x0400110E RID: 4366
		private bool m_appTrustedToRun;

		// Token: 0x0400110F RID: 4367
		private bool m_persist;

		// Token: 0x04001110 RID: 4368
		private object m_extraInfo;

		// Token: 0x04001111 RID: 4369
		private SecurityElement m_elExtraInfo;

		// Token: 0x04001112 RID: 4370
		private PolicyStatement m_psDefaultGrant;

		// Token: 0x04001113 RID: 4371
		private IList<StrongName> m_fullTrustAssemblies;

		// Token: 0x04001114 RID: 4372
		[NonSerialized]
		private int m_grantSetSpecialFlags;
	}
}
