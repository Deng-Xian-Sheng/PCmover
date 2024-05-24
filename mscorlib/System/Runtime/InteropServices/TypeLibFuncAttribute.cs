using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000926 RID: 2342
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibFuncAttribute : Attribute
	{
		// Token: 0x06006012 RID: 24594 RVA: 0x0014B7B3 File Offset: 0x001499B3
		public TypeLibFuncAttribute(TypeLibFuncFlags flags)
		{
			this._val = flags;
		}

		// Token: 0x06006013 RID: 24595 RVA: 0x0014B7C2 File Offset: 0x001499C2
		public TypeLibFuncAttribute(short flags)
		{
			this._val = (TypeLibFuncFlags)flags;
		}

		// Token: 0x170010DD RID: 4317
		// (get) Token: 0x06006014 RID: 24596 RVA: 0x0014B7D1 File Offset: 0x001499D1
		public TypeLibFuncFlags Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002AA1 RID: 10913
		internal TypeLibFuncFlags _val;
	}
}
