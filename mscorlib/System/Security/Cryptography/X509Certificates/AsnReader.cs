using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B3 RID: 691
	internal class AsnReader
	{
		// Token: 0x060024B1 RID: 9393 RVA: 0x00084E94 File Offset: 0x00083094
		public bool TryReadPrimitiveBitString(out int unusedBitCount, out ReadOnlyMemory<byte> value, Asn1Tag? expectedTag)
		{
			ReadOnlySpan<byte> smaller;
			int start;
			bool flag = AsnDecoder.TryReadPrimitiveBitString(this._data.Span, this.RuleSet, out unusedBitCount, out smaller, out start, expectedTag);
			if (flag)
			{
				value = AsnDecoder.Slice(this._data, smaller);
				this._data = this._data.Slice(start);
			}
			else
			{
				value = default(ReadOnlyMemory<byte>);
			}
			return flag;
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x00084EF0 File Offset: 0x000830F0
		public bool TryReadBitString(Span<byte> destination, out int unusedBitCount, out int bytesWritten, Asn1Tag? expectedTag)
		{
			int start;
			bool flag = AsnDecoder.TryReadBitString(this._data.Span, destination, this.RuleSet, out unusedBitCount, out start, out bytesWritten, expectedTag);
			if (flag)
			{
				this._data = this._data.Slice(start);
			}
			return flag;
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00084F34 File Offset: 0x00083134
		public byte[] ReadBitString(out int unusedBitCount, Asn1Tag? expectedTag)
		{
			int start;
			byte[] result = AsnDecoder.ReadBitString(this._data.Span, this.RuleSet, out unusedBitCount, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x060024B4 RID: 9396 RVA: 0x00084F6F File Offset: 0x0008316F
		public AsnEncodingRules RuleSet
		{
			get
			{
				return this._ruleSet;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x060024B5 RID: 9397 RVA: 0x00084F77 File Offset: 0x00083177
		public bool HasData
		{
			get
			{
				return !this._data.IsEmpty;
			}
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x00084F87 File Offset: 0x00083187
		public AsnReader(ReadOnlyMemory<byte> data, AsnEncodingRules ruleSet, AsnReaderOptions options)
		{
			AsnDecoder.CheckEncodingRules(ruleSet);
			this._data = data;
			this._ruleSet = ruleSet;
			this._options = options;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x00084FAC File Offset: 0x000831AC
		public AsnReader(ReadOnlyMemory<byte> data, AsnEncodingRules ruleSet) : this(data, ruleSet, default(AsnReaderOptions))
		{
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x00084FCA File Offset: 0x000831CA
		public void ThrowIfNotEmpty()
		{
			if (this.HasData)
			{
				throw new InvalidOperationException("The last expected value has been read, but the reader still has pending data. This value may be from a newer schema, or is corrupt.");
			}
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x00084FE0 File Offset: 0x000831E0
		public Asn1Tag PeekTag()
		{
			int num;
			return Asn1Tag.Decode(this._data.Span, out num);
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x00085000 File Offset: 0x00083200
		public ReadOnlyMemory<byte> PeekEncodedValue()
		{
			int num;
			int num2;
			int length;
			AsnDecoder.ReadEncodedValue(this._data.Span, this.RuleSet, out num, out num2, out length);
			return this._data.Slice(0, length);
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x00085038 File Offset: 0x00083238
		public ReadOnlyMemory<byte> PeekContentBytes()
		{
			int start;
			int length;
			int num;
			AsnDecoder.ReadEncodedValue(this._data.Span, this.RuleSet, out start, out length, out num);
			return this._data.Slice(start, length);
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x00085070 File Offset: 0x00083270
		public ReadOnlyMemory<byte> ReadEncodedValue()
		{
			ReadOnlyMemory<byte> result = this.PeekEncodedValue();
			this._data = this._data.Slice(result.Length);
			return result;
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x0008509D File Offset: 0x0008329D
		private AsnReader CloneAtSlice(int start, int length)
		{
			return new AsnReader(this._data.Slice(start, length), this.RuleSet, this._options);
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x000850C0 File Offset: 0x000832C0
		public ReadOnlyMemory<byte> ReadIntegerBytes(Asn1Tag? expectedTag)
		{
			int start;
			ReadOnlySpan<byte> smaller = AsnDecoder.ReadIntegerBytes(this._data.Span, this.RuleSet, out start, expectedTag);
			ReadOnlyMemory<byte> result = AsnDecoder.Slice(this._data, smaller);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x00085108 File Offset: 0x00083308
		public bool TryReadInt32(out int value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadInt32(this._data.Span, this.RuleSet, out value, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x00085144 File Offset: 0x00083344
		public bool TryReadUInt32(out uint value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadUInt32(this._data.Span, this.RuleSet, out value, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x00085180 File Offset: 0x00083380
		public bool TryReadInt64(out long value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadInt64(this._data.Span, this.RuleSet, out value, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x000851BC File Offset: 0x000833BC
		public bool TryReadUInt64(out ulong value, Asn1Tag? expectedTag)
		{
			int start;
			bool result = AsnDecoder.TryReadUInt64(this._data.Span, this.RuleSet, out value, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x000851F8 File Offset: 0x000833F8
		public void ReadNull(Asn1Tag? expectedTag)
		{
			int start;
			AsnDecoder.ReadNull(this._data.Span, this.RuleSet, out start, expectedTag);
			this._data = this._data.Slice(start);
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x00085230 File Offset: 0x00083430
		public bool TryReadOctetString(Span<byte> destination, out int bytesWritten, Asn1Tag? expectedTag)
		{
			int start;
			bool flag = AsnDecoder.TryReadOctetString(this._data.Span, destination, this.RuleSet, out start, out bytesWritten, expectedTag);
			if (flag)
			{
				this._data = this._data.Slice(start);
			}
			return flag;
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x00085270 File Offset: 0x00083470
		public byte[] ReadOctetString(Asn1Tag? expectedTag)
		{
			int start;
			byte[] result = AsnDecoder.ReadOctetString(this._data.Span, this.RuleSet, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x000852AC File Offset: 0x000834AC
		public bool TryReadPrimitiveOctetString(out ReadOnlyMemory<byte> contents, Asn1Tag? expectedTag)
		{
			ReadOnlySpan<byte> smaller;
			int start;
			bool flag = AsnDecoder.TryReadPrimitiveOctetString(this._data.Span, this.RuleSet, out smaller, out start, expectedTag);
			if (flag)
			{
				contents = AsnDecoder.Slice(this._data, smaller);
				this._data = this._data.Slice(start);
			}
			else
			{
				contents = default(ReadOnlyMemory<byte>);
			}
			return flag;
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x00085308 File Offset: 0x00083508
		public byte[] ReadObjectIdentifier(Asn1Tag? expectedTag)
		{
			int start;
			byte[] result = AsnDecoder.ReadObjectIdentifier(this._data.Span, this.RuleSet, out start, expectedTag);
			this._data = this._data.Slice(start);
			return result;
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x00085344 File Offset: 0x00083544
		public AsnReader ReadSequence(Asn1Tag? expectedTag)
		{
			int start;
			int length;
			int start2;
			AsnDecoder.ReadSequence(this._data.Span, this.RuleSet, out start, out length, out start2, expectedTag);
			AsnReader result = this.CloneAtSlice(start, length);
			this._data = this._data.Slice(start2);
			return result;
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x0008538C File Offset: 0x0008358C
		public AsnReader ReadSetOf(Asn1Tag? expectedTag)
		{
			return this.ReadSetOf(this._options.SkipSetSortOrderVerification, expectedTag);
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x000853B0 File Offset: 0x000835B0
		public AsnReader ReadSetOf(bool skipSortOrderValidation, Asn1Tag? expectedTag)
		{
			int start;
			int length;
			int start2;
			AsnDecoder.ReadSetOf(this._data.Span, this.RuleSet, out start, out length, out start2, skipSortOrderValidation, expectedTag);
			AsnReader result = this.CloneAtSlice(start, length);
			this._data = this._data.Slice(start2);
			return result;
		}

		// Token: 0x04000DB6 RID: 3510
		internal const int MaxCERSegmentSize = 1000;

		// Token: 0x04000DB7 RID: 3511
		private ReadOnlyMemory<byte> _data;

		// Token: 0x04000DB8 RID: 3512
		private readonly AsnReaderOptions _options;

		// Token: 0x04000DB9 RID: 3513
		private AsnEncodingRules _ruleSet;
	}
}
