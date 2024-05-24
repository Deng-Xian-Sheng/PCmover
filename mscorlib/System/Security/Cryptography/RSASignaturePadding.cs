using System;

namespace System.Security.Cryptography
{
	// Token: 0x0200027D RID: 637
	public sealed class RSASignaturePadding : IEquatable<RSASignaturePadding>
	{
		// Token: 0x060022A3 RID: 8867 RVA: 0x0007CC0F File Offset: 0x0007AE0F
		private RSASignaturePadding(RSASignaturePaddingMode mode)
		{
			this._mode = mode;
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x060022A4 RID: 8868 RVA: 0x0007CC1E File Offset: 0x0007AE1E
		public static RSASignaturePadding Pkcs1
		{
			get
			{
				return RSASignaturePadding.s_pkcs1;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x060022A5 RID: 8869 RVA: 0x0007CC25 File Offset: 0x0007AE25
		public static RSASignaturePadding Pss
		{
			get
			{
				return RSASignaturePadding.s_pss;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x060022A6 RID: 8870 RVA: 0x0007CC2C File Offset: 0x0007AE2C
		public RSASignaturePaddingMode Mode
		{
			get
			{
				return this._mode;
			}
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x0007CC34 File Offset: 0x0007AE34
		public override int GetHashCode()
		{
			return this._mode.GetHashCode();
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x0007CC55 File Offset: 0x0007AE55
		public override bool Equals(object obj)
		{
			return this.Equals(obj as RSASignaturePadding);
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x0007CC63 File Offset: 0x0007AE63
		public bool Equals(RSASignaturePadding other)
		{
			return other != null && this._mode == other._mode;
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x0007CC7E File Offset: 0x0007AE7E
		public static bool operator ==(RSASignaturePadding left, RSASignaturePadding right)
		{
			if (left == null)
			{
				return right == null;
			}
			return left.Equals(right);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x0007CC8F File Offset: 0x0007AE8F
		public static bool operator !=(RSASignaturePadding left, RSASignaturePadding right)
		{
			return !(left == right);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x0007CC9C File Offset: 0x0007AE9C
		public override string ToString()
		{
			return this._mode.ToString();
		}

		// Token: 0x04000C91 RID: 3217
		private static readonly RSASignaturePadding s_pkcs1 = new RSASignaturePadding(RSASignaturePaddingMode.Pkcs1);

		// Token: 0x04000C92 RID: 3218
		private static readonly RSASignaturePadding s_pss = new RSASignaturePadding(RSASignaturePaddingMode.Pss);

		// Token: 0x04000C93 RID: 3219
		private readonly RSASignaturePaddingMode _mode;
	}
}
