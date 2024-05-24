using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

namespace System.Security.Claims
{
	// Token: 0x0200031B RID: 795
	[Serializable]
	public class Claim
	{
		// Token: 0x06002810 RID: 10256 RVA: 0x000926F3 File Offset: 0x000908F3
		public Claim(BinaryReader reader) : this(reader, null)
		{
		}

		// Token: 0x06002811 RID: 10257 RVA: 0x000926FD File Offset: 0x000908FD
		public Claim(BinaryReader reader, ClaimsIdentity subject)
		{
			this.m_propertyLock = new object();
			base..ctor();
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.Initialize(reader, subject);
		}

		// Token: 0x06002812 RID: 10258 RVA: 0x00092726 File Offset: 0x00090926
		public Claim(string type, string value) : this(type, value, "http://www.w3.org/2001/XMLSchema#string", "LOCAL AUTHORITY", "LOCAL AUTHORITY", null)
		{
		}

		// Token: 0x06002813 RID: 10259 RVA: 0x00092740 File Offset: 0x00090940
		public Claim(string type, string value, string valueType) : this(type, value, valueType, "LOCAL AUTHORITY", "LOCAL AUTHORITY", null)
		{
		}

		// Token: 0x06002814 RID: 10260 RVA: 0x00092756 File Offset: 0x00090956
		public Claim(string type, string value, string valueType, string issuer) : this(type, value, valueType, issuer, issuer, null)
		{
		}

		// Token: 0x06002815 RID: 10261 RVA: 0x00092766 File Offset: 0x00090966
		public Claim(string type, string value, string valueType, string issuer, string originalIssuer) : this(type, value, valueType, issuer, originalIssuer, null)
		{
		}

		// Token: 0x06002816 RID: 10262 RVA: 0x00092778 File Offset: 0x00090978
		public Claim(string type, string value, string valueType, string issuer, string originalIssuer, ClaimsIdentity subject) : this(type, value, valueType, issuer, originalIssuer, subject, null, null)
		{
		}

		// Token: 0x06002817 RID: 10263 RVA: 0x00092798 File Offset: 0x00090998
		internal Claim(string type, string value, string valueType, string issuer, string originalIssuer, ClaimsIdentity subject, string propertyKey, string propertyValue)
		{
			this.m_propertyLock = new object();
			base..ctor();
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.m_type = type;
			this.m_value = value;
			if (string.IsNullOrEmpty(valueType))
			{
				this.m_valueType = "http://www.w3.org/2001/XMLSchema#string";
			}
			else
			{
				this.m_valueType = valueType;
			}
			if (string.IsNullOrEmpty(issuer))
			{
				this.m_issuer = "LOCAL AUTHORITY";
			}
			else
			{
				this.m_issuer = issuer;
			}
			if (string.IsNullOrEmpty(originalIssuer))
			{
				this.m_originalIssuer = this.m_issuer;
			}
			else
			{
				this.m_originalIssuer = originalIssuer;
			}
			this.m_subject = subject;
			if (propertyKey != null)
			{
				this.Properties.Add(propertyKey, propertyValue);
			}
		}

		// Token: 0x06002818 RID: 10264 RVA: 0x00092854 File Offset: 0x00090A54
		protected Claim(Claim other) : this(other, (other == null) ? null : other.m_subject)
		{
		}

