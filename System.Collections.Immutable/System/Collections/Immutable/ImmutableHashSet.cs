using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000024 RID: 36
	[NullableContext(1)]
	[Nullable(0)]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
	public sealed class ImmutableHashSet<[Nullable(2)] T> : IImmutableSet<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IHashKeyCollection<T>, ICollection<T>, ISet<T>, ICollection, IStrongEnumerable<T, ImmutableHashSet<T>.Enumerator>
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00002EAA File Offset: 0x000010AA
		internal ImmutableHashSet(IEqualityComparer<T> equalityComparer) : this(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode, equalityComparer, 0)
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00002EBC File Offset: 0x000010BC
		private ImmutableHashSet(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, IEqualityComparer<T> equalityComparer, int count)
		{
			Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
			Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
			root.Freeze(ImmutableHashSet<T>.s_FreezeBucketAction);
			this._root = root;
			this._count = count;
			this._equalityComparer = equalityComparer;
			this._hashBucketEqualityComparer = ImmutableHashSet<T>.GetHashBucketEqualityComparer(equalityComparer);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00002F11 File Offset: 0x00001111
		public ImmutableHashSet<T> Clear()
		{
			if (!this.IsEmpty)
			{
				return ImmutableHashSet<T>.Empty.WithComparer(this._equalityComparer);
			}
			return this;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00002F2D File Offset: 0x0000112D
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002F35 File Offset: 0x00001135
		public bool IsEmpty
		{
			get
			{
				return this.Count == 0;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00002F40 File Offset: 0x00001140
		public IEqualityComparer<T> KeyComparer
		{
			get
			{
				return this._equalityComparer;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00002F48 File Offset: 0x00001148
		IImmutableSet<T> IImmutableSet<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00002F50 File Offset: 0x00001150
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00002F53 File Offset: 0x00001153
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00002F56 File Offset: 0x00001156
		internal IBinaryTree Root
		{
			get
			{
				return this._root;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00002F5E File Offset: 0x0000115E
		[Nullable(0)]
		private ImmutableHashSet<T>.MutationInput Origin
		{
			get
			{
				return new ImmutableHashSet<T>.MutationInput(this);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002F66 File Offset: 0x00001166
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public ImmutableHashSet<T>.Builder ToBuilder()
		{
			return new ImmutableHashSet<T>.Builder(this);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002F70 File Offset: 0x00001170
		public ImmutableHashSet<T> Add(T item)
		{
			return ImmutableHashSet<T>.Add(item, this.Origin).Finalize(this);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002F94 File Offset: 0x00001194
		public ImmutableHashSet<T> Remove(T item)
		{
			return ImmutableHashSet<T>.Remove(item, this.Origin).Finalize(this);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002FB8 File Offset: 0x000011B8
		public bool TryGetValue(T equalValue, out T actualValue)
		{
			int key = (equalValue != null) ? this._equalityComparer.GetHashCode(equalValue) : 0;
			ImmutableHashSet<T>.HashBucket hashBucket;
			if (this._root.TryGetValue(key, out hashBucket))
			{
				return hashBucket.TryExchange(equalValue, this._equalityComparer, out actualValue);
			}
			actualValue = equalValue;
			return false;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003005 File Offset: 0x00001205
		public ImmutableHashSet<T> Union(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return this.Union(other, false);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000301C File Offset: 0x0000121C
		public ImmutableHashSet<T> Intersect(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.Intersect(other, this.Origin).Finalize(this);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000304C File Offset: 0x0000124C
		public ImmutableHashSet<T> Except(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.Except(other, this._equalityComparer, this._hashBucketEqualityComparer, this._root).Finalize(this);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003088 File Offset: 0x00001288
		public ImmutableHashSet<T> SymmetricExcept(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.SymmetricExcept(other, this.Origin).Finalize(this);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000030B5 File Offset: 0x000012B5
		public bool SetEquals(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return this == other || ImmutableHashSet<T>.SetEquals(other, this.Origin);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000030D4 File Offset: 0x000012D4
		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsProperSubsetOf(other, this.Origin);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000030ED File Offset: 0x000012ED
		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsProperSupersetOf(other, this.Origin);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003106 File Offset: 0x00001306
		public bool IsSubsetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsSubsetOf(other, this.Origin);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000311F File Offset: 0x0000131F
		public bool IsSupersetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsSupersetOf(other, this.Origin);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003138 File Offset: 0x00001338
		public bool Overlaps(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.Overlaps(other, this.Origin);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003151 File Offset: 0x00001351
		IImmutableSet<T> IImmutableSet<!0>.Add(T item)
		{
			return this.Add(item);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000315A File Offset: 0x0000135A
		IImmutableSet<T> IImmutableSet<!0>.Remove(T item)
		{
			return this.Remove(item);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003163 File Offset: 0x00001363
		IImmutableSet<T> IImmutableSet<!0>.Union(IEnumerable<T> other)
		{
			return this.Union(other);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000316C File Offset: 0x0000136C
		IImmutableSet<T> IImmutableSet<!0>.Intersect(IEnumerable<T> other)
		{
			return this.Intersect(other);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003175 File Offset: 0x00001375
		IImmutableSet<T> IImmutableSet<!0>.Except(IEnumerable<T> other)
		{
			return this.Except(other);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000317E File Offset: 0x0000137E
		IImmutableSet<T> IImmutableSet<!0>.SymmetricExcept(IEnumerable<T> other)
		{
			return this.SymmetricExcept(other);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003187 File Offset: 0x00001387
		public bool Contains(T item)
		{
			return ImmutableHashSet<T>.Contains(item, this.Origin);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003198 File Offset: 0x00001398
		public ImmutableHashSet<T> WithComparer([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			if (equalityComparer == null)
			{
				equalityComparer = EqualityComparer<T>.Default;
			}
			if (equalityComparer == this._equalityComparer)
			{
				return this;
			}
			ImmutableHashSet<T> immutableHashSet = new ImmutableHashSet<T>(equalityComparer);
			return immutableHashSet.Union(this, true);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000031CB File Offset: 0x000013CB
		bool ISet<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000031D2 File Offset: 0x000013D2
		void ISet<!0>.ExceptWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000031D9 File Offset: 0x000013D9
		void ISet<!0>.IntersectWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000031E0 File Offset: 0x000013E0
		void ISet<!0>.SymmetricExceptWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000031E7 File Offset: 0x000013E7
		void ISet<!0>.UnionWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000DC RID: 220 RVA: 0x000031EE File Offset: 0x000013EE
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000031F4 File Offset: 0x000013F4
		void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
		{
			Requires.NotNull<T[]>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (T t in this)
			{
				array[arrayIndex++] = t;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003280 File Offset: 0x00001480
		void ICollection<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003287 File Offset: 0x00001487
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000328E File Offset: 0x0000148E
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003298 File Offset: 0x00001498
		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			Requires.NotNull<Array>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (T t in this)
			{
				array.SetValue(t, arrayIndex++);
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000332C File Offset: 0x0000152C
		[NullableContext(0)]
		public ImmutableHashSet<T>.Enumerator GetEnumerator()
		{
			return new ImmutableHashSet<T>.Enumerator(this._root, null);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000333C File Offset: 0x0000153C
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			if (!this.IsEmpty)
			{
				return this.GetEnumerator();
			}
			return Enumerable.Empty<T>().GetEnumerator();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003369 File Offset: 0x00001569
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003378 File Offset: 0x00001578
		private static bool IsSupersetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				if (!ImmutableHashSet<T>.Contains(item, origin))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000033E4 File Offset: 0x000015E4
		private static ImmutableHashSet<T>.MutationResult Add(T item, ImmutableHashSet<T>.MutationInput origin)
		{
			int num = (item != null) ? origin.EqualityComparer.GetHashCode(item) : 0;
			ImmutableHashSet<T>.OperationResult operationResult;
			ImmutableHashSet<T>.HashBucket newBucket = origin.Root.GetValueOrDefault(num).Add(item, origin.EqualityComparer, out operationResult);
			if (operationResult == ImmutableHashSet<T>.OperationResult.NoChangeRequired)
			{
				return new ImmutableHashSet<T>.MutationResult(origin.Root, 0, ImmutableHashSet<T>.CountType.Adjustment);
			}
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = ImmutableHashSet<T>.UpdateRoot(origin.Root, num, origin.HashBucketEqualityComparer, newBucket);
			return new ImmutableHashSet<T>.MutationResult(root, 1, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00003460 File Offset: 0x00001660
		private static ImmutableHashSet<T>.MutationResult Remove(T item, ImmutableHashSet<T>.MutationInput origin)
		{
			ImmutableHashSet<T>.OperationResult operationResult = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
			int num = (item != null) ? origin.EqualityComparer.GetHashCode(item) : 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = origin.Root;
			ImmutableHashSet<T>.HashBucket hashBucket;
			if (origin.Root.TryGetValue(num, out hashBucket))
			{
				ImmutableHashSet<T>.HashBucket newBucket = hashBucket.Remove(item, origin.EqualityComparer, out operationResult);
				if (operationResult == ImmutableHashSet<T>.OperationResult.NoChangeRequired)
				{
					return new ImmutableHashSet<T>.MutationResult(origin.Root, 0, ImmutableHashSet<T>.CountType.Adjustment);
				}
				root = ImmutableHashSet<T>.UpdateRoot(origin.Root, num, origin.HashBucketEqualityComparer, newBucket);
			}
			return new ImmutableHashSet<T>.MutationResult(root, (operationResult == ImmutableHashSet<T>.OperationResult.SizeChanged) ? -1 : 0, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000034EC File Offset: 0x000016EC
		private static bool Contains(T item, ImmutableHashSet<T>.MutationInput origin)
		{
			int key = (item != null) ? origin.EqualityComparer.GetHashCode(item) : 0;
			ImmutableHashSet<T>.HashBucket hashBucket;
			return origin.Root.TryGetValue(key, out hashBucket) && hashBucket.Contains(item, origin.EqualityComparer);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003534 File Offset: 0x00001734
		private static ImmutableHashSet<T>.MutationResult Union(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			int num = 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> sortedInt32KeyNode = origin.Root;
			foreach (T t in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				int num2 = (t != null) ? origin.EqualityComparer.GetHashCode(t) : 0;
				ImmutableHashSet<T>.OperationResult operationResult;
				ImmutableHashSet<T>.HashBucket newBucket = sortedInt32KeyNode.GetValueOrDefault(num2).Add(t, origin.EqualityComparer, out operationResult);
				if (operationResult == ImmutableHashSet<T>.OperationResult.SizeChanged)
				{
					sortedInt32KeyNode = ImmutableHashSet<T>.UpdateRoot(sortedInt32KeyNode, num2, origin.HashBucketEqualityComparer, newBucket);
					num++;
				}
			}
			return new ImmutableHashSet<T>.MutationResult(sortedInt32KeyNode, num, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000035F8 File Offset: 0x000017F8
		private static bool Overlaps(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return false;
			}
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003674 File Offset: 0x00001874
		private static bool SetEquals(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
			if (origin.Count != hashSet.Count)
			{
				return false;
			}
			foreach (T item in hashSet)
			{
				if (!ImmutableHashSet<T>.Contains(item, origin))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000036F8 File Offset: 0x000018F8
		private static SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> UpdateRoot(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, int hashCode, IEqualityComparer<ImmutableHashSet<T>.HashBucket> hashBucketEqualityComparer, ImmutableHashSet<T>.HashBucket newBucket)
		{
			bool flag;
			if (newBucket.IsEmpty)
			{
				return root.Remove(hashCode, out flag);
			}
			bool flag2;
			return root.SetItem(hashCode, newBucket, hashBucketEqualityComparer, out flag2, out flag);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003728 File Offset: 0x00001928
		private static ImmutableHashSet<T>.MutationResult Intersect(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;
			int num = 0;
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					ImmutableHashSet<T>.MutationResult mutationResult = ImmutableHashSet<T>.Add(item, new ImmutableHashSet<T>.MutationInput(root, origin.EqualityComparer, origin.HashBucketEqualityComparer, num));
					root = mutationResult.Root;
					num += mutationResult.Count;
				}
			}
			return new ImmutableHashSet<T>.MutationResult(root, num, ImmutableHashSet<T>.CountType.FinalValue);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000037D0 File Offset: 0x000019D0
		private static ImmutableHashSet<T>.MutationResult Except(IEnumerable<T> other, IEqualityComparer<T> equalityComparer, IEqualityComparer<ImmutableHashSet<T>.HashBucket> hashBucketEqualityComparer, SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
			Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
			int num = 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> sortedInt32KeyNode = root;
			foreach (T t in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				int num2 = (t != null) ? equalityComparer.GetHashCode(t) : 0;
				ImmutableHashSet<T>.HashBucket hashBucket;
				if (sortedInt32KeyNode.TryGetValue(num2, out hashBucket))
				{
					ImmutableHashSet<T>.OperationResult operationResult;
					ImmutableHashSet<T>.HashBucket newBucket = hashBucket.Remove(t, equalityComparer, out operationResult);
					if (operationResult == ImmutableHashSet<T>.OperationResult.SizeChanged)
					{
						num--;
						sortedInt32KeyNode = ImmutableHashSet<T>.UpdateRoot(sortedInt32KeyNode, num2, hashBucketEqualityComparer, newBucket);
					}
				}
			}
			return new ImmutableHashSet<T>.MutationResult(sortedInt32KeyNode, num, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00003894 File Offset: 0x00001A94
		private static ImmutableHashSet<T>.MutationResult SymmetricExcept(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			ImmutableHashSet<T> immutableHashSet = ImmutableHashSet.CreateRange<T>(origin.EqualityComparer, other);
			int num = 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;
			foreach (T item in new ImmutableHashSet<T>.NodeEnumerable(origin.Root))
			{
				if (!immutableHashSet.Contains(item))
				{
					ImmutableHashSet<T>.MutationResult mutationResult = ImmutableHashSet<T>.Add(item, new ImmutableHashSet<T>.MutationInput(root, origin.EqualityComparer, origin.HashBucketEqualityComparer, num));
					root = mutationResult.Root;
					num += mutationResult.Count;
				}
			}
			foreach (T item2 in immutableHashSet)
			{
				if (!ImmutableHashSet<T>.Contains(item2, origin))
				{
					ImmutableHashSet<T>.MutationResult mutationResult2 = ImmutableHashSet<T>.Add(item2, new ImmutableHashSet<T>.MutationInput(root, origin.EqualityComparer, origin.HashBucketEqualityComparer, num));
					root = mutationResult2.Root;
					num += mutationResult2.Count;
				}
			}
			return new ImmutableHashSet<T>.MutationResult(root, num, ImmutableHashSet<T>.CountType.FinalValue);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000039C0 File Offset: 0x00001BC0
		private static bool IsProperSubsetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return other.Any<T>();
			}
			HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
			if (origin.Count >= hashSet.Count)
			{
				return false;
			}
			int num = 0;
			bool flag = false;
			foreach (T item in hashSet)
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					num++;
				}
				else
				{
					flag = true;
				}
				if (num == origin.Count && flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00003A74 File Offset: 0x00001C74
		private static bool IsProperSupersetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return false;
			}
			int num = 0;
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				num++;
				if (!ImmutableHashSet<T>.Contains(item, origin))
				{
					return false;
				}
			}
			return origin.Count > num;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003B00 File Offset: 0x00001D00
		private static bool IsSubsetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return true;
			}
			HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
			int num = 0;
			foreach (T item in hashSet)
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					num++;
				}
			}
			return num == origin.Count;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003B8C File Offset: 0x00001D8C
		private static ImmutableHashSet<T> Wrap(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, IEqualityComparer<T> equalityComparer, int count)
		{
			Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
			Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
			Requires.Range(count >= 0, "count", null);
			return new ImmutableHashSet<T>(root, equalityComparer, count);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00003BBE File Offset: 0x00001DBE
		private static IEqualityComparer<ImmutableHashSet<T>.HashBucket> GetHashBucketEqualityComparer(IEqualityComparer<T> valueComparer)
		{
			if (!ImmutableExtensions.IsValueType<T>())
			{
				return ImmutableHashSet<T>.HashBucketByRefEqualityComparer.DefaultInstance;
			}
			if (valueComparer == EqualityComparer<T>.Default)
			{
				return ImmutableHashSet<T>.HashBucketByValueEqualityComparer.DefaultInstance;
			}
			return new ImmutableHashSet<T>.HashBucketByValueEqualityComparer(valueComparer);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003BE1 File Offset: 0x00001DE1
		private ImmutableHashSet<T> Wrap(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, int adjustedCountIfDifferentRoot)
		{
			if (root == this._root)
			{
				return this;
			}
			return new ImmutableHashSet<T>(root, this._equalityComparer, adjustedCountIfDifferentRoot);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003BFC File Offset: 0x00001DFC
		private ImmutableHashSet<T> Union(IEnumerable<T> items, bool avoidWithComparer)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (this.IsEmpty && !avoidWithComparer)
			{
				ImmutableHashSet<T> immutableHashSet = items as ImmutableHashSet<T>;
				if (immutableHashSet != null)
				{
					return immutableHashSet.WithComparer(this.KeyComparer);
				}
			}
			return ImmutableHashSet<T>.Union(items, this.Origin).Finalize(this);
		}

		// Token: 0x04000013 RID: 19
		public static readonly ImmutableHashSet<T> Empty = new ImmutableHashSet<T>(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode, EqualityComparer<T>.Default, 0);

		// Token: 0x04000014 RID: 20
		private static readonly Action<KeyValuePair<int, ImmutableHashSet<T>.HashBucket>> s_FreezeBucketAction = delegate(KeyValuePair<int, ImmutableHashSet<T>.HashBucket> kv)
		{
			kv.Value.Freeze();
		};

		// Token: 0x04000015 RID: 21
		private readonly IEqualityComparer<T> _equalityComparer;

		// Token: 0x04000016 RID: 22
		private readonly int _count;

		// Token: 0x04000017 RID: 23
		private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;

		// Token: 0x04000018 RID: 24
		private readonly IEqualityComparer<ImmutableHashSet<T>.HashBucket> _hashBucketEqualityComparer;

		// Token: 0x0200004E RID: 78
		private class HashBucketByValueEqualityComparer : IEqualityComparer<ImmutableHashSet<T>.HashBucket>
		{
			// Token: 0x170000A1 RID: 161
			// (get) Token: 0x060003AF RID: 943 RVA: 0x00009C7F File Offset: 0x00007E7F
			internal static IEqualityComparer<ImmutableHashSet<T>.HashBucket> DefaultInstance
			{
				get
				{
					return ImmutableHashSet<T>.HashBucketByValueEqualityComparer.s_defaultInstance;
				}
			}

			// Token: 0x060003B0 RID: 944 RVA: 0x00009C86 File Offset: 0x00007E86
			internal HashBucketByValueEqualityComparer(IEqualityComparer<T> valueComparer)
			{
				Requires.NotNull<IEqualityComparer<T>>(valueComparer, "valueComparer");
				this._valueComparer = valueComparer;
			}

			// Token: 0x060003B1 RID: 945 RVA: 0x00009CA0 File Offset: 0x00007EA0
			public bool Equals(ImmutableHashSet<T>.HashBucket x, ImmutableHashSet<T>.HashBucket y)
			{
				return x.EqualsByValue(y, this._valueComparer);
			}

			// Token: 0x060003B2 RID: 946 RVA: 0x00009CB0 File Offset: 0x00007EB0
			public int GetHashCode(ImmutableHashSet<T>.HashBucket obj)
			{
				throw new NotSupportedException();
			}

			// Token: 0x04000058 RID: 88
			private static readonly IEqualityComparer<ImmutableHashSet<T>.HashBucket> s_defaultInstance = new ImmutableHashSet<T>.HashBucketByValueEqualityComparer(EqualityComparer<T>.Default);

			// Token: 0x04000059 RID: 89
			private readonly IEqualityComparer<T> _valueComparer;
		}

		// Token: 0x0200004F RID: 79
		private class HashBucketByRefEqualityComparer : IEqualityComparer<ImmutableHashSet<T>.HashBucket>
		{
			// Token: 0x170000A2 RID: 162
			// (get) Token: 0x060003B4 RID: 948 RVA: 0x00009CC8 File Offset: 0x00007EC8
			internal static IEqualityComparer<ImmutableHashSet<T>.HashBucket> DefaultInstance
			{
				get
				{
					return ImmutableHashSet<T>.HashBucketByRefEqualityComparer.s_defaultInstance;
				}
			}

			// Token: 0x060003B5 RID: 949 RVA: 0x00009CCF File Offset: 0x00007ECF
			private HashBucketByRefEqualityComparer()
			{
			}

			// Token: 0x060003B6 RID: 950 RVA: 0x00009CD7 File Offset: 0x00007ED7
			public bool Equals(ImmutableHashSet<T>.HashBucket x, ImmutableHashSet<T>.HashBucket y)
			{
				return x.EqualsByRef(y);
			}

			// Token: 0x060003B7 RID: 951 RVA: 0x00009CE1 File Offset: 0x00007EE1
			public int GetHashCode(ImmutableHashSet<T>.HashBucket obj)
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400005A RID: 90
			private static readonly IEqualityComparer<ImmutableHashSet<T>.HashBucket> s_defaultInstance = new ImmutableHashSet<T>.HashBucketByRefEqualityComparer();
		}

		// Token: 0x02000050 RID: 80
		[Nullable(0)]
		[DebuggerDisplay("Count = {Count}")]
		public sealed class Builder : IReadOnlyCollection<T>, IEnumerable<!0>, IEnumerable, ISet<!0>, ICollection<!0>
		{
			// Token: 0x060003B9 RID: 953 RVA: 0x00009CF4 File Offset: 0x00007EF4
			internal Builder(ImmutableHashSet<T> set)
			{
				Requires.NotNull<ImmutableHashSet<T>>(set, "set");
				this._root = set._root;
				this._count = set._count;
				this._equalityComparer = set._equalityComparer;
				this._hashBucketEqualityComparer = set._hashBucketEqualityComparer;
				this._immutable = set;
			}

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x060003BA RID: 954 RVA: 0x00009D54 File Offset: 0x00007F54
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x060003BB RID: 955 RVA: 0x00009D5C File Offset: 0x00007F5C
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000A5 RID: 165
			// (get) Token: 0x060003BC RID: 956 RVA: 0x00009D5F File Offset: 0x00007F5F
			// (set) Token: 0x060003BD RID: 957 RVA: 0x00009D68 File Offset: 0x00007F68
			public IEqualityComparer<T> KeyComparer
			{
				get
				{
					return this._equalityComparer;
				}
				set
				{
					Requires.NotNull<IEqualityComparer<T>>(value, "value");
					if (value != this._equalityComparer)
					{
						ImmutableHashSet<T>.MutationResult mutationResult = ImmutableHashSet<T>.Union(this, new ImmutableHashSet<T>.MutationInput(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode, value, this._hashBucketEqualityComparer, 0));
						this._immutable = null;
						this._equalityComparer = value;
						this.Root = mutationResult.Root;
						this._count = mutationResult.Count;
					}
				}
			}

			// Token: 0x170000A6 RID: 166
			// (get) Token: 0x060003BE RID: 958 RVA: 0x00009DCA File Offset: 0x00007FCA
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x170000A7 RID: 167
			// (get) Token: 0x060003BF RID: 959 RVA: 0x00009DD2 File Offset: 0x00007FD2
			[Nullable(0)]
			private ImmutableHashSet<T>.MutationInput Origin
			{
				get
				{
					return new ImmutableHashSet<T>.MutationInput(this.Root, this._equalityComparer, this._hashBucketEqualityComparer, this._count);
				}
			}

			// Token: 0x170000A8 RID: 168
			// (get) Token: 0x060003C0 RID: 960 RVA: 0x00009DF1 File Offset: 0x00007FF1
			// (set) Token: 0x060003C1 RID: 961 RVA: 0x00009DF9 File Offset: 0x00007FF9
			[Nullable(new byte[]
			{
				1,
				0,
				0
			})]
			private SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
				set
				{
					this._version++;
					if (this._root != value)
					{
						this._root = value;
						this._immutable = null;
					}
				}
			}

			// Token: 0x060003C2 RID: 962 RVA: 0x00009E20 File Offset: 0x00008020
			[NullableContext(0)]
			public ImmutableHashSet<T>.Enumerator GetEnumerator()
			{
				return new ImmutableHashSet<T>.Enumerator(this._root, this);
			}

			// Token: 0x060003C3 RID: 963 RVA: 0x00009E2E File Offset: 0x0000802E
			public ImmutableHashSet<T> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableHashSet<T>.Wrap(this._root, this._equalityComparer, this._count);
				}
				return this._immutable;
			}

			// Token: 0x060003C4 RID: 964 RVA: 0x00009E5C File Offset: 0x0000805C
			public bool TryGetValue(T equalValue, out T actualValue)
			{
				int key = (equalValue != null) ? this._equalityComparer.GetHashCode(equalValue) : 0;
				ImmutableHashSet<T>.HashBucket hashBucket;
				if (this._root.TryGetValue(key, out hashBucket))
				{
					return hashBucket.TryExchange(equalValue, this._equalityComparer, out actualValue);
				}
				actualValue = equalValue;
				return false;
			}

			// Token: 0x060003C5 RID: 965 RVA: 0x00009EAC File Offset: 0x000080AC
			public bool Add(T item)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Add(item, this.Origin);
				this.Apply(result);
				return result.Count != 0;
			}

			// Token: 0x060003C6 RID: 966 RVA: 0x00009ED8 File Offset: 0x000080D8
			public bool Remove(T item)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Remove(item, this.Origin);
				this.Apply(result);
				return result.Count != 0;
			}

			// Token: 0x060003C7 RID: 967 RVA: 0x00009F03 File Offset: 0x00008103
			public bool Contains(T item)
			{
				return ImmutableHashSet<T>.Contains(item, this.Origin);
			}

			// Token: 0x060003C8 RID: 968 RVA: 0x00009F11 File Offset: 0x00008111
			public void Clear()
			{
				this._count = 0;
				this.Root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;
			}

			// Token: 0x060003C9 RID: 969 RVA: 0x00009F28 File Offset: 0x00008128
			public void ExceptWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Except(other, this._equalityComparer, this._hashBucketEqualityComparer, this._root);
				this.Apply(result);
			}

			// Token: 0x060003CA RID: 970 RVA: 0x00009F58 File Offset: 0x00008158
			public void IntersectWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Intersect(other, this.Origin);
				this.Apply(result);
			}

			// Token: 0x060003CB RID: 971 RVA: 0x00009F79 File Offset: 0x00008179
			public bool IsProperSubsetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsProperSubsetOf(other, this.Origin);
			}

			// Token: 0x060003CC RID: 972 RVA: 0x00009F87 File Offset: 0x00008187
			public bool IsProperSupersetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsProperSupersetOf(other, this.Origin);
			}

			// Token: 0x060003CD RID: 973 RVA: 0x00009F95 File Offset: 0x00008195
			public bool IsSubsetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsSubsetOf(other, this.Origin);
			}

			// Token: 0x060003CE RID: 974 RVA: 0x00009FA3 File Offset: 0x000081A3
			public bool IsSupersetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsSupersetOf(other, this.Origin);
			}

			// Token: 0x060003CF RID: 975 RVA: 0x00009FB1 File Offset: 0x000081B1
			public bool Overlaps(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.Overlaps(other, this.Origin);
			}

			// Token: 0x060003D0 RID: 976 RVA: 0x00009FBF File Offset: 0x000081BF
			public bool SetEquals(IEnumerable<T> other)
			{
				return this == other || ImmutableHashSet<T>.SetEquals(other, this.Origin);
			}

			// Token: 0x060003D1 RID: 977 RVA: 0x00009FD4 File Offset: 0x000081D4
			public void SymmetricExceptWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.SymmetricExcept(other, this.Origin);
				this.Apply(result);
			}

			// Token: 0x060003D2 RID: 978 RVA: 0x00009FF8 File Offset: 0x000081F8
			public void UnionWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Union(other, this.Origin);
				this.Apply(result);
			}

			// Token: 0x060003D3 RID: 979 RVA: 0x0000A019 File Offset: 0x00008219
			void ICollection<!0>.Add(T item)
			{
				this.Add(item);
			}

			// Token: 0x060003D4 RID: 980 RVA: 0x0000A024 File Offset: 0x00008224
			void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				foreach (T t in this)
				{
					array[arrayIndex++] = t;
				}
			}

			// Token: 0x060003D5 RID: 981 RVA: 0x0000A0B0 File Offset: 0x000082B0
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003D6 RID: 982 RVA: 0x0000A0BD File Offset: 0x000082BD
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003D7 RID: 983 RVA: 0x0000A0CA File Offset: 0x000082CA
			private void Apply(ImmutableHashSet<T>.MutationResult result)
			{
				this.Root = result.Root;
				if (result.CountType == ImmutableHashSet<T>.CountType.Adjustment)
				{
					this._count += result.Count;
					return;
				}
				this._count = result.Count;
			}

			// Token: 0x0400005B RID: 91
			private SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;

			// Token: 0x0400005C RID: 92
			private IEqualityComparer<T> _equalityComparer;

			// Token: 0x0400005D RID: 93
			private readonly IEqualityComparer<ImmutableHashSet<T>.HashBucket> _hashBucketEqualityComparer;

			// Token: 0x0400005E RID: 94
			private int _count;

			// Token: 0x0400005F RID: 95
			private ImmutableHashSet<T> _immutable;

			// Token: 0x04000060 RID: 96
			private int _version;
		}

		// Token: 0x02000051 RID: 81
		[NullableContext(0)]
		public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator, IStrongEnumerator<T>
		{
			// Token: 0x060003D8 RID: 984 RVA: 0x0000A104 File Offset: 0x00008304
			internal Enumerator([Nullable(new byte[]
			{
				1,
				0,
				0
			})] SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, [Nullable(new byte[]
			{
				2,
				0
			})] ImmutableHashSet<T>.Builder builder = null)
			{
				this._builder = builder;
				this._mapEnumerator = new SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.Enumerator(root);
				this._bucketEnumerator = default(ImmutableHashSet<T>.HashBucket.Enumerator);
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
			}

			// Token: 0x170000A9 RID: 169
			// (get) Token: 0x060003D9 RID: 985 RVA: 0x0000A137 File Offset: 0x00008337
			[Nullable(1)]
			public T Current
			{
				[NullableContext(1)]
				get
				{
					this._mapEnumerator.ThrowIfDisposed();
					return this._bucketEnumerator.Current;
				}
			}

			// Token: 0x170000AA RID: 170
			// (get) Token: 0x060003DA RID: 986 RVA: 0x0000A14F File Offset: 0x0000834F
			[Nullable(2)]
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060003DB RID: 987 RVA: 0x0000A15C File Offset: 0x0000835C
			public bool MoveNext()
			{
				this.ThrowIfChanged();
				if (this._bucketEnumerator.MoveNext())
				{
					return true;
				}
				if (this._mapEnumerator.MoveNext())
				{
					KeyValuePair<int, ImmutableHashSet<T>.HashBucket> keyValuePair = this._mapEnumerator.Current;
					this._bucketEnumerator = new ImmutableHashSet<T>.HashBucket.Enumerator(keyValuePair.Value);
					return this._bucketEnumerator.MoveNext();
				}
				return false;
			}

			// Token: 0x060003DC RID: 988 RVA: 0x0000A1B6 File Offset: 0x000083B6
			public void Reset()
			{
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._mapEnumerator.Reset();
				this._bucketEnumerator.Dispose();
				this._bucketEnumerator = default(ImmutableHashSet<T>.HashBucket.Enumerator);
			}

			// Token: 0x060003DD RID: 989 RVA: 0x0000A1F6 File Offset: 0x000083F6
			public void Dispose()
			{
				this._mapEnumerator.Dispose();
				this._bucketEnumerator.Dispose();
			}

			// Token: 0x060003DE RID: 990 RVA: 0x0000A20E File Offset: 0x0000840E
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x04000061 RID: 97
			private readonly ImmutableHashSet<T>.Builder _builder;

			// Token: 0x04000062 RID: 98
			private SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.Enumerator _mapEnumerator;

			// Token: 0x04000063 RID: 99
			private ImmutableHashSet<T>.HashBucket.Enumerator _bucketEnumerator;

			// Token: 0x04000064 RID: 100
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x02000052 RID: 82
		[NullableContext(0)]
		internal enum OperationResult
		{
			// Token: 0x04000066 RID: 102
			SizeChanged,
			// Token: 0x04000067 RID: 103
			NoChangeRequired
		}

		// Token: 0x02000053 RID: 83
		[NullableContext(0)]
		internal readonly struct HashBucket
		{
			// Token: 0x060003DF RID: 991 RVA: 0x0000A236 File Offset: 0x00008436
			private HashBucket(T firstElement, ImmutableList<T>.Node additionalElements = null)
			{
				this._firstValue = firstElement;
				this._additionalElements = (additionalElements ?? ImmutableList<T>.Node.EmptyNode);
			}

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000A24F File Offset: 0x0000844F
			internal bool IsEmpty
			{
				get
				{
					return this._additionalElements == null;
				}
			}

			// Token: 0x060003E1 RID: 993 RVA: 0x0000A25A File Offset: 0x0000845A
			public ImmutableHashSet<T>.HashBucket.Enumerator GetEnumerator()
			{
				return new ImmutableHashSet<T>.HashBucket.Enumerator(this);
			}

			// Token: 0x060003E2 RID: 994 RVA: 0x0000A267 File Offset: 0x00008467
			[NullableContext(2)]
			public override bool Equals(object obj)
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003E3 RID: 995 RVA: 0x0000A26E File Offset: 0x0000846E
			public override int GetHashCode()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003E4 RID: 996 RVA: 0x0000A275 File Offset: 0x00008475
			internal bool EqualsByRef(ImmutableHashSet<T>.HashBucket other)
			{
				return this._firstValue == other._firstValue && this._additionalElements == other._additionalElements;
			}

			// Token: 0x060003E5 RID: 997 RVA: 0x0000A29F File Offset: 0x0000849F
			internal bool EqualsByValue(ImmutableHashSet<T>.HashBucket other, [Nullable(1)] IEqualityComparer<T> valueComparer)
			{
				return valueComparer.Equals(this._firstValue, other._firstValue) && this._additionalElements == other._additionalElements;
			}

			// Token: 0x060003E6 RID: 998 RVA: 0x0000A2C8 File Offset: 0x000084C8
			internal ImmutableHashSet<T>.HashBucket Add([Nullable(1)] T value, [Nullable(1)] IEqualityComparer<T> valueComparer, out ImmutableHashSet<T>.OperationResult result)
			{
				if (this.IsEmpty)
				{
					result = ImmutableHashSet<T>.OperationResult.SizeChanged;
					return new ImmutableHashSet<T>.HashBucket(value, null);
				}
				if (valueComparer.Equals(value, this._firstValue) || this._additionalElements.IndexOf(value, valueComparer) >= 0)
				{
					result = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
					return this;
				}
				result = ImmutableHashSet<T>.OperationResult.SizeChanged;
				return new ImmutableHashSet<T>.HashBucket(this._firstValue, this._additionalElements.Add(value));
			}

			// Token: 0x060003E7 RID: 999 RVA: 0x0000A32B File Offset: 0x0000852B
			[NullableContext(1)]
			internal bool Contains(T value, IEqualityComparer<T> valueComparer)
			{
				return !this.IsEmpty && (valueComparer.Equals(value, this._firstValue) || this._additionalElements.IndexOf(value, valueComparer) >= 0);
			}

			// Token: 0x060003E8 RID: 1000 RVA: 0x0000A35C File Offset: 0x0000855C
			[NullableContext(1)]
			internal unsafe bool TryExchange(T value, IEqualityComparer<T> valueComparer, out T existingValue)
			{
				if (!this.IsEmpty)
				{
					if (valueComparer.Equals(value, this._firstValue))
					{
						existingValue = this._firstValue;
						return true;
					}
					int num = this._additionalElements.IndexOf(value, valueComparer);
					if (num >= 0)
					{
						existingValue = *this._additionalElements.ItemRef(num);
						return true;
					}
				}
				existingValue = value;
				return false;
			}

			// Token: 0x060003E9 RID: 1001 RVA: 0x0000A3C4 File Offset: 0x000085C4
			internal ImmutableHashSet<T>.HashBucket Remove([Nullable(1)] T value, [Nullable(1)] IEqualityComparer<T> equalityComparer, out ImmutableHashSet<T>.OperationResult result)
			{
				if (this.IsEmpty)
				{
					result = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
					return this;
				}
				if (equalityComparer.Equals(this._firstValue, value))
				{
					if (this._additionalElements.IsEmpty)
					{
						result = ImmutableHashSet<T>.OperationResult.SizeChanged;
						return default(ImmutableHashSet<T>.HashBucket);
					}
					int count = this._additionalElements.Left.Count;
					result = ImmutableHashSet<T>.OperationResult.SizeChanged;
					return new ImmutableHashSet<T>.HashBucket(this._additionalElements.Key, this._additionalElements.RemoveAt(count));
				}
				else
				{
					int num = this._additionalElements.IndexOf(value, equalityComparer);
					if (num < 0)
					{
						result = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
						return this;
					}
					result = ImmutableHashSet<T>.OperationResult.SizeChanged;
					return new ImmutableHashSet<T>.HashBucket(this._firstValue, this._additionalElements.RemoveAt(num));
				}
			}

			// Token: 0x060003EA RID: 1002 RVA: 0x0000A473 File Offset: 0x00008673
			internal void Freeze()
			{
				if (this._additionalElements != null)
				{
					this._additionalElements.Freeze();
				}
			}

			// Token: 0x04000068 RID: 104
			private readonly T _firstValue;

			// Token: 0x04000069 RID: 105
			private readonly ImmutableList<T>.Node _additionalElements;

			// Token: 0x0200007D RID: 125
			internal struct Enumerator : IEnumerator<!0>, IDisposable, IEnumerator
			{
				// Token: 0x06000650 RID: 1616 RVA: 0x00010F87 File Offset: 0x0000F187
				internal Enumerator(ImmutableHashSet<T>.HashBucket bucket)
				{
					this._disposed = false;
					this._bucket = bucket;
					this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.BeforeFirst;
					this._additionalEnumerator = default(ImmutableList<T>.Enumerator);
				}

				// Token: 0x1700014B RID: 331
				// (get) Token: 0x06000651 RID: 1617 RVA: 0x00010FAA File Offset: 0x0000F1AA
				[Nullable(2)]
				object IEnumerator.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x1700014C RID: 332
				// (get) Token: 0x06000652 RID: 1618 RVA: 0x00010FB8 File Offset: 0x0000F1B8
				[Nullable(1)]
				public T Current
				{
					[NullableContext(1)]
					get
					{
						this.ThrowIfDisposed();
						ImmutableHashSet<T>.HashBucket.Enumerator.Position currentPosition = this._currentPosition;
						T result;
						if (currentPosition != ImmutableHashSet<T>.HashBucket.Enumerator.Position.First)
						{
							if (currentPosition != ImmutableHashSet<T>.HashBucket.Enumerator.Position.Additional)
							{
								throw new InvalidOperationException();
							}
							result = this._additionalEnumerator.Current;
						}
						else
						{
							result = this._bucket._firstValue;
						}
						return result;
					}
				}

				// Token: 0x06000653 RID: 1619 RVA: 0x00011000 File Offset: 0x0000F200
				public bool MoveNext()
				{
					this.ThrowIfDisposed();
					if (this._bucket.IsEmpty)
					{
						this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.End;
						return false;
					}
					switch (this._currentPosition)
					{
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.BeforeFirst:
						this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.First;
						return true;
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.First:
						if (this._bucket._additionalElements.IsEmpty)
						{
							this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.End;
							return false;
						}
						this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.Additional;
						this._additionalEnumerator = new ImmutableList<T>.Enumerator(this._bucket._additionalElements, null, -1, -1, false);
						return this._additionalEnumerator.MoveNext();
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.Additional:
						return this._additionalEnumerator.MoveNext();
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.End:
						return false;
					default:
						throw new InvalidOperationException();
					}
				}

				// Token: 0x06000654 RID: 1620 RVA: 0x000110AC File Offset: 0x0000F2AC
				public void Reset()
				{
					this.ThrowIfDisposed();
					this._additionalEnumerator.Dispose();
					this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.BeforeFirst;
				}

				// Token: 0x06000655 RID: 1621 RVA: 0x000110C6 File Offset: 0x0000F2C6
				public void Dispose()
				{
					this._disposed = true;
					this._additionalEnumerator.Dispose();
				}

				// Token: 0x06000656 RID: 1622 RVA: 0x000110DA File Offset: 0x0000F2DA
				private void ThrowIfDisposed()
				{
					if (this._disposed)
					{
						Requires.FailObjectDisposed<ImmutableHashSet<T>.HashBucket.Enumerator>(this);
					}
				}

				// Token: 0x04000107 RID: 263
				private readonly ImmutableHashSet<T>.HashBucket _bucket;

				// Token: 0x04000108 RID: 264
				private bool _disposed;

				// Token: 0x04000109 RID: 265
				private ImmutableHashSet<T>.HashBucket.Enumerator.Position _currentPosition;

				// Token: 0x0400010A RID: 266
				private ImmutableList<T>.Enumerator _additionalEnumerator;

				// Token: 0x02000083 RID: 131
				private enum Position
				{
					// Token: 0x04000120 RID: 288
					BeforeFirst,
					// Token: 0x04000121 RID: 289
					First,
					// Token: 0x04000122 RID: 290
					Additional,
					// Token: 0x04000123 RID: 291
					End
				}
			}
		}

		// Token: 0x02000054 RID: 84
		private readonly struct MutationInput
		{
			// Token: 0x060003EB RID: 1003 RVA: 0x0000A488 File Offset: 0x00008688
			internal MutationInput(ImmutableHashSet<T> set)
			{
				Requires.NotNull<ImmutableHashSet<T>>(set, "set");
				this._root = set._root;
				this._equalityComparer = set._equalityComparer;
				this._count = set._count;
				this._hashBucketEqualityComparer = set._hashBucketEqualityComparer;
			}

			// Token: 0x060003EC RID: 1004 RVA: 0x0000A4C8 File Offset: 0x000086C8
			internal MutationInput(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, IEqualityComparer<T> equalityComparer, IEqualityComparer<ImmutableHashSet<T>.HashBucket> hashBucketEqualityComparer, int count)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
				Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
				Requires.Range(count >= 0, "count", null);
				Requires.NotNull<IEqualityComparer<ImmutableHashSet<T>.HashBucket>>(hashBucketEqualityComparer, "hashBucketEqualityComparer");
				this._root = root;
				this._equalityComparer = equalityComparer;
				this._count = count;
				this._hashBucketEqualityComparer = hashBucketEqualityComparer;
			}

			// Token: 0x170000AC RID: 172
			// (get) Token: 0x060003ED RID: 1005 RVA: 0x0000A526 File Offset: 0x00008726
			internal SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170000AD RID: 173
			// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000A52E File Offset: 0x0000872E
			internal IEqualityComparer<T> EqualityComparer
			{
				get
				{
					return this._equalityComparer;
				}
			}

			// Token: 0x170000AE RID: 174
			// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000A536 File Offset: 0x00008736
			internal int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000AF RID: 175
			// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0000A53E File Offset: 0x0000873E
			internal IEqualityComparer<ImmutableHashSet<T>.HashBucket> HashBucketEqualityComparer
			{
				get
				{
					return this._hashBucketEqualityComparer;
				}
			}

			// Token: 0x0400006A RID: 106
			private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;

			// Token: 0x0400006B RID: 107
			private readonly IEqualityComparer<T> _equalityComparer;

			// Token: 0x0400006C RID: 108
			private readonly int _count;

			// Token: 0x0400006D RID: 109
			private readonly IEqualityComparer<ImmutableHashSet<T>.HashBucket> _hashBucketEqualityComparer;
		}

		// Token: 0x02000055 RID: 85
		private enum CountType
		{
			// Token: 0x0400006F RID: 111
			Adjustment,
			// Token: 0x04000070 RID: 112
			FinalValue
		}

		// Token: 0x02000056 RID: 86
		private readonly struct MutationResult
		{
			// Token: 0x060003F1 RID: 1009 RVA: 0x0000A546 File Offset: 0x00008746
			internal MutationResult(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, int count, ImmutableHashSet<T>.CountType countType = ImmutableHashSet<T>.CountType.Adjustment)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
				this._root = root;
				this._count = count;
				this._countType = countType;
			}

			// Token: 0x170000B0 RID: 176
			// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000A568 File Offset: 0x00008768
			internal SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170000B1 RID: 177
			// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000A570 File Offset: 0x00008770
			internal int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000B2 RID: 178
			// (get) Token: 0x060003F4 RID: 1012 RVA: 0x0000A578 File Offset: 0x00008778
			internal ImmutableHashSet<T>.CountType CountType
			{
				get
				{
					return this._countType;
				}
			}

			// Token: 0x060003F5 RID: 1013 RVA: 0x0000A580 File Offset: 0x00008780
			internal ImmutableHashSet<T> Finalize(ImmutableHashSet<T> priorSet)
			{
				Requires.NotNull<ImmutableHashSet<T>>(priorSet, "priorSet");
				int num = this.Count;
				if (this.CountType == ImmutableHashSet<T>.CountType.Adjustment)
				{
					num += priorSet._count;
				}
				return priorSet.Wrap(this.Root, num);
			}

			// Token: 0x04000071 RID: 113
			private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;

			// Token: 0x04000072 RID: 114
			private readonly int _count;

			// Token: 0x04000073 RID: 115
			private readonly ImmutableHashSet<T>.CountType _countType;
		}

		// Token: 0x02000057 RID: 87
		private readonly struct NodeEnumerable : IEnumerable<!0>, IEnumerable
		{
			// Token: 0x060003F6 RID: 1014 RVA: 0x0000A5BD File Offset: 0x000087BD
			internal NodeEnumerable(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
				this._root = root;
			}

			// Token: 0x060003F7 RID: 1015 RVA: 0x0000A5D1 File Offset: 0x000087D1
			public ImmutableHashSet<T>.Enumerator GetEnumerator()
			{
				return new ImmutableHashSet<T>.Enumerator(this._root, null);
			}

			// Token: 0x060003F8 RID: 1016 RVA: 0x0000A5DF File Offset: 0x000087DF
			[ExcludeFromCodeCoverage]
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003F9 RID: 1017 RVA: 0x0000A5EC File Offset: 0x000087EC
			[ExcludeFromCodeCoverage]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x04000074 RID: 116
			private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;
		}
	}
}
