using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Collections.ObjectModel
{
	// Token: 0x020004B4 RID: 1204
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public class Collection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<!0>, IReadOnlyCollection<T>
	{
		// Token: 0x060039A3 RID: 14755 RVA: 0x000DCA30 File Offset: 0x000DAC30
		[__DynamicallyInvokable]
		public Collection()
		{
			this.items = new List<T>();
		}

		// Token: 0x060039A4 RID: 14756 RVA: 0x000DCA43 File Offset: 0x000DAC43
		[__DynamicallyInvokable]
		public Collection(IList<T> list)
		{
			if (list == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.list);
			}
			this.items = list;
		}

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x060039A5 RID: 14757 RVA: 0x000DCA5B File Offset: 0x000DAC5B
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.items.Count;
			}
		}

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x060039A6 RID: 14758 RVA: 0x000DCA68 File Offset: 0x000DAC68
		[__DynamicallyInvokable]
		protected IList<T> Items
		{
			[__DynamicallyInvokable]
			get
			{
				return this.items;
			}
		}

		// Token: 0x170008A8 RID: 2216
		[__DynamicallyInvokable]
		public T this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.items[index];
			}
			[__DynamicallyInvokable]
			set
			{
				if (this.items.IsReadOnly)
				{
					ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
				}
				if (index < 0 || index >= this.items.Count)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException();
				}
				this.SetItem(index, value);
			}
		}

		// Token: 0x060039A9 RID: 14761 RVA: 0x000DCAB4 File Offset: 0x000DACB4
		[__DynamicallyInvokable]
		public void Add(T item)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			int count = this.items.Count;
			this.InsertItem(count, item);
		}

		// Token: 0x060039AA RID: 14762 RVA: 0x000DCAE9 File Offset: 0x000DACE9
		[__DynamicallyInvokable]
		public void Clear()
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			this.ClearItems();
		}

		// Token: 0x060039AB RID: 14763 RVA: 0x000DCB05 File Offset: 0x000DAD05
		[__DynamicallyInvokable]
		public void CopyTo(T[] array, int index)
		{
			this.items.CopyTo(array, index);
		}

		// Token: 0x060039AC RID: 14764 RVA: 0x000DCB14 File Offset: 0x000DAD14
		[__DynamicallyInvokable]
		public bool Contains(T item)
		{
			return this.items.Contains(item);
		}

		// Token: 0x060039AD RID: 14765 RVA: 0x000DCB22 File Offset: 0x000DAD22
		[__DynamicallyInvokable]
		public IEnumerator<T> GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		// Token: 0x060039AE RID: 14766 RVA: 0x000DCB2F File Offset: 0x000DAD2F
		[__DynamicallyInvokable]
		public int IndexOf(T item)
		{
			return this.items.IndexOf(item);
		}

		// Token: 0x060039AF RID: 14767 RVA: 0x000DCB3D File Offset: 0x000DAD3D
		[__DynamicallyInvokable]
		public void Insert(int index, T item)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			if (index < 0 || index > this.items.Count)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_ListInsert);
			}
			this.InsertItem(index, item);
		}

		// Token: 0x060039B0 RID: 14768 RVA: 0x000DCB78 File Offset: 0x000DAD78
		[__DynamicallyInvokable]
		public bool Remove(T item)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			int num = this.items.IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			this.RemoveItem(num);
			return true;
		}

		// Token: 0x060039B1 RID: 14769 RVA: 0x000DCBB4 File Offset: 0x000DADB4
		[__DynamicallyInvokable]
		public void RemoveAt(int index)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			if (index < 0 || index >= this.items.Count)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}
			this.RemoveItem(index);
		}

		// Token: 0x060039B2 RID: 14770 RVA: 0x000DCBE8 File Offset: 0x000DADE8
		[__DynamicallyInvokable]
		protected virtual void ClearItems()
		{
			this.items.Clear();
		}

		// Token: 0x060039B3 RID: 14771 RVA: 0x000DCBF5 File Offset: 0x000DADF5
		[__DynamicallyInvokable]
		protected virtual void InsertItem(int index, T item)
		{
			this.items.Insert(index, item);
		}

		// Token: 0x060039B4 RID: 14772 RVA: 0x000DCC04 File Offset: 0x000DAE04
		[__DynamicallyInvokable]
		protected virtual void RemoveItem(int index)
		{
			this.items.RemoveAt(index);
		}

		// Token: 0x060039B5 RID: 14773 RVA: 0x000DCC12 File Offset: 0x000DAE12
		[__DynamicallyInvokable]
		protected virtual void SetItem(int index, T item)
		{
			this.items[index] = item;
		}

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x060039B6 RID: 14774 RVA: 0x000DCC21 File Offset: 0x000DAE21
		[__DynamicallyInvokable]
		bool ICollection<!0>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return this.items.IsReadOnly;
			}
		}

		// Token: 0x060039B7 RID: 14775 RVA: 0x000DCC2E File Offset: 0x000DAE2E
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x060039B8 RID: 14776 RVA: 0x000DCC3B File Offset: 0x000DAE3B
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x060039B9 RID: 14777 RVA: 0x000DCC40 File Offset: 0x000DAE40
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				if (this._syncRoot == null)
				{
					ICollection collection = this.items as ICollection;
					if (collection != null)
					{
						this._syncRoot = collection.SyncRoot;
					}
					else
					{
						Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
					}
				}
				return this._syncRoot;
			}
		}

		// Token: 0x060039BA RID: 14778 RVA: 0x000DCC8C File Offset: 0x000DAE8C
		[__DynamicallyInvokable]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
			}
			if (array.Rank != 1)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
			}
			if (array.GetLowerBound(0) != 0)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
			}
			if (index < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			if (array.Length - index < this.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			T[] array2 = array as T[];
			if (array2 != null)
			{
				this.items.CopyTo(array2, index);
				return;
			}
			Type elementType = array.GetType().GetElementType();
			Type typeFromHandle = typeof(T);
			if (!elementType.IsAssignableFrom(typeFromHandle) && !typeFromHandle.IsAssignableFrom(elementType))
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			object[] array3 = array as object[];
			if (array3 == null)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			int count = this.items.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					array3[index++] = this.items[i];
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
		}

		// Token: 0x170008AC RID: 2220
		[__DynamicallyInvokable]
		object IList.this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.items[index];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(value, ExceptionArgument.value);
				try
				{
					this[index] = (T)((object)value);
				}
				catch (InvalidCastException)
				{
					ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(T));
				}
			}
		}

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x060039BD RID: 14781 RVA: 0x000DCDEC File Offset: 0x000DAFEC
		[__DynamicallyInvokable]
		bool IList.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return this.items.IsReadOnly;
			}
		}

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x060039BE RID: 14782 RVA: 0x000DCDFC File Offset: 0x000DAFFC
		[__DynamicallyInvokable]
		bool IList.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				IList list = this.items as IList;
				if (list != null)
				{
					return list.IsFixedSize;
				}
				return this.items.IsReadOnly;
			}
		}

		// Token: 0x060039BF RID: 14783 RVA: 0x000DCE2C File Offset: 0x000DB02C
		[__DynamicallyInvokable]
		int IList.Add(object value)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(value, ExceptionArgument.value);
			try
			{
				this.Add((T)((object)value));
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(T));
			}
			return this.Count - 1;
		}

		// Token: 0x060039C0 RID: 14784 RVA: 0x000DCE90 File Offset: 0x000DB090
		[__DynamicallyInvokable]
		bool IList.Contains(object value)
		{
			return Collection<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
		}

		// Token: 0x060039C1 RID: 14785 RVA: 0x000DCEA8 File Offset: 0x000DB0A8
		[__DynamicallyInvokable]
		int IList.IndexOf(object value)
		{
			if (Collection<T>.IsCompatibleObject(value))
			{
				return this.IndexOf((T)((object)value));
			}
			return -1;
		}

		// Token: 0x060039C2 RID: 14786 RVA: 0x000DCEC0 File Offset: 0x000DB0C0
		[__DynamicallyInvokable]
		void IList.Insert(int index, object value)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(value, ExceptionArgument.value);
			try
			{
				this.Insert(index, (T)((object)value));
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(T));
			}
		}

		// Token: 0x060039C3 RID: 14787 RVA: 0x000DCF1C File Offset: 0x000DB11C
		[__DynamicallyInvokable]
		void IList.Remove(object value)
		{
			if (this.items.IsReadOnly)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
			if (Collection<T>.IsCompatibleObject(value))
			{
				this.Remove((T)((object)value));
			}
		}

		// Token: 0x060039C4 RID: 14788 RVA: 0x000DCF48 File Offset: 0x000DB148
		private static bool IsCompatibleObject(object value)
		{
			return value is T || (value == null && default(T) == null);
		}

		// Token: 0x0400192C RID: 6444
		private IList<T> items;

		// Token: 0x0400192D RID: 6445
		[NonSerialized]
		private object _syncRoot;
	}
}
