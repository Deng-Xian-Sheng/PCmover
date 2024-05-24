using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000647 RID: 1607
	[ComVisible(false)]
	public struct ExceptionHandler : IEquatable<ExceptionHandler>
	{
		// Token: 0x17000BC4 RID: 3012
		// (get) Token: 0x06004B6D RID: 19309 RVA: 0x0011161F File Offset: 0x0010F81F
		public int ExceptionTypeToken
		{
			get
			{
				return this.m_exceptionClass;
			}
		}

		// Token: 0x17000BC5 RID: 3013
		// (get) Token: 0x06004B6E RID: 19310 RVA: 0x00111627 File Offset: 0x0010F827
		public int TryOffset
		{
			get
			{
				return this.m_tryStartOffset;
			}
		}

		// Token: 0x17000BC6 RID: 3014
		// (get) Token: 0x06004B6F RID: 19311 RVA: 0x0011162F File Offset: 0x0010F82F
		public int TryLength
		{
			get
			{
				return this.m_tryEndOffset - this.m_tryStartOffset;
			}
		}

		// Token: 0x17000BC7 RID: 3015
		// (get) Token: 0x06004B70 RID: 19312 RVA: 0x0011163E File Offset: 0x0010F83E
		public int FilterOffset
		{
			get
			{
				return this.m_filterOffset;
			}
		}

		// Token: 0x17000BC8 RID: 3016
		// (get) Token: 0x06004B71 RID: 19313 RVA: 0x00111646 File Offset: 0x0010F846
		public int HandlerOffset
		{
			get
			{
				return this.m_handlerStartOffset;
			}
		}

		// Token: 0x17000BC9 RID: 3017
		// (get) Token: 0x06004B72 RID: 19314 RVA: 0x0011164E File Offset: 0x0010F84E
		public int HandlerLength
		{
			get
			{
				return this.m_handlerEndOffset - this.m_handlerStartOffset;
			}
		}

		// Token: 0x17000BCA RID: 3018
		// (get) Token: 0x06004B73 RID: 19315 RVA: 0x0011165D File Offset: 0x0010F85D
		public ExceptionHandlingClauseOptions Kind
		{
			get
			{
				return this.m_kind;
			}
		}

		// Token: 0x06004B74 RID: 19316 RVA: 0x00111668 File Offset: 0x0010F868
		public ExceptionHandler(int tryOffset, int tryLength, int filterOffset, int handlerOffset, int handlerLength, ExceptionHandlingClauseOptions kind, int exceptionTypeToken)
		{
			if (tryOffset < 0)
			{
				throw new ArgumentOutOfRangeException("tryOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (tryLength < 0)
			{
				throw new ArgumentOutOfRangeException("tryLength", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (filterOffset < 0)
			{
				throw new ArgumentOutOfRangeException("filterOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (handlerOffset < 0)
			{
				throw new ArgumentOutOfRangeException("handlerOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (handlerLength < 0)
			{
				throw new ArgumentOutOfRangeException("handlerLength", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if ((long)tryOffset + (long)tryLength > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("tryLength", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					0,
					int.MaxValue - tryOffset
				}));
			}
			if ((long)handlerOffset + (long)handlerLength > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("handlerLength", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					0,
					int.MaxValue - handlerOffset
				}));
			}
			if (kind == ExceptionHandlingClauseOptions.Clause && (exceptionTypeToken & 16777215) == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidTypeToken", new object[]
				{
					exceptionTypeToken
				}), "exceptionTypeToken");
			}
			if (!ExceptionHandler.IsValidKind(kind))
			{
				throw new ArgumentOutOfRangeException("kind", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
			this.m_tryStartOffset = tryOffset;
			this.m_tryEndOffset = tryOffset + tryLength;
			this.m_filterOffset = filterOffset;
			this.m_handlerStartOffset = handlerOffset;
			this.m_handlerEndOffset = handlerOffset + handlerLength;
			this.m_kind = kind;
			this.m_exceptionClass = exceptionTypeToken;
		}

		// Token: 0x06004B75 RID: 19317 RVA: 0x00111802 File Offset: 0x0010FA02
		internal ExceptionHandler(int tryStartOffset, int tryEndOffset, int filterOffset, int handlerStartOffset, int handlerEndOffset, int kind, int exceptionTypeToken)
		{
			this.m_tryStartOffset = tryStartOffset;
			this.m_tryEndOffset = tryEndOffset;
			this.m_filterOffset = filterOffset;
			this.m_handlerStartOffset = handlerStartOffset;
			this.m_handlerEndOffset = handlerEndOffset;
			this.m_kind = (ExceptionHandlingClauseOptions)kind;
			this.m_exceptionClass = exceptionTypeToken;
		}

		// Token: 0x06004B76 RID: 19318 RVA: 0x00111839 File Offset: 0x0010FA39
		private static bool IsValidKind(ExceptionHandlingClauseOptions kind)
		{
			return kind <= ExceptionHandlingClauseOptions.Finally || kind == ExceptionHandlingClauseOptions.Fault;
		}

		// Token: 0x06004B77 RID: 19319 RVA: 0x00111846 File Offset: 0x0010FA46
		public override int GetHashCode()
		{
			return this.m_exceptionClass ^ this.m_tryStartOffset ^ this.m_tryEndOffset ^ this.m_filterOffset ^ this.m_handlerStartOffset ^ this.m_handlerEndOffset ^ (int)this.m_kind;
		}

		// Token: 0x06004B78 RID: 19320 RVA: 0x00111878 File Offset: 0x0010FA78
		public override bool Equals(object obj)
		{
			return obj is ExceptionHandler && this.Equals((ExceptionHandler)obj);
		}

		// Token: 0x06004B79 RID: 19321 RVA: 0x00111890 File Offset: 0x0010FA90
		public bool Equals(ExceptionHandler other)
		{
			return other.m_exceptionClass == this.m_exceptionClass && other.m_tryStartOffset == this.m_tryStartOffset && other.m_tryEndOffset == this.m_tryEndOffset && other.m_filterOffset == this.m_filterOffset && other.m_handlerStartOffset == this.m_handlerStartOffset && other.m_handlerEndOffset == this.m_handlerEndOffset && other.m_kind == this.m_kind;
		}

		// Token: 0x06004B7A RID: 19322 RVA: 0x00111901 File Offset: 0x0010FB01
		public static bool operator ==(ExceptionHandler left, ExceptionHandler right)
		{
			return left.Equals(right);
		}

		// Token: 0x06004B7B RID: 19323 RVA: 0x0011190B File Offset: 0x0010FB0B
		public static bool operator !=(ExceptionHandler left, ExceptionHandler right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04001F2B RID: 7979
		internal readonly int m_exceptionClass;

		// Token: 0x04001F2C RID: 7980
		internal readonly int m_tryStartOffset;

		// Token: 0x04001F2D RID: 7981
		internal readonly int m_tryEndOffset;

		// Token: 0x04001F2E RID: 7982
		internal readonly int m_filterOffset;

		// Token: 0x04001F2F RID: 7983
		internal readonly int m_handlerStartOffset;

		// Token: 0x04001F30 RID: 7984
		internal readonly int m_handlerEndOffset;

		// Token: 0x04001F31 RID: 7985
		internal readonly ExceptionHandlingClauseOptions m_kind;
	}
}
