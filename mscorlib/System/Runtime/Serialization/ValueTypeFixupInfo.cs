using System;
using System.Reflection;

namespace System.Runtime.Serialization
{
	// Token: 0x0200075B RID: 1883
	internal class ValueTypeFixupInfo
	{
		// Token: 0x060052EF RID: 21231 RVA: 0x00123A48 File Offset: 0x00121C48
		public ValueTypeFixupInfo(long containerID, FieldInfo member, int[] parentIndex)
		{
			if (member == null && parentIndex == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustSupplyParent"));
			}
			if (containerID == 0L && member == null)
			{
				this.m_containerID = containerID;
				this.m_parentField = member;
				this.m_parentIndex = parentIndex;
			}
			if (member != null)
			{
				if (parentIndex != null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MemberAndArray"));
				}
				if (member.FieldType.IsValueType && containerID == 0L)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MustSupplyContainer"));
				}
			}
			this.m_containerID = containerID;
			this.m_parentField = member;
			this.m_parentIndex = parentIndex;
		}

		// Token: 0x17000DB5 RID: 3509
		// (get) Token: 0x060052F0 RID: 21232 RVA: 0x00123AE9 File Offset: 0x00121CE9
		public long ContainerID
		{
			get
			{
				return this.m_containerID;
			}
		}

		// Token: 0x17000DB6 RID: 3510
		// (get) Token: 0x060052F1 RID: 21233 RVA: 0x00123AF1 File Offset: 0x00121CF1
		public FieldInfo ParentField
		{
			get
			{
				return this.m_parentField;
			}
		}

		// Token: 0x17000DB7 RID: 3511
		// (get) Token: 0x060052F2 RID: 21234 RVA: 0x00123AF9 File Offset: 0x00121CF9
		public int[] ParentIndex
		{
			get
			{
				return this.m_parentIndex;
			}
		}

		// Token: 0x040024C2 RID: 9410
		private long m_containerID;

		// Token: 0x040024C3 RID: 9411
		private FieldInfo m_parentField;

		// Token: 0x040024C4 RID: 9412
		private int[] m_parentIndex;
	}
}
