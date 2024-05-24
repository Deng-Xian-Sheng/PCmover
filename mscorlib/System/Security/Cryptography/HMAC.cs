using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000261 RID: 609
	[ComVisible(true)]
	public abstract class HMAC : KeyedHashAlgorithm
	{
		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x060021A8 RID: 8616 RVA: 0x000773A7 File Offset: 0x000755A7
		// (set) Token: 0x060021A9 RID: 8617 RVA: 0x000773AF File Offset: 0x000755AF
		protected int BlockSizeValue
		{
			get
			{
				return this.blockSizeValue;
			}
			set
			{
				this.blockSizeValue = value;
			}
		}

		// Token: 0x060021AA RID: 8618 RVA: 0x000773B8 File Offset: 0x000755B8
		private void UpdateIOPadBuffers()
		{
			if (this.m_inner == null)
			{
				this.m_inner = new byte[this.BlockSizeValue];
			}
			if (this.m_outer == null)
			{
				this.m_outer = new byte[this.BlockSizeValue];
			}
			for (int i = 0; i < this.BlockSizeValue; i++)
			{
				this.m_inner[i] = 54;
				this.m_outer[i] = 92;
			}
			for (int i = 0; i < this.KeyValue.Length; i++)
			{
				byte[] inner = this.m_inner;
				int num = i;
				inner[num] ^= this.KeyValue[i];
				byte[] outer = this.m_outer;
				int num2 = i;
				outer[num2] ^= this.KeyValue[i];
			}
		}

		// Token: 0x060021AB RID: 8619 RVA: 0x00077464 File Offset: 0x00075664
		internal void InitializeKey(byte[] key)
		{
			this.m_inner = null;
			this.m_outer = null;
			if (key.Length > this.BlockSizeValue)
			{
				if (this.m_hash1 == null)
				{
					this.m_hash1 = this.InstantiateHash();
				}
				this.KeyValue = this.m_hash1.ComputeHash(key);
			}
			else
			{
				this.KeyValue = (byte[])key.Clone();
			}
			if (this.m_impl == null)
			{
				this.UpdateIOPadBuffers();
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060021AC RID: 8620 RVA: 0x000774D1 File Offset: 0x000756D1
		// (set) Token: 0x060021AD RID: 8621 RVA: 0x000774E3 File Offset: 0x000756E3
		public override byte[] Key
		{
			get
			{
				return (byte[])this.KeyValue.Clone();
			}
			set
			{
				if (this.m_hashing)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_HashKeySet"));
				}
				this.InitializeKey(value);
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060021AE RID: 8622 RVA: 0x00077504 File Offset: 0x00075704
		// (set) Token: 0x060021AF RID: 8623 RVA: 0x0007750C File Offset: 0x0007570C
		public string HashName
		{
			get
			{
				return this.m_hashName;
			}
			set
			{
				if (this.m_hashing)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_HashNameSet"));
				}
				if (this.m_impl != null && !string.Equals(this.m_hashName, value, StringComparison.OrdinalIgnoreCase))
				{
					this.ClearImpl();
				}
				this.m_hashName = value;
				if (this.m_impl == null)
				{
					this.m_hash1 = HashAlgorithm.Create(this.m_hashName);
					this.m_hash2 = HashAlgorithm.Create(this.m_hashName);
				}
			}
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x0007757F File Offset: 0x0007577F
		public new static HMAC Create()
		{
			return HMAC.Create("System.Security.Cryptography.HMAC");
		}

		// Token: 0x060021B1 RID: 8625 RVA: 0x0007758B File Offset: 0x0007578B
		public new static HMAC Create(string algorithmName)
		{
			return (HMAC)CryptoConfig.CreateFromName(algorithmName);
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x00077598 File Offset: 0x00075798
		public override void Initialize()
		{
			if (this.m_impl != null)
			{
				this.m_impl.Reset();
			}
			else
			{
				this.m_hash1.Initialize();
				this.m_hash2.Initialize();
			}
			this.m_hashing = false;
		}

		// Token: 0x060021B3 RID: 8627 RVA: 0x000775CC File Offset: 0x000757CC
		protected override void HashCore(byte[] rgb, int ib, int cb)
		{
			if (this.m_impl != null)
			{
				if (!this.m_hashing)
				{
					this.m_impl.SetKey(this.KeyValue);
					this.m_hashing = true;
				}
				if (cb > 0)
				{
					this.m_impl.AppendData(rgb, ib, cb);
					return;
				}
			}
			else
			{
				if (!this.m_hashing)
				{
					this.m_hash1.TransformBlock(this.m_inner, 0, this.m_inner.Length, this.m_inner, 0);
					this.m_hashing = true;
				}
				this.m_hash1.TransformBlock(rgb, ib, cb, rgb, ib);
			}
		}

		// Token: 0x060021B4 RID: 8628 RVA: 0x00077658 File Offset: 0x00075858
		protected override byte[] HashFinal()
		{
			if (this.m_impl != null)
			{
				if (!this.m_hashing)
				{
					this.m_impl.SetKey(this.KeyValue);
				}
				byte[] array = new byte[this.HashSizeValue >> 3];
				this.m_impl.Finish(array);
				this.m_hashing = false;
				return array;
			}
			if (!this.m_hashing)
			{
				this.m_hash1.TransformBlock(this.m_inner, 0, this.m_inner.Length, this.m_inner, 0);
				this.m_hashing = true;
			}
			this.m_hash1.TransformFinalBlock(EmptyArray<byte>.Value, 0, 0);
			byte[] hashValue = this.m_hash1.HashValue;
			this.m_hash2.TransformBlock(this.m_outer, 0, this.m_outer.Length, this.m_outer, 0);
			this.m_hash2.TransformBlock(hashValue, 0, hashValue.Length, hashValue, 0);
			this.m_hashing = false;
			this.m_hash2.TransformFinalBlock(EmptyArray<byte>.Value, 0, 0);
			return this.m_hash2.HashValue;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x00077754 File Offset: 0x00075954
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.m_impl != null)
				{
					this.m_impl.Dispose();
				}
				if (this.m_hash1 != null)
				{
					((IDisposable)this.m_hash1).Dispose();
				}
				if (this.m_hash2 != null)
				{
					((IDisposable)this.m_hash2).Dispose();
				}
				if (this.m_inner != null)
				{
					Array.Clear(this.m_inner, 0, this.m_inner.Length);
				}
				if (this.m_outer != null)
				{
					Array.Clear(this.m_outer, 0, this.m_outer.Length);
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x060021B6 RID: 8630 RVA: 0x000777DC File Offset: 0x000759DC
		internal virtual HashAlgorithm InstantiateHash()
		{
			return null;
		}

		// Token: 0x060021B7 RID: 8631 RVA: 0x000777E0 File Offset: 0x000759E0
		internal void ClearImpl()
		{
			if (this.m_impl == null)
			{
				return;
			}
			this.m_impl.Dispose();
			this.m_impl = null;
			this.m_hash1 = this.InstantiateHash();
			this.m_hash2 = this.InstantiateHash();
			if (this.KeyValue != null)
			{
				this.UpdateIOPadBuffers();
			}
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x00077830 File Offset: 0x00075A30
		internal static HashAlgorithm GetHashAlgorithmWithFipsFallback(Func<HashAlgorithm> createStandardHashAlgorithmCallback, Func<HashAlgorithm> createFipsHashAlgorithmCallback)
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms)
			{
				try
				{
					return createFipsHashAlgorithmCallback();
				}
				catch (PlatformNotSupportedException ex)
				{
					throw new InvalidOperationException(ex.Message, ex);
				}
			}
			return createStandardHashAlgorithmCallback();
		}

		// Token: 0x04000C46 RID: 3142
		private int blockSizeValue = 64;

		// Token: 0x04000C47 RID: 3143
		internal string m_hashName;

		// Token: 0x04000C48 RID: 3144
		internal HashAlgorithm m_hash1;

		// Token: 0x04000C49 RID: 3145
		internal HashAlgorithm m_hash2;

		// Token: 0x04000C4A RID: 3146
		internal NativeHmac m_impl;

		// Token: 0x04000C4B RID: 3147
		private byte[] m_inner;

		// Token: 0x04000C4C RID: 3148
		private byte[] m_outer;

		// Token: 0x04000C4D RID: 3149
		internal bool m_hashing;
	}
}
