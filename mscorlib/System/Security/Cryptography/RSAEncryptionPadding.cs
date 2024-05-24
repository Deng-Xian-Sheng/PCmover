using System;

namespace System.Security.Cryptography
{
	// Token: 0x02000281 RID: 641
	public sealed class RSAEncryptionPadding : IEquatable<RSAEncryptionPadding>
	{
		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x060022DD RID: 8925 RVA: 0x0007D895 File Offset: 0x0007BA95
		public static RSAEncryptionPadding Pkcs1
		{
			get
			{
				return RSAEncryptionPadding.s_pkcs1;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x060022DE RID: 8926 RVA: 0x0007D89C File Offset: 0x0007BA9C
		public static RSAEncryptionPadding OaepSHA1
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA1;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x060022DF RID: 8927 RVA: 0x0007D8A3 File Offset: 0x0007BAA3
		public static RSAEncryptionPadding OaepSHA256
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA256;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x060022E0 RID: 8928 RVA: 0x0007D8AA File Offset: 0x0007BAAA
		public static RSAEncryptionPadding OaepSHA384
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA384;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060022E1 RID: 8929 RVA: 0x0007D8B1 File Offset: 0x0007BAB1
		public static RSAEncryptionPadding OaepSHA512
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA512;
			}
		}

		// Token: 0x060022E2 RID: 8930 RVA: 0x0007D8B8 File Offset: 0x0007BAB8
		private RSAEncryptionPadding(RSAEncryptionPaddingMode mode, HashAlgorithmName oaepHashAlgorithm)
		{
			this._mode = mode;
			this._oaepHashAlgorithm = oaepHashAlgorithm;
		}

		// Token: 0x060022E3 RID: 8931 RVA: 0x0007D8CE File Offset: 0x0007BACE
		public static RSAEncryptionPadding CreateOaep(HashAlgorithmName hashAlgorithm)
		{
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw new ArgumentException(Environment.GetResourceString("Cryptography_HashAlgorithmNameNullOrEmpty"), "hashAlgorithm");
			}
			return new RSAEncryptionPadding(RSAEncryptionPaddingMode.Oaep, hashAlgorithm);
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060022E4 RID: 8932 RVA: 0x0007D8FA File Offset: 0x0007BAFA
		public RSAEncryptionPaddingMode Mode
		{
			get
			{
				return this._mode;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060022E5 RID: 8933 RVA: 0x0007D902 File Offset: 0x0007BB02
		public HashAlgorithmName OaepHashAlgorithm
		{
			get
			{
				return this._oaepHashAlgorithm;
			}
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x0007D90A File Offset: 0x0007BB0A
		public override int GetHashCode()
		{
			return RSAEncryptionPadding.CombineHashCodes(this._mode.GetHashCode(), this._oaepHashAlgorithm.GetHashCode());
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x0007D933 File Offset: 0x0007BB33
		private static int CombineHashCodes(int h1, int h2)
		{
			return (h1 << 5) + h1 ^ h2;
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x0007D93C File Offset: 0x0007BB3C
		public override bool Equals(object obj)
		{
			return this.Equals(obj as RSAEncryptionPadding);
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x0007D94A File Offset: 0x0007BB4A
		public bool Equals(RSAEncryptionPadding other)
		{
			return other != null && this._mode == other._mode && this._oaepHashAlgorithm == other._oaepHashAlgorithm;
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x0007D976 File Offset: 0x0007BB76
		public static bool operator ==(RSAEncryptionPadding left, RSAEncryptionPadding right)
		{
			if (left == null)
			{
				return right == null;
			}
			return left.Equals(right);
		}

		// Token: 0x060022EB RID: 8939 RVA: 0x0007D987 File Offset: 0x0007BB87
		public static bool operator !=(RSAEncryptionPadding left, RSAEncryptionPadding right)
		{
			return !(left == right);
		}

		// Token: 0x060022EC RID: 8940 RVA: 0x0007D993 File Offset: 0x0007BB93
		public override string ToString()
		{
			return this._mode.ToString() + this._oaepHashAlgorithm.Name;
		}

		// Token: 0x04000CA5 RID: 3237
		private static readonly RSAEncryptionPadding s_pkcs1 = new RSAEncryptionPadding(RSAEncryptionPaddingMode.Pkcs1, default(HashAlgorithmName));

		// Token: 0x04000CA6 RID: 3238
		private static readonly RSAEncryptionPadding s_oaepSHA1 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA1);

		// Token: 0x04000CA7 RID: 3239
		private static readonly RSAEncryptionPadding s_oaepSHA256 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA256);

		// Token: 0x04000CA8 RID: 3240
		private static readonly RSAEncryptionPadding s_oaepSHA384 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA384);

		// Token: 0x04000CA9 RID: 3241
		private static readonly RSAEncryptionPadding s_oaepSHA512 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA512);

		// Token: 0x04000CAA RID: 3242
		private RSAEncryptionPaddingMode _mode;

		// Token: 0x04000CAB RID: 3243
		private HashAlgorithmName _oaepHashAlgorithm;
	}
}
