using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002D9 RID: 729
	internal static class BinaryPrimitives
	{
		// Token: 0x060025A5 RID: 9637 RVA: 0x00089522 File Offset: 0x00087722
		public static bool TryReadUInt16BigEndian(ReadOnlySpan<byte> bytes, out ushort value)
		{
			if (bytes.Length < 2)
			{
				value = 0;
				return false;
			}
			value = (ushort)((int)bytes[1] | (int)bytes[0] << 8);
			return true;
		}

		// Token: 0x060025A6 RID: 9638 RVA: 0x0008954A File Offset: 0x0008774A
		public static short ReadInt16BigEndian(ReadOnlySpan<byte> bytes)
		{
			return (short)((int)bytes[1] | (int)bytes[0] << 8);
		}
	}
}
