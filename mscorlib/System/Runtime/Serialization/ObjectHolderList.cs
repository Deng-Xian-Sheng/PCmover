using System;

namespace System.Runtime.Serialization
{
	// Token: 0x0200074F RID: 1871
	internal class ObjectHolderList
	{
		// Token: 0x060052BB RID: 21179 RVA: 0x00122D2E File Offset: 0x00120F2E
		internal ObjectHolderList() : this(8)
		{
		}

		// Token: 0x060052BC RID: 21180 RVA: 0x00122D37 File Offset: 0x00120F37
		internal ObjectHolderList(int startingSize)
		{
			this.m_count = 0;
			this.m_values = new ObjectHolder[startingSize];
		}

		// Token: 0x060052BD RID: 21181 RVA: 0x00122D54 File Offset: 0x00120F54
		internal virtual void Add(ObjectHolder value)
		{
			if (this.m_count == this.m_values.Length)
			{
				this.EnlargeArray();
			}
			ObjectHolder[] values = this.m_values;
			int count = this.m_count;
			this.m_count = count + 1;
			values[count] = value;
		}

		// Token: 0x060052BE RID: 21182 RVA: 0x00122D90 File Offset: 0x00120F90
		internal ObjectHolderListEnumerator GetFixupEnumerator()
		{
			return new ObjectHolderListEnumerator(this, true);
		}

		// Token: 0x060052BF RID: 21183 RVA: 0x00122D9C File Offset: 0x00120F9C
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
			ObjectHolder[] array = new ObjectHolder[num];
			Array.Copy(this.m_values, array, this.m_count);
			this.m_values = array;
		}

		// Token: 0x17000DAD RID: 3501
		// (get) Token: 0x060052C0 RID: 21184 RVA: 0x00122DF6 File Offset: 0x00120FF6
		internal int Version
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x17000DAE RID: 3502
		// (get) Token: 0x060052C1 RID: 21185 RVA: 0x00122DFE File Offset: 0x00120FFE
		internal int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x040024A6 RID: 9382
		internal const int DefaultInitialSize = 8;

		// Token: 0x040024A7 RID: 9383
		internal ObjectHolder[] m_values;

		// Token: 0x040024A8 RID: 9384
		internal int m_count;
	}
}
