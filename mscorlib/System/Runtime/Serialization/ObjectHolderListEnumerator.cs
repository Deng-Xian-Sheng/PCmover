using System;

namespace System.Runtime.Serialization
{
	// Token: 0x02000750 RID: 1872
	internal class ObjectHolderListEnumerator
	{
		// Token: 0x060052C2 RID: 21186 RVA: 0x00122E06 File Offset: 0x00121006
		internal ObjectHolderListEnumerator(ObjectHolderList list, bool isFixupEnumerator)
		{
			this.m_list = list;
			this.m_startingVersion = this.m_list.Version;
			this.m_currPos = -1;
			this.m_isFixupEnumerator = isFixupEnumerator;
		}

		// Token: 0x060052C3 RID: 21187 RVA: 0x00122E34 File Offset: 0x00121034
		internal bool MoveNext()
		{
			if (this.m_isFixupEnumerator)
			{
				int num;
				do
				{
					num = this.m_currPos + 1;
					this.m_currPos = num;
				}
				while (num < this.m_list.Count && this.m_list.m_values[this.m_currPos].CompletelyFixed);
				return this.m_currPos != this.m_list.Count;
			}
			this.m_currPos++;
			return this.m_currPos != this.m_list.Count;
		}

		// Token: 0x17000DAF RID: 3503
		// (get) Token: 0x060052C4 RID: 21188 RVA: 0x00122EBB File Offset: 0x001210BB
		internal ObjectHolder Current
		{
			get
			{
				return this.m_list.m_values[this.m_currPos];
			}
		}

		// Token: 0x040024A9 RID: 9385
		private bool m_isFixupEnumerator;

		// Token: 0x040024AA RID: 9386
		private ObjectHolderList m_list;

		// Token: 0x040024AB RID: 9387
		private int m_startingVersion;

		// Token: 0x040024AC RID: 9388
		private int m_currPos;
	}
}
