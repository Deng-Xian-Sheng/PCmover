using System;
using System.Collections.Generic;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002CE RID: 718
	internal struct SafeBagAsn
	{
		// Token: 0x0600255B RID: 9563 RVA: 0x000885F4 File Offset: 0x000867F4
		internal static SafeBagAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return SafeBagAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x0600255C RID: 9564 RVA: 0x00088604 File Offset: 0x00086804
		internal static SafeBagAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			SafeBagAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				SafeBagAsn safeBagAsn;
				SafeBagAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out safeBagAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = safeBagAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x0600255D RID: 9565 RVA: 0x00088654 File Offset: 0x00086854
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out SafeBagAsn decoded)
		{
			SafeBagAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x0600255E RID: 9566 RVA: 0x00088664 File Offset: 0x00086864
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out SafeBagAsn decoded)
		{
			try
			{
				SafeBagAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x0600255F RID: 9567 RVA: 0x0008869C File Offset: 0x0008689C
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out SafeBagAsn decoded)
		{
			decoded = default(SafeBagAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			ReadOnlySpan<byte> span = rebind.Span;
			decoded.BagId = asnValueReader.ReadObjectIdentifier();
			AsnValueReader asnValueReader2 = asnValueReader.ReadSequence(new Asn1Tag?(new Asn1Tag(TagClass.ContextSpecific, 0)));
			ReadOnlySpan<byte> destination = asnValueReader2.ReadEncodedValue();
			int start;
			decoded.BagValue = (span.Overlaps(destination, out start) ? rebind.Slice(start, destination.Length) : destination.ToArray());
			asnValueReader2.ThrowIfNotEmpty();
			if (asnValueReader.HasData && asnValueReader.PeekTag().HasSameClassAndValue(Asn1Tag.SetOf))
			{
				AsnValueReader asnValueReader3 = asnValueReader.ReadSetOf();
				List<AttributeAsn> list = new List<AttributeAsn>();
				while (asnValueReader3.HasData)
				{
					AttributeAsn item;
					AttributeAsn.Decode(ref asnValueReader3, rebind, out item);
					list.Add(item);
				}
				decoded.BagAttributes = list.ToArray();
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000E11 RID: 3601
		internal byte[] BagId;

		// Token: 0x04000E12 RID: 3602
		internal ReadOnlyMemory<byte> BagValue;

		// Token: 0x04000E13 RID: 3603
		internal AttributeAsn[] BagAttributes;
	}
}
