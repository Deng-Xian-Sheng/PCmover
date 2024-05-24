using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C4 RID: 708
	internal struct EncryptedContentInfoAsn
	{
		// Token: 0x06002525 RID: 9509 RVA: 0x00087354 File Offset: 0x00085554
		internal static EncryptedContentInfoAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return EncryptedContentInfoAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x06002526 RID: 9510 RVA: 0x00087364 File Offset: 0x00085564
		internal static EncryptedContentInfoAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			EncryptedContentInfoAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				EncryptedContentInfoAsn encryptedContentInfoAsn;
				EncryptedContentInfoAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out encryptedContentInfoAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = encryptedContentInfoAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x06002527 RID: 9511 RVA: 0x000873B4 File Offset: 0x000855B4
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out EncryptedContentInfoAsn decoded)
		{
			EncryptedContentInfoAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x06002528 RID: 9512 RVA: 0x000873C4 File Offset: 0x000855C4
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out EncryptedContentInfoAsn decoded)
		{
			try
			{
				EncryptedContentInfoAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x06002529 RID: 9513 RVA: 0x000873FC File Offset: 0x000855FC
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out EncryptedContentInfoAsn decoded)
		{
			decoded = default(EncryptedContentInfoAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			decoded.ContentType = asnValueReader.ReadObjectIdentifier();
			AlgorithmIdentifierAsn.Decode(ref asnValueReader, rebind, out decoded.ContentEncryptionAlgorithm);
			if (asnValueReader.HasData && asnValueReader.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 0)))
			{
				ReadOnlySpan<byte> destination;
				if (asnValueReader.TryReadPrimitiveOctetString(out destination, new Asn1Tag?(new Asn1Tag(TagClass.ContextSpecific, 0))))
				{
					int start;
					decoded.EncryptedContent = new ReadOnlyMemory<byte>?(span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray());
				}
				else
				{
					decoded.EncryptedContent = new ReadOnlyMemory<byte>?(asnValueReader.ReadOctetString(new Asn1Tag?(new Asn1Tag(TagClass.ContextSpecific, 0))));
				}
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000DF3 RID: 3571
		internal byte[] ContentType;

		// Token: 0x04000DF4 RID: 3572
		internal AlgorithmIdentifierAsn ContentEncryptionAlgorithm;

		// Token: 0x04000DF5 RID: 3573
		internal ReadOnlyMemory<byte>? EncryptedContent;
	}
}
