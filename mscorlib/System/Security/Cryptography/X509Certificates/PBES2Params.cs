using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002C9 RID: 713
	internal struct PBES2Params
	{
		// Token: 0x0600253F RID: 9535 RVA: 0x00087A64 File Offset: 0x00085C64
		internal static PBES2Params Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			return PBES2Params.Decode(Asn1Tag.Sequence, encoded, ruleSet);
		}

		// Token: 0x06002540 RID: 9536 RVA: 0x00087A74 File Offset: 0x00085C74
		internal static PBES2Params Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
		{
			PBES2Params result;
			try
			{
				AsnValueReader asnValueReader = new AsnValueReader(encoded.Span, ruleSet);
				PBES2Params pbes2Params;
				PBES2Params.DecodeCore(ref asnValueReader, expectedTag, encoded, out pbes2Params);
				asnValueReader.ThrowIfNotEmpty();
				result = pbes2Params;
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
			return result;
		}

		// Token: 0x06002541 RID: 9537 RVA: 0x00087AC4 File Offset: 0x00085CC4
		internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out PBES2Params decoded)
		{
			PBES2Params.Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
		}

		// Token: 0x06002542 RID: 9538 RVA: 0x00087AD4 File Offset: 0x00085CD4
		internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out PBES2Params decoded)
		{
			try
			{
				PBES2Params.DecodeCore(ref reader, expectedTag, rebind, out decoded);
			}
			catch (InvalidOperationException inner)
			{
				throw new CryptographicException("ASN1 corrupted data.", inner);
			}
		}

		// Token: 0x06002543 RID: 9539 RVA: 0x00087B0C File Offset: 0x00085D0C
		private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out PBES2Params decoded)
		{
			decoded = default(PBES2Params);
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag?(expectedTag));
			AlgorithmIdentifierAsn.Decode(ref asnValueReader, rebind, out decoded.KeyDerivationFunc);
			AlgorithmIdentifierAsn.Decode(ref asnValueReader, rebind, out decoded.EncryptionScheme);
			asnValueReader.ThrowIfNotEmpty();
		}

		// Token: 0x04000E01 RID: 3585
		internal AlgorithmIdentifierAsn KeyDerivationFunc;

		// Token: 0x04000E02 RID: 3586
		internal AlgorithmIdentifierAsn EncryptionScheme;
	}
}
