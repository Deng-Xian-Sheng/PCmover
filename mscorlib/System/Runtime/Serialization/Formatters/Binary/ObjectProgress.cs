using System;
using System.Diagnostics;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000793 RID: 1939
	internal sealed class ObjectProgress
	{
		// Token: 0x0600542D RID: 21549 RVA: 0x00128960 File Offset: 0x00126B60
		internal ObjectProgress()
		{
		}

		// Token: 0x0600542E RID: 21550 RVA: 0x0012897C File Offset: 0x00126B7C
		[Conditional("SER_LOGGING")]
		private void Counter()
		{
			lock (this)
			{
				this.opRecordId = ObjectProgress.opRecordIdCount++;
				if (ObjectProgress.opRecordIdCount > 1000)
				{
					ObjectProgress.opRecordIdCount = 1;
				}
			}
		}

		// Token: 0x0600542F RID: 21551 RVA: 0x001289D8 File Offset: 0x00126BD8
		internal void Init()
		{
			this.isInitial = false;
			this.count = 0;
			this.expectedType = BinaryTypeEnum.ObjectUrt;
			this.expectedTypeInformation = null;
			this.name = null;
			this.objectTypeEnum = InternalObjectTypeE.Empty;
			this.memberTypeEnum = InternalMemberTypeE.Empty;
			this.memberValueEnum = InternalMemberValueE.Empty;
			this.dtType = null;
			this.numItems = 0;
			this.nullCount = 0;
			this.typeInformation = null;
			this.memberLength = 0;
			this.binaryTypeEnumA = null;
			this.typeInformationA = null;
			this.memberNames = null;
			this.memberTypes = null;
			this.pr.Init();
		}

		// Token: 0x06005430 RID: 21552 RVA: 0x00128A67 File Offset: 0x00126C67
		internal void ArrayCountIncrement(int value)
		{
			this.count += value;
		}

		// Token: 0x06005431 RID: 21553 RVA: 0x00128A78 File Offset: 0x00126C78
		internal bool GetNext(out BinaryTypeEnum outBinaryTypeEnum, out object outTypeInformation)
		{
			outBinaryTypeEnum = BinaryTypeEnum.Primitive;
			outTypeInformation = null;
			if (this.objectTypeEnum == InternalObjectTypeE.Array)
			{
				if (this.count == this.numItems)
				{
					return false;
				}
				outBinaryTypeEnum = this.binaryTypeEnum;
				outTypeInformation = this.typeInformation;
				if (this.count == 0)
				{
					this.isInitial = false;
				}
				this.count++;
				return true;
			}
			else
			{
				if (this.count == this.memberLength && !this.isInitial)
				{
					return false;
				}
				outBinaryTypeEnum = this.binaryTypeEnumA[this.count];
				outTypeInformation = this.typeInformationA[this.count];
				if (this.count == 0)
				{
					this.isInitial = false;
				}
				this.name = this.memberNames[this.count];
				Type[] array = this.memberTypes;
				this.dtType = this.memberTypes[this.count];
				this.count++;
				return true;
			}
		}

		// Token: 0x04002607 RID: 9735
		internal static int opRecordIdCount = 1;

		// Token: 0x04002608 RID: 9736
		internal int opRecordId;

		// Token: 0x04002609 RID: 9737
		internal bool isInitial;

		// Token: 0x0400260A RID: 9738
		internal int count;

		// Token: 0x0400260B RID: 9739
		internal BinaryTypeEnum expectedType = BinaryTypeEnum.ObjectUrt;

		// Token: 0x0400260C RID: 9740
		internal object expectedTypeInformation;

		// Token: 0x0400260D RID: 9741
		internal string name;

		// Token: 0x0400260E RID: 9742
		internal InternalObjectTypeE objectTypeEnum;

		// Token: 0x0400260F RID: 9743
		internal InternalMemberTypeE memberTypeEnum;

		// Token: 0x04002610 RID: 9744
		internal InternalMemberValueE memberValueEnum;

		// Token: 0x04002611 RID: 9745
		internal Type dtType;

		// Token: 0x04002612 RID: 9746
		internal int numItems;

		// Token: 0x04002613 RID: 9747
		internal BinaryTypeEnum binaryTypeEnum;

		// Token: 0x04002614 RID: 9748
		internal object typeInformation;

		// Token: 0x04002615 RID: 9749
		internal int nullCount;

		// Token: 0x04002616 RID: 9750
		internal int memberLength;

		// Token: 0x04002617 RID: 9751
		internal BinaryTypeEnum[] binaryTypeEnumA;

		// Token: 0x04002618 RID: 9752
		internal object[] typeInformationA;

		// Token: 0x04002619 RID: 9753
		internal string[] memberNames;

		// Token: 0x0400261A RID: 9754
		internal Type[] memberTypes;

		// Token: 0x0400261B RID: 9755
		internal ParseRecord pr = new ParseRecord();
	}
}
