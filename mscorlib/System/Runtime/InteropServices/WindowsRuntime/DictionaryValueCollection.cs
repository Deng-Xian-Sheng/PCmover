using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009CE RID: 2510
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	internal sealed class DictionaryValueCollection<TKey, TValue> : ICollection<!1>, IEnumerable<!1>, IEnumerable
	{
		// Token: 0x060063E9 RID: 25577 RVA: 0x00154D6F File Offset: 0x00152F6F
		public DictionaryValueCollection(IDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
		}

		// Token: 0x060063EA RID: 25578 RVA: 0x00154D8C File Offset: 0x00152F8C
		public void CopyTo(TValue[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length <= index && this.Count > 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_IndexOutOfRangeException"));
			}
			if (array.Length - index < this.dictionary.Count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InsufficientSpaceToCopyCollection"));
			}
			int num = index;
			foreach (KeyValuePair<TKey, TValue> keyValuePair in this.dictionary)
			{
				array[num++] = keyValuePair.Value;
			}
		}

		// Token: 0x17001149 RID: 4425
		// (get) Token: 0x060063EB RID: 25579 RVA: 0x00154E44 File Offset: 0x00153044
		public int Count
		{
			get
			{
				return this.dictionary.Count;
			}
		}

		// Token: 0x1700114A RID: 4426
		// (get) Token: 0x060063EC RID: 25580 RVA: 0x00154E51 File Offset: 0x00153051
		bool ICollection<!1>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060063ED RID: 25581 RVA: 0x00154E54 File Offset: 0x00153054
		void ICollection<!1>.Add(TValue item)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_ValueCollectionSet"));
		}

		// Token: 0x060063EE RID: 25582 RVA: 0x00154E65 File Offset: 0x00153065
		void ICollection<!1>.Clear()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_ValueCollectionSet"));
		}

		// Token: 0x060063EF RID: 25583 RVA: 0x00154E78 File Offset: 0x00153078
		public bool Contains(TValue item)
		{
			EqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
			foreach (TValue y in this)
			{
				if (@default.Equals(item, y))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060063F0 RID: 25584 RVA: 0x00154ED0 File Offset: 0x001530D0
		bool ICollection<!1>.Remove(TValue item)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_ValueCollectionSet"));
		}

		// Token: 0x060063F1 RID: 25585 RVA: 0x00154EE1 File Offset: 0x001530E1
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<!1>)this).GetEnumerator();
		}

		// Token: 0x060063F2 RID: 25586 RVA: 0x00154EE9 File Offset: 0x001530E9
		public IEnumerator<TValue> GetEnumerator()
		{
			return new DictionaryValueEnumerator<TKey, TValue>(this.dictionary);
		}

		// Token: 0x04002CE1 RID: 11489
		private readonly IDictionary<TKey, TValue> dictionary;
	}
}
