using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200078B RID: 1931
	internal sealed class BinaryObjectWithMap : IStreamable
	{
		// Token: 0x060053FD RID: 21501 RVA: 0x00127D4D File Offset: 0x00125F4D
		internal BinaryObjectWithMap()
		{
		}

		// Token: 0x060053FE RID: 21502 RVA: 0x00127D55 File Offset: 0x00125F55
		internal BinaryObjectWithMap(BinaryHeaderEnum binaryHeaderEnum)
		{
			this.binaryHeaderEnum = binaryHeaderEnum;
		}

		// Token: 0x060053FF RID: 21503 RVA: 0x00127D64 File Offset: 0x00125F64
		internal void Set(int objectId, string name, int numMembers, string[] memberNames, int assemId)
		{
			this.objectId = objectId;
			this.name = name;
			this.numMembers = numMembers;
			this.memberNames = memberNames;
			this.assemId = assemId;
			if (assemId > 0)
			{
				this.binaryHeaderEnum = BinaryHeaderEnum.ObjectWithMapAssemId;
				return;
			}
			this.binaryHeaderEnum = BinaryHeaderEnum.ObjectWithMap;
		}

		// Token: 0x06005400 RID: 21504 RVA: 0x00127DA0 File Offset: 0x00125FA0
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte((byte)this.binaryHeaderEnum);
			sout.WriteInt32(this.objectId);
			sout.WriteString(this.name);
			sout.WriteInt32(this.numMembers);
			for (int i = 0; i < this.numMembers; i++)
			{
				sout.WriteString(this.memberNames[i]);
			}
			if (this.assemId > 0)
			{
				sout.WriteInt32(this.assemId);
			}
		}

		// Token: 0x06005401 RID: 21505 RVA: 0x00127E14 File Offset: 0x00126014
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.objectId = input.ReadInt32();
			this.name = input.ReadString();
			this.numMembers = input.ReadInt32();
			this.memberNames = new string[this.numMembers];
			for (int i = 0; i < this.numMembers; i++)
			{
				this.memberNames[i] = input.ReadString();
			}
			if (this.binaryHeaderEnum == BinaryHeaderEnum.ObjectWithMapAssemId)
			{
				this.assemId = input.ReadInt32();
			}
		}

		// Token: 0x06005402 RID: 21506 RVA: 0x00127E8A File Offset: 0x0012608A
		public void Dump()
		{
		}

		// Token: 0x06005403 RID: 21507 RVA: 0x00127E8C File Offset: 0x0012608C
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			if (BCLDebug.CheckEnabled("BINARY"))
			{
				for (int i = 0; i < this.numMembers; i++)
				{
				}
				BinaryHeaderEnum binaryHeaderEnum = this.binaryHeaderEnum;
			}
		}

		// Token: 0x040025E0 RID: 9696
		internal BinaryHeaderEnum binaryHeaderEnum;

		// Token: 0x040025E1 RID: 9697
		internal int objectId;

		// Token: 0x040025E2 RID: 9698
		internal string name;

		// Token: 0x040025E3 RID: 9699
		internal int numMembers;

		// Token: 0x040025E4 RID: 9700
		internal string[] memberNames;

		// Token: 0x040025E5 RID: 9701
		internal int assemId;
	}
}
