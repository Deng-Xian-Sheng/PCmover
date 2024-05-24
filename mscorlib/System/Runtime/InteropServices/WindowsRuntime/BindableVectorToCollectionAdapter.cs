using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009DC RID: 2524
	internal sealed class BindableVectorToCollectionAdapter
	{
		// Token: 0x06006453 RID: 25683 RVA: 0x00156114 File Offset: 0x00154314
		private BindableVectorToCollectionAdapter()
		{
		}

		// Token: 0x06006454 RID: 25684 RVA: 0x0015611C File Offset: 0x0015431C
		[SecurityCritical]
		internal int Count()
		{
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			uint size = bindableVector.Size;
			if (2147483647U < size)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			return (int)size;
		}

		// Token: 0x06006455 RID: 25685 RVA: 0x00156150 File Offset: 0x00154350
		[SecurityCritical]
		internal bool IsSynchronized()
		{
			return false;
		}

		// Token: 0x06006456 RID: 25686 RVA: 0x00156153 File Offset: 0x00154353
		[SecurityCritical]
		internal object SyncRoot()
		{
			return this;
		}

		// Token: 0x06006457 RID: 25687 RVA: 0x00156158 File Offset: 0x00154358
		[SecurityCritical]
		internal void CopyTo(Array array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			int lowerBound = array.GetLowerBound(0);
			int num = this.Count();
			int length = array.GetLength(0);
			if (arrayIndex < lowerBound)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (num > length - (arrayIndex - lowerBound))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InsufficientSpaceToCopyCollection"));
			}
			if (arrayIndex - lowerBound > length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IndexOutOfArrayBounds"));
			}
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)num))
			{
				array.SetValue(bindableVector.GetAt(num2), (long)((ulong)num2 + (ulong)((long)arrayIndex)));
				num2 += 1U;
			}
		}
	}
}
