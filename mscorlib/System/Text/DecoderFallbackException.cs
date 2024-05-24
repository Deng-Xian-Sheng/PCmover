using System;
using System.Runtime.Serialization;

namespace System.Text
{
	// Token: 0x02000A62 RID: 2658
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecoderFallbackException : ArgumentException
	{
		// Token: 0x06006793 RID: 26515 RVA: 0x0015DFA9 File Offset: 0x0015C1A9
		[__DynamicallyInvokable]
		public DecoderFallbackException() : base(Environment.GetResourceString("Arg_ArgumentException"))
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x06006794 RID: 26516 RVA: 0x0015DFC6 File Offset: 0x0015C1C6
		[__DynamicallyInvokable]
		public DecoderFallbackException(string message) : base(message)
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x06006795 RID: 26517 RVA: 0x0015DFDA File Offset: 0x0015C1DA
		[__DynamicallyInvokable]
		public DecoderFallbackException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x06006796 RID: 26518 RVA: 0x0015DFEF File Offset: 0x0015C1EF
		internal DecoderFallbackException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06006797 RID: 26519 RVA: 0x0015DFF9 File Offset: 0x0015C1F9
		[__DynamicallyInvokable]
		public DecoderFallbackException(string message, byte[] bytesUnknown, int index) : base(message)
		{
			this.bytesUnknown = bytesUnknown;
			this.index = index;
		}

		// Token: 0x170011A3 RID: 4515
		// (get) Token: 0x06006798 RID: 26520 RVA: 0x0015E010 File Offset: 0x0015C210
		[__DynamicallyInvokable]
		public byte[] BytesUnknown
		{
			[__DynamicallyInvokable]
			get
			{
				return this.bytesUnknown;
			}
		}

		// Token: 0x170011A4 RID: 4516
		// (get) Token: 0x06006799 RID: 26521 RVA: 0x0015E018 File Offset: 0x0015C218
		[__DynamicallyInvokable]
		public int Index
		{
			[__DynamicallyInvokable]
			get
			{
				return this.index;
			}
		}

		// Token: 0x04002E41 RID: 11841
		private byte[] bytesUnknown;

		// Token: 0x04002E42 RID: 11842
		private int index;
	}
}
