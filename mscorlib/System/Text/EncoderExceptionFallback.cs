using System;

namespace System.Text
{
	// Token: 0x02000A6B RID: 2667
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class EncoderExceptionFallback : EncoderFallback
	{
		// Token: 0x060067E4 RID: 26596 RVA: 0x0015F1A7 File Offset: 0x0015D3A7
		[__DynamicallyInvokable]
		public EncoderExceptionFallback()
		{
		}

		// Token: 0x060067E5 RID: 26597 RVA: 0x0015F1AF File Offset: 0x0015D3AF
		[__DynamicallyInvokable]
		public override EncoderFallbackBuffer CreateFallbackBuffer()
		{
			return new EncoderExceptionFallbackBuffer();
		}

		// Token: 0x170011B7 RID: 4535
		// (get) Token: 0x060067E6 RID: 26598 RVA: 0x0015F1B6 File Offset: 0x0015D3B6
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return 0;
			}
		}

		// Token: 0x060067E7 RID: 26599 RVA: 0x0015F1BC File Offset: 0x0015D3BC
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			return value is EncoderExceptionFallback;
		}

		// Token: 0x060067E8 RID: 26600 RVA: 0x0015F1D6 File Offset: 0x0015D3D6
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return 654;
		}
	}
}
