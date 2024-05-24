﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x02000034 RID: 52
	[NullableContext(1)]
	[Nullable(0)]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
	public sealed class ImmutableList<[Nullable(2)] T> : IImmutableList<!0>, IReadOnlyList<!0>, IReadOnlyCollection<!0>, IEnumerable<!0>, IEnumerable, IList<!0>, ICollection<!0>, IList, ICollection, IOrderedCollection<T>, IImmutableListQueries<T>, IStrongEnumerable<T, ImmutableList<T>.Enumerator>
	{
		// Token: 0x06000220 RID: 544 RVA: 0x00006CE7 File Offset: 0x00004EE7
		internal ImmutableList()
		{
			this._root = ImmutableList<T>.Node.EmptyNode;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00006CFA File Offset: 0x00004EFA
		private ImmutableList(ImmutableList<T>.Node root)
		{
			Requires.NotNull<ImmutableList<T>.Node>(root, "root");
			root.Freeze();
			this._root = root;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00006D1A File Offset: 0x00004F1A
		public ImmutableList<T> Clear()
		{
			return ImmutableList<T>.Empty;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00006D21 File Offset: 0x00004F21
		public int BinarySearch(T item)
		{
			return this.BinarySearch(item, null);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00006D2B File Offset: 0x00004F2B
		public int BinarySearch(T item, [Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return this.BinarySearch(0, this.Count, item, comparer);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00006D3C File Offset: 0x00004F3C
		public int BinarySearch(int index, int count, T item, [Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return this._root.BinarySearch(index, count, item, comparer);
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00006D4E File Offset: 0x00004F4E
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsEmpty
		{
			get
			{
				return this._root.IsEmpty;
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00006D5B File Offset: 0x00004F5B
		IImmutableList<T> IImmutableList<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00006D63 File Offset: 0x00004F63
		public int Count
		{
			get
			{
				return this._root.Count;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00006D70 File Offset: 0x00004F70
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00006D73 File Offset: 0x00004F73
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700005C RID: 92
		public unsafe T this[int index]
		{
			get
			{
				return *this._root.ItemRef(index);
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00006D89 File Offset: 0x00004F89
		public ref readonly T ItemRef(int index)
		{
			return this._root.ItemRef(index);
		}

		// Token: 0x1700005D RID: 93
		T IOrderedCollection<!0>.this[int index]
		{
			get
			{
				return this[index];
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00006DA0 File Offset: 0x00004FA0
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public ImmutableList<T>.Builder ToBuilder()
		{
			return new ImmutableList<T>.Builder(this);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00006DA8 File Offset: 0x00004FA8
		public ImmutableList<T> Add(T value)
		{
			ImmutableList<T>.Node root = this._root.Add(value);
			return this.Wrap(root);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00006DCC File Offset: 0x00004FCC
		public ImmutableList<T> AddRange(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (this.IsEmpty)
			{
				return ImmutableList<T>.CreateRange(items);
			}
			ImmutableList<T>.Node root = this._root.AddRange(items);
			return this.Wrap(root);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00006E07 File Offset: 0x00005007
		public ImmutableList<T> Insert(int index, T item)
		{
			Requires.Range(index >= 0 && index <= this.Count, "index", null);
			return this.Wrap(this._root.Insert(index, item));
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00006E3C File Offset: 0x0000503C
		public ImmutableList<T> InsertRange(int index, IEnumerable<T> items)
		{
			Requires.Range(index >= 0 && index <= this.Count, "index", null);
			Requires.NotNull<IEnumerable<T>>(items, "items");
			ImmutableList<T>.Node root = this._root.InsertRange(index, items);
			return this.Wrap(root);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00006E87 File Offset: 0x00005087
		public ImmutableList<T> Remove(T value)
		{
			return this.Remove(value, EqualityComparer<T>.Default);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00006E98 File Offset: 0x00005098
		public ImmutableList<T> Remove(T value, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			int num = this.IndexOf(value, equalityComparer);
			if (num >= 0)
			{
				return this.RemoveAt(num);
			}
			return this;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00006EBC File Offset: 0x000050BC
		public ImmutableList<T> RemoveRange(int index, int count)
		{
			Requires.Range(index >= 0 && index <= this.Count, "index", null);
			Requires.Range(count >= 0 && index + count <= this.Count, "count", null);
			ImmutableList<T>.Node node = this._root;
			int num = count;
			while (num-- > 0)
			{
				node = node.RemoveAt(index);
			}
			return this.Wrap(node);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00006F29 File Offset: 0x00005129
		public ImmutableList<T> RemoveRange(IEnumerable<T> items)
		{
			return this.RemoveRange(items, EqualityComparer<T>.Default);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00006F38 File Offset: 0x00005138
		public ImmutableList<T> RemoveRange(IEnumerable<T> items, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (this.IsEmpty)
			{
				return this;
			}
			ImmutableList<T>.Node node = this._root;
			foreach (T item in items.GetEnumerableDisposable<T, ImmutableList<T>.Enumerator>())
			{
				int num = node.IndexOf(item, equalityComparer);
				if (num >= 0)
				{
					node = node.RemoveAt(num);
				}
			}
			return this.Wrap(node);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00006FC4 File Offset: 0x000051C4
		public ImmutableList<T> RemoveAt(int index)
		{
			Requires.Range(index >= 0 && index < this.Count, "index", null);
			ImmutableList<T>.Node root = this._root.RemoveAt(index);
			return this.Wrap(root);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00007000 File Offset: 0x00005200
		public ImmutableList<T> RemoveAll(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this.Wrap(this._root.RemoveAll(match));
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000701F File Offset: 0x0000521F
		public ImmutableList<T> SetItem(int index, T value)
		{
			return this.Wrap(this._root.ReplaceAt(index, value));
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00007034 File Offset: 0x00005234
		public ImmutableList<T> Replace(T oldValue, T newValue)
		{
			return this.Replace(oldValue, newValue, EqualityComparer<T>.Default);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00007044 File Offset: 0x00005244
		public ImmutableList<T> Replace(T oldValue, T newValue, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			int num = this.IndexOf(oldValue, equalityComparer);
			if (num < 0)
			{
				throw new ArgumentException(SR.CannotFindOldValue, "oldValue");
			}
			return this.SetItem(num, newValue);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00007076 File Offset: 0x00005276
		public ImmutableList<T> Reverse()
		{
			return this.Wrap(this._root.Reverse());
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00007089 File Offset: 0x00005289
		public ImmutableList<T> Reverse(int index, int count)
		{
			return this.Wrap(this._root.Reverse(index, count));
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000709E File Offset: 0x0000529E
		public ImmutableList<T> Sort()
		{
			return this.Wrap(this._root.Sort());
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000070B1 File Offset: 0x000052B1
		public ImmutableList<T> Sort(Comparison<T> comparison)
		{
			Requires.NotNull<Comparison<T>>(comparison, "comparison");
			return this.Wrap(this._root.Sort(comparison));
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000070D0 File Offset: 0x000052D0
		public ImmutableList<T> Sort([Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return this.Wrap(this._root.Sort(comparer));
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000070E4 File Offset: 0x000052E4
		public ImmutableList<T> Sort(int index, int count, [Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			Requires.Range(index >= 0, "index", null);
			Requires.Range(count >= 0, "count", null);
			Requires.Range(index + count <= this.Count, "count", null);
			return this.Wrap(this._root.Sort(index, count, comparer));
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00007144 File Offset: 0x00005344
		public void ForEach(Action<T> action)
		{
			Requires.NotNull<Action<T>>(action, "action");
			foreach (T obj in this)
			{
				action(obj);
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000071A0 File Offset: 0x000053A0
		public void CopyTo(T[] array)
		{
			this._root.CopyTo(array);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000071AE File Offset: 0x000053AE
		public void CopyTo(T[] array, int arrayIndex)
		{
			this._root.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000071BD File Offset: 0x000053BD
		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			this._root.CopyTo(index, array, arrayIndex, count);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000071D0 File Offset: 0x000053D0
		public ImmutableList<T> GetRange(int index, int count)
		{
			Requires.Range(index >= 0, "index", null);
			Requires.Range(count >= 0, "count", null);
			Requires.Range(index + count <= this.Count, "count", null);
			return this.Wrap(ImmutableList<T>.Node.NodeTreeFromList(this, index, count));
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00007228 File Offset: 0x00005428
		public ImmutableList<TOutput> ConvertAll<[Nullable(2)] TOutput>(Func<T, TOutput> converter)
		{
			Requires.NotNull<Func<T, TOutput>>(converter, "converter");
			return ImmutableList<TOutput>.WrapNode(this._root.ConvertAll<TOutput>(converter));
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00007246 File Offset: 0x00005446
		public bool Exists(Predicate<T> match)
		{
			return this._root.Exists(match);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00007254 File Offset: 0x00005454
		[return: Nullable(2)]
		public T Find(Predicate<T> match)
		{
			return this._root.Find(match);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00007262 File Offset: 0x00005462
		public ImmutableList<T> FindAll(Predicate<T> match)
		{
			return this._root.FindAll(match);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00007270 File Offset: 0x00005470
		public int FindIndex(Predicate<T> match)
		{
			return this._root.FindIndex(match);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000727E File Offset: 0x0000547E
		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return this._root.FindIndex(startIndex, match);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000728D File Offset: 0x0000548D
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			return this._root.FindIndex(startIndex, count, match);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000729D File Offset: 0x0000549D
		[return: Nullable(2)]
		public T FindLast(Predicate<T> match)
		{
			return this._root.FindLast(match);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000072AB File Offset: 0x000054AB
		public int FindLastIndex(Predicate<T> match)
		{
			return this._root.FindLastIndex(match);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000072B9 File Offset: 0x000054B9
		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return this._root.FindLastIndex(startIndex, match);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000072C8 File Offset: 0x000054C8
		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return this._root.FindLastIndex(startIndex, count, match);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000072D8 File Offset: 0x000054D8
		public int IndexOf(T item, int index, int count, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			return this._root.IndexOf(item, index, count, equalityComparer);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000072EA File Offset: 0x000054EA
		public int LastIndexOf(T item, int index, int count, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			return this._root.LastIndexOf(item, index, count, equalityComparer);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000072FC File Offset: 0x000054FC
		public bool TrueForAll(Predicate<T> match)
		{
			return this._root.TrueForAll(match);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000730A File Offset: 0x0000550A
		public bool Contains(T value)
		{
			return this._root.Contains(value, EqualityComparer<T>.Default);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000731D File Offset: 0x0000551D
		public int IndexOf(T value)
		{
			return this.IndexOf(value, EqualityComparer<T>.Default);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000732B File Offset: 0x0000552B
		IImmutableList<T> IImmutableList<!0>.Add(T value)
		{
			return this.Add(value);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00007334 File Offset: 0x00005534
		IImmutableList<T> IImmutableList<!0>.AddRange(IEnumerable<T> items)
		{
			return this.AddRange(items);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000733D File Offset: 0x0000553D
		IImmutableList<T> IImmutableList<!0>.Insert(int index, T item)
		{
			return this.Insert(index, item);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00007347 File Offset: 0x00005547
		IImmutableList<T> IImmutableList<!0>.InsertRange(int index, IEnumerable<T> items)
		{
			return this.InsertRange(index, items);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00007351 File Offset: 0x00005551
		IImmutableList<T> IImmutableList<!0>.Remove(T value, IEqualityComparer<T> equalityComparer)
		{
			return this.Remove(value, equalityComparer);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000735B File Offset: 0x0000555B
		IImmutableList<T> IImmutableList<!0>.RemoveAll(Predicate<T> match)
		{
			return this.RemoveAll(match);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00007364 File Offset: 0x00005564
		IImmutableList<T> IImmutableList<!0>.RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
		{
			return this.RemoveRange(items, equalityComparer);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000736E File Offset: 0x0000556E
		IImmutableList<T> IImmutableList<!0>.RemoveRange(int index, int count)
		{
			return this.RemoveRange(index, count);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00007378 File Offset: 0x00005578
		IImmutableList<T> IImmutableList<!0>.RemoveAt(int index)
		{
			return this.RemoveAt(index);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00007381 File Offset: 0x00005581
		IImmutableList<T> IImmutableList<!0>.SetItem(int index, T value)
		{
			return this.SetItem(index, value);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000738B File Offset: 0x0000558B
		IImmutableList<T> IImmutableList<!0>.Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
		{
			return this.Replace(oldValue, newValue, equalityComparer);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00007398 File Offset: 0x00005598
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			if (!this.IsEmpty)
			{
				return this.GetEnumerator();
			}
			return Enumerable.Empty<T>().GetEnumerator();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000073C5 File Offset: 0x000055C5
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000073D2 File Offset: 0x000055D2
		void IList<!0>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000073D9 File Offset: 0x000055D9
		void IList<!0>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700005E RID: 94
		T IList<!0>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000073F0 File Offset: 0x000055F0
		void ICollection<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x000073F7 File Offset: 0x000055F7
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600026B RID: 619 RVA: 0x000073FE File Offset: 0x000055FE
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00007401 File Offset: 0x00005601
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00007408 File Offset: 0x00005608
		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			this._root.CopyTo(array, arrayIndex);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00007417 File Offset: 0x00005617
		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000741E File Offset: 0x0000561E
		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007425 File Offset: 0x00005625
		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000742C File Offset: 0x0000562C
		bool IList.Contains(object value)
		{
			return ImmutableList<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00007444 File Offset: 0x00005644
		int IList.IndexOf(object value)
		{
			if (!ImmutableList<T>.IsCompatibleObject(value))
			{
				return -1;
			}
			return this.IndexOf((T)((object)value));
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000745C File Offset: 0x0000565C
		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00007463 File Offset: 0x00005663
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00007466 File Offset: 0x00005666
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00007469 File Offset: 0x00005669
		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000062 RID: 98
		[Nullable(2)]
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00007485 File Offset: 0x00005685
		[NullableContext(0)]
		public ImmutableList<T>.Enumerator GetEnumerator()
		{
			return new ImmutableList<T>.Enumerator(this._root, null, -1, -1, false);
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00007496 File Offset: 0x00005696
		[Nullable(new byte[]
		{
			1,
			0
		})]
		internal ImmutableList<T>.Node Root
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				return this._root;
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000749E File Offset: 0x0000569E
		private static ImmutableList<T> WrapNode(ImmutableList<T>.Node root)
		{
			if (!root.IsEmpty)
			{
				return new ImmutableList<T>(root);
			}
			return ImmutableList<T>.Empty;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000074B4 File Offset: 0x000056B4
		private static bool TryCastToImmutableList(IEnumerable<T> sequence, [NotNullWhen(true)] out ImmutableList<T> other)
		{
			other = (sequence as ImmutableList<T>);
			if (other != null)
			{
				return true;
			}
			ImmutableList<T>.Builder builder = sequence as ImmutableList<T>.Builder;
			if (builder != null)
			{
				other = builder.ToImmutable();
				return true;
			}
			return false;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000074E4 File Offset: 0x000056E4
		private static bool IsCompatibleObject(object value)
		{
			return value is T || (value == null && default(T) == null);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00007511 File Offset: 0x00005711
		private ImmutableList<T> Wrap(ImmutableList<T>.Node root)
		{
			if (root == this._root)
			{
				return this;
			}
			if (!root.IsEmpty)
			{
				return new ImmutableList<T>(root);
			}
			return this.Clear();
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00007534 File Offset: 0x00005734
		private static ImmutableList<T> CreateRange(IEnumerable<T> items)
		{
			ImmutableList<T> result;
			if (ImmutableList<T>.TryCastToImmutableList(items, out result))
			{
				return result;
			}
			IOrderedCollection<T> orderedCollection = items.AsOrderedCollection<T>();
			if (orderedCollection.Count == 0)
			{
				return ImmutableList<T>.Empty;
			}
			ImmutableList<T>.Node root = ImmutableList<T>.Node.NodeTreeFromList(orderedCollection, 0, orderedCollection.Count);
			return new ImmutableList<T>(root);
		}

		// Token: 0x04000026 RID: 38
		public static readonly ImmutableList<T> Empty = new ImmutableList<T>();

		// Token: 0x04000027 RID: 39
		private readonly ImmutableList<T>.Node _root;

		// Token: 0x0200006C RID: 108
		[Nullable(0)]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ImmutableListBuilderDebuggerProxy<>))]
		public sealed class Builder : IList<!0>, ICollection<!0>, IEnumerable<!0>, IEnumerable, IList, ICollection, IOrderedCollection<!0>, IImmutableListQueries<T>, IReadOnlyList<!0>, IReadOnlyCollection<!0>
		{
			// Token: 0x060004C1 RID: 1217 RVA: 0x0000C452 File Offset: 0x0000A652
			internal Builder(ImmutableList<T> list)
			{
				Requires.NotNull<ImmutableList<T>>(list, "list");
				this._root = list._root;
				this._immutable = list;
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0000C483 File Offset: 0x0000A683
			public int Count
			{
				get
				{
					return this.Root.Count;
				}
			}

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x060004C3 RID: 1219 RVA: 0x0000C490 File Offset: 0x0000A690
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000C493 File Offset: 0x0000A693
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0000C49B File Offset: 0x0000A69B
			// (set) Token: 0x060004C6 RID: 1222 RVA: 0x0000C4A3 File Offset: 0x0000A6A3
			[Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Root
			{
				[return: Nullable(new byte[]
				{
					1,
					0
				})]
				get
				{
					return this._root;
				}
				private set
				{
					this._version++;
					if (this._root != value)
					{
						this._root = value;
						this._immutable = null;
					}
				}
			}

			// Token: 0x170000EA RID: 234
			public unsafe T this[int index]
			{
				get
				{
					return *this.Root.ItemRef(index);
				}
				set
				{
					this.Root = this.Root.ReplaceAt(index, value);
				}
			}

			// Token: 0x170000EB RID: 235
			T IOrderedCollection<!0>.this[int index]
			{
				get
				{
					return this[index];
				}
			}

			// Token: 0x060004CA RID: 1226 RVA: 0x0000C4FB File Offset: 0x0000A6FB
			public ref readonly T ItemRef(int index)
			{
				return this.Root.ItemRef(index);
			}

			// Token: 0x060004CB RID: 1227 RVA: 0x0000C509 File Offset: 0x0000A709
			public int IndexOf(T item)
			{
				return this.Root.IndexOf(item, EqualityComparer<T>.Default);
			}

			// Token: 0x060004CC RID: 1228 RVA: 0x0000C51C File Offset: 0x0000A71C
			public void Insert(int index, T item)
			{
				this.Root = this.Root.Insert(index, item);
			}

			// Token: 0x060004CD RID: 1229 RVA: 0x0000C531 File Offset: 0x0000A731
			public void RemoveAt(int index)
			{
				this.Root = this.Root.RemoveAt(index);
			}

			// Token: 0x060004CE RID: 1230 RVA: 0x0000C545 File Offset: 0x0000A745
			public void Add(T item)
			{
				this.Root = this.Root.Add(item);
			}

			// Token: 0x060004CF RID: 1231 RVA: 0x0000C559 File Offset: 0x0000A759
			public void Clear()
			{
				this.Root = ImmutableList<T>.Node.EmptyNode;
			}

			// Token: 0x060004D0 RID: 1232 RVA: 0x0000C566 File Offset: 0x0000A766
			public bool Contains(T item)
			{
				return this.IndexOf(item) >= 0;
			}

			// Token: 0x060004D1 RID: 1233 RVA: 0x0000C578 File Offset: 0x0000A778
			public bool Remove(T item)
			{
				int num = this.IndexOf(item);
				if (num < 0)
				{
					return false;
				}
				this.Root = this.Root.RemoveAt(num);
				return true;
			}

			// Token: 0x060004D2 RID: 1234 RVA: 0x0000C5A6 File Offset: 0x0000A7A6
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			public ImmutableList<T>.Enumerator GetEnumerator()
			{
				return this.Root.GetEnumerator(this);
			}

			// Token: 0x060004D3 RID: 1235 RVA: 0x0000C5B4 File Offset: 0x0000A7B4
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060004D4 RID: 1236 RVA: 0x0000C5C1 File Offset: 0x0000A7C1
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060004D5 RID: 1237 RVA: 0x0000C5D0 File Offset: 0x0000A7D0
			public void ForEach(Action<T> action)
			{
				Requires.NotNull<Action<T>>(action, "action");
				foreach (T obj in this)
				{
					action(obj);
				}
			}

			// Token: 0x060004D6 RID: 1238 RVA: 0x0000C62C File Offset: 0x0000A82C
			public void CopyTo(T[] array)
			{
				this._root.CopyTo(array);
			}

			// Token: 0x060004D7 RID: 1239 RVA: 0x0000C63A File Offset: 0x0000A83A
			public void CopyTo(T[] array, int arrayIndex)
			{
				this._root.CopyTo(array, arrayIndex);
			}

			// Token: 0x060004D8 RID: 1240 RVA: 0x0000C649 File Offset: 0x0000A849
			public void CopyTo(int index, T[] array, int arrayIndex, int count)
			{
				this._root.CopyTo(index, array, arrayIndex, count);
			}

			// Token: 0x060004D9 RID: 1241 RVA: 0x0000C65C File Offset: 0x0000A85C
			public ImmutableList<T> GetRange(int index, int count)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				return ImmutableList<T>.WrapNode(ImmutableList<T>.Node.NodeTreeFromList(this, index, count));
			}

			// Token: 0x060004DA RID: 1242 RVA: 0x0000C6B3 File Offset: 0x0000A8B3
			public ImmutableList<TOutput> ConvertAll<[Nullable(2)] TOutput>(Func<T, TOutput> converter)
			{
				Requires.NotNull<Func<T, TOutput>>(converter, "converter");
				return ImmutableList<TOutput>.WrapNode(this._root.ConvertAll<TOutput>(converter));
			}

			// Token: 0x060004DB RID: 1243 RVA: 0x0000C6D1 File Offset: 0x0000A8D1
			public bool Exists(Predicate<T> match)
			{
				return this._root.Exists(match);
			}

			// Token: 0x060004DC RID: 1244 RVA: 0x0000C6DF File Offset: 0x0000A8DF
			[return: Nullable(2)]
			public T Find(Predicate<T> match)
			{
				return this._root.Find(match);
			}

			// Token: 0x060004DD RID: 1245 RVA: 0x0000C6ED File Offset: 0x0000A8ED
			public ImmutableList<T> FindAll(Predicate<T> match)
			{
				return this._root.FindAll(match);
			}

			// Token: 0x060004DE RID: 1246 RVA: 0x0000C6FB File Offset: 0x0000A8FB
			public int FindIndex(Predicate<T> match)
			{
				return this._root.FindIndex(match);
			}

			// Token: 0x060004DF RID: 1247 RVA: 0x0000C709 File Offset: 0x0000A909
			public int FindIndex(int startIndex, Predicate<T> match)
			{
				return this._root.FindIndex(startIndex, match);
			}

			// Token: 0x060004E0 RID: 1248 RVA: 0x0000C718 File Offset: 0x0000A918
			public int FindIndex(int startIndex, int count, Predicate<T> match)
			{
				return this._root.FindIndex(startIndex, count, match);
			}

			// Token: 0x060004E1 RID: 1249 RVA: 0x0000C728 File Offset: 0x0000A928
			[return: Nullable(2)]
			public T FindLast(Predicate<T> match)
			{
				return this._root.FindLast(match);
			}

			// Token: 0x060004E2 RID: 1250 RVA: 0x0000C736 File Offset: 0x0000A936
			public int FindLastIndex(Predicate<T> match)
			{
				return this._root.FindLastIndex(match);
			}

			// Token: 0x060004E3 RID: 1251 RVA: 0x0000C744 File Offset: 0x0000A944
			public int FindLastIndex(int startIndex, Predicate<T> match)
			{
				return this._root.FindLastIndex(startIndex, match);
			}

			// Token: 0x060004E4 RID: 1252 RVA: 0x0000C753 File Offset: 0x0000A953
			public int FindLastIndex(int startIndex, int count, Predicate<T> match)
			{
				return this._root.FindLastIndex(startIndex, count, match);
			}

			// Token: 0x060004E5 RID: 1253 RVA: 0x0000C763 File Offset: 0x0000A963
			public int IndexOf(T item, int index)
			{
				return this._root.IndexOf(item, index, this.Count - index, EqualityComparer<T>.Default);
			}

			// Token: 0x060004E6 RID: 1254 RVA: 0x0000C77F File Offset: 0x0000A97F
			public int IndexOf(T item, int index, int count)
			{
				return this._root.IndexOf(item, index, count, EqualityComparer<T>.Default);
			}

			// Token: 0x060004E7 RID: 1255 RVA: 0x0000C794 File Offset: 0x0000A994
			public int IndexOf(T item, int index, int count, [Nullable(new byte[]
			{
				2,
				1
			})] IEqualityComparer<T> equalityComparer)
			{
				return this._root.IndexOf(item, index, count, equalityComparer);
			}

			// Token: 0x060004E8 RID: 1256 RVA: 0x0000C7A6 File Offset: 0x0000A9A6
			public int LastIndexOf(T item)
			{
				if (this.Count == 0)
				{
					return -1;
				}
				return this._root.LastIndexOf(item, this.Count - 1, this.Count, EqualityComparer<T>.Default);
			}

			// Token: 0x060004E9 RID: 1257 RVA: 0x0000C7D1 File Offset: 0x0000A9D1
			public int LastIndexOf(T item, int startIndex)
			{
				if (this.Count == 0 && startIndex == 0)
				{
					return -1;
				}
				return this._root.LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
			}

			// Token: 0x060004EA RID: 1258 RVA: 0x0000C7F5 File Offset: 0x0000A9F5
			public int LastIndexOf(T item, int startIndex, int count)
			{
				return this._root.LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);
			}

			// Token: 0x060004EB RID: 1259 RVA: 0x0000C80A File Offset: 0x0000AA0A
			public int LastIndexOf(T item, int startIndex, int count, [Nullable(new byte[]
			{
				2,
				1
			})] IEqualityComparer<T> equalityComparer)
			{
				return this._root.LastIndexOf(item, startIndex, count, equalityComparer);
			}

			// Token: 0x060004EC RID: 1260 RVA: 0x0000C81C File Offset: 0x0000AA1C
			public bool TrueForAll(Predicate<T> match)
			{
				return this._root.TrueForAll(match);
			}

			// Token: 0x060004ED RID: 1261 RVA: 0x0000C82A File Offset: 0x0000AA2A
			public void AddRange(IEnumerable<T> items)
			{
				Requires.NotNull<IEnumerable<T>>(items, "items");
				this.Root = this.Root.AddRange(items);
			}

			// Token: 0x060004EE RID: 1262 RVA: 0x0000C849 File Offset: 0x0000AA49
			public void InsertRange(int index, IEnumerable<T> items)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				Requires.NotNull<IEnumerable<T>>(items, "items");
				this.Root = this.Root.InsertRange(index, items);
			}

			// Token: 0x060004EF RID: 1263 RVA: 0x0000C888 File Offset: 0x0000AA88
			public int RemoveAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				int count = this.Count;
				this.Root = this.Root.RemoveAll(match);
				return count - this.Count;
			}

			// Token: 0x060004F0 RID: 1264 RVA: 0x0000C8C1 File Offset: 0x0000AAC1
			public void Reverse()
			{
				this.Reverse(0, this.Count);
			}

			// Token: 0x060004F1 RID: 1265 RVA: 0x0000C8D0 File Offset: 0x0000AAD0
			public void Reverse(int index, int count)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				this.Root = this.Root.Reverse(index, count);
			}

			// Token: 0x060004F2 RID: 1266 RVA: 0x0000C92D File Offset: 0x0000AB2D
			public void Sort()
			{
				this.Root = this.Root.Sort();
			}

			// Token: 0x060004F3 RID: 1267 RVA: 0x0000C940 File Offset: 0x0000AB40
			public void Sort(Comparison<T> comparison)
			{
				Requires.NotNull<Comparison<T>>(comparison, "comparison");
				this.Root = this.Root.Sort(comparison);
			}

			// Token: 0x060004F4 RID: 1268 RVA: 0x0000C95F File Offset: 0x0000AB5F
			public void Sort([Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				this.Root = this.Root.Sort(comparer);
			}

			// Token: 0x060004F5 RID: 1269 RVA: 0x0000C974 File Offset: 0x0000AB74
			public void Sort(int index, int count, [Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				this.Root = this.Root.Sort(index, count, comparer);
			}

			// Token: 0x060004F6 RID: 1270 RVA: 0x0000C9D2 File Offset: 0x0000ABD2
			public int BinarySearch(T item)
			{
				return this.BinarySearch(item, null);
			}

			// Token: 0x060004F7 RID: 1271 RVA: 0x0000C9DC File Offset: 0x0000ABDC
			public int BinarySearch(T item, [Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				return this.BinarySearch(0, this.Count, item, comparer);
			}

			// Token: 0x060004F8 RID: 1272 RVA: 0x0000C9ED File Offset: 0x0000ABED
			public int BinarySearch(int index, int count, T item, [Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				return this.Root.BinarySearch(index, count, item, comparer);
			}

			// Token: 0x060004F9 RID: 1273 RVA: 0x0000C9FF File Offset: 0x0000ABFF
			public ImmutableList<T> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableList<T>.WrapNode(this.Root);
				}
				return this._immutable;
			}

			// Token: 0x060004FA RID: 1274 RVA: 0x0000CA20 File Offset: 0x0000AC20
			int IList.Add(object value)
			{
				this.Add((T)((object)value));
				return this.Count - 1;
			}

			// Token: 0x060004FB RID: 1275 RVA: 0x0000CA36 File Offset: 0x0000AC36
			void IList.Clear()
			{
				this.Clear();
			}

			// Token: 0x060004FC RID: 1276 RVA: 0x0000CA3E File Offset: 0x0000AC3E
			bool IList.Contains(object value)
			{
				return ImmutableList<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
			}

			// Token: 0x060004FD RID: 1277 RVA: 0x0000CA56 File Offset: 0x0000AC56
			int IList.IndexOf(object value)
			{
				if (ImmutableList<T>.IsCompatibleObject(value))
				{
					return this.IndexOf((T)((object)value));
				}
				return -1;
			}

			// Token: 0x060004FE RID: 1278 RVA: 0x0000CA6E File Offset: 0x0000AC6E
			void IList.Insert(int index, object value)
			{
				this.Insert(index, (T)((object)value));
			}

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x060004FF RID: 1279 RVA: 0x0000CA7D File Offset: 0x0000AC7D
			bool IList.IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x06000500 RID: 1280 RVA: 0x0000CA80 File Offset: 0x0000AC80
			bool IList.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x06000501 RID: 1281 RVA: 0x0000CA83 File Offset: 0x0000AC83
			void IList.Remove(object value)
			{
				if (ImmutableList<T>.IsCompatibleObject(value))
				{
					this.Remove((T)((object)value));
				}
			}

			// Token: 0x170000EE RID: 238
			[Nullable(2)]
			object IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					this[index] = (T)((object)value);
				}
			}

			// Token: 0x06000504 RID: 1284 RVA: 0x0000CAB7 File Offset: 0x0000ACB7
			void ICollection.CopyTo(Array array, int arrayIndex)
			{
				this.Root.CopyTo(array, arrayIndex);
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x06000505 RID: 1285 RVA: 0x0000CAC6 File Offset: 0x0000ACC6
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x06000506 RID: 1286 RVA: 0x0000CAC9 File Offset: 0x0000ACC9
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			object ICollection.SyncRoot
			{
				get
				{
					if (this._syncRoot == null)
					{
						Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
					}
					return this._syncRoot;
				}
			}

			// Token: 0x040000AF RID: 175
			private ImmutableList<T>.Node _root = ImmutableList<T>.Node.EmptyNode;

			// Token: 0x040000B0 RID: 176
			private ImmutableList<T> _immutable;

			// Token: 0x040000B1 RID: 177
			private int _version;

			// Token: 0x040000B2 RID: 178
			private object _syncRoot;
		}

		// Token: 0x0200006D RID: 109
		[NullableContext(0)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<!0>, IDisposable, IEnumerator, ISecurePooledObjectUser, IStrongEnumerator<T>
		{
			// Token: 0x06000507 RID: 1287 RVA: 0x0000CAEC File Offset: 0x0000ACEC
			internal Enumerator([Nullable(new byte[]
			{
				1,
				0
			})] ImmutableList<T>.Node root, [Nullable(new byte[]
			{
				2,
				0
			})] ImmutableList<T>.Builder builder = null, int startIndex = -1, int count = -1, bool reversed = false)
			{
				Requires.NotNull<ImmutableList<T>.Node>(root, "root");
				Requires.Range(startIndex >= -1, "startIndex", null);
				Requires.Range(count >= -1, "count", null);
				Requires.Argument(reversed || count == -1 || ((startIndex == -1) ? 0 : startIndex) + count <= root.Count);
				Requires.Argument(!reversed || count == -1 || ((startIndex == -1) ? (root.Count - 1) : startIndex) - count + 1 >= 0);
				this._root = root;
				this._builder = builder;
				this._current = null;
				this._startIndex = ((startIndex >= 0) ? startIndex : (reversed ? (root.Count - 1) : 0));
				this._count = ((count == -1) ? root.Count : count);
				this._remainingCount = this._count;
				this._reversed = reversed;
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
				this._poolUserId = SecureObjectPool.NewId();
				this._stack = null;
				if (this._count > 0)
				{
					if (!ImmutableList<T>.Enumerator.s_EnumeratingStacks.TryTake(this, out this._stack))
					{
						this._stack = ImmutableList<T>.Enumerator.s_EnumeratingStacks.PrepNew(this, new Stack<RefAsValueType<ImmutableList<T>.Node>>(root.Height));
					}
					this.ResetStack();
				}
			}

			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x06000508 RID: 1288 RVA: 0x0000CC41 File Offset: 0x0000AE41
			int ISecurePooledObjectUser.PoolUserId
			{
				get
				{
					return this._poolUserId;
				}
			}

			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x06000509 RID: 1289 RVA: 0x0000CC49 File Offset: 0x0000AE49
			[Nullable(1)]
			public T Current
			{
				[NullableContext(1)]
				get
				{
					this.ThrowIfDisposed();
					if (this._current != null)
					{
						return this._current.Value;
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x0600050A RID: 1290 RVA: 0x0000CC6A File Offset: 0x0000AE6A
			[Nullable(2)]
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0600050B RID: 1291 RVA: 0x0000CC78 File Offset: 0x0000AE78
			public void Dispose()
			{
				this._root = null;
				this._current = null;
				Stack<RefAsValueType<ImmutableList<T>.Node>> stack;
				if (this._stack != null && this._stack.TryUse<ImmutableList<T>.Enumerator>(ref this, out stack))
				{
					stack.ClearFastWhenEmpty<RefAsValueType<ImmutableList<T>.Node>>();
					ImmutableList<T>.Enumerator.s_EnumeratingStacks.TryAdd(this, this._stack);
				}
				this._stack = null;
			}

			// Token: 0x0600050C RID: 1292 RVA: 0x0000CCD0 File Offset: 0x0000AED0
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				this.ThrowIfChanged();
				if (this._stack != null)
				{
					Stack<RefAsValueType<ImmutableList<T>.Node>> stack = this._stack.Use<ImmutableList<T>.Enumerator>(ref this);
					if (this._remainingCount > 0 && stack.Count > 0)
					{
						ImmutableList<T>.Node value = stack.Pop().Value;
						this._current = value;
						this.PushNext(this.NextBranch(value));
						this._remainingCount--;
						return true;
					}
				}
				this._current = null;
				return false;
			}

			// Token: 0x0600050D RID: 1293 RVA: 0x0000CD48 File Offset: 0x0000AF48
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._remainingCount = this._count;
				if (this._stack != null)
				{
					this.ResetStack();
				}
			}

			// Token: 0x0600050E RID: 1294 RVA: 0x0000CD88 File Offset: 0x0000AF88
			private void ResetStack()
			{
				Stack<RefAsValueType<ImmutableList<T>.Node>> stack = this._stack.Use<ImmutableList<T>.Enumerator>(ref this);
				stack.ClearFastWhenEmpty<RefAsValueType<ImmutableList<T>.Node>>();
				ImmutableList<T>.Node node = this._root;
				int num = this._reversed ? (this._root.Count - this._startIndex - 1) : this._startIndex;
				while (!node.IsEmpty && num != this.PreviousBranch(node).Count)
				{
					if (num < this.PreviousBranch(node).Count)
					{
						stack.Push(new RefAsValueType<ImmutableList<T>.Node>(node));
						node = this.PreviousBranch(node);
					}
					else
					{
						num -= this.PreviousBranch(node).Count + 1;
						node = this.NextBranch(node);
					}
				}
				if (!node.IsEmpty)
				{
					stack.Push(new RefAsValueType<ImmutableList<T>.Node>(node));
				}
			}

			// Token: 0x0600050F RID: 1295 RVA: 0x0000CE3F File Offset: 0x0000B03F
			private ImmutableList<T>.Node NextBranch(ImmutableList<T>.Node node)
			{
				if (!this._reversed)
				{
					return node.Right;
				}
				return node.Left;
			}

			// Token: 0x06000510 RID: 1296 RVA: 0x0000CE56 File Offset: 0x0000B056
			private ImmutableList<T>.Node PreviousBranch(ImmutableList<T>.Node node)
			{
				if (!this._reversed)
				{
					return node.Left;
				}
				return node.Right;
			}

			// Token: 0x06000511 RID: 1297 RVA: 0x0000CE6D File Offset: 0x0000B06D
			private void ThrowIfDisposed()
			{
				if (this._root == null || (this._stack != null && !this._stack.IsOwned<ImmutableList<T>.Enumerator>(ref this)))
				{
					Requires.FailObjectDisposed<ImmutableList<T>.Enumerator>(this);
				}
			}

			// Token: 0x06000512 RID: 1298 RVA: 0x0000CE98 File Offset: 0x0000B098
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x06000513 RID: 1299 RVA: 0x0000CEC0 File Offset: 0x0000B0C0
			private void PushNext(ImmutableList<T>.Node node)
			{
				Requires.NotNull<ImmutableList<T>.Node>(node, "node");
				if (!node.IsEmpty)
				{
					Stack<RefAsValueType<ImmutableList<T>.Node>> stack = this._stack.Use<ImmutableList<T>.Enumerator>(ref this);
					while (!node.IsEmpty)
					{
						stack.Push(new RefAsValueType<ImmutableList<T>.Node>(node));
						node = this.PreviousBranch(node);
					}
				}
			}

			// Token: 0x040000B3 RID: 179
			private static readonly SecureObjectPool<Stack<RefAsValueType<ImmutableList<T>.Node>>, ImmutableList<T>.Enumerator> s_EnumeratingStacks = new SecureObjectPool<Stack<RefAsValueType<ImmutableList<T>.Node>>, ImmutableList<T>.Enumerator>();

			// Token: 0x040000B4 RID: 180
			private readonly ImmutableList<T>.Builder _builder;

			// Token: 0x040000B5 RID: 181
			private readonly int _poolUserId;

			// Token: 0x040000B6 RID: 182
			private readonly int _startIndex;

			// Token: 0x040000B7 RID: 183
			private readonly int _count;

			// Token: 0x040000B8 RID: 184
			private int _remainingCount;

			// Token: 0x040000B9 RID: 185
			private readonly bool _reversed;

			// Token: 0x040000BA RID: 186
			private ImmutableList<T>.Node _root;

			// Token: 0x040000BB RID: 187
			private SecurePooledObject<Stack<RefAsValueType<ImmutableList<T>.Node>>> _stack;

			// Token: 0x040000BC RID: 188
			private ImmutableList<T>.Node _current;

			// Token: 0x040000BD RID: 189
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x0200006E RID: 110
		[Nullable(0)]
		[DebuggerDisplay("{_key}")]
		internal sealed class Node : IBinaryTree<T>, IBinaryTree, IEnumerable<!0>, IEnumerable
		{
			// Token: 0x06000515 RID: 1301 RVA: 0x0000CF18 File Offset: 0x0000B118
			private Node()
			{
				this._frozen = true;
			}

			// Token: 0x06000516 RID: 1302 RVA: 0x0000CF28 File Offset: 0x0000B128
			private Node(T key, ImmutableList<T>.Node left, ImmutableList<T>.Node right, bool frozen = false)
			{
				Requires.NotNull<ImmutableList<T>.Node>(left, "left");
				Requires.NotNull<ImmutableList<T>.Node>(right, "right");
				this._key = key;
				this._left = left;
				this._right = right;
				this._height = ImmutableList<T>.Node.ParentHeight(left, right);
				this._count = ImmutableList<T>.Node.ParentCount(left, right);
				this._frozen = frozen;
			}

			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x06000517 RID: 1303 RVA: 0x0000CF88 File Offset: 0x0000B188
			public bool IsEmpty
			{
				get
				{
					return this._left == null;
				}
			}

			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x06000518 RID: 1304 RVA: 0x0000CF93 File Offset: 0x0000B193
			public int Height
			{
				get
				{
					return (int)this._height;
				}
			}

			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x06000519 RID: 1305 RVA: 0x0000CF9B File Offset: 0x0000B19B
			[Nullable(new byte[]
			{
				2,
				0
			})]
			public ImmutableList<T>.Node Left
			{
				[return: Nullable(new byte[]
				{
					2,
					0
				})]
				get
				{
					return this._left;
				}
			}

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x0600051A RID: 1306 RVA: 0x0000CFA3 File Offset: 0x0000B1A3
			[Nullable(2)]
			IBinaryTree IBinaryTree.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x0600051B RID: 1307 RVA: 0x0000CFAB File Offset: 0x0000B1AB
			[Nullable(new byte[]
			{
				2,
				0
			})]
			public ImmutableList<T>.Node Right
			{
				[return: Nullable(new byte[]
				{
					2,
					0
				})]
				get
				{
					return this._right;
				}
			}

			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x0600051C RID: 1308 RVA: 0x0000CFB3 File Offset: 0x0000B1B3
			[Nullable(2)]
			IBinaryTree IBinaryTree.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x170000FA RID: 250
			// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000CFBB File Offset: 0x0000B1BB
			[Nullable(new byte[]
			{
				2,
				1
			})]
			IBinaryTree<T> IBinaryTree<!0>.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x0600051E RID: 1310 RVA: 0x0000CFC3 File Offset: 0x0000B1C3
			[Nullable(new byte[]
			{
				2,
				1
			})]
			IBinaryTree<T> IBinaryTree<!0>.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000CFCB File Offset: 0x0000B1CB
			public T Value
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x170000FD RID: 253
			// (get) Token: 0x06000520 RID: 1312 RVA: 0x0000CFD3 File Offset: 0x0000B1D3
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000CFDB File Offset: 0x0000B1DB
			internal T Key
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x170000FF RID: 255
			internal T this[int index]
			{
				get
				{
					Requires.Range(index >= 0 && index < this.Count, "index", null);
					if (index < this._left._count)
					{
						return this._left[index];
					}
					if (index > this._left._count)
					{
						return this._right[index - this._left._count - 1];
					}
					return this._key;
				}
			}

			// Token: 0x06000523 RID: 1315 RVA: 0x0000D058 File Offset: 0x0000B258
			internal ref readonly T ItemRef(int index)
			{
				Requires.Range(index >= 0 && index < this.Count, "index", null);
				if (index < this._left._count)
				{
					return this._left.ItemRef(index);
				}
				if (index > this._left._count)
				{
					return this._right.ItemRef(index - this._left._count - 1);
				}
				return ref this._key;
			}

			// Token: 0x06000524 RID: 1316 RVA: 0x0000D0CA File Offset: 0x0000B2CA
			[NullableContext(0)]
			public ImmutableList<T>.Enumerator GetEnumerator()
			{
				return new ImmutableList<T>.Enumerator(this, null, -1, -1, false);
			}

			// Token: 0x06000525 RID: 1317 RVA: 0x0000D0D6 File Offset: 0x0000B2D6
			[ExcludeFromCodeCoverage]
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000526 RID: 1318 RVA: 0x0000D0E3 File Offset: 0x0000B2E3
			[ExcludeFromCodeCoverage]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000527 RID: 1319 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
			[NullableContext(0)]
			internal ImmutableList<T>.Enumerator GetEnumerator([Nullable(new byte[]
			{
				1,
				0
			})] ImmutableList<T>.Builder builder)
			{
				return new ImmutableList<T>.Enumerator(this, builder, -1, -1, false);
			}

			// Token: 0x06000528 RID: 1320 RVA: 0x0000D0FC File Offset: 0x0000B2FC
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal static ImmutableList<T>.Node NodeTreeFromList(IOrderedCollection<T> items, int start, int length)
			{
				Requires.NotNull<IOrderedCollection<T>>(items, "items");
				Requires.Range(start >= 0, "start", null);
				Requires.Range(length >= 0, "length", null);
				if (length == 0)
				{
					return ImmutableList<T>.Node.EmptyNode;
				}
				int num = (length - 1) / 2;
				int num2 = length - 1 - num;
				ImmutableList<T>.Node left = ImmutableList<T>.Node.NodeTreeFromList(items, start, num2);
				ImmutableList<T>.Node right = ImmutableList<T>.Node.NodeTreeFromList(items, start + num2 + 1, num);
				return new ImmutableList<T>.Node(items[start + num2], left, right, true);
			}

			// Token: 0x06000529 RID: 1321 RVA: 0x0000D174 File Offset: 0x0000B374
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Add(T key)
			{
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateLeaf(key);
				}
				ImmutableList<T>.Node right = this._right.Add(key);
				ImmutableList<T>.Node node = this.MutateRight(right);
				if (!node.IsBalanced)
				{
					return node.BalanceRight();
				}
				return node;
			}

			// Token: 0x0600052A RID: 1322 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Insert(int index, T key)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateLeaf(key);
				}
				if (index <= this._left._count)
				{
					ImmutableList<T>.Node left = this._left.Insert(index, key);
					ImmutableList<T>.Node node = this.MutateLeft(left);
					if (!node.IsBalanced)
					{
						return node.BalanceLeft();
					}
					return node;
				}
				else
				{
					ImmutableList<T>.Node right = this._right.Insert(index - this._left._count - 1, key);
					ImmutableList<T>.Node node2 = this.MutateRight(right);
					if (!node2.IsBalanced)
					{
						return node2.BalanceRight();
					}
					return node2;
				}
			}

			// Token: 0x0600052B RID: 1323 RVA: 0x0000D25C File Offset: 0x0000B45C
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node AddRange(IEnumerable<T> keys)
			{
				Requires.NotNull<IEnumerable<T>>(keys, "keys");
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateRange(keys);
				}
				ImmutableList<T>.Node right = this._right.AddRange(keys);
				ImmutableList<T>.Node node = this.MutateRight(right);
				return node.BalanceMany();
			}

			// Token: 0x0600052C RID: 1324 RVA: 0x0000D2A0 File Offset: 0x0000B4A0
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node InsertRange(int index, IEnumerable<T> keys)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				Requires.NotNull<IEnumerable<T>>(keys, "keys");
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateRange(keys);
				}
				ImmutableList<T>.Node node;
				if (index <= this._left._count)
				{
					ImmutableList<T>.Node left = this._left.InsertRange(index, keys);
					node = this.MutateLeft(left);
				}
				else
				{
					ImmutableList<T>.Node right = this._right.InsertRange(index - this._left._count - 1, keys);
					node = this.MutateRight(right);
				}
				return node.BalanceMany();
			}

			// Token: 0x0600052D RID: 1325 RVA: 0x0000D338 File Offset: 0x0000B538
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node RemoveAt(int index)
			{
				Requires.Range(index >= 0 && index < this.Count, "index", null);
				ImmutableList<T>.Node node;
				if (index == this._left._count)
				{
					if (this._right.IsEmpty && this._left.IsEmpty)
					{
						node = ImmutableList<T>.Node.EmptyNode;
					}
					else if (this._right.IsEmpty && !this._left.IsEmpty)
					{
						node = this._left;
					}
					else if (!this._right.IsEmpty && this._left.IsEmpty)
					{
						node = this._right;
					}
					else
					{
						ImmutableList<T>.Node node2 = this._right;
						while (!node2._left.IsEmpty)
						{
							node2 = node2._left;
						}
						ImmutableList<T>.Node right = this._right.RemoveAt(0);
						node = node2.MutateBoth(this._left, right);
					}
				}
				else if (index < this._left._count)
				{
					ImmutableList<T>.Node left = this._left.RemoveAt(index);
					node = this.MutateLeft(left);
				}
				else
				{
					ImmutableList<T>.Node right2 = this._right.RemoveAt(index - this._left._count - 1);
					node = this.MutateRight(right2);
				}
				if (!node.IsEmpty && !node.IsBalanced)
				{
					return node.Balance();
				}
				return node;
			}

			// Token: 0x0600052E RID: 1326 RVA: 0x0000D480 File Offset: 0x0000B680
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node RemoveAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				ImmutableList<T>.Node node = this;
				ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(node, null, -1, -1, false);
				try
				{
					int num = 0;
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							node = node.RemoveAt(num);
							enumerator.Dispose();
							enumerator = new ImmutableList<T>.Enumerator(node, null, num, -1, false);
						}
						else
						{
							num++;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				return node;
			}

			// Token: 0x0600052F RID: 1327 RVA: 0x0000D500 File Offset: 0x0000B700
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node ReplaceAt(int index, T value)
			{
				Requires.Range(index >= 0 && index < this.Count, "index", null);
				ImmutableList<T>.Node result;
				if (index == this._left._count)
				{
					result = this.MutateKey(value);
				}
				else if (index < this._left._count)
				{
					ImmutableList<T>.Node left = this._left.ReplaceAt(index, value);
					result = this.MutateLeft(left);
				}
				else
				{
					ImmutableList<T>.Node right = this._right.ReplaceAt(index - this._left._count - 1, value);
					result = this.MutateRight(right);
				}
				return result;
			}

			// Token: 0x06000530 RID: 1328 RVA: 0x0000D58D File Offset: 0x0000B78D
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Reverse()
			{
				return this.Reverse(0, this.Count);
			}

			// Token: 0x06000531 RID: 1329 RVA: 0x0000D59C File Offset: 0x0000B79C
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal unsafe ImmutableList<T>.Node Reverse(int index, int count)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "index", null);
				ImmutableList<T>.Node node = this;
				int i = index;
				int num = index + count - 1;
				while (i < num)
				{
					T value = *node.ItemRef(i);
					T value2 = *node.ItemRef(num);
					node = node.ReplaceAt(num, value).ReplaceAt(i, value2);
					i++;
					num--;
				}
				return node;
			}

			// Token: 0x06000532 RID: 1330 RVA: 0x0000D62B File Offset: 0x0000B82B
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Sort()
			{
				return this.Sort(Comparer<T>.Default);
			}

			// Token: 0x06000533 RID: 1331 RVA: 0x0000D638 File Offset: 0x0000B838
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Sort(Comparison<T> comparison)
			{
				Requires.NotNull<Comparison<T>>(comparison, "comparison");
				T[] array = new T[this.Count];
				this.CopyTo(array);
				Array.Sort<T>(array, comparison);
				return ImmutableList<T>.Node.NodeTreeFromList(array.AsOrderedCollection<T>(), 0, this.Count);
			}

			// Token: 0x06000534 RID: 1332 RVA: 0x0000D67C File Offset: 0x0000B87C
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Sort([Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				return this.Sort(0, this.Count, comparer);
			}

			// Token: 0x06000535 RID: 1333 RVA: 0x0000D68C File Offset: 0x0000B88C
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			internal ImmutableList<T>.Node Sort(int index, int count, [Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Argument(index + count <= this.Count);
				T[] array = new T[this.Count];
				this.CopyTo(array);
				Array.Sort<T>(array, index, count, comparer);
				return ImmutableList<T>.Node.NodeTreeFromList(array.AsOrderedCollection<T>(), 0, this.Count);
			}

			// Token: 0x06000536 RID: 1334 RVA: 0x0000D700 File Offset: 0x0000B900
			internal int BinarySearch(int index, int count, T item, [Nullable(new byte[]
			{
				2,
				1
			})] IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				comparer = (comparer ?? Comparer<T>.Default);
				if (this.IsEmpty || count <= 0)
				{
					return ~index;
				}
				int count2 = this._left.Count;
				if (index + count <= count2)
				{
					return this._left.BinarySearch(index, count, item, comparer);
				}
				if (index > count2)
				{
					int num = this._right.BinarySearch(index - count2 - 1, count, item, comparer);
					int num2 = count2 + 1;
					if (num >= 0)
					{
						return num + num2;
					}
					return num - num2;
				}
				else
				{
					int num3 = comparer.Compare(item, this._key);
					if (num3 == 0)
					{
						return count2;
					}
					if (num3 > 0)
					{
						int num4 = count - (count2 - index) - 1;
						int num5 = (num4 < 0) ? -1 : this._right.BinarySearch(0, num4, item, comparer);
						int num6 = count2 + 1;
						if (num5 >= 0)
						{
							return num5 + num6;
						}
						return num5 - num6;
					}
					else
					{
						if (index == count2)
						{
							return ~index;
						}
						return this._left.BinarySearch(index, count, item, comparer);
					}
				}
			}

			// Token: 0x06000537 RID: 1335 RVA: 0x0000D806 File Offset: 0x0000BA06
			internal int IndexOf(T item, [Nullable(new byte[]
			{
				2,
				1
			})] IEqualityComparer<T> equalityComparer)
			{
				return this.IndexOf(item, 0, this.Count, equalityComparer);
			}

			// Token: 0x06000538 RID: 1336 RVA: 0x0000D817 File Offset: 0x0000BA17
			internal bool Contains(T item, IEqualityComparer<T> equalityComparer)
			{
				return ImmutableList<T>.Node.Contains(this, item, equalityComparer);
			}

			// Token: 0x06000539 RID: 1337 RVA: 0x0000D824 File Offset: 0x0000BA24
			internal int IndexOf(T item, int index, int count, [Nullable(new byte[]
			{
				2,
				1
			})] IEqualityComparer<T> equalityComparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(count <= this.Count, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, index, count, false))
				{
					while (enumerator.MoveNext())
					{
						if (equalityComparer.Equals(item, enumerator.Current))
						{
							return index;
						}
						index++;
					}
				}
				return -1;
			}

			// Token: 0x0600053A RID: 1338 RVA: 0x0000D8E8 File Offset: 0x0000BAE8
			internal int LastIndexOf(T item, int index, int count, [Nullable(new byte[]
			{
				2,
				1
			})] IEqualityComparer<T> equalityComparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0 && count <= this.Count, "count", null);
				Requires.Argument(index - count + 1 >= 0);
				equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, index, count, true))
				{
					while (enumerator.MoveNext())
					{
						if (equalityComparer.Equals(item, enumerator.Current))
						{
							return index;
						}
						index--;
					}
				}
				return -1;
			}

			// Token: 0x0600053B RID: 1339 RVA: 0x0000D998 File Offset: 0x0000BB98
			internal void CopyTo(T[] array)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(array.Length >= this.Count, "array", null);
				int num = 0;
				foreach (T t in this)
				{
					array[num++] = t;
				}
			}

			// Token: 0x0600053C RID: 1340 RVA: 0x0000DA14 File Offset: 0x0000BC14
			internal void CopyTo(T[] array, int arrayIndex)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				foreach (T t in this)
				{
					array[arrayIndex++] = t;
				}
			}

			// Token: 0x0600053D RID: 1341 RVA: 0x0000DAA0 File Offset: 0x0000BCA0
			internal void CopyTo(int index, T[] array, int arrayIndex, int count)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(arrayIndex + count <= array.Length, "arrayIndex", null);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, index, count, false))
				{
					while (enumerator.MoveNext())
					{
						T t = enumerator.Current;
						array[arrayIndex++] = t;
					}
				}
			}

			// Token: 0x0600053E RID: 1342 RVA: 0x0000DB6C File Offset: 0x0000BD6C
			internal void CopyTo(Array array, int arrayIndex)
			{
				Requires.NotNull<Array>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				foreach (T t in this)
				{
					array.SetValue(t, arrayIndex++);
				}
			}

			// Token: 0x0600053F RID: 1343 RVA: 0x0000DC00 File Offset: 0x0000BE00
			internal ImmutableList<TOutput>.Node ConvertAll<[Nullable(2)] TOutput>(Func<T, TOutput> converter)
			{
				ImmutableList<TOutput>.Node emptyNode = ImmutableList<TOutput>.Node.EmptyNode;
				if (this.IsEmpty)
				{
					return emptyNode;
				}
				return emptyNode.AddRange(this.Select(converter));
			}

			// Token: 0x06000540 RID: 1344 RVA: 0x0000DC2C File Offset: 0x0000BE2C
			internal bool TrueForAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				foreach (T obj in this)
				{
					if (!match(obj))
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x06000541 RID: 1345 RVA: 0x0000DC90 File Offset: 0x0000BE90
			internal bool Exists(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				foreach (T obj in this)
				{
					if (match(obj))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000542 RID: 1346 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
			[return: Nullable(2)]
			internal T Find(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				foreach (T t in this)
				{
					if (match(t))
					{
						return t;
					}
				}
				return default(T);
			}

			// Token: 0x06000543 RID: 1347 RVA: 0x0000DD60 File Offset: 0x0000BF60
			internal ImmutableList<T> FindAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Empty;
				}
				List<T> list = null;
				foreach (T t in this)
				{
					if (match(t))
					{
						if (list == null)
						{
							list = new List<T>();
						}
						list.Add(t);
					}
				}
				if (list == null)
				{
					return ImmutableList<T>.Empty;
				}
				return ImmutableList.CreateRange<T>(list);
			}

			// Token: 0x06000544 RID: 1348 RVA: 0x0000DDEC File Offset: 0x0000BFEC
			internal int FindIndex(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this.FindIndex(0, this._count, match);
			}

			// Token: 0x06000545 RID: 1349 RVA: 0x0000DE07 File Offset: 0x0000C007
			internal int FindIndex(int startIndex, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0 && startIndex <= this.Count, "startIndex", null);
				return this.FindIndex(startIndex, this.Count - startIndex, match);
			}

			// Token: 0x06000546 RID: 1350 RVA: 0x0000DE44 File Offset: 0x0000C044
			internal int FindIndex(int startIndex, int count, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(startIndex + count <= this.Count, "count", null);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, startIndex, count, false))
				{
					int num = startIndex;
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							return num;
						}
						num++;
					}
				}
				return -1;
			}

			// Token: 0x06000547 RID: 1351 RVA: 0x0000DEEC File Offset: 0x0000C0EC
			[return: Nullable(2)]
			internal T FindLast(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, -1, -1, true))
				{
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							return enumerator.Current;
						}
					}
				}
				return default(T);
			}

			// Token: 0x06000548 RID: 1352 RVA: 0x0000DF60 File Offset: 0x0000C160
			internal int FindLastIndex(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				if (!this.IsEmpty)
				{
					return this.FindLastIndex(this.Count - 1, this.Count, match);
				}
				return -1;
			}

			// Token: 0x06000549 RID: 1353 RVA: 0x0000DF8C File Offset: 0x0000C18C
			internal int FindLastIndex(int startIndex, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(startIndex == 0 || startIndex < this.Count, "startIndex", null);
				if (!this.IsEmpty)
				{
					return this.FindLastIndex(startIndex, startIndex + 1, match);
				}
				return -1;
			}

			// Token: 0x0600054A RID: 1354 RVA: 0x0000DFE8 File Offset: 0x0000C1E8
			internal int FindLastIndex(int startIndex, int count, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(count <= this.Count, "count", null);
				Requires.Range(startIndex - count + 1 >= 0, "startIndex", null);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, startIndex, count, true))
				{
					int num = startIndex;
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							return num;
						}
						num--;
					}
				}
				return -1;
			}

			// Token: 0x0600054B RID: 1355 RVA: 0x0000E094 File Offset: 0x0000C294
			internal void Freeze()
			{
				if (!this._frozen)
				{
					this._left.Freeze();
					this._right.Freeze();
					this._frozen = true;
				}
			}

			// Token: 0x0600054C RID: 1356 RVA: 0x0000E0BB File Offset: 0x0000C2BB
			private ImmutableList<T>.Node RotateLeft()
			{
				return this._right.MutateLeft(this.MutateRight(this._right._left));
			}

			// Token: 0x0600054D RID: 1357 RVA: 0x0000E0D9 File Offset: 0x0000C2D9
			private ImmutableList<T>.Node RotateRight()
			{
				return this._left.MutateRight(this.MutateLeft(this._left._right));
			}

			// Token: 0x0600054E RID: 1358 RVA: 0x0000E0F8 File Offset: 0x0000C2F8
			private ImmutableList<T>.Node DoubleLeft()
			{
				ImmutableList<T>.Node right = this._right;
				ImmutableList<T>.Node left = right._left;
				return left.MutateBoth(this.MutateRight(left._left), right.MutateLeft(left._right));
			}

			// Token: 0x0600054F RID: 1359 RVA: 0x0000E134 File Offset: 0x0000C334
			private ImmutableList<T>.Node DoubleRight()
			{
				ImmutableList<T>.Node left = this._left;
				ImmutableList<T>.Node right = left._right;
				return right.MutateBoth(left.MutateRight(right._left), this.MutateLeft(right._right));
			}

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x06000550 RID: 1360 RVA: 0x0000E16D File Offset: 0x0000C36D
			private int BalanceFactor
			{
				get
				{
					return (int)(this._right._height - this._left._height);
				}
			}

			// Token: 0x17000101 RID: 257
			// (get) Token: 0x06000551 RID: 1361 RVA: 0x0000E186 File Offset: 0x0000C386
			private bool IsRightHeavy
			{
				get
				{
					return this.BalanceFactor >= 2;
				}
			}

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x06000552 RID: 1362 RVA: 0x0000E194 File Offset: 0x0000C394
			private bool IsLeftHeavy
			{
				get
				{
					return this.BalanceFactor <= -2;
				}
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000E1A3 File Offset: 0x0000C3A3
			private bool IsBalanced
			{
				get
				{
					return this.BalanceFactor + 1 <= 2;
				}
			}

			// Token: 0x06000554 RID: 1364 RVA: 0x0000E1B3 File Offset: 0x0000C3B3
			private ImmutableList<T>.Node Balance()
			{
				if (!this.IsLeftHeavy)
				{
					return this.BalanceRight();
				}
				return this.BalanceLeft();
			}

			// Token: 0x06000555 RID: 1365 RVA: 0x0000E1CA File Offset: 0x0000C3CA
			private ImmutableList<T>.Node BalanceLeft()
			{
				if (this._left.BalanceFactor <= 0)
				{
					return this.RotateRight();
				}
				return this.DoubleRight();
			}

			// Token: 0x06000556 RID: 1366 RVA: 0x0000E1E7 File Offset: 0x0000C3E7
			private ImmutableList<T>.Node BalanceRight()
			{
				if (this._right.BalanceFactor >= 0)
				{
					return this.RotateLeft();
				}
				return this.DoubleLeft();
			}

			// Token: 0x06000557 RID: 1367 RVA: 0x0000E204 File Offset: 0x0000C404
			private ImmutableList<T>.Node BalanceMany()
			{
				ImmutableList<T>.Node node = this;
				while (!node.IsBalanced)
				{
					if (node.IsRightHeavy)
					{
						node = node.BalanceRight();
						node.MutateLeft(node._left.BalanceMany());
					}
					else
					{
						node = node.BalanceLeft();
						node.MutateRight(node._right.BalanceMany());
					}
				}
				return node;
			}

			// Token: 0x06000558 RID: 1368 RVA: 0x0000E25C File Offset: 0x0000C45C
			private ImmutableList<T>.Node MutateBoth(ImmutableList<T>.Node left, ImmutableList<T>.Node right)
			{
				Requires.NotNull<ImmutableList<T>.Node>(left, "left");
				Requires.NotNull<ImmutableList<T>.Node>(right, "right");
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(this._key, left, right, false);
				}
				this._left = left;
				this._right = right;
				this._height = ImmutableList<T>.Node.ParentHeight(left, right);
				this._count = ImmutableList<T>.Node.ParentCount(left, right);
				return this;
			}

			// Token: 0x06000559 RID: 1369 RVA: 0x0000E2C0 File Offset: 0x0000C4C0
			private ImmutableList<T>.Node MutateLeft(ImmutableList<T>.Node left)
			{
				Requires.NotNull<ImmutableList<T>.Node>(left, "left");
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(this._key, left, this._right, false);
				}
				this._left = left;
				this._height = ImmutableList<T>.Node.ParentHeight(left, this._right);
				this._count = ImmutableList<T>.Node.ParentCount(left, this._right);
				return this;
			}

			// Token: 0x0600055A RID: 1370 RVA: 0x0000E320 File Offset: 0x0000C520
			private ImmutableList<T>.Node MutateRight(ImmutableList<T>.Node right)
			{
				Requires.NotNull<ImmutableList<T>.Node>(right, "right");
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(this._key, this._left, right, false);
				}
				this._right = right;
				this._height = ImmutableList<T>.Node.ParentHeight(this._left, right);
				this._count = ImmutableList<T>.Node.ParentCount(this._left, right);
				return this;
			}

			// Token: 0x0600055B RID: 1371 RVA: 0x0000E380 File Offset: 0x0000C580
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static byte ParentHeight(ImmutableList<T>.Node left, ImmutableList<T>.Node right)
			{
				return checked(1 + Math.Max(left._height, right._height));
			}

			// Token: 0x0600055C RID: 1372 RVA: 0x0000E396 File Offset: 0x0000C596
			private static int ParentCount(ImmutableList<T>.Node left, ImmutableList<T>.Node right)
			{
				return 1 + left._count + right._count;
			}

			// Token: 0x0600055D RID: 1373 RVA: 0x0000E3A7 File Offset: 0x0000C5A7
			private ImmutableList<T>.Node MutateKey(T key)
			{
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(key, this._left, this._right, false);
				}
				this._key = key;
				return this;
			}

			// Token: 0x0600055E RID: 1374 RVA: 0x0000E3D0 File Offset: 0x0000C5D0
			private static ImmutableList<T>.Node CreateRange(IEnumerable<T> keys)
			{
				ImmutableList<T> immutableList;
				if (ImmutableList<T>.TryCastToImmutableList(keys, out immutableList))
				{
					return immutableList._root;
				}
				IOrderedCollection<T> orderedCollection = keys.AsOrderedCollection<T>();
				return ImmutableList<T>.Node.NodeTreeFromList(orderedCollection, 0, orderedCollection.Count);
			}

			// Token: 0x0600055F RID: 1375 RVA: 0x0000E402 File Offset: 0x0000C602
			private static ImmutableList<T>.Node CreateLeaf(T key)
			{
				return new ImmutableList<T>.Node(key, ImmutableList<T>.Node.EmptyNode, ImmutableList<T>.Node.EmptyNode, false);
			}

			// Token: 0x06000560 RID: 1376 RVA: 0x0000E415 File Offset: 0x0000C615
			private static bool Contains(ImmutableList<T>.Node node, T value, IEqualityComparer<T> equalityComparer)
			{
				return !node.IsEmpty && (equalityComparer.Equals(value, node._key) || ImmutableList<T>.Node.Contains(node._left, value, equalityComparer) || ImmutableList<T>.Node.Contains(node._right, value, equalityComparer));
			}

			// Token: 0x040000BE RID: 190
			[Nullable(new byte[]
			{
				1,
				0
			})]
			internal static readonly ImmutableList<T>.Node EmptyNode = new ImmutableList<T>.Node();

			// Token: 0x040000BF RID: 191
			private T _key;

			// Token: 0x040000C0 RID: 192
			private bool _frozen;

			// Token: 0x040000C1 RID: 193
			private byte _height;

			// Token: 0x040000C2 RID: 194
			private int _count;

			// Token: 0x040000C3 RID: 195
			private ImmutableList<T>.Node _left;

			// Token: 0x040000C4 RID: 196
			private ImmutableList<T>.Node _right;
		}
	}
}
