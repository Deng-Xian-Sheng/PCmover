using System;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004C3 RID: 1219
	[Serializable]
	internal class ByteEqualityComparer : EqualityComparer<byte>
	{
		// Token: 0x06003A89 RID: 14985 RVA: 0x000DF3DE File Offset: 0x000DD5DE
		public override bool Equals(byte x, byte y)
		{
			return x == y;
		}

		// Token: 0x06003A8A RID: 14986 RVA: 0x000DF3E4 File Offset: 0x000DD5E4
		public override int GetHashCode(byte b)
		{
			return b.GetHashCode();
		}

		// Token: 0x06003A8B RID: 14987 RVA: 0x000DF3F0 File Offset: 0x000DD5F0
		[SecuritySafeCritical]
		internal unsafe override int IndexOf(byte[] array, byte value, int startIndex, int count)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
			}
			if (count > array.Length - startIndex)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (count == 0)
			{
				return -1;
			}
			byte* src;
			if (array == null || array.Length == 0)
			{
				src = null;
			}
			else
			{
				src = &array[0];
			}
			return Buffer.IndexOfByte(src, value, startIndex, count);
		}

		// Token: 0x06003A8C RID: 14988 RVA: 0x000DF480 File Offset: 0x000DD680
		internal override int LastIndexOf(byte[] array, byte value, int startIndex, int count)
		{
			int num = startIndex - count + 1;
			for (int i = startIndex; i >= num; i--)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003A8D RID: 14989 RVA: 0x000DF4AC File Offset: 0x000DD6AC
		public override bool Equals(object obj)
		{
			ByteEqualityComparer byteEqualityComparer = obj as ByteEqualityComparer;
			return byteEqualityComparer != null;
		}

		// Token: 0x06003A8E RID: 14990 RVA: 0x000DF4C4 File Offset: 0x000DD6C4
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
