using System;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A71 RID: 2673
	public sealed class EncoderReplacementFallbackBuffer : EncoderFallbackBuffer
	{
		// Token: 0x06006813 RID: 26643 RVA: 0x0015F797 File Offset: 0x0015D997
		public EncoderReplacementFallbackBuffer(EncoderReplacementFallback fallback)
		{
			this.strDefault = fallback.DefaultString + fallback.DefaultString;
		}

		// Token: 0x06006814 RID: 26644 RVA: 0x0015F7C4 File Offset: 0x0015D9C4
		public override bool Fallback(char charUnknown, int index)
		{
			if (this.fallbackCount >= 1)
			{
				if (char.IsHighSurrogate(charUnknown) && this.fallbackCount >= 0 && char.IsLowSurrogate(this.strDefault[this.fallbackIndex + 1]))
				{
					base.ThrowLastCharRecursive(char.ConvertToUtf32(charUnknown, this.strDefault[this.fallbackIndex + 1]));
				}
				base.ThrowLastCharRecursive((int)charUnknown);
			}
			this.fallbackCount = this.strDefault.Length / 2;
			this.fallbackIndex = -1;
			return this.fallbackCount != 0;
		}

		// Token: 0x06006815 RID: 26645 RVA: 0x0015F850 File Offset: 0x0015DA50
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
		{
			if (!char.IsHighSurrogate(charUnknownHigh))
			{
				throw new ArgumentOutOfRangeException("charUnknownHigh", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					55296,
					56319
				}));
			}
			if (!char.IsLowSurrogate(charUnknownLow))
			{
				throw new ArgumentOutOfRangeException("CharUnknownLow", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					56320,
					57343
				}));
			}
			if (this.fallbackCount >= 1)
			{
				base.ThrowLastCharRecursive(char.ConvertToUtf32(charUnknownHigh, charUnknownLow));
			}
			this.fallbackCount = this.strDefault.Length;
			this.fallbackIndex = -1;
			return this.fallbackCount != 0;
		}

		// Token: 0x06006816 RID: 26646 RVA: 0x0015F910 File Offset: 0x0015DB10
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

		// Token: 0x06006817 RID: 26647 RVA: 0x0015F96B File Offset: 0x0015DB6B
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

		// Token: 0x170011C4 RID: 4548
		// (get) Token: 0x06006818 RID: 26648 RVA: 0x0015F99E File Offset: 0x0015DB9E
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

		// Token: 0x06006819 RID: 26649 RVA: 0x0015F9B1 File Offset: 0x0015DBB1
		[SecuritySafeCritical]
		public override void Reset()
		{
			this.fallbackCount = -1;
			this.fallbackIndex = 0;
			this.charStart = null;
			this.bFallingBack = false;
		}

		// Token: 0x04002E6C RID: 11884
		private string strDefault;

		// Token: 0x04002E6D RID: 11885
		private int fallbackCount = -1;

		// Token: 0x04002E6E RID: 11886
		private int fallbackIndex = -1;
	}
}
