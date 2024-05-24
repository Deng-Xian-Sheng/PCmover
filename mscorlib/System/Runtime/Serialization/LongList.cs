using System;

namespace System.Runtime.Serialization
{
	// Token: 0x0200074E RID: 1870
	[Serializable]
	internal class LongList
	{
		// Token: 0x060052B2 RID: 21170 RVA: 0x00122BB2 File Offset: 0x00120DB2
		internal LongList() : this(2)
		{
		}

		// Token: 0x060052B3 RID: 21171 RVA: 0x00122BBB File Offset: 0x00120DBB
		internal LongList(int startingSize)
		{
			this.m_count = 0;
			this.m_totalItems = 0;
			this.m_values = new long[startingSize];
		}

		// Token: 0x060052B4 RID: 21172 RVA: 0x00122BE0 File Offset: 0x00120DE0
		internal void Add(long value)
		{
			if (this.m_totalItems == this.m_values.Length)
			{
				this.EnlargeArray();
			}
			long[] values = this.m_values;
			int totalItems = this.m_totalItems;
			this.m_totalItems = totalItems + 1;
			values[totalItems] = value;
			this.m_count++;
		}

		// Token: 0x17000DAB RID: 3499
		// (get) Token: 0x060052B5 RID: 21173 RVA: 0x00122C2A File Offset: 0x00120E2A
		internal int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x060052B6 RID: 21174 RVA: 0x00122C32 File Offset: 0x00120E32
		internal void StartEnumeration()
		{
			this.m_currentItem = -1;
		}

		// Token: 0x060052B7 RID: 21175 RVA: 0x00122C3C File Offset: 0x00120E3C
		internal bool MoveNext()
		{
			int num;
			do
			{
				num = this.m_currentItem + 1;
				this.m_currentItem = num;
			}
			while (num < this.m_totalItems && this.m_values[this.m_currentItem] == -1L);
			return this.m_currentItem != this.m_totalItems;
		}

		// Token: 0x17000DAC RID: 3500
		// (get) Token: 0x060052B8 RID: 21176 RVA: 0x00122C84 File Offset: 0x00120E84
		internal long Current
		{
			get
			{
				return this.m_values[this.m_currentItem];
			}
		}

		// Token: 0x060052B9 RID: 21177 RVA: 0x00122C94 File Offset: 0x00120E94
		internal bool RemoveElement(long value)
		{
			int num = 0;
			while (num < this.m_totalItems && this.m_values[num] != value)
			{
				num++;
			}
			if (num == this.m_totalItems)
			{
				return false;
			}
			this.m_values[num] = -1L;
			return true;
		}

		// Token: 0x060052BA RID: 21178 RVA: 0x00122CD4 File Offset: 0x00120ED4
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
			long[] array = new long[num];
			Array.Copy(this.m_values, array, this.m_count);
			this.m_values = array;
		}

		// Token: 0x040024A1 RID: 9377
		private const int InitialSize = 2;

		// Token: 0x040024A2 RID: 9378
		private long[] m_values;

		// Token: 0x040024A3 RID: 9379
		private int m_count;

		// Token: 0x040024A4 RID: 9380
		private int m_totalItems;

		// Token: 0x040024A5 RID: 9381
		private int m_currentItem;
	}
}
