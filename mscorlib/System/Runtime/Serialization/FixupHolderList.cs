using System;

namespace System.Runtime.Serialization
{
	// Token: 0x0200074D RID: 1869
	[Serializable]
	internal class FixupHolderList
	{
		// Token: 0x060052AD RID: 21165 RVA: 0x00122AA3 File Offset: 0x00120CA3
		internal FixupHolderList() : this(2)
		{
		}

		// Token: 0x060052AE RID: 21166 RVA: 0x00122AAC File Offset: 0x00120CAC
		internal FixupHolderList(int startingSize)
		{
			this.m_count = 0;
			this.m_values = new FixupHolder[startingSize];
		}

		// Token: 0x060052AF RID: 21167 RVA: 0x00122AC8 File Offset: 0x00120CC8
		internal virtual void Add(long id, object fixupInfo)
		{
			if (this.m_count == this.m_values.Length)
			{
				this.EnlargeArray();
			}
			this.m_values[this.m_count].m_id = id;
			FixupHolder[] values = this.m_values;
			int count = this.m_count;
			this.m_count = count + 1;
			values[count].m_fixupInfo = fixupInfo;
		}

		// Token: 0x060052B0 RID: 21168 RVA: 0x00122B1C File Offset: 0x00120D1C
		internal virtual void Add(FixupHolder fixup)
		{
			if (this.m_count == this.m_values.Length)
			{
				this.EnlargeArray();
			}
			FixupHolder[] values = this.m_values;
			int count = this.m_count;
			this.m_count = count + 1;
			values[count] = fixup;
		}

		// Token: 0x060052B1 RID: 21169 RVA: 0x00122B58 File Offset: 0x00120D58
		private void EnlargeArray()
		{
			int num = this.m_values.Length * 2;
			if (num < 0)
			{
				if (num == 2147483647)
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_TooManyElements"));
				}
				num = int.MaxValue;
			}
			FixupHolder[] array = new FixupHolder[num];
			Array.Copy(this.m_values, array, this.m_count);
			this.m_values = array;
		}

		// Token: 0x0400249E RID: 9374
		internal const int InitialSize = 2;

		// Token: 0x0400249F RID: 9375
		internal FixupHolder[] m_values;

		// Token: 0x040024A0 RID: 9376
		internal int m_count;
	}
}
