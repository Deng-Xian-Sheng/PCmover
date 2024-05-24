using System;
using System.Runtime.Versioning;

namespace System.Collections.Generic
{
	// Token: 0x020004E2 RID: 1250
	internal class GenericArraySortHelper<TKey, TValue> : IArraySortHelper<TKey, TValue> where TKey : IComparable<TKey>
	{
		// Token: 0x06003B5D RID: 15197 RVA: 0x000E1C38 File Offset: 0x000DFE38
		public void Sort(TKey[] keys, TValue[] values, int index, int length, IComparer<TKey> comparer)
		{
			try
			{
				if (comparer == null || comparer == Comparer<TKey>.Default)
				{
					if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
					{
						GenericArraySortHelper<TKey, TValue>.IntrospectiveSort(keys, values, index, length);
					}
					else
					{
						GenericArraySortHelper<TKey, TValue>.DepthLimitedQuickSort(keys, values, index, length + index - 1, 32);
					}
				}
				else if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
				{
					ArraySortHelper<TKey, TValue>.IntrospectiveSort(keys, values, index, length, comparer);
				}
				else
				{
					ArraySortHelper<TKey, TValue>.DepthLimitedQuickSort(keys, values, index, length + index - 1, comparer, 32);
				}
			}
			catch (IndexOutOfRangeException)
			{
				IntrospectiveSortUtilities.ThrowOrIgnoreBadComparer(comparer);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), innerException);
			}
		}

		// Token: 0x06003B5E RID: 15198 RVA: 0x000E1CD8 File Offset: 0x000DFED8
		private static void SwapIfGreaterWithItems(TKey[] keys, TValue[] values, int a, int b)
		{
			if (a != b && keys[a] != null && keys[a].CompareTo(keys[b]) > 0)
			{
				TKey tkey = keys[a];
				keys[a] = keys[b];
				keys[b] = tkey;
				if (values != null)
				{
					TValue tvalue = values[a];
					values[a] = values[b];
					values[b] = tvalue;
				}
			}
		}

		// Token: 0x06003B5F RID: 15199 RVA: 0x000E1D54 File Offset: 0x000DFF54
		private static void Swap(TKey[] keys, TValue[] values, int i, int j)
		{
			if (i != j)
			{
				TKey tkey = keys[i];
				keys[i] = keys[j];
				keys[j] = tkey;
				if (values != null)
				{
					TValue tvalue = values[i];
					values[i] = values[j];
					values[j] = tvalue;
				}
			}
		}

		// Token: 0x06003B60 RID: 15200 RVA: 0x000E1DA4 File Offset: 0x000DFFA4
		private static void DepthLimitedQuickSort(TKey[] keys, TValue[] values, int left, int right, int depthLimit)
		{
			while (depthLimit != 0)
			{
				int num = left;
				int num2 = right;
				int num3 = num + (num2 - num >> 1);
				GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, num, num3);
				GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, num, num2);
				GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, num3, num2);
				TKey tkey = keys[num3];
				do
				{
					if (tkey == null)
					{
						while (keys[num2] != null)
						{
							num2--;
						}
					}
					else
					{
						while (tkey.CompareTo(keys[num]) > 0)
						{
							num++;
						}
						while (tkey.CompareTo(keys[num2]) < 0)
						{
							num2--;
						}
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						TKey tkey2 = keys[num];
						keys[num] = keys[num2];
						keys[num2] = tkey2;
						if (values != null)
						{
							TValue tvalue = values[num];
							values[num] = values[num2];
							values[num2] = tvalue;
						}
					}
					num++;
					num2--;
				}
				while (num <= num2);
				depthLimit--;
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						GenericArraySortHelper<TKey, TValue>.DepthLimitedQuickSort(keys, values, left, num2, depthLimit);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						GenericArraySortHelper<TKey, TValue>.DepthLimitedQuickSort(keys, values, num, right, depthLimit);
					}
					right = num2;
				}
				if (left >= right)
				{
					return;
				}
			}
			GenericArraySortHelper<TKey, TValue>.Heapsort(keys, values, left, right);
		}

		// Token: 0x06003B61 RID: 15201 RVA: 0x000E1ED9 File Offset: 0x000E00D9
		internal static void IntrospectiveSort(TKey[] keys, TValue[] values, int left, int length)
		{
			if (length < 2)
			{
				return;
			}
			GenericArraySortHelper<TKey, TValue>.IntroSort(keys, values, left, length + left - 1, 2 * IntrospectiveSortUtilities.FloorLog2(keys.Length));
		}

		// Token: 0x06003B62 RID: 15202 RVA: 0x000E1EF8 File Offset: 0x000E00F8
		private static void IntroSort(TKey[] keys, TValue[] values, int lo, int hi, int depthLimit)
		{
			while (hi > lo)
			{
				int num = hi - lo + 1;
				if (num <= 16)
				{
					if (num == 1)
					{
						return;
					}
					if (num == 2)
					{
						GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, lo, hi);
						return;
					}
					if (num == 3)
					{
						GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, lo, hi - 1);
						GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, lo, hi);
						GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, hi - 1, hi);
						return;
					}
					GenericArraySortHelper<TKey, TValue>.InsertionSort(keys, values, lo, hi);
					return;
				}
				else
				{
					if (depthLimit == 0)
					{
						GenericArraySortHelper<TKey, TValue>.Heapsort(keys, values, lo, hi);
						return;
					}
					depthLimit--;
					int num2 = GenericArraySortHelper<TKey, TValue>.PickPivotAndPartition(keys, values, lo, hi);
					GenericArraySortHelper<TKey, TValue>.IntroSort(keys, values, num2 + 1, hi, depthLimit);
					hi = num2 - 1;
				}
			}
		}

		// Token: 0x06003B63 RID: 15203 RVA: 0x000E1F88 File Offset: 0x000E0188
		private static int PickPivotAndPartition(TKey[] keys, TValue[] values, int lo, int hi)
		{
			int num = lo + (hi - lo) / 2;
			GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, lo, num);
			GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, lo, hi);
			GenericArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, num, hi);
			TKey tkey = keys[num];
			GenericArraySortHelper<TKey, TValue>.Swap(keys, values, num, hi - 1);
			int i = lo;
			int j = hi - 1;
			while (i < j)
			{
				if (tkey == null)
				{
					while (i < hi - 1 && keys[++i] == null)
					{
					}
					while (j > lo)
					{
						if (keys[--j] == null)
						{
							break;
						}
					}
				}
				else
				{
					while (tkey.CompareTo(keys[++i]) > 0)
					{
					}
					while (tkey.CompareTo(keys[--j]) < 0)
					{
					}
				}
				if (i >= j)
				{
					break;
				}
				GenericArraySortHelper<TKey, TValue>.Swap(keys, values, i, j);
			}
			GenericArraySortHelper<TKey, TValue>.Swap(keys, values, i, hi - 1);
			return i;
		}

		// Token: 0x06003B64 RID: 15204 RVA: 0x000E2060 File Offset: 0x000E0260
		private static void Heapsort(TKey[] keys, TValue[] values, int lo, int hi)
		{
			int num = hi - lo + 1;
			for (int i = num / 2; i >= 1; i--)
			{
				GenericArraySortHelper<TKey, TValue>.DownHeap(keys, values, i, num, lo);
			}
			for (int j = num; j > 1; j--)
			{
				GenericArraySortHelper<TKey, TValue>.Swap(keys, values, lo, lo + j - 1);
				GenericArraySortHelper<TKey, TValue>.DownHeap(keys, values, 1, j - 1, lo);
			}
		}

		// Token: 0x06003B65 RID: 15205 RVA: 0x000E20B0 File Offset: 0x000E02B0
		private static void DownHeap(TKey[] keys, TValue[] values, int i, int n, int lo)
		{
			TKey tkey = keys[lo + i - 1];
			TValue tvalue = (values != null) ? values[lo + i - 1] : default(TValue);
			while (i <= n / 2)
			{
				int num = 2 * i;
				if (num < n && (keys[lo + num - 1] == null || keys[lo + num - 1].CompareTo(keys[lo + num]) < 0))
				{
					num++;
				}
				if (keys[lo + num - 1] == null || keys[lo + num - 1].CompareTo(tkey) < 0)
				{
					break;
				}
				keys[lo + i - 1] = keys[lo + num - 1];
				if (values != null)
				{
					values[lo + i - 1] = values[lo + num - 1];
				}
				i = num;
			}
			keys[lo + i - 1] = tkey;
			if (values != null)
			{
				values[lo + i - 1] = tvalue;
			}
		}

		// Token: 0x06003B66 RID: 15206 RVA: 0x000E21BC File Offset: 0x000E03BC
		private static void InsertionSort(TKey[] keys, TValue[] values, int lo, int hi)
		{
			for (int i = lo; i < hi; i++)
			{
				int num = i;
				TKey tkey = keys[i + 1];
				TValue tvalue = (values != null) ? values[i + 1] : default(TValue);
				while (num >= lo && (tkey == null || tkey.CompareTo(keys[num]) < 0))
				{
					keys[num + 1] = keys[num];
					if (values != null)
					{
						values[num + 1] = values[num];
					}
					num--;
				}
				keys[num + 1] = tkey;
				if (values != null)
				{
					values[num + 1] = tvalue;
				}
			}
		}
	}
}
