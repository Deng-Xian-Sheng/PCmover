using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;

namespace System.Resources
{
	// Token: 0x02000389 RID: 905
	internal sealed class FastResourceComparer : IComparer, IEqualityComparer, IComparer<string>, IEqualityComparer<string>
	{
		// Token: 0x06002CD6 RID: 11478 RVA: 0x000A9130 File Offset: 0x000A7330
		public int GetHashCode(object key)
		{
			string key2 = (string)key;
			return FastResourceComparer.HashFunction(key2);
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x000A914A File Offset: 0x000A734A
		public int GetHashCode(string key)
		{
			return FastResourceComparer.HashFunction(key);
		}

		// Token: 0x06002CD8 RID: 11480 RVA: 0x000A9154 File Offset: 0x000A7354
		internal static int HashFunction(string key)
		{
			uint num = 5381U;
			for (int i = 0; i < key.Length; i++)
			{
				num = ((num << 5) + num ^ (uint)key[i]);
			}
			return (int)num;
		}

		// Token: 0x06002CD9 RID: 11481 RVA: 0x000A9188 File Offset: 0x000A7388
		public int Compare(object a, object b)
		{
			if (a == b)
			{
				return 0;
			}
			string strA = (string)a;
			string strB = (string)b;
			return string.CompareOrdinal(strA, strB);
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x000A91B0 File Offset: 0x000A73B0
		public int Compare(string a, string b)
		{
			return string.CompareOrdinal(a, b);
		}

		// Token: 0x06002CDB RID: 11483 RVA: 0x000A91B9 File Offset: 0x000A73B9
		public bool Equals(string a, string b)
		{
			return string.Equals(a, b);
		}

		// Token: 0x06002CDC RID: 11484 RVA: 0x000A91C4 File Offset: 0x000A73C4
		public bool Equals(object a, object b)
		{
			if (a == b)
			{
				return true;
			}
			string a2 = (string)a;
			string b2 = (string)b;
			return string.Equals(a2, b2);
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x000A91EC File Offset: 0x000A73EC
		[SecurityCritical]
		public unsafe static int CompareOrdinal(string a, byte[] bytes, int bCharLength)
		{
			int num = 0;
			int num2 = 0;
			int num3 = a.Length;
			if (num3 > bCharLength)
			{
				num3 = bCharLength;
			}
			if (bCharLength == 0)
			{
				if (a.Length != 0)
				{
					return -1;
				}
				return 0;
			}
			else
			{
				fixed (byte[] array = bytes)
				{
					byte* ptr;
					if (bytes == null || array.Length == 0)
					{
						ptr = null;
					}
					else
					{
						ptr = &array[0];
					}
					byte* ptr2 = ptr;
					while (num < num3 && num2 == 0)
					{
						int num4 = (int)(*ptr2) | (int)ptr2[1] << 8;
						num2 = (int)a[num++] - num4;
						ptr2 += 2;
					}
				}
				if (num2 != 0)
				{
					return num2;
				}
				return a.Length - bCharLength;
			}
		}

		// Token: 0x06002CDE RID: 11486 RVA: 0x000A9272 File Offset: 0x000A7472
		[SecurityCritical]
		public static int CompareOrdinal(byte[] bytes, int aCharLength, string b)
		{
			return -FastResourceComparer.CompareOrdinal(b, bytes, aCharLength);
		}

		// Token: 0x06002CDF RID: 11487 RVA: 0x000A9280 File Offset: 0x000A7480
		[SecurityCritical]
		internal unsafe static int CompareOrdinal(byte* a, int byteLen, string b)
		{
			int num = 0;
			int num2 = 0;
			int num3 = byteLen >> 1;
			if (num3 > b.Length)
			{
				num3 = b.Length;
			}
			while (num2 < num3 && num == 0)
			{
				char c = (char)((int)(*(a++)) | (int)(*(a++)) << 8);
				num = (int)(c - b[num2++]);
			}
			if (num != 0)
			{
				return num;
			}
			return byteLen - b.Length * 2;
		}

		// Token: 0x04001222 RID: 4642
		internal static readonly FastResourceComparer Default = new FastResourceComparer();
	}
}
