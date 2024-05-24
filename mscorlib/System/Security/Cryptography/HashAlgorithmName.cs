using System;

namespace System.Security.Cryptography
{
	// Token: 0x02000269 RID: 617
	public struct HashAlgorithmName : IEquatable<HashAlgorithmName>
	{
		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060021E6 RID: 8678 RVA: 0x0007816C File Offset: 0x0007636C
		public static HashAlgorithmName MD5
		{
			get
			{
				return new HashAlgorithmName("MD5");
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x060021E7 RID: 8679 RVA: 0x00078178 File Offset: 0x00076378
		public static HashAlgorithmName SHA1
		{
			get
			{
				return new HashAlgorithmName("SHA1");
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x060021E8 RID: 8680 RVA: 0x00078184 File Offset: 0x00076384
		public static HashAlgorithmName SHA256
		{
			get
			{
				return new HashAlgorithmName("SHA256");
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060021E9 RID: 8681 RVA: 0x00078190 File Offset: 0x00076390
		public static HashAlgorithmName SHA384
		{
			get
			{
				return new HashAlgorithmName("SHA384");
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060021EA RID: 8682 RVA: 0x0007819C File Offset: 0x0007639C
		public static HashAlgorithmName SHA512
		{
			get
			{
				return new HashAlgorithmName("SHA512");
			}
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x000781A8 File Offset: 0x000763A8
		public HashAlgorithmName(string name)
		{
			this._name = name;
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060021EC RID: 8684 RVA: 0x000781B1 File Offset: 0x000763B1
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x000781B9 File Offset: 0x000763B9
		public override string ToString()
		{
			return this._name ?? string.Empty;
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x000781CA File Offset: 0x000763CA
		public override bool Equals(object obj)
		{
			return obj is HashAlgorithmName && this.Equals((HashAlgorithmName)obj);
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x000781E2 File Offset: 0x000763E2
		public bool Equals(HashAlgorithmName other)
		{
			return this._name == other._name;
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x000781F5 File Offset: 0x000763F5
		public override int GetHashCode()
		{
			if (this._name != null)
			{
				return this._name.GetHashCode();
			}
			return 0;
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x0007820C File Offset: 0x0007640C
		public static bool operator ==(HashAlgorithmName left, HashAlgorithmName right)
		{
			return left.Equals(right);
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x00078216 File Offset: 0x00076416
		public static bool operator !=(HashAlgorithmName left, HashAlgorithmName right)
		{
			return !(left == right);
		}

		// Token: 0x04000C54 RID: 3156
		private readonly string _name;
	}
}
