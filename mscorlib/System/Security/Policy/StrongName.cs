using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x0200036B RID: 875
	[ComVisible(true)]
	[Serializable]
	public sealed class StrongName : EvidenceBase, IIdentityPermissionFactory, IDelayEvaluatedEvidence
	{
		// Token: 0x06002B4B RID: 11083 RVA: 0x000A1700 File Offset: 0x0009F900
		internal StrongName()
		{
		}

		// Token: 0x06002B4C RID: 11084 RVA: 0x000A1708 File Offset: 0x0009F908
		public StrongName(StrongNamePublicKeyBlob blob, string name, Version version) : this(blob, name, version, null)
		{
		}

		// Token: 0x06002B4D RID: 11085 RVA: 0x000A1714 File Offset: 0x0009F914
		internal StrongName(StrongNamePublicKeyBlob blob, string name, Version version, Assembly assembly)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyStrongName"));
			}
			if (blob == null)
			{
				throw new ArgumentNullException("blob");
			}
			if (version == null)
			{
				throw new ArgumentNullException("version");
			}
			RuntimeAssembly runtimeAssembly = assembly as RuntimeAssembly;
			if (assembly != null && runtimeAssembly == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"), "assembly");
			}
			this.m_publicKeyBlob = blob;
			this.m_name = name;
			this.m_version = version;
			this.m_assembly = runtimeAssembly;
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06002B4E RID: 11086 RVA: 0x000A17BB File Offset: 0x0009F9BB
		public StrongNamePublicKeyBlob PublicKey
		{
			get
			{
				return this.m_publicKeyBlob;
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06002B4F RID: 11087 RVA: 0x000A17C3 File Offset: 0x0009F9C3
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06002B50 RID: 11088 RVA: 0x000A17CB File Offset: 0x0009F9CB
		public Version Version
		{
			get
			{
				return this.m_version;
			}
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06002B51 RID: 11089 RVA: 0x000A17D3 File Offset: 0x0009F9D3
		bool IDelayEvaluatedEvidence.IsVerified
		{
			[SecurityCritical]
			get
			{
				return !(this.m_assembly != null) || this.m_assembly.IsStrongNameVerified;
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06002B52 RID: 11090 RVA: 0x000A17F0 File Offset: 0x0009F9F0
		bool IDelayEvaluatedEvidence.WasUsed
		{
			get
			{
				return this.m_wasUsed;
			}
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x000A17F8 File Offset: 0x0009F9F8
		void IDelayEvaluatedEvidence.MarkUsed()
		{
			this.m_wasUsed = true;
		}

		// Token: 0x06002B54 RID: 11092 RVA: 0x000A1804 File Offset: 0x0009FA04
		internal static bool CompareNames(string asmName, string mcName)
		{
			if (mcName.Length > 0 && mcName[mcName.Length - 1] == '*' && mcName.Length - 1 <= asmName.Length)
			{
				return string.Compare(mcName, 0, asmName, 0, mcName.Length - 1, StringComparison.OrdinalIgnoreCase) == 0;
			}
			return string.Compare(mcName, asmName, StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x06002B55 RID: 11093 RVA: 0x000A185D File Offset: 0x0009FA5D
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new StrongNameIdentityPermission(this.m_publicKeyBlob, this.m_name, this.m_version);
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x000A1876 File Offset: 0x0009FA76
		public override EvidenceBase Clone()
		{
			return new StrongName(this.m_publicKeyBlob, this.m_name, this.m_version);
		}

		// Token: 0x06002B57 RID: 11095 RVA: 0x000A188F File Offset: 0x0009FA8F
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002B58 RID: 11096 RVA: 0x000A1898 File Offset: 0x0009FA98
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("StrongName");
			securityElement.AddAttribute("version", "1");
			if (this.m_publicKeyBlob != null)
			{
				securityElement.AddAttribute("Key", Hex.EncodeHexString(this.m_publicKeyBlob.PublicKey));
			}
			if (this.m_name != null)
			{
				securityElement.AddAttribute("Name", this.m_name);
			}
			if (this.m_version != null)
			{
				securityElement.AddAttribute("Version", this.m_version.ToString());
			}
			return securityElement;
		}

		// Token: 0x06002B59 RID: 11097 RVA: 0x000A1924 File Offset: 0x0009FB24
		internal void FromXml(SecurityElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (string.Compare(element.Tag, "StrongName", StringComparison.Ordinal) != 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidXML"));
			}
			this.m_publicKeyBlob = null;
			this.m_version = null;
			string text = element.Attribute("Key");
			if (text != null)
			{
				this.m_publicKeyBlob = new StrongNamePublicKeyBlob(Hex.DecodeHexString(text));
			}
			this.m_name = element.Attribute("Name");
			string text2 = element.Attribute("Version");
			if (text2 != null)
			{
				this.m_version = new Version(text2);
			}
		}

		// Token: 0x06002B5A RID: 11098 RVA: 0x000A19BC File Offset: 0x0009FBBC
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002B5B RID: 11099 RVA: 0x000A19CC File Offset: 0x0009FBCC
		public override bool Equals(object o)
		{
			StrongName strongName = o as StrongName;
			return strongName != null && object.Equals(this.m_publicKeyBlob, strongName.m_publicKeyBlob) && object.Equals(this.m_name, strongName.m_name) && object.Equals(this.m_version, strongName.m_version);
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x000A1A1C File Offset: 0x0009FC1C
		public override int GetHashCode()
		{
			if (this.m_publicKeyBlob != null)
			{
				return this.m_publicKeyBlob.GetHashCode();
			}
			if (this.m_name != null || this.m_version != null)
			{
				return ((this.m_name == null) ? 0 : this.m_name.GetHashCode()) + ((this.m_version == null) ? 0 : this.m_version.GetHashCode());
			}
			return typeof(StrongName).GetHashCode();
		}

		// Token: 0x06002B5D RID: 11101 RVA: 0x000A1A98 File Offset: 0x0009FC98
		internal object Normalize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.m_publicKeyBlob.PublicKey);
			binaryWriter.Write(this.m_version.Major);
			binaryWriter.Write(this.m_name);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x04001194 RID: 4500
		private StrongNamePublicKeyBlob m_publicKeyBlob;

		// Token: 0x04001195 RID: 4501
		private string m_name;

		// Token: 0x04001196 RID: 4502
		private Version m_version;

		// Token: 0x04001197 RID: 4503
		[NonSerialized]
		private RuntimeAssembly m_assembly;

		// Token: 0x04001198 RID: 4504
		[NonSerialized]
		private bool m_wasUsed;
	}
}
