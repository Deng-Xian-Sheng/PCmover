using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000927 RID: 2343
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibVarAttribute : Attribute
	{
		// Token: 0x06006015 RID: 24597 RVA: 0x0014B7D9 File Offset: 0x001499D9
		public TypeLibVarAttribute(TypeLibVarFlags flags)
		{
			this._val = flags;
		}

		// Token: 0x06006016 RID: 24598 RVA: 0x0014B7E8 File Offset: 0x001499E8
		public TypeLibVarAttribute(short flags)
		{
			this._val = (TypeLibVarFlags)flags;
		}

		// Token: 0x170010DE RID: 4318
		// (get) Token: 0x06006017 RID: 24599 RVA: 0x0014B7F7 File Offset: 0x001499F7
		public TypeLibVarFlags Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002AA2 RID: 10914
		internal TypeLibVarFlags _val;
	}
}
