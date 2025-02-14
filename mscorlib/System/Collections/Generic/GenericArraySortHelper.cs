﻿using System;
using System.Runtime.Versioning;

namespace System.Collections.Generic
{
	// Token: 0x020004DF RID: 1247
	[Serializable]
	internal class GenericArraySortHelper<T> : IArraySortHelper<T> where T : IComparable<T>
	{
		// Token: 0x06003B42 RID: 15170 RVA: 0x000E1020 File Offset: 0x000DF220
		public void Sort(T[] keys, int index, int length, IComparer<T> comparer)
		{
			try
			{
				if (comparer == null || comparer == Comparer<T>.Default)
				{
					if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
					{
						GenericArraySortHelper<T>.IntrospectiveSort(keys, index, length);
					}
					else
					{
						GenericArraySortHelper<T>.DepthLimitedQuickSort(keys, index, length + index - 1, 32);
					}
				}
				else if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
				{
					ArraySortHelper<T>.IntrospectiveSort(keys, index, length, comparer);
				}
				else
				{
					ArraySortHelper<T>.DepthLimitedQuickSort(keys, index, length + index - 1, comparer, 32);
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

		// Token: 0x06003B43 RID: 15171 RVA: 0x000E10B8 File Offset: 0x000DF2B8
		public int BinarySearch(T[] array, int index, int length, T value, IComparer<T> comparer)
		{
			int result;
			try
			{
				if (comparer == null || comparer == Comparer<T>.Default)
				{
					result = GenericArraySortHelper<T>.BinarySearch(array, index, length, value);
				}
				else
				{
					result = ArraySortHelper<T>.InternalBinarySearch(array, index, length, value, comparer);
				}
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), innerException);
			}
			return result;
		}

		// Token: 0x06003B44 RID: 15172 RVA: 0x000E1114 File Offset: 0x000DF314
		private static int BinarySearch(T[] array, int index, int length, T value)
		{
			int i = index;
			int num = index + length - 1;
			while (i <= num)
			{
				int num2 = i + (num - i >> 1);
				int num3;
				if (array[num2] == null)
				{
					num3 = ((value == null) ? 0 : -1);
				}
				else
				{
					num3 = array[num2].CompareTo(value);
				}
				if (num3 == 0)
				{
					return num2;
				}
				if (num3 < 0)
				{
					i = num2 + 1;
				}
				else
				{
					num = num2 - 1;
				}
			}
			return ~i;
		}

		// Token: 0x06003B45 RID: 15173 RVA: 0x000E1180 File Offset: 0x000DF380
		private static void SwapIfGreaterWithItems(T[] keys, int a, int b)
		{
			if (a != b && keys[a] != null && keys[a].CompareTo(keys[b]) > 0)
			{
				T t = keys[a];
				keys[a] = keys[b];
				keys[b] = t;
			}
		}

		// Token: 0x06003B46 RID: 15174 RVA: 0x000E11DC File Offset: 0x000DF3DC
		private static void Swap(T[] a, int i, int j)
		{
			if (i != j)
			{
				T t = a[i];
				a[i] = a[j];
				a[j] = t;
			}
		}

		// Token: 0x06003B47 RID: 15175 RVA: 0x000E120C File Offset: 0x000DF40C
		private static void DepthLimitedQuickSort(T[] keys, int left, int right, int depthLimit)
		{
			while (depthLimit != 0)
			{
				int num = left;
				int num2 = right;
				int num3 = num + (num2 - num >> 1);
				GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, num, num3);
				GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, num, num2);
				GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, num3, num2);
				T t = keys[num3];
				do
				{
					if (t == null)
					{
						while (keys[num2] != null)
						{
							num2--;
						}
					}
					else
					{
						while (t.CompareTo(keys[num]) > 0)
						{
							num++;
						}
						while (t.CompareTo(keys[num2]) < 0)
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
						T t2 = keys[num];
						keys[num] = keys[num2];
						keys[num2] = t2;
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
						GenericArraySortHelper<T>.DepthLimitedQuickSort(keys, left, num2, depthLimit);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						GenericArraySortHelper<T>.DepthLimitedQuickSort(keys, num, right, depthLimit);
					}
					right = num2;
				}
				if (left >= right)
				{
					return;
				}
			}
			GenericArraySortHelper<T>.Heapsort(keys, left, right);
		}

		// Token: 0x06003B48 RID: 15176 RVA: 0x000E1314 File Offset: 0x000DF514
		internal static void IntrospectiveSort(T[] keys, int left, int length)
		{
			if (length < 2)
			{
				return;
			}
			GenericArraySortHelper<T>.IntroSort(keys, left, length + left - 1, 2 * IntrospectiveSortUtilities.FloorLog2(keys.Length));
		}

		// Token: 0x06003B49 RID: 15177 RVA: 0x000E1334 File Offset: 0x000DF534
		private static void IntroSort(T[] keys, int lo, int hi, int depthLimit)
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
						GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, lo, hi);
						return;
					}
					if (num == 3)
					{
						GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, lo, hi - 1);
						GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, lo, hi);
						GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, hi - 1, hi);
						return;
					}
					GenericArraySortHelper<T>.InsertionSort(keys, lo, hi);
					return;
				}
				else
				{
					if (depthLimit == 0)
					{
						GenericArraySortHelper<T>.Heapsort(keys, lo, hi);
						return;
					}
					depthLimit--;
					int num2 = GenericArraySortHelper<T>.PickPivotAndPartition(keys, lo, hi);
					GenericArraySortHelper<T>.IntroSort(keys, num2 + 1, hi, depthLimit);
					hi = num2 - 1;
				}
			}
		}

		// Token: 0x06003B4A RID: 15178 RVA: 0x000E13B8 File Offset: 0x000DF5B8
		private static int PickPivotAndPartition(T[] keys, int lo, int hi)
		{
			int num = lo + (hi - lo) / 2;
			GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, lo, num);
			GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, lo, hi);
			GenericArraySortHelper<T>.SwapIfGreaterWithItems(keys, num, hi);
			T t = keys[num];
			GenericArraySortHelper<T>.Swap(keys, num, hi - 1);
			int i = lo;
			int j = hi - 1;
			while (i < j)
			{
				if (t == null)
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
					while (t.CompareTo(keys[++i]) > 0)
					{
					}
					while (t.CompareTo(keys[--j]) < 0)
					{
					}
				}
				if (i >= j)
				{
					break;
				}
				GenericArraySortHelper<T>.Swap(keys, i, j);
			}
			GenericArraySortHelper<T>.Swap(keys, i, hi - 1);
			return i;
		}

		// Token: 0x06003B4B RID: 15179 RVA: 0x000E1488 File Offset: 0x000DF688
		private static void Heapsort(T[] keys, int lo, int hi)
		{
			int num = hi - lo + 1;
			for (int i = num / 2; i >= 1; i--)
			{
				GenericArraySortHelper<T>.DownHeap(keys, i, num, lo);
			}
			for (int j = num; j > 1; j--)
			{
				GenericArraySortHelper<T>.Swap(keys, lo, lo + j - 1);
				GenericArraySortHelper<T>.DownHeap(keys, 1, j - 1, lo);
			}
		}

		// Token: 0x06003B4C RID: 15180 RVA: 0x000E14D8 File Offset: 0x000DF6D8
		private static void DownHeap(T[] keys, int i, int n, int lo)
		{
			T t = keys[lo + i - 1];
			while (i <= n / 2)
			{
				int num = 2 * i;
				if (num < n && (keys[lo + num - 1] == null || keys[lo + num - 1].CompareTo(keys[lo + num]) < 0))
				{
					num++;
				}
				if (keys[lo + num - 1] == null || keys[lo + num - 1].CompareTo(t) < 0)
				{
					break;
				}
				keys[lo + i - 1] = keys[lo + num - 1];
				i = num;
			}
			keys[lo + i - 1] = t;
		}

		// Token: 0x06003B4D RID: 15181 RVA: 0x000E1594 File Offset: 0x000DF794
		private static void InsertionSort(T[] keys, int lo, int hi)
		{
			for (int i = lo; i < hi; i++)
			{
				int num = i;
				T t = keys[i + 1];
				while (num >= lo && (t == null || t.CompareTo(keys[num]) < 0))
				{
					keys[num + 1] = keys[num];
					num--;
				}
				keys[num + 1] = t;
			}
		}
	}
}
