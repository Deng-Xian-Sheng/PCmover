using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System
{
	// Token: 0x02000056 RID: 86
	internal sealed class SZArrayHelper
	{
		// Token: 0x0600030C RID: 780 RVA: 0x00007BB1 File Offset: 0x00005DB1
		private SZArrayHelper()
		{
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00007BBC File Offset: 0x00005DBC
		[SecuritySafeCritical]
		internal IEnumerator<T> GetEnumerator<T>()
		{
			T[] array = JitHelpers.UnsafeCast<T[]>(this);
			int num = array.Length;
			if (num != 0)
			{
				return new SZArrayHelper.SZGenericArrayEnumerator<T>(array, num);
			}
			return SZArrayHelper.SZGenericArrayEnumerator<T>.Empty;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00007BE4 File Offset: 0x00005DE4
		[SecuritySafeCritical]
		private void CopyTo<T>(T[] array, int index)
		{
			if (array != null && array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
			}
			T[] array2 = JitHelpers.UnsafeCast<T[]>(this);
			Array.Copy(array2, 0, array, index, array2.Length);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00007C20 File Offset: 0x00005E20
		[SecuritySafeCritical]
		internal int get_Count<T>()
		{
			T[] array = JitHelpers.UnsafeCast<T[]>(this);
			return array.Length;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00007C38 File Offset: 0x00005E38
		[SecuritySafeCritical]
		internal T get_Item<T>(int index)
		{
			T[] array = JitHelpers.UnsafeCast<T[]>(this);
			if (index >= array.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}
			return array[index];
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00007C60 File Offset: 0x00005E60
		[SecuritySafeCritical]
		internal void set_Item<T>(int index, T value)
		{
			T[] array = JitHelpers.UnsafeCast<T[]>(this);
			if (index >= array.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}
			array[index] = value;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00007C87 File Offset: 0x00005E87
		private void Add<T>(T value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00007C98 File Offset: 0x00005E98
		[SecuritySafeCritical]
		private bool Contains<T>(T value)
		{
			T[] array = JitHelpers.UnsafeCast<T[]>(this);
			return Array.IndexOf<T>(array, value) != -1;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00007CB9 File Offset: 0x00005EB9
		private bool get_IsReadOnly<T>()
		{
			return true;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00007CBC File Offset: 0x00005EBC
		private void Clear<T>()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_ReadOnlyCollection"));
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00007CD0 File Offset: 0x00005ED0
		[SecuritySafeCritical]
		private int IndexOf<T>(T value)
		{
			T[] array = JitHelpers.UnsafeCast<T[]>(this);
			return Array.IndexOf<T>(array, value);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00007CEB File Offset: 0x00005EEB
		private void Insert<T>(int index, T value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00007CFC File Offset: 0x00005EFC
		private bool Remove<T>(T value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00007D0D File Offset: 0x00005F0D
		private void RemoveAt<T>(int index)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
		}

		// Token: 0x02000AC4 RID: 2756
		[Serializable]
		private sealed class SZGenericArrayEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
		{
			// Token: 0x060069B8 RID: 27064 RVA: 0x0016C926 File Offset: 0x0016AB26
			internal SZGenericArrayEnumerator(T[] array, int endIndex)
			{
				this._array = array;
				this._index = -1;
				this._endIndex = endIndex;
			}

			// Token: 0x060069B9 RID: 27065 RVA: 0x0016C943 File Offset: 0x0016AB43
			public bool MoveNext()
			{
				if (this._index < this._endIndex)
				{
					this._index++;
					return this._index < this._endIndex;
				}
				return false;
			}

			// Token: 0x170011E9 RID: 4585
			// (get) Token: 0x060069BA RID: 27066 RVA: 0x0016C974 File Offset: 0x0016AB74
			public T Current
			{
				get
				{
					if (this._index < 0)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this._index >= this._endIndex)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					return this._array[this._index];
				}
			}

			// Token: 0x170011EA RID: 4586
			// (get) Token: 0x060069BB RID: 27067 RVA: 0x0016C9C9 File Offset: 0x0016ABC9
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060069BC RID: 27068 RVA: 0x0016C9D6 File Offset: 0x0016ABD6
			void IEnumerator.Reset()
			{
				this._index = -1;
			}

			// Token: 0x060069BD RID: 27069 RVA: 0x0016C9DF File Offset: 0x0016ABDF
			public void Dispose()
			{
			}

			// Token: 0x040030CD RID: 12493
			private T[] _array;

			// Token: 0x040030CE RID: 12494
			private int _index;

			// Token: 0x040030CF RID: 12495
			private int _endIndex;

			// Token: 0x040030D0 RID: 12496
			internal static readonly SZArrayHelper.SZGenericArrayEnumerator<T> Empty = new SZArrayHelper.SZGenericArrayEnumerator<T>(null, -1);
		}
	}
}
