using System;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200078C RID: 1932
	internal sealed class BinaryObjectWithMapTyped : IStreamable
	{
		// Token: 0x06005404 RID: 21508 RVA: 0x00127EBF File Offset: 0x001260BF
		internal BinaryObjectWithMapTyped()
		{
		}

		// Token: 0x06005405 RID: 21509 RVA: 0x00127EC7 File Offset: 0x001260C7
		internal BinaryObjectWithMapTyped(BinaryHeaderEnum binaryHeaderEnum)
		{
			this.binaryHeaderEnum = binaryHeaderEnum;
		}

		// Token: 0x06005406 RID: 21510 RVA: 0x00127ED8 File Offset: 0x001260D8
		internal void Set(int objectId, string name, int numMembers, string[] memberNames, BinaryTypeEnum[] binaryTypeEnumA, object[] typeInformationA, int[] memberAssemIds, int assemId)
		{
			this.objectId = objectId;
			this.assemId = assemId;
			this.name = name;
			this.numMembers = numMembers;
			this.memberNames = memberNames;
			this.binaryTypeEnumA = binaryTypeEnumA;
			this.typeInformationA = typeInformationA;
			this.memberAssemIds = memberAssemIds;
			this.assemId = assemId;
			if (assemId > 0)
			{
				this.binaryHeaderEnum = BinaryHeaderEnum.ObjectWithMapTypedAssemId;
				return;
			}
			this.binaryHeaderEnum = BinaryHeaderEnum.ObjectWithMapTyped;
		}

		// Token: 0x06005407 RID: 21511 RVA: 0x00127F40 File Offset: 0x00126140
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
			for (int j = 0; j < this.numMembers; j++)
			{
				sout.WriteByte((byte)this.binaryTypeEnumA[j]);
			}
			for (int k = 0; k < this.numMembers; k++)
			{
				BinaryConverter.WriteTypeInfo(this.binaryTypeEnumA[k], this.typeInformationA[k], this.memberAssemIds[k], sout);
			}
			if (this.assemId > 0)
			{
				sout.WriteInt32(this.assemId);
			}
		}

		// Token: 0x06005408 RID: 21512 RVA: 0x00128004 File Offset: 0x00126204
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.objectId = input.ReadInt32();
			this.name = input.ReadString();
			this.numMembers = input.ReadInt32();
			this.memberNames = new string[this.numMembers];
			this.binaryTypeEnumA = new BinaryTypeEnum[this.numMembers];
			this.typeInformationA = new object[this.numMembers];
			this.memberAssemIds = new int[this.numMembers];
			for (int i = 0; i < this.numMembers; i++)
			{
				this.memberNames[i] = input.ReadString();
			}
			for (int j = 0; j < this.numMembers; j++)
			{
				this.binaryTypeEnumA[j] = (BinaryTypeEnum)input.ReadByte();
			}
			for (int k = 0; k < this.numMembers; k++)
			{
				if (this.binaryTypeEnumA[k] != BinaryTypeEnum.ObjectUrt && this.binaryTypeEnumA[k] != BinaryTypeEnum.ObjectUser)
				{
					this.typeInformationA[k] = BinaryConverter.ReadTypeInfo(this.binaryTypeEnumA[k], input, out this.memberAssemIds[k]);
				}
				else
				{
					BinaryConverter.ReadTypeInfo(this.binaryTypeEnumA[k], input, out this.memberAssemIds[k]);
				}
			}
			if (this.binaryHeaderEnum == BinaryHeaderEnum.ObjectWithMapTypedAssemId)
			{
				this.assemId = input.ReadInt32();
			}
		}

		// Token: 0x040025E6 RID: 9702
		internal BinaryHeaderEnum binaryHeaderEnum;

		// Token: 0x040025E7 RID: 9703
		internal int objectId;

		// Token: 0x040025E8 RID: 9704
		internal string name;

		// Token: 0x040025E9 RID: 9705
		internal int numMembers;

		// Token: 0x040025EA RID: 9706
		internal string[] memberNames;

		// Token: 0x040025EB RID: 9707
		internal BinaryTypeEnum[] binaryTypeEnumA;

		// Token: 0x040025EC RID: 9708
		internal object[] typeInformationA;

		// Token: 0x040025ED RID: 9709
		internal int[] memberAssemIds;

		// Token: 0x040025EE RID: 9710
		internal int assemId;
	}
}
