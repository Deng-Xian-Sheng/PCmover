using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace System.Security.Permissions
{
	// Token: 0x02000314 RID: 788
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermissionAccessEntry
	{
		// Token: 0x060027B3 RID: 10163 RVA: 0x000906BE File Offset: 0x0008E8BE
		internal KeyContainerPermissionAccessEntry(KeyContainerPermissionAccessEntry accessEntry) : this(accessEntry.KeyStore, accessEntry.ProviderName, accessEntry.ProviderType, accessEntry.KeyContainerName, accessEntry.KeySpec, accessEntry.Flags)
		{
		}

		// Token: 0x060027B4 RID: 10164 RVA: 0x000906EA File Offset: 0x0008E8EA
		public KeyContainerPermissionAccessEntry(string keyContainerName, KeyContainerPermissionFlags flags) : this(null, null, -1, keyContainerName, -1, flags)
		{
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x000906F8 File Offset: 0x0008E8F8
		public KeyContainerPermissionAccessEntry(CspParameters parameters, KeyContainerPermissionFlags flags) : this(((parameters.Flags & CspProviderFlags.UseMachineKeyStore) == CspProviderFlags.UseMachineKeyStore) ? "Machine" : "User", parameters.ProviderName, parameters.ProviderType, parameters.KeyContainerName, parameters.KeyNumber, flags)
		{
		}

		// Token: 0x060027B6 RID: 10166 RVA: 0x00090730 File Offset: 0x0008E930
		public KeyContainerPermissionAccessEntry(string keyStore, string providerName, int providerType, string keyContainerName, int keySpec, KeyContainerPermissionFlags flags)
		{
			this.m_providerName = ((providerName == null) ? "*" : providerName);
			this.m_providerType = providerType;
			this.m_keyContainerName = ((keyContainerName == null) ? "*" : keyContainerName);
			this.m_keySpec = keySpec;
			this.KeyStore = keyStore;
			this.Flags = flags;
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060027B7 RID: 10167 RVA: 0x00090785 File Offset: 0x0008E985
		// (set) Token: 0x060027B8 RID: 10168 RVA: 0x00090790 File Offset: 0x0008E990
		public string KeyStore
		{
			get
			{
				return this.m_keyStore;
			}
			set
			{
				if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(value, this.ProviderName, this.ProviderType, this.KeyContainerName, this.KeySpec))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
				}
				if (value == null)
				{
					this.m_keyStore = "*";
					return;
				}
				if (value != "User" && value != "Machine" && value != "*")
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidKeyStore", new object[]
					{
						value
					}), "value");
				}
				this.m_keyStore = value;
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060027B9 RID: 10169 RVA: 0x00090829 File Offset: 0x0008EA29
		// (set) Token: 0x060027BA RID: 10170 RVA: 0x00090834 File Offset: 0x0008EA34
		public string ProviderName
		{
			get
			{
				return this.m_providerName;
			}
			set
			{
				if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, value, this.ProviderType, this.KeyContainerName, this.KeySpec))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
				}
				if (value == null)
				{
					this.m_providerName = "*";
					return;
				}
				this.m_providerName = value;
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060027BB RID: 10171 RVA: 0x00090887 File Offset: 0x0008EA87
		// (set) Token: 0x060027BC RID: 10172 RVA: 0x0009088F File Offset: 0x0008EA8F
		public int ProviderType
		{
			get
			{
				return this.m_providerType;
			}
			set
			{
				if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, this.ProviderName, value, this.KeyContainerName, this.KeySpec))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
				}
				this.m_providerType = value;
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060027BD RID: 10173 RVA: 0x000908C8 File Offset: 0x0008EAC8
		// (set) Token: 0x060027BE RID: 10174 RVA: 0x000908D0 File Offset: 0x0008EAD0
		public string KeyContainerName
		{
			get
			{
				return this.m_keyContainerName;
			}
			set
			{
				if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, this.ProviderName, this.ProviderType, value, this.KeySpec))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
				}
				if (value == null)
				{
					this.m_keyContainerName = "*";
					return;
				}
				this.m_keyContainerName = value;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060027BF RID: 10175 RVA: 0x00090923 File Offset: 0x0008EB23
		// (set) Token: 0x060027C0 RID: 10176 RVA: 0x0009092B File Offset: 0x0008EB2B
		public int KeySpec
		{
			get
			{
				return this.m_keySpec;
			}
			set
			{
				if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, this.ProviderName, this.ProviderType, this.KeyContainerName, value))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
				}
				this.m_keySpec = value;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060027C1 RID: 10177 RVA: 0x00090964 File Offset: 0x0008EB64
		// (set) Token: 0x060027C2 RID: 10178 RVA: 0x0009096C File Offset: 0x0008EB6C
		public KeyContainerPermissionFlags Flags
		{
			get
			{
				return this.m_flags;
			}
			set
			{
				KeyContainerPermission.VerifyFlags(value);
				this.m_flags = value;
			}
		}

		// Token: 0x060027C3 RID: 10179 RVA: 0x0009097C File Offset: 0x0008EB7C
		public override bool Equals(object o)
		{
			KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry = o as KeyContainerPermissionAccessEntry;
			return keyContainerPermissionAccessEntry != null && !(keyContainerPermissionAccessEntry.m_keyStore != this.m_keyStore) && !(keyContainerPermissionAccessEntry.m_providerName != this.m_providerName) && keyContainerPermissionAccessEntry.m_providerType == this.m_providerType && !(keyContainerPermissionAccessEntry.m_keyContainerName != this.m_keyContainerName) && keyContainerPermissionAccessEntry.m_keySpec == this.m_keySpec;
		}

		// Token: 0x060027C4 RID: 10180 RVA: 0x000909F8 File Offset: 0x0008EBF8
		public override int GetHashCode()
		{
			int num = 0;
			num |= (this.m_keyStore.GetHashCode() & 255) << 24;
			num |= (this.m_providerName.GetHashCode() & 255) << 16;
			num |= (this.m_providerType & 15) << 12;
			num |= (this.m_keyContainerName.GetHashCode() & 255) << 4;
			return num | (this.m_keySpec & 15);
		}

		// Token: 0x060027C5 RID: 10181 RVA: 0x00090A68 File Offset: 0x0008EC68
		internal bool IsSubsetOf(KeyContainerPermissionAccessEntry target)
		{
			return (!(target.m_keyStore != "*") || !(this.m_keyStore != target.m_keyStore)) && (!(target.m_providerName != "*") || !(this.m_providerName != target.m_providerName)) && (target.m_providerType == -1 || this.m_providerType == target.m_providerType) && (!(target.m_keyContainerName != "*") || !(this.m_keyContainerName != target.m_keyContainerName)) && (target.m_keySpec == -1 || this.m_keySpec == target.m_keySpec);
		}

		// Token: 0x060027C6 RID: 10182 RVA: 0x00090B20 File Offset: 0x0008ED20
		internal static bool IsUnrestrictedEntry(string keyStore, string providerName, int providerType, string keyContainerName, int keySpec)
		{
			return (!(keyStore != "*") || keyStore == null) && (!(providerName != "*") || providerName == null) && providerType == -1 && (!(keyContainerName != "*") || keyContainerName == null) && keySpec == -1;
		}

		// Token: 0x04000F62 RID: 3938
		private string m_keyStore;

		// Token: 0x04000F63 RID: 3939
		private string m_providerName;

		// Token: 0x04000F64 RID: 3940
		private int m_providerType;

		// Token: 0x04000F65 RID: 3941
		private string m_keyContainerName;

		// Token: 0x04000F66 RID: 3942
		private int m_keySpec;

		// Token: 0x04000F67 RID: 3943
		private KeyContainerPermissionFlags m_flags;
	}
}
