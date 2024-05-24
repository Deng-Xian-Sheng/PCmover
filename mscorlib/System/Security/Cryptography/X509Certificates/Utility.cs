using System;
using System.Text;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002D8 RID: 728
	internal static class Utility
	{
		// Token: 0x060025A0 RID: 9632 RVA: 0x0008944C File Offset: 0x0008764C
		public static Span<T> GetSpanForArray<T>(T[] array, int offset)
		{
			return Utility.GetSpanForArray<T>(array, offset, array.Length - offset);
		}

		// Token: 0x060025A1 RID: 9633 RVA: 0x0008945A File Offset: 0x0008765A
		public static Span<T> GetSpanForArray<T>(T[] array, int offset, int count)
		{
			return new Span<T>(array, offset, count);
		}

		// Token: 0x060025A2 RID: 9634 RVA: 0x00089464 File Offset: 0x00087664
		public static int EncodingGetByteCount(Encoding encoding, ReadOnlySpan<char> input)
		{
			if (input.IsNull)
			{
				return encoding.GetByteCount(new char[0]);
			}
			ArraySegment<char> arraySegment = input.DangerousGetArraySegment();
			return encoding.GetByteCount(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
		}

		// Token: 0x060025A3 RID: 9635 RVA: 0x000894AC File Offset: 0x000876AC
		public static int EncodingGetBytes(Encoding encoding, char[] input, Span<byte> destination)
		{
			ArraySegment<byte> arraySegment = destination.DangerousGetArraySegment();
			return encoding.GetBytes(input, 0, input.Length, arraySegment.Array, arraySegment.Offset);
		}

		// Token: 0x060025A4 RID: 9636 RVA: 0x000894DC File Offset: 0x000876DC
		public static int EncodingGetBytes(Encoding encoding, ReadOnlySpan<char> input, Span<byte> destination)
		{
			ArraySegment<byte> arraySegment = destination.DangerousGetArraySegment();
			ArraySegment<char> arraySegment2 = input.DangerousGetArraySegment();
			return encoding.GetBytes(arraySegment2.Array, arraySegment2.Offset, arraySegment2.Count, arraySegment.Array, arraySegment.Offset);
		}
	}
}
