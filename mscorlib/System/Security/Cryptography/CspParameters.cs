using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace System.Security.Cryptography
{
	// Token: 0x02000254 RID: 596
	[ComVisible(true)]
	public sealed class CspParameters
	{
		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06002118 RID: 8472 RVA: 0x00073889 File Offset: 0x00071A89
		// (set) Token: 0x06002119 RID: 8473 RVA: 0x00073894 File Offset: 0x00071A94
		public CspProviderFlags Flags
		{
			get
			{
				return (CspProviderFlags)this.m_flags;
			}
			set
			{
				int num = 255;
				if ((value & (CspProviderFlags)(~(CspProviderFlags)num)) != CspProviderFlags.NoFlags)
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
					{
						(int)value
					}), "value");
				}
				this.m_flags = (int)value;
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x0600211A RID: 8474 RVA: 0x000738DA File Offset: 0x00071ADA
		// (set) Token: 0x0600211B RID: 8475 RVA: 0x000738E2 File Offset: 0x00071AE2
		public CryptoKeySecurity CryptoKeySecurity
		{
			get
			{
				return this.m_cryptoKeySecurity;
			}
			set
			{
				this.m_cryptoKeySecurity = value;
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x0600211C RID: 8476 RVA: 0x000738EB File Offset: 0x00071AEB
		// (set) Token: 0x0600211D RID: 8477 RVA: 0x000738F3 File Offset: 0x00071AF3
		public SecureString KeyPassword
		{
			get
			{
				return this.m_keyPassword;
			}
			set
			{
				this.m_keyPassword = value;
				this.m_parentWindowHandle = IntPtr.Zero;
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x0600211E RID: 8478 RVA: 0x00073907 File Offset: 0x00071B07
		// (set) Token: 0x0600211F RID: 8479 RVA: 0x0007390F File Offset: 0x00071B0F
		public IntPtr ParentWindowHandle
		{
			get
			{
				return this.m_parentWindowHandle;
			}
			set
			{
				this.m_parentWindowHandle = value;
				this.m_keyPassword = null;
			}
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x0007391F File Offset: 0x00071B1F
		public CspParameters() : this(24, null, null)
		{
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x0007392B File Offset: 0x00071B2B
		public CspParameters(int dwTypeIn) : this(dwTypeIn, null, null)
		{
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x00073936 File Offset: 0x00071B36
		public CspParameters(int dwTypeIn, string strProviderNameIn) : this(dwTypeIn, strProviderNameIn, null)
		{
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x00073941 File Offset: 0x00071B41
		public CspParameters(int dwTypeIn, string strProviderNameIn, string strContainerNameIn) : this(dwTypeIn, strProviderNameIn, strContainerNameIn, CspProviderFlags.NoFlags)
		{
		}

		// Token: 0x06002124 RID: 8484 RVA: 0x0007394D File Offset: 0x00071B4D
		public CspParameters(int providerType, string providerName, string keyContainerName, CryptoKeySecurity cryptoKeySecurity, SecureString keyPassword) : this(providerType, providerName, keyContainerName)
		{
			this.m_cryptoKeySecurity = cryptoKeySecurity;
			this.m_keyPassword = keyPassword;
		}

		// Token: 0x06002125 RID: 8485 RVA: 0x00073968 File Offset: 0x00071B68
		public CspParameters(int providerType, string providerName, string keyContainerName, CryptoKeySecurity cryptoKeySecurity, IntPtr parentWindowHandle) : this(providerType, providerName, keyContainerName)
		{
			this.m_cryptoKeySecurity = cryptoKeySecurity;
			this.m_parentWindowHandle = parentWindowHandle;
		}

		// Token: 0x06002126 RID: 8486 RVA: 0x00073983 File Offset: 0x00071B83
		internal CspParameters(int providerType, string providerName, string keyContainerName, CspProviderFlags flags)
		{
			this.ProviderType = providerType;
			this.ProviderName = providerName;
			this.KeyContainerName = keyContainerName;
			this.KeyNumber = -1;
			this.Flags = flags;
		}

		// Token: 0x06002127 RID: 8487 RVA: 0x000739B0 File Offset: 0x00071BB0
		internal CspParameters(CspParameters parameters)
		{
			this.ProviderType = parameters.ProviderType;
			this.ProviderName = parameters.ProviderName;
			this.KeyContainerName = parameters.KeyContainerName;
			this.KeyNumber = parameters.KeyNumber;
			this.Flags = parameters.Flags;
			this.m_cryptoKeySecurity = parameters.m_cryptoKeySecurity;
			this.m_keyPassword = parameters.m_keyPassword;
			this.m_parentWindowHandle = parameters.m_parentWindowHandle;
		}

		// Token: 0x04000C06 RID: 3078
		public int ProviderType;

		// Token: 0x04000C07 RID: 3079
		public string ProviderName;

		// Token: 0x04000C08 RID: 3080
		public string KeyContainerName;

		// Token: 0x04000C09 RID: 3081
		public int KeyNumber;

		// Token: 0x04000C0A RID: 3082
		private int m_flags;

		// Token: 0x04000C0B RID: 3083
		private CryptoKeySecurity m_cryptoKeySecurity;

		// Token: 0x04000C0C RID: 3084
		private SecureString m_keyPassword;

		// Token: 0x04000C0D RID: 3085
		private IntPtr m_parentWindowHandle;
	}
}
