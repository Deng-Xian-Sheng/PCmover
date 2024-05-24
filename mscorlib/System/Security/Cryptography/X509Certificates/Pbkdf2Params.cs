using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002CA RID: 714
	internal struct Pbkdf2Params
	{
		// Token: 0x06002544 RID: 9540 RVA: 0x00087B50 File Offset: 0x00085D50
		internal static Pbkdf2Params Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return Pbkdf2Params.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x06002545 RID: 9541 RVA: 0x00087B60 File Offset: 0x00085D60
		internal static Pbkdf2Params Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			Pbkdf2Params result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				Pbkdf2Params pbkdf2Params;
				Pbkdf2Params.DecodeCore(ref asnValueReader, expectedTag, encoded, out pbkdf2Params);
				asnValueReader.ThrowIfNotEmpty();
				result = pbkdf2Params;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x06002546 RID: 9542 RVA: 0x00087BB0 File Offset: 0x00085DB0
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out Pbkdf2Params decoded)
		{
			Pbkdf2Params.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x06002547 RID: 9543 RVA: 0x00087BC0 File Offset: 0x00085DC0
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out Pbkdf2Params decoded)
		{
			try
			{
				Pbkdf2Params.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x06002548 RID: 9544 RVA: 0x00087BF8 File Offset: 0x00085DF8
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out Pbkdf2Params decoded)
		{
			decoded = default(Pbkdf2Params);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			Pbkdf2SaltChoice.Decode(ref asnValueReader, rebind, out decoded.Salt);
			if (!asnValueReader.TryReadInt32(out decoded.IterationCount))
			{
				asnValueReader.ThrowIfNotEmpty();
			}
			if (asnValueReader.HasData && asnValueReader.PeekTag().HasSameClassAndValue(Asn1Tag.Integer))
			{
				int value;
				if (asnValueReader.TryReadInt32(out value))
				{
					decoded.KeyLength = new int?(value);
				}
				else
				{
					asnValueReader.ThrowIfNotEmpty();
				}
			}
			if (asnValueReader.HasData && asnValueReader.PeekTag().HasSameClassAndValue(Asn1Tag.Sequence))
			{
				AlgorithmIdentifierAsn.Decode(ref asnValueReader, rebind, out decoded.Prf);
			}
			else
			{
				AsnValueReader asnValueReader2 = new AsnValueReader(Pbkdf2Params.s_DefaultPrf, AsnEncodingRules.DER);
				AlgorithmIdentifierAsn.Decode(ref asnValueReader2, rebind, out decoded.Prf);
			}
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000E03 RID: 3587
		private static readonly byte[] s_DefaultPrf = new byte[]
		{
			48,
			12,
			6,
			8,
			42,
			134,
			72,
			134,
			247,
			13,
			2,
			7,
			5,
			0
		};

		// Token: 0x04000E04 RID: 3588
		internal Pbkdf2SaltChoice Salt;

		// Token: 0x04000E05 RID: 3589
		internal int IterationCount;

		// Token: 0x04000E06 RID: 3590
		internal int? KeyLength;

		// Token: 0x04000E07 RID: 3591
		internal AlgorithmIdentifierAsn Prf;
	}
}
