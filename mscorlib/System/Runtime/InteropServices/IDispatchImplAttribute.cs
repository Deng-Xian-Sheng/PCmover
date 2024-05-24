using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200091F RID: 2335
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = false)]
	[Obsolete("This attribute is deprecated and will be removed in a future version.", false)]
	[ComVisible(true)]
	public sealed class IDispatchImplAttribute : Attribute
	{
		// Token: 0x06006005 RID: 24581 RVA: 0x0014B65D File Offset: 0x0014985D
		public IDispatchImplAttribute(IDispatchImplType implType)
		{
			this._val = implType;
		}

		// Token: 0x06006006 RID: 24582 RVA: 0x0014B66C File Offset: 0x0014986C
		public IDispatchImplAttribute(short implType)
		{
			this._val = (IDispatchImplType)implType;
		}

		// Token: 0x170010DA RID: 4314
		// (get) Token: 0x06006007 RID: 24583 RVA: 0x0014B67B File Offset: 0x0014987B
		public IDispatchImplType Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A73 RID: 10867
		internal IDispatchImplType _val;
	}
}
