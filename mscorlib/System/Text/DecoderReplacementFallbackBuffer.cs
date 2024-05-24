using System;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A66 RID: 2662
	public sealed class DecoderReplacementFallbackBuffer : DecoderFallbackBuffer
	{
		// Token: 0x060067B3 RID: 26547 RVA: 0x0015E3F7 File Offset: 0x0015C5F7
		public DecoderReplacementFallbackBuffer(DecoderReplacementFallback fallback)
		{
			this.strDefault = fallback.DefaultString;
		}

		// Token: 0x060067B4 RID: 26548 RVA: 0x0015E419 File Offset: 0x0015C619
		public override bool Fallback(byte[] bytesUnknown, int index)
		{
			if (this.fallbackCount >= 1)
			{
				base.ThrowLastBytesRecursive(bytesUnknown);
			}
			if (this.strDefault.Length == 0)
			{
				return false;
			}
			this.fallbackCount = this.strDefault.Length;
			this.fallbackIndex = -1;
			return true;
		}

		// Token: 0x060067B5 RID: 26549 RVA: 0x0015E454 File Offset: 0x0015C654
		public override char GetNextChar()
		{
			this.fallbackCount--;
			this.fallbackIndex++;
			if (this.fallbackCount < 0)
			{
				return '\0';
			}
			if (this.fallbackCount == 2147483647)
			{
				this.fallbackCount = -1;
				return '\0';
			}
			return this.strDefault[this.fallbackIndex];
		}

		// Token: 0x060067B6 RID: 26550 RVA: 0x0015E4AF File Offset: 0x0015C6AF
		public override bool MovePrevious()
		{
			if (this.fallbackCount >= -1 && this.fallbackIndex >= 0)
			{
				this.fallbackIndex--;
				this.fallbackCount++;
				return true;
			}
			return false;
		}

		// Token: 0x170011AD RID: 4525
		// (get) Token: 0x060067B7 RID: 26551 RVA: 0x0015E4E2 File Offset: 0x0015C6E2
		public override int Remaining
		{
			get
			{
				if (this.fallbackCount >= 0)
				{
					return this.fallbackCount;
				}
				return 0;
			}
		}

		// Token: 0x060067B8 RID: 26552 RVA: 0x0015E4F5 File Offset: 0x0015C6F5
		[SecuritySafeCritical]
		public override void Reset()
		{
			this.fallbackCount = -1;
			this.fallbackIndex = -1;
			this.byteStart = null;
		}

		// Token: 0x060067B9 RID: 26553 RVA: 0x0015E50D File Offset: 0x0015C70D
		[SecurityCritical]
		internal unsafe override int InternalFallback(byte[] bytes, byte* pBytes)
		{
			return this.strDefault.Length;
		}

		// Token: 0x04002E4A RID: 11850
		private string strDefault;

		// Token: 0x04002E4B RID: 11851
		private int fallbackCount = -1;

		// Token: 0x04002E4C RID: 11852
		private int fallbackIndex = -1;
	}
}
