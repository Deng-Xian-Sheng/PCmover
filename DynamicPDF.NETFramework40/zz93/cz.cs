using System;

namespace zz93
{
	// Token: 0x02000085 RID: 133
	internal class cz
	{
		// Token: 0x06000618 RID: 1560 RVA: 0x00056019 File Offset: 0x00055019
		internal cz()
		{
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00056024 File Offset: 0x00055024
		internal static byte[] b(byte[] A_0)
		{
			cz.a a = new cz.a();
			byte[] array = cz.a(A_0);
			int num = array.Length * 8 / 32;
			uint[] a_ = new uint[16];
			for (int i = 0; i < num / 16; i++)
			{
				cz.a(a_, array, i);
				cz.a(a_, ref a.a, ref a.b, ref a.c, ref a.d);
			}
			return a.a();
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x000560A0 File Offset: 0x000550A0
		private static void d(uint[] A_0, ref uint A_1, uint A_2, uint A_3, uint A_4, uint A_5, ushort A_6, uint A_7)
		{
			A_1 = A_2 + cz.a(A_1 + ((A_2 & A_3) | (~A_2 & A_4)) + A_0[(int)((UIntPtr)A_5)] + cz.a[(int)((UIntPtr)(A_7 - 1U))], A_6);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x000560CC File Offset: 0x000550CC
		private static void c(uint[] A_0, ref uint A_1, uint A_2, uint A_3, uint A_4, uint A_5, ushort A_6, uint A_7)
		{
			A_1 = A_2 + cz.a(A_1 + ((A_2 & A_4) | (A_3 & ~A_4)) + A_0[(int)((UIntPtr)A_5)] + cz.a[(int)((UIntPtr)(A_7 - 1U))], A_6);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x000560F9 File Offset: 0x000550F9
		private static void b(uint[] A_0, ref uint A_1, uint A_2, uint A_3, uint A_4, uint A_5, ushort A_6, uint A_7)
		{
			A_1 = A_2 + cz.a(A_1 + (A_2 ^ A_3 ^ A_4) + A_0[(int)((UIntPtr)A_5)] + cz.a[(int)((UIntPtr)(A_7 - 1U))], A_6);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00056122 File Offset: 0x00055122
		private static void a(uint[] A_0, ref uint A_1, uint A_2, uint A_3, uint A_4, uint A_5, ushort A_6, uint A_7)
		{
			A_1 = A_2 + cz.a(A_1 + (A_3 ^ (A_2 | ~A_4)) + A_0[(int)((UIntPtr)A_5)] + cz.a[(int)((UIntPtr)(A_7 - 1U))], A_6);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0005614C File Offset: 0x0005514C
		private static void a(uint[] A_0, ref uint A_1, ref uint A_2, ref uint A_3, ref uint A_4)
		{
			uint num = A_1;
			uint num2 = A_2;
			uint num3 = A_3;
			uint num4 = A_4;
			cz.d(A_0, ref A_1, A_2, A_3, A_4, 0U, 7, 1U);
			cz.d(A_0, ref A_4, A_1, A_2, A_3, 1U, 12, 2U);
			cz.d(A_0, ref A_3, A_4, A_1, A_2, 2U, 17, 3U);
			cz.d(A_0, ref A_2, A_3, A_4, A_1, 3U, 22, 4U);
			cz.d(A_0, ref A_1, A_2, A_3, A_4, 4U, 7, 5U);
			cz.d(A_0, ref A_4, A_1, A_2, A_3, 5U, 12, 6U);
			cz.d(A_0, ref A_3, A_4, A_1, A_2, 6U, 17, 7U);
			cz.d(A_0, ref A_2, A_3, A_4, A_1, 7U, 22, 8U);
			cz.d(A_0, ref A_1, A_2, A_3, A_4, 8U, 7, 9U);
			cz.d(A_0, ref A_4, A_1, A_2, A_3, 9U, 12, 10U);
			cz.d(A_0, ref A_3, A_4, A_1, A_2, 10U, 17, 11U);
			cz.d(A_0, ref A_2, A_3, A_4, A_1, 11U, 22, 12U);
			cz.d(A_0, ref A_1, A_2, A_3, A_4, 12U, 7, 13U);
			cz.d(A_0, ref A_4, A_1, A_2, A_3, 13U, 12, 14U);
			cz.d(A_0, ref A_3, A_4, A_1, A_2, 14U, 17, 15U);
			cz.d(A_0, ref A_2, A_3, A_4, A_1, 15U, 22, 16U);
			cz.c(A_0, ref A_1, A_2, A_3, A_4, 1U, 5, 17U);
			cz.c(A_0, ref A_4, A_1, A_2, A_3, 6U, 9, 18U);
			cz.c(A_0, ref A_3, A_4, A_1, A_2, 11U, 14, 19U);
			cz.c(A_0, ref A_2, A_3, A_4, A_1, 0U, 20, 20U);
			cz.c(A_0, ref A_1, A_2, A_3, A_4, 5U, 5, 21U);
			cz.c(A_0, ref A_4, A_1, A_2, A_3, 10U, 9, 22U);
			cz.c(A_0, ref A_3, A_4, A_1, A_2, 15U, 14, 23U);
			cz.c(A_0, ref A_2, A_3, A_4, A_1, 4U, 20, 24U);
			cz.c(A_0, ref A_1, A_2, A_3, A_4, 9U, 5, 25U);
			cz.c(A_0, ref A_4, A_1, A_2, A_3, 14U, 9, 26U);
			cz.c(A_0, ref A_3, A_4, A_1, A_2, 3U, 14, 27U);
			cz.c(A_0, ref A_2, A_3, A_4, A_1, 8U, 20, 28U);
			cz.c(A_0, ref A_1, A_2, A_3, A_4, 13U, 5, 29U);
			cz.c(A_0, ref A_4, A_1, A_2, A_3, 2U, 9, 30U);
			cz.c(A_0, ref A_3, A_4, A_1, A_2, 7U, 14, 31U);
			cz.c(A_0, ref A_2, A_3, A_4, A_1, 12U, 20, 32U);
			cz.b(A_0, ref A_1, A_2, A_3, A_4, 5U, 4, 33U);
			cz.b(A_0, ref A_4, A_1, A_2, A_3, 8U, 11, 34U);
			cz.b(A_0, ref A_3, A_4, A_1, A_2, 11U, 16, 35U);
			cz.b(A_0, ref A_2, A_3, A_4, A_1, 14U, 23, 36U);
			cz.b(A_0, ref A_1, A_2, A_3, A_4, 1U, 4, 37U);
			cz.b(A_0, ref A_4, A_1, A_2, A_3, 4U, 11, 38U);
			cz.b(A_0, ref A_3, A_4, A_1, A_2, 7U, 16, 39U);
			cz.b(A_0, ref A_2, A_3, A_4, A_1, 10U, 23, 40U);
			cz.b(A_0, ref A_1, A_2, A_3, A_4, 13U, 4, 41U);
			cz.b(A_0, ref A_4, A_1, A_2, A_3, 0U, 11, 42U);
			cz.b(A_0, ref A_3, A_4, A_1, A_2, 3U, 16, 43U);
			cz.b(A_0, ref A_2, A_3, A_4, A_1, 6U, 23, 44U);
			cz.b(A_0, ref A_1, A_2, A_3, A_4, 9U, 4, 45U);
			cz.b(A_0, ref A_4, A_1, A_2, A_3, 12U, 11, 46U);
			cz.b(A_0, ref A_3, A_4, A_1, A_2, 15U, 16, 47U);
			cz.b(A_0, ref A_2, A_3, A_4, A_1, 2U, 23, 48U);
			cz.a(A_0, ref A_1, A_2, A_3, A_4, 0U, 6, 49U);
			cz.a(A_0, ref A_4, A_1, A_2, A_3, 7U, 10, 50U);
			cz.a(A_0, ref A_3, A_4, A_1, A_2, 14U, 15, 51U);
			cz.a(A_0, ref A_2, A_3, A_4, A_1, 5U, 21, 52U);
			cz.a(A_0, ref A_1, A_2, A_3, A_4, 12U, 6, 53U);
			cz.a(A_0, ref A_4, A_1, A_2, A_3, 3U, 10, 54U);
			cz.a(A_0, ref A_3, A_4, A_1, A_2, 10U, 15, 55U);
			cz.a(A_0, ref A_2, A_3, A_4, A_1, 1U, 21, 56U);
			cz.a(A_0, ref A_1, A_2, A_3, A_4, 8U, 6, 57U);
			cz.a(A_0, ref A_4, A_1, A_2, A_3, 15U, 10, 58U);
			cz.a(A_0, ref A_3, A_4, A_1, A_2, 6U, 15, 59U);
			cz.a(A_0, ref A_2, A_3, A_4, A_1, 13U, 21, 60U);
			cz.a(A_0, ref A_1, A_2, A_3, A_4, 4U, 6, 61U);
			cz.a(A_0, ref A_4, A_1, A_2, A_3, 11U, 10, 62U);
			cz.a(A_0, ref A_3, A_4, A_1, A_2, 2U, 15, 63U);
			cz.a(A_0, ref A_2, A_3, A_4, A_1, 9U, 21, 64U);
			A_1 += num;
			A_2 += num2;
			A_3 += num3;
			A_4 += num4;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00056688 File Offset: 0x00055688
		private static byte[] a(byte[] A_0)
		{
			uint num = (uint)((448 - A_0.Length * 8 % 512 + 512) % 512);
			if (num == 0U)
			{
				num = 512U;
			}
			uint num2 = (uint)((long)A_0.Length + (long)((ulong)(num / 8U)) + 8L);
			ulong num3 = (ulong)((long)A_0.Length * 8L);
			byte[] array = new byte[num2];
			A_0.CopyTo(array, 0);
			byte[] array2 = array;
			int num4 = A_0.Length;
			array2[num4] |= 128;
			for (int i = 8; i > 0; i--)
			{
				array[(int)(checked((IntPtr)(unchecked((ulong)num2 - (ulong)((long)i)))))] = (byte)(num3 >> (8 - i) * 8 & 255UL);
			}
			return array;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00056744 File Offset: 0x00055744
		private static void a(uint[] A_0, byte[] A_1, int A_2)
		{
			A_2 <<= 6;
			for (uint num = 0U; num < 61U; num += 4U)
			{
				A_0[(int)((UIntPtr)(num >> 2))] = (uint)(checked((int)A_1[(int)((IntPtr)(unchecked((long)A_2 + (long)((ulong)(num + 3U)))))] << 24 | (int)A_1[(int)((IntPtr)(unchecked((long)A_2 + (long)((ulong)(num + 2U)))))] << 16 | (int)A_1[(int)((IntPtr)(unchecked((long)A_2 + (long)((ulong)(num + 1U)))))] << 8 | (int)A_1[(int)((IntPtr)(unchecked((long)A_2 + (long)((ulong)num))))]));
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x000567A4 File Offset: 0x000557A4
		private static uint a(uint A_0, ushort A_1)
		{
			return A_0 >> (int)(32 - A_1) | A_0 << (int)A_1;
		}

		// Token: 0x0400033D RID: 829
		private static readonly uint[] a = new uint[]
		{
			3614090360U,
			3905402710U,
			606105819U,
			3250441966U,
			4118548399U,
			1200080426U,
			2821735955U,
			4249261313U,
			1770035416U,
			2336552879U,
			4294925233U,
			2304563134U,
			1804603682U,
			4254626195U,
			2792965006U,
			1236535329U,
			4129170786U,
			3225465664U,
			643717713U,
			3921069994U,
			3593408605U,
			38016083U,
			3634488961U,
			3889429448U,
			568446438U,
			3275163606U,
			4107603335U,
			1163531501U,
			2850285829U,
			4243563512U,
			1735328473U,
			2368359562U,
			4294588738U,
			2272392833U,
			1839030562U,
			4259657740U,
			2763975236U,
			1272893353U,
			4139469664U,
			3200236656U,
			681279174U,
			3936430074U,
			3572445317U,
			76029189U,
			3654602809U,
			3873151461U,
			530742520U,
			3299628645U,
			4096336452U,
			1126891415U,
			2878612391U,
			4237533241U,
			1700485571U,
			2399980690U,
			4293915773U,
			2240044497U,
			1873313359U,
			4264355552U,
			2734768916U,
			1309151649U,
			4149444226U,
			3174756917U,
			718787259U,
			3951481745U
		};

		// Token: 0x02000086 RID: 134
		internal sealed class a
		{
			// Token: 0x06000623 RID: 1571 RVA: 0x000567DF File Offset: 0x000557DF
			internal a()
			{
			}

			// Token: 0x06000624 RID: 1572 RVA: 0x00056818 File Offset: 0x00055818
			internal byte[] a()
			{
				byte[] array = new byte[16];
				BitConverter.GetBytes(this.a).CopyTo(array, 0);
				BitConverter.GetBytes(this.b).CopyTo(array, 4);
				BitConverter.GetBytes(this.c).CopyTo(array, 8);
				BitConverter.GetBytes(this.d).CopyTo(array, 12);
				return array;
			}

			// Token: 0x0400033E RID: 830
			internal uint a = 1732584193U;

			// Token: 0x0400033F RID: 831
			internal uint b = 4023233417U;

			// Token: 0x04000340 RID: 832
			internal uint c = 2562383102U;

			// Token: 0x04000341 RID: 833
			internal uint d = 271733878U;
		}
	}
}
