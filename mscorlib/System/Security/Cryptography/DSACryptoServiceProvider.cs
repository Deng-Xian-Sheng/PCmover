﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Security.Cryptography
{
	// Token: 0x0200025E RID: 606
	[ComVisible(true)]
	public sealed class DSACryptoServiceProvider : DSA, ICspAsymmetricAlgorithm
	{
		// Token: 0x0600217D RID: 8573 RVA: 0x000769B4 File Offset: 0x00074BB4
		public DSACryptoServiceProvider() : this(0, new CspParameters(13, null, null, DSACryptoServiceProvider.s_UseMachineKeyStore))
		{
		}

		// Token: 0x0600217E RID: 8574 RVA: 0x000769CD File Offset: 0x00074BCD
		public DSACryptoServiceProvider(int dwKeySize) : this(dwKeySize, new CspParameters(13, null, null, DSACryptoServiceProvider.s_UseMachineKeyStore))
		{
		}

		// Token: 0x0600217F RID: 8575 RVA: 0x000769E6 File Offset: 0x00074BE6
		public DSACryptoServiceProvider(CspParameters parameters) : this(0, parameters)
		{
		}

		// Token: 0x06002180 RID: 8576 RVA: 0x000769F0 File Offset: 0x00074BF0
		[SecuritySafeCritical]
		public DSACryptoServiceProvider(int dwKeySize, CspParameters parameters)
		{
			if (dwKeySize < 0)
			{
				throw new ArgumentOutOfRangeException("dwKeySize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this._parameters = Utils.SaveCspParameters(CspAlgorithmType.Dss, parameters, DSACryptoServiceProvider.s_UseMachineKeyStore, ref this._randomKeyContainer);
			this.LegalKeySizesValue = new KeySizes[]
			{
				new KeySizes(512, 1024, 64)
			};
			this._dwKeySize = dwKeySize;
			this._sha1 = new SHA1CryptoServiceProvider();
			if (!this._randomKeyContainer || Environment.GetCompatibilityFlag(CompatibilityFlag.EagerlyGenerateRandomAsymmKeys))
			{
				this.GetKeyPair();
			}
		}

		// Token: 0x06002181 RID: 8577 RVA: 0x00076A80 File Offset: 0x00074C80
		[SecurityCritical]
		private void GetKeyPair()
		{
			if (this._safeKeyHandle == null)
			{
				lock (this)
				{
					if (this._safeKeyHandle == null)
					{
						Utils.GetKeyPairHelper(CspAlgorithmType.Dss, this._parameters, this._randomKeyContainer, this._dwKeySize, ref this._safeProvHandle, ref this._safeKeyHandle);
					}
				}
			}
		}

		// Token: 0x06002182 RID: 8578 RVA: 0x00076AEC File Offset: 0x00074CEC
		[SecuritySafeCritical]
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (this._safeKeyHandle != null && !this._safeKeyHandle.IsClosed)
			{
				this._safeKeyHandle.Dispose();
			}
			if (this._safeProvHandle != null && !this._safeProvHandle.IsClosed)
			{
				this._safeProvHandle.Dispose();
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06002183 RID: 8579 RVA: 0x00076B40 File Offset: 0x00074D40
		[ComVisible(false)]
		public bool PublicOnly
		{
			[SecuritySafeCritical]
			get
			{
				this.GetKeyPair();
				byte[] array = Utils._GetKeyParameter(this._safeKeyHandle, 2U);
				return array[0] == 1;
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06002184 RID: 8580 RVA: 0x00076B66 File Offset: 0x00074D66
		[ComVisible(false)]
		public CspKeyContainerInfo CspKeyContainerInfo
		{
			[SecuritySafeCritical]
			get
			{
				this.GetKeyPair();
				return new CspKeyContainerInfo(this._parameters, this._randomKeyContainer);
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06002185 RID: 8581 RVA: 0x00076B80 File Offset: 0x00074D80
		public override int KeySize
		{
			[SecuritySafeCritical]
			get
			{
				this.GetKeyPair();
				byte[] array = Utils._GetKeyParameter(this._safeKeyHandle, 1U);
				this._dwKeySize = ((int)array[0] | (int)array[1] << 8 | (int)array[2] << 16 | (int)array[3] << 24);
				return this._dwKeySize;
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06002186 RID: 8582 RVA: 0x00076BC3 File Offset: 0x00074DC3
		public override string KeyExchangeAlgorithm
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06002187 RID: 8583 RVA: 0x00076BC6 File Offset: 0x00074DC6
		public override string SignatureAlgorithm
		{
			get
			{
				return "http://www.w3.org/2000/09/xmldsig#dsa-sha1";
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06002188 RID: 8584 RVA: 0x00076BCD File Offset: 0x00074DCD
		// (set) Token: 0x06002189 RID: 8585 RVA: 0x00076BD9 File Offset: 0x00074DD9
		public static bool UseMachineKeyStore
		{
			get
			{
				return DSACryptoServiceProvider.s_UseMachineKeyStore == CspProviderFlags.UseMachineKeyStore;
			}
			set
			{
				DSACryptoServiceProvider.s_UseMachineKeyStore = (value ? CspProviderFlags.UseMachineKeyStore : CspProviderFlags.NoFlags);
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x0600218A RID: 8586 RVA: 0x00076BEC File Offset: 0x00074DEC
		// (set) Token: 0x0600218B RID: 8587 RVA: 0x00076C54 File Offset: 0x00074E54
		public bool PersistKeyInCsp
		{
			[SecuritySafeCritical]
			get
			{
				if (this._safeProvHandle == null)
				{
					lock (this)
					{
						if (this._safeProvHandle == null)
						{
							this._safeProvHandle = Utils.CreateProvHandle(this._parameters, this._randomKeyContainer);
						}
					}
				}
				return Utils.GetPersistKeyInCsp(this._safeProvHandle);
			}
			[SecuritySafeCritical]
			set
			{
				bool persistKeyInCsp = this.PersistKeyInCsp;
				if (value == persistKeyInCsp)
				{
					return;
				}
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
				if (!value)
				{
					KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Delete);
					keyContainerPermission.AccessEntries.Add(accessEntry);
				}
				else
				{
					KeyContainerPermissionAccessEntry accessEntry2 = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Create);
					keyContainerPermission.AccessEntries.Add(accessEntry2);
				}
				keyContainerPermission.Demand();
				Utils.SetPersistKeyInCsp(this._safeProvHandle, value);
			}
		}

		// Token: 0x0600218C RID: 8588 RVA: 0x00076CC0 File Offset: 0x00074EC0
		[SecuritySafeCritical]
		public override DSAParameters ExportParameters(bool includePrivateParameters)
		{
			this.GetKeyPair();
			if (includePrivateParameters)
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
				KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Export);
				keyContainerPermission.AccessEntries.Add(accessEntry);
				keyContainerPermission.Demand();
			}
			DSACspObject dsacspObject = new DSACspObject();
			int blobType = includePrivateParameters ? 7 : 6;
			Utils._ExportKey(this._safeKeyHandle, blobType, dsacspObject);
			return DSACryptoServiceProvider.DSAObjectToStruct(dsacspObject);
		}

		// Token: 0x0600218D RID: 8589 RVA: 0x00076D1F File Offset: 0x00074F1F
		[SecuritySafeCritical]
		[ComVisible(false)]
		public byte[] ExportCspBlob(bool includePrivateParameters)
		{
			this.GetKeyPair();
			return Utils.ExportCspBlobHelper(includePrivateParameters, this._parameters, this._safeKeyHandle);
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x00076D3C File Offset: 0x00074F3C
		[SecuritySafeCritical]
		public override void ImportParameters(DSAParameters parameters)
		{
			DSACspObject cspObject = DSACryptoServiceProvider.DSAStructToObject(parameters);
			if (this._safeKeyHandle != null && !this._safeKeyHandle.IsClosed)
			{
				this._safeKeyHandle.Dispose();
			}
			this._safeKeyHandle = SafeKeyHandle.InvalidHandle;
			if (DSACryptoServiceProvider.IsPublic(parameters))
			{
				Utils._ImportKey(Utils.StaticDssProvHandle, 8704, CspProviderFlags.NoFlags, cspObject, ref this._safeKeyHandle);
				return;
			}
			KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
			KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Import);
			keyContainerPermission.AccessEntries.Add(accessEntry);
			keyContainerPermission.Demand();
			if (this._safeProvHandle == null)
			{
				this._safeProvHandle = Utils.CreateProvHandle(this._parameters, this._randomKeyContainer);
			}
			Utils._ImportKey(this._safeProvHandle, 8704, this._parameters.Flags, cspObject, ref this._safeKeyHandle);
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x00076E04 File Offset: 0x00075004
		[SecuritySafeCritical]
		[ComVisible(false)]
		public void ImportCspBlob(byte[] keyBlob)
		{
			Utils.ImportCspBlobHelper(CspAlgorithmType.Dss, keyBlob, DSACryptoServiceProvider.IsPublic(keyBlob), ref this._parameters, this._randomKeyContainer, ref this._safeProvHandle, ref this._safeKeyHandle);
		}

		// Token: 0x06002190 RID: 8592 RVA: 0x00076E2C File Offset: 0x0007502C
		public byte[] SignData(Stream inputStream)
		{
			byte[] rgbHash = this._sha1.ComputeHash(inputStream);
			return this.SignHash(rgbHash, null);
		}

		// Token: 0x06002191 RID: 8593 RVA: 0x00076E50 File Offset: 0x00075050
		public byte[] SignData(byte[] buffer)
		{
			byte[] rgbHash = this._sha1.ComputeHash(buffer);
			return this.SignHash(rgbHash, null);
		}

		// Token: 0x06002192 RID: 8594 RVA: 0x00076E74 File Offset: 0x00075074
		public byte[] SignData(byte[] buffer, int offset, int count)
		{
			byte[] rgbHash = this._sha1.ComputeHash(buffer, offset, count);
			return this.SignHash(rgbHash, null);
		}

		// Token: 0x06002193 RID: 8595 RVA: 0x00076E98 File Offset: 0x00075098
		public bool VerifyData(byte[] rgbData, byte[] rgbSignature)
		{
			byte[] rgbHash = this._sha1.ComputeHash(rgbData);
			return this.VerifyHash(rgbHash, null, rgbSignature);
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x00076EBB File Offset: 0x000750BB
		public override byte[] CreateSignature(byte[] rgbHash)
		{
			return this.SignHash(rgbHash, null);
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x00076EC5 File Offset: 0x000750C5
		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature)
		{
			return this.VerifyHash(rgbHash, null, rgbSignature);
		}

		// Token: 0x06002196 RID: 8598 RVA: 0x00076ED0 File Offset: 0x000750D0
		protected override byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm)
		{
			if (hashAlgorithm != HashAlgorithmName.SHA1)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_UnknownHashAlgorithm", new object[]
				{
					hashAlgorithm.Name
				}));
			}
			return this._sha1.ComputeHash(data, offset, count);
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x00076F0E File Offset: 0x0007510E
		protected override byte[] HashData(Stream data, HashAlgorithmName hashAlgorithm)
		{
			if (hashAlgorithm != HashAlgorithmName.SHA1)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_UnknownHashAlgorithm", new object[]
				{
					hashAlgorithm.Name
				}));
			}
			return this._sha1.ComputeHash(data);
		}

		// Token: 0x06002198 RID: 8600 RVA: 0x00076F4C File Offset: 0x0007514C
		[SecuritySafeCritical]
		public byte[] SignHash(byte[] rgbHash, string str)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (this.PublicOnly)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_NoPrivateKey"));
			}
			int calgHash = X509Utils.NameOrOidToAlgId(str, OidGroup.HashAlgorithm);
			if (rgbHash.Length != this._sha1.HashSize / 8)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidHashSize", new object[]
				{
					"SHA1",
					this._sha1.HashSize / 8
				}));
			}
			this.GetKeyPair();
			if (!this.CspKeyContainerInfo.RandomlyGenerated)
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
				KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Sign);
				keyContainerPermission.AccessEntries.Add(accessEntry);
				keyContainerPermission.Demand();
			}
			return Utils.SignValue(this._safeKeyHandle, this._parameters.KeyNumber, 8704, calgHash, rgbHash);
		}

		// Token: 0x06002199 RID: 8601 RVA: 0x00077028 File Offset: 0x00075228
		[SecuritySafeCritical]
		public bool VerifyHash(byte[] rgbHash, string str, byte[] rgbSignature)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (rgbSignature == null)
			{
				throw new ArgumentNullException("rgbSignature");
			}
			int calgHash = X509Utils.NameOrOidToAlgId(str, OidGroup.HashAlgorithm);
			if (rgbHash.Length != this._sha1.HashSize / 8)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidHashSize", new object[]
				{
					"SHA1",
					this._sha1.HashSize / 8
				}));
			}
			this.GetKeyPair();
			return Utils.VerifySign(this._safeKeyHandle, 8704, calgHash, rgbHash, rgbSignature);
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x000770B8 File Offset: 0x000752B8
		private static DSAParameters DSAObjectToStruct(DSACspObject dsaCspObject)
		{
			return new DSAParameters
			{
				P = dsaCspObject.P,
				Q = dsaCspObject.Q,
				G = dsaCspObject.G,
				Y = dsaCspObject.Y,
				J = dsaCspObject.J,
				X = dsaCspObject.X,
				Seed = dsaCspObject.Seed,
				Counter = dsaCspObject.Counter
			};
		}

		// Token: 0x0600219B RID: 8603 RVA: 0x00077138 File Offset: 0x00075338
		private static DSACspObject DSAStructToObject(DSAParameters dsaParams)
		{
			return new DSACspObject
			{
				P = dsaParams.P,
				Q = dsaParams.Q,
				G = dsaParams.G,
				Y = dsaParams.Y,
				J = dsaParams.J,
				X = dsaParams.X,
				Seed = dsaParams.Seed,
				Counter = dsaParams.Counter
			};
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x000771AC File Offset: 0x000753AC
		private static bool IsPublic(DSAParameters dsaParams)
		{
			return dsaParams.X == null;
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x000771B8 File Offset: 0x000753B8
		private static bool IsPublic(byte[] keyBlob)
		{
			if (keyBlob == null)
			{
				throw new ArgumentNullException("keyBlob");
			}
			return keyBlob[0] == 6 && (keyBlob[11] == 49 || keyBlob[11] == 51) && keyBlob[10] == 83 && keyBlob[9] == 83 && keyBlob[8] == 68;
		}

		// Token: 0x04000C3B RID: 3131
		private int _dwKeySize;

		// Token: 0x04000C3C RID: 3132
		private CspParameters _parameters;

		// Token: 0x04000C3D RID: 3133
		private bool _randomKeyContainer;

		// Token: 0x04000C3E RID: 3134
		[SecurityCritical]
		private SafeProvHandle _safeProvHandle;

		// Token: 0x04000C3F RID: 3135
		[SecurityCritical]
		private SafeKeyHandle _safeKeyHandle;

		// Token: 0x04000C40 RID: 3136
		private SHA1CryptoServiceProvider _sha1;

		// Token: 0x04000C41 RID: 3137
		private static volatile CspProviderFlags s_UseMachineKeyStore;
	}
}
