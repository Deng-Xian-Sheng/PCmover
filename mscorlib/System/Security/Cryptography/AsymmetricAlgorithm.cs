﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000249 RID: 585
	[ComVisible(true)]
	public abstract class AsymmetricAlgorithm : IDisposable
	{
		// Token: 0x060020D2 RID: 8402 RVA: 0x00072BA7 File Offset: 0x00070DA7
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x00072BAF File Offset: 0x00070DAF
		public void Clear()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x00072BBE File Offset: 0x00070DBE
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x060020D5 RID: 8405 RVA: 0x00072BC0 File Offset: 0x00070DC0
		// (set) Token: 0x060020D6 RID: 8406 RVA: 0x00072BC8 File Offset: 0x00070DC8
		public virtual int KeySize
		{
			get
			{
				return this.KeySizeValue;
			}
			set
			{
				for (int i = 0; i < this.LegalKeySizesValue.Length; i++)
				{
					if (this.LegalKeySizesValue[i].SkipSize == 0)
					{
						if (this.LegalKeySizesValue[i].MinSize == value)
						{
							this.KeySizeValue = value;
							return;
						}
					}
					else
					{
						for (int j = this.LegalKeySizesValue[i].MinSize; j <= this.LegalKeySizesValue[i].MaxSize; j += this.LegalKeySizesValue[i].SkipSize)
						{
							if (j == value)
							{
								this.KeySizeValue = value;
								return;
							}
						}
					}
				}
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x060020D7 RID: 8407 RVA: 0x00072C5A File Offset: 0x00070E5A
		public virtual KeySizes[] LegalKeySizes
		{
			get
			{
				return (KeySizes[])this.LegalKeySizesValue.Clone();
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x060020D8 RID: 8408 RVA: 0x00072C6C File Offset: 0x00070E6C
		public virtual string SignatureAlgorithm
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x060020D9 RID: 8409 RVA: 0x00072C73 File Offset: 0x00070E73
		public virtual string KeyExchangeAlgorithm
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x00072C7A File Offset: 0x00070E7A
		public static AsymmetricAlgorithm Create()
		{
			return AsymmetricAlgorithm.Create("System.Security.Cryptography.AsymmetricAlgorithm");
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x00072C86 File Offset: 0x00070E86
		public static AsymmetricAlgorithm Create(string algName)
		{
			return (AsymmetricAlgorithm)CryptoConfig.CreateFromName(algName);
		}

		// Token: 0x060020DC RID: 8412 RVA: 0x00072C93 File Offset: 0x00070E93
		public virtual void FromXmlString(string xmlString)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060020DD RID: 8413 RVA: 0x00072C9A File Offset: 0x00070E9A
		public virtual string ToXmlString(bool includePrivateParameters)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000BE8 RID: 3048
		protected int KeySizeValue;

		// Token: 0x04000BE9 RID: 3049
		protected KeySizes[] LegalKeySizesValue;
	}
}
