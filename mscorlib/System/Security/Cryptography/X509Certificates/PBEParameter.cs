using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C8 RID: 712
	internal struct PBEParameter
	{
		// Token: 0x0600253A RID: 9530 RVA: 0x00087929 File Offset: 0x00085B29
		internal static PBEParameter Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return PBEParameter.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x0600253B RID: 9531 RVA: 0x00087938 File Offset: 0x00085B38
		internal static PBEParameter Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			PBEParameter result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				PBEParameter pbeparameter;
				PBEParameter.DecodeCore(ref asnValueReader, expectedTag, encoded, out pbeparameter);
				asnValueReader.ThrowIfNotEmpty();
				result = pbeparameter;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x0600253C RID: 9532 RVA: 0x00087988 File Offset: 0x00085B88
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out PBEParameter decoded)
		{
			PBEParameter.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x00087998 File Offset: 0x00085B98
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out PBEParameter decoded)
		{
			try
			{
				PBEParameter.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x0600253E RID: 9534 RVA: 0x000879D0 File Offset: 0x00085BD0
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out PBEParameter decoded)
		{
			decoded = default(PBEParameter);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			ReadOnlySpan<byte> destination;
			if (asnValueReader.TryReadPrimitiveOctetString(out destination))
			{
				int start;
				decoded.Salt = (span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray());
			}
			else
			{
				decoded.Salt = asnValueReader.ReadOctetString();
			}
			if (!asnValueReader.TryReadInt32(out decoded.IterationCount))
			{
				asnValueReader.ThrowIfNotEmpty();
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000DFF RID: 3583
		internal ReadOnlyMemory<byte> Salt;

		// Token: 0x04000E00 RID: 3584
		internal int IterationCount;
	}
}
