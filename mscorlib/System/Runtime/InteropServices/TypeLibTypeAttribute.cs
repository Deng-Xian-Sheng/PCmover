using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000925 RID: 2341
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibTypeAttribute : Attribute
	{
		// Token: 0x0600600F RID: 24591 RVA: 0x0014B78D File Offset: 0x0014998D
		public TypeLibTypeAttribute(TypeLibTypeFlags flags)
		{
			this._val = flags;
		}

		// Token: 0x06006010 RID: 24592 RVA: 0x0014B79C File Offset: 0x0014999C
		public TypeLibTypeAttribute(short flags)
		{
			this._val = (TypeLibTypeFlags)flags;
		}

		// Token: 0x170010DC RID: 4316
		// (get) Token: 0x06006011 RID: 24593 RVA: 0x0014B7AB File Offset: 0x001499AB
		public TypeLibTypeFlags Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002AA0 RID: 10912
		internal TypeLibTypeFlags _val;
	}
}
