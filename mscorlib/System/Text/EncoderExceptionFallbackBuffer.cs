using System;

namespace System.Text
{
	// Token: 0x02000A6C RID: 2668
	public sealed class EncoderExceptionFallbackBuffer : EncoderFallbackBuffer
	{
		// Token: 0x060067EA RID: 26602 RVA: 0x0015F1E5 File Offset: 0x0015D3E5
		public override bool Fallback(char charUnknown, int index)
		{
			throw new EncoderFallbackException(Environment.GetResourceString("Argument_InvalidCodePageConversionIndex", new object[]
			{
				(int)charUnknown,
				index
			}), charUnknown, index);
		}

		// Token: 0x060067EB RID: 26603 RVA: 0x0015F210 File Offset: 0x0015D410
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
			int num = char.ConvertToUtf32(charUnknownHigh, charUnknownLow);
			throw new EncoderFallbackException(Environment.GetResourceString("Argument_InvalidCodePageConversionIndex", new object[]
			{
				num,
				index
			}), charUnknownHigh, charUnknownLow, index);
		}

		// Token: 0x060067EC RID: 26604 RVA: 0x0015F2C9 File Offset: 0x0015D4C9
		public override char GetNextChar()
		{
			return '\0';
		}

		// Token: 0x060067ED RID: 26605 RVA: 0x0015F2CC File Offset: 0x0015D4CC
		public override bool MovePrevious()
		{
			return false;
		}

		// Token: 0x170011B8 RID: 4536
		// (get) Token: 0x060067EE RID: 26606 RVA: 0x0015F2CF File Offset: 0x0015D4CF
		public override int Remaining
		{
			get
			{
				return 0;
			}
		}
	}
}
