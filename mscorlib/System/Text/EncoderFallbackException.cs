using System;
using System.Runtime.Serialization;

namespace System.Text
{
	// Token: 0x02000A6D RID: 2669
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class EncoderFallbackException : ArgumentException
	{
		// Token: 0x060067EF RID: 26607 RVA: 0x0015F2D2 File Offset: 0x0015D4D2
		[__DynamicallyInvokable]
		public EncoderFallbackException() : base(Environment.GetResourceString("Arg_ArgumentException"))
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x060067F0 RID: 26608 RVA: 0x0015F2EF File Offset: 0x0015D4EF
		[__DynamicallyInvokable]
		public EncoderFallbackException(string message) : base(message)
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x060067F1 RID: 26609 RVA: 0x0015F303 File Offset: 0x0015D503
		[__DynamicallyInvokable]
		public EncoderFallbackException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x060067F2 RID: 26610 RVA: 0x0015F318 File Offset: 0x0015D518
		internal EncoderFallbackException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060067F3 RID: 26611 RVA: 0x0015F322 File Offset: 0x0015D522
		internal EncoderFallbackException(string message, char charUnknown, int index) : base(message)
		{
			this.charUnknown = charUnknown;
			this.index = index;
		}

		// Token: 0x060067F4 RID: 26612 RVA: 0x0015F33C File Offset: 0x0015D53C
		internal EncoderFallbackException(string message, char charUnknownHigh, char charUnknownLow, int index) : base(message)
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
			this.charUnknownHigh = charUnknownHigh;
			this.charUnknownLow = charUnknownLow;
			this.index = index;
		}

		// Token: 0x170011B9 RID: 4537
		// (get) Token: 0x060067F5 RID: 26613 RVA: 0x0015F3E0 File Offset: 0x0015D5E0
		[__DynamicallyInvokable]
		public char CharUnknown
		{
			[__DynamicallyInvokable]
			get
			{
				return this.charUnknown;
			}
		}

		// Token: 0x170011BA RID: 4538
		// (get) Token: 0x060067F6 RID: 26614 RVA: 0x0015F3E8 File Offset: 0x0015D5E8
		[__DynamicallyInvokable]
		public char CharUnknownHigh
		{
			[__DynamicallyInvokable]
			get
			{
				return this.charUnknownHigh;
			}
		}

		// Token: 0x170011BB RID: 4539
		// (get) Token: 0x060067F7 RID: 26615 RVA: 0x0015F3F0 File Offset: 0x0015D5F0
		[__DynamicallyInvokable]
		public char CharUnknownLow
		{
			[__DynamicallyInvokable]
			get
			{
				return this.charUnknownLow;
			}
		}

		// Token: 0x170011BC RID: 4540
		// (get) Token: 0x060067F8 RID: 26616 RVA: 0x0015F3F8 File Offset: 0x0015D5F8
		[__DynamicallyInvokable]
		public int Index
		{
			[__DynamicallyInvokable]
			get
			{
				return this.index;
			}
		}

		// Token: 0x060067F9 RID: 26617 RVA: 0x0015F400 File Offset: 0x0015D600
		[__DynamicallyInvokable]
		public bool IsUnknownSurrogate()
		{
			return this.charUnknownHigh > '\0';
		}

		// Token: 0x04002E5B RID: 11867
		private char charUnknown;

		// Token: 0x04002E5C RID: 11868
		private char charUnknownHigh;

		// Token: 0x04002E5D RID: 11869
		private char charUnknownLow;

		// Token: 0x04002E5E RID: 11870
		private int index;
	}
}
