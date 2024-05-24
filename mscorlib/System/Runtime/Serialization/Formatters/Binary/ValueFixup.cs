using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000799 RID: 1945
	internal sealed class ValueFixup
	{
		// Token: 0x06005451 RID: 21585 RVA: 0x00129209 File Offset: 0x00127409
		internal ValueFixup(Array arrayObj, int[] indexMap)
		{
			this.valueFixupEnum = ValueFixupEnum.Array;
			this.arrayObj = arrayObj;
			this.indexMap = indexMap;
		}

		// Token: 0x06005452 RID: 21586 RVA: 0x00129226 File Offset: 0x00127426
		internal ValueFixup(object memberObject, string memberName, ReadObjectInfo objectInfo)
		{
			this.valueFixupEnum = ValueFixupEnum.Member;
			this.memberObject = memberObject;
			this.memberName = memberName;
			this.objectInfo = objectInfo;
		}

		// Token: 0x06005453 RID: 21587 RVA: 0x0012924C File Offset: 0x0012744C
		[SecurityCritical]
		internal void Fixup(ParseRecord record, ParseRecord parent)
		{
			object prnewObj = record.PRnewObj;
			switch (this.valueFixupEnum)
			{
			case ValueFixupEnum.Array:
				this.arrayObj.SetValue(prnewObj, this.indexMap);
				return;
			case ValueFixupEnum.Header:
			{
				Type typeFromHandle = typeof(Header);
				if (ValueFixup.valueInfo == null)
				{
					MemberInfo[] member = typeFromHandle.GetMember("Value");
					if (member.Length != 1)
					{
						throw new SerializationException(Environment.GetResourceString("Serialization_HeaderReflection", new object[]
						{
							member.Length
						}));
					}
					ValueFixup.valueInfo = member[0];
				}
				FormatterServices.SerializationSetValue(ValueFixup.valueInfo, this.header, prnewObj);
				return;
			}
			case ValueFixupEnum.Member:
			{
				if (this.objectInfo.isSi)
				{
					this.objectInfo.objectManager.RecordDelayedFixup(parent.PRobjectId, this.memberName, record.PRobjectId);
					return;
				}
				MemberInfo memberInfo = this.objectInfo.GetMemberInfo(this.memberName);
				if (memberInfo != null)
				{
					this.objectInfo.objectManager.RecordFixup(parent.PRobjectId, memberInfo, record.PRobjectId);
				}
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x04002651 RID: 9809
		internal ValueFixupEnum valueFixupEnum;

		// Token: 0x04002652 RID: 9810
		internal Array arrayObj;

		// Token: 0x04002653 RID: 9811
		internal int[] indexMap;

		// Token: 0x04002654 RID: 9812
		internal object header;

		// Token: 0x04002655 RID: 9813
		internal object memberObject;

		// Token: 0x04002656 RID: 9814
		internal static volatile MemberInfo valueInfo;

		// Token: 0x04002657 RID: 9815
		internal ReadObjectInfo objectInfo;

		// Token: 0x04002658 RID: 9816
		internal string memberName;
	}
}
