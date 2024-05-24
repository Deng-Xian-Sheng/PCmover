using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Util;
using System.Threading;

namespace System.Security.Policy
{
	// Token: 0x02000375 RID: 885
	[ComVisible(true)]
	[Serializable]
	public sealed class HashMembershipCondition : ISerializable, IDeserializationCallback, IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IReportMatchMembershipCondition
	{
		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06002BE3 RID: 11235 RVA: 0x000A3700 File Offset: 0x000A1900
		private object InternalSyncObject
		{
			get
			{
				if (this.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange(ref this.s_InternalSyncObject, value, null);
				}
				return this.s_InternalSyncObject;
			}
		}

		// Token: 0x06002BE4 RID: 11236 RVA: 0x000A372F File Offset: 0x000A192F
		internal HashMembershipCondition()
		{
		}

		// Token: 0x06002BE5 RID: 11237 RVA: 0x000A3738 File Offset: 0x000A1938
		private HashMembershipCondition(SerializationInfo info, StreamingContext context)
		{
			this.m_value = (byte[])info.GetValue("HashValue", typeof(byte[]));
			string text = (string)info.GetValue("HashAlgorithm", typeof(string));
			if (text != null)
			{
				this.m_hashAlg = HashAlgorithm.Create(text);
				return;
			}
			this.m_hashAlg = new SHA1Managed();
		}

		// Token: 0x06002BE6 RID: 11238 RVA: 0x000A37A4 File Offset: 0x000A19A4
		public HashMembershipCondition(HashAlgorithm hashAlg, byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (hashAlg == null)
			{
				throw new ArgumentNullException("hashAlg");
			}
			this.m_value = new byte[value.Length];
			Array.Copy(value, this.m_value, value.Length);
			this.m_hashAlg = hashAlg;
		}

		// Token: 0x06002BE7 RID: 11239 RVA: 0x000A37F7 File Offset: 0x000A19F7
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("HashValue", this.HashValue);
			info.AddValue("HashAlgorithm", this.HashAlgorithm.ToString());
		}

		// Token: 0x06002BE8 RID: 11240 RVA: 0x000A3820 File Offset: 0x000A1A20
		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06002BEA RID: 11242 RVA: 0x000A3839 File Offset: 0x000A1A39
		// (set) Token: 0x06002BE9 RID: 11241 RVA: 0x000A3822 File Offset: 0x000A1A22
		public HashAlgorithm HashAlgorithm
		{
			get
			{
				if (this.m_hashAlg == null && this.m_element != null)
				{
					this.ParseHashAlgorithm();
				}
				return this.m_hashAlg;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("HashAlgorithm");
				}
				this.m_hashAlg = value;
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06002BEC RID: 11244 RVA: 0x000A3884 File Offset: 0x000A1A84
		// (set) Token: 0x06002BEB RID: 11243 RVA: 0x000A3857 File Offset: 0x000A1A57
		public byte[] HashValue
		{
			get
			{
				if (this.m_value == null && this.m_element != null)
				{
					this.ParseHashValue();
				}
				if (this.m_value == null)
				{
					return null;
				}
				byte[] array = new byte[this.m_value.Length];
				Array.Copy(this.m_value, array, this.m_value.Length);
				return array;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.m_value = new byte[value.Length];
				Array.Copy(value, this.m_value, value.Length);
			}
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x000A38D4 File Offset: 0x000A1AD4
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002BEE RID: 11246 RVA: 0x000A38EC File Offset: 0x000A1AEC
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Hash hostEvidence = evidence.GetHostEvidence<Hash>();
			if (hostEvidence != null)
			{
				if (this.m_value == null && this.m_element != null)
				{
					this.ParseHashValue();
				}
				if (this.m_hashAlg == null && this.m_element != null)
				{
					this.ParseHashAlgorithm();
				}
				byte[] array = null;
				object internalSyncObject = this.InternalSyncObject;
				lock (internalSyncObject)
				{
					array = hostEvidence.GenerateHash(this.m_hashAlg);
				}
				if (array != null && HashMembershipCondition.CompareArrays(array, this.m_value))
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x000A398C File Offset: 0x000A1B8C
		public IMembershipCondition Copy()
		{
			if (this.m_value == null && this.m_element != null)
			{
				this.ParseHashValue();
			}
			if (this.m_hashAlg == null && this.m_element != null)
			{
				this.ParseHashAlgorithm();
			}
			return new HashMembershipCondition(this.m_hashAlg, this.m_value);
		}

		// Token: 0x06002BF0 RID: 11248 RVA: 0x000A39CB File Offset: 0x000A1BCB
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002BF1 RID: 11249 RVA: 0x000A39D4 File Offset: 0x000A1BD4
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002BF2 RID: 11250 RVA: 0x000A39E0 File Offset: 0x000A1BE0
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_value == null && this.m_element != null)
			{
				this.ParseHashValue();
			}
			if (this.m_hashAlg == null && this.m_element != null)
			{
				this.ParseHashAlgorithm();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.HashMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_value != null)
			{
				securityElement.AddAttribute("HashValue", Hex.EncodeHexString(this.HashValue));
			}
			if (this.m_hashAlg != null)
			{
				securityElement.AddAttribute("HashAlgorithm", this.HashAlgorithm.GetType().FullName);
			}
			return securityElement;
		}

		// Token: 0x06002BF3 RID: 11251 RVA: 0x000A3A88 File Offset: 0x000A1C88
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
			object internalSyncObject = this.InternalSyncObject;
			lock (internalSyncObject)
			{
				this.m_element = e;
				this.m_value = null;
				this.m_hashAlg = null;
			}
		}

