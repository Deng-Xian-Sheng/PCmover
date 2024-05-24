using System;

namespace System.Text
{
	// Token: 0x02000A70 RID: 2672
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class EncoderReplacementFallback : EncoderFallback
	{
		// Token: 0x0600680C RID: 26636 RVA: 0x0015F6B3 File Offset: 0x0015D8B3
		[__DynamicallyInvokable]
		public EncoderReplacementFallback() : this("?")
		{
		}

		// Token: 0x0600680D RID: 26637 RVA: 0x0015F6C0 File Offset: 0x0015D8C0
		[__DynamicallyInvokable]
		public EncoderReplacementFallback(string replacement)
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

		// Token: 0x170011C2 RID: 4546
		// (get) Token: 0x0600680E RID: 26638 RVA: 0x0015F743 File Offset: 0x0015D943
		[__DynamicallyInvokable]
		public string DefaultString
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault;
			}
		}

		// Token: 0x0600680F RID: 26639 RVA: 0x0015F74B File Offset: 0x0015D94B
		[__DynamicallyInvokable]
		public override EncoderFallbackBuffer CreateFallbackBuffer()
		{
			return new EncoderReplacementFallbackBuffer(this);
		}

		// Token: 0x170011C3 RID: 4547
		// (get) Token: 0x06006810 RID: 26640 RVA: 0x0015F753 File Offset: 0x0015D953
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault.Length;
			}
		}

		// Token: 0x06006811 RID: 26641 RVA: 0x0015F760 File Offset: 0x0015D960
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			EncoderReplacementFallback encoderReplacementFallback = value as EncoderReplacementFallback;
			return encoderReplacementFallback != null && this.strDefault == encoderReplacementFallback.strDefault;
		}

		// Token: 0x06006812 RID: 26642 RVA: 0x0015F78A File Offset: 0x0015D98A
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.strDefault.GetHashCode();
		}

		// Token: 0x04002E6B RID: 11883
		private string strDefault;
	}
}
