using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B1 RID: 689
	internal struct Asn1Tag : IEquatable<Asn1Tag>
	{
		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x0600246E RID: 9326 RVA: 0x00083376 File Offset: 0x00081576
		public TagClass TagClass
		{
			get
			{
				return (TagClass)(this._controlFlags & 192);
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x0600246F RID: 9327 RVA: 0x00083384 File Offset: 0x00081584
		public bool IsConstructed
		{
			get
			{
				return (this._controlFlags & 32) > 0;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06002470 RID: 9328 RVA: 0x00083392 File Offset: 0x00081592
		public int TagValue
		{
			get
			{
				return this._tagValue;
			}
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x0008339A File Offset: 0x0008159A
		private Asn1Tag(byte controlFlags, int tagValue)
		{
			this._controlFlags = (controlFlags & 224);
			this._tagValue = tagValue;
		}

		// Token: 0x06002472 RID: 9330 RVA: 0x000833B1 File Offset: 0x000815B1
		public Asn1Tag(UniversalTagNumber universalTagNumber, bool isConstructed)
		{
			this = new Asn1Tag(isConstructed ? 32 : 0, (int)universalTagNumber);
			if (universalTagNumber < UniversalTagNumber.EndOfContents || universalTagNumber > UniversalTagNumber.RelativeObjectIdentifierIRI || universalTagNumber == (UniversalTagNumber)15)
			{
				throw new ArgumentOutOfRangeException("universalTagNumber");
			}
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x000833DC File Offset: 0x000815DC
		public Asn1Tag(TagClass tagClass, int tagValue, bool isConstructed)
		{
			this = new Asn1Tag((byte)tagClass | (isConstructed ? 32 : 0), tagValue);
			if (tagClass <= TagClass.Application)
			{
				if (tagClass == TagClass.Universal || tagClass == TagClass.Application)
				{
					goto IL_3D;
				}
			}
			else if (tagClass == TagClass.ContextSpecific || tagClass == TagClass.Private)
			{
				goto IL_3D;
			}
			throw new ArgumentOutOfRangeException("tagClass");
			IL_3D:
			if (tagValue < 0)
			{
				throw new ArgumentOutOfRangeException("tagValue");
			}
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x00083435 File Offset: 0x00081635
		public Asn1Tag(TagClass tagClass, int tagValue)
		{
			this = new Asn1Tag(tagClass, tagValue, false);
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x00083440 File Offset: 0x00081640
		public Asn1Tag AsConstructed()
		{
			return new Asn1Tag(this._controlFlags | 32, this.TagValue);
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x00083458 File Offset: 0x00081658
		public static bool TryDecode(ReadOnlySpan<byte> source, out Asn1Tag tag, out int bytesConsumed)
		{
			tag = default(Asn1Tag);
			bytesConsumed = 0;
			if (source.IsEmpty)
			{
				return false;
			}
			byte b = source[bytesConsumed];
			bytesConsumed++;
			uint num = (uint)(b & 31);
			if (num == 31U)
			{
				num = 0U;
				while (source.Length > bytesConsumed)
				{
					byte b2 = source[bytesConsumed];
					byte b3 = b2 & 127;
					bytesConsumed++;
					if (num >= 33554432U)
					{
						bytesConsumed = 0;
						return false;
					}
					num <<= 7;
					num |= (uint)b3;
					if (num == 0U)
					{
						bytesConsumed = 0;
						return false;
					}
					if ((b2 & 128) != 128)
					{
						if (num <= 30U)
						{
							bytesConsumed = 0;
							return false;
						}
						if (num > 2147483647U)
						{
							bytesConsumed = 0;
							return false;
						}
						goto IL_99;
					}
				}
				bytesConsumed = 0;
				return false;
			}
			IL_99:
			tag = new Asn1Tag(b, (int)num);
			return true;
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x0008350C File Offset: 0x0008170C
		public static Asn1Tag Decode(ReadOnlySpan<byte> source, out int bytesConsumed)
		{
			Asn1Tag result;
			if (Asn1Tag.TryDecode(source, out result, out bytesConsumed))
			{
				return result;
			}
			throw new InvalidOperationException("The provided data does not represent a valid tag.");
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x00083530 File Offset: 0x00081730
		public bool Equals(Asn1Tag other)
		{
			return this._controlFlags == other._controlFlags && this.TagValue == other.TagValue;
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x00083551 File Offset: 0x00081751
		public override bool Equals(object obj)
		{
			return obj is Asn1Tag && this.Equals((Asn1Tag)obj);
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x00083569 File Offset: 0x00081769
		public override int GetHashCode()
		{
			return (int)this._controlFlags << 24 ^ this.TagValue;
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x0008357B File Offset: 0x0008177B
		public static bool operator ==(Asn1Tag left, Asn1Tag right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x00083585 File Offset: 0x00081785
		public static bool operator !=(Asn1Tag left, Asn1Tag right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x00083592 File Offset: 0x00081792
		public bool HasSameClassAndValue(Asn1Tag other)
		{
			return this.TagValue == other.TagValue && this.TagClass == other.TagClass;
		}

		// Token: 0x04000DA4 RID: 3492
		internal static readonly Asn1Tag EndOfContents = new Asn1Tag(0, 0);

		// Token: 0x04000DA5 RID: 3493
		public static readonly Asn1Tag Integer = new Asn1Tag(0, 2);

		// Token: 0x04000DA6 RID: 3494
		public static readonly Asn1Tag PrimitiveBitString = new Asn1Tag(0, 3);

		// Token: 0x04000DA7 RID: 3495
		public static readonly Asn1Tag ConstructedBitString = new Asn1Tag(32, 3);

		// Token: 0x04000DA8 RID: 3496
		public static readonly Asn1Tag PrimitiveOctetString = new Asn1Tag(0, 4);

		// Token: 0x04000DA9 RID: 3497
		public static readonly Asn1Tag ConstructedOctetString = new Asn1Tag(32, 4);

		// Token: 0x04000DAA RID: 3498
		public static readonly Asn1Tag Null = new Asn1Tag(0, 5);

		// Token: 0x04000DAB RID: 3499
		public static readonly Asn1Tag ObjectIdentifier = new Asn1Tag(0, 6);

		// Token: 0x04000DAC RID: 3500
		public static readonly Asn1Tag Sequence = new Asn1Tag(32, 16);

		// Token: 0x04000DAD RID: 3501
		public static readonly Asn1Tag SetOf = new Asn1Tag(32, 17);

		// Token: 0x04000DAE RID: 3502
		private const byte ClassMask = 192;

		// Token: 0x04000DAF RID: 3503
		private const byte ConstructedMask = 32;

		// Token: 0x04000DB0 RID: 3504
		private const byte ControlMask = 224;

		// Token: 0x04000DB1 RID: 3505
		private const byte TagNumberMask = 31;

		// Token: 0x04000DB2 RID: 3506
		private readonly byte _controlFlags;

		// Token: 0x04000DB3 RID: 3507
		private int _tagValue;
	}
}
