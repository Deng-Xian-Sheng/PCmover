using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace System.Security.Cryptography
{
	// Token: 0x02000288 RID: 648
	[ComVisible(true)]
	public class RSAPKCS1SignatureFormatter : AsymmetricSignatureFormatter
	{
		// Token: 0x06002318 RID: 8984 RVA: 0x0007E146 File Offset: 0x0007C346
		public RSAPKCS1SignatureFormatter()
		{
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x0007E14E File Offset: 0x0007C34E
		public RSAPKCS1SignatureFormatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		// Token: 0x0600231A RID: 8986 RVA: 0x0007E170 File Offset: 0x0007C370
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesSignHash = null;
		}

		// Token: 0x0600231B RID: 8987 RVA: 0x0007E198 File Offset: 0x0007C398
		public override void SetHashAlgorithm(string strName)
		{
			this._strOID = CryptoConfig.MapNameToOID(strName, OidGroup.HashAlgorithm);
		}

		// Token: 0x0600231C RID: 8988 RVA: 0x0007E1A8 File Offset: 0x0007C3A8
		[SecuritySafeCritical]
		public override byte[] CreateSignature(byte[] rgbHash)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (this._strOID == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingOID"));
			}
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			if (this._rsaKey is RSACryptoServiceProvider)
			{
				int algIdFromOid = X509Utils.GetAlgIdFromOid(this._strOID, OidGroup.HashAlgorithm);
				return ((RSACryptoServiceProvider)this._rsaKey).SignHash(rgbHash, algIdFromOid);
			}
			if (this.OverridesSignHash)
			{
				HashAlgorithmName hashAlgorithm = Utils.OidToHashAlgorithmName(this._strOID);
				return this._rsaKey.SignHash(rgbHash, hashAlgorithm, RSASignaturePadding.Pkcs1);
			}
			byte[] rgb = Utils.RsaPkcs1Padding(this._rsaKey, CryptoConfig.EncodeOID(this._strOID), rgbHash);
			return this._rsaKey.DecryptValue(rgb);
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x0600231D RID: 8989 RVA: 0x0007E26C File Offset: 0x0007C46C
		private bool OverridesSignHash
		{
			get
			{
				if (this._rsaOverridesSignHash == null)
				{
					this._rsaOverridesSignHash = new bool?(Utils.DoesRsaKeyOverride(this._rsaKey, "SignHash", new Type[]
					{
						typeof(byte[]),
						typeof(HashAlgorithmName),
						typeof(RSASignaturePadding)
					}));
				}
				return this._rsaOverridesSignHash.Value;
			}
		}

		// Token: 0x04000CBE RID: 3262
		private RSA _rsaKey;

		// Token: 0x04000CBF RID: 3263
		private string _strOID;

		// Token: 0x04000CC0 RID: 3264
		private bool? _rsaOverridesSignHash;
	}
}
