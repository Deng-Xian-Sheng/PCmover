using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B6 RID: 694
	internal struct AsnValueReader
	{
		// Token: 0x060024CF RID: 9423 RVA: 0x0008543F File Offset: 0x0008363F
		internal AsnValueReader(ReadOnlySpan<byte> span, AsnEncodingRules ruleSet)
		{
			this._span = span;
			this._ruleSet = ruleSet;
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x060024D0 RID: 9424 RVA: 0x0008544F File Offset: 0x0008364F
		internal bool HasData
		{
			get
			{
				return !this._span.IsEmpty;
			}
		}

		// Token: 0x060024D1 RID: 9425 RVA: 0x0008545F File Offset: 0x0008365F
		internal void ThrowIfNotEmpty()
		{
			if (!this._span.IsEmpty)
			{
				new AsnReader(AsnValueReader.s_singleByte, this._ruleSet).ThrowIfNotEmpty();
			}
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x00085488 File Offset: 0x00083688
		internal Asn1Tag PeekTag()
		{
			int num;
			return Asn1Tag.Decode(this._span, out num);
		}

		// Token: 0x060024D3 RID: 9427 RVA: 0x000854A4 File Offset: 0x000836A4
		internal ReadOnlySpan<byte> PeekContentBytes()
		{
			int start;
			int length;
			int num;
			AsnDecoder.ReadEncodedValue(this._span, this._ruleSet, out start, out length, out num);
			return this._span.Slice(start, length);
		}

		// Token: 0x060024D4 RID: 9428 RVA: 0x000854D8 File Offset: 0x000836D8
		internal ReadOnlySpan<byte> PeekEncodedValue()
		{
			int num;
			int num2;
			int length;
			AsnDecoder.ReadEncodedValue(this._span, this._ruleSet, out num, out num2, out length);
			return this._span.Slice(0, length);
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x0008550C File Offset: 0x0008370C
		internal ReadOnlySpan<byte> ReadEncodedValue()
		{
			ReadOnlySpan<byte> result = this.PeekEncodedValue();
			this._span = this._span.Slice(result.Length);
			return result;
		}

		// Token: 0x060024D6 RID: 9430 RVA: 0x0008553C File Offset: 0x0008373C
		internal bool TryReadInt32(out int value)
		{
			return this.TryReadInt32(out value, null);
		}

		// Token: 0x060024D7 RID: 9431 RVA: 0x0008555C File Offset: 0x0008375C
		internal bool TryReadInt32(out int value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadInt32(this._span, this._ruleSet, out value, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x00085594 File Offset: 0x00083794
		internal ReadOnlySpan<byte> ReadIntegerBytes()
		{
			return this.ReadIntegerBytes(null);
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x000855B0 File Offset: 0x000837B0
		internal ReadOnlySpan<byte> ReadIntegerBytes(Asn1Tag? expectedTag)
		{
			int start;
			ReadOnlySpan<byte> result = AsnDecoder.ReadIntegerBytes(this._span, this._ruleSet, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x000855E8 File Offset: 0x000837E8
		internal bool TryReadPrimitiveBitString(out int unusedBitCount, out ReadOnlySpan<byte> value)
		{
			return this.TryReadPrimitiveBitString(out unusedBitCount, out value, null);
		}

		// Token: 0x060024DB RID: 9435 RVA: 0x00085608 File Offset: 0x00083808
		internal bool TryReadPrimitiveBitString(out int unusedBitCount, out ReadOnlySpan<byte> value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadPrimitiveBitString(this._span, this._ruleSet, out unusedBitCount, out value, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024DC RID: 9436 RVA: 0x00085640 File Offset: 0x00083840
		internal byte[] ReadBitString(out int unusedBitCount)
		{
			return this.ReadBitString(out unusedBitCount, null);
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x00085660 File Offset: 0x00083860
		internal byte[] ReadBitString(out int unusedBitCount, Asn1Tag? expectedTag)
		{
			int start;
			byte[] result = AsnDecoder.ReadBitString(this._span, this._ruleSet, out unusedBitCount, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x00085698 File Offset: 0x00083898
		internal bool TryReadPrimitiveOctetString(out ReadOnlySpan<byte> value)
		{
			return this.TryReadPrimitiveOctetString(out value, null);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x000856B8 File Offset: 0x000838B8
		internal bool TryReadPrimitiveOctetString(out ReadOnlySpan<byte> value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadPrimitiveOctetString(this._span, this._ruleSet, out value, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x000856F0 File Offset: 0x000838F0
		internal byte[] ReadOctetString()
		{
			return this.ReadOctetString(null);
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x0008570C File Offset: 0x0008390C
		internal byte[] ReadOctetString(Asn1Tag? expectedTag)
		{
			int start;
			byte[] result = AsnDecoder.ReadOctetString(this._span, this._ruleSet, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x00085744 File Offset: 0x00083944
		internal byte[] ReadObjectIdentifier()
		{
			return this.ReadObjectIdentifier(null);
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x00085760 File Offset: 0x00083960
		internal byte[] ReadObjectIdentifier(Asn1Tag? expectedTag)
		{
			int start;
			byte[] result = AsnDecoder.ReadObjectIdentifier(this._span, this._ruleSet, out start, expectedTag);
			this._span = this._span.Slice(start);
			return result;
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x00085798 File Offset: 0x00083998
		internal AsnValueReader ReadSequence()
		{
			return this.ReadSequence(null);
		}

		// Token: 0x060024E5 RID: 9445 RVA: 0x000857B4 File Offset: 0x000839B4
		internal AsnValueReader ReadSequence(Asn1Tag? expectedTag)
		{
			int start;
			int length;
			int start2;
			AsnDecoder.ReadSequence(this._span, this._ruleSet, out start, out length, out start2, expectedTag);
			ReadOnlySpan<byte> span = this._span.Slice(start, length);
			this._span = this._span.Slice(start2);
			return new AsnValueReader(span, this._ruleSet);
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x00085808 File Offset: 0x00083A08
		internal AsnValueReader ReadSetOf()
		{
			return this.ReadSetOf(null, false);
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x00085825 File Offset: 0x00083A25
		internal AsnValueReader ReadSetOf(Asn1Tag? expectedTag)
		{
			return this.ReadSetOf(expectedTag, false);
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x00085830 File Offset: 0x00083A30
		internal AsnValueReader ReadSetOf(Asn1Tag? expectedTag, bool skipSortOrderValidation)
		{
			int start;
			int length;
			int start2;
			AsnDecoder.ReadSetOf(this._span, this._ruleSet, out start, out length, out start2, skipSortOrderValidation, expectedTag);
			ReadOnlySpan<byte> span = this._span.Slice(start, length);
			this._span = this._span.Slice(start2);
			return new AsnValueReader(span, this._ruleSet);
		}

		// Token: 0x04000DC1 RID: 3521
		private static readonly byte[] s_singleByte = new byte[1];

		// Token: 0x04000DC2 RID: 3522
		private ReadOnlySpan<byte> _span;

		// Token: 0x04000DC3 RID: 3523
		private readonly AsnEncodingRules _ruleSet;
	}
}
