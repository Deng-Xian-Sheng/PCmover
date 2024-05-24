using System;
using System.Diagnostics;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B8 RID: 696
	internal static class Helpers
	{
		// Token: 0x060024EB RID: 9451 RVA: 0x00085898 File Offset: 0x00083A98
		internal static bool SequenceEqual(byte[] left, byte[] right)
		{
			if (left.Length != right.Length)
			{
				return false;
			}
			for (int i = 0; i < left.Length; i++)
			{
				if (left[i] != right[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060024EC RID: 9452 RVA: 0x000858C8 File Offset: 0x00083AC8
		internal static ReadOnlyMemory<byte> DecodeOctetStringAsMemory(ReadOnlyMemory<byte> encodedOctetString)
		{
			ReadOnlyMemory<byte> result;
			try
			{
				ReadOnlySpan<byte> span = encodedOctetString.Span;
				ReadOnlySpan<byte> destination;
				int num;
				if (AsnDecoder.TryReadPrimitiveOctetString(span, AsnEncodingRules.BER, out destination, out num, null))
				{
					if (num != span.Length)
					{
						throw new CryptographicException("ASN1 corrupted data.");
					}
					int start;
					if (span.Overlaps(destination, out start))
					{
						return encodedOctetString.Slice(start, destination.Length);
					}
					Assert.Fail("input.Overlaps(primitive)", "input.Overlaps(primitive) failed after TryReadPrimitiveOctetString succeeded");
				}
				byte[] array = AsnDecoder.ReadOctetString(span, AsnEncodingRules.BER, out num, null);
				if (num != span.Length)
				{
					throw new CryptographicException("ASN1 corrupted data.");
				}
				result = array;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}
	}
}