		// Token: 0x06002BF4 RID: 11252 RVA: 0x000A3B08 File Offset: 0x000A1D08
		public override bool Equals(object o)
		{
			HashMembershipCondition hashMembershipCondition = o as HashMembershipCondition;
			if (hashMembershipCondition != null)
			{
				if (this.m_hashAlg == null && this.m_element != null)
				{
					this.ParseHashAlgorithm();
				}
				if (hashMembershipCondition.m_hashAlg == null && hashMembershipCondition.m_element != null)
				{
					hashMembershipCondition.ParseHashAlgorithm();
				}
				if (this.m_hashAlg != null && hashMembershipCondition.m_hashAlg != null && this.m_hashAlg.GetType() == hashMembershipCondition.m_hashAlg.GetType())
				{
					if (this.m_value == null && this.m_element != null)
					{
						this.ParseHashValue();
					}
					if (hashMembershipCondition.m_value == null && hashMembershipCondition.m_element != null)
					{
						hashMembershipCondition.ParseHashValue();
					}
					if (this.m_value.Length != hashMembershipCondition.m_value.Length)
					{
						return false;
					}
					for (int i = 0; i < this.m_value.Length; i++)
					{
						if (this.m_value[i] != hashMembershipCondition.m_value[i])
						{
							return false;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002BF5 RID: 11253 RVA: 0x000A3BEC File Offset: 0x000A1DEC
		public override int GetHashCode()
		{
			if (this.m_hashAlg == null && this.m_element != null)
			{
				this.ParseHashAlgorithm();
			}
			int num = (this.m_hashAlg != null) ? this.m_hashAlg.GetType().GetHashCode() : 0;
			if (this.m_value == null && this.m_element != null)
			{
				this.ParseHashValue();
			}
			return num ^ HashMembershipCondition.GetByteArrayHashCode(this.m_value);
		}

		// Token: 0x06002BF6 RID: 11254 RVA: 0x000A3C50 File Offset: 0x000A1E50
		public override string ToString()
		{
			if (this.m_hashAlg == null)
			{
				this.ParseHashAlgorithm();
			}
			return Environment.GetResourceString("Hash_ToString", new object[]
			{
				this.m_hashAlg.GetType().AssemblyQualifiedName,
				Hex.EncodeHexString(this.HashValue)
			});
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x000A3C9C File Offset: 0x000A1E9C
		private void ParseHashValue()
		{
			object internalSyncObject = this.InternalSyncObject;
			lock (internalSyncObject)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("HashValue");
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidXMLElement", new object[]
						{
							"HashValue",
							base.GetType().FullName
						}));
					}
					this.m_value = Hex.DecodeHexString(text);
					if (this.m_value != null && this.m_hashAlg != null)
					{
						this.m_element = null;
					}
				}
			}
		}

		// Token: 0x06002BF8 RID: 11256 RVA: 0x000A3D48 File Offset: 0x000A1F48
		private void ParseHashAlgorithm()
		{
			object internalSyncObject = this.InternalSyncObject;
			lock (internalSyncObject)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("HashAlgorithm");
					if (text != null)
					{
						this.m_hashAlg = HashAlgorithm.Create(text);
					}
					else
					{
						this.m_hashAlg = new SHA1Managed();
					}
					if (this.m_value != null && this.m_hashAlg != null)
					{
						this.m_element = null;
					}
				}
			}
		}

		// Token: 0x06002BF9 RID: 11257 RVA: 0x000A3DD0 File Offset: 0x000A1FD0
		private static bool CompareArrays(byte[] first, byte[] second)
		{
			if (first.Length != second.Length)
			{
				return false;
			}
			int num = first.Length;
			for (int i = 0; i < num; i++)
			{
				if (first[i] != second[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002BFA RID: 11258 RVA: 0x000A3E04 File Offset: 0x000A2004
		private static int GetByteArrayHashCode(byte[] baData)
		{
			if (baData == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < baData.Length; i++)
			{
				num = (num << 8 ^ (int)baData[i] ^ num >> 24);
			}
			return num;
		}

		// Token: 0x040011AC RID: 4524
		private byte[] m_value;

		// Token: 0x040011AD RID: 4525
		private HashAlgorithm m_hashAlg;

		// Token: 0x040011AE RID: 4526
		private SecurityElement m_element;

		// Token: 0x040011AF RID: 4527
		private object s_InternalSyncObject;

		// Token: 0x040011B0 RID: 4528
		private const string s_tagHashValue = "HashValue";

		// Token: 0x040011B1 RID: 4529
		private const string s_tagHashAlgorithm = "HashAlgorithm";
	}
}
