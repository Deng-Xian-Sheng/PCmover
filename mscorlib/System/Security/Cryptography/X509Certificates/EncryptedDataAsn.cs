using System;
using System.Collections.Generic;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C5 RID: 709
	internal struct EncryptedDataAsn
	{
		// Token: 0x0600252A RID: 9514 RVA: 0x000874E8 File Offset: 0x000856E8
		internal static EncryptedDataAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return EncryptedDataAsn.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x000874F8 File Offset: 0x000856F8
		internal static EncryptedDataAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			EncryptedDataAsn result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				EncryptedDataAsn encryptedDataAsn;
				EncryptedDataAsn.DecodeCore(ref asnValueReader, expectedTag, encoded, out encryptedDataAsn);
				asnValueReader.ThrowIfNotEmpty();
				result = encryptedDataAsn;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x00087548 File Offset: 0x00085748
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out EncryptedDataAsn decoded)
		{
			EncryptedDataAsn.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x00087558 File Offset: 0x00085758
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out EncryptedDataAsn decoded)
		{
			try
			{
				EncryptedDataAsn.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x00087590 File Offset: 0x00085790
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out EncryptedDataAsn decoded)
		{
			decoded = default(EncryptedDataAsn);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			if (!asnValueReader.TryReadInt32(out decoded.Version))
			{
				asnValueReader.ThrowIfNotEmpty();
			}
			EncryptedContentInfoAsn.Decode(ref asnValueReader, rebind, out decoded.EncryptedContentInfo);
			if (asnValueReader.HasData && asnValueReader.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 1)))
			{
				AsnValueReader asnValueReader2 = asnValueReader.ReadSetOf(new Asn1Tag?(new Asn1Tag(TagClass.ContextSpecific, 1)));
				List<AttributeAsn> list = new List<AttributeAsn>();
				while (asnValueReader2.HasData)
				{
					AttributeAsn item;
					AttributeAsn.Decode(ref asnValueReader2, rebind, out item);
					list.Add(item);
				}
				decoded.UnprotectedAttributes = list.ToArray();
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000DF6 RID: 3574
		internal int Version;

		// Token: 0x04000DF7 RID: 3575
		internal EncryptedContentInfoAsn EncryptedContentInfo;

		// Token: 0x04000DF8 RID: 3576
		internal AttributeAsn[] UnprotectedAttributes;
	}
}
