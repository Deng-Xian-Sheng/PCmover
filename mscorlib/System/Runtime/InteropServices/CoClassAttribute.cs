using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000939 RID: 2361
	[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class CoClassAttribute : Attribute
	{
		// Token: 0x0600604A RID: 24650 RVA: 0x0014BDF9 File Offset: 0x00149FF9
		[__DynamicallyInvokable]
		public CoClassAttribute(Type coClass)
		{
			this._CoClass = coClass;
		}

		// Token: 0x170010E9 RID: 4329
		// (get) Token: 0x0600604B RID: 24651 RVA: 0x0014BE08 File Offset: 0x0014A008
		[__DynamicallyInvokable]
		public Type CoClass
		{
			[__DynamicallyInvokable]
			get
			{
				return this._CoClass;
			}
		}

		// Token: 0x04002B1E RID: 11038
		internal Type _CoClass;
	}
}
