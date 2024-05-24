using System;
using System.Collections.Generic;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C1 RID: 705
	internal struct AttributeAsn
	{
		// Token: 0x06002516 RID: 9494 RVA: 0x00086F9E File Offset: 0x0008519E
		internal static AttributeAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return AttributeAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x06002517 RID: 9495 RVA: 0x00086FAC File Offset: 0x000851AC
		internal static AttributeAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			AttributeAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				AttributeAsn attributeAsn;
				AttributeAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out attributeAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = attributeAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x00086FFC File Offset: 0x000851FC
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out AttributeAsn decoded)
		{
			AttributeAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x0008700C File Offset: 0x0008520C
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out AttributeAsn decoded)
		{
			try
			{
				AttributeAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x00087044 File Offset: 0x00085244
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out AttributeAsn decoded)
		{
			decoded = default(AttributeAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			decoded.AttrType = asnValueReader.ReadObjectIdentifier();
			AsnValueReader asnValueReader2 = asnValueReader.ReadSetOf();
			List<ReadOnlyMemory<byte>> list = new List<ReadOnlyMemory<byte>>();
			while (asnValueReader2.HasData)
			{
				ReadOnlySpan<byte> destination = asnValueReader2.ReadEncodedValue();
				int start;
				ReadOnlyMemory<byte> item = span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray();
				list.Add(item);
			}
			decoded.AttrValues = list.ToArray();
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000DED RID: 3565
		internal byte[] AttrType;

		// Token: 0x04000DEE RID: 3566
		internal ReadOnlyMemory<byte>[] AttrValues;
	}
}
