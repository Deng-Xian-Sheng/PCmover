using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C2 RID: 706
	internal struct ContentInfoAsn
	{
		// Token: 0x0600251B RID: 9499 RVA: 0x000870E6 File Offset: 0x000852E6
		internal static ContentInfoAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return ContentInfoAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x000870F4 File Offset: 0x000852F4
		internal static ContentInfoAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			ContentInfoAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				ContentInfoAsn contentInfoAsn;
				ContentInfoAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out contentInfoAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = contentInfoAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x00087144 File Offset: 0x00085344
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out ContentInfoAsn decoded)
		{
			ContentInfoAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x00087154 File Offset: 0x00085354
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out ContentInfoAsn decoded)
		{
			try
			{
				ContentInfoAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x0600251F RID: 9503 RVA: 0x0008718C File Offset: 0x0008538C
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out ContentInfoAsn decoded)
		{
			decoded = default(ContentInfoAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			decoded.ContentType = asnValueReader.ReadObjectIdentifier();
			AsnValueReader asnValueReader2 = asnValueReader.ReadSequence(new Asn1Tag?(new Asn1Tag(TagClass.ContextSpecific, 0)));
			ReadOnlySpan<byte> destination = asnValueReader2.ReadEncodedValue();
			int start;
			decoded.Content = (span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray());
			asnValueReader2.ThrowIfNotEmpty();
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000DEF RID: 3567
		internal byte[] ContentType;

		// Token: 0x04000DF0 RID: 3568
		internal ReadOnlyMemory<byte> Content;
	}
}
