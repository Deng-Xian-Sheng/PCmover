using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000790 RID: 1936
	internal sealed class ObjectNull : IStreamable
	{
		// Token: 0x0600541B RID: 21531 RVA: 0x001285E1 File Offset: 0x001267E1
		internal ObjectNull()
		{
		}

		// Token: 0x0600541C RID: 21532 RVA: 0x001285E9 File Offset: 0x001267E9
		internal void SetNullCount(int nullCount)
		{
			this.nullCount = nullCount;
		}

		// Token: 0x0600541D RID: 21533 RVA: 0x001285F4 File Offset: 0x001267F4
		public void Write(__BinaryWriter sout)
		{
			if (this.nullCount == 1)
			{
				sout.WriteByte(10);
				return;
			}
			if (this.nullCount < 256)
			{
				sout.WriteByte(13);
				sout.WriteByte((byte)this.nullCount);
				return;
			}
			sout.WriteByte(14);
			sout.WriteInt32(this.nullCount);
		}

		// Token: 0x0600541E RID: 21534 RVA: 0x0012864A File Offset: 0x0012684A
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.Read(input, BinaryHeaderEnum.ObjectNull);
		}

		// Token: 0x0600541F RID: 21535 RVA: 0x00128658 File Offset: 0x00126858
		public void Read(__BinaryParser input, BinaryHeaderEnum binaryHeaderEnum)
		{
			switch (binaryHeaderEnum)
			{
			case BinaryHeaderEnum.ObjectNull:
				this.nullCount = 1;
				return;
			case BinaryHeaderEnum.MessageEnd:
			case BinaryHeaderEnum.Assembly:
				break;
			case BinaryHeaderEnum.ObjectNullMultiple256:
				this.nullCount = (int)input.ReadByte();
				return;
			case BinaryHeaderEnum.ObjectNullMultiple:
				this.nullCount = input.ReadInt32();
				break;
			default:
				return;
			}
		}

		// Token: 0x06005420 RID: 21536 RVA: 0x001286A4 File Offset: 0x001268A4
		public void Dump()
		{
		}

		// Token: 0x06005421 RID: 21537 RVA: 0x001286A6 File Offset: 0x001268A6
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			if (BCLDebug.CheckEnabled("BINARY") && this.nullCount != 1)
			{
				int num = this.nullCount;
			}
		}

		// Token: 0x040025FB RID: 9723
		internal int nullCount;
	}
}
