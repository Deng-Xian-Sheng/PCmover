using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200026E RID: 622
	[ComVisible(true)]
	public class MACTripleDES : KeyedHashAlgorithm
	{
		// Token: 0x0600220C RID: 8716 RVA: 0x000786B8 File Offset: 0x000768B8
		public MACTripleDES()
		{
			this.KeyValue = new byte[24];
			Utils.StaticRandomNumberGenerator.GetBytes(this.KeyValue);
			this.des = TripleDES.Create();
			this.HashSizeValue = this.des.BlockSize;
			this.m_bytesPerBlock = this.des.BlockSize / 8;
			this.des.IV = new byte[this.m_bytesPerBlock];
			this.des.Padding = PaddingMode.Zeros;
			this.m_encryptor = null;
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x00078740 File Offset: 0x00076940
		public MACTripleDES(byte[] rgbKey) : this("System.Security.Cryptography.TripleDES", rgbKey)
		{
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x00078750 File Offset: 0x00076950
		public MACTripleDES(string strTripleDES, byte[] rgbKey)
		{
			if (rgbKey == null)
			{
				throw new ArgumentNullException("rgbKey");
			}
			if (strTripleDES == null)
			{
				this.des = TripleDES.Create();
			}
			else
			{
				this.des = TripleDES.Create(strTripleDES);
			}
			this.HashSizeValue = this.des.BlockSize;
			this.KeyValue = (byte[])rgbKey.Clone();
			this.m_bytesPerBlock = this.des.BlockSize / 8;
			this.des.IV = new byte[this.m_bytesPerBlock];
			this.des.Padding = PaddingMode.Zeros;
			this.m_encryptor = null;
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x000787EB File Offset: 0x000769EB
		public override void Initialize()
		{
			this.m_encryptor = null;
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06002210 RID: 8720 RVA: 0x000787F4 File Offset: 0x000769F4
		// (set) Token: 0x06002211 RID: 8721 RVA: 0x00078801 File Offset: 0x00076A01
		[ComVisible(false)]
		public PaddingMode Padding
		{
			get
			{
				return this.des.Padding;
			}
			set
			{
				if (value < PaddingMode.None || PaddingMode.ISO10126 < value)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidPaddingMode"));
				}
				this.des.Padding = value;
			}
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x00078828 File Offset: 0x00076A28
		protected override void HashCore(byte[] rgbData, int ibStart, int cbSize)
		{
			if (this.m_encryptor == null)
			{
				this.des.Key = this.Key;
				this.m_encryptor = this.des.CreateEncryptor();
				this._ts = new TailStream(this.des.BlockSize / 8);
				this._cs = new CryptoStream(this._ts, this.m_encryptor, CryptoStreamMode.Write);
			}
			this._cs.Write(rgbData, ibStart, cbSize);
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x000788A0 File Offset: 0x00076AA0
		protected override byte[] HashFinal()
		{
			if (this.m_encryptor == null)
			{
				this.des.Key = this.Key;
				this.m_encryptor = this.des.CreateEncryptor();
				this._ts = new TailStream(this.des.BlockSize / 8);
				this._cs = new CryptoStream(this._ts, this.m_encryptor, CryptoStreamMode.Write);
			}
			this._cs.FlushFinalBlock();
			return this._ts.Buffer;
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x00078920 File Offset: 0x00076B20
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.des != null)
				{
					this.des.Clear();
				}
				if (this.m_encryptor != null)
				{
					this.m_encryptor.Dispose();
				}
				if (this._cs != null)
				{
					this._cs.Clear();
				}
				if (this._ts != null)
				{
					this._ts.Clear();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000C5B RID: 3163
		private ICryptoTransform m_encryptor;

		// Token: 0x04000C5C RID: 3164
		private CryptoStream _cs;

		// Token: 0x04000C5D RID: 3165
		private TailStream _ts;

		// Token: 0x04000C5E RID: 3166
		private const int m_bitsPerByte = 8;

		// Token: 0x04000C5F RID: 3167
		private int m_bytesPerBlock;

		// Token: 0x04000C60 RID: 3168
		private TripleDES des;
	}
}
