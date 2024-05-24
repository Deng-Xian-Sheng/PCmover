using System;
using System.Diagnostics;
using System.IO;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000781 RID: 1921
	internal sealed class SerializationHeaderRecord : IStreamable
	{
		// Token: 0x060053C0 RID: 21440 RVA: 0x00126DCB File Offset: 0x00124FCB
		internal SerializationHeaderRecord()
		{
		}

		// Token: 0x060053C1 RID: 21441 RVA: 0x00126DDA File Offset: 0x00124FDA
		internal SerializationHeaderRecord(BinaryHeaderEnum binaryHeaderEnum, int topId, int headerId, int majorVersion, int minorVersion)
		{
			this.binaryHeaderEnum = binaryHeaderEnum;
			this.topId = topId;
			this.headerId = headerId;
			this.majorVersion = majorVersion;
			this.minorVersion = minorVersion;
		}

		// Token: 0x060053C2 RID: 21442 RVA: 0x00126E10 File Offset: 0x00125010
		public void Write(__BinaryWriter sout)
		{
			this.majorVersion = this.binaryFormatterMajorVersion;
			this.minorVersion = this.binaryFormatterMinorVersion;
			sout.WriteByte((byte)this.binaryHeaderEnum);
			sout.WriteInt32(this.topId);
			sout.WriteInt32(this.headerId);
			sout.WriteInt32(this.binaryFormatterMajorVersion);
			sout.WriteInt32(this.binaryFormatterMinorVersion);
		}

		// Token: 0x060053C3 RID: 21443 RVA: 0x00126E72 File Offset: 0x00125072
		private static int GetInt32(byte[] buffer, int index)
		{
			return (int)buffer[index] | (int)buffer[index + 1] << 8 | (int)buffer[index + 2] << 16 | (int)buffer[index + 3] << 24;
		}

		// Token: 0x060053C4 RID: 21444 RVA: 0x00126E94 File Offset: 0x00125094
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			byte[] array = input.ReadBytes(17);
			if (array.Length < 17)
			{
				__Error.EndOfFile();
			}
			this.majorVersion = SerializationHeaderRecord.GetInt32(array, 9);
			if (this.majorVersion > this.binaryFormatterMajorVersion)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_InvalidFormat", new object[]
				{
					BitConverter.ToString(array)
				}));
			}
			this.binaryHeaderEnum = (BinaryHeaderEnum)array[0];
			this.topId = SerializationHeaderRecord.GetInt32(array, 1);
			this.headerId = SerializationHeaderRecord.GetInt32(array, 5);
			this.minorVersion = SerializationHeaderRecord.GetInt32(array, 13);
		}

		// Token: 0x060053C5 RID: 21445 RVA: 0x00126F22 File Offset: 0x00125122
		public void Dump()
		{
		}

		// Token: 0x060053C6 RID: 21446 RVA: 0x00126F24 File Offset: 0x00125124
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025B3 RID: 9651
		internal int binaryFormatterMajorVersion = 1;

		// Token: 0x040025B4 RID: 9652
		internal int binaryFormatterMinorVersion;

		// Token: 0x040025B5 RID: 9653
		internal BinaryHeaderEnum binaryHeaderEnum;

		// Token: 0x040025B6 RID: 9654
		internal int topId;

		// Token: 0x040025B7 RID: 9655
		internal int headerId;

		// Token: 0x040025B8 RID: 9656
		internal int majorVersion;

		// Token: 0x040025B9 RID: 9657
		internal int minorVersion;
	}
}
