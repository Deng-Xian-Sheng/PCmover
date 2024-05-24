using System;
using System.Runtime.Versioning;

namespace System.Runtime.CompilerServices
{
	// Token: 0x02000002 RID: 2
	public static class Unsafe
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T Read<T>(void* source)
		{
			return *(T*)source;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020E4 File Offset: 0x000002E4
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T ReadUnaligned<T>(void* source)
		{
			return *(T*)source;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020FC File Offset: 0x000002FC
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T ReadUnaligned<T>(ref byte source)
		{
			return source;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Write<T>(void* destination, T value)
		{
			*(T*)destination = value;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002128 File Offset: 0x00000328
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WriteUnaligned<T>(void* destination, T value)
		{
			*(T*)destination = value;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002140 File Offset: 0x00000340
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteUnaligned<T>(ref byte destination, T value)
		{
			destination = value;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002158 File Offset: 0x00000358
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy<T>(void* destination, ref T source)
		{
			*(T*)destination = source;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002174 File Offset: 0x00000374
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy<T>(ref T destination, void* source)
		{
			destination = *(T*)source;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002190 File Offset: 0x00000390
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* AsPointer<T>(ref T value)
		{
			return (void*)(&value);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021A0 File Offset: 0x000003A0
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int SizeOf<T>()
		{
			return sizeof(T);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021B4 File Offset: 0x000003B4
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void CopyBlock(void* destination, void* source, uint byteCount)
		{
			cpblk(destination, source, byteCount);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021C8 File Offset: 0x000003C8
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CopyBlock(ref byte destination, ref byte source, uint byteCount)
		{
			cpblk(ref destination, ref source, byteCount);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021DC File Offset: 0x000003DC
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void CopyBlockUnaligned(void* destination, void* source, uint byteCount)
		{
			cpblk(destination, source, byteCount);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021F4 File Offset: 0x000003F4
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CopyBlockUnaligned(ref byte destination, ref byte source, uint byteCount)
		{
			cpblk(ref destination, ref source, byteCount);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000220C File Offset: 0x0000040C
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void InitBlock(void* startAddress, byte value, uint byteCount)
		{
			initblk(startAddress, value, byteCount);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002220 File Offset: 0x00000420
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InitBlock(ref byte startAddress, byte value, uint byteCount)
		{
			initblk(ref startAddress, value, byteCount);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002234 File Offset: 0x00000434
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void InitBlockUnaligned(void* startAddress, byte value, uint byteCount)
		{
			initblk(startAddress, value, byteCount);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000224C File Offset: 0x0000044C
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount)
		{
			initblk(ref startAddress, value, byteCount);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002264 File Offset: 0x00000464
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T As<T>(object o) where T : class
		{
			return o;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002274 File Offset: 0x00000474
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ref T AsRef<T>(void* source)
		{
			return ref *(T*)source;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002284 File Offset: 0x00000484
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T AsRef<T>(in T source)
		{
			return ref source;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002294 File Offset: 0x00000494
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref TTo As<TFrom, TTo>(ref TFrom source)
		{
			return ref source;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022A4 File Offset: 0x000004A4
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T Add<T>(ref T source, int elementOffset)
		{
			return ref source + (IntPtr)elementOffset * (IntPtr)sizeof(T);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022BC File Offset: 0x000004BC
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* Add<T>(void* source, int elementOffset)
		{
			return (void*)((byte*)source + (IntPtr)elementOffset * (IntPtr)sizeof(T));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000022D4 File Offset: 0x000004D4
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T Add<T>(ref T source, IntPtr elementOffset)
		{
			return ref source + elementOffset * (IntPtr)sizeof(T);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000022EC File Offset: 0x000004EC
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T AddByteOffset<T>(ref T source, IntPtr byteOffset)
		{
			return ref source + byteOffset;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000022FC File Offset: 0x000004FC
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T Subtract<T>(ref T source, int elementOffset)
		{
			return ref source - (IntPtr)elementOffset * (IntPtr)sizeof(T);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002314 File Offset: 0x00000514
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* Subtract<T>(void* source, int elementOffset)
		{
			return (void*)((byte*)source - (IntPtr)elementOffset * (IntPtr)sizeof(T));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000232C File Offset: 0x0000052C
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T Subtract<T>(ref T source, IntPtr elementOffset)
		{
			return ref source - elementOffset * (IntPtr)sizeof(T);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002344 File Offset: 0x00000544
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T SubtractByteOffset<T>(ref T source, IntPtr byteOffset)
		{
			return ref source - byteOffset;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002354 File Offset: 0x00000554
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IntPtr ByteOffset<T>(ref T origin, ref T target)
		{
			return ref target - ref origin;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002364 File Offset: 0x00000564
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AreSame<T>(ref T left, ref T right)
		{
			return ref left == ref right;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002378 File Offset: 0x00000578
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAddressGreaterThan<T>(ref T left, ref T right)
		{
			return ref left != ref right;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000238C File Offset: 0x0000058C
		[NonVersionable]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAddressLessThan<T>(ref T left, ref T right)
		{
			return ref left < ref right;
		}
	}
}
