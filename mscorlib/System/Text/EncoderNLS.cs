using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A68 RID: 2664
	[Serializable]
	internal class EncoderNLS : Encoder, ISerializable
	{
		// Token: 0x060067C7 RID: 26567 RVA: 0x0015E93F File Offset: 0x0015CB3F
		internal EncoderNLS(SerializationInfo info, StreamingContext context)
		{
			throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("NotSupported_TypeCannotDeserialized"), base.GetType()));
		}

		// Token: 0x060067C8 RID: 26568 RVA: 0x0015E966 File Offset: 0x0015CB66
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.SerializeEncoder(info);
			info.AddValue("encoding", this.m_encoding);
			info.AddValue("charLeftOver", this.charLeftOver);
			info.SetType(typeof(Encoding.DefaultEncoder));
		}

		// Token: 0x060067C9 RID: 26569 RVA: 0x0015E9A1 File Offset: 0x0015CBA1
		internal EncoderNLS(Encoding encoding)
		{
			this.m_encoding = encoding;
			this.m_fallback = this.m_encoding.EncoderFallback;
			this.Reset();
		}

		// Token: 0x060067CA RID: 26570 RVA: 0x0015E9C7 File Offset: 0x0015CBC7
		internal EncoderNLS()
		{
			this.m_encoding = null;
			this.Reset();
		}

		// Token: 0x060067CB RID: 26571 RVA: 0x0015E9DC File Offset: 0x0015CBDC
		public override void Reset()
		{
			this.charLeftOver = '\0';
			if (this.m_fallbackBuffer != null)
			{
				this.m_fallbackBuffer.Reset();
			}
		}

		// Token: 0x060067CC RID: 26572 RVA: 0x0015E9F8 File Offset: 0x0015CBF8
		[SecuritySafeCritical]
		public unsafe override int GetByteCount(char[] chars, int index, int count, bool flush)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (chars.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("chars", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (chars.Length == 0)
			{
				chars = new char[1];
			}
			char[] array;
			char* ptr;
			if ((array = chars) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			int byteCount = this.GetByteCount(ptr + index, count, flush);
			array = null;
			return byteCount;
		}

		// Token: 0x060067CD RID: 26573 RVA: 0x0015EA9C File Offset: 0x0015CC9C
		[SecurityCritical]
		public unsafe override int GetByteCount(char* chars, int count, bool flush)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_mustFlush = flush;
			this.m_throwOnOverflow = true;
			return this.m_encoding.GetByteCount(chars, count, this);
		}

		// Token: 0x060067CE RID: 26574 RVA: 0x0015EAF8 File Offset: 0x0015CCF8
		[SecuritySafeCritical]
		public unsafe override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charIndex < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((charIndex < 0) ? "charIndex" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (chars.Length - charIndex < charCount)
			{
				throw new ArgumentOutOfRangeException("chars", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (byteIndex < 0 || byteIndex > bytes.Length)
			{
				throw new ArgumentOutOfRangeException("byteIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (chars.Length == 0)
			{
				chars = new char[1];
			}
			int byteCount = bytes.Length - byteIndex;
			if (bytes.Length == 0)
			{
				bytes = new byte[1];
			}
			char[] array;
			char* ptr;
			if ((array = chars) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte[] array2;
			byte* ptr2;
			if ((array2 = bytes) == null || array2.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &array2[0];
			}
			return this.GetBytes(ptr + charIndex, charCount, ptr2 + byteIndex, byteCount, flush);
		}

		// Token: 0x060067CF RID: 26575 RVA: 0x0015EBFC File Offset: 0x0015CDFC
		[SecurityCritical]
		public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteCount < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteCount < 0) ? "byteCount" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_mustFlush = flush;
			this.m_throwOnOverflow = true;
			return this.m_encoding.GetBytes(chars, charCount, bytes, byteCount, this);
		}

		// Token: 0x060067D0 RID: 26576 RVA: 0x0015EC80 File Offset: 0x0015CE80
		[SecuritySafeCritical]
		public unsafe override void Convert(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charIndex < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((charIndex < 0) ? "charIndex" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (byteIndex < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteIndex < 0) ? "byteIndex" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (chars.Length - charIndex < charCount)
			{
				throw new ArgumentOutOfRangeException("chars", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (bytes.Length - byteIndex < byteCount)
			{
				throw new ArgumentOutOfRangeException("bytes", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (chars.Length == 0)
			{
				chars = new char[1];
			}
			if (bytes.Length == 0)
			{
				bytes = new byte[1];
			}
			char[] array;
			char* ptr;
			if ((array = chars) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte[] array2;
			byte* ptr2;
			if ((array2 = bytes) == null || array2.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &array2[0];
			}
			this.Convert(ptr + charIndex, charCount, ptr2 + byteIndex, byteCount, flush, out charsUsed, out bytesUsed, out completed);
			array2 = null;
			array = null;
		}

		// Token: 0x060067D1 RID: 26577 RVA: 0x0015EDAC File Offset: 0x0015CFAC
		[SecurityCritical]
		public unsafe override void Convert(char* chars, int charCount, byte* bytes, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed)
		{
			if (bytes == null || chars == null)
			{
				throw new ArgumentNullException((bytes == null) ? "bytes" : "chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charCount < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((charCount < 0) ? "charCount" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_mustFlush = flush;
			this.m_throwOnOverflow = false;
			this.m_charsUsed = 0;
			bytesUsed = this.m_encoding.GetBytes(chars, charCount, bytes, byteCount, this);
			charsUsed = this.m_charsUsed;
			completed = (charsUsed == charCount && (!flush || !this.HasState) && (this.m_fallbackBuffer == null || this.m_fallbackBuffer.Remaining == 0));
		}

		// Token: 0x170011B1 RID: 4529
		// (get) Token: 0x060067D2 RID: 26578 RVA: 0x0015EE71 File Offset: 0x0015D071
		public Encoding Encoding
		{
			get
			{
				return this.m_encoding;
			}
		}

		// Token: 0x170011B2 RID: 4530
		// (get) Token: 0x060067D3 RID: 26579 RVA: 0x0015EE79 File Offset: 0x0015D079
		public bool MustFlush
		{
			get
			{
				return this.m_mustFlush;
			}
		}

		// Token: 0x170011B3 RID: 4531
		// (get) Token: 0x060067D4 RID: 26580 RVA: 0x0015EE81 File Offset: 0x0015D081
		internal virtual bool HasState
		{
			get
			{
				return this.charLeftOver > '\0';
			}
		}

		// Token: 0x060067D5 RID: 26581 RVA: 0x0015EE8C File Offset: 0x0015D08C
		internal void ClearMustFlush()
		{
			this.m_mustFlush = false;
		}

		// Token: 0x04002E4F RID: 11855
		internal char charLeftOver;

		// Token: 0x04002E50 RID: 11856
		protected Encoding m_encoding;

		// Token: 0x04002E51 RID: 11857
		[NonSerialized]
		protected bool m_mustFlush;

		// Token: 0x04002E52 RID: 11858
		[NonSerialized]
		internal bool m_throwOnOverflow;

		// Token: 0x04002E53 RID: 11859
		[NonSerialized]
		internal int m_charsUsed;
	}
}
