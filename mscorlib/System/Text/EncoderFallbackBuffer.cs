using System;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A6F RID: 2671
	[__DynamicallyInvokable]
	public abstract class EncoderFallbackBuffer
	{
		// Token: 0x06006800 RID: 26624
		[__DynamicallyInvokable]
		public abstract bool Fallback(char charUnknown, int index);

		// Token: 0x06006801 RID: 26625
		[__DynamicallyInvokable]
		public abstract bool Fallback(char charUnknownHigh, char charUnknownLow, int index);

		// Token: 0x06006802 RID: 26626
		[__DynamicallyInvokable]
		public abstract char GetNextChar();

		// Token: 0x06006803 RID: 26627
		[__DynamicallyInvokable]
		public abstract bool MovePrevious();

		// Token: 0x170011C1 RID: 4545
		// (get) Token: 0x06006804 RID: 26628
		[__DynamicallyInvokable]
		public abstract int Remaining { [__DynamicallyInvokable] get; }

		// Token: 0x06006805 RID: 26629 RVA: 0x0015F500 File Offset: 0x0015D700
		[__DynamicallyInvokable]
		public virtual void Reset()
		{
			while (this.GetNextChar() != '\0')
			{
			}
		}

		// Token: 0x06006806 RID: 26630 RVA: 0x0015F50A File Offset: 0x0015D70A
		[SecurityCritical]
		internal void InternalReset()
		{
			this.charStart = null;
			this.bFallingBack = false;
			this.iRecursionCount = 0;
			this.Reset();
		}

		// Token: 0x06006807 RID: 26631 RVA: 0x0015F528 File Offset: 0x0015D728
		[SecurityCritical]
		internal unsafe void InternalInitialize(char* charStart, char* charEnd, EncoderNLS encoder, bool setEncoder)
		{
			this.charStart = charStart;
			this.charEnd = charEnd;
			this.encoder = encoder;
			this.setEncoder = setEncoder;
			this.bUsedEncoder = false;
			this.bFallingBack = false;
			this.iRecursionCount = 0;
		}

		// Token: 0x06006808 RID: 26632 RVA: 0x0015F55C File Offset: 0x0015D75C
		internal char InternalGetNextChar()
		{
			char nextChar = this.GetNextChar();
			this.bFallingBack = (nextChar > '\0');
			if (nextChar == '\0')
			{
				this.iRecursionCount = 0;
			}
			return nextChar;
		}

		// Token: 0x06006809 RID: 26633 RVA: 0x0015F588 File Offset: 0x0015D788
		[SecurityCritical]
		internal unsafe virtual bool InternalFallback(char ch, ref char* chars)
		{
			int index = (chars - this.charStart) / 2 - 1;
			if (char.IsHighSurrogate(ch))
			{
				if (chars >= this.charEnd)
				{
					if (this.encoder != null && !this.encoder.MustFlush)
					{
						if (this.setEncoder)
						{
							this.bUsedEncoder = true;
							this.encoder.charLeftOver = ch;
						}
						this.bFallingBack = false;
						return false;
					}
				}
				else
				{
					char c = (char)(*chars);
					if (char.IsLowSurrogate(c))
					{
						if (this.bFallingBack)
						{
							int num = this.iRecursionCount;
							this.iRecursionCount = num + 1;
							if (num > 250)
							{
								this.ThrowLastCharRecursive(char.ConvertToUtf32(ch, c));
							}
						}
						chars += 2;
						this.bFallingBack = this.Fallback(ch, c, index);
						return this.bFallingBack;
					}
				}
			}
			if (this.bFallingBack)
			{
				int num = this.iRecursionCount;
				this.iRecursionCount = num + 1;
				if (num > 250)
				{
					this.ThrowLastCharRecursive((int)ch);
				}
			}
			this.bFallingBack = this.Fallback(ch, index);
			return this.bFallingBack;
		}

		// Token: 0x0600680A RID: 26634 RVA: 0x0015F686 File Offset: 0x0015D886
		internal void ThrowLastCharRecursive(int charRecursive)
		{
			throw new ArgumentException(Environment.GetResourceString("Argument_RecursiveFallback", new object[]
			{
				charRecursive
			}), "chars");
		}

		// Token: 0x0600680B RID: 26635 RVA: 0x0015F6AB File Offset: 0x0015D8AB
		[__DynamicallyInvokable]
		protected EncoderFallbackBuffer()
		{
		}

		// Token: 0x04002E63 RID: 11875
		[SecurityCritical]
		internal unsafe char* charStart;

		// Token: 0x04002E64 RID: 11876
		[SecurityCritical]
		internal unsafe char* charEnd;

		// Token: 0x04002E65 RID: 11877
		internal EncoderNLS encoder;

		// Token: 0x04002E66 RID: 11878
		internal bool setEncoder;

		// Token: 0x04002E67 RID: 11879
		internal bool bUsedEncoder;

		// Token: 0x04002E68 RID: 11880
		internal bool bFallingBack;

		// Token: 0x04002E69 RID: 11881
		internal int iRecursionCount;

		// Token: 0x04002E6A RID: 11882
		private const int iMaxRecursion = 250;
	}
}
