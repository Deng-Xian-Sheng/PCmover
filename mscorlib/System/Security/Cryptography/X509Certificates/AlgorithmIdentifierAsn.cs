using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C0 RID: 704
	internal struct AlgorithmIdentifierAsn
	{
		// Token: 0x0600250E RID: 9486 RVA: 0x00086E06 File Offset: 0x00085006
		internal static AlgorithmIdentifierAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return AlgorithmIdentifierAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x00086E14 File Offset: 0x00085014
		internal static AlgorithmIdentifierAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			AlgorithmIdentifierAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				AlgorithmIdentifierAsn algorithmIdentifierAsn;
				AlgorithmIdentifierAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out algorithmIdentifierAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = algorithmIdentifierAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x00086E64 File Offset: 0x00085064
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out AlgorithmIdentifierAsn decoded)
		{
			AlgorithmIdentifierAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x06002511 RID: 9489 RVA: 0x00086E74 File Offset: 0x00085074
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out AlgorithmIdentifierAsn decoded)
		{
			try
			{
				AlgorithmIdentifierAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x00086EAC File Offset: 0x000850AC
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out AlgorithmIdentifierAsn decoded)
		{
			decoded = default(AlgorithmIdentifierAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			decoded.Algorithm = asnValueReader.ReadObjectIdentifier();
			if (asnValueReader.HasData)
			{
				ReadOnlySpan<byte> destination = asnValueReader.ReadEncodedValue();
				int start;
				decoded.Parameters = new ReadOnlyMemory<byte>?(span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray());
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x06002513 RID: 9491 RVA: 0x00086F2E File Offset: 0x0008512E
		internal bool HasNullEquivalentParameters()
		{
			return AlgorithmIdentifierAsn.RepresentsNull(this.Parameters);
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x00086F3C File Offset: 0x0008513C
		internal static bool RepresentsNull(ReadOnlyMemory<byte>? parameters)
		{
			if (parameters == null)
			{
				return true;
			}
			ReadOnlySpan<byte> span = parameters.Value.Span;
			return span.Length == 2 && span[0] == 5 && span[1] == 0;
		}

		// Token: 0x06002515 RID: 9493 RVA: 0x00086F88 File Offset: 0x00085188
		// Note: this type is marked as 'beforefieldinit'.
		static AlgorithmIdentifierAsn()
		{
			byte[] array = new byte[2];
			array[0] = 5;
			AlgorithmIdentifierAsn.ExplicitDerNull = array;
		}

		// Token: 0x04000DEA RID: 3562
		internal byte[] Algorithm;

		// Token: 0x04000DEB RID: 3563
		internal ReadOnlyMemory<byte>? Parameters;

		// Token: 0x04000DEC RID: 3564
		internal static readonly ReadOnlyMemory<byte> ExplicitDerNull;
	}
}
