using System;

namespace System.Text
{
	// Token: 0x02000A65 RID: 2661
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecoderReplacementFallback : DecoderFallback
	{
		// Token: 0x060067AC RID: 26540 RVA: 0x0015E312 File Offset: 0x0015C512
		[__DynamicallyInvokable]
		public DecoderReplacementFallback() : this("?")
		{
		}

		// Token: 0x060067AD RID: 26541 RVA: 0x0015E320 File Offset: 0x0015C520
		[__DynamicallyInvokable]
		public DecoderReplacementFallback(string replacement)
		{
			if (replacement == null)
			{
				throw new ArgumentNullException("replacement");
			}
			bool flag = false;
			for (int i = 0; i < replacement.Length; i++)
			{
				if (char.IsSurrogate(replacement, i))
				{
					if (char.IsHighSurrogate(replacement, i))
					{
						if (flag)
						{
							break;
						}
						flag = true;
					}
					else
					{
						if (!flag)
						{
							flag = true;
							break;
						}
						flag = false;
					}
				}
				else if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex", new object[]
				{
					"replacement"
				}));
			}
			this.strDefault = replacement;
		}

		// Token: 0x170011AB RID: 4523
		// (get) Token: 0x060067AE RID: 26542 RVA: 0x0015E3A3 File Offset: 0x0015C5A3
		[__DynamicallyInvokable]
		public string DefaultString
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault;
			}
		}

		// Token: 0x060067AF RID: 26543 RVA: 0x0015E3AB File Offset: 0x0015C5AB
		[__DynamicallyInvokable]
		public override DecoderFallbackBuffer CreateFallbackBuffer()
		{
			return new DecoderReplacementFallbackBuffer(this);
		}

		// Token: 0x170011AC RID: 4524
		// (get) Token: 0x060067B0 RID: 26544 RVA: 0x0015E3B3 File Offset: 0x0015C5B3
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault.Length;
			}
		}

		// Token: 0x060067B1 RID: 26545 RVA: 0x0015E3C0 File Offset: 0x0015C5C0
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			DecoderReplacementFallback decoderReplacementFallback = value as DecoderReplacementFallback;
			return decoderReplacementFallback != null && this.strDefault == decoderReplacementFallback.strDefault;
		}

		// Token: 0x060067B2 RID: 26546 RVA: 0x0015E3EA File Offset: 0x0015C5EA
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.strDefault.GetHashCode();
		}

		// Token: 0x04002E49 RID: 11849
		private string strDefault;
	}
}
