using System;
using System.Runtime.CompilerServices;

namespace System.Numerics
{
	// Token: 0x02000006 RID: 6
	internal class ConstantHelper
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002214 File Offset: 0x00000414
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte GetByteWithAllBitsSet()
		{
			byte result = 0;
			*(&result) = byte.MaxValue;
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002230 File Offset: 0x00000430
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static sbyte GetSByteWithAllBitsSet()
		{
			sbyte result = 0;
			*(&result) = -1;
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002248 File Offset: 0x00000448
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ushort GetUInt16WithAllBitsSet()
		{
			ushort result = 0;
			*(&result) = ushort.MaxValue;
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002264 File Offset: 0x00000464
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static short GetInt16WithAllBitsSet()
		{
			short result = 0;
			*(&result) = -1;
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000227C File Offset: 0x0000047C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint GetUInt32WithAllBitsSet()
		{
			uint result = 0U;
			*(&result) = uint.MaxValue;
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002294 File Offset: 0x00000494
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int GetInt32WithAllBitsSet()
		{
			int result = 0;
			*(&result) = -1;
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000022AC File Offset: 0x000004AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong GetUInt64WithAllBitsSet()
		{
			ulong result = 0UL;
			*(&result) = ulong.MaxValue;
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022C4 File Offset: 0x000004C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static long GetInt64WithAllBitsSet()
		{
			long result = 0L;
			*(&result) = -1L;
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000022DC File Offset: 0x000004DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static float GetSingleWithAllBitsSet()
		{
			float result = 0f;
			*(int*)(&result) = -1;
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000022F8 File Offset: 0x000004F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static double GetDoubleWithAllBitsSet()
		{
			double result = 0.0;
			*(long*)(&result) = -1L;
			return result;
		}
	}
}
