using System;
using System.Globalization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A64 RID: 2660
	[__DynamicallyInvokable]
	public abstract class DecoderFallbackBuffer
	{
		// Token: 0x060067A1 RID: 26529
		[__DynamicallyInvokable]
		public abstract bool Fallback(byte[] bytesUnknown, int index);

		// Token: 0x060067A2 RID: 26530
		[__DynamicallyInvokable]
		public abstract char GetNextChar();

		// Token: 0x060067A3 RID: 26531
		[__DynamicallyInvokable]
		public abstract bool MovePrevious();

		// Token: 0x170011AA RID: 4522
		// (get) Token: 0x060067A4 RID: 26532
		[__DynamicallyInvokable]
		public abstract int Remaining { [__DynamicallyInvokable] get; }

		// Token: 0x060067A5 RID: 26533 RVA: 0x0015E11C File Offset: 0x0015C31C
		[__DynamicallyInvokable]
		public virtual void Reset()
		{
			while (this.GetNextChar() != '\0')
			{
			}
		}

		// Token: 0x060067A6 RID: 26534 RVA: 0x0015E126 File Offset: 0x0015C326
		[SecurityCritical]
		internal void InternalReset()
		{
			this.byteStart = null;
			this.Reset();
		}

		// Token: 0x060067A7 RID: 26535 RVA: 0x0015E136 File Offset: 0x0015C336
		[SecurityCritical]
		internal unsafe void InternalInitialize(byte* byteStart, char* charEnd)
		{
			this.byteStart = byteStart;
			this.charEnd = charEnd;
		}

		// Token: 0x060067A8 RID: 26536 RVA: 0x0015E148 File Offset: 0x0015C348
		[SecurityCritical]
		internal unsafe virtual bool InternalFallback(byte[] bytes, byte* pBytes, ref char* chars)
		{
			if (this.Fallback(bytes, (int)((long)(pBytes - this.byteStart) - (long)bytes.Length)))
			{
				char* ptr = chars;
				bool flag = false;
				char nextChar;
				while ((nextChar = this.GetNextChar()) != '\0')
				{
					if (char.IsSurrogate(nextChar))
					{
						if (char.IsHighSurrogate(nextChar))
						{
							if (flag)
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
							}
							flag = true;
						}
						else
						{
							if (!flag)
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
							}
							flag = false;
						}
					}
					if (ptr >= this.charEnd)
					{
						return false;
					}
					*(ptr++) = nextChar;
				}
				if (flag)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
				}
				chars = ptr;
			}
			return true;
		}

		// Token: 0x060067A9 RID: 26537 RVA: 0x0015E1E8 File Offset: 0x0015C3E8
		[SecurityCritical]
		internal unsafe virtual int InternalFallback(byte[] bytes, byte* pBytes)
		{
			if (!this.Fallback(bytes, (int)((long)(pBytes - this.byteStart) - (long)bytes.Length)))
			{
				return 0;
			}
			int num = 0;
			bool flag = false;
			char nextChar;
			while ((nextChar = this.GetNextChar()) != '\0')
			{
				if (char.IsSurrogate(nextChar))
				{
					if (char.IsHighSurrogate(nextChar))
					{
						if (flag)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
						}
						flag = true;
					}
					else
					{
						if (!flag)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
						}
						flag = false;
					}
				}
				num++;
			}
			if (flag)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
			}
			return num;
		}

		// Token: 0x060067AA RID: 26538 RVA: 0x0015E278 File Offset: 0x0015C478
		internal void ThrowLastBytesRecursive(byte[] bytesUnknown)
		{
			StringBuilder stringBuilder = new StringBuilder(bytesUnknown.Length * 3);
			int num = 0;
			while (num < bytesUnknown.Length && num < 20)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" ");
				}
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "\\x{0:X2}", bytesUnknown[num]));
				num++;
			}
			if (num == 20)
			{
				stringBuilder.Append(" ...");
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_RecursiveFallbackBytes", new object[]
			{
				stringBuilder.ToString()
			}), "bytesUnknown");
		}

		// Token: 0x060067AB RID: 26539 RVA: 0x0015E30A File Offset: 0x0015C50A
		[__DynamicallyInvokable]
		protected DecoderFallbackBuffer()
		{
		}

		// Token: 0x04002E47 RID: 11847
		[SecurityCritical]
		internal unsafe byte* byteStart;

		// Token: 0x04002E48 RID: 11848
		[SecurityCritical]
		internal unsafe char* charEnd;
	}
}
