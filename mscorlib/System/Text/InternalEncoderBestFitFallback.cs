using System;

namespace System.Text
{
	// Token: 0x02000A69 RID: 2665
	[Serializable]
	internal class InternalEncoderBestFitFallback : EncoderFallback
	{
		// Token: 0x060067D6 RID: 26582 RVA: 0x0015EE95 File Offset: 0x0015D095
		internal InternalEncoderBestFitFallback(Encoding encoding)
		{
			this.encoding = encoding;
			this.bIsMicrosoftBestFitFallback = true;
		}

		// Token: 0x060067D7 RID: 26583 RVA: 0x0015EEAB File Offset: 0x0015D0AB
		public override EncoderFallbackBuffer CreateFallbackBuffer()
		{
			return new InternalEncoderBestFitFallbackBuffer(this);
		}

		// Token: 0x170011B4 RID: 4532
		// (get) Token: 0x060067D8 RID: 26584 RVA: 0x0015EEB3 File Offset: 0x0015D0B3
		public override int MaxCharCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060067D9 RID: 26585 RVA: 0x0015EEB8 File Offset: 0x0015D0B8
		public override bool Equals(object value)
		{
			InternalEncoderBestFitFallback internalEncoderBestFitFallback = value as InternalEncoderBestFitFallback;
			return internalEncoderBestFitFallback != null && this.encoding.CodePage == internalEncoderBestFitFallback.encoding.CodePage;
		}

		// Token: 0x060067DA RID: 26586 RVA: 0x0015EEE9 File Offset: 0x0015D0E9
		public override int GetHashCode()
		{
			return this.encoding.CodePage;
		}

		// Token: 0x04002E54 RID: 11860
		internal Encoding encoding;

		// Token: 0x04002E55 RID: 11861
		internal char[] arrayBestFit;
	}
}
