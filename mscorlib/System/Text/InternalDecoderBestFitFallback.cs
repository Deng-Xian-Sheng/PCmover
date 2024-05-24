using System;

namespace System.Text
{
	// Token: 0x02000A5E RID: 2654
	[Serializable]
	internal sealed class InternalDecoderBestFitFallback : DecoderFallback
	{
		// Token: 0x0600677A RID: 26490 RVA: 0x0015DBF5 File Offset: 0x0015BDF5
		internal InternalDecoderBestFitFallback(Encoding encoding)
		{
			this.encoding = encoding;
			this.bIsMicrosoftBestFitFallback = true;
		}

		// Token: 0x0600677B RID: 26491 RVA: 0x0015DC13 File Offset: 0x0015BE13
		public override DecoderFallbackBuffer CreateFallbackBuffer()
		{
			return new InternalDecoderBestFitFallbackBuffer(this);
		}

		// Token: 0x1700119E RID: 4510
		// (get) Token: 0x0600677C RID: 26492 RVA: 0x0015DC1B File Offset: 0x0015BE1B
		public override int MaxCharCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0600677D RID: 26493 RVA: 0x0015DC20 File Offset: 0x0015BE20
		public override bool Equals(object value)
		{
			InternalDecoderBestFitFallback internalDecoderBestFitFallback = value as InternalDecoderBestFitFallback;
			return internalDecoderBestFitFallback != null && this.encoding.CodePage == internalDecoderBestFitFallback.encoding.CodePage;
		}

		// Token: 0x0600677E RID: 26494 RVA: 0x0015DC51 File Offset: 0x0015BE51
		public override int GetHashCode()
		{
			return this.encoding.CodePage;
		}

		// Token: 0x04002E39 RID: 11833
		internal Encoding encoding;

		// Token: 0x04002E3A RID: 11834
		internal char[] arrayBestFit;

		// Token: 0x04002E3B RID: 11835
		internal char cReplacement = '?';
	}
}
