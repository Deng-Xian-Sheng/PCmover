using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009CC RID: 2508
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	internal sealed class DictionaryKeyCollection<TKey, TValue> : ICollection<!0>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060063D9 RID: 25561 RVA: 0x00154BAE File Offset: 0x00152DAE
		public DictionaryKeyCollection(IDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
		}

		// Token: 0x060063DA RID: 25562 RVA: 0x00154BCC File Offset: 0x00152DCC
		public void CopyTo(TKey[] array, int index)
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
				array[num++] = keyValuePair.Key;
			}
		}

		// Token: 0x17001145 RID: 4421
		// (get) Token: 0x060063DB RID: 25563 RVA: 0x00154C84 File Offset: 0x00152E84
		public int Count
		{
			get
			{
				return this.dictionary.Count;
			}
		}

		// Token: 0x17001146 RID: 4422
		// (get) Token: 0x060063DC RID: 25564 RVA: 0x00154C91 File Offset: 0x00152E91
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060063DD RID: 25565 RVA: 0x00154C94 File Offset: 0x00152E94
		void ICollection<!0>.Add(TKey item)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_KeyCollectionSet"));
		}

		// Token: 0x060063DE RID: 25566 RVA: 0x00154CA5 File Offset: 0x00152EA5
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_KeyCollectionSet"));
		}

		// Token: 0x060063DF RID: 25567 RVA: 0x00154CB6 File Offset: 0x00152EB6
		public bool Contains(TKey item)
		{
			return this.dictionary.ContainsKey(item);
		}

		// Token: 0x060063E0 RID: 25568 RVA: 0x00154CC4 File Offset: 0x00152EC4
		bool ICollection<!0>.Remove(TKey item)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_KeyCollectionSet"));
		}

		// Token: 0x060063E1 RID: 25569 RVA: 0x00154CD5 File Offset: 0x00152ED5
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<!0>)this).GetEnumerator();
		}

		// Token: 0x060063E2 RID: 25570 RVA: 0x00154CDD File Offset: 0x00152EDD
		public IEnumerator<TKey> GetEnumerator()
		{
			return new DictionaryKeyEnumerator<TKey, TValue>(this.dictionary);
		}

		// Token: 0x04002CDE RID: 11486
		private readonly IDictionary<TKey, TValue> dictionary;
	}
}
