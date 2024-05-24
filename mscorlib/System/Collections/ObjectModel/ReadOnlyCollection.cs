using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Collections.ObjectModel
{
	// Token: 0x020004B5 RID: 1205
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public class ReadOnlyCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<!0>, IReadOnlyCollection<T>
	{
		// Token: 0x060039C5 RID: 14789 RVA: 0x000DCF75 File Offset: 0x000DB175
		[__DynamicallyInvokable]
		public ReadOnlyCollection(IList<T> list)
		{
			if (list == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.list);
			}
			this.list = list;
		}

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x060039C6 RID: 14790 RVA: 0x000DCF8D File Offset: 0x000DB18D
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list.Count;
			}
		}

		// Token: 0x170008B0 RID: 2224
		[__DynamicallyInvokable]
		public T this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list[index];
			}
		}

		// Token: 0x060039C8 RID: 14792 RVA: 0x000DCFA8 File Offset: 0x000DB1A8
		[__DynamicallyInvokable]
		public bool Contains(T value)
		{
			return this.list.Contains(value);
		}

		// Token: 0x060039C9 RID: 14793 RVA: 0x000DCFB6 File Offset: 0x000DB1B6
		[__DynamicallyInvokable]
		public void CopyTo(T[] array, int index)
		{
			this.list.CopyTo(array, index);
		}

		// Token: 0x060039CA RID: 14794 RVA: 0x000DCFC5 File Offset: 0x000DB1C5
		[__DynamicallyInvokable]
		public IEnumerator<T> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		// Token: 0x060039CB RID: 14795 RVA: 0x000DCFD2 File Offset: 0x000DB1D2
		[__DynamicallyInvokable]
		public int IndexOf(T value)
		{
			return this.list.IndexOf(value);
		}

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x060039CC RID: 14796 RVA: 0x000DCFE0 File Offset: 0x000DB1E0
		[__DynamicallyInvokable]
		protected IList<T> Items
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list;
			}
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x060039CD RID: 14797 RVA: 0x000DCFE8 File Offset: 0x000DB1E8
		[__DynamicallyInvokable]
		bool ICollection<!0>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x170008B3 RID: 2227
		[__DynamicallyInvokable]
		T IList<!0>.this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list[index];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		// Token: 0x060039D0 RID: 14800 RVA: 0x000DD002 File Offset: 0x000DB202
		[__DynamicallyInvokable]
		void ICollection<!0>.Add(T value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039D1 RID: 14801 RVA: 0x000DD00B File Offset: 0x000DB20B
		[__DynamicallyInvokable]
		void ICollection<!0>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039D2 RID: 14802 RVA: 0x000DD014 File Offset: 0x000DB214
		[__DynamicallyInvokable]
		void IList<!0>.Insert(int index, T value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039D3 RID: 14803 RVA: 0x000DD01D File Offset: 0x000DB21D
		[__DynamicallyInvokable]
		bool ICollection<!0>.Remove(T value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return false;
		}

		// Token: 0x060039D4 RID: 14804 RVA: 0x000DD027 File Offset: 0x000DB227
		[__DynamicallyInvokable]
		void IList<!0>.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039D5 RID: 14805 RVA: 0x000DD030 File Offset: 0x000DB230
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x060039D6 RID: 14806 RVA: 0x000DD03D File Offset: 0x000DB23D
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x060039D7 RID: 14807 RVA: 0x000DD040 File Offset: 0x000DB240
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				if (this._syncRoot == null)
				{
					ICollection collection = this.list as ICollection;
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

		// Token: 0x060039D8 RID: 14808 RVA: 0x000DD08C File Offset: 0x000DB28C
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
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.arrayIndex, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			if (array.Length - index < this.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			T[] array2 = array as T[];
			if (array2 != null)
			{
				this.list.CopyTo(array2, index);
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
			int count = this.list.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					array3[index++] = this.list[i];
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
		}

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x060039D9 RID: 14809 RVA: 0x000DD190 File Offset: 0x000DB390
		[__DynamicallyInvokable]
		bool IList.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x060039DA RID: 14810 RVA: 0x000DD193 File Offset: 0x000DB393
		[__DynamicallyInvokable]
		bool IList.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x170008B8 RID: 2232
		[__DynamicallyInvokable]
		object IList.this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list[index];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		// Token: 0x060039DD RID: 14813 RVA: 0x000DD1B2 File Offset: 0x000DB3B2
		[__DynamicallyInvokable]
		int IList.Add(object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return -1;
		}

		// Token: 0x060039DE RID: 14814 RVA: 0x000DD1BC File Offset: 0x000DB3BC
		[__DynamicallyInvokable]
		void IList.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039DF RID: 14815 RVA: 0x000DD1C8 File Offset: 0x000DB3C8
		private static bool IsCompatibleObject(object value)
		{
			return value is T || (value == null && default(T) == null);
		}

		// Token: 0x060039E0 RID: 14816 RVA: 0x000DD1F5 File Offset: 0x000DB3F5
		[__DynamicallyInvokable]
		bool IList.Contains(object value)
		{
			return ReadOnlyCollection<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
		}

		// Token: 0x060039E1 RID: 14817 RVA: 0x000DD20D File Offset: 0x000DB40D
		[__DynamicallyInvokable]
		int IList.IndexOf(object value)
		{
			if (ReadOnlyCollection<T>.IsCompatibleObject(value))
			{
				return this.IndexOf((T)((object)value));
			}
			return -1;
		}

		// Token: 0x060039E2 RID: 14818 RVA: 0x000DD225 File Offset: 0x000DB425
		[__DynamicallyInvokable]
		void IList.Insert(int index, object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039E3 RID: 14819 RVA: 0x000DD22E File Offset: 0x000DB42E
		[__DynamicallyInvokable]
		void IList.Remove(object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039E4 RID: 14820 RVA: 0x000DD237 File Offset: 0x000DB437
		[__DynamicallyInvokable]
		void IList.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x0400192E RID: 6446
		private IList<T> list;

		// Token: 0x0400192F RID: 6447
		[NonSerialized]
		private object _syncRoot;
	}
}
