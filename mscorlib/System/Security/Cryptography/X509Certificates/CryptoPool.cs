using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002DA RID: 730
	internal static class CryptoPool
	{
		// Token: 0x060025A7 RID: 9639 RVA: 0x00089560 File Offset: 0x00087760
		public static byte[] Rent(int size)
		{
			return new byte[size];
		}

		// Token: 0x060025A8 RID: 9640 RVA: 0x00089568 File Offset: 0x00087768
		public static void Return(byte[] array, int clearSize)
		{
			CryptographicOperations.ZeroMemory(new Span<byte>(array, 0, clearSize));
		}

		// Token: 0x060025A9 RID: 9641 RVA: 0x00089577 File Offset: 0x00087777
		public static void Return(byte[] array)
		{
			CryptographicOperations.ZeroMemory(new Span<byte>(array));
		}

		// Token: 0x060025AA RID: 9642 RVA: 0x00089584 File Offset: 0x00087784
		public static void Return(ArraySegment<byte> segment, int clearSize)
		{
			CryptographicOperations.ZeroMemory(new Span<byte>(segment).Slice(0, clearSize));
		}

		// Token: 0x060025AB RID: 9643 RVA: 0x000895A6 File Offset: 0x000877A6
		public static void Return(ArraySegment<byte> segment)
		{
			CryptographicOperations.ZeroMemory(new Span<byte>(segment));
		}
	}
}
