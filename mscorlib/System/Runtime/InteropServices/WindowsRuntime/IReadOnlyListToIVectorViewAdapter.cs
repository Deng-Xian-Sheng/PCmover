using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009EB RID: 2539
	[DebuggerDisplay("Size = {Size}")]
	internal sealed class IReadOnlyListToIVectorViewAdapter
	{
		// Token: 0x060064A3 RID: 25763 RVA: 0x00156E35 File Offset: 0x00155035
		private IReadOnlyListToIVectorViewAdapter()
		{
		}

		// Token: 0x060064A4 RID: 25764 RVA: 0x00156E40 File Offset: 0x00155040
		[SecurityCritical]
		internal T GetAt<T>(uint index)
		{
			IReadOnlyList<T> readOnlyList = JitHelpers.UnsafeCast<IReadOnlyList<T>>(this);
			IReadOnlyListToIVectorViewAdapter.EnsureIndexInt32(index, readOnlyList.Count);
			T result;
			try
			{
				result = readOnlyList[(int)index];
			}
			catch (ArgumentOutOfRangeException ex)
			{
				ex.SetErrorCode(-2147483637);
				throw;
			}
			return result;
		}

		// Token: 0x060064A5 RID: 25765 RVA: 0x00156E8C File Offset: 0x0015508C
		[SecurityCritical]
		internal uint Size<T>()
		{
			IReadOnlyList<T> readOnlyList = JitHelpers.UnsafeCast<IReadOnlyList<T>>(this);
			return (uint)readOnlyList.Count;
		}

		// Token: 0x060064A6 RID: 25766 RVA: 0x00156EA8 File Offset: 0x001550A8
		[SecurityCritical]
		internal bool IndexOf<T>(T value, out uint index)
		{
			IReadOnlyList<T> readOnlyList = JitHelpers.UnsafeCast<IReadOnlyList<T>>(this);
			int num = -1;
			int count = readOnlyList.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(value, readOnlyList[i]))
				{
					num = i;
					break;
				}
			}
			if (-1 == num)
			{
				index = 0U;
				return false;
			}
			index = (uint)num;
			return true;
		}

		// Token: 0x060064A7 RID: 25767 RVA: 0x00156EF8 File Offset: 0x001550F8
		[SecurityCritical]
		internal uint GetMany<T>(uint startIndex, T[] items)
		{
			IReadOnlyList<T> readOnlyList = JitHelpers.UnsafeCast<IReadOnlyList<T>>(this);
			if ((ulong)startIndex == (ulong)((long)readOnlyList.Count))
			{
				return 0U;
			}
			IReadOnlyListToIVectorViewAdapter.EnsureIndexInt32(startIndex, readOnlyList.Count);
			if (items == null)
			{
				return 0U;
			}
			uint num = Math.Min((uint)items.Length, (uint)(readOnlyList.Count - (int)startIndex));
			for (uint num2 = 0U; num2 < num; num2 += 1U)
			{
				items[(int)num2] = readOnlyList[(int)(num2 + startIndex)];
			}
			if (typeof(T) == typeof(string))
			{
				string[] array = items as string[];
				uint num3 = num;
				while ((ulong)num3 < (ulong)((long)items.Length))
				{
					array[(int)num3] = string.Empty;
					num3 += 1U;
				}
			}
			return num;
		}

		// Token: 0x060064A8 RID: 25768 RVA: 0x00156F98 File Offset: 0x00155198
		private static void EnsureIndexInt32(uint index, int listCapacity)
		{
			if (2147483647U <= index || index >= (uint)listCapacity)
			{
				Exception ex = new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_IndexLargerThanMaxValue"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
		}
	}
}
