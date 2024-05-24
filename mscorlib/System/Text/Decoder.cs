using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A5C RID: 2652
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Decoder
	{
		// Token: 0x0600675B RID: 26459 RVA: 0x0015D279 File Offset: 0x0015B479
		internal void SerializeDecoder(SerializationInfo info)
		{
			info.AddValue("m_fallback", this.m_fallback);
		}

		// Token: 0x0600675C RID: 26460 RVA: 0x0015D28C File Offset: 0x0015B48C
		[__DynamicallyInvokable]
		protected Decoder()
		{
		}

		// Token: 0x17001199 RID: 4505
		// (get) Token: 0x0600675D RID: 26461 RVA: 0x0015D294 File Offset: 0x0015B494
		// (set) Token: 0x0600675E RID: 26462 RVA: 0x0015D29C File Offset: 0x0015B49C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public DecoderFallback Fallback
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_fallback;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.m_fallbackBuffer != null && this.m_fallbackBuffer.Remaining > 0)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_FallbackBufferNotEmpty"), "value");
				}
				this.m_fallback = value;
				this.m_fallbackBuffer = null;
			}
		}

		// Token: 0x1700119A RID: 4506
		// (get) Token: 0x0600675F RID: 26463 RVA: 0x0015D2F0 File Offset: 0x0015B4F0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public DecoderFallbackBuffer FallbackBuffer
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_fallbackBuffer == null)
				{
					if (this.m_fallback != null)
					{
						this.m_fallbackBuffer = this.m_fallback.CreateFallbackBuffer();
					}
					else
					{
						this.m_fallbackBuffer = DecoderFallback.ReplacementFallback.CreateFallbackBuffer();
					}
				}
				return this.m_fallbackBuffer;
			}
		}

		// Token: 0x1700119B RID: 4507
		// (get) Token: 0x06006760 RID: 26464 RVA: 0x0015D32B File Offset: 0x0015B52B
		internal bool InternalHasFallbackBuffer
		{
			get
			{
				return this.m_fallbackBuffer != null;
			}
		}

		// Token: 0x06006761 RID: 26465 RVA: 0x0015D338 File Offset: 0x0015B538
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual void Reset()
		{
			byte[] bytes = new byte[0];
			char[] chars = new char[this.GetCharCount(bytes, 0, 0, true)];
			this.GetChars(bytes, 0, 0, chars, 0, true);
			if (this.m_fallbackBuffer != null)
			{
				this.m_fallbackBuffer.Reset();
			}
		}

		// Token: 0x06006762 RID: 26466
		[__DynamicallyInvokable]
		public abstract int GetCharCount(byte[] bytes, int index, int count);

		// Token: 0x06006763 RID: 26467 RVA: 0x0015D37C File Offset: 0x0015B57C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual int GetCharCount(byte[] bytes, int index, int count, bool flush)
		{
			return this.GetCharCount(bytes, index, count);
		}

		// Token: 0x06006764 RID: 26468 RVA: 0x0015D388 File Offset: 0x0015B588
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual int GetCharCount(byte* bytes, int count, bool flush)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			byte[] array = new byte[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = bytes[i];
			}
			return this.GetCharCount(array, 0, count);
		}

		// Token: 0x06006765 RID: 26469
		[__DynamicallyInvokable]
		public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);

		// Token: 0x06006766 RID: 26470 RVA: 0x0015D3EB File Offset: 0x0015B5EB
		[__DynamicallyInvokable]
		public virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush)
		{
			return this.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
		}

		// Token: 0x06006767 RID: 26471 RVA: 0x0015D3FC File Offset: 0x0015B5FC
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteCount < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteCount < 0) ? "byteCount" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			byte[] array = new byte[byteCount];
			for (int i = 0; i < byteCount; i++)
			{
				array[i] = bytes[i];
			}
			char[] array2 = new char[charCount];
			int chars2 = this.GetChars(array, 0, byteCount, array2, 0, flush);
			if (chars2 < charCount)
			{
				charCount = chars2;
			}
			for (int i = 0; i < charCount; i++)
			{
				chars[i] = array2[i];
			}
			return charCount;
		}

		// Token: 0x06006768 RID: 26472 RVA: 0x0015D4B0 File Offset: 0x0015B6B0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed)
		{
			if (bytes == null || chars == null)
			{
				throw new ArgumentNullException((bytes == null) ? "bytes" : "chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteIndex < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteIndex < 0) ? "byteIndex" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (charIndex < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((charIndex < 0) ? "charIndex" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (bytes.Length - byteIndex < byteCount)
			{
				throw new ArgumentOutOfRangeException("bytes", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (chars.Length - charIndex < charCount)
			{
				throw new ArgumentOutOfRangeException("chars", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			for (bytesUsed = byteCount; bytesUsed > 0; bytesUsed /= 2)
			{
				if (this.GetCharCount(bytes, byteIndex, bytesUsed, flush) <= charCount)
				{
					charsUsed = this.GetChars(bytes, byteIndex, bytesUsed, chars, charIndex, flush);
					completed = (bytesUsed == byteCount && (this.m_fallbackBuffer == null || this.m_fallbackBuffer.Remaining == 0));
					return;
				}
				flush = false;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_ConversionOverflow"));
		}

		// Token: 0x06006769 RID: 26473 RVA: 0x0015D5E4 File Offset: 0x0015B7E4
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual void Convert(byte* bytes, int byteCount, char* chars, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteCount < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteCount < 0) ? "byteCount" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			for (bytesUsed = byteCount; bytesUsed > 0; bytesUsed /= 2)
			{
				if (this.GetCharCount(bytes, bytesUsed, flush) <= charCount)
				{
					charsUsed = this.GetChars(bytes, bytesUsed, chars, charCount, flush);
					completed = (bytesUsed == byteCount && (this.m_fallbackBuffer == null || this.m_fallbackBuffer.Remaining == 0));
					return;
				}
				flush = false;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_ConversionOverflow"));
		}

		// Token: 0x04002E33 RID: 11827
		internal DecoderFallback m_fallback;

		// Token: 0x04002E34 RID: 11828
		[NonSerialized]
		internal DecoderFallbackBuffer m_fallbackBuffer;
	}
}
