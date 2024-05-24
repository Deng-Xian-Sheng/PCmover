using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Collections.ObjectModel
{
	// Token: 0x020004B8 RID: 1208
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(Mscorlib_KeyedCollectionDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class KeyedCollection<TKey, TItem> : Collection<TItem>
	{
		// Token: 0x06003A0D RID: 14861 RVA: 0x000DD720 File Offset: 0x000DB920
		[__DynamicallyInvokable]
		protected KeyedCollection() : this(null, 0)
		{
		}

		// Token: 0x06003A0E RID: 14862 RVA: 0x000DD72A File Offset: 0x000DB92A
		[__DynamicallyInvokable]
		protected KeyedCollection(IEqualityComparer<TKey> comparer) : this(comparer, 0)
		{
		}

		// Token: 0x06003A0F RID: 14863 RVA: 0x000DD734 File Offset: 0x000DB934
		[__DynamicallyInvokable]
		protected KeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold)
		{
			if (comparer == null)
			{
				comparer = EqualityComparer<TKey>.Default;
			}
			if (dictionaryCreationThreshold == -1)
			{
				dictionaryCreationThreshold = int.MaxValue;
			}
			if (dictionaryCreationThreshold < -1)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.dictionaryCreationThreshold, ExceptionResource.ArgumentOutOfRange_InvalidThreshold);
			}
			this.comparer = comparer;
			this.threshold = dictionaryCreationThreshold;
		}

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x06003A10 RID: 14864 RVA: 0x000DD76B File Offset: 0x000DB96B
		[__DynamicallyInvokable]
		public IEqualityComparer<TKey> Comparer
		{
			[__DynamicallyInvokable]
			get
			{
				return this.comparer;
			}
		}

		// Token: 0x170008CC RID: 2252
		[__DynamicallyInvokable]
		public TItem this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				if (key == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
				}
				if (this.dict != null)
				{
					return this.dict[key];
				}
				foreach (TItem titem in base.Items)
				{
					if (this.comparer.Equals(this.GetKeyForItem(titem), key))
					{
						return titem;
					}
				}
				ThrowHelper.ThrowKeyNotFoundException();
				return default(TItem);
			}
		}

		// Token: 0x06003A12 RID: 14866 RVA: 0x000DD808 File Offset: 0x000DBA08
		[__DynamicallyInvokable]
		public bool Contains(TKey key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.dict != null)
			{
				return this.dict.ContainsKey(key);
			}
			if (key != null)
			{
				foreach (TItem item in base.Items)
				{
					if (this.comparer.Equals(this.GetKeyForItem(item), key))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06003A13 RID: 14867 RVA: 0x000DD898 File Offset: 0x000DBA98
		private bool ContainsItem(TItem item)
		{
			TKey keyForItem;
			if (this.dict == null || (keyForItem = this.GetKeyForItem(item)) == null)
			{
				return base.Items.Contains(item);
			}
			TItem x;
			bool flag = this.dict.TryGetValue(keyForItem, out x);
			return flag && EqualityComparer<TItem>.Default.Equals(x, item);
		}

		// Token: 0x06003A14 RID: 14868 RVA: 0x000DD8EC File Offset: 0x000DBAEC
		[__DynamicallyInvokable]
		public bool Remove(TKey key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.dict != null)
			{
				return this.dict.ContainsKey(key) && base.Remove(this.dict[key]);
			}
			if (key != null)
			{
				for (int i = 0; i < base.Items.Count; i++)
				{
					if (this.comparer.Equals(this.GetKeyForItem(base.Items[i]), key))
					{
						this.RemoveItem(i);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x06003A15 RID: 14869 RVA: 0x000DD97A File Offset: 0x000DBB7A
		[__DynamicallyInvokable]
		protected IDictionary<TKey, TItem> Dictionary
		{
			[__DynamicallyInvokable]
			get
			{
				return this.dict;
			}
		}

		// Token: 0x06003A16 RID: 14870 RVA: 0x000DD984 File Offset: 0x000DBB84
		[__DynamicallyInvokable]
		protected void ChangeItemKey(TItem item, TKey newKey)
		{
			if (!this.ContainsItem(item))
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_ItemNotExist);
			}
			TKey keyForItem = this.GetKeyForItem(item);
			if (!this.comparer.Equals(keyForItem, newKey))
			{
				if (newKey != null)
				{
					this.AddKey(newKey, item);
				}
				if (keyForItem != null)
				{
					this.RemoveKey(keyForItem);
				}
			}
		}

		// Token: 0x06003A17 RID: 14871 RVA: 0x000DD9D7 File Offset: 0x000DBBD7
		[__DynamicallyInvokable]
		protected override void ClearItems()
		{
			base.ClearItems();
			if (this.dict != null)
			{
				this.dict.Clear();
			}
			this.keyCount = 0;
		}

		// Token: 0x06003A18 RID: 14872
		[__DynamicallyInvokable]
		protected abstract TKey GetKeyForItem(TItem item);

		// Token: 0x06003A19 RID: 14873 RVA: 0x000DD9FC File Offset: 0x000DBBFC
		[__DynamicallyInvokable]
		protected override void InsertItem(int index, TItem item)
		{
			TKey keyForItem = this.GetKeyForItem(item);
			if (keyForItem != null)
			{
				this.AddKey(keyForItem, item);
			}
			base.InsertItem(index, item);
		}

		// Token: 0x06003A1A RID: 14874 RVA: 0x000DDA2C File Offset: 0x000DBC2C
		[__DynamicallyInvokable]
		protected override void RemoveItem(int index)
		{
			TKey keyForItem = this.GetKeyForItem(base.Items[index]);
			if (keyForItem != null)
			{
				this.RemoveKey(keyForItem);
			}
			base.RemoveItem(index);
		}

		// Token: 0x06003A1B RID: 14875 RVA: 0x000DDA64 File Offset: 0x000DBC64
		[__DynamicallyInvokable]
		protected override void SetItem(int index, TItem item)
		{
			TKey keyForItem = this.GetKeyForItem(item);
			TKey keyForItem2 = this.GetKeyForItem(base.Items[index]);
			if (this.comparer.Equals(keyForItem2, keyForItem))
			{
				if (keyForItem != null && this.dict != null)
				{
					this.dict[keyForItem] = item;
				}
			}
			else
			{
				if (keyForItem != null)
				{
					this.AddKey(keyForItem, item);
				}
				if (keyForItem2 != null)
				{
					this.RemoveKey(keyForItem2);
				}
			}
			base.SetItem(index, item);
		}

		// Token: 0x06003A1C RID: 14876 RVA: 0x000DDAE4 File Offset: 0x000DBCE4
		private void AddKey(TKey key, TItem item)
		{
			if (this.dict != null)
			{
				this.dict.Add(key, item);
				return;
			}
			if (this.keyCount == this.threshold)
			{
				this.CreateDictionary();
				this.dict.Add(key, item);
				return;
			}
			if (this.Contains(key))
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
			}
			this.keyCount++;
		}

		// Token: 0x06003A1D RID: 14877 RVA: 0x000DDB48 File Offset: 0x000DBD48
		private void CreateDictionary()
		{
			this.dict = new Dictionary<TKey, TItem>(this.comparer);
			foreach (TItem titem in base.Items)
			{
				TKey keyForItem = this.GetKeyForItem(titem);
				if (keyForItem != null)
				{
					this.dict.Add(keyForItem, titem);
				}
			}
		}

		// Token: 0x06003A1E RID: 14878 RVA: 0x000DDBBC File Offset: 0x000DBDBC
		private void RemoveKey(TKey key)
		{
			if (this.dict != null)
			{
				this.dict.Remove(key);
				return;
			}
			this.keyCount--;
		}

		// Token: 0x04001934 RID: 6452
		private const int defaultThreshold = 0;

		// Token: 0x04001935 RID: 6453
		private IEqualityComparer<TKey> comparer;

		// Token: 0x04001936 RID: 6454
		private Dictionary<TKey, TItem> dict;

		// Token: 0x04001937 RID: 6455
		private int keyCount;

		// Token: 0x04001938 RID: 6456
		private int threshold;
	}
}
