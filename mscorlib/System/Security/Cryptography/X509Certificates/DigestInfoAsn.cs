using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C3 RID: 707
	internal struct DigestInfoAsn
	{
		// Token: 0x06002520 RID: 9504 RVA: 0x00087221 File Offset: 0x00085421
		internal static DigestInfoAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return DigestInfoAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x06002521 RID: 9505 RVA: 0x00087230 File Offset: 0x00085430
		internal static DigestInfoAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			DigestInfoAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				DigestInfoAsn digestInfoAsn;
				DigestInfoAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out digestInfoAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = digestInfoAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x00087280 File Offset: 0x00085480
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out DigestInfoAsn decoded)
		{
			DigestInfoAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x00087290 File Offset: 0x00085490
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out DigestInfoAsn decoded)
		{
			try
			{
				DigestInfoAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x000872C8 File Offset: 0x000854C8
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out DigestInfoAsn decoded)
		{
			decoded = default(DigestInfoAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			AlgorithmIdentifierAsn.Decode(ref asnValueReader, rebind, out decoded.DigestAlgorithm);
			ReadOnlySpan<byte> destination;
			if (asnValueReader.TryReadPrimitiveOctetString(out destination))
			{
				int start;
				decoded.Digest = (span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray());
			}
			else
			{
				decoded.Digest = asnValueReader.ReadOctetString();
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000DF1 RID: 3569
		internal AlgorithmIdentifierAsn DigestAlgorithm;

		// Token: 0x04000DF2 RID: 3570
		internal ReadOnlyMemory<byte> Digest;
	}
}