		// Token: 0x06002819 RID: 10265 RVA: 0x0009286C File Offset: 0x00090A6C
		protected Claim(Claim other, ClaimsIdentity subject)
		{
			this.m_propertyLock = new object();
			base..ctor();
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			this.m_issuer = other.m_issuer;
			this.m_originalIssuer = other.m_originalIssuer;
			this.m_subject = subject;
			this.m_type = other.m_type;
			this.m_value = other.m_value;
			this.m_valueType = other.m_valueType;
			if (other.m_properties != null)
			{
				this.m_properties = new Dictionary<string, string>();
				foreach (string key in other.m_properties.Keys)
				{
					this.m_properties.Add(key, other.m_properties[key]);
				}
			}
			if (other.m_userSerializationData != null)
			{
				this.m_userSerializationData = (other.m_userSerializationData.Clone() as byte[]);
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x0600281A RID: 10266 RVA: 0x00092968 File Offset: 0x00090B68
		protected virtual byte[] CustomSerializationData
		{
			get
			{
				return this.m_userSerializationData;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x0600281B RID: 10267 RVA: 0x00092970 File Offset: 0x00090B70
		public string Issuer
		{
			get
			{
				return this.m_issuer;
			}
		}

		// Token: 0x0600281C RID: 10268 RVA: 0x00092978 File Offset: 0x00090B78
		[OnDeserialized]
		private void OnDeserializedMethod(StreamingContext context)
		{
			this.m_propertyLock = new object();
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x0600281D RID: 10269 RVA: 0x00092985 File Offset: 0x00090B85
		public string OriginalIssuer
		{
			get
			{
				return this.m_originalIssuer;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x0600281E RID: 10270 RVA: 0x00092990 File Offset: 0x00090B90
		public IDictionary<string, string> Properties
		{
			get
			{
				if (this.m_properties == null)
				{
					object propertyLock = this.m_propertyLock;
					lock (propertyLock)
					{
						if (this.m_properties == null)
						{
							this.m_properties = new Dictionary<string, string>();
						}
					}
				}
				return this.m_properties;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x0600281F RID: 10271 RVA: 0x000929EC File Offset: 0x00090BEC
		// (set) Token: 0x06002820 RID: 10272 RVA: 0x000929F4 File Offset: 0x00090BF4
		public ClaimsIdentity Subject
		{
			get
			{
				return this.m_subject;
			}
			internal set
			{
				this.m_subject = value;
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002821 RID: 10273 RVA: 0x000929FD File Offset: 0x00090BFD
		public string Type
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06002822 RID: 10274 RVA: 0x00092A05 File Offset: 0x00090C05
		public string Value
		{
			get
			{
				return this.m_value;
			}
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002823 RID: 10275 RVA: 0x00092A0D File Offset: 0x00090C0D
		public string ValueType
		{
			get
			{
				return this.m_valueType;
			}
		}

		// Token: 0x06002824 RID: 10276 RVA: 0x00092A15 File Offset: 0x00090C15
		public virtual Claim Clone()
		{
			return this.Clone(null);
		}

		// Token: 0x06002825 RID: 10277 RVA: 0x00092A1E File Offset: 0x00090C1E
		public virtual Claim Clone(ClaimsIdentity identity)
		{
			return new Claim(this, identity);
		}

		// Token: 0x06002826 RID: 10278 RVA: 0x00092A28 File Offset: 0x00090C28
		private void Initialize(BinaryReader reader, ClaimsIdentity subject)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.m_subject = subject;
			Claim.SerializationMask serializationMask = (Claim.SerializationMask)reader.ReadInt32();
			int num = 1;
			int num2 = reader.ReadInt32();
			this.m_value = reader.ReadString();
			if ((serializationMask & Claim.SerializationMask.NameClaimType) == Claim.SerializationMask.NameClaimType)
			{
				this.m_type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
			}
			else if ((serializationMask & Claim.SerializationMask.RoleClaimType) == Claim.SerializationMask.RoleClaimType)
			{
				this.m_type = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
			}
			else
			{
				this.m_type = reader.ReadString();
				num++;
			}
			if ((serializationMask & Claim.SerializationMask.StringType) == Claim.SerializationMask.StringType)
			{
				this.m_valueType = reader.ReadString();
				num++;
			}
			else
			{
				this.m_valueType = "http://www.w3.org/2001/XMLSchema#string";
			}
			if ((serializationMask & Claim.SerializationMask.Issuer) == Claim.SerializationMask.Issuer)
			{
				this.m_issuer = reader.ReadString();
				num++;
			}
			else
			{
				this.m_issuer = "LOCAL AUTHORITY";
			}
			if ((serializationMask & Claim.SerializationMask.OriginalIssuerEqualsIssuer) == Claim.SerializationMask.OriginalIssuerEqualsIssuer)
			{
				this.m_originalIssuer = this.m_issuer;
			}
			else if ((serializationMask & Claim.SerializationMask.OriginalIssuer) == Claim.SerializationMask.OriginalIssuer)
			{
				this.m_originalIssuer = reader.ReadString();
				num++;
			}
			else
			{
				this.m_originalIssuer = "LOCAL AUTHORITY";
			}
			if ((serializationMask & Claim.SerializationMask.HasProperties) == Claim.SerializationMask.HasProperties)
			{
				int num3 = reader.ReadInt32();
				for (int i = 0; i < num3; i++)
				{
					this.Properties.Add(reader.ReadString(), reader.ReadString());
				}
			}
			if ((serializationMask & Claim.SerializationMask.UserData) == Claim.SerializationMask.UserData)
			{
				int count = reader.ReadInt32();
				this.m_userSerializationData = reader.ReadBytes(count);
				num++;
			}
			for (int j = num; j < num2; j++)
			{
				reader.ReadString();
			}
		}

		// Token: 0x06002827 RID: 10279 RVA: 0x00092B92 File Offset: 0x00090D92
		public virtual void WriteTo(BinaryWriter writer)
		{
			this.WriteTo(writer, null);
		}

		// Token: 0x06002828 RID: 10280 RVA: 0x00092B9C File Offset: 0x00090D9C
		protected virtual void WriteTo(BinaryWriter writer, byte[] userData)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			int num = 1;
			Claim.SerializationMask serializationMask = Claim.SerializationMask.None;
			if (string.Equals(this.m_type, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"))
			{
				serializationMask |= Claim.SerializationMask.NameClaimType;
			}
			else if (string.Equals(this.m_type, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"))
			{
				serializationMask |= Claim.SerializationMask.RoleClaimType;
			}
			else
			{
				num++;
			}
			if (!string.Equals(this.m_valueType, "http://www.w3.org/2001/XMLSchema#string", StringComparison.Ordinal))
			{
				num++;
				serializationMask |= Claim.SerializationMask.StringType;
			}
			if (!string.Equals(this.m_issuer, "LOCAL AUTHORITY", StringComparison.Ordinal))
			{
				num++;
				serializationMask |= Claim.SerializationMask.Issuer;
			}
			if (string.Equals(this.m_originalIssuer, this.m_issuer, StringComparison.Ordinal))
			{
				serializationMask |= Claim.SerializationMask.OriginalIssuerEqualsIssuer;
			}
			else if (!string.Equals(this.m_originalIssuer, "LOCAL AUTHORITY", StringComparison.Ordinal))
			{
				num++;
				serializationMask |= Claim.SerializationMask.OriginalIssuer;
			}
			if (this.Properties.Count > 0)
			{
				num++;
				serializationMask |= Claim.SerializationMask.HasProperties;
			}
			if (userData != null && userData.Length != 0)
			{
				num++;
				serializationMask |= Claim.SerializationMask.UserData;
			}
			writer.Write((int)serializationMask);
			writer.Write(num);
			writer.Write(this.m_value);
			if ((serializationMask & Claim.SerializationMask.NameClaimType) != Claim.SerializationMask.NameClaimType && (serializationMask & Claim.SerializationMask.RoleClaimType) != Claim.SerializationMask.RoleClaimType)
			{
				writer.Write(this.m_type);
			}
			if ((serializationMask & Claim.SerializationMask.StringType) == Claim.SerializationMask.StringType)
			{
				writer.Write(this.m_valueType);
			}
			if ((serializationMask & Claim.SerializationMask.Issuer) == Claim.SerializationMask.Issuer)
			{
				writer.Write(this.m_issuer);
			}
			if ((serializationMask & Claim.SerializationMask.OriginalIssuer) == Claim.SerializationMask.OriginalIssuer)
			{
				writer.Write(this.m_originalIssuer);
			}
			if ((serializationMask & Claim.SerializationMask.HasProperties) == Claim.SerializationMask.HasProperties)
			{
				writer.Write(this.Properties.Count);
				foreach (string text in this.Properties.Keys)
				{
					writer.Write(text);
					writer.Write(this.Properties[text]);
				}
			}
			if ((serializationMask & Claim.SerializationMask.UserData) == Claim.SerializationMask.UserData)
			{
				writer.Write(userData.Length);
				writer.Write(userData);
			}
			writer.Flush();
		}

		// Token: 0x06002829 RID: 10281 RVA: 0x00092D84 File Offset: 0x00090F84
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}: {1}", this.m_type, this.m_value);
		}

		// Token: 0x04000F7C RID: 3964
		private string m_issuer;

		// Token: 0x04000F7D RID: 3965
		private string m_originalIssuer;

		// Token: 0x04000F7E RID: 3966
		private string m_type;

		// Token: 0x04000F7F RID: 3967
		private string m_value;

		// Token: 0x04000F80 RID: 3968
		private string m_valueType;

		// Token: 0x04000F81 RID: 3969
		[NonSerialized]
		private byte[] m_userSerializationData;

		// Token: 0x04000F82 RID: 3970
		private Dictionary<string, string> m_properties;

		// Token: 0x04000F83 RID: 3971
		[NonSerialized]
		private object m_propertyLock;

		// Token: 0x04000F84 RID: 3972
		[NonSerialized]
		private ClaimsIdentity m_subject;

		// Token: 0x02000B4F RID: 2895
		private enum SerializationMask
		{
			// Token: 0x040033DA RID: 13274
			None,
			// Token: 0x040033DB RID: 13275
			NameClaimType,
			// Token: 0x040033DC RID: 13276
			RoleClaimType,
			// Token: 0x040033DD RID: 13277
			StringType = 4,
			// Token: 0x040033DE RID: 13278
			Issuer = 8,
			// Token: 0x040033DF RID: 13279
			OriginalIssuerEqualsIssuer = 16,
			// Token: 0x040033E0 RID: 13280
			OriginalIssuer = 32,
			// Token: 0x040033E1 RID: 13281
			HasProperties = 64,
			// Token: 0x040033E2 RID: 13282
			UserData = 128
		}
	}
}
