using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x0200059E RID: 1438
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class MngdHiddenLengthArrayMarshaler
	{
		// Token: 0x060042F8 RID: 17144
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void CreateMarshaler(IntPtr pMarshalState, IntPtr pMT, IntPtr cbElementSize, ushort vt);

		// Token: 0x060042F9 RID: 17145
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertSpaceToNative(IntPtr pMarshalState, ref object pManagedHome, IntPtr pNativeHome);

		// Token: 0x060042FA RID: 17146
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertContentsToNative(IntPtr pMarshalState, ref object pManagedHome, IntPtr pNativeHome);

		// Token: 0x060042FB RID: 17147 RVA: 0x000F9818 File Offset: 0x000F7A18
		[SecurityCritical]
		internal unsafe static void ConvertContentsToNative_DateTime(ref DateTimeOffset[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				DateTimeNative* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					DateTimeOffsetMarshaler.ConvertToNative(ref managedArray[i], out ptr[i]);
				}
			}
		}

		// Token: 0x060042FC RID: 17148 RVA: 0x000F9858 File Offset: 0x000F7A58
		[SecurityCritical]
		internal unsafe static void ConvertContentsToNative_Type(ref Type[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				TypeNameNative* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					SystemTypeMarshaler.ConvertToNative(managedArray[i], ptr + i);
				}
			}
		}

		// Token: 0x060042FD RID: 17149 RVA: 0x000F9898 File Offset: 0x000F7A98
		[SecurityCritical]
		internal unsafe static void ConvertContentsToNative_Exception(ref Exception[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				int* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					ptr[i] = HResultExceptionMarshaler.ConvertToNative(managedArray[i]);
				}
			}
		}

		// Token: 0x060042FE RID: 17150 RVA: 0x000F98D0 File Offset: 0x000F7AD0
		[SecurityCritical]
		internal unsafe static void ConvertContentsToNative_Nullable<T>(ref T?[] managedArray, IntPtr pNativeHome) where T : struct
		{
			if (managedArray != null)
			{
				IntPtr* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					ptr[i] = NullableMarshaler.ConvertToNative<T>(ref managedArray[i]);
				}
			}
		}

		// Token: 0x060042FF RID: 17151 RVA: 0x000F9914 File Offset: 0x000F7B14
		[SecurityCritical]
		internal unsafe static void ConvertContentsToNative_KeyValuePair<K, V>(ref KeyValuePair<K, V>[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				IntPtr* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					ptr[i] = KeyValuePairMarshaler.ConvertToNative<K, V>(ref managedArray[i]);
				}
			}
		}

		// Token: 0x06004300 RID: 17152
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertSpaceToManaged(IntPtr pMarshalState, ref object pManagedHome, IntPtr pNativeHome, int elementCount);

		// Token: 0x06004301 RID: 17153
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertContentsToManaged(IntPtr pMarshalState, ref object pManagedHome, IntPtr pNativeHome);

		// Token: 0x06004302 RID: 17154 RVA: 0x000F9958 File Offset: 0x000F7B58
		[SecurityCritical]
		internal unsafe static void ConvertContentsToManaged_DateTime(ref DateTimeOffset[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				DateTimeNative* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					DateTimeOffsetMarshaler.ConvertToManaged(out managedArray[i], ref ptr[i]);
				}
			}
		}

		// Token: 0x06004303 RID: 17155 RVA: 0x000F9998 File Offset: 0x000F7B98
		[SecurityCritical]
		internal unsafe static void ConvertContentsToManaged_Type(ref Type[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				TypeNameNative* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					SystemTypeMarshaler.ConvertToManaged(ptr + i, ref managedArray[i]);
				}
			}
		}

		// Token: 0x06004304 RID: 17156 RVA: 0x000F99DC File Offset: 0x000F7BDC
		[SecurityCritical]
		internal unsafe static void ConvertContentsToManaged_Exception(ref Exception[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				int* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					managedArray[i] = HResultExceptionMarshaler.ConvertToManaged(ptr[i]);
				}
			}
		}

		// Token: 0x06004305 RID: 17157 RVA: 0x000F9A14 File Offset: 0x000F7C14
		[SecurityCritical]
		internal unsafe static void ConvertContentsToManaged_Nullable<T>(ref T?[] managedArray, IntPtr pNativeHome) where T : struct
		{
			if (managedArray != null)
			{
				IntPtr* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					managedArray[i] = NullableMarshaler.ConvertToManaged<T>(ptr[i]);
				}
			}
		}

		// Token: 0x06004306 RID: 17158 RVA: 0x000F9A58 File Offset: 0x000F7C58
		[SecurityCritical]
		internal unsafe static void ConvertContentsToManaged_KeyValuePair<K, V>(ref KeyValuePair<K, V>[] managedArray, IntPtr pNativeHome)
		{
			if (managedArray != null)
			{
				IntPtr* ptr = *(IntPtr*)((void*)pNativeHome);
				for (int i = 0; i < managedArray.Length; i++)
				{
					managedArray[i] = KeyValuePairMarshaler.ConvertToManaged<K, V>(ptr[i]);
				}
			}
		}

		// Token: 0x06004307 RID: 17159
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ClearNativeContents(IntPtr pMarshalState, IntPtr pNativeHome, int cElements);

		// Token: 0x06004308 RID: 17160 RVA: 0x000F9A9C File Offset: 0x000F7C9C
		[SecurityCritical]
		internal unsafe static void ClearNativeContents_Type(IntPtr pNativeHome, int cElements)
		{
			TypeNameNative* ptr = *(IntPtr*)((void*)pNativeHome);
			if (ptr != null)
			{
				for (int i = 0; i < cElements; i++)
				{
					SystemTypeMarshaler.ClearNative(ptr);
					ptr++;
				}
			}
		}
	}
}
