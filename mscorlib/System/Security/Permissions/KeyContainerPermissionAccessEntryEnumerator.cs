using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000316 RID: 790
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermissionAccessEntryEnumerator : IEnumerator
	{
		// Token: 0x060027D5 RID: 10197 RVA: 0x00090D52 File Offset: 0x0008EF52
		private KeyContainerPermissionAccessEntryEnumerator()
		{
		}

		// Token: 0x060027D6 RID: 10198 RVA: 0x00090D5A File Offset: 0x0008EF5A
		internal KeyContainerPermissionAccessEntryEnumerator(KeyContainerPermissionAccessEntryCollection entries)
		{
			this.m_entries = entries;
			this.m_current = -1;
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060027D7 RID: 10199 RVA: 0x00090D70 File Offset: 0x0008EF70
		public KeyContainerPermissionAccessEntry Current
		{
			get
			{
				return this.m_entries[this.m_current];
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060027D8 RID: 10200 RVA: 0x00090D83 File Offset: 0x0008EF83
		object IEnumerator.Current
		{
			get
			{
				return this.m_entries[this.m_current];
			}
		}

		// Token: 0x060027D9 RID: 10201 RVA: 0x00090D96 File Offset: 0x0008EF96
		public bool MoveNext()
		{
			if (this.m_current == this.m_entries.Count - 1)
			{
				return false;
			}
			this.m_current++;
			return true;
		}

		// Token: 0x060027DA RID: 10202 RVA: 0x00090DBE File Offset: 0x0008EFBE
		public void Reset()
		{
			this.m_current = -1;
		}

		// Token: 0x04000F6A RID: 3946
		private KeyContainerPermissionAccessEntryCollection m_entries;

		// Token: 0x04000F6B RID: 3947
		private int m_current;
	}
}
