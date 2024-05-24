using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000315 RID: 789
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermissionAccessEntryCollection : ICollection, IEnumerable
	{
		// Token: 0x060027C7 RID: 10183 RVA: 0x00090B71 File Offset: 0x0008ED71
		private KeyContainerPermissionAccessEntryCollection()
		{
		}

		// Token: 0x060027C8 RID: 10184 RVA: 0x00090B79 File Offset: 0x0008ED79
		internal KeyContainerPermissionAccessEntryCollection(KeyContainerPermissionFlags globalFlags)
		{
			this.m_list = new ArrayList();
			this.m_globalFlags = globalFlags;
		}

		// Token: 0x17000516 RID: 1302
		public KeyContainerPermissionAccessEntry this[int index]
		{
			get
			{
				if (index < 0)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
				}
				if (index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				return (KeyContainerPermissionAccessEntry)this.m_list[index];
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060027CA RID: 10186 RVA: 0x00090BE4 File Offset: 0x0008EDE4
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x060027CB RID: 10187 RVA: 0x00090BF4 File Offset: 0x0008EDF4
		public int Add(KeyContainerPermissionAccessEntry accessEntry)
		{
			if (accessEntry == null)
			{
				throw new ArgumentNullException("accessEntry");
			}
			int num = this.m_list.IndexOf(accessEntry);
			if (num != -1)
			{
				((KeyContainerPermissionAccessEntry)this.m_list[num]).Flags &= accessEntry.Flags;
				return num;
			}
			if (accessEntry.Flags != this.m_globalFlags)
			{
				return this.m_list.Add(accessEntry);
			}
			return -1;
		}

		// Token: 0x060027CC RID: 10188 RVA: 0x00090C61 File Offset: 0x0008EE61
		public void Clear()
		{
			this.m_list.Clear();
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x00090C6E File Offset: 0x0008EE6E
		public int IndexOf(KeyContainerPermissionAccessEntry accessEntry)
		{
			return this.m_list.IndexOf(accessEntry);
		}

		// Token: 0x060027CE RID: 10190 RVA: 0x00090C7C File Offset: 0x0008EE7C
		public void Remove(KeyContainerPermissionAccessEntry accessEntry)
		{
			if (accessEntry == null)
			{
				throw new ArgumentNullException("accessEntry");
			}
			this.m_list.Remove(accessEntry);
		}

		// Token: 0x060027CF RID: 10191 RVA: 0x00090C98 File Offset: 0x0008EE98
		public KeyContainerPermissionAccessEntryEnumerator GetEnumerator()
		{
			return new KeyContainerPermissionAccessEntryEnumerator(this);
		}

		// Token: 0x060027D0 RID: 10192 RVA: 0x00090CA0 File Offset: 0x0008EEA0
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new KeyContainerPermissionAccessEntryEnumerator(this);
		}

		// Token: 0x060027D1 RID: 10193 RVA: 0x00090CA8 File Offset: 0x0008EEA8
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (index < 0 || index >= array.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (index + this.Count > array.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			for (int i = 0; i < this.Count; i++)
			{
				array.SetValue(this[i], index);
				index++;
			}
		}

		// Token: 0x060027D2 RID: 10194 RVA: 0x00090D42 File Offset: 0x0008EF42
		public void CopyTo(KeyContainerPermissionAccessEntry[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060027D3 RID: 10195 RVA: 0x00090D4C File Offset: 0x0008EF4C
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060027D4 RID: 10196 RVA: 0x00090D4F File Offset: 0x0008EF4F
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x04000F68 RID: 3944
		private ArrayList m_list;

		// Token: 0x04000F69 RID: 3945
		private KeyContainerPermissionFlags m_globalFlags;
	}
}
