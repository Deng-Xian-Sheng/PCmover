using System;

namespace System.Text
{
	// Token: 0x02000A60 RID: 2656
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecoderExceptionFallback : DecoderFallback
	{
		// Token: 0x06006788 RID: 26504 RVA: 0x0015DEBF File Offset: 0x0015C0BF
		[__DynamicallyInvokable]
		public DecoderExceptionFallback()
		{
		}

		// Token: 0x06006789 RID: 26505 RVA: 0x0015DEC7 File Offset: 0x0015C0C7
		[__DynamicallyInvokable]
		public override DecoderFallbackBuffer CreateFallbackBuffer()
		{
			return new DecoderExceptionFallbackBuffer();
		}

		// Token: 0x170011A1 RID: 4513
		// (get) Token: 0x0600678A RID: 26506 RVA: 0x0015DECE File Offset: 0x0015C0CE
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return 0;
			}
		}

		// Token: 0x0600678B RID: 26507 RVA: 0x0015DED4 File Offset: 0x0015C0D4
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			return value is DecoderExceptionFallback;
		}

		// Token: 0x0600678C RID: 26508 RVA: 0x0015DEEE File Offset: 0x0015C0EE
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return 879;
		}
	}
}
